using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RustCrossbreeder.Logging;

namespace RustCrossbreeder.Data
{
	/// <summary>
	/// Contains data from collected seeds
	/// </summary>
	public class SeedManager
	{
		#region Constants

		/// <summary>
		/// Denotes the maximum amount of worker threads
		/// </summary>
		private const int MAX_BREEDER_THREADS = 100;

		/// <summary>
		/// Denotes how many crossbreed operations occur in a batch (executed on a different thread)
		/// </summary>
		private const int CROSSBREED_BATCH_SIZE = 5000;

		#endregion

		#region Fields

		/// <summary>
		/// Retains seed information
		/// </summary>
		private ISeedStore _seedStore;

		/// <summary>
		/// The currently selected seed catalog
		/// </summary>
		private int _activeCatalogId;

		/// <summary>
		/// The currently selected seed type
		/// </summary>
		private Seed.SeedTypes _activeSeedType;

		/// <summary>
		/// The minimum amount of parents required for a crossbreed
		/// </summary>
		private const int MinimumParents = 2;

		/// <summary>
		/// The hard maximum of parents that can be involved in a crossbreed.  This is limited by the slots in a large planter
		/// </summary>
		private const int MaximumParents = 8;

		/// <summary>
		/// The worker thread used to process the auto crossbreed so that we don't hang up the UI thread while doing work
		/// </summary>
		private Thread _workerThread;

		/// <summary>
		/// Denotes the current amount of breeder worker threads
		/// </summary>
		private int _breederThreadCount;

		/// <summary>
		/// An access control object to manage breeder thread count
		/// </summary>
		private object _breederLock = new object();

		/// <summary>
		/// A temporary cache of seeds used to speed up crossbreeding. Used to store the intermediate Seeds before being pushed to the database.
		/// NOTE: This dictionary is used for deduplication in C# so we don't have to execute duplicate SQL Queries on existing seeds.
		/// </summary>
		private ConcurrentDictionary<string, Seed> _seedCache = new ConcurrentDictionary<string, Seed>();

		#endregion

		#region Events

		/// <summary>
		/// Event that indicates that the active seed type has been updated
		/// </summary>
		public event Action ActiveSeedTypeUpdated;

		/// <summary>
		/// Event that indicates that the active catalog has updated
		/// </summary>
		public event Action ActiveCatalogUpdated;

		/// <summary>
		/// Signals that an AutoCrossBreed operation has finished
		/// </summary>
		public event Action AutoCrossBreedCompleted;

		/// <summary>
		/// Signal an error
		/// </summary>
		public event ErrorMessageDelegate DisplayError;

		#endregion

		#region Delegates

		/// <summary>
		/// Delegate used to display error messages to the form
		/// </summary>
		/// <param name="error"></param>
		public delegate void ErrorMessageDelegate(string error);

		#endregion

		#region Properties

		/// <summary>
		/// Returns the current breeder count in a thread safe way
		/// </summary>
		private int BreederThreadCount
		{
			get { lock (this._breederLock) { return this._breederThreadCount; } }
			set { lock (this._breederLock) { this._breederThreadCount = value; } }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Create a new seed manager
		/// </summary>
		public SeedManager(ISeedStore seedStore)
		{
			this._seedStore = seedStore;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Add a seed to the SeedStore
		/// </summary>
		/// <param name="seed"></param>
		public void AddSeed(Seed seed)
		{
			this._seedStore.StoreSeed(seed);
		}

		/// <summary>
		/// Add an array of seeds to the SeedStore
		/// </summary>
		/// <param name="seeds"></param>
		public void AddSeed(IEnumerable<Seed> seeds)
		{
			foreach (var seed in seeds)
			{
				this._seedStore.StoreSeed(seed);
			}
		}

		/// <summary>
		/// Remove the specified input seed from the SeedStore
		/// </summary>
		/// <param name="seed"></param>
		public void RemoveSeed(Seed seed)
		{
			this._seedStore.DeleteSeed(seed);
		}

		/// <summary>
		/// Return a list of stored seeds of the active type and catalog
		/// </summary>
		/// <returns></returns>
		public Seed[] GetActiveSeeds()
		{
			return this._seedStore.GetSeeds(this._activeSeedType, this._activeCatalogId);
		}

		/// <summary>
		/// Start a new thread which will auto-crossbreed the specified seeds.  When results are done an event will trigger the input data source to update
		/// </summary>
		/// <param name="seeds"></param>
		/// <param name="generations"></param>
		/// <param name="maxParents"></param>
		public bool StartAutoCrossBreed(Seed[] seeds, int generations, int maxParents)
		{
			if (this._workerThread != null && this._workerThread.IsAlive)
			{
				Logger.Instance.Log(Logger.Severity.Info, $"{nameof(SeedManager)} rejecting StartAutoCrossBreed request because worker thread is busy.");
				return false;
			}

			Logger.Instance.Log(Logger.Severity.Info, $"{nameof(SeedManager)} starting AutoCrossBreed with {seeds.Length} seeds for {generations} generations and with {maxParents} max parents");

			this._workerThread = new Thread(() => AutoCrossbreedSeeds(seeds, generations, maxParents)) { IsBackground = true };
			this._workerThread.Start();

			return true; // Successfully started worker thread
		}

		/// <summary>
		/// Return a set of seeds that could be created from the input set of seeds
		/// </summary>
		/// <param name="seeds"></param>
		/// <returns></returns>
		public IEnumerable<Seed> BreedSeeds(IEnumerable<Seed> seeds)
		{
			// Handle Null or Empty Input
			if (seeds == null || seeds.Count() == 0)
			{
				return null;
			}

			var resultSeeds = new List<Seed>();
			var maxGeneration = seeds.Max(a => a.Generation);

			// Initialize Dictionaries
			Dictionary<char, decimal>[] traitSlots = new Dictionary<char, decimal>[Traits.TraitCount];
			for (int i = 0; i < Traits.TraitCount; i++)
			{
				traitSlots[i] = new Dictionary<char, decimal>();
			}

			// Add Trait Weights to Dictionaries
			this.CalculateTraitWeights(traitSlots, seeds);

			// Trim the dictionary of any traits not tied for highest weight
			this.SelectResultingTraits(traitSlots);

			// Create all combinations of remaining seed traits as trait strings
			var plantBuilder = new List<StringBuilder>();
			plantBuilder.Add(new StringBuilder());

			// Create Resulting Seeds
			foreach (var slot in traitSlots)
			{
				// Create a new plant copy with the new trait letter appended and replace the original list
				var tempBuilders = new List<StringBuilder>();
				foreach (var trait in slot)
				{
					foreach (var plant in plantBuilder.ToList())
					{
						tempBuilders.Add(new StringBuilder(plant + trait.Key.ToString()));
					}
				}

				plantBuilder = tempBuilders.ToList();
			}

			// Construct seed objects for each result
			var probability = 1M / plantBuilder.Count;
			foreach (var resultBuilder in plantBuilder)
			{
				resultSeeds.Add(new Seed(resultBuilder.ToString(), this._activeSeedType, this._activeCatalogId, maxGeneration + 1, seeds, probability));
			}

			return resultSeeds.ToArray();
		}

		/// <summary>
		/// Return a dictionary of catalog names and ids from the seed store
		/// </summary>
		public Dictionary<int, string> GetCatalogs()
		{
			return this._seedStore.GetCatalogs();
		}

		/// <summary>
		/// Create a new seed catalog in the data store
		/// </summary>
		/// <param name="catalogName"></param>
		public void CreateCatalog(string catalogName)
		{
			_seedStore.CreateCatalog(catalogName);
		}

		/// <summary>
		/// Set the active seed type in the current seed catalog
		/// </summary>
		/// <param name="seedType"></param>
		public void SetActiveSeedType(Seed.SeedTypes seedType)
		{
			this._activeSeedType = seedType;
			this.ActiveSeedTypeUpdated?.Invoke();
		}

		/// <summary>
		/// Set the active seed catalog
		/// </summary>
		/// <param name="catalogId"></param>
		public void SetActiveCatalog(int catalogId)
		{
			this._activeCatalogId = catalogId;
			this.ActiveCatalogUpdated?.Invoke();
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Crossbreed the seeds in the database for the specified amount of generations and return the result seeds
		/// </summary>
		/// <param name="seeds"></param>
		/// <param name="generations">The amount of generations to simulate</param>
		/// <param name="maxParents">The maximum amount of parent seeds to breed with (max = 8 limited by size of large planter)</param>
		/// <returns></returns>
		private void AutoCrossbreedSeeds(Seed[] seeds, int generations, int maxParents)
		{
			var startTime = DateTime.Now;

			lock (this._breederLock)
			{
				this._seedCache.Clear(); // Clear the temporary cache
			}

			// Handle Null or Empty Input
			if (seeds == null || seeds.Length == 0)
			{
				return;
			}

			// Sanity check requested parent limit (limited by planter size)
			if (maxParents > MaximumParents)
			{
				Logger.Instance.Log(Logger.Severity.Warning, $"{nameof(SeedManager)} exceeded maximum crossbreed seed limit {MaximumParents} parent seeds. attempted:{maxParents}");
				maxParents = MaximumParents;
			}

			List<IEnumerable<Seed>> work = null;

			try
			{
				for (int i = 0; i < generations; i++)
				{
					// Create all permutations of the seed array using the specified amount of parents
					for (int parentAmount = MinimumParents; parentAmount <= maxParents; parentAmount++)
					{
						var parentArraysPermutations = GetPermutations(seeds, parentAmount);

						if (work == null)
						{
							work = parentArraysPermutations.ToList();
						}
						else
						{
							work.AddRange(parentArraysPermutations);
						}
					}
				}
			}
			catch(Exception ex) // Catch out of memory exception during permutation calculation
			{
				Logger.Instance.Log(Logger.Severity.Error, $"Exception: {ex}");
				this.DisplayError?.Invoke($"Error: {ex.Message}");
				return;
			}

			// Split the work between batches
			var permutations = work.Count();
			var batchCount = permutations / CROSSBREED_BATCH_SIZE;
			var remainder = permutations % CROSSBREED_BATCH_SIZE;

			Logger.Instance.Log(Logger.Severity.Debug, $"Auto-Breeder Created {work.Count()} permutations in {batchCount} batches of {CROSSBREED_BATCH_SIZE}");

			for (int batch = 0; batch <= batchCount; batch++)
			{
				var workingList = work.GetRange(batch * CROSSBREED_BATCH_SIZE, batch == batchCount ? remainder : CROSSBREED_BATCH_SIZE);

				while (this.BreederThreadCount >= MAX_BREEDER_THREADS)
				{
					Logger.Instance.Log(Logger.Severity.Debug, $"Auto-Breeder Reached max thread count: {MAX_BREEDER_THREADS}");
					Thread.Sleep(50); // Wait for breeder threads to finish work before starting new ones
				}

				// Start a breeder thread
				this.BreederThreadCount++;
				var breederThread = new Thread(() => BreedThreadWork(workingList))
				{
					IsBackground = true,
					Name = $"BreederThread:{BreederThreadCount}"
				};
				breederThread.Start();
			}

			// Wait for threads to finish
			while (this.BreederThreadCount > 0)
			{
				Logger.Instance.Log(Logger.Severity.Debug, $"Auto-Breeder Waiting for {this.BreederThreadCount} threads to finish...");
				Thread.Sleep(250);
			}

			// Store results in temporary memory into database
			var currentSeeds = this._seedStore.GetSeeds(this._activeSeedType, this._activeCatalogId);
			foreach (var seed in this._seedCache)
			{
				bool match = false;
				foreach(var existingSeed in currentSeeds)
				{
					if (seed.Key == existingSeed.Traits)
					{
						match = true;
						break;
					}
				}
				
				if (!match)
				{
					this._seedStore.StoreSeed(seed.Value);
				}
			}

			Logger.Instance.Log(Logger.Severity.Debug, $"Auto-Breeder Finished Breeding seeds in: {(DateTime.Now - startTime).TotalMilliseconds}ms");

			this.AutoCrossBreedCompleted.Invoke();
		}

		/// <summary>
		/// Calculate and store the weights of each genetic trait in the corresponding trait dictionary
		/// NOTE: Each trait has a weight associated with it (.6 for green traits, 1.0 for red traits).
		/// </summary>
		/// <param name="seeds"></param>
		/// <param name="traitSlots"></param>
		private void CalculateTraitWeights(Dictionary<char, decimal>[] traitSlots, IEnumerable<Seed> seeds)
		{
			// Add Trait weights to dictionaries
			foreach (var seed in seeds)
			{
				for (int i = 0; i < Traits.TraitCount; i++)
				{
					if (traitSlots[i].ContainsKey(seed.Traits[i]))
					{
						traitSlots[i][seed.Traits[i]] += Traits.GetWeight(seed.Traits[i]);
					}
					else
					{
						traitSlots[i].Add(seed.Traits[i], Traits.GetWeight(seed.Traits[i]));
					}
				}
			}
		}

		/// <summary>
		/// Compare the weights of all traits in each dictionary and remove any traits which are not tied for the highest weight
		/// NOTE: The resulting dictionaries contains only the resulting plant combinations for the specified input seeds
		/// </summary>
		/// <param name="traitSlots"></param>
		private void SelectResultingTraits(Dictionary<char, decimal>[] traitSlots)
		{
			// Trim all traits not tied for first
			for (int i = 0; i < Traits.TraitCount; i++)
			{
				var max = traitSlots[i].Values.Max();
				foreach (var toRemove in traitSlots[i].Where(a => a.Value != max).ToList())
				{
					traitSlots[i].Remove(toRemove.Key);
				}
			}
		}

		/// <summary>
		/// The target of the worker thread invocation to breed a set of seeds
		/// </summary>
		private void BreedThreadWork(IEnumerable<IEnumerable<Seed>> parentArraysPermutations)
		{
			foreach (var parentArray in parentArraysPermutations)
			{
				var result = this.BreedSeeds(parentArray);

				foreach (var seed in result)
				{
					if (!this._seedCache.ContainsKey(seed.Traits) || seed.Probability > this._seedCache[seed.Traits].Probability)
					{
						this._seedCache[seed.Traits] = seed;
					}
				}
			}

			this.BreederThreadCount--;
		}

		#endregion

		#region Static Methods

		/// <summary>
		/// Get all permutations of the input list with the specified result array length
		/// https://stackoverflow.com/questions/1952153/what-is-the-best-way-to-find-all-combinations-of-items-in-an-array/10629938#10629938
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="list"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
		{
			return length == 1 ? list.Select(t => new T[] { t }) : GetPermutations(list, length - 1).SelectMany(t => list, (t1, t2) => t1.Concat(new T[] {t2}));
		}

		#endregion
	}
}

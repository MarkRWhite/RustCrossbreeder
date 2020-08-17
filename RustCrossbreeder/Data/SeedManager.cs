using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RustCrossbreeder.Logging;

namespace RustCrossbreeder.Data
{
	/// <summary>
	/// Contains data from collected seeds
	/// </summary>
	public class SeedManager
	{
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
			return this._seedStore.GetSeeds(this._activeSeedType, this._activeCatalogId).ToArray();
		}

		/// <summary>
		/// Crossbreed the seeds in the database for the specified amount of generations and return the result seeds
		/// </summary>
		/// <param name="seeds"></param>
		/// <param name="generations">The amount of generations to simulate</param>
		/// <param name="maxParents">The maximum amount of parent seeds to breed with (max = 8 limited by size of large planter)</param>
		/// <returns></returns>
		public void AutoCrossbreedSeeds(Seed[] seeds, int generations, int maxParents)
		{
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

			for (int i = 0; i < generations; i++)
			{
				// Create all permutations of the seed array using the specified amount of parents
				for (int parentAmount = MinimumParents; parentAmount <= maxParents; parentAmount++)
				{
					var parentArraysPermutations = GetPermutations(seeds, parentAmount);
					foreach (var parentArray in parentArraysPermutations)
					{
						var result = this.BreedSeeds(parentArray.ToArray());
						foreach (var seed in result)
						{
							this._seedStore.StoreSeed(seed);
						}
					}
				}
			}
		}

		/// <summary>
		/// Return a set of seeds that could be created from the input set of seeds
		/// </summary>
		/// <param name="seeds"></param>
		/// <returns></returns>
		public Seed[] BreedSeeds(Seed[] seeds)
		{
			// Handle Null or Empty Input
			if (seeds == null || seeds.Length == 0)
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
			foreach (var resultBuilder in plantBuilder)
			{
				resultSeeds.Add(new Seed(resultBuilder.ToString(), this._activeSeedType, this._activeCatalogId, maxGeneration + 1, seeds, 1M / plantBuilder.Count));
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

			// TODO: Trigger data lookup and refresh
		}

		/// <summary>
		/// Set the active seed catalog
		/// </summary>
		/// <param name="catalogId"></param>
		public void SetActiveCatalog(int catalogId)
		{
			this._activeCatalogId = catalogId;

			// TODO: Trigger data source lookup and refresh on the UI (maybe throw an updated event?)
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Calculate and store the weights of each genetic trait in the corresponding trait dictionary
		/// NOTE: Each trait has a weight associated with it (.6 for green traits, 1.0 for red traits).
		/// </summary>
		/// <param name="seeds"></param>
		/// <param name="traitSlots"></param>
		private void CalculateTraitWeights(Dictionary<char, decimal>[] traitSlots, Seed[] seeds)
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

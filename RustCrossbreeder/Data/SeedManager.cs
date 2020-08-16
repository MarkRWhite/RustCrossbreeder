using System.Collections.Generic;
using System.Linq;
using System.Text;

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
		/// <param name="seed"></param>
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
		/// Return a list of stored seeds
		/// </summary>
		/// <returns></returns>
		public Seed[] ViewInputSeeds()
		{
			return this._seedStore.GetSeeds().Where(a => a.Generation == 0).ToArray();
		}

		public Seed[] ViewOutputSeeds()
		{
			return this._seedStore.GetSeeds().Where(a => a.Generation > 0).ToArray();
		}

		/// <summary>
		/// Crossbreed the seeds in the database for the specified amount of generations and return the result seeds
		/// </summary>
		/// <param name="seeds"></param>
		/// <param name="generations"></param>
		/// <returns></returns>
		public Seed[] CrossbreedSeeds(Seed[] seeds, int generations)
		{
			// Handle Null or Empty Input
			if (seeds == null || seeds.Length == 0)
			{
				return null;
			}

			var resultSeeds = new List<Seed>();
			for (int i = 0; i < generations; i++)
			{
				// TODO: For each unique combination of seeds (using 3-8 seeds because of farm plot size) run the BreedSeeds method and store results as next generation

				resultSeeds.AddRange( this.BreedSeeds(seeds) );
			}

			return resultSeeds.ToArray();
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Return a set of seeds that could be created from the input set of seeds
		/// </summary>
		/// <param name="seeds"></param>
		/// <returns></returns>
		private Seed[] BreedSeeds(Seed[] seeds)
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

			this.CreateResultingSeeds(traitSlots, plantBuilder);

			// Construct seed objects for each result
			foreach (var resultBuilder in plantBuilder)
			{
				resultSeeds.Add(new Seed(resultBuilder.ToString(), this._activeSeedType, this._activeCatalogId, maxGeneration+1, seeds, 1M / plantBuilder.Count) );
			}

			return resultSeeds.ToArray();
		}

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

		/// <summary>
		/// Create a unique seed trait string for each possible seed trait combination
		/// </summary>
		/// <param name="traitSlots"></param>
		/// <param name="plantBuilder"></param>
		private void CreateResultingSeeds(Dictionary<char, decimal>[] traitSlots, List<StringBuilder> plantBuilder)
		{
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
		}

		#endregion
	}
}

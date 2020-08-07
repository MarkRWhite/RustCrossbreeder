using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RustCrossbreeder.Data
{
	/// <summary>
	/// Contains data from collected seeds
	/// </summary>
	public class SeedManager
	{
		#region Fields

		private ISeedStore _seedStore;

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
		/// <param name="traits"></param>
		/// <param name="generations"></param>
		/// <returns></returns>
		public Seed[] CrossbreedSeeds(string traits, int generations)
		{
			var resultSeeds = new List<Seed>();
			for (int i = 0; i < generations; i++)
			{
				var seeds = this._seedStore.GetSeeds().ToArray();

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
			var resultSeeds = new List<Seed>();
			var maxGeneration = seeds.Max(a => a.Generation);

			// Initialize Dictionaries
			Dictionary<char, decimal>[] traitSlots = new Dictionary<char, decimal>[6];
			for (int i = 0; i < 6; i++)
			{
				traitSlots[i] = new Dictionary<char, decimal>();
			}

			// Add Trait weights to dictionaries
			foreach (var seed in seeds)
			{
				for (int i = 0; i < 6; i++)
				{
					if ( traitSlots[i].ContainsKey(seed.Traits[i]) )
					{
						traitSlots[i][seed.Traits[i]] += Traits.GetWeight(seed.Traits[i]);
					}
					else
					{
						traitSlots[i].Add(seed.Traits[i], Traits.GetWeight(seed.Traits[i]));
					}
				}
			}

			// Trim all traits not tied for first
			for (int i = 0; i < 6; i++)
			{
				var max = traitSlots[i].Values.Max();
				foreach (var toRemove in traitSlots[i].Where(a => a.Value != max).ToList())
				{
					traitSlots[i].Remove(toRemove.Key);
				}
			}

			// Create all combinations of remaining seed traits
			var plantBuilder = new List<StringBuilder>();
			plantBuilder.Add(new StringBuilder());

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

			// Compile results into objects
			foreach (var resultBuilder in plantBuilder)
			{
				resultSeeds.Add(new Seed(resultBuilder.ToString(), maxGeneration+1, seeds, 1M / plantBuilder.Count) );
			}

			return resultSeeds.ToArray();
		}

		#endregion
	}
}

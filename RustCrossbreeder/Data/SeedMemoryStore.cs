using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RustCrossbreeder.Data
{
	/// <summary>
	/// An in-memory seed store which will not retain seed information once the application is shut down
	/// </summary>
	public class SeedMemoryStore : ISeedStore
	{
		#region Fields

		/// <summary>
		/// The in-memory seed store
		/// </summary>
		private Dictionary<string, Seed> _seeds = new Dictionary<string, Seed>();

		#endregion

		#region Constructors

		/// <summary>
		/// Create a new instance of a SeedMemoryStore which stores seed information in memory
		/// </summary>
		public SeedMemoryStore()
		{

		}

		#endregion

		#region Public Methods

		public Seed[] GetSeeds()
		{
			return _seeds.Values.ToArray();
		}

		public Seed GetSeed(string traits)
		{
			return _seeds.ContainsKey(traits) ? _seeds[traits] : null;
		}

		public void StoreSeed(Seed seed)
		{
			if (!_seeds.ContainsKey(seed.Traits))
			{
				_seeds.Add(seed.Traits, seed);
			}
		}

		public void DeleteSeed(Seed seed)
		{
			if (_seeds.ContainsKey(seed.Traits))
			{
				_seeds.Remove(seed.Traits);
			}
		}

		#endregion
	}
}

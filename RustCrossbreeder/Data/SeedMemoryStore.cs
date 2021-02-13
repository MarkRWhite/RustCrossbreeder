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
		#region Static Fields

		/// <summary>
		/// An incrementing ID field used to calculate the next unique catalogId for the SeedMemoryStore
		/// </summary>
		private static int _nextCatalogId = 1;

		#endregion

		#region Fields

		/// <summary>
		/// The in-memory seed store.  Stored with key of CatalogId, and then seed Traits.
		/// Contains all seeds stored in the seed store
		/// </summary>
		private Dictionary<int, Dictionary<string, Seed>> _seeds = new Dictionary<int, Dictionary<string, Seed>>();

		/// <summary>
		/// Stores a dictionary of seed catalogs
		/// </summary>
		private Dictionary<int, string> _seedCatalogs = new Dictionary<int, string>();

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

		/// <summary>
		/// Gets all seeds from the seed store of the specified type in the specified catalog
		/// </summary>
		/// <param name="type"></param>
		/// <param name="catalogId"></param>
		/// <returns></returns>
		public Seed[] GetSeeds(Seed.SeedTypes type, int catalogId)
		{
			return !_seeds.ContainsKey(catalogId) ? new Seed[0] : _seeds[catalogId].Values.Where(a => a.SeedType == type).ToArray();
		}

		/// <summary>
		/// Gets the specific seed from the seed store
		/// </summary>
		/// <param name="type"></param>
		/// <param name="catalogId"></param>
		/// <param name="traits"></param>
		/// <returns></returns>
		public Seed GetSeed(Seed.SeedTypes type, int catalogId, string traits)
		{
			return _seeds[catalogId].Values.FirstOrDefault(a => a.SeedType == type && a.Traits == traits);
		}

		/// <summary>
		/// Store a new seed in the seed store
		/// </summary>
		/// <param name="seed"></param>
		public void StoreSeed(Seed seed)
		{
			if (!_seeds.ContainsKey(seed.CatalogId))
			{
				return; // Catalog doesn't exist
			}

			// Check if the seed exists already (same seed type with the same traits)
			var existingSeed = _seeds[seed.CatalogId].FirstOrDefault(a => a.Value.SeedType == seed.SeedType && a.Value.Traits == seed.Traits).Value;
			if (existingSeed != null)
			{
				// If seed probability is greater and generation is NOT 0, then replace the existing seed
				if (existingSeed.Probability >= seed.Probability)
				{
					return; // Seed already exists with a higher probability
				}

				// Replace existing seed with the new one
				_seeds[seed.CatalogId][seed.Traits] = Seed.GenerateNewSeedId(seed);
			}
			else
			{
				// Create a new copy of the seed an assign it an ID
				_seeds[seed.CatalogId][seed.Traits] = Seed.GenerateNewSeedId(seed);
			}
		}

		/// <summary>
		/// Delete a seed from the seed store
		/// </summary>
		/// <param name="seed"></param>
		public void DeleteSeed(Seed seed)
		{
			if (_seeds[seed.CatalogId].Values.Any(a => a.SeedType == seed.SeedType && a.Traits == seed.Traits))
			{
				_seeds[seed.CatalogId].Remove(seed.Traits);
			}
		}

		/// <summary>
		/// Return a dictionary of seed catalogs names associated with their IDs in the database
		/// </summary>
		/// <returns></returns>
		public Dictionary<int, string> GetCatalogs()
		{
			return this._seedCatalogs;
		}

		/// <summary>
		/// Create a new seed catalog
		/// NOTE: If name already exists, do nothing
		/// </summary>
		/// <param name="catalogName"></param>
		public void CreateCatalog(string catalogName)
		{
			if (this._seedCatalogs.Values.Any(a => a == catalogName))
			{
				return; // Catalog name already exists
			}

			this._seeds.Add(_nextCatalogId, new Dictionary<string, Seed>()); // Initialize new seed catalog
			this._seedCatalogs.Add(_nextCatalogId++, catalogName);
		}

		/// <summary>
		/// Delete a seed catalog and any seeds associated with it
		/// </summary>
		public void DeleteCatalog(int catalogId)
		{
			if (!this._seedCatalogs.ContainsKey(catalogId))
			{
				return; // CatalogId not found
			}

			this._seeds.Remove(catalogId);
			this._seedCatalogs.Remove(catalogId);
		}

		#endregion
	}
}

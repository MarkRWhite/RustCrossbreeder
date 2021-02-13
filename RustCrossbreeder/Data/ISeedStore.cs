using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RustCrossbreeder.Data
{
	/// <summary>
	/// Defines the behavior of a seed store which will retain seed information
	/// </summary>
	public interface ISeedStore
	{
		/// <summary>
		/// Gets all seeds from the seed store of the specified type in the specified catalog
		/// </summary>
		/// <param name="type"></param>
		/// <param name="catalogId"></param>
		/// <returns></returns>
		Seed[] GetSeeds(Seed.SeedTypes type, int catalogId);

		/// <summary>
		/// Gets the specific seed from the seed store
		/// </summary>
		/// <param name="type"></param>
		/// <param name="catalogId"></param>
		/// <param name="traits"></param>
		/// <returns></returns>
		Seed GetSeed(Seed.SeedTypes type, int catalogId, string traits);

		/// <summary>
		/// Store a new seed in the seed store
		/// </summary>
		/// <param name="seed"></param>
		void StoreSeed(Seed seed);

		/// <summary>
		/// Delete a seed from the seed store
		/// </summary>
		/// <param name="seed"></param>
		void DeleteSeed(Seed seed);

		/// <summary>
		/// Return a dictionary of seed catalogs names associated with their IDs in the database
		/// </summary>
		/// <returns></returns>
		Dictionary<int, string> GetCatalogs();

		/// <summary>
		/// Create a new seed catalog
		/// NOTE: If name already exists, do nothing
		/// </summary>
		/// <param name="catalogName"></param>
		void CreateCatalog(string catalogName);

		/// <summary>
		/// Delete a seed catalog and any seeds associated with it
		/// </summary>
		void DeleteCatalog(int catalogId);

	}
}

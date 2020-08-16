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
		/// Gets all seeds from the seed store
		/// </summary>
		/// <returns></returns>
		Seed[] GetSeeds();

		/// <summary>
		/// Gets the specific seed from the seed store
		/// </summary>
		/// <param name="traits"></param>
		/// <returns></returns>
		Seed GetSeed(string traits);

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
	}
}

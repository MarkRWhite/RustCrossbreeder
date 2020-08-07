using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RustCrossbreeder.Data
{
	public interface ISeedStore
	{
		Seed[] GetSeeds();

		Seed GetSeed(string traits);

		void StoreSeed(Seed seed);

		void DeleteSeed(Seed seed);
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RustCrossbreeder.Data
{
	public class SeedDatabaseStore : ISeedStore
	{
		#region Fields

		/// <summary>
		/// The database connection string
		/// </summary>
		private string _connectionString;

		#endregion

		#region Constructors

		/// <summary>
		/// Creates a new database backed seed store to interface with a SQL database
		/// </summary>
		/// <param name="connectionString"></param>
		public SeedDatabaseStore(string connectionString)
		{
			this._connectionString = connectionString;
		}

		#endregion

		#region Public Methods

		public Seed[] GetSeeds()
		{
			throw new NotImplementedException();
		}

		public Seed GetSeed(string traits)
		{
			throw new NotImplementedException();
		}

		public void StoreSeed(Seed seed)
		{
			throw new NotImplementedException();
		}

		public void DeleteSeed(Seed seed)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}

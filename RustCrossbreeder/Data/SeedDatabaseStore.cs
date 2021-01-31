using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace RustCrossbreeder.Data
{
	public class SeedDatabaseStore : ISeedStore
	{
		#region Constants

		private string GET_SEEDS_PROC = "usp_GetSeeds";
		private string ADD_SEED_PROC = "usp_AddSeed";
		private string UPDATE_SEED_PROC = "usp_UpdateSeed";
		private string DELETE_SEED_PROC = "usp_DeleteSeed";

		private string GET_CATALOGS_PROC = "usp_GetCatalogs";
		private string CREATE_CATALOG_PROC = "usp_CreateCatalog";
		private string DELETE_CATALOG_PROC = "usp_DeleteCatalog";

		private string RETURN_STATUS_ARG = "ReturnStatus";
		private string ERROR_MESSAGE_ARG = "ErrorMessage";

		private string CATALOG_ID_ARG = "CatalogId";
		private string CATLOG_NAME_ARG = "Name";
		
		#endregion

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

		public Seed[] GetSeeds(Seed.SeedTypes type, int catalogId)
		{
			var args = new DynamicParameters();
			args.Add(nameof(Seed.SeedType), type, DbType.Int32, ParameterDirection.Input);
			args.Add(nameof(Seed.CatalogId), catalogId, DbType.Int32, ParameterDirection.Input);

			args.Add(RETURN_STATUS_ARG, DbType.Int32, direction: ParameterDirection.Output);
			args.Add(ERROR_MESSAGE_ARG, DbType.String, direction: ParameterDirection.Output);

			using (var connection = new SqlConnection(_connectionString))
			{
				if (connection.State != ConnectionState.Open)
				{
					connection.Open();
				}

				try
				{
					var results = connection.ExecuteReader(GET_SEEDS_PROC, args, commandType: CommandType.StoredProcedure);

					if ((ResultStatus)args.Get<int>(RETURN_STATUS_ARG) == ResultStatus.Error)
					{
						var err = args.Get<string>(ERROR_MESSAGE_ARG);
						Logging.Logger.Instance.Log(Logging.Logger.Severity.Error, $"Database error: {GET_SEEDS_PROC} {err}");
						return null;
					}

					var seeds = results.Parse<Seed>();
					return seeds.ToArray();
				}
				catch (Exception ex)
				{
					Logging.Logger.Instance.Log(Logging.Logger.Severity.Error, $"Exception executing: {GET_SEEDS_PROC} {ex}");
					return null;
				}
				finally
				{
					if (connection.State == ConnectionState.Open)
					{
						connection.Close();
					}
				}
			}
		}

		public Seed[] GetSeeds(int catalogId)
		{
			throw new NotImplementedException();
		}

		public Seed GetSeed(Seed.SeedTypes type, int catalogId, string traits)
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

		public Dictionary<int, string> GetCatalogs()
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				if (connection.State != ConnectionState.Open)
				{
					connection.Open();
				}

				try
				{
					var results = connection.ExecuteReader(GET_CATALOGS_PROC, commandType: CommandType.Text);

					DataTable resultsTable = new DataTable();
					resultsTable.Load(results);

					return DataTableToCatalogs(resultsTable);
				}
				catch (Exception ex)
				{
					Logging.Logger.Instance.Log(Logging.Logger.Severity.Error, $"Exception executing: {GET_CATALOGS_PROC} {ex}");
					return null;
				}
				finally
				{
					if (connection.State == ConnectionState.Open)
					{
						connection.Close();
					}
				}
			}
		}

		public void CreateCatalog(string catalogName)
		{
			var args = new DynamicParameters();
			args.Add(CATLOG_NAME_ARG, catalogName, DbType.String, ParameterDirection.Input);

			args.Add(RETURN_STATUS_ARG, DbType.Int32, direction: ParameterDirection.Output);
			args.Add(ERROR_MESSAGE_ARG, DbType.String, direction: ParameterDirection.Output);

			using (var connection = new SqlConnection(_connectionString))
			{
				if (connection.State != ConnectionState.Open)
				{
					connection.Open();
				}

				try
				{
					var results = connection.ExecuteReader(CREATE_CATALOG_PROC, args, commandType: CommandType.StoredProcedure);
					this.LogResultStatus(args, CREATE_CATALOG_PROC);
				}
				catch (Exception ex)
				{
					Logging.Logger.Instance.Log(Logging.Logger.Severity.Error, $"Exception executing: {CREATE_CATALOG_PROC} {ex}");
				}
				finally
				{
					if (connection.State == ConnectionState.Open)
					{
						connection.Close();
					}
				}
			}
		}

		public void DeleteCatalog(int catalogId)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Log the result status from executing the stored procedures
		/// </summary>
		/// <param name="args">The procedure arguments</param>
		/// <param name="proc">The procedure name</param>
		/// <returns>Returns if an error occurred</returns>
		private bool LogResultStatus(DynamicParameters args, string proc)
		{
			var resultStatus = (ResultStatus)args.Get<int>(RETURN_STATUS_ARG);

			switch (resultStatus)
			{
				case ResultStatus.Completed:
					return false;
				case ResultStatus.Error:
					var err = args.Get<string>(ERROR_MESSAGE_ARG);
					Logging.Logger.Instance.Log(Logging.Logger.Severity.Error, $"Database error: {proc} {err}");
					return true;
				case ResultStatus.SeedAlreadyExists:
					Logging.Logger.Instance.Log(Logging.Logger.Severity.Warning, $"Database error: {proc} Seed already Exists");
					return true;
				case ResultStatus.ExistingSeedUpdated:
					Logging.Logger.Instance.Log(Logging.Logger.Severity.Warning, $"{proc} Existing seed updated");
					return false;
				case ResultStatus.CatalogExists:
					Logging.Logger.Instance.Log(Logging.Logger.Severity.Warning, $"Database error: {proc} Catalog already exists.");
					return true;
				case ResultStatus.CatalogNotFound:
					Logging.Logger.Instance.Log(Logging.Logger.Severity.Warning, $"Database error: {proc} Catalog not found.");
					return true;
				default:
					Logging.Logger.Instance.Log(Logging.Logger.Severity.Warning, $"Database error: {proc} Unrecognized result status code {resultStatus}.");
					return true;
			}
		}

		/// <summary>
		/// Convert a DataTable of Seeds to a list of Seed objects
		/// </summary>
		/// <param name="resultsTable"></param>
		/// <returns></returns>
		private IEnumerable<Seed> DataTableToSeeds(DataTable resultsTable)
		{
			// NOTE: FROM - https://stackoverflow.com/a/12834413/5157709
			var convertedList = (from row in resultsTable.AsEnumerable()
								 select new Seed(
									Convert.ToString(row[nameof(Seed.Traits)]),
									(Seed.SeedTypes)Convert.ToInt32(row[nameof(Seed.SeedType)]),
									Convert.ToInt32(row[nameof(Seed.CatalogId)]),
									Convert.ToInt32(row[nameof(Seed.Generation)]),
									probability: Convert.ToInt32(row[nameof(Seed.Probability)])
								 )).ToList();

			// Link Parents
			// TODO: Pull in parents from SeedRelationships

			return convertedList;
		}

		/// <summary>
		/// Convert a DataTable of Catalogs to a list of catalogs
		/// </summary>
		/// <param name="resultsTable"></param>
		/// <returns></returns>
		private Dictionary<int, string> DataTableToCatalogs(DataTable resultsTable)
		{
			var results = new Dictionary<int, string>();

			// NOTE: FROM - https://stackoverflow.com/a/12834413/5157709
			var convertedList = (from row in resultsTable.AsEnumerable()
								 select new Tuple<int, string>( Convert.ToInt32(row[CATALOG_ID_ARG]), Convert.ToString(row[CATLOG_NAME_ARG]))).ToList();

			foreach (var catalog in convertedList)
			{
				results.Add(catalog.Item1, catalog.Item2);
			}

			return results;
		}

		#endregion
	}

	/// <summary>
	/// Details the possible stored procedure return statuses
	/// </summary>
	public enum ResultStatus
	{
		Completed = 0,
		SeedAlreadyExists = 1,
		ExistingSeedUpdated = 2,
		Error = 3,
		CatalogExists = 4,
		CatalogNotFound = 5
	}
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using RustCrossbreeder.Data;

namespace RustCrossbreeder
{
	static class Program
	{
		#region Main

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// Initialize Data
			ISeedStore seedStore = null;
			if (Properties.Settings.Default.UseDatabaseStore)
			{
				if (!TestConnection(Properties.Settings.Default.SeedStoreConnectionString))
				{
					MessageBox.Show($"Failed to connect to database.  Using in-memory cache instead.  Seed results won't be saved if you close the program: \n\n{Properties.Settings.Default.SeedStoreConnectionString}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					seedStore = new SeedMemoryStore();
				}
				else
				{
					seedStore = new SeedDatabaseStore(Properties.Settings.Default.SeedStoreConnectionString);
				}
			}
			else
			{
				seedStore = new SeedMemoryStore();
			}

			var seedManager = new SeedManager(seedStore);

			Application.Run(new RustCrossbreederForm(seedManager));
		}

		#endregion

		#region Static Methods

		/// <summary>
		/// Static method to check if the database is good
		/// REFERENCE: https://stackoverflow.com/questions/17195200/check-mysql-db-connection
		/// </summary>
		/// <returns>if the connection was successful</returns>
		public static bool TestConnection(string connectionString)
		{
			if (string.IsNullOrEmpty(connectionString))
			{
				return false;
			}

			bool isConn = false;
			SqlConnection conn = null;
			try
			{
				conn = new SqlConnection(connectionString);
				conn.Open();
				isConn = true;
			}
			catch (Exception ex)
			{
				Logging.Logger.Instance.Log(Logging.Logger.Severity.Warning, $"Failed to connect to database: {connectionString} {ex}");
			}
			finally
			{
				if (conn.State == ConnectionState.Open)
				{
					conn.Close();
				}
			}
			return isConn;
		}

		#endregion

		#region Extension Methods

		/// <summary>
		/// Expose the DoubleBuffered DataGridView property
		/// NOTE: This normally private property of the DataGridView class can be enabled to increase drawing performance
		/// </summary>
		/// <param name="dgv"></param>
		/// <param name="setting"></param>
		public static void DoubleBuffered(this DataGridView dgv, bool setting)
		{
			Type dgvType = dgv.GetType();
			PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
			pi.SetValue(dgv, setting, null);
		}

		#endregion
	}
}

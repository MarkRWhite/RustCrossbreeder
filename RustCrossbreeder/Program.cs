using System;
using System.Collections.Generic;
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

			// Initialize Components
			ISeedStore seedStore = new SeedDatabaseStore(Properties.Settings.Default.SeedStoreConnectionString); // TODO: Implement SeedStore factory
			var seedManager = new SeedManager(seedStore);

			Application.Run(new RustCrossbreederForm(seedManager));
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

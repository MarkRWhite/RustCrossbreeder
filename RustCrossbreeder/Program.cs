using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RustCrossbreeder.Data;

namespace RustCrossbreeder
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			ISeedStore seedStore = new SeedMemoryStore();
			var seedManager = new SeedManager(seedStore);

			Application.Run(new RustCrossbreederForm(seedManager));
		}
	}
}

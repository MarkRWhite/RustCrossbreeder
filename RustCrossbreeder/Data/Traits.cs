using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RustCrossbreeder.Data
{
	/// <summary>
	/// Seed traits and their crossbreeding weight
	/// </summary>
	public static partial class Traits
	{
		#region Static Properties

		/// <summary>
		/// Empty Trait
		/// </summary>
		public static decimal X = 1.0M;

		/// <summary>
		/// Water Need Trait
		/// </summary>
		public static decimal W = 1.0M;

		/// <summary>
		/// Growth Trait
		/// </summary>
		public static decimal G = .6M;

		/// <summary>
		/// Yield Trait
		/// </summary>
		public static decimal Y = .6M;

		/// <summary>
		/// Hardiness Trait
		/// </summary>
		public static decimal H = .6M;

		#endregion

		#region Public Static Methods

		/// <summary>
		/// Get the trait weight for the specified trait
		/// </summary>
		/// <param name="trait"></param>
		/// <returns></returns>
		public static decimal GetWeight(char trait)
		{
			switch (trait)
			{
				case 'X':
					return X;
				case 'W':
					return W;
				case 'G':
					return G;
				case 'Y':
					return Y;
				case 'H':
					return H;
			}

			throw new IndexOutOfRangeException("Invalid Trait ID");
		}

		#endregion

		#region Enums

		#endregion

	}
}

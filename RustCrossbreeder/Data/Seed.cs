using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RustCrossbreeder.Data
{
	/// <summary>
	/// Represents a plant and its traits
	/// </summary>
	public class Seed
	{
		#region Properties

		/// <summary>
		/// The seed traits (6 length)
		/// </summary>
		public string Traits { get; set; }

		/// <summary>
		/// The seed generation
		/// </summary>
		public int Generation { get; set; }

		/// <summary>
		/// The Parents of this seed
		/// </summary>
		public Seed[] ParentSeeds { get; set; }

		/// <summary>
		/// The probability that this seed will be created from the parent seeds
		/// NOTE: Probability is displayed as a decimal (eg: .25 = 25%)
		/// </summary>
		public decimal Probability { get; set; }

		/// <summary>
		/// Display Count of Growth Traits
		/// </summary>
		public int Growth
		{
			get { return Traits.Count(a => a.ToString() == nameof(Data.Traits.G)); }
		}

		/// <summary>
		/// Display Count of Yield Traits
		/// </summary>
		public int Yield
		{
			get { return Traits.Count(a => a.ToString() == nameof(Data.Traits.Y)); }
		}

		/// <summary>
		/// Display Count of Hardiness Traits
		/// </summary>
		public int Hardiness
		{
			get { return Traits.Count(a => a.ToString() == nameof(Data.Traits.H)); }
		}

		/// <summary>
		/// Display Count of Water Need Traits
		/// </summary>
		public int WaterNeed
		{
			get { return Traits.Count(a => a.ToString() == nameof(Data.Traits.W)); }
		}

		/// <summary>
		/// Display Count of Empty Traits
		/// </summary>
		public int EmptyTrait
		{
			get { return Traits.Count(a => a.ToString() == nameof(Data.Traits.X)); }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Create a new seed with the specified traits
		/// </summary>
		/// <param name="traits"></param>
		/// <param name="generation"></param>
		/// <param name="parents"></param>
		/// <param name="probability"></param>
		public Seed(string traits, int generation = 0, Seed[] parents = null, decimal probability = 1M )
		{
			this.Traits = traits;
			this.Generation = generation;
			this.ParentSeeds = parents;
			this.Probability = probability;
		}

		#endregion

		#region Private Methods



		#endregion
	}
}

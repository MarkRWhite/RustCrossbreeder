﻿using System;
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
		#region Fields

		/// <summary>
		/// Stores the calculated amount of growth traits
		/// NOTE: This is a backing field that will be calculated and stored here when its public property is referenced
		/// </summary>
		private int? _growth = null;

		/// <summary>
		/// Stores the calculated amount of yield traits
		/// NOTE: This is a backing field that will be calculated and stored here when its public property is referenced
		/// </summary>
		private int? _yield = null;

		/// <summary>
		/// Stores the calculated amount of hardiness traits
		/// NOTE: This is a backing field that will be calculated and stored here when its public property is referenced
		/// </summary>
		private int? _hardiness = null;

		/// <summary>
		/// Stores the calculated amount of water need traits
		/// NOTE: This is a backing field that will be calculated and stored here when its public property is referenced
		/// </summary>
		private int? _waterNeed = null;

		/// <summary>
		/// Stores the calculated amount of empty traits
		/// NOTE: This is a backing field that will be calculated and stored here when its public property is referenced
		/// </summary>
		private int? _emptyTrait = null;

		#endregion

		#region Properties

		/// <summary>
		/// The Id of the seed.  Null if the seed hasn't been stored in the seed store yet
		/// NOTE: This is assigned automatically from the seed store when a seed is stored
		/// </summary>
		public int? SeedId { get; }

		/// <summary>
		/// The seed traits (6 length)
		/// </summary>
		public string Traits { get; }

		/// <summary>
		/// The type of seed
		/// </summary>
		public SeedTypes SeedType { get; }

		/// <summary>
		/// The seed catalog this seed belongs to
		/// </summary>
		public int CatalogId { get; }

		/// <summary>
		/// The seed generation
		/// </summary>
		public int Generation { get; }

		/// <summary>
		/// The Parents of this seed
		/// </summary>
		public Seed[] ParentSeeds { get; }

		/// <summary>
		/// The probability that this seed will be created from the parent seeds
		/// NOTE: Probability is displayed as a decimal (eg: .25 = 25%)
		/// </summary>
		public decimal Probability { get; }

		/// <summary>
		/// Display Count of Growth Traits
		/// </summary>
		public int Growth
		{
			get
			{
				if (this._growth == null)
				{
					this._growth = Traits.Count(a => a.ToString() == nameof(Data.Traits.G));
				}

				return (int)this._growth;
			}
		}

		/// <summary>
		/// Display Count of Yield Traits
		/// </summary>
		public int Yield
		{
			get
			{
				if (this._yield == null)
				{
					this._yield = Traits.Count(a => a.ToString() == nameof(Data.Traits.Y));
				}

				return (int)this._yield;
			}
		}

		/// <summary>
		/// Display Count of Hardiness Traits
		/// </summary>
		public int Hardiness
		{
			get
			{
				if (this._hardiness == null)
				{
					this._hardiness = Traits.Count(a => a.ToString() == nameof(Data.Traits.H));
				}

				return (int)this._hardiness;
			}
		}

		/// <summary>
		/// Display Count of Water Need Traits
		/// </summary>
		public int WaterNeed
		{
			get
			{
				if (this._waterNeed == null)
				{
					this._waterNeed = Traits.Count(a => a.ToString() == nameof(Data.Traits.W));
				}

				return (int)this._waterNeed;
			}
		}

		/// <summary>
		/// Display Count of Empty Traits
		/// </summary>
		public int EmptyTrait
		{
			get
			{
				if (this._emptyTrait == null)
				{
					this._emptyTrait = Traits.Count(a => a.ToString() == nameof(Data.Traits.X));
				}

				return (int) this._emptyTrait;
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Create a new seed with the specified traits
		/// </summary>
		/// <param name="traits">The seed genetic traits</param>
		/// <param name="seedType">Type of seed</param>
		/// <param name="catalogId">The server/seed catalog ID</param>
		/// <param name="generation">The seed generation</param>
		/// <param name="parents">The parent seeds information</param>
		/// <param name="probability">The probability of this seed being created from its parents</param>
		public Seed(string traits, SeedTypes seedType, int catalogId, int generation = 0, Seed[] parents = null, decimal probability = 1M )
		{
			this.Traits = traits;
			this.SeedType = seedType;
			this.CatalogId = catalogId;
			this.Generation = generation;
			this.ParentSeeds = parents;
			this.Probability = probability;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Create a deep copy of this seed
		/// NOTE: Parents are not deep copied
		/// </summary>
		/// <returns></returns>
		public Seed DeepCopy()
		{
			return new Seed(this.Traits, this.SeedType, this.CatalogId, this.Generation, this.ParentSeeds, this.Probability);
		}

		#endregion

		#region Enums

		/// <summary>
		/// Contains all seed types
		/// </summary>
		public enum SeedTypes
		{
			Hemp,
			Pumpkin,
			Potato,
			Corn,
			BlueBerry,
			RedBerry,
			YellowBerry,
			GreenBerry,
			WhiteBerry,
		}

		#endregion
	}
}

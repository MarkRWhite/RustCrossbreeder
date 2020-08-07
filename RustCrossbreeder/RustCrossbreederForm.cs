using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RustCrossbreeder.Data;

namespace RustCrossbreeder
{
	/// <summary>
	/// Rust Crossbreeder Form
	/// </summary>
	public partial class RustCrossbreederForm : Form
	{
		#region Fields

		/// <summary>
		/// The seed manager
		/// </summary>
		private SeedManager _seedManager;

		/// <summary>
		/// The DataSource for the output display seeds
		/// </summary>
		private Seed[] _outputSeedsDisplayDataSource;

		#endregion

		#region Static Properties

		/// <summary>
		/// Defines if the Alignment of the data properties are positive or negative
		/// </summary>
		public static Dictionary<string, TraitAlignment> SeedPropertyAlignments =
			new Dictionary<string, TraitAlignment>()
			{
				{ nameof(Seed.Growth), TraitAlignment.Positive },
				{ nameof(Seed.Yield), TraitAlignment.Positive },
				{ nameof(Seed.Hardiness), TraitAlignment.Positive },
				{ nameof(Seed.WaterNeed), TraitAlignment.Negative },
				{ nameof(Seed.EmptyTrait), TraitAlignment.Negative },
			};

		/// <summary>
		/// Contains a Lookup Dictionary of Highlight colors to display in the Trait weights window
		/// </summary>
		public static Dictionary<int, Dictionary<TraitAlignment, Color>> TraitDisplayHighlights =
			new Dictionary<int, Dictionary<TraitAlignment, Color>>()
			{
				{0, new Dictionary<TraitAlignment, Color>
				{
					{ TraitAlignment.Positive, Color.FromArgb(255,255,255)},
					{ TraitAlignment.Negative, Color.FromArgb(255,255,255)},
				} },
				{1, new Dictionary<TraitAlignment, Color>
				{
					{ TraitAlignment.Positive, Color.FromArgb(220,255,220)},
					{ TraitAlignment.Negative, Color.FromArgb(255,220,220)},
				} },
				{2, new Dictionary<TraitAlignment, Color>
				{
					{ TraitAlignment.Positive, Color.FromArgb(150,255,150)},
					{ TraitAlignment.Negative, Color.FromArgb(255,150,150)},
				} },
				{3, new Dictionary<TraitAlignment, Color>
				{
					{ TraitAlignment.Positive, Color.FromArgb(100,255,100)},
					{ TraitAlignment.Negative, Color.FromArgb(255,100,100)},
				} },
				{4, new Dictionary<TraitAlignment, Color>
				{
					{ TraitAlignment.Positive, Color.FromArgb(60,255,60)},
					{ TraitAlignment.Negative, Color.FromArgb(255,60,60)},
				} },
				{5, new Dictionary<TraitAlignment, Color>
				{
					{ TraitAlignment.Positive, Color.FromArgb(30,255,30)},
					{ TraitAlignment.Negative, Color.FromArgb(255,30,30)},
				} },
				{6, new Dictionary<TraitAlignment, Color>
				{
					{ TraitAlignment.Positive, Color.FromArgb(0,255,0)},
					{ TraitAlignment.Negative, Color.FromArgb(255,0,0)},
				} },
			};

		#endregion

		#region Constructors

		/// <summary>
		/// Create a new Form
		/// </summary>
		public RustCrossbreederForm(SeedManager seedManager)
		{
			InitializeComponent();

			this._seedManager = seedManager;
		}

		#endregion

		#region Form Events

		/// <summary>
		/// Add an input seed to the list of available seeds
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Click(object sender, EventArgs e)
		{
			foreach (var line in rtbSeeds.Lines)
			{
				this._seedManager.AddSeed(new Seed(line));
			}
			
			this.RefreshDataSource();
		}

		/// <summary>
		/// Remove an input seed from the seed store
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRemove_Click(object sender, EventArgs e)
		{
			this._seedManager.RemoveSeed((Seed)dgvInputSeeds.SelectedRows[0].DataBoundItem);
			this.RefreshDataSource();
		}

		/// <summary>
		/// Crossbreed the entered seeds to create the intended output
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCrossBreed_Click(object sender, EventArgs e)
		{
			this._outputSeedsDisplayDataSource = this._seedManager.CrossbreedSeeds(string.Empty, 1);
			this.RefreshDataSource();
		}

		/// <summary>
		/// Input Seeds Data Source Updated Form Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgvInputSeeds_DataSourceChanged(object sender, EventArgs e)
		{
			UpdateDataSourceTraitHighlights((DataGridView)sender);
		}

		/// <summary>
		/// Output Seeds Data Source Updated Form Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgvOutputSeeds_DataSourceChanged(object sender, EventArgs e)
		{
			UpdateDataSourceTraitHighlights((DataGridView)sender);
		}

		/// <summary>
		/// DataGridView DataBinding Complete Form Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgvSeeds_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			this.UpdateDataSourceTraitHighlights((DataGridView)sender);
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Update the InputSeed Data source with the input seeds from the Database
		/// </summary>
		private void RefreshDataSource()
		{
			this.dgvInputSeeds.DataSource = this._seedManager.ViewInputSeeds();
			this.dgvOutputSeeds.DataSource = _outputSeedsDisplayDataSource;

			this.dgvInputSeeds.ClearSelection();
			this.dgvOutputSeeds.ClearSelection();
		}

		/// <summary>
		/// Highlight the Trait strings and weights with their appropriate colors
		/// </summary>
		private void UpdateDataSourceTraitHighlights(DataGridView grid)
		{
			// Highlight Trait String

			// Highlight Property Weights
			foreach (var row in grid.Rows.Cast<DataGridViewRow>())
			{
				foreach (var cell in row.Cells.Cast<DataGridViewCell>())
				{
					var dataProperty = cell.OwningColumn.DataPropertyName;
					if (SeedPropertyAlignments.ContainsKey(dataProperty))
					{
						cell.Style.BackColor = TraitDisplayHighlights[(int)cell.Value][SeedPropertyAlignments[dataProperty]];
					}
				}
			}
		}

		#endregion

		#region Enums

		/// <summary>
		/// The Alignment of a Trait
		/// NOTE: Denotes whether a trait is displayed as positive or negative
		/// </summary>
		public enum TraitAlignment
		{
			Positive,
			Negative
		}

		#endregion

	}
}

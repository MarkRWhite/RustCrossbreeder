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
		/// The DataSource for the crossbreeder input seed DataGridView
		/// </summary>
		private List<Seed> _crossBreederInputDataSource = new List<Seed>();

		/// <summary>
		/// The DataSource for the output display seeds DataGridView
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

			// Set DataGridViews to DoubleBuffer to reduce redraw lag
			this.dgvInputSeeds.DoubleBuffered(true);
			this.dgvOutputSeeds.DoubleBuffered(true);
			this.dgvCrossbreedInput.DoubleBuffered(true);

			this._seedManager = seedManager;
		}

		#endregion

		#region Form Events

		/// <summary>
		/// Add an input seed to the list of available seeds
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnImportSeeds_Click(object sender, EventArgs e)
		{
			foreach (var line in rtbSeeds.Lines)
			{
				if (!string.IsNullOrWhiteSpace(line))
				{
					this._seedManager.AddSeed(new Seed(line));
				}
			}
			
			this.RefreshInputDataSource();
		}

		/// <summary>
		/// Add a seed to the crossbreeder input
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in dgvInputSeeds.SelectedRows)
			{
				this._crossBreederInputDataSource.Add(((Seed) row.DataBoundItem).DeepCopy());
			}

			this.RefreshCrossBreederDataSource();
		}

		/// <summary>
		/// Delete an input seed from the seed store
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in dgvInputSeeds.SelectedRows)
			{
				this._seedManager.RemoveSeed((Seed)row.DataBoundItem);
			}

			this.RefreshInputDataSource();
		}

		/// <summary>
		/// Crossbreed the entered seeds to create the intended output
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCrossBreed_Click(object sender, EventArgs e)
		{
			if (dgvCrossbreedInput.SelectedCells.Count == 0)
			{
				return; // Ignore Empty Requests
			}

			var breedSeeds = new List<Seed>();
			foreach (DataGridViewCell cell in dgvCrossbreedInput.SelectedCells)
			{
				breedSeeds.Add((Seed)dgvCrossbreedInput.Rows[cell.RowIndex].DataBoundItem);
			}

			this._outputSeedsDisplayDataSource = this._seedManager.CrossbreedSeeds(breedSeeds.ToArray(), 1);

			this.RefreshOutputDataSource();
		}

		/// <summary>
		/// Remove the selected seeds from the cross-breeder
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRemove_Click(object sender, EventArgs e)
		{
			var tempCopy = new Dictionary<Seed, bool>();
			foreach (var seed in _crossBreederInputDataSource)
			{
				tempCopy.Add(seed, false);
			}

			foreach (DataGridViewRow row in dgvCrossbreedInput.SelectedRows)
			{
				tempCopy[(Seed)row.DataBoundItem] = true; // Set Delete flag
			}

			// Overwrite existing data source
			var resultDataSource = tempCopy.Where(a => a.Value != true).ToList();
			this._crossBreederInputDataSource = resultDataSource.Select(a => a.Key.DeepCopy()).ToList();

			this.RefreshCrossBreederDataSource();
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
		private void RefreshInputDataSource()
		{
			this.dgvInputSeeds.DataSource = this._seedManager.ViewInputSeeds();
			this.dgvInputSeeds.ClearSelection();
		}

		/// <summary>
		/// Update the OutputSeed Data source
		/// </summary>
		private void RefreshOutputDataSource()
		{
			this.dgvOutputSeeds.DataSource = _outputSeedsDisplayDataSource;
			this.dgvOutputSeeds.ClearSelection();
		}

		/// <summary>
		/// Update the CrossBreeder Data source
		/// </summary>
		private void RefreshCrossBreederDataSource()
		{
			this.dgvCrossbreedInput.DataSource = _crossBreederInputDataSource.ToList();
			this.dgvCrossbreedInput.ClearSelection();
		}

		/// <summary>
		/// Highlight the Trait strings and weights with their appropriate colors
		/// </summary>
		private void UpdateDataSourceTraitHighlights(DataGridView grid)
		{
			// Highlight Trait String
			// TODO: Highlight the Trait String as Green/Red depending on PropertyAlignment

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

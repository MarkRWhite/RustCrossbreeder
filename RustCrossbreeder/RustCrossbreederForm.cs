using RustCrossbreeder.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RustCrossbreeder.ModalForms;

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
		private readonly SeedManager _seedManager;

		/// <summary>
		/// The DataSource for the crossbreeder input seed DataGridView
		/// </summary>
		private List<Seed> _crossBreederInputDataSource = new List<Seed>();

		/// <summary>
		/// The DataSource for the output display seeds DataGridView
		/// </summary>
		private Seed[] _outputSeedsDisplayDataSource;

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

			// Hook SeedManager events
			this._seedManager = seedManager;
			this._seedManager.ActiveCatalogUpdated += HandleActiveCatalogUpdated;
			this._seedManager.ActiveSeedTypeUpdated += HandleActiveSeedTypeUpdated;
			this._seedManager.CreateCatalog(cmbCatalog.Text);

			// Set Combo box data sources
			this.cmbSeedType.DataSource = Enum.GetNames(typeof(Seed.SeedTypes));
			this.cmbCatalog.DataSource = this._seedManager.GetCatalogs().ToList();
			this.cmbCatalog.DisplayMember = nameof(KeyValuePair<int, string>.Value); // Set display member to the Category string name
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
				if (!string.IsNullOrWhiteSpace(line) && line.Length == Traits.TraitCount)
				{
					var seedType = (Seed.SeedTypes)Enum.Parse(typeof(Seed.SeedTypes), cmbSeedType.Text);
					var catalogId = ((KeyValuePair<int,string>)this.cmbCatalog.SelectedItem).Key;
					this._seedManager.AddSeed(new Seed(line.ToUpper(), seedType, catalogId));
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

			this._outputSeedsDisplayDataSource = this._seedManager.BreedSeeds(breedSeeds.ToArray());

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

		/// <summary>
		/// Auto-breed button pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAutoBreed_Click(object sender, EventArgs e)
		{
			// TODO: Open auto-breed form, specify generations and max-parents.  display result count and allow import results to seed library

			this._seedManager.AutoCrossbreedSeeds(this._seedManager.GetActiveSeeds(), 1, 4);
			this.RefreshInputDataSource();
		}

		/// <summary>
		/// Create new catalog ID link label clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void linkLblCreateNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			// TODO: Create a new seed catalog with the name specified in the combo box
			this._seedManager.CreateCatalog(cmbCatalog.Text);
		}

		/// <summary>
		/// Seed Type Dropdown selected index changed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmbSeedType_SelectedIndexChanged(object sender, EventArgs e)
		{
			// TODO: replace the DataGridView data sources with the seeds from the specified seed types (and catalogs)
		}

		/// <summary>
		/// Catalog dropdown selected index changed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmbCatalog_SelectedIndexChanged(object sender, EventArgs e)
		{
			this._seedManager.SetActiveCatalog(((KeyValuePair<int, string>) cmbCatalog.SelectedItem).Key);
		}

		/// <summary>
		/// Seed cell double click
		/// NOTE: This should trigger for any DataGridView containing seed information
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgvSeeds_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1)
			{
				return;
			}

			var selectedSeed = (Seed)((DataGridView) sender).Rows[e.RowIndex].DataBoundItem;
			new SeedInfoForm(selectedSeed).Show();
		}

		/// <summary>
		/// Form Closing Event (Trigger form closing confirmation)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RustCrossbreederForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// TODO: Implement form closing confirmation
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Handle an Active SeedType update event
		/// </summary>
		private void HandleActiveSeedTypeUpdated()
		{
			this.RefreshInputDataSource();
			this.RefreshCrossBreederDataSource();
			this.RefreshCrossBreederDataSource();
		}

		/// <summary>
		/// Handle an Active Catalog update event
		/// </summary>
		private void HandleActiveCatalogUpdated()
		{
			this.RefreshInputDataSource();
			this.RefreshCrossBreederDataSource();
			this.RefreshCrossBreederDataSource();
		}

		/// <summary>
		/// Update the InputSeed Data source with the input seeds from the Database
		/// </summary>
		private void RefreshInputDataSource()
		{
			this.dgvInputSeeds.DataSource = this._seedManager.GetActiveSeeds();
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

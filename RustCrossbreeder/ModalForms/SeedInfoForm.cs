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

namespace RustCrossbreeder.ModalForms
{
	public partial class SeedInfoForm : Form
	{
		#region Constructors

		public SeedInfoForm(Seed seedInfo)
		{
			InitializeComponent();

			this.dgvSeedParents.DoubleBuffered(true);

			this.SetFormFields(seedInfo);
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Display the specified seed info on the SeedInfoForm
		/// </summary>
		/// <param name="seedInfo"></param>
		public void SetFormFields(Seed seedInfo)
		{
			this.txtSeedId.Text = seedInfo.SeedId.ToString();
			this.txtTraits.Text = seedInfo.Traits;
			this.txtSeedType.Text = seedInfo.SeedType.ToString();
			this.txtCatalogId.Text = seedInfo.CatalogId.ToString();
			this.txtGeneration.Text = seedInfo.Generation.ToString();
			this.txtProbability.Text = seedInfo.Probability.ToString();

			this.dgvSeedParents.DataSource = seedInfo.ParentSeeds;
		}

		#endregion

		#region Form Events

		/// <summary>
		/// Handles a cell double click event. Create a new SeedInfoForm displaying parent seed info
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgvSeedParents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1)
			{
				return;
			}

			var selectedSeed = (Seed)((DataGridView)sender).Rows[e.RowIndex].DataBoundItem;
			new SeedInfoForm(selectedSeed).Show();
		}

		/// <summary>
		/// Data binding complete event for DataGridView for displaying parents
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgvSeedParents_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			this.UpdateDataSourceTraitHighlights((DataGridView)sender);
		}

		#endregion

		#region Private Methods

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
					if (RustCrossbreederForm.SeedPropertyAlignments.ContainsKey(dataProperty))
					{
						cell.Style.BackColor = RustCrossbreederForm.TraitDisplayHighlights[(int)cell.Value][RustCrossbreederForm.SeedPropertyAlignments[dataProperty]];
					}
				}
			}
		}

		#endregion

	}
}

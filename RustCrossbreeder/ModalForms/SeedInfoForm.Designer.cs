namespace RustCrossbreeder.ModalForms
{
	partial class SeedInfoForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeedInfoForm));
			this.dgvSeedParents = new System.Windows.Forms.DataGridView();
			this.txtSeedId = new System.Windows.Forms.TextBox();
			this.txtTraits = new System.Windows.Forms.TextBox();
			this.lblSeedId = new System.Windows.Forms.Label();
			this.txtSeedType = new System.Windows.Forms.TextBox();
			this.txtCatalogId = new System.Windows.Forms.TextBox();
			this.lblTraits = new System.Windows.Forms.Label();
			this.lblSeedType = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtGeneration = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtProbability = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.seedBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.seedIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.traitsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Generation = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Probability = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.generationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.probabilityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.growthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.yieldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.hardinessDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.waterNeedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.emptyTraitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvSeedParents)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.seedBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvSeedParents
			// 
			this.dgvSeedParents.AllowUserToAddRows = false;
			this.dgvSeedParents.AllowUserToDeleteRows = false;
			this.dgvSeedParents.AllowUserToOrderColumns = true;
			this.dgvSeedParents.AllowUserToResizeRows = false;
			this.dgvSeedParents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvSeedParents.AutoGenerateColumns = false;
			this.dgvSeedParents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSeedParents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seedIdDataGridViewTextBoxColumn,
            this.traitsDataGridViewTextBoxColumn,
            this.Generation,
            this.Probability,
            this.generationDataGridViewTextBoxColumn,
            this.probabilityDataGridViewTextBoxColumn,
            this.growthDataGridViewTextBoxColumn,
            this.yieldDataGridViewTextBoxColumn,
            this.hardinessDataGridViewTextBoxColumn,
            this.waterNeedDataGridViewTextBoxColumn,
            this.emptyTraitDataGridViewTextBoxColumn});
			this.dgvSeedParents.DataSource = this.seedBindingSource;
			this.dgvSeedParents.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvSeedParents.Location = new System.Drawing.Point(8, 121);
			this.dgvSeedParents.Margin = new System.Windows.Forms.Padding(4);
			this.dgvSeedParents.Name = "dgvSeedParents";
			this.dgvSeedParents.RowHeadersVisible = false;
			this.dgvSeedParents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvSeedParents.ShowEditingIcon = false;
			this.dgvSeedParents.Size = new System.Drawing.Size(331, 179);
			this.dgvSeedParents.TabIndex = 4;
			this.dgvSeedParents.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeedParents_CellDoubleClick);
			this.dgvSeedParents.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSeedParents_DataBindingComplete);
			// 
			// txtSeedId
			// 
			this.txtSeedId.Location = new System.Drawing.Point(69, 12);
			this.txtSeedId.Name = "txtSeedId";
			this.txtSeedId.ReadOnly = true;
			this.txtSeedId.Size = new System.Drawing.Size(100, 20);
			this.txtSeedId.TabIndex = 5;
			// 
			// txtTraits
			// 
			this.txtTraits.Location = new System.Drawing.Point(69, 38);
			this.txtTraits.Name = "txtTraits";
			this.txtTraits.ReadOnly = true;
			this.txtTraits.Size = new System.Drawing.Size(100, 20);
			this.txtTraits.TabIndex = 6;
			// 
			// lblSeedId
			// 
			this.lblSeedId.Location = new System.Drawing.Point(5, 13);
			this.lblSeedId.Name = "lblSeedId";
			this.lblSeedId.Size = new System.Drawing.Size(58, 17);
			this.lblSeedId.TabIndex = 7;
			this.lblSeedId.Text = "Seed ID";
			this.lblSeedId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSeedType
			// 
			this.txtSeedType.Location = new System.Drawing.Point(69, 64);
			this.txtSeedType.Name = "txtSeedType";
			this.txtSeedType.ReadOnly = true;
			this.txtSeedType.Size = new System.Drawing.Size(100, 20);
			this.txtSeedType.TabIndex = 8;
			// 
			// txtCatalogId
			// 
			this.txtCatalogId.Location = new System.Drawing.Point(244, 12);
			this.txtCatalogId.Name = "txtCatalogId";
			this.txtCatalogId.ReadOnly = true;
			this.txtCatalogId.Size = new System.Drawing.Size(100, 20);
			this.txtCatalogId.TabIndex = 9;
			// 
			// lblTraits
			// 
			this.lblTraits.Location = new System.Drawing.Point(5, 39);
			this.lblTraits.Name = "lblTraits";
			this.lblTraits.Size = new System.Drawing.Size(58, 17);
			this.lblTraits.TabIndex = 10;
			this.lblTraits.Text = "Traits";
			this.lblTraits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblSeedType
			// 
			this.lblSeedType.Location = new System.Drawing.Point(2, 65);
			this.lblSeedType.Name = "lblSeedType";
			this.lblSeedType.Size = new System.Drawing.Size(61, 17);
			this.lblSeedType.TabIndex = 11;
			this.lblSeedType.Text = "Seed Type";
			this.lblSeedType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(175, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 17);
			this.label3.TabIndex = 12;
			this.label3.Text = "CatalogId";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(172, 39);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 17);
			this.label4.TabIndex = 14;
			this.label4.Text = "Generation";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtGeneration
			// 
			this.txtGeneration.Location = new System.Drawing.Point(244, 38);
			this.txtGeneration.Name = "txtGeneration";
			this.txtGeneration.ReadOnly = true;
			this.txtGeneration.Size = new System.Drawing.Size(100, 20);
			this.txtGeneration.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(175, 65);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 17);
			this.label5.TabIndex = 16;
			this.label5.Text = "Probability";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtProbability
			// 
			this.txtProbability.Location = new System.Drawing.Point(244, 64);
			this.txtProbability.Name = "txtProbability";
			this.txtProbability.ReadOnly = true;
			this.txtProbability.Size = new System.Drawing.Size(100, 20);
			this.txtProbability.TabIndex = 15;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(7, 95);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(123, 22);
			this.label1.TabIndex = 17;
			this.label1.Text = "Parent Seeds";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// seedBindingSource
			// 
			this.seedBindingSource.DataSource = typeof(RustCrossbreeder.Data.Seed);
			// 
			// seedIdDataGridViewTextBoxColumn
			// 
			this.seedIdDataGridViewTextBoxColumn.DataPropertyName = "SeedId";
			this.seedIdDataGridViewTextBoxColumn.HeaderText = "SeedId";
			this.seedIdDataGridViewTextBoxColumn.Name = "seedIdDataGridViewTextBoxColumn";
			this.seedIdDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// traitsDataGridViewTextBoxColumn
			// 
			this.traitsDataGridViewTextBoxColumn.DataPropertyName = "Traits";
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.traitsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
			this.traitsDataGridViewTextBoxColumn.HeaderText = "Traits";
			this.traitsDataGridViewTextBoxColumn.Name = "traitsDataGridViewTextBoxColumn";
			this.traitsDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// Generation
			// 
			this.Generation.DataPropertyName = "Generation";
			this.Generation.HeaderText = "Generation";
			this.Generation.Name = "Generation";
			this.Generation.ReadOnly = true;
			// 
			// Probability
			// 
			this.Probability.DataPropertyName = "Probability";
			this.Probability.HeaderText = "Probability";
			this.Probability.Name = "Probability";
			this.Probability.ReadOnly = true;
			// 
			// generationDataGridViewTextBoxColumn
			// 
			this.generationDataGridViewTextBoxColumn.DataPropertyName = "Generation";
			this.generationDataGridViewTextBoxColumn.HeaderText = "Generation";
			this.generationDataGridViewTextBoxColumn.Name = "generationDataGridViewTextBoxColumn";
			this.generationDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// probabilityDataGridViewTextBoxColumn
			// 
			this.probabilityDataGridViewTextBoxColumn.DataPropertyName = "Probability";
			this.probabilityDataGridViewTextBoxColumn.HeaderText = "Probability";
			this.probabilityDataGridViewTextBoxColumn.Name = "probabilityDataGridViewTextBoxColumn";
			this.probabilityDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// growthDataGridViewTextBoxColumn
			// 
			this.growthDataGridViewTextBoxColumn.DataPropertyName = "Growth";
			this.growthDataGridViewTextBoxColumn.HeaderText = "Growth";
			this.growthDataGridViewTextBoxColumn.Name = "growthDataGridViewTextBoxColumn";
			this.growthDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// yieldDataGridViewTextBoxColumn
			// 
			this.yieldDataGridViewTextBoxColumn.DataPropertyName = "Yield";
			this.yieldDataGridViewTextBoxColumn.HeaderText = "Yield";
			this.yieldDataGridViewTextBoxColumn.Name = "yieldDataGridViewTextBoxColumn";
			this.yieldDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// hardinessDataGridViewTextBoxColumn
			// 
			this.hardinessDataGridViewTextBoxColumn.DataPropertyName = "Hardiness";
			this.hardinessDataGridViewTextBoxColumn.HeaderText = "Hardiness";
			this.hardinessDataGridViewTextBoxColumn.Name = "hardinessDataGridViewTextBoxColumn";
			this.hardinessDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// waterNeedDataGridViewTextBoxColumn
			// 
			this.waterNeedDataGridViewTextBoxColumn.DataPropertyName = "WaterNeed";
			this.waterNeedDataGridViewTextBoxColumn.HeaderText = "WaterNeed";
			this.waterNeedDataGridViewTextBoxColumn.Name = "waterNeedDataGridViewTextBoxColumn";
			this.waterNeedDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// emptyTraitDataGridViewTextBoxColumn
			// 
			this.emptyTraitDataGridViewTextBoxColumn.DataPropertyName = "EmptyTrait";
			this.emptyTraitDataGridViewTextBoxColumn.HeaderText = "EmptyTrait";
			this.emptyTraitDataGridViewTextBoxColumn.Name = "emptyTraitDataGridViewTextBoxColumn";
			this.emptyTraitDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// SeedInfoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(352, 309);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtProbability);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtGeneration);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblSeedType);
			this.Controls.Add(this.lblTraits);
			this.Controls.Add(this.txtCatalogId);
			this.Controls.Add(this.txtSeedType);
			this.Controls.Add(this.lblSeedId);
			this.Controls.Add(this.txtTraits);
			this.Controls.Add(this.txtSeedId);
			this.Controls.Add(this.dgvSeedParents);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(368, 348);
			this.Name = "SeedInfoForm";
			this.Text = "Seed Information";
			((System.ComponentModel.ISupportInitialize)(this.dgvSeedParents)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.seedBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvSeedParents;
		private System.Windows.Forms.BindingSource seedBindingSource;
		private System.Windows.Forms.TextBox txtSeedId;
		private System.Windows.Forms.TextBox txtTraits;
		private System.Windows.Forms.Label lblSeedId;
		private System.Windows.Forms.TextBox txtSeedType;
		private System.Windows.Forms.TextBox txtCatalogId;
		private System.Windows.Forms.Label lblTraits;
		private System.Windows.Forms.Label lblSeedType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtGeneration;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtProbability;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridViewTextBoxColumn seedIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn traitsDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn Generation;
		private System.Windows.Forms.DataGridViewTextBoxColumn Probability;
		private System.Windows.Forms.DataGridViewTextBoxColumn generationDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn probabilityDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn growthDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn yieldDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn hardinessDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn waterNeedDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn emptyTraitDataGridViewTextBoxColumn;
	}
}
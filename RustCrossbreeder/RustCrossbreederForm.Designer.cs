namespace RustCrossbreeder
{
	partial class RustCrossbreederForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.lblSeed = new System.Windows.Forms.Label();
			this.btnAdd = new System.Windows.Forms.Button();
			this.dgvInputSeeds = new System.Windows.Forms.DataGridView();
			this.dgvOutputSeeds = new System.Windows.Forms.DataGridView();
			this.btnCrossBreed = new System.Windows.Forms.Button();
			this.lblIntendedOutput = new System.Windows.Forms.Label();
			this.tbOutputTraits = new System.Windows.Forms.TextBox();
			this.btnRemove = new System.Windows.Forms.Button();
			this.rtbSeeds = new System.Windows.Forms.RichTextBox();
			this.traitsDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.generationDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.probabilityDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.growthDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.yieldDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.hardinessDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.waterNeedDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.emptyTraitDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.seedBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.traitsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.generationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.probabilityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.growthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.yieldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.hardinessDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.waterNeedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.emptyTraitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvInputSeeds)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvOutputSeeds)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.seedBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// lblSeed
			// 
			this.lblSeed.AutoSize = true;
			this.lblSeed.Location = new System.Drawing.Point(13, 6);
			this.lblSeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblSeed.Name = "lblSeed";
			this.lblSeed.Size = new System.Drawing.Size(54, 21);
			this.lblSeed.TabIndex = 1;
			this.lblSeed.Text = "Seeds:";
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(122, 73);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(115, 38);
			this.btnAdd.TabIndex = 2;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// dgvInputSeeds
			// 
			this.dgvInputSeeds.AllowUserToAddRows = false;
			this.dgvInputSeeds.AllowUserToDeleteRows = false;
			this.dgvInputSeeds.AllowUserToOrderColumns = true;
			this.dgvInputSeeds.AllowUserToResizeRows = false;
			this.dgvInputSeeds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvInputSeeds.AutoGenerateColumns = false;
			this.dgvInputSeeds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvInputSeeds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.traitsDataGridViewTextBoxColumn,
            this.generationDataGridViewTextBoxColumn,
            this.probabilityDataGridViewTextBoxColumn,
            this.growthDataGridViewTextBoxColumn,
            this.yieldDataGridViewTextBoxColumn,
            this.hardinessDataGridViewTextBoxColumn,
            this.waterNeedDataGridViewTextBoxColumn,
            this.emptyTraitDataGridViewTextBoxColumn});
			this.dgvInputSeeds.DataSource = this.seedBindingSource;
			this.dgvInputSeeds.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvInputSeeds.Location = new System.Drawing.Point(13, 119);
			this.dgvInputSeeds.Margin = new System.Windows.Forms.Padding(4);
			this.dgvInputSeeds.MultiSelect = false;
			this.dgvInputSeeds.Name = "dgvInputSeeds";
			this.dgvInputSeeds.RowHeadersVisible = false;
			this.dgvInputSeeds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvInputSeeds.Size = new System.Drawing.Size(850, 203);
			this.dgvInputSeeds.TabIndex = 3;
			this.dgvInputSeeds.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSeeds_DataBindingComplete);
			// 
			// dgvOutputSeeds
			// 
			this.dgvOutputSeeds.AllowUserToAddRows = false;
			this.dgvOutputSeeds.AllowUserToDeleteRows = false;
			this.dgvOutputSeeds.AllowUserToOrderColumns = true;
			this.dgvOutputSeeds.AllowUserToResizeRows = false;
			this.dgvOutputSeeds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvOutputSeeds.AutoGenerateColumns = false;
			this.dgvOutputSeeds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvOutputSeeds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.traitsDataGridViewTextBoxColumn1,
            this.generationDataGridViewTextBoxColumn1,
            this.probabilityDataGridViewTextBoxColumn1,
            this.growthDataGridViewTextBoxColumn1,
            this.yieldDataGridViewTextBoxColumn1,
            this.hardinessDataGridViewTextBoxColumn1,
            this.waterNeedDataGridViewTextBoxColumn1,
            this.emptyTraitDataGridViewTextBoxColumn1});
			this.dgvOutputSeeds.DataSource = this.seedBindingSource;
			this.dgvOutputSeeds.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvOutputSeeds.Location = new System.Drawing.Point(13, 330);
			this.dgvOutputSeeds.Margin = new System.Windows.Forms.Padding(4);
			this.dgvOutputSeeds.MultiSelect = false;
			this.dgvOutputSeeds.Name = "dgvOutputSeeds";
			this.dgvOutputSeeds.RowHeadersVisible = false;
			this.dgvOutputSeeds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvOutputSeeds.Size = new System.Drawing.Size(850, 221);
			this.dgvOutputSeeds.TabIndex = 4;
			this.dgvOutputSeeds.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSeeds_DataBindingComplete);
			// 
			// btnCrossBreed
			// 
			this.btnCrossBreed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCrossBreed.Location = new System.Drawing.Point(751, 579);
			this.btnCrossBreed.Margin = new System.Windows.Forms.Padding(4);
			this.btnCrossBreed.Name = "btnCrossBreed";
			this.btnCrossBreed.Size = new System.Drawing.Size(112, 38);
			this.btnCrossBreed.TabIndex = 5;
			this.btnCrossBreed.Text = "CrossBreed";
			this.btnCrossBreed.UseVisualStyleBackColor = true;
			this.btnCrossBreed.Click += new System.EventHandler(this.btnCrossBreed_Click);
			// 
			// lblIntendedOutput
			// 
			this.lblIntendedOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lblIntendedOutput.AutoSize = true;
			this.lblIntendedOutput.Location = new System.Drawing.Point(520, 563);
			this.lblIntendedOutput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblIntendedOutput.Name = "lblIntendedOutput";
			this.lblIntendedOutput.Size = new System.Drawing.Size(103, 21);
			this.lblIntendedOutput.TabIndex = 7;
			this.lblIntendedOutput.Text = "Output Traits:";
			// 
			// tbOutputTraits
			// 
			this.tbOutputTraits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutputTraits.Location = new System.Drawing.Point(519, 588);
			this.tbOutputTraits.Margin = new System.Windows.Forms.Padding(4);
			this.tbOutputTraits.MaxLength = 6;
			this.tbOutputTraits.Name = "tbOutputTraits";
			this.tbOutputTraits.Size = new System.Drawing.Size(148, 29);
			this.tbOutputTraits.TabIndex = 6;
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(245, 73);
			this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(112, 38);
			this.btnRemove.TabIndex = 8;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = true;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// rtbSeeds
			// 
			this.rtbSeeds.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbSeeds.Location = new System.Drawing.Point(13, 30);
			this.rtbSeeds.Name = "rtbSeeds";
			this.rtbSeeds.Size = new System.Drawing.Size(102, 81);
			this.rtbSeeds.TabIndex = 9;
			this.rtbSeeds.Text = "";
			// 
			// traitsDataGridViewTextBoxColumn1
			// 
			this.traitsDataGridViewTextBoxColumn1.DataPropertyName = "Traits";
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
			this.traitsDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
			this.traitsDataGridViewTextBoxColumn1.HeaderText = "Traits";
			this.traitsDataGridViewTextBoxColumn1.Name = "traitsDataGridViewTextBoxColumn1";
			// 
			// generationDataGridViewTextBoxColumn1
			// 
			this.generationDataGridViewTextBoxColumn1.DataPropertyName = "Generation";
			this.generationDataGridViewTextBoxColumn1.HeaderText = "Generation";
			this.generationDataGridViewTextBoxColumn1.Name = "generationDataGridViewTextBoxColumn1";
			// 
			// probabilityDataGridViewTextBoxColumn1
			// 
			this.probabilityDataGridViewTextBoxColumn1.DataPropertyName = "Probability";
			this.probabilityDataGridViewTextBoxColumn1.HeaderText = "Probability";
			this.probabilityDataGridViewTextBoxColumn1.Name = "probabilityDataGridViewTextBoxColumn1";
			// 
			// growthDataGridViewTextBoxColumn1
			// 
			this.growthDataGridViewTextBoxColumn1.DataPropertyName = "Growth";
			this.growthDataGridViewTextBoxColumn1.HeaderText = "Growth";
			this.growthDataGridViewTextBoxColumn1.Name = "growthDataGridViewTextBoxColumn1";
			this.growthDataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// yieldDataGridViewTextBoxColumn1
			// 
			this.yieldDataGridViewTextBoxColumn1.DataPropertyName = "Yield";
			this.yieldDataGridViewTextBoxColumn1.HeaderText = "Yield";
			this.yieldDataGridViewTextBoxColumn1.Name = "yieldDataGridViewTextBoxColumn1";
			this.yieldDataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// hardinessDataGridViewTextBoxColumn1
			// 
			this.hardinessDataGridViewTextBoxColumn1.DataPropertyName = "Hardiness";
			this.hardinessDataGridViewTextBoxColumn1.HeaderText = "Hardiness";
			this.hardinessDataGridViewTextBoxColumn1.Name = "hardinessDataGridViewTextBoxColumn1";
			this.hardinessDataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// waterNeedDataGridViewTextBoxColumn1
			// 
			this.waterNeedDataGridViewTextBoxColumn1.DataPropertyName = "WaterNeed";
			this.waterNeedDataGridViewTextBoxColumn1.HeaderText = "WaterNeed";
			this.waterNeedDataGridViewTextBoxColumn1.Name = "waterNeedDataGridViewTextBoxColumn1";
			this.waterNeedDataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// emptyTraitDataGridViewTextBoxColumn1
			// 
			this.emptyTraitDataGridViewTextBoxColumn1.DataPropertyName = "EmptyTrait";
			this.emptyTraitDataGridViewTextBoxColumn1.HeaderText = "EmptyTrait";
			this.emptyTraitDataGridViewTextBoxColumn1.Name = "emptyTraitDataGridViewTextBoxColumn1";
			this.emptyTraitDataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// seedBindingSource
			// 
			this.seedBindingSource.DataSource = typeof(RustCrossbreeder.Data.Seed);
			// 
			// traitsDataGridViewTextBoxColumn
			// 
			this.traitsDataGridViewTextBoxColumn.DataPropertyName = "Traits";
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
			this.traitsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
			this.traitsDataGridViewTextBoxColumn.HeaderText = "Traits";
			this.traitsDataGridViewTextBoxColumn.Name = "traitsDataGridViewTextBoxColumn";
			// 
			// generationDataGridViewTextBoxColumn
			// 
			this.generationDataGridViewTextBoxColumn.DataPropertyName = "Generation";
			this.generationDataGridViewTextBoxColumn.HeaderText = "Generation";
			this.generationDataGridViewTextBoxColumn.Name = "generationDataGridViewTextBoxColumn";
			// 
			// probabilityDataGridViewTextBoxColumn
			// 
			this.probabilityDataGridViewTextBoxColumn.DataPropertyName = "Probability";
			this.probabilityDataGridViewTextBoxColumn.HeaderText = "Probability";
			this.probabilityDataGridViewTextBoxColumn.Name = "probabilityDataGridViewTextBoxColumn";
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
			// RustCrossbreederForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(876, 630);
			this.Controls.Add(this.rtbSeeds);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.lblIntendedOutput);
			this.Controls.Add(this.tbOutputTraits);
			this.Controls.Add(this.btnCrossBreed);
			this.Controls.Add(this.dgvOutputSeeds);
			this.Controls.Add(this.dgvInputSeeds);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lblSeed);
			this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "RustCrossbreederForm";
			this.Text = "Rust Crossbreeder";
			((System.ComponentModel.ISupportInitialize)(this.dgvInputSeeds)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvOutputSeeds)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.seedBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lblSeed;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.DataGridView dgvInputSeeds;
		private System.Windows.Forms.DataGridView dgvOutputSeeds;
		private System.Windows.Forms.Button btnCrossBreed;
		private System.Windows.Forms.Label lblIntendedOutput;
		private System.Windows.Forms.TextBox tbOutputTraits;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.RichTextBox rtbSeeds;
		private System.Windows.Forms.BindingSource seedBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn traitsDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn generationDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn probabilityDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn growthDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn yieldDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn hardinessDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn waterNeedDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn emptyTraitDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn traitsDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn generationDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn probabilityDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn growthDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn yieldDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn hardinessDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn waterNeedDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn emptyTraitDataGridViewTextBoxColumn;
	}
}


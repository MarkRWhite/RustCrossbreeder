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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RustCrossbreederForm));
			this.lblSeed = new System.Windows.Forms.Label();
			this.btnImport = new System.Windows.Forms.Button();
			this.dgvInputSeeds = new System.Windows.Forms.DataGridView();
			this.Generation = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Probability = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvOutputSeeds = new System.Windows.Forms.DataGridView();
			this.btnCrossBreed = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.rtbSeeds = new System.Windows.Forms.RichTextBox();
			this.splitContainerHorizontal = new System.Windows.Forms.SplitContainer();
			this.splitCrossbreedInput = new System.Windows.Forms.SplitContainer();
			this.lblCrossbreedInput = new System.Windows.Forms.Label();
			this.dgvCrossbreedInput = new System.Windows.Forms.DataGridView();
			this.splitContainerVertical = new System.Windows.Forms.SplitContainer();
			this.splitSeedLibrary = new System.Windows.Forms.SplitContainer();
			this.lblSeedLibrary = new System.Windows.Forms.Label();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.cmbSeedType = new System.Windows.Forms.ComboBox();
			this.cmbCatalog = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.linkLblCreateNew = new System.Windows.Forms.LinkLabel();
			this.btnSeedSearch = new System.Windows.Forms.Button();
			this.btnAutoBreed = new System.Windows.Forms.Button();
			this.lblError = new System.Windows.Forms.Label();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.seedBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvInputSeeds)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvOutputSeeds)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerHorizontal)).BeginInit();
			this.splitContainerHorizontal.Panel1.SuspendLayout();
			this.splitContainerHorizontal.Panel2.SuspendLayout();
			this.splitContainerHorizontal.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitCrossbreedInput)).BeginInit();
			this.splitCrossbreedInput.Panel1.SuspendLayout();
			this.splitCrossbreedInput.Panel2.SuspendLayout();
			this.splitCrossbreedInput.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCrossbreedInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerVertical)).BeginInit();
			this.splitContainerVertical.Panel1.SuspendLayout();
			this.splitContainerVertical.Panel2.SuspendLayout();
			this.splitContainerVertical.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitSeedLibrary)).BeginInit();
			this.splitSeedLibrary.Panel1.SuspendLayout();
			this.splitSeedLibrary.Panel2.SuspendLayout();
			this.splitSeedLibrary.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.seedBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// lblSeed
			// 
			this.lblSeed.AutoSize = true;
			this.lblSeed.Location = new System.Drawing.Point(10, 6);
			this.lblSeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblSeed.Name = "lblSeed";
			this.lblSeed.Size = new System.Drawing.Size(105, 21);
			this.lblSeed.TabIndex = 1;
			this.lblSeed.Text = "Import Seeds:";
			// 
			// btnImport
			// 
			this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
			this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnImport.Location = new System.Drawing.Point(122, 73);
			this.btnImport.Margin = new System.Windows.Forms.Padding(4);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(115, 38);
			this.btnImport.TabIndex = 2;
			this.btnImport.Text = "Import";
			this.btnImport.UseVisualStyleBackColor = false;
			this.btnImport.Click += new System.EventHandler(this.btnImportSeeds_Click);
			// 
			// dgvInputSeeds
			// 
			this.dgvInputSeeds.AllowUserToAddRows = false;
			this.dgvInputSeeds.AllowUserToDeleteRows = false;
			this.dgvInputSeeds.AllowUserToOrderColumns = true;
			this.dgvInputSeeds.AllowUserToResizeRows = false;
			this.dgvInputSeeds.AutoGenerateColumns = false;
			this.dgvInputSeeds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvInputSeeds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.Generation,
            this.Probability,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16});
			this.dgvInputSeeds.DataSource = this.seedBindingSource;
			this.dgvInputSeeds.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvInputSeeds.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvInputSeeds.Location = new System.Drawing.Point(0, 0);
			this.dgvInputSeeds.Margin = new System.Windows.Forms.Padding(4);
			this.dgvInputSeeds.Name = "dgvInputSeeds";
			this.dgvInputSeeds.RowHeadersVisible = false;
			this.dgvInputSeeds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvInputSeeds.ShowEditingIcon = false;
			this.dgvInputSeeds.Size = new System.Drawing.Size(579, 346);
			this.dgvInputSeeds.TabIndex = 3;
			this.dgvInputSeeds.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeeds_CellDoubleClick);
			this.dgvInputSeeds.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSeeds_DataBindingComplete);
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
			// dgvOutputSeeds
			// 
			this.dgvOutputSeeds.AllowUserToAddRows = false;
			this.dgvOutputSeeds.AllowUserToDeleteRows = false;
			this.dgvOutputSeeds.AllowUserToOrderColumns = true;
			this.dgvOutputSeeds.AllowUserToResizeRows = false;
			this.dgvOutputSeeds.AutoGenerateColumns = false;
			this.dgvOutputSeeds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvOutputSeeds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24});
			this.dgvOutputSeeds.DataSource = this.seedBindingSource;
			this.dgvOutputSeeds.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvOutputSeeds.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvOutputSeeds.Location = new System.Drawing.Point(0, 0);
			this.dgvOutputSeeds.Margin = new System.Windows.Forms.Padding(4);
			this.dgvOutputSeeds.MultiSelect = false;
			this.dgvOutputSeeds.Name = "dgvOutputSeeds";
			this.dgvOutputSeeds.RowHeadersVisible = false;
			this.dgvOutputSeeds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvOutputSeeds.ShowEditingIcon = false;
			this.dgvOutputSeeds.Size = new System.Drawing.Size(604, 184);
			this.dgvOutputSeeds.TabIndex = 4;
			this.dgvOutputSeeds.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeeds_CellDoubleClick);
			this.dgvOutputSeeds.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSeeds_DataBindingComplete);
			// 
			// btnCrossBreed
			// 
			this.btnCrossBreed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCrossBreed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCrossBreed.Location = new System.Drawing.Point(1086, 73);
			this.btnCrossBreed.Margin = new System.Windows.Forms.Padding(4);
			this.btnCrossBreed.Name = "btnCrossBreed";
			this.btnCrossBreed.Size = new System.Drawing.Size(112, 38);
			this.btnCrossBreed.TabIndex = 5;
			this.btnCrossBreed.Text = "CrossBreed";
			this.btnCrossBreed.UseVisualStyleBackColor = true;
			this.btnCrossBreed.Click += new System.EventHandler(this.btnCrossBreed_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDelete.Location = new System.Drawing.Point(245, 73);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(112, 38);
			this.btnDelete.TabIndex = 8;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
			// splitContainerHorizontal
			// 
			this.splitContainerHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerHorizontal.Location = new System.Drawing.Point(0, 0);
			this.splitContainerHorizontal.Name = "splitContainerHorizontal";
			this.splitContainerHorizontal.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerHorizontal.Panel1
			// 
			this.splitContainerHorizontal.Panel1.Controls.Add(this.splitCrossbreedInput);
			// 
			// splitContainerHorizontal.Panel2
			// 
			this.splitContainerHorizontal.Panel2.Controls.Add(this.dgvOutputSeeds);
			this.splitContainerHorizontal.Size = new System.Drawing.Size(604, 375);
			this.splitContainerHorizontal.SplitterDistance = 187;
			this.splitContainerHorizontal.TabIndex = 10;
			// 
			// splitCrossbreedInput
			// 
			this.splitCrossbreedInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitCrossbreedInput.IsSplitterFixed = true;
			this.splitCrossbreedInput.Location = new System.Drawing.Point(0, 0);
			this.splitCrossbreedInput.Name = "splitCrossbreedInput";
			this.splitCrossbreedInput.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitCrossbreedInput.Panel1
			// 
			this.splitCrossbreedInput.Panel1.Controls.Add(this.lblCrossbreedInput);
			// 
			// splitCrossbreedInput.Panel2
			// 
			this.splitCrossbreedInput.Panel2.Controls.Add(this.dgvCrossbreedInput);
			this.splitCrossbreedInput.Size = new System.Drawing.Size(604, 187);
			this.splitCrossbreedInput.SplitterDistance = 25;
			this.splitCrossbreedInput.TabIndex = 0;
			// 
			// lblCrossbreedInput
			// 
			this.lblCrossbreedInput.AutoSize = true;
			this.lblCrossbreedInput.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCrossbreedInput.Location = new System.Drawing.Point(3, 0);
			this.lblCrossbreedInput.Name = "lblCrossbreedInput";
			this.lblCrossbreedInput.Size = new System.Drawing.Size(154, 21);
			this.lblCrossbreedInput.TabIndex = 21;
			this.lblCrossbreedInput.Text = "Crossbreeder Input";
			// 
			// dgvCrossbreedInput
			// 
			this.dgvCrossbreedInput.AllowUserToAddRows = false;
			this.dgvCrossbreedInput.AllowUserToDeleteRows = false;
			this.dgvCrossbreedInput.AllowUserToOrderColumns = true;
			this.dgvCrossbreedInput.AllowUserToResizeRows = false;
			this.dgvCrossbreedInput.AutoGenerateColumns = false;
			this.dgvCrossbreedInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCrossbreedInput.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28,
            this.dataGridViewTextBoxColumn29,
            this.dataGridViewTextBoxColumn30,
            this.dataGridViewTextBoxColumn31,
            this.dataGridViewTextBoxColumn32});
			this.dgvCrossbreedInput.DataSource = this.seedBindingSource;
			this.dgvCrossbreedInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvCrossbreedInput.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvCrossbreedInput.Location = new System.Drawing.Point(0, 0);
			this.dgvCrossbreedInput.Margin = new System.Windows.Forms.Padding(4);
			this.dgvCrossbreedInput.Name = "dgvCrossbreedInput";
			this.dgvCrossbreedInput.RowHeadersVisible = false;
			this.dgvCrossbreedInput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvCrossbreedInput.ShowEditingIcon = false;
			this.dgvCrossbreedInput.Size = new System.Drawing.Size(604, 158);
			this.dgvCrossbreedInput.TabIndex = 11;
			this.dgvCrossbreedInput.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeeds_CellDoubleClick);
			this.dgvCrossbreedInput.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSeeds_DataBindingComplete);
			// 
			// splitContainerVertical
			// 
			this.splitContainerVertical.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainerVertical.Location = new System.Drawing.Point(12, 141);
			this.splitContainerVertical.Name = "splitContainerVertical";
			// 
			// splitContainerVertical.Panel1
			// 
			this.splitContainerVertical.Panel1.Controls.Add(this.splitSeedLibrary);
			// 
			// splitContainerVertical.Panel2
			// 
			this.splitContainerVertical.Panel2.Controls.Add(this.splitContainerHorizontal);
			this.splitContainerVertical.Size = new System.Drawing.Size(1187, 375);
			this.splitContainerVertical.SplitterDistance = 579;
			this.splitContainerVertical.TabIndex = 12;
			// 
			// splitSeedLibrary
			// 
			this.splitSeedLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitSeedLibrary.IsSplitterFixed = true;
			this.splitSeedLibrary.Location = new System.Drawing.Point(0, 0);
			this.splitSeedLibrary.Name = "splitSeedLibrary";
			this.splitSeedLibrary.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitSeedLibrary.Panel1
			// 
			this.splitSeedLibrary.Panel1.Controls.Add(this.lblSeedLibrary);
			// 
			// splitSeedLibrary.Panel2
			// 
			this.splitSeedLibrary.Panel2.Controls.Add(this.dgvInputSeeds);
			this.splitSeedLibrary.Size = new System.Drawing.Size(579, 375);
			this.splitSeedLibrary.SplitterDistance = 25;
			this.splitSeedLibrary.TabIndex = 0;
			// 
			// lblSeedLibrary
			// 
			this.lblSeedLibrary.AutoSize = true;
			this.lblSeedLibrary.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSeedLibrary.Location = new System.Drawing.Point(3, 0);
			this.lblSeedLibrary.Name = "lblSeedLibrary";
			this.lblSeedLibrary.Size = new System.Drawing.Size(105, 21);
			this.lblSeedLibrary.TabIndex = 20;
			this.lblSeedLibrary.Text = "Seed Library";
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdd.Location = new System.Drawing.Point(846, 73);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(112, 38);
			this.btnAdd.TabIndex = 13;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = false;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(150)))), ((int)(((byte)(50)))));
			this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemove.Location = new System.Drawing.Point(966, 73);
			this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(112, 38);
			this.btnRemove.TabIndex = 14;
			this.btnRemove.Text = "Remove";
			this.btnRemove.UseVisualStyleBackColor = false;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// cmbSeedType
			// 
			this.cmbSeedType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSeedType.FormattingEnabled = true;
			this.cmbSeedType.Location = new System.Drawing.Point(211, 34);
			this.cmbSeedType.Name = "cmbSeedType";
			this.cmbSeedType.Size = new System.Drawing.Size(121, 29);
			this.cmbSeedType.TabIndex = 15;
			this.cmbSeedType.SelectedIndexChanged += new System.EventHandler(this.cmbSeedType_SelectedIndexChanged);
			// 
			// cmbCatalog
			// 
			this.cmbCatalog.FormattingEnabled = true;
			this.cmbCatalog.Location = new System.Drawing.Point(348, 34);
			this.cmbCatalog.Name = "cmbCatalog";
			this.cmbCatalog.Size = new System.Drawing.Size(129, 29);
			this.cmbCatalog.TabIndex = 16;
			this.cmbCatalog.Text = "DefaultCatalog";
			this.cmbCatalog.SelectedIndexChanged += new System.EventHandler(this.cmbCatalog_SelectedIndexChanged);
			this.cmbCatalog.TextChanged += new System.EventHandler(this.cmbCatalog_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(121, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 21);
			this.label1.TabIndex = 17;
			this.label1.Text = "Seed Type:";
			// 
			// linkLblCreateNew
			// 
			this.linkLblCreateNew.AutoSize = true;
			this.linkLblCreateNew.Location = new System.Drawing.Point(483, 37);
			this.linkLblCreateNew.Name = "linkLblCreateNew";
			this.linkLblCreateNew.Size = new System.Drawing.Size(91, 21);
			this.linkLblCreateNew.TabIndex = 18;
			this.linkLblCreateNew.TabStop = true;
			this.linkLblCreateNew.Text = "Create New";
			this.linkLblCreateNew.Visible = false;
			this.linkLblCreateNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblCreateNew_LinkClicked);
			// 
			// btnSeedSearch
			// 
			this.btnSeedSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSeedSearch.Location = new System.Drawing.Point(487, 73);
			this.btnSeedSearch.Margin = new System.Windows.Forms.Padding(4);
			this.btnSeedSearch.Name = "btnSeedSearch";
			this.btnSeedSearch.Size = new System.Drawing.Size(112, 38);
			this.btnSeedSearch.TabIndex = 19;
			this.btnSeedSearch.Text = "Seed Search";
			this.btnSeedSearch.UseVisualStyleBackColor = true;
			this.btnSeedSearch.Visible = false;
			// 
			// btnAutoBreed
			// 
			this.btnAutoBreed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAutoBreed.Location = new System.Drawing.Point(367, 73);
			this.btnAutoBreed.Margin = new System.Windows.Forms.Padding(4);
			this.btnAutoBreed.Name = "btnAutoBreed";
			this.btnAutoBreed.Size = new System.Drawing.Size(112, 38);
			this.btnAutoBreed.TabIndex = 20;
			this.btnAutoBreed.Text = "Auto-Breed";
			this.btnAutoBreed.UseVisualStyleBackColor = true;
			this.btnAutoBreed.Click += new System.EventHandler(this.btnAutoBreed_Click);
			// 
			// lblError
			// 
			this.lblError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblError.ForeColor = System.Drawing.Color.Red;
			this.lblError.Location = new System.Drawing.Point(746, 34);
			this.lblError.Name = "lblError";
			this.lblError.Size = new System.Drawing.Size(453, 28);
			this.lblError.TabIndex = 21;
			this.lblError.Text = "Error:";
			this.lblError.Visible = false;
			// 
			// dataGridViewTextBoxColumn9
			// 
			this.dataGridViewTextBoxColumn9.DataPropertyName = "Traits";
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridViewTextBoxColumn9.HeaderText = "Traits";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn12
			// 
			this.dataGridViewTextBoxColumn12.DataPropertyName = "Growth";
			this.dataGridViewTextBoxColumn12.HeaderText = "Growth";
			this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn12.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn13
			// 
			this.dataGridViewTextBoxColumn13.DataPropertyName = "Yield";
			this.dataGridViewTextBoxColumn13.HeaderText = "Yield";
			this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
			this.dataGridViewTextBoxColumn13.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn14
			// 
			this.dataGridViewTextBoxColumn14.DataPropertyName = "Hardiness";
			this.dataGridViewTextBoxColumn14.HeaderText = "Hardiness";
			this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
			this.dataGridViewTextBoxColumn14.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn15
			// 
			this.dataGridViewTextBoxColumn15.DataPropertyName = "WaterNeed";
			this.dataGridViewTextBoxColumn15.HeaderText = "WaterNeed";
			this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
			this.dataGridViewTextBoxColumn15.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn16
			// 
			this.dataGridViewTextBoxColumn16.DataPropertyName = "EmptyTrait";
			this.dataGridViewTextBoxColumn16.HeaderText = "EmptyTrait";
			this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
			this.dataGridViewTextBoxColumn16.ReadOnly = true;
			// 
			// seedBindingSource
			// 
			this.seedBindingSource.DataSource = typeof(RustCrossbreeder.Data.Seed);
			// 
			// dataGridViewTextBoxColumn25
			// 
			this.dataGridViewTextBoxColumn25.DataPropertyName = "Traits";
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 12F);
			this.dataGridViewTextBoxColumn25.DefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridViewTextBoxColumn25.HeaderText = "Traits";
			this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
			this.dataGridViewTextBoxColumn25.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn26
			// 
			this.dataGridViewTextBoxColumn26.DataPropertyName = "Generation";
			this.dataGridViewTextBoxColumn26.HeaderText = "Generation";
			this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
			this.dataGridViewTextBoxColumn26.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn27
			// 
			this.dataGridViewTextBoxColumn27.DataPropertyName = "Probability";
			this.dataGridViewTextBoxColumn27.HeaderText = "Probability";
			this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
			this.dataGridViewTextBoxColumn27.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn28
			// 
			this.dataGridViewTextBoxColumn28.DataPropertyName = "Growth";
			this.dataGridViewTextBoxColumn28.HeaderText = "Growth";
			this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
			this.dataGridViewTextBoxColumn28.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn29
			// 
			this.dataGridViewTextBoxColumn29.DataPropertyName = "Yield";
			this.dataGridViewTextBoxColumn29.HeaderText = "Yield";
			this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
			this.dataGridViewTextBoxColumn29.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn30
			// 
			this.dataGridViewTextBoxColumn30.DataPropertyName = "Hardiness";
			this.dataGridViewTextBoxColumn30.HeaderText = "Hardiness";
			this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
			this.dataGridViewTextBoxColumn30.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn31
			// 
			this.dataGridViewTextBoxColumn31.DataPropertyName = "WaterNeed";
			this.dataGridViewTextBoxColumn31.HeaderText = "WaterNeed";
			this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
			this.dataGridViewTextBoxColumn31.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn32
			// 
			this.dataGridViewTextBoxColumn32.DataPropertyName = "EmptyTrait";
			this.dataGridViewTextBoxColumn32.HeaderText = "EmptyTrait";
			this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
			this.dataGridViewTextBoxColumn32.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn17
			// 
			this.dataGridViewTextBoxColumn17.DataPropertyName = "Traits";
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 12F);
			this.dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewTextBoxColumn17.HeaderText = "Traits";
			this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
			this.dataGridViewTextBoxColumn17.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn18
			// 
			this.dataGridViewTextBoxColumn18.DataPropertyName = "Generation";
			this.dataGridViewTextBoxColumn18.HeaderText = "Generation";
			this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
			this.dataGridViewTextBoxColumn18.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn19
			// 
			this.dataGridViewTextBoxColumn19.DataPropertyName = "Probability";
			this.dataGridViewTextBoxColumn19.HeaderText = "Probability";
			this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
			this.dataGridViewTextBoxColumn19.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn20
			// 
			this.dataGridViewTextBoxColumn20.DataPropertyName = "Growth";
			this.dataGridViewTextBoxColumn20.HeaderText = "Growth";
			this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
			this.dataGridViewTextBoxColumn20.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn21
			// 
			this.dataGridViewTextBoxColumn21.DataPropertyName = "Yield";
			this.dataGridViewTextBoxColumn21.HeaderText = "Yield";
			this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
			this.dataGridViewTextBoxColumn21.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn22
			// 
			this.dataGridViewTextBoxColumn22.DataPropertyName = "Hardiness";
			this.dataGridViewTextBoxColumn22.HeaderText = "Hardiness";
			this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
			this.dataGridViewTextBoxColumn22.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn23
			// 
			this.dataGridViewTextBoxColumn23.DataPropertyName = "WaterNeed";
			this.dataGridViewTextBoxColumn23.HeaderText = "WaterNeed";
			this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
			this.dataGridViewTextBoxColumn23.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn24
			// 
			this.dataGridViewTextBoxColumn24.DataPropertyName = "EmptyTrait";
			this.dataGridViewTextBoxColumn24.HeaderText = "EmptyTrait";
			this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
			this.dataGridViewTextBoxColumn24.ReadOnly = true;
			// 
			// RustCrossbreederForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1211, 528);
			this.Controls.Add(this.lblError);
			this.Controls.Add(this.btnAutoBreed);
			this.Controls.Add(this.btnSeedSearch);
			this.Controls.Add(this.linkLblCreateNew);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cmbCatalog);
			this.Controls.Add(this.cmbSeedType);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.splitContainerVertical);
			this.Controls.Add(this.rtbSeeds);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnCrossBreed);
			this.Controls.Add(this.btnImport);
			this.Controls.Add(this.lblSeed);
			this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(1022, 567);
			this.Name = "RustCrossbreederForm";
			this.Text = "Rust Crossbreeder";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RustCrossbreederForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dgvInputSeeds)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvOutputSeeds)).EndInit();
			this.splitContainerHorizontal.Panel1.ResumeLayout(false);
			this.splitContainerHorizontal.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerHorizontal)).EndInit();
			this.splitContainerHorizontal.ResumeLayout(false);
			this.splitCrossbreedInput.Panel1.ResumeLayout(false);
			this.splitCrossbreedInput.Panel1.PerformLayout();
			this.splitCrossbreedInput.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitCrossbreedInput)).EndInit();
			this.splitCrossbreedInput.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvCrossbreedInput)).EndInit();
			this.splitContainerVertical.Panel1.ResumeLayout(false);
			this.splitContainerVertical.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerVertical)).EndInit();
			this.splitContainerVertical.ResumeLayout(false);
			this.splitSeedLibrary.Panel1.ResumeLayout(false);
			this.splitSeedLibrary.Panel1.PerformLayout();
			this.splitSeedLibrary.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitSeedLibrary)).EndInit();
			this.splitSeedLibrary.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.seedBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lblSeed;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.DataGridView dgvInputSeeds;
		private System.Windows.Forms.DataGridView dgvOutputSeeds;
		private System.Windows.Forms.Button btnCrossBreed;
		private System.Windows.Forms.Button btnDelete;
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
		private System.Windows.Forms.SplitContainer splitContainerHorizontal;
		private System.Windows.Forms.DataGridView dgvCrossbreedInput;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private System.Windows.Forms.SplitContainer splitContainerVertical;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.ComboBox cmbSeedType;
		private System.Windows.Forms.ComboBox cmbCatalog;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel linkLblCreateNew;
		private System.Windows.Forms.Button btnSeedSearch;
		private System.Windows.Forms.Label lblCrossbreedInput;
		private System.Windows.Forms.Label lblSeedLibrary;
		private System.Windows.Forms.SplitContainer splitCrossbreedInput;
		private System.Windows.Forms.SplitContainer splitSeedLibrary;
		private System.Windows.Forms.Button btnAutoBreed;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
		private System.Windows.Forms.DataGridViewTextBoxColumn Generation;
		private System.Windows.Forms.DataGridViewTextBoxColumn Probability;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
		private System.Windows.Forms.Label lblError;
	}
}


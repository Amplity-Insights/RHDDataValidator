namespace RHDBatchChecker
{
	partial class MainForm
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
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.btnChooseFolder = new System.Windows.Forms.Button();
			this.txtDataSource = new System.Windows.Forms.TextBox();
			this.btnValidate = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.StatusImage = new System.Windows.Forms.DataGridViewImageColumn();
			this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
			this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.validationStepDescriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.validationStepStatusMessageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.validationStepBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.validationStepBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// btnChooseFolder
			// 
			this.btnChooseFolder.Location = new System.Drawing.Point(424, 19);
			this.btnChooseFolder.Name = "btnChooseFolder";
			this.btnChooseFolder.Size = new System.Drawing.Size(111, 24);
			this.btnChooseFolder.TabIndex = 1;
			this.btnChooseFolder.Text = "Choose folder...";
			this.btnChooseFolder.UseVisualStyleBackColor = true;
			this.btnChooseFolder.Click += new System.EventHandler(this.btnChooseFolder_Click);
			// 
			// txtDataSource
			// 
			this.txtDataSource.Location = new System.Drawing.Point(20, 19);
			this.txtDataSource.Name = "txtDataSource";
			this.txtDataSource.Size = new System.Drawing.Size(398, 20);
			this.txtDataSource.TabIndex = 2;
			// 
			// btnValidate
			// 
			this.btnValidate.Enabled = false;
			this.btnValidate.Location = new System.Drawing.Point(755, 229);
			this.btnValidate.Name = "btnValidate";
			this.btnValidate.Size = new System.Drawing.Size(75, 23);
			this.btnValidate.TabIndex = 4;
			this.btnValidate.Text = "Validate";
			this.btnValidate.UseVisualStyleBackColor = true;
			this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtDataSource);
			this.groupBox1.Controls.Add(this.btnChooseFolder);
			this.groupBox1.Location = new System.Drawing.Point(30, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(567, 49);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Data Source";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 267);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(861, 22);
			this.statusStrip1.TabIndex = 6;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.AutoGenerateColumns = false;
			this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.ColumnHeadersVisible = false;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StatusImage,
            this.statusDataGridViewTextBoxColumn,
            this.validationStepDescriptionDataGridViewTextBoxColumn,
            this.validationStepStatusMessageDataGridViewTextBoxColumn});
			this.dataGridView.DataSource = this.validationStepBindingSource;
			this.dataGridView.Location = new System.Drawing.Point(30, 73);
			this.dataGridView.MultiSelect = false;
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.RowHeadersVisible = false;
			this.dataGridView.Size = new System.Drawing.Size(800, 150);
			this.dataGridView.TabIndex = 7;
			this.dataGridView.Visible = false;
			// 
			// StatusImage
			// 
			this.StatusImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.StatusImage.DataPropertyName = "StatusImage";
			this.StatusImage.FillWeight = 101.5228F;
			this.StatusImage.HeaderText = "StatusImage";
			this.StatusImage.Name = "StatusImage";
			this.StatusImage.ReadOnly = true;
			this.StatusImage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.StatusImage.Width = 50;
			// 
			// statusDataGridViewTextBoxColumn
			// 
			this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
			this.statusDataGridViewTextBoxColumn.FillWeight = 99.49239F;
			this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
			this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
			this.statusDataGridViewTextBoxColumn.ReadOnly = true;
			this.statusDataGridViewTextBoxColumn.Visible = false;
			// 
			// validationStepDescriptionDataGridViewTextBoxColumn
			// 
			this.validationStepDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ValidationStepDescription";
			this.validationStepDescriptionDataGridViewTextBoxColumn.FillWeight = 192.2166F;
			this.validationStepDescriptionDataGridViewTextBoxColumn.HeaderText = "ValidationStepDescription";
			this.validationStepDescriptionDataGridViewTextBoxColumn.Name = "validationStepDescriptionDataGridViewTextBoxColumn";
			this.validationStepDescriptionDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// validationStepStatusMessageDataGridViewTextBoxColumn
			// 
			this.validationStepStatusMessageDataGridViewTextBoxColumn.DataPropertyName = "ValidationStepStatusMessage";
			this.validationStepStatusMessageDataGridViewTextBoxColumn.FillWeight = 400F;
			this.validationStepStatusMessageDataGridViewTextBoxColumn.HeaderText = "ValidationStepStatusMessage";
			this.validationStepStatusMessageDataGridViewTextBoxColumn.Name = "validationStepStatusMessageDataGridViewTextBoxColumn";
			this.validationStepStatusMessageDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// validationStepBindingSource
			// 
			this.validationStepBindingSource.DataSource = typeof(RHDBatchChecker.ValidationStep);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(861, 289);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.btnValidate);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.Text = "PH18 Data Validator";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.validationStepBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Button btnChooseFolder;
		private System.Windows.Forms.TextBox txtDataSource;
		private System.Windows.Forms.Button btnValidate;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.BindingSource validationStepBindingSource;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
		private System.Windows.Forms.DataGridViewImageColumn StatusImage;
		private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn validationStepDescriptionDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn validationStepStatusMessageDataGridViewTextBoxColumn;
	}
}


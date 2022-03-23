
namespace SAM.Analytical.Windows.Forms
{
    partial class ConstructionLibraryForm
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
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.DataGridView_Constructions = new System.Windows.Forms.DataGridView();
            this.TextBox_Search = new System.Windows.Forms.TextBox();
            this.Label_Search = new System.Windows.Forms.Label();
            this.Column_ConstructionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Thickness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Button_Remove = new System.Windows.Forms.Button();
            this.Button_Add = new System.Windows.Forms.Button();
            this.Button_Duplicate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Constructions)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.Location = new System.Drawing.Point(414, 413);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 28);
            this.Button_OK.TabIndex = 6;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(495, 413);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 28);
            this.Button_Cancel.TabIndex = 5;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // DataGridView_Constructions
            // 
            this.DataGridView_Constructions.AllowUserToAddRows = false;
            this.DataGridView_Constructions.AllowUserToDeleteRows = false;
            this.DataGridView_Constructions.AllowUserToResizeRows = false;
            this.DataGridView_Constructions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_Constructions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_Constructions.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGridView_Constructions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Constructions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ConstructionName,
            this.Column_Thickness,
            this.Column_Type});
            this.DataGridView_Constructions.Location = new System.Drawing.Point(12, 56);
            this.DataGridView_Constructions.Name = "DataGridView_Constructions";
            this.DataGridView_Constructions.RowHeadersVisible = false;
            this.DataGridView_Constructions.RowHeadersWidth = 51;
            this.DataGridView_Constructions.RowTemplate.Height = 24;
            this.DataGridView_Constructions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_Constructions.Size = new System.Drawing.Size(558, 276);
            this.DataGridView_Constructions.TabIndex = 7;
            this.DataGridView_Constructions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Constructions_CellContentClick);
            this.DataGridView_Constructions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Constructions_CellDoubleClick);
            // 
            // TextBox_Search
            // 
            this.TextBox_Search.Location = new System.Drawing.Point(71, 28);
            this.TextBox_Search.Name = "TextBox_Search";
            this.TextBox_Search.Size = new System.Drawing.Size(499, 22);
            this.TextBox_Search.TabIndex = 8;
            // 
            // Label_Search
            // 
            this.Label_Search.AutoSize = true;
            this.Label_Search.Location = new System.Drawing.Point(12, 31);
            this.Label_Search.Name = "Label_Search";
            this.Label_Search.Size = new System.Drawing.Size(53, 17);
            this.Label_Search.TabIndex = 9;
            this.Label_Search.Text = "Search";
            // 
            // Column_ConstructionName
            // 
            this.Column_ConstructionName.FillWeight = 60F;
            this.Column_ConstructionName.HeaderText = "Construction Name";
            this.Column_ConstructionName.MinimumWidth = 6;
            this.Column_ConstructionName.Name = "Column_ConstructionName";
            this.Column_ConstructionName.ReadOnly = true;
            // 
            // Column_Thickness
            // 
            this.Column_Thickness.FillWeight = 15F;
            this.Column_Thickness.HeaderText = "Thickness";
            this.Column_Thickness.MinimumWidth = 6;
            this.Column_Thickness.Name = "Column_Thickness";
            this.Column_Thickness.ReadOnly = true;
            // 
            // Column_Type
            // 
            this.Column_Type.FillWeight = 25F;
            this.Column_Type.HeaderText = "Default Type";
            this.Column_Type.MinimumWidth = 6;
            this.Column_Type.Name = "Column_Type";
            this.Column_Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Button_Remove
            // 
            this.Button_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Remove.Location = new System.Drawing.Point(495, 338);
            this.Button_Remove.Name = "Button_Remove";
            this.Button_Remove.Size = new System.Drawing.Size(75, 28);
            this.Button_Remove.TabIndex = 11;
            this.Button_Remove.Text = "Remove";
            this.Button_Remove.UseVisualStyleBackColor = true;
            this.Button_Remove.Click += new System.EventHandler(this.Button_Remove_Click);
            // 
            // Button_Add
            // 
            this.Button_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Add.Location = new System.Drawing.Point(414, 338);
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Size = new System.Drawing.Size(75, 28);
            this.Button_Add.TabIndex = 10;
            this.Button_Add.Text = "Add";
            this.Button_Add.UseVisualStyleBackColor = true;
            this.Button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // Button_Duplicate
            // 
            this.Button_Duplicate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Duplicate.Location = new System.Drawing.Point(333, 338);
            this.Button_Duplicate.Name = "Button_Duplicate";
            this.Button_Duplicate.Size = new System.Drawing.Size(75, 28);
            this.Button_Duplicate.TabIndex = 12;
            this.Button_Duplicate.Text = "Duplicate";
            this.Button_Duplicate.UseVisualStyleBackColor = true;
            this.Button_Duplicate.Click += new System.EventHandler(this.Button_Duplicate_Click);
            // 
            // ConstructionLibraryForm
            // 
            this.AcceptButton = this.Button_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Button_Cancel;
            this.ClientSize = new System.Drawing.Size(582, 453);
            this.Controls.Add(this.Button_Duplicate);
            this.Controls.Add(this.Button_Remove);
            this.Controls.Add(this.Button_Add);
            this.Controls.Add(this.Label_Search);
            this.Controls.Add(this.TextBox_Search);
            this.Controls.Add(this.DataGridView_Constructions);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_Cancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "ConstructionLibraryForm";
            this.ShowIcon = false;
            this.Text = "Construction Library";
            this.Load += new System.EventHandler(this.ConstructionLibraryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Constructions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.DataGridView DataGridView_Constructions;
        private System.Windows.Forms.TextBox TextBox_Search;
        private System.Windows.Forms.Label Label_Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ConstructionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Thickness;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_Type;
        private System.Windows.Forms.Button Button_Remove;
        private System.Windows.Forms.Button Button_Add;
        private System.Windows.Forms.Button Button_Duplicate;
    }
}

namespace SAM.Core.Windows.Forms
{
    partial class MaterialLibraryForm
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
            this.Button_Duplicate = new System.Windows.Forms.Button();
            this.Button_Remove = new System.Windows.Forms.Button();
            this.Button_Add = new System.Windows.Forms.Button();
            this.Label_Search = new System.Windows.Forms.Label();
            this.TextBox_Search = new System.Windows.Forms.TextBox();
            this.DataGridView_Materials = new System.Windows.Forms.DataGridView();
            this.Column_DisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Materials)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_Duplicate
            // 
            this.Button_Duplicate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Duplicate.Location = new System.Drawing.Point(333, 330);
            this.Button_Duplicate.Name = "Button_Duplicate";
            this.Button_Duplicate.Size = new System.Drawing.Size(75, 28);
            this.Button_Duplicate.TabIndex = 20;
            this.Button_Duplicate.Text = "Duplicate";
            this.Button_Duplicate.UseVisualStyleBackColor = true;
            this.Button_Duplicate.Click += new System.EventHandler(this.Button_Duplicate_Click);
            // 
            // Button_Remove
            // 
            this.Button_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Remove.Location = new System.Drawing.Point(495, 330);
            this.Button_Remove.Name = "Button_Remove";
            this.Button_Remove.Size = new System.Drawing.Size(75, 28);
            this.Button_Remove.TabIndex = 19;
            this.Button_Remove.Text = "Remove";
            this.Button_Remove.UseVisualStyleBackColor = true;
            // 
            // Button_Add
            // 
            this.Button_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Add.Location = new System.Drawing.Point(414, 330);
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Size = new System.Drawing.Size(75, 28);
            this.Button_Add.TabIndex = 18;
            this.Button_Add.Text = "Add";
            this.Button_Add.UseVisualStyleBackColor = true;
            // 
            // Label_Search
            // 
            this.Label_Search.AutoSize = true;
            this.Label_Search.Location = new System.Drawing.Point(12, 23);
            this.Label_Search.Name = "Label_Search";
            this.Label_Search.Size = new System.Drawing.Size(53, 17);
            this.Label_Search.TabIndex = 17;
            this.Label_Search.Text = "Search";
            // 
            // TextBox_Search
            // 
            this.TextBox_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Search.Location = new System.Drawing.Point(71, 20);
            this.TextBox_Search.Name = "TextBox_Search";
            this.TextBox_Search.Size = new System.Drawing.Size(499, 22);
            this.TextBox_Search.TabIndex = 16;
            this.TextBox_Search.TextChanged += new System.EventHandler(this.TextBox_Search_TextChanged);
            // 
            // DataGridView_Materials
            // 
            this.DataGridView_Materials.AllowUserToAddRows = false;
            this.DataGridView_Materials.AllowUserToDeleteRows = false;
            this.DataGridView_Materials.AllowUserToResizeRows = false;
            this.DataGridView_Materials.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_Materials.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_Materials.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGridView_Materials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Materials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_DisplayName,
            this.Column_Name,
            this.Column_Description});
            this.DataGridView_Materials.Location = new System.Drawing.Point(12, 48);
            this.DataGridView_Materials.MultiSelect = false;
            this.DataGridView_Materials.Name = "DataGridView_Materials";
            this.DataGridView_Materials.RowHeadersVisible = false;
            this.DataGridView_Materials.RowHeadersWidth = 51;
            this.DataGridView_Materials.RowTemplate.Height = 24;
            this.DataGridView_Materials.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_Materials.Size = new System.Drawing.Size(558, 276);
            this.DataGridView_Materials.TabIndex = 15;
            this.DataGridView_Materials.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Materials_CellDoubleClick);
            // 
            // Column_DisplayName
            // 
            this.Column_DisplayName.FillWeight = 30F;
            this.Column_DisplayName.HeaderText = "Display Name";
            this.Column_DisplayName.MinimumWidth = 6;
            this.Column_DisplayName.Name = "Column_DisplayName";
            this.Column_DisplayName.ReadOnly = true;
            // 
            // Column_Name
            // 
            this.Column_Name.FillWeight = 30F;
            this.Column_Name.HeaderText = "Name";
            this.Column_Name.MinimumWidth = 6;
            this.Column_Name.Name = "Column_Name";
            this.Column_Name.ReadOnly = true;
            // 
            // Column_Description
            // 
            this.Column_Description.FillWeight = 40F;
            this.Column_Description.HeaderText = "Description";
            this.Column_Description.MinimumWidth = 6;
            this.Column_Description.Name = "Column_Description";
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.Location = new System.Drawing.Point(414, 413);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 28);
            this.Button_OK.TabIndex = 14;
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
            this.Button_Cancel.TabIndex = 13;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // MaterialLibraryForm
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
            this.Controls.Add(this.DataGridView_Materials);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_Cancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "MaterialLibraryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Material Library";
            this.Load += new System.EventHandler(this.MaterialLibraryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Materials)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Duplicate;
        private System.Windows.Forms.Button Button_Remove;
        private System.Windows.Forms.Button Button_Add;
        private System.Windows.Forms.Label Label_Search;
        private System.Windows.Forms.TextBox TextBox_Search;
        private System.Windows.Forms.DataGridView DataGridView_Materials;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_DisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Description;
    }
}
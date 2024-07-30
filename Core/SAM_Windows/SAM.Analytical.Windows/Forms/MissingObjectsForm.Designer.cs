
namespace SAM.Analytical.Windows.Forms
{
    partial class MissingObjectsForm
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
            this.DataGridView_Main = new System.Windows.Forms.DataGridView();
            this.Button_Search = new System.Windows.Forms.Button();
            this.ListBox_Paths = new System.Windows.Forms.ListBox();
            this.SplitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.Column_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Button_AddFile = new System.Windows.Forms.Button();
            this.Button_AddFolder = new System.Windows.Forms.Button();
            this.Button_Remove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).BeginInit();
            this.SplitContainer_Main.Panel1.SuspendLayout();
            this.SplitContainer_Main.Panel2.SuspendLayout();
            this.SplitContainer_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.Location = new System.Drawing.Point(632, 410);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 28);
            this.Button_OK.TabIndex = 8;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(713, 410);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 28);
            this.Button_Cancel.TabIndex = 7;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            // 
            // DataGridView_Main
            // 
            this.DataGridView_Main.AllowUserToAddRows = false;
            this.DataGridView_Main.AllowUserToDeleteRows = false;
            this.DataGridView_Main.AllowUserToResizeRows = false;
            this.DataGridView_Main.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_Main.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGridView_Main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Type,
            this.Column_Name,
            this.Column_FileName});
            this.DataGridView_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView_Main.Location = new System.Drawing.Point(0, 0);
            this.DataGridView_Main.Name = "DataGridView_Main";
            this.DataGridView_Main.RowHeadersVisible = false;
            this.DataGridView_Main.RowHeadersWidth = 51;
            this.DataGridView_Main.RowTemplate.Height = 24;
            this.DataGridView_Main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_Main.Size = new System.Drawing.Size(514, 392);
            this.DataGridView_Main.TabIndex = 9;
            // 
            // Button_Search
            // 
            this.Button_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_Search.Location = new System.Drawing.Point(15, 410);
            this.Button_Search.Name = "Button_Search";
            this.Button_Search.Size = new System.Drawing.Size(75, 28);
            this.Button_Search.TabIndex = 10;
            this.Button_Search.Text = "Search";
            this.Button_Search.UseVisualStyleBackColor = true;
            // 
            // ListBox_Paths
            // 
            this.ListBox_Paths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox_Paths.FormattingEnabled = true;
            this.ListBox_Paths.ItemHeight = 16;
            this.ListBox_Paths.Location = new System.Drawing.Point(3, 3);
            this.ListBox_Paths.Name = "ListBox_Paths";
            this.ListBox_Paths.Size = new System.Drawing.Size(253, 340);
            this.ListBox_Paths.TabIndex = 11;
            // 
            // SplitContainer_Main
            // 
            this.SplitContainer_Main.Location = new System.Drawing.Point(12, 12);
            this.SplitContainer_Main.Name = "SplitContainer_Main";
            // 
            // SplitContainer_Main.Panel1
            // 
            this.SplitContainer_Main.Panel1.Controls.Add(this.Button_Remove);
            this.SplitContainer_Main.Panel1.Controls.Add(this.Button_AddFolder);
            this.SplitContainer_Main.Panel1.Controls.Add(this.Button_AddFile);
            this.SplitContainer_Main.Panel1.Controls.Add(this.ListBox_Paths);
            // 
            // SplitContainer_Main.Panel2
            // 
            this.SplitContainer_Main.Panel2.Controls.Add(this.DataGridView_Main);
            this.SplitContainer_Main.Size = new System.Drawing.Size(776, 392);
            this.SplitContainer_Main.SplitterDistance = 258;
            this.SplitContainer_Main.TabIndex = 12;
            // 
            // Column_Type
            // 
            this.Column_Type.HeaderText = "Type";
            this.Column_Type.MinimumWidth = 6;
            this.Column_Type.Name = "Column_Type";
            this.Column_Type.ReadOnly = true;
            // 
            // Column_Name
            // 
            this.Column_Name.HeaderText = "Name";
            this.Column_Name.MinimumWidth = 6;
            this.Column_Name.Name = "Column_Name";
            this.Column_Name.ReadOnly = true;
            // 
            // Column_FileName
            // 
            this.Column_FileName.HeaderText = "File Name";
            this.Column_FileName.MinimumWidth = 6;
            this.Column_FileName.Name = "Column_FileName";
            this.Column_FileName.ReadOnly = true;
            // 
            // Button_AddFile
            // 
            this.Button_AddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_AddFile.Location = new System.Drawing.Point(3, 349);
            this.Button_AddFile.Name = "Button_AddFile";
            this.Button_AddFile.Size = new System.Drawing.Size(75, 28);
            this.Button_AddFile.TabIndex = 13;
            this.Button_AddFile.Text = "Add File";
            this.Button_AddFile.UseVisualStyleBackColor = true;
            // 
            // Button_AddFolder
            // 
            this.Button_AddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_AddFolder.Location = new System.Drawing.Point(85, 349);
            this.Button_AddFolder.Name = "Button_AddFolder";
            this.Button_AddFolder.Size = new System.Drawing.Size(85, 28);
            this.Button_AddFolder.TabIndex = 13;
            this.Button_AddFolder.Text = "Add Folder";
            this.Button_AddFolder.UseVisualStyleBackColor = true;
            // 
            // Button_Remove
            // 
            this.Button_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Remove.Location = new System.Drawing.Point(180, 349);
            this.Button_Remove.Name = "Button_Remove";
            this.Button_Remove.Size = new System.Drawing.Size(75, 28);
            this.Button_Remove.TabIndex = 14;
            this.Button_Remove.Text = "Remove";
            this.Button_Remove.UseVisualStyleBackColor = true;
            // 
            // MissingObjectsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SplitContainer_Main);
            this.Controls.Add(this.Button_Search);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_Cancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MissingObjectsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Missing Objects";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Main)).EndInit();
            this.SplitContainer_Main.Panel1.ResumeLayout(false);
            this.SplitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).EndInit();
            this.SplitContainer_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.DataGridView DataGridView_Main;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_FileName;
        private System.Windows.Forms.Button Button_Search;
        private System.Windows.Forms.ListBox ListBox_Paths;
        private System.Windows.Forms.SplitContainer SplitContainer_Main;
        private System.Windows.Forms.Button Button_Remove;
        private System.Windows.Forms.Button Button_AddFolder;
        private System.Windows.Forms.Button Button_AddFile;
    }
}
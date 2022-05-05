
namespace SAM.Analytical.Windows.Controls
{
    partial class ProfileControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Label_Name = new System.Windows.Forms.Label();
            this.TextBox_Name = new System.Windows.Forms.TextBox();
            this.Label_Category = new System.Windows.Forms.Label();
            this.ComboBox_Category = new System.Windows.Forms.ComboBox();
            this.Button_Remove = new System.Windows.Forms.Button();
            this.Button_SetProfile = new System.Windows.Forms.Button();
            this.Button_SetValue = new System.Windows.Forms.Button();
            this.DataGridView_Values = new System.Windows.Forms.DataGridView();
            this.Column_Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContextMenuStrip_DataGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.Chart_Main = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SplitContainer_Main = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Values)).BeginInit();
            this.ContextMenuStrip_DataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).BeginInit();
            this.SplitContainer_Main.Panel1.SuspendLayout();
            this.SplitContainer_Main.Panel2.SuspendLayout();
            this.SplitContainer_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Location = new System.Drawing.Point(15, 8);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(49, 17);
            this.Label_Name.TabIndex = 0;
            this.Label_Name.Text = "Name:";
            // 
            // TextBox_Name
            // 
            this.TextBox_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Name.Location = new System.Drawing.Point(90, 5);
            this.TextBox_Name.Name = "TextBox_Name";
            this.TextBox_Name.Size = new System.Drawing.Size(270, 22);
            this.TextBox_Name.TabIndex = 1;
            // 
            // Label_Category
            // 
            this.Label_Category.AutoSize = true;
            this.Label_Category.Location = new System.Drawing.Point(15, 36);
            this.Label_Category.Name = "Label_Category";
            this.Label_Category.Size = new System.Drawing.Size(69, 17);
            this.Label_Category.TabIndex = 2;
            this.Label_Category.Text = "Category:";
            // 
            // ComboBox_Category
            // 
            this.ComboBox_Category.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Category.FormattingEnabled = true;
            this.ComboBox_Category.Location = new System.Drawing.Point(90, 33);
            this.ComboBox_Category.Name = "ComboBox_Category";
            this.ComboBox_Category.Size = new System.Drawing.Size(270, 24);
            this.ComboBox_Category.TabIndex = 3;
            // 
            // Button_Remove
            // 
            this.Button_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Remove.Location = new System.Drawing.Point(60, 459);
            this.Button_Remove.Name = "Button_Remove";
            this.Button_Remove.Size = new System.Drawing.Size(96, 23);
            this.Button_Remove.TabIndex = 17;
            this.Button_Remove.Text = "Remove";
            this.Button_Remove.UseVisualStyleBackColor = true;
            this.Button_Remove.Click += new System.EventHandler(this.Button_Remove_Click);
            // 
            // Button_SetProfile
            // 
            this.Button_SetProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_SetProfile.Enabled = false;
            this.Button_SetProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_SetProfile.Location = new System.Drawing.Point(162, 459);
            this.Button_SetProfile.Name = "Button_SetProfile";
            this.Button_SetProfile.Size = new System.Drawing.Size(96, 23);
            this.Button_SetProfile.TabIndex = 16;
            this.Button_SetProfile.Text = "Set Profile";
            this.Button_SetProfile.UseVisualStyleBackColor = true;
            this.Button_SetProfile.Click += new System.EventHandler(this.Button_SetProfile_Click);
            // 
            // Button_SetValue
            // 
            this.Button_SetValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_SetValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_SetValue.Location = new System.Drawing.Point(264, 459);
            this.Button_SetValue.Name = "Button_SetValue";
            this.Button_SetValue.Size = new System.Drawing.Size(96, 23);
            this.Button_SetValue.TabIndex = 15;
            this.Button_SetValue.Text = "Set Value";
            this.Button_SetValue.UseVisualStyleBackColor = true;
            this.Button_SetValue.Click += new System.EventHandler(this.Button_SetValue_Click);
            // 
            // DataGridView_Values
            // 
            this.DataGridView_Values.AllowUserToAddRows = false;
            this.DataGridView_Values.AllowUserToDeleteRows = false;
            this.DataGridView_Values.AllowUserToResizeRows = false;
            this.DataGridView_Values.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_Values.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_Values.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Values.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Index,
            this.Column_Name,
            this.Column_Value});
            this.DataGridView_Values.ContextMenuStrip = this.ContextMenuStrip_DataGridView;
            this.DataGridView_Values.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DataGridView_Values.Location = new System.Drawing.Point(15, 63);
            this.DataGridView_Values.Name = "DataGridView_Values";
            this.DataGridView_Values.RowHeadersVisible = false;
            this.DataGridView_Values.RowHeadersWidth = 51;
            this.DataGridView_Values.RowTemplate.Height = 24;
            this.DataGridView_Values.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_Values.Size = new System.Drawing.Size(345, 390);
            this.DataGridView_Values.TabIndex = 14;
            this.DataGridView_Values.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridView_Values_EditingControlShowing);
            // 
            // Column_Index
            // 
            this.Column_Index.FillWeight = 15F;
            this.Column_Index.HeaderText = "Index";
            this.Column_Index.MinimumWidth = 6;
            this.Column_Index.Name = "Column_Index";
            this.Column_Index.ReadOnly = true;
            // 
            // Column_Name
            // 
            this.Column_Name.FillWeight = 60F;
            this.Column_Name.HeaderText = "Name";
            this.Column_Name.MinimumWidth = 6;
            this.Column_Name.Name = "Column_Name";
            this.Column_Name.ReadOnly = true;
            // 
            // Column_Value
            // 
            this.Column_Value.FillWeight = 25F;
            this.Column_Value.HeaderText = "Value";
            this.Column_Value.MinimumWidth = 6;
            this.Column_Value.Name = "Column_Value";
            // 
            // ContextMenuStrip_DataGridView
            // 
            this.ContextMenuStrip_DataGridView.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextMenuStrip_DataGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_SelectAll,
            this.ToolStripMenuItem_Copy,
            this.ToolStripMenuItem_Paste});
            this.ContextMenuStrip_DataGridView.Name = "ContextMenuStrip_DataGridView";
            this.ContextMenuStrip_DataGridView.Size = new System.Drawing.Size(141, 76);
            // 
            // ToolStripMenuItem_SelectAll
            // 
            this.ToolStripMenuItem_SelectAll.Name = "ToolStripMenuItem_SelectAll";
            this.ToolStripMenuItem_SelectAll.Size = new System.Drawing.Size(140, 24);
            this.ToolStripMenuItem_SelectAll.Text = "Select All";
            this.ToolStripMenuItem_SelectAll.Click += new System.EventHandler(this.ToolStripMenuItem_SelectAll_Click);
            // 
            // ToolStripMenuItem_Copy
            // 
            this.ToolStripMenuItem_Copy.Name = "ToolStripMenuItem_Copy";
            this.ToolStripMenuItem_Copy.Size = new System.Drawing.Size(140, 24);
            this.ToolStripMenuItem_Copy.Text = "Copy";
            this.ToolStripMenuItem_Copy.Click += new System.EventHandler(this.ToolStripMenuItem_Copy_Click);
            // 
            // ToolStripMenuItem_Paste
            // 
            this.ToolStripMenuItem_Paste.Name = "ToolStripMenuItem_Paste";
            this.ToolStripMenuItem_Paste.Size = new System.Drawing.Size(140, 24);
            this.ToolStripMenuItem_Paste.Text = "Paste";
            this.ToolStripMenuItem_Paste.Click += new System.EventHandler(this.ToolStripMenuItem_Paste_Click);
            // 
            // Chart_Main
            // 
            this.Chart_Main.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.Chart_Main.ChartAreas.Add(chartArea1);
            this.Chart_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chart_Main.Location = new System.Drawing.Point(0, 0);
            this.Chart_Main.Name = "Chart_Main";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.Chart_Main.Series.Add(series1);
            this.Chart_Main.Size = new System.Drawing.Size(407, 485);
            this.Chart_Main.TabIndex = 18;
            // 
            // SplitContainer_Main
            // 
            this.SplitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer_Main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer_Main.Name = "SplitContainer_Main";
            // 
            // SplitContainer_Main.Panel1
            // 
            this.SplitContainer_Main.Panel1.Controls.Add(this.DataGridView_Values);
            this.SplitContainer_Main.Panel1.Controls.Add(this.Button_Remove);
            this.SplitContainer_Main.Panel1.Controls.Add(this.Label_Name);
            this.SplitContainer_Main.Panel1.Controls.Add(this.Button_SetProfile);
            this.SplitContainer_Main.Panel1.Controls.Add(this.TextBox_Name);
            this.SplitContainer_Main.Panel1.Controls.Add(this.Button_SetValue);
            this.SplitContainer_Main.Panel1.Controls.Add(this.Label_Category);
            this.SplitContainer_Main.Panel1.Controls.Add(this.ComboBox_Category);
            // 
            // SplitContainer_Main.Panel2
            // 
            this.SplitContainer_Main.Panel2.Controls.Add(this.Chart_Main);
            this.SplitContainer_Main.Size = new System.Drawing.Size(774, 485);
            this.SplitContainer_Main.SplitterDistance = 363;
            this.SplitContainer_Main.TabIndex = 19;
            // 
            // ProfileControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.SplitContainer_Main);
            this.Name = "ProfileControl";
            this.Size = new System.Drawing.Size(774, 485);
            this.Load += new System.EventHandler(this.ProfileControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Values)).EndInit();
            this.ContextMenuStrip_DataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Main)).EndInit();
            this.SplitContainer_Main.Panel1.ResumeLayout(false);
            this.SplitContainer_Main.Panel1.PerformLayout();
            this.SplitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).EndInit();
            this.SplitContainer_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.TextBox TextBox_Name;
        private System.Windows.Forms.Label Label_Category;
        private System.Windows.Forms.ComboBox ComboBox_Category;
        private System.Windows.Forms.Button Button_Remove;
        private System.Windows.Forms.Button Button_SetProfile;
        private System.Windows.Forms.Button Button_SetValue;
        private System.Windows.Forms.DataGridView DataGridView_Values;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Main;
        private System.Windows.Forms.SplitContainer SplitContainer_Main;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip_DataGridView;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Copy;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Paste;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SelectAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Value;
    }
}


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
            this.Label_Name = new System.Windows.Forms.Label();
            this.TextBox_Name = new System.Windows.Forms.TextBox();
            this.Label_Category = new System.Windows.Forms.Label();
            this.ComboBox_Category = new System.Windows.Forms.ComboBox();
            this.DataGridView_Values = new System.Windows.Forms.DataGridView();
            this.Column_Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CartesianChart_Profile = new LiveCharts.WinForms.CartesianChart();
            this.SplitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.Button_Remove = new System.Windows.Forms.Button();
            this.Button_SetProfile = new System.Windows.Forms.Button();
            this.Button_SetValue = new System.Windows.Forms.Button();
            this.TabControl_Profile = new System.Windows.Forms.TabControl();
            this.TabPage_Profile = new System.Windows.Forms.TabPage();
            this.TabPage_Yearly = new System.Windows.Forms.TabPage();
            this.CartesianChart_Yearly = new LiveCharts.WinForms.CartesianChart();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Values)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).BeginInit();
            this.SplitContainer_Main.Panel1.SuspendLayout();
            this.SplitContainer_Main.Panel2.SuspendLayout();
            this.SplitContainer_Main.SuspendLayout();
            this.TabControl_Profile.SuspendLayout();
            this.TabPage_Profile.SuspendLayout();
            this.TabPage_Yearly.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Location = new System.Drawing.Point(3, 6);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(49, 17);
            this.Label_Name.TabIndex = 0;
            this.Label_Name.Text = "Name:";
            // 
            // TextBox_Name
            // 
            this.TextBox_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Name.Location = new System.Drawing.Point(78, 3);
            this.TextBox_Name.Name = "TextBox_Name";
            this.TextBox_Name.Size = new System.Drawing.Size(282, 22);
            this.TextBox_Name.TabIndex = 1;
            // 
            // Label_Category
            // 
            this.Label_Category.AutoSize = true;
            this.Label_Category.Location = new System.Drawing.Point(3, 34);
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
            this.ComboBox_Category.Location = new System.Drawing.Point(78, 31);
            this.ComboBox_Category.Name = "ComboBox_Category";
            this.ComboBox_Category.Size = new System.Drawing.Size(282, 24);
            this.ComboBox_Category.TabIndex = 3;
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
            this.DataGridView_Values.Location = new System.Drawing.Point(0, 0);
            this.DataGridView_Values.Name = "DataGridView_Values";
            this.DataGridView_Values.ReadOnly = true;
            this.DataGridView_Values.RowHeadersVisible = false;
            this.DataGridView_Values.RowHeadersWidth = 51;
            this.DataGridView_Values.RowTemplate.Height = 24;
            this.DataGridView_Values.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_Values.Size = new System.Drawing.Size(357, 157);
            this.DataGridView_Values.TabIndex = 4;
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
            this.Column_Value.ReadOnly = true;
            // 
            // CartesianChart_Profile
            // 
            this.CartesianChart_Profile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CartesianChart_Profile.Location = new System.Drawing.Point(3, 3);
            this.CartesianChart_Profile.Name = "CartesianChart_Profile";
            this.CartesianChart_Profile.Size = new System.Drawing.Size(343, 151);
            this.CartesianChart_Profile.TabIndex = 5;
            this.CartesianChart_Profile.Text = "Profile";
            // 
            // SplitContainer_Main
            // 
            this.SplitContainer_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer_Main.Location = new System.Drawing.Point(3, 61);
            this.SplitContainer_Main.Name = "SplitContainer_Main";
            this.SplitContainer_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer_Main.Panel1
            // 
            this.SplitContainer_Main.Panel1.Controls.Add(this.Button_Remove);
            this.SplitContainer_Main.Panel1.Controls.Add(this.Button_SetProfile);
            this.SplitContainer_Main.Panel1.Controls.Add(this.Button_SetValue);
            this.SplitContainer_Main.Panel1.Controls.Add(this.DataGridView_Values);
            // 
            // SplitContainer_Main.Panel2
            // 
            this.SplitContainer_Main.Panel2.Controls.Add(this.TabControl_Profile);
            this.SplitContainer_Main.Size = new System.Drawing.Size(357, 379);
            this.SplitContainer_Main.SplitterDistance = 189;
            this.SplitContainer_Main.TabIndex = 6;
            // 
            // Button_Remove
            // 
            this.Button_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Remove.Location = new System.Drawing.Point(53, 164);
            this.Button_Remove.Name = "Button_Remove";
            this.Button_Remove.Size = new System.Drawing.Size(96, 23);
            this.Button_Remove.TabIndex = 13;
            this.Button_Remove.Text = "Remove";
            this.Button_Remove.UseVisualStyleBackColor = true;
            // 
            // Button_SetProfile
            // 
            this.Button_SetProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_SetProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_SetProfile.Location = new System.Drawing.Point(155, 164);
            this.Button_SetProfile.Name = "Button_SetProfile";
            this.Button_SetProfile.Size = new System.Drawing.Size(96, 23);
            this.Button_SetProfile.TabIndex = 12;
            this.Button_SetProfile.Text = "Set Profile";
            this.Button_SetProfile.UseVisualStyleBackColor = true;
            // 
            // Button_SetValue
            // 
            this.Button_SetValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_SetValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_SetValue.Location = new System.Drawing.Point(257, 163);
            this.Button_SetValue.Name = "Button_SetValue";
            this.Button_SetValue.Size = new System.Drawing.Size(96, 23);
            this.Button_SetValue.TabIndex = 11;
            this.Button_SetValue.Text = "Set Value";
            this.Button_SetValue.UseVisualStyleBackColor = true;
            this.Button_SetValue.Click += new System.EventHandler(this.Button_SetValue_Click);
            // 
            // TabControl_Profile
            // 
            this.TabControl_Profile.Controls.Add(this.TabPage_Profile);
            this.TabControl_Profile.Controls.Add(this.TabPage_Yearly);
            this.TabControl_Profile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_Profile.Location = new System.Drawing.Point(0, 0);
            this.TabControl_Profile.Name = "TabControl_Profile";
            this.TabControl_Profile.SelectedIndex = 0;
            this.TabControl_Profile.Size = new System.Drawing.Size(357, 186);
            this.TabControl_Profile.TabIndex = 5;
            // 
            // TabPage_Profile
            // 
            this.TabPage_Profile.Controls.Add(this.CartesianChart_Profile);
            this.TabPage_Profile.Location = new System.Drawing.Point(4, 25);
            this.TabPage_Profile.Name = "TabPage_Profile";
            this.TabPage_Profile.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Profile.Size = new System.Drawing.Size(349, 157);
            this.TabPage_Profile.TabIndex = 0;
            this.TabPage_Profile.Text = "Profile";
            this.TabPage_Profile.UseVisualStyleBackColor = true;
            // 
            // TabPage_Yearly
            // 
            this.TabPage_Yearly.Controls.Add(this.CartesianChart_Yearly);
            this.TabPage_Yearly.Location = new System.Drawing.Point(4, 25);
            this.TabPage_Yearly.Name = "TabPage_Yearly";
            this.TabPage_Yearly.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Yearly.Size = new System.Drawing.Size(349, 157);
            this.TabPage_Yearly.TabIndex = 1;
            this.TabPage_Yearly.Text = "Yearly";
            this.TabPage_Yearly.UseVisualStyleBackColor = true;
            // 
            // CartesianChart_Yearly
            // 
            this.CartesianChart_Yearly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CartesianChart_Yearly.Location = new System.Drawing.Point(3, 3);
            this.CartesianChart_Yearly.Name = "CartesianChart_Yearly";
            this.CartesianChart_Yearly.Size = new System.Drawing.Size(343, 151);
            this.CartesianChart_Yearly.TabIndex = 6;
            this.CartesianChart_Yearly.Text = "Profile";
            // 
            // ProfileControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.SplitContainer_Main);
            this.Controls.Add(this.ComboBox_Category);
            this.Controls.Add(this.Label_Category);
            this.Controls.Add(this.TextBox_Name);
            this.Controls.Add(this.Label_Name);
            this.Name = "ProfileControl";
            this.Size = new System.Drawing.Size(363, 443);
            this.Load += new System.EventHandler(this.ProfileControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Values)).EndInit();
            this.SplitContainer_Main.Panel1.ResumeLayout(false);
            this.SplitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).EndInit();
            this.SplitContainer_Main.ResumeLayout(false);
            this.TabControl_Profile.ResumeLayout(false);
            this.TabPage_Profile.ResumeLayout(false);
            this.TabPage_Yearly.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.TextBox TextBox_Name;
        private System.Windows.Forms.Label Label_Category;
        private System.Windows.Forms.ComboBox ComboBox_Category;
        private System.Windows.Forms.DataGridView DataGridView_Values;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Value;
        private LiveCharts.WinForms.CartesianChart CartesianChart_Profile;
        private System.Windows.Forms.SplitContainer SplitContainer_Main;
        private System.Windows.Forms.TabControl TabControl_Profile;
        private System.Windows.Forms.TabPage TabPage_Profile;
        private System.Windows.Forms.TabPage TabPage_Yearly;
        private LiveCharts.WinForms.CartesianChart CartesianChart_Yearly;
        private System.Windows.Forms.Button Button_Remove;
        private System.Windows.Forms.Button Button_SetProfile;
        private System.Windows.Forms.Button Button_SetValue;
    }
}

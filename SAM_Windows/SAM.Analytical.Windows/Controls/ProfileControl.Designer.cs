
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
            this.Button_Remove = new System.Windows.Forms.Button();
            this.Button_SetProfile = new System.Windows.Forms.Button();
            this.Button_SetValue = new System.Windows.Forms.Button();
            this.DataGridView_Values = new System.Windows.Forms.DataGridView();
            this.Column_Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Values)).BeginInit();
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
            // Button_Remove
            // 
            this.Button_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Remove.Location = new System.Drawing.Point(60, 460);
            this.Button_Remove.Name = "Button_Remove";
            this.Button_Remove.Size = new System.Drawing.Size(96, 23);
            this.Button_Remove.TabIndex = 17;
            this.Button_Remove.Text = "Remove";
            this.Button_Remove.UseVisualStyleBackColor = true;
            // 
            // Button_SetProfile
            // 
            this.Button_SetProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_SetProfile.Enabled = false;
            this.Button_SetProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_SetProfile.Location = new System.Drawing.Point(162, 460);
            this.Button_SetProfile.Name = "Button_SetProfile";
            this.Button_SetProfile.Size = new System.Drawing.Size(96, 23);
            this.Button_SetProfile.TabIndex = 16;
            this.Button_SetProfile.Text = "Set Profile";
            this.Button_SetProfile.UseVisualStyleBackColor = true;
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
            this.DataGridView_Values.Location = new System.Drawing.Point(3, 61);
            this.DataGridView_Values.Name = "DataGridView_Values";
            this.DataGridView_Values.ReadOnly = true;
            this.DataGridView_Values.RowHeadersVisible = false;
            this.DataGridView_Values.RowHeadersWidth = 51;
            this.DataGridView_Values.RowTemplate.Height = 24;
            this.DataGridView_Values.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_Values.Size = new System.Drawing.Size(357, 393);
            this.DataGridView_Values.TabIndex = 14;
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
            // ProfileControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.Button_Remove);
            this.Controls.Add(this.Button_SetProfile);
            this.Controls.Add(this.Button_SetValue);
            this.Controls.Add(this.DataGridView_Values);
            this.Controls.Add(this.ComboBox_Category);
            this.Controls.Add(this.Label_Category);
            this.Controls.Add(this.TextBox_Name);
            this.Controls.Add(this.Label_Name);
            this.Name = "ProfileControl";
            this.Size = new System.Drawing.Size(363, 485);
            this.Load += new System.EventHandler(this.ProfileControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Values)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Value;
    }
}

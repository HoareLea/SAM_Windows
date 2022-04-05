
namespace SAM.Analytical.Windows.Forms
{
    partial class ApertureConstructionForm
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
            this.Label_Name = new System.Windows.Forms.Label();
            this.TextBox_Name = new System.Windows.Forms.TextBox();
            this.DataGridView_Layers = new System.Windows.Forms.DataGridView();
            this.Column_MaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Thickness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.Button_Add = new System.Windows.Forms.Button();
            this.Button_Remove = new System.Windows.Forms.Button();
            this.Button_Down = new System.Windows.Forms.Button();
            this.Button_Up = new System.Windows.Forms.Button();
            this.Label_ApertureType = new System.Windows.Forms.Label();
            this.ComboBox_ApertureType = new System.Windows.Forms.ComboBox();
            this.GroupBox_PaneConstructionLayers = new System.Windows.Forms.GroupBox();
            this.GroupBox_FrameConstruction = new System.Windows.Forms.GroupBox();
            this.DataGridView_FrameConstruction = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Layers)).BeginInit();
            this.GroupBox_PaneConstructionLayers.SuspendLayout();
            this.GroupBox_FrameConstruction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_FrameConstruction)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Location = new System.Drawing.Point(12, 25);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(49, 17);
            this.Label_Name.TabIndex = 0;
            this.Label_Name.Text = "Name:";
            // 
            // TextBox_Name
            // 
            this.TextBox_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Name.Location = new System.Drawing.Point(67, 22);
            this.TextBox_Name.Name = "TextBox_Name";
            this.TextBox_Name.Size = new System.Drawing.Size(403, 22);
            this.TextBox_Name.TabIndex = 1;
            // 
            // DataGridView_Layers
            // 
            this.DataGridView_Layers.AllowUserToAddRows = false;
            this.DataGridView_Layers.AllowUserToDeleteRows = false;
            this.DataGridView_Layers.AllowUserToResizeRows = false;
            this.DataGridView_Layers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_Layers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_Layers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGridView_Layers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_Layers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Layers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_MaterialName,
            this.Column_Thickness});
            this.DataGridView_Layers.Location = new System.Drawing.Point(6, 31);
            this.DataGridView_Layers.Name = "DataGridView_Layers";
            this.DataGridView_Layers.RowHeadersVisible = false;
            this.DataGridView_Layers.RowHeadersWidth = 51;
            this.DataGridView_Layers.RowTemplate.Height = 24;
            this.DataGridView_Layers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_Layers.Size = new System.Drawing.Size(443, 224);
            this.DataGridView_Layers.TabIndex = 2;
            this.DataGridView_Layers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Layers_CellClick);
            this.DataGridView_Layers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Layers_CellContentClick);
            this.DataGridView_Layers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Layers_CellDoubleClick);
            this.DataGridView_Layers.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridView_Layers_EditingControlShowing);
            // 
            // Column_MaterialName
            // 
            this.Column_MaterialName.HeaderText = "Material Name";
            this.Column_MaterialName.MinimumWidth = 6;
            this.Column_MaterialName.Name = "Column_MaterialName";
            this.Column_MaterialName.ReadOnly = true;
            this.Column_MaterialName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column_Thickness
            // 
            this.Column_Thickness.FillWeight = 30F;
            this.Column_Thickness.HeaderText = "Thickness";
            this.Column_Thickness.MinimumWidth = 6;
            this.Column_Thickness.Name = "Column_Thickness";
            this.Column_Thickness.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.Location = new System.Drawing.Point(314, 763);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 28);
            this.Button_OK.TabIndex = 4;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(395, 763);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 28);
            this.Button_Cancel.TabIndex = 3;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // Button_Add
            // 
            this.Button_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Add.Location = new System.Drawing.Point(293, 261);
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Size = new System.Drawing.Size(75, 28);
            this.Button_Add.TabIndex = 5;
            this.Button_Add.Text = "Add";
            this.Button_Add.UseVisualStyleBackColor = true;
            this.Button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // Button_Remove
            // 
            this.Button_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Remove.Location = new System.Drawing.Point(374, 261);
            this.Button_Remove.Name = "Button_Remove";
            this.Button_Remove.Size = new System.Drawing.Size(75, 28);
            this.Button_Remove.TabIndex = 6;
            this.Button_Remove.Text = "Remove";
            this.Button_Remove.UseVisualStyleBackColor = true;
            this.Button_Remove.Click += new System.EventHandler(this.Button_Remove_Click);
            // 
            // Button_Down
            // 
            this.Button_Down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_Down.Location = new System.Drawing.Point(67, 261);
            this.Button_Down.Name = "Button_Down";
            this.Button_Down.Size = new System.Drawing.Size(55, 28);
            this.Button_Down.TabIndex = 7;
            this.Button_Down.Text = "Down";
            this.Button_Down.UseVisualStyleBackColor = true;
            this.Button_Down.Click += new System.EventHandler(this.Button_Down_Click);
            // 
            // Button_Up
            // 
            this.Button_Up.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_Up.Location = new System.Drawing.Point(6, 261);
            this.Button_Up.Name = "Button_Up";
            this.Button_Up.Size = new System.Drawing.Size(55, 28);
            this.Button_Up.TabIndex = 8;
            this.Button_Up.Text = "Up";
            this.Button_Up.UseVisualStyleBackColor = true;
            this.Button_Up.Click += new System.EventHandler(this.Button_Up_Click);
            // 
            // Label_ApertureType
            // 
            this.Label_ApertureType.AutoSize = true;
            this.Label_ApertureType.Location = new System.Drawing.Point(12, 62);
            this.Label_ApertureType.Name = "Label_ApertureType";
            this.Label_ApertureType.Size = new System.Drawing.Size(103, 17);
            this.Label_ApertureType.TabIndex = 9;
            this.Label_ApertureType.Text = "Aperture Type:";
            // 
            // ComboBox_ApertureType
            // 
            this.ComboBox_ApertureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_ApertureType.FormattingEnabled = true;
            this.ComboBox_ApertureType.Location = new System.Drawing.Point(254, 59);
            this.ComboBox_ApertureType.Name = "ComboBox_ApertureType";
            this.ComboBox_ApertureType.Size = new System.Drawing.Size(216, 24);
            this.ComboBox_ApertureType.TabIndex = 10;
            // 
            // GroupBox_PaneConstructionLayers
            // 
            this.GroupBox_PaneConstructionLayers.Controls.Add(this.DataGridView_Layers);
            this.GroupBox_PaneConstructionLayers.Controls.Add(this.Button_Remove);
            this.GroupBox_PaneConstructionLayers.Controls.Add(this.Button_Add);
            this.GroupBox_PaneConstructionLayers.Controls.Add(this.Button_Up);
            this.GroupBox_PaneConstructionLayers.Controls.Add(this.Button_Down);
            this.GroupBox_PaneConstructionLayers.Location = new System.Drawing.Point(15, 110);
            this.GroupBox_PaneConstructionLayers.Name = "GroupBox_PaneConstructionLayers";
            this.GroupBox_PaneConstructionLayers.Size = new System.Drawing.Size(455, 295);
            this.GroupBox_PaneConstructionLayers.TabIndex = 11;
            this.GroupBox_PaneConstructionLayers.TabStop = false;
            this.GroupBox_PaneConstructionLayers.Text = "Pane Construction";
            // 
            // GroupBox_FrameConstruction
            // 
            this.GroupBox_FrameConstruction.Controls.Add(this.DataGridView_FrameConstruction);
            this.GroupBox_FrameConstruction.Controls.Add(this.button1);
            this.GroupBox_FrameConstruction.Controls.Add(this.button2);
            this.GroupBox_FrameConstruction.Controls.Add(this.button3);
            this.GroupBox_FrameConstruction.Controls.Add(this.button4);
            this.GroupBox_FrameConstruction.Location = new System.Drawing.Point(12, 429);
            this.GroupBox_FrameConstruction.Name = "GroupBox_FrameConstruction";
            this.GroupBox_FrameConstruction.Size = new System.Drawing.Size(455, 295);
            this.GroupBox_FrameConstruction.TabIndex = 12;
            this.GroupBox_FrameConstruction.TabStop = false;
            this.GroupBox_FrameConstruction.Text = "Frame Construction";
            // 
            // DataGridView_FrameConstruction
            // 
            this.DataGridView_FrameConstruction.AllowUserToAddRows = false;
            this.DataGridView_FrameConstruction.AllowUserToDeleteRows = false;
            this.DataGridView_FrameConstruction.AllowUserToResizeRows = false;
            this.DataGridView_FrameConstruction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_FrameConstruction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridView_FrameConstruction.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGridView_FrameConstruction.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_FrameConstruction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_FrameConstruction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.DataGridView_FrameConstruction.Location = new System.Drawing.Point(6, 31);
            this.DataGridView_FrameConstruction.Name = "DataGridView_FrameConstruction";
            this.DataGridView_FrameConstruction.RowHeadersVisible = false;
            this.DataGridView_FrameConstruction.RowHeadersWidth = 51;
            this.DataGridView_FrameConstruction.RowTemplate.Height = 24;
            this.DataGridView_FrameConstruction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_FrameConstruction.Size = new System.Drawing.Size(443, 224);
            this.DataGridView_FrameConstruction.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Material Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 30F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Thickness";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(374, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(293, 261);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 28);
            this.button2.TabIndex = 5;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(6, 261);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 28);
            this.button3.TabIndex = 8;
            this.button3.Text = "Up";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(67, 261);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 28);
            this.button4.TabIndex = 7;
            this.button4.Text = "Down";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // ApertureConstructionForm
            // 
            this.AcceptButton = this.Button_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Button_Cancel;
            this.ClientSize = new System.Drawing.Size(482, 803);
            this.Controls.Add(this.GroupBox_FrameConstruction);
            this.Controls.Add(this.GroupBox_PaneConstructionLayers);
            this.Controls.Add(this.ComboBox_ApertureType);
            this.Controls.Add(this.Label_ApertureType);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.TextBox_Name);
            this.Controls.Add(this.Label_Name);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 1000);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "ApertureConstructionForm";
            this.ShowIcon = false;
            this.Text = "Aperture Construction";
            this.Load += new System.EventHandler(this.ApertureConstructionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Layers)).EndInit();
            this.GroupBox_PaneConstructionLayers.ResumeLayout(false);
            this.GroupBox_FrameConstruction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_FrameConstruction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.TextBox TextBox_Name;
        private System.Windows.Forms.DataGridView DataGridView_Layers;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.Button Button_Add;
        private System.Windows.Forms.Button Button_Remove;
        private System.Windows.Forms.Button Button_Down;
        private System.Windows.Forms.Button Button_Up;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_MaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Thickness;
        private System.Windows.Forms.Label Label_ApertureType;
        private System.Windows.Forms.ComboBox ComboBox_ApertureType;
        private System.Windows.Forms.GroupBox GroupBox_PaneConstructionLayers;
        private System.Windows.Forms.GroupBox GroupBox_FrameConstruction;
        private System.Windows.Forms.DataGridView DataGridView_FrameConstruction;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}
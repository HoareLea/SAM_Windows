
namespace SAM.Architectural.Windows
{
    partial class MaterialLayersControl
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
            this.DataGridView_Layers = new System.Windows.Forms.DataGridView();
            this.Column_MaterialName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Thickness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Button_Remove = new System.Windows.Forms.Button();
            this.Button_Add = new System.Windows.Forms.Button();
            this.Button_Up = new System.Windows.Forms.Button();
            this.Button_Down = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Layers)).BeginInit();
            this.SuspendLayout();
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
            this.DataGridView_Layers.Location = new System.Drawing.Point(3, 3);
            this.DataGridView_Layers.Name = "DataGridView_Layers";
            this.DataGridView_Layers.RowHeadersVisible = false;
            this.DataGridView_Layers.RowHeadersWidth = 51;
            this.DataGridView_Layers.RowTemplate.Height = 24;
            this.DataGridView_Layers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_Layers.Size = new System.Drawing.Size(344, 210);
            this.DataGridView_Layers.TabIndex = 2;
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
            // Button_Remove
            // 
            this.Button_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Remove.Location = new System.Drawing.Point(272, 219);
            this.Button_Remove.Name = "Button_Remove";
            this.Button_Remove.Size = new System.Drawing.Size(75, 28);
            this.Button_Remove.TabIndex = 6;
            this.Button_Remove.Text = "Remove";
            this.Button_Remove.UseVisualStyleBackColor = true;
            this.Button_Remove.Click += new System.EventHandler(this.Button_Remove_Click);
            // 
            // Button_Add
            // 
            this.Button_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Add.Location = new System.Drawing.Point(191, 219);
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Size = new System.Drawing.Size(75, 28);
            this.Button_Add.TabIndex = 5;
            this.Button_Add.Text = "Add";
            this.Button_Add.UseVisualStyleBackColor = true;
            this.Button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // Button_Up
            // 
            this.Button_Up.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_Up.Location = new System.Drawing.Point(3, 219);
            this.Button_Up.Name = "Button_Up";
            this.Button_Up.Size = new System.Drawing.Size(55, 28);
            this.Button_Up.TabIndex = 8;
            this.Button_Up.Text = "Up";
            this.Button_Up.UseVisualStyleBackColor = true;
            this.Button_Up.Click += new System.EventHandler(this.Button_Up_Click);
            // 
            // Button_Down
            // 
            this.Button_Down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_Down.Location = new System.Drawing.Point(64, 219);
            this.Button_Down.Name = "Button_Down";
            this.Button_Down.Size = new System.Drawing.Size(55, 28);
            this.Button_Down.TabIndex = 7;
            this.Button_Down.Text = "Down";
            this.Button_Down.UseVisualStyleBackColor = true;
            this.Button_Down.Click += new System.EventHandler(this.Button_Down_Click);
            // 
            // MaterialLayersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridView_Layers);
            this.Controls.Add(this.Button_Remove);
            this.Controls.Add(this.Button_Add);
            this.Controls.Add(this.Button_Down);
            this.Controls.Add(this.Button_Up);
            this.Name = "MaterialLayersControl";
            this.Size = new System.Drawing.Size(350, 250);
            this.Load += new System.EventHandler(this.MaterialLayersControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Layers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView_Layers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_MaterialName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Thickness;
        private System.Windows.Forms.Button Button_Remove;
        private System.Windows.Forms.Button Button_Add;
        private System.Windows.Forms.Button Button_Up;
        private System.Windows.Forms.Button Button_Down;
    }
}

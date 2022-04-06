
namespace SAM.Analytical.Windows.Forms
{
    partial class ApertureForm
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
            this.PropertyGrid_Parameters = new System.Windows.Forms.PropertyGrid();
            this.Label_Name = new System.Windows.Forms.Label();
            this.TextBox_Name = new System.Windows.Forms.TextBox();
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.TextBox_Guid = new System.Windows.Forms.TextBox();
            this.Label_DisplayName = new System.Windows.Forms.Label();
            this.TextBox_Construction = new System.Windows.Forms.TextBox();
            this.Label_Construction = new System.Windows.Forms.Label();
            this.Button_SelectConstruction = new System.Windows.Forms.Button();
            this.Label_ApertureType = new System.Windows.Forms.Label();
            this.ComboBox_ApertureType = new System.Windows.Forms.ComboBox();
            this.TextBox_Area = new System.Windows.Forms.TextBox();
            this.Label_Area = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PropertyGrid_Parameters
            // 
            this.PropertyGrid_Parameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyGrid_Parameters.Location = new System.Drawing.Point(15, 188);
            this.PropertyGrid_Parameters.Name = "PropertyGrid_Parameters";
            this.PropertyGrid_Parameters.Size = new System.Drawing.Size(355, 319);
            this.PropertyGrid_Parameters.TabIndex = 0;
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Location = new System.Drawing.Point(12, 15);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(49, 17);
            this.Label_Name.TabIndex = 1;
            this.Label_Name.Text = "Name:";
            // 
            // TextBox_Name
            // 
            this.TextBox_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Name.Location = new System.Drawing.Point(121, 12);
            this.TextBox_Name.Name = "TextBox_Name";
            this.TextBox_Name.ReadOnly = true;
            this.TextBox_Name.Size = new System.Drawing.Size(249, 22);
            this.TextBox_Name.TabIndex = 2;
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.Location = new System.Drawing.Point(214, 513);
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
            this.Button_Cancel.Location = new System.Drawing.Point(295, 513);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 28);
            this.Button_Cancel.TabIndex = 5;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // TextBox_Guid
            // 
            this.TextBox_Guid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Guid.Location = new System.Drawing.Point(121, 40);
            this.TextBox_Guid.Name = "TextBox_Guid";
            this.TextBox_Guid.ReadOnly = true;
            this.TextBox_Guid.Size = new System.Drawing.Size(249, 22);
            this.TextBox_Guid.TabIndex = 8;
            // 
            // Label_DisplayName
            // 
            this.Label_DisplayName.AutoSize = true;
            this.Label_DisplayName.Location = new System.Drawing.Point(12, 43);
            this.Label_DisplayName.Name = "Label_DisplayName";
            this.Label_DisplayName.Size = new System.Drawing.Size(42, 17);
            this.Label_DisplayName.TabIndex = 7;
            this.Label_DisplayName.Text = "Guid:";
            // 
            // TextBox_Construction
            // 
            this.TextBox_Construction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Construction.Location = new System.Drawing.Point(121, 68);
            this.TextBox_Construction.Name = "TextBox_Construction";
            this.TextBox_Construction.ReadOnly = true;
            this.TextBox_Construction.Size = new System.Drawing.Size(249, 22);
            this.TextBox_Construction.TabIndex = 10;
            // 
            // Label_Construction
            // 
            this.Label_Construction.AutoSize = true;
            this.Label_Construction.Location = new System.Drawing.Point(12, 71);
            this.Label_Construction.Name = "Label_Construction";
            this.Label_Construction.Size = new System.Drawing.Size(91, 17);
            this.Label_Construction.TabIndex = 9;
            this.Label_Construction.Text = "Construction:";
            // 
            // Button_SelectConstruction
            // 
            this.Button_SelectConstruction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_SelectConstruction.Location = new System.Drawing.Point(121, 96);
            this.Button_SelectConstruction.Name = "Button_SelectConstruction";
            this.Button_SelectConstruction.Size = new System.Drawing.Size(249, 28);
            this.Button_SelectConstruction.TabIndex = 11;
            this.Button_SelectConstruction.Text = "Select Construction";
            this.Button_SelectConstruction.UseVisualStyleBackColor = true;
            this.Button_SelectConstruction.Click += new System.EventHandler(this.Button_SelectConstruction_Click);
            // 
            // Label_ApertureType
            // 
            this.Label_ApertureType.AutoSize = true;
            this.Label_ApertureType.Location = new System.Drawing.Point(12, 133);
            this.Label_ApertureType.Name = "Label_ApertureType";
            this.Label_ApertureType.Size = new System.Drawing.Size(103, 17);
            this.Label_ApertureType.TabIndex = 9;
            this.Label_ApertureType.Text = "Aperture Type:";
            // 
            // ComboBox_ApertureType
            // 
            this.ComboBox_ApertureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_ApertureType.Enabled = false;
            this.ComboBox_ApertureType.FormattingEnabled = true;
            this.ComboBox_ApertureType.Location = new System.Drawing.Point(121, 130);
            this.ComboBox_ApertureType.Name = "ComboBox_ApertureType";
            this.ComboBox_ApertureType.Size = new System.Drawing.Size(249, 24);
            this.ComboBox_ApertureType.TabIndex = 12;
            // 
            // TextBox_Area
            // 
            this.TextBox_Area.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Area.Location = new System.Drawing.Point(121, 160);
            this.TextBox_Area.Name = "TextBox_Area";
            this.TextBox_Area.ReadOnly = true;
            this.TextBox_Area.Size = new System.Drawing.Size(69, 22);
            this.TextBox_Area.TabIndex = 14;
            // 
            // Label_Area
            // 
            this.Label_Area.AutoSize = true;
            this.Label_Area.Location = new System.Drawing.Point(13, 163);
            this.Label_Area.Name = "Label_Area";
            this.Label_Area.Size = new System.Drawing.Size(42, 17);
            this.Label_Area.TabIndex = 13;
            this.Label_Area.Text = "Area:";
            // 
            // ApertureForm
            // 
            this.AcceptButton = this.Button_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Button_Cancel;
            this.ClientSize = new System.Drawing.Size(382, 553);
            this.Controls.Add(this.TextBox_Area);
            this.Controls.Add(this.Label_Area);
            this.Controls.Add(this.ComboBox_ApertureType);
            this.Controls.Add(this.Button_SelectConstruction);
            this.Controls.Add(this.TextBox_Construction);
            this.Controls.Add(this.Label_ApertureType);
            this.Controls.Add(this.Label_Construction);
            this.Controls.Add(this.TextBox_Guid);
            this.Controls.Add(this.Label_DisplayName);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.TextBox_Name);
            this.Controls.Add(this.Label_Name);
            this.Controls.Add(this.PropertyGrid_Parameters);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "ApertureForm";
            this.ShowIcon = false;
            this.Text = "Aperture";
            this.Load += new System.EventHandler(this.MaterialForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid PropertyGrid_Parameters;
        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.TextBox TextBox_Name;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.TextBox TextBox_Guid;
        private System.Windows.Forms.Label Label_DisplayName;
        private System.Windows.Forms.TextBox TextBox_Construction;
        private System.Windows.Forms.Label Label_Construction;
        private System.Windows.Forms.Button Button_SelectConstruction;
        private System.Windows.Forms.Label Label_ApertureType;
        private System.Windows.Forms.ComboBox ComboBox_ApertureType;
        private System.Windows.Forms.TextBox TextBox_Area;
        private System.Windows.Forms.Label Label_Area;
    }
}
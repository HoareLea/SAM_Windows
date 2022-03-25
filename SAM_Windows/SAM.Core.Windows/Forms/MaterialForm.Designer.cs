
namespace SAM.Core.Windows.Forms
{
    partial class MaterialForm
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
            this.TextBox_DisplayName = new System.Windows.Forms.TextBox();
            this.Label_DisplayName = new System.Windows.Forms.Label();
            this.TextBox_Description = new System.Windows.Forms.TextBox();
            this.Label_Description = new System.Windows.Forms.Label();
            this.TextBox_ThermalConductivity = new System.Windows.Forms.TextBox();
            this.Label_ThermalConductivity = new System.Windows.Forms.Label();
            this.Label_SpecificHeatCapacity = new System.Windows.Forms.Label();
            this.TextBox_SpecificHeatCapacity = new System.Windows.Forms.TextBox();
            this.Label_Density = new System.Windows.Forms.Label();
            this.TextBox_Density = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PropertyGrid_Parameters
            // 
            this.PropertyGrid_Parameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyGrid_Parameters.Location = new System.Drawing.Point(15, 180);
            this.PropertyGrid_Parameters.Name = "PropertyGrid_Parameters";
            this.PropertyGrid_Parameters.Size = new System.Drawing.Size(355, 227);
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
            this.TextBox_Name.Location = new System.Drawing.Point(171, 12);
            this.TextBox_Name.Name = "TextBox_Name";
            this.TextBox_Name.Size = new System.Drawing.Size(199, 22);
            this.TextBox_Name.TabIndex = 2;
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.Location = new System.Drawing.Point(214, 413);
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
            this.Button_Cancel.Location = new System.Drawing.Point(295, 413);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 28);
            this.Button_Cancel.TabIndex = 5;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // TextBox_DisplayName
            // 
            this.TextBox_DisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_DisplayName.Location = new System.Drawing.Point(171, 40);
            this.TextBox_DisplayName.Name = "TextBox_DisplayName";
            this.TextBox_DisplayName.Size = new System.Drawing.Size(199, 22);
            this.TextBox_DisplayName.TabIndex = 8;
            // 
            // Label_DisplayName
            // 
            this.Label_DisplayName.AutoSize = true;
            this.Label_DisplayName.Location = new System.Drawing.Point(12, 43);
            this.Label_DisplayName.Name = "Label_DisplayName";
            this.Label_DisplayName.Size = new System.Drawing.Size(99, 17);
            this.Label_DisplayName.TabIndex = 7;
            this.Label_DisplayName.Text = "Display Name:";
            // 
            // TextBox_Description
            // 
            this.TextBox_Description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Description.Location = new System.Drawing.Point(171, 68);
            this.TextBox_Description.Name = "TextBox_Description";
            this.TextBox_Description.Size = new System.Drawing.Size(199, 22);
            this.TextBox_Description.TabIndex = 10;
            // 
            // Label_Description
            // 
            this.Label_Description.AutoSize = true;
            this.Label_Description.Location = new System.Drawing.Point(12, 71);
            this.Label_Description.Name = "Label_Description";
            this.Label_Description.Size = new System.Drawing.Size(83, 17);
            this.Label_Description.TabIndex = 9;
            this.Label_Description.Text = "Description:";
            // 
            // TextBox_ThermalConductivity
            // 
            this.TextBox_ThermalConductivity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_ThermalConductivity.Location = new System.Drawing.Point(218, 96);
            this.TextBox_ThermalConductivity.Name = "TextBox_ThermalConductivity";
            this.TextBox_ThermalConductivity.Size = new System.Drawing.Size(152, 22);
            this.TextBox_ThermalConductivity.TabIndex = 12;
            // 
            // Label_ThermalConductivity
            // 
            this.Label_ThermalConductivity.AutoSize = true;
            this.Label_ThermalConductivity.Location = new System.Drawing.Point(12, 99);
            this.Label_ThermalConductivity.Name = "Label_ThermalConductivity";
            this.Label_ThermalConductivity.Size = new System.Drawing.Size(193, 17);
            this.Label_ThermalConductivity.TabIndex = 11;
            this.Label_ThermalConductivity.Text = "Thermal Conductivity [W/mK]:";
            // 
            // Label_SpecificHeatCapacity
            // 
            this.Label_SpecificHeatCapacity.AutoSize = true;
            this.Label_SpecificHeatCapacity.Location = new System.Drawing.Point(12, 127);
            this.Label_SpecificHeatCapacity.Name = "Label_SpecificHeatCapacity";
            this.Label_SpecificHeatCapacity.Size = new System.Drawing.Size(200, 17);
            this.Label_SpecificHeatCapacity.TabIndex = 11;
            this.Label_SpecificHeatCapacity.Text = "Specific Heat Capacity [J/kgK]:";
            // 
            // TextBox_SpecificHeatCapacity
            // 
            this.TextBox_SpecificHeatCapacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_SpecificHeatCapacity.Location = new System.Drawing.Point(218, 124);
            this.TextBox_SpecificHeatCapacity.Name = "TextBox_SpecificHeatCapacity";
            this.TextBox_SpecificHeatCapacity.Size = new System.Drawing.Size(152, 22);
            this.TextBox_SpecificHeatCapacity.TabIndex = 12;
            // 
            // Label_Density
            // 
            this.Label_Density.AutoSize = true;
            this.Label_Density.Location = new System.Drawing.Point(12, 155);
            this.Label_Density.Name = "Label_Density";
            this.Label_Density.Size = new System.Drawing.Size(109, 17);
            this.Label_Density.TabIndex = 11;
            this.Label_Density.Text = "Density [kg/m3]:";
            // 
            // TextBox_Density
            // 
            this.TextBox_Density.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Density.Location = new System.Drawing.Point(218, 152);
            this.TextBox_Density.Name = "TextBox_Density";
            this.TextBox_Density.Size = new System.Drawing.Size(152, 22);
            this.TextBox_Density.TabIndex = 12;
            // 
            // MaterialForm
            // 
            this.AcceptButton = this.Button_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Button_Cancel;
            this.ClientSize = new System.Drawing.Size(382, 453);
            this.Controls.Add(this.TextBox_Density);
            this.Controls.Add(this.Label_Density);
            this.Controls.Add(this.TextBox_SpecificHeatCapacity);
            this.Controls.Add(this.Label_SpecificHeatCapacity);
            this.Controls.Add(this.TextBox_ThermalConductivity);
            this.Controls.Add(this.Label_ThermalConductivity);
            this.Controls.Add(this.TextBox_Description);
            this.Controls.Add(this.Label_Description);
            this.Controls.Add(this.TextBox_DisplayName);
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
            this.Name = "MaterialForm";
            this.ShowIcon = false;
            this.Text = "Material";
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
        private System.Windows.Forms.TextBox TextBox_DisplayName;
        private System.Windows.Forms.Label Label_DisplayName;
        private System.Windows.Forms.TextBox TextBox_Description;
        private System.Windows.Forms.Label Label_Description;
        private System.Windows.Forms.TextBox TextBox_ThermalConductivity;
        private System.Windows.Forms.Label Label_ThermalConductivity;
        private System.Windows.Forms.Label Label_SpecificHeatCapacity;
        private System.Windows.Forms.TextBox TextBox_SpecificHeatCapacity;
        private System.Windows.Forms.Label Label_Density;
        private System.Windows.Forms.TextBox TextBox_Density;
    }
}
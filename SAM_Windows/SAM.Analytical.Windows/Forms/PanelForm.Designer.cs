// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

namespace SAM.Analytical.Windows.Forms
{
    partial class PanelForm
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
            PropertyGrid_Parameters = new System.Windows.Forms.PropertyGrid();
            Label_Name = new System.Windows.Forms.Label();
            TextBox_Name = new System.Windows.Forms.TextBox();
            Button_OK = new System.Windows.Forms.Button();
            Button_Cancel = new System.Windows.Forms.Button();
            TextBox_Guid = new System.Windows.Forms.TextBox();
            Label_DisplayName = new System.Windows.Forms.Label();
            TextBox_Construction = new System.Windows.Forms.TextBox();
            Label_Construction = new System.Windows.Forms.Label();
            Button_SelectConstruction = new System.Windows.Forms.Button();
            Label_PanelType = new System.Windows.Forms.Label();
            ComboBox_PanelType = new System.Windows.Forms.ComboBox();
            TextBox_Area = new System.Windows.Forms.TextBox();
            Label_Area = new System.Windows.Forms.Label();
            Label_NetArea = new System.Windows.Forms.Label();
            TextBox_NetArea = new System.Windows.Forms.TextBox();
            TextBox_MaxElevation = new System.Windows.Forms.TextBox();
            Label_MaxElevation = new System.Windows.Forms.Label();
            TextBox_MinElevation = new System.Windows.Forms.TextBox();
            Label_MinElevation = new System.Windows.Forms.Label();
            TextBox_Azimuth = new System.Windows.Forms.TextBox();
            Label_Azimuth = new System.Windows.Forms.Label();
            TextBox_PanelGroup = new System.Windows.Forms.TextBox();
            Label_PanelGroup = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // PropertyGrid_Parameters
            // 
            PropertyGrid_Parameters.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            PropertyGrid_Parameters.Location = new System.Drawing.Point(15, 289);
            PropertyGrid_Parameters.Name = "PropertyGrid_Parameters";
            PropertyGrid_Parameters.Size = new System.Drawing.Size(355, 418);
            PropertyGrid_Parameters.TabIndex = 0;
            // 
            // Label_Name
            // 
            Label_Name.AutoSize = true;
            Label_Name.Location = new System.Drawing.Point(12, 15);
            Label_Name.Name = "Label_Name";
            Label_Name.Size = new System.Drawing.Size(52, 20);
            Label_Name.TabIndex = 1;
            Label_Name.Text = "Name:";
            // 
            // TextBox_Name
            // 
            TextBox_Name.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TextBox_Name.Location = new System.Drawing.Point(117, 12);
            TextBox_Name.Name = "TextBox_Name";
            TextBox_Name.ReadOnly = true;
            TextBox_Name.Size = new System.Drawing.Size(253, 27);
            TextBox_Name.TabIndex = 2;
            // 
            // Button_OK
            // 
            Button_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            Button_OK.Location = new System.Drawing.Point(214, 713);
            Button_OK.Name = "Button_OK";
            Button_OK.Size = new System.Drawing.Size(75, 28);
            Button_OK.TabIndex = 6;
            Button_OK.Text = "OK";
            Button_OK.UseVisualStyleBackColor = true;
            Button_OK.Click += Button_OK_Click;
            // 
            // Button_Cancel
            // 
            Button_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Button_Cancel.Location = new System.Drawing.Point(295, 713);
            Button_Cancel.Name = "Button_Cancel";
            Button_Cancel.Size = new System.Drawing.Size(75, 28);
            Button_Cancel.TabIndex = 5;
            Button_Cancel.Text = "Cancel";
            Button_Cancel.UseVisualStyleBackColor = true;
            Button_Cancel.Click += Button_Cancel_Click;
            // 
            // TextBox_Guid
            // 
            TextBox_Guid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TextBox_Guid.Location = new System.Drawing.Point(117, 40);
            TextBox_Guid.Name = "TextBox_Guid";
            TextBox_Guid.ReadOnly = true;
            TextBox_Guid.Size = new System.Drawing.Size(253, 27);
            TextBox_Guid.TabIndex = 8;
            // 
            // Label_DisplayName
            // 
            Label_DisplayName.AutoSize = true;
            Label_DisplayName.Location = new System.Drawing.Point(12, 43);
            Label_DisplayName.Name = "Label_DisplayName";
            Label_DisplayName.Size = new System.Drawing.Size(43, 20);
            Label_DisplayName.TabIndex = 7;
            Label_DisplayName.Text = "Guid:";
            // 
            // TextBox_Construction
            // 
            TextBox_Construction.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TextBox_Construction.Location = new System.Drawing.Point(117, 68);
            TextBox_Construction.Name = "TextBox_Construction";
            TextBox_Construction.ReadOnly = true;
            TextBox_Construction.Size = new System.Drawing.Size(253, 27);
            TextBox_Construction.TabIndex = 10;
            // 
            // Label_Construction
            // 
            Label_Construction.AutoSize = true;
            Label_Construction.Location = new System.Drawing.Point(12, 71);
            Label_Construction.Name = "Label_Construction";
            Label_Construction.Size = new System.Drawing.Size(95, 20);
            Label_Construction.TabIndex = 9;
            Label_Construction.Text = "Construction:";
            // 
            // Button_SelectConstruction
            // 
            Button_SelectConstruction.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            Button_SelectConstruction.Location = new System.Drawing.Point(117, 96);
            Button_SelectConstruction.Name = "Button_SelectConstruction";
            Button_SelectConstruction.Size = new System.Drawing.Size(253, 28);
            Button_SelectConstruction.TabIndex = 11;
            Button_SelectConstruction.Text = "Select Construction";
            Button_SelectConstruction.UseVisualStyleBackColor = true;
            Button_SelectConstruction.Click += Button_SelectConstruction_Click;
            // 
            // Label_PanelType
            // 
            Label_PanelType.AutoSize = true;
            Label_PanelType.Location = new System.Drawing.Point(12, 133);
            Label_PanelType.Name = "Label_PanelType";
            Label_PanelType.Size = new System.Drawing.Size(82, 20);
            Label_PanelType.TabIndex = 9;
            Label_PanelType.Text = "Panel Type:";
            // 
            // ComboBox_PanelType
            // 
            ComboBox_PanelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ComboBox_PanelType.FormattingEnabled = true;
            ComboBox_PanelType.Location = new System.Drawing.Point(118, 130);
            ComboBox_PanelType.Name = "ComboBox_PanelType";
            ComboBox_PanelType.Size = new System.Drawing.Size(252, 28);
            ComboBox_PanelType.TabIndex = 12;
            ComboBox_PanelType.SelectedIndexChanged += ComboBox_PanelType_SelectedIndexChanged;
            // 
            // TextBox_Area
            // 
            TextBox_Area.Location = new System.Drawing.Point(117, 197);
            TextBox_Area.Name = "TextBox_Area";
            TextBox_Area.ReadOnly = true;
            TextBox_Area.Size = new System.Drawing.Size(69, 27);
            TextBox_Area.TabIndex = 14;
            // 
            // Label_Area
            // 
            Label_Area.AutoSize = true;
            Label_Area.Location = new System.Drawing.Point(12, 200);
            Label_Area.Name = "Label_Area";
            Label_Area.Size = new System.Drawing.Size(43, 20);
            Label_Area.TabIndex = 13;
            Label_Area.Text = "Area:";
            // 
            // Label_NetArea
            // 
            Label_NetArea.AutoSize = true;
            Label_NetArea.Location = new System.Drawing.Point(225, 200);
            Label_NetArea.Name = "Label_NetArea";
            Label_NetArea.Size = new System.Drawing.Size(71, 20);
            Label_NetArea.TabIndex = 13;
            Label_NetArea.Text = "Net Area:";
            // 
            // TextBox_NetArea
            // 
            TextBox_NetArea.Location = new System.Drawing.Point(299, 197);
            TextBox_NetArea.Name = "TextBox_NetArea";
            TextBox_NetArea.ReadOnly = true;
            TextBox_NetArea.Size = new System.Drawing.Size(70, 27);
            TextBox_NetArea.TabIndex = 14;
            // 
            // TextBox_MaxElevation
            // 
            TextBox_MaxElevation.Location = new System.Drawing.Point(299, 228);
            TextBox_MaxElevation.Name = "TextBox_MaxElevation";
            TextBox_MaxElevation.ReadOnly = true;
            TextBox_MaxElevation.Size = new System.Drawing.Size(70, 27);
            TextBox_MaxElevation.TabIndex = 17;
            // 
            // Label_MaxElevation
            // 
            Label_MaxElevation.AutoSize = true;
            Label_MaxElevation.Location = new System.Drawing.Point(194, 231);
            Label_MaxElevation.Name = "Label_MaxElevation";
            Label_MaxElevation.Size = new System.Drawing.Size(105, 20);
            Label_MaxElevation.TabIndex = 15;
            Label_MaxElevation.Text = "Max Elevation:";
            // 
            // TextBox_MinElevation
            // 
            TextBox_MinElevation.Location = new System.Drawing.Point(117, 228);
            TextBox_MinElevation.Name = "TextBox_MinElevation";
            TextBox_MinElevation.ReadOnly = true;
            TextBox_MinElevation.Size = new System.Drawing.Size(69, 27);
            TextBox_MinElevation.TabIndex = 18;
            // 
            // Label_MinElevation
            // 
            Label_MinElevation.AutoSize = true;
            Label_MinElevation.Location = new System.Drawing.Point(12, 231);
            Label_MinElevation.Name = "Label_MinElevation";
            Label_MinElevation.Size = new System.Drawing.Size(102, 20);
            Label_MinElevation.TabIndex = 16;
            Label_MinElevation.Text = "Min Elevation:";
            // 
            // TextBox_Azimuth
            // 
            TextBox_Azimuth.Location = new System.Drawing.Point(116, 256);
            TextBox_Azimuth.Name = "TextBox_Azimuth";
            TextBox_Azimuth.ReadOnly = true;
            TextBox_Azimuth.Size = new System.Drawing.Size(69, 27);
            TextBox_Azimuth.TabIndex = 20;
            // 
            // Label_Azimuth
            // 
            Label_Azimuth.AutoSize = true;
            Label_Azimuth.Location = new System.Drawing.Point(11, 259);
            Label_Azimuth.Name = "Label_Azimuth";
            Label_Azimuth.Size = new System.Drawing.Size(67, 20);
            Label_Azimuth.TabIndex = 19;
            Label_Azimuth.Text = "Azimuth:";
            // 
            // TextBox_PanelGroup
            // 
            TextBox_PanelGroup.Location = new System.Drawing.Point(118, 164);
            TextBox_PanelGroup.Name = "TextBox_PanelGroup";
            TextBox_PanelGroup.ReadOnly = true;
            TextBox_PanelGroup.Size = new System.Drawing.Size(252, 27);
            TextBox_PanelGroup.TabIndex = 22;
            // 
            // Label_PanelGroup
            // 
            Label_PanelGroup.AutoSize = true;
            Label_PanelGroup.Location = new System.Drawing.Point(13, 167);
            Label_PanelGroup.Name = "Label_PanelGroup";
            Label_PanelGroup.Size = new System.Drawing.Size(92, 20);
            Label_PanelGroup.TabIndex = 21;
            Label_PanelGroup.Text = "Panel Group:";
            // 
            // PanelForm
            // 
            AcceptButton = Button_OK;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            CancelButton = Button_Cancel;
            ClientSize = new System.Drawing.Size(382, 753);
            Controls.Add(TextBox_PanelGroup);
            Controls.Add(Label_PanelGroup);
            Controls.Add(TextBox_Azimuth);
            Controls.Add(Label_Azimuth);
            Controls.Add(TextBox_MaxElevation);
            Controls.Add(Label_MaxElevation);
            Controls.Add(TextBox_MinElevation);
            Controls.Add(Label_MinElevation);
            Controls.Add(TextBox_NetArea);
            Controls.Add(Label_NetArea);
            Controls.Add(TextBox_Area);
            Controls.Add(Label_Area);
            Controls.Add(ComboBox_PanelType);
            Controls.Add(Button_SelectConstruction);
            Controls.Add(TextBox_Construction);
            Controls.Add(Label_PanelType);
            Controls.Add(Label_Construction);
            Controls.Add(TextBox_Guid);
            Controls.Add(Label_DisplayName);
            Controls.Add(Button_OK);
            Controls.Add(Button_Cancel);
            Controls.Add(TextBox_Name);
            Controls.Add(Label_Name);
            Controls.Add(PropertyGrid_Parameters);
            KeyPreview = true;
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(800, 800);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(400, 500);
            Name = "PanelForm";
            ShowIcon = false;
            Text = "Panel";
            Load += MaterialForm_Load;
            KeyDown += PanelForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.Label Label_PanelType;
        private System.Windows.Forms.ComboBox ComboBox_PanelType;
        private System.Windows.Forms.TextBox TextBox_Area;
        private System.Windows.Forms.Label Label_Area;
        private System.Windows.Forms.Label Label_NetArea;
        private System.Windows.Forms.TextBox TextBox_NetArea;
        private System.Windows.Forms.TextBox TextBox_MaxElevation;
        private System.Windows.Forms.Label Label_MaxElevation;
        private System.Windows.Forms.TextBox TextBox_MinElevation;
        private System.Windows.Forms.Label Label_MinElevation;
        private System.Windows.Forms.TextBox TextBox_Azimuth;
        private System.Windows.Forms.Label Label_Azimuth;
        private System.Windows.Forms.TextBox TextBox_PanelGroup;
        private System.Windows.Forms.Label Label_PanelGroup;
    }
}
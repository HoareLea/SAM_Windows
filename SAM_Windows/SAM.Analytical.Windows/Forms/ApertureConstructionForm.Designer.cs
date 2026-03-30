// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

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
            Label_Name = new System.Windows.Forms.Label();
            TextBox_Name = new System.Windows.Forms.TextBox();
            Button_OK = new System.Windows.Forms.Button();
            Button_Cancel = new System.Windows.Forms.Button();
            Label_ApertureType = new System.Windows.Forms.Label();
            ComboBox_ApertureType = new System.Windows.Forms.ComboBox();
            GroupBox_PaneConstructionLayers = new System.Windows.Forms.GroupBox();
            MaterialLayersControl_Pane = new SAM.Architectural.Windows.MaterialLayersControl();
            GroupBox_FrameConstruction = new System.Windows.Forms.GroupBox();
            MaterialLayersControl_Frame = new SAM.Architectural.Windows.MaterialLayersControl();
            SplitContainer_Construction = new System.Windows.Forms.SplitContainer();
            TextBox_Description = new System.Windows.Forms.TextBox();
            Label_Description = new System.Windows.Forms.Label();
            Button_CopyFromConstruction = new System.Windows.Forms.Button();
            GroupBox_PaneConstructionLayers.SuspendLayout();
            GroupBox_FrameConstruction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SplitContainer_Construction).BeginInit();
            SplitContainer_Construction.Panel1.SuspendLayout();
            SplitContainer_Construction.Panel2.SuspendLayout();
            SplitContainer_Construction.SuspendLayout();
            SuspendLayout();
            // 
            // Label_Name
            // 
            Label_Name.AutoSize = true;
            Label_Name.Location = new System.Drawing.Point(12, 25);
            Label_Name.Name = "Label_Name";
            Label_Name.Size = new System.Drawing.Size(52, 20);
            Label_Name.TabIndex = 0;
            Label_Name.Text = "Name:";
            // 
            // TextBox_Name
            // 
            TextBox_Name.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TextBox_Name.Location = new System.Drawing.Point(96, 22);
            TextBox_Name.Name = "TextBox_Name";
            TextBox_Name.Size = new System.Drawing.Size(374, 27);
            TextBox_Name.TabIndex = 1;
            // 
            // Button_OK
            // 
            Button_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            Button_OK.Location = new System.Drawing.Point(314, 813);
            Button_OK.Name = "Button_OK";
            Button_OK.Size = new System.Drawing.Size(75, 28);
            Button_OK.TabIndex = 4;
            Button_OK.Text = "OK";
            Button_OK.UseVisualStyleBackColor = true;
            Button_OK.Click += Button_OK_Click;
            // 
            // Button_Cancel
            // 
            Button_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Button_Cancel.Location = new System.Drawing.Point(395, 813);
            Button_Cancel.Name = "Button_Cancel";
            Button_Cancel.Size = new System.Drawing.Size(75, 28);
            Button_Cancel.TabIndex = 3;
            Button_Cancel.Text = "Cancel";
            Button_Cancel.UseVisualStyleBackColor = true;
            Button_Cancel.Click += Button_Cancel_Click;
            // 
            // Label_ApertureType
            // 
            Label_ApertureType.AutoSize = true;
            Label_ApertureType.Location = new System.Drawing.Point(15, 81);
            Label_ApertureType.Name = "Label_ApertureType";
            Label_ApertureType.Size = new System.Drawing.Size(105, 20);
            Label_ApertureType.TabIndex = 9;
            Label_ApertureType.Text = "Aperture Type:";
            // 
            // ComboBox_ApertureType
            // 
            ComboBox_ApertureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ComboBox_ApertureType.FormattingEnabled = true;
            ComboBox_ApertureType.Location = new System.Drawing.Point(254, 78);
            ComboBox_ApertureType.Name = "ComboBox_ApertureType";
            ComboBox_ApertureType.Size = new System.Drawing.Size(216, 28);
            ComboBox_ApertureType.TabIndex = 10;
            // 
            // GroupBox_PaneConstructionLayers
            // 
            GroupBox_PaneConstructionLayers.Controls.Add(MaterialLayersControl_Pane);
            GroupBox_PaneConstructionLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            GroupBox_PaneConstructionLayers.Location = new System.Drawing.Point(0, 0);
            GroupBox_PaneConstructionLayers.Name = "GroupBox_PaneConstructionLayers";
            GroupBox_PaneConstructionLayers.Size = new System.Drawing.Size(458, 322);
            GroupBox_PaneConstructionLayers.TabIndex = 11;
            GroupBox_PaneConstructionLayers.TabStop = false;
            GroupBox_PaneConstructionLayers.Text = "Pane Construction";
            // 
            // MaterialLayersControl_Pane
            // 
            MaterialLayersControl_Pane.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            MaterialLayersControl_Pane.Location = new System.Drawing.Point(6, 21);
            MaterialLayersControl_Pane.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaterialLayersControl_Pane.MinimumSize = new System.Drawing.Size(350, 300);
            MaterialLayersControl_Pane.Name = "MaterialLayersControl_Pane";
            MaterialLayersControl_Pane.Size = new System.Drawing.Size(440, 300);
            MaterialLayersControl_Pane.TabIndex = 0;
            // 
            // GroupBox_FrameConstruction
            // 
            GroupBox_FrameConstruction.Controls.Add(MaterialLayersControl_Frame);
            GroupBox_FrameConstruction.Dock = System.Windows.Forms.DockStyle.Fill;
            GroupBox_FrameConstruction.Location = new System.Drawing.Point(0, 0);
            GroupBox_FrameConstruction.Name = "GroupBox_FrameConstruction";
            GroupBox_FrameConstruction.Size = new System.Drawing.Size(458, 318);
            GroupBox_FrameConstruction.TabIndex = 12;
            GroupBox_FrameConstruction.TabStop = false;
            GroupBox_FrameConstruction.Text = "Frame Construction";
            // 
            // MaterialLayersControl_Frame
            // 
            MaterialLayersControl_Frame.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            MaterialLayersControl_Frame.Location = new System.Drawing.Point(6, 15);
            MaterialLayersControl_Frame.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaterialLayersControl_Frame.MinimumSize = new System.Drawing.Size(350, 300);
            MaterialLayersControl_Frame.Name = "MaterialLayersControl_Frame";
            MaterialLayersControl_Frame.Size = new System.Drawing.Size(443, 300);
            MaterialLayersControl_Frame.TabIndex = 0;
            // 
            // SplitContainer_Construction
            // 
            SplitContainer_Construction.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            SplitContainer_Construction.Location = new System.Drawing.Point(12, 127);
            SplitContainer_Construction.Name = "SplitContainer_Construction";
            SplitContainer_Construction.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer_Construction.Panel1
            // 
            SplitContainer_Construction.Panel1.Controls.Add(GroupBox_PaneConstructionLayers);
            // 
            // SplitContainer_Construction.Panel2
            // 
            SplitContainer_Construction.Panel2.Controls.Add(GroupBox_FrameConstruction);
            SplitContainer_Construction.Size = new System.Drawing.Size(458, 644);
            SplitContainer_Construction.SplitterDistance = 322;
            SplitContainer_Construction.TabIndex = 13;
            // 
            // TextBox_Description
            // 
            TextBox_Description.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TextBox_Description.Location = new System.Drawing.Point(96, 50);
            TextBox_Description.Name = "TextBox_Description";
            TextBox_Description.Size = new System.Drawing.Size(374, 27);
            TextBox_Description.TabIndex = 15;
            // 
            // Label_Description
            // 
            Label_Description.AutoSize = true;
            Label_Description.Location = new System.Drawing.Point(12, 53);
            Label_Description.Name = "Label_Description";
            Label_Description.Size = new System.Drawing.Size(88, 20);
            Label_Description.TabIndex = 14;
            Label_Description.Text = "Description:";
            // 
            // Button_CopyFromConstruction
            // 
            Button_CopyFromConstruction.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            Button_CopyFromConstruction.Location = new System.Drawing.Point(12, 813);
            Button_CopyFromConstruction.Name = "Button_CopyFromConstruction";
            Button_CopyFromConstruction.Size = new System.Drawing.Size(264, 28);
            Button_CopyFromConstruction.TabIndex = 16;
            Button_CopyFromConstruction.Text = "Copy From ApertureConstruction";
            Button_CopyFromConstruction.UseVisualStyleBackColor = true;
            Button_CopyFromConstruction.Click += Button_CopyFromAprtureConstruction_Click;
            // 
            // ApertureConstructionForm
            // 
            AcceptButton = Button_OK;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            CancelButton = Button_Cancel;
            ClientSize = new System.Drawing.Size(482, 853);
            Controls.Add(Button_CopyFromConstruction);
            Controls.Add(TextBox_Description);
            Controls.Add(Label_Description);
            Controls.Add(SplitContainer_Construction);
            Controls.Add(ComboBox_ApertureType);
            Controls.Add(Label_ApertureType);
            Controls.Add(Button_OK);
            Controls.Add(Button_Cancel);
            Controls.Add(TextBox_Name);
            Controls.Add(Label_Name);
            KeyPreview = true;
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(800, 1000);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(400, 500);
            Name = "ApertureConstructionForm";
            ShowIcon = false;
            Text = "Aperture Construction";
            Load += ApertureConstructionForm_Load;
            KeyDown += ApertureConstructionForm_KeyDown;
            GroupBox_PaneConstructionLayers.ResumeLayout(false);
            GroupBox_FrameConstruction.ResumeLayout(false);
            SplitContainer_Construction.Panel1.ResumeLayout(false);
            SplitContainer_Construction.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SplitContainer_Construction).EndInit();
            SplitContainer_Construction.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.TextBox TextBox_Name;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.Label Label_ApertureType;
        private System.Windows.Forms.ComboBox ComboBox_ApertureType;
        private System.Windows.Forms.GroupBox GroupBox_PaneConstructionLayers;
        private System.Windows.Forms.GroupBox GroupBox_FrameConstruction;
        private System.Windows.Forms.SplitContainer SplitContainer_Construction;
        private Architectural.Windows.MaterialLayersControl MaterialLayersControl_Pane;
        private Architectural.Windows.MaterialLayersControl MaterialLayersControl_Frame;
        private System.Windows.Forms.TextBox TextBox_Description;
        private System.Windows.Forms.Label Label_Description;
        private System.Windows.Forms.Button Button_CopyFromConstruction;
    }
}
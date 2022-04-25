
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
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.Label_ApertureType = new System.Windows.Forms.Label();
            this.ComboBox_ApertureType = new System.Windows.Forms.ComboBox();
            this.GroupBox_PaneConstructionLayers = new System.Windows.Forms.GroupBox();
            this.MaterialLayersControl_Pane = new SAM.Architectural.Windows.MaterialLayersControl();
            this.GroupBox_FrameConstruction = new System.Windows.Forms.GroupBox();
            this.MaterialLayersControl_Frame = new SAM.Architectural.Windows.MaterialLayersControl();
            this.SplitContainer_Construction = new System.Windows.Forms.SplitContainer();
            this.GroupBox_PaneConstructionLayers.SuspendLayout();
            this.GroupBox_FrameConstruction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Construction)).BeginInit();
            this.SplitContainer_Construction.Panel1.SuspendLayout();
            this.SplitContainer_Construction.Panel2.SuspendLayout();
            this.SplitContainer_Construction.SuspendLayout();
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
            this.GroupBox_PaneConstructionLayers.Controls.Add(this.MaterialLayersControl_Pane);
            this.GroupBox_PaneConstructionLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox_PaneConstructionLayers.Location = new System.Drawing.Point(0, 0);
            this.GroupBox_PaneConstructionLayers.Name = "GroupBox_PaneConstructionLayers";
            this.GroupBox_PaneConstructionLayers.Size = new System.Drawing.Size(458, 322);
            this.GroupBox_PaneConstructionLayers.TabIndex = 11;
            this.GroupBox_PaneConstructionLayers.TabStop = false;
            this.GroupBox_PaneConstructionLayers.Text = "Pane Construction";
            // 
            // MaterialLayersControl_Pane
            // 
            this.MaterialLayersControl_Pane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MaterialLayersControl_Pane.Location = new System.Drawing.Point(6, 21);
            this.MaterialLayersControl_Pane.MinimumSize = new System.Drawing.Size(350, 300);
            this.MaterialLayersControl_Pane.Name = "MaterialLayersControl_Pane";
            this.MaterialLayersControl_Pane.Size = new System.Drawing.Size(440, 300);
            this.MaterialLayersControl_Pane.TabIndex = 0;
            // 
            // GroupBox_FrameConstruction
            // 
            this.GroupBox_FrameConstruction.Controls.Add(this.MaterialLayersControl_Frame);
            this.GroupBox_FrameConstruction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox_FrameConstruction.Location = new System.Drawing.Point(0, 0);
            this.GroupBox_FrameConstruction.Name = "GroupBox_FrameConstruction";
            this.GroupBox_FrameConstruction.Size = new System.Drawing.Size(458, 318);
            this.GroupBox_FrameConstruction.TabIndex = 12;
            this.GroupBox_FrameConstruction.TabStop = false;
            this.GroupBox_FrameConstruction.Text = "Frame Construction";
            // 
            // MaterialLayersControl_Frame
            // 
            this.MaterialLayersControl_Frame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MaterialLayersControl_Frame.Location = new System.Drawing.Point(6, 15);
            this.MaterialLayersControl_Frame.MinimumSize = new System.Drawing.Size(350, 300);
            this.MaterialLayersControl_Frame.Name = "MaterialLayersControl_Frame";
            this.MaterialLayersControl_Frame.Size = new System.Drawing.Size(443, 300);
            this.MaterialLayersControl_Frame.TabIndex = 0;
            // 
            // SplitContainer_Construction
            // 
            this.SplitContainer_Construction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer_Construction.Location = new System.Drawing.Point(12, 89);
            this.SplitContainer_Construction.Name = "SplitContainer_Construction";
            this.SplitContainer_Construction.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer_Construction.Panel1
            // 
            this.SplitContainer_Construction.Panel1.Controls.Add(this.GroupBox_PaneConstructionLayers);
            // 
            // SplitContainer_Construction.Panel2
            // 
            this.SplitContainer_Construction.Panel2.Controls.Add(this.GroupBox_FrameConstruction);
            this.SplitContainer_Construction.Size = new System.Drawing.Size(458, 644);
            this.SplitContainer_Construction.SplitterDistance = 322;
            this.SplitContainer_Construction.TabIndex = 13;
            // 
            // ApertureConstructionForm
            // 
            this.AcceptButton = this.Button_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Button_Cancel;
            this.ClientSize = new System.Drawing.Size(482, 803);
            this.Controls.Add(this.SplitContainer_Construction);
            this.Controls.Add(this.ComboBox_ApertureType);
            this.Controls.Add(this.Label_ApertureType);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.TextBox_Name);
            this.Controls.Add(this.Label_Name);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 1000);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "ApertureConstructionForm";
            this.ShowIcon = false;
            this.Text = "Aperture Construction";
            this.Load += new System.EventHandler(this.ApertureConstructionForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ApertureConstructionForm_KeyDown);
            this.GroupBox_PaneConstructionLayers.ResumeLayout(false);
            this.GroupBox_FrameConstruction.ResumeLayout(false);
            this.SplitContainer_Construction.Panel1.ResumeLayout(false);
            this.SplitContainer_Construction.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Construction)).EndInit();
            this.SplitContainer_Construction.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}
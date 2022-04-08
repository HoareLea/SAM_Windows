
namespace SAM.Core.Windows.Forms
{
    partial class SelectMaterialForm
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
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.MaterialControl_Main = new SAM.Core.Windows.MaterialControl();
            this.SplitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.SearchControl_Main = new SAM.Core.Windows.SearchControl();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).BeginInit();
            this.SplitContainer_Main.Panel1.SuspendLayout();
            this.SplitContainer_Main.Panel2.SuspendLayout();
            this.SplitContainer_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.Location = new System.Drawing.Point(514, 435);
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
            this.Button_Cancel.Location = new System.Drawing.Point(595, 435);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 28);
            this.Button_Cancel.TabIndex = 5;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // MaterialControl_Main
            // 
            this.MaterialControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaterialControl_Main.Enums = null;
            this.MaterialControl_Main.Location = new System.Drawing.Point(0, 0);
            this.MaterialControl_Main.Name = "MaterialControl_Main";
            this.MaterialControl_Main.Size = new System.Drawing.Size(351, 417);
            this.MaterialControl_Main.TabIndex = 7;
            // 
            // SplitContainer_Main
            // 
            this.SplitContainer_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer_Main.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer_Main.Location = new System.Drawing.Point(12, 12);
            this.SplitContainer_Main.Name = "SplitContainer_Main";
            // 
            // SplitContainer_Main.Panel1
            // 
            this.SplitContainer_Main.Panel1.Controls.Add(this.SearchControl_Main);
            // 
            // SplitContainer_Main.Panel2
            // 
            this.SplitContainer_Main.Panel2.Controls.Add(this.MaterialControl_Main);
            this.SplitContainer_Main.Size = new System.Drawing.Size(658, 417);
            this.SplitContainer_Main.SplitterDistance = 303;
            this.SplitContainer_Main.TabIndex = 8;
            // 
            // SearchControl_Main
            // 
            this.SearchControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchControl_Main.Location = new System.Drawing.Point(0, 0);
            this.SearchControl_Main.Name = "SearchControl_Main";
            this.SearchControl_Main.SearchObjectWrapper = null;
            this.SearchControl_Main.SearchText = "";
            this.SearchControl_Main.SelectionMode = System.Windows.Forms.SelectionMode.One;
            this.SearchControl_Main.Size = new System.Drawing.Size(303, 417);
            this.SearchControl_Main.TabIndex = 0;
            // 
            // SelectMaterialForm
            // 
            this.AcceptButton = this.Button_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Button_Cancel;
            this.ClientSize = new System.Drawing.Size(682, 475);
            this.Controls.Add(this.SplitContainer_Main);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_Cancel);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "SelectMaterialForm";
            this.ShowIcon = false;
            this.Text = "Select Material";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.SelectMaterialForm_HelpButtonClicked);
            this.Load += new System.EventHandler(this.SelectMaterialForm_Load);
            this.SplitContainer_Main.Panel1.ResumeLayout(false);
            this.SplitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer_Main)).EndInit();
            this.SplitContainer_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
        private MaterialControl MaterialControl_Main;
        private System.Windows.Forms.SplitContainer SplitContainer_Main;
        private SearchControl SearchControl_Main;
    }
}
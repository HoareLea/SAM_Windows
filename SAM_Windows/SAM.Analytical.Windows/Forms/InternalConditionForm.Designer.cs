
namespace SAM.Analytical.Windows.Forms
{
    partial class InternalConditionForm
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
            this.InternalConditionControl_Main = new SAM.Analytical.Windows.Controls.InternalConditionControl();
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InternalConditionControl_Main
            // 
            this.InternalConditionControl_Main.AdjacencyCluster = null;
            this.InternalConditionControl_Main.InternalCondition = null;
            this.InternalConditionControl_Main.Location = new System.Drawing.Point(12, 12);
            this.InternalConditionControl_Main.Name = "InternalConditionControl_Main";
            this.InternalConditionControl_Main.ProfileLibrary = null;
            this.InternalConditionControl_Main.Size = new System.Drawing.Size(849, 1006);
            this.InternalConditionControl_Main.Space = null;
            this.InternalConditionControl_Main.TabIndex = 0;
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.Location = new System.Drawing.Point(701, 1041);
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
            this.Button_Cancel.Location = new System.Drawing.Point(782, 1041);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 28);
            this.Button_Cancel.TabIndex = 5;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // InternalConditionForm
            // 
            this.AcceptButton = this.Button_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Button_Cancel;
            this.ClientSize = new System.Drawing.Size(869, 1081);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.InternalConditionControl_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InternalConditionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Internal Condition";
            this.Load += new System.EventHandler(this.InternalConditionForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.InternalConditionControl InternalConditionControl_Main;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
    }
}

namespace SAM.Analytical.Windows.Forms
{
    partial class SetProfileValueForm
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
            this.TextBox_StartIndex = new System.Windows.Forms.TextBox();
            this.Label_StartIndex = new System.Windows.Forms.Label();
            this.Label_Value = new System.Windows.Forms.Label();
            this.TextBox_Value = new System.Windows.Forms.TextBox();
            this.Label_Count = new System.Windows.Forms.Label();
            this.TextBox_Count = new System.Windows.Forms.TextBox();
            this.CheckBox_Append = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Button_OK
            // 
            this.Button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_OK.Location = new System.Drawing.Point(64, 113);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 28);
            this.Button_OK.TabIndex = 1;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(145, 113);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 28);
            this.Button_Cancel.TabIndex = 2;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // TextBox_StartIndex
            // 
            this.TextBox_StartIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_StartIndex.Location = new System.Drawing.Point(86, 12);
            this.TextBox_StartIndex.MaxLength = 5;
            this.TextBox_StartIndex.Name = "TextBox_StartIndex";
            this.TextBox_StartIndex.Size = new System.Drawing.Size(50, 22);
            this.TextBox_StartIndex.TabIndex = 3;
            // 
            // Label_StartIndex
            // 
            this.Label_StartIndex.AutoSize = true;
            this.Label_StartIndex.Location = new System.Drawing.Point(5, 15);
            this.Label_StartIndex.Name = "Label_StartIndex";
            this.Label_StartIndex.Size = new System.Drawing.Size(75, 17);
            this.Label_StartIndex.TabIndex = 12;
            this.Label_StartIndex.Text = "Start Index";
            // 
            // Label_Value
            // 
            this.Label_Value.AutoSize = true;
            this.Label_Value.Location = new System.Drawing.Point(5, 68);
            this.Label_Value.Name = "Label_Value";
            this.Label_Value.Size = new System.Drawing.Size(44, 17);
            this.Label_Value.TabIndex = 14;
            this.Label_Value.Text = "Value";
            // 
            // TextBox_Value
            // 
            this.TextBox_Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Value.Location = new System.Drawing.Point(86, 69);
            this.TextBox_Value.MaxLength = 10;
            this.TextBox_Value.Name = "TextBox_Value";
            this.TextBox_Value.Size = new System.Drawing.Size(80, 22);
            this.TextBox_Value.TabIndex = 0;
            // 
            // Label_Count
            // 
            this.Label_Count.AutoSize = true;
            this.Label_Count.Location = new System.Drawing.Point(5, 43);
            this.Label_Count.Name = "Label_Count";
            this.Label_Count.Size = new System.Drawing.Size(45, 17);
            this.Label_Count.TabIndex = 16;
            this.Label_Count.Text = "Count";
            // 
            // TextBox_Count
            // 
            this.TextBox_Count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Count.Location = new System.Drawing.Point(86, 40);
            this.TextBox_Count.MaxLength = 5;
            this.TextBox_Count.Name = "TextBox_Count";
            this.TextBox_Count.Size = new System.Drawing.Size(50, 22);
            this.TextBox_Count.TabIndex = 5;
            // 
            // CheckBox_Append
            // 
            this.CheckBox_Append.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBox_Append.AutoSize = true;
            this.CheckBox_Append.Location = new System.Drawing.Point(142, 14);
            this.CheckBox_Append.Name = "CheckBox_Append";
            this.CheckBox_Append.Size = new System.Drawing.Size(79, 21);
            this.CheckBox_Append.TabIndex = 4;
            this.CheckBox_Append.Text = "Append";
            this.CheckBox_Append.UseVisualStyleBackColor = true;
            this.CheckBox_Append.CheckedChanged += new System.EventHandler(this.CheckBox_Append_CheckedChanged);
            // 
            // SetProfileValueForm
            // 
            this.AcceptButton = this.Button_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.Button_Cancel;
            this.ClientSize = new System.Drawing.Size(232, 153);
            this.Controls.Add(this.CheckBox_Append);
            this.Controls.Add(this.Label_Count);
            this.Controls.Add(this.TextBox_Count);
            this.Controls.Add(this.Label_Value);
            this.Controls.Add(this.TextBox_Value);
            this.Controls.Add(this.Label_StartIndex);
            this.Controls.Add(this.TextBox_StartIndex);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Button_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetProfileValueForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Value";
            this.Load += new System.EventHandler(this.SetProfileValueForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.TextBox TextBox_StartIndex;
        private System.Windows.Forms.Label Label_StartIndex;
        private System.Windows.Forms.Label Label_Value;
        private System.Windows.Forms.TextBox TextBox_Value;
        private System.Windows.Forms.Label Label_Count;
        private System.Windows.Forms.TextBox TextBox_Count;
        private System.Windows.Forms.CheckBox CheckBox_Append;
    }
}
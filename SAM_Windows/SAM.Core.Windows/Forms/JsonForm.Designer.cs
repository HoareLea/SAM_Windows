
namespace SAM.Core.Windows.Forms
{
    partial class JsonForm<T>
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
            this.RichTextBox_Main = new System.Windows.Forms.RichTextBox();
            this.Button_Close = new System.Windows.Forms.Button();
            this.Button_Save = new System.Windows.Forms.Button();
            this.Button_Copy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RichTextBox_Main
            // 
            this.RichTextBox_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBox_Main.BackColor = System.Drawing.SystemColors.Window;
            this.RichTextBox_Main.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBox_Main.Location = new System.Drawing.Point(12, 12);
            this.RichTextBox_Main.Name = "RichTextBox_Main";
            this.RichTextBox_Main.ReadOnly = true;
            this.RichTextBox_Main.Size = new System.Drawing.Size(776, 392);
            this.RichTextBox_Main.TabIndex = 0;
            this.RichTextBox_Main.Text = "";
            // 
            // Button_Close
            // 
            this.Button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Close.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Button_Close.Location = new System.Drawing.Point(713, 410);
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Size = new System.Drawing.Size(75, 28);
            this.Button_Close.TabIndex = 7;
            this.Button_Close.Text = "Close";
            this.Button_Close.UseVisualStyleBackColor = true;
            this.Button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // Button_Save
            // 
            this.Button_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_Save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Button_Save.Location = new System.Drawing.Point(12, 410);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(75, 28);
            this.Button_Save.TabIndex = 8;
            this.Button_Save.Text = "Save";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Button_Copy
            // 
            this.Button_Copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button_Copy.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Button_Copy.Location = new System.Drawing.Point(93, 410);
            this.Button_Copy.Name = "Button_Copy";
            this.Button_Copy.Size = new System.Drawing.Size(75, 28);
            this.Button_Copy.TabIndex = 9;
            this.Button_Copy.Text = "Copy";
            this.Button_Copy.UseVisualStyleBackColor = true;
            this.Button_Copy.Click += new System.EventHandler(this.Button_Copy_Click);
            // 
            // JsonForm
            // 
            this.AcceptButton = this.Button_Close;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Button_Close;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Button_Copy);
            this.Controls.Add(this.Button_Save);
            this.Controls.Add(this.Button_Close);
            this.Controls.Add(this.RichTextBox_Main);
            this.Name = "JsonForm";
            this.ShowIcon = false;
            this.Text = "Json";
            this.Load += new System.EventHandler(this.JsonForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RichTextBox_Main;
        private System.Windows.Forms.Button Button_Close;
        private System.Windows.Forms.Button Button_Save;
        private System.Windows.Forms.Button Button_Copy;
    }
}
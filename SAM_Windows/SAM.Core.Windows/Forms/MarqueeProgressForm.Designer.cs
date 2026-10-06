// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020-2026 Michal Dengusiak & Jakub Ziolkowski and contributors

namespace SAM.Core.Windows.Forms
{
    partial class MarqueeProgressForm
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
            this.components = new System.ComponentModel.Container();
            this.Label_Description = new System.Windows.Forms.Label();
            this.Label_Note = new System.Windows.Forms.Label();
            this.ProgressBar_Main = new System.Windows.Forms.ProgressBar();
            // Owned by components so the designer Dispose above stops and releases it with the form.
            this.Timer_Elapsed = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            //
            // Label_Description
            //
            // Both labels sit in the strip above the bar that this form has always left empty, so the client
            // size is unchanged and callers that set neither Description nor Note look exactly as before.
            this.Label_Description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Description.AutoSize = false;
            this.Label_Description.AutoEllipsis = true;
            this.Label_Description.Location = new System.Drawing.Point(12, 8);
            this.Label_Description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Description.Name = "Label_Description";
            this.Label_Description.Size = new System.Drawing.Size(391, 16);
            this.Label_Description.TabIndex = 0;
            this.Label_Description.Text = "";
            //
            // Label_Note
            //
            this.Label_Note.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Note.AutoSize = false;
            this.Label_Note.AutoEllipsis = true;
            this.Label_Note.ForeColor = System.Drawing.SystemColors.GrayText;
            // Two lines and word-wrapping for the same reason as ProgressForm's: the notes are full sentences
            // that a single 391px line would ellipsise. Setting Note grows the form to make room (see
            // MarqueeProgressForm.Note), so a caller that sets neither property keeps the original layout.
            this.Label_Note.Location = new System.Drawing.Point(12, 26);
            this.Label_Note.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Note.Name = "Label_Note";
            this.Label_Note.Size = new System.Drawing.Size(391, 34);
            this.Label_Note.TabIndex = 1;
            this.Label_Note.Text = "";
            this.Label_Note.Visible = false;
            //
            // Timer_Elapsed
            //
            this.Timer_Elapsed.Interval = 500;
            this.Timer_Elapsed.Tick += new System.EventHandler(this.Timer_Elapsed_Tick);
            //
            // ProgressBar_Main
            //
            // Not bottom-anchored: setting Note grows the form to fit the note, and the bar must move down
            // rather than stretch. The form is FixedSingle and never user-resized, so no existing caller is
            // affected.
            this.ProgressBar_Main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar_Main.Location = new System.Drawing.Point(9, 46);
            this.ProgressBar_Main.Margin = new System.Windows.Forms.Padding(4);
            this.ProgressBar_Main.MarqueeAnimationSpeed = 30;
            this.ProgressBar_Main.Name = "ProgressBar_Main";
            this.ProgressBar_Main.Size = new System.Drawing.Size(394, 35);
            this.ProgressBar_Main.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBar_Main.TabIndex = 2;
            // 
            // MarqueeProgressForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(416, 94);
            this.ControlBox = false;
            this.Controls.Add(this.Label_Description);
            this.Controls.Add(this.Label_Note);
            this.Controls.Add(this.ProgressBar_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MarqueeProgressForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loading";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Label_Description;
        private System.Windows.Forms.Label Label_Note;
        private System.Windows.Forms.ProgressBar ProgressBar_Main;
        private System.Windows.Forms.Timer Timer_Elapsed;
    }
}
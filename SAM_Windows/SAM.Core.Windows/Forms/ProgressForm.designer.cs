// SPDX-License-Identifier: LGPL-3.0-or-later
// Copyright (c) 2020–2026 Michal Dengusiak & Jakub Ziolkowski and contributors

namespace SAM.Core.Windows.Forms
{
    partial class ProgressForm
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
            this.Button_Cancel = new System.Windows.Forms.Button();
            // Owned by components so the designer Dispose above stops and releases it with the form. Disabled
            // until ProgressFormHost turns it on - see ProgressForm.OwnsMessageLoop.
            this.Timer_Elapsed = new System.Windows.Forms.Timer(this.components);
            this.Timer_Elapsed.Interval = 500;
            this.Timer_Elapsed.Tick += new System.EventHandler(this.Timer_Elapsed_Tick);
            this.SuspendLayout();
            // 
            // Label_Description
            // 
            this.Label_Description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            // Width-aware ellipsis: the label is a fixed 391px, so any character cap is only a coarse guard.
            // This makes overflow render as a real trailing ellipsis instead of being hard-clipped.
            this.Label_Description.AutoSize = false;
            this.Label_Description.AutoEllipsis = true;
            this.Label_Description.Location = new System.Drawing.Point(16, 19);
            this.Label_Description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Description.Name = "Label_Description";
            this.Label_Description.Size = new System.Drawing.Size(391, 21);
            this.Label_Description.TabIndex = 0;
            this.Label_Description.Text = "Waiting...";
            //
            // Label_Note
            //
            // Secondary text under the main line, shown only when the form is Cancellable. Carries the note
            // about what the Cancel button can and cannot interrupt. Two lines tall and word-wrapping: the
            // notes run to ~90 characters, which a single 391px line ellipsises away to nothing useful.
            // AutoEllipsis stays on purely as a backstop for a pathologically long step name.
            this.Label_Note.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Note.AutoSize = false;
            this.Label_Note.AutoEllipsis = true;
            this.Label_Note.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Label_Note.Location = new System.Drawing.Point(16, 42);
            this.Label_Note.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_Note.Name = "Label_Note";
            this.Label_Note.Size = new System.Drawing.Size(391, 34);
            this.Label_Note.TabIndex = 3;
            this.Label_Note.Visible = false;
            //
            // ProgressBar_Main
            //
            // Not bottom-anchored: Cancellable grows the form to reveal Button_Cancel, and the bar must keep
            // its height rather than stretch over the button. The form is FixedSingle and never user-resized,
            // so this does not affect any existing caller.
            this.ProgressBar_Main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar_Main.Location = new System.Drawing.Point(13, 50);
            this.ProgressBar_Main.Margin = new System.Windows.Forms.Padding(4);
            this.ProgressBar_Main.Name = "ProgressBar_Main";
            this.ProgressBar_Main.Size = new System.Drawing.Size(394, 35);
            this.ProgressBar_Main.TabIndex = 1;
            //
            // Button_Cancel
            //
            // Fixed top-left placement so the position is deterministic when Cancellable grows the form;
            // bottom-anchoring would be measured against the collapsed height and drift.
            this.Button_Cancel.Location = new System.Drawing.Point(311, 127);
            this.Button_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(96, 30);
            this.Button_Cancel.TabIndex = 2;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Visible = false;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            //
            // SimpleProgressForm
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            // Original collapsed height: unchanged for every caller that does not opt into Cancellable.
            this.ClientSize = new System.Drawing.Size(420, 98);
            this.ControlBox = false;
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Label_Note);
            this.Controls.Add(this.ProgressBar_Main);
            this.Controls.Add(this.Label_Description);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimpleProgressForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Loading";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SimpleProgressForm_FormClosing);
            this.Load += new System.EventHandler(this.SimpleProgressForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Label_Description;
        private System.Windows.Forms.Label Label_Note;
        private System.Windows.Forms.ProgressBar ProgressBar_Main;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.Timer Timer_Elapsed;
    }
}
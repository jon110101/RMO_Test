﻿namespace RMO
{
    partial class SubForm
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
            this.PalView = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PalView
            // 
            this.PalView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PalView.Location = new System.Drawing.Point(0, 0);
            this.PalView.Name = "PalView";
            this.PalView.Size = new System.Drawing.Size(749, 468);
            this.PalView.TabIndex = 0;
            // 
            // SubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 468);
            this.Controls.Add(this.PalView);
            this.Name = "SubForm";
            this.Text = "SubForm";
            this.Load += new System.EventHandler(this.SubForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public  System.Windows.Forms.Panel PalView;

    }
}
﻿
namespace PicDector.ImageSensor
{
    partial class ScreenShoter
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
            this.SuspendLayout();
            // 
            // ScreenShoter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(465, 318);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenShoter";
            this.ShowIcon = false;
            this.Text = "ScreenShoter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScreenShoter_FormClosing);
            this.Load += new System.EventHandler(this.ScreenShoter_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ScreenShoter_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenShoter_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ScreenShoter_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
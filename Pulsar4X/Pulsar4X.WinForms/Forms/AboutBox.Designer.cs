﻿namespace Pulsar4X.WinForms.Forms
{
    partial class AboutBox
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
            this.PulsarLogoPicBox = new System.Windows.Forms.PictureBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.AboutTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PulsarLogoPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PulsarLogoPicBox
            // 
            this.PulsarLogoPicBox.Location = new System.Drawing.Point(13, 13);
            this.PulsarLogoPicBox.Name = "PulsarLogoPicBox";
            this.PulsarLogoPicBox.Size = new System.Drawing.Size(100, 96);
            this.PulsarLogoPicBox.TabIndex = 0;
            this.PulsarLogoPicBox.TabStop = false;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(378, 168);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // AboutTextBox
            // 
            this.AboutTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AboutTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.AboutTextBox.Location = new System.Drawing.Point(120, 13);
            this.AboutTextBox.Name = "AboutTextBox";
            this.AboutTextBox.ReadOnly = true;
            this.AboutTextBox.Size = new System.Drawing.Size(334, 148);
            this.AboutTextBox.TabIndex = 1;
            this.AboutTextBox.Text = "";
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 200);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.AboutTextBox);
            this.Controls.Add(this.PulsarLogoPicBox);
            this.Name = "AboutBox";
            this.Text = "AboutBox";
            this.Load += new System.EventHandler(this.AboutBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PulsarLogoPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PulsarLogoPicBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.RichTextBox AboutTextBox;
    }
}
﻿namespace ImageOptimizer
{
    partial class Settings
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
            this.labelSetThreads = new System.Windows.Forms.Label();
            this.nThreads = new System.Windows.Forms.NumericUpDown();
            this.labelKey = new System.Windows.Forms.Label();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.labelSecret = new System.Windows.Forms.Label();
            this.textBoxSecret = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nThreads)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSetThreads
            // 
            this.labelSetThreads.Location = new System.Drawing.Point(33, 19);
            this.labelSetThreads.Name = "labelSetThreads";
            this.labelSetThreads.Size = new System.Drawing.Size(94, 20);
            this.labelSetThreads.TabIndex = 0;
            this.labelSetThreads.Text = "Number of threads";
            this.labelSetThreads.Click += new System.EventHandler(this.labelSetThreads_Click);
            // 
            // nThreads
            // 
            this.nThreads.Location = new System.Drawing.Point(33, 44);
            this.nThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nThreads.Name = "nThreads";
            this.nThreads.Size = new System.Drawing.Size(76, 20);
            this.nThreads.TabIndex = 1;
            this.nThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelKey
            // 
            this.labelKey.Location = new System.Drawing.Point(33, 69);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(66, 20);
            this.labelKey.TabIndex = 2;
            this.labelKey.Text = "Your-api-key";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(33, 94);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(404, 20);
            this.textBoxKey.TabIndex = 3;
            this.textBoxKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelSecret
            // 
            this.labelSecret.Location = new System.Drawing.Point(33, 119);
            this.labelSecret.Name = "labelSecret";
            this.labelSecret.Size = new System.Drawing.Size(404, 20);
            this.labelSecret.TabIndex = 4;
            this.labelSecret.Text = "Your-api-secret";
            // 
            // textBoxSecret
            // 
            this.textBoxSecret.Location = new System.Drawing.Point(33, 144);
            this.textBoxSecret.Name = "textBoxSecret";
            this.textBoxSecret.Size = new System.Drawing.Size(404, 20);
            this.textBoxSecret.TabIndex = 5;
            this.textBoxSecret.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(279, 179);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(76, 23);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(361, 179);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(76, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(459, 224);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxSecret);
            this.Controls.Add(this.labelSecret);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.nThreads);
            this.Controls.Add(this.labelSetThreads);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Settings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.nThreads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSetThreads;
        private System.Windows.Forms.NumericUpDown nThreads;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Label labelSecret;
        private System.Windows.Forms.TextBox textBoxSecret;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}
﻿namespace Advics.Screen.TransitAfterPack
{
    partial class frmZHTP010_TransitAfterPackEntry
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
            this.txtScanQR = new System.Windows.Forms.Label();
            this.txtQRCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtScanQR
            // 
            this.txtScanQR.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtScanQR.Location = new System.Drawing.Point(6, 48);
            this.txtScanQR.Name = "txtScanQR";
            this.txtScanQR.Size = new System.Drawing.Size(132, 18);
            this.txtScanQR.Text = "CaseMark QR Code";
            // 
            // txtQRCode
            // 
            this.txtQRCode.BackColor = System.Drawing.Color.PowderBlue;
            this.txtQRCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtQRCode.Location = new System.Drawing.Point(4, 69);
            this.txtQRCode.Name = "txtQRCode";
            this.txtQRCode.Size = new System.Drawing.Size(234, 19);
            this.txtQRCode.TabIndex = 36;
            this.txtQRCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQRCode_KeyUp);
            // 
            // frmZHTP010_TransitAfterPackEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(242, 272);
            this.Controls.Add(this.txtScanQR);
            this.Controls.Add(this.txtQRCode);
            this.Name = "frmZHTP010_TransitAfterPackEntry";
            this.Text = "ZHTP010 : TransitAfterPackEntry";
            this.Load += new System.EventHandler(this.frmZHTP010_TransitAfterPackEntry_Load);
            this.Controls.SetChildIndex(this.txtQRCode, 0);
            this.Controls.SetChildIndex(this.txtScanQR, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txtScanQR;
        private System.Windows.Forms.TextBox txtQRCode;
    }
}
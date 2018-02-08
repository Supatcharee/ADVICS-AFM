namespace Advics.Screen._4.Packing.porn
{
    partial class frmZHPA010_pornEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.lblScanQR = new System.Windows.Forms.TextBox();
            this.txtScanQR = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblScanQR
            // 
            this.lblScanQR.BackColor = System.Drawing.Color.PowderBlue;
            this.lblScanQR.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblScanQR.Location = new System.Drawing.Point(1, 80);
            this.lblScanQR.Name = "lblScanQR";
            this.lblScanQR.Size = new System.Drawing.Size(234, 19);
            this.lblScanQR.TabIndex = 34;
            // 
            // txtScanQR
            // 
            this.txtScanQR.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtScanQR.Location = new System.Drawing.Point(3, 59);
            this.txtScanQR.Name = "txtScanQR";
            this.txtScanQR.Size = new System.Drawing.Size(132, 18);
            this.txtScanQR.Text = "Scan QR Code";
            // 
            // frmZHPA010_pornEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(241, 272);
            this.Controls.Add(this.txtScanQR);
            this.Controls.Add(this.lblScanQR);
            this.Menu = this.mainMenu1;
            this.Name = "frmZHPA010_pornEntry";
            this.Text = "frmZHPA010_pornEntry";
            this.Load += new System.EventHandler(this.frmZHPA010_pornEntry_Load);
            this.Controls.SetChildIndex(this.lblScanQR, 0);
            this.Controls.SetChildIndex(this.txtScanQR, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox lblScanQR;
        private System.Windows.Forms.Label txtScanQR;
    }
}
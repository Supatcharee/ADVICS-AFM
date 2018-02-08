namespace Advics.Screen.TransitAfterPack
{
    partial class frmZHTP020_TransitafterPackEntryScanLocation
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocationCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPalletNo = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.Coral;
            this.label1.Location = new System.Drawing.Point(6, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.Text = "QR Location Code";
            // 
            // txtLocationCode
            // 
            this.txtLocationCode.BackColor = System.Drawing.Color.PowderBlue;
            this.txtLocationCode.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtLocationCode.Location = new System.Drawing.Point(4, 103);
            this.txtLocationCode.Name = "txtLocationCode";
            this.txtLocationCode.Size = new System.Drawing.Size(234, 19);
            this.txtLocationCode.TabIndex = 9;
            this.txtLocationCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLocationCode_KeyUp);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.Text = "Pallet No. :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.Text = "Location :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPalletNo
            // 
            this.lblPalletNo.ForeColor = System.Drawing.Color.Gray;
            this.lblPalletNo.Location = new System.Drawing.Point(94, 39);
            this.lblPalletNo.Name = "lblPalletNo";
            this.lblPalletNo.Size = new System.Drawing.Size(100, 20);
            this.lblPalletNo.Text = "Pallet No.";
            // 
            // lblLocation
            // 
            this.lblLocation.ForeColor = System.Drawing.Color.Gray;
            this.lblLocation.Location = new System.Drawing.Point(94, 59);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(100, 20);
            this.lblLocation.Text = "-";
            // 
            // frmZHTP020_TransitafterPackEntryScanLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(242, 272);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblPalletNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLocationCode);
            this.Controls.Add(this.label1);
            this.Name = "frmZHTP020_TransitafterPackEntryScanLocation";
            this.Text = "ZHTP020 : TransitafterPackEntryScanLocation";
            this.Load += new System.EventHandler(this.frmZHTP020_TransitafterPackEntryScanLocation_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtLocationCode, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblPalletNo, 0);
            this.Controls.SetChildIndex(this.lblLocation, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocationCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPalletNo;
        private System.Windows.Forms.Label lblLocation;
    }
}
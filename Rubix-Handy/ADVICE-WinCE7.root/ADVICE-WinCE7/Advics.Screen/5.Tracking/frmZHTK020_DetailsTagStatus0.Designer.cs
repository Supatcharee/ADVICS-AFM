namespace Advics.Screen.Tracking
{
    partial class frmZHTK020_DetailsTagStatus0
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblRunningno = new System.Windows.Forms.Label();
            this.lblPDSno = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.Label();
            this.txtRunningno = new System.Windows.Forms.Label();
            this.txtPDSno = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(57, 92);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(125, 13);
            this.lblStatus.Text = "Not Received";
            // 
            // lblRunningno
            // 
            this.lblRunningno.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblRunningno.ForeColor = System.Drawing.Color.Gray;
            this.lblRunningno.Location = new System.Drawing.Point(80, 62);
            this.lblRunningno.Name = "lblRunningno";
            this.lblRunningno.Size = new System.Drawing.Size(125, 13);
            this.lblRunningno.Text = "00xxx-00xxx";
            // 
            // lblPDSno
            // 
            this.lblPDSno.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPDSno.ForeColor = System.Drawing.Color.Gray;
            this.lblPDSno.Location = new System.Drawing.Point(57, 46);
            this.lblPDSno.Name = "lblPDSno";
            this.lblPDSno.Size = new System.Drawing.Size(124, 13);
            this.lblPDSno.Text = "xxxxx-xxxxx";
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtStatus.Location = new System.Drawing.Point(0, 91);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(54, 13);
            this.txtStatus.Text = "Status :";
            this.txtStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtRunningno
            // 
            this.txtRunningno.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtRunningno.Location = new System.Drawing.Point(0, 62);
            this.txtRunningno.Name = "txtRunningno";
            this.txtRunningno.Size = new System.Drawing.Size(80, 13);
            this.txtRunningno.Text = "RunningNo :";
            this.txtRunningno.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPDSno
            // 
            this.txtPDSno.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtPDSno.Location = new System.Drawing.Point(0, 46);
            this.txtPDSno.Name = "txtPDSno";
            this.txtPDSno.Size = new System.Drawing.Size(56, 13);
            this.txtPDSno.Text = "PDSNo :";
            this.txtPDSno.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmZHTK020_DetailsTagStatus0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(241, 272);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblRunningno);
            this.Controls.Add(this.lblPDSno);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtRunningno);
            this.Controls.Add(this.txtPDSno);
            this.Name = "frmZHTK020_DetailsTagStatus0";
            this.Text = "ZHTK020 : Details";
            this.Load += new System.EventHandler(this.frmZHTK020_DetailsTagStatus0_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmZHTK020_DetailsTagStatus0_KeyUp);
            this.Controls.SetChildIndex(this.txtPDSno, 0);
            this.Controls.SetChildIndex(this.txtRunningno, 0);
            this.Controls.SetChildIndex(this.txtStatus, 0);
            this.Controls.SetChildIndex(this.lblPDSno, 0);
            this.Controls.SetChildIndex(this.lblRunningno, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblRunningno;
        private System.Windows.Forms.Label lblPDSno;
        private System.Windows.Forms.Label txtStatus;
        private System.Windows.Forms.Label txtRunningno;
        private System.Windows.Forms.Label txtPDSno;
    }
}
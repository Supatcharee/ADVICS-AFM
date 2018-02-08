namespace Advics.Screen.Tracking
{
    partial class frmZHTK026_DetailsCaseMark
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
            this.lblPalletno = new System.Windows.Forms.Label();
            this.txtPalletno = new System.Windows.Forms.Label();
            this.lbVanningDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grdResult = new System.Windows.Forms.DataGrid();
            this.gdtTableStyle = new System.Windows.Forms.DataGridTableStyle();
            this.colProCode = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colPdsNo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colRunningNo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPalletno
            // 
            this.lblPalletno.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPalletno.ForeColor = System.Drawing.Color.Gray;
            this.lblPalletno.Location = new System.Drawing.Point(95, 44);
            this.lblPalletno.Name = "lblPalletno";
            this.lblPalletno.Size = new System.Drawing.Size(124, 13);
            this.lblPalletno.Text = "xxxxx-xxxx";
            // 
            // txtPalletno
            // 
            this.txtPalletno.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtPalletno.Location = new System.Drawing.Point(28, 44);
            this.txtPalletno.Name = "txtPalletno";
            this.txtPalletno.Size = new System.Drawing.Size(63, 13);
            this.txtPalletno.Text = "Pallet No :";
            this.txtPalletno.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbVanningDate
            // 
            this.lbVanningDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbVanningDate.ForeColor = System.Drawing.Color.Gray;
            this.lbVanningDate.Location = new System.Drawing.Point(95, 68);
            this.lbVanningDate.Name = "lbVanningDate";
            this.lbVanningDate.Size = new System.Drawing.Size(124, 13);
            this.lbVanningDate.Text = "xxxxx-xxxx";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(0, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.Text = "Vanning Date :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grdResult
            // 
            this.grdResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdResult.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.grdResult.Location = new System.Drawing.Point(6, 138);
            this.grdResult.Name = "grdResult";
            this.grdResult.Size = new System.Drawing.Size(233, 121);
            this.grdResult.TabIndex = 58;
            this.grdResult.TableStyles.Add(this.gdtTableStyle);
            this.grdResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdResult_KeyUp);
            // 
            // gdtTableStyle
            // 
            this.gdtTableStyle.GridColumnStyles.Add(this.colProCode);
            this.gdtTableStyle.GridColumnStyles.Add(this.colPdsNo);
            this.gdtTableStyle.GridColumnStyles.Add(this.colRunningNo);
            this.gdtTableStyle.MappingName = "DataTableData";
            // 
            // colProCode
            // 
            this.colProCode.Format = "";
            this.colProCode.FormatInfo = null;
            this.colProCode.HeaderText = "Product Code";
            this.colProCode.MappingName = "ProductCode";
            this.colProCode.Width = 120;
            // 
            // colPdsNo
            // 
            this.colPdsNo.Format = "";
            this.colPdsNo.FormatInfo = null;
            this.colPdsNo.HeaderText = "PDS No.";
            this.colPdsNo.MappingName = "PDSNo";
            this.colPdsNo.Width = 120;
            // 
            // colRunningNo
            // 
            this.colRunningNo.Format = "";
            this.colRunningNo.FormatInfo = null;
            this.colRunningNo.HeaderText = "Running No.";
            this.colRunningNo.MappingName = "RunningNo";
            this.colRunningNo.Width = 100;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(26, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.Text = "Status :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(6, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.Text = "Location :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblLocation
            // 
            this.lblLocation.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblLocation.ForeColor = System.Drawing.Color.Gray;
            this.lblLocation.Location = new System.Drawing.Point(95, 110);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(124, 16);
            this.lblLocation.Text = "xxxxxx";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(95, 90);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(124, 15);
            this.lblStatus.Text = "xxxxxx";
            // 
            // frmZHTK026_DetailsCaseMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(244, 302);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdResult);
            this.Controls.Add(this.lbVanningDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPalletno);
            this.Controls.Add(this.txtPalletno);
            this.Name = "frmZHTK026_DetailsCaseMark";
            this.Text = "ZHTK026 : DetailsCaseMark";
            this.Load += new System.EventHandler(this.frmZHTK026_DetailsCaseMark_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmZHTK026_DetailsCaseMark_KeyUp);
            this.Controls.SetChildIndex(this.txtPalletno, 0);
            this.Controls.SetChildIndex(this.lblPalletno, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lbVanningDate, 0);
            this.Controls.SetChildIndex(this.grdResult, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblLocation, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPalletno;
        private System.Windows.Forms.Label txtPalletno;
        private System.Windows.Forms.Label lbVanningDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGrid grdResult;
        private System.Windows.Forms.DataGridTableStyle gdtTableStyle;
        private System.Windows.Forms.DataGridTextBoxColumn colProCode;
        private System.Windows.Forms.DataGridTextBoxColumn colPdsNo;
        private System.Windows.Forms.DataGridTextBoxColumn colRunningNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblStatus;
    }
}
namespace Advics.Screen.Tracking
{
    partial class frmZHTK025_DetailsTagOut
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
            this.grdResult = new System.Windows.Forms.DataGrid();
            this.gdtTableStyle = new System.Windows.Forms.DataGridTableStyle();
            this.colProCode = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colPDSNo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colRunningNo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lbPackDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPalletno
            // 
            this.lblPalletno.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPalletno.ForeColor = System.Drawing.Color.Gray;
            this.lblPalletno.Location = new System.Drawing.Point(69, 41);
            this.lblPalletno.Name = "lblPalletno";
            this.lblPalletno.Size = new System.Drawing.Size(124, 13);
            this.lblPalletno.Text = "xxxxx-xxxx";
            // 
            // txtPalletno
            // 
            this.txtPalletno.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtPalletno.Location = new System.Drawing.Point(4, 41);
            this.txtPalletno.Name = "txtPalletno";
            this.txtPalletno.Size = new System.Drawing.Size(63, 13);
            this.txtPalletno.Text = "Pallet No :";
            this.txtPalletno.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grdResult
            // 
            this.grdResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdResult.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.grdResult.Location = new System.Drawing.Point(4, 89);
            this.grdResult.Name = "grdResult";
            this.grdResult.Size = new System.Drawing.Size(233, 121);
            this.grdResult.TabIndex = 47;
            this.grdResult.TableStyles.Add(this.gdtTableStyle);
            this.grdResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdResult_KeyUp);
            // 
            // gdtTableStyle
            // 
            this.gdtTableStyle.GridColumnStyles.Add(this.colProCode);
            this.gdtTableStyle.GridColumnStyles.Add(this.colPDSNo);
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
            // colPDSNo
            // 
            this.colPDSNo.Format = "";
            this.colPDSNo.FormatInfo = null;
            this.colPDSNo.HeaderText = "PDS No.";
            this.colPDSNo.MappingName = "PDSNo";
            this.colPDSNo.Width = 120;
            // 
            // colRunningNo
            // 
            this.colRunningNo.Format = "";
            this.colRunningNo.FormatInfo = null;
            this.colRunningNo.HeaderText = "Running No.";
            this.colRunningNo.MappingName = "RunningNo";
            this.colRunningNo.Width = 100;
            // 
            // lbPackDate
            // 
            this.lbPackDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbPackDate.ForeColor = System.Drawing.Color.Gray;
            this.lbPackDate.Location = new System.Drawing.Point(96, 62);
            this.lbPackDate.Name = "lbPackDate";
            this.lbPackDate.Size = new System.Drawing.Size(124, 13);
            this.lbPackDate.Text = "xxxxx-xxxx";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(4, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.Text = "Packed Date :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmZHTK025_DetailsTagOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(241, 272);
            this.Controls.Add(this.lbPackDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grdResult);
            this.Controls.Add(this.lblPalletno);
            this.Controls.Add(this.txtPalletno);
            this.Name = "frmZHTK025_DetailsTagOut";
            this.Text = "ZHTK025 : DetailsTagOut";
            this.Load += new System.EventHandler(this.frmZHTK025_DetailsTagOut_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmZHTK025_DetailsTagOut_KeyUp);
            this.Controls.SetChildIndex(this.txtPalletno, 0);
            this.Controls.SetChildIndex(this.lblPalletno, 0);
            this.Controls.SetChildIndex(this.grdResult, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lbPackDate, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPalletno;
        private System.Windows.Forms.Label txtPalletno;
        private System.Windows.Forms.DataGrid grdResult;
        private System.Windows.Forms.DataGridTableStyle gdtTableStyle;
        private System.Windows.Forms.DataGridTextBoxColumn colProCode;
        private System.Windows.Forms.Label lbPackDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridTextBoxColumn colPDSNo;
        private System.Windows.Forms.DataGridTextBoxColumn colRunningNo;
    }
}
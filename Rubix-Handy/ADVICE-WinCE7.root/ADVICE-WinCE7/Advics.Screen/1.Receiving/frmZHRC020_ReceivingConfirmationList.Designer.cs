namespace Advics.Screen.Receiving
{
    partial class frmZHRC020_ReceivingConfirmationList
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
            this.lblReceivingDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grdResult = new System.Windows.Forms.DataGrid();
            this.gdtTableStyle = new System.Windows.Forms.DataGridTableStyle();
            this.gdcReceivingNo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcSupplier = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcPONo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.Text = "วันที่รับสินค้า :";
            // 
            // lblReceivingDate
            // 
            this.lblReceivingDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblReceivingDate.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lblReceivingDate.Location = new System.Drawing.Point(81, 33);
            this.lblReceivingDate.Name = "lblReceivingDate";
            this.lblReceivingDate.Size = new System.Drawing.Size(146, 14);
            this.lblReceivingDate.Text = "99/99/9999";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(2, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 15);
            this.label4.Text = "เลือกใบรายการที่ต้องการรับ";
            // 
            // grdResult
            // 
            this.grdResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdResult.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.grdResult.Location = new System.Drawing.Point(2, 65);
            this.grdResult.Name = "grdResult";
            this.grdResult.Size = new System.Drawing.Size(233, 184);
            this.grdResult.TabIndex = 13;
            this.grdResult.TableStyles.Add(this.gdtTableStyle);
            this.grdResult.DoubleClick += new System.EventHandler(this.grdResult_DoubleClick);
            this.grdResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdResult_KeyUp);
            // 
            // gdtTableStyle
            // 
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcReceivingNo);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcSupplier);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcPONo);
            this.gdtTableStyle.MappingName = "DataTableData";
            // 
            // gdcReceivingNo
            // 
            this.gdcReceivingNo.Format = "";
            this.gdcReceivingNo.FormatInfo = null;
            this.gdcReceivingNo.HeaderText = "รายการรับสินค้า (Rcv No.)";
            this.gdcReceivingNo.MappingName = "ReceivingNo";
            this.gdcReceivingNo.Width = 125;
            // 
            // gdcSupplier
            // 
            this.gdcSupplier.Format = "";
            this.gdcSupplier.FormatInfo = null;
            this.gdcSupplier.HeaderText = "ผู้ผลิต (Supplier)";
            this.gdcSupplier.MappingName = "SupplierLongName";
            this.gdcSupplier.Width = 150;
            // 
            // gdcPONo
            // 
            this.gdcPONo.Format = "";
            this.gdcPONo.FormatInfo = null;
            this.gdcPONo.HeaderText = "หมายเลข PO";
            this.gdcPONo.MappingName = "PONo";
            this.gdcPONo.Width = 100;
            // 
            // frmZHRC020_ReceivingConfirmationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(238, 272);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblReceivingDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grdResult);
            this.Name = "frmZHRC020_ReceivingConfirmationList";
            this.Text = "ZHRC020 : Receiving Confirmation List";
            this.Load += new System.EventHandler(this.frmZHRC020_ReceivingConfirmationList_Load);
            this.Controls.SetChildIndex(this.grdResult, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblReceivingDate, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblReceivingDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGrid grdResult;
        private System.Windows.Forms.DataGridTableStyle gdtTableStyle;
        private System.Windows.Forms.DataGridTextBoxColumn gdcReceivingNo;
        private System.Windows.Forms.DataGridTextBoxColumn gdcSupplier;
        private System.Windows.Forms.DataGridTextBoxColumn gdcPONo;
    }
}
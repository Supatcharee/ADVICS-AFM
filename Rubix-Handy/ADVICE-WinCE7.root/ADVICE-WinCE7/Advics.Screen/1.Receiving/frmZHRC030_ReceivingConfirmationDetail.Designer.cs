namespace Advics.Screen.Receiving
{
    partial class frmZHRC030_ReceivingConfirmationDetail
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRMTag = new System.Windows.Forms.TextBox();
            this.grdResult = new System.Windows.Forms.DataGrid();
            this.gdtTableStyle = new System.Windows.Forms.DataGridTableStyle();
            this.gdcShortCode = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcActualQTY = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcRemainQTY = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcLocationCode = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcItemCode = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcItemName = new System.Windows.Forms.DataGridTextBoxColumn();
            this.chkIsCompleteFlag = new System.Windows.Forms.CheckBox();
            this.lblReceivingNo = new System.Windows.Forms.Label();
            this.lblReceivingDate = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.Text = "วันที่รับสินค้า :";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(2, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.Text = "ผู้ผลิต :";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(3, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 14);
            this.label4.Text = "สแกนหมายเลข R/M :";
            // 
            // txtRMTag
            // 
            this.txtRMTag.BackColor = System.Drawing.Color.PowderBlue;
            this.txtRMTag.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtRMTag.Location = new System.Drawing.Point(121, 80);
            this.txtRMTag.Name = "txtRMTag";
            this.txtRMTag.Size = new System.Drawing.Size(114, 19);
            this.txtRMTag.TabIndex = 18;
            this.txtRMTag.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRMTag_KeyUp);
            // 
            // grdResult
            // 
            this.grdResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdResult.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.grdResult.Location = new System.Drawing.Point(3, 102);
            this.grdResult.Name = "grdResult";
            this.grdResult.Size = new System.Drawing.Size(232, 128);
            this.grdResult.TabIndex = 20;
            this.grdResult.TableStyles.Add(this.gdtTableStyle);
            this.grdResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdResult_KeyUp);
            // 
            // gdtTableStyle
            // 
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcShortCode);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcActualQTY);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcRemainQTY);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcLocationCode);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcItemCode);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcItemName);
            this.gdtTableStyle.MappingName = "DataTableData";
            // 
            // gdcShortCode
            // 
            this.gdcShortCode.Format = "";
            this.gdcShortCode.FormatInfo = null;
            this.gdcShortCode.HeaderText = "รหัสย่อ (Short Code)";
            this.gdcShortCode.MappingName = "ItemShortCode";
            this.gdcShortCode.Width = 45;
            // 
            // gdcActualQTY
            // 
            this.gdcActualQTY.Format = "#,##0";
            this.gdcActualQTY.FormatInfo = null;
            this.gdcActualQTY.HeaderText = "จำนวนรับจริง";
            this.gdcActualQTY.MappingName = "ActualQty";
            this.gdcActualQTY.Width = 75;
            // 
            // gdcRemainQTY
            // 
            this.gdcRemainQTY.Format = "#,##0";
            this.gdcRemainQTY.FormatInfo = null;
            this.gdcRemainQTY.HeaderText = "จำนวนคงเหลือ";
            this.gdcRemainQTY.MappingName = "RemainQty";
            this.gdcRemainQTY.Width = 75;
            // 
            // gdcLocationCode
            // 
            this.gdcLocationCode.Format = "";
            this.gdcLocationCode.FormatInfo = null;
            this.gdcLocationCode.HeaderText = "สถานที่จัดเก็บ";
            this.gdcLocationCode.MappingName = "LocationCode";
            // 
            // gdcItemCode
            // 
            this.gdcItemCode.Format = "";
            this.gdcItemCode.FormatInfo = null;
            this.gdcItemCode.HeaderText = "รหัส (Code)";
            this.gdcItemCode.MappingName = "ItemCode";
            this.gdcItemCode.Width = 80;
            // 
            // gdcItemName
            // 
            this.gdcItemName.Format = "";
            this.gdcItemName.FormatInfo = null;
            this.gdcItemName.HeaderText = "ชื่อ (Name)";
            this.gdcItemName.MappingName = "ItemName";
            this.gdcItemName.Width = 200;
            // 
            // chkIsCompleteFlag
            // 
            this.chkIsCompleteFlag.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkIsCompleteFlag.ForeColor = System.Drawing.Color.Red;
            this.chkIsCompleteFlag.Location = new System.Drawing.Point(2, 234);
            this.chkIsCompleteFlag.Name = "chkIsCompleteFlag";
            this.chkIsCompleteFlag.Size = new System.Drawing.Size(166, 15);
            this.chkIsCompleteFlag.TabIndex = 21;
            this.chkIsCompleteFlag.Text = "ต้องการปิดใบรับสินค้านี้";
            // 
            // lblReceivingNo
            // 
            this.lblReceivingNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblReceivingNo.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblReceivingNo.Location = new System.Drawing.Point(3, 30);
            this.lblReceivingNo.Name = "lblReceivingNo";
            this.lblReceivingNo.Size = new System.Drawing.Size(234, 14);
            this.lblReceivingNo.Text = "ADVICS-RC140101001";
            // 
            // lblReceivingDate
            // 
            this.lblReceivingDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblReceivingDate.Location = new System.Drawing.Point(82, 47);
            this.lblReceivingDate.Name = "lblReceivingDate";
            this.lblReceivingDate.Size = new System.Drawing.Size(97, 15);
            this.lblReceivingDate.Text = "99/99/9999";
            // 
            // lblSupplier
            // 
            this.lblSupplier.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblSupplier.Location = new System.Drawing.Point(45, 64);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(186, 14);
            this.lblSupplier.Text = "SIAM AISIN CO., LTD.";
            // 
            // frmZHRC030_ReceivingConfirmationDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(238, 272);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.lblReceivingDate);
            this.Controls.Add(this.lblReceivingNo);
            this.Controls.Add(this.chkIsCompleteFlag);
            this.Controls.Add(this.grdResult);
            this.Controls.Add(this.txtRMTag);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frmZHRC030_ReceivingConfirmationDetail";
            this.Text = "ZHRC030 : Receiving Confirmation Detail";
            this.Load += new System.EventHandler(this.frmZHRC030_ReceivingConfirmationDetail_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtRMTag, 0);
            this.Controls.SetChildIndex(this.grdResult, 0);
            this.Controls.SetChildIndex(this.chkIsCompleteFlag, 0);
            this.Controls.SetChildIndex(this.lblReceivingNo, 0);
            this.Controls.SetChildIndex(this.lblReceivingDate, 0);
            this.Controls.SetChildIndex(this.lblSupplier, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRMTag;
        private System.Windows.Forms.DataGrid grdResult;
        private System.Windows.Forms.DataGridTableStyle gdtTableStyle;
        private System.Windows.Forms.CheckBox chkIsCompleteFlag;
        private System.Windows.Forms.Label lblReceivingNo;
        private System.Windows.Forms.Label lblReceivingDate;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.DataGridTextBoxColumn gdcItemCode;
        private System.Windows.Forms.DataGridTextBoxColumn gdcItemName;
        private System.Windows.Forms.DataGridTextBoxColumn gdcActualQTY;
        private System.Windows.Forms.DataGridTextBoxColumn gdcRemainQTY;
        private System.Windows.Forms.DataGridTextBoxColumn gdcShortCode;
        private System.Windows.Forms.DataGridTextBoxColumn gdcLocationCode;
    }
}
namespace Advics.Screen.Picking
{
    partial class frmZHPK030_PickingConfirmationDetail
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
            this.lblPickingDate = new System.Windows.Forms.Label();
            this.lblPickingNo = new System.Windows.Forms.Label();
            this.txtRMTag = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPackingNo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.grdResult = new System.Windows.Forms.DataGrid();
            this.gdtTableStyle = new System.Windows.Forms.DataGridTableStyle();
            this.gdcProductCode = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcActualQTY = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcPickQTY = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcLocationCode = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcShortCode = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcProductName = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SuspendLayout();
            // 
            // lblPickingDate
            // 
            this.lblPickingDate.BackColor = System.Drawing.Color.White;
            this.lblPickingDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPickingDate.Location = new System.Drawing.Point(85, 65);
            this.lblPickingDate.Name = "lblPickingDate";
            this.lblPickingDate.Size = new System.Drawing.Size(87, 14);
            this.lblPickingDate.Text = "99/99/9999";
            // 
            // lblPickingNo
            // 
            this.lblPickingNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblPickingNo.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblPickingNo.Location = new System.Drawing.Point(4, 30);
            this.lblPickingNo.Name = "lblPickingNo";
            this.lblPickingNo.Size = new System.Drawing.Size(206, 15);
            this.lblPickingNo.Text = "ADVICS-PK140101001";
            // 
            // txtRMTag
            // 
            this.txtRMTag.BackColor = System.Drawing.Color.PowderBlue;
            this.txtRMTag.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtRMTag.Location = new System.Drawing.Point(120, 79);
            this.txtRMTag.Name = "txtRMTag";
            this.txtRMTag.Size = new System.Drawing.Size(114, 19);
            this.txtRMTag.TabIndex = 26;
            this.txtRMTag.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRMTag_KeyUp);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(2, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 15);
            this.label4.Text = "สแกนหมายเลข R/M :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(2, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 15);
            this.label2.Text = "วันที่หยิบสินค้า :";
            // 
            // lblPackingNo
            // 
            this.lblPackingNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblPackingNo.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblPackingNo.Location = new System.Drawing.Point(3, 46);
            this.lblPackingNo.Name = "lblPackingNo";
            this.lblPackingNo.Size = new System.Drawing.Size(206, 15);
            this.lblPackingNo.Text = "ADVICS-PA140101001";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(2, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.Text = "รายการที่ต้องการหยิบ";
            // 
            // grdResult
            // 
            this.grdResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdResult.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.grdResult.Location = new System.Drawing.Point(3, 114);
            this.grdResult.Name = "grdResult";
            this.grdResult.Size = new System.Drawing.Size(232, 136);
            this.grdResult.TabIndex = 42;
            this.grdResult.TableStyles.Add(this.gdtTableStyle);
            this.grdResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdResult_KeyUp);
            // 
            // gdtTableStyle
            // 
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcProductCode);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcActualQTY);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcPickQTY);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcLocationCode);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcShortCode);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcProductName);
            this.gdtTableStyle.MappingName = "DataTableData";
            // 
            // gdcProductCode
            // 
            this.gdcProductCode.Format = "80";
            this.gdcProductCode.FormatInfo = null;
            this.gdcProductCode.HeaderText = "รหัส (Code)";
            this.gdcProductCode.MappingName = "ItemCode";
            this.gdcProductCode.Width = 75;
            // 
            // gdcActualQTY
            // 
            this.gdcActualQTY.Format = "#,##0";
            this.gdcActualQTY.FormatInfo = null;
            this.gdcActualQTY.HeaderText = "หยิบจริง";
            this.gdcActualQTY.MappingName = "PickingQty";
            this.gdcActualQTY.Width = 55;
            // 
            // gdcPickQTY
            // 
            this.gdcPickQTY.Format = "#,##0";
            this.gdcPickQTY.FormatInfo = null;
            this.gdcPickQTY.HeaderText = "แผน";
            this.gdcPickQTY.MappingName = "PlanPickingQty";
            this.gdcPickQTY.Width = 40;
            // 
            // gdcLocationCode
            // 
            this.gdcLocationCode.Format = "";
            this.gdcLocationCode.FormatInfo = null;
            this.gdcLocationCode.HeaderText = "พื้นที่จัดเก็บ";
            this.gdcLocationCode.MappingName = "LocationCode";
            this.gdcLocationCode.Width = 70;
            // 
            // gdcShortCode
            // 
            this.gdcShortCode.Format = "";
            this.gdcShortCode.FormatInfo = null;
            this.gdcShortCode.HeaderText = "รหัสย่อ (Item Short Code)";
            this.gdcShortCode.MappingName = "ItemShortCode";
            this.gdcShortCode.Width = 45;
            // 
            // gdcProductName
            // 
            this.gdcProductName.Format = "";
            this.gdcProductName.FormatInfo = null;
            this.gdcProductName.HeaderText = "ชื่อ (Name)";
            this.gdcProductName.MappingName = "ItemName";
            this.gdcProductName.Width = 200;
            // 
            // frmZHPK030_PickingConfirmationDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(238, 272);
            this.Controls.Add(this.grdResult);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblPackingNo);
            this.Controls.Add(this.lblPickingDate);
            this.Controls.Add(this.lblPickingNo);
            this.Controls.Add(this.txtRMTag);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "frmZHPK030_PickingConfirmationDetail";
            this.Text = "ZHPK030 : Picking Confirmation Detail";
            this.Load += new System.EventHandler(this.frmZHPK030_PickingConfirmationDetail_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtRMTag, 0);
            this.Controls.SetChildIndex(this.lblPickingNo, 0);
            this.Controls.SetChildIndex(this.lblPickingDate, 0);
            this.Controls.SetChildIndex(this.lblPackingNo, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.grdResult, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPickingDate;
        private System.Windows.Forms.Label lblPickingNo;
        private System.Windows.Forms.TextBox txtRMTag;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPackingNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGrid grdResult;
        private System.Windows.Forms.DataGridTableStyle gdtTableStyle;
        private System.Windows.Forms.DataGridTextBoxColumn gdcProductCode;
        private System.Windows.Forms.DataGridTextBoxColumn gdcProductName;
        private System.Windows.Forms.DataGridTextBoxColumn gdcLocationCode;
        private System.Windows.Forms.DataGridTextBoxColumn gdcPickQTY;
        private System.Windows.Forms.DataGridTextBoxColumn gdcActualQTY;
        private System.Windows.Forms.DataGridTextBoxColumn gdcShortCode;
    }
}
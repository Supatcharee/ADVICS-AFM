namespace Advics.Screen.Packing
{
    partial class frmZHPA030_PackingConfirmaionDetail
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
            this.lblPackingNo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPickingDate = new System.Windows.Forms.Label();
            this.lblShippingNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdResult = new System.Windows.Forms.DataGrid();
            this.gdtTableStyle = new System.Windows.Forms.DataGridTableStyle();
            this.gdcProductCode = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcPackQTY = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcRMTagNo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcProductName = new System.Windows.Forms.DataGridTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRMTag = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPackingNo
            // 
            this.lblPackingNo.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.lblPackingNo.Location = new System.Drawing.Point(145, 48);
            this.lblPackingNo.Name = "lblPackingNo";
            this.lblPackingNo.Size = new System.Drawing.Size(232, 20);
            this.lblPackingNo.Text = "ADVICS-PA140101001";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(5, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 20);
            this.label6.Text = "หมายเลขใบแพ็ค :";
            // 
            // lblPickingDate
            // 
            this.lblPickingDate.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.lblPickingDate.Location = new System.Drawing.Point(89, 96);
            this.lblPickingDate.Name = "lblPickingDate";
            this.lblPickingDate.Size = new System.Drawing.Size(145, 20);
            this.lblPickingDate.Text = "99/99/9999";
            // 
            // lblShippingNo
            // 
            this.lblShippingNo.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.lblShippingNo.Location = new System.Drawing.Point(146, 27);
            this.lblShippingNo.Name = "lblShippingNo";
            this.lblShippingNo.Size = new System.Drawing.Size(232, 20);
            this.lblShippingNo.Text = "ADVICS-SH140101001";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(5, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.Text = "วันที่แพ็ค :";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(5, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.Text = "หมายเลขใบส่ง :";
            // 
            // grdResult
            // 
            this.grdResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdResult.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.grdResult.Location = new System.Drawing.Point(3, 171);
            this.grdResult.Name = "grdResult";
            this.grdResult.Size = new System.Drawing.Size(370, 190);
            this.grdResult.TabIndex = 44;
            this.grdResult.TableStyles.Add(this.gdtTableStyle);
            // 
            // gdtTableStyle
            // 
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcProductCode);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcPackQTY);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcRMTagNo);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcProductName);
            // 
            // gdcProductCode
            // 
            this.gdcProductCode.Format = "";
            this.gdcProductCode.FormatInfo = null;
            this.gdcProductCode.HeaderText = "รหัส (Code)";
            this.gdcProductCode.MappingName = "ProductCode";
            this.gdcProductCode.Width = 150;
            // 
            // gdcPackQTY
            // 
            this.gdcPackQTY.Format = "";
            this.gdcPackQTY.FormatInfo = null;
            this.gdcPackQTY.HeaderText = "จำนวนชิ้น";
            this.gdcPackQTY.MappingName = "PackQTY";
            // 
            // gdcRMTagNo
            // 
            this.gdcRMTagNo.Format = "";
            this.gdcRMTagNo.FormatInfo = null;
            this.gdcRMTagNo.HeaderText = "R/M Tag";
            this.gdcRMTagNo.MappingName = "RMTagNo";
            this.gdcRMTagNo.Width = 150;
            // 
            // gdcProductName
            // 
            this.gdcProductName.Format = "";
            this.gdcProductName.FormatInfo = null;
            this.gdcProductName.HeaderText = "ชื่อ (Name)";
            this.gdcProductName.MappingName = "ProductName";
            this.gdcProductName.Width = 200;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(5, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(210, 20);
            this.label8.Text = "รายการที่ต้องการแพ็ค";
            // 
            // checkBox1
            // 
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.checkBox1.ForeColor = System.Drawing.Color.Red;
            this.checkBox1.Location = new System.Drawing.Point(3, 367);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(304, 20);
            this.checkBox1.TabIndex = 46;
            this.checkBox1.Text = "ต้องการปิดใบแพ็คส่งสินค้า";
            // 
            // lblCustomer
            // 
            this.lblCustomer.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.lblCustomer.Location = new System.Drawing.Point(70, 71);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(305, 20);
            this.lblCustomer.Text = "Customer";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(5, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.Text = "ลูกค้า :";
            // 
            // txtRMTag
            // 
            this.txtRMTag.BackColor = System.Drawing.Color.PowderBlue;
            this.txtRMTag.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtRMTag.Location = new System.Drawing.Point(177, 119);
            this.txtRMTag.Name = "txtRMTag";
            this.txtRMTag.Size = new System.Drawing.Size(198, 26);
            this.txtRMTag.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(5, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 20);
            this.label3.Text = "สแกนหมายเลข R/M :";
            // 
            // frmZHPA030_PackingConfirmaionDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(378, 415);
            this.Controls.Add(this.txtRMTag);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.grdResult);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblPackingNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblPickingDate);
            this.Controls.Add(this.lblShippingNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmZHPA030_PackingConfirmaionDetail";
            this.Text = "ZHPA030 : Packing Confirmaion Detail";
            this.Load += new System.EventHandler(this.frmZHPA030_PackingConfirmaionDetail_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.lblShippingNo, 0);
            this.Controls.SetChildIndex(this.lblPickingDate, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.lblPackingNo, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.grdResult, 0);
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblCustomer, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtRMTag, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPackingNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPickingDate;
        private System.Windows.Forms.Label lblShippingNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGrid grdResult;
        private System.Windows.Forms.DataGridTableStyle gdtTableStyle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridTextBoxColumn gdcRMTagNo;
        private System.Windows.Forms.DataGridTextBoxColumn gdcProductCode;
        private System.Windows.Forms.DataGridTextBoxColumn gdcProductName;
        private System.Windows.Forms.DataGridTextBoxColumn gdcPackQTY;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRMTag;
        private System.Windows.Forms.Label label3;
    }
}
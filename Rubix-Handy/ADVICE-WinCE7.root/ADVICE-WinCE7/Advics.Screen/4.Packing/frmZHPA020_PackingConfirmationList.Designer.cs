namespace Advics.Screen.Packing
{
    partial class frmZHPA020_PackingConfirmationList
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
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grdResult = new System.Windows.Forms.DataGrid();
            this.gdtTableStyle = new System.Windows.Forms.DataGridTableStyle();
            this.gdcShippingNo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcPackingNo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcCustomer = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gdcAddress = new System.Windows.Forms.DataGridTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblDeliveryDate.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lblDeliveryDate.Location = new System.Drawing.Point(143, 34);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(129, 20);
            this.lblDeliveryDate.Text = "99/99/9999";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(13, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 20);
            this.label4.Text = "เลือกรายการส่งสินค้า";
            // 
            // grdResult
            // 
            this.grdResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdResult.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.grdResult.Location = new System.Drawing.Point(4, 77);
            this.grdResult.Name = "grdResult";
            this.grdResult.Size = new System.Drawing.Size(370, 309);
            this.grdResult.TabIndex = 21;
            this.grdResult.TableStyles.Add(this.gdtTableStyle);
            this.grdResult.DoubleClick += new System.EventHandler(this.grdResult_DoubleClick);
            // 
            // gdtTableStyle
            // 
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcShippingNo);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcPackingNo);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcCustomer);
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcAddress);
            // 
            // gdcShippingNo
            // 
            this.gdcShippingNo.Format = "";
            this.gdcShippingNo.FormatInfo = null;
            this.gdcShippingNo.HeaderText = "หมายเลขส่งสินค้า";
            this.gdcShippingNo.MappingName = "ShippingNo";
            // 
            // gdcPackingNo
            // 
            this.gdcPackingNo.Format = "";
            this.gdcPackingNo.FormatInfo = null;
            this.gdcPackingNo.HeaderText = "หมายเลขแพ็ค";
            this.gdcPackingNo.MappingName = "PackingNo";
            // 
            // gdcCustomer
            // 
            this.gdcCustomer.Format = "";
            this.gdcCustomer.FormatInfo = null;
            this.gdcCustomer.HeaderText = "ลูกค้า";
            this.gdcCustomer.MappingName = "Customer";
            // 
            // gdcAddress
            // 
            this.gdcAddress.Format = "";
            this.gdcAddress.FormatInfo = null;
            this.gdcAddress.HeaderText = "สถานที่ส่ง";
            this.gdcAddress.MappingName = "Address";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.Text = "วันที่แพ็คสินค้า :";
            // 
            // frmZHPA020_PackingConfirmationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(378, 415);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDeliveryDate);
            this.Controls.Add(this.grdResult);
            this.Controls.Add(this.label4);
            this.Name = "frmZHPA020_PackingConfirmationList";
            this.Text = "ZHPA020 : Packing Confirmation List";
            this.Load += new System.EventHandler(this.frmZHPA020_PackingConfirmationList_Load);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.grdResult, 0);
            this.Controls.SetChildIndex(this.lblDeliveryDate, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGrid grdResult;
        private System.Windows.Forms.DataGridTableStyle gdtTableStyle;
        private System.Windows.Forms.DataGridTextBoxColumn gdcShippingNo;
        private System.Windows.Forms.DataGridTextBoxColumn gdcPackingNo;
        private System.Windows.Forms.DataGridTextBoxColumn gdcCustomer;
        private System.Windows.Forms.DataGridTextBoxColumn gdcAddress;
        private System.Windows.Forms.Label label1;
    }
}
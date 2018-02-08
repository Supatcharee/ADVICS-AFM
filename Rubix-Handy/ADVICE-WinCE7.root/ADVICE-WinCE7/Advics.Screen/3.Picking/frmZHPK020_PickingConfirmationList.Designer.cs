namespace Advics.Screen.Picking
{
    partial class frmZHPK020_PickingConfirmationList
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
            this.lblPickingDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grdResult = new System.Windows.Forms.DataGrid();
            this.gdtTableStyle = new System.Windows.Forms.DataGridTableStyle();
            this.gdcPickingNo = new System.Windows.Forms.DataGridTextBoxColumn();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 14);
            this.label1.Text = "วันที่หยิบสินค้า :";
            // 
            // lblPickingDate
            // 
            this.lblPickingDate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPickingDate.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lblPickingDate.Location = new System.Drawing.Point(92, 35);
            this.lblPickingDate.Name = "lblPickingDate";
            this.lblPickingDate.Size = new System.Drawing.Size(72, 14);
            this.lblPickingDate.Text = "99/99/9999";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(3, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 14);
            this.label4.Text = "เลือกใบรายการที่ต้องการหยิบ";
            // 
            // grdResult
            // 
            this.grdResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdResult.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.grdResult.Location = new System.Drawing.Point(3, 70);
            this.grdResult.Name = "grdResult";
            this.grdResult.Size = new System.Drawing.Size(232, 180);
            this.grdResult.TabIndex = 17;
            this.grdResult.TableStyles.Add(this.gdtTableStyle);
            this.grdResult.DoubleClick += new System.EventHandler(this.grdResult_DoubleClick);
            this.grdResult.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdResult_KeyUp);
            // 
            // gdtTableStyle
            // 
            this.gdtTableStyle.GridColumnStyles.Add(this.gdcPickingNo);
            this.gdtTableStyle.MappingName = "DataTableData";
            // 
            // gdcPickingNo
            // 
            this.gdcPickingNo.Format = "";
            this.gdcPickingNo.FormatInfo = null;
            this.gdcPickingNo.HeaderText = "รายการหยิบสินค้า (Picking No.)";
            this.gdcPickingNo.MappingName = "PickingNo";
            this.gdcPickingNo.Width = 120;
            // 
            // frmZHPK020_PickingConfirmationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(238, 272);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPickingDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grdResult);
            this.Name = "frmZHPK020_PickingConfirmationList";
            this.Text = "ZHPK020 : Picking Confirmation List";
            this.Load += new System.EventHandler(this.frmZHPK020_PickingConfirmationList_Load);
            this.Controls.SetChildIndex(this.grdResult, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.lblPickingDate, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPickingDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGrid grdResult;
        private System.Windows.Forms.DataGridTableStyle gdtTableStyle;
        private System.Windows.Forms.DataGridTextBoxColumn gdcPickingNo;
    }
}
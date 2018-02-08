namespace Advics.Screen.PickForShip
{
    partial class frmZHPS020_PickForShipEntryScanPallet
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
            this.label2 = new System.Windows.Forms.Label();
            this.grdResult = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPalletNo = new System.Windows.Forms.TextBox();
            this.lblShipmentNo = new System.Windows.Forms.Label();
            this.lblContainerNo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.Text = "Shipment No. : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(7, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.Text = "Container No. :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grdResult
            // 
            this.grdResult.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grdResult.Location = new System.Drawing.Point(3, 73);
            this.grdResult.Name = "grdResult";
            this.grdResult.Size = new System.Drawing.Size(235, 126);
            this.grdResult.TabIndex = 10;
            this.grdResult.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.MappingName = "DataTableData";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Pallet No.";
            this.dataGridTextBoxColumn1.MappingName = "PalletNo";
            this.dataGridTextBoxColumn1.Width = 90;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Location";
            this.dataGridTextBoxColumn2.MappingName = "LocationCode";
            this.dataGridTextBoxColumn2.Width = 85;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.DarkOrange;
            this.label3.Location = new System.Drawing.Point(3, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 18);
            this.label3.Text = "QR Pallet No.";
            // 
            // txtPalletNo
            // 
            this.txtPalletNo.BackColor = System.Drawing.Color.PowderBlue;
            this.txtPalletNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtPalletNo.Location = new System.Drawing.Point(3, 223);
            this.txtPalletNo.Name = "txtPalletNo";
            this.txtPalletNo.Size = new System.Drawing.Size(235, 19);
            this.txtPalletNo.TabIndex = 12;
            this.txtPalletNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPalletNo_KeyUp);
            // 
            // lblShipmentNo
            // 
            this.lblShipmentNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblShipmentNo.Location = new System.Drawing.Point(96, 30);
            this.lblShipmentNo.Name = "lblShipmentNo";
            this.lblShipmentNo.Size = new System.Drawing.Size(142, 20);
            this.lblShipmentNo.Text = "Shipment No.";
            // 
            // lblContainerNo
            // 
            this.lblContainerNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblContainerNo.Location = new System.Drawing.Point(96, 50);
            this.lblContainerNo.Name = "lblContainerNo";
            this.lblContainerNo.Size = new System.Drawing.Size(142, 20);
            this.lblContainerNo.Text = "Container No.";
            // 
            // frmZHPS020_PickForShipEntryScanPallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(242, 272);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grdResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPalletNo);
            this.Controls.Add(this.lblShipmentNo);
            this.Controls.Add(this.lblContainerNo);
            this.Name = "frmZHPS020_PickForShipEntryScanPallet";
            this.Text = "ZHPS020 : PickForShipEntryScanPallet";
            this.Load += new System.EventHandler(this.frmZHPS020_PickForShipEntryScanPallet_Load);
            this.Controls.SetChildIndex(this.lblContainerNo, 0);
            this.Controls.SetChildIndex(this.lblShipmentNo, 0);
            this.Controls.SetChildIndex(this.txtPalletNo, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.grdResult, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGrid grdResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPalletNo;
        private System.Windows.Forms.Label lblShipmentNo;
        private System.Windows.Forms.Label lblContainerNo;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
    }
}
namespace Rubix.Screen.Form.Operation.K_Packing.Dialog
{
    partial class dlgKPK021_ConfirmPacking_ScanDetail
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
            this.txtQRCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblErrorMsg = new DevExpress.XtraEditors.LabelControl();
            this.lblPackingNo = new DevExpress.XtraEditors.LabelControl();
            this.lblShipmentNo = new DevExpress.XtraEditors.LabelControl();
            this.lblPacking = new DevExpress.XtraEditors.LabelControl();
            this.lblShipment = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtQRCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQRCode
            // 
            this.txtQRCode.Location = new System.Drawing.Point(785, 5);
            this.txtQRCode.Name = "txtQRCode";
            this.txtQRCode.Size = new System.Drawing.Size(383, 20);
            this.txtQRCode.TabIndex = 0;
            this.txtQRCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQRCode_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(724, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "QR Code";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.lblErrorMsg);
            this.panelControl1.Controls.Add(this.lblPackingNo);
            this.panelControl1.Controls.Add(this.lblShipmentNo);
            this.panelControl1.Controls.Add(this.lblPacking);
            this.panelControl1.Controls.Add(this.lblShipment);
            this.panelControl1.Controls.Add(this.txtQRCode);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(3, 32);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1173, 46);
            this.panelControl1.TabIndex = 7;
            // 
            // lblErrorMsg
            // 
            this.lblErrorMsg.Location = new System.Drawing.Point(789, 29);
            this.lblErrorMsg.Name = "lblErrorMsg";
            this.lblErrorMsg.Size = new System.Drawing.Size(0, 13);
            this.lblErrorMsg.TabIndex = 152;
            // 
            // lblPackingNo
            // 
            this.lblPackingNo.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPackingNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPackingNo.Location = new System.Drawing.Point(488, 7);
            this.lblPackingNo.Name = "lblPackingNo";
            this.lblPackingNo.Size = new System.Drawing.Size(243, 16);
            this.lblPackingNo.TabIndex = 73;
            this.lblPackingNo.Text = "OWNER_CODE-SHYYMMDDXXX";
            // 
            // lblShipmentNo
            // 
            this.lblShipmentNo.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipmentNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblShipmentNo.Location = new System.Drawing.Point(127, 7);
            this.lblShipmentNo.Name = "lblShipmentNo";
            this.lblShipmentNo.Size = new System.Drawing.Size(233, 17);
            this.lblShipmentNo.TabIndex = 72;
            this.lblShipmentNo.Text = "OWNER_CODE-SHYYMMDDXXX";
            // 
            // lblPacking
            // 
            this.lblPacking.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPacking.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblPacking.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPacking.Location = new System.Drawing.Point(366, 6);
            this.lblPacking.Name = "lblPacking";
            this.lblPacking.Size = new System.Drawing.Size(116, 18);
            this.lblPacking.TabIndex = 71;
            this.lblPacking.Text = "Packing No :";
            // 
            // lblShipment
            // 
            this.lblShipment.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipment.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblShipment.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblShipment.Location = new System.Drawing.Point(7, 7);
            this.lblShipment.Name = "lblShipment";
            this.lblShipment.Size = new System.Drawing.Size(114, 17);
            this.lblShipment.TabIndex = 70;
            this.lblShipment.Text = "Shipment No :";
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(3, 80);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1177, 388);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 70;
            this.pictureBox.TabStop = false;
            // 
            // dlgKPK021_ConfirmPacking_ScanDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 471);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgKPK021_ConfirmPacking_ScanDetail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KPK021 : Confirm Packing Scan RM Tag Dialog";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.dlgKPK021_ConfirmPacking_ScanDetail_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.pictureBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.txtQRCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtQRCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblPackingNo;
        private DevExpress.XtraEditors.LabelControl lblShipmentNo;
        private DevExpress.XtraEditors.LabelControl lblPacking;
        private DevExpress.XtraEditors.LabelControl lblShipment;
        private DevExpress.XtraEditors.LabelControl lblErrorMsg;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}
namespace Rubix.Screen.Form.Master.Dialog
{
    partial class dlgXMSS150_ShippingArea
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
            this.groupYard = new DevExpress.XtraEditors.PanelControl();
            this.requireField3 = new Rubix.Control.RequireField();
            this.requireField2 = new Rubix.Control.RequireField();
            this.requireField1 = new Rubix.Control.RequireField();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.memoRemark = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtShippingAreaName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtShippingAreaCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupYard)).BeginInit();
            this.groupYard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAreaName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAreaCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupYard
            // 
            this.groupYard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupYard.Controls.Add(this.requireField3);
            this.groupYard.Controls.Add(this.requireField2);
            this.groupYard.Controls.Add(this.requireField1);
            this.groupYard.Controls.Add(this.warehouseControl);
            this.groupYard.Controls.Add(this.memoRemark);
            this.groupYard.Controls.Add(this.labelControl8);
            this.groupYard.Controls.Add(this.txtShippingAreaName);
            this.groupYard.Controls.Add(this.labelControl3);
            this.groupYard.Controls.Add(this.txtShippingAreaCode);
            this.groupYard.Controls.Add(this.labelControl1);
            this.groupYard.Location = new System.Drawing.Point(2, 36);
            this.groupYard.Name = "groupYard";
            this.groupYard.Size = new System.Drawing.Size(792, 140);
            this.groupYard.TabIndex = 4;
            // 
            // requireField3
            // 
            this.requireField3.Location = new System.Drawing.Point(157, 63);
            this.requireField3.Name = "requireField3";
            this.requireField3.Size = new System.Drawing.Size(10, 10);
            this.requireField3.TabIndex = 112;
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(157, 40);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 111;
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(157, 17);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 110;
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(94, 9);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(629, 21);
            this.warehouseControl.TabIndex = 0;
            // 
            // memoRemark
            // 
            this.memoRemark.Location = new System.Drawing.Point(169, 77);
            this.memoRemark.Name = "memoRemark";
            this.memoRemark.Properties.MaxLength = 100;
            this.memoRemark.Size = new System.Drawing.Size(554, 55);
            this.memoRemark.TabIndex = 3;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.Location = new System.Drawing.Point(6, 82);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(149, 13);
            this.labelControl8.TabIndex = 107;
            this.labelControl8.Text = "Remark";
            // 
            // txtShippingAreaName
            // 
            this.txtShippingAreaName.EditValue = "";
            this.txtShippingAreaName.Location = new System.Drawing.Point(169, 55);
            this.txtShippingAreaName.Name = "txtShippingAreaName";
            this.txtShippingAreaName.Properties.MaxLength = 50;
            this.txtShippingAreaName.Size = new System.Drawing.Size(554, 20);
            this.txtShippingAreaName.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(6, 59);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(149, 13);
            this.labelControl3.TabIndex = 98;
            this.labelControl3.Text = "Shipping Area Name";
            // 
            // txtShippingAreaCode
            // 
            this.txtShippingAreaCode.Location = new System.Drawing.Point(169, 33);
            this.txtShippingAreaCode.Name = "txtShippingAreaCode";
            this.txtShippingAreaCode.Properties.MaxLength = 20;
            this.txtShippingAreaCode.Size = new System.Drawing.Size(183, 20);
            this.txtShippingAreaCode.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(6, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(149, 13);
            this.labelControl1.TabIndex = 96;
            this.labelControl1.Text = "Shipping Area Code";
            // 
            // dlgXMSS150_ShippingArea
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 213);
            this.Controls.Add(this.groupYard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgXMSS150_ShippingArea";
            this.Text = "XMSS151: Shipping Area Dialog";
            this.Load += new System.EventHandler(this.dlgXMSS150_ShippingArea_Load);
            this.Controls.SetChildIndex(this.groupYard, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupYard)).EndInit();
            this.groupYard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAreaName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAreaCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl groupYard;
        private DevExpress.XtraEditors.TextEdit txtShippingAreaName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtShippingAreaCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit memoRemark;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private Control.WarehouseControl warehouseControl;
        private Control.RequireField requireField3;
        private Control.RequireField requireField2;
        private Control.RequireField requireField1;
    }
}
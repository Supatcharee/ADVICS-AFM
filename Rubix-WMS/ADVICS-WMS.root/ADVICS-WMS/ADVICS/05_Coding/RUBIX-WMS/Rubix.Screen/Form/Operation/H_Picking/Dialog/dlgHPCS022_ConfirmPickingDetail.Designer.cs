namespace Rubix.Screen.Form.Operation.H_Picking.Dialog
{
    partial class dlgHPCS022_ConfirmPickingDetail
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtPallet = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtQtyActual = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtQty = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.lblShipmentNo = new DevExpress.XtraEditors.LabelControl();
            this.txtShipmentNo = new DevExpress.XtraEditors.TextEdit();
            this.lblPickingNo = new DevExpress.XtraEditors.LabelControl();
            this.txtPickingNo = new DevExpress.XtraEditors.TextEdit();
            this.itemConditionControl = new Rubix.Control.ItemConditionControl();
            this.itemControl = new Rubix.Control.ItemControl();
            this.txtLineNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.grdRMTagResult = new DevExpress.XtraGrid.GridControl();
            this.gdvgrdRMTagResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.recCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gdcPDSNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcRunningNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLocationName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPallet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyActual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipmentNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPickingNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRMTagResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvgrdRMTagResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Controls.Add(this.lblShipmentNo);
            this.groupControl1.Controls.Add(this.txtShipmentNo);
            this.groupControl1.Controls.Add(this.lblPickingNo);
            this.groupControl1.Controls.Add(this.txtPickingNo);
            this.groupControl1.Controls.Add(this.itemConditionControl);
            this.groupControl1.Controls.Add(this.itemControl);
            this.groupControl1.Controls.Add(this.txtLineNo);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 31);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(653, 141);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Picking Information";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtPallet);
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.txtQtyActual);
            this.groupControl2.Controls.Add(this.labelControl9);
            this.groupControl2.Controls.Add(this.txtQty);
            this.groupControl2.Controls.Add(this.labelControl10);
            this.groupControl2.Location = new System.Drawing.Point(446, 24);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(194, 81);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Qty Information";
            // 
            // txtPallet
            // 
            this.txtPallet.Location = new System.Drawing.Point(110, 95);
            this.txtPallet.Name = "txtPallet";
            this.txtPallet.Properties.Mask.EditMask = "n0";
            this.txtPallet.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPallet.Size = new System.Drawing.Size(122, 20);
            this.txtPallet.TabIndex = 3;
            this.txtPallet.Visible = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(32, 98);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(70, 17);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Pallet";
            this.labelControl5.Visible = false;
            // 
            // txtQtyActual
            // 
            this.txtQtyActual.Location = new System.Drawing.Point(110, 51);
            this.txtQtyActual.Name = "txtQtyActual";
            this.txtQtyActual.Properties.DisplayFormat.FormatString = "#,###";
            this.txtQtyActual.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQtyActual.Properties.ReadOnly = true;
            this.txtQtyActual.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQtyActual.Size = new System.Drawing.Size(81, 20);
            this.txtQtyActual.TabIndex = 1;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl9.Location = new System.Drawing.Point(0, 56);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(102, 15);
            this.labelControl9.TabIndex = 2;
            this.labelControl9.Text = "Sum of Qty Actual";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(110, 29);
            this.txtQty.Name = "txtQty";
            this.txtQty.Properties.DisplayFormat.FormatString = "#,###";
            this.txtQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQty.Properties.MaxLength = 23;
            this.txtQty.Properties.ReadOnly = true;
            this.txtQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQty.Size = new System.Drawing.Size(81, 20);
            this.txtQty.TabIndex = 0;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl10.Location = new System.Drawing.Point(32, 34);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(70, 15);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "Qty";
            // 
            // lblShipmentNo
            // 
            this.lblShipmentNo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblShipmentNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblShipmentNo.Location = new System.Drawing.Point(13, 26);
            this.lblShipmentNo.Name = "lblShipmentNo";
            this.lblShipmentNo.Size = new System.Drawing.Size(89, 17);
            this.lblShipmentNo.TabIndex = 20;
            this.lblShipmentNo.Text = "Shipment No.";
            // 
            // txtShipmentNo
            // 
            this.txtShipmentNo.Location = new System.Drawing.Point(115, 24);
            this.txtShipmentNo.Name = "txtShipmentNo";
            this.txtShipmentNo.Properties.MaxLength = 22;
            this.txtShipmentNo.Properties.ReadOnly = true;
            this.txtShipmentNo.Size = new System.Drawing.Size(167, 20);
            this.txtShipmentNo.TabIndex = 19;
            // 
            // lblPickingNo
            // 
            this.lblPickingNo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblPickingNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPickingNo.Location = new System.Drawing.Point(14, 47);
            this.lblPickingNo.Name = "lblPickingNo";
            this.lblPickingNo.Size = new System.Drawing.Size(89, 18);
            this.lblPickingNo.TabIndex = 17;
            this.lblPickingNo.Text = "Picking No.";
            // 
            // txtPickingNo
            // 
            this.txtPickingNo.Location = new System.Drawing.Point(115, 46);
            this.txtPickingNo.Name = "txtPickingNo";
            this.txtPickingNo.Properties.MaxLength = 22;
            this.txtPickingNo.Properties.ReadOnly = true;
            this.txtPickingNo.Size = new System.Drawing.Size(167, 20);
            this.txtPickingNo.TabIndex = 0;
            // 
            // itemConditionControl
            // 
            this.itemConditionControl.ErrorText = "Item Condition Control is Require Field";
            this.itemConditionControl.Location = new System.Drawing.Point(13, 110);
            this.itemConditionControl.Name = "itemConditionControl";
            this.itemConditionControl.ProductID = null;
            this.itemConditionControl.RequireField = false;
            this.itemConditionControl.Size = new System.Drawing.Size(428, 22);
            this.itemConditionControl.TabIndex = 3;
            // 
            // itemControl
            // 
            this.itemControl.ErrorText = "Item Control is Require Field";
            this.itemControl.Location = new System.Drawing.Point(74, 89);
            this.itemControl.Name = "itemControl";
            this.itemControl.RequireField = false;
            this.itemControl.Size = new System.Drawing.Size(367, 22);
            this.itemControl.TabIndex = 2;
            // 
            // txtLineNo
            // 
            this.txtLineNo.Location = new System.Drawing.Point(115, 68);
            this.txtLineNo.Name = "txtLineNo";
            this.txtLineNo.Properties.ReadOnly = true;
            this.txtLineNo.Size = new System.Drawing.Size(73, 20);
            this.txtLineNo.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(70, 72);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Line No.";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.grdRMTagResult);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 172);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(653, 266);
            this.groupControl3.TabIndex = 5;
            this.groupControl3.Text = "RM Tag Information";
            // 
            // grdRMTagResult
            // 
            this.grdRMTagResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRMTagResult.Location = new System.Drawing.Point(2, 21);
            this.grdRMTagResult.MainView = this.gdvgrdRMTagResult;
            this.grdRMTagResult.Name = "grdRMTagResult";
            this.grdRMTagResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.recCheck});
            this.grdRMTagResult.Size = new System.Drawing.Size(649, 243);
            this.grdRMTagResult.TabIndex = 0;
            this.grdRMTagResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvgrdRMTagResult});
            // 
            // gdvgrdRMTagResult
            // 
            this.gdvgrdRMTagResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcSelect,
            this.gdcPDSNo,
            this.gdcRunningNo,
            this.gdcLocationName});
            this.gdvgrdRMTagResult.GridControl = this.grdRMTagResult;
            this.gdvgrdRMTagResult.Name = "gdvgrdRMTagResult";
            this.gdvgrdRMTagResult.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gdvgrdRMTagResult.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            // 
            // gdcSelect
            // 
            this.gdcSelect.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcSelect.AppearanceHeader.Options.UseFont = true;
            this.gdcSelect.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSelect.Caption = "Select";
            this.gdcSelect.ColumnEdit = this.recCheck;
            this.gdcSelect.FieldName = "Select";
            this.gdcSelect.Name = "gdcSelect";
            this.gdcSelect.Visible = true;
            this.gdcSelect.VisibleIndex = 0;
            this.gdcSelect.Width = 110;
            // 
            // recCheck
            // 
            this.recCheck.AutoHeight = false;
            this.recCheck.Name = "recCheck";
            this.recCheck.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.recCheck.ValueChecked = ((long)(1));
            this.recCheck.ValueUnchecked = ((long)(0));
            this.recCheck.EditValueChanged += new System.EventHandler(this.recCheck_EditValueChanged);
            // 
            // gdcPDSNo
            // 
            this.gdcPDSNo.AppearanceCell.Options.UseTextOptions = true;
            this.gdcPDSNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPDSNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPDSNo.AppearanceHeader.Options.UseFont = true;
            this.gdcPDSNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPDSNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPDSNo.Caption = "PDS No.";
            this.gdcPDSNo.FieldName = "PDSNo";
            this.gdcPDSNo.Name = "gdcPDSNo";
            this.gdcPDSNo.OptionsColumn.AllowEdit = false;
            this.gdcPDSNo.Visible = true;
            this.gdcPDSNo.VisibleIndex = 1;
            this.gdcPDSNo.Width = 356;
            // 
            // gdcRunningNo
            // 
            this.gdcRunningNo.AppearanceCell.Options.UseTextOptions = true;
            this.gdcRunningNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcRunningNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcRunningNo.AppearanceHeader.Options.UseFont = true;
            this.gdcRunningNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcRunningNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcRunningNo.Caption = "Running No.";
            this.gdcRunningNo.FieldName = "RunningNo";
            this.gdcRunningNo.Name = "gdcRunningNo";
            this.gdcRunningNo.OptionsColumn.AllowEdit = false;
            this.gdcRunningNo.Visible = true;
            this.gdcRunningNo.VisibleIndex = 2;
            this.gdcRunningNo.Width = 356;
            // 
            // gdcLocationName
            // 
            this.gdcLocationName.AppearanceCell.Options.UseTextOptions = true;
            this.gdcLocationName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcLocationName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcLocationName.AppearanceHeader.Options.UseFont = true;
            this.gdcLocationName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcLocationName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcLocationName.Caption = "Location";
            this.gdcLocationName.FieldName = "LocationCode";
            this.gdcLocationName.Name = "gdcLocationName";
            this.gdcLocationName.OptionsColumn.AllowEdit = false;
            this.gdcLocationName.Visible = true;
            this.gdcLocationName.VisibleIndex = 3;
            this.gdcLocationName.Width = 358;
            // 
            // dlgHPCS022_ConfirmPickingDetail
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 469);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgHPCS022_ConfirmPickingDetail";
            this.Text = "HPCS022 : Confirm Picking Detail Dialog";
            this.Load += new System.EventHandler(this.dlgHPCS022_ConfirmPickingDetail_Load);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPallet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyActual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipmentNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPickingNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRMTagResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvgrdRMTagResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblPickingNo;
        private DevExpress.XtraEditors.TextEdit txtPickingNo;
        private Control.ItemConditionControl itemConditionControl;
        private Control.ItemControl itemControl;
        private DevExpress.XtraEditors.TextEdit txtLineNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblShipmentNo;
        private DevExpress.XtraEditors.TextEdit txtShipmentNo;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit txtPallet;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtQtyActual;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtQty;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl grdRMTagResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvgrdRMTagResult;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSelect;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPDSNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcRunningNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLocationName;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit recCheck;

    }
}
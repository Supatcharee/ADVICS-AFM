namespace Rubix.Screen.Form.Operation.F_ShippingEntry.Dialog
{
    partial class dlgFSES014_ShippingByLot
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
            this.grdLot = new DevExpress.XtraGrid.GridControl();
            this.gdvLot = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcReceivingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPalletNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPalletNoRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcReceiveQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRcvUnitCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcShippingQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repQty = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcInventory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAvalQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcQtyPlan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPackingUnitCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProductConditionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnitID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProductConditionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRcvUnitID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLotKey = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvLot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repQty)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.grdLot);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 31);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(866, 338);
            this.groupControl1.TabIndex = 4;
            // 
            // grdLot
            // 
            this.grdLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLot.Location = new System.Drawing.Point(2, 21);
            this.grdLot.MainView = this.gdvLot;
            this.grdLot.Name = "grdLot";
            this.grdLot.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repQty,
            this.repSelect});
            this.grdLot.Size = new System.Drawing.Size(862, 315);
            this.grdLot.TabIndex = 0;
            this.grdLot.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvLot});
            // 
            // gdvLot
            // 
            this.gdvLot.BestFitMaxRowCount = 50;
            this.gdvLot.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcSelect,
            this.gcReceivingDate,
            this.gcInvoice,
            this.gcLotNo,
            this.gcPalletNo,
            this.gcPalletNoRef,
            this.gcPONo,
            this.gcReceiveQty,
            this.gcRcvUnitCode,
            this.gcShippingQty,
            this.gcInventory,
            this.gcAvalQty,
            this.gcQtyPlan,
            this.gcPackingUnitCode,
            this.gcProductConditionName,
            this.gcUnitID,
            this.gcProductConditionID,
            this.gcRcvUnitID,
            this.gcLotKey});
            this.gdvLot.GridControl = this.grdLot;
            this.gdvLot.Name = "gdvLot";
            this.gdvLot.OptionsView.ColumnAutoWidth = false;
            this.gdvLot.OptionsView.ShowFooter = true;
            this.gdvLot.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.gdvLot_CustomSummaryCalculate);
            // 
            // gcSelect
            // 
            this.gcSelect.Caption = " Select";
            this.gcSelect.ColumnEdit = this.repSelect;
            this.gcSelect.FieldName = "Select";
            this.gcSelect.Name = "gcSelect";
            this.gcSelect.OptionsColumn.AllowEdit = false;
            this.gcSelect.Visible = true;
            this.gcSelect.VisibleIndex = 0;
            // 
            // repSelect
            // 
            this.repSelect.AutoHeight = false;
            this.repSelect.Name = "repSelect";
            this.repSelect.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repSelect.CheckedChanged += new System.EventHandler(this.repSelect_CheckedChanged);
            // 
            // gcReceivingDate
            // 
            this.gcReceivingDate.Caption = "Receiving Date";
            this.gcReceivingDate.FieldName = "ReceivingDate";
            this.gcReceivingDate.Name = "gcReceivingDate";
            this.gcReceivingDate.OptionsColumn.AllowEdit = false;
            this.gcReceivingDate.Visible = true;
            this.gcReceivingDate.VisibleIndex = 1;
            // 
            // gcInvoice
            // 
            this.gcInvoice.Caption = "Invoice No.";
            this.gcInvoice.FieldName = "InvoiceNo";
            this.gcInvoice.Name = "gcInvoice";
            this.gcInvoice.OptionsColumn.AllowEdit = false;
            this.gcInvoice.Visible = true;
            this.gcInvoice.VisibleIndex = 2;
            // 
            // gcLotNo
            // 
            this.gcLotNo.Caption = "Lot No.";
            this.gcLotNo.FieldName = "LotNo";
            this.gcLotNo.Name = "gcLotNo";
            this.gcLotNo.OptionsColumn.AllowEdit = false;
            this.gcLotNo.Visible = true;
            this.gcLotNo.VisibleIndex = 3;
            // 
            // gcPalletNo
            // 
            this.gcPalletNo.Caption = "Pallet No.";
            this.gcPalletNo.FieldName = "PalletNo";
            this.gcPalletNo.Name = "gcPalletNo";
            this.gcPalletNo.OptionsColumn.AllowEdit = false;
            this.gcPalletNo.OptionsColumn.ShowInCustomizationForm = false;
            this.gcPalletNo.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // gcPalletNoRef
            // 
            this.gcPalletNoRef.Caption = "Pallet No. (Ref)";
            this.gcPalletNoRef.FieldName = "PalletNoRef";
            this.gcPalletNoRef.Name = "gcPalletNoRef";
            this.gcPalletNoRef.OptionsColumn.AllowEdit = false;
            this.gcPalletNoRef.OptionsColumn.ShowInCustomizationForm = false;
            this.gcPalletNoRef.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // gcPONo
            // 
            this.gcPONo.Caption = "PO No.";
            this.gcPONo.FieldName = "PONo";
            this.gcPONo.Name = "gcPONo";
            this.gcPONo.OptionsColumn.AllowEdit = false;
            this.gcPONo.Visible = true;
            this.gcPONo.VisibleIndex = 4;
            // 
            // gcReceiveQty
            // 
            this.gcReceiveQty.Caption = "Receive Qty";
            this.gcReceiveQty.FieldName = "ReceiveQty";
            this.gcReceiveQty.Name = "gcReceiveQty";
            this.gcReceiveQty.OptionsColumn.AllowEdit = false;
            this.gcReceiveQty.Visible = true;
            this.gcReceiveQty.VisibleIndex = 5;
            // 
            // gcRcvUnitCode
            // 
            this.gcRcvUnitCode.Caption = "Unit Code";
            this.gcRcvUnitCode.FieldName = "RcvUnitCode";
            this.gcRcvUnitCode.Name = "gcRcvUnitCode";
            this.gcRcvUnitCode.OptionsColumn.AllowEdit = false;
            this.gcRcvUnitCode.Visible = true;
            this.gcRcvUnitCode.VisibleIndex = 6;
            // 
            // gcShippingQty
            // 
            this.gcShippingQty.Caption = "Shipping Qty";
            this.gcShippingQty.ColumnEdit = this.repQty;
            this.gcShippingQty.FieldName = "ShippingQty";
            this.gcShippingQty.Name = "gcShippingQty";
            this.gcShippingQty.OptionsColumn.AllowEdit = false;
            this.gcShippingQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)});
            this.gcShippingQty.Visible = true;
            this.gcShippingQty.VisibleIndex = 7;
            // 
            // repQty
            // 
            this.repQty.AutoHeight = false;
            this.repQty.Mask.EditMask = "\\d{0,15}(\\.{1}\\d{0,3}){0,1}";
            this.repQty.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repQty.Name = "repQty";
            this.repQty.EditValueChanged += new System.EventHandler(this.repQty_EditValueChanged);
            // 
            // gcInventory
            // 
            this.gcInventory.Caption = "Inventory Qty";
            this.gcInventory.FieldName = "Inventory";
            this.gcInventory.Name = "gcInventory";
            this.gcInventory.OptionsColumn.AllowEdit = false;
            this.gcInventory.Visible = true;
            this.gcInventory.VisibleIndex = 8;
            // 
            // gcAvalQty
            // 
            this.gcAvalQty.Caption = "Available Qty";
            this.gcAvalQty.FieldName = "AvalQty";
            this.gcAvalQty.Name = "gcAvalQty";
            this.gcAvalQty.OptionsColumn.AllowEdit = false;
            this.gcAvalQty.Visible = true;
            this.gcAvalQty.VisibleIndex = 9;
            // 
            // gcQtyPlan
            // 
            this.gcQtyPlan.Caption = "Qty (Plan)";
            this.gcQtyPlan.FieldName = "PlanQty";
            this.gcQtyPlan.Name = "gcQtyPlan";
            this.gcQtyPlan.OptionsColumn.AllowEdit = false;
            this.gcQtyPlan.Visible = true;
            this.gcQtyPlan.VisibleIndex = 10;
            // 
            // gcPackingUnitCode
            // 
            this.gcPackingUnitCode.Caption = "Unit Code";
            this.gcPackingUnitCode.FieldName = "UnitCode";
            this.gcPackingUnitCode.Name = "gcPackingUnitCode";
            this.gcPackingUnitCode.OptionsColumn.AllowEdit = false;
            this.gcPackingUnitCode.Visible = true;
            this.gcPackingUnitCode.VisibleIndex = 11;
            // 
            // gcProductConditionName
            // 
            this.gcProductConditionName.Caption = "Item Condition Name";
            this.gcProductConditionName.FieldName = "ProductConditionName";
            this.gcProductConditionName.Name = "gcProductConditionName";
            this.gcProductConditionName.OptionsColumn.AllowEdit = false;
            this.gcProductConditionName.Visible = true;
            this.gcProductConditionName.VisibleIndex = 12;
            // 
            // gcUnitID
            // 
            this.gcUnitID.Caption = "UnitID";
            this.gcUnitID.FieldName = "UnitID";
            this.gcUnitID.Name = "gcUnitID";
            this.gcUnitID.OptionsColumn.AllowEdit = false;
            this.gcUnitID.OptionsColumn.ShowCaption = false;
            this.gcUnitID.OptionsColumn.ShowInCustomizationForm = false;
            this.gcUnitID.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // gcProductConditionID
            // 
            this.gcProductConditionID.Caption = "ProductConditionID";
            this.gcProductConditionID.FieldName = "ProductConditionID";
            this.gcProductConditionID.Name = "gcProductConditionID";
            this.gcProductConditionID.OptionsColumn.AllowEdit = false;
            this.gcProductConditionID.OptionsColumn.ShowCaption = false;
            this.gcProductConditionID.OptionsColumn.ShowInCustomizationForm = false;
            this.gcProductConditionID.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // gcRcvUnitID
            // 
            this.gcRcvUnitID.Caption = "gridColumn1";
            this.gcRcvUnitID.FieldName = "RcvUnitID";
            this.gcRcvUnitID.Name = "gcRcvUnitID";
            this.gcRcvUnitID.OptionsColumn.AllowEdit = false;
            this.gcRcvUnitID.OptionsColumn.ShowCaption = false;
            this.gcRcvUnitID.OptionsColumn.ShowInCustomizationForm = false;
            this.gcRcvUnitID.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // gcLotKey
            // 
            this.gcLotKey.Caption = "LotKey";
            this.gcLotKey.FieldName = "LotKey";
            this.gcLotKey.Name = "gcLotKey";
            this.gcLotKey.OptionsColumn.AllowEdit = false;
            this.gcLotKey.OptionsColumn.ShowCaption = false;
            this.gcLotKey.OptionsColumn.ShowInCustomizationForm = false;
            this.gcLotKey.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // dlgFSES013_ShippingByLot
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 400);
            this.ControlBox = false;
            this.Controls.Add(this.groupControl1);
            this.Name = "dlgFSES014_ShippingByLot";
            this.Text = "FSES014 : Shipping By Lot Dialog";
            this.Load += new System.EventHandler(this.dlgFSES014_ShippingByLot_Load);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvLot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl grdLot;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvLot;
        private DevExpress.XtraGrid.Columns.GridColumn gcSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repSelect;
        private DevExpress.XtraGrid.Columns.GridColumn gcReceivingDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcLotNo;
        private DevExpress.XtraGrid.Columns.GridColumn gcPalletNo;
        private DevExpress.XtraGrid.Columns.GridColumn gcPalletNoRef;
        private DevExpress.XtraGrid.Columns.GridColumn gcPONo;
        private DevExpress.XtraGrid.Columns.GridColumn gcReceiveQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcInventory;
        private DevExpress.XtraGrid.Columns.GridColumn gcShippingQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repQty;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductConditionName;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnitID;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductConditionID;
        private DevExpress.XtraGrid.Columns.GridColumn gcLotKey;
        private DevExpress.XtraGrid.Columns.GridColumn gcRcvUnitCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcPackingUnitCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcRcvUnitID;
        private DevExpress.XtraGrid.Columns.GridColumn gcInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn gcQtyPlan;
        private DevExpress.XtraGrid.Columns.GridColumn gcAvalQty;
    }
}
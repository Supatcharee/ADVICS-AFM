namespace Rubix.Control
{
    partial class LotByLocationControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboLotNo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.GridSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcReceiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProductConditionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPalletNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPalletRefNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcInventory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcAvalQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcQtyPlan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUnitCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPalletNo = new DevExpress.XtraEditors.TextEdit();
            this.errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            this.grcLocationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcLocationName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cboLotNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPalletNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(80, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(6, 13);
            this.labelControl2.TabIndex = 29;
            this.labelControl2.Text = "  ";
            // 
            // cboLotNo
            // 
            this.cboLotNo.EditValue = "";
            this.cboLotNo.Location = new System.Drawing.Point(89, 1);
            this.cboLotNo.Name = "cboLotNo";
            this.cboLotNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLotNo.Properties.NullText = "";
            this.cboLotNo.Properties.View = this.GridSearch;
            this.cboLotNo.Size = new System.Drawing.Size(123, 20);
            this.cboLotNo.TabIndex = 27;
            this.cboLotNo.EditValueChanged += new System.EventHandler(this.cboLotNo_EditValueChanged);
            // 
            // GridSearch
            // 
            this.GridSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcReceiveDate,
            this.gcInvoice,
            this.gdcLotNo,
            this.grcLocationCode,
            this.grcLocationName,
            this.gcProductConditionCode,
            this.gdcPalletNo,
            this.gdcPalletRefNo,
            this.gdcPONo,
            this.gdcQty,
            this.gdcInventory,
            this.gdcAvalQty,
            this.gdcQtyPlan,
            this.gdcUnitCode});
            this.GridSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridSearch.OptionsView.ColumnAutoWidth = false;
            this.GridSearch.OptionsView.ShowGroupPanel = false;
            this.GridSearch.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GridSearch_FocusedRowChanged);
            // 
            // gdcReceiveDate
            // 
            this.gdcReceiveDate.Caption = "Receive Date";
            this.gdcReceiveDate.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm";
            this.gdcReceiveDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcReceiveDate.FieldName = "ReceivingDate";
            this.gdcReceiveDate.Name = "gdcReceiveDate";
            this.gdcReceiveDate.Visible = true;
            this.gdcReceiveDate.VisibleIndex = 0;
            // 
            // gcInvoice
            // 
            this.gcInvoice.Caption = "Invoice No.";
            this.gcInvoice.FieldName = "InvoiceNo";
            this.gcInvoice.Name = "gcInvoice";
            this.gcInvoice.Visible = true;
            this.gcInvoice.VisibleIndex = 1;
            // 
            // gdcLotNo
            // 
            this.gdcLotNo.Caption = "Lot No.";
            this.gdcLotNo.FieldName = "LotNo";
            this.gdcLotNo.Name = "gdcLotNo";
            this.gdcLotNo.Visible = true;
            this.gdcLotNo.VisibleIndex = 2;
            // 
            // gcProductConditionCode
            // 
            this.gcProductConditionCode.Caption = "Condition";
            this.gcProductConditionCode.FieldName = "ProductConditionName";
            this.gcProductConditionCode.Name = "gcProductConditionCode";
            this.gcProductConditionCode.Visible = true;
            this.gcProductConditionCode.VisibleIndex = 5;
            // 
            // gdcPalletNo
            // 
            this.gdcPalletNo.Caption = "Pallet No.";
            this.gdcPalletNo.FieldName = "PalletNo";
            this.gdcPalletNo.Name = "gdcPalletNo";
            this.gdcPalletNo.OptionsColumn.ShowInCustomizationForm = false;
            this.gdcPalletNo.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // gdcPalletRefNo
            // 
            this.gdcPalletRefNo.Caption = "Pallet Ref. No.";
            this.gdcPalletRefNo.FieldName = "PalletNoRef";
            this.gdcPalletRefNo.Name = "gdcPalletRefNo";
            this.gdcPalletRefNo.OptionsColumn.ShowInCustomizationForm = false;
            this.gdcPalletRefNo.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // gdcPONo
            // 
            this.gdcPONo.Caption = "PO No.";
            this.gdcPONo.FieldName = "PONo";
            this.gdcPONo.Name = "gdcPONo";
            this.gdcPONo.Visible = true;
            this.gdcPONo.VisibleIndex = 6;
            // 
            // gdcQty
            // 
            this.gdcQty.Caption = "Begin Qty";
            this.gdcQty.DisplayFormat.FormatString = "#,###,###,##0.000";
            this.gdcQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcQty.FieldName = "ReceiveQty";
            this.gdcQty.Name = "gdcQty";
            this.gdcQty.Visible = true;
            this.gdcQty.VisibleIndex = 7;
            // 
            // gdcInventory
            // 
            this.gdcInventory.Caption = "Inventory";
            this.gdcInventory.DisplayFormat.FormatString = "#,###,###,##0.000";
            this.gdcInventory.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcInventory.FieldName = "Inventory";
            this.gdcInventory.Name = "gdcInventory";
            this.gdcInventory.Visible = true;
            this.gdcInventory.VisibleIndex = 8;
            // 
            // gdcAvalQty
            // 
            this.gdcAvalQty.Caption = "Aval Qty";
            this.gdcAvalQty.DisplayFormat.FormatString = "#,###,###,##0.000";
            this.gdcAvalQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcAvalQty.FieldName = "AvalQty";
            this.gdcAvalQty.Name = "gdcAvalQty";
            this.gdcAvalQty.Visible = true;
            this.gdcAvalQty.VisibleIndex = 9;
            // 
            // gdcQtyPlan
            // 
            this.gdcQtyPlan.Caption = "Qty (Plan)";
            this.gdcQtyPlan.DisplayFormat.FormatString = "#,###,###,##0.000";
            this.gdcQtyPlan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcQtyPlan.FieldName = "ShipPlanQty";
            this.gdcQtyPlan.Name = "gdcQtyPlan";
            this.gdcQtyPlan.Visible = true;
            this.gdcQtyPlan.VisibleIndex = 10;
            // 
            // gdcUnitCode
            // 
            this.gdcUnitCode.Caption = "UnitCode";
            this.gdcUnitCode.FieldName = "UnitCode";
            this.gdcUnitCode.Name = "gdcUnitCode";
            this.gdcUnitCode.Visible = true;
            this.gdcUnitCode.VisibleIndex = 11;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(-1, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 13);
            this.labelControl1.TabIndex = 30;
            this.labelControl1.Text = "Lot";
            // 
            // txtPalletNo
            // 
            this.txtPalletNo.Location = new System.Drawing.Point(214, 1);
            this.txtPalletNo.Name = "txtPalletNo";
            this.txtPalletNo.Properties.ReadOnly = true;
            this.txtPalletNo.Size = new System.Drawing.Size(234, 20);
            this.txtPalletNo.TabIndex = 28;
            this.txtPalletNo.Tag = "no control";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // grcLocationCode
            // 
            this.grcLocationCode.Caption = "Location Code";
            this.grcLocationCode.FieldName = "LocationCode";
            this.grcLocationCode.Name = "grcLocationCode";
            this.grcLocationCode.Visible = true;
            this.grcLocationCode.VisibleIndex = 3;
            // 
            // grcLocationName
            // 
            this.grcLocationName.Caption = "Location Name";
            this.grcLocationName.FieldName = "LocationName";
            this.grcLocationName.Name = "grcLocationName";
            this.grcLocationName.Visible = true;
            this.grcLocationName.VisibleIndex = 4;
            // 
            // LotByLocationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboLotNo);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtPalletNo);
            this.Name = "LotByLocationControl";
            this.Size = new System.Drawing.Size(452, 23);
            this.Load += new System.EventHandler(this.LotByLocationControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboLotNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPalletNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit cboLotNo;
        private DevExpress.XtraGrid.Views.Grid.GridView GridSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gdcReceiveDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLotNo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPalletNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPalletNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcQty;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider errorProvider;
        private DevExpress.XtraGrid.Columns.GridColumn gdcInventory;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUnitCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPalletRefNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPONo;
        private DevExpress.XtraGrid.Columns.GridColumn gcInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductConditionCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcQtyPlan;
        private DevExpress.XtraGrid.Columns.GridColumn gdcAvalQty;
        private DevExpress.XtraGrid.Columns.GridColumn grcLocationCode;
        private DevExpress.XtraGrid.Columns.GridColumn grcLocationName;
    }
}

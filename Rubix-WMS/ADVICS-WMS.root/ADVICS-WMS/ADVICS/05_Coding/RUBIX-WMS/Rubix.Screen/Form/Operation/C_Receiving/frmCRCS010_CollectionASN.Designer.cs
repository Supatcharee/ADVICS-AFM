namespace Rubix.Screen.Form.Operation.C_Receiving
{
    partial class frmCRCS010_CollectionASN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCRCS010_CollectionASN));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.requireField1 = new Rubix.Control.RequireField();
            this.requireField5 = new Rubix.Control.RequireField();
            this.supplierControl = new Rubix.Control.SupplierControl();
            this.truckCompanyControl = new Rubix.Control.TruckCompanyControl();
            this.dtArrivalDateTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtArrivalDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.txtSlipNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSupplierCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSupplierLongName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcReceivingNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcInstallment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcArrivalDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPalletNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPalletNoRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcQtyUnitID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repUnit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gdcNetWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcTypeOfPackageID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repPack = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gdcInPackage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcInPackageUnitID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcProductConditionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCondition = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gdcPartName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtArrivalDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtArrivalDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtArrivalDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtArrivalDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSlipNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCondition)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Size = new System.Drawing.Size(1106, 47);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.requireField1);
            this.groupControl1.Controls.Add(this.requireField5);
            this.groupControl1.Controls.Add(this.supplierControl);
            this.groupControl1.Controls.Add(this.truckCompanyControl);
            this.groupControl1.Controls.Add(this.dtArrivalDateTo);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.dtArrivalDateFrom);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.warehouseControl);
            this.groupControl1.Controls.Add(this.ownerControl);
            this.groupControl1.Controls.Add(this.txtSlipNo);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 78);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1106, 93);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Search Criteria";
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(137, 54);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 189;
            // 
            // requireField5
            // 
            this.requireField5.Location = new System.Drawing.Point(137, 31);
            this.requireField5.Name = "requireField5";
            this.requireField5.Size = new System.Drawing.Size(10, 10);
            this.requireField5.TabIndex = 189;
            // 
            // supplierControl
            // 
            this.supplierControl.ErrorText = "Supplier is Require Field";
            this.supplierControl.Location = new System.Drawing.Point(95, 68);
            this.supplierControl.Name = "supplierControl";
            this.supplierControl.ReadOnly = false;
            this.supplierControl.RequireField = false;
            this.supplierControl.Size = new System.Drawing.Size(442, 23);
            this.supplierControl.TabIndex = 3;
            // 
            // truckCompanyControl
            // 
            this.truckCompanyControl.ErrorText = "Truck Company Control is Require Field";
            this.truckCompanyControl.Location = new System.Drawing.Point(575, 23);
            this.truckCompanyControl.Name = "truckCompanyControl";
            this.truckCompanyControl.RequireField = false;
            this.truckCompanyControl.Size = new System.Drawing.Size(476, 22);
            this.truckCompanyControl.TabIndex = 4;
            // 
            // dtArrivalDateTo
            // 
            this.dtArrivalDateTo.EditValue = null;
            this.dtArrivalDateTo.Location = new System.Drawing.Point(807, 68);
            this.dtArrivalDateTo.Name = "dtArrivalDateTo";
            this.dtArrivalDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtArrivalDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtArrivalDateTo.Size = new System.Drawing.Size(123, 20);
            this.dtArrivalDateTo.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(791, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 13);
            this.labelControl2.TabIndex = 113;
            this.labelControl2.Text = "To";
            // 
            // dtArrivalDateFrom
            // 
            this.dtArrivalDateFrom.EditValue = null;
            this.dtArrivalDateFrom.Location = new System.Drawing.Point(662, 68);
            this.dtArrivalDateFrom.Name = "dtArrivalDateFrom";
            this.dtArrivalDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtArrivalDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtArrivalDateFrom.Size = new System.Drawing.Size(123, 20);
            this.dtArrivalDateFrom.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(516, 71);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(131, 17);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Arrival Date";
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(74, 47);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(463, 21);
            this.warehouseControl.TabIndex = 2;
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(88, 24);
            this.ownerControl.Name = "ownerControl";
            this.ownerControl.ReadOnly = false;
            this.ownerControl.RequireField = false;
            this.ownerControl.Size = new System.Drawing.Size(449, 21);
            this.ownerControl.TabIndex = 1;
            this.ownerControl.EditValueChanged += new System.EventHandler(this.ownerControl_EditValueChanged);
            // 
            // txtSlipNo
            // 
            this.txtSlipNo.Location = new System.Drawing.Point(662, 46);
            this.txtSlipNo.MenuManager = this.ribbonControl1;
            this.txtSlipNo.Name = "txtSlipNo";
            this.txtSlipNo.Properties.MaxLength = 50;
            this.txtSlipNo.Size = new System.Drawing.Size(123, 20);
            this.txtSlipNo.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(525, 49);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(125, 17);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Receiving No.";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(1027, 65);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(946, 65);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 171);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1106, 319);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Search Result";
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSearchResult.Location = new System.Drawing.Point(2, 21);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.MenuManager = this.ribbonControl1;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repUnit,
            this.repPack,
            this.repCondition});
            this.grdSearchResult.Size = new System.Drawing.Size(1102, 296);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcStatus,
            this.gdcSupplierCode,
            this.gdcSupplierLongName,
            this.gdcReceivingNo,
            this.gdcInstallment,
            this.gdcArrivalDate,
            this.gdcLineNo,
            this.gdcPalletNo,
            this.gdcItemCode,
            this.gdcPartName,
            this.gdcLotNo,
            this.gdcPalletNoRef,
            this.gdcQty,
            this.gdcQtyUnitID,
            this.gdcNetWeight,
            this.gdcTypeOfPackageID,
            this.gdcInPackage,
            this.gdcInPackageUnitID,
            this.gdcProductConditionID});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsCustomization.AllowGroup = false;
            this.gdvSearchResult.OptionsView.AllowCellMerge = true;
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            this.gdvSearchResult.OptionsView.ShowGroupPanel = false;
            this.gdvSearchResult.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.gdvSearchResult_CellMerge);
            // 
            // gdcStatus
            // 
            this.gdcStatus.AppearanceCell.Options.UseTextOptions = true;
            this.gdcStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcStatus.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcStatus.AppearanceHeader.Options.UseFont = true;
            this.gdcStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcStatus.Caption = "Status";
            this.gdcStatus.FieldName = "Status";
            this.gdcStatus.Name = "gdcStatus";
            this.gdcStatus.Visible = true;
            this.gdcStatus.VisibleIndex = 0;
            // 
            // gdcSupplierCode
            // 
            this.gdcSupplierCode.AppearanceCell.Options.UseTextOptions = true;
            this.gdcSupplierCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcSupplierCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcSupplierCode.AppearanceHeader.Options.UseFont = true;
            this.gdcSupplierCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSupplierCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSupplierCode.Caption = "Supplier Code";
            this.gdcSupplierCode.FieldName = "SupplierCode";
            this.gdcSupplierCode.Name = "gdcSupplierCode";
            this.gdcSupplierCode.Visible = true;
            this.gdcSupplierCode.VisibleIndex = 1;
            // 
            // gdcSupplierLongName
            // 
            this.gdcSupplierLongName.AppearanceCell.Options.UseTextOptions = true;
            this.gdcSupplierLongName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcSupplierLongName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcSupplierLongName.AppearanceHeader.Options.UseFont = true;
            this.gdcSupplierLongName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSupplierLongName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSupplierLongName.Caption = "Supplier Name";
            this.gdcSupplierLongName.FieldName = "SupplierLongName";
            this.gdcSupplierLongName.Name = "gdcSupplierLongName";
            this.gdcSupplierLongName.Visible = true;
            this.gdcSupplierLongName.VisibleIndex = 2;
            // 
            // gdcReceivingNo
            // 
            this.gdcReceivingNo.AppearanceCell.Options.UseTextOptions = true;
            this.gdcReceivingNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcReceivingNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcReceivingNo.AppearanceHeader.Options.UseFont = true;
            this.gdcReceivingNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcReceivingNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcReceivingNo.Caption = "Receiving No.";
            this.gdcReceivingNo.FieldName = "ReceivingNo";
            this.gdcReceivingNo.Name = "gdcReceivingNo";
            this.gdcReceivingNo.Visible = true;
            this.gdcReceivingNo.VisibleIndex = 3;
            // 
            // gdcInstallment
            // 
            this.gdcInstallment.AppearanceCell.Options.UseTextOptions = true;
            this.gdcInstallment.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcInstallment.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcInstallment.AppearanceHeader.Options.UseFont = true;
            this.gdcInstallment.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcInstallment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcInstallment.Caption = "Installment";
            this.gdcInstallment.FieldName = "Installment";
            this.gdcInstallment.Name = "gdcInstallment";
            this.gdcInstallment.Visible = true;
            this.gdcInstallment.VisibleIndex = 4;
            // 
            // gdcArrivalDate
            // 
            this.gdcArrivalDate.AppearanceCell.Options.UseTextOptions = true;
            this.gdcArrivalDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcArrivalDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcArrivalDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcArrivalDate.AppearanceHeader.Options.UseFont = true;
            this.gdcArrivalDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcArrivalDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcArrivalDate.Caption = "Arrival Date";
            this.gdcArrivalDate.FieldName = "ArrivalDate";
            this.gdcArrivalDate.Name = "gdcArrivalDate";
            this.gdcArrivalDate.Visible = true;
            this.gdcArrivalDate.VisibleIndex = 5;
            // 
            // gdcLineNo
            // 
            this.gdcLineNo.AppearanceCell.Options.UseTextOptions = true;
            this.gdcLineNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcLineNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcLineNo.AppearanceHeader.Options.UseFont = true;
            this.gdcLineNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcLineNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcLineNo.Caption = "Line No.";
            this.gdcLineNo.FieldName = "LineNo";
            this.gdcLineNo.Name = "gdcLineNo";
            this.gdcLineNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gdcLineNo.Visible = true;
            this.gdcLineNo.VisibleIndex = 6;
            // 
            // gdcPalletNo
            // 
            this.gdcPalletNo.AppearanceCell.Options.UseTextOptions = true;
            this.gdcPalletNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcPalletNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPalletNo.AppearanceHeader.Options.UseFont = true;
            this.gdcPalletNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPalletNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPalletNo.Caption = "Pallet No.";
            this.gdcPalletNo.FieldName = "PalletNo";
            this.gdcPalletNo.Name = "gdcPalletNo";
            this.gdcPalletNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gdcPalletNo.OptionsColumn.ShowInCustomizationForm = false;
            this.gdcPalletNo.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // gdcItemCode
            // 
            this.gdcItemCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcItemCode.AppearanceHeader.Options.UseFont = true;
            this.gdcItemCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcItemCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcItemCode.Caption = "Item Code";
            this.gdcItemCode.FieldName = "ProductCode";
            this.gdcItemCode.Name = "gdcItemCode";
            this.gdcItemCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gdcItemCode.Visible = true;
            this.gdcItemCode.VisibleIndex = 7;
            // 
            // gdcLotNo
            // 
            this.gdcLotNo.AppearanceCell.Options.UseTextOptions = true;
            this.gdcLotNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcLotNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcLotNo.AppearanceHeader.Options.UseFont = true;
            this.gdcLotNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcLotNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcLotNo.Caption = "Lot No.";
            this.gdcLotNo.FieldName = "LotNo";
            this.gdcLotNo.Name = "gdcLotNo";
            this.gdcLotNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gdcPalletNoRef
            // 
            this.gdcPalletNoRef.AppearanceCell.Options.UseTextOptions = true;
            this.gdcPalletNoRef.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcPalletNoRef.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPalletNoRef.AppearanceHeader.Options.UseFont = true;
            this.gdcPalletNoRef.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPalletNoRef.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPalletNoRef.Caption = "Pallet No. Ref.";
            this.gdcPalletNoRef.FieldName = "PalletNoRef";
            this.gdcPalletNoRef.Name = "gdcPalletNoRef";
            this.gdcPalletNoRef.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gdcQty
            // 
            this.gdcQty.AppearanceCell.Options.UseTextOptions = true;
            this.gdcQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gdcQty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcQty.AppearanceHeader.Options.UseFont = true;
            this.gdcQty.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcQty.Caption = "Qty";
            this.gdcQty.DisplayFormat.FormatString = "n3";
            this.gdcQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcQty.FieldName = "Qty";
            this.gdcQty.Name = "gdcQty";
            this.gdcQty.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gdcQty.Visible = true;
            this.gdcQty.VisibleIndex = 9;
            // 
            // gdcQtyUnitID
            // 
            this.gdcQtyUnitID.AppearanceCell.Options.UseTextOptions = true;
            this.gdcQtyUnitID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcQtyUnitID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcQtyUnitID.AppearanceHeader.Options.UseFont = true;
            this.gdcQtyUnitID.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcQtyUnitID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcQtyUnitID.Caption = "Qty Unit";
            this.gdcQtyUnitID.ColumnEdit = this.repUnit;
            this.gdcQtyUnitID.FieldName = "QtyUnitID";
            this.gdcQtyUnitID.Name = "gdcQtyUnitID";
            this.gdcQtyUnitID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gdcQtyUnitID.Visible = true;
            this.gdcQtyUnitID.VisibleIndex = 10;
            // 
            // repUnit
            // 
            this.repUnit.AutoHeight = false;
            this.repUnit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repUnit.Name = "repUnit";
            this.repUnit.NullText = "";
            // 
            // gdcNetWeight
            // 
            this.gdcNetWeight.AppearanceCell.Options.UseTextOptions = true;
            this.gdcNetWeight.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gdcNetWeight.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcNetWeight.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcNetWeight.AppearanceHeader.Options.UseFont = true;
            this.gdcNetWeight.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcNetWeight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcNetWeight.Caption = "Net Weight";
            this.gdcNetWeight.FieldName = "NetWeight";
            this.gdcNetWeight.Name = "gdcNetWeight";
            this.gdcNetWeight.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gdcNetWeight.Visible = true;
            this.gdcNetWeight.VisibleIndex = 11;
            // 
            // gdcTypeOfPackageID
            // 
            this.gdcTypeOfPackageID.AppearanceCell.Options.UseTextOptions = true;
            this.gdcTypeOfPackageID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcTypeOfPackageID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcTypeOfPackageID.AppearanceHeader.Options.UseFont = true;
            this.gdcTypeOfPackageID.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcTypeOfPackageID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcTypeOfPackageID.Caption = "Type Of Package";
            this.gdcTypeOfPackageID.ColumnEdit = this.repPack;
            this.gdcTypeOfPackageID.FieldName = "TypeOfPackageID";
            this.gdcTypeOfPackageID.Name = "gdcTypeOfPackageID";
            this.gdcTypeOfPackageID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gdcTypeOfPackageID.Visible = true;
            this.gdcTypeOfPackageID.VisibleIndex = 12;
            // 
            // repPack
            // 
            this.repPack.AutoHeight = false;
            this.repPack.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repPack.Name = "repPack";
            // 
            // gdcInPackage
            // 
            this.gdcInPackage.AppearanceCell.Options.UseTextOptions = true;
            this.gdcInPackage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gdcInPackage.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcInPackage.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcInPackage.AppearanceHeader.Options.UseFont = true;
            this.gdcInPackage.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcInPackage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcInPackage.Caption = "In Package";
            this.gdcInPackage.FieldName = "InPackage";
            this.gdcInPackage.Name = "gdcInPackage";
            this.gdcInPackage.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gdcInPackage.Visible = true;
            this.gdcInPackage.VisibleIndex = 13;
            // 
            // gdcInPackageUnitID
            // 
            this.gdcInPackageUnitID.AppearanceCell.Options.UseTextOptions = true;
            this.gdcInPackageUnitID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcInPackageUnitID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcInPackageUnitID.AppearanceHeader.Options.UseFont = true;
            this.gdcInPackageUnitID.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcInPackageUnitID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcInPackageUnitID.Caption = "In Package Unit";
            this.gdcInPackageUnitID.ColumnEdit = this.repUnit;
            this.gdcInPackageUnitID.FieldName = "InPackageUnitID";
            this.gdcInPackageUnitID.Name = "gdcInPackageUnitID";
            this.gdcInPackageUnitID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gdcInPackageUnitID.Visible = true;
            this.gdcInPackageUnitID.VisibleIndex = 14;
            // 
            // gdcProductConditionID
            // 
            this.gdcProductConditionID.AppearanceCell.Options.UseTextOptions = true;
            this.gdcProductConditionID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcProductConditionID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcProductConditionID.AppearanceHeader.Options.UseFont = true;
            this.gdcProductConditionID.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcProductConditionID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcProductConditionID.Caption = "Item Condition";
            this.gdcProductConditionID.ColumnEdit = this.repCondition;
            this.gdcProductConditionID.FieldName = "ProductConditionID";
            this.gdcProductConditionID.Name = "gdcProductConditionID";
            this.gdcProductConditionID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gdcProductConditionID.Visible = true;
            this.gdcProductConditionID.VisibleIndex = 15;
            // 
            // repCondition
            // 
            this.repCondition.AutoHeight = false;
            this.repCondition.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCondition.Name = "repCondition";
            // 
            // gdcPartName
            // 
            this.gdcPartName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPartName.AppearanceHeader.Options.UseFont = true;
            this.gdcPartName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPartName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPartName.Caption = "Part Name";
            this.gdcPartName.FieldName = "ProductLongName";
            this.gdcPartName.Name = "gdcPartName";
            this.gdcPartName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gdcPartName.Visible = true;
            this.gdcPartName.VisibleIndex = 8;
            // 
            // frmCRCS010_CollectionASN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 490);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmCRCS010_CollectionASN";
            this.Text = "CRCS010 : Receiving Plan List";
            this.Load += new System.EventHandler(this.frmCRCS010_CollectionASN_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtArrivalDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtArrivalDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtArrivalDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtArrivalDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSlipNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCondition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Control.OwnerControl ownerControl;
        private DevExpress.XtraEditors.TextEdit txtSlipNo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Control.WarehouseControl warehouseControl;
        private Control.SupplierControl supplierControl;
        private Control.TruckCompanyControl truckCompanyControl;
        private DevExpress.XtraEditors.DateEdit dtArrivalDateTo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dtArrivalDateFrom;
        private DevExpress.XtraGrid.Columns.GridColumn gdcStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gdcReceivingNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcArrivalDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPalletNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLotNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPalletNoRef;
        private DevExpress.XtraGrid.Columns.GridColumn gdcQty;
        private DevExpress.XtraGrid.Columns.GridColumn gdcQtyUnitID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repUnit;
        private DevExpress.XtraGrid.Columns.GridColumn gdcNetWeight;
        private DevExpress.XtraGrid.Columns.GridColumn gdcTypeOfPackageID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repPack;
        private DevExpress.XtraGrid.Columns.GridColumn gdcInPackage;
        private DevExpress.XtraGrid.Columns.GridColumn gdcInPackageUnitID;
        private DevExpress.XtraGrid.Columns.GridColumn gdcProductConditionID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repCondition;
        private DevExpress.XtraGrid.Columns.GridColumn gdcItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcInstallment;
        private Control.RequireField requireField1;
        private Control.RequireField requireField5;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSupplierCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSupplierLongName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPartName;
    }
}
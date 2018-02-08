namespace Rubix.Screen.Form.Operation.A_Order
{
    partial class frmASO050_PurchaseOrderConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmASO050_PurchaseOrderConfirm));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gdcStatusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcOwnerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcOwnerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcWarehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcWarehouseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSupplierCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPOIssueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcVat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcArrivalDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCollectDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.requireField1 = new Rubix.Control.RequireField();
            this.requireField5 = new Rubix.Control.RequireField();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtCustomerPONo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.customerControl = new Rubix.Control.CustomerControl();
            this.txtPONo = new DevExpress.XtraEditors.TextEdit();
            this.txtSONo = new DevExpress.XtraEditors.TextEdit();
            this.dtPOIssueDateTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.dtPOIssueDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.supplierControl = new Rubix.Control.SupplierControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerPONo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPONo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSONo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPOIssueDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPOIssueDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPOIssueDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPOIssueDateFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 196);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1140, 237);
            this.groupControl2.TabIndex = 8;
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
            this.repSelect});
            this.grdSearchResult.Size = new System.Drawing.Size(1136, 214);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcSelect,
            this.gdcStatusName,
            this.gdcPONo,
            this.gdcSONo,
            this.gdcOwnerCode,
            this.gdcOwnerName,
            this.gdcWarehouseCode,
            this.gdcWarehouseName,
            this.gdcSupplierCode,
            this.gdcSupplierName,
            this.gdcCustomerCode,
            this.gdcCustomerName,
            this.gdcPOIssueDate,
            this.gdcCurrency,
            this.gdcVat,
            this.gdcArrivalDate,
            this.gdcCollectDate,
            this.gdcRemark,
            this.gdcCreateDate,
            this.gdcCreateUser,
            this.gdcUpdateDate,
            this.gdcUpdateUser});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsView.AllowCellMerge = true;
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            this.gdvSearchResult.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gdvSearchResult_RowCellClick);
            this.gdvSearchResult.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.gdvSearchResult_CellMerge);
            // 
            // gdcSelect
            // 
            this.gdcSelect.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcSelect.AppearanceHeader.Options.UseFont = true;
            this.gdcSelect.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSelect.Caption = "Select";
            this.gdcSelect.ColumnEdit = this.repSelect;
            this.gdcSelect.FieldName = "Select";
            this.gdcSelect.Name = "gdcSelect";
            this.gdcSelect.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcSelect.Visible = true;
            this.gdcSelect.VisibleIndex = 0;
            // 
            // repSelect
            // 
            this.repSelect.AutoHeight = false;
            this.repSelect.Name = "repSelect";
            this.repSelect.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repSelect.ValueChecked = ((long)(1));
            this.repSelect.ValueUnchecked = ((long)(0));
            // 
            // gdcStatusName
            // 
            this.gdcStatusName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcStatusName.AppearanceHeader.Options.UseFont = true;
            this.gdcStatusName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcStatusName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcStatusName.Caption = "Status";
            this.gdcStatusName.FieldName = "StatusName";
            this.gdcStatusName.FieldNameSortGroup = "StatusName";
            this.gdcStatusName.Name = "gdcStatusName";
            this.gdcStatusName.OptionsColumn.AllowEdit = false;
            this.gdcStatusName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcStatusName.Visible = true;
            this.gdcStatusName.VisibleIndex = 1;
            // 
            // gdcPONo
            // 
            this.gdcPONo.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcPONo.AppearanceHeader.Options.UseFont = true;
            this.gdcPONo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPONo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPONo.Caption = "PO No.";
            this.gdcPONo.FieldName = "PONo";
            this.gdcPONo.FieldNameSortGroup = "PONo";
            this.gdcPONo.Name = "gdcPONo";
            this.gdcPONo.OptionsColumn.AllowEdit = false;
            this.gdcPONo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcPONo.Visible = true;
            this.gdcPONo.VisibleIndex = 2;
            // 
            // gdcSONo
            // 
            this.gdcSONo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcSONo.AppearanceHeader.Options.UseFont = true;
            this.gdcSONo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSONo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSONo.Caption = "SO No";
            this.gdcSONo.FieldName = "SONo";
            this.gdcSONo.Name = "gdcSONo";
            this.gdcSONo.OptionsColumn.AllowEdit = false;
            this.gdcSONo.Visible = true;
            this.gdcSONo.VisibleIndex = 3;
            // 
            // gdcOwnerCode
            // 
            this.gdcOwnerCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcOwnerCode.AppearanceHeader.Options.UseFont = true;
            this.gdcOwnerCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcOwnerCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcOwnerCode.Caption = "Owner Code";
            this.gdcOwnerCode.FieldName = "OwnerCode";
            this.gdcOwnerCode.FieldNameSortGroup = "OwnerCode";
            this.gdcOwnerCode.Name = "gdcOwnerCode";
            this.gdcOwnerCode.OptionsColumn.AllowEdit = false;
            this.gdcOwnerCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcOwnerCode.Visible = true;
            this.gdcOwnerCode.VisibleIndex = 4;
            // 
            // gdcOwnerName
            // 
            this.gdcOwnerName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcOwnerName.AppearanceHeader.Options.UseFont = true;
            this.gdcOwnerName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcOwnerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcOwnerName.Caption = "Owner Name";
            this.gdcOwnerName.FieldName = "OwnerName";
            this.gdcOwnerName.FieldNameSortGroup = "OwnerName";
            this.gdcOwnerName.Name = "gdcOwnerName";
            this.gdcOwnerName.OptionsColumn.AllowEdit = false;
            this.gdcOwnerName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcOwnerName.Visible = true;
            this.gdcOwnerName.VisibleIndex = 5;
            // 
            // gdcWarehouseCode
            // 
            this.gdcWarehouseCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcWarehouseCode.AppearanceHeader.Options.UseFont = true;
            this.gdcWarehouseCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcWarehouseCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcWarehouseCode.Caption = "Warehouse Code";
            this.gdcWarehouseCode.FieldName = "WarehouseCode";
            this.gdcWarehouseCode.FieldNameSortGroup = "WarehouseCode";
            this.gdcWarehouseCode.Name = "gdcWarehouseCode";
            this.gdcWarehouseCode.OptionsColumn.AllowEdit = false;
            this.gdcWarehouseCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcWarehouseCode.Visible = true;
            this.gdcWarehouseCode.VisibleIndex = 6;
            // 
            // gdcWarehouseName
            // 
            this.gdcWarehouseName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcWarehouseName.AppearanceHeader.Options.UseFont = true;
            this.gdcWarehouseName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcWarehouseName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcWarehouseName.Caption = "Warehouse Name";
            this.gdcWarehouseName.FieldName = "WarehouseName";
            this.gdcWarehouseName.FieldNameSortGroup = "WarehouseName";
            this.gdcWarehouseName.Name = "gdcWarehouseName";
            this.gdcWarehouseName.OptionsColumn.AllowEdit = false;
            this.gdcWarehouseName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcWarehouseName.Visible = true;
            this.gdcWarehouseName.VisibleIndex = 7;
            // 
            // gdcSupplierCode
            // 
            this.gdcSupplierCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcSupplierCode.AppearanceHeader.Options.UseFont = true;
            this.gdcSupplierCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSupplierCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSupplierCode.Caption = "Supplier Code";
            this.gdcSupplierCode.FieldName = "SupplierCode";
            this.gdcSupplierCode.FieldNameSortGroup = "SupplierCode";
            this.gdcSupplierCode.Name = "gdcSupplierCode";
            this.gdcSupplierCode.OptionsColumn.AllowEdit = false;
            this.gdcSupplierCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcSupplierCode.Visible = true;
            this.gdcSupplierCode.VisibleIndex = 8;
            // 
            // gdcSupplierName
            // 
            this.gdcSupplierName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcSupplierName.AppearanceHeader.Options.UseFont = true;
            this.gdcSupplierName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSupplierName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSupplierName.Caption = "Supplier Name";
            this.gdcSupplierName.FieldName = "SupplierName";
            this.gdcSupplierName.FieldNameSortGroup = "SupplierName";
            this.gdcSupplierName.Name = "gdcSupplierName";
            this.gdcSupplierName.OptionsColumn.AllowEdit = false;
            this.gdcSupplierName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcSupplierName.Visible = true;
            this.gdcSupplierName.VisibleIndex = 9;
            // 
            // gdcCustomerCode
            // 
            this.gdcCustomerCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcCustomerCode.AppearanceHeader.Options.UseFont = true;
            this.gdcCustomerCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCustomerCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCustomerCode.Caption = "Customer Code";
            this.gdcCustomerCode.FieldName = "CustomerCode";
            this.gdcCustomerCode.FieldNameSortGroup = "CustomerCode";
            this.gdcCustomerCode.Name = "gdcCustomerCode";
            this.gdcCustomerCode.OptionsColumn.AllowEdit = false;
            this.gdcCustomerCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcCustomerCode.Visible = true;
            this.gdcCustomerCode.VisibleIndex = 10;
            // 
            // gdcCustomerName
            // 
            this.gdcCustomerName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcCustomerName.AppearanceHeader.Options.UseFont = true;
            this.gdcCustomerName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCustomerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCustomerName.Caption = "Customer Name";
            this.gdcCustomerName.FieldName = "CustomerName";
            this.gdcCustomerName.FieldNameSortGroup = "CustomerName";
            this.gdcCustomerName.Name = "gdcCustomerName";
            this.gdcCustomerName.OptionsColumn.AllowEdit = false;
            this.gdcCustomerName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcCustomerName.Visible = true;
            this.gdcCustomerName.VisibleIndex = 11;
            // 
            // gdcPOIssueDate
            // 
            this.gdcPOIssueDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcPOIssueDate.AppearanceHeader.Options.UseFont = true;
            this.gdcPOIssueDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPOIssueDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPOIssueDate.Caption = "P/O Issue Date";
            this.gdcPOIssueDate.FieldName = "IssuedDate";
            this.gdcPOIssueDate.FieldNameSortGroup = "IssuedDate";
            this.gdcPOIssueDate.Name = "gdcPOIssueDate";
            this.gdcPOIssueDate.OptionsColumn.AllowEdit = false;
            this.gdcPOIssueDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcPOIssueDate.Visible = true;
            this.gdcPOIssueDate.VisibleIndex = 12;
            // 
            // gdcCurrency
            // 
            this.gdcCurrency.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcCurrency.AppearanceHeader.Options.UseFont = true;
            this.gdcCurrency.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCurrency.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCurrency.Caption = "Currency";
            this.gdcCurrency.FieldName = "CurrencyCode";
            this.gdcCurrency.FieldNameSortGroup = "CurrencyCode";
            this.gdcCurrency.Name = "gdcCurrency";
            this.gdcCurrency.OptionsColumn.AllowEdit = false;
            this.gdcCurrency.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcCurrency.Visible = true;
            this.gdcCurrency.VisibleIndex = 13;
            // 
            // gdcVat
            // 
            this.gdcVat.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcVat.AppearanceHeader.Options.UseFont = true;
            this.gdcVat.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcVat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcVat.Caption = "Vat";
            this.gdcVat.FieldName = "Vat";
            this.gdcVat.FieldNameSortGroup = "Vat";
            this.gdcVat.Name = "gdcVat";
            this.gdcVat.OptionsColumn.AllowEdit = false;
            this.gdcVat.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcVat.Visible = true;
            this.gdcVat.VisibleIndex = 14;
            // 
            // gdcArrivalDate
            // 
            this.gdcArrivalDate.Caption = "Arrival Date";
            this.gdcArrivalDate.FieldName = "ArrivalDate";
            this.gdcArrivalDate.FieldNameSortGroup = "ArrivalDate";
            this.gdcArrivalDate.Name = "gdcArrivalDate";
            this.gdcArrivalDate.OptionsColumn.AllowEdit = false;
            this.gdcArrivalDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcArrivalDate.Visible = true;
            this.gdcArrivalDate.VisibleIndex = 15;
            // 
            // gdcCollectDate
            // 
            this.gdcCollectDate.Caption = "Collect Date";
            this.gdcCollectDate.FieldName = "CollectDate";
            this.gdcCollectDate.FieldNameSortGroup = "CollectDate";
            this.gdcCollectDate.Name = "gdcCollectDate";
            this.gdcCollectDate.OptionsColumn.AllowEdit = false;
            this.gdcCollectDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcCollectDate.Visible = true;
            this.gdcCollectDate.VisibleIndex = 16;
            // 
            // gdcRemark
            // 
            this.gdcRemark.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcRemark.AppearanceHeader.Options.UseFont = true;
            this.gdcRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcRemark.Caption = "Remark";
            this.gdcRemark.FieldName = "Remark";
            this.gdcRemark.Name = "gdcRemark";
            this.gdcRemark.OptionsColumn.AllowEdit = false;
            this.gdcRemark.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcRemark.Visible = true;
            this.gdcRemark.VisibleIndex = 17;
            // 
            // gdcCreateDate
            // 
            this.gdcCreateDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcCreateDate.AppearanceHeader.Options.UseFont = true;
            this.gdcCreateDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCreateDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCreateDate.Caption = "Create Date";
            this.gdcCreateDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gdcCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcCreateDate.FieldName = "CreateDate";
            this.gdcCreateDate.FieldNameSortGroup = "CreateDate";
            this.gdcCreateDate.Name = "gdcCreateDate";
            this.gdcCreateDate.OptionsColumn.AllowEdit = false;
            this.gdcCreateDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcCreateDate.Visible = true;
            this.gdcCreateDate.VisibleIndex = 18;
            // 
            // gdcCreateUser
            // 
            this.gdcCreateUser.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcCreateUser.AppearanceHeader.Options.UseFont = true;
            this.gdcCreateUser.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCreateUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCreateUser.Caption = "Create User";
            this.gdcCreateUser.FieldName = "CreateUser";
            this.gdcCreateUser.FieldNameSortGroup = "CreateUser";
            this.gdcCreateUser.Name = "gdcCreateUser";
            this.gdcCreateUser.OptionsColumn.AllowEdit = false;
            this.gdcCreateUser.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcCreateUser.Visible = true;
            this.gdcCreateUser.VisibleIndex = 19;
            // 
            // gdcUpdateDate
            // 
            this.gdcUpdateDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcUpdateDate.AppearanceHeader.Options.UseFont = true;
            this.gdcUpdateDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcUpdateDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcUpdateDate.Caption = "Update Date";
            this.gdcUpdateDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gdcUpdateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcUpdateDate.FieldName = "UpdateDate";
            this.gdcUpdateDate.FieldNameSortGroup = "UpdateDate";
            this.gdcUpdateDate.Name = "gdcUpdateDate";
            this.gdcUpdateDate.OptionsColumn.AllowEdit = false;
            this.gdcUpdateDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcUpdateDate.Visible = true;
            this.gdcUpdateDate.VisibleIndex = 20;
            // 
            // gdcUpdateUser
            // 
            this.gdcUpdateUser.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcUpdateUser.AppearanceHeader.Options.UseFont = true;
            this.gdcUpdateUser.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcUpdateUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcUpdateUser.Caption = "Update User";
            this.gdcUpdateUser.FieldName = "UpdateUser";
            this.gdcUpdateUser.FieldNameSortGroup = "UpdateUser";
            this.gdcUpdateUser.Name = "gdcUpdateUser";
            this.gdcUpdateUser.OptionsColumn.AllowEdit = false;
            this.gdcUpdateUser.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcUpdateUser.Visible = true;
            this.gdcUpdateUser.VisibleIndex = 21;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.requireField1);
            this.groupControl1.Controls.Add(this.requireField5);
            this.groupControl1.Controls.Add(this.warehouseControl);
            this.groupControl1.Controls.Add(this.ownerControl);
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.txtCustomerPONo);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.customerControl);
            this.groupControl1.Controls.Add(this.txtPONo);
            this.groupControl1.Controls.Add(this.txtSONo);
            this.groupControl1.Controls.Add(this.dtPOIssueDateTo);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.dtPOIssueDateFrom);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.supplierControl);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 78);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1140, 118);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Search Criteria";
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(118, 52);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 190;
            // 
            // requireField5
            // 
            this.requireField5.Location = new System.Drawing.Point(118, 30);
            this.requireField5.Name = "requireField5";
            this.requireField5.Size = new System.Drawing.Size(10, 10);
            this.requireField5.TabIndex = 190;
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(54, 46);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(434, 21);
            this.warehouseControl.TabIndex = 2;
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(68, 24);
            this.ownerControl.Name = "ownerControl";
            this.ownerControl.ReadOnly = false;
            this.ownerControl.RequireField = false;
            this.ownerControl.Size = new System.Drawing.Size(420, 21);
            this.ownerControl.TabIndex = 1;
            this.ownerControl.EditValueChanged += new System.EventHandler(this.ownerControl_EditValueChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(1058, 88);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 25;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(979, 88);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 24;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCustomerPONo
            // 
            this.txtCustomerPONo.Location = new System.Drawing.Point(662, 68);
            this.txtCustomerPONo.MenuManager = this.ribbonControl1;
            this.txtCustomerPONo.Name = "txtCustomerPONo";
            this.txtCustomerPONo.Size = new System.Drawing.Size(218, 20);
            this.txtCustomerPONo.TabIndex = 7;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.Location = new System.Drawing.Point(540, 70);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(112, 17);
            this.labelControl7.TabIndex = 22;
            this.labelControl7.Text = "Customer P/O No.";
            // 
            // customerControl
            // 
            this.customerControl.ErrorText = "Customer Control is Require Field";
            this.customerControl.Location = new System.Drawing.Point(66, 90);
            this.customerControl.Name = "customerControl";
            this.customerControl.OwnerID = null;
            this.customerControl.ReadOnly = false;
            this.customerControl.RequireField = false;
            this.customerControl.Size = new System.Drawing.Size(422, 21);
            this.customerControl.TabIndex = 4;
            // 
            // txtPONo
            // 
            this.txtPONo.Location = new System.Drawing.Point(662, 46);
            this.txtPONo.MenuManager = this.ribbonControl1;
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.Size = new System.Drawing.Size(218, 20);
            this.txtPONo.TabIndex = 6;
            // 
            // txtSONo
            // 
            this.txtSONo.Location = new System.Drawing.Point(662, 24);
            this.txtSONo.MenuManager = this.ribbonControl1;
            this.txtSONo.Name = "txtSONo";
            this.txtSONo.Size = new System.Drawing.Size(218, 20);
            this.txtSONo.TabIndex = 5;
            // 
            // dtPOIssueDateTo
            // 
            this.dtPOIssueDateTo.EditValue = null;
            this.dtPOIssueDateTo.Location = new System.Drawing.Point(787, 89);
            this.dtPOIssueDateTo.MenuManager = this.ribbonControl1;
            this.dtPOIssueDateTo.Name = "dtPOIssueDateTo";
            this.dtPOIssueDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtPOIssueDateTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtPOIssueDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtPOIssueDateTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtPOIssueDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtPOIssueDateTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtPOIssueDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtPOIssueDateTo.Size = new System.Drawing.Size(94, 20);
            this.dtPOIssueDateTo.TabIndex = 9;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(757, 92);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(27, 17);
            this.labelControl6.TabIndex = 16;
            this.labelControl6.Text = "To";
            // 
            // dtPOIssueDateFrom
            // 
            this.dtPOIssueDateFrom.EditValue = null;
            this.dtPOIssueDateFrom.Location = new System.Drawing.Point(662, 90);
            this.dtPOIssueDateFrom.MenuManager = this.ribbonControl1;
            this.dtPOIssueDateFrom.Name = "dtPOIssueDateFrom";
            this.dtPOIssueDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtPOIssueDateFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtPOIssueDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtPOIssueDateFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtPOIssueDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtPOIssueDateFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtPOIssueDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtPOIssueDateFrom.Size = new System.Drawing.Size(92, 20);
            this.dtPOIssueDateFrom.TabIndex = 8;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(542, 48);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(110, 17);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "P/O No.";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(538, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(114, 17);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "S/O No.";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(531, 92);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(120, 17);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "P/O Issue Date";
            // 
            // supplierControl
            // 
            this.supplierControl.ErrorText = "Supplier is Require Field";
            this.supplierControl.Location = new System.Drawing.Point(75, 67);
            this.supplierControl.Name = "supplierControl";
            this.supplierControl.ReadOnly = false;
            this.supplierControl.RequireField = false;
            this.supplierControl.Size = new System.Drawing.Size(413, 23);
            this.supplierControl.TabIndex = 3;
            // 
            // frmASO050_PurchaseOrderConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 433);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmASO050_PurchaseOrderConfirm";
            this.Text = "ASO050 : Purchase Order Confirm";
            this.Load += new System.EventHandler(this.frmASO050_PurchaseOrderConfirm_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerPONo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPONo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSONo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPOIssueDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPOIssueDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPOIssueDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPOIssueDateFrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraGrid.Columns.GridColumn gdcStatusName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPONo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWarehouseCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWarehouseName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSupplierCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSupplierName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPOIssueDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn gdcVat;
        private DevExpress.XtraGrid.Columns.GridColumn gdcArrivalDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCollectDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateUser;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Control.WarehouseControl warehouseControl;
        private Control.OwnerControl ownerControl;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TextEdit txtCustomerPONo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private Control.CustomerControl customerControl;
        private DevExpress.XtraEditors.TextEdit txtPONo;
        private DevExpress.XtraEditors.TextEdit txtSONo;
        private DevExpress.XtraEditors.DateEdit dtPOIssueDateTo;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.DateEdit dtPOIssueDateFrom;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Control.SupplierControl supplierControl;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repSelect;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSONo;
        private Control.RequireField requireField1;
        private Control.RequireField requireField5;
    }
}
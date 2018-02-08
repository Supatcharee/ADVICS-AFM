namespace Rubix.Screen.Form.Operation.E_Stocktaking
{
    partial class frmESTS010_CorrectInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmESTS010_CorrectInventory));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnUnselectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gdcOwnerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcOwnerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcWarehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcWarehouseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcProductCondition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLocationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLocationName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcInventory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcExpiredDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.requireField2 = new Rubix.Control.RequireField();
            this.requireField1 = new Rubix.Control.RequireField();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.txtPalletNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.itemControl = new Rubix.Control.ItemControl();
            this.txtSlipNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPalletNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSlipNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Size = new System.Drawing.Size(891, 47);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.grdSearchResult);
            this.groupControl1.Controls.Add(this.btnPrint);
            this.groupControl1.Controls.Add(this.btnUnselectAll);
            this.groupControl1.Controls.Add(this.btnSelectAll);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 173);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(891, 346);
            this.groupControl1.TabIndex = 29;
            this.groupControl1.Text = "Search Result";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(743, 318);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(139, 23);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "Print Receiving Label";
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUnselectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnUnselectAll.Image")));
            this.btnUnselectAll.Location = new System.Drawing.Point(142, 318);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(120, 23);
            this.btnUnselectAll.TabIndex = 9;
            this.btnUnselectAll.Text = "Unselect All";
            this.btnUnselectAll.Visible = false;
            this.btnUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.Location = new System.Drawing.Point(7, 318);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(120, 23);
            this.btnSelectAll.TabIndex = 8;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.Visible = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSearchResult.Location = new System.Drawing.Point(3, 24);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repSelect});
            this.grdSearchResult.Size = new System.Drawing.Size(884, 317);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcSelect,
            this.gdcOwnerCode,
            this.gdcOwnerName,
            this.gdcWarehouseCode,
            this.gdcWarehouseName,
            this.gdcProductCode,
            this.gdcProductName,
            this.gdcProductCondition,
            this.gdcLotNo,
            this.gdcLocationCode,
            this.gdcLocationName,
            this.gdcInventory,
            this.gdcUnitName,
            this.gdcExpiredDate});
            this.gdvSearchResult.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
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
            this.gdcSelect.Visible = true;
            this.gdcSelect.VisibleIndex = 0;
            // 
            // repSelect
            // 
            this.repSelect.AutoHeight = false;
            this.repSelect.Name = "repSelect";
            // 
            // gdcOwnerCode
            // 
            this.gdcOwnerCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcOwnerCode.AppearanceHeader.Options.UseFont = true;
            this.gdcOwnerCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcOwnerCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcOwnerCode.Caption = "Owner Code";
            this.gdcOwnerCode.FieldName = "OwnerCode";
            this.gdcOwnerCode.FieldNameSortGroup = "OwnerCode";
            this.gdcOwnerCode.Name = "gdcOwnerCode";
            this.gdcOwnerCode.OptionsColumn.AllowEdit = false;
            this.gdcOwnerCode.Visible = true;
            this.gdcOwnerCode.VisibleIndex = 1;
            // 
            // gdcOwnerName
            // 
            this.gdcOwnerName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcOwnerName.AppearanceHeader.Options.UseFont = true;
            this.gdcOwnerName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcOwnerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcOwnerName.Caption = "Owner Name";
            this.gdcOwnerName.FieldName = "OwnerName";
            this.gdcOwnerName.FieldNameSortGroup = "OwnerName";
            this.gdcOwnerName.Name = "gdcOwnerName";
            this.gdcOwnerName.OptionsColumn.AllowEdit = false;
            this.gdcOwnerName.Visible = true;
            this.gdcOwnerName.VisibleIndex = 2;
            // 
            // gdcWarehouseCode
            // 
            this.gdcWarehouseCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcWarehouseCode.AppearanceHeader.Options.UseFont = true;
            this.gdcWarehouseCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcWarehouseCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcWarehouseCode.Caption = "Warehouse Code";
            this.gdcWarehouseCode.FieldName = "WarehouseCode";
            this.gdcWarehouseCode.FieldNameSortGroup = "WarehouseCode";
            this.gdcWarehouseCode.Name = "gdcWarehouseCode";
            this.gdcWarehouseCode.OptionsColumn.AllowEdit = false;
            this.gdcWarehouseCode.Visible = true;
            this.gdcWarehouseCode.VisibleIndex = 3;
            // 
            // gdcWarehouseName
            // 
            this.gdcWarehouseName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcWarehouseName.AppearanceHeader.Options.UseFont = true;
            this.gdcWarehouseName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcWarehouseName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcWarehouseName.Caption = "Warehouse Name";
            this.gdcWarehouseName.FieldName = "WarehouseName";
            this.gdcWarehouseName.FieldNameSortGroup = "WarehouseName";
            this.gdcWarehouseName.Name = "gdcWarehouseName";
            this.gdcWarehouseName.OptionsColumn.AllowEdit = false;
            this.gdcWarehouseName.Visible = true;
            this.gdcWarehouseName.VisibleIndex = 4;
            // 
            // gdcProductCode
            // 
            this.gdcProductCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcProductCode.AppearanceHeader.Options.UseFont = true;
            this.gdcProductCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcProductCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcProductCode.Caption = "Product Code";
            this.gdcProductCode.FieldName = "ProductCode";
            this.gdcProductCode.FieldNameSortGroup = "ProductCode";
            this.gdcProductCode.Name = "gdcProductCode";
            this.gdcProductCode.OptionsColumn.AllowEdit = false;
            this.gdcProductCode.Visible = true;
            this.gdcProductCode.VisibleIndex = 5;
            // 
            // gdcProductName
            // 
            this.gdcProductName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcProductName.AppearanceHeader.Options.UseFont = true;
            this.gdcProductName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcProductName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcProductName.Caption = "Product Name";
            this.gdcProductName.FieldName = "ProductName";
            this.gdcProductName.FieldNameSortGroup = "ProductName";
            this.gdcProductName.Name = "gdcProductName";
            this.gdcProductName.OptionsColumn.AllowEdit = false;
            this.gdcProductName.Visible = true;
            this.gdcProductName.VisibleIndex = 6;
            // 
            // gdcProductCondition
            // 
            this.gdcProductCondition.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcProductCondition.AppearanceHeader.Options.UseFont = true;
            this.gdcProductCondition.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcProductCondition.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcProductCondition.Caption = "Product Condition";
            this.gdcProductCondition.FieldName = "ProductConditionName";
            this.gdcProductCondition.FieldNameSortGroup = "ProductConditionName";
            this.gdcProductCondition.Name = "gdcProductCondition";
            this.gdcProductCondition.OptionsColumn.AllowEdit = false;
            this.gdcProductCondition.Visible = true;
            this.gdcProductCondition.VisibleIndex = 7;
            // 
            // gdcLotNo
            // 
            this.gdcLotNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcLotNo.AppearanceHeader.Options.UseFont = true;
            this.gdcLotNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcLotNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcLotNo.Caption = "Lot No.";
            this.gdcLotNo.FieldName = "LotNo";
            this.gdcLotNo.FieldNameSortGroup = "LotNo";
            this.gdcLotNo.Name = "gdcLotNo";
            this.gdcLotNo.OptionsColumn.AllowEdit = false;
            // 
            // gdcLocationCode
            // 
            this.gdcLocationCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcLocationCode.AppearanceHeader.Options.UseFont = true;
            this.gdcLocationCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcLocationCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcLocationCode.Caption = "Location Code";
            this.gdcLocationCode.FieldName = "LocationCode";
            this.gdcLocationCode.FieldNameSortGroup = "LocationCode";
            this.gdcLocationCode.Name = "gdcLocationCode";
            this.gdcLocationCode.OptionsColumn.AllowEdit = false;
            this.gdcLocationCode.Visible = true;
            this.gdcLocationCode.VisibleIndex = 8;
            // 
            // gdcLocationName
            // 
            this.gdcLocationName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcLocationName.AppearanceHeader.Options.UseFont = true;
            this.gdcLocationName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcLocationName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcLocationName.Caption = "Location Name";
            this.gdcLocationName.FieldName = "LocationName";
            this.gdcLocationName.FieldNameSortGroup = "LocationName";
            this.gdcLocationName.Name = "gdcLocationName";
            this.gdcLocationName.OptionsColumn.AllowEdit = false;
            this.gdcLocationName.Visible = true;
            this.gdcLocationName.VisibleIndex = 9;
            // 
            // gdcInventory
            // 
            this.gdcInventory.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcInventory.AppearanceHeader.Options.UseFont = true;
            this.gdcInventory.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcInventory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcInventory.Caption = "Inventory";
            this.gdcInventory.DisplayFormat.FormatString = "#,##0.00";
            this.gdcInventory.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcInventory.FieldName = "InventoryQtyL3";
            this.gdcInventory.FieldNameSortGroup = "InventoryQtyL3";
            this.gdcInventory.Name = "gdcInventory";
            this.gdcInventory.OptionsColumn.AllowEdit = false;
            this.gdcInventory.Visible = true;
            this.gdcInventory.VisibleIndex = 10;
            // 
            // gdcUnitName
            // 
            this.gdcUnitName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcUnitName.AppearanceHeader.Options.UseFont = true;
            this.gdcUnitName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcUnitName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcUnitName.Caption = "Unit";
            this.gdcUnitName.FieldName = "UnitName";
            this.gdcUnitName.FieldNameSortGroup = "UnitName";
            this.gdcUnitName.Name = "gdcUnitName";
            this.gdcUnitName.OptionsColumn.AllowEdit = false;
            this.gdcUnitName.Visible = true;
            this.gdcUnitName.VisibleIndex = 11;
            // 
            // gdcExpiredDate
            // 
            this.gdcExpiredDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcExpiredDate.AppearanceHeader.Options.UseFont = true;
            this.gdcExpiredDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcExpiredDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcExpiredDate.Caption = "Expired Date";
            this.gdcExpiredDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gdcExpiredDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcExpiredDate.FieldName = "ExpiredDate";
            this.gdcExpiredDate.FieldNameSortGroup = "ExpiredDate";
            this.gdcExpiredDate.Name = "gdcExpiredDate";
            this.gdcExpiredDate.OptionsColumn.AllowEdit = false;
            this.gdcExpiredDate.Visible = true;
            this.gdcExpiredDate.VisibleIndex = 12;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.requireField2);
            this.groupControl3.Controls.Add(this.requireField1);
            this.groupControl3.Controls.Add(this.warehouseControl);
            this.groupControl3.Controls.Add(this.itemControl);
            this.groupControl3.Controls.Add(this.txtSlipNo);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.ownerControl);
            this.groupControl3.Controls.Add(this.btnClear);
            this.groupControl3.Controls.Add(this.btnSearch);
            this.groupControl3.Controls.Add(this.txtPalletNo);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl3.Location = new System.Drawing.Point(0, 78);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(891, 95);
            this.groupControl3.TabIndex = 39;
            this.groupControl3.Text = "Search Criteria";
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(145, 29);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 194;
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(145, 52);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 193;
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(82, 46);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(463, 21);
            this.warehouseControl.TabIndex = 2;
            // 
            // txtPalletNo
            // 
            this.txtPalletNo.Location = new System.Drawing.Point(717, 46);
            this.txtPalletNo.MenuManager = this.ribbonControl1;
            this.txtPalletNo.Name = "txtPalletNo";
            this.txtPalletNo.Properties.MaxLength = 50;
            this.txtPalletNo.Size = new System.Drawing.Size(169, 20);
            this.txtPalletNo.TabIndex = 5;
            this.txtPalletNo.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(589, 48);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(117, 16);
            this.labelControl3.TabIndex = 122;
            this.labelControl3.Text = "Pallet No.";
            this.labelControl3.Visible = false;
            // 
            // itemControl
            // 
            this.itemControl.ErrorText = "Item Control is Require Field";
            this.itemControl.Location = new System.Drawing.Point(115, 68);
            this.itemControl.Name = "itemControl";
            this.itemControl.RequireField = false;
            this.itemControl.Size = new System.Drawing.Size(430, 22);
            this.itemControl.TabIndex = 3;
            // 
            // txtSlipNo
            // 
            this.txtSlipNo.Location = new System.Drawing.Point(717, 25);
            this.txtSlipNo.MenuManager = this.ribbonControl1;
            this.txtSlipNo.Name = "txtSlipNo";
            this.txtSlipNo.Properties.MaxLength = 50;
            this.txtSlipNo.Size = new System.Drawing.Size(169, 20);
            this.txtSlipNo.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(566, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(138, 16);
            this.labelControl1.TabIndex = 117;
            this.labelControl1.Text = "Receiving No.";
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(96, 24);
            this.ownerControl.Name = "ownerControl";
            this.ownerControl.ReadOnly = false;
            this.ownerControl.RequireField = false;
            this.ownerControl.Size = new System.Drawing.Size(449, 21);
            this.ownerControl.TabIndex = 1;
            this.ownerControl.EditValueChanged += new System.EventHandler(this.ownerControl_EditValueChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(811, 68);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(730, 68);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmESTS010_CorrectInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 519);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl3);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmESTS010_CorrectInventory";
            this.Text = "ESTS010 : Inventory Adjustment";
            this.Load += new System.EventHandler(this.frmESTS010_CorrectInventory_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl3, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPalletNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSlipNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private Rubix.Control.ItemControl itemControl;
        private DevExpress.XtraEditors.TextEdit txtSlipNo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Rubix.Control.OwnerControl ownerControl;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TextEdit txtPalletNo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnUnselectAll;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private Control.RequireField requireField2;
        private Control.RequireField requireField1;
        private Control.WarehouseControl warehouseControl;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSelect;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWarehouseCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWarehouseName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcProductName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcProductCondition;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLotNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLocationCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLocationName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcInventory;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcExpiredDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repSelect;

    }
}
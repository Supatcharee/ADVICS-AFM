namespace Rubix.Screen.Form.Operation.B_ReceivingEntry
{
    partial class frmBRES010_ReceivingEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBRES010_ReceivingEntry));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.requireField1 = new Rubix.Control.RequireField();
            this.requireField5 = new Rubix.Control.RequireField();
            this.txtInvoiceNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deArrivalDateTo = new DevExpress.XtraEditors.DateEdit();
            this.deArrivalDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.supplierControl = new Rubix.Control.SupplierControl();
            this.itemControl = new Rubix.Control.ItemControl();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.chkIncomplete = new DevExpress.XtraEditors.CheckEdit();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.txtReceivingNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcStatusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcReceivingNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcInstallment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcOwnerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcOwnerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcWarehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcWarehouseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSupplierCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcArrivalDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcNumberOfPallet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCancelSlipFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deArrivalDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deArrivalDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deArrivalDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deArrivalDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncomplete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceivingNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Location = new System.Drawing.Point(0, 149);
            this.ribbonControl1.Size = new System.Drawing.Size(1086, 47);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.requireField1);
            this.groupControl1.Controls.Add(this.requireField5);
            this.groupControl1.Controls.Add(this.txtInvoiceNo);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.warehouseControl);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.deArrivalDateTo);
            this.groupControl1.Controls.Add(this.deArrivalDateFrom);
            this.groupControl1.Controls.Add(this.supplierControl);
            this.groupControl1.Controls.Add(this.itemControl);
            this.groupControl1.Controls.Add(this.chkAll);
            this.groupControl1.Controls.Add(this.chkIncomplete);
            this.groupControl1.Controls.Add(this.ownerControl);
            this.groupControl1.Controls.Add(this.txtReceivingNo);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 31);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1086, 118);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Search Criteria";
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(114, 53);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 190;
            // 
            // requireField5
            // 
            this.requireField5.Location = new System.Drawing.Point(114, 30);
            this.requireField5.Name = "requireField5";
            this.requireField5.Size = new System.Drawing.Size(10, 10);
            this.requireField5.TabIndex = 189;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(658, 43);
            this.txtInvoiceNo.MenuManager = this.ribbonControl1;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(123, 20);
            this.txtInvoiceNo.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(533, 47);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(113, 13);
            this.labelControl4.TabIndex = 19;
            this.labelControl4.Text = "Invoice No.";
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Distribution Center Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(51, 47);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(464, 21);
            this.warehouseControl.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(787, 68);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 13);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "To";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(548, 69);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(98, 13);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "Arrival Date";
            // 
            // deArrivalDateTo
            // 
            this.deArrivalDateTo.EditValue = null;
            this.deArrivalDateTo.Location = new System.Drawing.Point(805, 65);
            this.deArrivalDateTo.MenuManager = this.ribbonControl1;
            this.deArrivalDateTo.Name = "deArrivalDateTo";
            this.deArrivalDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deArrivalDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deArrivalDateTo.Size = new System.Drawing.Size(123, 20);
            this.deArrivalDateTo.TabIndex = 8;
            // 
            // deArrivalDateFrom
            // 
            this.deArrivalDateFrom.EditValue = null;
            this.deArrivalDateFrom.Location = new System.Drawing.Point(658, 65);
            this.deArrivalDateFrom.MenuManager = this.ribbonControl1;
            this.deArrivalDateFrom.Name = "deArrivalDateFrom";
            this.deArrivalDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deArrivalDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deArrivalDateFrom.Size = new System.Drawing.Size(123, 20);
            this.deArrivalDateFrom.TabIndex = 7;
            // 
            // supplierControl
            // 
            this.supplierControl.ErrorText = "Supplier is Require Field";
            this.supplierControl.Location = new System.Drawing.Point(72, 69);
            this.supplierControl.Name = "supplierControl";
            this.supplierControl.ReadOnly = false;
            this.supplierControl.RequireField = false;
            this.supplierControl.Size = new System.Drawing.Size(442, 23);
            this.supplierControl.TabIndex = 3;
            // 
            // itemControl
            // 
            this.itemControl.ErrorText = "Item Control is Require Field";
            this.itemControl.Location = new System.Drawing.Point(84, 93);
            this.itemControl.Name = "itemControl";
            this.itemControl.RequireField = false;
            this.itemControl.Size = new System.Drawing.Size(430, 22);
            this.itemControl.TabIndex = 4;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(785, 91);
            this.chkAll.MenuManager = this.ribbonControl1;
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "All Status";
            this.chkAll.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkAll.Properties.RadioGroupIndex = 0;
            this.chkAll.Size = new System.Drawing.Size(94, 19);
            this.chkAll.TabIndex = 10;
            this.chkAll.TabStop = false;
            // 
            // chkIncomplete
            // 
            this.chkIncomplete.EditValue = true;
            this.chkIncomplete.Location = new System.Drawing.Point(655, 91);
            this.chkIncomplete.MenuManager = this.ribbonControl1;
            this.chkIncomplete.Name = "chkIncomplete";
            this.chkIncomplete.Properties.Caption = "Incomplete";
            this.chkIncomplete.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkIncomplete.Properties.RadioGroupIndex = 0;
            this.chkIncomplete.Size = new System.Drawing.Size(128, 19);
            this.chkIncomplete.TabIndex = 9;
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(65, 24);
            this.ownerControl.Name = "ownerControl";
            this.ownerControl.ReadOnly = false;
            this.ownerControl.RequireField = false;
            this.ownerControl.Size = new System.Drawing.Size(449, 21);
            this.ownerControl.TabIndex = 1;
            this.ownerControl.EditValueChanged += new System.EventHandler(this.ownerControl_EditValueChanged);
            // 
            // txtReceivingNo
            // 
            this.txtReceivingNo.Location = new System.Drawing.Point(658, 21);
            this.txtReceivingNo.MenuManager = this.ribbonControl1;
            this.txtReceivingNo.Name = "txtReceivingNo";
            this.txtReceivingNo.Size = new System.Drawing.Size(123, 20);
            this.txtReceivingNo.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(537, 24);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(109, 15);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Receiving No.";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(1005, 89);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(924, 89);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 149);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1086, 372);
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
            this.grdSearchResult.Size = new System.Drawing.Size(1082, 349);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcStatusName,
            this.gdcReceivingNo,
            this.gdcInstallment,
            this.gdcOwnerCode,
            this.gdcOwnerName,
            this.gdcWarehouseCode,
            this.gdcWarehouseName,
            this.gdcSupplierCode,
            this.gdcSupplierName,
            this.gdcArrivalDate,
            this.gdcNumberOfPallet,
            this.gdcCancelSlipFlag,
            this.gdcRemark,
            this.gdcCreateDate,
            this.gdcCreateUser,
            this.gdcUpdateDate,
            this.gdcUpdateUser});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            // 
            // gdcStatusName
            // 
            this.gdcStatusName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcStatusName.AppearanceHeader.Options.UseFont = true;
            this.gdcStatusName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcStatusName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcStatusName.Caption = "Status Name";
            this.gdcStatusName.FieldName = "StatusName";
            this.gdcStatusName.FieldNameSortGroup = "StatusName";
            this.gdcStatusName.Name = "gdcStatusName";
            this.gdcStatusName.Visible = true;
            this.gdcStatusName.VisibleIndex = 0;
            // 
            // gdcReceivingNo
            // 
            this.gdcReceivingNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcReceivingNo.AppearanceHeader.Options.UseFont = true;
            this.gdcReceivingNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcReceivingNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcReceivingNo.Caption = "Receiving No.";
            this.gdcReceivingNo.FieldName = "ReceivingNo";
            this.gdcReceivingNo.FieldNameSortGroup = "ReceivingNo";
            this.gdcReceivingNo.Name = "gdcReceivingNo";
            this.gdcReceivingNo.Visible = true;
            this.gdcReceivingNo.VisibleIndex = 1;
            // 
            // gdcInstallment
            // 
            this.gdcInstallment.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcInstallment.AppearanceHeader.Options.UseFont = true;
            this.gdcInstallment.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcInstallment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcInstallment.Caption = "Installment";
            this.gdcInstallment.FieldName = "Installment";
            this.gdcInstallment.FieldNameSortGroup = "Installment";
            this.gdcInstallment.Name = "gdcInstallment";
            this.gdcInstallment.Visible = true;
            this.gdcInstallment.VisibleIndex = 2;
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
            this.gdcOwnerCode.Visible = true;
            this.gdcOwnerCode.VisibleIndex = 3;
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
            this.gdcOwnerName.Visible = true;
            this.gdcOwnerName.VisibleIndex = 4;
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
            this.gdcWarehouseCode.Visible = true;
            this.gdcWarehouseCode.VisibleIndex = 5;
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
            this.gdcWarehouseName.Visible = true;
            this.gdcWarehouseName.VisibleIndex = 6;
            // 
            // gdcSupplierCode
            // 
            this.gdcSupplierCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcSupplierCode.AppearanceHeader.Options.UseFont = true;
            this.gdcSupplierCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSupplierCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSupplierCode.Caption = "Supplier Code";
            this.gdcSupplierCode.FieldName = "SupplierCode";
            this.gdcSupplierCode.FieldNameSortGroup = "SupplierCode";
            this.gdcSupplierCode.Name = "gdcSupplierCode";
            this.gdcSupplierCode.Visible = true;
            this.gdcSupplierCode.VisibleIndex = 7;
            // 
            // gdcSupplierName
            // 
            this.gdcSupplierName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcSupplierName.AppearanceHeader.Options.UseFont = true;
            this.gdcSupplierName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSupplierName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSupplierName.Caption = "Supplier Name";
            this.gdcSupplierName.FieldName = "SupplierName";
            this.gdcSupplierName.FieldNameSortGroup = "SupplierName";
            this.gdcSupplierName.Name = "gdcSupplierName";
            this.gdcSupplierName.Visible = true;
            this.gdcSupplierName.VisibleIndex = 8;
            // 
            // gdcArrivalDate
            // 
            this.gdcArrivalDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcArrivalDate.AppearanceHeader.Options.UseFont = true;
            this.gdcArrivalDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcArrivalDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcArrivalDate.Caption = "Arrival Date";
            this.gdcArrivalDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.gdcArrivalDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcArrivalDate.FieldName = "ArrivalDate";
            this.gdcArrivalDate.FieldNameSortGroup = "ArrivalDate";
            this.gdcArrivalDate.Name = "gdcArrivalDate";
            this.gdcArrivalDate.Visible = true;
            this.gdcArrivalDate.VisibleIndex = 9;
            // 
            // gdcNumberOfPallet
            // 
            this.gdcNumberOfPallet.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcNumberOfPallet.AppearanceHeader.Options.UseFont = true;
            this.gdcNumberOfPallet.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcNumberOfPallet.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcNumberOfPallet.Caption = "Number Of Pallet";
            this.gdcNumberOfPallet.FieldName = "NumberOfPallet";
            this.gdcNumberOfPallet.FieldNameSortGroup = "NumberOfPallet";
            this.gdcNumberOfPallet.Name = "gdcNumberOfPallet";
            // 
            // gdcCancelSlipFlag
            // 
            this.gdcCancelSlipFlag.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcCancelSlipFlag.AppearanceHeader.Options.UseFont = true;
            this.gdcCancelSlipFlag.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCancelSlipFlag.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCancelSlipFlag.Caption = "Cancel Slip Flag";
            this.gdcCancelSlipFlag.FieldName = "CancelSlipFlag";
            this.gdcCancelSlipFlag.FieldNameSortGroup = "CancelSlipFlag";
            this.gdcCancelSlipFlag.Name = "gdcCancelSlipFlag";
            this.gdcCancelSlipFlag.Visible = true;
            this.gdcCancelSlipFlag.VisibleIndex = 10;
            // 
            // gdcRemark
            // 
            this.gdcRemark.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcRemark.AppearanceHeader.Options.UseFont = true;
            this.gdcRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcRemark.Caption = "Remark";
            this.gdcRemark.FieldName = "Remark";
            this.gdcRemark.FieldNameSortGroup = "Remark";
            this.gdcRemark.Name = "gdcRemark";
            this.gdcRemark.Visible = true;
            this.gdcRemark.VisibleIndex = 11;
            // 
            // gdcCreateDate
            // 
            this.gdcCreateDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcCreateDate.AppearanceHeader.Options.UseFont = true;
            this.gdcCreateDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCreateDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCreateDate.Caption = "Create Date";
            this.gdcCreateDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gdcCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcCreateDate.FieldName = "CreateDate";
            this.gdcCreateDate.FieldNameSortGroup = "CreateDate";
            this.gdcCreateDate.Name = "gdcCreateDate";
            this.gdcCreateDate.Visible = true;
            this.gdcCreateDate.VisibleIndex = 12;
            // 
            // gdcCreateUser
            // 
            this.gdcCreateUser.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcCreateUser.AppearanceHeader.Options.UseFont = true;
            this.gdcCreateUser.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCreateUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCreateUser.Caption = "Create User";
            this.gdcCreateUser.FieldName = "CreateUser";
            this.gdcCreateUser.FieldNameSortGroup = "CreateUser";
            this.gdcCreateUser.Name = "gdcCreateUser";
            this.gdcCreateUser.Visible = true;
            this.gdcCreateUser.VisibleIndex = 13;
            // 
            // gdcUpdateDate
            // 
            this.gdcUpdateDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcUpdateDate.AppearanceHeader.Options.UseFont = true;
            this.gdcUpdateDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcUpdateDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcUpdateDate.Caption = "Update Date";
            this.gdcUpdateDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gdcUpdateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcUpdateDate.FieldName = "UpdateDate";
            this.gdcUpdateDate.FieldNameSortGroup = "UpdateDate";
            this.gdcUpdateDate.Name = "gdcUpdateDate";
            this.gdcUpdateDate.Visible = true;
            this.gdcUpdateDate.VisibleIndex = 14;
            // 
            // gdcUpdateUser
            // 
            this.gdcUpdateUser.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcUpdateUser.AppearanceHeader.Options.UseFont = true;
            this.gdcUpdateUser.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcUpdateUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcUpdateUser.Caption = "Update User";
            this.gdcUpdateUser.FieldName = "UpdateUser";
            this.gdcUpdateUser.FieldNameSortGroup = "UpdateUser";
            this.gdcUpdateUser.Name = "gdcUpdateUser";
            this.gdcUpdateUser.Visible = true;
            this.gdcUpdateUser.VisibleIndex = 15;
            // 
            // frmBRES010_ReceivingEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 521);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmBRES010_ReceivingEntry";
            this.Text = "BRES010 : Receiving Plan Preparation";
            this.Load += new System.EventHandler(this.frmBRES010_ReceivingEntry_Load);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deArrivalDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deArrivalDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deArrivalDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deArrivalDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncomplete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceivingNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraEditors.TextEdit txtReceivingNo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private Control.OwnerControl ownerControl;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraEditors.CheckEdit chkIncomplete;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit deArrivalDateTo;
        private DevExpress.XtraEditors.DateEdit deArrivalDateFrom;
        private Control.SupplierControl supplierControl;
        private Control.ItemControl itemControl;
        private Control.WarehouseControl warehouseControl;
        private DevExpress.XtraEditors.TextEdit txtInvoiceNo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenMgr;
        private DevExpress.XtraGrid.Columns.GridColumn gdcStatusName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcReceivingNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcInstallment;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWarehouseCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWarehouseName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSupplierCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSupplierName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcArrivalDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcNumberOfPallet;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCancelSlipFlag;
        private DevExpress.XtraGrid.Columns.GridColumn gdcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateUser;
        private Control.RequireField requireField1;
        private Control.RequireField requireField5;
    }
}
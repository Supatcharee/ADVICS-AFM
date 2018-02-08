namespace Rubix.Screen.Form.Operation.A_Order
{
    partial class frmASO010_SaleOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmASO010_SaleOrder));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.requireField2 = new Rubix.Control.RequireField();
            this.requireField5 = new Rubix.Control.RequireField();
            this.dtShippingPeriod = new DevExpress.XtraEditors.DateEdit();
            this.chkAllStatus = new DevExpress.XtraEditors.CheckEdit();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.txtSONo = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerPONo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dtCustomerPOIssueDateTo = new DevExpress.XtraEditors.DateEdit();
            this.dtCustomerPOIssueDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.customerControl = new Rubix.Control.CustomerControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcUpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcStatusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCustomerPONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcOwnerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcOwnerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcWarehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcWarehouseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcShippingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCustPOIssDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtShippingPeriod.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtShippingPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSONo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerPONo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 154);
            this.ribbonControl1.Size = new System.Drawing.Size(1025, 47);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.requireField2);
            this.groupControl1.Controls.Add(this.requireField5);
            this.groupControl1.Controls.Add(this.dtShippingPeriod);
            this.groupControl1.Controls.Add(this.chkAllStatus);
            this.groupControl1.Controls.Add(this.warehouseControl);
            this.groupControl1.Controls.Add(this.ownerControl);
            this.groupControl1.Controls.Add(this.txtSONo);
            this.groupControl1.Controls.Add(this.txtCustomerPONo);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.dtCustomerPOIssueDateTo);
            this.groupControl1.Controls.Add(this.dtCustomerPOIssueDateFrom);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.customerControl);
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 31);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1025, 123);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "Search Criteria";
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(135, 73);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 189;
            // 
            // requireField5
            // 
            this.requireField5.Location = new System.Drawing.Point(133, 28);
            this.requireField5.Name = "requireField5";
            this.requireField5.Size = new System.Drawing.Size(10, 10);
            this.requireField5.TabIndex = 188;
            // 
            // dtShippingPeriod
            // 
            this.dtShippingPeriod.EditValue = null;
            this.dtShippingPeriod.Location = new System.Drawing.Point(145, 89);
            this.dtShippingPeriod.Name = "dtShippingPeriod";
            this.dtShippingPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("dtShippingPeriod.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.dtShippingPeriod.Properties.DisplayFormat.FormatString = "MM/yyyy";
            this.dtShippingPeriod.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtShippingPeriod.Properties.EditFormat.FormatString = "yyyy/MM";
            this.dtShippingPeriod.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtShippingPeriod.Properties.Mask.EditMask = "MM/yyyy";
            this.dtShippingPeriod.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtShippingPeriod.Size = new System.Drawing.Size(123, 22);
            this.dtShippingPeriod.TabIndex = 4;
            // 
            // chkAllStatus
            // 
            this.chkAllStatus.Location = new System.Drawing.Point(274, 92);
            this.chkAllStatus.Name = "chkAllStatus";
            this.chkAllStatus.Properties.Caption = "All status";
            this.chkAllStatus.Size = new System.Drawing.Size(230, 19);
            this.chkAllStatus.TabIndex = 9;
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(71, 67);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(434, 21);
            this.warehouseControl.TabIndex = 3;
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(85, 23);
            this.ownerControl.Name = "ownerControl";
            this.ownerControl.ReadOnly = false;
            this.ownerControl.RequireField = false;
            this.ownerControl.Size = new System.Drawing.Size(419, 21);
            this.ownerControl.TabIndex = 1;
            this.ownerControl.EditValueChanged += new System.EventHandler(this.ownerControl_EditValueChanged);
            // 
            // txtSONo
            // 
            this.txtSONo.Location = new System.Drawing.Point(694, 45);
            this.txtSONo.MenuManager = this.ribbonControl1;
            this.txtSONo.Name = "txtSONo";
            this.txtSONo.Properties.MaxLength = 50;
            this.txtSONo.Size = new System.Drawing.Size(201, 20);
            this.txtSONo.TabIndex = 6;
            // 
            // txtCustomerPONo
            // 
            this.txtCustomerPONo.Location = new System.Drawing.Point(694, 23);
            this.txtCustomerPONo.MenuManager = this.ribbonControl1;
            this.txtCustomerPONo.Name = "txtCustomerPONo";
            this.txtCustomerPONo.Properties.MaxLength = 50;
            this.txtCustomerPONo.Size = new System.Drawing.Size(201, 20);
            this.txtCustomerPONo.TabIndex = 5;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(556, 49);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(130, 13);
            this.labelControl6.TabIndex = 19;
            this.labelControl6.Text = "S/O No.";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(556, 27);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(130, 13);
            this.labelControl5.TabIndex = 18;
            this.labelControl5.Text = "Customer P/O No.";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(820, 70);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(29, 13);
            this.labelControl4.TabIndex = 17;
            this.labelControl4.Text = "To";
            // 
            // dtCustomerPOIssueDateTo
            // 
            this.dtCustomerPOIssueDateTo.EditValue = null;
            this.dtCustomerPOIssueDateTo.Location = new System.Drawing.Point(853, 67);
            this.dtCustomerPOIssueDateTo.MenuManager = this.ribbonControl1;
            this.dtCustomerPOIssueDateTo.Name = "dtCustomerPOIssueDateTo";
            this.dtCustomerPOIssueDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtCustomerPOIssueDateTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtCustomerPOIssueDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCustomerPOIssueDateTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtCustomerPOIssueDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCustomerPOIssueDateTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtCustomerPOIssueDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtCustomerPOIssueDateTo.Size = new System.Drawing.Size(123, 20);
            this.dtCustomerPOIssueDateTo.TabIndex = 8;
            // 
            // dtCustomerPOIssueDateFrom
            // 
            this.dtCustomerPOIssueDateFrom.EditValue = null;
            this.dtCustomerPOIssueDateFrom.Location = new System.Drawing.Point(694, 67);
            this.dtCustomerPOIssueDateFrom.MenuManager = this.ribbonControl1;
            this.dtCustomerPOIssueDateFrom.Name = "dtCustomerPOIssueDateFrom";
            this.dtCustomerPOIssueDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtCustomerPOIssueDateFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtCustomerPOIssueDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCustomerPOIssueDateFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtCustomerPOIssueDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCustomerPOIssueDateFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtCustomerPOIssueDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtCustomerPOIssueDateFrom.Size = new System.Drawing.Size(123, 20);
            this.dtCustomerPOIssueDateFrom.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(509, 70);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(174, 13);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "Customer P/O Issue Date";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(7, 93);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(130, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Shipping Period";
            // 
            // customerControl
            // 
            this.customerControl.ErrorText = "Customer Control is Require Field";
            this.customerControl.Location = new System.Drawing.Point(83, 45);
            this.customerControl.Name = "customerControl";
            this.customerControl.OwnerID = null;
            this.customerControl.ReadOnly = false;
            this.customerControl.RequireField = false;
            this.customerControl.Size = new System.Drawing.Size(422, 24);
            this.customerControl.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(943, 95);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(862, 95);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // gdcUpdateUser
            // 
            this.gdcUpdateUser.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcUpdateUser.AppearanceHeader.Options.UseFont = true;
            this.gdcUpdateUser.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcUpdateUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcUpdateUser.Caption = "Update User";
            this.gdcUpdateUser.FieldName = "UpdateUser";
            this.gdcUpdateUser.Name = "gdcUpdateUser";
            this.gdcUpdateUser.Visible = true;
            this.gdcUpdateUser.VisibleIndex = 16;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 154);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1025, 336);
            this.groupControl2.TabIndex = 11;
            this.groupControl2.Text = "Search Result";
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSearchResult.Location = new System.Drawing.Point(2, 21);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.MenuManager = this.ribbonControl1;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.Size = new System.Drawing.Size(1021, 313);
            this.grdSearchResult.TabIndex = 1;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult,
            this.gridView2});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcStatusName,
            this.gdcSONo,
            this.gdcCustomerPONo,
            this.gdcOwnerCode,
            this.gdcOwnerName,
            this.gdcWarehouseCode,
            this.gdcWarehouseName,
            this.gdcCustomerCode,
            this.gdcCustomerName,
            this.gdcShippingDate,
            this.gdcCustPOIssDate,
            this.gdcCurrency,
            this.gdcRemark,
            this.gdcCreateDate,
            this.gdcCreateUser,
            this.gdcUpdateDate,
            this.gdcUpdateUser});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            this.gdvSearchResult.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.gdvSearchResult_CellMerge);
            // 
            // gdcStatusName
            // 
            this.gdcStatusName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcStatusName.AppearanceHeader.Options.UseFont = true;
            this.gdcStatusName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcStatusName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcStatusName.Caption = "Status";
            this.gdcStatusName.FieldName = "StatusName";
            this.gdcStatusName.Name = "gdcStatusName";
            this.gdcStatusName.Visible = true;
            this.gdcStatusName.VisibleIndex = 0;
            // 
            // gdcSONo
            // 
            this.gdcSONo.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcSONo.AppearanceHeader.Options.UseFont = true;
            this.gdcSONo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSONo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSONo.Caption = "S/O No.";
            this.gdcSONo.FieldName = "SONo";
            this.gdcSONo.Name = "gdcSONo";
            this.gdcSONo.Visible = true;
            this.gdcSONo.VisibleIndex = 1;
            // 
            // gdcCustomerPONo
            // 
            this.gdcCustomerPONo.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcCustomerPONo.AppearanceHeader.Options.UseFont = true;
            this.gdcCustomerPONo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCustomerPONo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCustomerPONo.Caption = "Customer P/O No.";
            this.gdcCustomerPONo.FieldName = "CustomerPONo";
            this.gdcCustomerPONo.Name = "gdcCustomerPONo";
            this.gdcCustomerPONo.Visible = true;
            this.gdcCustomerPONo.VisibleIndex = 2;
            // 
            // gdcOwnerCode
            // 
            this.gdcOwnerCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcOwnerCode.AppearanceHeader.Options.UseFont = true;
            this.gdcOwnerCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcOwnerCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcOwnerCode.Caption = "Owner Code";
            this.gdcOwnerCode.FieldName = "OwnerCode";
            this.gdcOwnerCode.Name = "gdcOwnerCode";
            this.gdcOwnerCode.Visible = true;
            this.gdcOwnerCode.VisibleIndex = 3;
            // 
            // gdcOwnerName
            // 
            this.gdcOwnerName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcOwnerName.AppearanceHeader.Options.UseFont = true;
            this.gdcOwnerName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcOwnerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcOwnerName.Caption = "Owner Name";
            this.gdcOwnerName.FieldName = "OwnerName";
            this.gdcOwnerName.Name = "gdcOwnerName";
            this.gdcOwnerName.Visible = true;
            this.gdcOwnerName.VisibleIndex = 4;
            // 
            // gdcWarehouseCode
            // 
            this.gdcWarehouseCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcWarehouseCode.AppearanceHeader.Options.UseFont = true;
            this.gdcWarehouseCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcWarehouseCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcWarehouseCode.Caption = "Warehouse Code";
            this.gdcWarehouseCode.FieldName = "WarehouseCode";
            this.gdcWarehouseCode.Name = "gdcWarehouseCode";
            this.gdcWarehouseCode.Visible = true;
            this.gdcWarehouseCode.VisibleIndex = 5;
            // 
            // gdcWarehouseName
            // 
            this.gdcWarehouseName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcWarehouseName.AppearanceHeader.Options.UseFont = true;
            this.gdcWarehouseName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcWarehouseName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcWarehouseName.Caption = "Warehouse Name";
            this.gdcWarehouseName.FieldName = "WarehouseName";
            this.gdcWarehouseName.Name = "gdcWarehouseName";
            this.gdcWarehouseName.Visible = true;
            this.gdcWarehouseName.VisibleIndex = 6;
            // 
            // gdcCustomerCode
            // 
            this.gdcCustomerCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcCustomerCode.AppearanceHeader.Options.UseFont = true;
            this.gdcCustomerCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCustomerCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCustomerCode.Caption = "Customer Code";
            this.gdcCustomerCode.FieldName = "CustomerCode";
            this.gdcCustomerCode.Name = "gdcCustomerCode";
            this.gdcCustomerCode.Visible = true;
            this.gdcCustomerCode.VisibleIndex = 7;
            // 
            // gdcCustomerName
            // 
            this.gdcCustomerName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcCustomerName.AppearanceHeader.Options.UseFont = true;
            this.gdcCustomerName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCustomerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCustomerName.Caption = "Customer Name";
            this.gdcCustomerName.FieldName = "CustomerName";
            this.gdcCustomerName.Name = "gdcCustomerName";
            this.gdcCustomerName.Visible = true;
            this.gdcCustomerName.VisibleIndex = 8;
            // 
            // gdcShippingDate
            // 
            this.gdcShippingDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcShippingDate.AppearanceHeader.Options.UseFont = true;
            this.gdcShippingDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcShippingDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcShippingDate.Caption = "Shipping Period";
            this.gdcShippingDate.FieldName = "ShippingPeriod";
            this.gdcShippingDate.Name = "gdcShippingDate";
            this.gdcShippingDate.Visible = true;
            this.gdcShippingDate.VisibleIndex = 9;
            // 
            // gdcCustPOIssDate
            // 
            this.gdcCustPOIssDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcCustPOIssDate.AppearanceHeader.Options.UseFont = true;
            this.gdcCustPOIssDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCustPOIssDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCustPOIssDate.Caption = "Customer P/O Issue Date";
            this.gdcCustPOIssDate.FieldName = "CustomerPOIssueDate";
            this.gdcCustPOIssDate.Name = "gdcCustPOIssDate";
            this.gdcCustPOIssDate.Visible = true;
            this.gdcCustPOIssDate.VisibleIndex = 10;
            // 
            // gdcCurrency
            // 
            this.gdcCurrency.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcCurrency.AppearanceHeader.Options.UseFont = true;
            this.gdcCurrency.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCurrency.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCurrency.Caption = "Currency";
            this.gdcCurrency.FieldName = "CurrencyCode";
            this.gdcCurrency.Name = "gdcCurrency";
            this.gdcCurrency.Visible = true;
            this.gdcCurrency.VisibleIndex = 11;
            // 
            // gdcRemark
            // 
            this.gdcRemark.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcRemark.AppearanceHeader.Options.UseFont = true;
            this.gdcRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcRemark.Caption = "Remarks";
            this.gdcRemark.FieldName = "Remark";
            this.gdcRemark.Name = "gdcRemark";
            this.gdcRemark.Visible = true;
            this.gdcRemark.VisibleIndex = 12;
            // 
            // gdcCreateDate
            // 
            this.gdcCreateDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcCreateDate.AppearanceHeader.Options.UseFont = true;
            this.gdcCreateDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCreateDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCreateDate.Caption = "Create Date";
            this.gdcCreateDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gdcCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcCreateDate.FieldName = "CreateDate";
            this.gdcCreateDate.Name = "gdcCreateDate";
            this.gdcCreateDate.Visible = true;
            this.gdcCreateDate.VisibleIndex = 13;
            // 
            // gdcCreateUser
            // 
            this.gdcCreateUser.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcCreateUser.AppearanceHeader.Options.UseFont = true;
            this.gdcCreateUser.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCreateUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCreateUser.Caption = "Create User";
            this.gdcCreateUser.FieldName = "CreateUser";
            this.gdcCreateUser.Name = "gdcCreateUser";
            this.gdcCreateUser.Visible = true;
            this.gdcCreateUser.VisibleIndex = 14;
            // 
            // gdcUpdateDate
            // 
            this.gdcUpdateDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcUpdateDate.AppearanceHeader.Options.UseFont = true;
            this.gdcUpdateDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcUpdateDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcUpdateDate.Caption = "Update Date";
            this.gdcUpdateDate.FieldName = "UpdateDate";
            this.gdcUpdateDate.Name = "gdcUpdateDate";
            this.gdcUpdateDate.Visible = true;
            this.gdcUpdateDate.VisibleIndex = 15;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdSearchResult;
            this.gridView2.Name = "gridView2";
            // 
            // groupControl3
            // 
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(200, 100);
            this.groupControl3.TabIndex = 0;
            // 
            // frmASO010_SaleOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 490);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmASO010_SaleOrder";
            this.Text = "ASO010 : Sale Order";
            this.Load += new System.EventHandler(this.frmASO010_SaleOrder_Load);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtShippingPeriod.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtShippingPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSONo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerPONo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Control.CustomerControl customerControl;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtSONo;
        private DevExpress.XtraEditors.TextEdit txtCustomerPONo;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit dtCustomerPOIssueDateTo;
        private DevExpress.XtraEditors.DateEdit dtCustomerPOIssueDateFrom;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateUser;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSONo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCurrency;
        private DevExpress.XtraGrid.Columns.GridColumn gdcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateDate;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCustomerPONo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcShippingDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCustPOIssDate;
        private Control.WarehouseControl warehouseControl;
        private Control.OwnerControl ownerControl;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWarehouseCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWarehouseName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcStatusName;
        private DevExpress.XtraEditors.CheckEdit chkAllStatus;
        private DevExpress.XtraEditors.DateEdit dtShippingPeriod;
        private Control.RequireField requireField2;
        private Control.RequireField requireField5;
    }
}
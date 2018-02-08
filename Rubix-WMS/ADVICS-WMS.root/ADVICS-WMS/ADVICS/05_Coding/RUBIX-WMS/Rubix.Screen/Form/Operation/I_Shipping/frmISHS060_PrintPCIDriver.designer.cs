namespace Rubix.Screen.Form.Operation.I_Shipping
{
    partial class frmISHS060_PrintPCIDriver
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmISHS060_PrintPCIDriver));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.customerControl = new Rubix.Control.CustomerControl();
            this.lblDateTo = new DevExpress.XtraEditors.LabelControl();
            this.dtPickingTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtPickingFrom = new DevExpress.XtraEditors.DateEdit();
            this.shipmentControl = new Rubix.Control.ShipmentControl();
            this.requireField1 = new Rubix.Control.RequireField();
            this.requireField2 = new Rubix.Control.RequireField();
            this.pickingControl = new Rubix.Control.PickingControl();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btnPrintLabel = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintDO = new DevExpress.XtraEditors.SimpleButton();
            this.btnUnselectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.spISHS060PrintDeliveryOrderSearchAllResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcStatusID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcStatusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPortOfLoading = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPortOfDischarge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcFinalDestination = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcShipmentNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPickingNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcDeliveryNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcInstallment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcNumberOfDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPickingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcDownload = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDownload = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spISHS060PrintDeliveryOrderSearchAllResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownload)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Size = new System.Drawing.Size(1147, 47);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.customerControl);
            this.groupControl1.Controls.Add(this.lblDateTo);
            this.groupControl1.Controls.Add(this.dtPickingTo);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.dtPickingFrom);
            this.groupControl1.Controls.Add(this.shipmentControl);
            this.groupControl1.Controls.Add(this.requireField1);
            this.groupControl1.Controls.Add(this.requireField2);
            this.groupControl1.Controls.Add(this.pickingControl);
            this.groupControl1.Controls.Add(this.warehouseControl);
            this.groupControl1.Controls.Add(this.ownerControl);
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 78);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1147, 95);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Search Criteria";
            // 
            // customerControl
            // 
            this.customerControl.ErrorText = "Customer Control is Require Field";
            this.customerControl.Location = new System.Drawing.Point(60, 46);
            this.customerControl.Name = "customerControl";
            this.customerControl.OwnerID = null;
            this.customerControl.ReadOnly = false;
            this.customerControl.RequireField = false;
            this.customerControl.Size = new System.Drawing.Size(452, 21);
            this.customerControl.TabIndex = 1;
            this.customerControl.EditValueChanged += new System.EventHandler(this.customerControl_EditValueChanged);
            // 
            // lblDateTo
            // 
            this.lblDateTo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblDateTo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDateTo.Location = new System.Drawing.Point(835, 70);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(15, 17);
            this.lblDateTo.TabIndex = 133;
            this.lblDateTo.Text = "To";
            // 
            // dtPickingTo
            // 
            this.dtPickingTo.EditValue = null;
            this.dtPickingTo.Location = new System.Drawing.Point(852, 68);
            this.dtPickingTo.MenuManager = this.ribbonControl1;
            this.dtPickingTo.Name = "dtPickingTo";
            this.dtPickingTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtPickingTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtPickingTo.Size = new System.Drawing.Size(123, 20);
            this.dtPickingTo.TabIndex = 6;
            this.dtPickingTo.EditValueChanged += new System.EventHandler(this.dtPickingTo_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(610, 70);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(86, 17);
            this.labelControl1.TabIndex = 131;
            this.labelControl1.Text = "Picking Date";
            // 
            // dtPickingFrom
            // 
            this.dtPickingFrom.EditValue = null;
            this.dtPickingFrom.Location = new System.Drawing.Point(709, 68);
            this.dtPickingFrom.MenuManager = this.ribbonControl1;
            this.dtPickingFrom.Name = "dtPickingFrom";
            this.dtPickingFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtPickingFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtPickingFrom.Size = new System.Drawing.Size(123, 20);
            this.dtPickingFrom.TabIndex = 5;
            this.dtPickingFrom.EditValueChanged += new System.EventHandler(this.dtPickingFrom_EditValueChanged);
            // 
            // shipmentControl
            // 
            this.shipmentControl.ErrorText = "Shipment Control is Require Field";
            this.shipmentControl.Location = new System.Drawing.Point(572, 23);
            this.shipmentControl.Name = "shipmentControl";
            this.shipmentControl.RequireField = false;
            this.shipmentControl.Size = new System.Drawing.Size(403, 22);
            this.shipmentControl.TabIndex = 3;
            this.shipmentControl.EditValueChanged += new System.EventHandler(this.shipmentControl_EditValueChanged);
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(111, 75);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 47;
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(111, 31);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 46;
            // 
            // pickingControl
            // 
            this.pickingControl.ComboType = Rubix.Control.PickingControl.eComboType.Screen;
            this.pickingControl.ErrorText = "Picking Control is Require Field";
            this.pickingControl.Location = new System.Drawing.Point(576, 45);
            this.pickingControl.Name = "pickingControl";
            this.pickingControl.OwnerID = null;
            this.pickingControl.RequireField = false;
            this.pickingControl.Size = new System.Drawing.Size(399, 22);
            this.pickingControl.TabIndex = 4;
            this.pickingControl.WarehouseID = null;
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(48, 68);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(464, 21);
            this.warehouseControl.TabIndex = 2;
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(62, 24);
            this.ownerControl.Name = "ownerControl";
            this.ownerControl.ReadOnly = false;
            this.ownerControl.RequireField = false;
            this.ownerControl.Size = new System.Drawing.Size(449, 21);
            this.ownerControl.TabIndex = 0;
            this.ownerControl.EditValueChanged += new System.EventHandler(this.ownerControl_EditValueChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(1064, 66);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(983, 66);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.btnPrintLabel);
            this.groupControl3.Controls.Add(this.btnPrintDO);
            this.groupControl3.Controls.Add(this.btnUnselectAll);
            this.groupControl3.Controls.Add(this.btnSelectAll);
            this.groupControl3.Controls.Add(this.grdSearchResult);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 173);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1147, 320);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "Search Result";
            // 
            // btnPrintLabel
            // 
            this.btnPrintLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintLabel.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintLabel.Image")));
            this.btnPrintLabel.Location = new System.Drawing.Point(814, 291);
            this.btnPrintLabel.Name = "btnPrintLabel";
            this.btnPrintLabel.Size = new System.Drawing.Size(160, 23);
            this.btnPrintLabel.TabIndex = 3;
            this.btnPrintLabel.Text = "Print Shipment Label";
            this.btnPrintLabel.Click += new System.EventHandler(this.btnPrintLabel_Click);
            // 
            // btnPrintDO
            // 
            this.btnPrintDO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintDO.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintDO.Image")));
            this.btnPrintDO.Location = new System.Drawing.Point(983, 291);
            this.btnPrintDO.Name = "btnPrintDO";
            this.btnPrintDO.Size = new System.Drawing.Size(160, 23);
            this.btnPrintDO.TabIndex = 4;
            this.btnPrintDO.Text = "Print Delivery Note";
            this.btnPrintDO.Click += new System.EventHandler(this.btnPrintDO_Click);
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUnselectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnUnselectAll.Image")));
            this.btnUnselectAll.Location = new System.Drawing.Point(148, 290);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(120, 23);
            this.btnUnselectAll.TabIndex = 2;
            this.btnUnselectAll.Text = "Unselect All";
            this.btnUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.Location = new System.Drawing.Point(10, 290);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(120, 23);
            this.btnSelectAll.TabIndex = 1;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSearchResult.DataSource = this.spISHS060PrintDeliveryOrderSearchAllResultBindingSource;
            this.grdSearchResult.Location = new System.Drawing.Point(6, 24);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.MenuManager = this.ribbonControl1;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnDownload});
            this.grdSearchResult.Size = new System.Drawing.Size(1135, 258);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // spISHS060PrintDeliveryOrderSearchAllResultBindingSource
            // 
            this.spISHS060PrintDeliveryOrderSearchAllResultBindingSource.DataSource = typeof(CSI.Business.DataObjects.sp_ISHS060_PrintDeliveryOrder_SearchAll_Result);
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcSelect,
            this.gdcStatusID,
            this.gdcStatusName,
            this.gdcPortOfLoading,
            this.gdcPortOfDischarge,
            this.gdcFinalDestination,
            this.gdcShipmentNo,
            this.gdcPickingNo,
            this.gdcDeliveryNo,
            this.gdcInstallment,
            this.gdcNumberOfDetail,
            this.gdcPickingDate,
            this.gdcDownload});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            this.gdvSearchResult.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gdvSearchResult_RowCellStyle);
            this.gdvSearchResult.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gdvSearchResult_ShowingEditor);
            // 
            // gdcSelect
            // 
            this.gdcSelect.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcSelect.AppearanceHeader.Options.UseFont = true;
            this.gdcSelect.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSelect.FieldName = "Select";
            this.gdcSelect.Name = "gdcSelect";
            this.gdcSelect.Visible = true;
            this.gdcSelect.VisibleIndex = 0;
            // 
            // gdcStatusID
            // 
            this.gdcStatusID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcStatusID.AppearanceHeader.Options.UseFont = true;
            this.gdcStatusID.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcStatusID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcStatusID.FieldName = "StatusID";
            this.gdcStatusID.Name = "gdcStatusID";
            this.gdcStatusID.OptionsColumn.AllowEdit = false;
            this.gdcStatusID.OptionsColumn.ShowInCustomizationForm = false;
            this.gdcStatusID.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // gdcStatusName
            // 
            this.gdcStatusName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcStatusName.AppearanceHeader.Options.UseFont = true;
            this.gdcStatusName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcStatusName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcStatusName.FieldName = "StatusName";
            this.gdcStatusName.Name = "gdcStatusName";
            this.gdcStatusName.OptionsColumn.AllowEdit = false;
            this.gdcStatusName.Visible = true;
            this.gdcStatusName.VisibleIndex = 1;
            // 
            // gdcPortOfLoading
            // 
            this.gdcPortOfLoading.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcPortOfLoading.AppearanceHeader.Options.UseFont = true;
            this.gdcPortOfLoading.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPortOfLoading.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPortOfLoading.FieldName = "PortOfLoading";
            this.gdcPortOfLoading.Name = "gdcPortOfLoading";
            this.gdcPortOfLoading.OptionsColumn.AllowEdit = false;
            this.gdcPortOfLoading.Visible = true;
            this.gdcPortOfLoading.VisibleIndex = 2;
            // 
            // gdcPortOfDischarge
            // 
            this.gdcPortOfDischarge.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcPortOfDischarge.AppearanceHeader.Options.UseFont = true;
            this.gdcPortOfDischarge.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPortOfDischarge.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPortOfDischarge.FieldName = "PortOfDischarge";
            this.gdcPortOfDischarge.Name = "gdcPortOfDischarge";
            this.gdcPortOfDischarge.OptionsColumn.AllowEdit = false;
            this.gdcPortOfDischarge.Visible = true;
            this.gdcPortOfDischarge.VisibleIndex = 3;
            // 
            // gdcFinalDestination
            // 
            this.gdcFinalDestination.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcFinalDestination.AppearanceHeader.Options.UseFont = true;
            this.gdcFinalDestination.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcFinalDestination.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcFinalDestination.FieldName = "FinalDestination";
            this.gdcFinalDestination.Name = "gdcFinalDestination";
            this.gdcFinalDestination.OptionsColumn.AllowEdit = false;
            this.gdcFinalDestination.Visible = true;
            this.gdcFinalDestination.VisibleIndex = 4;
            // 
            // gdcShipmentNo
            // 
            this.gdcShipmentNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcShipmentNo.AppearanceHeader.Options.UseFont = true;
            this.gdcShipmentNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcShipmentNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcShipmentNo.FieldName = "ShipmentNo";
            this.gdcShipmentNo.Name = "gdcShipmentNo";
            this.gdcShipmentNo.OptionsColumn.AllowEdit = false;
            this.gdcShipmentNo.Visible = true;
            this.gdcShipmentNo.VisibleIndex = 5;
            // 
            // gdcPickingNo
            // 
            this.gdcPickingNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcPickingNo.AppearanceHeader.Options.UseFont = true;
            this.gdcPickingNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPickingNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPickingNo.FieldName = "PickingNo";
            this.gdcPickingNo.Name = "gdcPickingNo";
            this.gdcPickingNo.OptionsColumn.AllowEdit = false;
            this.gdcPickingNo.Visible = true;
            this.gdcPickingNo.VisibleIndex = 6;
            // 
            // gdcDeliveryNo
            // 
            this.gdcDeliveryNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcDeliveryNo.AppearanceHeader.Options.UseFont = true;
            this.gdcDeliveryNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcDeliveryNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcDeliveryNo.FieldName = "DeliveryNo";
            this.gdcDeliveryNo.Name = "gdcDeliveryNo";
            this.gdcDeliveryNo.OptionsColumn.AllowEdit = false;
            this.gdcDeliveryNo.Visible = true;
            this.gdcDeliveryNo.VisibleIndex = 7;
            // 
            // gdcInstallment
            // 
            this.gdcInstallment.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcInstallment.AppearanceHeader.Options.UseFont = true;
            this.gdcInstallment.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcInstallment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcInstallment.FieldName = "Installment";
            this.gdcInstallment.Name = "gdcInstallment";
            this.gdcInstallment.OptionsColumn.AllowEdit = false;
            this.gdcInstallment.Visible = true;
            this.gdcInstallment.VisibleIndex = 8;
            // 
            // gdcNumberOfDetail
            // 
            this.gdcNumberOfDetail.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcNumberOfDetail.AppearanceHeader.Options.UseFont = true;
            this.gdcNumberOfDetail.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcNumberOfDetail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcNumberOfDetail.FieldName = "NumberOfDetail";
            this.gdcNumberOfDetail.Name = "gdcNumberOfDetail";
            this.gdcNumberOfDetail.OptionsColumn.AllowEdit = false;
            this.gdcNumberOfDetail.Visible = true;
            this.gdcNumberOfDetail.VisibleIndex = 9;
            // 
            // gdcPickingDate
            // 
            this.gdcPickingDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcPickingDate.AppearanceHeader.Options.UseFont = true;
            this.gdcPickingDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPickingDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPickingDate.FieldName = "PickingDate";
            this.gdcPickingDate.Name = "gdcPickingDate";
            this.gdcPickingDate.OptionsColumn.AllowEdit = false;
            this.gdcPickingDate.Visible = true;
            this.gdcPickingDate.VisibleIndex = 10;
            // 
            // gdcDownload
            // 
            this.gdcDownload.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcDownload.AppearanceHeader.Options.UseFont = true;
            this.gdcDownload.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcDownload.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcDownload.Caption = "Download COA";
            this.gdcDownload.ColumnEdit = this.btnDownload;
            this.gdcDownload.Name = "gdcDownload";
            this.gdcDownload.Visible = true;
            this.gdcDownload.VisibleIndex = 11;
            // 
            // btnDownload
            // 
            this.btnDownload.AutoHeight = false;
            this.btnDownload.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // frmISHS060_PrintPCIDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 493);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmISHS060_PrintPCIDriver";
            this.Text = "ISHS060 : Print Delivery Note";
            this.Load += new System.EventHandler(this.frmISHS060_PrintPCIDriver_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spISHS060PrintDeliveryOrderSearchAllResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownload)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Control.PickingControl pickingControl;
        private Control.WarehouseControl warehouseControl;
        private Control.OwnerControl ownerControl;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraEditors.SimpleButton btnPrintDO;
        private DevExpress.XtraEditors.SimpleButton btnUnselectAll;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnPrintLabel;
        private Control.RequireField requireField1;
        private Control.RequireField requireField2;
        private DevExpress.XtraEditors.LabelControl lblDateTo;
        private DevExpress.XtraEditors.DateEdit dtPickingTo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtPickingFrom;
        private Control.ShipmentControl shipmentControl;
        private System.Windows.Forms.BindingSource spISHS060PrintDeliveryOrderSearchAllResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSelect;
        private DevExpress.XtraGrid.Columns.GridColumn gdcStatusID;
        private DevExpress.XtraGrid.Columns.GridColumn gdcStatusName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPortOfLoading;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPortOfDischarge;
        private DevExpress.XtraGrid.Columns.GridColumn gdcFinalDestination;
        private DevExpress.XtraGrid.Columns.GridColumn gdcShipmentNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPickingNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcDeliveryNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcInstallment;
        private DevExpress.XtraGrid.Columns.GridColumn gdcNumberOfDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPickingDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcDownload;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDownload;
        private Control.CustomerControl customerControl;
    }
}
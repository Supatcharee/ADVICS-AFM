namespace Rubix.Screen.Form.Operation.H_Picking
{
    partial class frmHPCS010_PickingInstruction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHPCS010_PickingInstruction));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.grpControl = new DevExpress.XtraEditors.GroupControl();
            this.txtInvoiceNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtpDeliveryTo = new DevExpress.XtraEditors.DateEdit();
            this.dtpDeliveryFrom = new DevExpress.XtraEditors.DateEdit();
            this.customerControl = new Rubix.Control.CustomerControl();
            this.requireField2 = new Rubix.Control.RequireField();
            this.requireField1 = new Rubix.Control.RequireField();
            this.pickingControl = new Rubix.Control.PickingControl();
            this.shipmentControl = new Rubix.Control.ShipmentControl();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnReprint = new DevExpress.XtraEditors.SimpleButton();
            this.btnUnselectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Select = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repChkEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.PortOfDischargeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PortOfDischargeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PortOfLoadingCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PortOfLoadingName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcStockOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ShipmentNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PickingNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeliveryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NumberOfDetails = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPalletNo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpControl)).BeginInit();
            this.grpControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDeliveryTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDeliveryTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDeliveryFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDeliveryFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChkEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Size = new System.Drawing.Size(942, 47);
            // 
            // grpControl
            // 
            this.grpControl.Controls.Add(this.txtInvoiceNo);
            this.grpControl.Controls.Add(this.labelControl3);
            this.grpControl.Controls.Add(this.labelControl2);
            this.grpControl.Controls.Add(this.labelControl1);
            this.grpControl.Controls.Add(this.dtpDeliveryTo);
            this.grpControl.Controls.Add(this.dtpDeliveryFrom);
            this.grpControl.Controls.Add(this.customerControl);
            this.grpControl.Controls.Add(this.requireField2);
            this.grpControl.Controls.Add(this.requireField1);
            this.grpControl.Controls.Add(this.pickingControl);
            this.grpControl.Controls.Add(this.shipmentControl);
            this.grpControl.Controls.Add(this.warehouseControl);
            this.grpControl.Controls.Add(this.ownerControl);
            this.grpControl.Controls.Add(this.btnClear);
            this.grpControl.Controls.Add(this.btnSearch);
            this.grpControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpControl.Location = new System.Drawing.Point(0, 78);
            this.grpControl.Name = "grpControl";
            this.grpControl.Size = new System.Drawing.Size(942, 122);
            this.grpControl.TabIndex = 0;
            this.grpControl.Text = "Search Criteria";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(723, 70);
            this.txtInvoiceNo.MenuManager = this.ribbonControl1;
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Properties.MaxLength = 50;
            this.txtInvoiceNo.Size = new System.Drawing.Size(199, 20);
            this.txtInvoiceNo.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(566, 72);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(144, 17);
            this.labelControl3.TabIndex = 126;
            this.labelControl3.Text = "Invoice No.";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(293, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 17);
            this.labelControl2.TabIndex = 125;
            this.labelControl2.Text = "To";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(5, 93);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(143, 19);
            this.labelControl1.TabIndex = 124;
            this.labelControl1.Text = "Delivery Date";
            // 
            // dtpDeliveryTo
            // 
            this.dtpDeliveryTo.EditValue = null;
            this.dtpDeliveryTo.Location = new System.Drawing.Point(311, 91);
            this.dtpDeliveryTo.MenuManager = this.ribbonControl1;
            this.dtpDeliveryTo.Name = "dtpDeliveryTo";
            this.dtpDeliveryTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDeliveryTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpDeliveryTo.Size = new System.Drawing.Size(124, 20);
            this.dtpDeliveryTo.TabIndex = 4;
            this.dtpDeliveryTo.EditValueChanged += new System.EventHandler(this.dtpDeliveryTo_EditValueChanged);
            // 
            // dtpDeliveryFrom
            // 
            this.dtpDeliveryFrom.EditValue = null;
            this.dtpDeliveryFrom.Location = new System.Drawing.Point(162, 91);
            this.dtpDeliveryFrom.MenuManager = this.ribbonControl1;
            this.dtpDeliveryFrom.Name = "dtpDeliveryFrom";
            this.dtpDeliveryFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDeliveryFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpDeliveryFrom.Size = new System.Drawing.Size(124, 20);
            this.dtpDeliveryFrom.TabIndex = 3;
            this.dtpDeliveryFrom.EditValueChanged += new System.EventHandler(this.dtpDeliveryFrom_EditValueChanged);
            // 
            // customerControl
            // 
            this.customerControl.ErrorText = "Customer Control is Require Field";
            this.customerControl.Location = new System.Drawing.Point(100, 46);
            this.customerControl.Name = "customerControl";
            this.customerControl.OwnerID = null;
            this.customerControl.ReadOnly = false;
            this.customerControl.RequireField = false;
            this.customerControl.Size = new System.Drawing.Size(451, 21);
            this.customerControl.TabIndex = 1;
            this.customerControl.EditValueChanged += new System.EventHandler(this.customerControl_EditValueChanged);
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(151, 74);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 119;
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(151, 30);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 118;
            // 
            // pickingControl
            // 
            this.pickingControl.ComboType = Rubix.Control.PickingControl.eComboType.Screen;
            this.pickingControl.ErrorText = "Picking Control is Require Field";
            this.pickingControl.Location = new System.Drawing.Point(591, 47);
            this.pickingControl.Name = "pickingControl";
            this.pickingControl.OwnerID = null;
            this.pickingControl.RequireField = false;
            this.pickingControl.Size = new System.Drawing.Size(331, 22);
            this.pickingControl.TabIndex = 6;
            this.pickingControl.WarehouseID = null;
            // 
            // shipmentControl
            // 
            this.shipmentControl.ErrorText = "Shipment Control is Require Field";
            this.shipmentControl.Location = new System.Drawing.Point(587, 24);
            this.shipmentControl.Name = "shipmentControl";
            this.shipmentControl.RequireField = false;
            this.shipmentControl.Size = new System.Drawing.Size(334, 22);
            this.shipmentControl.TabIndex = 5;
            this.shipmentControl.EditValueChanged += new System.EventHandler(this.shipmentControl_EditValueChanged);
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(88, 68);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(465, 21);
            this.warehouseControl.TabIndex = 2;
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(102, 24);
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
            this.btnClear.Location = new System.Drawing.Point(862, 94);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(781, 94);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnReprint);
            this.groupControl2.Controls.Add(this.btnUnselectAll);
            this.groupControl2.Controls.Add(this.btnSelectAll);
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 200);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(942, 295);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Search Result";
            // 
            // btnReprint
            // 
            this.btnReprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReprint.Image = ((System.Drawing.Image)(resources.GetObject("btnReprint.Image")));
            this.btnReprint.Location = new System.Drawing.Point(816, 265);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(120, 23);
            this.btnReprint.TabIndex = 3;
            this.btnReprint.Text = "Re-Print";
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUnselectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnUnselectAll.Image")));
            this.btnUnselectAll.Location = new System.Drawing.Point(134, 265);
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
            this.btnSelectAll.Location = new System.Drawing.Point(8, 265);
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
            this.grdSearchResult.Location = new System.Drawing.Point(6, 24);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.MenuManager = this.ribbonControl1;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repChkEdit});
            this.grdSearchResult.Size = new System.Drawing.Size(930, 227);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Select,
            this.PortOfDischargeCode,
            this.PortOfDischargeName,
            this.PortOfLoadingCode,
            this.PortOfLoadingName,
            this.gdcStockOut,
            this.ShipmentNo,
            this.PickingNo,
            this.colDeliveryDate,
            this.colInvoiceNo,
            this.gdcProductCode,
            this.gdcProductName,
            this.NumberOfDetails,
            this.gdcPalletNo});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "[StockOut] == \'Stock Out\'";
            this.gdvSearchResult.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gdvSearchResult.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gdvSearchResult.OptionsSelection.UseIndicatorForSelection = false;
            this.gdvSearchResult.OptionsView.AllowCellMerge = true;
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            this.gdvSearchResult.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gdvSearchResult_RowStyle);
            this.gdvSearchResult.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gdvSearchResult_ShowingEditor);
            // 
            // Select
            // 
            this.Select.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Select.AppearanceHeader.Options.UseFont = true;
            this.Select.AppearanceHeader.Options.UseTextOptions = true;
            this.Select.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Select.Caption = "Select";
            this.Select.ColumnEdit = this.repChkEdit;
            this.Select.FieldName = "Select";
            this.Select.Name = "Select";
            this.Select.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.Select.Visible = true;
            this.Select.VisibleIndex = 0;
            // 
            // repChkEdit
            // 
            this.repChkEdit.AutoHeight = false;
            this.repChkEdit.Name = "repChkEdit";
            this.repChkEdit.EditValueChanged += new System.EventHandler(this.repChkEdit_EditValueChanged);
            // 
            // PortOfDischargeCode
            // 
            this.PortOfDischargeCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.PortOfDischargeCode.AppearanceHeader.Options.UseFont = true;
            this.PortOfDischargeCode.AppearanceHeader.Options.UseTextOptions = true;
            this.PortOfDischargeCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PortOfDischargeCode.Caption = "Port Of Discharge Code";
            this.PortOfDischargeCode.FieldName = "PortOfDischargeCode";
            this.PortOfDischargeCode.Name = "PortOfDischargeCode";
            this.PortOfDischargeCode.OptionsColumn.AllowEdit = false;
            this.PortOfDischargeCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PortOfDischargeCode.OptionsColumn.ShowInCustomizationForm = false;
            this.PortOfDischargeCode.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // PortOfDischargeName
            // 
            this.PortOfDischargeName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.PortOfDischargeName.AppearanceHeader.Options.UseFont = true;
            this.PortOfDischargeName.AppearanceHeader.Options.UseTextOptions = true;
            this.PortOfDischargeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PortOfDischargeName.Caption = "Port Of Discharge Name";
            this.PortOfDischargeName.FieldName = "PortOfDischargeName";
            this.PortOfDischargeName.Name = "PortOfDischargeName";
            this.PortOfDischargeName.OptionsColumn.AllowEdit = false;
            this.PortOfDischargeName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PortOfDischargeName.OptionsColumn.ShowInCustomizationForm = false;
            this.PortOfDischargeName.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // PortOfLoadingCode
            // 
            this.PortOfLoadingCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.PortOfLoadingCode.AppearanceHeader.Options.UseFont = true;
            this.PortOfLoadingCode.AppearanceHeader.Options.UseTextOptions = true;
            this.PortOfLoadingCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PortOfLoadingCode.Caption = "Port Of Loading Code";
            this.PortOfLoadingCode.FieldName = "PortOfLoadingCode";
            this.PortOfLoadingCode.Name = "PortOfLoadingCode";
            this.PortOfLoadingCode.OptionsColumn.AllowEdit = false;
            this.PortOfLoadingCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PortOfLoadingCode.OptionsColumn.ShowInCustomizationForm = false;
            this.PortOfLoadingCode.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // PortOfLoadingName
            // 
            this.PortOfLoadingName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.PortOfLoadingName.AppearanceHeader.Options.UseFont = true;
            this.PortOfLoadingName.AppearanceHeader.Options.UseTextOptions = true;
            this.PortOfLoadingName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PortOfLoadingName.Caption = "Port Of Loading Name";
            this.PortOfLoadingName.FieldName = "PortOfLoadingName";
            this.PortOfLoadingName.Name = "PortOfLoadingName";
            this.PortOfLoadingName.OptionsColumn.AllowEdit = false;
            this.PortOfLoadingName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.PortOfLoadingName.OptionsColumn.ShowInCustomizationForm = false;
            this.PortOfLoadingName.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // gdcStockOut
            // 
            this.gdcStockOut.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcStockOut.AppearanceHeader.Options.UseFont = true;
            this.gdcStockOut.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcStockOut.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcStockOut.Caption = "Stock Out";
            this.gdcStockOut.FieldName = "StockOut";
            this.gdcStockOut.Name = "gdcStockOut";
            this.gdcStockOut.OptionsColumn.AllowEdit = false;
            this.gdcStockOut.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gdcStockOut.Visible = true;
            this.gdcStockOut.VisibleIndex = 1;
            // 
            // ShipmentNo
            // 
            this.ShipmentNo.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ShipmentNo.AppearanceHeader.Options.UseFont = true;
            this.ShipmentNo.AppearanceHeader.Options.UseTextOptions = true;
            this.ShipmentNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ShipmentNo.Caption = "Shipment No";
            this.ShipmentNo.FieldName = "ShipmentNo";
            this.ShipmentNo.Name = "ShipmentNo";
            this.ShipmentNo.OptionsColumn.AllowEdit = false;
            this.ShipmentNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.ShipmentNo.Visible = true;
            this.ShipmentNo.VisibleIndex = 2;
            // 
            // PickingNo
            // 
            this.PickingNo.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.PickingNo.AppearanceHeader.Options.UseFont = true;
            this.PickingNo.AppearanceHeader.Options.UseTextOptions = true;
            this.PickingNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PickingNo.Caption = "Picking No";
            this.PickingNo.FieldName = "PickingNo";
            this.PickingNo.Name = "PickingNo";
            this.PickingNo.OptionsColumn.AllowEdit = false;
            this.PickingNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.PickingNo.Visible = true;
            this.PickingNo.VisibleIndex = 3;
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.colDeliveryDate.AppearanceHeader.Options.UseFont = true;
            this.colDeliveryDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colDeliveryDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeliveryDate.Caption = "Delivery Date";
            this.colDeliveryDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDeliveryDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDeliveryDate.FieldName = "DeliveryDate";
            this.colDeliveryDate.Name = "colDeliveryDate";
            this.colDeliveryDate.OptionsColumn.AllowEdit = false;
            this.colDeliveryDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colDeliveryDate.Visible = true;
            this.colDeliveryDate.VisibleIndex = 4;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.colInvoiceNo.AppearanceHeader.Options.UseFont = true;
            this.colInvoiceNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colInvoiceNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInvoiceNo.Caption = "Invoice No.";
            this.colInvoiceNo.FieldName = "InvoiceNo";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.OptionsColumn.AllowEdit = false;
            this.colInvoiceNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNo.Visible = true;
            this.colInvoiceNo.VisibleIndex = 5;
            // 
            // gdcProductCode
            // 
            this.gdcProductCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcProductCode.AppearanceHeader.Options.UseFont = true;
            this.gdcProductCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcProductCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcProductCode.Caption = "Item Code";
            this.gdcProductCode.FieldName = "ProductCode";
            this.gdcProductCode.Name = "gdcProductCode";
            this.gdcProductCode.OptionsColumn.AllowEdit = false;
            this.gdcProductCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gdcProductCode.Visible = true;
            this.gdcProductCode.VisibleIndex = 6;
            // 
            // gdcProductName
            // 
            this.gdcProductName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcProductName.AppearanceHeader.Options.UseFont = true;
            this.gdcProductName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcProductName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcProductName.Caption = "Item Name";
            this.gdcProductName.FieldName = "ProductLongName";
            this.gdcProductName.Name = "gdcProductName";
            this.gdcProductName.OptionsColumn.AllowEdit = false;
            this.gdcProductName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gdcProductName.Visible = true;
            this.gdcProductName.VisibleIndex = 7;
            // 
            // NumberOfDetails
            // 
            this.NumberOfDetails.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.NumberOfDetails.AppearanceHeader.Options.UseFont = true;
            this.NumberOfDetails.AppearanceHeader.Options.UseTextOptions = true;
            this.NumberOfDetails.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NumberOfDetails.Caption = "Number Of Details";
            this.NumberOfDetails.FieldName = "NumberOfDetails";
            this.NumberOfDetails.Name = "NumberOfDetails";
            this.NumberOfDetails.OptionsColumn.AllowEdit = false;
            this.NumberOfDetails.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gdcPalletNo
            // 
            this.gdcPalletNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPalletNo.AppearanceHeader.Options.UseFont = true;
            this.gdcPalletNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPalletNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPalletNo.Caption = "Pallet No.";
            this.gdcPalletNo.FieldName = "PalletNo";
            this.gdcPalletNo.Name = "gdcPalletNo";
            this.gdcPalletNo.Visible = true;
            this.gdcPalletNo.VisibleIndex = 8;
            // 
            // frmHPCS010_PickingInstruction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 495);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.grpControl);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmHPCS010_PickingInstruction";
            this.Text = "HPCS010 : Picking Arrangement";
            this.Load += new System.EventHandler(this.frmHPCS010_PickingInstruction_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.grpControl, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpControl)).EndInit();
            this.grpControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDeliveryTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDeliveryTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDeliveryFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDeliveryFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChkEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpControl;
        private Control.ShipmentControl shipmentControl;
        private Control.WarehouseControl warehouseControl;
        private Control.OwnerControl ownerControl;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private Control.PickingControl pickingControl;
        private DevExpress.XtraEditors.SimpleButton btnUnselectAll;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private Control.RequireField requireField2;
        private Control.RequireField requireField1;
        private DevExpress.XtraGrid.Columns.GridColumn Select;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repChkEdit;
        private DevExpress.XtraGrid.Columns.GridColumn PortOfDischargeCode;
        private DevExpress.XtraGrid.Columns.GridColumn PortOfDischargeName;
        private DevExpress.XtraGrid.Columns.GridColumn PortOfLoadingCode;
        private DevExpress.XtraGrid.Columns.GridColumn PortOfLoadingName;
        private DevExpress.XtraGrid.Columns.GridColumn ShipmentNo;
        private DevExpress.XtraGrid.Columns.GridColumn PickingNo;
        private DevExpress.XtraGrid.Columns.GridColumn NumberOfDetails;
        private DevExpress.XtraEditors.TextEdit txtInvoiceNo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtpDeliveryTo;
        private DevExpress.XtraEditors.DateEdit dtpDeliveryFrom;
        private Control.CustomerControl customerControl;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryDate;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNo;
        private DevExpress.XtraEditors.SimpleButton btnReprint;
        private DevExpress.XtraGrid.Columns.GridColumn gdcStockOut;
        private DevExpress.XtraGrid.Columns.GridColumn gdcProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcProductName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPalletNo;

    }
}
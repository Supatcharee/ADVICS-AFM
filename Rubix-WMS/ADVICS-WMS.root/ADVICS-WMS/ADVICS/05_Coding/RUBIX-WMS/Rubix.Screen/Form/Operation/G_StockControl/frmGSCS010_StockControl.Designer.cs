namespace Rubix.Screen.Form.Operation.G_StockControl
{
    partial class frmGSCS010_StockControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGSCS010_StockControl));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.customerControl = new Rubix.Control.CustomerControl();
            this.requireField3 = new Rubix.Control.RequireField();
            this.requireField2 = new Rubix.Control.RequireField();
            this.requireField1 = new Rubix.Control.RequireField();
            this.shipmentControl = new Rubix.Control.ShipmentControl();
            this.finalDestinationControl = new Rubix.Control.FinalDestinationControl();
            this.dtPickingDateTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtPickingDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Select = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.StockOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ShipmentNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PickingNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PickingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeliveryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NumberOfDetails = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PortOfLoadingCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PortOfLoadingName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PortOfDischargeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PortOfDischargeName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Size = new System.Drawing.Size(887, 47);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.customerControl);
            this.groupControl1.Controls.Add(this.requireField3);
            this.groupControl1.Controls.Add(this.requireField2);
            this.groupControl1.Controls.Add(this.requireField1);
            this.groupControl1.Controls.Add(this.shipmentControl);
            this.groupControl1.Controls.Add(this.finalDestinationControl);
            this.groupControl1.Controls.Add(this.dtPickingDateTo);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.dtPickingDateFrom);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.warehouseControl);
            this.groupControl1.Controls.Add(this.ownerControl);
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 78);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(887, 160);
            this.groupControl1.TabIndex = 13;
            this.groupControl1.Text = "Search Criteria";
            // 
            // customerControl
            // 
            this.customerControl.ErrorText = "Customer Control is Require Field";
            this.customerControl.Location = new System.Drawing.Point(75, 46);
            this.customerControl.Name = "customerControl";
            this.customerControl.OwnerID = null;
            this.customerControl.ReadOnly = false;
            this.customerControl.RequireField = false;
            this.customerControl.Size = new System.Drawing.Size(452, 21);
            this.customerControl.TabIndex = 120;
            this.customerControl.EditValueChanged += new System.EventHandler(this.shippingCustomerControl1_EditValueChanged);
            // 
            // requireField3
            // 
            this.requireField3.Location = new System.Drawing.Point(125, 96);
            this.requireField3.Name = "requireField3";
            this.requireField3.Size = new System.Drawing.Size(10, 10);
            this.requireField3.TabIndex = 119;
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(125, 75);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 118;
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(125, 30);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 117;
            // 
            // shipmentControl
            // 
            this.shipmentControl.ErrorText = "Shipment Control is Require Field";
            this.shipmentControl.Location = new System.Drawing.Point(2, 111);
            this.shipmentControl.Name = "shipmentControl";
            this.shipmentControl.RequireField = false;
            this.shipmentControl.Size = new System.Drawing.Size(407, 22);
            this.shipmentControl.TabIndex = 116;
            // 
            // finalDestinationControl
            // 
            this.finalDestinationControl.ErrorText = "Final Destionation Control is Require Field";
            this.finalDestinationControl.Location = new System.Drawing.Point(43, 134);
            this.finalDestinationControl.Name = "finalDestinationControl";
            this.finalDestinationControl.ReadOnly = false;
            this.finalDestinationControl.RequireField = false;
            this.finalDestinationControl.Size = new System.Drawing.Size(483, 24);
            this.finalDestinationControl.TabIndex = 115;
            // 
            // dtPickingDateTo
            // 
            this.dtPickingDateTo.EditValue = null;
            this.dtPickingDateTo.Location = new System.Drawing.Point(286, 91);
            this.dtPickingDateTo.Name = "dtPickingDateTo";
            this.dtPickingDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtPickingDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtPickingDateTo.Size = new System.Drawing.Size(123, 20);
            this.dtPickingDateTo.TabIndex = 114;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(262, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 17);
            this.labelControl2.TabIndex = 113;
            this.labelControl2.Text = "To";
            // 
            // dtPickingDateFrom
            // 
            this.dtPickingDateFrom.EditValue = null;
            this.dtPickingDateFrom.Location = new System.Drawing.Point(137, 91);
            this.dtPickingDateFrom.Name = "dtPickingDateFrom";
            this.dtPickingDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtPickingDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtPickingDateFrom.Size = new System.Drawing.Size(123, 20);
            this.dtPickingDateFrom.TabIndex = 112;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(0, 93);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(125, 18);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Picking Date";
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(63, 68);
            this.warehouseControl.Name = "warehouseControl";
            
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(464, 21);
            this.warehouseControl.TabIndex = 9;
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(77, 24);
            this.ownerControl.Name = "ownerControl";
            this.ownerControl.ReadOnly = false;
            this.ownerControl.RequireField = false;
            this.ownerControl.Size = new System.Drawing.Size(449, 21);
            this.ownerControl.TabIndex = 8;
            this.ownerControl.EditValueChanged += new System.EventHandler(this.customerControl_EditValueChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(804, 132);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(723, 132);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 238);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(887, 255);
            this.groupControl2.TabIndex = 12;
            this.groupControl2.Text = "Search Result";
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
            this.repCheckEdit});
            this.grdSearchResult.Size = new System.Drawing.Size(875, 226);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Select,
            this.StockOut,
            this.ShipmentNo,
            this.PickingNo,
            this.PickingDate,
            this.DeliveryDate,
            this.NumberOfDetails,
            this.PortOfLoadingCode,
            this.PortOfLoadingName,
            this.PortOfDischargeCode,
            this.PortOfDischargeName});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            this.gdvSearchResult.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            this.gdvSearchResult.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gdvSearchResult_RowStyle);
            this.gdvSearchResult.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gdvSearchResult_ShowingEditor);
            // 
            // Select
            // 
            this.Select.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Select.AppearanceHeader.Options.UseFont = true;
            this.Select.AppearanceHeader.Options.UseTextOptions = true;
            this.Select.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Select.Caption = "Select";
            this.Select.ColumnEdit = this.repCheckEdit;
            this.Select.FieldName = "Select";
            this.Select.Name = "Select";
            this.Select.OptionsColumn.ShowInCustomizationForm = false;
            this.Select.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // repCheckEdit
            // 
            this.repCheckEdit.AutoHeight = false;
            this.repCheckEdit.Name = "repCheckEdit";
            this.repCheckEdit.EditValueChanged += new System.EventHandler(this.repCheckEdit_EditValueChanged);
            // 
            // StockOut
            // 
            this.StockOut.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockOut.AppearanceHeader.Options.UseFont = true;
            this.StockOut.AppearanceHeader.Options.UseTextOptions = true;
            this.StockOut.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.StockOut.Caption = "Stock Out";
            this.StockOut.FieldName = "StockOut";
            this.StockOut.Name = "StockOut";
            this.StockOut.OptionsColumn.AllowEdit = false;
            this.StockOut.Visible = true;
            this.StockOut.VisibleIndex = 0;
            // 
            // ShipmentNo
            // 
            this.ShipmentNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShipmentNo.AppearanceHeader.Options.UseFont = true;
            this.ShipmentNo.AppearanceHeader.Options.UseTextOptions = true;
            this.ShipmentNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ShipmentNo.Caption = "Shipment No";
            this.ShipmentNo.FieldName = "ShipmentNo";
            this.ShipmentNo.Name = "ShipmentNo";
            this.ShipmentNo.OptionsColumn.AllowEdit = false;
            this.ShipmentNo.Visible = true;
            this.ShipmentNo.VisibleIndex = 1;
            // 
            // PickingNo
            // 
            this.PickingNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PickingNo.AppearanceHeader.Options.UseFont = true;
            this.PickingNo.AppearanceHeader.Options.UseTextOptions = true;
            this.PickingNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PickingNo.Caption = "Picking No";
            this.PickingNo.FieldName = "PickingNo";
            this.PickingNo.Name = "PickingNo";
            this.PickingNo.OptionsColumn.AllowEdit = false;
            this.PickingNo.Visible = true;
            this.PickingNo.VisibleIndex = 2;
            // 
            // PickingDate
            // 
            this.PickingDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PickingDate.AppearanceHeader.Options.UseFont = true;
            this.PickingDate.AppearanceHeader.Options.UseTextOptions = true;
            this.PickingDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PickingDate.Caption = "Picking Date";
            this.PickingDate.FieldName = "PickingDate";
            this.PickingDate.Name = "PickingDate";
            this.PickingDate.OptionsColumn.AllowEdit = false;
            this.PickingDate.Visible = true;
            this.PickingDate.VisibleIndex = 3;
            // 
            // DeliveryDate
            // 
            this.DeliveryDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeliveryDate.AppearanceHeader.Options.UseFont = true;
            this.DeliveryDate.AppearanceHeader.Options.UseTextOptions = true;
            this.DeliveryDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DeliveryDate.Caption = "Delivery Date";
            this.DeliveryDate.FieldName = "DeliveryDate";
            this.DeliveryDate.Name = "DeliveryDate";
            this.DeliveryDate.OptionsColumn.AllowEdit = false;
            this.DeliveryDate.Visible = true;
            this.DeliveryDate.VisibleIndex = 4;
            // 
            // NumberOfDetails
            // 
            this.NumberOfDetails.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberOfDetails.AppearanceHeader.Options.UseFont = true;
            this.NumberOfDetails.AppearanceHeader.Options.UseTextOptions = true;
            this.NumberOfDetails.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NumberOfDetails.Caption = "Number Of Details";
            this.NumberOfDetails.FieldName = "NumberOfDetails";
            this.NumberOfDetails.Name = "NumberOfDetails";
            this.NumberOfDetails.OptionsColumn.AllowEdit = false;
            this.NumberOfDetails.Visible = true;
            this.NumberOfDetails.VisibleIndex = 5;
            // 
            // PortOfLoadingCode
            // 
            this.PortOfLoadingCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortOfLoadingCode.AppearanceHeader.Options.UseFont = true;
            this.PortOfLoadingCode.AppearanceHeader.Options.UseTextOptions = true;
            this.PortOfLoadingCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PortOfLoadingCode.Caption = "Port Of Loading Code";
            this.PortOfLoadingCode.FieldName = "PortOfLoadingCode";
            this.PortOfLoadingCode.Name = "PortOfLoadingCode";
            this.PortOfLoadingCode.OptionsColumn.AllowEdit = false;
            this.PortOfLoadingCode.Visible = true;
            this.PortOfLoadingCode.VisibleIndex = 6;
            // 
            // PortOfLoadingName
            // 
            this.PortOfLoadingName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortOfLoadingName.AppearanceHeader.Options.UseFont = true;
            this.PortOfLoadingName.AppearanceHeader.Options.UseTextOptions = true;
            this.PortOfLoadingName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PortOfLoadingName.Caption = "Port Of Loading Name";
            this.PortOfLoadingName.FieldName = "PortOfLoadingName";
            this.PortOfLoadingName.Name = "PortOfLoadingName";
            this.PortOfLoadingName.OptionsColumn.AllowEdit = false;
            this.PortOfLoadingName.Visible = true;
            this.PortOfLoadingName.VisibleIndex = 7;
            // 
            // PortOfDischargeCode
            // 
            this.PortOfDischargeCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortOfDischargeCode.AppearanceHeader.Options.UseFont = true;
            this.PortOfDischargeCode.AppearanceHeader.Options.UseTextOptions = true;
            this.PortOfDischargeCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PortOfDischargeCode.Caption = "Port Of Discharge Code";
            this.PortOfDischargeCode.FieldName = "PortOfDischargeCode";
            this.PortOfDischargeCode.Name = "PortOfDischargeCode";
            this.PortOfDischargeCode.OptionsColumn.AllowEdit = false;
            this.PortOfDischargeCode.Visible = true;
            this.PortOfDischargeCode.VisibleIndex = 8;
            // 
            // PortOfDischargeName
            // 
            this.PortOfDischargeName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortOfDischargeName.AppearanceHeader.Options.UseFont = true;
            this.PortOfDischargeName.AppearanceHeader.Options.UseTextOptions = true;
            this.PortOfDischargeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PortOfDischargeName.Caption = "Port Of Discharge Name";
            this.PortOfDischargeName.FieldName = "PortOfDischargeName";
            this.PortOfDischargeName.Name = "PortOfDischargeName";
            this.PortOfDischargeName.OptionsColumn.AllowEdit = false;
            this.PortOfDischargeName.Visible = true;
            this.PortOfDischargeName.VisibleIndex = 9;
            // 
            // frmGSCS010_StockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 493);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmGSCS010_StockControl";
            this.Text = "GSCS010 : Stock Control";
            this.Load += new System.EventHandler(this.frmGSCS010_StockControl_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DateEdit dtPickingDateTo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dtPickingDateFrom;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Control.WarehouseControl warehouseControl;
        private Control.OwnerControl ownerControl;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private Control.FinalDestinationControl finalDestinationControl;
        private Control.ShipmentControl shipmentControl;
        private Control.RequireField requireField3;
        private Control.RequireField requireField2;
        private Control.RequireField requireField1;
        private DevExpress.XtraGrid.Columns.GridColumn Select;
        private DevExpress.XtraGrid.Columns.GridColumn ShipmentNo;
        private DevExpress.XtraGrid.Columns.GridColumn PickingNo;
        private DevExpress.XtraGrid.Columns.GridColumn PortOfLoadingCode;
        private DevExpress.XtraGrid.Columns.GridColumn PortOfLoadingName;
        private DevExpress.XtraGrid.Columns.GridColumn PortOfDischargeCode;
        private DevExpress.XtraGrid.Columns.GridColumn PortOfDischargeName;
        private DevExpress.XtraGrid.Columns.GridColumn PickingDate;
        private DevExpress.XtraGrid.Columns.GridColumn DeliveryDate;
        private DevExpress.XtraGrid.Columns.GridColumn NumberOfDetails;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckEdit;
        private DevExpress.XtraGrid.Columns.GridColumn StockOut;
        private Control.CustomerControl customerControl;
    }
}
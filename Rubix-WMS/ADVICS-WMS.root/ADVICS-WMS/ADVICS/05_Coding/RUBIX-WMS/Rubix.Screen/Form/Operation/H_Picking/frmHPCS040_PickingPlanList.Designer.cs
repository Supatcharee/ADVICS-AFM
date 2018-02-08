namespace Rubix.Screen.Form.Operation.H_Picking
{
    partial class frmHPCS040_PickingPlanList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHPCS040_PickingPlanList));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkCompleteTransport = new DevExpress.XtraEditors.CheckEdit();
            this.customerControl = new Rubix.Control.CustomerControl();
            this.requireField1 = new Rubix.Control.RequireField();
            this.requireField5 = new Rubix.Control.RequireField();
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
            this.gdcStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcShipmentNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcInstallment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcETD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPickingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPickingNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPalletNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPartCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcQtyUnitID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkActual = new DevExpress.XtraEditors.CheckEdit();
            this.chkPlan = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCompleteTransport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPlan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Size = new System.Drawing.Size(966, 47);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.chkActual);
            this.groupControl1.Controls.Add(this.chkPlan);
            this.groupControl1.Controls.Add(this.chkCompleteTransport);
            this.groupControl1.Controls.Add(this.customerControl);
            this.groupControl1.Controls.Add(this.requireField1);
            this.groupControl1.Controls.Add(this.requireField5);
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
            this.groupControl1.Size = new System.Drawing.Size(966, 98);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Search Criteria";
            // 
            // chkCompleteTransport
            // 
            this.chkCompleteTransport.Location = new System.Drawing.Point(613, 71);
            this.chkCompleteTransport.Name = "chkCompleteTransport";
            this.chkCompleteTransport.Properties.Caption = "Complete Transport";
            this.chkCompleteTransport.Size = new System.Drawing.Size(170, 19);
            this.chkCompleteTransport.TabIndex = 193;
            // 
            // customerControl
            // 
            this.customerControl.ErrorText = "Customer Control is Require Field";
            this.customerControl.Location = new System.Drawing.Point(86, 70);
            this.customerControl.Name = "customerControl";
            this.customerControl.OwnerID = null;
            this.customerControl.ReadOnly = false;
            this.customerControl.RequireField = false;
            this.customerControl.Size = new System.Drawing.Size(451, 21);
            this.customerControl.TabIndex = 190;
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
            // dtPickingDateTo
            // 
            this.dtPickingDateTo.EditValue = null;
            this.dtPickingDateTo.Location = new System.Drawing.Point(833, 25);
            this.dtPickingDateTo.Name = "dtPickingDateTo";
            this.dtPickingDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtPickingDateTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtPickingDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtPickingDateTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtPickingDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtPickingDateTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtPickingDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtPickingDateTo.Size = new System.Drawing.Size(123, 20);
            this.dtPickingDateTo.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(817, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 13);
            this.labelControl2.TabIndex = 113;
            this.labelControl2.Text = "To";
            // 
            // dtPickingDateFrom
            // 
            this.dtPickingDateFrom.EditValue = null;
            this.dtPickingDateFrom.Location = new System.Drawing.Point(688, 25);
            this.dtPickingDateFrom.Name = "dtPickingDateFrom";
            this.dtPickingDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtPickingDateFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtPickingDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtPickingDateFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtPickingDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtPickingDateFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtPickingDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtPickingDateFrom.Size = new System.Drawing.Size(123, 20);
            this.dtPickingDateFrom.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(542, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(131, 17);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Picking Date";
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
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(887, 67);
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
            this.btnSearch.Location = new System.Drawing.Point(806, 67);
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
            this.groupControl2.Location = new System.Drawing.Point(0, 176);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(966, 262);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "Search Result";
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSearchResult.Location = new System.Drawing.Point(2, 21);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.MenuManager = this.ribbonControl1;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.Size = new System.Drawing.Size(962, 239);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcStatus,
            this.gdcShipmentNo,
            this.gdcInstallment,
            this.gdcETD,
            this.gdcPickingDate,
            this.gdcPickingNo,
            this.gdcPalletNo,
            this.gdcLineNo,
            this.gdcPartCode,
            this.gdcQty,
            this.gdcQtyUnitID});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsCustomization.AllowGroup = false;
            this.gdvSearchResult.OptionsView.AllowCellMerge = true;
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            this.gdvSearchResult.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.gdvSearchResult_CellMerge);
            // 
            // gdcStatus
            // 
            this.gdcStatus.AppearanceCell.Options.UseTextOptions = true;
            this.gdcStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcStatus.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcStatus.AppearanceHeader.Options.UseFont = true;
            this.gdcStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcStatus.Caption = "Status";
            this.gdcStatus.FieldName = "StatusName";
            this.gdcStatus.Name = "gdcStatus";
            this.gdcStatus.Visible = true;
            this.gdcStatus.VisibleIndex = 0;
            // 
            // gdcShipmentNo
            // 
            this.gdcShipmentNo.AppearanceCell.Options.UseTextOptions = true;
            this.gdcShipmentNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcShipmentNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcShipmentNo.AppearanceHeader.Options.UseFont = true;
            this.gdcShipmentNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcShipmentNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcShipmentNo.Caption = "Shipment No.";
            this.gdcShipmentNo.FieldName = "ShipmentNo";
            this.gdcShipmentNo.Name = "gdcShipmentNo";
            this.gdcShipmentNo.Visible = true;
            this.gdcShipmentNo.VisibleIndex = 1;
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
            this.gdcInstallment.VisibleIndex = 2;
            // 
            // gdcETD
            // 
            this.gdcETD.AppearanceCell.Options.UseTextOptions = true;
            this.gdcETD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcETD.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcETD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcETD.AppearanceHeader.Options.UseFont = true;
            this.gdcETD.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcETD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcETD.Caption = "ETD";
            this.gdcETD.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gdcETD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcETD.FieldName = "ETD";
            this.gdcETD.Name = "gdcETD";
            this.gdcETD.Visible = true;
            this.gdcETD.VisibleIndex = 3;
            // 
            // gdcPickingDate
            // 
            this.gdcPickingDate.AppearanceCell.Options.UseTextOptions = true;
            this.gdcPickingDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPickingDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcPickingDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcPickingDate.AppearanceHeader.Options.UseFont = true;
            this.gdcPickingDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPickingDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPickingDate.Caption = "Picking Date";
            this.gdcPickingDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gdcPickingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcPickingDate.FieldName = "PickingDate";
            this.gdcPickingDate.Name = "gdcPickingDate";
            this.gdcPickingDate.Visible = true;
            this.gdcPickingDate.VisibleIndex = 4;
            // 
            // gdcPickingNo
            // 
            this.gdcPickingNo.AppearanceCell.Options.UseTextOptions = true;
            this.gdcPickingNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcPickingNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPickingNo.AppearanceHeader.Options.UseFont = true;
            this.gdcPickingNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPickingNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPickingNo.Caption = "Picking No.";
            this.gdcPickingNo.FieldName = "PickingNo";
            this.gdcPickingNo.Name = "gdcPickingNo";
            this.gdcPickingNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gdcPickingNo.Visible = true;
            this.gdcPickingNo.VisibleIndex = 5;
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
            this.gdcPalletNo.Visible = true;
            this.gdcPalletNo.VisibleIndex = 6;
            // 
            // gdcLineNo
            // 
            this.gdcLineNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcLineNo.AppearanceHeader.Options.UseFont = true;
            this.gdcLineNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcLineNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcLineNo.Caption = "Line No.";
            this.gdcLineNo.FieldName = "LineNo";
            this.gdcLineNo.Name = "gdcLineNo";
            this.gdcLineNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gdcLineNo.Visible = true;
            this.gdcLineNo.VisibleIndex = 7;
            // 
            // gdcPartCode
            // 
            this.gdcPartCode.AppearanceCell.Options.UseTextOptions = true;
            this.gdcPartCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcPartCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcPartCode.AppearanceHeader.Options.UseFont = true;
            this.gdcPartCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPartCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPartCode.Caption = "Part Code";
            this.gdcPartCode.FieldName = "ProductCode";
            this.gdcPartCode.Name = "gdcPartCode";
            this.gdcPartCode.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gdcPartCode.Visible = true;
            this.gdcPartCode.VisibleIndex = 8;
            // 
            // gdcQty
            // 
            this.gdcQty.AppearanceCell.Options.UseTextOptions = true;
            this.gdcQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gdcQty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcQty.AppearanceHeader.Options.UseFont = true;
            this.gdcQty.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcQty.Caption = "Qty";
            this.gdcQty.DisplayFormat.FormatString = "#,##0.##";
            this.gdcQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcQty.FieldName = "OrderQty";
            this.gdcQty.Name = "gdcQty";
            this.gdcQty.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gdcQty.Visible = true;
            this.gdcQty.VisibleIndex = 9;
            // 
            // gdcQtyUnitID
            // 
            this.gdcQtyUnitID.AppearanceCell.Options.UseTextOptions = true;
            this.gdcQtyUnitID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcQtyUnitID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcQtyUnitID.AppearanceHeader.Options.UseFont = true;
            this.gdcQtyUnitID.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcQtyUnitID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcQtyUnitID.Caption = "Unit Qty";
            this.gdcQtyUnitID.FieldName = "UnitCode";
            this.gdcQtyUnitID.Name = "gdcQtyUnitID";
            this.gdcQtyUnitID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gdcQtyUnitID.Visible = true;
            this.gdcQtyUnitID.VisibleIndex = 10;
            // 
            // chkActual
            // 
            this.chkActual.EditValue = true;
            this.chkActual.Location = new System.Drawing.Point(743, 48);
            this.chkActual.MenuManager = this.ribbonControl1;
            this.chkActual.Name = "chkActual";
            this.chkActual.Properties.Caption = "Actual";
            this.chkActual.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkActual.Properties.RadioGroupIndex = 1;
            this.chkActual.Size = new System.Drawing.Size(123, 19);
            this.chkActual.TabIndex = 200;
            // 
            // chkPlan
            // 
            this.chkPlan.Location = new System.Drawing.Point(614, 48);
            this.chkPlan.MenuManager = this.ribbonControl1;
            this.chkPlan.Name = "chkPlan";
            this.chkPlan.Properties.Caption = "Plan";
            this.chkPlan.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkPlan.Properties.RadioGroupIndex = 1;
            this.chkPlan.Size = new System.Drawing.Size(123, 19);
            this.chkPlan.TabIndex = 199;
            this.chkPlan.TabStop = false;
            // 
            // frmHPCS040_PickingPlanList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 438);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmHPCS040_PickingPlanList";
            this.Text = "FSES030 : Shipping Plan List";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkCompleteTransport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPlan.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Control.RequireField requireField1;
        private Control.RequireField requireField5;
        private DevExpress.XtraEditors.DateEdit dtPickingDateTo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dtPickingDateFrom;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Control.WarehouseControl warehouseControl;
        private Control.OwnerControl ownerControl;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private Control.CustomerControl customerControl;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraGrid.Columns.GridColumn gdcStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gdcShipmentNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcInstallment;
        private DevExpress.XtraGrid.Columns.GridColumn gdcETD;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPickingDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPartCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcQty;
        private DevExpress.XtraGrid.Columns.GridColumn gdcQtyUnitID;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPickingNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPalletNo;
        private DevExpress.XtraEditors.CheckEdit chkCompleteTransport;
        private DevExpress.XtraEditors.CheckEdit chkActual;
        private DevExpress.XtraEditors.CheckEdit chkPlan;
    }
}
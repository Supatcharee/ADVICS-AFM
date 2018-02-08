namespace Rubix.Screen.Form.Operation.I_Shipping
{
    partial class frmISHS070_ConfirmReturnShipping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmISHS070_ConfirmReturnShipping));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcShippingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcShipmentNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPickingNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcItemCondition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcQty2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUnit2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcQty3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUnit3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.defaultAssignQtyTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.chkSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.requireField2 = new Rubix.Control.RequireField();
            this.requireField1 = new Rubix.Control.RequireField();
            this.dtpShippingFrom = new DevExpress.XtraEditors.DateEdit();
            this.dtpShippingTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.customerControl = new Rubix.Control.CustomerControl();
            this.shipmentControl = new Rubix.Control.ShipmentControl();
            this.pickingControl = new Rubix.Control.PickingControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultAssignQtyTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpShippingFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpShippingFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpShippingTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpShippingTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Size = new System.Drawing.Size(1127, 47);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 175);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1127, 369);
            this.groupControl2.TabIndex = 1;
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
            this.defaultAssignQtyTextEdit,
            this.chkSelect});
            this.grdSearchResult.Size = new System.Drawing.Size(1115, 340);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcShippingDate,
            this.gdcShipmentNo,
            this.gdcPickingNo,
            this.gdcLineNo,
            this.gdcProductID,
            this.gdcItemCode,
            this.gdcItemName,
            this.gdcItemCondition,
            this.gdcQty2,
            this.gdcUnit2,
            this.gdcQty3,
            this.gdcUnit3});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsBehavior.Editable = false;
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            // 
            // gdcShippingDate
            // 
            this.gdcShippingDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcShippingDate.AppearanceHeader.Options.UseFont = true;
            this.gdcShippingDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcShippingDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcShippingDate.DisplayFormat.FormatString = "d";
            this.gdcShippingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcShippingDate.FieldName = "ShippingDate";
            this.gdcShippingDate.Name = "gdcShippingDate";
            this.gdcShippingDate.Visible = true;
            this.gdcShippingDate.VisibleIndex = 0;
            // 
            // gdcShipmentNo
            // 
            this.gdcShipmentNo.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcShipmentNo.AppearanceHeader.Options.UseFont = true;
            this.gdcShipmentNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcShipmentNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcShipmentNo.FieldName = "ShipmentNo";
            this.gdcShipmentNo.Name = "gdcShipmentNo";
            this.gdcShipmentNo.Visible = true;
            this.gdcShipmentNo.VisibleIndex = 1;
            // 
            // gdcPickingNo
            // 
            this.gdcPickingNo.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcPickingNo.AppearanceHeader.Options.UseFont = true;
            this.gdcPickingNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPickingNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPickingNo.FieldName = "PickingNo";
            this.gdcPickingNo.Name = "gdcPickingNo";
            this.gdcPickingNo.Visible = true;
            this.gdcPickingNo.VisibleIndex = 2;
            // 
            // gdcLineNo
            // 
            this.gdcLineNo.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcLineNo.AppearanceHeader.Options.UseFont = true;
            this.gdcLineNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcLineNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcLineNo.FieldName = "LineNo";
            this.gdcLineNo.Name = "gdcLineNo";
            this.gdcLineNo.OptionsColumn.ShowInCustomizationForm = false;
            this.gdcLineNo.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // gdcProductID
            // 
            this.gdcProductID.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcProductID.AppearanceHeader.Options.UseFont = true;
            this.gdcProductID.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcProductID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcProductID.FieldName = "ProductID";
            this.gdcProductID.Name = "gdcProductID";
            this.gdcProductID.OptionsColumn.ShowInCustomizationForm = false;
            this.gdcProductID.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // gdcItemCode
            // 
            this.gdcItemCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcItemCode.AppearanceHeader.Options.UseFont = true;
            this.gdcItemCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcItemCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcItemCode.FieldName = "ItemCode";
            this.gdcItemCode.Name = "gdcItemCode";
            this.gdcItemCode.Visible = true;
            this.gdcItemCode.VisibleIndex = 3;
            // 
            // gdcItemName
            // 
            this.gdcItemName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcItemName.AppearanceHeader.Options.UseFont = true;
            this.gdcItemName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcItemName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcItemName.FieldName = "ItemName";
            this.gdcItemName.Name = "gdcItemName";
            this.gdcItemName.Visible = true;
            this.gdcItemName.VisibleIndex = 4;
            // 
            // gdcItemCondition
            // 
            this.gdcItemCondition.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcItemCondition.AppearanceHeader.Options.UseFont = true;
            this.gdcItemCondition.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcItemCondition.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcItemCondition.FieldName = "ItemCondition";
            this.gdcItemCondition.Name = "gdcItemCondition";
            this.gdcItemCondition.Visible = true;
            this.gdcItemCondition.VisibleIndex = 5;
            // 
            // gdcQty2
            // 
            this.gdcQty2.AppearanceCell.Options.UseTextOptions = true;
            this.gdcQty2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gdcQty2.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcQty2.AppearanceHeader.Options.UseFont = true;
            this.gdcQty2.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcQty2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcQty2.Caption = "Qty";
            this.gdcQty2.DisplayFormat.FormatString = "#,##0.0000";
            this.gdcQty2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcQty2.FieldName = "Qty2";
            this.gdcQty2.Name = "gdcQty2";
            this.gdcQty2.Visible = true;
            this.gdcQty2.VisibleIndex = 6;
            // 
            // gdcUnit2
            // 
            this.gdcUnit2.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcUnit2.AppearanceHeader.Options.UseFont = true;
            this.gdcUnit2.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcUnit2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcUnit2.Caption = "Unit";
            this.gdcUnit2.FieldName = "Unit2";
            this.gdcUnit2.Name = "gdcUnit2";
            this.gdcUnit2.Visible = true;
            this.gdcUnit2.VisibleIndex = 7;
            // 
            // gdcQty3
            // 
            this.gdcQty3.AppearanceCell.Options.UseTextOptions = true;
            this.gdcQty3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gdcQty3.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcQty3.AppearanceHeader.Options.UseFont = true;
            this.gdcQty3.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcQty3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcQty3.Caption = "Qty";
            this.gdcQty3.DisplayFormat.FormatString = "#,##0.0000";
            this.gdcQty3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcQty3.FieldName = "Qty3";
            this.gdcQty3.Name = "gdcQty3";
            this.gdcQty3.Visible = true;
            this.gdcQty3.VisibleIndex = 8;
            // 
            // gdcUnit3
            // 
            this.gdcUnit3.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gdcUnit3.AppearanceHeader.Options.UseFont = true;
            this.gdcUnit3.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcUnit3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcUnit3.Caption = "Unit";
            this.gdcUnit3.FieldName = "Unit3";
            this.gdcUnit3.Name = "gdcUnit3";
            this.gdcUnit3.Visible = true;
            this.gdcUnit3.VisibleIndex = 9;
            // 
            // defaultAssignQtyTextEdit
            // 
            this.defaultAssignQtyTextEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.defaultAssignQtyTextEdit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.defaultAssignQtyTextEdit.Appearance.Options.UseBackColor = true;
            this.defaultAssignQtyTextEdit.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.defaultAssignQtyTextEdit.AppearanceFocused.Options.UseBackColor = true;
            this.defaultAssignQtyTextEdit.AutoHeight = false;
            this.defaultAssignQtyTextEdit.Mask.EditMask = "###,###,###,###,##0.000;###,###,###,###,##0.000";
            this.defaultAssignQtyTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.defaultAssignQtyTextEdit.Mask.UseMaskAsDisplayFormat = true;
            this.defaultAssignQtyTextEdit.Name = "defaultAssignQtyTextEdit";
            this.defaultAssignQtyTextEdit.ValidateOnEnterKey = true;
            // 
            // chkSelect
            // 
            this.chkSelect.AutoHeight = false;
            this.chkSelect.Name = "chkSelect";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(965, 68);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(1046, 68);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(59, 24);
            this.ownerControl.Name = "ownerControl";
            this.ownerControl.ReadOnly = false;
            this.ownerControl.RequireField = false;
            this.ownerControl.Size = new System.Drawing.Size(449, 21);
            this.ownerControl.TabIndex = 0;
            this.ownerControl.EditValueChanged += new System.EventHandler(this.ownerControl_EditValueChanged);
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(45, 68);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(464, 21);
            this.warehouseControl.TabIndex = 2;
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(108, 31);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 46;
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(108, 75);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 47;
            // 
            // dtpShippingFrom
            // 
            this.dtpShippingFrom.EditValue = null;
            this.dtpShippingFrom.Location = new System.Drawing.Point(686, 70);
            this.dtpShippingFrom.MenuManager = this.ribbonControl1;
            this.dtpShippingFrom.Name = "dtpShippingFrom";
            this.dtpShippingFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpShippingFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpShippingFrom.Size = new System.Drawing.Size(124, 20);
            this.dtpShippingFrom.TabIndex = 5;
            this.dtpShippingFrom.EditValueChanged += new System.EventHandler(this.dtpShippingFrom_EditValueChanged);
            // 
            // dtpShippingTo
            // 
            this.dtpShippingTo.EditValue = null;
            this.dtpShippingTo.Location = new System.Drawing.Point(835, 70);
            this.dtpShippingTo.MenuManager = this.ribbonControl1;
            this.dtpShippingTo.Name = "dtpShippingTo";
            this.dtpShippingTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpShippingTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpShippingTo.Size = new System.Drawing.Size(124, 20);
            this.dtpShippingTo.TabIndex = 6;
            this.dtpShippingTo.EditValueChanged += new System.EventHandler(this.dtpShippingTo_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(523, 71);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(151, 18);
            this.labelControl3.TabIndex = 136;
            this.labelControl3.Text = "Shipping Date";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(817, 74);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 13);
            this.labelControl2.TabIndex = 137;
            this.labelControl2.Text = "To";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.customerControl);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.dtpShippingTo);
            this.groupControl1.Controls.Add(this.dtpShippingFrom);
            this.groupControl1.Controls.Add(this.requireField1);
            this.groupControl1.Controls.Add(this.requireField2);
            this.groupControl1.Controls.Add(this.shipmentControl);
            this.groupControl1.Controls.Add(this.pickingControl);
            this.groupControl1.Controls.Add(this.warehouseControl);
            this.groupControl1.Controls.Add(this.ownerControl);
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 78);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1127, 97);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Search Criteria";
            // 
            // customerControl
            // 
            this.customerControl.ErrorText = "Customer Control is Require Field";
            this.customerControl.Location = new System.Drawing.Point(57, 46);
            this.customerControl.Name = "customerControl";
            this.customerControl.OwnerID = null;
            this.customerControl.ReadOnly = false;
            this.customerControl.RequireField = false;
            this.customerControl.Size = new System.Drawing.Size(451, 21);
            this.customerControl.TabIndex = 1;
            this.customerControl.EditValueChanged += new System.EventHandler(this.customerControl_EditValueChanged);
            // 
            // shipmentControl
            // 
            this.shipmentControl.ErrorText = "Shipment Control is Require Field";
            this.shipmentControl.Location = new System.Drawing.Point(551, 24);
            this.shipmentControl.Name = "shipmentControl";
            this.shipmentControl.RequireField = false;
            this.shipmentControl.Size = new System.Drawing.Size(408, 22);
            this.shipmentControl.TabIndex = 3;
            this.shipmentControl.EditValueChanged += new System.EventHandler(this.shipmentControl_EditValueChanged);
            // 
            // pickingControl
            // 
            this.pickingControl.ComboType = Rubix.Control.PickingControl.eComboType.Screen;
            this.pickingControl.ErrorText = "Picking Control is Require Field";
            this.pickingControl.Location = new System.Drawing.Point(555, 47);
            this.pickingControl.Name = "pickingControl";
            this.pickingControl.OwnerID = null;
            this.pickingControl.RequireField = false;
            this.pickingControl.Size = new System.Drawing.Size(403, 22);
            this.pickingControl.TabIndex = 4;
            this.pickingControl.WarehouseID = null;
            // 
            // frmISHS070_ConfirmReturnShipping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 544);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmISHS070_ConfirmReturnShipping";
            this.Text = "ISHS070 : Confirm Return Shipping";
            this.Load += new System.EventHandler(this.frmISHS070_ConfirmReturnShipping_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultAssignQtyTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpShippingFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpShippingFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpShippingTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpShippingTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit defaultAssignQtyTextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gdcShippingDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcShipmentNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPickingNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcProductID;
        private DevExpress.XtraGrid.Columns.GridColumn gdcItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcItemName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcItemCondition;
        private DevExpress.XtraGrid.Columns.GridColumn gdcQty2;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUnit2;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private Control.OwnerControl ownerControl;
        private Control.WarehouseControl warehouseControl;
        private Control.RequireField requireField2;
        private Control.RequireField requireField1;
        private DevExpress.XtraEditors.DateEdit dtpShippingFrom;
        private DevExpress.XtraEditors.DateEdit dtpShippingTo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Control.ShipmentControl shipmentControl;
        private Control.PickingControl pickingControl;
        private Control.CustomerControl customerControl;
        private DevExpress.XtraGrid.Columns.GridColumn gdcQty3;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUnit3;
    }
}
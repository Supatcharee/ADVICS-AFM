namespace Rubix.Screen.Form.Operation.E_Stocktaking.Dialog
{
    partial class dlgESTS010_CorrectInventory
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.requireField2 = new Rubix.Control.RequireField();
            this.zoneControl = new Rubix.Control.ZoneControl();
            this.cboLocationCode = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.GridSearchLocationCode = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcLocationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcMaxCapacity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcAvailableCapacity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.requireField8 = new Rubix.Control.RequireField();
            this.requireField1 = new Rubix.Control.RequireField();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.requireField3 = new Rubix.Control.RequireField();
            this.itemControl = new Rubix.Control.ItemControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.deExpiryDate = new DevExpress.XtraEditors.DateEdit();
            this.chkFullCapacity = new DevExpress.XtraEditors.CheckEdit();
            this.requireField4 = new Rubix.Control.RequireField();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.cboAdjustUnit = new DevExpress.XtraEditors.LookUpEdit();
            this.lblAfterAdjustUnit = new DevExpress.XtraEditors.LabelControl();
            this.lblInventoryUnit = new DevExpress.XtraEditors.LabelControl();
            this.requireField5 = new Rubix.Control.RequireField();
            this.txtAdjust = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtInventory = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.txtAfterAdjust = new DevExpress.XtraEditors.TextEdit();
            this.itemConditionControl = new Rubix.Control.ItemConditionControl();
            this.cboLotNo = new DevExpress.XtraEditors.MRUEdit();
            this.requireField7 = new Rubix.Control.RequireField();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.requireField6 = new Rubix.Control.RequireField();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLocationCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearchLocationCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deExpiryDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deExpiryDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFullCapacity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAdjustUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdjust.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInventory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAfterAdjust.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLotNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.requireField2);
            this.groupControl1.Controls.Add(this.zoneControl);
            this.groupControl1.Controls.Add(this.cboLocationCode);
            this.groupControl1.Controls.Add(this.requireField8);
            this.groupControl1.Controls.Add(this.requireField1);
            this.groupControl1.Controls.Add(this.ownerControl);
            this.groupControl1.Controls.Add(this.warehouseControl);
            this.groupControl1.Controls.Add(this.requireField3);
            this.groupControl1.Controls.Add(this.itemControl);
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Location = new System.Drawing.Point(4, 35);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(816, 151);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Correction of Inventory Header";
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(114, 100);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 73;
            // 
            // zoneControl
            // 
            this.zoneControl.ErrorText = "Zone Control is Require Field";
            this.zoneControl.Location = new System.Drawing.Point(52, 95);
            this.zoneControl.Name = "zoneControl";
            this.zoneControl.RequireField = false;
            this.zoneControl.Size = new System.Drawing.Size(438, 21);
            this.zoneControl.TabIndex = 3;
            this.zoneControl.EditValueChanged += new System.EventHandler(this.zoneControl_EditValueChanged);
            // 
            // cboLocationCode
            // 
            this.cboLocationCode.EditValue = "";
            this.cboLocationCode.Location = new System.Drawing.Point(125, 119);
            this.cboLocationCode.Name = "cboLocationCode";
            this.cboLocationCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLocationCode.Properties.NullText = "";
            this.cboLocationCode.Properties.View = this.GridSearchLocationCode;
            this.cboLocationCode.Size = new System.Drawing.Size(123, 20);
            this.cboLocationCode.TabIndex = 4;
            // 
            // GridSearchLocationCode
            // 
            this.GridSearchLocationCode.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcLocationCode,
            this.gdcMaxCapacity,
            this.gdcAvailableCapacity});
            this.GridSearchLocationCode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridSearchLocationCode.Name = "GridSearchLocationCode";
            this.GridSearchLocationCode.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridSearchLocationCode.OptionsView.ShowGroupPanel = false;
            // 
            // gdcLocationCode
            // 
            this.gdcLocationCode.Caption = "Location Code";
            this.gdcLocationCode.FieldName = "LocationCode";
            this.gdcLocationCode.Name = "gdcLocationCode";
            this.gdcLocationCode.Visible = true;
            this.gdcLocationCode.VisibleIndex = 0;
            // 
            // gdcMaxCapacity
            // 
            this.gdcMaxCapacity.Caption = "Max Capacity";
            this.gdcMaxCapacity.FieldName = "MaxCapacity";
            this.gdcMaxCapacity.Name = "gdcMaxCapacity";
            this.gdcMaxCapacity.Visible = true;
            this.gdcMaxCapacity.VisibleIndex = 1;
            // 
            // gdcAvailableCapacity
            // 
            this.gdcAvailableCapacity.Caption = "Available Capacity";
            this.gdcAvailableCapacity.FieldName = "AvailableCapacity";
            this.gdcAvailableCapacity.Name = "gdcAvailableCapacity";
            this.gdcAvailableCapacity.Visible = true;
            this.gdcAvailableCapacity.VisibleIndex = 2;
            // 
            // requireField8
            // 
            this.requireField8.Location = new System.Drawing.Point(114, 53);
            this.requireField8.Name = "requireField8";
            this.requireField8.Size = new System.Drawing.Size(10, 10);
            this.requireField8.TabIndex = 71;
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(114, 30);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 70;
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
            this.ownerControl.Size = new System.Drawing.Size(424, 21);
            this.ownerControl.TabIndex = 0;
            this.ownerControl.EditValueChanged += new System.EventHandler(this.ownerControl_EditValueChanged);
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(50, 48);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(440, 21);
            this.warehouseControl.TabIndex = 1;
            this.warehouseControl.EditValueChanged += new System.EventHandler(this.warehouseControl_EditValueChanged);
            // 
            // requireField3
            // 
            this.requireField3.Location = new System.Drawing.Point(114, 78);
            this.requireField3.Name = "requireField3";
            this.requireField3.Size = new System.Drawing.Size(10, 10);
            this.requireField3.TabIndex = 72;
            // 
            // itemControl
            // 
            this.itemControl.ErrorText = "Item Control is Require Field";
            this.itemControl.Location = new System.Drawing.Point(83, 72);
            this.itemControl.Name = "itemControl";
            this.itemControl.RequireField = false;
            this.itemControl.Size = new System.Drawing.Size(406, 22);
            this.itemControl.TabIndex = 2;
            this.itemControl.EditValueChanged += new System.EventHandler(this.itemControl_EditValueChanged);
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl11.Location = new System.Drawing.Point(0, 121);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(114, 17);
            this.labelControl11.TabIndex = 50;
            this.labelControl11.Text = "Location Code";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.requireField6);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.txtRemark);
            this.groupControl2.Controls.Add(this.labelControl8);
            this.groupControl2.Controls.Add(this.deExpiryDate);
            this.groupControl2.Controls.Add(this.chkFullCapacity);
            this.groupControl2.Controls.Add(this.requireField4);
            this.groupControl2.Controls.Add(this.groupControl3);
            this.groupControl2.Controls.Add(this.itemConditionControl);
            this.groupControl2.Location = new System.Drawing.Point(4, 192);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(816, 165);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Correction of Inventory Detail";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(11, 79);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(103, 13);
            this.labelControl4.TabIndex = 118;
            this.labelControl4.Text = "Remark";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(125, 76);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(318, 82);
            this.txtRemark.TabIndex = 3;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.Location = new System.Drawing.Point(10, 57);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(103, 13);
            this.labelControl8.TabIndex = 116;
            this.labelControl8.Text = "Expiry Date";
            // 
            // deExpiryDate
            // 
            this.deExpiryDate.EditValue = null;
            this.deExpiryDate.Location = new System.Drawing.Point(125, 54);
            this.deExpiryDate.Name = "deExpiryDate";
            this.deExpiryDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deExpiryDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.deExpiryDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deExpiryDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.deExpiryDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deExpiryDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deExpiryDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deExpiryDate.Size = new System.Drawing.Size(123, 20);
            this.deExpiryDate.TabIndex = 2;
            // 
            // chkFullCapacity
            // 
            this.chkFullCapacity.Location = new System.Drawing.Point(123, 164);
            this.chkFullCapacity.Name = "chkFullCapacity";
            this.chkFullCapacity.Properties.Caption = "Full Capacity of Location";
            this.chkFullCapacity.Size = new System.Drawing.Size(308, 19);
            this.chkFullCapacity.TabIndex = 4;
            // 
            // requireField4
            // 
            this.requireField4.Location = new System.Drawing.Point(114, 35);
            this.requireField4.Name = "requireField4";
            this.requireField4.Size = new System.Drawing.Size(10, 13);
            this.requireField4.TabIndex = 73;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.cboAdjustUnit);
            this.groupControl3.Controls.Add(this.lblAfterAdjustUnit);
            this.groupControl3.Controls.Add(this.lblInventoryUnit);
            this.groupControl3.Controls.Add(this.requireField5);
            this.groupControl3.Controls.Add(this.txtAdjust);
            this.groupControl3.Controls.Add(this.labelControl12);
            this.groupControl3.Controls.Add(this.txtInventory);
            this.groupControl3.Controls.Add(this.labelControl14);
            this.groupControl3.Controls.Add(this.labelControl13);
            this.groupControl3.Controls.Add(this.txtAfterAdjust);
            this.groupControl3.Location = new System.Drawing.Point(449, 32);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(362, 127);
            this.groupControl3.TabIndex = 8;
            this.groupControl3.Text = "Adjustment";
            // 
            // cboAdjustUnit
            // 
            this.cboAdjustUnit.Location = new System.Drawing.Point(245, 23);
            this.cboAdjustUnit.Name = "cboAdjustUnit";
            this.cboAdjustUnit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAdjustUnit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitID", "Unit ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitCode", "Unit Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitName", "Unit Name")});
            this.cboAdjustUnit.Properties.NullText = "";
            this.cboAdjustUnit.Properties.PopupSizeable = false;
            this.cboAdjustUnit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cboAdjustUnit.Size = new System.Drawing.Size(103, 20);
            this.cboAdjustUnit.TabIndex = 1;
            this.cboAdjustUnit.EditValueChanged += new System.EventHandler(this.cboAdjustUnit_EditValueChanged);
            // 
            // lblAfterAdjustUnit
            // 
            this.lblAfterAdjustUnit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblAfterAdjustUnit.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAfterAdjustUnit.Location = new System.Drawing.Point(245, 73);
            this.lblAfterAdjustUnit.Name = "lblAfterAdjustUnit";
            this.lblAfterAdjustUnit.Size = new System.Drawing.Size(103, 13);
            this.lblAfterAdjustUnit.TabIndex = 120;
            // 
            // lblInventoryUnit
            // 
            this.lblInventoryUnit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblInventoryUnit.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblInventoryUnit.Location = new System.Drawing.Point(245, 50);
            this.lblInventoryUnit.Name = "lblInventoryUnit";
            this.lblInventoryUnit.Size = new System.Drawing.Size(103, 13);
            this.lblInventoryUnit.TabIndex = 119;
            // 
            // requireField5
            // 
            this.requireField5.Location = new System.Drawing.Point(111, 28);
            this.requireField5.Name = "requireField5";
            this.requireField5.Size = new System.Drawing.Size(10, 10);
            this.requireField5.TabIndex = 111;
            // 
            // txtAdjust
            // 
            this.txtAdjust.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAdjust.Location = new System.Drawing.Point(123, 23);
            this.txtAdjust.Name = "txtAdjust";
            this.txtAdjust.Properties.Mask.EditMask = "n3";
            this.txtAdjust.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtAdjust.Properties.MaxValue = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            196608});
            this.txtAdjust.Properties.MinValue = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            -2147287040});
            this.txtAdjust.Size = new System.Drawing.Size(116, 20);
            this.txtAdjust.TabIndex = 0;
            this.txtAdjust.EditValueChanged += new System.EventHandler(this.txtAdjust_EditValueChanged);
            this.txtAdjust.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.txtAdjust_EditValueChanging);
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl12.Location = new System.Drawing.Point(5, 25);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(104, 17);
            this.labelControl12.TabIndex = 55;
            this.labelControl12.Text = "Adjustment";
            // 
            // txtInventory
            // 
            this.txtInventory.Location = new System.Drawing.Point(123, 46);
            this.txtInventory.Name = "txtInventory";
            this.txtInventory.Properties.Appearance.Options.UseTextOptions = true;
            this.txtInventory.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtInventory.Properties.Mask.EditMask = "n3";
            this.txtInventory.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtInventory.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtInventory.Properties.ReadOnly = true;
            this.txtInventory.Size = new System.Drawing.Size(116, 20);
            this.txtInventory.TabIndex = 0;
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl14.Location = new System.Drawing.Point(-4, 69);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(113, 17);
            this.labelControl14.TabIndex = 57;
            this.labelControl14.Text = "After Adjustment";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl13.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl13.Location = new System.Drawing.Point(-4, 48);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(113, 17);
            this.labelControl13.TabIndex = 53;
            this.labelControl13.Text = "Inventory";
            // 
            // txtAfterAdjust
            // 
            this.txtAfterAdjust.Location = new System.Drawing.Point(123, 68);
            this.txtAfterAdjust.Name = "txtAfterAdjust";
            this.txtAfterAdjust.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAfterAdjust.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtAfterAdjust.Properties.Mask.EditMask = "n3";
            this.txtAfterAdjust.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAfterAdjust.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtAfterAdjust.Properties.ReadOnly = true;
            this.txtAfterAdjust.Size = new System.Drawing.Size(116, 20);
            this.txtAfterAdjust.TabIndex = 2;
            // 
            // itemConditionControl
            // 
            this.itemConditionControl.Appearance.Options.UseTextOptions = true;
            this.itemConditionControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.itemConditionControl.ErrorText = "Item Condition Control is Require Field";
            this.itemConditionControl.Location = new System.Drawing.Point(23, 30);
            this.itemConditionControl.Name = "itemConditionControl";
            this.itemConditionControl.ProductID = null;
            this.itemConditionControl.RequireField = false;
            this.itemConditionControl.Size = new System.Drawing.Size(419, 24);
            this.itemConditionControl.TabIndex = 0;
            this.itemConditionControl.EditValueChanged += new System.EventHandler(this.itemConditionControl_EditValueChanged);
            // 
            // cboLotNo
            // 
            this.cboLotNo.Location = new System.Drawing.Point(653, 326);
            this.cboLotNo.Name = "cboLotNo";
            this.cboLotNo.Properties.AllowRemoveMRUItems = false;
            this.cboLotNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLotNo.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.cboLotNo.Properties.Sorted = true;
            this.cboLotNo.Size = new System.Drawing.Size(123, 20);
            this.cboLotNo.TabIndex = 1;
            this.cboLotNo.Visible = false;
            // 
            // requireField7
            // 
            this.requireField7.Location = new System.Drawing.Point(641, 331);
            this.requireField7.Name = "requireField7";
            this.requireField7.Size = new System.Drawing.Size(10, 10);
            this.requireField7.TabIndex = 78;
            this.requireField7.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(528, 329);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(114, 17);
            this.labelControl3.TabIndex = 77;
            this.labelControl3.Text = "Lot No.";
            this.labelControl3.Visible = false;
            // 
            // requireField6
            // 
            this.requireField6.Location = new System.Drawing.Point(114, 80);
            this.requireField6.Name = "requireField6";
            this.requireField6.Size = new System.Drawing.Size(10, 13);
            this.requireField6.TabIndex = 119;
            // 
            // dlgESTS010_CorrectInventory
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 387);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.cboLotNo);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.requireField7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgESTS010_CorrectInventory";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ESTS011 : Inventory Adjustment Dialog";
            this.Load += new System.EventHandler(this.dlgESTS010_CorrectInventory_Load);
            this.Controls.SetChildIndex(this.requireField7, 0);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            this.Controls.SetChildIndex(this.cboLotNo, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboLocationCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearchLocationCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deExpiryDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deExpiryDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFullCapacity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboAdjustUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdjust.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInventory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAfterAdjust.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLotNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtInventory;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.TextEdit txtAfterAdjust;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private Rubix.Control.OwnerControl ownerControl;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private Rubix.Control.ItemConditionControl itemConditionControl;
        private Rubix.Control.ItemControl itemControl;
        private Rubix.Control.WarehouseControl warehouseControl;
        private Rubix.Control.RequireField requireField1;
        private Rubix.Control.RequireField requireField4;
        private Rubix.Control.RequireField requireField3;
        private Rubix.Control.RequireField requireField7;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit txtAdjust;
        private Rubix.Control.RequireField requireField2;
        private Rubix.Control.RequireField requireField8;
        private DevExpress.XtraEditors.CheckEdit chkFullCapacity;
        private Rubix.Control.RequireField requireField5;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.DateEdit deExpiryDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.LabelControl lblAfterAdjustUnit;
        private DevExpress.XtraEditors.LabelControl lblInventoryUnit;
        private DevExpress.XtraEditors.SearchLookUpEdit cboLocationCode;
        private DevExpress.XtraGrid.Views.Grid.GridView GridSearchLocationCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLocationCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcMaxCapacity;
        private DevExpress.XtraGrid.Columns.GridColumn gdcAvailableCapacity;
        private Rubix.Control.ZoneControl zoneControl;
        private DevExpress.XtraEditors.LookUpEdit cboAdjustUnit;
        private DevExpress.XtraEditors.MRUEdit cboLotNo;
        private Control.RequireField requireField6;
    }
}
namespace Rubix.Screen.Form.Operation.E_Stocktaking
{
    partial class frmESTS040_StockChecking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmESTS040_StockChecking));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.itemControl = new Rubix.Control.ItemControl();
            this.dteCheckingTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dteCheckingDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.requireField3 = new Rubix.Control.RequireField();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.requireField2 = new Rubix.Control.RequireField();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.rdbDifferent = new System.Windows.Forms.RadioButton();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcConditionOfItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcInventoryQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcActualQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCheckedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCheckedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDiff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteCheckingTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteCheckingTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteCheckingDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteCheckingDateFrom.Properties)).BeginInit();
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
            this.ribbonControl1.Size = new System.Drawing.Size(866, 47);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.itemControl);
            this.groupControl1.Controls.Add(this.dteCheckingTo);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.dteCheckingDateFrom);
            this.groupControl1.Controls.Add(this.requireField3);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.requireField2);
            this.groupControl1.Controls.Add(this.ownerControl);
            this.groupControl1.Controls.Add(this.rdbDifferent);
            this.groupControl1.Controls.Add(this.rdbAll);
            this.groupControl1.Controls.Add(this.warehouseControl);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 78);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(866, 156);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Search Criteria";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(782, 111);
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
            this.btnSearch.Location = new System.Drawing.Point(701, 111);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // itemControl
            // 
            this.itemControl.ErrorText = "Item Control is Require Field";
            this.itemControl.Location = new System.Drawing.Point(66, 111);
            this.itemControl.Name = "itemControl";
            this.itemControl.RequireField = false;
            this.itemControl.Size = new System.Drawing.Size(400, 22);
            this.itemControl.TabIndex = 7;
            // 
            // dteCheckingTo
            // 
            this.dteCheckingTo.EditValue = null;
            this.dteCheckingTo.Location = new System.Drawing.Point(252, 90);
            this.dteCheckingTo.MenuManager = this.ribbonControl1;
            this.dteCheckingTo.Name = "dteCheckingTo";
            this.dteCheckingTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteCheckingTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteCheckingTo.Size = new System.Drawing.Size(123, 20);
            this.dteCheckingTo.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(236, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 13);
            this.labelControl2.TabIndex = 50;
            this.labelControl2.Text = "To";
            // 
            // dteCheckingDateFrom
            // 
            this.dteCheckingDateFrom.EditValue = null;
            this.dteCheckingDateFrom.Location = new System.Drawing.Point(107, 90);
            this.dteCheckingDateFrom.MenuManager = this.ribbonControl1;
            this.dteCheckingDateFrom.Name = "dteCheckingDateFrom";
            this.dteCheckingDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteCheckingDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteCheckingDateFrom.Size = new System.Drawing.Size(123, 20);
            this.dteCheckingDateFrom.TabIndex = 5;
            // 
            // requireField3
            // 
            this.requireField3.Location = new System.Drawing.Point(97, 95);
            this.requireField3.Name = "requireField3";
            this.requireField3.Size = new System.Drawing.Size(10, 10);
            this.requireField3.TabIndex = 48;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(22, 93);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 13);
            this.labelControl1.TabIndex = 47;
            this.labelControl1.Text = "Checking Date";
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(97, 74);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 45;
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(47, 47);
            this.ownerControl.Name = "ownerControl";
            this.ownerControl.ReadOnly = false;
            this.ownerControl.RequireField = false;
            this.ownerControl.Size = new System.Drawing.Size(419, 21);
            this.ownerControl.TabIndex = 3;
            this.ownerControl.Enter += new System.EventHandler(this.customerControl_Enter);
            this.ownerControl.Leave += new System.EventHandler(this.customerControl_Leave);
            // 
            // rdbDifferent
            // 
            this.rdbDifferent.AutoSize = true;
            this.rdbDifferent.Location = new System.Drawing.Point(176, 24);
            this.rdbDifferent.Name = "rdbDifferent";
            this.rdbDifferent.Size = new System.Drawing.Size(91, 17);
            this.rdbDifferent.TabIndex = 2;
            this.rdbDifferent.Text = "Different only";
            this.rdbDifferent.UseVisualStyleBackColor = true;
            this.rdbDifferent.CheckedChanged += new System.EventHandler(this.rdbDifferent_CheckedChanged);
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Checked = true;
            this.rdbAll.Location = new System.Drawing.Point(105, 24);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(36, 17);
            this.rdbAll.TabIndex = 1;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "All";
            this.rdbAll.UseVisualStyleBackColor = true;
            this.rdbAll.CheckedChanged += new System.EventHandler(this.rdbAll_CheckedChanged);
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(33, 68);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(434, 21);
            this.warehouseControl.TabIndex = 4;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 234);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(866, 256);
            this.groupControl2.TabIndex = 30;
            this.groupControl2.Text = "Search Result";
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSearchResult.Location = new System.Drawing.Point(7, 26);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.Size = new System.Drawing.Size(853, 223);
            this.grdSearchResult.TabIndex = 1;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcItemCode,
            this.grcItemName,
            this.grcConditionOfItem,
            this.grcLocation,
            this.grcLotNo,
            this.grcInventoryQty,
            this.grcActualQty,
            this.grcCheckedBy,
            this.grcCheckedDate,
            this.grcDiff,
            this.gridRemark});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsBehavior.AutoPopulateColumns = false;
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            this.gdvSearchResult.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gdvSearchResult_RowCellStyle);
            // 
            // grcItemCode
            // 
            this.grcItemCode.AppearanceCell.Options.UseTextOptions = true;
            this.grcItemCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grcItemCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcItemCode.AppearanceHeader.Options.UseFont = true;
            this.grcItemCode.AppearanceHeader.Options.UseTextOptions = true;
            this.grcItemCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcItemCode.Caption = "Item Code";
            this.grcItemCode.FieldName = "ProductCode";
            this.grcItemCode.Name = "grcItemCode";
            this.grcItemCode.Visible = true;
            this.grcItemCode.VisibleIndex = 0;
            // 
            // grcItemName
            // 
            this.grcItemName.AppearanceCell.Options.UseTextOptions = true;
            this.grcItemName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grcItemName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcItemName.AppearanceHeader.Options.UseFont = true;
            this.grcItemName.AppearanceHeader.Options.UseTextOptions = true;
            this.grcItemName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcItemName.Caption = "Item Name";
            this.grcItemName.FieldName = "ProductLongName";
            this.grcItemName.Name = "grcItemName";
            this.grcItemName.Visible = true;
            this.grcItemName.VisibleIndex = 1;
            // 
            // grcConditionOfItem
            // 
            this.grcConditionOfItem.AppearanceCell.Options.UseTextOptions = true;
            this.grcConditionOfItem.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grcConditionOfItem.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcConditionOfItem.AppearanceHeader.Options.UseFont = true;
            this.grcConditionOfItem.AppearanceHeader.Options.UseTextOptions = true;
            this.grcConditionOfItem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcConditionOfItem.Caption = "Item Condition";
            this.grcConditionOfItem.FieldName = "ProductConditionName";
            this.grcConditionOfItem.Name = "grcConditionOfItem";
            this.grcConditionOfItem.Visible = true;
            this.grcConditionOfItem.VisibleIndex = 2;
            // 
            // grcLocation
            // 
            this.grcLocation.AppearanceCell.Options.UseTextOptions = true;
            this.grcLocation.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grcLocation.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcLocation.AppearanceHeader.Options.UseFont = true;
            this.grcLocation.AppearanceHeader.Options.UseTextOptions = true;
            this.grcLocation.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcLocation.Caption = "Location Code";
            this.grcLocation.FieldName = "LocationCode";
            this.grcLocation.Name = "grcLocation";
            this.grcLocation.Visible = true;
            this.grcLocation.VisibleIndex = 3;
            // 
            // grcLotNo
            // 
            this.grcLotNo.AppearanceCell.Options.UseTextOptions = true;
            this.grcLotNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grcLotNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcLotNo.AppearanceHeader.Options.UseFont = true;
            this.grcLotNo.AppearanceHeader.Options.UseTextOptions = true;
            this.grcLotNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcLotNo.Caption = "Lot No.";
            this.grcLotNo.FieldName = "LotNo";
            this.grcLotNo.Name = "grcLotNo";
            this.grcLotNo.Visible = true;
            this.grcLotNo.VisibleIndex = 4;
            // 
            // grcInventoryQty
            // 
            this.grcInventoryQty.AppearanceCell.Options.UseTextOptions = true;
            this.grcInventoryQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcInventoryQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcInventoryQty.AppearanceHeader.Options.UseFont = true;
            this.grcInventoryQty.AppearanceHeader.Options.UseTextOptions = true;
            this.grcInventoryQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcInventoryQty.Caption = "Inventory Qty";
            this.grcInventoryQty.DisplayFormat.FormatString = "n2";
            this.grcInventoryQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcInventoryQty.FieldName = "InventoryQty";
            this.grcInventoryQty.Name = "grcInventoryQty";
            this.grcInventoryQty.Visible = true;
            this.grcInventoryQty.VisibleIndex = 5;
            // 
            // grcActualQty
            // 
            this.grcActualQty.AppearanceCell.Options.UseTextOptions = true;
            this.grcActualQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grcActualQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcActualQty.AppearanceHeader.Options.UseFont = true;
            this.grcActualQty.AppearanceHeader.Options.UseTextOptions = true;
            this.grcActualQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcActualQty.Caption = "Actual Qty";
            this.grcActualQty.DisplayFormat.FormatString = "n2";
            this.grcActualQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcActualQty.FieldName = "CheckedQty";
            this.grcActualQty.Name = "grcActualQty";
            this.grcActualQty.Visible = true;
            this.grcActualQty.VisibleIndex = 6;
            // 
            // grcCheckedBy
            // 
            this.grcCheckedBy.AppearanceCell.Options.UseTextOptions = true;
            this.grcCheckedBy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grcCheckedBy.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcCheckedBy.AppearanceHeader.Options.UseFont = true;
            this.grcCheckedBy.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCheckedBy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCheckedBy.Caption = "Checked By";
            this.grcCheckedBy.FieldName = "CheckedBy";
            this.grcCheckedBy.Name = "grcCheckedBy";
            this.grcCheckedBy.Visible = true;
            this.grcCheckedBy.VisibleIndex = 7;
            // 
            // grcCheckedDate
            // 
            this.grcCheckedDate.AppearanceCell.Options.UseTextOptions = true;
            this.grcCheckedDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grcCheckedDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcCheckedDate.AppearanceHeader.Options.UseFont = true;
            this.grcCheckedDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCheckedDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCheckedDate.Caption = "Checked Date";
            this.grcCheckedDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.grcCheckedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcCheckedDate.FieldName = "CheckedDate";
            this.grcCheckedDate.Name = "grcCheckedDate";
            this.grcCheckedDate.Visible = true;
            this.grcCheckedDate.VisibleIndex = 8;
            // 
            // grcDiff
            // 
            this.grcDiff.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcDiff.AppearanceHeader.Options.UseFont = true;
            this.grcDiff.AppearanceHeader.Options.UseTextOptions = true;
            this.grcDiff.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcDiff.Caption = "DiffFlag";
            this.grcDiff.FieldName = "DiffFlag";
            this.grcDiff.Name = "grcDiff";
            // 
            // gridRemark
            // 
            this.gridRemark.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridRemark.AppearanceHeader.Options.UseFont = true;
            this.gridRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.gridRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridRemark.Caption = "Remark";
            this.gridRemark.FieldName = "Remark";
            this.gridRemark.Name = "gridRemark";
            this.gridRemark.Visible = true;
            this.gridRemark.VisibleIndex = 9;
            // 
            // frmESTS040_StockChecking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 490);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmESTS040_StockChecking";
            this.Text = "ESTS040 : Stock Checking";
            this.Load += new System.EventHandler(this.frmESTS040_StockChecking_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteCheckingTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteCheckingTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteCheckingDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteCheckingDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.RadioButton rdbDifferent;
        private System.Windows.Forms.RadioButton rdbAll;
        private Control.OwnerControl ownerControl;
        private Control.ItemControl itemControl;
        private DevExpress.XtraEditors.DateEdit dteCheckingTo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dteCheckingDateFrom;
        private Control.RequireField requireField3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Control.RequireField requireField2;
        private Control.WarehouseControl warehouseControl;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraGrid.Columns.GridColumn grcItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn grcItemName;
        private DevExpress.XtraGrid.Columns.GridColumn grcConditionOfItem;
        private DevExpress.XtraGrid.Columns.GridColumn grcLocation;
        private DevExpress.XtraGrid.Columns.GridColumn grcLotNo;
        private DevExpress.XtraGrid.Columns.GridColumn grcInventoryQty;
        private DevExpress.XtraGrid.Columns.GridColumn grcActualQty;
        private DevExpress.XtraGrid.Columns.GridColumn grcCheckedBy;
        private DevExpress.XtraGrid.Columns.GridColumn grcCheckedDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcDiff;
        private DevExpress.XtraGrid.Columns.GridColumn gridRemark;

    }
}
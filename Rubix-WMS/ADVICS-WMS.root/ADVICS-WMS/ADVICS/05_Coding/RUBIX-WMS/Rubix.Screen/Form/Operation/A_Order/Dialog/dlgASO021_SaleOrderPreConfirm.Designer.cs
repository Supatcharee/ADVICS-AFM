namespace Rubix.Screen.Form.Operation.A_Order.Dialog
{
    partial class dlgASO021_SaleOrderPreConfirm
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
            this.grdEditPO = new DevExpress.XtraGrid.GridControl();
            this.gdvEditPO = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcPartName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSumQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcRemaining = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcMinOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSupplierCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repQty = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repQtyLock = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.BTNAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gpcEditdata = new DevExpress.XtraEditors.GroupControl();
            this.gpcMenuControl = new DevExpress.XtraEditors.GroupControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcSrhProductLongName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSrhProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSrhPONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSrhProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSrhSONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSrhSupplierCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEditPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvEditPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repQtyLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcEditdata)).BeginInit();
            this.gpcEditdata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpcMenuControl)).BeginInit();
            this.gpcMenuControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdEditPO
            // 
            this.grdEditPO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEditPO.Location = new System.Drawing.Point(2, 21);
            this.grdEditPO.MainView = this.gdvEditPO;
            this.grdEditPO.Name = "grdEditPO";
            this.grdEditPO.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repQty,
            this.repQtyLock});
            this.grdEditPO.Size = new System.Drawing.Size(838, 386);
            this.grdEditPO.TabIndex = 4;
            this.grdEditPO.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvEditPO});
            // 
            // gdvEditPO
            // 
            this.gdvEditPO.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcPartName,
            this.gdcProductID,
            this.gdcSumQty,
            this.gdcPONo,
            this.gdcRemaining,
            this.gdcProductCode,
            this.gdcMinOrder,
            this.gdcSupplierCode});
            this.gdvEditPO.GridControl = this.grdEditPO;
            this.gdvEditPO.Name = "gdvEditPO";
            this.gdvEditPO.OptionsCustomization.AllowSort = false;
            this.gdvEditPO.OptionsView.AllowCellMerge = true;
            this.gdvEditPO.OptionsView.ColumnAutoWidth = false;
            this.gdvEditPO.OptionsView.ShowGroupPanel = false;
            this.gdvEditPO.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.gdvEditPO_CellMerge);
            this.gdvEditPO.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gdvEditPO_CellValueChanged);
            // 
            // gdcPartName
            // 
            this.gdcPartName.AppearanceCell.Options.UseTextOptions = true;
            this.gdcPartName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcPartName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPartName.AppearanceHeader.Options.UseFont = true;
            this.gdcPartName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPartName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPartName.Caption = "Part Name";
            this.gdcPartName.FieldName = "ProductLongName";
            this.gdcPartName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gdcPartName.Name = "gdcPartName";
            this.gdcPartName.OptionsColumn.AllowEdit = false;
            this.gdcPartName.Visible = true;
            this.gdcPartName.VisibleIndex = 1;
            // 
            // gdcProductID
            // 
            this.gdcProductID.Caption = "ProductID";
            this.gdcProductID.FieldName = "ProductID";
            this.gdcProductID.Name = "gdcProductID";
            this.gdcProductID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gdcSumQty
            // 
            this.gdcSumQty.AppearanceCell.Options.UseTextOptions = true;
            this.gdcSumQty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcSumQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcSumQty.AppearanceHeader.Options.UseFont = true;
            this.gdcSumQty.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSumQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSumQty.Caption = "Total Plan Qty";
            this.gdcSumQty.FieldName = "SUMQty";
            this.gdcSumQty.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gdcSumQty.Name = "gdcSumQty";
            this.gdcSumQty.OptionsColumn.AllowEdit = false;
            this.gdcSumQty.Visible = true;
            this.gdcSumQty.VisibleIndex = 5;
            // 
            // gdcPONo
            // 
            this.gdcPONo.AppearanceCell.Options.UseTextOptions = true;
            this.gdcPONo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcPONo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPONo.AppearanceHeader.Options.UseFont = true;
            this.gdcPONo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPONo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPONo.Caption = "PO No.";
            this.gdcPONo.FieldName = "PONo";
            this.gdcPONo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gdcPONo.Name = "gdcPONo";
            this.gdcPONo.OptionsColumn.AllowEdit = false;
            this.gdcPONo.Visible = true;
            this.gdcPONo.VisibleIndex = 3;
            // 
            // gdcRemaining
            // 
            this.gdcRemaining.AppearanceCell.Options.UseTextOptions = true;
            this.gdcRemaining.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcRemaining.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcRemaining.AppearanceHeader.Options.UseFont = true;
            this.gdcRemaining.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcRemaining.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcRemaining.Caption = "Remain Qty";
            this.gdcRemaining.FieldName = "RemainQty";
            this.gdcRemaining.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gdcRemaining.Name = "gdcRemaining";
            this.gdcRemaining.OptionsColumn.AllowEdit = false;
            this.gdcRemaining.Visible = true;
            this.gdcRemaining.VisibleIndex = 6;
            // 
            // gdcProductCode
            // 
            this.gdcProductCode.AppearanceCell.Options.UseTextOptions = true;
            this.gdcProductCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcProductCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcProductCode.AppearanceHeader.Options.UseFont = true;
            this.gdcProductCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcProductCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcProductCode.Caption = "Product Code";
            this.gdcProductCode.FieldName = "ProductCode";
            this.gdcProductCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gdcProductCode.Name = "gdcProductCode";
            this.gdcProductCode.OptionsColumn.AllowEdit = false;
            this.gdcProductCode.Visible = true;
            this.gdcProductCode.VisibleIndex = 2;
            // 
            // gdcMinOrder
            // 
            this.gdcMinOrder.AppearanceCell.Options.UseTextOptions = true;
            this.gdcMinOrder.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcMinOrder.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcMinOrder.AppearanceHeader.Options.UseFont = true;
            this.gdcMinOrder.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcMinOrder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcMinOrder.Caption = "Min Order";
            this.gdcMinOrder.FieldName = "MinOrder";
            this.gdcMinOrder.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gdcMinOrder.Name = "gdcMinOrder";
            this.gdcMinOrder.OptionsColumn.AllowEdit = false;
            this.gdcMinOrder.Visible = true;
            this.gdcMinOrder.VisibleIndex = 4;
            // 
            // gdcSupplierCode
            // 
            this.gdcSupplierCode.AppearanceCell.Options.UseTextOptions = true;
            this.gdcSupplierCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcSupplierCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcSupplierCode.AppearanceHeader.Options.UseFont = true;
            this.gdcSupplierCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSupplierCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSupplierCode.Caption = "Supplier Code";
            this.gdcSupplierCode.FieldName = "SupplierCode";
            this.gdcSupplierCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gdcSupplierCode.Name = "gdcSupplierCode";
            this.gdcSupplierCode.OptionsColumn.AllowEdit = false;
            this.gdcSupplierCode.Visible = true;
            this.gdcSupplierCode.VisibleIndex = 0;
            // 
            // repQty
            // 
            this.repQty.AutoHeight = false;
            this.repQty.Mask.EditMask = "\\d+";
            this.repQty.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repQty.Name = "repQty";
            this.repQty.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.repQty_EditValueChanging);
            this.repQty.Enter += new System.EventHandler(this.repQty_Enter);
            // 
            // repQtyLock
            // 
            this.repQtyLock.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.repQtyLock.Appearance.BackColor2 = System.Drawing.Color.LightGray;
            this.repQtyLock.Appearance.Options.UseBackColor = true;
            this.repQtyLock.AppearanceDisabled.BackColor = System.Drawing.Color.LightGray;
            this.repQtyLock.AppearanceDisabled.BackColor2 = System.Drawing.Color.LightGray;
            this.repQtyLock.AppearanceDisabled.Options.UseBackColor = true;
            this.repQtyLock.AppearanceFocused.BackColor = System.Drawing.Color.LightGray;
            this.repQtyLock.AppearanceFocused.BackColor2 = System.Drawing.Color.LightGray;
            this.repQtyLock.AppearanceFocused.Options.UseBackColor = true;
            this.repQtyLock.AppearanceReadOnly.BackColor = System.Drawing.Color.LightGray;
            this.repQtyLock.AppearanceReadOnly.BackColor2 = System.Drawing.Color.LightGray;
            this.repQtyLock.AppearanceReadOnly.Options.UseBackColor = true;
            this.repQtyLock.AutoHeight = false;
            this.repQtyLock.Name = "repQtyLock";
            // 
            // BTNAdd
            // 
            this.BTNAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNAdd.Location = new System.Drawing.Point(8, 24);
            this.BTNAdd.Name = "BTNAdd";
            this.BTNAdd.Size = new System.Drawing.Size(75, 23);
            this.BTNAdd.TabIndex = 5;
            this.BTNAdd.Text = "Add";
            this.BTNAdd.Click += new System.EventHandler(this.BTNAdd_Click);
            // 
            // gpcEditdata
            // 
            this.gpcEditdata.Controls.Add(this.grdEditPO);
            this.gpcEditdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpcEditdata.Location = new System.Drawing.Point(0, 0);
            this.gpcEditdata.Name = "gpcEditdata";
            this.gpcEditdata.Size = new System.Drawing.Size(842, 409);
            this.gpcEditdata.TabIndex = 6;
            this.gpcEditdata.Text = "Adjust Plan";
            // 
            // gpcMenuControl
            // 
            this.gpcMenuControl.Controls.Add(this.BTNAdd);
            this.gpcMenuControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.gpcMenuControl.Location = new System.Drawing.Point(842, 0);
            this.gpcMenuControl.Name = "gpcMenuControl";
            this.gpcMenuControl.Size = new System.Drawing.Size(91, 409);
            this.gpcMenuControl.TabIndex = 7;
            this.gpcMenuControl.Text = "Menu";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 31);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(939, 437);
            this.xtraTabControl1.TabIndex = 8;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gpcEditdata);
            this.xtraTabPage1.Controls.Add(this.gpcMenuControl);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(933, 409);
            this.xtraTabPage1.Text = "Adjust";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.grdSearchResult);
            this.xtraTabPage2.Controls.Add(this.panelControl1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(933, 409);
            this.xtraTabPage2.Text = "Current";
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSearchResult.Location = new System.Drawing.Point(0, 0);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
            this.grdSearchResult.Size = new System.Drawing.Size(933, 366);
            this.grdSearchResult.TabIndex = 5;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcSrhProductLongName,
            this.gdcSrhProductID,
            this.gdcSrhPONo,
            this.gdcSrhProductCode,
            this.gdcSrhSONo,
            this.gdcSrhSupplierCode});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsBehavior.Editable = false;
            this.gdvSearchResult.OptionsView.AllowCellMerge = true;
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            this.gdvSearchResult.OptionsView.ShowGroupPanel = false;
            this.gdvSearchResult.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.gdvSearchResult_CellMerge);
            // 
            // gdcSrhProductLongName
            // 
            this.gdcSrhProductLongName.AppearanceCell.Options.UseTextOptions = true;
            this.gdcSrhProductLongName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcSrhProductLongName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcSrhProductLongName.AppearanceHeader.Options.UseFont = true;
            this.gdcSrhProductLongName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSrhProductLongName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSrhProductLongName.Caption = "Part Name";
            this.gdcSrhProductLongName.FieldName = "ProductLongName";
            this.gdcSrhProductLongName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gdcSrhProductLongName.Name = "gdcSrhProductLongName";
            this.gdcSrhProductLongName.OptionsColumn.AllowEdit = false;
            this.gdcSrhProductLongName.Visible = true;
            this.gdcSrhProductLongName.VisibleIndex = 1;
            // 
            // gdcSrhProductID
            // 
            this.gdcSrhProductID.Caption = "ProductID";
            this.gdcSrhProductID.FieldName = "ProductID";
            this.gdcSrhProductID.Name = "gdcSrhProductID";
            this.gdcSrhProductID.OptionsColumn.AllowEdit = false;
            this.gdcSrhProductID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gdcSrhPONo
            // 
            this.gdcSrhPONo.AppearanceCell.Options.UseTextOptions = true;
            this.gdcSrhPONo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcSrhPONo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcSrhPONo.AppearanceHeader.Options.UseFont = true;
            this.gdcSrhPONo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSrhPONo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSrhPONo.Caption = "PO No.";
            this.gdcSrhPONo.FieldName = "PONo";
            this.gdcSrhPONo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gdcSrhPONo.Name = "gdcSrhPONo";
            this.gdcSrhPONo.OptionsColumn.AllowEdit = false;
            this.gdcSrhPONo.Visible = true;
            this.gdcSrhPONo.VisibleIndex = 3;
            // 
            // gdcSrhProductCode
            // 
            this.gdcSrhProductCode.AppearanceCell.Options.UseTextOptions = true;
            this.gdcSrhProductCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcSrhProductCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcSrhProductCode.AppearanceHeader.Options.UseFont = true;
            this.gdcSrhProductCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSrhProductCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSrhProductCode.Caption = "Product Code";
            this.gdcSrhProductCode.FieldName = "ProductCode";
            this.gdcSrhProductCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gdcSrhProductCode.Name = "gdcSrhProductCode";
            this.gdcSrhProductCode.OptionsColumn.AllowEdit = false;
            this.gdcSrhProductCode.Visible = true;
            this.gdcSrhProductCode.VisibleIndex = 2;
            // 
            // gdcSrhSONo
            // 
            this.gdcSrhSONo.AppearanceCell.Options.UseTextOptions = true;
            this.gdcSrhSONo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcSrhSONo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcSrhSONo.AppearanceHeader.Options.UseFont = true;
            this.gdcSrhSONo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSrhSONo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSrhSONo.Caption = "SO No.";
            this.gdcSrhSONo.FieldName = "SONo";
            this.gdcSrhSONo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gdcSrhSONo.Name = "gdcSrhSONo";
            this.gdcSrhSONo.OptionsColumn.AllowEdit = false;
            this.gdcSrhSONo.Visible = true;
            this.gdcSrhSONo.VisibleIndex = 4;
            // 
            // gdcSrhSupplierCode
            // 
            this.gdcSrhSupplierCode.AppearanceCell.Options.UseTextOptions = true;
            this.gdcSrhSupplierCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gdcSrhSupplierCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcSrhSupplierCode.AppearanceHeader.Options.UseFont = true;
            this.gdcSrhSupplierCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSrhSupplierCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSrhSupplierCode.Caption = "Supplier Code";
            this.gdcSrhSupplierCode.FieldName = "SupplierCode";
            this.gdcSrhSupplierCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gdcSrhSupplierCode.Name = "gdcSrhSupplierCode";
            this.gdcSrhSupplierCode.Visible = true;
            this.gdcSrhSupplierCode.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.EditMask = "\\d+";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.repositoryItemTextEdit2.Appearance.BackColor2 = System.Drawing.Color.LightGray;
            this.repositoryItemTextEdit2.Appearance.Options.UseBackColor = true;
            this.repositoryItemTextEdit2.AppearanceDisabled.BackColor = System.Drawing.Color.LightGray;
            this.repositoryItemTextEdit2.AppearanceDisabled.BackColor2 = System.Drawing.Color.LightGray;
            this.repositoryItemTextEdit2.AppearanceDisabled.Options.UseBackColor = true;
            this.repositoryItemTextEdit2.AppearanceFocused.BackColor = System.Drawing.Color.LightGray;
            this.repositoryItemTextEdit2.AppearanceFocused.BackColor2 = System.Drawing.Color.LightGray;
            this.repositoryItemTextEdit2.AppearanceFocused.Options.UseBackColor = true;
            this.repositoryItemTextEdit2.AppearanceReadOnly.BackColor = System.Drawing.Color.LightGray;
            this.repositoryItemTextEdit2.AppearanceReadOnly.BackColor2 = System.Drawing.Color.LightGray;
            this.repositoryItemTextEdit2.AppearanceReadOnly.Options.UseBackColor = true;
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnExport);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 366);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(933, 43);
            this.panelControl1.TabIndex = 6;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(11, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(88, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "ExportToExcel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dlgASO021_SaleOrderPreConfirm
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 499);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "dlgASO021_SaleOrderPreConfirm";
            this.Text = "ASO021 : Sale Order Confirm";
            this.Load += new System.EventHandler(this.dlgASO021_SaleOrderPreConfirm_Load);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEditPO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvEditPO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repQtyLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcEditdata)).EndInit();
            this.gpcEditdata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpcMenuControl)).EndInit();
            this.gpcMenuControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdEditPO;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvEditPO;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPartName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repQty;
        private DevExpress.XtraGrid.Columns.GridColumn gdcProductID;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSumQty;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repQtyLock;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPONo;
        private DevExpress.XtraEditors.SimpleButton BTNAdd;
        private DevExpress.XtraGrid.Columns.GridColumn gdcRemaining;
        private DevExpress.XtraEditors.GroupControl gpcEditdata;
        private DevExpress.XtraEditors.GroupControl gpcMenuControl;
        private DevExpress.XtraGrid.Columns.GridColumn gdcProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcMinOrder;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSrhProductLongName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSrhProductID;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSrhPONo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSrhProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSrhSONo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSupplierCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSrhSupplierCode;
    }
}
namespace Rubix.Screen.Form.Operation.A_Order.Dialog
{
    partial class dlgASO042_PurchaseOrderSearchSaleOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgASO042_PurchaseOrderSearchSaleOrder));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.customerControl = new Rubix.Control.CustomerControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.grpSearchCriteria = new DevExpress.XtraEditors.GroupControl();
            this.txtSONo = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerPONo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dtCustomerPOIssueDateTo = new DevExpress.XtraEditors.DateEdit();
            this.dtCustomerPOIssueDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dtShippingPeriod = new DevExpress.XtraEditors.DateEdit();
            this.grpSearchResult = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gdcSONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCustomerPONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcShippingPeriod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCustPOIssDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearchCriteria)).BeginInit();
            this.grpSearchCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSONo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerPONo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtShippingPeriod.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtShippingPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearchResult)).BeginInit();
            this.grpSearchResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // customerControl
            // 
            this.customerControl.ErrorText = "Customer Control is Require Field";
            this.customerControl.Location = new System.Drawing.Point(85, 23);
            this.customerControl.Name = "customerControl";
            this.customerControl.OwnerID = null;
            this.customerControl.ReadOnly = false;
            this.customerControl.RequireField = false;
            this.customerControl.Size = new System.Drawing.Size(439, 21);
            this.customerControl.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(14, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(124, 16);
            this.labelControl2.TabIndex = 155;
            this.labelControl2.Text = "Shipping Period";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(792, 67);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(711, 67);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grpSearchCriteria
            // 
            this.grpSearchCriteria.Controls.Add(this.txtSONo);
            this.grpSearchCriteria.Controls.Add(this.txtCustomerPONo);
            this.grpSearchCriteria.Controls.Add(this.labelControl6);
            this.grpSearchCriteria.Controls.Add(this.labelControl5);
            this.grpSearchCriteria.Controls.Add(this.labelControl4);
            this.grpSearchCriteria.Controls.Add(this.dtCustomerPOIssueDateTo);
            this.grpSearchCriteria.Controls.Add(this.dtCustomerPOIssueDateFrom);
            this.grpSearchCriteria.Controls.Add(this.labelControl3);
            this.grpSearchCriteria.Controls.Add(this.dtShippingPeriod);
            this.grpSearchCriteria.Controls.Add(this.btnSearch);
            this.grpSearchCriteria.Controls.Add(this.btnClear);
            this.grpSearchCriteria.Controls.Add(this.customerControl);
            this.grpSearchCriteria.Controls.Add(this.labelControl2);
            this.grpSearchCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearchCriteria.Location = new System.Drawing.Point(0, 31);
            this.grpSearchCriteria.Name = "grpSearchCriteria";
            this.grpSearchCriteria.Size = new System.Drawing.Size(871, 94);
            this.grpSearchCriteria.TabIndex = 166;
            this.grpSearchCriteria.Text = "Search Criteria";
            // 
            // txtSONo
            // 
            this.txtSONo.Location = new System.Drawing.Point(667, 45);
            this.txtSONo.Name = "txtSONo";
            this.txtSONo.Properties.MaxLength = 50;
            this.txtSONo.Size = new System.Drawing.Size(201, 20);
            this.txtSONo.TabIndex = 5;
            // 
            // txtCustomerPONo
            // 
            this.txtCustomerPONo.Location = new System.Drawing.Point(667, 23);
            this.txtCustomerPONo.Name = "txtCustomerPONo";
            this.txtCustomerPONo.Properties.MaxLength = 50;
            this.txtCustomerPONo.Size = new System.Drawing.Size(201, 20);
            this.txtCustomerPONo.TabIndex = 4;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(529, 49);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(130, 13);
            this.labelControl6.TabIndex = 202;
            this.labelControl6.Text = "S/O No.";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(529, 27);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(130, 13);
            this.labelControl5.TabIndex = 201;
            this.labelControl5.Text = "Customer P/O No.";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(274, 49);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(29, 13);
            this.labelControl4.TabIndex = 200;
            this.labelControl4.Text = "To";
            // 
            // dtCustomerPOIssueDateTo
            // 
            this.dtCustomerPOIssueDateTo.EditValue = null;
            this.dtCustomerPOIssueDateTo.Location = new System.Drawing.Point(307, 46);
            this.dtCustomerPOIssueDateTo.Name = "dtCustomerPOIssueDateTo";
            this.dtCustomerPOIssueDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtCustomerPOIssueDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtCustomerPOIssueDateTo.Size = new System.Drawing.Size(123, 20);
            this.dtCustomerPOIssueDateTo.TabIndex = 2;
            // 
            // dtCustomerPOIssueDateFrom
            // 
            this.dtCustomerPOIssueDateFrom.EditValue = null;
            this.dtCustomerPOIssueDateFrom.Location = new System.Drawing.Point(148, 46);
            this.dtCustomerPOIssueDateFrom.Name = "dtCustomerPOIssueDateFrom";
            this.dtCustomerPOIssueDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtCustomerPOIssueDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtCustomerPOIssueDateFrom.Size = new System.Drawing.Size(123, 20);
            this.dtCustomerPOIssueDateFrom.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(10, 49);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(130, 13);
            this.labelControl3.TabIndex = 197;
            this.labelControl3.Text = "Customer P/O Issue Date";
            // 
            // dtShippingPeriod
            // 
            this.dtShippingPeriod.EditValue = null;
            this.dtShippingPeriod.Location = new System.Drawing.Point(148, 67);
            this.dtShippingPeriod.Name = "dtShippingPeriod";
            this.dtShippingPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("dtShippingPeriod.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.dtShippingPeriod.Properties.DisplayFormat.FormatString = "MM/yyyy";
            this.dtShippingPeriod.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtShippingPeriod.Properties.EditFormat.FormatString = "yyyy/MM";
            this.dtShippingPeriod.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtShippingPeriod.Properties.Mask.EditMask = "MM/yyyy";
            this.dtShippingPeriod.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtShippingPeriod.Size = new System.Drawing.Size(123, 22);
            this.dtShippingPeriod.TabIndex = 3;
            // 
            // grpSearchResult
            // 
            this.grpSearchResult.Controls.Add(this.grdSearchResult);
            this.grpSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSearchResult.Location = new System.Drawing.Point(0, 125);
            this.grpSearchResult.Name = "grpSearchResult";
            this.grpSearchResult.Size = new System.Drawing.Size(871, 327);
            this.grpSearchResult.TabIndex = 167;
            this.grpSearchResult.Text = "Search Result";
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSearchResult.Location = new System.Drawing.Point(2, 21);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repSelect});
            this.grdSearchResult.Size = new System.Drawing.Size(867, 304);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult,
            this.gridView2});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcSelect,
            this.gdcSONo,
            this.gdcCustomerPONo,
            this.gdcCustomerCode,
            this.gdcCustomerName,
            this.gdcShippingPeriod,
            this.gdcCustPOIssDate});
            this.gdvSearchResult.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsCustomization.AllowGroup = false;
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            this.gdvSearchResult.OptionsView.ShowGroupPanel = false;
            // 
            // gdcSelect
            // 
            this.gdcSelect.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcSelect.AppearanceHeader.Options.UseFont = true;
            this.gdcSelect.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSelect.Caption = "Select";
            this.gdcSelect.ColumnEdit = this.repSelect;
            this.gdcSelect.FieldName = "Select";
            this.gdcSelect.Name = "gdcSelect";
            this.gdcSelect.Visible = true;
            this.gdcSelect.VisibleIndex = 0;
            // 
            // repSelect
            // 
            this.repSelect.AutoHeight = false;
            this.repSelect.Name = "repSelect";
            this.repSelect.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repSelect.ValueChecked = ((long)(1));
            this.repSelect.ValueUnchecked = ((long)(0));
            // 
            // gdcSONo
            // 
            this.gdcSONo.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcSONo.AppearanceHeader.Options.UseFont = true;
            this.gdcSONo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSONo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSONo.Caption = "S/O No.";
            this.gdcSONo.FieldName = "SONo";
            this.gdcSONo.Name = "gdcSONo";
            this.gdcSONo.OptionsColumn.AllowEdit = false;
            this.gdcSONo.Visible = true;
            this.gdcSONo.VisibleIndex = 1;
            // 
            // gdcCustomerPONo
            // 
            this.gdcCustomerPONo.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCustomerPONo.AppearanceHeader.Options.UseFont = true;
            this.gdcCustomerPONo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCustomerPONo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCustomerPONo.Caption = "Customer P/O No.";
            this.gdcCustomerPONo.FieldName = "CustomerPONo";
            this.gdcCustomerPONo.Name = "gdcCustomerPONo";
            this.gdcCustomerPONo.OptionsColumn.AllowEdit = false;
            this.gdcCustomerPONo.Visible = true;
            this.gdcCustomerPONo.VisibleIndex = 2;
            this.gdcCustomerPONo.Width = 143;
            // 
            // gdcCustomerCode
            // 
            this.gdcCustomerCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCustomerCode.AppearanceHeader.Options.UseFont = true;
            this.gdcCustomerCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCustomerCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCustomerCode.Caption = "Customer Code";
            this.gdcCustomerCode.FieldName = "CustomerCode";
            this.gdcCustomerCode.Name = "gdcCustomerCode";
            this.gdcCustomerCode.OptionsColumn.AllowEdit = false;
            this.gdcCustomerCode.Visible = true;
            this.gdcCustomerCode.VisibleIndex = 3;
            this.gdcCustomerCode.Width = 133;
            // 
            // gdcCustomerName
            // 
            this.gdcCustomerName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCustomerName.AppearanceHeader.Options.UseFont = true;
            this.gdcCustomerName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCustomerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCustomerName.Caption = "Customer Name";
            this.gdcCustomerName.FieldName = "CustomerName";
            this.gdcCustomerName.Name = "gdcCustomerName";
            this.gdcCustomerName.OptionsColumn.AllowEdit = false;
            this.gdcCustomerName.Visible = true;
            this.gdcCustomerName.VisibleIndex = 4;
            this.gdcCustomerName.Width = 123;
            // 
            // gdcShippingPeriod
            // 
            this.gdcShippingPeriod.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcShippingPeriod.AppearanceHeader.Options.UseFont = true;
            this.gdcShippingPeriod.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcShippingPeriod.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcShippingPeriod.Caption = "Shipping Period";
            this.gdcShippingPeriod.FieldName = "ShippingPeriod";
            this.gdcShippingPeriod.Name = "gdcShippingPeriod";
            this.gdcShippingPeriod.OptionsColumn.AllowEdit = false;
            this.gdcShippingPeriod.Visible = true;
            this.gdcShippingPeriod.VisibleIndex = 5;
            this.gdcShippingPeriod.Width = 138;
            // 
            // gdcCustPOIssDate
            // 
            this.gdcCustPOIssDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCustPOIssDate.AppearanceHeader.Options.UseFont = true;
            this.gdcCustPOIssDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCustPOIssDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCustPOIssDate.Caption = "Customer P/O Issue Date";
            this.gdcCustPOIssDate.FieldName = "CustomerPOIssueDate";
            this.gdcCustPOIssDate.Name = "gdcCustPOIssDate";
            this.gdcCustPOIssDate.OptionsColumn.AllowEdit = false;
            this.gdcCustPOIssDate.Visible = true;
            this.gdcCustPOIssDate.VisibleIndex = 6;
            this.gdcCustPOIssDate.Width = 183;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdSearchResult;
            this.gridView2.Name = "gridView2";
            // 
            // dlgASO042_PurchaseOrderSearchSaleOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 452);
            this.Controls.Add(this.grpSearchResult);
            this.Controls.Add(this.grpSearchCriteria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgASO042_PurchaseOrderSearchSaleOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ASO042 : Select Sale Order Dialog";
            this.Load += new System.EventHandler(this.dlgASO042_PurchaseOrderSearchSaleOrder_Load);
            this.Controls.SetChildIndex(this.grpSearchCriteria, 0);
            this.Controls.SetChildIndex(this.grpSearchResult, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grpSearchCriteria)).EndInit();
            this.grpSearchCriteria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSONo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerPONo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtShippingPeriod.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtShippingPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSearchResult)).EndInit();
            this.grpSearchResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.CustomerControl customerControl;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.GroupControl grpSearchCriteria;
        private DevExpress.XtraEditors.GroupControl grpSearchResult;
        private DevExpress.XtraEditors.DateEdit dtShippingPeriod;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit dtCustomerPOIssueDateTo;
        private DevExpress.XtraEditors.DateEdit dtCustomerPOIssueDateFrom;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtSONo;
        private DevExpress.XtraEditors.TextEdit txtCustomerPONo;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSONo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCustomerPONo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcShippingPeriod;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCustPOIssDate;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repSelect;
    }
}
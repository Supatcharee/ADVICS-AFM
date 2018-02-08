namespace Rubix.Screen.Form.Master.Dialog
{
    partial class dlgXMSS320_SalePrice
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.grdResult = new DevExpress.XtraGrid.GridControl();
            this.gdvResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCustomerCode = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcrepCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcrepCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemCode = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcrepProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcrepProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSalePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSalePrice = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gdcCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCurrencyCode = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcrepCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcrepCurrencyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcIncoterm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcEffectiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repEffectiveDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gdcImplementDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcHSCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPrivilegeFormat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repPVCode = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcrepPVCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcrepPVName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repRemark = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gdcErrorDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repErrorDetail = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSalePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCurrencyCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEffectiveDate.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPVCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repErrorDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // grdResult
            // 
            this.grdResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdResult.Location = new System.Drawing.Point(2, 30);
            this.grdResult.MainView = this.gdvResult;
            this.grdResult.Name = "grdResult";
            this.grdResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCustomerCode,
            this.repItemCode,
            this.repEffectiveDate,
            this.repSalePrice,
            this.repCurrencyCode,
            this.repRemark,
            this.repPVCode,
            this.repErrorDetail});
            this.grdResult.Size = new System.Drawing.Size(864, 370);
            this.grdResult.TabIndex = 4;
            this.grdResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvResult});
            // 
            // gdvResult
            // 
            this.gdvResult.ColumnPanelRowHeight = 50;
            this.gdvResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcCustomerCode,
            this.gdcProductCode,
            this.gdcSalePrice,
            this.gdcCurrencyCode,
            this.gdcIncoterm,
            this.gdcEffectiveDate,
            this.gdcImplementDate,
            this.gdcHSCode,
            this.gdcPrivilegeFormat,
            this.gdcRemark,
            this.gdcErrorDetail});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "[ErrorDetail]  !=  null && [ErrorDetail] != \'\'";
            this.gdvResult.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gdvResult.GridControl = this.grdResult;
            this.gdvResult.Name = "gdvResult";
            this.gdvResult.OptionsCustomization.AllowGroup = false;
            this.gdvResult.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gdvResult.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gdvResult.OptionsView.AllowHtmlDrawHeaders = true;
            this.gdvResult.OptionsView.ColumnAutoWidth = false;
            this.gdvResult.OptionsView.RowAutoHeight = true;
            this.gdvResult.OptionsView.ShowGroupPanel = false;
            this.gdvResult.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gdvResult_ValidateRow);
            this.gdvResult.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gdvResult_ValidatingEditor);
            // 
            // gdcCustomerCode
            // 
            this.gdcCustomerCode.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdcCustomerCode.AppearanceCell.Options.UseFont = true;
            this.gdcCustomerCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCustomerCode.AppearanceHeader.Options.UseFont = true;
            this.gdcCustomerCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCustomerCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCustomerCode.Caption = "Customer Code <color=\"red\">*</color> ";
            this.gdcCustomerCode.ColumnEdit = this.repCustomerCode;
            this.gdcCustomerCode.FieldName = "CustomerID";
            this.gdcCustomerCode.Name = "gdcCustomerCode";
            this.gdcCustomerCode.Visible = true;
            this.gdcCustomerCode.VisibleIndex = 0;
            this.gdcCustomerCode.Width = 126;
            // 
            // repCustomerCode
            // 
            this.repCustomerCode.AutoHeight = false;
            this.repCustomerCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCustomerCode.DisplayMember = "CustomerCode";
            this.repCustomerCode.Name = "repCustomerCode";
            this.repCustomerCode.NullText = "";
            this.repCustomerCode.ValueMember = "CustomerID";
            this.repCustomerCode.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcrepCustomerCode,
            this.gdcrepCustomerName});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gdcrepCustomerCode
            // 
            this.gdcrepCustomerCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcrepCustomerCode.AppearanceHeader.Options.UseFont = true;
            this.gdcrepCustomerCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcrepCustomerCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcrepCustomerCode.Caption = "Customer Code";
            this.gdcrepCustomerCode.FieldName = "CustomerCode";
            this.gdcrepCustomerCode.Name = "gdcrepCustomerCode";
            this.gdcrepCustomerCode.Visible = true;
            this.gdcrepCustomerCode.VisibleIndex = 0;
            // 
            // gdcrepCustomerName
            // 
            this.gdcrepCustomerName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcrepCustomerName.AppearanceHeader.Options.UseFont = true;
            this.gdcrepCustomerName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcrepCustomerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcrepCustomerName.Caption = "Customer Name";
            this.gdcrepCustomerName.FieldName = "CustomerName";
            this.gdcrepCustomerName.Name = "gdcrepCustomerName";
            this.gdcrepCustomerName.Visible = true;
            this.gdcrepCustomerName.VisibleIndex = 1;
            // 
            // gdcProductCode
            // 
            this.gdcProductCode.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdcProductCode.AppearanceCell.Options.UseFont = true;
            this.gdcProductCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcProductCode.AppearanceHeader.Options.UseFont = true;
            this.gdcProductCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcProductCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcProductCode.Caption = "Part Number <color=\"red\">*</color> ";
            this.gdcProductCode.ColumnEdit = this.repItemCode;
            this.gdcProductCode.FieldName = "ProductID";
            this.gdcProductCode.Name = "gdcProductCode";
            this.gdcProductCode.Visible = true;
            this.gdcProductCode.VisibleIndex = 1;
            this.gdcProductCode.Width = 95;
            // 
            // repItemCode
            // 
            this.repItemCode.AutoHeight = false;
            this.repItemCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemCode.DisplayMember = "ProductCode";
            this.repItemCode.Name = "repItemCode";
            this.repItemCode.NullText = "";
            this.repItemCode.ValueMember = "ProductID";
            this.repItemCode.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcrepProductCode,
            this.gdcrepProductName});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gdcrepProductCode
            // 
            this.gdcrepProductCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcrepProductCode.AppearanceHeader.Options.UseFont = true;
            this.gdcrepProductCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcrepProductCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcrepProductCode.Caption = "Product Code";
            this.gdcrepProductCode.FieldName = "ProductCode";
            this.gdcrepProductCode.Name = "gdcrepProductCode";
            this.gdcrepProductCode.Visible = true;
            this.gdcrepProductCode.VisibleIndex = 0;
            // 
            // gdcrepProductName
            // 
            this.gdcrepProductName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcrepProductName.AppearanceHeader.Options.UseFont = true;
            this.gdcrepProductName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcrepProductName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcrepProductName.Caption = "Product Name";
            this.gdcrepProductName.FieldName = "ProductLongName";
            this.gdcrepProductName.Name = "gdcrepProductName";
            this.gdcrepProductName.Visible = true;
            this.gdcrepProductName.VisibleIndex = 1;
            // 
            // gdcSalePrice
            // 
            this.gdcSalePrice.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdcSalePrice.AppearanceCell.Options.UseFont = true;
            this.gdcSalePrice.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcSalePrice.AppearanceHeader.Options.UseFont = true;
            this.gdcSalePrice.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSalePrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSalePrice.Caption = "Sale Price <color=\"red\">*</color> ";
            this.gdcSalePrice.ColumnEdit = this.repSalePrice;
            this.gdcSalePrice.FieldName = "SalePrice";
            this.gdcSalePrice.Name = "gdcSalePrice";
            this.gdcSalePrice.Visible = true;
            this.gdcSalePrice.VisibleIndex = 2;
            // 
            // repSalePrice
            // 
            this.repSalePrice.AutoHeight = false;
            this.repSalePrice.DisplayFormat.FormatString = "#,##0.00";
            this.repSalePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repSalePrice.EditFormat.FormatString = "#,##0.00";
            this.repSalePrice.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repSalePrice.Mask.EditMask = "#,##0.00";
            this.repSalePrice.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repSalePrice.Name = "repSalePrice";
            // 
            // gdcCurrencyCode
            // 
            this.gdcCurrencyCode.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdcCurrencyCode.AppearanceCell.Options.UseFont = true;
            this.gdcCurrencyCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCurrencyCode.AppearanceHeader.Options.UseFont = true;
            this.gdcCurrencyCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCurrencyCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCurrencyCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gdcCurrencyCode.Caption = "Currency  Code <color=\"red\">*</color> ";
            this.gdcCurrencyCode.ColumnEdit = this.repCurrencyCode;
            this.gdcCurrencyCode.FieldName = "CurrencyID";
            this.gdcCurrencyCode.Name = "gdcCurrencyCode";
            this.gdcCurrencyCode.Visible = true;
            this.gdcCurrencyCode.VisibleIndex = 3;
            // 
            // repCurrencyCode
            // 
            this.repCurrencyCode.AutoHeight = false;
            this.repCurrencyCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCurrencyCode.DisplayMember = "CurrencyCode";
            this.repCurrencyCode.Name = "repCurrencyCode";
            this.repCurrencyCode.NullText = "";
            this.repCurrencyCode.ValueMember = "CurrencyID";
            this.repCurrencyCode.View = this.gridView2;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcrepCurrencyCode,
            this.gdcrepCurrencyName});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gdcrepCurrencyCode
            // 
            this.gdcrepCurrencyCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcrepCurrencyCode.AppearanceHeader.Options.UseFont = true;
            this.gdcrepCurrencyCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcrepCurrencyCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcrepCurrencyCode.Caption = "Currency Code";
            this.gdcrepCurrencyCode.FieldName = "CurrencyCode";
            this.gdcrepCurrencyCode.Name = "gdcrepCurrencyCode";
            this.gdcrepCurrencyCode.Visible = true;
            this.gdcrepCurrencyCode.VisibleIndex = 0;
            // 
            // gdcrepCurrencyName
            // 
            this.gdcrepCurrencyName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcrepCurrencyName.AppearanceHeader.Options.UseFont = true;
            this.gdcrepCurrencyName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcrepCurrencyName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcrepCurrencyName.Caption = "Currency Name";
            this.gdcrepCurrencyName.FieldName = "CurrencyName";
            this.gdcrepCurrencyName.Name = "gdcrepCurrencyName";
            this.gdcrepCurrencyName.Visible = true;
            this.gdcrepCurrencyName.VisibleIndex = 1;
            // 
            // gdcIncoterm
            // 
            this.gdcIncoterm.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdcIncoterm.AppearanceCell.Options.UseFont = true;
            this.gdcIncoterm.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcIncoterm.AppearanceHeader.Options.UseFont = true;
            this.gdcIncoterm.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcIncoterm.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcIncoterm.Caption = "Incoterm";
            this.gdcIncoterm.FieldName = "Incoterm";
            this.gdcIncoterm.FieldNameSortGroup = "Incoterm";
            this.gdcIncoterm.Name = "gdcIncoterm";
            this.gdcIncoterm.Visible = true;
            this.gdcIncoterm.VisibleIndex = 4;
            // 
            // gdcEffectiveDate
            // 
            this.gdcEffectiveDate.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdcEffectiveDate.AppearanceCell.Options.UseFont = true;
            this.gdcEffectiveDate.AppearanceCell.Options.UseTextOptions = true;
            this.gdcEffectiveDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcEffectiveDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcEffectiveDate.AppearanceHeader.Options.UseFont = true;
            this.gdcEffectiveDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcEffectiveDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcEffectiveDate.Caption = "Effective Date <color=\"red\">*</color> ";
            this.gdcEffectiveDate.ColumnEdit = this.repEffectiveDate;
            this.gdcEffectiveDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gdcEffectiveDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcEffectiveDate.FieldName = "EffectiveDate";
            this.gdcEffectiveDate.FieldNameSortGroup = "EffectiveDate";
            this.gdcEffectiveDate.Name = "gdcEffectiveDate";
            this.gdcEffectiveDate.Visible = true;
            this.gdcEffectiveDate.VisibleIndex = 5;
            this.gdcEffectiveDate.Width = 99;
            // 
            // repEffectiveDate
            // 
            this.repEffectiveDate.AutoHeight = false;
            this.repEffectiveDate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repEffectiveDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.repEffectiveDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repEffectiveDate.EditFormat.FormatString = "dd/MM/yyyy";
            this.repEffectiveDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repEffectiveDate.Mask.EditMask = "dd/MM/yyyy";
            this.repEffectiveDate.Name = "repEffectiveDate";
            this.repEffectiveDate.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gdcImplementDate
            // 
            this.gdcImplementDate.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdcImplementDate.AppearanceCell.Options.UseFont = true;
            this.gdcImplementDate.AppearanceCell.Options.UseTextOptions = true;
            this.gdcImplementDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcImplementDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcImplementDate.AppearanceHeader.Options.UseFont = true;
            this.gdcImplementDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcImplementDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcImplementDate.Caption = "Implement Date";
            this.gdcImplementDate.ColumnEdit = this.repEffectiveDate;
            this.gdcImplementDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gdcImplementDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcImplementDate.FieldName = "ImplementDate";
            this.gdcImplementDate.FieldNameSortGroup = "ImplementDate";
            this.gdcImplementDate.Name = "gdcImplementDate";
            this.gdcImplementDate.Visible = true;
            this.gdcImplementDate.VisibleIndex = 6;
            this.gdcImplementDate.Width = 116;
            // 
            // gdcHSCode
            // 
            this.gdcHSCode.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdcHSCode.AppearanceCell.Options.UseFont = true;
            this.gdcHSCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcHSCode.AppearanceHeader.Options.UseFont = true;
            this.gdcHSCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcHSCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcHSCode.Caption = "HS Code";
            this.gdcHSCode.FieldName = "HSCode";
            this.gdcHSCode.FieldNameSortGroup = "HSCode";
            this.gdcHSCode.Name = "gdcHSCode";
            this.gdcHSCode.Visible = true;
            this.gdcHSCode.VisibleIndex = 7;
            this.gdcHSCode.Width = 93;
            // 
            // gdcPrivilegeFormat
            // 
            this.gdcPrivilegeFormat.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdcPrivilegeFormat.AppearanceCell.Options.UseFont = true;
            this.gdcPrivilegeFormat.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPrivilegeFormat.AppearanceHeader.Options.UseFont = true;
            this.gdcPrivilegeFormat.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPrivilegeFormat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPrivilegeFormat.Caption = "Privilege Format";
            this.gdcPrivilegeFormat.ColumnEdit = this.repPVCode;
            this.gdcPrivilegeFormat.FieldName = "PVID";
            this.gdcPrivilegeFormat.FieldNameSortGroup = "PVID";
            this.gdcPrivilegeFormat.Name = "gdcPrivilegeFormat";
            this.gdcPrivilegeFormat.Visible = true;
            this.gdcPrivilegeFormat.VisibleIndex = 8;
            this.gdcPrivilegeFormat.Width = 114;
            // 
            // repPVCode
            // 
            this.repPVCode.AutoHeight = false;
            this.repPVCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repPVCode.DisplayMember = "PVCode";
            this.repPVCode.Name = "repPVCode";
            this.repPVCode.NullText = "";
            this.repPVCode.ValueMember = "PVID";
            this.repPVCode.View = this.gridView3;
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcrepPVCode,
            this.gdcrepPVName});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gdcrepPVCode
            // 
            this.gdcrepPVCode.Caption = "Privilege Code";
            this.gdcrepPVCode.FieldName = "PVCode";
            this.gdcrepPVCode.Name = "gdcrepPVCode";
            this.gdcrepPVCode.Visible = true;
            this.gdcrepPVCode.VisibleIndex = 0;
            // 
            // gdcrepPVName
            // 
            this.gdcrepPVName.Caption = "Privilege Name";
            this.gdcrepPVName.FieldName = "PVName";
            this.gdcrepPVName.Name = "gdcrepPVName";
            this.gdcrepPVName.Visible = true;
            this.gdcrepPVName.VisibleIndex = 1;
            // 
            // gdcRemark
            // 
            this.gdcRemark.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdcRemark.AppearanceCell.Options.UseFont = true;
            this.gdcRemark.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcRemark.AppearanceHeader.Options.UseFont = true;
            this.gdcRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcRemark.Caption = "Remark";
            this.gdcRemark.ColumnEdit = this.repRemark;
            this.gdcRemark.FieldName = "Remark";
            this.gdcRemark.Name = "gdcRemark";
            this.gdcRemark.Visible = true;
            this.gdcRemark.VisibleIndex = 9;
            this.gdcRemark.Width = 140;
            // 
            // repRemark
            // 
            this.repRemark.AutoHeight = false;
            this.repRemark.Name = "repRemark";
            // 
            // gdcErrorDetail
            // 
            this.gdcErrorDetail.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdcErrorDetail.AppearanceCell.Options.UseFont = true;
            this.gdcErrorDetail.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcErrorDetail.AppearanceHeader.Options.UseFont = true;
            this.gdcErrorDetail.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcErrorDetail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcErrorDetail.Caption = "Error Detail";
            this.gdcErrorDetail.ColumnEdit = this.repErrorDetail;
            this.gdcErrorDetail.FieldName = "ErrorDetail";
            this.gdcErrorDetail.Name = "gdcErrorDetail";
            this.gdcErrorDetail.OptionsColumn.AllowEdit = false;
            this.gdcErrorDetail.Visible = true;
            this.gdcErrorDetail.VisibleIndex = 10;
            this.gdcErrorDetail.Width = 317;
            // 
            // repErrorDetail
            // 
            this.repErrorDetail.Name = "repErrorDetail";
            // 
            // dlgXMSS320_SalePrice
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 400);
            this.Controls.Add(this.grdResult);
            this.Name = "dlgXMSS320_SalePrice";
            this.Text = "dlgXMSS320_SalePrice";
            this.Load += new System.EventHandler(this.dlgXMSS320_SalePrice_Load);
            this.Controls.SetChildIndex(this.grdResult, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSalePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCurrencyCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEffectiveDate.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPVCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repErrorDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvResult;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCustomerCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repCustomerCode;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gdcrepCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcrepCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcProductCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repItemCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gdcrepProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcrepProductName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSalePrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repSalePrice;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCurrencyCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repCurrencyCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gdcrepCurrencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcrepCurrencyName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcIncoterm;
        private DevExpress.XtraGrid.Columns.GridColumn gdcEffectiveDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repEffectiveDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcImplementDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcHSCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPrivilegeFormat;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repPVCode;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gdcrepPVCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcrepPVName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcRemark;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gdcErrorDetail;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repErrorDetail;

    }
}
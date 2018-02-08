namespace Rubix.Screen.Form.Master.Dialog
{
    partial class dlgXMSS330_PurchasePrice
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
            this.gdcOwnerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcOwnerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSupplierID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSupplierCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPurchasePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repPurchasePrice = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gdcCurrencyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcIncoterm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcEffectiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repEffectiveDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gdcImplementDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcErrorDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repErrorDetail = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPurchasePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEffectiveDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEffectiveDate.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repErrorDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // grdResult
            // 
            this.grdResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdResult.Location = new System.Drawing.Point(0, 31);
            this.grdResult.MainView = this.gdvResult;
            this.grdResult.Name = "grdResult";
            this.grdResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repEffectiveDate,
            this.repPurchasePrice,
            this.repErrorDetail});
            this.grdResult.Size = new System.Drawing.Size(1132, 369);
            this.grdResult.TabIndex = 4;
            this.grdResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvResult});
            // 
            // gdvResult
            // 
            this.gdvResult.ColumnPanelRowHeight = 50;
            this.gdvResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcOwnerID,
            this.gdcOwnerCode,
            this.gdcSupplierID,
            this.gdcSupplierCode,
            this.gdcProductID,
            this.gdcProductCode,
            this.gcPurchasePrice,
            this.gdcCurrencyID,
            this.gdcCurrencyCode,
            this.gdcIncoterm,
            this.gdcEffectiveDate,
            this.gdcImplementDate,
            this.gdcRemark,
            this.gdcErrorDetail});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Red;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "[ErrorDetail] != null && [ErrorDetail] != \'\'";
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
            // gdcOwnerID
            // 
            this.gdcOwnerID.Caption = "OwnerID";
            this.gdcOwnerID.FieldName = "OwnerID";
            this.gdcOwnerID.Name = "gdcOwnerID";
            // 
            // gdcOwnerCode
            // 
            this.gdcOwnerCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcOwnerCode.AppearanceHeader.Options.UseFont = true;
            this.gdcOwnerCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcOwnerCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcOwnerCode.Caption = "Owner Code <color=\"red\">*</color> ";
            this.gdcOwnerCode.FieldName = "OwnerCode";
            this.gdcOwnerCode.Name = "gdcOwnerCode";
            this.gdcOwnerCode.OptionsColumn.AllowEdit = false;
            this.gdcOwnerCode.Visible = true;
            this.gdcOwnerCode.VisibleIndex = 0;
            // 
            // gdcSupplierID
            // 
            this.gdcSupplierID.Caption = "SupplierID";
            this.gdcSupplierID.FieldName = "SupplierID";
            this.gdcSupplierID.Name = "gdcSupplierID";
            // 
            // gdcSupplierCode
            // 
            this.gdcSupplierCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcSupplierCode.AppearanceHeader.Options.UseFont = true;
            this.gdcSupplierCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSupplierCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSupplierCode.Caption = "Supplier Code <color=\"red\">*</color> ";
            this.gdcSupplierCode.FieldName = "SupplierCode";
            this.gdcSupplierCode.Name = "gdcSupplierCode";
            this.gdcSupplierCode.OptionsColumn.AllowEdit = false;
            this.gdcSupplierCode.Visible = true;
            this.gdcSupplierCode.VisibleIndex = 1;
            this.gdcSupplierCode.Width = 123;
            // 
            // gdcProductID
            // 
            this.gdcProductID.Caption = "ItemID";
            this.gdcProductID.FieldName = "ProductID";
            this.gdcProductID.Name = "gdcProductID";
            // 
            // gdcProductCode
            // 
            this.gdcProductCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcProductCode.AppearanceHeader.Options.UseFont = true;
            this.gdcProductCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcProductCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcProductCode.Caption = "Item Code <color=\"red\">*</color> ";
            this.gdcProductCode.FieldName = "ProductCode";
            this.gdcProductCode.Name = "gdcProductCode";
            this.gdcProductCode.OptionsColumn.AllowEdit = false;
            this.gdcProductCode.Visible = true;
            this.gdcProductCode.VisibleIndex = 2;
            this.gdcProductCode.Width = 121;
            // 
            // gcPurchasePrice
            // 
            this.gcPurchasePrice.AppearanceCell.Options.UseTextOptions = true;
            this.gcPurchasePrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gcPurchasePrice.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcPurchasePrice.AppearanceHeader.Options.UseFont = true;
            this.gcPurchasePrice.AppearanceHeader.Options.UseTextOptions = true;
            this.gcPurchasePrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcPurchasePrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gcPurchasePrice.Caption = "Purchase Price <color=\"red\">*</color> ";
            this.gcPurchasePrice.ColumnEdit = this.repPurchasePrice;
            this.gcPurchasePrice.FieldName = "PurchasePrice";
            this.gcPurchasePrice.Name = "gcPurchasePrice";
            this.gcPurchasePrice.OptionsColumn.AllowEdit = false;
            this.gcPurchasePrice.Visible = true;
            this.gcPurchasePrice.VisibleIndex = 3;
            this.gcPurchasePrice.Width = 68;
            // 
            // repPurchasePrice
            // 
            this.repPurchasePrice.AutoHeight = false;
            this.repPurchasePrice.DisplayFormat.FormatString = "#,##0.00";
            this.repPurchasePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repPurchasePrice.EditFormat.FormatString = "#,##0.00";
            this.repPurchasePrice.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repPurchasePrice.Mask.EditMask = "#,##0.00";
            this.repPurchasePrice.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repPurchasePrice.Name = "repPurchasePrice";
            // 
            // gdcCurrencyID
            // 
            this.gdcCurrencyID.Caption = "CurrencyID";
            this.gdcCurrencyID.FieldName = "CurrencyID";
            this.gdcCurrencyID.Name = "gdcCurrencyID";
            // 
            // gdcCurrencyCode
            // 
            this.gdcCurrencyCode.AppearanceCell.Options.UseTextOptions = true;
            this.gdcCurrencyCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gdcCurrencyCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCurrencyCode.AppearanceHeader.Options.UseFont = true;
            this.gdcCurrencyCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCurrencyCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCurrencyCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gdcCurrencyCode.Caption = "Currency Code <color=\"red\">*</color> ";
            this.gdcCurrencyCode.FieldName = "CurrencyCode";
            this.gdcCurrencyCode.Name = "gdcCurrencyCode";
            this.gdcCurrencyCode.OptionsColumn.AllowEdit = false;
            this.gdcCurrencyCode.Visible = true;
            this.gdcCurrencyCode.VisibleIndex = 4;
            this.gdcCurrencyCode.Width = 65;
            // 
            // gdcIncoterm
            // 
            this.gdcIncoterm.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcIncoterm.AppearanceHeader.Options.UseFont = true;
            this.gdcIncoterm.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcIncoterm.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcIncoterm.Caption = "Incoterm";
            this.gdcIncoterm.FieldName = "Incoterm";
            this.gdcIncoterm.Name = "gdcIncoterm";
            this.gdcIncoterm.OptionsColumn.AllowEdit = false;
            this.gdcIncoterm.Visible = true;
            this.gdcIncoterm.VisibleIndex = 5;
            this.gdcIncoterm.Width = 142;
            // 
            // gdcEffectiveDate
            // 
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
            this.gdcEffectiveDate.Name = "gdcEffectiveDate";
            this.gdcEffectiveDate.OptionsColumn.AllowEdit = false;
            this.gdcEffectiveDate.Visible = true;
            this.gdcEffectiveDate.VisibleIndex = 6;
            this.gdcEffectiveDate.Width = 117;
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
            this.gdcImplementDate.AppearanceCell.Options.UseTextOptions = true;
            this.gdcImplementDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcImplementDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcImplementDate.AppearanceHeader.Options.UseFont = true;
            this.gdcImplementDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcImplementDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcImplementDate.Caption = "Implement Date";
            this.gdcImplementDate.ColumnEdit = this.repEffectiveDate;
            this.gdcImplementDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gdcImplementDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcImplementDate.FieldName = "ImplementDate";
            this.gdcImplementDate.Name = "gdcImplementDate";
            this.gdcImplementDate.OptionsColumn.AllowEdit = false;
            this.gdcImplementDate.Visible = true;
            this.gdcImplementDate.VisibleIndex = 7;
            this.gdcImplementDate.Width = 127;
            // 
            // gdcRemark
            // 
            this.gdcRemark.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcRemark.AppearanceHeader.Options.UseFont = true;
            this.gdcRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcRemark.Caption = "Remark";
            this.gdcRemark.FieldName = "Remark";
            this.gdcRemark.Name = "gdcRemark";
            this.gdcRemark.OptionsColumn.AllowEdit = false;
            this.gdcRemark.Visible = true;
            this.gdcRemark.VisibleIndex = 8;
            this.gdcRemark.Width = 135;
            // 
            // gdcErrorDetail
            // 
            this.gdcErrorDetail.AppearanceCell.Options.UseTextOptions = true;
            this.gdcErrorDetail.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gdcErrorDetail.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcErrorDetail.AppearanceHeader.Options.UseFont = true;
            this.gdcErrorDetail.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcErrorDetail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcErrorDetail.Caption = "Error Detail";
            this.gdcErrorDetail.ColumnEdit = this.repErrorDetail;
            this.gdcErrorDetail.FieldName = "ErrorDetail";
            this.gdcErrorDetail.Name = "gdcErrorDetail";
            this.gdcErrorDetail.OptionsColumn.AllowEdit = false;
            this.gdcErrorDetail.Visible = true;
            this.gdcErrorDetail.VisibleIndex = 9;
            this.gdcErrorDetail.Width = 266;
            // 
            // repErrorDetail
            // 
            this.repErrorDetail.Name = "repErrorDetail";
            // 
            // dlgXMSS330_PurchasePrice
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 400);
            this.Controls.Add(this.grdResult);
            this.Name = "dlgXMSS330_PurchasePrice";
            this.Text = "XMSS331 : Purchase Price Dialog";
            this.Load += new System.EventHandler(this.dlgXMSS330_PurchasePrice_Load);
            this.Controls.SetChildIndex(this.grdResult, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repPurchasePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEffectiveDate.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repEffectiveDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repErrorDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdResult;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repPurchasePrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repEffectiveDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repErrorDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvResult;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSupplierCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcPurchasePrice;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCurrencyCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcIncoterm;
        private DevExpress.XtraGrid.Columns.GridColumn gdcEffectiveDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcImplementDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gdcErrorDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerID;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSupplierID;
        private DevExpress.XtraGrid.Columns.GridColumn gdcProductID;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCurrencyID;

    }
}
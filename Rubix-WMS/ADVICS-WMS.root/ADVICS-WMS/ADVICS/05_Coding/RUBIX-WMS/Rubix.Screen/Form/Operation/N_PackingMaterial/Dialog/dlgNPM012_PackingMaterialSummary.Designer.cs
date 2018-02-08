namespace Rubix.Screen.Form.Operation.N_PackingMaterial.Dialog
{
    partial class dlgNPM012_PackingMaterialSummary
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
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcProductLongName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcBom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repNumberReadOnly = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gdcPrevBal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcReserved = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcDamage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repNumberEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gdcAdjust = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcTotalOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPeriod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcMinOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSafetyStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcEstimateStockNextMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSupplierCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPurchasePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.rdoWithOutSafe = new DevExpress.XtraEditors.CheckEdit();
            this.rdoWithSafe = new DevExpress.XtraEditors.CheckEdit();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNumberReadOnly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNumberEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoWithOutSafe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoWithSafe.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSearchResult.Location = new System.Drawing.Point(0, 90);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repNumberEdit,
            this.repNumberReadOnly});
            this.grdSearchResult.Size = new System.Drawing.Size(1125, 279);
            this.grdSearchResult.TabIndex = 4;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcProductLongName,
            this.gdcBom,
            this.gdcPrevBal,
            this.gdcReserved,
            this.gdcDamage,
            this.gdcAdjust,
            this.gdcTotalOrder,
            this.gdcProductID,
            this.gdcProductCode,
            this.gdcPeriod,
            this.gdcMinOrder,
            this.gdcSafetyStock,
            this.gdcEstimateStockNextMonth,
            this.gdcSupplierCode,
            this.gdcPurchasePrice});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsView.AllowCellMerge = true;
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            this.gdvSearchResult.OptionsView.ShowGroupPanel = false;
            this.gdvSearchResult.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.gdvSearchResult_CellMerge);
            this.gdvSearchResult.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gdvSearchResult_RowCellStyle);
            // 
            // gdcProductLongName
            // 
            this.gdcProductLongName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcProductLongName.AppearanceHeader.Options.UseFont = true;
            this.gdcProductLongName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcProductLongName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcProductLongName.Caption = "Product Name";
            this.gdcProductLongName.FieldName = "ProductLongName";
            this.gdcProductLongName.Name = "gdcProductLongName";
            this.gdcProductLongName.OptionsColumn.AllowEdit = false;
            this.gdcProductLongName.Visible = true;
            this.gdcProductLongName.VisibleIndex = 3;
            this.gdcProductLongName.Width = 99;
            // 
            // gdcBom
            // 
            this.gdcBom.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcBom.AppearanceHeader.Options.UseFont = true;
            this.gdcBom.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcBom.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcBom.Caption = "BOM";
            this.gdcBom.ColumnEdit = this.repNumberReadOnly;
            this.gdcBom.FieldName = "BOMQty";
            this.gdcBom.Name = "gdcBom";
            this.gdcBom.OptionsColumn.AllowEdit = false;
            this.gdcBom.Visible = true;
            this.gdcBom.VisibleIndex = 4;
            // 
            // repNumberReadOnly
            // 
            this.repNumberReadOnly.AutoHeight = false;
            this.repNumberReadOnly.DisplayFormat.FormatString = "#,##0";
            this.repNumberReadOnly.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repNumberReadOnly.EditFormat.FormatString = "#,##0";
            this.repNumberReadOnly.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repNumberReadOnly.Mask.EditMask = "d";
            this.repNumberReadOnly.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repNumberReadOnly.Name = "repNumberReadOnly";
            this.repNumberReadOnly.ReadOnly = true;
            // 
            // gdcPrevBal
            // 
            this.gdcPrevBal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPrevBal.AppearanceHeader.Options.UseFont = true;
            this.gdcPrevBal.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPrevBal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPrevBal.Caption = "Prev. Bal";
            this.gdcPrevBal.ColumnEdit = this.repNumberReadOnly;
            this.gdcPrevBal.FieldName = "CURRENTQty";
            this.gdcPrevBal.Name = "gdcPrevBal";
            this.gdcPrevBal.OptionsColumn.AllowEdit = false;
            this.gdcPrevBal.Visible = true;
            this.gdcPrevBal.VisibleIndex = 5;
            // 
            // gdcReserved
            // 
            this.gdcReserved.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcReserved.AppearanceHeader.Options.UseFont = true;
            this.gdcReserved.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcReserved.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcReserved.Caption = "Reserved";
            this.gdcReserved.ColumnEdit = this.repNumberReadOnly;
            this.gdcReserved.FieldName = "RESERVEDQty";
            this.gdcReserved.Name = "gdcReserved";
            this.gdcReserved.OptionsColumn.AllowEdit = false;
            this.gdcReserved.Visible = true;
            this.gdcReserved.VisibleIndex = 6;
            // 
            // gdcDamage
            // 
            this.gdcDamage.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdcDamage.AppearanceCell.Options.UseBackColor = true;
            this.gdcDamage.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcDamage.AppearanceHeader.Options.UseFont = true;
            this.gdcDamage.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcDamage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcDamage.Caption = "DMG";
            this.gdcDamage.ColumnEdit = this.repNumberEdit;
            this.gdcDamage.FieldName = "DMGQty";
            this.gdcDamage.Name = "gdcDamage";
            this.gdcDamage.Visible = true;
            this.gdcDamage.VisibleIndex = 9;
            // 
            // repNumberEdit
            // 
            this.repNumberEdit.AutoHeight = false;
            this.repNumberEdit.DisplayFormat.FormatString = "#,##0";
            this.repNumberEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repNumberEdit.EditFormat.FormatString = "#,##0";
            this.repNumberEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repNumberEdit.Mask.EditMask = "d";
            this.repNumberEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repNumberEdit.Name = "repNumberEdit";
            this.repNumberEdit.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.repNumberEdit_EditValueChanging);
            // 
            // gdcAdjust
            // 
            this.gdcAdjust.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gdcAdjust.AppearanceCell.Options.UseBackColor = true;
            this.gdcAdjust.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcAdjust.AppearanceHeader.Options.UseFont = true;
            this.gdcAdjust.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcAdjust.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcAdjust.Caption = "Adjust";
            this.gdcAdjust.ColumnEdit = this.repNumberEdit;
            this.gdcAdjust.FieldName = "Adjust";
            this.gdcAdjust.Name = "gdcAdjust";
            this.gdcAdjust.Visible = true;
            this.gdcAdjust.VisibleIndex = 10;
            // 
            // gdcTotalOrder
            // 
            this.gdcTotalOrder.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcTotalOrder.AppearanceHeader.Options.UseFont = true;
            this.gdcTotalOrder.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcTotalOrder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcTotalOrder.Caption = "Total Order";
            this.gdcTotalOrder.ColumnEdit = this.repNumberReadOnly;
            this.gdcTotalOrder.FieldName = "TotalOrder";
            this.gdcTotalOrder.Name = "gdcTotalOrder";
            this.gdcTotalOrder.OptionsColumn.AllowEdit = false;
            this.gdcTotalOrder.Visible = true;
            this.gdcTotalOrder.VisibleIndex = 11;
            // 
            // gdcProductID
            // 
            this.gdcProductID.Caption = "ProductID";
            this.gdcProductID.FieldName = "ProductID";
            this.gdcProductID.Name = "gdcProductID";
            // 
            // gdcProductCode
            // 
            this.gdcProductCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcProductCode.AppearanceHeader.Options.UseFont = true;
            this.gdcProductCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcProductCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcProductCode.Caption = "Product Code";
            this.gdcProductCode.FieldName = "ProductCode";
            this.gdcProductCode.Name = "gdcProductCode";
            this.gdcProductCode.OptionsColumn.AllowEdit = false;
            this.gdcProductCode.Visible = true;
            this.gdcProductCode.VisibleIndex = 2;
            this.gdcProductCode.Width = 113;
            // 
            // gdcPeriod
            // 
            this.gdcPeriod.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPeriod.AppearanceHeader.Options.UseFont = true;
            this.gdcPeriod.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPeriod.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPeriod.Caption = "Period";
            this.gdcPeriod.FieldName = "Period";
            this.gdcPeriod.Name = "gdcPeriod";
            this.gdcPeriod.OptionsColumn.AllowEdit = false;
            this.gdcPeriod.Visible = true;
            this.gdcPeriod.VisibleIndex = 1;
            // 
            // gdcMinOrder
            // 
            this.gdcMinOrder.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcMinOrder.AppearanceHeader.Options.UseFont = true;
            this.gdcMinOrder.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcMinOrder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcMinOrder.Caption = "Min Order";
            this.gdcMinOrder.ColumnEdit = this.repNumberReadOnly;
            this.gdcMinOrder.FieldName = "MinOrder";
            this.gdcMinOrder.Name = "gdcMinOrder";
            this.gdcMinOrder.OptionsColumn.AllowEdit = false;
            this.gdcMinOrder.Visible = true;
            this.gdcMinOrder.VisibleIndex = 7;
            // 
            // gdcSafetyStock
            // 
            this.gdcSafetyStock.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcSafetyStock.AppearanceHeader.Options.UseFont = true;
            this.gdcSafetyStock.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSafetyStock.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSafetyStock.Caption = "Safety Stock";
            this.gdcSafetyStock.ColumnEdit = this.repNumberReadOnly;
            this.gdcSafetyStock.FieldName = "SafetyStock";
            this.gdcSafetyStock.Name = "gdcSafetyStock";
            this.gdcSafetyStock.OptionsColumn.AllowEdit = false;
            this.gdcSafetyStock.Visible = true;
            this.gdcSafetyStock.VisibleIndex = 8;
            this.gdcSafetyStock.Width = 99;
            // 
            // gdcEstimateStockNextMonth
            // 
            this.gdcEstimateStockNextMonth.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcEstimateStockNextMonth.AppearanceHeader.Options.UseFont = true;
            this.gdcEstimateStockNextMonth.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcEstimateStockNextMonth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcEstimateStockNextMonth.Caption = "Estimate Stock Next Month";
            this.gdcEstimateStockNextMonth.ColumnEdit = this.repNumberReadOnly;
            this.gdcEstimateStockNextMonth.FieldName = "EstimateStockNextMonth";
            this.gdcEstimateStockNextMonth.Name = "gdcEstimateStockNextMonth";
            this.gdcEstimateStockNextMonth.OptionsColumn.AllowEdit = false;
            this.gdcEstimateStockNextMonth.Visible = true;
            this.gdcEstimateStockNextMonth.VisibleIndex = 12;
            this.gdcEstimateStockNextMonth.Width = 192;
            // 
            // gdcSupplierCode
            // 
            this.gdcSupplierCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcSupplierCode.AppearanceHeader.Options.UseFont = true;
            this.gdcSupplierCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSupplierCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSupplierCode.Caption = "Supplier Code";
            this.gdcSupplierCode.FieldName = "SupplierCode";
            this.gdcSupplierCode.Name = "gdcSupplierCode";
            this.gdcSupplierCode.OptionsColumn.AllowEdit = false;
            this.gdcSupplierCode.Visible = true;
            this.gdcSupplierCode.VisibleIndex = 0;
            this.gdcSupplierCode.Width = 100;
            // 
            // gdcPurchasePrice
            // 
            this.gdcPurchasePrice.Caption = "PurchasePrice";
            this.gdcPurchasePrice.FieldName = "PurchasePrice";
            this.gdcPurchasePrice.Name = "gdcPurchasePrice";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnExport);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.rdoWithOutSafe);
            this.panelControl1.Controls.Add(this.rdoWithSafe);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 31);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1125, 59);
            this.panelControl1.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Location = new System.Drawing.Point(1027, 21);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(86, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "No Purchase Price";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.Red;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(1001, 19);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(20, 18);
            this.labelControl2.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(12, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Calulate Mathod";
            // 
            // rdoWithOutSafe
            // 
            this.rdoWithOutSafe.Location = new System.Drawing.Point(177, 30);
            this.rdoWithOutSafe.Name = "rdoWithOutSafe";
            this.rdoWithOutSafe.Properties.AutoHeight = false;
            this.rdoWithOutSafe.Properties.Caption = "Calculate without SafetyStock";
            this.rdoWithOutSafe.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdoWithOutSafe.Properties.RadioGroupIndex = 1;
            this.rdoWithOutSafe.Size = new System.Drawing.Size(177, 19);
            this.rdoWithOutSafe.TabIndex = 1;
            this.rdoWithOutSafe.TabStop = false;
            // 
            // rdoWithSafe
            // 
            this.rdoWithSafe.EditValue = true;
            this.rdoWithSafe.Location = new System.Drawing.Point(12, 30);
            this.rdoWithSafe.Name = "rdoWithSafe";
            this.rdoWithSafe.Properties.AutoHeight = false;
            this.rdoWithSafe.Properties.Caption = "Calculate with SafetyStock";
            this.rdoWithSafe.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdoWithSafe.Properties.RadioGroupIndex = 1;
            this.rdoWithSafe.Size = new System.Drawing.Size(159, 19);
            this.rdoWithSafe.TabIndex = 0;
            this.rdoWithSafe.CheckedChanged += new System.EventHandler(this.rdoWithSafe_CheckedChanged);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(360, 27);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dlgNPM012_PackingMaterialSummary
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 400);
            this.Controls.Add(this.grdSearchResult);
            this.Controls.Add(this.panelControl1);
            this.Name = "dlgNPM012_PackingMaterialSummary";
            this.Text = "NPM012 : Packing Material Summary";
            this.Load += new System.EventHandler(this.dlgNPM012_PackingMaterialSummary_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.grdSearchResult, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNumberReadOnly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repNumberEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoWithOutSafe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoWithSafe.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit rdoWithOutSafe;
        private DevExpress.XtraEditors.CheckEdit rdoWithSafe;
        private DevExpress.XtraGrid.Columns.GridColumn gdcProductLongName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcBom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repNumberReadOnly;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPrevBal;
        private DevExpress.XtraGrid.Columns.GridColumn gdcReserved;
        private DevExpress.XtraGrid.Columns.GridColumn gdcDamage;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repNumberEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gdcAdjust;
        private DevExpress.XtraGrid.Columns.GridColumn gdcTotalOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gdcProductID;
        private DevExpress.XtraGrid.Columns.GridColumn gdcProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPeriod;
        private DevExpress.XtraGrid.Columns.GridColumn gdcMinOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSafetyStock;
        private DevExpress.XtraGrid.Columns.GridColumn gdcEstimateStockNextMonth;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSupplierCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPurchasePrice;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnExport;
    }
}
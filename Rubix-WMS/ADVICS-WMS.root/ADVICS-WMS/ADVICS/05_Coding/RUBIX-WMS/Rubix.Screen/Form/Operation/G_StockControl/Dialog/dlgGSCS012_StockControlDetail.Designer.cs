namespace Rubix.Screen.Form.Operation.G_StockControl.Dialog
{
    partial class dlgGSCS012_StockControlDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgGSCS012_StockControlDetail));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblPickingNo = new DevExpress.XtraEditors.LabelControl();
            this.txtPickingNo = new DevExpress.XtraEditors.TextEdit();
            this.lblShipmentNo = new DevExpress.XtraEditors.LabelControl();
            this.txtShipmentNo = new DevExpress.XtraEditors.TextEdit();
            this.portOfDischarge = new Rubix.Control.PortOfDischarge();
            this.finalDestinationControl = new Rubix.Control.FinalDestinationControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnUpdateToZero = new DevExpress.XtraEditors.SimpleButton();
            this.grdSearchDetail = new DevExpress.XtraGrid.GridControl();
            this.spGSCS012StockControlDetailSearchResultBindingSource = new System.Windows.Forms.BindingSource();
            this.grvSearchDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLineno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSortedLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemCondition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAssignQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInventory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPickingNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipmentNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spGSCS012StockControlDetailSearchResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSearchDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.lblPickingNo);
            this.groupControl1.Controls.Add(this.txtPickingNo);
            this.groupControl1.Controls.Add(this.lblShipmentNo);
            this.groupControl1.Controls.Add(this.txtShipmentNo);
            this.groupControl1.Controls.Add(this.portOfDischarge);
            this.groupControl1.Controls.Add(this.finalDestinationControl);
            this.groupControl1.Location = new System.Drawing.Point(2, 36);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(857, 98);
            this.groupControl1.TabIndex = 31;
            this.groupControl1.Text = "Display Condition";
            // 
            // lblPickingNo
            // 
            this.lblPickingNo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblPickingNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPickingNo.Location = new System.Drawing.Point(310, 73);
            this.lblPickingNo.Name = "lblPickingNo";
            this.lblPickingNo.Size = new System.Drawing.Size(52, 18);
            this.lblPickingNo.TabIndex = 17;
            this.lblPickingNo.Text = "Picking No";
            // 
            // txtPickingNo
            // 
            this.txtPickingNo.Location = new System.Drawing.Point(369, 70);
            this.txtPickingNo.Name = "txtPickingNo";
            this.txtPickingNo.Properties.MaxLength = 22;
            this.txtPickingNo.Size = new System.Drawing.Size(168, 20);
            this.txtPickingNo.TabIndex = 16;
            // 
            // lblShipmentNo
            // 
            this.lblShipmentNo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblShipmentNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblShipmentNo.Location = new System.Drawing.Point(36, 73);
            this.lblShipmentNo.Name = "lblShipmentNo";
            this.lblShipmentNo.Size = new System.Drawing.Size(97, 17);
            this.lblShipmentNo.TabIndex = 15;
            this.lblShipmentNo.Text = "Shipment No";
            // 
            // txtShipmentNo
            // 
            this.txtShipmentNo.Location = new System.Drawing.Point(144, 70);
            this.txtShipmentNo.Name = "txtShipmentNo";
            this.txtShipmentNo.Properties.MaxLength = 22;
            this.txtShipmentNo.Size = new System.Drawing.Size(164, 20);
            this.txtShipmentNo.TabIndex = 14;
            // 
            // portOfDischarge
            // 
            this.portOfDischarge.ErrorText = "Port of Discharge Control is Require Field";
            this.portOfDischarge.Location = new System.Drawing.Point(47, 22);
            this.portOfDischarge.Name = "portOfDischarge";
            this.portOfDischarge.RequireField = false;
            this.portOfDischarge.Size = new System.Drawing.Size(493, 25);
            this.portOfDischarge.TabIndex = 13;
            // 
            // finalDestinationControl
            // 
            this.finalDestinationControl.ErrorText = "Final Destionation Control is Require Field";
            this.finalDestinationControl.Location = new System.Drawing.Point(50, 46);
            this.finalDestinationControl.Name = "finalDestinationControl";
            this.finalDestinationControl.ReadOnly = false;
            this.finalDestinationControl.RequireField = false;
            this.finalDestinationControl.Size = new System.Drawing.Size(488, 21);
            this.finalDestinationControl.TabIndex = 10;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.btnUpdateToZero);
            this.groupControl2.Controls.Add(this.grdSearchDetail);
            this.groupControl2.Location = new System.Drawing.Point(2, 140);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(857, 327);
            this.groupControl2.TabIndex = 32;
            this.groupControl2.Text = "Search Result";
            // 
            // btnUpdateToZero
            // 
            this.btnUpdateToZero.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateToZero.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateToZero.Image")));
            this.btnUpdateToZero.Location = new System.Drawing.Point(700, 299);
            this.btnUpdateToZero.Name = "btnUpdateToZero";
            this.btnUpdateToZero.Size = new System.Drawing.Size(147, 23);
            this.btnUpdateToZero.TabIndex = 33;
            this.btnUpdateToZero.Text = "Update Assign Qty to 0";
            this.btnUpdateToZero.Click += new System.EventHandler(this.btnUpdateToZero_Click);
            // 
            // grdSearchDetail
            // 
            this.grdSearchDetail.DataSource = this.spGSCS012StockControlDetailSearchResultBindingSource;
            this.grdSearchDetail.Location = new System.Drawing.Point(5, 29);
            this.grdSearchDetail.MainView = this.grvSearchDetail;
            this.grdSearchDetail.Name = "grdSearchDetail";
            this.grdSearchDetail.Size = new System.Drawing.Size(847, 267);
            this.grdSearchDetail.TabIndex = 33;
            this.grdSearchDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSearchDetail});
            // 
            // spGSCS012StockControlDetailSearchResultBindingSource
            // 
            this.spGSCS012StockControlDetailSearchResultBindingSource.DataSource = typeof(CSI.Business.DataObjects.sp_GSCS012_StockControlDetail_Search_Result);
            // 
            // grvSearchDetail
            // 
            this.grvSearchDetail.BestFitMaxRowCount = 50;
            this.grvSearchDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLineno,
            this.colSortedLineNo,
            this.colItemCode,
            this.colItemName,
            this.colItemCondition,
            this.colLotNo,
            this.colOrderQty,
            this.colAssignQty,
            this.colInventory,
            this.colUnitCode});
            this.grvSearchDetail.GridControl = this.grdSearchDetail;
            this.grvSearchDetail.Name = "grvSearchDetail";
            this.grvSearchDetail.OptionsBehavior.Editable = false;
            this.grvSearchDetail.OptionsView.ColumnAutoWidth = false;
            this.grvSearchDetail.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvSearchDetail_RowCellStyle);
            // 
            // colLineno
            // 
            this.colLineno.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colLineno.AppearanceHeader.Options.UseFont = true;
            this.colLineno.AppearanceHeader.Options.UseTextOptions = true;
            this.colLineno.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLineno.Caption = "Line No.";
            this.colLineno.FieldName = "Lineno";
            this.colLineno.Name = "colLineno";
            this.colLineno.OptionsColumn.AllowEdit = false;
            this.colLineno.OptionsColumn.ShowInCustomizationForm = false;
            this.colLineno.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // colSortedLineNo
            // 
            this.colSortedLineNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSortedLineNo.AppearanceHeader.Options.UseFont = true;
            this.colSortedLineNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colSortedLineNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSortedLineNo.Caption = "Line No";
            this.colSortedLineNo.FieldName = "SortedLineNo";
            this.colSortedLineNo.Name = "colSortedLineNo";
            this.colSortedLineNo.OptionsColumn.AllowEdit = false;
            this.colSortedLineNo.Visible = true;
            this.colSortedLineNo.VisibleIndex = 0;
            // 
            // colItemCode
            // 
            this.colItemCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colItemCode.AppearanceHeader.Options.UseFont = true;
            this.colItemCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colItemCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItemCode.FieldName = "ItemCode";
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.OptionsColumn.AllowEdit = false;
            this.colItemCode.Visible = true;
            this.colItemCode.VisibleIndex = 1;
            // 
            // colItemName
            // 
            this.colItemName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colItemName.AppearanceHeader.Options.UseFont = true;
            this.colItemName.AppearanceHeader.Options.UseTextOptions = true;
            this.colItemName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItemName.Caption = "Item Name";
            this.colItemName.FieldName = "ItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.OptionsColumn.AllowEdit = false;
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 3;
            // 
            // colItemCondition
            // 
            this.colItemCondition.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colItemCondition.AppearanceHeader.Options.UseFont = true;
            this.colItemCondition.AppearanceHeader.Options.UseTextOptions = true;
            this.colItemCondition.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItemCondition.FieldName = "ItemCondition";
            this.colItemCondition.Name = "colItemCondition";
            this.colItemCondition.OptionsColumn.AllowEdit = false;
            this.colItemCondition.Visible = true;
            this.colItemCondition.VisibleIndex = 2;
            // 
            // colLotNo
            // 
            this.colLotNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colLotNo.AppearanceHeader.Options.UseFont = true;
            this.colLotNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colLotNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLotNo.FieldName = "LotNo";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.OptionsColumn.AllowEdit = false;
            this.colLotNo.Visible = true;
            this.colLotNo.VisibleIndex = 4;
            // 
            // colOrderQty
            // 
            this.colOrderQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colOrderQty.AppearanceHeader.Options.UseFont = true;
            this.colOrderQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colOrderQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOrderQty.FieldName = "OrderQty";
            this.colOrderQty.Name = "colOrderQty";
            this.colOrderQty.OptionsColumn.AllowEdit = false;
            this.colOrderQty.Visible = true;
            this.colOrderQty.VisibleIndex = 5;
            // 
            // colAssignQty
            // 
            this.colAssignQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colAssignQty.AppearanceHeader.Options.UseFont = true;
            this.colAssignQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colAssignQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAssignQty.FieldName = "AssignQty";
            this.colAssignQty.Name = "colAssignQty";
            this.colAssignQty.Visible = true;
            this.colAssignQty.VisibleIndex = 6;
            // 
            // colInventory
            // 
            this.colInventory.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colInventory.AppearanceHeader.Options.UseFont = true;
            this.colInventory.AppearanceHeader.Options.UseTextOptions = true;
            this.colInventory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInventory.FieldName = "Inventory";
            this.colInventory.Name = "colInventory";
            this.colInventory.OptionsColumn.AllowEdit = false;
            this.colInventory.Visible = true;
            this.colInventory.VisibleIndex = 7;
            // 
            // colUnitCode
            // 
            this.colUnitCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUnitCode.AppearanceHeader.Options.UseFont = true;
            this.colUnitCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnitCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnitCode.FieldName = "UnitCode";
            this.colUnitCode.Name = "colUnitCode";
            this.colUnitCode.OptionsColumn.AllowEdit = false;
            this.colUnitCode.Visible = true;
            this.colUnitCode.VisibleIndex = 8;
            // 
            // dlgGSCS012_StockControlDetail
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 504);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgGSCS012_StockControlDetail";
            this.ShowIcon = false;
            this.Text = "GSCS011 : Stock Control Edit Dialog";
            this.Load += new System.EventHandler(this.dlgGSCS012_StockControlDetail_Load);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPickingNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipmentNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spGSCS012StockControlDetailSearchResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSearchDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSearchDetail;
        private Control.FinalDestinationControl finalDestinationControl;
        private Control.PortOfDischarge portOfDischarge;
        private DevExpress.XtraEditors.SimpleButton btnUpdateToZero;
        private DevExpress.XtraEditors.TextEdit txtShipmentNo;
        private DevExpress.XtraEditors.LabelControl lblShipmentNo;
        private DevExpress.XtraEditors.LabelControl lblPickingNo;
        private DevExpress.XtraEditors.TextEdit txtPickingNo;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.BindingSource spGSCS012StockControlDetailSearchResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colLineno;
        private DevExpress.XtraGrid.Columns.GridColumn colItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn colItemCondition;
        private DevExpress.XtraGrid.Columns.GridColumn colLotNo;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderQty;
        private DevExpress.XtraGrid.Columns.GridColumn colAssignQty;
        private DevExpress.XtraGrid.Columns.GridColumn colInventory;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitCode;
        private DevExpress.XtraGrid.Columns.GridColumn colSortedLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName;

    }
}
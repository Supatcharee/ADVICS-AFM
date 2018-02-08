namespace Rubix.Screen.Form.Operation.I_Shipping.Dialog
{
    partial class dlgISHS071_ConfirmReturnShipping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgISHS071_ConfirmReturnShipping));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtLotNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblPickingNo = new DevExpress.XtraEditors.LabelControl();
            this.txtPickingNo = new DevExpress.XtraEditors.TextEdit();
            this.itemConditionControl = new Rubix.Control.ItemConditionControl();
            this.itemControl = new Rubix.Control.ItemControl();
            this.txtLineNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtQtyActual = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtQty = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.btnDeleteLocation = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddLocation = new DevExpress.XtraEditors.SimpleButton();
            this.grdQtyActual = new DevExpress.XtraGrid.GridControl();
            this.gdvQtyActual = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLocation = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gdcMaxCap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcActual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repActualQty = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gdcCondition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCondition = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gdcFullCap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcSeq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.lblShipmentNo = new DevExpress.XtraEditors.LabelControl();
            this.txtShipmentNo = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPickingNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyActual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQtyActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvQtyActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repActualQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipmentNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtLotNo);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.lblPickingNo);
            this.groupControl1.Controls.Add(this.txtPickingNo);
            this.groupControl1.Controls.Add(this.itemConditionControl);
            this.groupControl1.Controls.Add(this.itemControl);
            this.groupControl1.Controls.Add(this.txtLineNo);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Location = new System.Drawing.Point(2, 98);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(615, 98);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Picking Information";
            // 
            // txtLotNo
            // 
            this.txtLotNo.Location = new System.Drawing.Point(411, 73);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Properties.ReadOnly = true;
            this.txtLotNo.Size = new System.Drawing.Size(185, 20);
            this.txtLotNo.TabIndex = 19;
            this.txtLotNo.Visible = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(344, 77);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(64, 16);
            this.labelControl6.TabIndex = 18;
            this.labelControl6.Text = "Lot No.";
            this.labelControl6.Visible = false;
            // 
            // lblPickingNo
            // 
            this.lblPickingNo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblPickingNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPickingNo.Location = new System.Drawing.Point(19, 30);
            this.lblPickingNo.Name = "lblPickingNo";
            this.lblPickingNo.Size = new System.Drawing.Size(89, 17);
            this.lblPickingNo.TabIndex = 17;
            this.lblPickingNo.Text = "Picking No.";
            // 
            // txtPickingNo
            // 
            this.txtPickingNo.Location = new System.Drawing.Point(121, 27);
            this.txtPickingNo.Name = "txtPickingNo";
            this.txtPickingNo.Properties.MaxLength = 22;
            this.txtPickingNo.Size = new System.Drawing.Size(124, 20);
            this.txtPickingNo.TabIndex = 16;
            // 
            // itemConditionControl
            // 
            this.itemConditionControl.ErrorText = "Item Condition Control is Require Field";
            this.itemConditionControl.Location = new System.Drawing.Point(19, 71);
            this.itemConditionControl.Name = "itemConditionControl";
            this.itemConditionControl.ProductID = null;
            this.itemConditionControl.RequireField = false;
            this.itemConditionControl.Size = new System.Drawing.Size(319, 22);
            this.itemConditionControl.TabIndex = 13;
            // 
            // itemControl
            // 
            this.itemControl.ErrorText = "Item Control is Require Field";
            this.itemControl.Location = new System.Drawing.Point(79, 49);
            this.itemControl.Name = "itemControl";
            this.itemControl.RequireField = false;
            this.itemControl.Size = new System.Drawing.Size(517, 22);
            this.itemControl.TabIndex = 12;
            // 
            // txtLineNo
            // 
            this.txtLineNo.Location = new System.Drawing.Point(337, 27);
            this.txtLineNo.Name = "txtLineNo";
            this.txtLineNo.Size = new System.Drawing.Size(73, 20);
            this.txtLineNo.TabIndex = 3;
            this.txtLineNo.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(269, 31);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(62, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Line No.";
            this.labelControl2.Visible = false;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtQtyActual);
            this.groupControl2.Controls.Add(this.labelControl9);
            this.groupControl2.Controls.Add(this.txtQty);
            this.groupControl2.Controls.Add(this.labelControl10);
            this.groupControl2.Location = new System.Drawing.Point(622, 99);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(247, 97);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "Qty Information ({0})";
            // 
            // txtQtyActual
            // 
            this.txtQtyActual.Location = new System.Drawing.Point(110, 51);
            this.txtQtyActual.Name = "txtQtyActual";
            this.txtQtyActual.Size = new System.Drawing.Size(122, 20);
            this.txtQtyActual.TabIndex = 3;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl9.Location = new System.Drawing.Point(5, 56);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(97, 15);
            this.labelControl9.TabIndex = 2;
            this.labelControl9.Text = "Sum of Qty Actual";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(110, 29);
            this.txtQty.Name = "txtQty";
            this.txtQty.Properties.DisplayFormat.FormatString = "#,##0.000";
            this.txtQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQty.Properties.MaxLength = 23;
            this.txtQty.Size = new System.Drawing.Size(122, 20);
            this.txtQty.TabIndex = 1;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl10.Location = new System.Drawing.Point(48, 34);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(54, 15);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "Qty";
            // 
            // groupControl4
            // 
            this.groupControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl4.Controls.Add(this.btnDeleteLocation);
            this.groupControl4.Controls.Add(this.btnAddLocation);
            this.groupControl4.Controls.Add(this.grdQtyActual);
            this.groupControl4.Location = new System.Drawing.Point(2, 202);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(867, 246);
            this.groupControl4.TabIndex = 7;
            this.groupControl4.Text = "Qty (Actual)";
            // 
            // btnDeleteLocation
            // 
            this.btnDeleteLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteLocation.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteLocation.Image")));
            this.btnDeleteLocation.Location = new System.Drawing.Point(811, 144);
            this.btnDeleteLocation.Name = "btnDeleteLocation";
            this.btnDeleteLocation.Size = new System.Drawing.Size(40, 36);
            this.btnDeleteLocation.TabIndex = 91;
            this.btnDeleteLocation.Click += new System.EventHandler(this.btnDeleteLocation_Click);
            // 
            // btnAddLocation
            // 
            this.btnAddLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddLocation.Image = ((System.Drawing.Image)(resources.GetObject("btnAddLocation.Image")));
            this.btnAddLocation.Location = new System.Drawing.Point(811, 91);
            this.btnAddLocation.Name = "btnAddLocation";
            this.btnAddLocation.Size = new System.Drawing.Size(40, 36);
            this.btnAddLocation.TabIndex = 90;
            this.btnAddLocation.Click += new System.EventHandler(this.btnAddLocation_Click);
            // 
            // grdQtyActual
            // 
            this.grdQtyActual.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdQtyActual.Location = new System.Drawing.Point(6, 24);
            this.grdQtyActual.MainView = this.gdvQtyActual;
            this.grdQtyActual.Name = "grdQtyActual";
            this.grdQtyActual.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLocation,
            this.repCheck,
            this.repCondition,
            this.repActualQty});
            this.grdQtyActual.Size = new System.Drawing.Size(792, 215);
            this.grdQtyActual.TabIndex = 0;
            this.grdQtyActual.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvQtyActual});
            // 
            // gdvQtyActual
            // 
            this.gdvQtyActual.BestFitMaxRowCount = 50;
            this.gdvQtyActual.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcLocation,
            this.gdcMaxCap,
            this.gdcQty,
            this.gdcActual,
            this.gdcCondition,
            this.gdcFullCap,
            this.gcSeq});
            this.gdvQtyActual.GridControl = this.grdQtyActual;
            this.gdvQtyActual.Name = "gdvQtyActual";
            this.gdvQtyActual.OptionsCustomization.AllowColumnMoving = false;
            this.gdvQtyActual.OptionsCustomization.AllowGroup = false;
            this.gdvQtyActual.OptionsCustomization.AllowQuickHideColumns = false;
            this.gdvQtyActual.OptionsCustomization.AllowSort = false;
            this.gdvQtyActual.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gdvQtyActual.OptionsView.ShowGroupPanel = false;
            this.gdvQtyActual.Tag = "";
            this.gdvQtyActual.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gdvQtyActual_RowCellStyle);
            // 
            // gdcLocation
            // 
            this.gdcLocation.Caption = "Location";
            this.gdcLocation.ColumnEdit = this.repLocation;
            this.gdcLocation.FieldName = "LocationID";
            this.gdcLocation.Name = "gdcLocation";
            this.gdcLocation.Tag = "";
            this.gdcLocation.Visible = true;
            this.gdcLocation.VisibleIndex = 0;
            // 
            // repLocation
            // 
            this.repLocation.AutoHeight = false;
            this.repLocation.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLocation.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationCode", "Location Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LocationName", "Location Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PalletNo", "Pallet No", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.repLocation.Name = "repLocation";
            this.repLocation.NullText = " ";
            this.repLocation.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.repLocation_EditValueChanging);
            // 
            // gdcMaxCap
            // 
            this.gdcMaxCap.Caption = "Total Capacity";
            this.gdcMaxCap.DisplayFormat.FormatString = "#,##0.000";
            this.gdcMaxCap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcMaxCap.FieldName = "TotalCapacity";
            this.gdcMaxCap.Name = "gdcMaxCap";
            this.gdcMaxCap.OptionsColumn.AllowEdit = false;
            this.gdcMaxCap.Visible = true;
            this.gdcMaxCap.VisibleIndex = 1;
            // 
            // gdcQty
            // 
            this.gdcQty.Caption = "Current Capacity";
            this.gdcQty.DisplayFormat.FormatString = "#,##0.000";
            this.gdcQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcQty.FieldName = "CurrentCapacity";
            this.gdcQty.Name = "gdcQty";
            this.gdcQty.OptionsColumn.AllowEdit = false;
            this.gdcQty.Visible = true;
            this.gdcQty.VisibleIndex = 2;
            // 
            // gdcActual
            // 
            this.gdcActual.Caption = "Qty (Actual)";
            this.gdcActual.ColumnEdit = this.repActualQty;
            this.gdcActual.DisplayFormat.FormatString = "#,##0.000";
            this.gdcActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcActual.FieldName = "StockActualQty";
            this.gdcActual.Name = "gdcActual";
            this.gdcActual.Visible = true;
            this.gdcActual.VisibleIndex = 3;
            // 
            // repActualQty
            // 
            this.repActualQty.AutoHeight = false;
            this.repActualQty.Mask.EditMask = "n3";
            this.repActualQty.Mask.UseMaskAsDisplayFormat = true;
            this.repActualQty.Name = "repActualQty";
            this.repActualQty.Leave += new System.EventHandler(this.repActualQty_Leave);
            // 
            // gdcCondition
            // 
            this.gdcCondition.Caption = "Item Condition";
            this.gdcCondition.ColumnEdit = this.repCondition;
            this.gdcCondition.FieldName = "ConditionID";
            this.gdcCondition.Name = "gdcCondition";
            this.gdcCondition.Visible = true;
            this.gdcCondition.VisibleIndex = 4;
            // 
            // repCondition
            // 
            this.repCondition.AutoHeight = false;
            this.repCondition.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repCondition.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductConditionID", "Item Condition ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductConditionCode", "Item Condition Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductConditionName", "Item Condition Name")});
            this.repCondition.Name = "repCondition";
            this.repCondition.NullText = "";
            // 
            // gdcFullCap
            // 
            this.gdcFullCap.Caption = "Full Current Capacity";
            this.gdcFullCap.ColumnEdit = this.repCheck;
            this.gdcFullCap.FieldName = "FullCapacityFlag";
            this.gdcFullCap.Name = "gdcFullCap";
            this.gdcFullCap.Visible = true;
            this.gdcFullCap.VisibleIndex = 5;
            // 
            // repCheck
            // 
            this.repCheck.AutoHeight = false;
            this.repCheck.Name = "repCheck";
            this.repCheck.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // gcSeq
            // 
            this.gcSeq.Caption = "gcSeq";
            this.gcSeq.FieldName = "PickingLineSeq";
            this.gcSeq.Name = "gcSeq";
            this.gcSeq.OptionsColumn.ShowInCustomizationForm = false;
            this.gcSeq.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.lblShipmentNo);
            this.groupControl3.Controls.Add(this.txtShipmentNo);
            this.groupControl3.Location = new System.Drawing.Point(2, 33);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(868, 60);
            this.groupControl3.TabIndex = 8;
            this.groupControl3.Text = "Shipment";
            // 
            // lblShipmentNo
            // 
            this.lblShipmentNo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblShipmentNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblShipmentNo.Location = new System.Drawing.Point(44, 31);
            this.lblShipmentNo.Name = "lblShipmentNo";
            this.lblShipmentNo.Size = new System.Drawing.Size(64, 13);
            this.lblShipmentNo.TabIndex = 10;
            this.lblShipmentNo.Text = "Shipment No.";
            // 
            // txtShipmentNo
            // 
            this.txtShipmentNo.Location = new System.Drawing.Point(121, 28);
            this.txtShipmentNo.Name = "txtShipmentNo";
            this.txtShipmentNo.Properties.MaxLength = 22;
            this.txtShipmentNo.Size = new System.Drawing.Size(210, 20);
            this.txtShipmentNo.TabIndex = 9;
            // 
            // dlgISHS071_ConfirmReturnShipping
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 451);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgISHS071_ConfirmReturnShipping";
            this.ShowIcon = false;
            this.Text = "ISHS071 : Confirmation of Return Shipping Location Dialog";
            this.Load += new System.EventHandler(this.dlgISHS071_ConfirmReturnShipping_Load);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            this.Controls.SetChildIndex(this.groupControl4, 0);
            this.Controls.SetChildIndex(this.groupControl3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPickingNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyActual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdQtyActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvQtyActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repActualQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtShipmentNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtLineNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit txtQtyActual;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtQty;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraGrid.GridControl grdQtyActual;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvQtyActual;
        private DevExpress.XtraEditors.SimpleButton btnDeleteLocation;
        private DevExpress.XtraEditors.SimpleButton btnAddLocation;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLocation;
        private DevExpress.XtraGrid.Columns.GridColumn gdcQty;
        private DevExpress.XtraGrid.Columns.GridColumn gdcActual;
        private Control.ItemConditionControl itemConditionControl;
        private Control.ItemControl itemControl;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LabelControl lblPickingNo;
        private DevExpress.XtraEditors.TextEdit txtPickingNo;
        private DevExpress.XtraEditors.LabelControl lblShipmentNo;
        private DevExpress.XtraEditors.TextEdit txtShipmentNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repLocation;
        private DevExpress.XtraEditors.TextEdit txtLotNo;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraGrid.Columns.GridColumn gdcFullCap;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheck;
        private DevExpress.XtraGrid.Columns.GridColumn gcSeq;
        private DevExpress.XtraGrid.Columns.GridColumn gdcMaxCap;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCondition;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repCondition;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repActualQty;
    }
}
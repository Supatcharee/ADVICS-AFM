namespace Rubix.Screen.Form.Operation.N_PackingMaterial.Dialog
{
    partial class dlgNPM011_PackingMaterialAdjustment
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
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEditPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvEditPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repQtyLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcEditdata)).BeginInit();
            this.gpcEditdata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpcMenuControl)).BeginInit();
            this.gpcMenuControl.SuspendLayout();
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
            this.grdEditPO.Size = new System.Drawing.Size(844, 414);
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
            this.BTNAdd.Location = new System.Drawing.Point(8, 26);
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
            this.gpcEditdata.Location = new System.Drawing.Point(0, 31);
            this.gpcEditdata.Name = "gpcEditdata";
            this.gpcEditdata.Size = new System.Drawing.Size(848, 437);
            this.gpcEditdata.TabIndex = 6;
            this.gpcEditdata.Text = "Adjust Plan";
            // 
            // gpcMenuControl
            // 
            this.gpcMenuControl.Controls.Add(this.BTNAdd);
            this.gpcMenuControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.gpcMenuControl.Location = new System.Drawing.Point(848, 31);
            this.gpcMenuControl.Name = "gpcMenuControl";
            this.gpcMenuControl.Size = new System.Drawing.Size(91, 437);
            this.gpcMenuControl.TabIndex = 7;
            this.gpcMenuControl.Text = "Menu";
            // 
            // dlgNPM011_PackingMaterialAdjustment
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 499);
            this.Controls.Add(this.gpcEditdata);
            this.Controls.Add(this.gpcMenuControl);
            this.Name = "dlgNPM011_PackingMaterialAdjustment";
            this.Text = "NPM011 : Packing Material Adjustment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgNPM011_PackingMaterialAdjustment_FormClosing);
            this.Load += new System.EventHandler(this.dlgNPM011_PackingMaterialAdjustment_Load);
            this.Controls.SetChildIndex(this.gpcMenuControl, 0);
            this.Controls.SetChildIndex(this.gpcEditdata, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEditPO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvEditPO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repQtyLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcEditdata)).EndInit();
            this.gpcEditdata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpcMenuControl)).EndInit();
            this.gpcMenuControl.ResumeLayout(false);
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
        private DevExpress.XtraGrid.Columns.GridColumn gdcSupplierCode;
    }
}
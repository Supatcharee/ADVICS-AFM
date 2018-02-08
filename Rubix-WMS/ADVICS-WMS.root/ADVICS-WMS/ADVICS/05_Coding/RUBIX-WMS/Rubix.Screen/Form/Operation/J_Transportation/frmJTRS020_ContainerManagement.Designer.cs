namespace Rubix.Screen.Form.Operation.J_Transportation
{
    partial class frmJTRS020_ContainerManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJTRS020_ContainerManagement));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.requireField4 = new Rubix.Control.RequireField();
            this.dtShippingTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dtShippingFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.pickingControl = new Rubix.Control.PickingControl();
            this.shipmentControl = new Rubix.Control.ShipmentControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gdcPackingNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcContainerNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPalletNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnUnselect = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtShippingTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtShippingTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtShippingFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtShippingFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Size = new System.Drawing.Size(808, 47);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.requireField4);
            this.groupControl1.Controls.Add(this.dtShippingTo);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.dtShippingFrom);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.pickingControl);
            this.groupControl1.Controls.Add(this.shipmentControl);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 78);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(808, 89);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Search Criteria";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(726, 53);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 137;
            this.btnClear.Text = "Clear";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(645, 53);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 136;
            this.btnSearch.Text = "Search";
            // 
            // requireField4
            // 
            this.requireField4.Location = new System.Drawing.Point(135, 58);
            this.requireField4.Name = "requireField4";
            this.requireField4.Size = new System.Drawing.Size(10, 10);
            this.requireField4.TabIndex = 135;
            // 
            // dtShippingTo
            // 
            this.dtShippingTo.EditValue = null;
            this.dtShippingTo.Location = new System.Drawing.Point(367, 52);
            this.dtShippingTo.Name = "dtShippingTo";
            this.dtShippingTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtShippingTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtShippingTo.Size = new System.Drawing.Size(123, 20);
            this.dtShippingTo.TabIndex = 132;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(329, 53);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(21, 17);
            this.labelControl3.TabIndex = 134;
            this.labelControl3.Text = "To";
            // 
            // dtShippingFrom
            // 
            this.dtShippingFrom.EditValue = null;
            this.dtShippingFrom.Location = new System.Drawing.Point(147, 52);
            this.dtShippingFrom.Name = "dtShippingFrom";
            this.dtShippingFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtShippingFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtShippingFrom.Size = new System.Drawing.Size(176, 20);
            this.dtShippingFrom.TabIndex = 131;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(33, 55);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(99, 17);
            this.labelControl4.TabIndex = 133;
            this.labelControl4.Text = "Shipping Date";
            // 
            // pickingControl
            // 
            this.pickingControl.ComboType = Rubix.Control.PickingControl.eComboType.Screen;
            this.pickingControl.ErrorText = "Picking Control is Require Field";
            this.pickingControl.Location = new System.Drawing.Point(329, 24);
            this.pickingControl.Name = "pickingControl";
            this.pickingControl.OwnerID = null;
            this.pickingControl.RequireField = false;
            this.pickingControl.Size = new System.Drawing.Size(309, 23);
            this.pickingControl.TabIndex = 1;
            this.pickingControl.WarehouseID = null;
            // 
            // shipmentControl
            // 
            this.shipmentControl.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.shipmentControl.Appearance.Options.UseBackColor = true;
            this.shipmentControl.ErrorText = "Shipment Control is Require Field";
            this.shipmentControl.Location = new System.Drawing.Point(12, 24);
            this.shipmentControl.Name = "shipmentControl";
            this.shipmentControl.RequireField = false;
            this.shipmentControl.Size = new System.Drawing.Size(311, 22);
            this.shipmentControl.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 167);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(808, 180);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "Search Result";
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSearchResult.Location = new System.Drawing.Point(2, 21);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.MenuManager = this.ribbonControl1;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repSelect});
            this.grdSearchResult.Size = new System.Drawing.Size(804, 157);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcSelect,
            this.gdcPackingNo,
            this.gdcContainerNo,
            this.gdcPalletNo,
            this.gdcWeight});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            // 
            // gdcSelect
            // 
            this.gdcSelect.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcSelect.AppearanceHeader.Options.UseFont = true;
            this.gdcSelect.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcSelect.Caption = "Select";
            this.gdcSelect.ColumnEdit = this.repSelect;
            this.gdcSelect.Name = "gdcSelect";
            this.gdcSelect.Visible = true;
            this.gdcSelect.VisibleIndex = 0;
            // 
            // repSelect
            // 
            this.repSelect.AutoHeight = false;
            this.repSelect.Name = "repSelect";
            // 
            // gdcPackingNo
            // 
            this.gdcPackingNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPackingNo.AppearanceHeader.Options.UseFont = true;
            this.gdcPackingNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPackingNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPackingNo.Caption = "Packing No.";
            this.gdcPackingNo.FieldName = "PackingNo";
            this.gdcPackingNo.Name = "gdcPackingNo";
            this.gdcPackingNo.Visible = true;
            this.gdcPackingNo.VisibleIndex = 1;
            // 
            // gdcContainerNo
            // 
            this.gdcContainerNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcContainerNo.AppearanceHeader.Options.UseFont = true;
            this.gdcContainerNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcContainerNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcContainerNo.Caption = "Container No.";
            this.gdcContainerNo.FieldName = "ContainerNo";
            this.gdcContainerNo.Name = "gdcContainerNo";
            this.gdcContainerNo.Visible = true;
            this.gdcContainerNo.VisibleIndex = 2;
            // 
            // gdcPalletNo
            // 
            this.gdcPalletNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPalletNo.AppearanceHeader.Options.UseFont = true;
            this.gdcPalletNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPalletNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPalletNo.Caption = "Pallet No.";
            this.gdcPalletNo.FieldName = "PalletNo";
            this.gdcPalletNo.Name = "gdcPalletNo";
            this.gdcPalletNo.Visible = true;
            this.gdcPalletNo.VisibleIndex = 3;
            // 
            // gdcWeight
            // 
            this.gdcWeight.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcWeight.AppearanceHeader.Options.UseFont = true;
            this.gdcWeight.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcWeight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcWeight.Caption = "Weight";
            this.gdcWeight.FieldName = "Weight";
            this.gdcWeight.Name = "gdcWeight";
            this.gdcWeight.Visible = true;
            this.gdcWeight.VisibleIndex = 4;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnUnselect);
            this.panelControl1.Controls.Add(this.btnSelect);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 347);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(808, 48);
            this.panelControl1.TabIndex = 7;
            // 
            // btnUnselect
            // 
            this.btnUnselect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUnselect.Image = ((System.Drawing.Image)(resources.GetObject("btnUnselect.Image")));
            this.btnUnselect.Location = new System.Drawing.Point(147, 13);
            this.btnUnselect.Name = "btnUnselect";
            this.btnUnselect.Size = new System.Drawing.Size(120, 23);
            this.btnUnselect.TabIndex = 46;
            this.btnUnselect.Text = "Unselect All";
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.Location = new System.Drawing.Point(12, 13);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(120, 23);
            this.btnSelect.TabIndex = 45;
            this.btnSelect.Text = "Select All";
            // 
            // frmJTRS020_ContainerManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 395);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmJTRS020_ContainerManagement";
            this.Text = "JTR020 : ContainerManagement";
            this.Load += new System.EventHandler(this.frmJTRS020_ContainerManagement_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtShippingTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtShippingTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtShippingFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtShippingFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Control.PickingControl pickingControl;
        private Control.ShipmentControl shipmentControl;
        private Control.RequireField requireField4;
        private DevExpress.XtraEditors.DateEdit dtShippingTo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dtShippingFrom;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSelect;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPackingNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcContainerNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPalletNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWeight;
        private DevExpress.XtraEditors.SimpleButton btnUnselect;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repSelect;
    }
}
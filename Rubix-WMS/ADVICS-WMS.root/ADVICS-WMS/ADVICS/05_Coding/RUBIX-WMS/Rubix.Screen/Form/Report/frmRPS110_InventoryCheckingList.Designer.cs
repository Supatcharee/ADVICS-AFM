namespace Rubix.Screen.Form.Report
{
    partial class frmRPS110_InventoryCheckingList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRPS110_InventoryCheckingList));
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.requireField3 = new Rubix.Control.RequireField();
            this.requireField2 = new Rubix.Control.RequireField();
            this.requireField1 = new Rubix.Control.RequireField();
            this.itemControl = new Rubix.Control.ItemControl();
            this.rdoZone = new DevExpress.XtraEditors.CheckEdit();
            this.rdoProduct = new DevExpress.XtraEditors.CheckEdit();
            this.zoneControl = new Rubix.Control.ZoneControl();
            this.dtMovementSince = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoZone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMovementSince.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMovementSince.Properties)).BeginInit();
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
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Controls.Add(this.requireField3);
            this.groupControl3.Controls.Add(this.requireField2);
            this.groupControl3.Controls.Add(this.requireField1);
            this.groupControl3.Controls.Add(this.itemControl);
            this.groupControl3.Controls.Add(this.rdoZone);
            this.groupControl3.Controls.Add(this.rdoProduct);
            this.groupControl3.Controls.Add(this.zoneControl);
            this.groupControl3.Controls.Add(this.dtMovementSince);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.warehouseControl);
            this.groupControl3.Controls.Add(this.ownerControl);
            this.groupControl3.Controls.Add(this.btnClear);
            this.groupControl3.Controls.Add(this.btnSearch);
            this.groupControl3.Location = new System.Drawing.Point(4, 33);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(858, 284);
            this.groupControl3.TabIndex = 44;
            this.groupControl3.Text = "Search Criteria";
            // 
            // requireField3
            // 
            this.requireField3.Location = new System.Drawing.Point(129, 79);
            this.requireField3.Name = "requireField3";
            this.requireField3.Size = new System.Drawing.Size(10, 10);
            this.requireField3.TabIndex = 133;
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(129, 54);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 132;
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(129, 30);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 131;
            // 
            // itemControl
            // 
            this.itemControl.ErrorText = "Item Control is Require Field";
            this.itemControl.Location = new System.Drawing.Point(101, 115);
            this.itemControl.Name = "itemControl";
            this.itemControl.RequireField = false;
            this.itemControl.Size = new System.Drawing.Size(429, 22);
            this.itemControl.TabIndex = 128;
            // 
            // rdoZone
            // 
            this.rdoZone.Location = new System.Drawing.Point(112, 143);
            this.rdoZone.Name = "rdoZone";
            this.rdoZone.Properties.Caption = "Inventory Checking List by Zone";
            this.rdoZone.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdoZone.Size = new System.Drawing.Size(199, 19);
            this.rdoZone.TabIndex = 127;
            this.rdoZone.CheckedChanged += new System.EventHandler(this.rdoZone_CheckedChanged);
            // 
            // rdoProduct
            // 
            this.rdoProduct.Location = new System.Drawing.Point(112, 96);
            this.rdoProduct.Name = "rdoProduct";
            this.rdoProduct.Properties.Caption = "Inventory Checking List by Item";
            this.rdoProduct.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdoProduct.Size = new System.Drawing.Size(199, 19);
            this.rdoProduct.TabIndex = 126;
            this.rdoProduct.CheckedChanged += new System.EventHandler(this.rdoProduct_CheckedChanged);
            // 
            // zoneControl
            // 
            this.zoneControl.ErrorText = "Zone Control is Require Field";
            this.zoneControl.Location = new System.Drawing.Point(69, 161);
            this.zoneControl.Name = "zoneControl";
            this.zoneControl.RequireField = false;
            this.zoneControl.Size = new System.Drawing.Size(461, 22);
            this.zoneControl.TabIndex = 125;
            // 
            // dtMovementSince
            // 
            this.dtMovementSince.EditValue = null;
            this.dtMovementSince.Location = new System.Drawing.Point(141, 72);
            this.dtMovementSince.Name = "dtMovementSince";
            this.dtMovementSince.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtMovementSince.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtMovementSince.Size = new System.Drawing.Size(123, 20);
            this.dtMovementSince.TabIndex = 122;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(5, 76);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(122, 13);
            this.labelControl1.TabIndex = 121;
            this.labelControl1.Text = "Movement As of";
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(66, 47);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(464, 21);
            this.warehouseControl.TabIndex = 120;
            this.warehouseControl.EditValueChanged += new System.EventHandler(this.warehouseControl_EditValueChanged);
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(81, 24);
            this.ownerControl.Name = "ownerControl";
            this.ownerControl.ReadOnly = false;
            this.ownerControl.RequireField = false;
            this.ownerControl.Size = new System.Drawing.Size(449, 21);
            this.ownerControl.TabIndex = 8;
            this.ownerControl.EditValueChanged += new System.EventHandler(this.customerControl_EditValueChanged);
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(455, 247);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(374, 247);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Report";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmRPS110_InventoryCheckingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 323);
            this.Controls.Add(this.groupControl3);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRPS110_InventoryCheckingList";
            this.Text = "RPS110 : Inventory Checking List Report";
            this.Load += new System.EventHandler(this.frmRPS110_InventoryCheckingList_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdoZone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMovementSince.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtMovementSince.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl3;
        private Control.ItemControl itemControl;
        private DevExpress.XtraEditors.CheckEdit rdoZone;
        private DevExpress.XtraEditors.CheckEdit rdoProduct;
        private Control.ZoneControl zoneControl;
        private DevExpress.XtraEditors.DateEdit dtMovementSince;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Control.WarehouseControl warehouseControl;
        private Control.OwnerControl ownerControl;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private Control.RequireField requireField3;
        private Control.RequireField requireField2;
        private Control.RequireField requireField1;
    }
}
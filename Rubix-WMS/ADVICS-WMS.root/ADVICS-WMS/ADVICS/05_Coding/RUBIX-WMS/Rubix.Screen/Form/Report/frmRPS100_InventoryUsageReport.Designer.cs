namespace Rubix.Screen.Form.Report
{
    partial class frmRPS100_InventoryUsageReport
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRPS100_InventoryUsageReport));
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.chkGraph = new DevExpress.XtraEditors.CheckEdit();
            this.chkTable = new DevExpress.XtraEditors.CheckEdit();
            this.requireField1 = new Rubix.Control.RequireField();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.dxErrorProviderMovement = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.requireField2 = new Rubix.Control.RequireField();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkGraph.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderMovement)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Size = new System.Drawing.Size(882, 47);
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Controls.Add(this.requireField2);
            this.groupControl3.Controls.Add(this.chkGraph);
            this.groupControl3.Controls.Add(this.chkTable);
            this.groupControl3.Controls.Add(this.requireField1);
            this.groupControl3.Controls.Add(this.warehouseControl);
            this.groupControl3.Controls.Add(this.btnClear);
            this.groupControl3.Controls.Add(this.btnSearch);
            this.groupControl3.Controls.Add(this.ownerControl);
            this.groupControl3.Location = new System.Drawing.Point(5, 34);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(873, 188);
            this.groupControl3.TabIndex = 46;
            this.groupControl3.Text = "Search Criteria";
            // 
            // chkGraph
            // 
            this.chkGraph.Location = new System.Drawing.Point(138, 101);
            this.chkGraph.MenuManager = this.ribbonControl1;
            this.chkGraph.Name = "chkGraph";
            this.chkGraph.Properties.Caption = "Graph";
            this.chkGraph.Size = new System.Drawing.Size(75, 19);
            this.chkGraph.TabIndex = 145;
            // 
            // chkTable
            // 
            this.chkTable.EditValue = true;
            this.chkTable.Location = new System.Drawing.Point(138, 76);
            this.chkTable.MenuManager = this.ribbonControl1;
            this.chkTable.Name = "chkTable";
            this.chkTable.Properties.Caption = "Table";
            this.chkTable.Size = new System.Drawing.Size(75, 19);
            this.chkTable.TabIndex = 144;
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(128, 34);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 143;
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(67, 50);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(490, 21);
            this.warehouseControl.TabIndex = 120;
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(482, 127);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(401, 127);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Report";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(81, 27);
            this.ownerControl.Name = "ownerControl";
            this.ownerControl.ReadOnly = false;
            this.ownerControl.RequireField = false;
            this.ownerControl.Size = new System.Drawing.Size(476, 21);
            this.ownerControl.TabIndex = 149;
            this.ownerControl.EditValueChanged += new System.EventHandler(this.customerControl_EditValueChanged);
            // 
            // dxErrorProviderMovement
            // 
            this.dxErrorProviderMovement.ContainerControl = this;
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(128, 55);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 150;
            // 
            // frmRPS100_InventoryUsageReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 226);
            this.Controls.Add(this.groupControl3);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRPS100_InventoryUsageReport";
            this.Text = "RPS100 : Inventory Usage Report";
            this.Load += new System.EventHandler(this.frmRPS100_InventoryUsageReport_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkGraph.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProviderMovement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl3;
        private Control.WarehouseControl warehouseControl;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private Control.RequireField requireField1;
        private DevExpress.XtraEditors.CheckEdit chkGraph;
        private DevExpress.XtraEditors.CheckEdit chkTable;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProviderMovement;
        private Control.OwnerControl ownerControl;
        private Control.RequireField requireField2;
    }
}
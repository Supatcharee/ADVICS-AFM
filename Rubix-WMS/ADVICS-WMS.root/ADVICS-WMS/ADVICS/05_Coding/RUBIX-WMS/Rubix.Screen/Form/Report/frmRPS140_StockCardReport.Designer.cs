namespace Rubix.Screen.Form.Report
{
    partial class frmRPS140_StockCardReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRPS140_StockCardReport));
            this.grpEdit = new DevExpress.XtraEditors.GroupControl();
            this.itemGroupControl = new Rubix.Control.ItemGroupControl();
            this.requireField2 = new Rubix.Control.RequireField();
            this.requireField4 = new Rubix.Control.RequireField();
            this.requireField3 = new Rubix.Control.RequireField();
            this.requireField1 = new Rubix.Control.RequireField();
            this.dteDateTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.itemControl = new Rubix.Control.ItemControl();
            this.dteDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpEdit)).BeginInit();
            this.grpEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDateFrom.Properties)).BeginInit();
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
            // grpEdit
            // 
            this.grpEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEdit.Controls.Add(this.itemGroupControl);
            this.grpEdit.Controls.Add(this.requireField2);
            this.grpEdit.Controls.Add(this.requireField4);
            this.grpEdit.Controls.Add(this.requireField3);
            this.grpEdit.Controls.Add(this.requireField1);
            this.grpEdit.Controls.Add(this.dteDateTo);
            this.grpEdit.Controls.Add(this.labelControl1);
            this.grpEdit.Controls.Add(this.itemControl);
            this.grpEdit.Controls.Add(this.dteDateFrom);
            this.grpEdit.Controls.Add(this.labelControl2);
            this.grpEdit.Controls.Add(this.warehouseControl);
            this.grpEdit.Controls.Add(this.ownerControl);
            this.grpEdit.Controls.Add(this.btnClear);
            this.grpEdit.Controls.Add(this.btnSearch);
            this.grpEdit.Location = new System.Drawing.Point(0, 31);
            this.grpEdit.Name = "grpEdit";
            this.grpEdit.Size = new System.Drawing.Size(875, 243);
            this.grpEdit.TabIndex = 46;
            this.grpEdit.Text = "Search Criteria";
            // 
            // itemGroupControl
            // 
            this.itemGroupControl.ErrorText = "Type Of Goods Control is Require Field";
            this.itemGroupControl.Location = new System.Drawing.Point(63, 68);
            this.itemGroupControl.Name = "itemGroupControl";
            this.itemGroupControl.RequireField = false;
            this.itemGroupControl.Size = new System.Drawing.Size(467, 23);
            this.itemGroupControl.TabIndex = 151;
            this.itemGroupControl.EditValueChanged += new System.EventHandler(this.typeOfGoodsControl_EditValueChanged);
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(130, 51);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 150;
            // 
            // requireField4
            // 
            this.requireField4.Location = new System.Drawing.Point(282, 124);
            this.requireField4.Name = "requireField4";
            this.requireField4.Size = new System.Drawing.Size(10, 10);
            this.requireField4.TabIndex = 146;
            // 
            // requireField3
            // 
            this.requireField3.Location = new System.Drawing.Point(129, 124);
            this.requireField3.Name = "requireField3";
            this.requireField3.Size = new System.Drawing.Size(10, 10);
            this.requireField3.TabIndex = 145;
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(130, 30);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 143;
            // 
            // dteDateTo
            // 
            this.dteDateTo.EditValue = null;
            this.dteDateTo.Location = new System.Drawing.Point(296, 117);
            this.dteDateTo.MenuManager = this.ribbonControl1;
            this.dteDateTo.Name = "dteDateTo";
            this.dteDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteDateTo.Size = new System.Drawing.Size(122, 20);
            this.dteDateTo.TabIndex = 142;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(270, 121);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 13);
            this.labelControl1.TabIndex = 141;
            this.labelControl1.Text = "To";
            // 
            // itemControl
            // 
            this.itemControl.ErrorText = "Item Control is Require Field";
            this.itemControl.Location = new System.Drawing.Point(100, 92);
            this.itemControl.Name = "itemControl";
            this.itemControl.RequireField = false;
            this.itemControl.Size = new System.Drawing.Size(430, 22);
            this.itemControl.TabIndex = 138;
            // 
            // dteDateFrom
            // 
            this.dteDateFrom.EditValue = null;
            this.dteDateFrom.Location = new System.Drawing.Point(140, 117);
            this.dteDateFrom.MenuManager = this.ribbonControl1;
            this.dteDateFrom.Name = "dteDateFrom";
            this.dteDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dteDateFrom.Size = new System.Drawing.Size(122, 20);
            this.dteDateFrom.TabIndex = 132;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(41, 120);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(82, 13);
            this.labelControl2.TabIndex = 130;
            this.labelControl2.Text = "Transaction Date";
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(67, 46);
            this.warehouseControl.Name = "warehouseControl";
            
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(464, 21);
            this.warehouseControl.TabIndex = 120;
            this.warehouseControl.EditValueChanged += new System.EventHandler(this.warehouseControl_EditValueChanged);
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
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
            this.btnClear.Location = new System.Drawing.Point(455, 195);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(374, 195);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Report";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmRPS140_StockCardReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 271);
            this.Controls.Add(this.grpEdit);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRPS140_StockCardReport";
            this.Text = "RPS130 : Stock Card Report";
            this.Load += new System.EventHandler(this.frmRPS140_StockCardReport_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.grpEdit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpEdit)).EndInit();
            this.grpEdit.ResumeLayout(false);
            this.grpEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteDateFrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpEdit;
        private Control.RequireField requireField4;
        private Control.RequireField requireField3;
        private Control.RequireField requireField1;
        private DevExpress.XtraEditors.DateEdit dteDateTo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Control.ItemControl itemControl;
        private DevExpress.XtraEditors.DateEdit dteDateFrom;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private Control.WarehouseControl warehouseControl;
        private Control.OwnerControl ownerControl;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private Control.RequireField requireField2;
        private Control.ItemGroupControl itemGroupControl;
    }
}
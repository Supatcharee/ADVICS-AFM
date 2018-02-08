namespace Rubix.Screen.Form.Report
{
    partial class frmRPS050_MovementReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRPS050_MovementReport));
            this.grpEdit = new DevExpress.XtraEditors.GroupControl();
            this.grpMode = new DevExpress.XtraEditors.GroupControl();
            this.chkMonthly = new DevExpress.XtraEditors.CheckEdit();
            this.chkDaily = new DevExpress.XtraEditors.CheckEdit();
            this.chkGraph = new DevExpress.XtraEditors.CheckEdit();
            this.requireField4 = new Rubix.Control.RequireField();
            this.requireField3 = new Rubix.Control.RequireField();
            this.requireField2 = new Rubix.Control.RequireField();
            this.requireField1 = new Rubix.Control.RequireField();
            this.dtReceivedDateTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkTable = new DevExpress.XtraEditors.CheckEdit();
            this.itemControl = new Rubix.Control.ItemControl();
            this.dtReceivedDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpEdit)).BeginInit();
            this.grpEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMode)).BeginInit();
            this.grpMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMonthly.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDaily.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGraph.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReceivedDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReceivedDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReceivedDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReceivedDateFrom.Properties)).BeginInit();
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
            // grpEdit
            // 
            this.grpEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEdit.Controls.Add(this.labelControl4);
            this.grpEdit.Controls.Add(this.grpMode);
            this.grpEdit.Controls.Add(this.chkGraph);
            this.grpEdit.Controls.Add(this.requireField4);
            this.grpEdit.Controls.Add(this.requireField3);
            this.grpEdit.Controls.Add(this.requireField2);
            this.grpEdit.Controls.Add(this.requireField1);
            this.grpEdit.Controls.Add(this.dtReceivedDateTo);
            this.grpEdit.Controls.Add(this.labelControl1);
            this.grpEdit.Controls.Add(this.chkTable);
            this.grpEdit.Controls.Add(this.itemControl);
            this.grpEdit.Controls.Add(this.dtReceivedDateFrom);
            this.grpEdit.Controls.Add(this.labelControl2);
            this.grpEdit.Controls.Add(this.warehouseControl);
            this.grpEdit.Controls.Add(this.ownerControl);
            this.grpEdit.Controls.Add(this.btnClear);
            this.grpEdit.Controls.Add(this.btnSearch);
            this.grpEdit.Location = new System.Drawing.Point(4, 33);
            this.grpEdit.Name = "grpEdit";
            this.grpEdit.Size = new System.Drawing.Size(875, 306);
            this.grpEdit.TabIndex = 45;
            this.grpEdit.Text = "Search Criteria";
            // 
            // grpMode
            // 
            this.grpMode.Controls.Add(this.chkMonthly);
            this.grpMode.Controls.Add(this.chkDaily);
            this.grpMode.Location = new System.Drawing.Point(201, 140);
            this.grpMode.Name = "grpMode";
            this.grpMode.ShowCaption = false;
            this.grpMode.Size = new System.Drawing.Size(174, 29);
            this.grpMode.TabIndex = 152;
            // 
            // chkMonthly
            // 
            this.chkMonthly.Location = new System.Drawing.Point(86, 5);
            this.chkMonthly.MenuManager = this.ribbonControl1;
            this.chkMonthly.Name = "chkMonthly";
            this.chkMonthly.Properties.Caption = "Monthly";
            this.chkMonthly.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkMonthly.Properties.RadioGroupIndex = 1;
            this.chkMonthly.Size = new System.Drawing.Size(75, 19);
            this.chkMonthly.TabIndex = 150;
            this.chkMonthly.TabStop = false;
            // 
            // chkDaily
            // 
            this.chkDaily.EditValue = true;
            this.chkDaily.Location = new System.Drawing.Point(5, 5);
            this.chkDaily.MenuManager = this.ribbonControl1;
            this.chkDaily.Name = "chkDaily";
            this.chkDaily.Properties.Caption = "Daily";
            this.chkDaily.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkDaily.Properties.RadioGroupIndex = 1;
            this.chkDaily.Size = new System.Drawing.Size(75, 19);
            this.chkDaily.TabIndex = 151;
            // 
            // chkGraph
            // 
            this.chkGraph.Location = new System.Drawing.Point(139, 145);
            this.chkGraph.MenuManager = this.ribbonControl1;
            this.chkGraph.Name = "chkGraph";
            this.chkGraph.Properties.Caption = "Graph";
            this.chkGraph.Size = new System.Drawing.Size(75, 19);
            this.chkGraph.TabIndex = 140;
            this.chkGraph.TabStop = false;
            this.chkGraph.CheckedChanged += new System.EventHandler(this.chkGraph_CheckedChanged);
            // 
            // requireField4
            // 
            this.requireField4.Location = new System.Drawing.Point(283, 101);
            this.requireField4.Name = "requireField4";
            this.requireField4.Size = new System.Drawing.Size(10, 10);
            this.requireField4.TabIndex = 146;
            // 
            // requireField3
            // 
            this.requireField3.Location = new System.Drawing.Point(130, 101);
            this.requireField3.Name = "requireField3";
            this.requireField3.Size = new System.Drawing.Size(10, 10);
            this.requireField3.TabIndex = 145;
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(130, 51);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 144;
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(130, 30);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 143;
            // 
            // dtReceivedDateTo
            // 
            this.dtReceivedDateTo.EditValue = null;
            this.dtReceivedDateTo.Location = new System.Drawing.Point(297, 94);
            this.dtReceivedDateTo.MenuManager = this.ribbonControl1;
            this.dtReceivedDateTo.Name = "dtReceivedDateTo";
            this.dtReceivedDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtReceivedDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtReceivedDateTo.Size = new System.Drawing.Size(122, 20);
            this.dtReceivedDateTo.TabIndex = 142;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(271, 98);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(12, 13);
            this.labelControl1.TabIndex = 141;
            this.labelControl1.Text = "To";
            // 
            // chkTable
            // 
            this.chkTable.EditValue = true;
            this.chkTable.Location = new System.Drawing.Point(139, 120);
            this.chkTable.MenuManager = this.ribbonControl1;
            this.chkTable.Name = "chkTable";
            this.chkTable.Properties.Caption = "Table";
            this.chkTable.Size = new System.Drawing.Size(75, 19);
            this.chkTable.TabIndex = 139;
            // 
            // itemControl
            // 
            this.itemControl.ErrorText = "Item Control is Require Field";
            this.itemControl.Location = new System.Drawing.Point(100, 70);
            this.itemControl.Name = "itemControl";
            this.itemControl.RequireField = false;
            this.itemControl.Size = new System.Drawing.Size(430, 22);
            this.itemControl.TabIndex = 138;
            // 
            // dtReceivedDateFrom
            // 
            this.dtReceivedDateFrom.EditValue = null;
            this.dtReceivedDateFrom.Location = new System.Drawing.Point(141, 94);
            this.dtReceivedDateFrom.MenuManager = this.ribbonControl1;
            this.dtReceivedDateFrom.Name = "dtReceivedDateFrom";
            this.dtReceivedDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtReceivedDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtReceivedDateFrom.Size = new System.Drawing.Size(122, 20);
            this.dtReceivedDateFrom.TabIndex = 132;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(106, 98);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 13);
            this.labelControl2.TabIndex = 130;
            this.labelControl2.Text = "From";
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(67, 47);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(464, 21);
            this.warehouseControl.TabIndex = 120;
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
            this.btnClear.Location = new System.Drawing.Point(455, 214);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(374, 214);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Report";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl4.Location = new System.Drawing.Point(141, 265);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(206, 13);
            this.labelControl4.TabIndex = 153;
            this.labelControl4.Text = "** Force Run to get data in real time";
            // 
            // frmRPS050_MovementReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 343);
            this.Controls.Add(this.grpEdit);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRPS050_MovementReport";
            this.Text = "RPS050 : Movement Report";
            this.Load += new System.EventHandler(this.frmRPS050_MovementReport_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.grpEdit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpEdit)).EndInit();
            this.grpEdit.ResumeLayout(false);
            this.grpEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMode)).EndInit();
            this.grpMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkMonthly.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDaily.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGraph.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReceivedDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReceivedDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReceivedDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReceivedDateFrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpEdit;
        private DevExpress.XtraEditors.DateEdit dtReceivedDateFrom;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private Control.WarehouseControl warehouseControl;
        private Control.OwnerControl ownerControl;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private Control.ItemControl itemControl;
        private DevExpress.XtraEditors.CheckEdit chkGraph;
        private DevExpress.XtraEditors.CheckEdit chkTable;
        private DevExpress.XtraEditors.DateEdit dtReceivedDateTo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Control.RequireField requireField1;
        private Control.RequireField requireField4;
        private Control.RequireField requireField3;
        private Control.RequireField requireField2;
        private DevExpress.XtraEditors.GroupControl grpMode;
        private DevExpress.XtraEditors.CheckEdit chkMonthly;
        private DevExpress.XtraEditors.CheckEdit chkDaily;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}
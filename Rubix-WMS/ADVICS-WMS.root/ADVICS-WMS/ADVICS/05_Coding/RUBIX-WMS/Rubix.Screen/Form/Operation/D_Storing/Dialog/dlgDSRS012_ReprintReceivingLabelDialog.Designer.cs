namespace Rubix.Screen.Form.Operation.D_Storing.Dialog
{
    partial class dlgDSRS012_ReprintReceivingLabelDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgDSRS012_ReprintReceivingLabelDialog));
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.requireField1 = new Rubix.Control.RequireField();
            this.requireField5 = new Rubix.Control.RequireField();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deArrivalDateTo = new DevExpress.XtraEditors.DateEdit();
            this.deArrivalDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcReceivingNo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deArrivalDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deArrivalDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deArrivalDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deArrivalDateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.requireField1);
            this.groupControl3.Controls.Add(this.requireField5);
            this.groupControl3.Controls.Add(this.btnClear);
            this.groupControl3.Controls.Add(this.btnSearch);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.deArrivalDateTo);
            this.groupControl3.Controls.Add(this.deArrivalDateFrom);
            this.groupControl3.Controls.Add(this.warehouseControl);
            this.groupControl3.Controls.Add(this.ownerControl);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl3.Location = new System.Drawing.Point(0, 31);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(526, 128);
            this.groupControl3.TabIndex = 8;
            this.groupControl3.Text = "Search Criteria";
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(131, 53);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 191;
            // 
            // requireField5
            // 
            this.requireField5.Location = new System.Drawing.Point(131, 30);
            this.requireField5.Name = "requireField5";
            this.requireField5.Size = new System.Drawing.Size(10, 10);
            this.requireField5.TabIndex = 191;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(437, 99);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(356, 99);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(272, 73);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 13);
            this.labelControl2.TabIndex = 20;
            this.labelControl2.Text = "To";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(33, 74);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(98, 13);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "Arrival Date";
            // 
            // deArrivalDateTo
            // 
            this.deArrivalDateTo.EditValue = null;
            this.deArrivalDateTo.Location = new System.Drawing.Point(290, 70);
            this.deArrivalDateTo.Name = "deArrivalDateTo";
            this.deArrivalDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deArrivalDateTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.deArrivalDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deArrivalDateTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.deArrivalDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deArrivalDateTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deArrivalDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deArrivalDateTo.Size = new System.Drawing.Size(123, 20);
            this.deArrivalDateTo.TabIndex = 3;
            // 
            // deArrivalDateFrom
            // 
            this.deArrivalDateFrom.EditValue = null;
            this.deArrivalDateFrom.Location = new System.Drawing.Point(143, 70);
            this.deArrivalDateFrom.Name = "deArrivalDateFrom";
            this.deArrivalDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deArrivalDateFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.deArrivalDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deArrivalDateFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.deArrivalDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deArrivalDateFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deArrivalDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deArrivalDateFrom.Size = new System.Drawing.Size(123, 20);
            this.deArrivalDateFrom.TabIndex = 2;
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(69, 46);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(433, 21);
            this.warehouseControl.TabIndex = 1;
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(83, 24);
            this.ownerControl.Name = "ownerControl";
            this.ownerControl.ReadOnly = false;
            this.ownerControl.RequireField = false;
            this.ownerControl.Size = new System.Drawing.Size(419, 21);
            this.ownerControl.TabIndex = 0;
            this.ownerControl.EditValueChanged += new System.EventHandler(this.ownerControl_EditValueChanged);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 159);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(526, 237);
            this.groupControl2.TabIndex = 9;
            this.groupControl2.Text = "Search Result";
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSearchResult.Location = new System.Drawing.Point(2, 21);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.Size = new System.Drawing.Size(522, 214);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcReceivingNo});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsBehavior.Editable = false;
            this.gdvSearchResult.OptionsCustomization.AllowGroup = false;
            this.gdvSearchResult.OptionsView.ShowGroupPanel = false;
            // 
            // gdcReceivingNo
            // 
            this.gdcReceivingNo.Caption = "Receiving No";
            this.gdcReceivingNo.FieldName = "ReceivingNo";
            this.gdcReceivingNo.Name = "gdcReceivingNo";
            this.gdcReceivingNo.Visible = true;
            this.gdcReceivingNo.VisibleIndex = 0;
            // 
            // dlgDSRS012_ReprintReceivingLabelDialog
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 427);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgDSRS012_ReprintReceivingLabelDialog";
            this.ShowIcon = false;
            this.Text = "DSRS012 : Receiving Label Reprint";
            this.Load += new System.EventHandler(this.dlgDSRS012_ReprintReceivingLabelDialog_Load);
            this.Controls.SetChildIndex(this.groupControl3, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deArrivalDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deArrivalDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deArrivalDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deArrivalDateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl3;
        private Control.WarehouseControl warehouseControl;
        private Control.OwnerControl ownerControl;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit deArrivalDateTo;
        private DevExpress.XtraEditors.DateEdit deArrivalDateFrom;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraGrid.Columns.GridColumn gdcReceivingNo;
        private Control.RequireField requireField1;
        private Control.RequireField requireField5;
    }
}
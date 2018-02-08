namespace Rubix.Screen.Form.Operation.F_ShippingEntry.Dialog
{
    partial class dlgFSES013_OtherCharge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgFSES013_OtherCharge));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.grdOtherCharge = new DevExpress.XtraGrid.GridControl();
            this.gdvOtherCharge = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcChargeDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCharge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlEdit = new DevExpress.XtraEditors.PanelControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.requireField3 = new Rubix.Control.RequireField();
            this.requireField1 = new Rubix.Control.RequireField();
            this.requireField2 = new Rubix.Control.RequireField();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.memoRemark = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtEffective = new DevExpress.XtraEditors.DateEdit();
            this.txtOtherCharge = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOtherCharge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvOtherCharge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).BeginInit();
            this.pnlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEffective.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEffective.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherCharge.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.grdOtherCharge);
            this.panelControl2.Location = new System.Drawing.Point(3, 165);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(820, 231);
            this.panelControl2.TabIndex = 8;
            // 
            // grdOtherCharge
            // 
            this.grdOtherCharge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdOtherCharge.Location = new System.Drawing.Point(5, 5);
            this.grdOtherCharge.MainView = this.gdvOtherCharge;
            this.grdOtherCharge.Name = "grdOtherCharge";
            this.grdOtherCharge.Size = new System.Drawing.Size(807, 218);
            this.grdOtherCharge.TabIndex = 0;
            this.grdOtherCharge.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvOtherCharge});
            // 
            // gdvOtherCharge
            // 
            this.gdvOtherCharge.BestFitMaxRowCount = 50;
            this.gdvOtherCharge.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcChargeDate,
            this.grcCharge,
            this.grcRemark});
            this.gdvOtherCharge.GridControl = this.grdOtherCharge;
            this.gdvOtherCharge.Name = "gdvOtherCharge";
            this.gdvOtherCharge.OptionsBehavior.Editable = false;
            this.gdvOtherCharge.OptionsCustomization.AllowGroup = false;
            this.gdvOtherCharge.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gdvOtherCharge.OptionsView.ShowGroupPanel = false;
            this.gdvOtherCharge.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gdvOtherCharge_InitNewRow);
            // 
            // grcChargeDate
            // 
            this.grcChargeDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grcChargeDate.AppearanceHeader.Options.UseFont = true;
            this.grcChargeDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcChargeDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcChargeDate.Caption = "Charge Date";
            this.grcChargeDate.DisplayFormat.FormatString = "d";
            this.grcChargeDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcChargeDate.FieldName = "ChargeDate";
            this.grcChargeDate.Name = "grcChargeDate";
            this.grcChargeDate.Visible = true;
            this.grcChargeDate.VisibleIndex = 0;
            this.grcChargeDate.Width = 83;
            // 
            // grcCharge
            // 
            this.grcCharge.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grcCharge.AppearanceHeader.Options.UseFont = true;
            this.grcCharge.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCharge.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCharge.Caption = "Other Charge";
            this.grcCharge.DisplayFormat.FormatString = "#,##0.00";
            this.grcCharge.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.grcCharge.FieldName = "OtherCharge";
            this.grcCharge.Name = "grcCharge";
            this.grcCharge.Visible = true;
            this.grcCharge.VisibleIndex = 1;
            this.grcCharge.Width = 104;
            // 
            // grcRemark
            // 
            this.grcRemark.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grcRemark.AppearanceHeader.Options.UseFont = true;
            this.grcRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.grcRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcRemark.Caption = "Remark";
            this.grcRemark.FieldName = "Remark";
            this.grcRemark.Name = "grcRemark";
            this.grcRemark.Visible = true;
            this.grcRemark.VisibleIndex = 2;
            this.grcRemark.Width = 307;
            // 
            // pnlEdit
            // 
            this.pnlEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEdit.Controls.Add(this.btnDelete);
            this.pnlEdit.Controls.Add(this.btnOK);
            this.pnlEdit.Controls.Add(this.requireField3);
            this.pnlEdit.Controls.Add(this.requireField1);
            this.pnlEdit.Controls.Add(this.requireField2);
            this.pnlEdit.Controls.Add(this.labelControl3);
            this.pnlEdit.Controls.Add(this.memoRemark);
            this.pnlEdit.Controls.Add(this.labelControl2);
            this.pnlEdit.Controls.Add(this.labelControl1);
            this.pnlEdit.Controls.Add(this.dtEffective);
            this.pnlEdit.Controls.Add(this.txtOtherCharge);
            this.pnlEdit.Controls.Add(this.labelControl6);
            this.pnlEdit.Controls.Add(this.btnUpdate);
            this.pnlEdit.Controls.Add(this.btnAdd);
            this.pnlEdit.Controls.Add(this.btnCancel);
            this.pnlEdit.Location = new System.Drawing.Point(3, 35);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(820, 124);
            this.pnlEdit.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(750, 95);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 24);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(752, 95);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(62, 24);
            this.btnOK.TabIndex = 152;
            this.btnOK.Text = "OK";
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // requireField3
            // 
            this.requireField3.Location = new System.Drawing.Point(116, 62);
            this.requireField3.Name = "requireField3";
            this.requireField3.Size = new System.Drawing.Size(10, 10);
            this.requireField3.TabIndex = 151;
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(116, 39);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 150;
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(116, 16);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 149;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(49, 60);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(66, 16);
            this.labelControl3.TabIndex = 138;
            this.labelControl3.Text = "Remark";
            // 
            // memoRemark
            // 
            this.memoRemark.Location = new System.Drawing.Point(126, 57);
            this.memoRemark.Name = "memoRemark";
            this.memoRemark.Properties.MaxLength = 255;
            this.memoRemark.Size = new System.Drawing.Size(262, 50);
            this.memoRemark.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(255, 36);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 13);
            this.labelControl2.TabIndex = 136;
            this.labelControl2.Text = "Baht";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(25, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(91, 16);
            this.labelControl1.TabIndex = 135;
            this.labelControl1.Text = "Charge Date";
            // 
            // dtEffective
            // 
            this.dtEffective.EditValue = null;
            this.dtEffective.Location = new System.Drawing.Point(126, 10);
            this.dtEffective.Name = "dtEffective";
            this.dtEffective.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEffective.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEffective.Size = new System.Drawing.Size(100, 20);
            this.dtEffective.TabIndex = 0;
            // 
            // txtOtherCharge
            // 
            this.txtOtherCharge.Location = new System.Drawing.Point(126, 33);
            this.txtOtherCharge.Name = "txtOtherCharge";
            this.txtOtherCharge.Properties.Appearance.Options.UseTextOptions = true;
            this.txtOtherCharge.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtOtherCharge.Properties.DisplayFormat.FormatString = "#,##0.00";
            this.txtOtherCharge.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtOtherCharge.Properties.Mask.EditMask = "n2";
            this.txtOtherCharge.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtOtherCharge.Size = new System.Drawing.Size(123, 20);
            this.txtOtherCharge.TabIndex = 1;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(20, 36);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(96, 16);
            this.labelControl6.TabIndex = 132;
            this.labelControl6.Text = "Other Charge";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(673, 95);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(71, 24);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(596, 95);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(71, 24);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(673, 95);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 24);
            this.btnCancel.TabIndex = 212;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dlgFSES013_OtherCharge
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 431);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgFSES013_OtherCharge";
            this.ShowIcon = false;
            this.Text = "FSES013 : Other Charge Dialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgBRES013_OtherCharge_FormClosing);
            this.Load += new System.EventHandler(this.dlgBRES013_OtherCharge_Load);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            this.Controls.SetChildIndex(this.pnlEdit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOtherCharge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvOtherCharge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).EndInit();
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEffective.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEffective.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherCharge.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl grdOtherCharge;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvOtherCharge;
        private DevExpress.XtraGrid.Columns.GridColumn grcChargeDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcCharge;
        private DevExpress.XtraGrid.Columns.GridColumn grcRemark;
        private DevExpress.XtraEditors.PanelControl pnlEdit;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.TextEdit txtOtherCharge;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit memoRemark;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtEffective;
        private Control.RequireField requireField3;
        private Control.RequireField requireField1;
        private Control.RequireField requireField2;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
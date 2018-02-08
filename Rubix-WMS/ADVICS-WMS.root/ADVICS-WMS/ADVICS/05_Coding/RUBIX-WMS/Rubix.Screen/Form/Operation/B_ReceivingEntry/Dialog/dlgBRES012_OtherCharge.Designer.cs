namespace Rubix.Screen.Form.Operation.B_ReceivingEntry.Dialog
{
    partial class dlgBRES012_OtherCharge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgBRES012_OtherCharge));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.grdOtherCharge = new DevExpress.XtraGrid.GridControl();
            this.gdvOtherCharge = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcEffectiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCharge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRowStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlEdit = new DevExpress.XtraEditors.PanelControl();
            this.requireField3 = new Rubix.Control.RequireField();
            this.requireField1 = new Rubix.Control.RequireField();
            this.requireField2 = new Rubix.Control.RequireField();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtChargeDate = new DevExpress.XtraEditors.DateEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtChargeDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtChargeDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherCharge.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.grdOtherCharge);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 155);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(796, 180);
            this.panelControl2.TabIndex = 8;
            // 
            // grdOtherCharge
            // 
            this.grdOtherCharge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOtherCharge.Location = new System.Drawing.Point(2, 2);
            this.grdOtherCharge.MainView = this.gdvOtherCharge;
            this.grdOtherCharge.Name = "grdOtherCharge";
            this.grdOtherCharge.Size = new System.Drawing.Size(792, 176);
            this.grdOtherCharge.TabIndex = 0;
            this.grdOtherCharge.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvOtherCharge});
            // 
            // gdvOtherCharge
            // 
            this.gdvOtherCharge.BestFitMaxRowCount = 50;
            this.gdvOtherCharge.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcEffectiveDate,
            this.grcCharge,
            this.grcRemark,
            this.gcRowStatus});
            this.gdvOtherCharge.GridControl = this.grdOtherCharge;
            this.gdvOtherCharge.Name = "gdvOtherCharge";
            this.gdvOtherCharge.OptionsCustomization.AllowGroup = false;
            this.gdvOtherCharge.OptionsView.ShowGroupPanel = false;
            // 
            // grcEffectiveDate
            // 
            this.grcEffectiveDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grcEffectiveDate.AppearanceHeader.Options.UseFont = true;
            this.grcEffectiveDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEffectiveDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEffectiveDate.Caption = "Charge Date";
            this.grcEffectiveDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.grcEffectiveDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcEffectiveDate.FieldName = "ChargeDate";
            this.grcEffectiveDate.Name = "grcEffectiveDate";
            this.grcEffectiveDate.Visible = true;
            this.grcEffectiveDate.VisibleIndex = 0;
            this.grcEffectiveDate.Width = 182;
            // 
            // grcCharge
            // 
            this.grcCharge.AppearanceCell.Options.UseTextOptions = true;
            this.grcCharge.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
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
            this.grcCharge.Width = 178;
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
            this.grcRemark.Width = 820;
            // 
            // gcRowStatus
            // 
            this.gcRowStatus.Caption = "Row Status";
            this.gcRowStatus.FieldName = "RowStatus";
            this.gcRowStatus.Name = "gcRowStatus";
            this.gcRowStatus.OptionsColumn.AllowShowHide = false;
            this.gcRowStatus.OptionsColumn.ShowCaption = false;
            this.gcRowStatus.OptionsColumn.ShowInCustomizationForm = false;
            this.gcRowStatus.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // pnlEdit
            // 
            this.pnlEdit.Controls.Add(this.requireField3);
            this.pnlEdit.Controls.Add(this.requireField1);
            this.pnlEdit.Controls.Add(this.requireField2);
            this.pnlEdit.Controls.Add(this.btnOK);
            this.pnlEdit.Controls.Add(this.btnDelete);
            this.pnlEdit.Controls.Add(this.labelControl3);
            this.pnlEdit.Controls.Add(this.txtRemark);
            this.pnlEdit.Controls.Add(this.labelControl2);
            this.pnlEdit.Controls.Add(this.labelControl1);
            this.pnlEdit.Controls.Add(this.dtChargeDate);
            this.pnlEdit.Controls.Add(this.txtOtherCharge);
            this.pnlEdit.Controls.Add(this.labelControl6);
            this.pnlEdit.Controls.Add(this.btnUpdate);
            this.pnlEdit.Controls.Add(this.btnAdd);
            this.pnlEdit.Controls.Add(this.btnCancel);
            this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEdit.Location = new System.Drawing.Point(0, 31);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(796, 124);
            this.pnlEdit.TabIndex = 0;
            // 
            // requireField3
            // 
            this.requireField3.Location = new System.Drawing.Point(116, 63);
            this.requireField3.Name = "requireField3";
            this.requireField3.Size = new System.Drawing.Size(10, 10);
            this.requireField3.TabIndex = 150;
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(116, 39);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 149;
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(116, 17);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 148;
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(726, 94);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(65, 26);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(726, 95);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 24);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(21, 60);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(95, 13);
            this.labelControl3.TabIndex = 138;
            this.labelControl3.Text = "Remark";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(126, 57);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.MaxLength = 255;
            this.txtRemark.Size = new System.Drawing.Size(262, 50);
            this.txtRemark.TabIndex = 2;
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
            this.labelControl1.Location = new System.Drawing.Point(21, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 16);
            this.labelControl1.TabIndex = 135;
            this.labelControl1.Text = "Charge Date";
            // 
            // dtChargeDate
            // 
            this.dtChargeDate.EditValue = null;
            this.dtChargeDate.Location = new System.Drawing.Point(126, 10);
            this.dtChargeDate.Name = "dtChargeDate";
            this.dtChargeDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtChargeDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtChargeDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtChargeDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtChargeDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtChargeDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtChargeDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtChargeDate.Size = new System.Drawing.Size(100, 20);
            this.dtChargeDate.TabIndex = 0;
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
            this.txtOtherCharge.Properties.MaxLength = 18;
            this.txtOtherCharge.Size = new System.Drawing.Size(123, 20);
            this.txtOtherCharge.TabIndex = 1;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(9, 36);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(108, 18);
            this.labelControl6.TabIndex = 132;
            this.labelControl6.Text = "Other Charge";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(652, 95);
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
            this.btnAdd.Location = new System.Drawing.Point(578, 95);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(71, 24);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(652, 94);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 26);
            this.btnCancel.TabIndex = 209;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dlgBRES012_OtherCharge
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 366);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.pnlEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "dlgBRES012_OtherCharge";
            this.Text = "BRES012 : Other Charge Detail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlgBRES012_OtherCharge_FormClosing);
            this.Load += new System.EventHandler(this.dlgBRES012_OtherCharge_Load);
            this.Controls.SetChildIndex(this.pnlEdit, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOtherCharge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvOtherCharge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEdit)).EndInit();
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtChargeDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtChargeDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherCharge.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl grdOtherCharge;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvOtherCharge;
        private DevExpress.XtraGrid.Columns.GridColumn grcEffectiveDate;
        private DevExpress.XtraGrid.Columns.GridColumn grcCharge;
        private DevExpress.XtraGrid.Columns.GridColumn grcRemark;
        private DevExpress.XtraEditors.PanelControl pnlEdit;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.TextEdit txtOtherCharge;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dtChargeDate;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn gcRowStatus;
        private Control.RequireField requireField3;
        private Control.RequireField requireField1;
        private Control.RequireField requireField2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
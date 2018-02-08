namespace Rubix.Control
{
    partial class ShippingAreaControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtShippingAreaName = new DevExpress.XtraEditors.TextEdit();
            this.gdcShippingAreaName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboShippingAreaCode = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.GridSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcShippingAreaCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAreaName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboShippingAreaCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtShippingAreaName
            // 
            this.txtShippingAreaName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShippingAreaName.Location = new System.Drawing.Point(203, 1);
            this.txtShippingAreaName.Name = "txtShippingAreaName";
            this.txtShippingAreaName.Properties.ReadOnly = true;
            this.txtShippingAreaName.Size = new System.Drawing.Size(234, 20);
            this.txtShippingAreaName.TabIndex = 20;
            this.txtShippingAreaName.Tag = "no control";
            // 
            // gdcShippingAreaName
            // 
            this.gdcShippingAreaName.Caption = "Shipping Area Name";
            this.gdcShippingAreaName.Name = "gdcShippingAreaName";
            this.gdcShippingAreaName.Visible = true;
            this.gdcShippingAreaName.VisibleIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(2, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 13);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "Shipping Area";
            // 
            // cboShippingAreaCode
            // 
            this.cboShippingAreaCode.EditValue = "";
            this.cboShippingAreaCode.Location = new System.Drawing.Point(78, 1);
            this.cboShippingAreaCode.Name = "cboShippingAreaCode";
            this.cboShippingAreaCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboShippingAreaCode.Properties.NullText = "";
            this.cboShippingAreaCode.Properties.View = this.GridSearch;
            this.cboShippingAreaCode.Size = new System.Drawing.Size(123, 20);
            this.cboShippingAreaCode.TabIndex = 19;
            this.cboShippingAreaCode.EditValueChanged += new System.EventHandler(this.cboSupplierCode_EditValueChanged);
            // 
            // GridSearch
            // 
            this.GridSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcShippingAreaCode,
            this.gdcShippingAreaName});
            this.GridSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridSearch.OptionsView.ShowGroupPanel = false;
            // 
            // gdcShippingAreaCode
            // 
            this.gdcShippingAreaCode.Caption = "Shipping Area Code";
            this.gdcShippingAreaCode.Name = "gdcShippingAreaCode";
            this.gdcShippingAreaCode.Visible = true;
            this.gdcShippingAreaCode.VisibleIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(43, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(6, 13);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "  ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ShippingAreaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtShippingAreaName);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cboShippingAreaCode);
            this.Controls.Add(this.labelControl2);
            this.Name = "ShippingAreaControl";
            this.Size = new System.Drawing.Size(439, 21);
            this.Load += new System.EventHandler(this.ShippingAreaControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtShippingAreaName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboShippingAreaCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtShippingAreaName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcShippingAreaName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit cboShippingAreaCode;
        private DevExpress.XtraGrid.Views.Grid.GridView GridSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gdcShippingAreaCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider errorProvider;
    }
}

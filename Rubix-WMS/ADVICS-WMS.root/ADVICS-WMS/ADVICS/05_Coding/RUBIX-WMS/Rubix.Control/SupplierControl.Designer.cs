namespace Rubix.Control
{
    partial class SupplierControl
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
            this.cboSupplierCode = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.GridSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcSupplierCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcSupplierShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtSupplierName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboSupplierCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSupplierCode
            // 
            this.cboSupplierCode.EditValue = "";
            this.cboSupplierCode.Location = new System.Drawing.Point(53, 2);
            this.cboSupplierCode.Name = "cboSupplierCode";
            this.cboSupplierCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSupplierCode.Properties.NullText = "";
            this.cboSupplierCode.Properties.View = this.GridSearch;
            this.cboSupplierCode.Size = new System.Drawing.Size(123, 20);
            this.cboSupplierCode.TabIndex = 6;
            this.cboSupplierCode.EditValueChanged += new System.EventHandler(this.cboSupplierCode_EditValueChanged);
            // 
            // GridSearch
            // 
            this.GridSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcSupplierCode,
            this.gdcSupplierShortName});
            this.GridSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridSearch.OptionsView.ShowGroupPanel = false;
            // 
            // gdcSupplierCode
            // 
            this.gdcSupplierCode.Caption = "Supplier Code";
            this.gdcSupplierCode.Name = "gdcSupplierCode";
            this.gdcSupplierCode.Visible = true;
            this.gdcSupplierCode.VisibleIndex = 0;
            // 
            // gdcSupplierShortName
            // 
            this.gdcSupplierShortName.Caption = "Supplier Short Name";
            this.gdcSupplierShortName.Name = "gdcSupplierShortName";
            this.gdcSupplierShortName.Visible = true;
            this.gdcSupplierShortName.VisibleIndex = 1;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSupplierName.Location = new System.Drawing.Point(178, 2);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Properties.ReadOnly = true;
            this.txtSupplierName.Size = new System.Drawing.Size(234, 20);
            this.txtSupplierName.TabIndex = 7;
            this.txtSupplierName.Tag = "no control";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(3, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Supplier";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(44, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(6, 13);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "  ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // SupplierControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboSupplierCode);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.labelControl1);
            this.Name = "SupplierControl";
            this.Size = new System.Drawing.Size(412, 23);
            this.Load += new System.EventHandler(this.SupplierControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboSupplierCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit cboSupplierCode;
        private DevExpress.XtraGrid.Views.Grid.GridView GridSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSupplierCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcSupplierShortName;
        private DevExpress.XtraEditors.TextEdit txtSupplierName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider errorProvider;
    }
}

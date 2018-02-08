namespace Rubix.Control
{
    partial class TruckCompanyControl
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
            this.gdcTruckCompanyShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcTruckCompanyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtTruckCompanyName = new DevExpress.XtraEditors.TextEdit();
            this.cboTruckCompany = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.GridSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtTruckCompanyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTruckCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gdcTruckCompanyShortName
            // 
            this.gdcTruckCompanyShortName.Caption = "Truck Company Short Name";
            this.gdcTruckCompanyShortName.Name = "gdcTruckCompanyShortName";
            this.gdcTruckCompanyShortName.Visible = true;
            this.gdcTruckCompanyShortName.VisibleIndex = 1;
            // 
            // gdcTruckCompanyCode
            // 
            this.gdcTruckCompanyCode.Caption = "Truck Company Code";
            this.gdcTruckCompanyCode.Name = "gdcTruckCompanyCode";
            this.gdcTruckCompanyCode.Visible = true;
            this.gdcTruckCompanyCode.VisibleIndex = 0;
            // 
            // txtTruckCompanyName
            // 
            this.txtTruckCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTruckCompanyName.Location = new System.Drawing.Point(212, 1);
            this.txtTruckCompanyName.Name = "txtTruckCompanyName";
            this.txtTruckCompanyName.Properties.ReadOnly = true;
            this.txtTruckCompanyName.Size = new System.Drawing.Size(234, 20);
            this.txtTruckCompanyName.TabIndex = 10;
            this.txtTruckCompanyName.Tag = "no control";
            // 
            // cboTruckCompany
            // 
            this.cboTruckCompany.EditValue = "";
            this.cboTruckCompany.Location = new System.Drawing.Point(87, 1);
            this.cboTruckCompany.Name = "cboTruckCompany";
            this.cboTruckCompany.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTruckCompany.Properties.NullText = "";
            this.cboTruckCompany.Properties.View = this.GridSearch;
            this.cboTruckCompany.Size = new System.Drawing.Size(123, 20);
            this.cboTruckCompany.TabIndex = 9;
            this.cboTruckCompany.EditValueChanged += new System.EventHandler(this.cboTruckCompany_EditValueChanged);
            // 
            // GridSearch
            // 
            this.GridSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcTruckCompanyCode,
            this.gdcTruckCompanyShortName});
            this.GridSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridSearch.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(2, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 13);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Truck Company";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(78, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(6, 13);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "  ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // TruckCompanyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtTruckCompanyName);
            this.Controls.Add(this.cboTruckCompany);
            this.Controls.Add(this.labelControl1);
            this.Name = "TruckCompanyControl";
            this.Size = new System.Drawing.Size(446, 22);
            this.Load += new System.EventHandler(this.TruckCompanyControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTruckCompanyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTruckCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gdcTruckCompanyShortName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcTruckCompanyCode;
        private DevExpress.XtraEditors.TextEdit txtTruckCompanyName;
        private DevExpress.XtraEditors.SearchLookUpEdit cboTruckCompany;
        private DevExpress.XtraGrid.Views.Grid.GridView GridSearch;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider errorProvider;
    }
}

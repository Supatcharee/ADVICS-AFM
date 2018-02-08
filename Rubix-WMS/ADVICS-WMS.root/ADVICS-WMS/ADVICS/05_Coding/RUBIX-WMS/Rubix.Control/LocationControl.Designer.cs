namespace Rubix.Control
{
    partial class LocationControl
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
            this.txtLocationName = new DevExpress.XtraEditors.TextEdit();
            this.cboLocationCode = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.GridSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcLocationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLocationName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocationName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLocationCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLocationName
            // 
            this.txtLocationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocationName.Location = new System.Drawing.Point(197, 1);
            this.txtLocationName.Name = "txtLocationName";
            this.txtLocationName.Properties.ReadOnly = true;
            this.txtLocationName.Size = new System.Drawing.Size(236, 20);
            this.txtLocationName.TabIndex = 7;
            this.txtLocationName.Tag = "no control";
            // 
            // cboLocationCode
            // 
            this.cboLocationCode.EditValue = "";
            this.cboLocationCode.Location = new System.Drawing.Point(72, 1);
            this.cboLocationCode.Name = "cboLocationCode";
            this.cboLocationCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLocationCode.Properties.NullText = "";
            this.cboLocationCode.Properties.View = this.GridSearch;
            this.cboLocationCode.Size = new System.Drawing.Size(123, 20);
            this.cboLocationCode.TabIndex = 6;
            // 
            // GridSearch
            // 
            this.GridSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcLocationCode,
            this.gdcLocationName});
            this.GridSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridSearch.OptionsView.ShowGroupPanel = false;
            // 
            // gdcLocationCode
            // 
            this.gdcLocationCode.Caption = "Location Code";
            this.gdcLocationCode.Name = "gdcLocationCode";
            this.gdcLocationCode.Visible = true;
            this.gdcLocationCode.VisibleIndex = 0;
            // 
            // gdcLocationName
            // 
            this.gdcLocationName.Caption = "Location Name";
            this.gdcLocationName.Name = "gdcLocationName";
            this.gdcLocationName.Visible = true;
            this.gdcLocationName.VisibleIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(0, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Loaction";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // LocationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtLocationName);
            this.Controls.Add(this.cboLocationCode);
            this.Controls.Add(this.labelControl1);
            this.Name = "LocationControl";
            this.Size = new System.Drawing.Size(434, 21);
            ((System.ComponentModel.ISupportInitialize)(this.txtLocationName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLocationCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtLocationName;
        private DevExpress.XtraEditors.SearchLookUpEdit cboLocationCode;
        private DevExpress.XtraGrid.Views.Grid.GridView GridSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLocationCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLocationName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider errorProvider;
    }
}

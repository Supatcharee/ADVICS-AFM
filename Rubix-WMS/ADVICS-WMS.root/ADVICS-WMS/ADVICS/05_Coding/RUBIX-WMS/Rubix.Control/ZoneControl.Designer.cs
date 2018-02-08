namespace Rubix.Control
{
    partial class ZoneControl
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
            this.txtZoneName = new DevExpress.XtraEditors.TextEdit();
            this.cboZoneCode = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.GridSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcZoneCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcZoneName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtZoneName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboZoneCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtZoneName
            // 
            this.txtZoneName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZoneName.Location = new System.Drawing.Point(197, 1);
            this.txtZoneName.Name = "txtZoneName";
            this.txtZoneName.Properties.ReadOnly = true;
            this.txtZoneName.Size = new System.Drawing.Size(235, 20);
            this.txtZoneName.TabIndex = 7;
            this.txtZoneName.Tag = "no control";
            // 
            // cboZoneCode
            // 
            this.cboZoneCode.EditValue = "";
            this.cboZoneCode.Location = new System.Drawing.Point(72, 1);
            this.cboZoneCode.Name = "cboZoneCode";
            this.cboZoneCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboZoneCode.Properties.NullText = "";
            this.cboZoneCode.Properties.View = this.GridSearch;
            this.cboZoneCode.Size = new System.Drawing.Size(123, 20);
            this.cboZoneCode.TabIndex = 6;
            this.cboZoneCode.EditValueChanged += new System.EventHandler(this.cboZoneCode_EditValueChanged);
            // 
            // GridSearch
            // 
            this.GridSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcZoneCode,
            this.gdcZoneName});
            this.GridSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridSearch.OptionsView.ShowGroupPanel = false;
            // 
            // gdcZoneCode
            // 
            this.gdcZoneCode.Caption = "Zone Code";
            this.gdcZoneCode.Name = "gdcZoneCode";
            this.gdcZoneCode.Visible = true;
            this.gdcZoneCode.VisibleIndex = 0;
            // 
            // gdcZoneName
            // 
            this.gdcZoneName.Caption = "Zone Name";
            this.gdcZoneName.Name = "gdcZoneName";
            this.gdcZoneName.Visible = true;
            this.gdcZoneName.VisibleIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(5, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Zone";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ZoneControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtZoneName);
            this.Controls.Add(this.cboZoneCode);
            this.Controls.Add(this.labelControl1);
            this.Name = "ZoneControl";
            this.Size = new System.Drawing.Size(434, 21);
            this.Load += new System.EventHandler(this.ZoneControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtZoneName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboZoneCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtZoneName;
        private DevExpress.XtraEditors.SearchLookUpEdit cboZoneCode;
        private DevExpress.XtraGrid.Views.Grid.GridView GridSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gdcZoneCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcZoneName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider errorProvider;
    }
}

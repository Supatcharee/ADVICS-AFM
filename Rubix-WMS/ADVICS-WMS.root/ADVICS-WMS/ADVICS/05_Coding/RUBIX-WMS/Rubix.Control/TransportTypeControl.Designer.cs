namespace Rubix.Control
{
    partial class TransportTypeControl
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gdcTransportTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GridSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcTransportTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtTransportTypeName = new DevExpress.XtraEditors.TextEdit();
            this.cboTransportType = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransportTypeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTransportType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(78, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(6, 13);
            this.labelControl2.TabIndex = 22;
            this.labelControl2.Text = "  ";
            // 
            // gdcTransportTypeName
            // 
            this.gdcTransportTypeName.Caption = "Transport Type Name";
            this.gdcTransportTypeName.Name = "gdcTransportTypeName";
            this.gdcTransportTypeName.Visible = true;
            this.gdcTransportTypeName.VisibleIndex = 1;
            // 
            // GridSearch
            // 
            this.GridSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcTransportTypeCode,
            this.gdcTransportTypeName});
            this.GridSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridSearch.OptionsView.ShowGroupPanel = false;
            // 
            // gdcTransportTypeCode
            // 
            this.gdcTransportTypeCode.Caption = "Transport Type Code";
            this.gdcTransportTypeCode.Name = "gdcTransportTypeCode";
            this.gdcTransportTypeCode.Visible = true;
            this.gdcTransportTypeCode.VisibleIndex = 0;
            // 
            // txtTransportTypeName
            // 
            this.txtTransportTypeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTransportTypeName.Location = new System.Drawing.Point(212, 0);
            this.txtTransportTypeName.Name = "txtTransportTypeName";
            this.txtTransportTypeName.Properties.ReadOnly = true;
            this.txtTransportTypeName.Size = new System.Drawing.Size(234, 20);
            this.txtTransportTypeName.TabIndex = 20;
            this.txtTransportTypeName.Tag = "no control";
            // 
            // cboTransportType
            // 
            this.cboTransportType.EditValue = "";
            this.cboTransportType.Location = new System.Drawing.Point(87, 0);
            this.cboTransportType.Name = "cboTransportType";
            this.cboTransportType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTransportType.Properties.NullText = "";
            this.cboTransportType.Properties.View = this.GridSearch;
            this.cboTransportType.Size = new System.Drawing.Size(123, 20);
            this.cboTransportType.TabIndex = 19;
            this.cboTransportType.EditValueChanged += new System.EventHandler(this.cboTransportType_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(2, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 13);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "Transport Type";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // TransportTypeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtTransportTypeName);
            this.Controls.Add(this.cboTransportType);
            this.Controls.Add(this.labelControl1);
            this.Name = "TransportTypeControl";
            this.Size = new System.Drawing.Size(447, 21);
            this.Load += new System.EventHandler(this.TransportTypeControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransportTypeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTransportType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn gdcTransportTypeName;
        private DevExpress.XtraGrid.Views.Grid.GridView GridSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gdcTransportTypeCode;
        private DevExpress.XtraEditors.TextEdit txtTransportTypeName;
        private DevExpress.XtraEditors.SearchLookUpEdit cboTransportType;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider errorProvider;

    }
}

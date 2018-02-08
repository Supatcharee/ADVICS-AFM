namespace Rubix.Control
{
    partial class ItemGroupControl
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
            this.txtItemGroupName = new DevExpress.XtraEditors.TextEdit();
            this.cboItemGroupCode = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.GridSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcItemGroupCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcItemGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtItemGroupName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboItemGroupCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtItemGroupName
            // 
            this.txtItemGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemGroupName.Location = new System.Drawing.Point(203, 2);
            this.txtItemGroupName.Name = "txtItemGroupName";
            this.txtItemGroupName.Properties.ReadOnly = true;
            this.txtItemGroupName.Size = new System.Drawing.Size(243, 20);
            this.txtItemGroupName.TabIndex = 16;
            this.txtItemGroupName.Tag = "no control";
            // 
            // cboItemGroupCode
            // 
            this.cboItemGroupCode.EditValue = "";
            this.cboItemGroupCode.Location = new System.Drawing.Point(78, 2);
            this.cboItemGroupCode.Name = "cboItemGroupCode";
            this.cboItemGroupCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboItemGroupCode.Properties.NullText = "";
            this.cboItemGroupCode.Properties.View = this.GridSearch;
            this.cboItemGroupCode.Size = new System.Drawing.Size(123, 20);
            this.cboItemGroupCode.TabIndex = 15;
            this.cboItemGroupCode.EditValueChanged += new System.EventHandler(this.cboItemGroupCode_EditValueChanged);
            // 
            // GridSearch
            // 
            this.GridSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gdcItemGroupCode,
            this.gdcItemGroupName});
            this.GridSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridSearch.OptionsView.ShowGroupPanel = false;
            // 
            // gcID
            // 
            this.gcID.Caption = "gridColumn1";
            this.gcID.FieldName = "TypeOfGoodsID";
            this.gcID.Name = "gcID";
            // 
            // gdcItemGroupCode
            // 
            this.gdcItemGroupCode.Caption = "Item Group Code";
            this.gdcItemGroupCode.FieldName = "TypeOfGoodsCode";
            this.gdcItemGroupCode.Name = "gdcItemGroupCode";
            this.gdcItemGroupCode.Visible = true;
            this.gdcItemGroupCode.VisibleIndex = 0;
            // 
            // gdcItemGroupName
            // 
            this.gdcItemGroupName.Caption = "Item Group Name";
            this.gdcItemGroupName.FieldName = "TypeOfGoodsName";
            this.gdcItemGroupName.Name = "gdcItemGroupName";
            this.gdcItemGroupName.Visible = true;
            this.gdcItemGroupName.VisibleIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(4, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(62, 13);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "Item Group";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ItemGroupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtItemGroupName);
            this.Controls.Add(this.cboItemGroupCode);
            this.Controls.Add(this.labelControl1);
            this.Name = "ItemGroupControl";
            this.Size = new System.Drawing.Size(446, 23);
            this.Load += new System.EventHandler(this.ItemGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtItemGroupName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboItemGroupCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtItemGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcItemGroupCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcItemGroupName;
        private DevExpress.XtraEditors.SearchLookUpEdit cboItemGroupCode;
        private DevExpress.XtraGrid.Views.Grid.GridView GridSearch;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider errorProvider;
    }
}

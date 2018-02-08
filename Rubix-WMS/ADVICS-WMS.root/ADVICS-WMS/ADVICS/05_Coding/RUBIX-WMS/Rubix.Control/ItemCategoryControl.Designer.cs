namespace Rubix.Control
{
    partial class ItemCategoryControl
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCategoryName = new DevExpress.XtraEditors.TextEdit();
            this.cboItemCategory = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.GridSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcItemCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcItemCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoryName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboItemCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Item Category";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategoryName.Location = new System.Drawing.Point(209, 1);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Properties.ReadOnly = true;
            this.txtCategoryName.Size = new System.Drawing.Size(241, 20);
            this.txtCategoryName.TabIndex = 7;
            this.txtCategoryName.Tag = "no control";
            // 
            // cboItemCategory
            // 
            this.cboItemCategory.Location = new System.Drawing.Point(84, 1);
            this.cboItemCategory.Name = "cboItemCategory";
            this.cboItemCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboItemCategory.Properties.NullText = "";
            this.cboItemCategory.Properties.View = this.GridSearch;
            this.cboItemCategory.Size = new System.Drawing.Size(123, 20);
            this.cboItemCategory.TabIndex = 6;
            this.cboItemCategory.EditValueChanged += new System.EventHandler(this.cboTypeOfGoods_EditValueChanged);
            // 
            // GridSearch
            // 
            this.GridSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcItemCategoryCode,
            this.gdcItemCategoryName});
            this.GridSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridSearch.OptionsView.ShowGroupPanel = false;
            // 
            // gdcItemCategoryCode
            // 
            this.gdcItemCategoryCode.Caption = "Item Cetegory Code";
            this.gdcItemCategoryCode.Name = "gdcItemCategoryCode";
            this.gdcItemCategoryCode.Visible = true;
            this.gdcItemCategoryCode.VisibleIndex = 0;
            // 
            // gdcItemCategoryName
            // 
            this.gdcItemCategoryName.Caption = "Item Category Name";
            this.gdcItemCategoryName.Name = "gdcItemCategoryName";
            this.gdcItemCategoryName.Visible = true;
            this.gdcItemCategoryName.VisibleIndex = 1;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ItemCategoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.cboItemCategory);
            this.Name = "ItemCategoryControl";
            this.Size = new System.Drawing.Size(450, 23);
            this.Load += new System.EventHandler(this.ItemCategoryControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoryName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboItemCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtCategoryName;
        private DevExpress.XtraEditors.SearchLookUpEdit cboItemCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView GridSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gdcItemCategoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcItemCategoryName;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider errorProvider;
    }
}

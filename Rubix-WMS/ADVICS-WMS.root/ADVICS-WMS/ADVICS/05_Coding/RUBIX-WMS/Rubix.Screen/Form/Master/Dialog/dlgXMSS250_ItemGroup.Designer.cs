namespace Rubix.Screen.Form.Master.Dialog
{
    partial class dlgXMSS250_ItemGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgXMSS250_ItemGroup));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.grdItemCategory = new DevExpress.XtraGrid.GridControl();
            this.gdvItemCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcItemCategoryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcItemCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.requireField2 = new Rubix.Control.RequireField();
            this.txtCategoryName = new DevExpress.XtraEditors.TextEdit();
            this.txtCategoryCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddItem = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.requireField1 = new Rubix.Control.RequireField();
            this.txtGoodsName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtGoodsCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvItemCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoryName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoryCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodsName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodsCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.requireField1);
            this.panelControl1.Controls.Add(this.txtGoodsName);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtGoodsCode);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(2, 36);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(800, 383);
            this.panelControl1.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.btnUpdate);
            this.groupControl2.Controls.Add(this.grdItemCategory);
            this.groupControl2.Controls.Add(this.requireField2);
            this.groupControl2.Controls.Add(this.txtCategoryName);
            this.groupControl2.Controls.Add(this.txtCategoryCode);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.btnDelete);
            this.groupControl2.Controls.Add(this.btnAddItem);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.btnOK);
            this.groupControl2.Location = new System.Drawing.Point(7, 67);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(785, 309);
            this.groupControl2.TabIndex = 95;
            this.groupControl2.Text = "Item Category";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(604, 83);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 25);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // grdItemCategory
            // 
            this.grdItemCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdItemCategory.Location = new System.Drawing.Point(5, 114);
            this.grdItemCategory.MainView = this.gdvItemCategory;
            this.grdItemCategory.Name = "grdItemCategory";
            this.grdItemCategory.Size = new System.Drawing.Size(774, 189);
            this.grdItemCategory.TabIndex = 5;
            this.grdItemCategory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvItemCategory});
            // 
            // gdvItemCategory
            // 
            this.gdvItemCategory.BestFitMaxRowCount = 50;
            this.gdvItemCategory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcItemCategoryCode,
            this.gdcItemCategoryName});
            this.gdvItemCategory.GridControl = this.grdItemCategory;
            this.gdvItemCategory.Name = "gdvItemCategory";
            this.gdvItemCategory.OptionsCustomization.AllowFilter = false;
            this.gdvItemCategory.OptionsCustomization.AllowSort = false;
            this.gdvItemCategory.OptionsHint.ShowColumnHeaderHints = false;
            this.gdvItemCategory.OptionsMenu.EnableColumnMenu = false;
            this.gdvItemCategory.OptionsMenu.EnableFooterMenu = false;
            this.gdvItemCategory.OptionsMenu.EnableGroupPanelMenu = false;
            this.gdvItemCategory.OptionsView.ShowGroupPanel = false;
            // 
            // gdcItemCategoryCode
            // 
            this.gdcItemCategoryCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcItemCategoryCode.AppearanceHeader.Options.UseFont = true;
            this.gdcItemCategoryCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcItemCategoryCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcItemCategoryCode.Caption = "Product Category Code";
            this.gdcItemCategoryCode.FieldName = "ProductCategoryCode";
            this.gdcItemCategoryCode.FieldNameSortGroup = "ProductCategoryCode";
            this.gdcItemCategoryCode.Name = "gdcItemCategoryCode";
            this.gdcItemCategoryCode.Visible = true;
            this.gdcItemCategoryCode.VisibleIndex = 0;
            // 
            // gdcItemCategoryName
            // 
            this.gdcItemCategoryName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcItemCategoryName.AppearanceHeader.Options.UseFont = true;
            this.gdcItemCategoryName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcItemCategoryName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcItemCategoryName.Caption = "Product Category Name";
            this.gdcItemCategoryName.FieldName = "ProductCategoryName";
            this.gdcItemCategoryName.FieldNameSortGroup = "ProductCategoryName";
            this.gdcItemCategoryName.Name = "gdcItemCategoryName";
            this.gdcItemCategoryName.Visible = true;
            this.gdcItemCategoryName.VisibleIndex = 1;
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(219, 38);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 96;
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(230, 52);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Properties.MaxLength = 100;
            this.txtCategoryName.Size = new System.Drawing.Size(515, 20);
            this.txtCategoryName.TabIndex = 1;
            // 
            // txtCategoryCode
            // 
            this.txtCategoryCode.Location = new System.Drawing.Point(230, 31);
            this.txtCategoryCode.Name = "txtCategoryCode";
            this.txtCategoryCode.Properties.MaxLength = 15;
            this.txtCategoryCode.Size = new System.Drawing.Size(198, 20);
            this.txtCategoryCode.TabIndex = 0;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(5, 56);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(214, 16);
            this.labelControl4.TabIndex = 95;
            this.labelControl4.Text = "Item Category Name";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(684, 82);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(71, 24);
            this.btnDelete.TabIndex = 94;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.Image")));
            this.btnAddItem.Location = new System.Drawing.Point(527, 83);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(71, 24);
            this.btnAddItem.TabIndex = 2;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(7, 34);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(212, 16);
            this.labelControl3.TabIndex = 92;
            this.labelControl3.Text = "Item Category Code";
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(685, 83);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(70, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(229, 18);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 94;
            // 
            // txtGoodsName
            // 
            this.txtGoodsName.Location = new System.Drawing.Point(239, 33);
            this.txtGoodsName.Name = "txtGoodsName";
            this.txtGoodsName.Properties.MaxLength = 100;
            this.txtGoodsName.Size = new System.Drawing.Size(516, 20);
            this.txtGoodsName.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(17, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(210, 18);
            this.labelControl2.TabIndex = 93;
            this.labelControl2.Text = "Item Group Name";
            // 
            // txtGoodsCode
            // 
            this.txtGoodsCode.Location = new System.Drawing.Point(239, 11);
            this.txtGoodsCode.Name = "txtGoodsCode";
            this.txtGoodsCode.Properties.MaxLength = 15;
            this.txtGoodsCode.Size = new System.Drawing.Size(199, 20);
            this.txtGoodsCode.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(18, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(208, 18);
            this.labelControl1.TabIndex = 91;
            this.labelControl1.Text = "Item Group Code";
            // 
            // dlgXMSS250_ItemGroup
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 453);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgXMSS250_ItemGroup";
            this.Text = "XMSS251 : Item Group Dialog";
            this.Load += new System.EventHandler(this.dlgXMSS250_ItemGroup_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdItemCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvItemCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoryName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoryCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodsName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGoodsCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtGoodsName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtGoodsCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Control.RequireField requireField1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAddItem;
        private Control.RequireField requireField2;
        private DevExpress.XtraEditors.TextEdit txtCategoryName;
        private DevExpress.XtraEditors.TextEdit txtCategoryCode;
        private DevExpress.XtraGrid.GridControl grdItemCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvItemCategory;
        private DevExpress.XtraGrid.Columns.GridColumn gdcItemCategoryCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcItemCategoryName;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}
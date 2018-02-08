namespace Rubix.Screen.Form.Master
{
    partial class frmXMSS300_Pallet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXMSS300_Pallet));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtPalletName = new DevExpress.XtraEditors.TextEdit();
            this.txtPalletCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcPalletCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPalletName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWidth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcHeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcM3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPalletName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPalletCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.AllowMinimizeRibbon = false;
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Location = new System.Drawing.Point(0, 124);
            this.ribbonControl1.Size = new System.Drawing.Size(838, 47);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.txtPalletName);
            this.groupControl1.Controls.Add(this.txtPalletCode);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 31);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(838, 93);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Search Criteria";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(751, 64);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(670, 64);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtPalletName
            // 
            this.txtPalletName.Location = new System.Drawing.Point(96, 57);
            this.txtPalletName.MenuManager = this.ribbonControl1;
            this.txtPalletName.Name = "txtPalletName";
            this.txtPalletName.Size = new System.Drawing.Size(201, 20);
            this.txtPalletName.TabIndex = 2;
            // 
            // txtPalletCode
            // 
            this.txtPalletCode.Location = new System.Drawing.Point(96, 35);
            this.txtPalletCode.MenuManager = this.ribbonControl1;
            this.txtPalletCode.Name = "txtPalletCode";
            this.txtPalletCode.Size = new System.Drawing.Size(128, 20);
            this.txtPalletCode.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(13, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(77, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Pallet Name";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(13, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(77, 17);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Pallet Code";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 171);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(838, 319);
            this.groupControl2.TabIndex = 6;
            this.groupControl2.Text = "Search Result";
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSearchResult.Location = new System.Drawing.Point(2, 21);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.MenuManager = this.ribbonControl1;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.Size = new System.Drawing.Size(834, 296);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcPalletCode,
            this.gcPalletName,
            this.gcLength,
            this.gcWidth,
            this.gcHeight,
            this.gcM3,
            this.gcWeight,
            this.gcRemark,
            this.gcCreateDate,
            this.gcCreateUser,
            this.gcUpdateDate,
            this.gcUpdateUser});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsCustomization.AllowGroup = false;
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            this.gdvSearchResult.OptionsView.ShowGroupPanel = false;
            // 
            // gcPalletCode
            // 
            this.gcPalletCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcPalletCode.AppearanceHeader.Options.UseFont = true;
            this.gcPalletCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcPalletCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcPalletCode.Caption = "Pallet Code";
            this.gcPalletCode.FieldName = "PalletCode";
            this.gcPalletCode.Name = "gcPalletCode";
            this.gcPalletCode.Visible = true;
            this.gcPalletCode.VisibleIndex = 0;
            // 
            // gcPalletName
            // 
            this.gcPalletName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcPalletName.AppearanceHeader.Options.UseFont = true;
            this.gcPalletName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcPalletName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcPalletName.Caption = "Pallet Name";
            this.gcPalletName.FieldName = "PalletName";
            this.gcPalletName.Name = "gcPalletName";
            this.gcPalletName.Visible = true;
            this.gcPalletName.VisibleIndex = 1;
            // 
            // gcLength
            // 
            this.gcLength.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcLength.AppearanceHeader.Options.UseFont = true;
            this.gcLength.AppearanceHeader.Options.UseTextOptions = true;
            this.gcLength.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcLength.Caption = "Length (mm.)";
            this.gcLength.DisplayFormat.FormatString = "##0.0000";
            this.gcLength.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcLength.FieldName = "Length";
            this.gcLength.Name = "gcLength";
            this.gcLength.Visible = true;
            this.gcLength.VisibleIndex = 2;
            // 
            // gcWidth
            // 
            this.gcWidth.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcWidth.AppearanceHeader.Options.UseFont = true;
            this.gcWidth.AppearanceHeader.Options.UseTextOptions = true;
            this.gcWidth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcWidth.Caption = "Width (mm.)";
            this.gcWidth.DisplayFormat.FormatString = "##0.0000";
            this.gcWidth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcWidth.FieldName = "Width";
            this.gcWidth.Name = "gcWidth";
            this.gcWidth.Visible = true;
            this.gcWidth.VisibleIndex = 3;
            // 
            // gcHeight
            // 
            this.gcHeight.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcHeight.AppearanceHeader.Options.UseFont = true;
            this.gcHeight.AppearanceHeader.Options.UseTextOptions = true;
            this.gcHeight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcHeight.Caption = "Height (mm.)";
            this.gcHeight.DisplayFormat.FormatString = "##0.0000";
            this.gcHeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcHeight.FieldName = "Height";
            this.gcHeight.Name = "gcHeight";
            this.gcHeight.Visible = true;
            this.gcHeight.VisibleIndex = 4;
            // 
            // gcM3
            // 
            this.gcM3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcM3.AppearanceHeader.Options.UseFont = true;
            this.gcM3.AppearanceHeader.Options.UseTextOptions = true;
            this.gcM3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcM3.Caption = "M3";
            this.gcM3.DisplayFormat.FormatString = "##0.0000";
            this.gcM3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcM3.FieldName = "M3";
            this.gcM3.Name = "gcM3";
            this.gcM3.Visible = true;
            this.gcM3.VisibleIndex = 5;
            // 
            // gcWeight
            // 
            this.gcWeight.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcWeight.AppearanceHeader.Options.UseFont = true;
            this.gcWeight.Caption = "Weight limit (Kg)";
            this.gcWeight.DisplayFormat.FormatString = "##0.0000";
            this.gcWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcWeight.FieldName = "WeightLimit";
            this.gcWeight.Name = "gcWeight";
            this.gcWeight.Visible = true;
            this.gcWeight.VisibleIndex = 6;
            // 
            // gcRemark
            // 
            this.gcRemark.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcRemark.AppearanceHeader.Options.UseFont = true;
            this.gcRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.gcRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcRemark.Caption = "Remark";
            this.gcRemark.FieldName = "Remark";
            this.gcRemark.Name = "gcRemark";
            this.gcRemark.Visible = true;
            this.gcRemark.VisibleIndex = 7;
            // 
            // gcCreateDate
            // 
            this.gcCreateDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcCreateDate.AppearanceHeader.Options.UseFont = true;
            this.gcCreateDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gcCreateDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcCreateDate.Caption = "Create Date";
            this.gcCreateDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gcCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcCreateDate.FieldName = "CreateDate";
            this.gcCreateDate.Name = "gcCreateDate";
            this.gcCreateDate.Visible = true;
            this.gcCreateDate.VisibleIndex = 8;
            // 
            // gcCreateUser
            // 
            this.gcCreateUser.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcCreateUser.AppearanceHeader.Options.UseFont = true;
            this.gcCreateUser.AppearanceHeader.Options.UseTextOptions = true;
            this.gcCreateUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcCreateUser.Caption = "Create User";
            this.gcCreateUser.FieldName = "CreateUser";
            this.gcCreateUser.Name = "gcCreateUser";
            this.gcCreateUser.Visible = true;
            this.gcCreateUser.VisibleIndex = 9;
            // 
            // gcUpdateDate
            // 
            this.gcUpdateDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcUpdateDate.AppearanceHeader.Options.UseFont = true;
            this.gcUpdateDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gcUpdateDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcUpdateDate.Caption = "Update Date";
            this.gcUpdateDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gcUpdateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcUpdateDate.FieldName = "UpdateDate";
            this.gcUpdateDate.Name = "gcUpdateDate";
            this.gcUpdateDate.Visible = true;
            this.gcUpdateDate.VisibleIndex = 10;
            // 
            // gcUpdateUser
            // 
            this.gcUpdateUser.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcUpdateUser.AppearanceHeader.Options.UseFont = true;
            this.gcUpdateUser.AppearanceHeader.Options.UseTextOptions = true;
            this.gcUpdateUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcUpdateUser.Caption = "Update User";
            this.gcUpdateUser.FieldName = "UpdateUser";
            this.gcUpdateUser.Name = "gcUpdateUser";
            this.gcUpdateUser.Visible = true;
            this.gcUpdateUser.VisibleIndex = 11;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // frmXMSS300_Pallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 490);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmXMSS300_Pallet";
            this.Text = "frmXMSS300_Pallet";
            this.Load += new System.EventHandler(this.frmXMSS300_Pallet_Load);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPalletName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPalletCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit txtPalletName;
        private DevExpress.XtraEditors.TextEdit txtPalletCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraGrid.Columns.GridColumn gcPalletCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcPalletName;
        private DevExpress.XtraGrid.Columns.GridColumn gcLength;
        private DevExpress.XtraGrid.Columns.GridColumn gcWidth;
        private DevExpress.XtraGrid.Columns.GridColumn gcHeight;
        private DevExpress.XtraGrid.Columns.GridColumn gcM3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gcUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcUpdateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gcWeight;
    }
}
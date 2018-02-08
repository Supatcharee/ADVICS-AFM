namespace Rubix.Screen.Form.Master
{
    partial class frmXMSS020_TruckCompany
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXMSS020_TruckCompany));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtTruckCompanyName = new DevExpress.XtraEditors.TextEdit();
            this.txtTruckCompanyCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcTruckCompanyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcTruckCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcTruckCompanyAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPhoneNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcExtension = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcMobileNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcFaxNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcContactName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcContactName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcContactName3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTruckCompanyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTruckCompanyCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Size = new System.Drawing.Size(889, 47);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.txtTruckCompanyName);
            this.groupControl1.Controls.Add(this.txtTruckCompanyCode);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 78);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(889, 78);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Search Criteria";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(808, 47);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(727, 47);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtTruckCompanyName
            // 
            this.txtTruckCompanyName.Location = new System.Drawing.Point(126, 50);
            this.txtTruckCompanyName.MenuManager = this.ribbonControl1;
            this.txtTruckCompanyName.Name = "txtTruckCompanyName";
            this.txtTruckCompanyName.Size = new System.Drawing.Size(340, 20);
            this.txtTruckCompanyName.TabIndex = 3;
            // 
            // txtTruckCompanyCode
            // 
            this.txtTruckCompanyCode.Location = new System.Drawing.Point(126, 27);
            this.txtTruckCompanyCode.MenuManager = this.ribbonControl1;
            this.txtTruckCompanyCode.Name = "txtTruckCompanyCode";
            this.txtTruckCompanyCode.Size = new System.Drawing.Size(137, 20);
            this.txtTruckCompanyCode.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(14, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(104, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Truck Company Name";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(16, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(102, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Truck Company Code";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 156);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(889, 337);
            this.groupControl2.TabIndex = 8;
            this.groupControl2.Text = "Search Result";
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSearchResult.Location = new System.Drawing.Point(6, 24);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.MenuManager = this.ribbonControl1;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.Size = new System.Drawing.Size(877, 307);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcTruckCompanyCode,
            this.gdcTruckCompanyName,
            this.gdcTruckCompanyAddress,
            this.gdcPhoneNo,
            this.gdcExtension,
            this.gdcMobileNo,
            this.gdcFaxNo,
            this.gdcContactName1,
            this.gdcContactName2,
            this.gdcContactName3,
            this.gdcCreateDate,
            this.gdcCreateUser,
            this.gdcUpdateDate,
            this.gdcUpdateUser});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            // 
            // gdcTruckCompanyCode
            // 
            this.gdcTruckCompanyCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcTruckCompanyCode.AppearanceHeader.Options.UseFont = true;
            this.gdcTruckCompanyCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcTruckCompanyCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcTruckCompanyCode.Caption = "Truck Company Code";
            this.gdcTruckCompanyCode.FieldName = "TruckCompanyCode";
            this.gdcTruckCompanyCode.FieldNameSortGroup = "TruckCompanyCode";
            this.gdcTruckCompanyCode.Name = "gdcTruckCompanyCode";
            this.gdcTruckCompanyCode.Visible = true;
            this.gdcTruckCompanyCode.VisibleIndex = 0;
            // 
            // gdcTruckCompanyName
            // 
            this.gdcTruckCompanyName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcTruckCompanyName.AppearanceHeader.Options.UseFont = true;
            this.gdcTruckCompanyName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcTruckCompanyName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcTruckCompanyName.Caption = "Truck Company Name";
            this.gdcTruckCompanyName.FieldName = "TruckCompanyName";
            this.gdcTruckCompanyName.FieldNameSortGroup = "TruckCompanyName";
            this.gdcTruckCompanyName.Name = "gdcTruckCompanyName";
            this.gdcTruckCompanyName.Visible = true;
            this.gdcTruckCompanyName.VisibleIndex = 1;
            // 
            // gdcTruckCompanyAddress
            // 
            this.gdcTruckCompanyAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcTruckCompanyAddress.AppearanceHeader.Options.UseFont = true;
            this.gdcTruckCompanyAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcTruckCompanyAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcTruckCompanyAddress.Caption = "Truck Company Address";
            this.gdcTruckCompanyAddress.FieldName = "TruckCompanyAddress";
            this.gdcTruckCompanyAddress.FieldNameSortGroup = "TruckCompanyAddress";
            this.gdcTruckCompanyAddress.Name = "gdcTruckCompanyAddress";
            this.gdcTruckCompanyAddress.Visible = true;
            this.gdcTruckCompanyAddress.VisibleIndex = 2;
            // 
            // gdcPhoneNo
            // 
            this.gdcPhoneNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPhoneNo.AppearanceHeader.Options.UseFont = true;
            this.gdcPhoneNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPhoneNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPhoneNo.Caption = "Phone No.";
            this.gdcPhoneNo.FieldName = "PhoneNo";
            this.gdcPhoneNo.FieldNameSortGroup = "PhoneNo";
            this.gdcPhoneNo.Name = "gdcPhoneNo";
            this.gdcPhoneNo.Visible = true;
            this.gdcPhoneNo.VisibleIndex = 3;
            // 
            // gdcExtension
            // 
            this.gdcExtension.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcExtension.AppearanceHeader.Options.UseFont = true;
            this.gdcExtension.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcExtension.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcExtension.Caption = "Extension";
            this.gdcExtension.FieldName = "Extension";
            this.gdcExtension.FieldNameSortGroup = "Extension";
            this.gdcExtension.Name = "gdcExtension";
            this.gdcExtension.Visible = true;
            this.gdcExtension.VisibleIndex = 4;
            // 
            // gdcMobileNo
            // 
            this.gdcMobileNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcMobileNo.AppearanceHeader.Options.UseFont = true;
            this.gdcMobileNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcMobileNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcMobileNo.Caption = "Mobile No.";
            this.gdcMobileNo.FieldName = "MobileNo";
            this.gdcMobileNo.FieldNameSortGroup = "MobileNo";
            this.gdcMobileNo.Name = "gdcMobileNo";
            this.gdcMobileNo.Visible = true;
            this.gdcMobileNo.VisibleIndex = 5;
            // 
            // gdcFaxNo
            // 
            this.gdcFaxNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcFaxNo.AppearanceHeader.Options.UseFont = true;
            this.gdcFaxNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcFaxNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcFaxNo.Caption = "Fax No.";
            this.gdcFaxNo.FieldName = "FaxNo";
            this.gdcFaxNo.FieldNameSortGroup = "FaxNo";
            this.gdcFaxNo.Name = "gdcFaxNo";
            this.gdcFaxNo.Visible = true;
            this.gdcFaxNo.VisibleIndex = 6;
            // 
            // gdcContactName1
            // 
            this.gdcContactName1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcContactName1.AppearanceHeader.Options.UseFont = true;
            this.gdcContactName1.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcContactName1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcContactName1.Caption = "Contact Name 1";
            this.gdcContactName1.FieldName = "ContactName1";
            this.gdcContactName1.FieldNameSortGroup = "ContactName1";
            this.gdcContactName1.Name = "gdcContactName1";
            this.gdcContactName1.Visible = true;
            this.gdcContactName1.VisibleIndex = 7;
            // 
            // gdcContactName2
            // 
            this.gdcContactName2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcContactName2.AppearanceHeader.Options.UseFont = true;
            this.gdcContactName2.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcContactName2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcContactName2.Caption = "Contact Name 2";
            this.gdcContactName2.FieldName = "ContactName2";
            this.gdcContactName2.FieldNameSortGroup = "ContactName2";
            this.gdcContactName2.Name = "gdcContactName2";
            this.gdcContactName2.Visible = true;
            this.gdcContactName2.VisibleIndex = 8;
            // 
            // gdcContactName3
            // 
            this.gdcContactName3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcContactName3.AppearanceHeader.Options.UseFont = true;
            this.gdcContactName3.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcContactName3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcContactName3.Caption = "Contact Name 3";
            this.gdcContactName3.FieldName = "ContactName3";
            this.gdcContactName3.FieldNameSortGroup = "ContactName3";
            this.gdcContactName3.Name = "gdcContactName3";
            this.gdcContactName3.Visible = true;
            this.gdcContactName3.VisibleIndex = 9;
            // 
            // gdcCreateDate
            // 
            this.gdcCreateDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCreateDate.AppearanceHeader.Options.UseFont = true;
            this.gdcCreateDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCreateDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCreateDate.Caption = "Create Date";
            this.gdcCreateDate.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            this.gdcCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcCreateDate.FieldName = "CreateDate";
            this.gdcCreateDate.FieldNameSortGroup = "CreateDate";
            this.gdcCreateDate.Name = "gdcCreateDate";
            this.gdcCreateDate.Visible = true;
            this.gdcCreateDate.VisibleIndex = 10;
            // 
            // gdcCreateUser
            // 
            this.gdcCreateUser.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCreateUser.AppearanceHeader.Options.UseFont = true;
            this.gdcCreateUser.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCreateUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCreateUser.Caption = "Create User";
            this.gdcCreateUser.FieldName = "CreateUser";
            this.gdcCreateUser.FieldNameSortGroup = "CreateUser";
            this.gdcCreateUser.Name = "gdcCreateUser";
            this.gdcCreateUser.Visible = true;
            this.gdcCreateUser.VisibleIndex = 11;
            // 
            // gdcUpdateDate
            // 
            this.gdcUpdateDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcUpdateDate.AppearanceHeader.Options.UseFont = true;
            this.gdcUpdateDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcUpdateDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcUpdateDate.Caption = "Update Date";
            this.gdcUpdateDate.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            this.gdcUpdateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcUpdateDate.FieldName = "UpdateDate";
            this.gdcUpdateDate.FieldNameSortGroup = "UpdateDate";
            this.gdcUpdateDate.Name = "gdcUpdateDate";
            this.gdcUpdateDate.Visible = true;
            this.gdcUpdateDate.VisibleIndex = 12;
            // 
            // gdcUpdateUser
            // 
            this.gdcUpdateUser.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcUpdateUser.AppearanceHeader.Options.UseFont = true;
            this.gdcUpdateUser.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcUpdateUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcUpdateUser.Caption = "Update User";
            this.gdcUpdateUser.FieldName = "UpdateUser";
            this.gdcUpdateUser.FieldNameSortGroup = "UpdateUser";
            this.gdcUpdateUser.Name = "gdcUpdateUser";
            this.gdcUpdateUser.Visible = true;
            this.gdcUpdateUser.VisibleIndex = 13;
            // 
            // frmXMSS020_TruckCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 493);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmXMSS020_TruckCompany";
            this.Text = "XMSS020 : Company/ Truck Company Master";
            this.Load += new System.EventHandler(this.frmXMSS020_TruckCompany_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTruckCompanyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTruckCompanyCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TextEdit txtTruckCompanyName;
        private DevExpress.XtraEditors.TextEdit txtTruckCompanyCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraGrid.Columns.GridColumn gdcTruckCompanyCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcTruckCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcTruckCompanyAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPhoneNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcExtension;
        private DevExpress.XtraGrid.Columns.GridColumn gdcMobileNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcFaxNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcContactName1;
        private DevExpress.XtraGrid.Columns.GridColumn gdcContactName2;
        private DevExpress.XtraGrid.Columns.GridColumn gdcContactName3;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateUser;
    }
}
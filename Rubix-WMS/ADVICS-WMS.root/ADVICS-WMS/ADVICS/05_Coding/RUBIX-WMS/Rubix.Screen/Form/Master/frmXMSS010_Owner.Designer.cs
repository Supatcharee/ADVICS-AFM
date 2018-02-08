namespace Rubix.Screen.Form.Master
{
    partial class frmXMSS010_Owner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXMSS010_Owner));
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcOwnerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcOwnerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcBusinessType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcStateOrProvince = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPostalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCountry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPhoneNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcExtension = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcMobileNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcFaxNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcEmailAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcContactName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcContactName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcContactName3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcDefaultReceivingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLimitCapacity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtOwnerCode = new DevExpress.XtraEditors.TextEdit();
            this.txtOwnerName = new DevExpress.XtraEditors.TextEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gdcBankAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOwnerCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOwnerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Location = new System.Drawing.Point(0, 118);
            this.ribbonControl1.Size = new System.Drawing.Size(802, 47);
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSearchResult.Location = new System.Drawing.Point(2, 21);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.MenuManager = this.ribbonControl1;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.Size = new System.Drawing.Size(798, 290);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcOwnerCode,
            this.gdcOwnerName,
            this.gdcBusinessType,
            this.gdcAddress,
            this.gdcCity,
            this.gdcStateOrProvince,
            this.gdcPostalCode,
            this.gdcCountry,
            this.gdcPhoneNo,
            this.gdcExtension,
            this.gdcMobileNo,
            this.gdcFaxNo,
            this.gdcEmailAddress,
            this.gdcContactName1,
            this.gdcContactName2,
            this.gdcContactName3,
            this.gdcDefaultReceivingDate,
            this.gdcLimitCapacity,
            this.gdcBankAccount,
            this.gdcCreateDate,
            this.gdcCreateUser,
            this.gdcUpdateDate,
            this.gdcUpdateUser});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            // 
            // gdcOwnerCode
            // 
            this.gdcOwnerCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcOwnerCode.AppearanceHeader.Options.UseFont = true;
            this.gdcOwnerCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcOwnerCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcOwnerCode.Caption = "Owner Code";
            this.gdcOwnerCode.FieldName = "OwnerCode";
            this.gdcOwnerCode.FieldNameSortGroup = "OwnerCode";
            this.gdcOwnerCode.Name = "gdcOwnerCode";
            this.gdcOwnerCode.Visible = true;
            this.gdcOwnerCode.VisibleIndex = 0;
            // 
            // gdcOwnerName
            // 
            this.gdcOwnerName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcOwnerName.AppearanceHeader.Options.UseFont = true;
            this.gdcOwnerName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcOwnerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcOwnerName.Caption = "Owner Name";
            this.gdcOwnerName.FieldName = "OwnerName";
            this.gdcOwnerName.FieldNameSortGroup = "OwnerName";
            this.gdcOwnerName.Name = "gdcOwnerName";
            this.gdcOwnerName.Visible = true;
            this.gdcOwnerName.VisibleIndex = 1;
            // 
            // gdcBusinessType
            // 
            this.gdcBusinessType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcBusinessType.AppearanceHeader.Options.UseFont = true;
            this.gdcBusinessType.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcBusinessType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcBusinessType.Caption = "Business Type";
            this.gdcBusinessType.FieldName = "BusinessType";
            this.gdcBusinessType.FieldNameSortGroup = "BusinessType";
            this.gdcBusinessType.Name = "gdcBusinessType";
            this.gdcBusinessType.Visible = true;
            this.gdcBusinessType.VisibleIndex = 2;
            // 
            // gdcAddress
            // 
            this.gdcAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcAddress.AppearanceHeader.Options.UseFont = true;
            this.gdcAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcAddress.Caption = "Address";
            this.gdcAddress.FieldName = "Address";
            this.gdcAddress.FieldNameSortGroup = "Address";
            this.gdcAddress.Name = "gdcAddress";
            this.gdcAddress.Visible = true;
            this.gdcAddress.VisibleIndex = 3;
            // 
            // gdcCity
            // 
            this.gdcCity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcCity.AppearanceHeader.Options.UseFont = true;
            this.gdcCity.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCity.Caption = "City";
            this.gdcCity.FieldName = "City";
            this.gdcCity.FieldNameSortGroup = "City";
            this.gdcCity.Name = "gdcCity";
            this.gdcCity.Visible = true;
            this.gdcCity.VisibleIndex = 4;
            // 
            // gdcStateOrProvince
            // 
            this.gdcStateOrProvince.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcStateOrProvince.AppearanceHeader.Options.UseFont = true;
            this.gdcStateOrProvince.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcStateOrProvince.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcStateOrProvince.Caption = "State / Province";
            this.gdcStateOrProvince.FieldName = "StateOrProvince";
            this.gdcStateOrProvince.FieldNameSortGroup = "StateOrProvince";
            this.gdcStateOrProvince.Name = "gdcStateOrProvince";
            this.gdcStateOrProvince.Visible = true;
            this.gdcStateOrProvince.VisibleIndex = 5;
            // 
            // gdcPostalCode
            // 
            this.gdcPostalCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcPostalCode.AppearanceHeader.Options.UseFont = true;
            this.gdcPostalCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPostalCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPostalCode.Caption = "Postal Code";
            this.gdcPostalCode.FieldName = "PostalCode";
            this.gdcPostalCode.FieldNameSortGroup = "PostalCode";
            this.gdcPostalCode.Name = "gdcPostalCode";
            this.gdcPostalCode.Visible = true;
            this.gdcPostalCode.VisibleIndex = 6;
            // 
            // gdcCountry
            // 
            this.gdcCountry.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcCountry.AppearanceHeader.Options.UseFont = true;
            this.gdcCountry.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCountry.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCountry.Caption = "Country";
            this.gdcCountry.FieldName = "Country";
            this.gdcCountry.FieldNameSortGroup = "Country";
            this.gdcCountry.Name = "gdcCountry";
            this.gdcCountry.Visible = true;
            this.gdcCountry.VisibleIndex = 7;
            // 
            // gdcPhoneNo
            // 
            this.gdcPhoneNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcPhoneNo.AppearanceHeader.Options.UseFont = true;
            this.gdcPhoneNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPhoneNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPhoneNo.Caption = "Phone No.";
            this.gdcPhoneNo.FieldName = "PhoneNo";
            this.gdcPhoneNo.FieldNameSortGroup = "PhoneNo";
            this.gdcPhoneNo.Name = "gdcPhoneNo";
            this.gdcPhoneNo.Visible = true;
            this.gdcPhoneNo.VisibleIndex = 8;
            // 
            // gdcExtension
            // 
            this.gdcExtension.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcExtension.AppearanceHeader.Options.UseFont = true;
            this.gdcExtension.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcExtension.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcExtension.Caption = "Extension";
            this.gdcExtension.FieldName = "Extension";
            this.gdcExtension.FieldNameSortGroup = "Extension";
            this.gdcExtension.Name = "gdcExtension";
            this.gdcExtension.Visible = true;
            this.gdcExtension.VisibleIndex = 9;
            // 
            // gdcMobileNo
            // 
            this.gdcMobileNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcMobileNo.AppearanceHeader.Options.UseFont = true;
            this.gdcMobileNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcMobileNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcMobileNo.Caption = "Mobile No.";
            this.gdcMobileNo.FieldName = "MobileNo";
            this.gdcMobileNo.FieldNameSortGroup = "MobileNo";
            this.gdcMobileNo.Name = "gdcMobileNo";
            this.gdcMobileNo.Visible = true;
            this.gdcMobileNo.VisibleIndex = 10;
            // 
            // gdcFaxNo
            // 
            this.gdcFaxNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcFaxNo.AppearanceHeader.Options.UseFont = true;
            this.gdcFaxNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcFaxNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcFaxNo.Caption = "Fax No";
            this.gdcFaxNo.FieldName = "FaxNo";
            this.gdcFaxNo.FieldNameSortGroup = "FaxNo";
            this.gdcFaxNo.Name = "gdcFaxNo";
            this.gdcFaxNo.Visible = true;
            this.gdcFaxNo.VisibleIndex = 11;
            // 
            // gdcEmailAddress
            // 
            this.gdcEmailAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcEmailAddress.AppearanceHeader.Options.UseFont = true;
            this.gdcEmailAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcEmailAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcEmailAddress.Caption = "Email Address";
            this.gdcEmailAddress.FieldName = "EmailAddress";
            this.gdcEmailAddress.FieldNameSortGroup = "EmailAddress";
            this.gdcEmailAddress.Name = "gdcEmailAddress";
            this.gdcEmailAddress.Visible = true;
            this.gdcEmailAddress.VisibleIndex = 12;
            // 
            // gdcContactName1
            // 
            this.gdcContactName1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcContactName1.AppearanceHeader.Options.UseFont = true;
            this.gdcContactName1.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcContactName1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcContactName1.Caption = "Contact Name1";
            this.gdcContactName1.FieldName = "ContactName1";
            this.gdcContactName1.FieldNameSortGroup = "ContactName1";
            this.gdcContactName1.Name = "gdcContactName1";
            this.gdcContactName1.Visible = true;
            this.gdcContactName1.VisibleIndex = 13;
            // 
            // gdcContactName2
            // 
            this.gdcContactName2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcContactName2.AppearanceHeader.Options.UseFont = true;
            this.gdcContactName2.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcContactName2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcContactName2.Caption = "Contact Name2";
            this.gdcContactName2.FieldName = "ContactName2";
            this.gdcContactName2.FieldNameSortGroup = "ContactName2";
            this.gdcContactName2.Name = "gdcContactName2";
            this.gdcContactName2.Visible = true;
            this.gdcContactName2.VisibleIndex = 14;
            // 
            // gdcContactName3
            // 
            this.gdcContactName3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcContactName3.AppearanceHeader.Options.UseFont = true;
            this.gdcContactName3.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcContactName3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcContactName3.Caption = "Contact Name3";
            this.gdcContactName3.FieldName = "ContactName3";
            this.gdcContactName3.FieldNameSortGroup = "ContactName3";
            this.gdcContactName3.Name = "gdcContactName3";
            this.gdcContactName3.Visible = true;
            this.gdcContactName3.VisibleIndex = 15;
            // 
            // gdcDefaultReceivingDate
            // 
            this.gdcDefaultReceivingDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcDefaultReceivingDate.AppearanceHeader.Options.UseFont = true;
            this.gdcDefaultReceivingDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcDefaultReceivingDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcDefaultReceivingDate.Caption = "Default Receiving Date";
            this.gdcDefaultReceivingDate.FieldName = "DefaultReceivingDate";
            this.gdcDefaultReceivingDate.FieldNameSortGroup = "DefaultReceivingDate";
            this.gdcDefaultReceivingDate.Name = "gdcDefaultReceivingDate";
            this.gdcDefaultReceivingDate.Visible = true;
            this.gdcDefaultReceivingDate.VisibleIndex = 16;
            // 
            // gdcLimitCapacity
            // 
            this.gdcLimitCapacity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcLimitCapacity.AppearanceHeader.Options.UseFont = true;
            this.gdcLimitCapacity.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcLimitCapacity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcLimitCapacity.Caption = "Limit Capacity";
            this.gdcLimitCapacity.FieldName = "LimitCapacity";
            this.gdcLimitCapacity.FieldNameSortGroup = "LimitCapacity";
            this.gdcLimitCapacity.Name = "gdcLimitCapacity";
            this.gdcLimitCapacity.Visible = true;
            this.gdcLimitCapacity.VisibleIndex = 17;
            // 
            // gdcCreateDate
            // 
            this.gdcCreateDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.gdcCreateDate.VisibleIndex = 19;
            // 
            // gdcCreateUser
            // 
            this.gdcCreateUser.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcCreateUser.AppearanceHeader.Options.UseFont = true;
            this.gdcCreateUser.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCreateUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCreateUser.Caption = "Create User";
            this.gdcCreateUser.FieldName = "CreateUser";
            this.gdcCreateUser.FieldNameSortGroup = "CreateUser";
            this.gdcCreateUser.Name = "gdcCreateUser";
            this.gdcCreateUser.Visible = true;
            this.gdcCreateUser.VisibleIndex = 20;
            // 
            // gdcUpdateDate
            // 
            this.gdcUpdateDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.gdcUpdateDate.VisibleIndex = 21;
            // 
            // gdcUpdateUser
            // 
            this.gdcUpdateUser.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcUpdateUser.AppearanceHeader.Options.UseFont = true;
            this.gdcUpdateUser.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcUpdateUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcUpdateUser.Caption = "Update User";
            this.gdcUpdateUser.FieldName = "UpdateUser";
            this.gdcUpdateUser.FieldNameSortGroup = "UpdateUser";
            this.gdcUpdateUser.Name = "gdcUpdateUser";
            this.gdcUpdateUser.Visible = true;
            this.gdcUpdateUser.VisibleIndex = 22;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(12, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Owner Code";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(10, 62);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(81, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Owner Name";
            // 
            // txtOwnerCode
            // 
            this.txtOwnerCode.Location = new System.Drawing.Point(99, 36);
            this.txtOwnerCode.MenuManager = this.ribbonControl1;
            this.txtOwnerCode.Name = "txtOwnerCode";
            this.txtOwnerCode.Size = new System.Drawing.Size(137, 20);
            this.txtOwnerCode.TabIndex = 2;
            // 
            // txtOwnerName
            // 
            this.txtOwnerName.Location = new System.Drawing.Point(99, 59);
            this.txtOwnerName.MenuManager = this.ribbonControl1;
            this.txtOwnerName.Name = "txtOwnerName";
            this.txtOwnerName.Size = new System.Drawing.Size(395, 20);
            this.txtOwnerName.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(634, 53);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(715, 53);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtOwnerName);
            this.groupControl1.Controls.Add(this.txtOwnerCode);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 31);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(802, 87);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Search Criteria";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 118);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(802, 314);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Search Result";
            // 
            // gdcBankAccount
            // 
            this.gdcBankAccount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcBankAccount.AppearanceHeader.Options.UseFont = true;
            this.gdcBankAccount.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcBankAccount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcBankAccount.Caption = "gdcBank Account";
            this.gdcBankAccount.FieldName = "BankAccount";
            this.gdcBankAccount.FieldNameSortGroup = "gdcBankAccount";
            this.gdcBankAccount.Name = "gdcBankAccount";
            this.gdcBankAccount.Visible = true;
            this.gdcBankAccount.VisibleIndex = 18;
            // 
            // frmXMSS010_Owner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 432);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmXMSS010_Owner";
            this.Text = "XMSS010 :  Owner Master";
            this.Load += new System.EventHandler(this.frmXMSS010_Owner_Load);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOwnerCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOwnerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtOwnerCode;
        private DevExpress.XtraEditors.TextEdit txtOwnerName;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcBusinessType;
        private DevExpress.XtraGrid.Columns.GridColumn gdcAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCity;
        private DevExpress.XtraGrid.Columns.GridColumn gdcStateOrProvince;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPostalCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCountry;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPhoneNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcExtension;
        private DevExpress.XtraGrid.Columns.GridColumn gdcMobileNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcFaxNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcEmailAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gdcContactName1;
        private DevExpress.XtraGrid.Columns.GridColumn gdcContactName2;
        private DevExpress.XtraGrid.Columns.GridColumn gdcContactName3;
        private DevExpress.XtraGrid.Columns.GridColumn gdcDefaultReceivingDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLimitCapacity;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcBankAccount;
    }
}
namespace Rubix.Screen.Form.Master
{
    partial class frmXMSS070_FinalDestination
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXMSS070_FinalDestination));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.customerControl = new Rubix.Control.CustomerControl();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtFinalDesName = new DevExpress.XtraEditors.TextEdit();
            this.txtFinalDesCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcOwnerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcOwnerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcFinalDestinationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcFinalDestinationName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcFinalDestinationAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcFinalDestinationDetail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcStateOrProvince = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCountry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPhoneNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcExtension = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcFaxNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPostalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcDistance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcMobileNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLeadTimeDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLeadTimeHr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcContactName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcContactName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcContactName3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcExchangeRate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinalDesName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinalDesCode.Properties)).BeginInit();
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
            this.ribbonControl1.Size = new System.Drawing.Size(887, 47);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.customerControl);
            this.groupControl1.Controls.Add(this.ownerControl);
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.txtFinalDesName);
            this.groupControl1.Controls.Add(this.txtFinalDesCode);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 78);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(887, 127);
            this.groupControl1.TabIndex = 15;
            this.groupControl1.Text = "Search Criteria";
            // 
            // customerControl
            // 
            this.customerControl.ErrorText = "Customer Control is Require Field";
            this.customerControl.Location = new System.Drawing.Point(70, 46);
            this.customerControl.Name = "customerControl";
            this.customerControl.OwnerID = null;
            this.customerControl.ReadOnly = false;
            this.customerControl.RequireField = false;
            this.customerControl.Size = new System.Drawing.Size(457, 24);
            this.customerControl.TabIndex = 2;
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(72, 24);
            this.ownerControl.Name = "ownerControl";
            this.ownerControl.ReadOnly = false;
            this.ownerControl.RequireField = false;
            this.ownerControl.Size = new System.Drawing.Size(455, 21);
            this.ownerControl.TabIndex = 1;
            this.ownerControl.EditValueChanged += new System.EventHandler(this.customerControl_EditValueChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(804, 98);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(723, 98);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFinalDesName
            // 
            this.txtFinalDesName.Location = new System.Drawing.Point(132, 93);
            this.txtFinalDesName.MenuManager = this.ribbonControl1;
            this.txtFinalDesName.Name = "txtFinalDesName";
            this.txtFinalDesName.Size = new System.Drawing.Size(395, 20);
            this.txtFinalDesName.TabIndex = 4;
            // 
            // txtFinalDesCode
            // 
            this.txtFinalDesCode.Location = new System.Drawing.Point(133, 70);
            this.txtFinalDesCode.MenuManager = this.ribbonControl1;
            this.txtFinalDesCode.Name = "txtFinalDesCode";
            this.txtFinalDesCode.Size = new System.Drawing.Size(123, 20);
            this.txtFinalDesCode.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(7, 94);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(115, 19);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Final Destination Name";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(1, 72);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(123, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Final Destination Code";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 205);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(887, 291);
            this.groupControl2.TabIndex = 14;
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
            this.grdSearchResult.Size = new System.Drawing.Size(875, 261);
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
            this.gdcCustomerCode,
            this.gdcCustomerName,
            this.gdcFinalDestinationCode,
            this.gdcFinalDestinationName,
            this.gdcFinalDestinationAddress,
            this.gdcFinalDestinationDetail,
            this.gdcCity,
            this.gdcStateOrProvince,
            this.gdcCountry,
            this.gdcPhoneNo,
            this.gdcExtension,
            this.gdcFaxNo,
            this.gdcPostalCode,
            this.gdcDistance,
            this.gdcMobileNo,
            this.gdcLeadTimeDays,
            this.gdcLeadTimeHr,
            this.gdcContactName1,
            this.gdcContactName2,
            this.gdcContactName3,
            this.gdcRemark,
            this.gdcCreateDate,
            this.gdcCreateUser,
            this.gdcUpdateDate,
            this.gdcUpdateUser,
            this.gdcExchangeRate});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            // 
            // gdcOwnerCode
            // 
            this.gdcOwnerCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
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
            this.gdcOwnerName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcOwnerName.AppearanceHeader.Options.UseFont = true;
            this.gdcOwnerName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcOwnerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcOwnerName.Caption = "Owner Name";
            this.gdcOwnerName.FieldName = "OwnerName";
            this.gdcOwnerName.Name = "gdcOwnerName";
            this.gdcOwnerName.Visible = true;
            this.gdcOwnerName.VisibleIndex = 1;
            // 
            // gdcCustomerCode
            // 
            this.gdcCustomerCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCustomerCode.AppearanceHeader.Options.UseFont = true;
            this.gdcCustomerCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCustomerCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCustomerCode.Caption = "Customer Code";
            this.gdcCustomerCode.FieldName = "CustomerCode";
            this.gdcCustomerCode.FieldNameSortGroup = "CustomerCode";
            this.gdcCustomerCode.Name = "gdcCustomerCode";
            this.gdcCustomerCode.Visible = true;
            this.gdcCustomerCode.VisibleIndex = 2;
            // 
            // gdcCustomerName
            // 
            this.gdcCustomerName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCustomerName.AppearanceHeader.Options.UseFont = true;
            this.gdcCustomerName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCustomerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCustomerName.Caption = "Customer Name";
            this.gdcCustomerName.FieldName = "CustomerName";
            this.gdcCustomerName.Name = "gdcCustomerName";
            this.gdcCustomerName.Visible = true;
            this.gdcCustomerName.VisibleIndex = 3;
            // 
            // gdcFinalDestinationCode
            // 
            this.gdcFinalDestinationCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcFinalDestinationCode.AppearanceHeader.Options.UseFont = true;
            this.gdcFinalDestinationCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcFinalDestinationCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcFinalDestinationCode.Caption = "Final Destination Code";
            this.gdcFinalDestinationCode.FieldName = "FinalDestinationCode";
            this.gdcFinalDestinationCode.FieldNameSortGroup = "FinalDestinationCode";
            this.gdcFinalDestinationCode.Name = "gdcFinalDestinationCode";
            this.gdcFinalDestinationCode.Visible = true;
            this.gdcFinalDestinationCode.VisibleIndex = 4;
            // 
            // gdcFinalDestinationName
            // 
            this.gdcFinalDestinationName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcFinalDestinationName.AppearanceHeader.Options.UseFont = true;
            this.gdcFinalDestinationName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcFinalDestinationName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcFinalDestinationName.Caption = "Final Destination Name";
            this.gdcFinalDestinationName.FieldName = "FinalDestinationName";
            this.gdcFinalDestinationName.FieldNameSortGroup = "FinalDestinationName";
            this.gdcFinalDestinationName.Name = "gdcFinalDestinationName";
            this.gdcFinalDestinationName.Visible = true;
            this.gdcFinalDestinationName.VisibleIndex = 5;
            // 
            // gdcFinalDestinationAddress
            // 
            this.gdcFinalDestinationAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcFinalDestinationAddress.AppearanceHeader.Options.UseFont = true;
            this.gdcFinalDestinationAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcFinalDestinationAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcFinalDestinationAddress.Caption = "Final Destination Address";
            this.gdcFinalDestinationAddress.FieldName = "FinalDestinationAddress";
            this.gdcFinalDestinationAddress.FieldNameSortGroup = "FinalDestinationAddress";
            this.gdcFinalDestinationAddress.Name = "gdcFinalDestinationAddress";
            this.gdcFinalDestinationAddress.Visible = true;
            this.gdcFinalDestinationAddress.VisibleIndex = 6;
            // 
            // gdcFinalDestinationDetail
            // 
            this.gdcFinalDestinationDetail.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcFinalDestinationDetail.AppearanceHeader.Options.UseFont = true;
            this.gdcFinalDestinationDetail.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcFinalDestinationDetail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcFinalDestinationDetail.Caption = "Final Destination Detail";
            this.gdcFinalDestinationDetail.FieldName = "FinalDestinationDetail";
            this.gdcFinalDestinationDetail.FieldNameSortGroup = "FinalDestinationDetail";
            this.gdcFinalDestinationDetail.Name = "gdcFinalDestinationDetail";
            this.gdcFinalDestinationDetail.Visible = true;
            this.gdcFinalDestinationDetail.VisibleIndex = 7;
            // 
            // gdcCity
            // 
            this.gdcCity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCity.AppearanceHeader.Options.UseFont = true;
            this.gdcCity.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCity.Caption = "City";
            this.gdcCity.FieldName = "City";
            this.gdcCity.FieldNameSortGroup = "City";
            this.gdcCity.Name = "gdcCity";
            this.gdcCity.Visible = true;
            this.gdcCity.VisibleIndex = 8;
            // 
            // gdcStateOrProvince
            // 
            this.gdcStateOrProvince.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcStateOrProvince.AppearanceHeader.Options.UseFont = true;
            this.gdcStateOrProvince.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcStateOrProvince.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcStateOrProvince.Caption = "State or Province";
            this.gdcStateOrProvince.FieldName = "StateOrProvince";
            this.gdcStateOrProvince.FieldNameSortGroup = "StateOrProvince";
            this.gdcStateOrProvince.Name = "gdcStateOrProvince";
            this.gdcStateOrProvince.Visible = true;
            this.gdcStateOrProvince.VisibleIndex = 9;
            // 
            // gdcCountry
            // 
            this.gdcCountry.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCountry.AppearanceHeader.Options.UseFont = true;
            this.gdcCountry.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCountry.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCountry.Caption = "Country";
            this.gdcCountry.FieldName = "Country";
            this.gdcCountry.FieldNameSortGroup = "Country";
            this.gdcCountry.Name = "gdcCountry";
            this.gdcCountry.Visible = true;
            this.gdcCountry.VisibleIndex = 10;
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
            this.gdcPhoneNo.VisibleIndex = 11;
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
            this.gdcExtension.VisibleIndex = 12;
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
            this.gdcFaxNo.VisibleIndex = 13;
            // 
            // gdcPostalCode
            // 
            this.gdcPostalCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPostalCode.AppearanceHeader.Options.UseFont = true;
            this.gdcPostalCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPostalCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPostalCode.Caption = "Postal Code";
            this.gdcPostalCode.FieldName = "PostalCode";
            this.gdcPostalCode.FieldNameSortGroup = "PostalCode";
            this.gdcPostalCode.Name = "gdcPostalCode";
            this.gdcPostalCode.Visible = true;
            this.gdcPostalCode.VisibleIndex = 14;
            // 
            // gdcDistance
            // 
            this.gdcDistance.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcDistance.AppearanceHeader.Options.UseFont = true;
            this.gdcDistance.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcDistance.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcDistance.Caption = "Distance";
            this.gdcDistance.FieldName = "Distance";
            this.gdcDistance.FieldNameSortGroup = "Distance";
            this.gdcDistance.Name = "gdcDistance";
            this.gdcDistance.Visible = true;
            this.gdcDistance.VisibleIndex = 15;
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
            this.gdcMobileNo.VisibleIndex = 16;
            // 
            // gdcLeadTimeDays
            // 
            this.gdcLeadTimeDays.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcLeadTimeDays.AppearanceHeader.Options.UseFont = true;
            this.gdcLeadTimeDays.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcLeadTimeDays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcLeadTimeDays.Caption = "Lead Time Days";
            this.gdcLeadTimeDays.FieldName = "LeadTimeDays";
            this.gdcLeadTimeDays.FieldNameSortGroup = "LeadTimeDays";
            this.gdcLeadTimeDays.Name = "gdcLeadTimeDays";
            this.gdcLeadTimeDays.Visible = true;
            this.gdcLeadTimeDays.VisibleIndex = 17;
            // 
            // gdcLeadTimeHr
            // 
            this.gdcLeadTimeHr.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcLeadTimeHr.AppearanceHeader.Options.UseFont = true;
            this.gdcLeadTimeHr.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcLeadTimeHr.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcLeadTimeHr.Caption = "Lead Time Hr.";
            this.gdcLeadTimeHr.FieldName = "LeadTimeHr";
            this.gdcLeadTimeHr.FieldNameSortGroup = "LeadTimeHr";
            this.gdcLeadTimeHr.Name = "gdcLeadTimeHr";
            this.gdcLeadTimeHr.Visible = true;
            this.gdcLeadTimeHr.VisibleIndex = 18;
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
            this.gdcContactName1.VisibleIndex = 19;
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
            this.gdcContactName2.VisibleIndex = 20;
            // 
            // gdcContactName3
            // 
            this.gdcContactName3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcContactName3.AppearanceHeader.Options.UseFont = true;
            this.gdcContactName3.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcContactName3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcContactName3.Caption = "ContactName3";
            this.gdcContactName3.FieldName = "ContactName3";
            this.gdcContactName3.FieldNameSortGroup = "ContactName3";
            this.gdcContactName3.Name = "gdcContactName3";
            this.gdcContactName3.Visible = true;
            this.gdcContactName3.VisibleIndex = 21;
            // 
            // gdcRemark
            // 
            this.gdcRemark.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcRemark.AppearanceHeader.Options.UseFont = true;
            this.gdcRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcRemark.Caption = "Remark";
            this.gdcRemark.FieldName = "Remark";
            this.gdcRemark.FieldNameSortGroup = "Remark";
            this.gdcRemark.Name = "gdcRemark";
            this.gdcRemark.Visible = true;
            this.gdcRemark.VisibleIndex = 22;
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
            this.gdcCreateDate.VisibleIndex = 24;
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
            this.gdcCreateUser.VisibleIndex = 25;
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
            this.gdcUpdateDate.VisibleIndex = 26;
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
            this.gdcUpdateUser.VisibleIndex = 27;
            // 
            // gdcExchangeRate
            // 
            this.gdcExchangeRate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcExchangeRate.AppearanceHeader.Options.UseFont = true;
            this.gdcExchangeRate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcExchangeRate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcExchangeRate.Caption = "Exchange Rate";
            this.gdcExchangeRate.FieldName = "Rate";
            this.gdcExchangeRate.Name = "gdcExchangeRate";
            this.gdcExchangeRate.Visible = true;
            this.gdcExchangeRate.VisibleIndex = 23;
            // 
            // frmXMSS070_FinalDestination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 496);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmXMSS070_FinalDestination";
            this.Text = "XMSS070 : Final Destination Master";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFinalDesName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinalDesCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Control.OwnerControl ownerControl;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TextEdit txtFinalDesName;
        private DevExpress.XtraEditors.TextEdit txtFinalDesCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private Control.CustomerControl customerControl;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcFinalDestinationCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcFinalDestinationName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcFinalDestinationAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gdcFinalDestinationDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCity;
        private DevExpress.XtraGrid.Columns.GridColumn gdcStateOrProvince;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCountry;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPhoneNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcExtension;
        private DevExpress.XtraGrid.Columns.GridColumn gdcFaxNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPostalCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcDistance;
        private DevExpress.XtraGrid.Columns.GridColumn gdcMobileNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLeadTimeDays;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLeadTimeHr;
        private DevExpress.XtraGrid.Columns.GridColumn gdcContactName1;
        private DevExpress.XtraGrid.Columns.GridColumn gdcContactName2;
        private DevExpress.XtraGrid.Columns.GridColumn gdcContactName3;
        private DevExpress.XtraGrid.Columns.GridColumn gdcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcExchangeRate;
    }
}
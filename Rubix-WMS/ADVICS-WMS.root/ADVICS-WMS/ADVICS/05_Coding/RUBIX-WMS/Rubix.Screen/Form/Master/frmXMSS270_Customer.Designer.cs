namespace Rubix.Screen.Form.Master
{
    partial class frmXMSS270_Customer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXMSS270_Customer));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcOwnerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcOwnerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gdcPickingLeadTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPackingLeadTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcTransportLeadTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcIsCalVAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcVAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPaymentTerm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcInvoiceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcBranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcTaxID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcInsurance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcFreight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gdcAccountee = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerCode.Properties)).BeginInit();
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
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 185);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(889, 313);
            this.groupControl2.TabIndex = 6;
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
            this.grdSearchResult.Size = new System.Drawing.Size(877, 283);
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
            this.gdcPriority,
            this.gdcCustomerCode,
            this.gdcCustomerName,
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
            this.gdcPickingLeadTime,
            this.gdcPackingLeadTime,
            this.gdcTransportLeadTime,
            this.gdcIsCalVAT,
            this.gdcVAT,
            this.gdcPaymentTerm,
            this.gdcInvoiceType,
            this.gdcBranch,
            this.gdcTaxID,
            this.gdcRemark,
            this.gdcCreateDate,
            this.gdcCreateUser,
            this.gdcUpdateDate,
            this.gdcUpdateUser,
            this.gdcInsurance,
            this.gdcFreight,
            this.gdcAccountee});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            // 
            // gdcOwnerCode
            // 
            this.gdcOwnerCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
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
            this.gdcOwnerName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
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
            // gdcPriority
            // 
            this.gdcPriority.AppearanceCell.Options.UseTextOptions = true;
            this.gdcPriority.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPriority.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPriority.AppearanceHeader.Options.UseFont = true;
            this.gdcPriority.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPriority.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPriority.Caption = "Priority";
            this.gdcPriority.FieldName = "Priority";
            this.gdcPriority.Name = "gdcPriority";
            this.gdcPriority.Visible = true;
            this.gdcPriority.VisibleIndex = 2;
            // 
            // gdcCustomerCode
            // 
            this.gdcCustomerCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCustomerCode.AppearanceHeader.Options.UseFont = true;
            this.gdcCustomerCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCustomerCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCustomerCode.Caption = "Customer Code";
            this.gdcCustomerCode.FieldName = "CustomerCode";
            this.gdcCustomerCode.FieldNameSortGroup = "CustomerCode";
            this.gdcCustomerCode.Name = "gdcCustomerCode";
            this.gdcCustomerCode.Visible = true;
            this.gdcCustomerCode.VisibleIndex = 3;
            // 
            // gdcCustomerName
            // 
            this.gdcCustomerName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCustomerName.AppearanceHeader.Options.UseFont = true;
            this.gdcCustomerName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCustomerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCustomerName.Caption = "Customer Name";
            this.gdcCustomerName.FieldName = "CustomerName";
            this.gdcCustomerName.FieldNameSortGroup = "CustomerName";
            this.gdcCustomerName.Name = "gdcCustomerName";
            this.gdcCustomerName.Visible = true;
            this.gdcCustomerName.VisibleIndex = 4;
            // 
            // gdcBusinessType
            // 
            this.gdcBusinessType.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcBusinessType.AppearanceHeader.Options.UseFont = true;
            this.gdcBusinessType.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcBusinessType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcBusinessType.Caption = "Business Type";
            this.gdcBusinessType.FieldName = "BusinessType";
            this.gdcBusinessType.FieldNameSortGroup = "BusinessType";
            this.gdcBusinessType.Name = "gdcBusinessType";
            this.gdcBusinessType.Visible = true;
            this.gdcBusinessType.VisibleIndex = 5;
            // 
            // gdcAddress
            // 
            this.gdcAddress.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcAddress.AppearanceHeader.Options.UseFont = true;
            this.gdcAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcAddress.Caption = "Address";
            this.gdcAddress.FieldName = "Address";
            this.gdcAddress.FieldNameSortGroup = "Address";
            this.gdcAddress.Name = "gdcAddress";
            this.gdcAddress.Visible = true;
            this.gdcAddress.VisibleIndex = 6;
            // 
            // gdcCity
            // 
            this.gdcCity.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
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
            this.gdcStateOrProvince.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcStateOrProvince.AppearanceHeader.Options.UseFont = true;
            this.gdcStateOrProvince.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcStateOrProvince.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcStateOrProvince.Caption = "State / Province";
            this.gdcStateOrProvince.FieldName = "StateOrProvince";
            this.gdcStateOrProvince.FieldNameSortGroup = "StateOrProvince";
            this.gdcStateOrProvince.Name = "gdcStateOrProvince";
            this.gdcStateOrProvince.Visible = true;
            this.gdcStateOrProvince.VisibleIndex = 9;
            // 
            // gdcPostalCode
            // 
            this.gdcPostalCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPostalCode.AppearanceHeader.Options.UseFont = true;
            this.gdcPostalCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPostalCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPostalCode.Caption = "Postal Code";
            this.gdcPostalCode.FieldName = "PostalCode";
            this.gdcPostalCode.FieldNameSortGroup = "PostalCode";
            this.gdcPostalCode.Name = "gdcPostalCode";
            this.gdcPostalCode.Visible = true;
            this.gdcPostalCode.VisibleIndex = 10;
            // 
            // gdcCountry
            // 
            this.gdcCountry.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCountry.AppearanceHeader.Options.UseFont = true;
            this.gdcCountry.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCountry.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCountry.Caption = "Country";
            this.gdcCountry.FieldName = "Country";
            this.gdcCountry.FieldNameSortGroup = "Country";
            this.gdcCountry.Name = "gdcCountry";
            this.gdcCountry.Visible = true;
            this.gdcCountry.VisibleIndex = 11;
            // 
            // gdcPhoneNo
            // 
            this.gdcPhoneNo.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPhoneNo.AppearanceHeader.Options.UseFont = true;
            this.gdcPhoneNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPhoneNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPhoneNo.Caption = "Phone No.";
            this.gdcPhoneNo.FieldName = "PhoneNo";
            this.gdcPhoneNo.FieldNameSortGroup = "PhoneNo";
            this.gdcPhoneNo.Name = "gdcPhoneNo";
            this.gdcPhoneNo.Visible = true;
            this.gdcPhoneNo.VisibleIndex = 12;
            // 
            // gdcExtension
            // 
            this.gdcExtension.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcExtension.AppearanceHeader.Options.UseFont = true;
            this.gdcExtension.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcExtension.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcExtension.Caption = "Extension";
            this.gdcExtension.FieldName = "Extension";
            this.gdcExtension.FieldNameSortGroup = "Extension";
            this.gdcExtension.Name = "gdcExtension";
            this.gdcExtension.Visible = true;
            this.gdcExtension.VisibleIndex = 13;
            // 
            // gdcMobileNo
            // 
            this.gdcMobileNo.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcMobileNo.AppearanceHeader.Options.UseFont = true;
            this.gdcMobileNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcMobileNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcMobileNo.Caption = "Mobile No.";
            this.gdcMobileNo.FieldName = "MobileNo";
            this.gdcMobileNo.FieldNameSortGroup = "MobileNo";
            this.gdcMobileNo.Name = "gdcMobileNo";
            this.gdcMobileNo.Visible = true;
            this.gdcMobileNo.VisibleIndex = 14;
            // 
            // gdcFaxNo
            // 
            this.gdcFaxNo.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcFaxNo.AppearanceHeader.Options.UseFont = true;
            this.gdcFaxNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcFaxNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcFaxNo.Caption = "Fax No.";
            this.gdcFaxNo.FieldName = "FaxNo";
            this.gdcFaxNo.FieldNameSortGroup = "FaxNo";
            this.gdcFaxNo.Name = "gdcFaxNo";
            this.gdcFaxNo.Visible = true;
            this.gdcFaxNo.VisibleIndex = 15;
            // 
            // gdcEmailAddress
            // 
            this.gdcEmailAddress.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcEmailAddress.AppearanceHeader.Options.UseFont = true;
            this.gdcEmailAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcEmailAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcEmailAddress.Caption = "Email Address";
            this.gdcEmailAddress.FieldName = "EmailAddress";
            this.gdcEmailAddress.FieldNameSortGroup = "EmailAddress";
            this.gdcEmailAddress.Name = "gdcEmailAddress";
            this.gdcEmailAddress.Visible = true;
            this.gdcEmailAddress.VisibleIndex = 16;
            // 
            // gdcContactName1
            // 
            this.gdcContactName1.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcContactName1.AppearanceHeader.Options.UseFont = true;
            this.gdcContactName1.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcContactName1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcContactName1.Caption = "Contact Name1";
            this.gdcContactName1.FieldName = "ContactName1";
            this.gdcContactName1.FieldNameSortGroup = "ContactName1";
            this.gdcContactName1.Name = "gdcContactName1";
            this.gdcContactName1.Visible = true;
            this.gdcContactName1.VisibleIndex = 17;
            // 
            // gdcContactName2
            // 
            this.gdcContactName2.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcContactName2.AppearanceHeader.Options.UseFont = true;
            this.gdcContactName2.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcContactName2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcContactName2.Caption = "Contact Name2";
            this.gdcContactName2.FieldName = "ContactName2";
            this.gdcContactName2.FieldNameSortGroup = "ContactName2";
            this.gdcContactName2.Name = "gdcContactName2";
            this.gdcContactName2.Visible = true;
            this.gdcContactName2.VisibleIndex = 18;
            // 
            // gdcContactName3
            // 
            this.gdcContactName3.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcContactName3.AppearanceHeader.Options.UseFont = true;
            this.gdcContactName3.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcContactName3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcContactName3.Caption = "Contact Name3";
            this.gdcContactName3.FieldName = "ContactName3";
            this.gdcContactName3.FieldNameSortGroup = "ContactName3";
            this.gdcContactName3.Name = "gdcContactName3";
            this.gdcContactName3.Visible = true;
            this.gdcContactName3.VisibleIndex = 19;
            // 
            // gdcPickingLeadTime
            // 
            this.gdcPickingLeadTime.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPickingLeadTime.AppearanceHeader.Options.UseFont = true;
            this.gdcPickingLeadTime.Caption = "Picking L/T";
            this.gdcPickingLeadTime.FieldName = "PickingLeadTime";
            this.gdcPickingLeadTime.FieldNameSortGroup = "PickingLeadTime";
            this.gdcPickingLeadTime.Name = "gdcPickingLeadTime";
            this.gdcPickingLeadTime.Visible = true;
            this.gdcPickingLeadTime.VisibleIndex = 20;
            // 
            // gdcPackingLeadTime
            // 
            this.gdcPackingLeadTime.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPackingLeadTime.AppearanceHeader.Options.UseFont = true;
            this.gdcPackingLeadTime.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPackingLeadTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPackingLeadTime.Caption = "Packing L/T";
            this.gdcPackingLeadTime.FieldName = "PackingLeadTime";
            this.gdcPackingLeadTime.FieldNameSortGroup = "PackingLeadTime";
            this.gdcPackingLeadTime.Name = "gdcPackingLeadTime";
            this.gdcPackingLeadTime.Visible = true;
            this.gdcPackingLeadTime.VisibleIndex = 22;
            // 
            // gdcTransportLeadTime
            // 
            this.gdcTransportLeadTime.Caption = "Transport L/T";
            this.gdcTransportLeadTime.FieldName = "TransportLeadTime";
            this.gdcTransportLeadTime.FieldNameSortGroup = "TransportLeadTime";
            this.gdcTransportLeadTime.Name = "gdcTransportLeadTime";
            this.gdcTransportLeadTime.Visible = true;
            this.gdcTransportLeadTime.VisibleIndex = 21;
            // 
            // gdcIsCalVAT
            // 
            this.gdcIsCalVAT.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcIsCalVAT.AppearanceHeader.Options.UseFont = true;
            this.gdcIsCalVAT.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcIsCalVAT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcIsCalVAT.Caption = "Is Cal VAT";
            this.gdcIsCalVAT.FieldName = "IsCalVAT";
            this.gdcIsCalVAT.FieldNameSortGroup = "IsCalVAT";
            this.gdcIsCalVAT.Name = "gdcIsCalVAT";
            this.gdcIsCalVAT.Visible = true;
            this.gdcIsCalVAT.VisibleIndex = 23;
            // 
            // gdcVAT
            // 
            this.gdcVAT.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcVAT.AppearanceHeader.Options.UseFont = true;
            this.gdcVAT.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcVAT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcVAT.Caption = "VAT";
            this.gdcVAT.FieldName = "VAT";
            this.gdcVAT.FieldNameSortGroup = "VAT";
            this.gdcVAT.Name = "gdcVAT";
            this.gdcVAT.Visible = true;
            this.gdcVAT.VisibleIndex = 24;
            // 
            // gdcPaymentTerm
            // 
            this.gdcPaymentTerm.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPaymentTerm.AppearanceHeader.Options.UseFont = true;
            this.gdcPaymentTerm.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPaymentTerm.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPaymentTerm.Caption = "Payment Term";
            this.gdcPaymentTerm.FieldName = "PaymentTerm";
            this.gdcPaymentTerm.FieldNameSortGroup = "PaymentTerm";
            this.gdcPaymentTerm.Name = "gdcPaymentTerm";
            this.gdcPaymentTerm.Visible = true;
            this.gdcPaymentTerm.VisibleIndex = 27;
            // 
            // gdcInvoiceType
            // 
            this.gdcInvoiceType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcInvoiceType.AppearanceHeader.Options.UseFont = true;
            this.gdcInvoiceType.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcInvoiceType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcInvoiceType.Caption = "Invoice Type";
            this.gdcInvoiceType.FieldName = "InvoiceType";
            this.gdcInvoiceType.FieldNameSortGroup = "InvoiceType";
            this.gdcInvoiceType.Name = "gdcInvoiceType";
            this.gdcInvoiceType.Visible = true;
            this.gdcInvoiceType.VisibleIndex = 28;
            // 
            // gdcBranch
            // 
            this.gdcBranch.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcBranch.AppearanceHeader.Options.UseFont = true;
            this.gdcBranch.Caption = "Branch";
            this.gdcBranch.FieldName = "Branch";
            this.gdcBranch.FieldNameSortGroup = "Branch";
            this.gdcBranch.Name = "gdcBranch";
            this.gdcBranch.Visible = true;
            this.gdcBranch.VisibleIndex = 29;
            // 
            // gdcTaxID
            // 
            this.gdcTaxID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcTaxID.AppearanceHeader.Options.UseFont = true;
            this.gdcTaxID.Caption = "TAX ID";
            this.gdcTaxID.FieldName = "TaxID";
            this.gdcTaxID.FieldNameSortGroup = "TaxID";
            this.gdcTaxID.Name = "gdcTaxID";
            this.gdcTaxID.Visible = true;
            this.gdcTaxID.VisibleIndex = 30;
            // 
            // gdcRemark
            // 
            this.gdcRemark.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcRemark.AppearanceHeader.Options.UseFont = true;
            this.gdcRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcRemark.Caption = "Remark";
            this.gdcRemark.FieldName = "Remark";
            this.gdcRemark.Name = "gdcRemark";
            this.gdcRemark.Visible = true;
            this.gdcRemark.VisibleIndex = 31;
            // 
            // gdcCreateDate
            // 
            this.gdcCreateDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
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
            this.gdcCreateDate.VisibleIndex = 32;
            // 
            // gdcCreateUser
            // 
            this.gdcCreateUser.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCreateUser.AppearanceHeader.Options.UseFont = true;
            this.gdcCreateUser.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCreateUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCreateUser.Caption = "Create User";
            this.gdcCreateUser.FieldName = "CreateUser";
            this.gdcCreateUser.FieldNameSortGroup = "CreateUser";
            this.gdcCreateUser.Name = "gdcCreateUser";
            this.gdcCreateUser.Visible = true;
            this.gdcCreateUser.VisibleIndex = 33;
            // 
            // gdcUpdateDate
            // 
            this.gdcUpdateDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
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
            this.gdcUpdateDate.VisibleIndex = 34;
            // 
            // gdcUpdateUser
            // 
            this.gdcUpdateUser.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcUpdateUser.AppearanceHeader.Options.UseFont = true;
            this.gdcUpdateUser.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcUpdateUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcUpdateUser.Caption = "Update User";
            this.gdcUpdateUser.FieldName = "UpdateUser";
            this.gdcUpdateUser.FieldNameSortGroup = "UpdateUser";
            this.gdcUpdateUser.Name = "gdcUpdateUser";
            this.gdcUpdateUser.Visible = true;
            this.gdcUpdateUser.VisibleIndex = 35;
            // 
            // gdcInsurance
            // 
            this.gdcInsurance.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcInsurance.AppearanceHeader.Options.UseFont = true;
            this.gdcInsurance.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcInsurance.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcInsurance.Caption = "Insurance";
            this.gdcInsurance.FieldName = "Insurance";
            this.gdcInsurance.Name = "gdcInsurance";
            this.gdcInsurance.Visible = true;
            this.gdcInsurance.VisibleIndex = 25;
            // 
            // gdcFreight
            // 
            this.gdcFreight.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcFreight.AppearanceHeader.Options.UseFont = true;
            this.gdcFreight.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcFreight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcFreight.Caption = "Freight";
            this.gdcFreight.FieldName = "Freight";
            this.gdcFreight.Name = "gdcFreight";
            this.gdcFreight.Visible = true;
            this.gdcFreight.VisibleIndex = 26;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.ownerControl);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.txtCustomerName);
            this.groupControl1.Controls.Add(this.txtCustomerCode);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 78);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(889, 107);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Search Criteria";
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(44, 28);
            this.ownerControl.Name = "ownerControl";
            this.ownerControl.ReadOnly = false;
            this.ownerControl.RequireField = false;
            this.ownerControl.Size = new System.Drawing.Size(419, 21);
            this.ownerControl.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(6, 80);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(84, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Customer Name";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(806, 73);
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
            this.btnSearch.Location = new System.Drawing.Point(725, 73);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(105, 77);
            this.txtCustomerName.MenuManager = this.ribbonControl1;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(359, 20);
            this.txtCustomerName.TabIndex = 3;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(105, 53);
            this.txtCustomerCode.MenuManager = this.ribbonControl1;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(122, 20);
            this.txtCustomerCode.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(7, 56);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(82, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Customer Code";
            // 
            // gdcAccountee
            // 
            this.gdcAccountee.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcAccountee.AppearanceHeader.Options.UseFont = true;
            this.gdcAccountee.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcAccountee.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcAccountee.Caption = "Accountee";
            this.gdcAccountee.FieldName = "Accountee";
            this.gdcAccountee.Name = "gdcAccountee";
            this.gdcAccountee.Visible = true;
            this.gdcAccountee.VisibleIndex = 7;
            // 
            // frmXMSS270_Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 498);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmXMSS270_Customer";
            this.Text = "XMSS270 :  Customer Master";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraEditors.TextEdit txtCustomerCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private Control.OwnerControl ownerControl;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCustomerName;
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
        private DevExpress.XtraGrid.Columns.GridColumn gdcIsCalVAT;
        private DevExpress.XtraGrid.Columns.GridColumn gdcVAT;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPaymentTerm;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPackingLeadTime;
        private DevExpress.XtraGrid.Columns.GridColumn gdcInvoiceType;
        private DevExpress.XtraGrid.Columns.GridColumn gdcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gdcBranch;
        private DevExpress.XtraGrid.Columns.GridColumn gdcTaxID;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPickingLeadTime;
        private DevExpress.XtraGrid.Columns.GridColumn gdcTransportLeadTime;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPriority;
        private DevExpress.XtraGrid.Columns.GridColumn gdcInsurance;
        private DevExpress.XtraGrid.Columns.GridColumn gdcFreight;
        private DevExpress.XtraGrid.Columns.GridColumn gdcAccountee;
    }
}
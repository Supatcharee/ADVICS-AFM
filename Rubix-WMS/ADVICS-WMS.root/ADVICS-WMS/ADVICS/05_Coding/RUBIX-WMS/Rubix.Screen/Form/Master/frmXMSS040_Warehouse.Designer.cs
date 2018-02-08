namespace Rubix.Screen.Form.Master
{
    partial class frmXMSS040_Warehouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXMSS040_Warehouse));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtWarehouseName = new DevExpress.XtraEditors.TextEdit();
            this.txtWarehouseCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcWarehouseID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcWarehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcWarehouseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPhoneNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcExtension = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcMobile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcFaxNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcAddress1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcAddress2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcDivision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcContactName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcContactName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcContactName3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcMaxM3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcMaxM2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcMaxPallet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcMaxCapacity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcNoOfForklift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcManPower = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcInChargeEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseCode.Properties)).BeginInit();
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
            this.groupControl1.Controls.Add(this.ownerControl);
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.txtWarehouseName);
            this.groupControl1.Controls.Add(this.txtWarehouseCode);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 78);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(887, 99);
            this.groupControl1.TabIndex = 11;
            this.groupControl1.Text = "Search Criteria";
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(88, 24);
            this.ownerControl.Name = "ownerControl";
            this.ownerControl.ReadOnly = false;
            this.ownerControl.RequireField = false;
            this.ownerControl.Size = new System.Drawing.Size(455, 21);
            this.ownerControl.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(804, 70);
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
            this.btnSearch.Location = new System.Drawing.Point(723, 70);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtWarehouseName
            // 
            this.txtWarehouseName.Location = new System.Drawing.Point(148, 71);
            this.txtWarehouseName.MenuManager = this.ribbonControl1;
            this.txtWarehouseName.Name = "txtWarehouseName";
            this.txtWarehouseName.Size = new System.Drawing.Size(395, 20);
            this.txtWarehouseName.TabIndex = 3;
            // 
            // txtWarehouseCode
            // 
            this.txtWarehouseCode.Location = new System.Drawing.Point(148, 48);
            this.txtWarehouseCode.MenuManager = this.ribbonControl1;
            this.txtWarehouseCode.Name = "txtWarehouseCode";
            this.txtWarehouseCode.Size = new System.Drawing.Size(123, 20);
            this.txtWarehouseCode.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(4, 75);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(132, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Warehouse Name";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(6, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(130, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Warehouse Code";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 177);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(887, 313);
            this.groupControl2.TabIndex = 10;
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
            this.grdSearchResult.Size = new System.Drawing.Size(875, 283);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcWarehouseID,
            this.gdcWarehouseCode,
            this.gdcWarehouseName,
            this.gdcPhoneNo,
            this.gdcExtension,
            this.gdcMobile,
            this.gdcFaxNo,
            this.gdcAddress1,
            this.gdcAddress2,
            this.gdcDivision,
            this.gdcContactName1,
            this.gdcContactName2,
            this.gdcContactName3,
            this.gdcMaxM3,
            this.gdcMaxM2,
            this.gdcMaxPallet,
            this.gdcMaxCapacity,
            this.gdcNoOfForklift,
            this.gdcManPower,
            this.gdcInChargeEmail,
            this.gdcRemark,
            this.gdcCreateDate,
            this.gdcCreateUser,
            this.gdcUpdateDate,
            this.gdcUpdateUser});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            // 
            // gdcWarehouseID
            // 
            this.gdcWarehouseID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcWarehouseID.AppearanceHeader.Options.UseFont = true;
            this.gdcWarehouseID.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcWarehouseID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcWarehouseID.Caption = "Warehouse ID";
            this.gdcWarehouseID.FieldName = "WarehouseID";
            this.gdcWarehouseID.FieldNameSortGroup = "WarehouseID";
            this.gdcWarehouseID.Name = "gdcWarehouseID";
            // 
            // gdcWarehouseCode
            // 
            this.gdcWarehouseCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcWarehouseCode.AppearanceHeader.Options.UseFont = true;
            this.gdcWarehouseCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcWarehouseCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcWarehouseCode.Caption = "Warehouse Code";
            this.gdcWarehouseCode.FieldName = "WarehouseCode";
            this.gdcWarehouseCode.FieldNameSortGroup = "WarehouseCode";
            this.gdcWarehouseCode.Name = "gdcWarehouseCode";
            this.gdcWarehouseCode.Visible = true;
            this.gdcWarehouseCode.VisibleIndex = 0;
            // 
            // gdcWarehouseName
            // 
            this.gdcWarehouseName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcWarehouseName.AppearanceHeader.Options.UseFont = true;
            this.gdcWarehouseName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcWarehouseName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcWarehouseName.Caption = "Warehouse Name";
            this.gdcWarehouseName.FieldName = "WarehouseName";
            this.gdcWarehouseName.FieldNameSortGroup = "WarehouseName";
            this.gdcWarehouseName.Name = "gdcWarehouseName";
            this.gdcWarehouseName.Visible = true;
            this.gdcWarehouseName.VisibleIndex = 1;
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
            this.gdcPhoneNo.VisibleIndex = 2;
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
            this.gdcExtension.VisibleIndex = 3;
            // 
            // gdcMobile
            // 
            this.gdcMobile.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcMobile.AppearanceHeader.Options.UseFont = true;
            this.gdcMobile.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcMobile.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcMobile.Caption = "Mobile";
            this.gdcMobile.FieldName = "Mobile";
            this.gdcMobile.FieldNameSortGroup = "Mobile";
            this.gdcMobile.Name = "gdcMobile";
            this.gdcMobile.Visible = true;
            this.gdcMobile.VisibleIndex = 4;
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
            this.gdcFaxNo.VisibleIndex = 5;
            // 
            // gdcAddress1
            // 
            this.gdcAddress1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcAddress1.AppearanceHeader.Options.UseFont = true;
            this.gdcAddress1.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcAddress1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcAddress1.Caption = "Address 1";
            this.gdcAddress1.FieldName = "Address1";
            this.gdcAddress1.FieldNameSortGroup = "Address1";
            this.gdcAddress1.Name = "gdcAddress1";
            this.gdcAddress1.Visible = true;
            this.gdcAddress1.VisibleIndex = 6;
            // 
            // gdcAddress2
            // 
            this.gdcAddress2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcAddress2.AppearanceHeader.Options.UseFont = true;
            this.gdcAddress2.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcAddress2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcAddress2.Caption = "Address 2";
            this.gdcAddress2.FieldName = "Address2";
            this.gdcAddress2.FieldNameSortGroup = "Address2";
            this.gdcAddress2.Name = "gdcAddress2";
            this.gdcAddress2.Visible = true;
            this.gdcAddress2.VisibleIndex = 7;
            // 
            // gdcDivision
            // 
            this.gdcDivision.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcDivision.AppearanceHeader.Options.UseFont = true;
            this.gdcDivision.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcDivision.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcDivision.Caption = "Division";
            this.gdcDivision.FieldName = "Division";
            this.gdcDivision.FieldNameSortGroup = "Division";
            this.gdcDivision.Name = "gdcDivision";
            this.gdcDivision.Visible = true;
            this.gdcDivision.VisibleIndex = 8;
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
            this.gdcContactName1.VisibleIndex = 9;
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
            this.gdcContactName2.VisibleIndex = 10;
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
            this.gdcContactName3.VisibleIndex = 11;
            // 
            // gdcMaxM3
            // 
            this.gdcMaxM3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcMaxM3.AppearanceHeader.Options.UseFont = true;
            this.gdcMaxM3.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcMaxM3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcMaxM3.Caption = "Max M3";
            this.gdcMaxM3.FieldName = "MaxM3";
            this.gdcMaxM3.FieldNameSortGroup = "MaxM3";
            this.gdcMaxM3.Name = "gdcMaxM3";
            this.gdcMaxM3.Visible = true;
            this.gdcMaxM3.VisibleIndex = 12;
            // 
            // gdcMaxM2
            // 
            this.gdcMaxM2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcMaxM2.AppearanceHeader.Options.UseFont = true;
            this.gdcMaxM2.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcMaxM2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcMaxM2.Caption = "Max M2";
            this.gdcMaxM2.FieldName = "MaxM2";
            this.gdcMaxM2.FieldNameSortGroup = "MaxM2";
            this.gdcMaxM2.Name = "gdcMaxM2";
            this.gdcMaxM2.Visible = true;
            this.gdcMaxM2.VisibleIndex = 13;
            // 
            // gdcMaxPallet
            // 
            this.gdcMaxPallet.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcMaxPallet.AppearanceHeader.Options.UseFont = true;
            this.gdcMaxPallet.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcMaxPallet.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcMaxPallet.Caption = "Max Pallet";
            this.gdcMaxPallet.FieldName = "MaxPallet";
            this.gdcMaxPallet.FieldNameSortGroup = "MaxPallet";
            this.gdcMaxPallet.Name = "gdcMaxPallet";
            this.gdcMaxPallet.Visible = true;
            this.gdcMaxPallet.VisibleIndex = 14;
            // 
            // gdcMaxCapacity
            // 
            this.gdcMaxCapacity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcMaxCapacity.AppearanceHeader.Options.UseFont = true;
            this.gdcMaxCapacity.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcMaxCapacity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcMaxCapacity.Caption = "Max Capacity";
            this.gdcMaxCapacity.FieldName = "MaxCapacity";
            this.gdcMaxCapacity.FieldNameSortGroup = "MaxCapacity";
            this.gdcMaxCapacity.Name = "gdcMaxCapacity";
            this.gdcMaxCapacity.Visible = true;
            this.gdcMaxCapacity.VisibleIndex = 15;
            // 
            // gdcNoOfForklift
            // 
            this.gdcNoOfForklift.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcNoOfForklift.AppearanceHeader.Options.UseFont = true;
            this.gdcNoOfForklift.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcNoOfForklift.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcNoOfForklift.Caption = "No. of Forklift";
            this.gdcNoOfForklift.FieldName = "NoOfForklift";
            this.gdcNoOfForklift.FieldNameSortGroup = "NoOfForklift";
            this.gdcNoOfForklift.Name = "gdcNoOfForklift";
            this.gdcNoOfForklift.Visible = true;
            this.gdcNoOfForklift.VisibleIndex = 16;
            // 
            // gdcManPower
            // 
            this.gdcManPower.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcManPower.AppearanceHeader.Options.UseFont = true;
            this.gdcManPower.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcManPower.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcManPower.Caption = "ManPower";
            this.gdcManPower.FieldName = "ManPower";
            this.gdcManPower.FieldNameSortGroup = "ManPower";
            this.gdcManPower.Name = "gdcManPower";
            this.gdcManPower.Visible = true;
            this.gdcManPower.VisibleIndex = 17;
            // 
            // gdcInChargeEmail
            // 
            this.gdcInChargeEmail.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcInChargeEmail.AppearanceHeader.Options.UseFont = true;
            this.gdcInChargeEmail.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcInChargeEmail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcInChargeEmail.Caption = "In Charge Email";
            this.gdcInChargeEmail.FieldName = "InChargeEmail";
            this.gdcInChargeEmail.FieldNameSortGroup = "InChargeEmail";
            this.gdcInChargeEmail.Name = "gdcInChargeEmail";
            this.gdcInChargeEmail.Visible = true;
            this.gdcInChargeEmail.VisibleIndex = 18;
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
            this.gdcRemark.VisibleIndex = 19;
            // 
            // gdcCreateDate
            // 
            this.gdcCreateDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCreateDate.AppearanceHeader.Options.UseFont = true;
            this.gdcCreateDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCreateDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCreateDate.Caption = "Create Date";
            this.gdcCreateDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gdcCreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcCreateDate.FieldName = "CreateDate";
            this.gdcCreateDate.FieldNameSortGroup = "CreateDate";
            this.gdcCreateDate.Name = "gdcCreateDate";
            this.gdcCreateDate.Visible = true;
            this.gdcCreateDate.VisibleIndex = 20;
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
            this.gdcCreateUser.VisibleIndex = 21;
            // 
            // gdcUpdateDate
            // 
            this.gdcUpdateDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcUpdateDate.AppearanceHeader.Options.UseFont = true;
            this.gdcUpdateDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcUpdateDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcUpdateDate.Caption = "Update Date";
            this.gdcUpdateDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gdcUpdateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcUpdateDate.FieldName = "UpdateDate";
            this.gdcUpdateDate.FieldNameSortGroup = "UpdateDate";
            this.gdcUpdateDate.Name = "gdcUpdateDate";
            this.gdcUpdateDate.Visible = true;
            this.gdcUpdateDate.VisibleIndex = 22;
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
            this.gdcUpdateUser.VisibleIndex = 23;
            // 
            // frmXMSS040_Warehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 490);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmXMSS040_Warehouse";
            this.Text = "XMSS040 : Distribution Center Master";
            this.Load += new System.EventHandler(this.frmXMSS040_Warehouse_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseCode.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txtWarehouseName;
        private DevExpress.XtraEditors.TextEdit txtWarehouseCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWarehouseID;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWarehouseCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWarehouseName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPhoneNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcExtension;
        private DevExpress.XtraGrid.Columns.GridColumn gdcMobile;
        private DevExpress.XtraGrid.Columns.GridColumn gdcFaxNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcAddress1;
        private DevExpress.XtraGrid.Columns.GridColumn gdcAddress2;
        private DevExpress.XtraGrid.Columns.GridColumn gdcDivision;
        private DevExpress.XtraGrid.Columns.GridColumn gdcContactName1;
        private DevExpress.XtraGrid.Columns.GridColumn gdcContactName2;
        private DevExpress.XtraGrid.Columns.GridColumn gdcContactName3;
        private DevExpress.XtraGrid.Columns.GridColumn gdcMaxM3;
        private DevExpress.XtraGrid.Columns.GridColumn gdcMaxM2;
        private DevExpress.XtraGrid.Columns.GridColumn gdcMaxPallet;
        private DevExpress.XtraGrid.Columns.GridColumn gdcMaxCapacity;
        private DevExpress.XtraGrid.Columns.GridColumn gdcNoOfForklift;
        private DevExpress.XtraGrid.Columns.GridColumn gdcManPower;
        private DevExpress.XtraGrid.Columns.GridColumn gdcInChargeEmail;
        private DevExpress.XtraGrid.Columns.GridColumn gdcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateUser;


    }
}
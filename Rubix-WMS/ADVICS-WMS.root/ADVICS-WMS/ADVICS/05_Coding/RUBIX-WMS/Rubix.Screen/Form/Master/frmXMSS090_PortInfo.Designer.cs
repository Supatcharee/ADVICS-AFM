namespace Rubix.Screen.Form.Master
{
    partial class frmXMSS090_PortInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXMSS090_PortInfo));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtPostName = new DevExpress.XtraEditors.TextEdit();
            this.txtPostCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcOwnerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcOwnerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPortID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPortCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPortLongName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPortClassification = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPortClassificationName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCountryCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLeadTimeDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLeadTimeHr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPortAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPostalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcFreight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCurrency = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostCode.Properties)).BeginInit();
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
            this.ribbonControl1.Size = new System.Drawing.Size(890, 47);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.ownerControl);
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.txtPostName);
            this.groupControl1.Controls.Add(this.txtPostCode);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 78);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(890, 94);
            this.groupControl1.TabIndex = 17;
            this.groupControl1.Text = "Search Criteria";
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(20, 24);
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
            this.btnClear.Location = new System.Drawing.Point(807, 65);
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
            this.btnSearch.Location = new System.Drawing.Point(726, 65);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtPostName
            // 
            this.txtPostName.Location = new System.Drawing.Point(80, 69);
            this.txtPostName.MenuManager = this.ribbonControl1;
            this.txtPostName.Name = "txtPostName";
            this.txtPostName.Size = new System.Drawing.Size(395, 20);
            this.txtPostName.TabIndex = 3;
            // 
            // txtPostCode
            // 
            this.txtPostCode.Location = new System.Drawing.Point(80, 47);
            this.txtPostCode.MenuManager = this.ribbonControl1;
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(123, 20);
            this.txtPostCode.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(4, 70);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Port Name";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(6, 48);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Port Code";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 172);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(890, 320);
            this.groupControl2.TabIndex = 16;
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
            this.grdSearchResult.Size = new System.Drawing.Size(878, 290);
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
            this.gdcPortID,
            this.gdcPortCode,
            this.gdcPortLongName,
            this.gdcPortClassification,
            this.gdcPortClassificationName,
            this.gdcCountryCode,
            this.gdcLeadTimeDays,
            this.gdcLeadTimeHr,
            this.gdcPortAddress,
            this.gdcPostalCode,
            this.gdcFreight,
            this.gdcCurrency,
            this.gdcRemark,
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
            this.gdcOwnerName.FieldNameSortGroup = "OwnerName";
            this.gdcOwnerName.Name = "gdcOwnerName";
            this.gdcOwnerName.Visible = true;
            this.gdcOwnerName.VisibleIndex = 1;
            // 
            // gdcPortID
            // 
            this.gdcPortID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPortID.AppearanceHeader.Options.UseFont = true;
            this.gdcPortID.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPortID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPortID.Caption = "Port ID";
            this.gdcPortID.FieldName = "PortID";
            this.gdcPortID.FieldNameSortGroup = "PortID";
            this.gdcPortID.Name = "gdcPortID";
            // 
            // gdcPortCode
            // 
            this.gdcPortCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPortCode.AppearanceHeader.Options.UseFont = true;
            this.gdcPortCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPortCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPortCode.Caption = "Port Code";
            this.gdcPortCode.FieldName = "PortCode";
            this.gdcPortCode.FieldNameSortGroup = "PortCode";
            this.gdcPortCode.Name = "gdcPortCode";
            this.gdcPortCode.Visible = true;
            this.gdcPortCode.VisibleIndex = 2;
            // 
            // gdcPortLongName
            // 
            this.gdcPortLongName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPortLongName.AppearanceHeader.Options.UseFont = true;
            this.gdcPortLongName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPortLongName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPortLongName.Caption = "Port Name";
            this.gdcPortLongName.FieldName = "PortLongName";
            this.gdcPortLongName.FieldNameSortGroup = "PortLongName";
            this.gdcPortLongName.Name = "gdcPortLongName";
            this.gdcPortLongName.Visible = true;
            this.gdcPortLongName.VisibleIndex = 3;
            // 
            // gdcPortClassification
            // 
            this.gdcPortClassification.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPortClassification.AppearanceHeader.Options.UseFont = true;
            this.gdcPortClassification.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPortClassification.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPortClassification.Caption = "Port Classification";
            this.gdcPortClassification.FieldName = "PortClassification";
            this.gdcPortClassification.FieldNameSortGroup = "PortClassification";
            this.gdcPortClassification.Name = "gdcPortClassification";
            this.gdcPortClassification.Visible = true;
            this.gdcPortClassification.VisibleIndex = 4;
            // 
            // gdcPortClassificationName
            // 
            this.gdcPortClassificationName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPortClassificationName.AppearanceHeader.Options.UseFont = true;
            this.gdcPortClassificationName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPortClassificationName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPortClassificationName.Caption = "Port Classification Name";
            this.gdcPortClassificationName.FieldName = "PortClassificationName";
            this.gdcPortClassificationName.FieldNameSortGroup = "PortClassificationName";
            this.gdcPortClassificationName.Name = "gdcPortClassificationName";
            this.gdcPortClassificationName.Visible = true;
            this.gdcPortClassificationName.VisibleIndex = 5;
            // 
            // gdcCountryCode
            // 
            this.gdcCountryCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCountryCode.AppearanceHeader.Options.UseFont = true;
            this.gdcCountryCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcCountryCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcCountryCode.Caption = "Country Code";
            this.gdcCountryCode.FieldName = "CountryCode";
            this.gdcCountryCode.FieldNameSortGroup = "CountryCode";
            this.gdcCountryCode.Name = "gdcCountryCode";
            this.gdcCountryCode.Visible = true;
            this.gdcCountryCode.VisibleIndex = 6;
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
            this.gdcLeadTimeDays.VisibleIndex = 7;
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
            this.gdcLeadTimeHr.VisibleIndex = 8;
            // 
            // gdcPortAddress
            // 
            this.gdcPortAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPortAddress.AppearanceHeader.Options.UseFont = true;
            this.gdcPortAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPortAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPortAddress.Caption = "Port Address";
            this.gdcPortAddress.FieldName = "PortAddress";
            this.gdcPortAddress.FieldNameSortGroup = "PortAddress";
            this.gdcPortAddress.Name = "gdcPortAddress";
            this.gdcPortAddress.Visible = true;
            this.gdcPortAddress.VisibleIndex = 9;
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
            this.gdcPostalCode.VisibleIndex = 10;
            // 
            // gdcFreight
            // 
            this.gdcFreight.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcFreight.AppearanceHeader.Options.UseFont = true;
            this.gdcFreight.Caption = "Freight";
            this.gdcFreight.Name = "gdcFreight";
            this.gdcFreight.Visible = true;
            this.gdcFreight.VisibleIndex = 11;
            // 
            // gdcRemark
            // 
            this.gdcRemark.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcRemark.AppearanceHeader.Options.UseFont = true;
            this.gdcRemark.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcRemark.Caption = "gridColumn1";
            this.gdcRemark.FieldName = "Remark";
            this.gdcRemark.FieldNameSortGroup = "Remark";
            this.gdcRemark.Name = "gdcRemark";
            this.gdcRemark.Visible = true;
            this.gdcRemark.VisibleIndex = 13;
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
            this.gdcCreateDate.VisibleIndex = 14;
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
            this.gdcCreateUser.VisibleIndex = 15;
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
            this.gdcUpdateDate.VisibleIndex = 16;
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
            this.gdcUpdateUser.VisibleIndex = 17;
            // 
            // gdcCurrency
            // 
            this.gdcCurrency.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcCurrency.AppearanceHeader.Options.UseFont = true;
            this.gdcCurrency.Caption = "Currency";
            this.gdcCurrency.Name = "gdcCurrency";
            this.gdcCurrency.Visible = true;
            this.gdcCurrency.VisibleIndex = 12;
            // 
            // frmXMSS090_PortInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 492);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmXMSS090_PortInfo";
            this.Text = "XMSS090 : Port Information Master";
            this.Load += new System.EventHandler(this.frmXMSS090_PortInfo_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPostName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPostCode.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txtPostName;
        private DevExpress.XtraEditors.TextEdit txtPostCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPortID;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPortCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPortLongName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPortClassification;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPortClassificationName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCountryCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLeadTimeDays;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLeadTimeHr;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPortAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPostalCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcFreight;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCurrency;
    }
}
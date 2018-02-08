namespace Rubix.Screen.Form.Admin
{
    partial class frmADM010_UserMaintenance
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcMobile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLoginTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcDomainName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcWarehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcWarehouseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcOwnerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcOwnerName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
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
            this.ribbonControl1.Size = new System.Drawing.Size(882, 47);
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Location = new System.Drawing.Point(5, 34);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(872, 450);
            this.groupControl2.TabIndex = 9;
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
            this.grdSearchResult.Size = new System.Drawing.Size(860, 420);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcUserID,
            this.gdcFirstName,
            this.gdcLastName,
            this.gdcAddress,
            this.gdcTelephone,
            this.gdcMobile,
            this.gdcEmail,
            this.gdcLoginTypeName,
            this.gdcDomainName,
            this.gdcWarehouseCode,
            this.gdcWarehouseName,
            this.gdcOwnerCode,
            this.gdcOwnerName,
            this.gdcCreateUser,
            this.gdcCreateDate,
            this.gdcUpdateUser,
            this.gdcUpdateDate});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsCustomization.AllowGroup = false;
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            this.gdvSearchResult.OptionsView.ShowGroupPanel = false;
            // 
            // gdcUserID
            // 
            this.gdcUserID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcUserID.AppearanceHeader.Options.UseFont = true;
            this.gdcUserID.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcUserID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcUserID.Caption = "User Name";
            this.gdcUserID.FieldName = "UserID";
            this.gdcUserID.FieldNameSortGroup = "UserID";
            this.gdcUserID.Name = "gdcUserID";
            this.gdcUserID.Visible = true;
            this.gdcUserID.VisibleIndex = 0;
            // 
            // gdcFirstName
            // 
            this.gdcFirstName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcFirstName.AppearanceHeader.Options.UseFont = true;
            this.gdcFirstName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcFirstName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcFirstName.Caption = "First Name";
            this.gdcFirstName.FieldName = "FirstName";
            this.gdcFirstName.FieldNameSortGroup = "FirstName";
            this.gdcFirstName.Name = "gdcFirstName";
            this.gdcFirstName.Visible = true;
            this.gdcFirstName.VisibleIndex = 1;
            // 
            // gdcLastName
            // 
            this.gdcLastName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcLastName.AppearanceHeader.Options.UseFont = true;
            this.gdcLastName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcLastName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcLastName.Caption = "Last Name";
            this.gdcLastName.FieldName = "LastName";
            this.gdcLastName.FieldNameSortGroup = "LastName";
            this.gdcLastName.Name = "gdcLastName";
            this.gdcLastName.Visible = true;
            this.gdcLastName.VisibleIndex = 2;
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
            // gdcTelephone
            // 
            this.gdcTelephone.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcTelephone.AppearanceHeader.Options.UseFont = true;
            this.gdcTelephone.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcTelephone.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcTelephone.Caption = "Telephone";
            this.gdcTelephone.FieldName = "Telephone";
            this.gdcTelephone.FieldNameSortGroup = "Telephone";
            this.gdcTelephone.Name = "gdcTelephone";
            this.gdcTelephone.Visible = true;
            this.gdcTelephone.VisibleIndex = 4;
            // 
            // gdcMobile
            // 
            this.gdcMobile.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcMobile.AppearanceHeader.Options.UseFont = true;
            this.gdcMobile.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcMobile.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcMobile.Caption = "Mobile";
            this.gdcMobile.FieldName = "Mobile";
            this.gdcMobile.FieldNameSortGroup = "Mobile";
            this.gdcMobile.Name = "gdcMobile";
            this.gdcMobile.Visible = true;
            this.gdcMobile.VisibleIndex = 5;
            // 
            // gdcEmail
            // 
            this.gdcEmail.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcEmail.AppearanceHeader.Options.UseFont = true;
            this.gdcEmail.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcEmail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcEmail.Caption = "Email";
            this.gdcEmail.FieldName = "Email";
            this.gdcEmail.FieldNameSortGroup = "Email";
            this.gdcEmail.Name = "gdcEmail";
            this.gdcEmail.Visible = true;
            this.gdcEmail.VisibleIndex = 6;
            // 
            // gdcLoginTypeName
            // 
            this.gdcLoginTypeName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcLoginTypeName.AppearanceHeader.Options.UseFont = true;
            this.gdcLoginTypeName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcLoginTypeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcLoginTypeName.Caption = "Login Type";
            this.gdcLoginTypeName.FieldName = "LoginTypeName";
            this.gdcLoginTypeName.FieldNameSortGroup = "LoginTypeName";
            this.gdcLoginTypeName.Name = "gdcLoginTypeName";
            this.gdcLoginTypeName.Visible = true;
            this.gdcLoginTypeName.VisibleIndex = 7;
            // 
            // gdcDomainName
            // 
            this.gdcDomainName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcDomainName.AppearanceHeader.Options.UseFont = true;
            this.gdcDomainName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcDomainName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcDomainName.Caption = "Domain Name";
            this.gdcDomainName.FieldName = "DomainName";
            this.gdcDomainName.FieldNameSortGroup = "DomainName";
            this.gdcDomainName.Name = "gdcDomainName";
            this.gdcDomainName.Visible = true;
            this.gdcDomainName.VisibleIndex = 8;
            // 
            // gdcWarehouseCode
            // 
            this.gdcWarehouseCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcWarehouseCode.AppearanceHeader.Options.UseFont = true;
            this.gdcWarehouseCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcWarehouseCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcWarehouseCode.Caption = "Warehouse Code";
            this.gdcWarehouseCode.FieldName = "WarehouseCode";
            this.gdcWarehouseCode.FieldNameSortGroup = "WarehouseCode";
            this.gdcWarehouseCode.Name = "gdcWarehouseCode";
            this.gdcWarehouseCode.Visible = true;
            this.gdcWarehouseCode.VisibleIndex = 9;
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
            this.gdcCreateUser.VisibleIndex = 13;
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
            this.gdcCreateDate.VisibleIndex = 14;
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
            this.gdcUpdateUser.VisibleIndex = 15;
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
            this.gdcUpdateDate.VisibleIndex = 16;
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
            this.gdcWarehouseName.VisibleIndex = 10;
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
            this.gdcOwnerCode.VisibleIndex = 11;
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
            this.gdcOwnerName.VisibleIndex = 12;
            // 
            // frmADM010_UserMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 490);
            this.Controls.Add(this.groupControl2);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmADM010_UserMaintenance";
            this.Text = "frmADM010_UserMaintenance";
            this.Load += new System.EventHandler(this.frmADM010_UserMaintenance_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUserID;
        private DevExpress.XtraGrid.Columns.GridColumn gdcFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLastName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gdcTelephone;
        private DevExpress.XtraGrid.Columns.GridColumn gdcMobile;
        private DevExpress.XtraGrid.Columns.GridColumn gdcEmail;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLoginTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWarehouseCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcDomainName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWarehouseName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerName;
    }
}
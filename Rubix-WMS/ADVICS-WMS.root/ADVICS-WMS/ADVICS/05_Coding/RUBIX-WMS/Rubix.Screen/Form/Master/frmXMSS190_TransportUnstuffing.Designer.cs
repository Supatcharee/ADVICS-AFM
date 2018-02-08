namespace Rubix.Screen.Form.Master
{
    partial class frmXMSS190_TransportUnstuffing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXMSS190_TransportUnstuffing));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.customerControl = new Rubix.Control.CustomerControl();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcOwnerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcOwnerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcWarehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcWarehouseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcTruckCompanyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcTruckCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcEffectiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
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
            this.ribbonControl1.Size = new System.Drawing.Size(888, 47);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.customerControl);
            this.groupControl1.Controls.Add(this.warehouseControl);
            this.groupControl1.Controls.Add(this.ownerControl);
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 78);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(888, 107);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Search Criteria";
            // 
            // customerControl
            // 
            this.customerControl.ErrorText = "Customer Control is Require Field";
            this.customerControl.Location = new System.Drawing.Point(60, 50);
            this.customerControl.Name = "customerControl";
            this.customerControl.OwnerID = null;
            this.customerControl.ReadOnly = false;
            this.customerControl.RequireField = false;
            this.customerControl.Size = new System.Drawing.Size(435, 24);
            this.customerControl.TabIndex = 2;
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(48, 73);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(449, 21);
            this.warehouseControl.TabIndex = 3;
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(62, 28);
            this.ownerControl.Name = "ownerControl";
            this.ownerControl.ReadOnly = false;
            this.ownerControl.RequireField = false;
            this.ownerControl.Size = new System.Drawing.Size(433, 21);
            this.ownerControl.TabIndex = 1;
            this.ownerControl.EditValueChanged += new System.EventHandler(this.customerControl_EditValueChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(805, 72);
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
            this.btnSearch.Location = new System.Drawing.Point(724, 73);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 185);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(888, 312);
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
            this.grdSearchResult.Size = new System.Drawing.Size(876, 282);
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
            this.gdcWarehouseCode,
            this.gdcWarehouseName,
            this.gdcTruckCompanyCode,
            this.gdcTruckCompanyName,
            this.gdcEffectiveDate,
            this.gdcCreateUser,
            this.gdcCreateDate,
            this.gdcUpdateUser,
            this.gdcUpdateDate});
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
            this.gdcCustomerName.FieldNameSortGroup = "CustomerName";
            this.gdcCustomerName.Name = "gdcCustomerName";
            this.gdcCustomerName.Visible = true;
            this.gdcCustomerName.VisibleIndex = 3;
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
            this.gdcWarehouseCode.VisibleIndex = 4;
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
            this.gdcWarehouseName.VisibleIndex = 5;
            // 
            // gdcTruckCompanyCode
            // 
            this.gdcTruckCompanyCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcTruckCompanyCode.AppearanceHeader.Options.UseFont = true;
            this.gdcTruckCompanyCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcTruckCompanyCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcTruckCompanyCode.Caption = "TruckCompany Code";
            this.gdcTruckCompanyCode.FieldName = "TruckCompanyCode";
            this.gdcTruckCompanyCode.FieldNameSortGroup = "TruckCompanyCode";
            this.gdcTruckCompanyCode.Name = "gdcTruckCompanyCode";
            this.gdcTruckCompanyCode.Visible = true;
            this.gdcTruckCompanyCode.VisibleIndex = 6;
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
            this.gdcTruckCompanyName.VisibleIndex = 7;
            // 
            // gdcEffectiveDate
            // 
            this.gdcEffectiveDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcEffectiveDate.AppearanceHeader.Options.UseFont = true;
            this.gdcEffectiveDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcEffectiveDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcEffectiveDate.Caption = "Effective Date";
            this.gdcEffectiveDate.FieldName = "EffectiveDate";
            this.gdcEffectiveDate.FieldNameSortGroup = "EffectiveDate";
            this.gdcEffectiveDate.Name = "gdcEffectiveDate";
            this.gdcEffectiveDate.Visible = true;
            this.gdcEffectiveDate.VisibleIndex = 8;
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
            this.gdcCreateUser.VisibleIndex = 9;
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
            this.gdcUpdateUser.VisibleIndex = 11;
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
            // frmXMSS190_TransportUnstuffing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 497);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmXMSS190_TransportUnstuffing";
            this.Text = "XMSS190 : Transport & Unstuffing Charge Master";
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
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
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private Control.WarehouseControl warehouseControl;
        private Control.OwnerControl ownerControl;
        private Control.CustomerControl customerControl;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOwnerName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWarehouseCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWarehouseName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcTruckCompanyCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcTruckCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcEffectiveDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateDate;
    }
}
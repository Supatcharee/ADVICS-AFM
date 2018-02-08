namespace Rubix.Screen.Form.Master
{
    partial class frmXMSS120_Zone
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXMSS120_Zone));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.txtFloor = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtZoneName = new DevExpress.XtraEditors.TextEdit();
            this.txtZoneCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.spXMSS120ZoneSearchAllResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcZoneID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcDistributionCenterCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcFloor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcZoneCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcZoneName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcZoneType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcZoneColor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemColorEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.gdcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdclUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFloor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZoneName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZoneCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spXMSS120ZoneSearchAllResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Size = new System.Drawing.Size(891, 47);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.warehouseControl);
            this.groupControl1.Controls.Add(this.ownerControl);
            this.groupControl1.Controls.Add(this.txtFloor);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.txtZoneName);
            this.groupControl1.Controls.Add(this.txtZoneCode);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 78);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(891, 104);
            this.groupControl1.TabIndex = 21;
            this.groupControl1.Text = "Search Criteria";
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(45, 31);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(472, 21);
            this.warehouseControl.TabIndex = 1;
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(739, 47);
            this.ownerControl.Name = "ownerControl";
            this.ownerControl.ReadOnly = false;
            this.ownerControl.RequireField = false;
            this.ownerControl.Size = new System.Drawing.Size(124, 21);
            this.ownerControl.TabIndex = 1;
            this.ownerControl.Visible = false;
            this.ownerControl.EditValueChanged += new System.EventHandler(this.customerControl_EditValueChanged);
            this.ownerControl.Enter += new System.EventHandler(this.customerControl_Enter);
            this.ownerControl.Leave += new System.EventHandler(this.customerControl_Leave);
            // 
            // txtFloor
            // 
            this.txtFloor.Location = new System.Drawing.Point(798, 21);
            this.txtFloor.MenuManager = this.ribbonControl1;
            this.txtFloor.Name = "txtFloor";
            this.txtFloor.Properties.Appearance.Options.UseTextOptions = true;
            this.txtFloor.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtFloor.Properties.Mask.EditMask = "d";
            this.txtFloor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtFloor.Size = new System.Drawing.Size(65, 20);
            this.txtFloor.TabIndex = 4;
            this.txtFloor.Visible = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(761, 28);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Floor";
            this.labelControl3.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(807, 74);
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
            this.btnSearch.Location = new System.Drawing.Point(726, 73);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtZoneName
            // 
            this.txtZoneName.Location = new System.Drawing.Point(119, 77);
            this.txtZoneName.MenuManager = this.ribbonControl1;
            this.txtZoneName.Name = "txtZoneName";
            this.txtZoneName.Properties.MaxLength = 20;
            this.txtZoneName.Size = new System.Drawing.Size(395, 20);
            this.txtZoneName.TabIndex = 3;
            // 
            // txtZoneCode
            // 
            this.txtZoneCode.Location = new System.Drawing.Point(119, 55);
            this.txtZoneCode.MenuManager = this.ribbonControl1;
            this.txtZoneCode.Name = "txtZoneCode";
            this.txtZoneCode.Properties.MaxLength = 2;
            this.txtZoneCode.Size = new System.Drawing.Size(123, 20);
            this.txtZoneCode.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(5, 80);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(103, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Zone Name";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(7, 58);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(101, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Zone Code";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 182);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(891, 314);
            this.groupControl2.TabIndex = 8;
            this.groupControl2.Text = "Search Result";
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSearchResult.DataSource = this.spXMSS120ZoneSearchAllResultBindingSource;
            this.grdSearchResult.Location = new System.Drawing.Point(6, 24);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.MenuManager = this.ribbonControl1;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemColorEdit1});
            this.grdSearchResult.Size = new System.Drawing.Size(879, 284);
            this.grdSearchResult.TabIndex = 9;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // spXMSS120ZoneSearchAllResultBindingSource
            // 
            this.spXMSS120ZoneSearchAllResultBindingSource.DataSource = typeof(CSI.Business.DataObjects.sp_XMSS120_Zone_SearchAll_Result);
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcZoneID,
            this.gdcDistributionCenterCode,
            this.gdcFloor,
            this.gdcZoneCode,
            this.gdcZoneName,
            this.gdcZoneType,
            this.gdcZoneColor,
            this.gdcCreateDate,
            this.gdcCreateUser,
            this.gdclUpdateDate,
            this.gdcUpdateUser});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            // 
            // gdcZoneID
            // 
            this.gdcZoneID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcZoneID.AppearanceHeader.Options.UseFont = true;
            this.gdcZoneID.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcZoneID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcZoneID.FieldName = "ZoneID";
            this.gdcZoneID.Name = "gdcZoneID";
            // 
            // gdcDistributionCenterCode
            // 
            this.gdcDistributionCenterCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcDistributionCenterCode.AppearanceHeader.Options.UseFont = true;
            this.gdcDistributionCenterCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcDistributionCenterCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcDistributionCenterCode.Caption = "Warehouse Code";
            this.gdcDistributionCenterCode.FieldName = "WarehouseCode";
            this.gdcDistributionCenterCode.Name = "gdcDistributionCenterCode";
            this.gdcDistributionCenterCode.Visible = true;
            this.gdcDistributionCenterCode.VisibleIndex = 0;
            this.gdcDistributionCenterCode.Width = 110;
            // 
            // gdcFloor
            // 
            this.gdcFloor.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcFloor.AppearanceHeader.Options.UseFont = true;
            this.gdcFloor.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcFloor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcFloor.FieldName = "Floor";
            this.gdcFloor.Name = "gdcFloor";
            this.gdcFloor.OptionsColumn.ShowInCustomizationForm = false;
            this.gdcFloor.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // gdcZoneCode
            // 
            this.gdcZoneCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcZoneCode.AppearanceHeader.Options.UseFont = true;
            this.gdcZoneCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcZoneCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcZoneCode.Caption = "Zone Code";
            this.gdcZoneCode.FieldName = "ZoneCode";
            this.gdcZoneCode.FieldNameSortGroup = "ZoneCode";
            this.gdcZoneCode.Name = "gdcZoneCode";
            this.gdcZoneCode.Visible = true;
            this.gdcZoneCode.VisibleIndex = 1;
            // 
            // gdcZoneName
            // 
            this.gdcZoneName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcZoneName.AppearanceHeader.Options.UseFont = true;
            this.gdcZoneName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcZoneName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcZoneName.Caption = "Zone Name";
            this.gdcZoneName.FieldName = "ZoneName";
            this.gdcZoneName.FieldNameSortGroup = "ZoneName";
            this.gdcZoneName.Name = "gdcZoneName";
            this.gdcZoneName.Visible = true;
            this.gdcZoneName.VisibleIndex = 2;
            // 
            // gdcZoneType
            // 
            this.gdcZoneType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcZoneType.AppearanceHeader.Options.UseFont = true;
            this.gdcZoneType.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcZoneType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcZoneType.Caption = "Zone Type";
            this.gdcZoneType.FieldName = "ZoneTypeName";
            this.gdcZoneType.FieldNameSortGroup = "ZoneTypeName";
            this.gdcZoneType.Name = "gdcZoneType";
            this.gdcZoneType.Visible = true;
            this.gdcZoneType.VisibleIndex = 3;
            // 
            // gdcZoneColor
            // 
            this.gdcZoneColor.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcZoneColor.AppearanceHeader.Options.UseFont = true;
            this.gdcZoneColor.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcZoneColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcZoneColor.Caption = "Zone Color";
            this.gdcZoneColor.ColumnEdit = this.repositoryItemColorEdit1;
            this.gdcZoneColor.FieldName = "ZoneColor";
            this.gdcZoneColor.FieldNameSortGroup = "ZoneColor";
            this.gdcZoneColor.Name = "gdcZoneColor";
            this.gdcZoneColor.Visible = true;
            this.gdcZoneColor.VisibleIndex = 4;
            // 
            // repositoryItemColorEdit1
            // 
            this.repositoryItemColorEdit1.AutoHeight = false;
            this.repositoryItemColorEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemColorEdit1.Name = "repositoryItemColorEdit1";
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
            this.gdcCreateDate.VisibleIndex = 5;
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
            this.gdcCreateUser.VisibleIndex = 6;
            // 
            // gdclUpdateDate
            // 
            this.gdclUpdateDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdclUpdateDate.AppearanceHeader.Options.UseFont = true;
            this.gdclUpdateDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdclUpdateDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdclUpdateDate.Caption = "Update Date";
            this.gdclUpdateDate.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            this.gdclUpdateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdclUpdateDate.FieldName = "UpdateDate";
            this.gdclUpdateDate.FieldNameSortGroup = "UpdateDate";
            this.gdclUpdateDate.Name = "gdclUpdateDate";
            this.gdclUpdateDate.Visible = true;
            this.gdclUpdateDate.VisibleIndex = 7;
            this.gdclUpdateDate.Width = 94;
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
            this.gdcUpdateUser.VisibleIndex = 8;
            this.gdcUpdateUser.Width = 86;
            // 
            // frmXMSS120_Zone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 496);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmXMSS120_Zone";
            this.Text = "XMSS120 : Zone Master";
            this.Load += new System.EventHandler(this.frmXMSS120_Zone_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFloor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZoneName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZoneCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spXMSS120ZoneSearchAllResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemColorEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TextEdit txtZoneName;
        private DevExpress.XtraEditors.TextEdit txtZoneCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraEditors.TextEdit txtFloor;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private Control.WarehouseControl warehouseControl;
        private System.Windows.Forms.BindingSource spXMSS120ZoneSearchAllResultBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn gdcZoneID;
        private DevExpress.XtraGrid.Columns.GridColumn gdcDistributionCenterCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcFloor;
        private DevExpress.XtraGrid.Columns.GridColumn gdcZoneCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcZoneName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcZoneColor;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdclUpdateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateUser;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit repositoryItemColorEdit1;
        private Control.OwnerControl ownerControl;
        private DevExpress.XtraGrid.Columns.GridColumn gdcZoneType;

    }
}
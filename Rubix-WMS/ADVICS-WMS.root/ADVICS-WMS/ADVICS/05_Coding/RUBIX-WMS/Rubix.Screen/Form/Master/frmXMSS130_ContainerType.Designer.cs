namespace Rubix.Screen.Form.Master
{
    partial class frmXMSS130_ContainerType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXMSS130_ContainerType));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtContainerSizeName = new DevExpress.XtraEditors.TextEdit();
            this.txtContainerSizeCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcTransportTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcTransportTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcWidth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcHeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcMaxM3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcContainerWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcMaxPallet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLGL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUpdateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtContainerSizeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContainerSizeCode.Properties)).BeginInit();
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
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.txtContainerSizeName);
            this.groupControl1.Controls.Add(this.txtContainerSizeCode);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 78);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(888, 79);
            this.groupControl1.TabIndex = 23;
            this.groupControl1.Text = "Search Criteria";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(805, 50);
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
            this.btnSearch.Location = new System.Drawing.Point(724, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtContainerSizeName
            // 
            this.txtContainerSizeName.Location = new System.Drawing.Point(127, 52);
            this.txtContainerSizeName.MenuManager = this.ribbonControl1;
            this.txtContainerSizeName.Name = "txtContainerSizeName";
            this.txtContainerSizeName.Size = new System.Drawing.Size(395, 20);
            this.txtContainerSizeName.TabIndex = 2;
            // 
            // txtContainerSizeCode
            // 
            this.txtContainerSizeCode.Location = new System.Drawing.Point(127, 29);
            this.txtContainerSizeCode.MenuManager = this.ribbonControl1;
            this.txtContainerSizeCode.Name = "txtContainerSizeCode";
            this.txtContainerSizeCode.Size = new System.Drawing.Size(123, 20);
            this.txtContainerSizeCode.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(15, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(104, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Container Type Name";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(17, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(102, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Container Type Code";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 157);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(888, 337);
            this.groupControl2.TabIndex = 22;
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
            this.grdSearchResult.Size = new System.Drawing.Size(876, 307);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcTransportTypeCode,
            this.gdcTransportTypeName,
            this.gdcWidth,
            this.gdcLength,
            this.gdcHeight,
            this.gdcMaxM3,
            this.gdcContainerWeight,
            this.gdcMaxPallet,
            this.gdcLGL,
            this.gdcRemark,
            this.gdcCreateUser,
            this.gdcCreateDate,
            this.gdcUpdateUser,
            this.gdcUpdateDate});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            // 
            // gdcTransportTypeCode
            // 
            this.gdcTransportTypeCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcTransportTypeCode.AppearanceHeader.Options.UseFont = true;
            this.gdcTransportTypeCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcTransportTypeCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcTransportTypeCode.Caption = "Transport Type Code";
            this.gdcTransportTypeCode.FieldName = "TransportTypeCode";
            this.gdcTransportTypeCode.FieldNameSortGroup = "TransportTypeCode";
            this.gdcTransportTypeCode.Name = "gdcTransportTypeCode";
            this.gdcTransportTypeCode.Visible = true;
            this.gdcTransportTypeCode.VisibleIndex = 0;
            // 
            // gdcTransportTypeName
            // 
            this.gdcTransportTypeName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcTransportTypeName.AppearanceHeader.Options.UseFont = true;
            this.gdcTransportTypeName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcTransportTypeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcTransportTypeName.Caption = "Transport Type Name";
            this.gdcTransportTypeName.FieldName = "TransportTypeName";
            this.gdcTransportTypeName.FieldNameSortGroup = "TransportTypeName";
            this.gdcTransportTypeName.Name = "gdcTransportTypeName";
            this.gdcTransportTypeName.Visible = true;
            this.gdcTransportTypeName.VisibleIndex = 1;
            // 
            // gdcWidth
            // 
            this.gdcWidth.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcWidth.AppearanceHeader.Options.UseFont = true;
            this.gdcWidth.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcWidth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcWidth.Caption = "Width (m)";
            this.gdcWidth.DisplayFormat.FormatString = "n4";
            this.gdcWidth.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcWidth.FieldName = "Width";
            this.gdcWidth.FieldNameSortGroup = "Width";
            this.gdcWidth.Name = "gdcWidth";
            this.gdcWidth.Visible = true;
            this.gdcWidth.VisibleIndex = 2;
            // 
            // gdcLength
            // 
            this.gdcLength.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcLength.AppearanceHeader.Options.UseFont = true;
            this.gdcLength.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcLength.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcLength.Caption = "Length (m)";
            this.gdcLength.DisplayFormat.FormatString = "n4";
            this.gdcLength.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcLength.FieldName = "Length";
            this.gdcLength.FieldNameSortGroup = "Length";
            this.gdcLength.Name = "gdcLength";
            this.gdcLength.Visible = true;
            this.gdcLength.VisibleIndex = 3;
            // 
            // gdcHeight
            // 
            this.gdcHeight.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcHeight.AppearanceHeader.Options.UseFont = true;
            this.gdcHeight.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcHeight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcHeight.Caption = "Height (m)";
            this.gdcHeight.DisplayFormat.FormatString = "n4";
            this.gdcHeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcHeight.FieldName = "Height";
            this.gdcHeight.FieldNameSortGroup = "Height";
            this.gdcHeight.Name = "gdcHeight";
            this.gdcHeight.Visible = true;
            this.gdcHeight.VisibleIndex = 4;
            // 
            // gdcMaxM3
            // 
            this.gdcMaxM3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcMaxM3.AppearanceHeader.Options.UseFont = true;
            this.gdcMaxM3.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcMaxM3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcMaxM3.Caption = "MaxM3";
            this.gdcMaxM3.FieldName = "MaxM3";
            this.gdcMaxM3.FieldNameSortGroup = "MaxM3";
            this.gdcMaxM3.Name = "gdcMaxM3";
            this.gdcMaxM3.Visible = true;
            this.gdcMaxM3.VisibleIndex = 5;
            // 
            // gdcContainerWeight
            // 
            this.gdcContainerWeight.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcContainerWeight.AppearanceHeader.Options.UseFont = true;
            this.gdcContainerWeight.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcContainerWeight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcContainerWeight.Caption = "Max Container Weight (Kgs.)";
            this.gdcContainerWeight.DisplayFormat.FormatString = "n4";
            this.gdcContainerWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcContainerWeight.FieldName = "ContainerWeight";
            this.gdcContainerWeight.FieldNameSortGroup = "ContainerWeight";
            this.gdcContainerWeight.Name = "gdcContainerWeight";
            this.gdcContainerWeight.Visible = true;
            this.gdcContainerWeight.VisibleIndex = 6;
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
            this.gdcMaxPallet.VisibleIndex = 7;
            // 
            // gdcLGL
            // 
            this.gdcLGL.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcLGL.AppearanceHeader.Options.UseFont = true;
            this.gdcLGL.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcLGL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcLGL.Caption = "LGL";
            this.gdcLGL.FieldName = "LGL";
            this.gdcLGL.FieldNameSortGroup = "LGL";
            this.gdcLGL.Name = "gdcLGL";
            this.gdcLGL.Visible = true;
            this.gdcLGL.VisibleIndex = 8;
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
            this.gdcRemark.VisibleIndex = 9;
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
            this.gdcCreateUser.VisibleIndex = 10;
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
            this.gdcCreateDate.VisibleIndex = 11;
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
            this.gdcUpdateUser.VisibleIndex = 12;
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
            this.gdcUpdateDate.VisibleIndex = 13;
            // 
            // frmXMSS130_ContainerType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 494);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmXMSS130_ContainerType";
            this.Text = "XMSS130 : Container Type Master";
            this.Load += new System.EventHandler(this.frmXMSS130_ContainerSize_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtContainerSizeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContainerSizeCode.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txtContainerSizeName;
        private DevExpress.XtraEditors.TextEdit txtContainerSizeCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraGrid.Columns.GridColumn gdcTransportTypeCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcTransportTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWidth;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLength;
        private DevExpress.XtraGrid.Columns.GridColumn gdcHeight;
        private DevExpress.XtraGrid.Columns.GridColumn gdcMaxM3;
        private DevExpress.XtraGrid.Columns.GridColumn gdcContainerWeight;
        private DevExpress.XtraGrid.Columns.GridColumn gdcMaxPallet;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLGL;
        private DevExpress.XtraGrid.Columns.GridColumn gdcRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateUser;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUpdateDate;
    }
}
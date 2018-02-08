namespace Rubix.Screen.Form.Admin.Dialog
{
    partial class dlgADM020_UserGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgADM020_UserGroup));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cboUser = new Rubix.Control.UserInfoControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.grdUser = new DevExpress.XtraGrid.GridControl();
            this.gdvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcFirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcLastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcTelephone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcMobile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtDesc = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtGroupName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Controls.Add(this.txtDesc);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtGroupName);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(6, 36);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(829, 428);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "User Group Information";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.cboUser);
            this.groupControl2.Controls.Add(this.btnDelete);
            this.groupControl2.Controls.Add(this.btnAdd);
            this.groupControl2.Controls.Add(this.grdUser);
            this.groupControl2.Location = new System.Drawing.Point(30, 96);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(791, 325);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Group Member";
            // 
            // cboUser
            // 
            this.cboUser.Location = new System.Drawing.Point(16, 29);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(464, 21);
            this.cboUser.TabIndex = 9;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(688, 29);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 24);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete User";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(588, 29);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 24);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add User";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grdUser
            // 
            this.grdUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUser.Location = new System.Drawing.Point(81, 59);
            this.grdUser.MainView = this.gdvUser;
            this.grdUser.Name = "grdUser";
            this.grdUser.Size = new System.Drawing.Size(704, 260);
            this.grdUser.TabIndex = 6;
            this.grdUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvUser});
            // 
            // gdvUser
            // 
            this.gdvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcUserID,
            this.grcFirstName,
            this.grcLastName,
            this.grcAddress,
            this.grcEmail,
            this.grcTelephone,
            this.grcMobile});
            this.gdvUser.GridControl = this.grdUser;
            this.gdvUser.Name = "gdvUser";
            this.gdvUser.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gdvUser.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gdvUser.OptionsBehavior.Editable = false;
            this.gdvUser.OptionsCustomization.AllowGroup = false;
            this.gdvUser.OptionsView.ShowGroupPanel = false;
            // 
            // grcUserID
            // 
            this.grcUserID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcUserID.AppearanceHeader.Options.UseFont = true;
            this.grcUserID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcUserID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcUserID.Caption = "User ID";
            this.grcUserID.FieldName = "UserID";
            this.grcUserID.Name = "grcUserID";
            this.grcUserID.Visible = true;
            this.grcUserID.VisibleIndex = 0;
            // 
            // grcFirstName
            // 
            this.grcFirstName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcFirstName.AppearanceHeader.Options.UseFont = true;
            this.grcFirstName.AppearanceHeader.Options.UseTextOptions = true;
            this.grcFirstName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcFirstName.Caption = "First Name";
            this.grcFirstName.FieldName = "FirstName";
            this.grcFirstName.Name = "grcFirstName";
            this.grcFirstName.Visible = true;
            this.grcFirstName.VisibleIndex = 1;
            // 
            // grcLastName
            // 
            this.grcLastName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcLastName.AppearanceHeader.Options.UseFont = true;
            this.grcLastName.AppearanceHeader.Options.UseTextOptions = true;
            this.grcLastName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcLastName.Caption = "Last Name";
            this.grcLastName.FieldName = "LastName";
            this.grcLastName.Name = "grcLastName";
            this.grcLastName.Visible = true;
            this.grcLastName.VisibleIndex = 2;
            // 
            // grcAddress
            // 
            this.grcAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcAddress.AppearanceHeader.Options.UseFont = true;
            this.grcAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.grcAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcAddress.Caption = "Address";
            this.grcAddress.FieldName = "Address";
            this.grcAddress.Name = "grcAddress";
            this.grcAddress.Visible = true;
            this.grcAddress.VisibleIndex = 3;
            // 
            // grcEmail
            // 
            this.grcEmail.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcEmail.AppearanceHeader.Options.UseFont = true;
            this.grcEmail.AppearanceHeader.Options.UseTextOptions = true;
            this.grcEmail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcEmail.Caption = "Email";
            this.grcEmail.FieldName = "Email";
            this.grcEmail.Name = "grcEmail";
            this.grcEmail.Visible = true;
            this.grcEmail.VisibleIndex = 4;
            // 
            // grcTelephone
            // 
            this.grcTelephone.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcTelephone.AppearanceHeader.Options.UseFont = true;
            this.grcTelephone.AppearanceHeader.Options.UseTextOptions = true;
            this.grcTelephone.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcTelephone.Caption = "Telephone";
            this.grcTelephone.FieldName = "Telephone";
            this.grcTelephone.Name = "grcTelephone";
            this.grcTelephone.Visible = true;
            this.grcTelephone.VisibleIndex = 5;
            // 
            // grcMobile
            // 
            this.grcMobile.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcMobile.AppearanceHeader.Options.UseFont = true;
            this.grcMobile.AppearanceHeader.Options.UseTextOptions = true;
            this.grcMobile.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcMobile.Caption = "Mobile";
            this.grcMobile.FieldName = "Mobile";
            this.grcMobile.Name = "grcMobile";
            this.grcMobile.Visible = true;
            this.grcMobile.VisibleIndex = 6;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(96, 55);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Properties.MaxLength = 100;
            this.txtDesc.Size = new System.Drawing.Size(359, 20);
            this.txtDesc.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(4, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Description";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(96, 31);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Properties.MaxLength = 20;
            this.txtGroupName.Size = new System.Drawing.Size(359, 20);
            this.txtGroupName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(4, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(86, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Group Name";
            // 
            // dlgADM020_UserGroup
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 501);
            this.Controls.Add(this.groupControl1);
            this.Name = "dlgADM020_UserGroup";
            this.Text = "ADM020: User Group Dialog";
            this.Load += new System.EventHandler(this.dlgADM020_UserGroup_Load);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGroupName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtDesc;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtGroupName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvUser;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private Control.UserInfoControl cboUser;
        private DevExpress.XtraGrid.Columns.GridColumn grcUserID;
        private DevExpress.XtraGrid.Columns.GridColumn grcFirstName;
        private DevExpress.XtraGrid.Columns.GridColumn grcLastName;
        private DevExpress.XtraGrid.Columns.GridColumn grcAddress;
        private DevExpress.XtraGrid.Columns.GridColumn grcEmail;
        private DevExpress.XtraGrid.Columns.GridColumn grcTelephone;
        private DevExpress.XtraGrid.Columns.GridColumn grcMobile;
    }
}
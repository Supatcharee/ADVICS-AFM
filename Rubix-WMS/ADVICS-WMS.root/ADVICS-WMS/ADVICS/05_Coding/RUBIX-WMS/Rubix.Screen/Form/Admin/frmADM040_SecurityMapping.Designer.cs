namespace Rubix.Screen.Form.Admin
{
    partial class frmADM040_SecurityMapping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmADM040_SecurityMapping));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabUser = new DevExpress.XtraTab.XtraTabPage();
            this.gpcBelongGroup = new DevExpress.XtraEditors.GroupControl();
            this.trlBelongGroup = new DevExpress.XtraTreeList.TreeList();
            this.tlcBelongGroup = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imgList = new System.Windows.Forms.ImageList();
            this.trlUser = new DevExpress.XtraTreeList.TreeList();
            this.tlcUserName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trlUserID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trlFirstLastName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tabGroup = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.trlMember = new DevExpress.XtraTreeList.TreeList();
            this.tlcMember = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trlUserGroup = new DevExpress.XtraTreeList.TreeList();
            this.tlcUserGroup = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trlGroupID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trlGroupName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tabScreen = new DevExpress.XtraTab.XtraTabPage();
            this.trlScreen = new DevExpress.XtraTreeList.TreeList();
            this.tlcScreen = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcKey = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcDisplayName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlcClassName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.gpcSecurity = new DevExpress.XtraEditors.GroupControl();
            this.trlSecurity = new DevExpress.XtraTreeList.TreeList();
            this.trlPermission = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trlPermUserID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trlPermGroupID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trlPermScreenID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpcBelongGroup)).BeginInit();
            this.gpcBelongGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlBelongGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlUser)).BeginInit();
            this.tabGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlUserGroup)).BeginInit();
            this.tabScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcSecurity)).BeginInit();
            this.gpcSecurity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trlSecurity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Size = new System.Drawing.Size(870, 47);
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelControl1.Controls.Add(this.xtraTabControl1);
            this.panelControl1.Location = new System.Drawing.Point(5, 35);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(396, 519);
            this.panelControl1.TabIndex = 29;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.xtraTabControl1.Location = new System.Drawing.Point(7, 5);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabUser;
            this.xtraTabControl1.Size = new System.Drawing.Size(386, 514);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabUser,
            this.tabGroup,
            this.tabScreen});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.gpcBelongGroup);
            this.tabUser.Controls.Add(this.trlUser);
            this.tabUser.Image = ((System.Drawing.Image)(resources.GetObject("tabUser.Image")));
            this.tabUser.Name = "tabUser";
            this.tabUser.Size = new System.Drawing.Size(380, 475);
            this.tabUser.Text = "User";
            // 
            // gpcBelongGroup
            // 
            this.gpcBelongGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gpcBelongGroup.Controls.Add(this.trlBelongGroup);
            this.gpcBelongGroup.Location = new System.Drawing.Point(3, 378);
            this.gpcBelongGroup.Name = "gpcBelongGroup";
            this.gpcBelongGroup.Size = new System.Drawing.Size(373, 93);
            this.gpcBelongGroup.TabIndex = 2;
            this.gpcBelongGroup.Text = "Belong to group";
            // 
            // trlBelongGroup
            // 
            this.trlBelongGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trlBelongGroup.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcBelongGroup});
            this.trlBelongGroup.Location = new System.Drawing.Point(5, 25);
            this.trlBelongGroup.Name = "trlBelongGroup";
            this.trlBelongGroup.OptionsBehavior.Editable = false;
            this.trlBelongGroup.OptionsView.ShowHorzLines = false;
            this.trlBelongGroup.OptionsView.ShowIndicator = false;
            this.trlBelongGroup.OptionsView.ShowRoot = false;
            this.trlBelongGroup.OptionsView.ShowVertLines = false;
            this.trlBelongGroup.SelectImageList = this.imgList;
            this.trlBelongGroup.Size = new System.Drawing.Size(362, 62);
            this.trlBelongGroup.TabIndex = 0;
            // 
            // tlcBelongGroup
            // 
            this.tlcBelongGroup.Caption = "Name";
            this.tlcBelongGroup.FieldName = "Name";
            this.tlcBelongGroup.MinWidth = 33;
            this.tlcBelongGroup.Name = "tlcBelongGroup";
            this.tlcBelongGroup.Visible = true;
            this.tlcBelongGroup.VisibleIndex = 0;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "screen.png");
            this.imgList.Images.SetKeyName(1, "computer.png");
            this.imgList.Images.SetKeyName(2, "user1.png");
            this.imgList.Images.SetKeyName(3, "user2.png");
            this.imgList.Images.SetKeyName(4, "emblem-people.png");
            this.imgList.Images.SetKeyName(5, "group_permission.png");
            this.imgList.Images.SetKeyName(6, "1327374351_edit_group.png");
            this.imgList.Images.SetKeyName(7, "screen1.png");
            this.imgList.Images.SetKeyName(8, "screen2.png");
            this.imgList.Images.SetKeyName(9, "screen3.png");
            this.imgList.Images.SetKeyName(10, "screen4.png");
            this.imgList.Images.SetKeyName(11, "screen5.png");
            this.imgList.Images.SetKeyName(12, "screen6.png");
            this.imgList.Images.SetKeyName(13, "Check-icon.png");
            // 
            // trlUser
            // 
            this.trlUser.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcUserName,
            this.trlUserID,
            this.trlFirstLastName});
            this.trlUser.Location = new System.Drawing.Point(3, 4);
            this.trlUser.Name = "trlUser";
            this.trlUser.OptionsView.ShowHorzLines = false;
            this.trlUser.OptionsView.ShowIndicator = false;
            this.trlUser.OptionsView.ShowRoot = false;
            this.trlUser.OptionsView.ShowVertLines = false;
            this.trlUser.SelectImageList = this.imgList;
            this.trlUser.Size = new System.Drawing.Size(373, 369);
            this.trlUser.TabIndex = 0;
            this.trlUser.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.trlUser_FocusedNodeChanged);
            // 
            // tlcUserName
            // 
            this.tlcUserName.Caption = "Name";
            this.tlcUserName.FieldName = "Name";
            this.tlcUserName.MinWidth = 33;
            this.tlcUserName.Name = "tlcUserName";
            this.tlcUserName.OptionsColumn.AllowEdit = false;
            this.tlcUserName.OptionsColumn.AllowMove = false;
            this.tlcUserName.OptionsColumn.AllowSort = false;
            this.tlcUserName.Visible = true;
            this.tlcUserName.VisibleIndex = 0;
            // 
            // trlUserID
            // 
            this.trlUserID.Caption = "trlUserID";
            this.trlUserID.FieldName = "trlUserID";
            this.trlUserID.Name = "trlUserID";
            this.trlUserID.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            // 
            // trlFirstLastName
            // 
            this.trlFirstLastName.Caption = "trlFirstLastName";
            this.trlFirstLastName.FieldName = "trlFirstLastName";
            this.trlFirstLastName.Name = "trlFirstLastName";
            // 
            // tabGroup
            // 
            this.tabGroup.Controls.Add(this.groupControl1);
            this.tabGroup.Controls.Add(this.trlUserGroup);
            this.tabGroup.Image = ((System.Drawing.Image)(resources.GetObject("tabGroup.Image")));
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Size = new System.Drawing.Size(380, 475);
            this.tabGroup.Text = "User Group";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl1.Controls.Add(this.trlMember);
            this.groupControl1.Location = new System.Drawing.Point(3, 378);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(373, 93);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Member (s)";
            // 
            // trlMember
            // 
            this.trlMember.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trlMember.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcMember});
            this.trlMember.Location = new System.Drawing.Point(5, 25);
            this.trlMember.Name = "trlMember";
            this.trlMember.OptionsBehavior.Editable = false;
            this.trlMember.OptionsView.ShowHorzLines = false;
            this.trlMember.OptionsView.ShowIndicator = false;
            this.trlMember.OptionsView.ShowRoot = false;
            this.trlMember.OptionsView.ShowVertLines = false;
            this.trlMember.SelectImageList = this.imgList;
            this.trlMember.Size = new System.Drawing.Size(362, 62);
            this.trlMember.TabIndex = 0;
            // 
            // tlcMember
            // 
            this.tlcMember.Caption = "Name";
            this.tlcMember.FieldName = "Name";
            this.tlcMember.MinWidth = 33;
            this.tlcMember.Name = "tlcMember";
            this.tlcMember.Visible = true;
            this.tlcMember.VisibleIndex = 0;
            // 
            // trlUserGroup
            // 
            this.trlUserGroup.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcUserGroup,
            this.trlGroupID,
            this.trlGroupName});
            this.trlUserGroup.Location = new System.Drawing.Point(3, 4);
            this.trlUserGroup.Name = "trlUserGroup";
            this.trlUserGroup.OptionsBehavior.Editable = false;
            this.trlUserGroup.OptionsView.ShowHorzLines = false;
            this.trlUserGroup.OptionsView.ShowIndicator = false;
            this.trlUserGroup.OptionsView.ShowRoot = false;
            this.trlUserGroup.OptionsView.ShowVertLines = false;
            this.trlUserGroup.SelectImageList = this.imgList;
            this.trlUserGroup.Size = new System.Drawing.Size(373, 369);
            this.trlUserGroup.TabIndex = 0;
            this.trlUserGroup.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.trlUserGroup_FocusedNodeChanged);
            // 
            // tlcUserGroup
            // 
            this.tlcUserGroup.Caption = "Name";
            this.tlcUserGroup.FieldName = "Name";
            this.tlcUserGroup.MinWidth = 33;
            this.tlcUserGroup.Name = "tlcUserGroup";
            this.tlcUserGroup.Visible = true;
            this.tlcUserGroup.VisibleIndex = 0;
            // 
            // trlGroupID
            // 
            this.trlGroupID.Caption = "trlGroupID";
            this.trlGroupID.FieldName = "trlGroupID";
            this.trlGroupID.Name = "trlGroupID";
            this.trlGroupID.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Integer;
            // 
            // trlGroupName
            // 
            this.trlGroupName.Caption = "trlGroupName";
            this.trlGroupName.FieldName = "trlGroupName";
            this.trlGroupName.Name = "trlGroupName";
            // 
            // tabScreen
            // 
            this.tabScreen.Controls.Add(this.trlScreen);
            this.tabScreen.Image = ((System.Drawing.Image)(resources.GetObject("tabScreen.Image")));
            this.tabScreen.Name = "tabScreen";
            this.tabScreen.Size = new System.Drawing.Size(380, 475);
            this.tabScreen.Text = "Screen";
            // 
            // trlScreen
            // 
            this.trlScreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trlScreen.BestFitVisibleOnly = true;
            this.trlScreen.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcScreen,
            this.tlcKey,
            this.tlcDisplayName,
            this.tlcClassName});
            this.trlScreen.Location = new System.Drawing.Point(4, 5);
            this.trlScreen.Name = "trlScreen";
            this.trlScreen.OptionsBehavior.Editable = false;
            this.trlScreen.OptionsLayout.AddNewColumns = false;
            this.trlScreen.OptionsMenu.EnableColumnMenu = false;
            this.trlScreen.OptionsMenu.EnableFooterMenu = false;
            this.trlScreen.OptionsMenu.ShowAutoFilterRowItem = false;
            this.trlScreen.OptionsView.AutoWidth = false;
            this.trlScreen.OptionsView.ShowHorzLines = false;
            this.trlScreen.OptionsView.ShowIndicator = false;
            this.trlScreen.OptionsView.ShowVertLines = false;
            this.trlScreen.SelectImageList = this.imgList;
            this.trlScreen.Size = new System.Drawing.Size(373, 466);
            this.trlScreen.TabIndex = 1;
            this.trlScreen.AfterExpand += new DevExpress.XtraTreeList.NodeEventHandler(this.trlScreen_AfterExpand);
            this.trlScreen.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.trlScreen_FocusedNodeChanged);
            // 
            // tlcScreen
            // 
            this.tlcScreen.Caption = "Name";
            this.tlcScreen.FieldName = "Display";
            this.tlcScreen.MinWidth = 33;
            this.tlcScreen.Name = "tlcScreen";
            this.tlcScreen.OptionsColumn.AllowEdit = false;
            this.tlcScreen.OptionsColumn.AllowMove = false;
            this.tlcScreen.OptionsColumn.AllowSort = false;
            this.tlcScreen.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            this.tlcScreen.Visible = true;
            this.tlcScreen.VisibleIndex = 0;
            this.tlcScreen.Width = 371;
            // 
            // tlcKey
            // 
            this.tlcKey.Caption = "Key";
            this.tlcKey.FieldName = "ID";
            this.tlcKey.Name = "tlcKey";
            this.tlcKey.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.Integer;
            // 
            // tlcDisplayName
            // 
            this.tlcDisplayName.Caption = "DisplayName";
            this.tlcDisplayName.FieldName = "DisplayName";
            this.tlcDisplayName.Name = "tlcDisplayName";
            this.tlcDisplayName.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            // 
            // tlcClassName
            // 
            this.tlcClassName.Caption = "Class";
            this.tlcClassName.FieldName = "Class";
            this.tlcClassName.Name = "tlcClassName";
            this.tlcClassName.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            // 
            // gpcSecurity
            // 
            this.gpcSecurity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpcSecurity.Controls.Add(this.trlSecurity);
            this.gpcSecurity.Location = new System.Drawing.Point(407, 35);
            this.gpcSecurity.Name = "gpcSecurity";
            this.gpcSecurity.Size = new System.Drawing.Size(457, 519);
            this.gpcSecurity.TabIndex = 30;
            this.gpcSecurity.Text = "Security mapping for user \"Admin\"";
            // 
            // trlSecurity
            // 
            this.trlSecurity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trlSecurity.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.trlSecurity.Appearance.FocusedCell.BorderColor = System.Drawing.Color.Red;
            this.trlSecurity.Appearance.FocusedCell.Options.UseBackColor = true;
            this.trlSecurity.Appearance.FocusedCell.Options.UseBorderColor = true;
            this.trlSecurity.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.trlSecurity.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Red;
            this.trlSecurity.Appearance.FocusedRow.Options.UseBackColor = true;
            this.trlSecurity.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.trlSecurity.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.trlSecurity.Appearance.SelectedRow.BorderColor = System.Drawing.Color.Red;
            this.trlSecurity.Appearance.SelectedRow.Options.UseBackColor = true;
            this.trlSecurity.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.trlSecurity.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.trlPermission,
            this.trlPermUserID,
            this.trlPermGroupID,
            this.trlPermScreenID});
            this.trlSecurity.Location = new System.Drawing.Point(5, 24);
            this.trlSecurity.Name = "trlSecurity";
            this.trlSecurity.OptionsBehavior.Editable = false;
            this.trlSecurity.OptionsSelection.UseIndicatorForSelection = true;
            this.trlSecurity.OptionsView.ShowHorzLines = false;
            this.trlSecurity.OptionsView.ShowRoot = false;
            this.trlSecurity.OptionsView.ShowVertLines = false;
            this.trlSecurity.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.trlSecurity.SelectImageList = this.imgList;
            this.trlSecurity.Size = new System.Drawing.Size(446, 490);
            this.trlSecurity.TabIndex = 0;
            this.trlSecurity.AfterExpand += new DevExpress.XtraTreeList.NodeEventHandler(this.trlSecurity_AfterExpand);
            this.trlSecurity.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.trlSecurity_FocusedNodeChanged);
            this.trlSecurity.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trlSecurity_MouseClick);
            // 
            // trlPermission
            // 
            this.trlPermission.Caption = "Permission";
            this.trlPermission.FieldName = "Permission";
            this.trlPermission.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.trlPermission.MinWidth = 33;
            this.trlPermission.Name = "trlPermission";
            this.trlPermission.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            this.trlPermission.Visible = true;
            this.trlPermission.VisibleIndex = 0;
            this.trlPermission.Width = 427;
            // 
            // trlPermUserID
            // 
            this.trlPermUserID.Caption = "trlPermUserID";
            this.trlPermUserID.FieldName = "trlPermUserID";
            this.trlPermUserID.Name = "trlPermUserID";
            // 
            // trlPermGroupID
            // 
            this.trlPermGroupID.Caption = "trlPermGroupID";
            this.trlPermGroupID.FieldName = "trlPermGroupID";
            this.trlPermGroupID.Name = "trlPermGroupID";
            // 
            // trlPermScreenID
            // 
            this.trlPermScreenID.Caption = "trlPermScreenID";
            this.trlPermScreenID.FieldName = "trlPermScreenID";
            this.trlPermScreenID.Name = "trlPermScreenID";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AppearanceFocused.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.repositoryItemCheckEdit1.AppearanceFocused.BorderColor = System.Drawing.Color.Red;
            this.repositoryItemCheckEdit1.AppearanceFocused.Options.UseBackColor = true;
            this.repositoryItemCheckEdit1.AppearanceFocused.Options.UseBorderColor = true;
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // frmADM040_SecurityMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 558);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gpcSecurity);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmADM040_SecurityMapping";
            this.Text = "ADM040: Security Mapping";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmADM040_SecurityMapping_FormClosing);
            this.Load += new System.EventHandler(this.frmMAS040_SecurityMapping_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.gpcSecurity, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpcBelongGroup)).EndInit();
            this.gpcBelongGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlBelongGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlUser)).EndInit();
            this.tabGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlUserGroup)).EndInit();
            this.tabScreen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcSecurity)).EndInit();
            this.gpcSecurity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trlSecurity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabUser;
        private DevExpress.XtraTab.XtraTabPage tabGroup;
        private DevExpress.XtraTab.XtraTabPage tabScreen;
        private DevExpress.XtraEditors.GroupControl gpcSecurity;
        private DevExpress.XtraTreeList.TreeList trlSecurity;
        private DevExpress.XtraTreeList.TreeList trlUser;
        private DevExpress.XtraTreeList.TreeList trlUserGroup;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcUserGroup;
        private DevExpress.XtraTreeList.TreeList trlScreen;
        private DevExpress.XtraEditors.GroupControl gpcBelongGroup;
        private DevExpress.XtraTreeList.TreeList trlBelongGroup;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcBelongGroup;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTreeList.TreeList trlMember;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcMember;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcUserName;
        private System.Windows.Forms.ImageList imgList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcScreen;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcClassName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcDisplayName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcKey;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trlPermission;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trlUserID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trlGroupID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trlFirstLastName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trlGroupName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trlPermUserID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trlPermGroupID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn trlPermScreenID;
    }
}
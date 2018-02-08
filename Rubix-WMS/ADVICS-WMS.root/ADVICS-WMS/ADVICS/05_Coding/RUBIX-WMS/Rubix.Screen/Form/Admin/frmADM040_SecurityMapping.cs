using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using CSI.Business.Admin;
using Rubix.Framework;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Form.Admin
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Edit)]
    public partial class frmADM040_SecurityMapping : FormBase
    {
        #region Member
        const string PERMISSION_NODE = "PM_NODE";
        const int CHECKED_IMAGE_IDX = 13;
        private SecurityMapping db;
        private enum DataCol
        {
            Display
            ,
            ID
                ,
            Name
                , ClassName
        }

        List<tb_SecurityMatch> SecuritityList;

        #endregion

        #region Properties
        private SecurityMapping BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new SecurityMapping();
                }
                return db;
            }
        }

        public Common.eScreenMode ScreenMode { get; set; }

        public TreeListNode ActiveNode { get; set; }
        #endregion

        #region Construnctor
        public frmADM040_SecurityMapping()
        {
            InitializeComponent();
            base.TreeListControl = new TreeList[] { trlUser, trlUserGroup, trlScreen, trlSecurity, trlBelongGroup, trlMember };
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh, m_toolBarAdd, m_toolBarExport, m_toolBarView, m_toolBarDelete);
            ScreenMode = Common.eScreenMode.View;
        }
        #endregion

        #region Override Method
        public override bool OnCommandEdit()
        {
            ControlUtil.HiddenControl(false, m_toolBarSave, m_toolBarCancel);
            m_toolBarEdit.Enabled = false;
            ScreenMode = Common.eScreenMode.Edit;

            foreach (DevExpress.XtraTab.XtraTabPage page in xtraTabControl1.TabPages)
            {
                page.PageEnabled = (page == xtraTabControl1.SelectedTabPage);
            }

            trlScreen.Enabled = false;
            trlUser.Enabled = false;
            trlUserGroup.Enabled = false;

            SecuritityList = new List<tb_SecurityMatch>();

            return base.OnCommandEdit();
        }

        public override bool OnCommandSave()
        {
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel);
            trlSecurity.PostEditor();
            m_toolBarEdit.Enabled = true;
            ScreenMode = Common.eScreenMode.View;

            BusinessClass.SaveChanges(SecuritityList);

            foreach (DevExpress.XtraTab.XtraTabPage page in xtraTabControl1.TabPages)
            {
                page.PageEnabled = true;
            }

            trlScreen.Enabled = true;
            trlUser.Enabled = true;
            trlUserGroup.Enabled = true;

            SecuritityList.Clear();

            return base.OnCommandSave();
        }

        public override bool OnCommandCancel()
        {
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel);
            m_toolBarEdit.Enabled = true;
            ScreenMode = Common.eScreenMode.View;
            foreach (DevExpress.XtraTab.XtraTabPage page in xtraTabControl1.TabPages)
            {
                page.PageEnabled = true;
            }
            trlScreen.Enabled = true;
            trlUser.Enabled = true;
            trlUserGroup.Enabled = true;
            if (xtraTabControl1.SelectedTabPage == tabUser)
            {
                LoadUserSecurity(trlUser.FocusedNode);
            }
            else if (xtraTabControl1.SelectedTabPage == tabGroup)
            {
                LoadUserGroupSecurity(trlUserGroup.FocusedNode);
            }
            else
            {
                LoadScreenSecurity(trlScreen.FocusedNode);
            }

            SecuritityList.Clear();

            return base.OnCommandCancel();
        }

        public override void OnLanguageChange(object sender, LanguageChangeEventArgs e)
        {
            string param = gpcSecurity.Text;
            base.OnLanguageChange(sender, e);
            SetSecurityPanelText(param);
        }

        private void LoadScreenSecurity(TreeListNode tln)
        {
            if (xtraTabControl1.SelectedTabPage != tabScreen)
                return;
            trlSecurity.ClearNodes();
            if (tln != null && tln.GetValue((int)DataCol.ID) != null && !tln.GetValue((int)DataCol.ClassName).ToString().Equals("-"))
            {
                trlSecurity.ClearNodes();
                ActiveNode = tln;
                //gpcSecurity.Text = string.Format("Security mapping for Screen \"{0}\"", tln.GetValue((int)DataCol.Name));
                SetSecurityPanelText(tln.GetValue((int)DataCol.Name).ToString());

                string screenID = tln.GetValue((int)DataCol.ID).ToString();

                TreeListNode nodeUser = null;
                TreeListNode nodeGroup = null;
                TreeListNode nodeLast = null;
                nodeUser = trlSecurity.AppendNode(new object[] { "User Level" }, null);
                nodeUser.ImageIndex = 2;
                nodeUser.SelectImageIndex = 2;
                nodeGroup = trlSecurity.AppendNode(new object[] { "User Group Level" }, null);
                nodeGroup.ImageIndex = 5;
                nodeGroup.SelectImageIndex = 5;

                string previosData = string.Empty;
                foreach (DataRow dr in BusinessClass.LoadUserPermissionByScreenID(Int32.Parse(screenID)).Rows)
                {
                    if (!previosData.Equals(dr["USERID"].ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        previosData = dr["USERID"].ToString();
                        nodeLast = nodeUser.Nodes.Add(new object[] { dr["USERID"] });
                        nodeLast.Tag = null;
                        nodeLast.ImageIndex = 2;
                        nodeLast.SelectImageIndex = 2;
                        string[] permissions = BusinessClass.GetScreenPermission(System.Reflection.Assembly.GetExecutingAssembly().GetType(tln.GetValue((int)DataCol.ClassName).ToString()));
                        foreach (string permission in permissions)
                        {
                            TreeListNode curNode = nodeLast.Nodes.Add(new object[] { permission, dr["USERID"], null, screenID });
                            curNode.Tag = PERMISSION_NODE;
                            curNode.ImageIndex = -1;
                            curNode.SelectImageIndex = -1;
                        }
                    }
                    foreach (TreeListNode nd in nodeLast.Nodes)
                    {
                        if (nd.GetValue(0).ToString().Equals(dr["PERMISSION"].ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            nd.Checked = true;
                            nd.ImageIndex = CHECKED_IMAGE_IDX;
                            nd.SelectImageIndex = CHECKED_IMAGE_IDX;
                        }
                    }
                }
                previosData = string.Empty;
                foreach (DataRow dr in BusinessClass.LoadGroupPermissionByScreenID(Int32.Parse(screenID)).Rows)
                {
                    if (!previosData.Equals(dr["GROUPID"].ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        previosData = dr["GROUPID"].ToString();
                        nodeLast = nodeGroup.Nodes.Add(new object[] { dr["GROUPNAME"] });
                        nodeLast.Tag = null;
                        nodeLast.ImageIndex = 2;
                        nodeLast.SelectImageIndex = 2;
                        string[] permissions = BusinessClass.GetScreenPermission(System.Reflection.Assembly.GetExecutingAssembly().GetType(tln.GetValue((int)DataCol.ClassName).ToString()));
                        foreach (string permission in permissions)
                        {
                            TreeListNode curNode = nodeLast.Nodes.Add(new object[] { permission, null, dr["GROUPID"], screenID });
                            curNode.Tag = PERMISSION_NODE;
                            curNode.ImageIndex = -1;
                            curNode.SelectImageIndex = -1;
                        }
                    }
                    foreach (TreeListNode nd in nodeLast.Nodes)
                    {
                        if (nd.GetValue(0).ToString().Equals(dr["PERMISSION"].ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            nd.Checked = true;
                            nd.ImageIndex = CHECKED_IMAGE_IDX;
                            nd.SelectImageIndex = CHECKED_IMAGE_IDX;
                        }
                    }
                }
                trlSecurity.EndUnboundLoad();
                nodeUser.ExpandAll();
                nodeGroup.ExpandAll();
            }
            else
            {
                gpcSecurity.Text = "";
            }
        }

        private void LoadUserSecurity(TreeListNode tln)
        {
            if (xtraTabControl1.SelectedTabPage != tabUser)
                return;
            trlSecurity.ClearNodes();
            trlBelongGroup.ClearNodes();
            if (tln != null && tln.GetValue((int)DataCol.ID) != null)
            {
                trlSecurity.BeginUnboundLoad();
                ActiveNode = tln;
                //gpcSecurity.Text = string.Format("Security mapping for User \"{0}\"", tln.GetValue((int)DataCol.Name));
                SetSecurityPanelText(tln.GetValue((int)DataCol.Name).ToString());

                string userID = tln.GetValue((int)DataCol.ID).ToString();

                foreach (DataRow dr in BusinessClass.LoadGroupByUserID(userID).Rows)
                {
                    trlBelongGroup.AppendNode(new object[] { dr["GROUPNAME"] }, null);
                }

                TreeListNode nodeLast = null;
                string previosData = string.Empty;
                foreach (DataRow dr in BusinessClass.LoadUserPermissionByUserID(userID).Rows)
                {
                    if (!previosData.Equals(dr["CLASSNAME"].ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        previosData = dr["CLASSNAME"].ToString();
                        nodeLast = trlSecurity.Nodes.Add(new object[] { string.Format("{0} [{1}]", dr["DISPLAYNAME"], dr["CLASSNAME"]) });
                        nodeLast.Tag = null;
                        nodeLast.ImageIndex = 7;
                        nodeLast.SelectImageIndex = 7;
                        string[] permissions = BusinessClass.GetScreenPermission(System.Reflection.Assembly.GetExecutingAssembly().GetType(dr["CLASSNAME"].ToString()));
                        foreach (string permission in permissions)
                        {
                            TreeListNode curNode = nodeLast.Nodes.Add(new object[] { permission, userID, null, dr["SCREENID"] });
                            curNode.Tag = PERMISSION_NODE;
                            curNode.ImageIndex = -1;
                            curNode.SelectImageIndex = -1;
                        }
                    }
                    foreach (TreeListNode nd in nodeLast.Nodes)
                    {
                        if (nd.GetValue(0).ToString().Equals(dr["PERMISSION"].ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            nd.Checked = true;
                            nd.ImageIndex = CHECKED_IMAGE_IDX;
                            nd.SelectImageIndex = CHECKED_IMAGE_IDX;
                        }
                    }
                }
                trlSecurity.EndUnboundLoad();
                trlSecurity.ExpandAll();
            }
        }

        private void LoadUserGroupSecurity(TreeListNode tln)
        {
            if (xtraTabControl1.SelectedTabPage != tabGroup)
                return;
            trlSecurity.ClearNodes();
            trlMember.ClearNodes();
            if (tln != null && tln.GetValue((int)DataCol.ID) != null)
            {
                trlSecurity.BeginUnboundLoad();
                ActiveNode = tln;
                //gpcSecurity.Text = string.Format("Security mapping for User Group \"{0}\"", tln.GetValue((int)DataCol.Name));
                SetSecurityPanelText(tln.GetValue((int)DataCol.Name).ToString());

                int groupID = Int32.Parse(tln.GetValue((int)DataCol.ID).ToString());

                foreach (DataRow dr in BusinessClass.LoadUserByGroupID(groupID).Rows)
                {
                    trlMember.AppendNode(new object[] { string.Format("{0} [{1} {2}]", dr["USERID"], dr["FIRSTNAME"], dr["LASTNAME"]) }, null);
                }

                TreeListNode nodeLast = null;
                string previosData = string.Empty;
                foreach (DataRow dr in BusinessClass.LoadGroupPermissionByGroupID(groupID).Rows)
                {
                    if (!previosData.Equals(dr["CLASSNAME"].ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        previosData = dr["CLASSNAME"].ToString();
                        nodeLast = trlSecurity.Nodes.Add(new object[] { string.Format("{0} [{1}]", dr["DISPLAYNAME"], dr["CLASSNAME"]) });
                        nodeLast.Tag = null;
                        nodeLast.ImageIndex = 7;
                        nodeLast.SelectImageIndex = 7;
                        string[] permissions = BusinessClass.GetScreenPermission(System.Reflection.Assembly.GetExecutingAssembly().GetType(dr["CLASSNAME"].ToString()));
                        foreach (string permission in permissions)
                        {
                            TreeListNode curNode = nodeLast.Nodes.Add(new object[] { permission, null, groupID, dr["SCREENID"] });
                            curNode.Tag = PERMISSION_NODE;
                            curNode.ImageIndex = -1;
                            curNode.SelectImageIndex = -1;
                        }
                    }
                    foreach (TreeListNode nd in nodeLast.Nodes)
                    {
                        if (nd.GetValue(0).ToString().Equals(dr["PERMISSION"].ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            nd.Checked = true;
                            nd.ImageIndex = CHECKED_IMAGE_IDX;
                            nd.SelectImageIndex = CHECKED_IMAGE_IDX;
                        }
                    }
                }
                trlSecurity.EndUnboundLoad();
                trlSecurity.ExpandAll();
            }
        }

        private void SetSecurityPanelText(string param)
        {

            try
            {
                if (param.Contains("\""))
                {
                    param = param.Substring(param.IndexOf('"')).Replace("\"", "");
                }
            }
            catch (Exception) { }

            if (xtraTabControl1.SelectedTabPage == tabUser)
            {
                gpcSecurity.Text = string.Format(base.GetLanguange("gpcSecurity", gpcSecurity.Text), tabUser.Text, param);
            }
            else if (xtraTabControl1.SelectedTabPage == tabGroup)
            {
                gpcSecurity.Text = string.Format(base.GetLanguange("gpcSecurity", gpcSecurity.Text), tabGroup.Text, param);
            }
            else
            {
                gpcSecurity.Text = string.Format(base.GetLanguange("gpcSecurity", gpcSecurity.Text), tabScreen.Text, param);
            }

        }
        #endregion

        #region Event Handler Function
        private void frmMAS040_SecurityMapping_Load(object sender, EventArgs e)
        {
            if (AUTError == null)
            {
                LoadAllUser();
            }
        }

        private void trlScreen_AfterExpand(object sender, NodeEventArgs e)
        {
            trlScreen.Columns[0].BestFit();
        }

        private void trlSecurity_AfterExpand(object sender, NodeEventArgs e)
        {
            trlSecurity.Columns[0].BestFit();
        }

        private void trlScreen_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                this.ShowWaitScreen();
                LoadScreenSecurity(e.Node);
            }
            catch (Exception ex)
            {
                ExceptionManager.ManageException(this, ex);
            }
            finally
            {
                this.CloseWaitScreen();
            }
        }

        private void trlUser_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                this.ShowWaitScreen();
                LoadUserSecurity(e.Node);
            }
            catch (Exception ex)
            {
                ExceptionManager.ManageException(this, ex);
            }
            finally
            {
                this.CloseWaitScreen();
            }
        }

        private void trlUserGroup_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                this.ShowWaitScreen();
                LoadUserGroupSecurity(e.Node);
            }
            catch (Exception ex)
            {
                ExceptionManager.ManageException(this, ex);
            }
            finally
            {
                this.CloseWaitScreen();
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            ShowWaitScreen();
            if (e.Page == tabUser)
            {
                LoadAllUser();
            }
            else if (e.Page == tabGroup)
            {
                LoadAllUserGroup();
            }
            else
            {
                LoadAllScreen();
            }
            CloseWaitScreen();
        }

        private void frmADM040_SecurityMapping_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ScreenMode == Common.eScreenMode.Edit)
            {
                e.Cancel = (MessageDialog.ShowConfirmationMsg(this, Common.GetMessage("I0004")) != DialogButton.Yes);
            }
        }

        private void trlSecurity_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {

        }

        private void trlSecurity_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.ScreenMode == Common.eScreenMode.Edit)
            {
                ToggleCheckNode(trlSecurity.FocusedNode);
            }
        }
        #endregion

        #region LoadAllData
        private void LoadAllUser()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //trlUser.BeginUnboundLoad();
                trlUser.Nodes.Clear();
                TreeListNode nodeLast = null;
                foreach (DataRow dr in BusinessClass.LoadAllUser().Rows)
                {
                    nodeLast = trlUser.AppendNode(new object[] { string.Format("{0} [{1} {2}]", dr["UserID"], dr["FirstName"], dr["LastName"]), dr["UserID"], string.Format("{0} {1}", dr["FirstName"], dr["LastName"]) }, null);
                    nodeLast.ImageIndex = 2;
                    nodeLast.SelectImageIndex = 4;
                }
                //trlUser.EndUnboundLoad();
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void LoadAllUserGroup()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                trlUserGroup.BeginUnboundLoad();
                trlUserGroup.Nodes.Clear();
                TreeListNode nodeLast = null;
                foreach (DataRow dr in BusinessClass.LoadAllGroup().Rows)
                {
                    nodeLast = trlUserGroup.AppendNode(new object[] { string.Format("{0} [{1}]", dr["GroupName"].ToString(), dr["Description"].ToString()), Convert.ToInt32(dr["GroupID"]), dr["GroupName"].ToString() }, null);
                    nodeLast.ImageIndex = 5;
                    nodeLast.SelectImageIndex = 6;
                }
                trlUserGroup.EndUnboundLoad();
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void LoadAllScreen()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                trlScreen.BeginUnboundLoad();
                trlScreen.Nodes.Clear();
                TreeListNode nodeLast = null;
                string perviousMenuGroup = string.Empty;
                bool isFirstNode = true;
                foreach (DataRow dr in BusinessClass.LoadAllScreen().Rows)
                {
                    if (!dr["ClassName"].ToString().Equals("-"))
                    {
                        if (!perviousMenuGroup.Equals(dr["MenuGroupName"].ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            perviousMenuGroup = dr["MenuGroupName"].ToString();
                            nodeLast = trlScreen.AppendNode(new object[] { dr["MenuGroupName"].ToString(), 0, dr["MenuGroupName"].ToString(), "-" }, null);
                        }
                        TreeListNode node = nodeLast.Nodes.Add(new object[] { dr["DisplayName"].ToString() + string.Format(" [{0}]", dr["ClassName"].ToString()), Convert.ToInt32(dr["ScreenID"]), dr["DisplayName"].ToString(), dr["ClassName"].ToString() });
                        if (isFirstNode)
                        {
                            node.Selected = true;
                            isFirstNode = false;
                        }
                        node.ImageIndex = 7;
                        node.SelectImageIndex = 8;
                    }
                }
                trlScreen.EndUnboundLoad();

                trlScreen.ExpandAll();
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ToggleCheckNode(TreeListNode tln)
        {

            tb_SecurityMatch sm = new tb_SecurityMatch();

            if (tln != null && tln.Tag != null && tln.Tag.ToString().Equals(PERMISSION_NODE))
            {
                tln.Checked = !tln.Checked;
                int? groupID;
                if (tln.GetValue(2) != null)
                {
                    string data = tln.GetValue(2).ToString();
                    groupID = int.Parse(data);
                }
                else
                    groupID = null;
                if (tln.Checked) //check
                {
                    tln.ImageIndex = CHECKED_IMAGE_IDX;
                    tln.SelectImageIndex = CHECKED_IMAGE_IDX;

                    sm.SCREENID = (int)Convert.ToDouble(tln.GetValue(3).ToString());
                    sm.PERMISSION = tln.GetValue(0).ToString();
                    sm.USERID = (string)tln.GetValue(1);
                    sm.GROUPID = groupID;
                    sm.CREATEUSER = AppConfig.UserLogin;
                    sm.SECURITYID = 0;

                    SecuritityList.Remove(sm);
                    SecuritityList.Add(sm);
                }
                else //uncheck
                {
                    tln.ImageIndex = -1;
                    tln.SelectImageIndex = -1;

                    sm.SCREENID = (int)Convert.ToDouble(tln.GetValue(3).ToString());
                    sm.PERMISSION = tln.GetValue(0).ToString();
                    sm.USERID = (string)tln.GetValue(1);
                    sm.GROUPID = groupID;
                    sm.CREATEUSER = AppConfig.UserLogin;
                    sm.SECURITYID = 0;

                    SecuritityList.Remove(sm);
                    SecuritityList.Add(sm);

                }
            }
        }
        #endregion

    }
}
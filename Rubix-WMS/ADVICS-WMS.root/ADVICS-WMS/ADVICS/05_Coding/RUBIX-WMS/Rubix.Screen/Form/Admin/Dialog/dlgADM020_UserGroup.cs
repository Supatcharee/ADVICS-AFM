using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using Rubix.Framework;
using CSI.Business.Admin;
using CSI.Business.DataObjects;
using System.Xml;

namespace Rubix.Screen.Form.Admin.Dialog
{
    public partial class dlgADM020_UserGroup : DialogBase
    {
        #region "Member"
        private UserGroup db;
        private List<sp_ADM020_LoadUserByGroup_Result> userList = null;
        #endregion

        #region "Properties"
        public Common.eScreenMode ScreenMode { get; set; }

        public decimal? GroupID { get; set; }
        public tb_UserGroups UserGroup { get; set; }
        public List<sp_ADM020_LoadUserByGroup_Result> UserInfo { 
            get {
                if (userList == null)
                    userList = new List<sp_ADM020_LoadUserByGroup_Result>();
                return userList;
            }
            set {
                userList = value;
            }
        }

        public UserGroup BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new UserGroup();
                }
                return db;
            }
            set
            {
                db= value;
            }
        }
        #endregion

        #region Constructor
        public dlgADM020_UserGroup()
        {
            InitializeComponent();
        } 
        #endregion
        
        #region "Overrides"
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), txtGroupName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        BusinessClass.SaveChange(this.GroupID, txtGroupName.Text.Trim(), txtDesc.Text.Trim(), AppConfig.UserLogin, UserInfo);
                        DialogResult = DialogResult.OK;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }

        public override bool OnCommandClear()
        {
            if (this.ScreenMode == Common.eScreenMode.Add)
            {
                ClearControl();
            }
            else
            {
                DataBinding();
            }
            return true;
        }
        #endregion

        #region "Event handler"
        private void dlgADM020_UserGroup_Load(object sender, EventArgs e)
        {
            errorProvider.ClearErrors();
            this.UserInfo.Clear();
            cboUser.Reset();            
            DataBinding();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboUser.GetUserID == null)
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0008"));
            else
            {
                bool isExists = false;
                foreach (sp_ADM020_LoadUserByGroup_Result data in this.UserInfo)
                {
                    if (data.UserID.Equals(cboUser.GetUserID, StringComparison.OrdinalIgnoreCase))
                    {
                        isExists = true;
                        break;
                    }
                }
                if (!isExists) 
                {
                    this.UserInfo.Add(BusinessClass.GetUserInfo(cboUser.GetUserID));
                    
                    btnDelete.Enabled = (this.UserInfo.Count > 0 && ScreenMode != Common.eScreenMode.View);
                    grdUser.DataSource = this.UserInfo;
                    
                    foreach (DevExpress.XtraGrid.Columns.GridColumn gc in gdvUser.Columns)
                    {
                        gc.Width = gc.GetBestWidth();
                    }

                    gdvUser.RefreshData();
                }
                else
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0009"));
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.GetSelectedUserID()))
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0010"));
            else
            {
                foreach (sp_ADM020_LoadUserByGroup_Result data in this.UserInfo)
                {
                    if (data.UserID.Equals(this.GetSelectedUserID(), StringComparison.OrdinalIgnoreCase))
                    {
                        this.UserInfo.Remove(data);
                        gdvUser.RefreshData();
                        break;
                    }
                }
            }
        }
        #endregion

        #region "Generic function"
        private void ClearControl()
        {
            txtDesc.Text = string.Empty;
            txtGroupName.Text = string.Empty;
            //txtName.Text = string.Empty;
            //cboUser.Reset();
            grdUser.DataSource = null;
        }
        private void DataBinding()
        {
            if (ScreenMode == Common.eScreenMode.View)
            {
                ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
                ControlUtil.EnableControl(false, this.Controls);
              
                this.UserGroup = BusinessClass.GetUserGroup(this.GroupID.Value);
                txtGroupName.Text = this.UserGroup.GROUPNAME;
                txtDesc.Text = this.UserGroup.DESCRIPTION;
                List<sp_ADM020_LoadUserByGroup_Result> list = new List<sp_ADM020_LoadUserByGroup_Result>();
                foreach (sp_ADM020_LoadUserByGroup_Result data in BusinessClass.LoadUserByGroup(this.GroupID.Value))
                {
                    list.Add(data);
                }
                this.UserInfo = list;

                m_statusBarCreatedDate.Caption = this.UserGroup.CREATEDATE.ToString(Rubix.Screen.Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = this.UserGroup.CREATEUSER;
                if (this.UserGroup.UPDATEDATE.HasValue)
                    m_statusBarUpdatedDate.Caption = this.UserGroup.UPDATEDATE.Value.ToString(Rubix.Screen.Common.FullDatetimeFormat);
                else
                    m_statusBarUpdatedDate.Caption = "-";
                if (String.IsNullOrWhiteSpace(this.UserGroup.UPDATEUSER))
                    m_statusBarUpdatedUser.Caption = "-";
                else
                    m_statusBarUpdatedUser.Caption = this.UserGroup.UPDATEUSER;

            }
            else if (ScreenMode == Common.eScreenMode.Add)
            {
                ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);
                ControlUtil.EnableControl(true, this.Controls);
                ClearControl();

                m_statusBarCreatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = AppConfig.UserLogin;
                m_statusBarUpdatedDate.Caption = "-";
                m_statusBarUpdatedUser.Caption = "-";
            }
            else
            {
                ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);
                ControlUtil.EnableControl(true, this.Controls);

                this.UserGroup = BusinessClass.GetUserGroup(this.GroupID.Value);
                txtGroupName.Text = this.UserGroup.GROUPNAME;
                txtDesc.Text = this.UserGroup.DESCRIPTION;
                List<sp_ADM020_LoadUserByGroup_Result> list = new List<sp_ADM020_LoadUserByGroup_Result>();
                foreach (sp_ADM020_LoadUserByGroup_Result data in BusinessClass.LoadUserByGroup(this.GroupID.Value))
                {
                    list.Add(data);
                }
                this.UserInfo = list;

                m_statusBarCreatedDate.Caption = this.UserGroup.CREATEDATE.ToString(Rubix.Screen.Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = this.UserGroup.CREATEUSER;
                if (this.UserGroup.UPDATEDATE.HasValue)
                    m_statusBarUpdatedDate.Caption = this.UserGroup.UPDATEDATE.Value.ToString(Rubix.Screen.Common.FullDatetimeFormat);
                else
                    m_statusBarUpdatedDate.Caption = "-";
                if (String.IsNullOrWhiteSpace(this.UserGroup.UPDATEUSER))
                    m_statusBarUpdatedUser.Caption = "-";
                else
                    m_statusBarUpdatedUser.Caption = this.UserGroup.UPDATEUSER;
            }

            btnDelete.Enabled = (this.UserInfo.Count > 0 && ScreenMode != Common.eScreenMode.View);
            grdUser.DataSource = this.UserInfo;
        }
        private Boolean ValidateData()
        {
            Boolean errFlag = true;


            if (String.IsNullOrWhiteSpace(txtGroupName.Text))
            {
                errorProvider.SetError(txtGroupName, Rubix.Screen.Common.GetMessage("I0007"));
                errFlag = false;
            }
            else
                errorProvider.SetError(txtGroupName, string.Empty);

            if (errorProvider.GetError(txtGroupName).Length <= 0)
            {
                if (BusinessClass.IsDuplicatedGroupName(this.GroupID, txtGroupName.Text.Trim()))
                {
                    errorProvider.SetError(txtGroupName, Rubix.Screen.Common.GetMessage("I0146"));
                    errFlag = false;
                }
                else
                    errorProvider.SetError(txtGroupName, string.Empty);
            }

            if (errFlag)
                errorProvider.ClearErrors();
            return errFlag;
        }
        private string GetSelectedUserID()
        {
            if (gdvUser.GetFocusedRow() is sp_ADM020_LoadUserByGroup_Result)
            {
                sp_ADM020_LoadUserByGroup_Result selected = (sp_ADM020_LoadUserByGroup_Result)gdvUser.GetFocusedRow();
                return selected.UserID;
            }
            else
                return string.Empty;
        }
        #endregion


    }
}
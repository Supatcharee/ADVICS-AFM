using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;
using Rubix.Framework;
using CSI.Business.Admin;
using System.Xml;

namespace Rubix.Screen.Form.Admin.Dialog
{
    public partial class dlgADM010_UserMaintenance : DialogBase
    {
        #region "Member"
        private UserMaintenance db;
        #endregion

        #region "Properties"
        public Common.eScreenMode ScreenMode { get; set; }

        public string UserID { get; set; }
        public CSI.Business.DataObjects.tb_User UserInfo { get; set; }

        public UserMaintenance BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new UserMaintenance();
                }
                return db;
            }
            set
            {
                db = value;
            }
        }
        #endregion

        #region "Constructor"
        public dlgADM010_UserMaintenance()
        {
            InitializeComponent();
            warehouseControl.IsForEdit = true;
        }
        #endregion

        #region "Overrides"
        public override bool OnCommandSave()
        {
            bool result;
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), txtUserID.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (this.ScreenMode == Common.eScreenMode.Add)
                        {
                            result = BusinessClass.AddUser(txtUserID.Text.Trim(), txtPassword.Text.Trim(), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim(), txtEmail.Text.Trim(), txtMobile.Text.Trim(), txtTel.Text.Trim(), AppConfig.UserLogin, warehouseControl.WarehouseID, ownerControl.OwnerID, Convert.ToInt16(cboLoginType.EditValue), Convert.ToString(cboDomainServerName.EditValue), cboDomainServerName.Text);
                            //AppConfig.DefaultWarehouseID = warehouseControl.WarehouseID;
                            //AppConfig.DefaultOwnerID = ownerControl.OwnerID;
                        }
                        else
                        {
                            result = BusinessClass.EditUser(txtUserID.Text.Trim(), txtPassword.Text.Trim(), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim(), txtEmail.Text.Trim(), txtMobile.Text.Trim(), txtTel.Text.Trim(), AppConfig.UserLogin, warehouseControl.WarehouseID, ownerControl.OwnerID, Convert.ToInt16(cboLoginType.EditValue), Convert.ToString(cboDomainServerName.EditValue), cboDomainServerName.Text);
                            //AppConfig.DefaultWarehouseID = warehouseControl.WarehouseID;
                            //AppConfig.DefaultOwnerID = ownerControl.OwnerID;
                        }
                        if (result)
                        {
                            DialogResult = DialogResult.OK;
                            return true;
                        }
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
                InitialCombobox();
                ClearControl();
            }
            else
                DataBinding();
            return true;
        }
        #endregion

        #region "Event handler"
        private void dlgADM010_UserMaintenance_Load(object sender, EventArgs e)
        {
            errorProvider.ClearErrors();
            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();

            InitialCombobox();

            if (ScreenMode == Common.eScreenMode.View)
            {
                ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
                txtUserID.Focus();
                ControlUtil.EnableControl(false, this.Controls);
                DataBinding();
                ownerControl.EnableControl = false;
                warehouseControl.EnableControl = false;
            }
            else if (ScreenMode == Common.eScreenMode.Add)
            {
                ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);
                ControlUtil.EnableControl(true, this.Controls);
                txtUserID.Focus();
                ClearControl();

                m_statusBarCreatedDate.Caption = DateTime.Now.ToString(Rubix.Screen.Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = AppConfig.UserLogin;
                m_statusBarUpdatedDate.Caption = "-";
                m_statusBarUpdatedUser.Caption = "-";
            }
            else
            {
                ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);
                ControlUtil.EnableControl(true, this.Controls);
                ControlUtil.EnableControl(false, txtUserID);
                txtPassword.Focus();
                DataBinding();
            }
        }

        private void ownerControl_EditValueChanged(object sender, EventArgs e)
        {
            if (ownerControl.OwnerID != null)
            {
                warehouseControl.OwnerID = ownerControl.OwnerID;
                warehouseControl.DataLoading();
            }
            else
            {
                warehouseControl.ClearData();
            }
        }
        
        private void cboLoginType_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cboLoginType.EditValue) == 1)
            {
                cboDomainServerName.EditValue = string.Empty;
                ControlUtil.EnableControl(false, cboDomainServerName);
                ControlUtil.EnableControl(true, txtPassword, txtComfirmPassword, txtFirstName);
                ControlUtil.HiddenControl(true, btnSearchDomainUser, reqDomainName);
            }
            else
            {
                ControlUtil.EnableControl(true, cboDomainServerName);
                ControlUtil.EnableControl(false, txtPassword, txtComfirmPassword, txtFirstName);
                ControlUtil.HiddenControl(false, btnSearchDomainUser, reqDomainName);
            }
        }

        private void cboDomainServerName_EditValueChanged(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void btnSearchDomainUser_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider.ClearErrors();

                if (string.IsNullOrEmpty(Convert.ToString(cboDomainServerName.EditValue)))
                {
                    errorProvider.SetError(cboDomainServerName, Rubix.Screen.Common.GetMessage("I0011"));                    
                    return;
                }

                if (String.IsNullOrWhiteSpace(txtUserID.Text))
                {
                    errorProvider.SetError(txtUserID, Rubix.Screen.Common.GetMessage("I0005"));
                    return;
                }

                ShowWaitScreen();
                LDAPAuthentication ldap = new LDAPAuthentication(cboDomainServerName.Text, cboDomainServerName.EditValue.ToString());
                LDAPUserObjectLink ldapUser = ldap.GetUserObjectLinkByName(txtUserID.Text.Trim());

                if (ldapUser.Count > 0) //Update By Narongchai J. 23/01/2015
                {
                    foreach (LDAPUserObject objUser in ldapUser)
                    {
                        txtFirstName.Text = objUser.FirstName;
                        txtLastName.Text = objUser.LastName;
                        txtEmail.Text = objUser.EMail;
                        return;
                    }
                }
                else
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void txtUserID_EditValueChanged(object sender, EventArgs e)
        {
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtEmail.Text = String.Empty;
        }

        #endregion

        #region "Generic function"
        private void InitialCombobox()
        {
            cboDomainServerName.Properties.DataSource = AppConfig.DomainList;
            cboDomainServerName.Properties.DisplayMember = "DomainName";
            cboDomainServerName.Properties.ValueMember = "DomainIPAddress";

            DataTable dt = new DataTable();
            dt.Columns.Add("LoginTypeID",typeof(int));
            dt.Columns.Add("LoginTypeName", typeof(string));

            DataRow dr = dt.NewRow();
            dr["LoginTypeID"] = 1;
            dr["LoginTypeName"] = "Database";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["LoginTypeID"] = 2;
            dr["LoginTypeName"] = "Domain";
            dt.Rows.Add(dr);
            dt.AcceptChanges();

            cboLoginType.Properties.DataSource = dt;
            cboLoginType.Properties.DisplayMember = "LoginTypeName";
            cboLoginType.Properties.ValueMember = "LoginTypeID";
            cboLoginType.EditValue = 1;
        }
        
        private void ClearControl()
        {
            if (this.ScreenMode != Common.eScreenMode.Edit)
            {
                txtUserID.Text = String.Empty;
            }
            txtPassword.Text = String.Empty;
            txtComfirmPassword.Text = String.Empty;
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtMobile.Text = String.Empty;
            txtTel.Text = String.Empty;
            txtAddress.Text = String.Empty;
            ownerControl.ClearData();
            warehouseControl.ClearData();
            errorProvider.ClearErrors();
        }

        private void DataBinding()
        {
            errorProvider.ClearErrors();
            this.UserInfo = BusinessClass.GetUser(this.UserID);
            cboLoginType.EditValue = this.UserInfo.LoginType;
            cboDomainServerName.EditValue = this.UserInfo.DomainIPAddress;

            txtUserID.Text = this.UserInfo.UserID;
            txtPassword.Text = String.Empty;
            txtComfirmPassword.Text = string.Empty;
            txtFirstName.Text = this.UserInfo.FirstName;
            txtLastName.Text = this.UserInfo.LastName;
            txtEmail.Text = this.UserInfo.Email;
            txtMobile.Text = this.UserInfo.Mobile;
            txtTel.Text = this.UserInfo.Tel;
            txtAddress.Text = this.UserInfo.Address;            

            m_statusBarCreatedDate.Caption = this.UserInfo.CreateDate .ToString(Rubix.Screen.Common.FullDatetimeFormat);
            m_statusBarCreatedUser.Caption = this.UserInfo.CreateUser;
            if (this.UserInfo.UpdateDate.HasValue)
                m_statusBarUpdatedDate.Caption = this.UserInfo.UpdateDate.Value.ToString(Rubix.Screen.Common.FullDatetimeFormat);
            else
                m_statusBarUpdatedDate.Caption = "-";
            if (String.IsNullOrWhiteSpace(this.UserInfo.UpdateUser))
                m_statusBarUpdatedUser.Caption = "-";
            else
                m_statusBarUpdatedUser.Caption = this.UserInfo.UpdateUser;

            //Add By Narongchai J. 23/01/2015
            ownerControl.DataLoading();
            ownerControl.OwnerID = this.UserInfo.OwnerID;

            warehouseControl.OwnerID = this.UserInfo.OwnerID;
            warehouseControl.DataLoading();
            warehouseControl.WarehouseID = this.UserInfo.WarehouseID;
        }

        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();

            if (String.IsNullOrWhiteSpace(txtUserID.Text))
            {
                errorProvider.SetError(txtUserID, Rubix.Screen.Common.GetMessage("I0005"));
                errFlag = false;
            }
            else
            {
                if (BusinessClass.IsExists(txtUserID.Text) && this.ScreenMode == Common.eScreenMode.Add)
                {
                    errorProvider.SetError(txtUserID, Rubix.Screen.Common.GetMessage("I0141"));
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0141"));
                    errFlag = false;
                }
            }

            if (Convert.ToInt16(cboLoginType.EditValue) == 1)
            {
                if (String.IsNullOrWhiteSpace(txtPassword.Text) && ScreenMode == Common.eScreenMode.Add)
                {
                    errorProvider.SetError(txtPassword, Rubix.Screen.Common.GetMessage("I0281"));
                    errFlag = false;
                }

                if (String.IsNullOrWhiteSpace(txtComfirmPassword.Text) && ScreenMode == Common.eScreenMode.Add)
                {
                    errorProvider.SetError(txtComfirmPassword, Rubix.Screen.Common.GetMessage("I0281"));
                    errFlag = false;
                }

                if (!txtPassword.Text.Equals(txtComfirmPassword.Text))
                {
                    errorProvider.SetError(txtComfirmPassword, Rubix.Screen.Common.GetMessage("I0140"));
                    errFlag = false;
                }
            }
            else if (Convert.ToInt16(cboLoginType.EditValue) == 2) //Add By Narongchai J. 23/01/2015
            {
                if (string.IsNullOrEmpty(Convert.ToString(cboDomainServerName.EditValue)))
                {
                    errorProvider.SetError(cboDomainServerName, Rubix.Screen.Common.GetMessage("I0011"));
                    errFlag = false;
                }
            }
            
            if (String.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorProvider.SetError(txtFirstName, Rubix.Screen.Common.GetMessage("I0006"));
                errFlag = false;
            }

            return errFlag;
        }
        #endregion        

    }
}
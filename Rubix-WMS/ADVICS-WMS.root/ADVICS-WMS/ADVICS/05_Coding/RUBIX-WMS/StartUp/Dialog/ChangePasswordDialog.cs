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
using System.Xml;
using CSI.Business;
using Rubix.Screen;
using CSI.Business.Admin;

namespace StartUp.Dialog
{
    public partial class ChangePasswordDialog : DevExpress.XtraEditors.XtraForm
    {

        #region Member
        private MultiLangBiz mb = null;
        private UserMaintenance um;
        #endregion

        #region Constructor
        public ChangePasswordDialog()
        {
            InitializeComponent();
        } 
        #endregion

        #region Properties
        public string UserID
        {
            get
            {
                return txtUserID.Text;
            }
            set
            {
                txtUserID.Text = value;
            }
        }
        private MultiLangBiz MultiLangClass
        {
            get
            {
                if (mb == null)
                {
                    mb = new MultiLangBiz();
                }
                return mb;
            }
        }
        private UserMaintenance BusinessClass
        {
            get
            {
                if (um == null)
                {
                    um = new UserMaintenance();
                }
                return um;
            }
            set
            {
                if (um == null)
                {
                    um = new UserMaintenance();
                }
                um = value;
            }
        }
        #endregion
        
        #region Event Handler
        private void ChangePasswordDialog_Load(object sender, EventArgs e)
        {
            try
            {
                if (AppConfig.IsDomainLogin)
                {
                    ControlUtil.EnableControl(false, txtConfirmPass, txtCurrentPass, txtNewPass);
                }
                else
                {
                    ControlUtil.EnableControl(true, txtConfirmPass, txtCurrentPass, txtNewPass);
                }
                //////////////////initial multi lang ////////////////////////////////////
                if (!Util.IsNullOrEmpty(AppConfig.DefaultLanguagePath))
                {
                    AppConfig.CurrentLanguage = new MultiLanguage();
                    AppConfig.CurrentLanguage.LoadMultiLang(MultiLangClass.LoadMultilang(AppConfig.DefaultLanguagePath));
                    OnLanguageChange(this, new LanguageChangeEventArgs(AppConfig.CurrentLanguage));
                }
                /////////////////////////////////////////////////////////////////////////
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        } 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    BusinessClass = null;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
        #endregion

        #region Generic Function
        public void OnLanguageChange(object sender, LanguageChangeEventArgs e)
        {
            Util.ChangeLanguage(this.Name, this.Controls, e);
            this.Text = e.MultiLanguage.GetText(MultiLanguage.eType.Form, this.Name, "Text", this.Text);
        }

        private bool ValidateData()
        {
            bool IsResult = true;
            if (BusinessClass.VerifyUser(AppConfig.UserLogin, txtCurrentPass.Text.Trim()))
            {
                if (!String.IsNullOrWhiteSpace(txtConfirmPass.Text))
                {
                    if (txtNewPass.Text.Equals(txtConfirmPass.Text))
                    {
                        BusinessClass.ChangePassword(txtUserID.Text, txtNewPass.Text.Trim(), AppConfig.UserLogin);
                    }
                    else
                    {
                        IsResult = false;
                        Rubix.Framework.MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0140"));
                    }
                }
                else
                {
                    IsResult = false;
                    Rubix.Framework.MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0281"));
                }
            }
            else
            {
                IsResult = false;
                Rubix.Framework.MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0001"));                
            }
            return IsResult;
        }
        #endregion
    }
}
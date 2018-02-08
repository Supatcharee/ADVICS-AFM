using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSI.Business.Master;
using CSI.Business;
using Rubix.Framework;
using System.Text.RegularExpressions;

namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS010_Owner : DialogBase,Rubix.Framework.IClearable
    {
        #region Member
        String strCustomerID = String.Empty;
        String strCustomerCode = String.Empty;
        private Owner db;
        private Common.eScreenMode eScrenMode;
        #endregion

        #region Properties
        public String OwnerID
        {
            get { return strCustomerID; }
            set { strCustomerID = value; }
        }
        public String OwnerCode
        {
            get { return strCustomerCode; }
            set { strCustomerCode = value; }
        }
        public Owner BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Owner();
                }
                return db;
            }
            set 
            {
                if (db == null)
                {
                    db = new Owner();
                }
                db = value;
            }
        }
        public Common.eScreenMode ScreenMode
        {
            get { return eScrenMode; }
            set { eScrenMode = value; }
        }
        #endregion

        #region Constructor
        public dlgXMSS010_Owner()
        {
            InitializeComponent();           
        } 
        #endregion
        
        #region Event Handler Function
        private void dlgXMSS010_Owner_Load(object sender, EventArgs e)
        {
            if (ScreenMode == Common.eScreenMode.View)
            {
                ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
                ControlUtil.EnableControl(false, Controls);
                if (BusinessClass.DefaultReceivingDate == "Plan")
                {
                    rdoPlan.Checked = true;
                }
                else if (BusinessClass.DefaultReceivingDate == "Actual")
                {
                    rdoActual.Checked = true;
                }
            }
            else
            {
                ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);
            }
            if (ScreenMode == Common.eScreenMode.Add)
            {
                rdoActual.Checked = true;
                m_statusBarCreatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = AppConfig.UserLogin;
                m_statusBarUpdatedDate.Caption = "-";
                m_statusBarUpdatedUser.Caption = "-";
                ControlUtil.ClearControlData(txtOwnerCode
                                                , txtOwnerName 
                                                , txtBusinessType
                                                , txtAddress
                                                , txtCity
                                                , txtProvince
                                                , txtPostal
                                                , txtCountry
                                                , txtMobile
                                                , txtMobile
                                                , txtPhone
                                                , txtExtension
                                                , txtFax
                                                , txtEmail
                                                , txtContactName1
                                                , txtContactName2
                                                , txtContactName3
                                                , memoEdit1);
                // Edit by Chalermchai C. // 04/23/2012
                if (BusinessClass.OwnerCode != null)
                {
                    BusinessClass = new Owner();
                }
            }

            else
            {
                DataBinding();
            }
        } 
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0047"),txtOwnerName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistOwnerCode(BusinessClass.OwnerID,txtOwnerCode.Text.Trim()) && BusinessClass.OwnerCode != txtOwnerCode.Text.Trim())
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0020"));
                            return false;
                        }
                        
                        SavaData();
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
            ControlUtil.ClearControlData(this);
            //memoEdit1.Text = String.Empty;
            rdoActual.Checked = true;
            return base.OnCommandClear();
        }
        #endregion

        #region Generic Function
        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();

            if (txtOwnerCode.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtOwnerCode, Rubix.Screen.Common.GetMessage("I0018"));
                errFlag = false;
            }

            if (txtOwnerName.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtOwnerName, Rubix.Screen.Common.GetMessage("I0019"));
                errFlag = false;
            }                     

            if (txtEmail.EditValue != null && !string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                foreach (string email in txtEmail.Text.Split(';'))
                {
                    if (string.IsNullOrWhiteSpace(email))
                        continue;
                    if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$"))
                    {
                        errFlag = false;
                        errorProvider.SetError(txtEmail, Common.GetMessage("I0267"));
                        break;
                    }
                }
            }

            return errFlag;
        }

        private void DataBinding()
        {
            txtOwnerCode.Text = BusinessClass.OwnerCode;
            txtOwnerName.Text = BusinessClass.OwnerName;
            txtBusinessType.Text = BusinessClass.BusinessType;
            txtAddress.Text = BusinessClass.Address;
            txtCity.Text = BusinessClass.City;
            txtProvince.Text = BusinessClass.StateOrProvince;
            txtPostal.Text = BusinessClass.PostalCode;
            txtCountry.Text = BusinessClass.Country;
            txtMobile.Text = BusinessClass.MobileNo;
            txtPhone.Text = BusinessClass.PhoneNo;
            txtExtension.Text = BusinessClass.Extension;
            txtFax.Text = BusinessClass.FaxNo;
            txtEmail.Text = BusinessClass.EmailAddress;
            txtContactName1.Text = BusinessClass.ContactName1;
            txtContactName2.Text = BusinessClass.ContactName2;
            txtContactName3.Text = BusinessClass.ContactName3;
            txtLimitCapacity.EditValue = BusinessClass.LimitCapacity;
            memoEdit1.Text = BusinessClass.BankAccount;

            if (BusinessClass.DefaultReceivingDateType == 1)
            {
                rdoPlan.Checked = true;
            }
            else
            {
                rdoActual.Checked = true;
            }
            
            //Binding Statusbar
            m_statusBarCreatedDate.Caption = BusinessClass.CreateDate.ToString(Common.FullDatetimeFormat);
            m_statusBarCreatedUser.Caption = BusinessClass.CreateUser;
            if (BusinessClass.UpdateDate != null)
            {
                m_statusBarUpdatedDate.Caption = Convert.ToDateTime(BusinessClass.UpdateDate).ToString(Common.FullDatetimeFormat);
                m_statusBarUpdatedUser.Caption = BusinessClass.UpdateUser;
            }
            else if (BusinessClass.UpdateDate == null && ScreenMode == Common.eScreenMode.Edit)
            {
                m_statusBarUpdatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarUpdatedUser.Caption = AppConfig.UserLogin;
            }
        }

        private void SavaData()
        {
            BusinessClass.OwnerCode = txtOwnerCode.Text.Trim();
            BusinessClass.OwnerName = txtOwnerName.Text.Trim();
            BusinessClass.BusinessType = txtBusinessType.Text.Trim();
            BusinessClass.Address = txtAddress.Text.Trim();
            BusinessClass.City = txtCity.Text.Trim();
            BusinessClass.StateOrProvince = txtProvince.Text.Trim();
            BusinessClass.PostalCode = txtPostal.Text.Trim();
            BusinessClass.Country = txtCountry.Text.Trim();
            BusinessClass.MobileNo = txtMobile.Text.Trim();
            BusinessClass.PhoneNo = txtPhone.Text.Trim();
            BusinessClass.Extension = txtExtension.Text.Trim();
            BusinessClass.FaxNo = txtFax.Text.Trim();
            BusinessClass.EmailAddress = txtEmail.Text.Trim();
            BusinessClass.ContactName1 = txtContactName1.Text.Trim();
            BusinessClass.ContactName2 = txtContactName2.Text.Trim();
            BusinessClass.ContactName3 = txtContactName3.Text.Trim();
            BusinessClass.CreateUser = AppConfig.UserLogin;
            BusinessClass.BankAccount = memoEdit1.Text;
            BusinessClass.LimitCapacity = DataUtil.Convert<int>(txtLimitCapacity.EditValue);
            BusinessClass.DefaultReceivingDateType = (rdoPlan.Checked ? 1 : 0);            
            BusinessClass.SaveOwnerData();
        }
        
        public void ClearData()
        {
            errorProvider.ClearErrors();
            if (ScreenMode == Common.eScreenMode.Add)
            {
                ControlUtil.ClearControlData(txtOwnerCode
                                                , txtOwnerName
                                                , txtBusinessType
                                                , txtAddress
                                                , txtCity
                                                , txtProvince
                                                , txtPostal
                                                , txtCountry
                                                , txtMobile
                                                , txtMobile
                                                , txtPhone
                                                , txtExtension
                                                , txtFax
                                                , txtEmail
                                                , txtContactName1
                                                , txtContactName2
                                                , txtContactName3);
            }
            else
            {
                DataBinding();
            }
        }
        #endregion

    }
}
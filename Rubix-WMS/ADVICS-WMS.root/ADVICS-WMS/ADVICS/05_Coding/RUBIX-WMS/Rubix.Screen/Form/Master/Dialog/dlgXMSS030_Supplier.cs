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
    public partial class dlgXMSS030_Supplier : DialogBase, Rubix.Framework.IClearable
    {
        #region Member
        String strClientID = String.Empty;
        String strClientCode = String.Empty;
        String strSupplierID = String.Empty;
        String strSupplierCode = String.Empty;
        private Supplier db;
        private Common.eScreenMode eScrenMode;
        #endregion

        #region Properties
        public String ClientID
        {
            get { return strClientID; }
            set { strClientID = value; }
        }
        public String ClientCode
        {
            get { return strClientCode; }
            set { strClientCode = value; }
        }
        public String SupplierID
        {
            get { return strSupplierID; }
            set { strSupplierID = value; }
        }
        public String SupplierCode
        {
            get { return strSupplierCode; }
            set { strSupplierCode = value; }
        }
        public Supplier BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Supplier();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new Supplier();
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
        public dlgXMSS030_Supplier()
        {
            InitializeComponent();
        } 
        #endregion

        #region Event Handler Function
        private void dlgXMSS030_Supplier_Load(object sender, EventArgs e)
        {
            if (ScreenMode == Common.eScreenMode.Add)
            {
                m_statusBarCreatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = AppConfig.UserLogin;
                m_statusBarUpdatedDate.Caption = "-";
                m_statusBarUpdatedUser.Caption = "-";
                ownerControl.DataLoading();
                clearControl();
                if (BusinessClass.SupplierCode != null)
                {
                    BusinessClass = new Supplier();
                }
            }
            else
            {
                DataBinding();
            }

            if (ScreenMode == Common.eScreenMode.View)
            {
                ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
                ControlUtil.EnableControl(false, Controls);
                ownerControl.EnableControl = false;
            }
            else
            {
                ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);
            }

            if (ScreenMode == Common.eScreenMode.Edit)
                m_toolBarSaveACopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            else
                m_toolBarSaveACopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            
        }

        private void chkCalculateVat_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCalculateVat.Checked)
                {
                    txtCalculateVat.Properties.ReadOnly = false;
                }
                else
                {
                    txtCalculateVat.Properties.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0047"),txtLongName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistSupplierCode(BusinessClass.SupplierID, txtSupplierCode.Text.Trim(), ownerControl.OwnerID.Value))
                        {
                            if (ScreenMode == Common.eScreenMode.Edit)
                            {
                                if (BusinessClass.SupplierCode != txtSupplierCode.Text.Trim() || BusinessClass.OwnerID != ownerControl.OwnerID.Value)
                                {
                                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0027"));
                                    return false;
                                }
                            }
                            else 
                            {                             
                                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0027"));
                                return false;
                            }
                        }
                                                
                        SaveData();
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
        public override bool OnCommandSaveACopy()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), txtLongName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        BusinessClass.SupplierID = 0;
                        if (BusinessClass.CheckExistSupplierCode(BusinessClass.SupplierID , txtSupplierCode.Text.Trim(), ownerControl.OwnerID.Value))
                        {
                            if (ScreenMode == Common.eScreenMode.Edit)
                            {
                                if (BusinessClass.SupplierCode != txtSupplierCode.Text.Trim() || BusinessClass.OwnerID != ownerControl.OwnerID.Value)
                                {
                                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0027"));
                                    return false;
                                }
                            }
                            else
                            {
                                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0027"));
                                return false;
                            }
                        }

                        SaveData();
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
            return base.OnCommandClear();
        }
        #endregion
        
        #region Generic Function
        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();
            ////Supplier Code
            if (txtSupplierCode.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtSupplierCode, Rubix.Screen.Common.GetMessage("I0365"));
                errFlag = false;
            }

            ////Supplier No
            if (txtSupplierNo.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtSupplierNo, Rubix.Screen.Common.GetMessage("I0024"));
                errFlag = false;
            }

            ////Customer Code
            ownerControl.RequireField = true;
            ownerControl.ErrorText = Rubix.Screen.Common.GetMessage("I0026");
            if (!ownerControl.ValidateControl())
            {
                errFlag = false;
            }

            ////Supplier Name
            if (txtLongName.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtLongName, Rubix.Screen.Common.GetMessage("I0025"));
                errFlag = false;
            }

            //ArrivalLT
            if (txtArrivalLT.EditValue == null)
            {
                errorProvider.SetError(txtArrivalLT, Rubix.Screen.Common.GetMessage("I0366"));
                errFlag = false;

            }
            else
            {
                if (Convert.ToInt32(txtArrivalLT.EditValue) < 0)
                {
                    errorProvider.SetError(txtArrivalLT, Rubix.Screen.Common.GetMessage("I0390"));
                    errFlag = false;
                }
            }

            ////ArrivalTime
            if (txtArrivalTime.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtArrivalTime, Rubix.Screen.Common.GetMessage("I0367"));
                errFlag = false;
            }


            ////CollectTime
            if (txtCollectTime.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtCollectTime, Rubix.Screen.Common.GetMessage("I0369"));
                errFlag = false;
            }

            if (txtEmail.EditValue != null && !string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, String.Empty);
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

            if (!(chkMonday.Checked || chkTuesday.Checked || chkWednesday.Checked || chkThursday.Checked || chkFriday.Checked || chkSaturday.Checked || chkSunday.Checked))
            {
                errFlag = false;
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0391"));
            }

            return errFlag;
        }
        private void DataBinding()
        {

            txtSupplierCode.Text        = BusinessClass.SupplierCode;
            ownerControl.OwnerCode      = BusinessClass.OwnerCode;
            txtLongName.Text            = BusinessClass.SupplierLongName;            
            txtAddress1.Text            = BusinessClass.SupplierAddress1;
            txtAddress2.Text            = BusinessClass.SupplierAddress2;
            txtCity.Text                = BusinessClass.City;
            txtProvince.Text            = BusinessClass.StateOrProvince;
            txtCountry.Text             = BusinessClass.Country;
            txtPostalCode.Text          = BusinessClass.PostalCode;
            txtKM.Text                  = Convert.ToString(BusinessClass.KM);  
            txtMobile.Text              = BusinessClass.MobileNo;
            txtPhone.Text               = BusinessClass.PhoneNo;
            txtExt.Text                 = BusinessClass.Extension;
            txtFax.Text                 = BusinessClass.FaxNo;
            txtEmail.Text               = BusinessClass.EmailAddress;
            txtContactName1.Text        = BusinessClass.ContactName1;
            txtContactName2.Text        = BusinessClass.ContactName2;
            txtContactName3.Text        = BusinessClass.ContactName3;
            txtSupplierNo.Text          = BusinessClass.SupplierNo;
            txtArrivalLT.EditValue      = BusinessClass.ArrivalLeadTime;


            txtArrivalTime.EditValue    = string.Format("{0}:{1}", BusinessClass.ArrivalTime.Hours.ToString().PadLeft(2,'0'), BusinessClass.ArrivalTime.Minutes.ToString().PadLeft(2, '0'));
            txtCollectTime.EditValue = string.Format("{0}:{1}", BusinessClass.CollectTime.Hours.ToString().PadLeft(2, '0'), BusinessClass.CollectTime.Minutes.ToString().PadLeft(2, '0'));
            txtCreditTerm.Text          = BusinessClass.CreditTerm;
            txtDeliveryPlace.Text       = BusinessClass.DeliveryPlace;
            txtCalculateVat.EditValue   = BusinessClass.VAT;
            //chkCalculateVat.Checked     = Decimal.Parse(BusinessClass.VAT.ToString()) == decimal.Zero ? false : true;
            chkCalculateVat.Checked     = BusinessClass.isCalVat;
            chkMonday.Checked           = BusinessClass.Monday;
            chkTuesday.Checked          = BusinessClass.Tuesday;
            chkWednesday.Checked        = BusinessClass.Wednesday;
            chkThursday.Checked         = BusinessClass.Thursday;
            chkFriday.Checked           = BusinessClass.Friday;
            chkSaturday.Checked         = BusinessClass.Saturday;
            chkSunday.Checked           = BusinessClass.Sunday;
            txtLeadTime.Text            = BusinessClass.AdvLeadTime.ToString();

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
        private void SaveData()
        {
            BusinessClass.OwnerID               = ownerControl.OwnerID.Value;
            BusinessClass.SupplierCode          = txtSupplierCode.Text.Trim();
            BusinessClass.SupplierLongName      = txtLongName.Text.Trim();
            BusinessClass.SupplierAddress1      = txtAddress1.Text.Trim();
            BusinessClass.SupplierAddress2      = txtAddress2.Text.Trim();
            BusinessClass.SupplierNo            = txtSupplierNo.Text.Trim();
            BusinessClass.City                  = txtCity.Text.Trim();
            BusinessClass.StateOrProvince       = txtProvince.Text.Trim();
            BusinessClass.PostalCode            = txtPostalCode.Text.Trim();
            BusinessClass.Country               = txtCountry.Text.Trim();
            BusinessClass.MobileNo              = txtMobile.Text.Trim();
            BusinessClass.PhoneNo               = txtPhone.Text.Trim();
            BusinessClass.ArrivalLeadTime       = Int32.Parse(txtArrivalLT.Text.Trim());
            BusinessClass.ArrivalTime           = TimeSpan.Parse(txtArrivalTime.Text.Trim());
            BusinessClass.CollectTime           = TimeSpan.Parse(txtCollectTime.Text.Trim());
            BusinessClass.CreditTerm            = txtCreditTerm.Text;
            BusinessClass.DeliveryPlace         = txtDeliveryPlace.Text;
            BusinessClass.isCalVat              = chkCalculateVat.Checked;
            BusinessClass.VAT                   = !string.IsNullOrEmpty(txtCalculateVat.Text.Trim()) ? Decimal.Parse(txtCalculateVat.Text.Trim()) : (Decimal)0.00;
            BusinessClass.OwnerCode             = ownerControl.OwnerCode;
            BusinessClass.OwnerName             = ownerControl.Name;

            BusinessClass.Monday                = chkMonday.Checked;
            BusinessClass.Tuesday               = chkTuesday.Checked;
            BusinessClass.Wednesday             = chkWednesday.Checked;
            BusinessClass.Thursday              = chkThursday.Checked;
            BusinessClass.Friday                = chkFriday.Checked;
            BusinessClass.Saturday              = chkSaturday.Checked;
            BusinessClass.Sunday                = chkSunday.Checked;
            BusinessClass.AdvLeadTime           = DataUtil.Convert<int>(txtLeadTime.Text);

            if (txtKM.Text.Trim() != string.Empty)
            {
                //BusinessClass.KM = Convert.ToInt32(txtKM.Text.Trim());
                //BusinessClass.KM = txtKM.Text
                int val;
                if (Int32.TryParse(txtKM.EditValue.ToString(), out val))
                    BusinessClass.KM = val;
            }
            else {
                BusinessClass.KM = null;
            }
            
            BusinessClass.PhoneNo = txtPhone.Text.Trim();
            BusinessClass.Extension = txtExt.Text.Trim();
            BusinessClass.FaxNo = txtFax.Text.Trim();
            BusinessClass.EmailAddress = txtEmail.Text.Trim();
            BusinessClass.ContactName1 = txtContactName1.Text.Trim();
            BusinessClass.ContactName2 = txtContactName2.Text.Trim();
            BusinessClass.ContactName3 = txtContactName3.Text.Trim();
            BusinessClass.CreateUser = AppConfig.UserLogin;
            
            BusinessClass.SaveSupplierData();
        }
        private void clearControl()
        {
            ControlUtil.ClearControlData(txtSupplierCode
                                                    , txtSupplierNo
                                                    , txtLongName
                                                    , txtAddress1
                                                    , txtAddress2
                                                    , txtCity
                                                    , txtProvince
                                                    , txtCountry
                                                    , txtPostalCode
                                                    , txtKM
                                                    , txtMobile
                                                    , txtMobile
                                                    , txtPhone
                                                    , txtExt
                                                    , txtFax
                                                    , txtEmail
                                                    , txtContactName1
                                                    , txtContactName2
                                                    , txtContactName3
                                                    , txtCalculateVat);
            ownerControl.DataLoading();
        }
        public void ClearData()
        {
            errorProvider.ClearErrors();
            if (ScreenMode == Common.eScreenMode.Add)
            {
                clearControl();
            }
            else
            {
                DataBinding();
            }
        }
        #endregion

        
    }
}
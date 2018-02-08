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
using System.IO;
using System.Text.RegularExpressions;

namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS070_FinalDestination : DialogBase, Rubix.Framework.IClearable
    {
        #region Member
        String strFinalDestinationID = String.Empty;
        String strFinalDestinationCode = String.Empty;
        private FinalDestination db;
        private Common.eScreenMode eScrenMode;
        private Dialog.dlgXMSS070_FinalDestinationPicture m_Dialog;
        private FileStream fs;
        private Byte[] ImageByte = null;
        #endregion

        #region Properties
        public String FinalDestinationID 
        {
            get { return strFinalDestinationID; }
            set { strFinalDestinationID = value; }
        }
        public String FinalDestinationCode
        {
            get { return strFinalDestinationCode; }
            set { strFinalDestinationCode = value; }
        }
        public FinalDestination BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new FinalDestination();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new FinalDestination();
                }
                db = value;
            }
        }        
        public Common.eScreenMode ScreenMode
        {
            get { return eScrenMode; }
            set { eScrenMode = value; }
        }
        private Dialog.dlgXMSS070_FinalDestinationPicture Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgXMSS070_FinalDestinationPicture();
                }
                return m_Dialog;
            }
            set
            {
                m_Dialog = value;
            }
        }
        #endregion

        #region Constructor
        public dlgXMSS070_FinalDestination()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handler Function
        private void dlgXMSS070_FinalDestination_Load(object sender, EventArgs e)
        {
            if (ScreenMode == Common.eScreenMode.View)
            {
                ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
                ControlUtil.EnableControl(false, Controls);
                ControlUtil.EnableControl(true, btnViewImage);
            }
            else
            {
                ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);
            }

            if (ScreenMode == Common.eScreenMode.Edit)
            {
                ControlUtil.HiddenControl(true, m_toolBarSaveACopy);
                ControlUtil.EnableControl(true, btnViewImage, btnDelete);
            }
            else
            {
                ControlUtil.HiddenControl(true, m_toolBarSaveACopy);
            }

            if (ScreenMode == Common.eScreenMode.Add)
            {
                ControlUtil.EnableControl(false, btnViewImage, btnDelete);
                m_statusBarCreatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = AppConfig.UserLogin;
                m_statusBarUpdatedDate.Caption = "-";
                m_statusBarUpdatedUser.Caption = "-";
                ownerControl.DataLoading();
                clearControl();
                if (BusinessClass.FinalDestinationCode != null)
                {
                    BusinessClass = new FinalDestination();
                }
            }

            else
            {
                DataBinding();
            }
        }

        private void btnEditImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Imgage Files (*.gif,*.jpg,*.jpeg,*.tiff,*.bmp)|*.gif;*.jpg;*.jpeg;*.tiff;*.bmp";
            openFileDialog1.FileName = "";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog1.FileName);

                long filesize = fileInfo.Length;
                if (filesize >= 4194340)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0200"));
                    return;
                }
                fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                pictureBox1.Image = Image.FromStream(fs);
                btnViewImage.Enabled = true;
                btnDelete.Enabled = true;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            fs = null;
            pictureBox1.Image = null;
            btnViewImage.Enabled = false;
            btnDelete.Enabled = false;
            this.BusinessClass.ImageFile = null;
        }

        private void btnViewImage_Click(object sender, EventArgs e)
        {
            Dialog.Picture = pictureBox1.Image;
            Dialog.ShowDialog();
        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            customerControl.OwnerID = ownerControl.OwnerID;
            customerControl.DataLoading();
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            string FileName = string.Empty;

            try
            {
                if (MessageDialog.ShowConfirmationMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0047"),txtFinalDestLongName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        int? x = BusinessClass.FinalDestinationID;
                        if (x == 0) // Is Add Mode
                        {
                            if (BusinessClass.CheckExistFinalDestinationCode(txtFinalDestCode.Text.Trim(), ownerControl.OwnerID, customerControl.CustomerID))
                            // && (BusinessClass.FinalDestinationCode != txtFinalDestCode.Text.Trim())    
                            {
                                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0034"));
                                return false;
                            }
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
        public override bool OnCommandSaveACopy()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), txtFinalDestLongName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistFinalDestinationCode(txtFinalDestCode.Text.Trim(), ownerControl.OwnerID, customerControl.CustomerID))
                            //(BusinessClass.CheckExistFinalDestinationCode(txtFinalDestCode.Text.Trim()) && BusinessClass.FinalDestinationCode != txtFinalDestCode.Text.Trim())
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0034"));
                            return false;
                        }
                        BusinessClass.FinalDestinationID = 0;
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
            return base.OnCommandClear();
        }
        public override bool OnCommandClose()
        {
            BusinessClass.ImageFile = ImageByte;
            return base.OnCommandClose();
        }
        #endregion
        
        #region Generic Function
        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            ////FinalDestination Code
            if (txtFinalDestCode.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtFinalDestCode, Rubix.Screen.Common.GetMessage("I0032"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtFinalDestCode, String.Empty);
            }

            ////Customer Code
            ownerControl.RequireField = true;
            ownerControl.ErrorText = Rubix.Screen.Common.GetMessage("I0026");
            if (!ownerControl.ValidateControl())
            {
                errorProvider.SetError(ownerControl, Rubix.Screen.Common.GetMessage("I0026"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(ownerControl, String.Empty);
            }

            if (txtExchangeRate.EditValue == null)
            {
                errorProvider.SetError(txtExchangeRate, "Please Input Exchange Rate.");
                errFlag = false;
            }
            
            ////Supplier Name
            if (txtFinalDestLongName.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtFinalDestLongName, Rubix.Screen.Common.GetMessage("I0033"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtFinalDestLongName, String.Empty);
            }

            customerControl.RequireField = true;
            customerControl.ErrorText = Rubix.Screen.Common.GetMessage("I0249");
            if (!customerControl.ValidateControl())
            {
                errorProvider.SetError(customerControl, Rubix.Screen.Common.GetMessage("I0249"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(customerControl, String.Empty);
            }

            return errFlag;
        }

        private void DataBinding()
        {
            txtFinalDestCode.Text = BusinessClass.FinalDestinationCode;
            ownerControl.OwnerCode = BusinessClass.OwnerCode;
            txtFinalDestLongName.Text = BusinessClass.FinalDestinationLongName;
            memFinalDestDetail.Text = BusinessClass.FinalDestinationDetail;
            memAddress.Text = BusinessClass.FinalDestinationAddress;
            txtCity.Text = BusinessClass.City;
            txtProvince.Text = BusinessClass.StateOrProvince;
            txtCountry.Text = BusinessClass.Country;
            txtPostalCode.Text = BusinessClass.PostalCode;
            txtKM.Text = BusinessClass.KM.ToString();
            txtMobile.Text = BusinessClass.MobileNo;
            txtPhone.Text = BusinessClass.PhoneNo;
            txtExt.Text = BusinessClass.Extension;
            txtFax.Text = BusinessClass.FaxNo;
            txtContactName1.Text = BusinessClass.ContactName1;
            txtContactName2.Text = BusinessClass.ContactName2;
            txtContactName3.Text = BusinessClass.ContactName3;
            txtLeadTimeD.Text = BusinessClass.LeadTimeDays.ToString();
            txtLeadTimeH.Text = BusinessClass.LeadTimeHr;
            memoEdit1.Text = BusinessClass.Remark;
            txtExchangeRate.EditValue = BusinessClass.Rate;

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

            customerControl.CustomerID = BusinessClass.CustomerID;

            //Bind Image
            pictureBox1.Image = ControlUtil.ConvertByteToImage(BusinessClass.ImageFile);
            ImageByte = BusinessClass.ImageFile;

            if (BusinessClass.ImageFile == null)
            {
                ControlUtil.EnableControl(false, btnViewImage, btnDelete);
            }
        }

        private void SavaData()
        {   
            BusinessClass.FinalDestinationCode = txtFinalDestCode.Text.Trim();
            BusinessClass.OwnerID = ownerControl.OwnerID.Value;
            BusinessClass.OwnerCode = ownerControl.OwnerCode;
            BusinessClass.OwnerName = ownerControl.OwnerName;            
            BusinessClass.FinalDestinationLongName = txtFinalDestLongName.Text.Trim();
            BusinessClass.FinalDestinationDetail = memFinalDestDetail.Text.Trim();
            BusinessClass.FinalDestinationAddress = memAddress.Text.Trim();
            BusinessClass.City = txtCity.Text.Trim();
            BusinessClass.StateOrProvince = txtProvince.Text.Trim();
            BusinessClass.Country = txtCountry.Text.Trim();
            BusinessClass.PostalCode = txtPostalCode.Text;
            BusinessClass.CustomerID = customerControl.CustomerID;
            BusinessClass.CustomerCode = customerControl.CustomerCode;
            BusinessClass.CustomerName = customerControl.CustomerName;
            
                
            BusinessClass.KM = DataUtil.Convert<int>(txtKM.Text.Trim());
            BusinessClass.MobileNo = txtMobile.Text;
            BusinessClass.PhoneNo = txtPhone.Text;
            BusinessClass.Extension = txtExt.Text;
            BusinessClass.FaxNo = txtFax.Text;
            BusinessClass.ContactName1 = txtContactName1.Text;
            BusinessClass.ContactName2 = txtContactName2.Text;
            BusinessClass.ContactName3 = txtContactName3.Text;
            BusinessClass.Rate = DataUtil.Convert<decimal>(txtExchangeRate.EditValue);
           
            BusinessClass.LeadTimeDays = DataUtil.Convert<int>(txtLeadTimeD.Text);
          
            BusinessClass.LeadTimeHr = txtLeadTimeH.Text;
            BusinessClass.Remark = memoEdit1.Text;
            BusinessClass.CreateUser = AppConfig.UserLogin;
            BusinessClass.ImageFile = ControlUtil.ConvertImageByte(pictureBox1.Image);

            BusinessClass.SaveFinalDestinationData();
        }

        private void clearControl()
        {
            ControlUtil.ClearControlData(txtFinalDestCode
                                                    , txtFinalDestLongName
                                                    , memFinalDestDetail
                                                    , memAddress
                                                    , txtCity
                                                    , txtProvince
                                                    , txtCountry
                                                    , txtPostalCode
                                                    , txtKM
                                                    , txtMobile
                                                    , txtPhone
                                                    , txtExt
                                                    , txtFax
                                                    , txtContactName1
                                                    , txtContactName2
                                                    , txtContactName3
                                                    , txtLeadTimeD
                                                    , txtLeadTimeH
                                                    , memoEdit1
                                                    );
            customerControl.ClearData();
            pictureBox1.Image = null;
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
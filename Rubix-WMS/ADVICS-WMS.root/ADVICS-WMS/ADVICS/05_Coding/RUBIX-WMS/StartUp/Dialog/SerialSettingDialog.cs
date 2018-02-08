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
using System.Data.SqlClient;
using System.Configuration;
using Rubix.Screen;

namespace Rubix.ScreenMaster.Dialog
{
    public partial class SerialSettingDialog : DialogBase
    {
        #region Member
        CSI.Business.Admin.UserMaintenance _UserMaintenance = null;
        #endregion

        #region Constructor
        public SerialSettingDialog()
        {
            InitializeComponent();
            m_statusBar.Visible = false;
            
        } 
        #endregion

        #region Properties
        private CSI.Business.Admin.UserMaintenance Database
        {
            get 
            {
                if (_UserMaintenance == null)
                {
                    _UserMaintenance = new CSI.Business.Admin.UserMaintenance();
                }
                return _UserMaintenance;
            }
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this, CSI.Business.BusinessCommon.GetMessage(AppConfig.Locale, "I0337", "Do you want to save this serial key?")) == DialogButton.Yes)
                {
                    
                    if (ValidateData())
                    {
                        ShowWaitScreen();

                        string md5Serial = DataUtil.MD5Encrypt(txtSerial.Text.Trim());
                        string md5Mainboard = DataUtil.MD5Encrypt(DataUtil.GetMainboardSerialNumber());

                        bool bStatus = Database.CheckActivateSerial(DataUtil.MD5Encrypt(txtSerial.Text.Trim()));
                        if (bStatus)
                        {
                            if (Database.RegisterMachine(md5Serial, md5Mainboard))
                            {

                                DataUtil.WriteRegisterSerialNumber(txtSerial.Text.Trim());

                                   
                                CloseWaitScreen();
                                MessageDialog.ShowInformationMsg(CSI.Business.BusinessCommon.GetMessage(AppConfig.Locale, "I0338", "Save Serial Key complete."));
                                this.Close();
                            }
                            else
                            {
                                CloseWaitScreen();
                                MessageDialog.ShowBusinessErrorMsg(this, CSI.Business.BusinessCommon.GetMessage(AppConfig.Locale, "I0339", "Can't register"));
                            }
                        }
                        else
                        {
                            CloseWaitScreen();
                            MessageDialog.ShowBusinessErrorMsg(this, CSI.Business.BusinessCommon.GetMessage(AppConfig.Locale, "I0340", "Invalid or maximum registration of this Serial key"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }

            return true;
        }
        public override bool OnCommandClear()
        {
            txtSerial.Text = string.Empty;
            return true;
        }
        public override bool OnCommandClose()
        {
            return true;
        }
        #endregion

        #region Event Handler
        private void SerialSettingDialog_Load(object sender, EventArgs e)
        {
            txtSerial.Text = string.Empty;
        }
        #endregion

        #region Genneric Function
        private bool ValidateData()
        {
            errorProvider.ClearErrors();
            bool validate = true;

            if (string.IsNullOrWhiteSpace(txtSerial.Text))
            {
                errorProvider.SetError(txtSerial, CSI.Business.BusinessCommon.GetMessage(AppConfig.Locale, "I0336", "Please input Serial key."));
                validate = false;
            }
            else
            {
                errorProvider.SetError(txtSerial, string.Empty);
                validate = true;
            }
            return validate;
        }
        #endregion

    }
}
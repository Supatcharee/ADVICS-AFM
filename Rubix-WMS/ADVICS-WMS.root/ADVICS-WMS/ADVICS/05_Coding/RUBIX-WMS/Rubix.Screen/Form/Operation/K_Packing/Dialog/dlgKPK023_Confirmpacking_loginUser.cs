using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Rubix.Framework;
using System.Net;
using System.Net.NetworkInformation;

namespace Rubix.Screen.Form.Operation.K_Packing.Dialog
{
    public partial class dlgKPK023_Confirmpacking_loginUser : SubDialogBase
    {

        #region Member
        private string _userLogin;
        private string _machineIP;
        #endregion

        #region Properties
        public string UserLogin
        {
            get { return _userLogin; }
            set { _userLogin = value;}
        }

        public string MachineIP
        {
            get { return _machineIP; }
            set { _machineIP = value; }
        }
        #endregion

        #region Constructor
        public dlgKPK023_Confirmpacking_loginUser()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarCancel);
        }


        #endregion

        #region Override Method
        public override bool OnCommandOK()
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
                return false;
            }
        }


        #endregion

        #region Event Handler
        private void txtQRCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtQRCode.Enabled && !string.IsNullOrEmpty(txtQRCode.Text) && e.KeyChar == (char)Keys.Enter)
            {
                if (txtQRCode.Text == "confirm")
                {
                    if (!string.IsNullOrEmpty(UserLogin))
                    {
                        UserLogin = UserLogin.Remove(UserLogin.Length - 3);
                        setMachineIP();
                        OnCommandOK();
                    }
                    else
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, "No User Logon");
                    }
                }
                else
                {
                    if (!UserLogin.Contains(txtQRCode.Text))
                    {
                        UserLogin += txtQRCode.Text + "#|#";
                    }
                    else
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, "Duplicate Logon User");
                    }
                    
                }
                txtQRCode.Text = string.Empty;
                txtQRCode.Focus();
            }
        }

        private void dlgKPK023_Confirmpacking_loginUser_Load(object sender, EventArgs e)
        {
            UserLogin = "";
            MachineIP = "";
            txtQRCode.Focus();
        }

        #endregion


        #region Generic Function
        public void setMachineIP()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet && nic.OperationalStatus == OperationalStatus.Up)
                {
                    MachineIP = nic.GetPhysicalAddress().ToString();
                }
            }         
        }
        #endregion

    }
}

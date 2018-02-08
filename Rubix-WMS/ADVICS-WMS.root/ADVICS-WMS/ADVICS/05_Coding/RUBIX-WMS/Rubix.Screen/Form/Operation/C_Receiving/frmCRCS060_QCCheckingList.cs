using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSI.Business.Operation;
using Rubix.Framework;
using CSI.Business.Master;
using CSI.Business.DataObjects;
using System.Diagnostics;

namespace Rubix.Screen.Form.Operation.C_Receiving
{
   [ScreenPermissionAttribute(Permission.OpenScreen)]
    public partial class frmCRCS060_QCCheckingList : FormBase
    {
        #region Member
       string strRMTag = string.Empty;
       private int iConfirmCommand = 0;  //0 = OK Common; 1 = Restart; 2 = Shutdown;
       private Product _dbProduct = null;
        #endregion

        #region Properties
       public Product ProductBusinessClass
       {
           get
           {
               if (_dbProduct == null)
                   _dbProduct = new Product();
               return _dbProduct;
           }
           set
           {
               _dbProduct = value;
           }
       }
        #endregion

        #region Constructor
       public frmCRCS060_QCCheckingList()
        {
            InitializeComponent();
        } 
        #endregion

        #region Override Method

        #endregion
        
        #region Event Handler
       private void frmCRCS060_QCCheckingList_Load(object sender, EventArgs e)
        {
            try
            {
                ControlUtil.HiddenControl(true, m_toolBar);
                lblErrorMessage.Text = string.Empty;
                timer1.Enabled = true;
            }
            catch (Exception ex) 
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
       
       private void frmCRCS060_QCCheckingList_KeyPress(object sender, KeyPressEventArgs e)
       {
           try
           {
               if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(strRMTag))
               {                 
                   String QRCode = strRMTag;
                   if (!ValidateQRCode(QRCode))
                   {
                       picQCPicture.Image = null;
                       lblErrorMessage.Text = Rubix.Screen.Common.GetMessage("I0403");
                       strRMTag = string.Empty;
                       return;
                   }                  

                   if (QRCode.Split('-').Length == 2)
                   {
                       picQCPicture.Image = null;
                       CommandFunction();
                       strRMTag = string.Empty;
                       return;
                   }

                   ThisShowWaitScreen();

                   //0 = PO No.
                   //1 = PDS No.
                   //2 = Running No. --> 00001
                   //3 = Supplier Code
                   //4 = Item No.
                   //5 = Item Short Code
                   //6 = Qty level 3
                   //7 = Collect Date

                   String[] QRData = QRCode.Split(':');

                   byte[] imageByte = ProductBusinessClass.LoadQCImage(QRData[4]);
                   picQCPicture.Image = ControlUtil.ConvertByteToImage(imageByte);
                   strRMTag = string.Empty;
               }
               else
               {
                   strRMTag = strRMTag + e.KeyChar.ToString();
                   lblErrorMessage.Text = string.Empty;
               }
           }
           catch (Exception ex)
           {
               picQCPicture.Image = null;
               MessageDialog.ShowSystemErrorMsg(this, ex);
           }
           finally
           {
               ThisCloseWaitScreen();
           }
       }

       private void timer1_Tick(object sender, EventArgs e)
       {
           this.Focus();
           timer1.Enabled = false;
       }
        #endregion
       
        #region Generic Function
        private bool ValidateQRCode(string QRCode)
        {
            bool isValid = false;
            string[] QRData = QRCode.Split(':');
            string[] QRCommand = QRCode.Split('-');
            if (QRData.Length == 8 || QRCommand.Length == 2)
            {
                isValid = true;
            }
            return isValid;
        }

        private void CommandFunction()
        {
            if (strRMTag.Equals("PCI-SF02")) //OK
            {
                if (iConfirmCommand == 1)
                {
                    Process.Start("shutdown", "/r /t 0");
                    // the argument /r is to restart the computer
                }
                else if (iConfirmCommand == 2)
                {
                    Process.Start("shutdown", "/s /t 0");
                    // starts the shutdown application 
                    // the argument /s is to shut down the computer
                    // the argument /t 0 is to tell the process that 
                    // the specified operation needs to be completed 
                    // after 0 seconds
                }
            }
            else if (strRMTag.Equals("PCI-F12"))
            {
                base.OnLogout();
            }
            else if (strRMTag.Equals("PCI-F20"))
            {
                base.OnLogout();
            }
            else if (strRMTag.Equals("PCI-F30"))
            {
                lblErrorMessage.Text = Rubix.Screen.Common.GetMessage("I0429");
                iConfirmCommand = 1; //restart               
            }
            else if (strRMTag.Equals("PCI-F40"))
            {
                lblErrorMessage.Text = Rubix.Screen.Common.GetMessage("I0429");
                iConfirmCommand = 2; //shutdown
            }
        }

        protected void ThisShowWaitScreen()
        {
            if (!splashScreenManager.IsSplashFormVisible)
            {
                splashScreenManager.ShowWaitForm();
                splashScreenManager.SetWaitFormCaption(Common.GetMessage("A0002"));
                splashScreenManager.SetWaitFormDescription(Common.GetMessage("A0003"));
            }
        }

        protected void ThisCloseWaitScreen()
        {
            if (splashScreenManager.IsSplashFormVisible)
            {
                splashScreenManager.CloseWaitForm();
            }
        }
        #endregion

    }
}
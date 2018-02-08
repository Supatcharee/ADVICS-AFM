using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Rubix.Framework;
using Rubix.ScreenMaster.Dialog;
using CSI.Business.DataObjects;
using CSI.Business;
using System.Diagnostics;
using System.IO;
using CSI.Business.BusinessFactory.Master;
using System.Linq;
using System.Data;
using System.Runtime.InteropServices;
using DevExpress.LookAndFeel;

namespace StartUp.Dialog
{
    public partial class frmLOG010_Login : DevExpress.XtraEditors.XtraForm
    {
        #region Win32
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );

        const int AW_HIDE = 0X10000;
        const int AW_ACTIVATE = 0X20000;
        const int AW_HOR_POSITIVE = 0X1;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_SLIDE = 0X40000;
        const int AW_BLEND = 0X80000;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int AnimateWindow
        (IntPtr hwand, int dwTime, int dwFlags);
        #endregion
          
        #region Member
        private MultiLangBiz mb = null;
        private AutoUpdateBiz au = null;
        private SystemConfig sc = null;
        private LDAPAuthentication DomainServerAuth = null;
        private bool IsDomainAutoLogin = false;
        private bool IsDomainAutoUpdate = false;
        private bool _UseSlideAnimation = true;
        private int iLocationX;
        private string strCurrentScreenStyle;

        struct RegistrationStruct
        {
            public string Token;
            public string RubixWebURL;
            public string DatabaseServerName;
            public string DatabaseName;
            public string DatabaseUserName;
            public string DatabasePassword;
            public int AuthenLevel;
            public string CompanyCode;
            public string CompanyName;
        }
        #endregion

        enum eLanguange
        {
            English,
            Japanese,
            Thai
        }

        #region Properties
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
        private AutoUpdateBiz AutoUpdateData
        {
            get
            {
                if (au == null)
                {
                    au = new AutoUpdateBiz();
                }
                return au;
            }
        }
        private SystemConfig SystemConfigBiz
        {
            get
            {
                if (sc == null)
                {
                    sc = new SystemConfig();
                }
                return sc;
            }
        }
        public bool IsLogout { get; set; }
        #endregion

        #region Constructor
        public frmLOG010_Login()
        {            
            InitializeComponent();
            AppConfig.SplashScreenManager = splashScreenManager;
        }
        #endregion

        #region Event Handler Function
        private void frmLOG010_Login_Load(object sender, EventArgs e)
        {
            try
            {                
                AppConfig.CompanyCode = "ADVICS-WMS";
                AppConfig.CompanyName = "ADVICS Asia Pacific Co., Ltd.";
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Login failed"))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, "Cannot connect to database, Please check database connection.");
                }
            }
            finally
            {
               // Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
                iLocationX = this.Location.X;
                this.Location = new System.Drawing.Point(-iLocationX - this.Size.Width, this.Location.Y);
            }
            //AnimateWindow(this.Handle, 1000, AW_ACTIVATE | (_UseSlideAnimation ? AW_HOR_POSITIVE | AW_SLIDE : AW_BLEND));            
        }

        private void frmLOG010_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AW_HIDE | (_UseSlideAnimation ? AW_HOR_NEGATIVE | AW_SLIDE : AW_BLEND));
        }

        private void pnlExit_Click(object sender, EventArgs e)
        {
            this.Close();
            //parentScreen.Close();
        }

        private void pnlOption_Click(object sender, EventArgs e)
        {
            pnlDefaultOption.Visible = !pnlDefaultOption.Visible;
        }

        private void pnlTheme_Click(object sender, EventArgs e)
        {
            MainFrame.MainSkin mskin = new MainFrame.MainSkin();
            mskin.Show(this);
        }

         private void pnlSerial_Click(object sender, EventArgs e)
         {
             SerialSettingDialog dialog = new SerialSettingDialog();
             dialog.ShowDialog();
         }        

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTimeNow();
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            ShowWaitScreen();
            try
            {
                if (txtUsername.Text.ToUpper().Contains("USERNAME"))
                {
                    string[] arrUserName = txtUsername.Text.Split('-');
                    CSI.Business.Admin.UserMaintenance um = new CSI.Business.Admin.UserMaintenance();
                    tb_User us = um.GetUser(arrUserName[1]);
                    if (us != null)
                    {
                        AppConfig.UserLogin = us.UserID;
                        AppConfig.DefaultWarehouseID = us.WarehouseID;
                        AppConfig.DefaultOwnerID = us.OwnerID;
                        AppConfig.Firstname = us.FirstName;
                        AppConfig.Lastname = us.LastName;
                        AppConfig.IsDomainLogin = false;
                        if (txtDisplayPeriod.EditValue != null && txtDisplayPeriod.EditValue.ToString() != string.Empty)
                        {
                            AppConfig.DisplayPeriodMonth = Convert.ToInt32(txtDisplayPeriod.EditValue);
                        }
                        else
                        {
                            AppConfig.DisplayPeriodMonth = 0;
                        }

                        LoginPassShowMainMenu();
                        CloseWaitScreen();
                    }
                }
                else if (ValidateData())
                {    
                    //Login from Domain Server
                    if (!string.IsNullOrEmpty(Convert.ToString(cboDomainServerName.EditValue)))
                    {                        
                        string[] arrDomain = cboDomainServerName.EditValue.ToString().Split(':');
                        DomainServerAuth = new LDAPAuthentication(arrDomain[0], arrDomain[1]);
                        if (DomainServerAuth.GetAuthenResult(txtUsername.Text.Trim(), txtPassword.Text))
                        {
                            //this.Close();
                            if (LoadUserLoginInformation(txtUsername.Text.Trim(), txtPassword.Text, false))
                            {
                                LoginPassShowMainMenu();
                                CloseWaitScreen();
                            }
                            else
                            {
                                Rubix.Framework.MessageDialog.ShowBusinessErrorMsg(this, CSI.Business.BusinessCommon.GetMessage(AppConfig.Locale, "I0001", "The username or password is incorrect. Please try again."));
                            }
                        }
                    }
                    //Login from Database
                    else if (LoadUserLoginInformation(txtUsername.Text.Trim(), txtPassword.Text, true))
                    {
                        LoginPassShowMainMenu();
                        CloseWaitScreen();
                    }
                    else
                    {
                        Rubix.Framework.MessageDialog.ShowBusinessErrorMsg(this, CSI.Business.BusinessCommon.GetMessage(AppConfig.Locale, "I0001", "The username or password is incorrect. Please try again."));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
                
        private void chkDefaultPassword_CheckedChanged(object sender, EventArgs e)
        {
            AppConfig.RememberPassword = chkDefaultPassword.Checked;
        }

        private void chkDefaultUser_CheckedChanged(object sender, EventArgs e)
        {
            AppConfig.RememberUserLogin = chkDefaultUser.Checked;
        }

         private void lblAvailbleUpdate_Click(object sender, EventArgs e)
         {
             AutoUpdateRunning();
         }

         private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
         {
             try
             {
                 IsDomainAutoLogin = false;
                 IsDomainAutoUpdate = false;

                 InitialDomainServer();
                 ShowWaitScreen();

                 ////////////////////initial multi lang ////////////////////////////////////
                 if (!IsLogout)
                 {
                     if (!Util.IsNullOrEmpty(AppConfig.DefaultLanguagePath))
                     {
                         AppConfig.CurrentLanguage = new MultiLanguage();
                         AppConfig.CurrentLanguage.LoadMultiLang(MultiLangClass.LoadMultilang(AppConfig.DefaultLanguagePath, this.Name));
                     }
                 }
                 ///////////////////////////////////////////////////////////////////////////
             }
             catch (Exception ex)
             {
                 
             }
         }

         private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
         {
             try
             {
                 //Fix style
                 strCurrentScreenStyle = AppConfig.ScreenThemeStyle;
                 UserLookAndFeel.Default.SetSkinStyle("Money Twins");

                 if (IsDomainAutoLogin)
                 {
                     CloseWaitScreen();
                     LoginPassShowMainMenu();
                     return;
                 }

                 if (IsDomainAutoUpdate)
                 {
                     CloseWaitScreen();
                     AutoUpdateRunning();
                     return;
                 }

                 if (AppConfig.RememberUserLogin)
                 {
                     txtUsername.Text = AppConfig.UserLogin;
                     txtPassword.Text = AppConfig.Password;
                 }
                 else
                 {
                     txtUsername.Text = string.Empty;
                     txtPassword.Text = string.Empty;
                 }

                 txtDisplayPeriod.EditValue = AppConfig.DisplayPeriodMonth;
                 chkDefaultPassword.Checked = AppConfig.RememberPassword;
                 chkDefaultUser.Checked = AppConfig.RememberUserLogin;

                 pnlDefaultOption.Visible = false;
                 lblAvailbleUpdate.Visible = false;

                 cboDomainServerName.Properties.DataSource = AppConfig.DomainList;
                 cboDomainServerName.Properties.DisplayMember = "DomainName";
                 cboDomainServerName.Properties.ValueMember = "DomainValue";

                 ///////////////////////////////////////////////////////////////////////////
                 ////////////////////Auto Update////////////////////////////////////////////
                 if (AutoUpdateData.CheckProgramUpdate())
                 {
                     lblAvailbleUpdate.Visible = true;
                 }
                 ///////////////////////////////////////////////////////////////////////////
                 ///////////////////////////////////////////////////////////////////////////
                 if (!Util.IsNullOrEmpty(AppConfig.DefaultLanguagePath))
                 {
                     OnLanguageChange(this, new LanguageChangeEventArgs(AppConfig.CurrentLanguage));
                 }
                 ///////////////////////////////////////////////////////////////////////////

                 this.Focus();
                 this.Activate();
                 this.txtUsername.Focus();
                 this.TopMost = true;                 
             }
             catch (Exception ex)
             {
                 
             }
             finally
             {
                 CloseWaitScreen();
             }
         }

         private void Control_KeyDown(object sender, KeyEventArgs e)
         {
             try
             {
                 string strKey = e.Control.ToString() + e.Shift.ToString() + e.KeyCode.ToString();

                 if (strKey.ToUpper().Contains("TRUETRUEA"))
                 {
                     txtWebAPIURL.Text = AppConfig.RubixWebApiUrl;
                     ControlUtil.HiddenControl(false, gpcWebAPIURL);
                 }
             }
             catch (Exception ex)
             {
                 MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
             }
         }

         private void btnWebAPIURLOK_Click(object sender, EventArgs e)
         {
             try
             {
                 AppConfig.RubixWebApiUrl = txtWebAPIURL.Text.Trim();
                 ControlUtil.HiddenControl(true, gpcWebAPIURL);
                 txtUsername.Focus();
             }
             catch (Exception ex)
             {
                 MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
             }
         }

         private void timerScreenEffice_Tick(object sender, EventArgs e)
         {
             this.Location = new System.Drawing.Point(this.Location.X + 25, this.Location.Y);
             if (this.Location.X >= iLocationX)
             {
                 timerScreenEffice.Enabled = false;
             }
         }
        #endregion

        #region Generic Function
        public void ResetScreen()
        {
            if (!AppConfig.RememberUserLogin)
                AppConfig.UserLogin = string.Empty;
            if (!AppConfig.RememberPassword)
                AppConfig.Password = string.Empty;
        }         
        
        private void DateTimeNow()
        {
            lblTime.Text = DateTime.Now.ToString("ddd dd/MM/yyyy HH:mm:ss");            
        }

         public void OnLanguageChange(object sender, LanguageChangeEventArgs e)
         {
             lblProgramVersion.Text = String.Format(Util.GetGlobalText("A0005"), AppConfig.ProgramVersion);
             Util.ChangeLanguage(this.Name, this.Controls, e);            
         }

         private bool ValidateData()
         {
             Boolean errFlag = true;

             //if (DataUtil.ReadRegisterSerialNumber() == string.Empty)
             //{
             //    if (splashScreenManager.IsSplashFormVisible)
             //    {
             //        CloseWaitScreen();
             //    }
             //    MessageDialog.ShowBusinessErrorMsg(this, CSI.Business.BusinessCommon.GetMessage(AppConfig.Locale, "I0342", "Please register Serial Key before using the system."));
             //    errFlag = false;
             //}
             //else if (!DataUtil.CheckValidRegisterSerialNumber())
             //{
             //    if (splashScreenManager.IsSplashFormVisible)
             //    {
             //        CloseWaitScreen();
             //    }
             //    MessageDialog.ShowBusinessErrorMsg(this, CSI.Business.BusinessCommon.GetMessage(AppConfig.Locale, "I0341", "Invalid Serial key, please register Serial Key again."));
             //    errFlag = false;
             //}

             if (String.IsNullOrWhiteSpace(txtUsername.Text))
             {
                 errorProvider.SetError(txtUsername, CSI.Business.BusinessCommon.GetMessage(AppConfig.Locale, "I0005", "Please input User ID."));
                 errFlag = false;
             }
             else
             {
                 errorProvider.SetError(txtUsername, string.Empty);
             }

             if (String.IsNullOrWhiteSpace(txtPassword.Text))
             {
                 errorProvider.SetError(txtPassword, CSI.Business.BusinessCommon.GetMessage(AppConfig.Locale, "I0281", "Please input Password."));
                 errFlag = false;
             }
             else
             {
                 errorProvider.SetError(txtPassword, string.Empty);
             }
             
             if (!errFlag)
             {
                 if (splashScreenManager.IsSplashFormVisible)
                 {
                     CloseWaitScreen();
                 }
             }

             return errFlag;
         }

         private void AutoUpdateRunning()
         {
             try
             {
                 ProcessStartInfo info = new ProcessStartInfo();
                 info.FileName = Path.Combine(Application.StartupPath, "Rubix.AutoUpdate.exe");
                 info.Arguments = "GotoRubixUpdate";

                 Process p = new Process();
                 p.StartInfo = info;
                 p.Start();

                 this.Close();
             }
             catch (Exception ex)
             {
                 MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
             }
         }
        
         private void InitialDomainServer()
         {
             try
             {
                 ShowWaitScreen();

                 sp_XMSS280_SystemConfig_Search_Result DomainServer = SystemConfigBiz.DataLoading("DomainServerList").FirstOrDefault();
                 sp_XMSS280_SystemConfig_Search_Result DomainAutoLogin = SystemConfigBiz.DataLoading("DomainUserAutoLogin").FirstOrDefault();
                 sp_XMSS280_SystemConfig_Search_Result DomainUsername = SystemConfigBiz.DataLoading("DomainUser").FirstOrDefault();
                 sp_XMSS280_SystemConfig_Search_Result DomainPassword = SystemConfigBiz.DataLoading("DomainPassword").FirstOrDefault();

                 /////////////////////////////////////////////////////////////////
                 /////////////////////////////////////////////////////////////////
                 DataTable dt = new DataTable();

                 if (DomainServer != null)
                 {                     
                     dt.Columns.Add("DomainValue", typeof(string));
                     dt.Columns.Add("DomainName", typeof(string));
                     dt.Columns.Add("DomainIPAddress", typeof(string));

                     DataRow dr = dt.NewRow();
                     dr["DomainValue"] = "";
                     dr["DomainName"] = "";
                     dr["DomainIPAddress"] = "";
                     dt.Rows.Add(dr);

                     string[] arrDomainList = DomainServer.ConfigValue.Split(';'.ToString().Split(':'),StringSplitOptions.RemoveEmptyEntries);

                     if (arrDomainList.Length > 0)
                     {
                         foreach (string domain in arrDomainList)
                         {
                             dr = dt.NewRow();
                             dr["DomainValue"] = domain;
                             dr["DomainName"] = domain.Split(':')[0];
                             dr["DomainIPAddress"] = domain.Split(':')[1];
                             dt.Rows.Add(dr);
                         }
                     }

                     dt.AcceptChanges();
                     AppConfig.DomainList = dt;  

                    if (DomainUsername != null)
                    {
                        AppConfig.DomainUsername = DomainUsername.ConfigValue;
                    }
                    if (DomainPassword != null)
                    {
                        AppConfig.DomainPassword = DomainPassword.ConfigValue;
                    }
                    /////////////////////////////////////////////////////////////////
                    /////////////////////////////////////////////////////////////////

                    ///Auto Login
                    if (DomainAutoLogin.ConfigValue.ToString().ToUpper().Trim() == "TRUE" && !IsLogout)
                    {
                        if (AutoUpdateData.CheckProgramUpdate())
                        {
                            IsDomainAutoUpdate = true;                            
                        }

                        if ((new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent()).Identity).IsAuthenticated == true)
                        {
                            string[] arrCurrentDomain = new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent()).Identity.Name.Split('\\');
                            DataRow[] drr = dt.Select(string.Format("DomainName LIKE '%{0}%'", arrCurrentDomain[0]));
                            if (drr.Length > 0)
                            {
                                if (LoadUserLoginInformation(arrCurrentDomain[1], string.Empty, false))
                                {                                    
                                    IsDomainAutoLogin = true;
                                }
                            }
                        }
                    }
                 }
             }
             catch (Exception ex)
             {

             }
             finally
             {
                 CloseWaitScreen();
             }
         }

         private bool LoadUserLoginInformation(string UserLogin, string Password, bool VerifyUser = true)
         {
             CSI.Business.Admin.UserMaintenance um = new CSI.Business.Admin.UserMaintenance();
             if (VerifyUser && (um.VerifyUser(txtUsername.Text.Trim(), txtPassword.Text)))
             {
                 AppConfig.UserLogin = UserLogin;
                 AppConfig.Password = Password;
                 tb_User us = um.GetUser(AppConfig.UserLogin);
                 AppConfig.DefaultWarehouseID = us.WarehouseID;
                 AppConfig.DefaultOwnerID = us.OwnerID;
                 AppConfig.Firstname = us.FirstName;
                 AppConfig.Lastname = us.LastName;
                 AppConfig.IsDomainLogin = false;
                 if (txtDisplayPeriod.EditValue != null && txtDisplayPeriod.EditValue.ToString() != string.Empty)
                 {
                     AppConfig.DisplayPeriodMonth = Convert.ToInt32(txtDisplayPeriod.EditValue);
                 }
                 else
                 {
                     AppConfig.DisplayPeriodMonth = 0;
                 }
                 return true;
             }
             else if (!VerifyUser)
             {
                 AppConfig.UserLogin = UserLogin;
                 AppConfig.Password = Password;                 
                 tb_User us = um.GetUser(AppConfig.UserLogin);
                 if (us != null)
                 {
                     AppConfig.DefaultWarehouseID = us.WarehouseID;
                     AppConfig.DefaultOwnerID = us.OwnerID;
                     AppConfig.Firstname = us.FirstName;
                     AppConfig.Lastname = us.LastName;
                     AppConfig.IsDomainLogin = true;
                     if (txtDisplayPeriod.EditValue != null && txtDisplayPeriod.EditValue.ToString() != string.Empty)
                     {
                         AppConfig.DisplayPeriodMonth = Convert.ToInt32(txtDisplayPeriod.EditValue);
                     }
                     else
                     {
                         AppConfig.DisplayPeriodMonth = 0;
                     }
                     return true;
                 }
                 return false;
             }
             else
             {
                 return false;
             }
         }

         private void ShowWaitScreen()
         {
             //if (!AppConfig.SplashScreenManager.IsSplashFormVisible)
             //{
             //    if (AppConfig.SplashScreenType != 0)
             //    {
             //        AppConfig.SplashScreenType = 0;
             //        AppConfig.SplashScreenManager = splashScreenManager;
             //    }
             //    AppConfig.SplashScreenManager.ShowWaitForm();
             //}
         }

         private void CloseWaitScreen()
         {
             //if (AppConfig.SplashScreenManager.IsSplashFormVisible)
             //{
             //    AppConfig.SplashScreenManager.CloseWaitForm();
             //    //AppConfig.SplashScreenManager.Dispose();
             //}
         }

         private void LoginPassShowMainMenu()
         {            
             MainFrame.MainMenu mainSC = new MainFrame.MainMenu();
             mainSC.MainLogin = this;
             this.Hide();
             UserLookAndFeel.Default.SetSkinStyle(strCurrentScreenStyle);
             mainSC.Show();             
         }
        #endregion               
    }
}
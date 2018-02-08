using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.Reflection;
using Rubix.Framework;
using CSI.Business.Admin;
using CSI.Business.DataObjects;
using CSI.Business;
using CSI.Business.Common;
using DevExpress.XtraNavBar;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraEditors.Controls;
using Rubix.Screen;
using System.Threading;
using System.Globalization;

namespace StartUp.MainFrame
{
    public partial class MainMenu : XtraForm, ILogoutable
    {
        #region Member
        private StartUp.Dialog.frmLOG010_Login ml;
        private SecurityMapping db = null;
        private MultiLangBiz mb = null;
        private LastestDaily ld = null;
        private bool isClose = true;
        private TreeListHitInfo tlHit;
        public MultiLanguage CurrentLanguage { get { return AppConfig.CurrentLanguage; } set { AppConfig.CurrentLanguage = value; } }
        private NavBarGroupEventArgs nbgActive;
        #endregion

        enum eLanguange
        {
            English,
            Japanese,
            Thai
        }

        #region Properties
        private SecurityMapping BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new SecurityMapping();
                }
                return db;
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
        public StartUp.Dialog.frmLOG010_Login MainLogin
        {
            get { return ml; }
            set { ml = value; }
        }
        private LastestDaily LastestDailyBiz
        {
            get
            {
                if (ld == null)
                {
                    ld = new LastestDaily();
                }
                return ld;
            }
        }
        private DataTable ListMenuDataTable { get; set; }
        #endregion

        #region Constructor
        public MainMenu()
        {
            InitializeComponent();         
                   
            //Hidden right click menu on main menu
            dockManager1.PopupMenuShowing += (s, e) => e.Cancel = true;

            AppConfig.LastestDailyPost = bsLastestDailyPost;

            Thread.CurrentThread.CurrentCulture = new CultureInfo(AppConfig.Locale);
            CultureInfo standardizedCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            standardizedCulture.DateTimeFormat.DateSeparator = "/";
            standardizedCulture.DateTimeFormat.LongDatePattern = "yyyy/MM/dd hh:mm:ss";
            standardizedCulture.DateTimeFormat.FullDateTimePattern = "yyyy/MM/dd hh:mm:ss";
            standardizedCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";
            Thread.CurrentThread.CurrentCulture = standardizedCulture;
            Thread.CurrentThread.CurrentUICulture = standardizedCulture;
        }
        #endregion

        #region Event Handler Function
        private void MainMenu_Load(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (AppConfig.IsDomainLogin)
                {
                    btnChangePassword.Enabled = false;
                }
                InitMainMenu();
                docMgr.MdiParent = this;
                UserLookAndFeel.Default.SetSkinStyle(AppConfig.ScreenThemeStyle);
                bsUserLogin.Caption = AppConfig.UserLogin;
                AppConfig.MainScreen = this as ILogoutable;
                LastestDailyPost();
                ///////////////////////////////////////////////////////////////////////////
                ////////////////////initial multi lang ////////////////////////////////////
                AppConfig.CurrentLanguage = new MultiLanguage();
                AppConfig.CurrentLanguage.LoadMultiLang(MultiLangClass.LoadMultilang(Util.strCurrentLang));

                switch (AppConfig.DefaultLanguagePath)
                {
                    case Util.strLang_English:
                        ChangeLang(eLanguange.English);
                        break;
                    case Util.strLang_Japanese:
                        ChangeLang(eLanguange.Japanese);
                        break;
                    case Util.strLang_Thai:
                        ChangeLang(eLanguange.Thai);
                        break;
                }
                ///////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////
                CloseWaitScreen();
                this.Activate();

                DataTable dt = BusinessClass.LoadGroupByUserID(AppConfig.UserLogin);
                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0]["GROUPNAME"].ToString().ToUpper() == "QC")
                    {
                        Assembly asm = Assembly.LoadFrom(AppConfig.ExePath);
                        Type t = asm.GetType("Rubix.Screen.Form.Operation.C_Receiving.frmCRCS060_QCCheckingList");

                        if (t != null)
                        {
                            LoadChildForm(t);
                            dcpMenu.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                        }
                    }
                    else if (dt.Rows[0]["GROUPNAME"].ToString().ToUpper() == "HANDHELD")
                    {
                        Assembly asm = Assembly.LoadFrom(AppConfig.ExePath);
                        Type t = asm.GetType("Rubix.Screen.Form.Operation.K_Packing.frmKPK020_ConfirmPacking");

                        if (t != null)
                        {
                            LoadChildForm(t);
                            dcpMenu.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void MainMenu_MdiChildActivate(object sender, EventArgs e)
        {
            if ((docMgr.MdiParent).ActiveMdiChild != null)
            {
                bsScreenName.Caption = (docMgr.MdiParent).ActiveMdiChild.Text;
            }
            else
            {
                bsScreenName.Caption = "Welcome to Warehouse Management System (WMS)";
            }
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isClose)
            {
                MainLogin.Close();
            }
        }

        private void btnSkin_Click(object sender, EventArgs e)
        {
            MainSkin mskin = new MainSkin();
            mskin.Show(this);
            mskin.Main = this;
        }

        private void trlMenu_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {  
                if (e.Clicks > 1)
                {
                    ShowWaitScreen();

                    Assembly asm = Assembly.LoadFrom(AppConfig.ExePath);
                    Type t = asm.GetType(trlMenuList.FocusedNode["ClassName"].ToString());

                    if (t != null)
                    {
                        LoadChildForm(t);
                    }
                    CloseWaitScreen();
                }
            }
            catch(Exception ex)
            {
               CloseWaitScreen();
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
        
        private void btnThaiLang_Click(object sender, EventArgs e)
        {
            ChangeLang(eLanguange.Thai);
        }

        private void btnJapanLang_Click(object sender, EventArgs e)
        {
            ChangeLang(eLanguange.Japanese);
        }

        private void btnEngLishLang_Click(object sender, EventArgs e)
        {
            ChangeLang(eLanguange.English);
        }
        
        private void btnLogout_Click(object sender, EventArgs e)
        {
            OnLogout();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            Dialog.ChangePasswordDialog cpd = new Dialog.ChangePasswordDialog();
            cpd.UserID = AppConfig.UserLogin;
            cpd.ShowDialog(this);
            cpd = null;
        }
        
        private void dockManager1_StartDocking(object sender, DevExpress.XtraBars.Docking.DockPanelCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void nbcMenu_GroupExpanded(object sender, NavBarGroupEventArgs e)
        {
            ShowWaitScreen();
            nbgActive = e;
            trlMenuList.BeginUnboundLoad();

            trlMenuList.ClearNodes();
            trlMenuList.Columns[0].Caption = e.Group.Caption;

            DataRow[] dr = ListMenuDataTable.Select(String.Format("MenuGroupName = '{0}' ", e.Group.Tag));

            if (dr.Count() > 0)
            {
                for (int i = 0; i < dr.Count(); i++)
                {
                    dr[i]["DisplayName"] = Util.GetFormText("MainMenu", dr[i]["ClassName"].ToString(), dr[i]["DisplayName"].ToString());
                }

                trlMenuList.DataSource = dr.CopyToDataTable();

                trlMenuList.EndUnboundLoad();
                trlMenuList.ForceInitialize();
                //trlMenuList.ExpandAll();
                trlMenuList.BestFitColumns();
            }
            CloseWaitScreen();
        }

        private void trlMenuList_GetStateImage(object sender, GetStateImageEventArgs e)
        {
            if (e.Node.GetValue("PictureName") != null)
            {
                e.NodeImageIndex = imgMenuList.Images.Keys.IndexOf(string.Format("{0}.png", e.Node.GetValue("PictureName")));
            }
        }

        private void trlMenuList_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            e.Allow = false;
        }
        #endregion

        #region Generic Function
        private void LoadChildForm(System.Type frmType, params object[] args)
        {
            this.Cursor = Cursors.WaitCursor;
            FormBase frmChild = null;
            try
            {
                // Get opened form
                frmChild = (FormBase)GetExistingForm(frmType);

                // if not found exist form, so create new.
                if (frmChild == null)
                {
                    frmChild = (FormBase)Activator.CreateInstance(frmType, args);
                    frmChild.MdiParent = this;
                    frmChild.Text = frmType.Name.Split('_')[0].Replace("frm", "") + ": " + trlMenuList.FocusedNode["DisplayName"];
                    frmChild.Show();
                    if (frmChild.IsNotSetScreenID)
                    {
                        CloseWaitScreen();
                        MessageDialog.ShowBusinessErrorMsg(this, "Screen ID is not set.");
                    }

                    if (frmChild.AUTError != null)
                    {
                        frmChild.Close();
                        frmChild.Dispose();
                        throw frmChild.AUTError;
                    }
                }
                else
                {
                    frmChild.Activate();
                }
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowSystemErrorMsg(this, ex);
                frmChild = null;
            }
            this.Cursor = Cursors.Default;
        }

        private Form GetExistingForm(Type frmType)
        {
            if (frmType.FullName == null) return null;
            foreach (Form form in (docMgr.MdiParent).MdiChildren)
            {
                if (form.Name.Contains(frmType.Name))
                {
                    return form;
                }
            }
            return null;

        }
        
        private void InitMainMenu()
        {
            ListMenuDataTable = BusinessClass.LoadMainMenu(AppConfig.UserLogin, Permission.OpenScreen);
            if (ListMenuDataTable.Rows.Count > 0)
            {
                DataView view = new DataView(ListMenuDataTable);
                DataTable dtMenuGroupName = view.ToTable(true, "MenuGroupName");

                nbcMenu.Groups.Clear();
                foreach (DataRow dr in dtMenuGroupName.Rows)
                {
                    NavBarGroup nbg = new NavBarGroup();
                    nbg.Appearance.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    nbg.Appearance.Options.UseFont = true;
                    nbg.Caption = dr["MenuGroupName"].ToString();
                    nbg.LargeImage = imgGroupList.Images[string.Format("{0}.png", dr["MenuGroupName"].ToString())];
                    nbg.Name = string.Format("nbg{0}", dr["MenuGroupName"].ToString());
                    nbg.Tag = dr["MenuGroupName"].ToString();
                    nbcMenu.Groups.Add(nbg);
                }

                if (dtMenuGroupName.Rows.Count > 0)
                {
                    nbcMenu.Groups[0].Expanded = true;
                    nbcMenu_GroupExpanded(this, new NavBarGroupEventArgs(nbcMenu.Groups[0]));
                }
                else
                {
                    trlMenuList.Visible = false;
                }
                AdjustMenuSize();
            }
        }
        
        private void ChangeLang(eLanguange lang)
        {

            btnJapanLang.Image = global::StartUp.Properties.Resources.flag_japanese_dis;
            btnEngLishLang.Image = global::StartUp.Properties.Resources.english_flag_dis;
            btnThaiLang.Image = global::StartUp.Properties.Resources.Thai_Flag_dis;

            switch (lang)
            {
                case eLanguange.English:
                    btnEngLishLang.Image = global::StartUp.Properties.Resources.english_flag;
                    AppConfig.DefaultLanguagePath = Util.strLang_English;
                    Util.strCurrentLang = Util.strLang_English;
                    break;
                case eLanguange.Japanese:
                    btnJapanLang.Image = global::StartUp.Properties.Resources.flag_japanese;
                    AppConfig.DefaultLanguagePath = Util.strLang_Japanese;
                    Util.strCurrentLang = Util.strLang_Japanese;
                    break;
                case eLanguange.Thai:
                    btnThaiLang.Image = global::StartUp.Properties.Resources.Thai_Flag;
                    AppConfig.DefaultLanguagePath = Util.strLang_Thai;
                    Util.strCurrentLang = Util.strLang_Thai;
                    break;
            }
            OnLanguageChange(this, new LanguageChangeEventArgs(CurrentLanguage));            
        }

        private void LastestDailyPost()
        {
            try
            {
                DataTable dt = LastestDailyBiz.LastestDailyPost();
                if (dt.Rows.Count > 0)
                {
                    AppConfig.LastestDailyPost.Caption = string.Format(AppConfig.LastestDailyPost.Caption,Convert.ToDateTime(dt.Rows[0]["MaxDateDailyPost"]).ToString("dd/MM/yyyy HH:mm"));
                }
                else
                {
                    AppConfig.LastestDailyPost.Caption = string.Format(AppConfig.LastestDailyPost.Caption, "-");
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void ShowWaitScreen()
        {
            
            if (!AppConfig.SplashScreenManager.IsSplashFormVisible)
            {
                if (AppConfig.SplashScreenType != 1)
                {
                    AppConfig.SplashScreenType = 1;
                    AppConfig.SplashScreenManager = splashScreenMgr;
                }
                AppConfig.SplashScreenManager.ShowWaitForm();
                AppConfig.SplashScreenManager.SetWaitFormCaption(Common.GetMessageWithDefault("A0002", "Please Wait"));
                AppConfig.SplashScreenManager.SetWaitFormDescription(Common.GetMessageWithDefault("A0003", "Loading ..."));
            }
        }

        protected void CloseWaitScreen()
        {
            if (AppConfig.SplashScreenManager.IsSplashFormVisible && AppConfig.SplashScreenType == 1)
            {
                AppConfig.SplashScreenManager.CloseWaitForm();
            }
        }
        
        public void AdjustMenuSize()
        {
            Size client = nbcMenu.ClientSize;
            int startPoint = nbcMenu.Height - 1;
            if (nbcMenu.GetViewInfo().CalcHitInfo(new Point(5, startPoint)).Group != null)
            {
                string caption = nbcMenu.GetViewInfo().CalcHitInfo(new Point(5, startPoint)).Group.Caption;
                if (nbcMenu.GetViewInfo().CalcHitInfo(new Point(5, startPoint)).Group != null)
                    for (int i = startPoint; i >= 0; i--)
                    {
                        if (nbcMenu.GetViewInfo().CalcHitInfo(new Point(5, i)).Group == null)
                        {
                            startPoint = 0;
                            break;
                        }
                        if (!nbcMenu.GetViewInfo().CalcHitInfo(new Point(5, i)).Group.Caption.Equals(caption))
                        {
                            startPoint = startPoint - i;
                            break;
                        }
                    }
                client.Height -= ((startPoint * (nbcMenu.Groups.Count))) + 3;
                trlMenuList.Size = client;
            }
        }
        #endregion
        
        #region IMultiLanguage Members
        public void OnLanguageChange(object sender, LanguageChangeEventArgs e)
        {
            ShowWaitScreen();

            try
            {  
                CurrentLanguage.LoadMultiLang(MultiLangClass.LoadMultilang(AppConfig.DefaultLanguagePath));

                LastestDailyPost();

                bsDatabase.Caption = string.Format("{0}:{1}", AppConfig.CompanyCode, AppConfig.CompanyName);
                bsProgramVersion.Caption = String.Format(Util.GetGlobalText("A0005"), AppConfig.ProgramVersion);
                bsScreenName.Caption = Util.GetGlobalText("A0006");

                GridLocalizer.Active = new GridLocalizerLanguage();
                Localizer.Active = new EditorsLocalizerLanguage();
            }
            catch (Exception)
            {
                throw new Exception("Can't Load Language");
            }

            //change lang to all form
            foreach (Form frm in (docMgr.MdiParent).MdiChildren)
            {
                IMultiLanguage ml = frm as IMultiLanguage;
                if (ml != null)
                {
                    ml.OnLanguageChange(this, new LanguageChangeEventArgs(CurrentLanguage));
                }
            }   
                        
            this.Text = e.MultiLanguage.GetText(MultiLanguage.eType.Form, this.Name, "Text", this.Text);
            Util.ChangeLanguage(this.Name, this.Controls, e);

            //Change Language for main menu.
            if (nbgActive != null)
            {
                nbcMenu_GroupExpanded(this, nbgActive);
            }
            CloseWaitScreen();
        }
        #endregion  
        
        #region ILogoutable Members
        public void OnLogout()
        {
            isClose = false;  
            MainLogin.IsLogout = true;
            this.Close();
            MainLogin.Show();
            MainLogin.backgroundWorker1.RunWorkerAsync();  
        }
        #endregion  


    }
}
 
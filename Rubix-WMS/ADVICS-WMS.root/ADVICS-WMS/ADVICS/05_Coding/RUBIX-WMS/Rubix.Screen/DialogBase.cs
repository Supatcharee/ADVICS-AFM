using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using Rubix.Framework;
using DevExpress.XtraBars;
using CSI.Business.BusinessFactory.Common;
namespace Rubix.Screen
{
    public partial class DialogBase : DevExpress.XtraEditors.XtraForm, IMultiLanguage
    {
        #region Member
        GridControl[] grdSearchResult = null;
        TreeList[] trlList = null;
        protected IdleValidator iv;
        #endregion

        #region Constructor
        public DialogBase()
        {
            InitializeComponent();
            btnPrint.Visibility = BarItemVisibility.Never;

            btnSaveACopy.Visibility = BarItemVisibility.Never;
        } 
        #endregion

        #region Properties
        public IdleValidator IdleValidatorControl { set { iv = value; } }
        public GridControl[] GridViewControl
        {
            get { return grdSearchResult; }
            set { grdSearchResult = value; }
        }
        public TreeList[] TreeListControl
        {
            get { return trlList; }
            set { trlList = value; }
        }
        #endregion

        #region Properties Toolbar Control
        public BarButtonItem m_toolBarSave { get { return btnSave; } }
        public BarButtonItem m_toolBarSaveACopy { get { return btnSaveACopy; } }
        public BarButtonItem m_toolBarClear { get { return btnClear; } }
        public BarButtonItem m_toolBarClose { get { return btnClose; } }
        public BarButtonItem m_toolBarPrint { get { return btnPrint; } }
        public BarButtonItem m_toolBarImport { get { return btnImport; } }

        public BarStaticItem m_statusBarCreatedDate { get { return btCreatedDate; } }
        public BarStaticItem m_statusBarCreatedUser { get { return btCreatedUser; } }
        public BarStaticItem m_statusBarUpdatedDate { get { return btUpdatedDate; } }
        public BarStaticItem m_statusBarUpdatedUser { get { return btUpdatedUser; } }

        public Bar m_statusBar { get { return bStatusBar; } }
        #endregion

        #region Virtual Method Must Implement by inherrited form
        public virtual bool OnCommandSave()         { return true; }
        public virtual bool OnCommandSaveACopy()    { return true; }
        public virtual bool OnCommandClear()        { return true; }
        public virtual bool OnCommandPrint()        { return true; }
        public virtual bool OnCommandImport()       { return true; }
        public virtual bool OnCommandClose() {
            if (MessageDialog.ShowConfirmationMsg(this, Common.GetMessage("I0004")) != DialogButton.Yes)
                return false;
            else
                return true; 
        }

        #endregion

        #region Event Handler Function
         private void DialogBase_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                OnLanguageChange(this, new LanguageChangeEventArgs(new MultiLanguage()));
                ChangeThemeStyle();
                ChangePaintStyle();
                ProtectEditGrid();
                SetShowAddButton();
            }
        }
         private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                OnCommandSave();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }  
        }
         private void btnClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                OnCommandClear();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }  
        }

         private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (OnCommandClose())
                    DialogResult = DialogResult.Abort;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
         private void btnPrint_ItemClick(object sender, ItemClickEventArgs e)
         {
             try
             {
                 OnCommandPrint();
             }
             catch (Exception ex)
             {
                 throw (ex);
             }
         }
         private void btnImport_ItemClick(object sender, ItemClickEventArgs e)
         {
             this.Cursor = Cursors.WaitCursor;
             try
             {
                 OnCommandImport();
             }
             catch (Exception ex)
             {
                 throw (ex);
             }
             finally
             {
                 this.Cursor = Cursors.Default;
             }
         }
         private void btnSaveACopy_ItemClick(object sender, ItemClickEventArgs e)
         {
             this.Cursor = Cursors.WaitCursor;
             try
             {
                 OnCommandSaveACopy();
             }
             catch (Exception ex)
             {
                 throw (ex);
             }
             finally
             {
                 this.Cursor = Cursors.Default;
             }  
         }
         private void DialogBase_FormClosing(object sender, FormClosingEventArgs e)
         {

         }

        #endregion

        #region Generic Function
         private void ChangeThemeStyle()
         {
             if (GridViewControl != null)
             {
                 foreach (GridControl gdc in GridViewControl)
                 {
                     gdc.ForceInitialize();
                     string filePath;
                     DevExpress.XtraGrid.Design.XAppearances gvScheme;
                     try
                     {
                         filePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.System) + "\\DevExpress.XtraGrid.Appearances.xml";
                         gvScheme = new DevExpress.XtraGrid.Design.XAppearances(filePath);
                     }
                     catch (Exception)
                     {
                         filePath = System.Environment.CurrentDirectory + "\\DevExpress.XtraGrid.Appearances.xml";
                         gvScheme = new DevExpress.XtraGrid.Design.XAppearances(filePath);
                     }
                     foreach (GridView gdv in gdc.Views)
                     {
                         gvScheme.LoadScheme(AppConfig.GridThemeStyle, gdv);
                     }
                 }
             }

             if (TreeListControl != null)
             {
                 string filePath;
                 DevExpress.XtraTreeList.Design.XAppearances gvScheme;
                 try
                 {
                     filePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.System) + "\\DevExpress.XtraTreeList.Appearances.xml";
                     gvScheme = new DevExpress.XtraTreeList.Design.XAppearances(filePath);
                 }
                 catch (Exception)
                 {
                     filePath = System.Environment.CurrentDirectory + "\\DevExpress.XtraTreeList.Appearances.xml";
                     gvScheme = new DevExpress.XtraTreeList.Design.XAppearances(filePath);
                 }
                 if (TreeListControl != null)
                 {
                     foreach (TreeList trl in TreeListControl)
                     {
                         gvScheme.LoadScheme(AppConfig.GridThemeStyle, trl);
                     }
                 }
             }
         }

         private void ChangePaintStyle()
         {
             if (GridViewControl != null)
             {
                 foreach (GridControl gdc in GridViewControl)
                 {
                     for (int i = gdc.Views.Count - 1; i >= 0; i--)
                     {
                         gdc.Views[i].PaintStyleName = AppConfig.GridPaintStyle;
                     }
                 }
             }
         }

         private void ProtectEditGrid()
         {
             if (GridViewControl != null)
             {
                 foreach (GridControl gdc in GridViewControl)
                 {
                     foreach (GridView gdv in gdc.Views)
                     {
                         gdv.OptionsBehavior.Editable = false;
                         gdv.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                         gdv.Appearance.HeaderPanel.Font = new Font(gdv.Appearance.HeaderPanel.Font, FontStyle.Bold);
                         gdv.OptionsCustomization.AllowQuickHideColumns = false;
                         //gdv.OptionsView.ColumnAutoWidth = false;
                     }
                 }
             }
         }

         protected void ShowWaitScreen()
         {
             if (this.ActiveControl != null && !AppConfig.SplashScreenManager.IsSplashFormVisible)
             {
                 if (AppConfig.SplashScreenType != 3)
                 {
                     AppConfig.SplashScreenType = 3;
                     AppConfig.SplashScreenManager = splashScreenMgr;
                 }                 
                 AppConfig.SplashScreenManager.ShowWaitForm();
                 AppConfig.SplashScreenManager.SetWaitFormCaption(Common.GetMessageWithDefault("A0002", "Please Wait"));
                 AppConfig.SplashScreenManager.SetWaitFormDescription(Common.GetMessageWithDefault("A0003", "Loading ..."));
             }
         }

         protected void CloseWaitScreen()
         {
             if (this.ActiveControl != null && AppConfig.SplashScreenManager.IsSplashFormVisible && AppConfig.SplashScreenType == 3)
             {
                 AppConfig.SplashScreenManager.CloseWaitForm();
             }
         }

         public void HideStatusBar()
         {
             m_statusBarCreatedDate.Visibility = BarItemVisibility.Never;
             m_statusBarCreatedUser.Visibility = BarItemVisibility.Never;
             m_statusBarUpdatedDate.Visibility = BarItemVisibility.Never;
             m_statusBarUpdatedUser.Visibility = BarItemVisibility.Never;
             bsCreatedDate.Visibility = BarItemVisibility.Never;
             bsCreatedUser.Visibility = BarItemVisibility.Never;
             bsUpdatedDate.Visibility = BarItemVisibility.Never;
             bsUpdatedUser.Visibility = BarItemVisibility.Never;
             bStatusBar.Visible = false;
         }

         private bool IsAllowToPerform(string FormFullName, string userID, string permission)
         {
             CSI.Business.Admin.SecurityMapping sm = new CSI.Business.Admin.SecurityMapping();
             return sm.IsAllowToPerformAuthen(FormFullName, userID, permission);
         }

         protected void SetShowAddButton()
         {
             //////////////////////////////////////////////////////////////////
             //Check Add permission for adding Add button to user control.
             foreach (DataRow dr in Common.InitialDataTableUserControl().Rows)
             {
                 System.Windows.Forms.Control[] ct = this.Controls.Find(dr["UserControlName"].ToString(), true);
                 if (ct.Length > 0)
                 {
                     Common.SetEnableAddToUserControl(ct, this.IsAllowToPerform(dr["ScreenName"].ToString(), AppConfig.UserLogin, Rubix.Framework.Permission.Add));
                 }
             }
             /////////////////////////////////////////////////////////////////
         }
        #endregion

        #region IMultiLanguage Members
         LanguageChangeEventArgs lang = new LanguageChangeEventArgs(new MultiLanguage());
         public virtual void OnLanguageChange(object sender, LanguageChangeEventArgs e)
         {
             if (!this.DesignMode)
             {
                 this.Text = e.MultiLanguage.GetText(MultiLanguage.eType.Form, this.Name, "Text", this.Text);
                 Util.ChangeLanguage(this.Name, ((System.Windows.Forms.Control)sender).Controls, e);
                 Util.ChangeLanguage("DialogBase", this.Controls, e);
                 lang = e;
             }
         }
         protected void GridViewOnChangeLanguage(GridControl gridControl)
         {
             

             Util.ChangeLanguage(this.Name, gridControl, lang);
         }
         protected string GetLanguange(string ControlName, string CurrentDisplayText)
         {
             return lang.MultiLanguage.GetText(MultiLanguage.eType.Form, this.Name, ControlName, CurrentDisplayText);
         }
         #endregion
    }
}
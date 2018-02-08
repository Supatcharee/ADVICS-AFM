using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using DevExpress.XtraGrid;
using DevExpress.XtraTreeList;
using CSI.Business.BusinessFactory.Common;
using DevExpress.XtraBars;

namespace Rubix.Screen
{
    public partial class SubDialogBase : DevExpress.XtraEditors.XtraForm
    {
        #region Member

        #endregion

        #region Properties

        #endregion

        #region Constructor
        public SubDialogBase()
        {
            InitializeComponent();
        } 
        #endregion

        #region Properties Toolbar Control

        public BarButtonItem m_toolBarOK { get { return btnOK; } }
        public BarButtonItem m_toolBarCancel { get { return btnClose; } }

        #endregion

        #region Virtual Method Must Implement by inherrited form
        public virtual bool OnCommandOK() { return true; }
        public virtual bool OnCommandClose() { return true; } 
        #endregion
        
        #region Event Handler Function
          private void SubDialogBase_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                OnLanguageChange(this, new LanguageChangeEventArgs(new MultiLanguage()));
            }
        }      
        
        private void btnOK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                OnCommandOK();
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

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
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
        #endregion

        #region Generic Function
        protected void ShowWaitScreen()
        {
            if (!AppConfig.SplashScreenManager.IsSplashFormVisible)
            {
                AppConfig.SplashScreenManager.ShowWaitForm();
                AppConfig.SplashScreenManager.SetWaitFormCaption(Common.GetMessageWithDefault("A0002", "Please Wait"));
                AppConfig.SplashScreenManager.SetWaitFormDescription(Common.GetMessageWithDefault("A0003", "Loading ..."));
            }
        }

        protected void CloseWaitScreen()
        {
            if (AppConfig.SplashScreenManager.IsSplashFormVisible)
            {
                AppConfig.SplashScreenManager.CloseWaitForm();
            }
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
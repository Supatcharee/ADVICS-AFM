using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using CSI.Business.Admin;
using Rubix.Framework;
namespace Rubix.Screen.Form.Admin
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Add, Permission.Edit, Permission.Delete, Permission.Export)]
    public partial class frmADM010_UserMaintenance : FormBase
    {
        #region Member
        private UserMaintenance  db;
        private Dialog.dlgADM010_UserMaintenance m_Dialog = null;
        #endregion

        #region Properties
        private UserMaintenance BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new UserMaintenance();
                }
                return db;
            }
        }
        private Dialog.dlgADM010_UserMaintenance Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgADM010_UserMaintenance();
                }
                return m_Dialog;
            }
            set
            {
                m_Dialog = null;
            }
        }
        #endregion
        
        #region Constructor
        public frmADM010_UserMaintenance()
        {
            InitializeComponent();
            base.GridExportExcel = gdvSearchResult;
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);            
        }
        #endregion

        #region Event Handler Function
        private void frmADM010_UserMaintenance_Load(object sender, EventArgs e)
        {
            try
            {
                DataLoading();
                base.GridViewOnChangeLanguage(grdSearchResult);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        } 
        #endregion

        #region Override Method
        public override bool OnCommandAdd()
        {
            try
            {
                OpenDialog(Common.eScreenMode.Add);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            } 
        }
        public override bool OnCommandEdit()
        {
            try
            {
                OpenDialog(Common.eScreenMode.Edit);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            } 
        }
        public override bool OnCommandView()
        {
            try
            {
                OpenDialog(Common.eScreenMode.View);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }
        public override bool OnCommandDelete()
        {
            if (gdvSearchResult.RowCount <= 0)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                return false;
            }
            try
            {
                string userid = GetSelectedUserID();
                if (userid.Equals("admin", StringComparison.InvariantCultureIgnoreCase))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0283"));
                    return false;
                }
                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0002"), userid)) == DialogButton.Yes)
                {
                    BusinessClass.DeleteUser(userid);
                    DataLoading();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }
        #endregion

        #region Generic Function
        private void OpenDialog(Common.eScreenMode ScreenMode)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (ScreenMode != Common.eScreenMode.Add)
                {
                    if (gdvSearchResult.RowCount <= 0)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                        return;
                    }
                    Dialog.UserID = GetSelectedUserID();
                }

                Dialog.ScreenMode = ScreenMode;
                Dialog.BusinessClass = this.BusinessClass;

                if (Dialog.ShowDialog(this) == DialogResult.OK)
                {
                    MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), Dialog.UserID));
                    DataLoading();
                }
                Dialog = null;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void DataLoading()
        {
            ShowWaitScreen();
            grdSearchResult.DataSource = BusinessClass.DataLoading();
            CloseWaitScreen();
        }

        private string GetSelectedUserID()
        {
            if (gdvSearchResult.GetFocusedRow() is CSI.Business.DataObjects.sp_ADM010_UserMaintenance_SearchAll_Result) {
                CSI.Business.DataObjects.sp_ADM010_UserMaintenance_SearchAll_Result selected = (CSI.Business.DataObjects.sp_ADM010_UserMaintenance_SearchAll_Result)gdvSearchResult.GetFocusedRow();
                return selected.UserID;
            }
            else
                return string.Empty;
        }
        #endregion
    }
}
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
    public partial class frmADM060_UserWebMaintenance : FormBase
    {
        #region Member
        private UserWebMaintenance  db;
        private Dialog.dlgADM060_UserWebMaintenance m_Dialog = null;
        #endregion

        #region Properties
        private UserWebMaintenance BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new UserWebMaintenance();
                }
                return db;
            }
        }
        private Dialog.dlgADM060_UserWebMaintenance Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgADM060_UserWebMaintenance();
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
        public frmADM060_UserWebMaintenance()
        {
            InitializeComponent();
            base.GridExportExcel = gdvSearchResult;
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);            
        }
        #endregion

        #region Event Handler Function
        private void frmADM060_UserWebMaintenance_Load(object sender, EventArgs e)
        {
            DataLoading();
            base.GridViewOnChangeLanguage(grdSearchResult);
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

                if (Dialog.ShowDialog(this) == DialogResult.OK)
                {
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
            grdSearchResult.DataSource = BusinessClass.DataLoading();

            for (int i = 0; i < gdvSearchResult.Columns.Count; i++)
            {
                if (gdvSearchResult.Columns[i].ColumnType == typeof(DateTime) || gdvSearchResult.Columns[i].ColumnType == typeof(DateTime?))
                {
                    gdvSearchResult.Columns[i].DisplayFormat.FormatString = Common.FullDatetimeFormat;
                    gdvSearchResult.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                }
            }

            foreach (DevExpress.XtraGrid.Columns.GridColumn gc in gdvSearchResult.Columns)
            {
                gc.Width = gc.GetBestWidth();
            }
        }

        private string GetSelectedUserID()
        {
            DataRow dr = gdvSearchResult.GetFocusedDataRow();
            if (dr != null)
            {
                return dr["UserID"].ToString();
            }
            return string.Empty;
        }
        #endregion
    }
}
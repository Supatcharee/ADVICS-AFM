using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using CSI.Business.Master;
using Rubix.Framework;
namespace Rubix.Screen.Form.Master
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Add, Permission.Edit, Permission.Delete, Permission.Export)]
    public partial class frmXMSS230_WorkMethod : FormBase
    {
        #region Member
        private WorkMethod db;
        private Dialog.dlgXMSS230_WorkMethod m_Dialog = null;
        #endregion

        #region Enumeration
        private enum eColDetail
        {
            WorkMethodID,
            WorkMethodCode,
            WorkMethodName,
            Description,
            CreateDate,
            CreateUser,
            UpdateDate,
            UpdateUser
        }
        #endregion

        #region Properties
        private WorkMethod BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new WorkMethod();
                }
                return db;
            }
        }
        private Dialog.dlgXMSS230_WorkMethod Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgXMSS230_WorkMethod();
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
        public frmXMSS230_WorkMethod()
        {
            InitializeComponent();
            base.GridExportExcel = gdvSearchResult;
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.SetExpandGroupControl(groupControl1);
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh,m_toolBarDelete);  //Hide  Button Delete  Update 29-03-2013
        }
        #endregion

        #region Event Handler Function
        private void frmXMSS230_WorkMethod_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataLoading();
                base.GridViewOnChangeLanguage(grdSearchResult);
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                }
            }
            catch (Exception ex)
            {

                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ControlUtil.ClearControlData(txtWorkMethodCode, txtWorkMethodName);
            grdSearchResult.DataSource = null;
            gdvSearchResult.Columns.Clear();
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
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        public override bool OnCommandEdit()
        {
            try
            {
                OpenDialog(Common.eScreenMode.Edit);
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        public override bool OnCommandView()
        {
            try
            {
                OpenDialog(Common.eScreenMode.View);
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        public override bool OnCommandDelete()
        {
            try
            {
                if ((grdSearchResult.DefaultView).DataRowCount == 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }
                else
                {
                    BusinessClass.SelectData = gdvSearchResult.GetFocusedRow();
                    if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0002"), BusinessClass.WorkMethodName)) == DialogButton.Yes)
                    {
                        if (BusinessClass.CheckReference(BusinessClass.WorkMethodID) == 0) // Check Reference before Delete : Add by Chalermchai C. // 04/25/2012
                        {
                            BusinessClass.DeleteWorkMethodData();
                            DataLoading();
                            MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0013"), BusinessClass.WorkMethodName));
                        }
                        else
                        {
                            MessageDialog.ShowBusinessErrorMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0082"), "Work Method"));
                            return false;
                        }


                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        #endregion

        #region Generic Function
        private void OpenDialog(Common.eScreenMode ScreenMode)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if ((grdSearchResult.DefaultView).DataRowCount == 0 && ScreenMode != Common.eScreenMode.Add)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                }
                else
                {
                    if (ScreenMode != Common.eScreenMode.Add)
                    {
                        BusinessClass.SelectData = gdvSearchResult.GetFocusedRow();
                    }
                    Dialog.ScreenMode = ScreenMode;
                    Dialog.BusinessClass = BusinessClass;
                    if (Dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        DataLoading();
                        MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), Dialog.BusinessClass.WorkMethodName));
                    }
                    Dialog = null;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.ToString());
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                grdSearchResult.DataSource = BusinessClass.DataLoading(txtWorkMethodCode.Text.Trim(), txtWorkMethodName.Text.Trim());
                //gdvSearchResult.Columns[(int)eColDetail.WorkMethodID].Visible = false;
                for (int i = 0; i < gdvSearchResult.Columns.Count; i++)
                {
                    if (gdvSearchResult.Columns[i].ColumnType == typeof(DateTime) || gdvSearchResult.Columns[i].ColumnType == typeof(DateTime?))
                    {
                        gdvSearchResult.Columns[i].DisplayFormat.FormatString = Common.FullDatetimeFormat;
                        gdvSearchResult.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    }
                }
                ControlUtil.HiddenControl(true, gdvSearchResult, (int)eColDetail.WorkMethodID);
                ControlUtil.SetBestWidth(gdvSearchResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseWaitScreen();
            }
        }
        #endregion

    }
}
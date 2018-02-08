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
    public partial class frmXMSS240_ItemClassification : FormBase
    {
        #region Member
        private Classification db;
        private Dialog.dlgXMSS240_ItemClassification m_Dialog = null;
        #endregion

        #region Enumeration
        private enum eColDetail
        {
            ClassificationID,
            //OwnerID,
            //CustomerCode,
            ClassificationCode,
            ClassificationName,
            Remark,
            CreateDate,
            CreateUser,
            UpdateDate,
            UpdateUser
        }
        #endregion

        #region Properties
        private Classification BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Classification();
                }
                return db;
            }
        }
        private Dialog.dlgXMSS240_ItemClassification Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgXMSS240_ItemClassification();
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
        public frmXMSS240_ItemClassification()
        {
            InitializeComponent();
            base.GridExportExcel = gdvSearchResult;
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.SetExpandGroupControl(groupControl1);
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
        }
        #endregion

        #region Event Handler Function
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
            try
            {
                ControlUtil.ClearControlData(txtClassificationCode, txtClassificationName);
                grdSearchResult.DataSource = null;
                ownerControl.DataLoading();
                ownerControl.ClearData();
                //gdvSearchResult.Columns.Clear();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
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
                    if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0002"), BusinessClass.ClassificationName)) == DialogButton.Yes)
                    {
                        if (BusinessClass.CheckReference(BusinessClass.ClassificationID) == 0) // Check Reference before Delete : Add by Chalermchai C. // 04/25/2012
                        {
                            BusinessClass.DeleteClassificationData();
                            DataLoading();
                            MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0013"), BusinessClass.ClassificationName));
                        }
                        else
                        {
                            MessageDialog.ShowBusinessErrorMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0082"), "Item Classification"));
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
                        MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), Dialog.BusinessClass.ClassificationName));
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
                grdSearchResult.DataSource = BusinessClass.DataLoading(/*ownerControl.OwnerID,*/ txtClassificationCode.Text.Trim(), txtClassificationName.Text.Trim());

                for (int i = 0; i < gdvSearchResult.Columns.Count; i++)
                {
                    if (gdvSearchResult.Columns[i].ColumnType == typeof(DateTime) || gdvSearchResult.Columns[i].ColumnType == typeof(DateTime?))
                    {
                        gdvSearchResult.Columns[i].DisplayFormat.FormatString = Common.FullDatetimeFormat;
                        gdvSearchResult.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    }
                }
                //gdvSearchResult.Columns[(int)eColDetail.ClassificationCode].Caption = "Item Classification Code";
                //gdvSearchResult.Columns[(int)eColDetail.ClassificationName].Caption = "Item Classification Name";
                //ControlUtil.HiddenControl(true, gdvSearchResult, (int)eColDetail.ClassificationID/*, (int)eColDetail.OwnerID*/);
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using CSI.Business.Master;
using Rubix.Framework;
using CSI.Business.BusinessFactory.Master;

namespace Rubix.Screen.Form.Master
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Add, Permission.Edit, Permission.Delete, Permission.Export)]
    public partial class frmXMSS300_Pallet : FormBase
    {
        #region Member
        private Pallet db = null;
        private Dialog.dlgXMSS301_Pallet m_Dialog = null;

        #endregion

        #region Constructor

        public frmXMSS300_Pallet()
        {
            InitializeComponent();
            base.GridExportExcel = gdvSearchResult;
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.SetExpandGroupControl(groupControl1);
            ControlUtil.HiddenControl(true, m_toolBarCancel, m_toolBarSave, m_toolBarRefresh);
        }


        #endregion

        #region Properties

        public Pallet BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Pallet();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new Pallet();
                }
                db = value;
            }
        }

        private Dialog.dlgXMSS301_Pallet Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgXMSS301_Pallet();
                }
                return m_Dialog;
            }
            set
            {
                m_Dialog = value;
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
                    DataRow dtr = gdvSearchResult.GetFocusedDataRow();

                    if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0002"), dtr["PalletName"])) == DialogButton.Yes)
                    {
                        if (BusinessClass.CheckReference(Convert.ToInt32(dtr["PalletID"])) == 0)
                        {
                            BusinessClass.PalletID = Convert.ToInt32(dtr["PalletID"]);
                            BusinessClass.DeleteData();
                            DataLoading();
                            MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0013"), dtr["PalletName"]));
                        }
                        else
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0082"), "Pallet"));
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

        #region Event Handler

        private void frmXMSS300_Pallet_Load(object sender, EventArgs e)
        {

            base.GridExportExcel = gdvSearchResult;
            base.GridViewOnChangeLanguage(grdSearchResult);
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
            ControlUtil.ClearControlData(txtPalletCode, txtPalletName);
            grdSearchResult.DataSource = null;
        }

        #endregion

        #region Generic Function

        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                grdSearchResult.DataSource = BusinessClass.DataLoading(txtPalletCode.Text.Trim(), txtPalletName.Text.Trim());
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
                        Dialog.SelectData = gdvSearchResult.GetFocusedDataRow();
                    }
                    Dialog.ScreenMode = ScreenMode;
                    if (Dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        DataLoading();
                        //MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), Dialog.BusinessClass.ConfigItem));
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

        #endregion
    }
}

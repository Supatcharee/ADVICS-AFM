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
    public partial class frmXMSS120_Zone : FormBase
    {
        #region Member
        private Zone db;
        private Dialog.dlgXMSS120_Zone m_Dialog = null;
        #endregion

        #region Enumeration
        private enum eColDetail
        {
            ZoneID,
            CustomerCode,
            WarehouseCode,
            Floor,
            ZoneCode,
            ZoneName,
            CreateDate,
            CreateUser,
            UpdateDate,
            UpdateUser
        }
        #endregion

        #region Properties
        private Zone BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Zone();
                }
                return db;
            }
        }
        private Dialog.dlgXMSS120_Zone Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgXMSS120_Zone();
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
        public frmXMSS120_Zone()
        {
            InitializeComponent();
            base.GridExportExcel = gdvSearchResult;
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.SetExpandGroupControl(groupControl1);
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
        }
        #endregion

        #region Event Handler Function
        private void frmXMSS120_Zone_Load(object sender, EventArgs e)
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
            try
            {
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void customerControl_Enter(object sender, EventArgs e)
        {
            
        }

        private void customerControl_Leave(object sender, EventArgs e)
        {
           
        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            warehouseControl.OwnerID = ownerControl.OwnerID;
            warehouseControl.DataLoading();
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
        public override bool OnCommandDelete()
        {
            try
            {
                BusinessClass.SelectData = gdvSearchResult.GetFocusedRow();
                if (gdvSearchResult.GetFocusedRow() == null)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                    return false;
                }
                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0002"), BusinessClass.ZoneName)) == DialogButton.Yes)
                {
                    if (BusinessClass.CheckReference(BusinessClass.ZoneID) == 0) // Check Reference before Delete : Add by Chalermchai C. // 04/25/2012
                    {
                        BusinessClass.DeleteZoneData();
                        DataLoading();
                        MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0013"), BusinessClass.ZoneName));
                    }
                    else
                    {
                        MessageDialog.ShowBusinessErrorMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0082"), "Zone"));
                        return false;
                    }


                }
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

                    Dialog.BusinessClass = BusinessClass;
                    Dialog.ScreenMode = ScreenMode;

                    if (Dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        DataLoading();
                        MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), Dialog.BusinessClass.ZoneName));
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
                grdSearchResult.DataSource = BusinessClass.DataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, (txtFloor.Text.Trim() == String.Empty ? 0 : Convert.ToInt32(txtFloor.Text.Trim())), txtZoneCode.Text.Trim(), txtZoneName.Text.Trim());

                for (int i = 0; i < gdvSearchResult.RowCount; i++)
                {
                    CSI.Business.DataObjects.sp_XMSS120_Zone_SearchAll_Result rec = (CSI.Business.DataObjects.sp_XMSS120_Zone_SearchAll_Result)gdvSearchResult.GetRow(i);
                    rec.ZoneColor = '#' + rec.ZoneColor;
                }
                    
                    ControlUtil.HiddenControl(true, gdvSearchResult, (int)eColDetail.ZoneID);

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

        private void ClearAll()
        {
            ControlUtil.ClearControlData(txtFloor, txtZoneCode, txtZoneName, ownerControl, warehouseControl);
            warehouseControl.ClearData();
            ownerControl.ClearData();
            grdSearchResult.DataSource = null;
            //gdvSearchResult.Columns.Clear();

            warehouseControl.OwnerID = null;
            warehouseControl.DataLoading();
        }
        #endregion
        
    }
}
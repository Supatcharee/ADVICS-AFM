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
    public partial class frmXMSS190_TransportUnstuffing : FormBase
    {
        #region Member
        private TransportCharge db;
        private Dialog.dlgXMSS190_TransportUnstuffing m_Dialog = null;
        #endregion

        #region Enumeration
        private enum eColDetail
        {
            OwnerID,
            WarehouseID,
            OwnerCode,
            OwnerName,
            CustomerCode,
            CustomerName,
            WarehouseCode,
            WarehouseName,
            TruckCompanyCode,
            TruckCompanyName,
            EffectiveDate,
            CreateUser,
            CreateDate,
            UpdateUser,
            UpdateDate,
		    CustomerID,
		    FuelPrice,
		    TruckCompanyID
        }
        #endregion

        #region Properties
        private TransportCharge BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new TransportCharge();
                }
                return db;
            }
        }
        private Dialog.dlgXMSS190_TransportUnstuffing Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgXMSS190_TransportUnstuffing();
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
        public frmXMSS190_TransportUnstuffing()
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
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            warehouseControl.OwnerID = ownerControl.OwnerID;
            warehouseControl.DataLoading();

            customerControl.OwnerID = ownerControl.OwnerID;
            customerControl.DataLoading();
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
                if (gdvSearchResult.GetFocusedRow() == null)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                    return false;
                }
                BusinessClass.SelectData = gdvSearchResult.GetFocusedRow();
                if (MessageDialog.ShowConfirmationMsg(this, Rubix.Screen.Common.GetMessage("I0016")) == DialogButton.Yes)
                {
                    BusinessClass.Delete();
                    DataLoading();
                    MessageDialog.ShowInformationMsg(Rubix.Screen.Common.GetMessage("I0017"));
                }
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
                        MessageDialog.ShowInformationMsg(Rubix.Screen.Common.GetMessage("I0003"));
                    }
                    Dialog = null;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
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
                grdSearchResult.DataSource = BusinessClass.DataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID,customerControl.CustomerID);

                //ControlUtil.HiddenControl(true, gdvSearchResult, (int)eColDetail.OwnerID, (int)eColDetail.WarehouseID,
                //    (int)eColDetail.TruckCompanyID,(int)eColDetail.CustomerID,(int)eColDetail.FuelPrice);
                
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
            warehouseControl.ClearData();
            ownerControl.ClearData();
            grdSearchResult.DataSource = null;
           // gdvSearchResult.Columns.Clear();
            customerControl.ClearData();
            warehouseControl.OwnerID = null;
            warehouseControl.DataLoading();
        }
        #endregion
        
    }
}
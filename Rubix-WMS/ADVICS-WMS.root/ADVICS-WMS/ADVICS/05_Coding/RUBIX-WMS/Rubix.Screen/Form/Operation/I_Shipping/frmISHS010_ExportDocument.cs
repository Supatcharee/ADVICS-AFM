using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CSI.Business.DataObjects;
using CSI.Business.Operation;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using Rubix.Framework;
using Rubix.Screen.Form.Operation.I_Shipping.Dialog;

namespace Rubix.Screen.Form.Operation.I_Shipping
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Print, Permission.Export)]
    public partial class frmISHS010_ExportDocument : FormBase
    {
        #region Member

        private ExportDocument objExportDocument = null;

        #endregion

        #region Constructor

        public frmISHS010_ExportDocument()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(false, m_toolBarPrint);
            ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);

            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;            
        }

        #endregion

        #region Properties
        private ExportDocument BusinessClass
        {
            get
            {
                if (objExportDocument == null)
                {
                    objExportDocument = new ExportDocument();
                }
                return objExportDocument;
            }
        }
        #endregion

        #region Override Method
        public override bool OnCommandPrint()
        {
            try
            {
                if (gdvSearchResult.RowCount <= 0)
                {
                    // No data.Please select data.
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }

                sp_ISHS010_ExportDocument_SearchAll_Result data = gdvSearchResult.GetFocusedRow() as sp_ISHS010_ExportDocument_SearchAll_Result;
                if (data == null)
                {
                    // No data.Please select data.
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }                
                dlgISHS011_ExportDocument dlg = new dlgISHS011_ExportDocument(data.ShipmentNo, data.Installment, data.ContainerNo);
                dlg.ShowDialog();
                DataLoading();
                dlg = null;
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        #endregion

        #region Generic Method

        private bool DataLoading()
        {
            try
            { 
                this.ShowWaitScreen();
                grdSearchResult.DataSource = null;

                string ShippingDateFrom = Util.IsNullOrEmpty(dtpShippingDateFrom.EditValue) ? null : dtpShippingDateFrom.DateTime.ToString("yyyy/MM/dd");
                string ShippingDateTo = Util.IsNullOrEmpty(dtpShippingDateTo.EditValue) ? null : dtpShippingDateTo.DateTime.ToString("yyyy/MM/dd");

                List<sp_ISHS010_ExportDocument_SearchAll_Result> data = BusinessClass.Search(ownerControl.OwnerID
                    , customerControl.CustomerID
                    , warehouseControl.WarehouseID
                    , ShippingDateFrom
                    , ShippingDateTo
                    , txtPONo.Text
                    , txtSONo.Text
                    , txtContainerNo.Text);

                if (data.Count == 0)
                {
                    return false;
                }
                grdSearchResult.DataSource = data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseWaitScreen();
                base.GridViewOnChangeLanguage(grdSearchResult);
            }
            return true;
        }

        private bool ValidateData()
        {
            errorProvider.ClearErrors();
            Boolean validate = true;
            // set require field
            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            //customerControl.ErrorText = Common.GetMessage("I0249");
            //customerControl.RequireField = true;

            validate &= ownerControl.ValidateControl();
            validate &= warehouseControl.ValidateControl();
            //if (false == customerControl.ValidateControl())
            //{
            //    validate = false;
            //}

            return validate;
        }

        #endregion

        #region Events Handler Function
        private void frmISHS010_ExportDocument_Load(object sender, EventArgs e)
        {
            try
            {
                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();

                dtpShippingDateFrom.EditValue = ControlUtil.GetStartDate();
                dtpShippingDateTo.EditValue = ControlUtil.GetEndDate();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    if (!DataLoading())
                    {                        
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0014"));
                    }
                    else
                    {
                        m_toolBarEdit.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                ControlUtil.ClearControlData(this.Controls);

                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();

                dtpShippingDateFrom.EditValue = ControlUtil.GetStartDate();
                dtpShippingDateTo.EditValue = ControlUtil.GetEndDate();

                grdSearchResult.DataSource = null;
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void ownerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (ownerControl.OwnerID != null)
                {
                    customerControl.OwnerID = ownerControl.OwnerID;
                    customerControl.DataLoading();
                    warehouseControl.OwnerID = ownerControl.OwnerID;
                    warehouseControl.DataLoading();
                }
                else
                {
                    customerControl.OwnerID = Common.GetDefaultOwnerID();
                    customerControl.DataLoading();
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }

            finally
            {
                CloseWaitScreen();
            }
        }

        #endregion        

    }
}
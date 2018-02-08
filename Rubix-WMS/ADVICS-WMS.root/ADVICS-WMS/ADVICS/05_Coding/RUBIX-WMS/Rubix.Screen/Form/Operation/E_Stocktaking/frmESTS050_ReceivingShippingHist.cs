/*
 * 13 Feb 2013:
 * 1. add wait screen when search
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using CSI.Business.Operation;
using Rubix.Framework;
using CSI.Business.DataObjects;
namespace Rubix.Screen.Form.Operation.E_Stocktaking
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Export)]
    public partial class frmESTS050_ReceivingShippingHist : FormBase
    {
        #region Member
        private ReceivingShippingHist db;
        #endregion

        #region  Enumeration

        private enum eColumn
        {
            Date,
            Time,
            DCCode,
            ProductCode,
            ProductName,
            ShipmentNo_ReceivingNo,
            PickingNo,
            LineNo,
            LotNo,
            //PalletNoRef,
            FinalDestination_SupplierCode,
            FinalDestination_SupplierName,
            ConditionOfProductCode,
            ConditionOfProduct,
            //Location,
            Qty,
            Incoming,
            Outgoing,
            PortOfLoadingCode,
            PortOfLoadingName,
            PortOfDischargeCode,
            PortOfDischargeName
        } 
        #endregion

        #region Properties
        private ReceivingShippingHist BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ReceivingShippingHist();
                }
                return db;
            }
        }
        #endregion

        #region Constructor
        public frmESTS050_ReceivingShippingHist()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarAdd, m_toolBarEdit, m_toolBarDelete, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh, q_toolBarView, q_toolBarAdd, q_toolBarEdit, q_toolBarDelete);
            ControlUtil.EnableControl(false, txtNumberOfReceiving,txtNumberOfShipping, txtReceivingQty, txtShippingQty);

            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl3);

            dtReceivingShippingDateFrom.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtReceivingShippingDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtReceivingShippingDateFrom.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtReceivingShippingDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtReceivingShippingDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtReceivingShippingDateFrom.Properties.Mask.EditMask = Common.FullDateFormat;

            dtReceivingShippingDateTo.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtReceivingShippingDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtReceivingShippingDateTo.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtReceivingShippingDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtReceivingShippingDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtReceivingShippingDateTo.Properties.Mask.EditMask = Common.FullDateFormat;
        }
        #endregion

        #region Event Handler Function
        private void frmESTS050_ReceivingShippingHist_Load(object sender, EventArgs e)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    DataLoading();
                    if (gdvSearchResult.RowCount == 0)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
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
                ClearAll();
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
                    warehouseControl.OwnerID = ownerControl.OwnerID;
                    warehouseControl.DataLoading();
                    itemControl.OwnerID = ownerControl.OwnerID;
                    itemControl.DataLoading();
                }
                else
                {
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    itemControl.OwnerID = Common.GetDefaultOwnerID();
                    itemControl.DataLoading();
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        #endregion

        #region Override Method

        #endregion

        #region Generic Function
        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                grdSearchResult.DataSource = BusinessClass.DataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, itemControl.ProductID, itemConditionControl.ProductConditionID, dtReceivingShippingDateFrom.DateTime, dtReceivingShippingDateTo.DateTime, txtLocation.Text.Trim());
                setTotal();
                base.GridViewOnChangeLanguage(grdSearchResult);
            }
            finally
            {
                this.CloseWaitScreen();
            }
        }

        private void setTotal()
        {
            //decimal numLine = Convert.ToDecimal((gdvSearchResult).DataRowCount);
            decimal numReceiving = 0.0M;
            decimal numShipping = 0.0M;
            Int32 numCountReceiving = 0;
            Int32 numCountShipping = 0;

            for (int i = 0; i < gdvSearchResult.DataRowCount; i++)
            {
                string objReceiving = null;
                string objShipping = null;
                if (gdvSearchResult.GetRowCellValue(i, gdvSearchResult.Columns[(int)eColumn.Incoming]) != null)
                    objReceiving = gdvSearchResult.GetRowCellValue(i, gdvSearchResult.Columns[(int)eColumn.Incoming]).ToString();
                if (gdvSearchResult.GetRowCellValue(i, gdvSearchResult.Columns[(int)eColumn.Outgoing]) != null)
                    objShipping = gdvSearchResult.GetRowCellValue(i, gdvSearchResult.Columns[(int)eColumn.Outgoing]).ToString();

                numReceiving = string.IsNullOrWhiteSpace(objReceiving) ? numReceiving + 0.0M : numReceiving + Convert.ToDecimal(objReceiving);
                numShipping = string.IsNullOrWhiteSpace(objShipping) ? numShipping + 0.0M : numShipping + Convert.ToDecimal(objShipping);
                if (objReceiving != null)
                {
                    numCountReceiving = numCountReceiving + 1;
                }

                if (objShipping != null)
                {
                    numCountShipping = numCountShipping + 1;
                }
            }

            //txtNumberOfLine.Text = numLine.ToString();
            txtReceivingQty.Text = numReceiving.ToString();
            txtShippingQty.Text = numShipping.ToString();

            txtNumberOfReceiving.Text = numCountReceiving.ToString();
            txtNumberOfShipping.Text = numCountShipping.ToString();
        }

        private void ClearAll()
        {
            ControlUtil.ClearControlData(this.Controls);
            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();
            itemControl.OwnerID = Common.GetDefaultOwnerID();
            itemControl.DataLoading();
            dtReceivingShippingDateFrom.EditValue = ControlUtil.GetStartDate();
            dtReceivingShippingDateTo.EditValue = ControlUtil.GetEndDate();
            grdSearchResult.DataSource = null;
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

            validate &= ownerControl.ValidateControl();
            validate &= warehouseControl.ValidateControl();
            
            if (dtReceivingShippingDateFrom.Text == string.Empty)
            {
                validate = false;
                errorProvider.SetError(dtReceivingShippingDateFrom, Rubix.Screen.Common.GetMessage("I0095"));
            }
            if (dtReceivingShippingDateTo.Text == string.Empty)
            {
                validate = false;
                errorProvider.SetError(dtReceivingShippingDateTo, Rubix.Screen.Common.GetMessage("I0095"));
            }
            return validate;
        }
        #endregion



    }
}
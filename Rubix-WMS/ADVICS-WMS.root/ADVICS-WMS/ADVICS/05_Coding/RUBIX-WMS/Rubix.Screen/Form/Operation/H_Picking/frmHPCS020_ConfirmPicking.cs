/*
 * 23 Jan 2013:
 * 1. add filter shipping status
 * 30 Jan 2013:
 * 1. add validate transaction date
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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Rubix.Screen.Report;
using System.Linq;
using System.Transactions;
using System.Data.SqlClient;
namespace Rubix.Screen.Form.Operation.H_Picking
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Export, Permission.Confirm)]
    public partial class frmHPCS020_ConfirmPicking : FormBase
    {
        #region Member
        private ConfirmPicking  db;
        private Dialog.dlgHPCS022_ConfirmPickingDetail m_Dialog = null;       
        #endregion

        #region Properties
        private ConfirmPicking BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ConfirmPicking();
                }
                return db;
            }
        }
        private Dialog.dlgHPCS022_ConfirmPickingDetail Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgHPCS022_ConfirmPickingDetail();
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
        public frmHPCS020_ConfirmPicking()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarAdd, m_toolBarDelete, m_toolBarCancel, m_toolBarRefresh,m_toolBarSave, m_toolBarEdit);
            ControlUtil.HiddenControl(false, m_toolBarConfirm);
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl1);

            dtPickingFrom.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtPickingFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingFrom.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtPickingFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtPickingFrom.Properties.Mask.EditMask = Common.FullDateFormat;

            dtPickingTo.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtPickingTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingTo.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtPickingTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtPickingTo.Properties.Mask.EditMask = Common.FullDateFormat;

            dtpDeliveryFrom.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtpDeliveryFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtpDeliveryFrom.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtpDeliveryFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtpDeliveryFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtpDeliveryFrom.Properties.Mask.EditMask = Common.FullDateFormat;

            dtpDeliveryTo.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtpDeliveryTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtpDeliveryTo.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtpDeliveryTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtpDeliveryTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtpDeliveryTo.Properties.Mask.EditMask = Common.FullDateFormat;
        }
        #endregion

        #region Override Method
        public override bool OnCommandConfirm()
        {
            try
            {
                if (checkBeforeConfirm())
                {
                    if (gdvSearchResult.GetFocusedDataRow() == null)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0085")); //Please select at least one Picking No. to confirm
                    }
                    else
                    {
                        Dialog.SelectRow = gdvSearchResult.GetFocusedDataRow();
                        if (Dialog.ShowDialog(this) == DialogResult.OK)
                        {
                            DataLoading();
                        }
                        Dialog = null;
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
        #endregion

        #region Event Handler Function

        private void frmHPCS020_ConfirmPicking_Load(object sender, EventArgs e)
        {
            try
            {
                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusId(false);
                shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                shipmentControl.DataLoading();
                pickingControl.ShipmentNo = "-1";
                pickingControl.DataLoading();

                dtpDeliveryFrom.EditValue = ControlUtil.GetStartDate();
                dtpDeliveryTo.EditValue = ControlUtil.GetEndDate();
                dtPickingFrom.EditValue = ControlUtil.GetStartDate();
                dtPickingTo.EditValue = ControlUtil.GetEndDate();
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
                if (true == ValidateData())
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
                ClearAll();
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
                    customerControl.OwnerID = ownerControl.OwnerID;
                    customerControl.DataLoading();

                    shipmentControl.PickDateFrom = DataUtil.Convert<DateTime>(dtPickingFrom.EditValue);
                    shipmentControl.PickDateTo = DataUtil.Convert<DateTime>(dtPickingTo.EditValue);
                    shipmentControl.OwnerID = ownerControl.OwnerID;
                    shipmentControl.DataLoading();

                    pickingControl.ShipmentNo = "-1";
                    pickingControl.DataLoading();
                }
                else
                {
                    customerControl.OwnerID = Common.GetDefaultOwnerID();
                    customerControl.DataLoading();
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                    shipmentControl.DataLoading();
                    pickingControl.ShipmentNo = "-1";
                    pickingControl.DataLoading();
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                shipmentControl.CustomerID = customerControl.CustomerID;
                shipmentControl.DataLoading();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void shipmentControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (ownerControl.OwnerID != null)
                {
                    pickingControl.ShipmentNo = shipmentControl.ShipmentNo;
                    pickingControl.DataLoading();
                }
                else
                {
                    pickingControl.ShipmentNo = "-1";
                    pickingControl.DataLoading();
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        
        private void dtPickingFrom_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                shipmentControl.PickDateFrom = DataUtil.Convert<DateTime>(dtPickingFrom.EditValue);
                shipmentControl.DataLoading();
                shipmentControl.ClearData();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void dtPickingTo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                shipmentControl.PickDateTo = DataUtil.Convert<DateTime>(dtPickingTo.EditValue);
                shipmentControl.DataLoading();
                shipmentControl.ClearData();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void chkUnconfirm_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkUnconfirm.Checked)
                {
                    ShowWaitScreen();
                    shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusId(false);
                    shipmentControl.OwnerID = ownerControl.OwnerID == null ? -1 : ownerControl.OwnerID;
                    shipmentControl.DataLoading();
                    ControlUtil.EnableControl(true,m_toolBarConfirm);
                    CloseWaitScreen();
                }
                grdSearchResult.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void chkAll_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked)
                {
                    shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusId(true);
                    shipmentControl.OwnerID = ownerControl.OwnerID == null ? -1 : ownerControl.OwnerID;
                    shipmentControl.DataLoading();
                    ControlUtil.EnableControl(false, m_toolBarConfirm);
                }
                grdSearchResult.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
                
        private void gdvSearchResult_CellMerge(object sender, CellMergeEventArgs e)
        {
            try
            {
                e.Handled = true;

                if (e.Column == gdcShipmentNo || e.Column == gdcPickingNo || e.Column == gdcDeliveryDate)
                {
                    DataRow firstRow = ((DataRowView)(gdvSearchResult.GetRow(e.RowHandle1))).Row;
                    DataRow secondRow = ((DataRowView)(gdvSearchResult.GetRow(e.RowHandle2))).Row;
                    if (firstRow["ShipmentNo"].Equals(secondRow["ShipmentNo"]) && firstRow["PickingNo"].Equals(secondRow["PickingNo"]))
                        e.Merge = true;
                    else
                        e.Merge = false;
                }
                else if (e.Column == gdcSortedLineNo || e.Column == gdcProductCode || e.Column == gdcProductName || e.Column == gdcProductCondition || e.Column == gdcQty)
                {
                    DataRow firstRow = ((DataRowView)(gdvSearchResult.GetRow(e.RowHandle1))).Row;
                    DataRow secondRow = ((DataRowView)(gdvSearchResult.GetRow(e.RowHandle2))).Row;

                    if (firstRow["ShipmentNo"].Equals(secondRow["ShipmentNo"]) && firstRow["PickingNo"].Equals(secondRow["PickingNo"]) && Convert.ToInt32(firstRow["LineNo"]) == Convert.ToInt32(secondRow["LineNo"]))
                        e.Merge = true;
                    else
                        e.Merge = false;
                }
                else
                    e.Merge = false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());

            }
        }

        private void gdvSearchResult_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                DataRow focus = ((DataRowView)(gdvSearchResult.GetRow(e.RowHandle))).Row;
                if (focus != null && Convert.ToInt32(focus["CanEditConfirm"]) == 0)
                {
                    if (e.Column == gdcQtyActual || e.Column == gdcStatus)
                    {
                        e.Appearance.BackColor = Common.CompleteColor();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());

            }
        }
        #endregion
        
        #region Generic Function
        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();

                DataTable dt = BusinessClass.DataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, shipmentControl.ShipmentNo, pickingControl.PickingNo
                                                         ,DataUtil.Convert<DateTime>(dtPickingFrom.EditValue), DataUtil.Convert<DateTime>(dtPickingTo.EditValue), (chkAll.Checked ? 1 : 0)
                                                         ,customerControl.CustomerID, (DateTime?)dtpDeliveryFrom.EditValue, (DateTime?)dtpDeliveryTo.EditValue);

                grdSearchResult.DataSource = dt;

                base.GridViewOnChangeLanguage(grdSearchResult);
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
        
        private Boolean ValidateData()
        {
            Boolean validate = true;
            errorProvider.ClearErrors();

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
            //    noError = false;
            //}

            if (dtpDeliveryFrom.EditValue == null)
            {
                errorProvider.SetError(dtpDeliveryFrom, Common.GetMessage("I0136"));
                validate = false;
            }

            if (dtpDeliveryTo.EditValue == null)
            {
                errorProvider.SetError(dtpDeliveryTo, Common.GetMessage("I0136"));
                validate = false;
            }

            return validate;
        }

        private Boolean checkBeforeConfirm()
        {
            Boolean noError = true;
            Boolean chkSelect = false;
            //string messageId = string.Empty;
            //List<sp_HPCS020_ConfirmPicking_SearchAll_Result> temp = this.DisplayDatasource;
            //if (temp == null)
            //    return false;

            //foreach (sp_HPCS020_ConfirmPicking_SearchAll_Result item in temp)
            //{
            //    if (item.Select == true)
            //    {
            //        if (item.CanEditConfirm != 1)
            //        {
            //            MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0160"));
            //            return false;
            //        }
            //        if (false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(item.PickingDate))
            //        {
            //            MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0236"));
            //            return false;
            //        }
            //        chkSelect = true;
            //    }                
            //}
            //gdvSearchResult.ActiveFilterEnabled = false;

            //if (noError == false)
            //    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0111"));
            
            //if (chkSelect == false)
            //{
            //    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0085")); //Please select at least one Picking No. to confirm
            //    noError = false;
            //}
            
            return noError;
        }        

        private void ClearAll()
        {
            ownerControl.ClearData();
            customerControl.OwnerID = Common.GetDefaultOwnerID();
            customerControl.DataLoading();
            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();
            shipmentControl.OwnerID = Common.GetDefaultOwnerID();
            shipmentControl.DataLoading();
            pickingControl.ShipmentNo = "-1";
            pickingControl.DataLoading();
          
            grdSearchResult.DataSource = null;
            errorProvider.ClearErrors();
            chkUnconfirm.Checked = true;

            dtpDeliveryFrom.EditValue = ControlUtil.GetStartDate();
            dtpDeliveryTo.EditValue = ControlUtil.GetEndDate();
            dtPickingFrom.EditValue = ControlUtil.GetStartDate();
            dtPickingTo.EditValue = ControlUtil.GetEndDate();
        }
        #endregion              


    }
}
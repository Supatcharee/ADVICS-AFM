using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraGrid;
using CSI.Business.Operation;
using Rubix.Framework;
using CSI.Business.DataObjects;
using DevExpress.XtraGrid.Views.Grid;
using System.Linq;

namespace Rubix.Screen.Form.Operation.R_OrderMaintenance
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Export, Permission.Edit)]
    public partial class frmROMS020_OrderCancel : FormBase
    {
        #region Member
        private OrderCancel db;
        private Common.eScreenMode ScreenMode;
        #endregion

        #region Enumeration
        private enum eColReceive
        {
            Select,
            Progress,
            LineNo,
            SortedLineNo,
            ProductCode,
            ProductName,
            ProductCondition,
            Qty,
            ReceivingEntryDate,
            TransitInstructionIssuedDate,
            ReceivingDate,
            TransitDate,
            DetailRemark,
            ReceivingNo,
            SupplierCode,
            SupplierName,
            PortOfDischargeCode,
            PortOfDischargeName,
            FinalDestinationCode,
            FinalDestinationName,
            Remark,
            StatusID
        }
        // 15 Jan 2013: comment because no used
        //private enum eColShipping
        //{
        //    Select,
        //    Progress,
        //    LineNo,
        //    ProductCode,
        //    ProductName,
        //    ProductCondition,
        //    Qty,
        //    EntryDate,
        //    StockControlDate,
        //    PickingListIssuedDate,
        //    PickingDate,
        //    ShippingDate,
        //    DOIssueDate,
        //    DetailRemark,
        //    ShipmentNo,
        //    PickingNo,
        //    Remark,
        //    PortOfDischargeCode,
        //    PortOfDischargeName,
        //    FinalDestinationCode,
        //    FinalDestinationName,
        //    StatusID
        //}
        // end 15 Jan 2013: comment because no used
        private enum eColumn
        {
            Select,
            Progress,
            LineNo,
            SortedLineNo,
            ProductCode,
            ProductName,
            ProductCondition,
            Qty,
            ReceivingEntryDate,
            TransitInstructionIssuedDate,
            ReceivingDate,
            TransitDate,
            EntryDate,
            StockControlDate,
            PickingListIssuedDate,
            PickingDate,
            ShippingDate,
            DOIssueDate,
            DetailRemark,
            ReceivingNo,
            ShipmentNo,
            PickingNo,
            SupplierCode,
            SupplierName,
            PortOfDischargeCode,
            PortOfDischargeName,
            FinalDestinationCode,
            FinalDestinationName,
            Remark,
            StatusID
        }
        #endregion

        #region Properties
        private OrderCancel BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new OrderCancel();
                }
                return db;
            }
        }
        #endregion

        #region Constructor
        public frmROMS020_OrderCancel()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarDelete, m_toolBarView, m_toolBarRefresh);
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(gpcSearchCriteria);
        }
        #endregion

        #region Override Method
        public override bool OnCommandEdit()
        {
            try
            {
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                    return false;
                }
                ScreenMode = Common.eScreenMode.Edit;
                ControlUtil.EnableControl(true, m_toolBarSave, m_toolBarCancel);
                ControlUtil.EnableControl(false, m_toolBarEdit);
                ControlUtil.EnableControl(false, btnSearch, btnClear, gpcSearchCriteria);
                ControlUtil.EnableControl(true, btnSelectAll, btnUnselectAll);
                gdcSelect.Visible = true;
                gdcSelect.VisibleIndex = 0;
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
                return false;
            }
        }

        public override bool OnCommandSave()
        {
            try
            {
                gdvSearchResult.PostEditor();
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                    return false;
                }
                if (MessageDialog.ShowConfirmationMsg(this, Rubix.Screen.Common.GetMessage("I0015")) == DialogButton.Yes)
                {
                    ShowWaitScreen();

                    if (rdoReceiving.Checked)
                    {
                        List<sp_ROMS020_OrderCancel_SearchAll_Receiving_Result> data = ((List<sp_ROMS020_OrderCancel_SearchAll_Receiving_Result>)grdSearchResult.DataSource).Where(c => c.Select == true).ToList();

                        if (data.Count > 0)
                        {
                            string MsgId = BusinessClass.SaveDataReceiving(data);

                            if (!string.IsNullOrEmpty(MsgId))
                            {
                                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage(MsgId));
                                return false;
                            }
                        }
                        else
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                            return false;
                        }
                    }
                    else if (rdoShipping.Checked)
                    {
                        List<sp_ROMS020_OrderCancel_SearchAll_Shipping_Result> data = ((List<sp_ROMS020_OrderCancel_SearchAll_Shipping_Result>)grdSearchResult.DataSource).Where(c => c.Select == true).ToList();

                        if (data.Count > 0)
                        {
                            string MsgId = BusinessClass.SaveDataShipping(data);

                            if (!string.IsNullOrEmpty(MsgId))
                            {
                                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage(MsgId));
                                return false;
                            }
                        }
                        else
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                            return false;
                        }
                    }

                    CloseWaitScreen();
                    MessageDialog.ShowInformationMsg(Rubix.Screen.Common.GetMessage("I0003"));
                    ScreenMode = Common.eScreenMode.View;
                    ControlUtil.EnableControl(false, m_toolBarSave, m_toolBarCancel);
                    ControlUtil.EnableControl(true, m_toolBarEdit);
                    ControlUtil.EnableControl(true, btnSearch, btnClear, gpcSearchCriteria);
                    ControlUtil.EnableControl(false, btnSelectAll, btnUnselectAll);
                   
                    if (rdoReceiving.Checked)
                    {
                        ControlUtil.EnableControl(false, customerControl);
                    }
                    gdcSelect.Visible = false;
                    if (!DataLoading())
                    {
                        grdSearchResult.DataSource = null;
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
                return false;
            }
        }

        public override bool OnCommandCancel()
        {
            try
            {
                ScreenMode = Common.eScreenMode.View;
                SelectCheckBox(false);
                ControlUtil.EnableControl(false, m_toolBarSave, m_toolBarCancel);
                ControlUtil.EnableControl(true, m_toolBarEdit);
                ControlUtil.EnableControl(true, btnSearch, btnClear, gpcSearchCriteria);
                ControlUtil.EnableControl(false, btnSelectAll, btnUnselectAll);
                if (rdoReceiving.Checked)
                {
                    ControlUtil.EnableControl(false, customerControl);
                }
                gdcSelect.Visible = false;
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
                return false;
            }
        }
        #endregion

        #region Event Handler Function
        private void frmROMS020_OrderCancel_Load(object sender, EventArgs e)
        {
            try
            {
                ControlUtil.EnableControl(false, m_toolBarSave, m_toolBarCancel, m_toolBarEdit);
                ControlUtil.EnableControl(false, customerControl);
                ControlUtil.EnableControl(false, btnSelectAll, btnUnselectAll);
                gdcSelect.Visible = false;
                ScreenMode = Common.eScreenMode.View;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
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
                        ControlUtil.EnableControl(false, m_toolBarEdit);
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0014"));
                        gdvSearchResult.OptionsBehavior.Editable = false;
                    }
                    else
                    {
                        ControlUtil.EnableControl(true, m_toolBarEdit);
                        gdvSearchResult.OptionsBehavior.Editable = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void gdvSearchResult_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                int StatusID = Convert.ToInt32(View.GetRowCellValue(gdvSearchResult.FocusedRowHandle, eColReceive.StatusID.ToString()));

                if (StatusID == CSI.Business.Common.Status.OrderCancel || StatusID == CSI.Business.Common.Status.NewReceivingEntry)
                {
                    e.Cancel = true;
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0123"));
                }
                else if (StatusID == CSI.Business.Common.Status.CompleteTransit)
                {
                    e.Cancel = true;
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0100"));
                }
                else if (StatusID >= CSI.Business.Common.Status.CompleteShipping)
                {
                    e.Cancel = true;
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0103"));
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        
        private void rdoReceiving_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoReceiving.Checked)
            {
                customerControl.ClearData();
                customerControl.EnableControl = false;
                customerControl.RequireField = false;                
            }
            else
            {
                customerControl.ClearData();
                customerControl.EnableControl = true;
                customerControl.RequireField = true;
            }
            grdSearchResult.DataSource = null;
            ControlUtil.EnableControl(false, m_toolBarEdit);
            ControlUtil.ClearControlData(groupControl1);
        }
        
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (ScreenMode == Common.eScreenMode.Edit)
            {
                SelectCheckBox(true);
            }
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            if (ScreenMode == Common.eScreenMode.Edit)
            {
                SelectCheckBox(false);
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
                if (ownerControl.OwnerID != null)
                {
                    warehouseControl.OwnerID = ownerControl.OwnerID;
                    warehouseControl.DataLoading();
                    customerControl.OwnerID = ownerControl.OwnerID;
                    customerControl.DataLoading();
                }
                else
                {
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    customerControl.OwnerID = Common.GetDefaultOwnerID();
                    customerControl.DataLoading();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        #endregion
        
        #region Generic Function
        private bool DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                grdSearchResult.DataSource = null;
                if (rdoReceiving.Checked == true)
                {                    
                    List<sp_ROMS020_OrderCancel_SearchAll_Receiving_Result> data = BusinessClass.DataLoadReceiving(ownerControl.OwnerID, warehouseControl.WarehouseID, txtSlipNo.Text.Trim());
                    
                    if (data.Count == 0)
                    {
                        return false;
                    }

                    grdSearchResult.DataSource = data;

                    txtSupplierCode.Text = data[0].SupplierCode;
                    txtSupplierName.Text = data[0].SupplierName;
                    txtPortCode.Text = data[0].PortOfDischargeCode;
                    txtPortName.Text = data[0].PortOfDischargeName;
                    txtFinalCode.Text = data[0].FinalDestinationCode;
                    txtFinalName.Text = data[0].FinalDestinationName;
                    txtRemark.Text = data[0].Remark;
                }
                else if (rdoShipping.Checked == true)
                {
                    List<sp_ROMS020_OrderCancel_SearchAll_Shipping_Result> data = BusinessClass.DataLoadShipping(ownerControl.OwnerID, warehouseControl.WarehouseID, txtSlipNo.Text.Trim(), null, customerControl.CustomerID);

                    if (data.Count == 0)
                    {
                        return false;
                    }

                    grdSearchResult.DataSource = data;                    

                    txtSupplierCode.Text = string.Empty;
                    txtSupplierName.Text = string.Empty;
                    txtPortCode.Text = data[0].PortOfDischargeCode;
                    txtPortName.Text = data[0].PortOfDischargeName;
                    txtFinalCode.Text = data[0].FinalDestinationCode;
                    txtFinalName.Text = data[0].FinalDestinationName;
                    txtRemark.Text = data[0].Remark;
                }
                base.GridViewOnChangeLanguage(grdSearchResult);
            }
            finally
            {
                this.CloseWaitScreen();
            }
            return true;
        }
        
        private bool ValidateData()
        {
            errorProvider.ClearErrors();
            bool validate = true;

            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            customerControl.ErrorText = Common.GetMessage("I0249");
            customerControl.RequireField = false;

            validate &= ownerControl.ValidateControl();
            validate &= warehouseControl.ValidateControl();

            if (rdoShipping.Checked)
            {
                customerControl.RequireField = true;
                validate &= customerControl.ValidateControl();
            }
            
            if (txtSlipNo.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtSlipNo, Rubix.Screen.Common.GetMessage("I0105"));
                validate = false;
            }

            return validate;
        }
        
        private void ClearAll()
        {
            errorProvider.ClearErrors();
            ControlUtil.ClearControlData(this.Controls);
            ownerControl.ClearData();
            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();
            customerControl.OwnerID = Common.GetDefaultOwnerID();
            customerControl.DataLoading();
            rdoReceiving.Checked = true;
            grdSearchResult.DataSource = null;
            ControlUtil.EnableControl(false, m_toolBarEdit);
            gdcSelect.Visible = false;
        }
        
        private void SelectCheckBox(bool Condition)
        {
            for (int i = 0; i < (gdvSearchResult).DataRowCount; i++)
            {
                int StatusID = Convert.ToInt32(gdvSearchResult.GetRowCellValue(i, eColReceive.StatusID.ToString()));
                if (StatusID != CSI.Business.Common.Status.OrderCancel && StatusID != CSI.Business.Common.Status.NewReceivingEntry)
                {
                    gdvSearchResult.SetRowCellValue(i, gdcSelect, Condition);
                }
            }
        }
        #endregion
    }
}
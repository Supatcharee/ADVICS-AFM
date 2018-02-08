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
using System.Data.Objects;
using CSI.Business.DataObjects;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Data.SqlClient;
namespace Rubix.Screen.Form.Operation.R_OrderMaintenance
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Edit, Permission.Export)]
    public partial class frmROMS010_OrderRefresh : FormBase
    {
        #region Member
        private OrderRefresh db;
        private ReceivingProgress db_Rcv;
        private ShippingProgress db_Shp;
        private Rubix.Screen.Form.Operation.F_ShippingEntry.Dialog.dlgFSES011_ShippingInstruction m_DialogShipping = null;
        private Rubix.Screen.Form.Operation.B_ReceivingEntry.Dialog.dlgBRES010_ReceivingEntry m_DialogReceiving = null;
        private Common.eScreenMode ScreenMode;
        #endregion

        #region Enumeration
        private enum eColReceive
        {
            Select,
            ReceivingNo,
            Entry,
            TransitInstruction,
            ReceivingDate,
            TransitDate,
            WarehouseID,
            SupplierID,
            Remark,
            Installment,
            WarehouseCode,
            SupplierCode,
            SupplierName,
            OwnerID
        }
        private enum eColShipping
        {
            Select,
            ShipmentNo,
            Entry,
            StockControl,
            PickingInstruction,
            Picking,
            Shipping,
            Transporation,
            WarehouseID,
            DeliveryDate,
            FinalDestinationID,
            WarehouseCode,
            FinalDestinationCode,
            PortCode,
            PortName,
            Remark,
            Installment,
            PickingNo
        }
        private enum eColumn
        {
            Select,
            No,
            Entry,
            TransitInstruction,
            ReceivingDate,
            TransitDate,
            StockControl,
            PickingInstruction,
            Picking,
            Shipping,
            Transporation,
            PortCode,
            PortName,
            WarehouseID,
            WarehouseCode,
            SupplierID,
            SupplierCode,
            SupplierName,
            Remark,
            Installment,
            OwnerID,
            DeliveryDate,
            FinalDestinationID,
            FinalDestinationCode,
            PickingNo
        }
        #endregion

        #region Properties
        private OrderRefresh BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new OrderRefresh();
                }
                return db;
            }
        }
        private ReceivingProgress BusinessClassReceiving
        {
            get
            {
                if (db_Rcv == null)
                {
                    db_Rcv = new ReceivingProgress();
                }
                return db_Rcv;
            }
        }
        private ShippingProgress BusinessClassShipping
        {
            get
            {
                if (db_Shp == null)
                {
                    db_Shp = new ShippingProgress();
                }
                return db_Shp;
            }
        }
        private Rubix.Screen.Form.Operation.B_ReceivingEntry.Dialog.dlgBRES010_ReceivingEntry DialogReceiving
        {
            get
            {
                if (m_DialogReceiving == null)
                {
                    m_DialogReceiving = new Rubix.Screen.Form.Operation.B_ReceivingEntry.Dialog.dlgBRES010_ReceivingEntry();
                }
                m_DialogReceiving.ShowActual = true;
                return m_DialogReceiving;
            }
            set
            {
                m_DialogReceiving = value;
            }
        }
        private Rubix.Screen.Form.Operation.F_ShippingEntry.Dialog.dlgFSES011_ShippingInstruction DialogShipping
        {
            get
            {
                if (m_DialogShipping == null)
                {
                    m_DialogShipping = new Rubix.Screen.Form.Operation.F_ShippingEntry.Dialog.dlgFSES011_ShippingInstruction();
                }

                m_DialogShipping.ShowActual = true;
                return m_DialogShipping;
            }
            set
            {
                m_DialogShipping = value;
            }
        }
        #endregion

        #region Constructor
        public frmROMS010_OrderRefresh()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarDelete, m_toolBarRefresh);
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl3);
        }
        #endregion

        #region Event Handler Function
        private void frmROMS010_OrderRefresh_Load(object sender, EventArgs e)
        {
            ControlUtil.EnableControl(false, m_toolBarSave, m_toolBarCancel, m_toolBarEdit);
            //txtStoring.Enabled = false;
            //txtDelivDate.Enabled = false;
            finalDestinationControl.EnableControl = false;
            //warehouseControl.EnableControl = false;
            //txtRemark.Enabled = false;
            //txtPortSupplierCode.Enabled = false;
            //txtPortSupplierName.Enabled = false;
            pickingControl1.EnableControl = false;
            customerControl.EnableControl = false;
            HiddenGrid();
            ScreenMode = Common.eScreenMode.View;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    if (!DataLoading())
                    {
                        m_toolBarEdit.Enabled = false;
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0014"));
                        ControlUtil.ClearControlData(txtDelivDate, txtPortSupplierCode, txtPortSupplierName, txtRemark);
                        //warehouseControl.ClearData();
                        finalDestinationControl.ClearData();
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

        private void rdoReceiving_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoReceiving.Checked == true)
            {
                rdoShipping.Checked = false;
                pickingControl1.EnableControl = false;
                customerControl.EnableControl = false;
                customerControl.RequireField = false;
                customerControl.ClearData();
            }
            else
            {

            }
        }

        private void rdoShipping_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoShipping.Checked == true)
            {
                rdoReceiving.Checked = false;
                pickingControl1.EnableControl = true;
                customerControl.EnableControl = true;
                customerControl.RequireField = true;
            }
            else
            {

            }
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

        private void txtSlipNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSlipNo.Text.Trim()))
                {
                    pickingControl1.ShipmentNo = txtSlipNo.Text.Trim();
                    pickingControl1.DataLoading();
                }
                else
                {
                    pickingControl1.ShipmentNo = null;
                    pickingControl1.DataLoading();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());

            }
        }

        private void repSelect_EditValueChanged(object sender, EventArgs e)
        {
            gdvSearchResult.PostEditor();
        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ownerControl.OwnerCode))
            {
                warehouseControl.OwnerID = ownerControl.OwnerID;
                warehouseControl.DataLoading();
                customerControl.OwnerID = ownerControl.OwnerID;
                customerControl.DataLoading();
            }
        }

        private void txtSlipNo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSlipNo.Text.Trim()))
                {
                    pickingControl1.ShipmentNo = txtSlipNo.Text.Trim();
                    pickingControl1.DataLoading();
                }
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
                ScreenMode = Common.eScreenMode.Edit;
                EnableGrid();
                m_toolBarSave.Enabled = true;
                m_toolBarCancel.Enabled = true;
                m_toolBarEdit.Enabled = false;
                btnSearch.Enabled = false;
                btnClear.Enabled = false;
                
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
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this, Rubix.Screen.Common.GetMessage("I0015")) == DialogButton.Yes)
                {
                    try
                    {
                        SaveData();
                        MessageDialog.ShowInformationMsg(Rubix.Screen.Common.GetMessage("I0003"));
                    }
                    catch (Exception ex)
                    {
                        if (ex.InnerException != null)
                        {
                            if (ex.InnerException is SqlException 
                                && (((SqlException)ex.InnerException).Number == 50009 
                                || ((SqlException)ex.InnerException).Number == 50010))
                            {
                                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0270"));
                            }
                            else
                                MessageDialog.ShowSystemErrorMsg(this, ex);

                        }
                        else
                            MessageDialog.ShowSystemErrorMsg(this, ex);
                    }
                    ScreenMode = Common.eScreenMode.View;
                    btnSearch.Enabled = true;
                    btnClear.Enabled = true;
                    m_toolBarSave.Enabled = false;
                    m_toolBarCancel.Enabled = false;
                    m_toolBarEdit.Enabled = true;
                    if (!DataLoading())
                    {
                        grdSearchResult.DataSource = null;
                        HiddenGrid();
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
                return false;
            }

        }
        public override bool OnCommandCancel()
        {
            try
            {
                DisableGrid();
                m_toolBarSave.Enabled = false;
                m_toolBarCancel.Enabled = false;
                m_toolBarEdit.Enabled = true;
                btnSearch.Enabled = true;
                btnClear.Enabled = true;
                ScreenMode = Common.eScreenMode.View;
                SelectCheckBox(false);
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
                if (ScreenMode == Common.eScreenMode.View)
                {
                    // no data found
                    if (gdvSearchResult.RowCount == 0)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                        return;
                    }

                    if (rdoReceiving.Checked == true)
                    {
                        sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result data =
                            (sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result)gdvSearchResult.GetFocusedRow();

                        DialogReceiving.ReceivingNo = data.ReceivingNo;
                        DialogReceiving.Installment = data.Installment;
                        DialogReceiving.ScreenMode = ScreenMode;
                        DialogReceiving.BusinessClass = new ReceivingEntry();//BusinessClassReceiving;

                        DialogReceiving.ShowDialog(this);
                    }
                    else if (rdoShipping.Checked == true)
                    {

                        sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result data =
                            (sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result)gdvSearchResult.GetFocusedRow();

                        DialogShipping.BusinessClass = new ShippingInstruction();
                        DialogShipping.BusinessClass.ShipmentNo = data.ShipmentNo;
                        DialogShipping.BusinessClass.PickingNo = data.PickingNo;
                        DialogShipping.BusinessClass.Installment = data.Installment;
                        DialogShipping.ScreenMode = ScreenMode;

                        DialogShipping.ShowDialog(this);
                    }
                }
                DialogShipping = null;
                DialogReceiving = null;
            }
            catch (Exception ex)
            {
                //MessageDialog.ShowSystemErrorMsg(this, ex);
                //return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private bool DataLoading()
        {
            try
            {
                grdSearchResult.DataSource = null;
                HiddenGrid();

                if (rdoReceiving.Checked == true)
                {
                    // 13 Feb 2013: add wait screen
                    this.ShowWaitScreen();
                    // end 13 Feb 2013
                    List<sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result> data = BusinessClass.DataLoadReceiving(ownerControl.OwnerID, warehouseControl.WarehouseID, txtSlipNo.Text.Trim());

                    if (data.Count == 0)
                    {
                        return false;
                    }

                    // Set Field Name & Caption
                    gcNo.FieldName = "ReceivingNo";
                    gcNo.Caption = Common.GetMessage("I0331");

                    grdSearchResult.DataSource = data;
                    for (int i = 0; i < gdvSearchResult.Columns.Count; i++)
                    {
                        if (gdvSearchResult.Columns[i].ColumnType == typeof(DateTime) || gdvSearchResult.Columns[i].ColumnType == typeof(DateTime?))
                        {
                            gdvSearchResult.Columns[i].DisplayFormat.FormatString = Common.FullDatetimeFormat;
                            gdvSearchResult.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        }
                    }
                    // 13 Feb 2013: add wait screen
                    this.CloseWaitScreen();
                    // end 13 Feb 2013

                    gdvSearchResult.Columns[(int)eColumn.TransitDate].Visible = true;
                    gdvSearchResult.Columns[(int)eColumn.ReceivingDate].Visible = true;
                    gdvSearchResult.Columns[(int)eColumn.TransitInstruction].Visible = true;
                    gdvSearchResult.Columns[(int)eColumn.Entry].Visible = true;
                    gdvSearchResult.Columns[(int)eColumn.No].Visible = true;
                    gdvSearchResult.Columns[(int)eColumn.Select].Visible = true;

                    ControlUtil.SetBestWidth(gdvSearchResult);
                    // Header \\

                    //warehouseControl.WarehouseCode = data[0].WarehouseCode;
                    txtRemark.Text = data[0].Remark;
                    txtPortSupplierCode.Text = data[0].SupplierCode;
                    txtPortSupplierName.Text = data[0].SupplierName;

                }
                else if (rdoShipping.Checked == true)
                {
                    // 13 Feb 2013: add wait screen
                    this.ShowWaitScreen();
                    // end 13 Feb 2013
                    List<sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result> data = BusinessClass.DataLoadShipping(ownerControl.OwnerID, warehouseControl.WarehouseID, txtSlipNo.Text.Trim(), pickingControl1.PickingNo,customerControl.CustomerID);
                    

                    if (data.Count == 0)
                    {
                        return false;
                    }

                    // Set Field Name & Caption
                    gcNo.FieldName = "ShipmentNo";
                    gcNo.Caption = Common.GetMessage("I0332");

                    grdSearchResult.DataSource = data;
                    grdSearchResult.DataSource = data;
                    for (int i = 0; i < gdvSearchResult.Columns.Count; i++)
                    {
                        if (gdvSearchResult.Columns[i].ColumnType == typeof(DateTime) || gdvSearchResult.Columns[i].ColumnType == typeof(DateTime?))
                        {
                            gdvSearchResult.Columns[i].DisplayFormat.FormatString = Common.FullDatetimeFormat;
                            gdvSearchResult.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        }
                    }
                    // 13 Feb 2013: add wait screen
                    this.CloseWaitScreen();
                    // end 13 Feb 2013

                    gdvSearchResult.Columns[(int)eColumn.PortName].Visible = true;
                    gdvSearchResult.Columns[(int)eColumn.PortCode].Visible = true;
                    gdvSearchResult.Columns[(int)eColumn.Transporation].Visible = true;
                    gdvSearchResult.Columns[(int)eColumn.Shipping].Visible = true;
                    gdvSearchResult.Columns[(int)eColumn.Picking].Visible = true;
                    gdvSearchResult.Columns[(int)eColumn.PickingInstruction].Visible = true;
                    gdvSearchResult.Columns[(int)eColumn.StockControl].Visible = true;
                    gdvSearchResult.Columns[(int)eColumn.Entry].Visible = true;
                    gdvSearchResult.Columns[(int)eColumn.No].Visible = true;
                    gdvSearchResult.Columns[(int)eColumn.Select].Visible = true;

                    ControlUtil.SetBestWidth(gdvSearchResult);
                    // Header \\
                    //warehouseControl.WarehouseCode = data[0].WarehouseCode;
                    txtDelivDate.Text = data[0].DeliveryDate.ToShortDateString();
                    finalDestinationControl.FinalDestinationID = data[0].FinalDestinationID;
                    txtRemark.Text = data[0].Remark;
                    txtPortSupplierCode.Text = data[0].PortCode;
                    txtPortSupplierName.Text = data[0].PortName;
                }
                DisableGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // 13 Feb 2013: add wait screen
                this.CloseWaitScreen();
                // end 13 Feb 2013
            }
            return true;
        }

        private void EnableGrid()
        {
            gdvSearchResult.OptionsBehavior.Editable = true;

            for (int i = 0; i < gdvSearchResult.Columns.Count; i++)
            {
                if (i == 0)
                {
                    gdvSearchResult.Columns[i].OptionsColumn.AllowEdit = true;
                    gdvSearchResult.Columns[i].OptionsColumn.AllowFocus = true;
                }
            }
        }
        private void DisableGrid()
        {
            gdvSearchResult.OptionsBehavior.Editable = false;

            for (int i = 0; i < gdvSearchResult.Columns.Count; i++)
            {
                gdvSearchResult.Columns[i].OptionsColumn.AllowEdit = false;
                gdvSearchResult.Columns[i].OptionsColumn.AllowFocus = false;

            }


        }
        private void SaveData()
        {
            try
            {
                if (rdoReceiving.Checked == true)
                {
                    SaveReceiving();
                }
                else if (rdoShipping.Checked == true)
                {
                    SaveShipping();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void SaveReceiving()
        {
            List<sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result> temp = (List<sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result>)grdSearchResult.DataSource;

            List<sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result> data = new List<sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result>();

            foreach (sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result item in temp)
            {
                if (item.Select == true)
                {
                    data.Add(item);
                }
            }

            if (data.Count > 0)
            {
                BusinessClass.SaveDataReceiving(data);
            }
            else
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
            }
        }
        private void SaveShipping()
        {
            List<sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result> temp = (List<sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result>)grdSearchResult.DataSource;

            List<sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result> data = new List<sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result>();

            foreach (sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result item in temp)
            {
                if (item.Select == true)
                {
                    data.Add(item);
                }
            }

            if (data.Count > 0)
            {
                string ResultMsg = BusinessClass.SaveDataShipping(data);
                if (!string.IsNullOrEmpty(ResultMsg))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, ResultMsg);
                }
            }
            else
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
            }
        }
        private void ClearAll()
        {
            // Search Condition
            rdoReceiving.Checked = true;
            rdoShipping.Checked = false;
            ownerControl.ClearData();
            warehouseControl.ClearData();
            txtSlipNo.Text = string.Empty;
            pickingControl1.ClearData();

            // Search Result
            txtStoring.Text = string.Empty;
            txtDelivDate.Text = string.Empty;
            finalDestinationControl.ClearData();
            warehouseControl.ClearData();
            txtRemark.Text = string.Empty;
            txtPortSupplierCode.Text = string.Empty;
            txtPortSupplierName.Text = string.Empty;

            m_toolBarEdit.Enabled = false;

            grdSearchResult.DataSource = null;
            HiddenGrid();

            customerControl.CustomerID = null;
            customerControl.DataLoading();

            warehouseControl.OwnerID = null;
            warehouseControl.DataLoading();
            pickingControl1.ShipmentNo = null;
            pickingControl1.DataLoading();
        }
        private bool ValidateData()
        {
            Boolean errFlag = true;
            ownerControl.RequireField = true;
            ownerControl.ErrorText = Rubix.Screen.Common.GetMessage("I0026");
            if (!ownerControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(ownerControl, String.Empty);
            }

            //customerControl.ErrorText = Rubix.Screen.Common.GetMessage("I0249");
            //if (!customerControl.ValidateControl())
            //{
            //    errFlag = false;
            //}
            //else
            //{
            //    errorProvider.SetError(customerControl, String.Empty);
            //}

            warehouseControl.RequireField = true;
            warehouseControl.ErrorText = Rubix.Screen.Common.GetMessage("I0045");
            if (!warehouseControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(warehouseControl, String.Empty);
            }
            return errFlag;
        }
        private void HiddenGrid()
        {
            for (int i = 0; i < gdvSearchResult.Columns.Count; i++)
            {
                ControlUtil.HiddenControl(true, gdvSearchResult.Columns[i]);
            }
        }
        private void SelectCheckBox(bool Condition)
        {
            for (int i = 0; i < (gdvSearchResult).DataRowCount; i++)
            {
                gdvSearchResult.SetRowCellValue(i, gcSelect, Condition);
            }
        }
        #endregion

    }
}
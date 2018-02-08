using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using CSI.Business.Operation;

namespace Rubix.Screen.Form.Operation.K_Packing.Dialog
{
    public partial class dlgKPK012_PackingManagementDialog : DialogBase
    {
        #region Member
        private PackingInstruction m_BusinessClass = null;
        #endregion

        #region Properties
        private PackingInstruction BusinessClass
        {
            get
            {
                if (m_BusinessClass == null)
                {
                    m_BusinessClass = new PackingInstruction();
                }
                return m_BusinessClass;
            }
        }
        public DateTime ShippingDate { get; set; }
        public DateTime PackingDate { get; set; }
        public string ShipmentNo {get; set;}
        public string PackingNo { get; set; }
        public int? OwnerID { get; set; }
        #endregion
        
        #region Constructor
        public dlgKPK012_PackingManagementDialog()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarClear);
        } 
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                ShowWaitScreen();

                gdvSearchResult.CloseEditor();
                gdvSearchResult.UpdateCurrentRow();

                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                    return false;
                }

                DataRow[] dr = (grdSearchResult.DataSource as DataTable).Select("Select = 1 and MoveBox > 0");
                if (dr.Length <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                    return false;
                }

                if (ValidateData())
                {
                    BusinessClass.PackingManagementSave(ownerControl.OwnerID
                                                        , warehouseControl.WarehouseID
                                                        , customerControl.CustomerID
                                                        , dtShippingDateTo.DateTime
                                                        , dtPackingDateTo.EditValue != null ? dtPackingDateTo.DateTime : DataUtil.Convert<DateTime>(dtPackingDateNew.EditValue)
                                                        , DataUtil.Convert<DateTime>(dtPickingDateNew.EditValue)
                                                        , shipmentControlTo.ShipmentNo
                                                        , packingControlTo.PackingNo
                                                        , dr.CopyToDataTable());
                }
                DataLoading();
                MessageDialog.ShowInformationMsg("Save Conplete");
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
            finally
            {
                CloseWaitScreen();
            }
        }
        #endregion

        #region Event Handler Function

        private void repMovebox_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void repMovebox_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                DataRow dr = gdvSearchResult.GetFocusedDataRow();

                if (DataUtil.Convert<int>(dr["Box"]) < DataUtil.Convert<int>(e.NewValue))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, "Move Qty shouldn't over than assign Qty.");
                    e.Cancel = true;
                }
                else if (DataUtil.Convert<int>(e.NewValue) < 1)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, "Move Qty shouldn't less than 1.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void dlgKPK012_PackingManagementDialog_Load(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                base.HideStatusBar();

                shipmentControlFrom.OwnerID = Common.GetDefaultOwnerID();
                shipmentControlFrom.StatusIdList = BusinessClass.GetSpecificStatusIdForPackingManagement(string.Empty);
                shipmentControlFrom.DataLoading();

                shipmentControlTo.StatusIdList = BusinessClass.GetSpecificStatusIdForPackingManagement("Start");
                shipmentControlTo.OwnerID = Common.GetDefaultOwnerID();
                shipmentControlTo.DataLoading();

                packingControlFrom.ShipmentNo = "-1";
                packingControlFrom.StatusIdList = new List<int?>() { 65 };
                packingControlFrom.DataLoading();

                packingControlTo.StatusIdList = new List<int?>() { 65 };
                packingControlTo.ShipmentNo = "-1";
                packingControlTo.DataLoading();

                ControlUtil.EnableControl(false, dtPickingDateNew, dtPackingDateNew, shipmentControlFrom, dtShippingDateFrom);
                ControlUtil.HiddenControl(true, reqPickingDateNew, repPackingDateNew);
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
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    DataLoading();
                    if (gdvSearchResult.RowCount <= 0)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();

                errorProvider.ClearErrors();

                dtPackingDateFrom.EditValue = null;
                dtPackingDateTo.EditValue = null;

                dtShippingDateFrom.EditValue = null;
                dtShippingDateTo.EditValue = null;

                ownerControl.ClearData();

                shipmentControlFrom.OwnerID = Common.GetDefaultOwnerID();
                shipmentControlFrom.DataLoading();

                shipmentControlTo.OwnerID = Common.GetDefaultOwnerID();
                shipmentControlTo.ClearData();
                shipmentControlTo.DataLoading();

                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();

                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();

                packingControlFrom.ShipmentNo = "-1";
                packingControlFrom.DataLoading();

                packingControlTo.ShipmentNo = "-1";
                
                packingControlTo.DataLoading();

                grdSearchResult.DataSource = null;
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

        private void chkMovePack_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                btnClear_Click(sender, e);
                if (chkMovePack.Checked)
                {
                    rdoExisting.Checked = true;
                    ControlUtil.HiddenControl(false, reqPackingSearch, reqShipmentSearch);
                    ControlUtil.HiddenControl(true, reqPackingTo, reqPackingDateTo);
                    ControlUtil.EnableControl(false, packingControlTo, dtPackingDateTo, dtPickingDateNew, dtPackingDateNew, rdoExisting, rdoNew);
                    packingControlTo.ClearData();
                    ControlUtil.ClearControlData(dtPackingDateTo, dtPickingDateNew, dtPackingDateNew);

                    grdSearchResult.DataSource = null;
                    gdcSelect.OptionsColumn.AllowEdit = false;
                    gdcMovebox.OptionsColumn.AllowEdit = false;

                    shipmentControlTo.StatusIdList = null;
                    shipmentControlFrom.DataLoading();

                    shipmentControlFrom.StatusIdList = BusinessClass.GetSpecificStatusIdForPackingManagement("AllPack");
                    shipmentControlFrom.DataLoading();

                    packingControlFrom.StatusIdList = new List<int?>() { 65 };
                    packingControlFrom.DataLoading();
                }
                else
                {
                    shipmentControlTo.StatusIdList = BusinessClass.GetSpecificStatusIdForPackingManagement("Start");
                    shipmentControlFrom.DataLoading();

                    shipmentControlFrom.ClearData();
                    shipmentControlFrom.StatusIdList = BusinessClass.GetSpecificStatusIdForPackingManagement("Start");
                    shipmentControlFrom.DataLoading();

                    packingControlFrom.StatusIdList = new List<int?>() { 65 };
                    packingControlFrom.ShipmentNo = "-1";
                    packingControlFrom.DataLoading();

                    ControlUtil.HiddenControl(true, reqPackingSearch, reqShipmentSearch);
                    ControlUtil.HiddenControl(false, reqPackingTo, reqPackingDateTo);
                    ControlUtil.EnableControl(true, packingControlTo, dtPackingDateTo, rdoExisting, rdoNew);
                    gdcSelect.OptionsColumn.AllowEdit = true;

                    gdcMovebox.OptionsColumn.AllowEdit = true;
                    gdcMovebox.FieldName = "MoveBox";
                }
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

        private void ownerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                grdSearchResult.DataSource = null;
                if (ownerControl.OwnerID != null)
                {
                    customerControl.OwnerID = ownerControl.OwnerID;
                    customerControl.DataLoading();
                    warehouseControl.OwnerID = ownerControl.OwnerID;
                    warehouseControl.DataLoading();
                    
                    shipmentControlFrom.OwnerID = ownerControl.OwnerID;
                    shipmentControlFrom.DataLoading();
                    shipmentControlTo.OwnerID = ownerControl.OwnerID;
                    shipmentControlTo.DataLoading();
                }
                else
                {
                    customerControl.OwnerID = -1;
                    customerControl.DataLoading();
                    warehouseControl.OwnerID = -1;
                    warehouseControl.DataLoading();
                    shipmentControlFrom.OwnerID = Common.GetDefaultOwnerID();
                    shipmentControlFrom.DataLoading();
                    shipmentControlTo.OwnerID = Common.GetDefaultOwnerID();
                    shipmentControlTo.DataLoading();
                    packingControlFrom.ShipmentNo = "-1";
                    packingControlFrom.DataLoading();
                    packingControlTo.ShipmentNo = "-1";
                    packingControlTo.DataLoading();                   
                }
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

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                grdSearchResult.DataSource = null;
                shipmentControlFrom.CustomerID = customerControl.CustomerID;
                shipmentControlFrom.DataLoading();

                shipmentControlTo.CustomerID = customerControl.CustomerID;
                shipmentControlTo.DataLoading();

                
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

        private void dtShippingDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                shipmentControlFrom.ClearData();

                if (dtShippingDateFrom.EditValue != null)
                {
                    shipmentControlFrom.ShippingDateFrom = dtShippingDateFrom.DateTime;
                    shipmentControlFrom.ShippingDateTo = dtShippingDateFrom.DateTime;
                    shipmentControlFrom.DataLoading();

                    packingControlFrom.ShippingDateFrom = dtShippingDateFrom.DateTime;
                    packingControlFrom.ShippingDateTo = dtShippingDateFrom.DateTime;
                    packingControlFrom.DataLoading();
                }
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

        private void shipmentControlFrom_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (shipmentControlFrom.ShipmentNo != string.Empty)
                {
                    packingControlFrom.ShipmentNo = shipmentControlFrom.ShipmentNo;
                    packingControlFrom.DataLoading();
                }
                else
                {
                    packingControlFrom.ShipmentNo = "-1";
                    packingControlFrom.DataLoading();
                }
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

        private void dtPackingDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                packingControlFrom.ClearData();
                grdSearchResult.DataSource = null;
                if (dtPackingDateFrom.EditValue != null)
                {
                    if (!rdoExisting.Checked)
                    {   
                        shipmentControlFrom.PackDateFrom = dtPackingDateFrom.DateTime;
                        shipmentControlFrom.PackDateTo = dtPackingDateFrom.DateTime;
                        shipmentControlFrom.DataLoading();
                    }

                    packingControlFrom.PackingDateFrom = dtPackingDateFrom.DateTime;
                    packingControlFrom.PackingDateTo = dtPackingDateFrom.DateTime;
                    packingControlFrom.DataLoading();
                }
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
        
        private void dtShippingDateTo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                shipmentControlTo.ClearData();
                grdSearchResult.DataSource = null;
                if (dtShippingDateTo.EditValue != null)
                {
                    shipmentControlTo.ShippingDateFrom = dtShippingDateTo.DateTime;
                    shipmentControlTo.ShippingDateTo = dtShippingDateTo.DateTime;
                    shipmentControlTo.DataLoading();

                    packingControlTo.ShippingDateFrom = dtShippingDateTo.DateTime;
                    packingControlTo.ShippingDateTo = dtShippingDateTo.DateTime;
                    packingControlTo.DataLoading();

                    if (rdoExisting.Checked)
                    {
                        dtShippingDateFrom.EditValue = dtShippingDateTo.EditValue;
                    }
                }
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

        private void shipmentControlTo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                grdSearchResult.DataSource = null;
                if (shipmentControlTo.ShipmentNo != string.Empty)
                {
                    int ShipmentStatus = BusinessClass.PackingManagementGetShipmentStatus(shipmentControlTo.ShipmentNo, packingControlTo.PackingNo);
                    shipmentControlFrom.StatusIdList = BusinessClass.GetSpecificStatusIdForPackingManagement(ShipmentStatus.ToString());
                    packingControlFrom.StatusIdList = new List<int?>() { 65 };

                    packingControlTo.ShipmentNo = shipmentControlTo.ShipmentNo;
                    packingControlTo.DataLoading();
                    if (rdoExisting.Checked)
                    {
                        shipmentControlFrom.DataLoading();
                        shipmentControlFrom.ShipmentNo = shipmentControlTo.ShipmentNo;
                    }
                }
                else
                {
                    shipmentControlFrom.StatusIdList = BusinessClass.GetSpecificStatusIdForPackingManagement(string.Empty);
                    shipmentControlFrom.DataLoading();

                    packingControlFrom.StatusIdList = new List<int?>() { 65 };
                    packingControlFrom.DataLoading();

                    packingControlTo.ShipmentNo = "-1";
                    packingControlTo.DataLoading();
                }
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

        private void packingControlTo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                grdSearchResult.DataSource = null;
                if (packingControlTo.PackingNo != string.Empty)
                {
                    int ShipmentStatus = BusinessClass.PackingManagementGetShipmentStatus(shipmentControlTo.ShipmentNo, packingControlTo.PackingNo);
                    shipmentControlFrom.StatusIdList = BusinessClass.GetSpecificStatusIdForPackingManagement(ShipmentStatus.ToString());
                    packingControlFrom.StatusIdList = new List<int?>() { 65 };
                }
                else if (shipmentControlTo.ShipmentNo != string.Empty)
                {
                    int ShipmentStatus = BusinessClass.PackingManagementGetShipmentStatus(shipmentControlTo.ShipmentNo, packingControlTo.PackingNo);
                    shipmentControlFrom.StatusIdList = BusinessClass.GetSpecificStatusIdForPackingManagement(ShipmentStatus.ToString());
                    packingControlFrom.StatusIdList = new List<int?>() { 65 };
                }
                else
                {
                    shipmentControlFrom.StatusIdList = BusinessClass.GetSpecificStatusIdForPackingManagement(string.Empty);
                    shipmentControlFrom.DataLoading();

                    packingControlFrom.StatusIdList = new List<int?>() { 65 };
                    packingControlFrom.DataLoading();

                    packingControlTo.ShipmentNo = "-1";
                    packingControlTo.DataLoading();
                }
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

        private void dtPackingDateTo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                packingControlTo.ClearData();
                grdSearchResult.DataSource = null;
                if (dtPackingDateTo.EditValue != null)
                {
                    //shipmentControlTo.PackDateFrom = dtPackingDateTo.DateTime;
                    //shipmentControlTo.PackDateTo = dtPackingDateTo.DateTime;
                    //shipmentControlTo.DataLoading();

                    packingControlTo.PackingDateFrom = dtPackingDateTo.DateTime;
                    packingControlTo.PackingDateTo = dtPackingDateTo.DateTime;
                    packingControlTo.DataLoading();
                }
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

        private void rdoMethod_EditValueChanged(object sender, EventArgs e)
        {
            btnClear_Click(sender, e);
            if (rdoExisting.Checked)
            {
                ControlUtil.EnableControl(true, packingControlTo, dtPackingDateTo);
                ControlUtil.HiddenControl(false, reqPackingTo, reqPackingDateTo);
                ControlUtil.EnableControl(false, dtPickingDateNew, dtPackingDateNew, shipmentControlFrom, dtShippingDateFrom);
                ControlUtil.HiddenControl(true, reqPickingDateNew, repPackingDateNew);                
            }
            else
            {
                ControlUtil.EnableControl(false, packingControlTo, dtPackingDateTo);
                ControlUtil.HiddenControl(true, reqPackingTo, reqPackingDateTo);
                ControlUtil.EnableControl(true, dtPickingDateNew, dtPackingDateNew, shipmentControlFrom, dtShippingDateFrom);
                ControlUtil.HiddenControl(false, reqPickingDateNew, repPackingDateNew);
            }
        }
        #endregion
                
        #region Generic Function
        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                grdSearchResult.DataSource = null;
                DataTable dt = BusinessClass.PackingManagementSearchAll(ownerControl.OwnerID, customerControl.CustomerID, warehouseControl.WarehouseID ,dtShippingDateFrom.DateTime, dtPackingDateFrom.DateTime, shipmentControlFrom.ShipmentNo, packingControlFrom.PackingNo, chkMovePack.Checked ? 1 : 0, shipmentControlTo.ShipmentNo, packingControlTo.PackingNo);
                dt.Columns.Add("MoveBox");

                foreach (DataRow dtr in dt.Rows)
                {
                    dtr["MoveBox"] = dtr["Box"];
                }

                grdSearchResult.DataSource = dt;
                base.GridViewOnChangeLanguage(grdSearchResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseWaitScreen();
            }
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
            customerControl.RequireField = true;

            shipmentControlTo.ErrorText = Common.GetMessage("I0419");
            shipmentControlTo.RequireField = true;

            validate &= ownerControl.ValidateControl();
            validate &= warehouseControl.ValidateControl();
            validate &= customerControl.ValidateControl();
            validate &= shipmentControlTo.ValidateControl();

            if (string.IsNullOrEmpty(dtShippingDateFrom.Text))
            {
                errorProvider.SetError(dtShippingDateFrom, Common.GetMessage("I0384"));
                validate = false;
            }

            if (string.IsNullOrEmpty(dtPackingDateFrom.Text))
            {
                errorProvider.SetError(dtPackingDateFrom, Common.GetMessage("I0420"));
                validate = false;
            }

            if (string.IsNullOrEmpty(dtShippingDateTo.Text))
            {
                errorProvider.SetError(dtShippingDateTo, Common.GetMessage("I0384"));
                validate = false;
            }

            if (chkMovePack.Checked)
            {
                shipmentControlFrom.ErrorText = Common.GetMessage("I0419");
                shipmentControlFrom.RequireField = true;
                validate &= shipmentControlFrom.ValidateControl();

                packingControlFrom.RequireField = true;
                packingControlFrom.ErrorText = Common.GetMessage("I0405");
                validate &= packingControlFrom.ValidateControl();
            }
            else
            {
                shipmentControlFrom.RequireField = false;
                validate &= shipmentControlFrom.ValidateControl();

                packingControlFrom.RequireField = false;
                validate &= packingControlFrom.ValidateControl();

                if (rdoExisting.Checked)
                {
                    packingControlTo.RequireField = true;
                    packingControlTo.ErrorText = Common.GetMessage("I0405");
                    validate &= packingControlTo.ValidateControl();

                    if (string.IsNullOrEmpty(dtPackingDateTo.Text))
                    {
                        errorProvider.SetError(dtPackingDateTo, Common.GetMessage("I0420"));
                        validate = false;
                    }
                }
                else
                {
                    packingControlTo.RequireField = false;
                    packingControlTo.ValidateControl();

                    if (string.IsNullOrEmpty(dtPickingDateNew.Text) || string.IsNullOrEmpty(dtPackingDateNew.Text))
                    {
                        errorProvider.SetError(dtPickingDateNew, Common.GetMessage("I0266"));
                        errorProvider.SetError(dtPackingDateNew, Common.GetMessage("I0266"));
                        validate = false;
                    }
                }
            }

            return validate;
        }
        #endregion

        private void repMovebox_Leave(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = gdvSearchResult.GetFocusedDataRow();

                if (DataUtil.Convert<int>(dr["Box"]) < DataUtil.Convert<int>(dr["MoveBox"]))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, "Move Qty shouldn't over than assign Qty.");
                    dr["MoveBox"] = dr["Box"];
                }
                else if (DataUtil.Convert<int>(dr["MoveBox"]) < 1)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, "Move Qty shouldn't less than 1.");
                    dr["MoveBox"] = dr["Box"];
                }
                else if (DataUtil.Convert<int>(dr["MoveBox"]) == null)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, "Move Qty shouldn't blank");
                    dr["MoveBox"] = dr["Box"];
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }


        
    }
}
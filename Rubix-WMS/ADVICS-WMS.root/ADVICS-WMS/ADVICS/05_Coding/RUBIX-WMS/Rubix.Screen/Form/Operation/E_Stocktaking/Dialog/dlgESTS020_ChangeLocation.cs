/*
 6 Feb 2013:
 * 1. change query for show report
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSI.Business.Operation;
using Rubix.Framework;
using Rubix.Screen.Report;
using CSI.Business.DataObjects;
using CSI.Business.BusinessFactory.Report;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Transactions;

namespace Rubix.Screen.Form.Operation.E_Stocktaking.Dialog
{
    public partial class dlgESTS020_ChangeLocation : DialogBase
    {
        #region Member
        private ChangeLocation db;
        private Common.eScreenMode eScrenMode;
        private bool fullCapacityFlagTo;
        #endregion

        #region Properties
        public ChangeLocation BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ChangeLocation();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new ChangeLocation();
                }
                db = value;
            }
        }
        public Common.eScreenMode ScreenMode
        {
            get { return eScrenMode; }
            set { eScrenMode = value; }
        }
        #endregion

        #region Constructor
        public dlgESTS020_ChangeLocation()
        {
            InitializeComponent();
            SetFieldName();
            ControlUtil.HiddenControl(true, m_statusBar);
        }
        #endregion

        #region Event Handler Function
        private void dlgESTS020_ChangeLocation_Load(object sender, EventArgs e)
        {
            warehouseControlFrom.OwnerID = null;
            warehouseControlFrom.DataLoading();
            warehouseControlFrom.EnableControl = false;
            warehouseControlTo.OwnerID = null;
            warehouseControlTo.DataLoading();
            warehouseControlTo.EnableControl = false;
            zoneControlFrom.OwnerID = null;
            zoneControlFrom.WarehouseID = null;
            zoneControlFrom.Floor = null;
            zoneControlFrom.DataLoading();
            zoneControlFrom.EnableControl = false;
            zoneControlTo.OwnerID = null;
            zoneControlTo.WarehouseID = null;
            zoneControlTo.Floor = null;
            zoneControlTo.DataLoading();
            itemControl.OwnerID = null;
            itemControl.DataLoading();
            itemControl.EnableControl = false;
            productConditionControlFrom.EnableControl = false;
            txtQtyTo.Enabled = true;
           

            DataBinding();
            ControlUtil.EnableControl(false, chkFullCapacityFrom);
        }

        private void warehouseControlTo_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(warehouseControlTo.WarehouseCode))
            {

                zoneControlTo.OwnerID = null;
                zoneControlTo.WarehouseID = null;
                zoneControlTo.Floor = null;
                zoneControlTo.DataLoading();
            }
        }
        
        private void zoneControlTo_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(zoneControlTo.ZoneCode))
            {
                DataTable RackTable = BusinessClass.LoadRack(zoneControlTo.ZoneID);
                cboRackNo.Properties.DataSource = RackTable;
                //if (RackTable.Rows.Count != 0)
                //    cboRackNo.EditValue = RackTable.Rows[0].ItemArray[0].ToString();
                ControlUtil.ClearControlData(txtLocationTo);
                try
                {
                    if (!string.IsNullOrWhiteSpace(zoneControlTo.ZoneCode) && !string.IsNullOrWhiteSpace(warehouseControlTo.WarehouseCode) && !string.IsNullOrWhiteSpace(cboRackNo.Text))
                    {
                        String strLocationCode = BusinessClass.LoadLocationCode(warehouseControlTo.WarehouseID, zoneControlTo.ZoneID, cboRackNo.Text);
                        txtLocationTo.Text = strLocationCode;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void cboRackNo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(zoneControlTo.ZoneCode) && !string.IsNullOrWhiteSpace(warehouseControlTo.WarehouseCode) && !string.IsNullOrWhiteSpace(cboRackNo.Text))
                {
                    String strLocationCode = BusinessClass.LoadLocationCode(warehouseControlTo.WarehouseID, zoneControlTo.ZoneID, cboRackNo.Text);
                    txtLocationTo.Text = strLocationCode;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void productConditionControlTo_EditValueChanged(object sender, EventArgs e)
        {
            if (productConditionControlFrom.ProductConditionID != productConditionControlTo.ProductConditionID)
            {
                EnableControl(true);
            }
            else
            {
                EnableControl(false);
            }
        }

        private void txtQtyTo_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal val = Convert.ToDecimal(e.NewValue);
            e.Cancel = val > ((SpinEdit)sender).Properties.MaxValue ||
                val < ((SpinEdit)sender).Properties.MinValue;
        }

        private void txtLocationTo_TextChanged(object sender, EventArgs e)
        {
            //bool fullCapacityChk = BusinessClass.LoadFullCapacityFlag(BusinessClass.OwnerID, warehouseControlTo.WarehouseID, txtLocationTo.Text);
            //chkFullCapacityTo.Checked = fullCapacityChk;
            //fullCapacityFlagTo = fullCapacityChk;
        }

        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this, Rubix.Screen.Common.GetMessage("I0015")) == DialogButton.Yes)
                {
                    if (string.IsNullOrEmpty(cboRackNo.Text) && deExpiryDateTo.EditValue != null)
                    {
                        SaveExpiryDate();
                        DialogResult = DialogResult.OK;
                        return true;
                    }
                    else
                    {
                        if (ValidateData())
                        {
                            if (!iv.ValidateTicket(BusinessClass.OwnerID.ToString(), BusinessClass.WarehouseID.ToString()
                                                  ,BusinessClass.LocationID.ToString(), BusinessClass.ProductID.ToString()
                                                  ,BusinessClass.ProductConditionID.ToString(), BusinessClass.PalletNo))
                            {
                                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0275"));
                                return false;
                            }
                            SavaData();
                            SaveExpiryDate();
                            DialogResult = DialogResult.OK;
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        public override bool OnCommandClear()
        {
            DataBinding();

            return base.OnCommandClear();
        }
        #endregion

        #region Generic Function
        private void DisAbleControl()
        {
            ControlUtil.EnableControl(false, txtLocationTo, cboRackNo);
            warehouseControlTo.EnableControl = false;
            zoneControlTo.EnableControl = false;
            productConditionControlTo.EnableControl = false;
        }
        private void DataBinding()
        {
            itemControl.OwnerID = BusinessClass.OwnerID;
            itemControl.DataLoading();
            itemControl.ProductID = BusinessClass.ProductID;
            txtLotNo.Text = BusinessClass.LotNo;

            //-----From-------------------------------------------------------
            warehouseControlFrom.WarehouseCode = BusinessClass.WarehouseCode;
            zoneControlFrom.OwnerID = BusinessClass.OwnerID;
            zoneControlFrom.WarehouseID = warehouseControlFrom.WarehouseID;
            zoneControlFrom.ZoneCode = BusinessClass.ZoneCode;
            deExpiryDateFrom.EditValue = BusinessClass.ExpiryDate;

            if (string.IsNullOrWhiteSpace(BusinessClass.RackNoAndLevel))
            {
                txtRackFrom.Text = BusinessClass.RackNo;
            }
            else
            {
                txtRackFrom.Text = BusinessClass.RackNoAndLevel;
            }

            txtLocationFrom.Text = BusinessClass.LocationCode;
            productConditionControlFrom.ProductConditionCode = BusinessClass.ProductConditionCode;
            txtQtyFrom.Text = BusinessClass.InventoryBox.ToString(Common.QtyFormat);
            lblUnitFrom.Text = BusinessClass.Level2UnitName;

            bool fullFromChk = BusinessClass.LoadFullCapacityFlag(zoneControlFrom.WarehouseID, BusinessClass.LocationCode);
            ControlUtil.EnableControl(fullFromChk, chkFullCapacityFrom);
            chkFullCapacityFrom.Checked = fullFromChk;
            
            //----To---------------------------------------------------------------
            warehouseControlTo.WarehouseCode = BusinessClass.WarehouseCode;

            zoneControlTo.OwnerID = null;
            zoneControlTo.WarehouseID = null;
            zoneControlTo.Floor = null;
            zoneControlTo.DataLoading();
            zoneControlTo.OwnerID = BusinessClass.OwnerID;
            zoneControlTo.WarehouseID = warehouseControlTo.WarehouseID;
            zoneControlTo.DataLoading();
            zoneControlTo.ZoneCode = BusinessClass.ZoneCode;

            cboRackNo.Properties.DataSource = BusinessClass.LoadRack(zoneControlTo.ZoneID);
            cboRackNo.EditValue = BusinessClass.RackNo;
            //txtLocationTo.Text = BusinessClass.LocationCode;
            productConditionControlTo.ProductConditionCode = BusinessClass.ProductConditionCode;
            txtQtyTo.Text = BusinessClass.InventoryBox.ToString();
            lblUnitTo.Text = BusinessClass.Level2UnitName;

            if (BusinessClass.Inventory == 0)
            {
                DisAbleControl();
            }

        }
        private void EnableControl(bool Condition)
        {
            //ControlUtil.EnableControl(Condition, txtQtyTo);
            //chkFullCapacityTo.Checked = !Condition;
            //ControlUtil.EnableControl(!Condition, chkFullCapacityTo);
        }
        private void SetFieldName()
        {


            gdcRackNo.FieldName = "RackNo";
            cboRackNo.Properties.DisplayMember = "RackNo";
            cboRackNo.Properties.ValueMember = "RackNo";
        }
        private void SavaData()
        {
            int? iLocationIDFrom = BusinessClass.LocationID;
            int? iLocationIDTo = BusinessClass.LoadLocationID(warehouseControlTo.WarehouseID.Value, txtLocationTo.Text);

            try
            {
                BusinessClass.SaveLocationChange(BusinessClass.OwnerID, warehouseControlFrom.WarehouseID, BusinessClass.ProductID, BusinessClass.LotNo,
                                                 BusinessClass.PalletNo, BusinessClass.ProductConditionID, iLocationIDFrom, chkFullCapacityFrom.Checked, productConditionControlTo.ProductConditionID,
                                                 iLocationIDTo, chkFullCapacityTo.Checked, Convert.ToDecimal(txtQtyTo.Text)*BusinessClass.RatioConvertInventory);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void SaveExpiryDate()
        {
            try
            {
                if (deExpiryDateTo.EditValue != null)
                {
                    BusinessClass.SaveExpiryDate(BusinessClass.PalletNo, deExpiryDateTo.DateTime);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        private bool ValidateData()
        {
            errorProvider.ClearErrors();
            Boolean errFlag = true;

            warehouseControlTo.RequireField = true;
            warehouseControlTo.ErrorText = Rubix.Screen.Common.GetMessage("I0045");
            if (!warehouseControlTo.ValidateControl())
            {
                errFlag = false;
            }

            zoneControlTo.RequireField = true;
            zoneControlTo.ErrorText = Rubix.Screen.Common.GetMessage("I0055");
            if (!zoneControlTo.ValidateControl())
            {
                errFlag = false;
            }

            if (string.IsNullOrEmpty(cboRackNo.Text))
            {
                errorProvider.SetError(cboRackNo, Rubix.Screen.Common.GetMessage("I0053"));
                errFlag = false;
            }

            if (Convert.ToDecimal(txtQtyTo.Text) == 0)
            {
                errorProvider.SetError(txtQtyTo, Rubix.Screen.Common.GetMessage("I0129"));
                errFlag = false;
            }
            else
            {
                if (Convert.ToDecimal(txtQtyTo.Text) > Convert.ToDecimal(txtQtyFrom.Text))
                {
                    errorProvider.SetError(txtQtyTo, Rubix.Screen.Common.GetMessage("I0246"));
                    errFlag = false;
                }
            }

            if (zoneControlFrom.ZoneID == zoneControlTo.ZoneID)
            {
                if (cboRackNo.Text.ToString() == txtRackFrom.Text.ToString())
                {
                    if (productConditionControlTo.ProductConditionID == productConditionControlFrom.ProductConditionID)
                    {
                        errorProvider.SetError(txtLocationTo, Rubix.Screen.Common.GetMessage("I0218"));
                        errFlag = false;
                    }
                }
            }
            return errFlag;
        }
        #endregion      
        
    }
}
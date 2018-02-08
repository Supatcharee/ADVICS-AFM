/*
 * 20121217:
 * 1. set format for Adjustment control
 * 20121226
 * 1. Modify to use EditValue on SetAfterAdjust function
 * 2. Change qty control to SpinEdit and implement EditValueChanging event for it.
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

namespace Rubix.Screen.Form.Operation.E_Stocktaking.Dialog
{
    public partial class dlgESTS010_CorrectInventory : DialogBase
    {
        #region Member
        private CorrectInventory db;
        private ChangeLocation dbChangeLocation;
        private Common.eScreenMode eScrenMode;
        private object txtSlipNo = null;
        private int itemUnitBase = -1;
        private int CurrentUnitID = -1;        
        #endregion

        #region Properties
        public CorrectInventory BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new CorrectInventory();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new CorrectInventory();
                }
                db = value;
            }
        }
        public ChangeLocation ChangeLocationBusinessClass
        {
            get
            {
                if (dbChangeLocation == null)
                {
                    dbChangeLocation = new ChangeLocation();
                }
                return dbChangeLocation;
            }
            set
            {
                if (dbChangeLocation == null)
                {
                    dbChangeLocation = new ChangeLocation();
                }
                dbChangeLocation = value;
            }
        }
        public Common.eScreenMode ScreenMode
        {
            get { return eScrenMode; }
            set { eScrenMode = value; }
        }
        #endregion

        #region Constructor
        public dlgESTS010_CorrectInventory()
        {
            InitializeComponent();

        }
        #endregion

        #region Event Handler Function
        private void dlgESTS010_CorrectInventory_Load(object sender, EventArgs e)
        {
            try
            {
                base.HideStatusBar();
                ownerControl.WarehouseID = null;
                ownerControl.DataLoading();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                itemControl.OwnerID = null;
                itemControl.DataLoading();
                itemConditionControl.DataLoading();
                UnitAdjustLoading();

                if (ScreenMode != Common.eScreenMode.Add)
                {
                    DataBinding();
                }
                else
                {
                    ClearAll();
                    txtInventory.EditValue = 0.0;
                    txtAdjust.EditValue = 0.0;
                }

                InitControl(ScreenMode);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }

        }
        
        private void txtAdjust_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAdjust.Text))
            {
                //setAfterAdjust();
                decimal adjust = Convert.ToDecimal(txtAdjust.EditValue);
                if (adjust < 0)
                {
                    txtAdjust.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    txtAdjust.ForeColor = System.Drawing.Color.Green;
                }
                setAfterAdjust();
            }
        }

        private void ownerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ScreenMode == Common.eScreenMode.Add)
                {
                    if (ownerControl.OwnerID != null)
                    {
                        warehouseControl.OwnerID = ownerControl.OwnerID;
                        warehouseControl.DataLoading();
                        ZoneDataLoading();
                        ownerControl.EnableControl = false;
                    }
                    else
                    {
                        warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                        warehouseControl.DataLoading();
                        itemControl.OwnerID = Common.GetDefaultOwnerID();
                        itemControl.DataLoading();
                        ZoneDataLoading();
                        ControlUtil.ClearControlData(itemConditionControl);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void warehouseControl_EditValueChanged(object sender, EventArgs e)
        {
            if (ScreenMode == Common.eScreenMode.Add)
            {
                if (!string.IsNullOrWhiteSpace(warehouseControl.WarehouseCode))
                {
                    // zoneControl.OwnerID = null;
                    //zoneControl.WarehouseID = null;
                    //zoneControl.Floor = null;

                    itemControl.OwnerID = ownerControl.OwnerID;
                    itemControl.DataLoading();
                    ZoneDataLoading();
                    ControlUtil.ClearControlData(itemConditionControl);

                }
            }
        }

        private void itemControl_EditValueChanged(object sender, EventArgs e)
        {
            if (ScreenMode == Common.eScreenMode.Add)
            {
                if (!string.IsNullOrWhiteSpace(itemControl.ProductCode))
                {
                    ZoneDataLoading();
                    LoadAllUnitAdjust();
                    warehouseControl.EnableControl = false;
                    ControlUtil.ClearControlData(itemConditionControl);
                }
            }
        }

        private void zoneControl_EditValueChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(warehouseControl.WarehouseCode))
            {
                ControlUtil.ClearControlData(cboLocationCode);

                LocationCodeLoading();
                LoadLotNo();
                ControlUtil.EnableControl(false, itemControl);
            }
        }

        private void itemConditionControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ScreenMode == Common.eScreenMode.Add)
                {
                    if (!string.IsNullOrWhiteSpace(zoneControl.ZoneCode) &&
                        !string.IsNullOrWhiteSpace(warehouseControl.WarehouseCode) &&
                        !string.IsNullOrWhiteSpace(itemControl.ProductCode) &&
                        !string.IsNullOrWhiteSpace(itemConditionControl.ProductConditionCode))
                    {
                        //  txtLotNo.Properties.DataSource = BusinessClass.LoadLotNo((int)customerControl.OwnerID, (int)warehouseControl.WarehouseID, BusinessClass.LocationID, (int)productControl.ProductID, (int)productConditionControl.ProductConditionID);

                    }
                    LoadLotNo();
                    BusinessClass.PalletNo = string.Empty;
                    //txtLotNo.Text = string.Empty;
                    txtInventory.EditValue = 0.0;
                    chkFullCapacity.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        
        private void txtAdjust_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal val = Convert.ToDecimal(e.NewValue);
            e.Cancel = val > ((SpinEdit)sender).Properties.MaxValue ||
                val < ((SpinEdit)sender).Properties.MinValue;
        }
        
        private void cboAdjustUnit_EditValueChanged(object sender, EventArgs e)
        {
            setAfterAdjust();
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this, Common.GetMessage("I0015")) == DialogButton.Yes)
                {
                    setAfterAdjust();

                    if (ValidateData())
                    {
                        SavaData();
                        
                        DialogResult = DialogResult.OK;
                        return true;
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
            if (ScreenMode == Common.eScreenMode.Add)
            {
                ControlUtil.ClearControlData(ownerControl, warehouseControl, itemControl, zoneControl, itemConditionControl, cboLotNo);
                ControlUtil.ClearControlData(txtAdjust, txtAfterAdjust, cboLocationCode, chkFullCapacity);
                BusinessClass.PalletNo = string.Empty;
                BusinessClass.LocationID = 0;
                ownerControl.EnableControl = true;
                warehouseControl.EnableControl = true;
                itemControl.EnableControl = true;
            }
            else
            {
                ControlUtil.ClearControlData(txtAdjust, txtAfterAdjust, chkFullCapacity);
            }
            return base.OnCommandClear();
        }
        #endregion

        #region Generic Function
        private void DataBinding()
        {
            ownerControl.OwnerID = BusinessClass.OwnerID;
            warehouseControl.OwnerID = BusinessClass.OwnerID;
            warehouseControl.DataLoading();
            warehouseControl.WarehouseID = BusinessClass.WarehouseID;
            itemControl.ProductID = BusinessClass.ProductID;
            itemConditionControl.ProductConditionCode = BusinessClass.ProductConditionCode;
            ZoneDataLoading();
            zoneControl.ZoneCode = BusinessClass.ZoneCode;

            cboLocationCode.Text = BusinessClass.LocationCode;
            cboLocationCode.EditValue = BusinessClass.LocationID;
            txtInventory.EditValue = BusinessClass.InventoryQty;
            cboLotNo.Text = BusinessClass.LotNo;
           //cboLotNo.EditValue = BusinessClass.LotNo;
            LoadAllUnitAdjust();

            deExpiryDate.EditValue = BusinessClass.LoadExpiryDate(BusinessClass.PalletNo);
        }

        private void ClearAll()
        {
            ControlUtil.ClearControlData(ownerControl, warehouseControl, itemControl, zoneControl, itemConditionControl, cboLotNo);
            ControlUtil.ClearControlData(txtAdjust, txtAfterAdjust, cboLocationCode, chkFullCapacity);
            BusinessClass.PalletNo = string.Empty;
            BusinessClass.LocationID = 0;
        }

        private void setAfterAdjust()
        {
            try
            {
                
                if (txtAdjust.Text.Equals("-") || txtInventory.EditValue.ToString().Trim() == string.Empty || itemControl.ProductID == null || itemUnitBase == -1)
                {
                    return;
                }
                
                decimal? ratioScreen = BusinessClass.GetConvertRatio(CurrentUnitID, Convert.ToInt32(cboAdjustUnit.EditValue), itemControl.ProductID);
                
                decimal? InventoryQty = Convert.ToDecimal(txtInventory.EditValue);
                decimal? adjust = Convert.ToDecimal(txtAdjust.EditValue);

                txtAfterAdjust.EditValue = ((InventoryQty * ratioScreen) + adjust);
                txtInventory.EditValue = (InventoryQty * ratioScreen);

                lblInventoryUnit.Text = cboAdjustUnit.Text;
                lblAfterAdjustUnit.Text = cboAdjustUnit.Text;

                CurrentUnitID = Convert.ToInt32(cboAdjustUnit.EditValue);

            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private bool ValidateData()
        {
            Boolean errFlag = true;
            ownerControl.RequireField = true;
            ownerControl.ErrorText = Common.GetMessage("I0026");
            if (!ownerControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(ownerControl, String.Empty);
            }

            warehouseControl.RequireField = true;
            warehouseControl.ErrorText = Common.GetMessage("I0045");
            if (!warehouseControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(warehouseControl, String.Empty);
            }

            itemControl.RequireField = true;
            itemControl.ErrorText = Common.GetMessage("I0093");
            if (!itemControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(itemControl, String.Empty);
            }

            //zoneControl.RequireField = true;
            //zoneControl.ErrorText = Common.GetMessage("I0055");
            if (!zoneControl.ValidateControl())
            {
                errorProvider.SetError(zoneControl, Common.GetMessage("I0055"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(zoneControl, String.Empty);
            }


            itemConditionControl.RequireField = true;
            itemConditionControl.ErrorText = Common.GetMessage("I0039");
            if (!itemConditionControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(itemConditionControl, String.Empty);
            }

            //if (Util.IsNullOrEmpty(cboLotNo.EditValue))
            //{
            //    errorProvider.SetError(cboLotNo, Common.GetMessage("I0172"));
            //    errFlag = false;
            //}
            //else
            //{
            //    errorProvider.SetError(cboLotNo, String.Empty);
            //}

            if (!DataUtil.IsValidDecimal(txtAdjust.Text, 18, 3) || Convert.ToDecimal(txtAdjust.EditValue) == 0)
            {
                errorProvider.SetError(txtAdjust, Common.GetMessage("I0277"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtAdjust, String.Empty);
            }

            if (string.IsNullOrWhiteSpace(txtRemark.Text))
            {
                errorProvider.SetError(txtRemark, "Remark shouldn't be empty.");
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtRemark, String.Empty);
            }
            return errFlag;
        }

        private void SavaData()
        {
            decimal? ratioInventory = BusinessClass.GetConvertRatio(DataUtil.Convert<int>(cboAdjustUnit.EditValue), itemUnitBase, itemControl.ProductID);
            decimal? adjust = Convert.ToDecimal(txtAdjust.EditValue) * ratioInventory;
            adjust = Math.Round(Convert.ToDecimal(adjust), 3);

            DateTime? ExpriedDate = null;
            if (deExpiryDate.EditValue != null)
            {
                ExpriedDate = (DateTime)deExpiryDate.EditValue;
            }

            BusinessClass.SaveData(ownerControl.OwnerID, warehouseControl.WarehouseID, BusinessClass.ReceivingNo
                                    , itemControl.ProductID, itemConditionControl.ProductConditionID
                                    , Convert.ToInt32(cboLocationCode.EditValue), BusinessClass.PalletNo
                                    , "L-"+itemControl.ProductCode, adjust, chkFullCapacity.Checked, ExpriedDate, txtRemark.Text);
        }

        private void InitControl(Common.eScreenMode mode)
        {
            switch (mode)
            {
                case Common.eScreenMode.Add:
                    EnableControl(true);
                    break;
                case Common.eScreenMode.Edit:
                    EnableControl(false);
                    break;
            }
        }

        private void EnableControl(bool Condition)
        {
            ownerControl.EnableControl = Condition;
            warehouseControl.EnableControl = Condition;
            itemControl.EnableControl = Condition;
            itemConditionControl.EnableControl = Condition;
            ControlUtil.EnableControl(Condition, cboLotNo, zoneControl,cboLocationCode);

        }
        
        private void ZoneDataLoading()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(warehouseControl.WarehouseCode))
                {
                    zoneControl.WarehouseID = warehouseControl.WarehouseID;
                    zoneControl.DataLoading();

                }
                else
                {
                    zoneControl.WarehouseID = Common.GetDefaultWarehouseID();
                    zoneControl.DataLoading();
                }
            }
            catch (Exception e)
            {
                MessageDialog.ShowBusinessErrorMsg(this, e.Message, e.ToString());
            }
        }

        private void LocationCodeLoading()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(zoneControl.ZoneCode))
                {
                    cboLocationCode.Properties.ValueMember = "LocationID";
                    cboLocationCode.Properties.DisplayMember = "LocationCode";
                    gdcLocationCode.FieldName = "LocationCode";
                    gdcMaxCapacity.FieldName = "MaxCapacity";
                    gdcAvailableCapacity.FieldName = "AvailableCapacity";
                    cboLocationCode.Properties.DataSource = BusinessClass.LoadLocationCode((int)zoneControl.ZoneID);
                }
                else
                {
                    cboLocationCode.Properties.DataSource = null;
                }
            }
            catch (Exception e)
            {
                MessageDialog.ShowBusinessErrorMsg(this, e.Message, e.ToString());
            }
        }

        private void UnitAdjustLoading()
        {
            try
            {
                DataTable dt = BusinessClass.LoadDefaultUnit();

                if (dt != null)
                {
                    lblInventoryUnit.Text = dt.Rows[0]["UnitCode"].ToString();
                    lblAfterAdjustUnit.Text = dt.Rows[0]["UnitCode"].ToString();
                    //lblActualAdjust.Text = dt.Rows[0]["UnitCode"].ToString();
                    itemUnitBase = Int32.Parse(dt.Rows[0]["UnitID"].ToString());
                    CurrentUnitID = itemUnitBase;
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadAllUnitAdjust()
        {
            try
            {
                DataTable dt = BusinessClass.LoadAllUnitAdjust(itemControl.ProductID);
                if (dt != null)
                {
                    cboAdjustUnit.Properties.DataSource = dt;
                    cboAdjustUnit.Properties.DisplayMember = "UnitCode";
                    cboAdjustUnit.Properties.ValueMember = "UnitID";

                    cboAdjustUnit.EditValue = cboAdjustUnit.Properties.GetDataSourceValue(cboAdjustUnit.Properties.ValueMember, 2);
                    
                }
                else
                {
                    cboAdjustUnit.Properties.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadLotNo()
        {
            cboLotNo.Properties.Items.Clear();

            try
            {
                if (!string.IsNullOrEmpty(ownerControl.OwnerID.ToString()) 
                    && !string.IsNullOrEmpty(warehouseControl.WarehouseID.ToString()) 
                    && cboLocationCode.EditValue != null
                    && !string.IsNullOrEmpty(itemControl.ProductID.ToString()) 
                    && !string.IsNullOrEmpty(itemConditionControl.ProductConditionID.ToString()))
                {
                    if (ownerControl.OwnerID != -1 
                        && warehouseControl.WarehouseID != -1 
                        && Int32.Parse(cboLocationCode.EditValue.ToString()) > 0
                        && itemControl.ProductID != -1 
                        && itemConditionControl.ProductConditionID != -1)
                    {
                        DataTable dt = BusinessClass.LoadLotNo((int)ownerControl.OwnerID, (int)warehouseControl.WarehouseID, Int32.Parse(cboLocationCode.EditValue.ToString()), (int)itemControl.ProductID, (int)itemConditionControl.ProductConditionID);

                        foreach (DataRow dr in dt.Rows)
                        {
                            cboLotNo.Properties.Items.Add(dr["LotNo"]);
                        }
                    }
                }
                
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
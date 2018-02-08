/*
 7 Feb 2013:
 * 1. modify validate unit
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
using CSI.Business.Master;
using Rubix.Framework;
using System.IO;
using CSI.Business.DataObjects;
using System.Collections;
using DevExpress.XtraTab;
using System.Linq;
using System.Transactions;
using CSI.Business;
using DevExpress.XtraEditors.Mask;
using System.Runtime.Serialization.Formatters.Binary;
using DevExpress.XtraGrid.Views.Base;
using CSI.Business.BusinessFactory.Master;

namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS050_Item : DialogBase, IClearable
    { 
        #region Member
        private Product _db = null;  
        private CSI.Business.Common.Packaging _pck = null;
        private CSI.Business.Common.Warehouse _WarehouseCommon = null;
        private CSI.Business.Common.Zone _ZoneCommon = null;
        private CSI.Business.Common.Location _LocationCommon = null;
        private CSI.Business.Common.ProductCondition _ProductConditionCommon = null;
        private TypeOfUnit _tu = null;
        private Pallet _pallet = null;
        private Common.eScreenMode eScrenMode;
        private Dialog.dlgXMSS051_Item_SalePerchasePrice m_Dialog = null;
        private Dialog.dlgXMSS052_Item_SearchPallet pallet_Dialog = null;
        private ProductInfomation proInfo = null;

        private FileStream fs;
        DataTable dtTransitZone = new DataTable();
        DataTable dtCargoType = new DataTable();
        
        #endregion

        #region Enum
        public enum eTypeOfpallet
        {
            AfterProduction = 1,
            AfterRcv = 2,
            FollowCOA = 3
        }

        private enum eTransitZone
        {
            ProductID,
            ProductConditionID,
            ZoneID,
            LocationID,
            ProductConditionDisplayName,
            ZoneDisplayName,
            LocationDisplayName,
            WarehouseDisplayName
        }

        private enum eCargoType
        {
             ProductID
            ,CargoType
			,PackageID
            ,PalletID
			,L1Vol
			,L1Unit
			,rptTypeOfUnitLevel1
			,L2Number
			,L2Unit
			,rptTypeOfUnitLevel2
			,L3Number
			,L3Unit
			,rptTypeOfUnitLevel3
			,L4Number
			,L4Unit
			,rptTypeOfUnitLevel4
            ,InventoryRecord
			,NetWeight
            ,GrossWeight
            ,PalletWeightLimit
        }
        #endregion

        #region Properties
        public Product BusinessClass
        {
            get
            {
                if (_db == null)
                    _db = new Product();
                return _db;
            }
            set
            {
                _db = value;
            }
        }
        public Common.eScreenMode ScreenMode
        {
            get { return eScrenMode; }
            set { eScrenMode = value; }
        }
        private CSI.Business.Common.Packaging Packaging
        {
            get
            {
                if (_pck == null)
                {
                    _pck = new CSI.Business.Common.Packaging();
                }
                return _pck;
            }
        }
        private CSI.Business.Common.Warehouse WarehouseCommonBusiness
        {
            get
            {
                if (_WarehouseCommon == null)
                    _WarehouseCommon = new CSI.Business.Common.Warehouse();
                return _WarehouseCommon;
            }
            set
            {
                _WarehouseCommon = value;
            }
        }
        private CSI.Business.Common.Zone ZoneCommonBusiness
        {
            get
            {
                if (_ZoneCommon == null)
                    _ZoneCommon = new CSI.Business.Common.Zone();
                return _ZoneCommon;
            }
            set
            {
                _ZoneCommon = value;
            }
        }
        private CSI.Business.Common.Location LocationCommonBusiness
        {
            get
            {
                if (_LocationCommon == null)
                    _LocationCommon = new CSI.Business.Common.Location();
                return _LocationCommon;
            }
            set
            {
                _LocationCommon = value;
            }
        }
        private CSI.Business.Common.ProductCondition ProductConditionCommonBusiness
        {
            get
            {
                if (_ProductConditionCommon == null)
                    _ProductConditionCommon = new CSI.Business.Common.ProductCondition();
                return _ProductConditionCommon;
            }
            set
            {
                _ProductConditionCommon = value;
            }
        }
        private TypeOfUnit UnitType
        {
            get
            {
                if (_tu == null)
                {
                    _tu = new TypeOfUnit();
                }
                return _tu;
            }
        }
        private Pallet Pallet
        {
            get
            {
                if (_pallet == null)
                {
                    _pallet = new Pallet();
                }
                return _pallet;
            }
        }
        private bool isValidData = true;
        public int? ProductID { get; set; }
        public ProductInfomation ProductInfo
        {
            get
            {
                if (proInfo == null)
                {
                    return proInfo = new ProductInfomation();
                }
                return proInfo;
            }
            set
            {
                proInfo = value;
            }
        }

        private Dialog.dlgXMSS051_Item_SalePerchasePrice Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgXMSS051_Item_SalePerchasePrice();
                }
                return m_Dialog;
            }
            set
            {
                m_Dialog = value;
            }
        }

        private Dialog.dlgXMSS052_Item_SearchPallet PalletDialog
        {

            get
            {
                if (pallet_Dialog == null)
                {
                    return pallet_Dialog = new Dialog.dlgXMSS052_Item_SearchPallet();
                }
                return pallet_Dialog;
            }
            set
            {
                pallet_Dialog = value;
            }
        }
        #endregion

        #region Constructor
        public dlgXMSS050_Item()
        {
            InitializeComponent();
            //SetFieldName();
            base.GridViewControl = new GridControl[] { grdTransitZone, grdCargoType};
            
            txtSafetyStock.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtSafetyStock.Properties.DisplayFormat.FormatString = Common.QtyFormat;
            txtSafetyStock.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtSafetyStock.Properties.EditFormat.FormatString = Common.QtyFormat;
            txtSafetyStock.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtSafetyStock.Properties.Mask.EditMask = Common.QtyFormat;
            txtSafetyStock.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            
            txtShelfLife.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtShelfLife.Properties.DisplayFormat.FormatString = Common.DecimalFormat;
            txtShelfLife.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtShelfLife.Properties.EditFormat.FormatString = Common.DecimalFormat;
            txtShelfLife.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtShelfLife.Properties.Mask.EditMask = Common.DecimalFormat;
            txtShelfLife.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            
            txtEstimateValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtEstimateValue.Properties.DisplayFormat.FormatString = Common.AmountFormat;
            txtEstimateValue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            txtEstimateValue.Properties.EditFormat.FormatString = Common.AmountFormat;
            txtEstimateValue.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtEstimateValue.Properties.Mask.EditMask = Common.AmountFormat;
            txtEstimateValue.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;

            
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                gdvTransitZone.CloseEditor();
                gdvTransitZone.UpdateCurrentRow();
                gdvCargoType.CloseEditor();
                gdvCargoType.UpdateCurrentRow();
                gdvMaterialPacking.CloseEditor();
                gdvMaterialPacking.UpdateCurrentRow();

                if (isValidData)
                {

                    if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), txtPartCode.Text.Trim())) == DialogButton.Yes)
                    {
                        if (ValidateData())
                        {

                            if (BusinessClass.CheckExistProduct((int)ownerControl.OwnerID, ProductInfo.ProductID, txtPartCode.Text))
                            {
                                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0151"));
                                return false;
                            }

                            if (ScreenMode == Common.eScreenMode.Add && ProductInfo.SalePrice == null && ProductInfo.PurchasePrice == null)
                            {
                                if (MessageDialog.ShowConfirmationMsg(this, Common.GetMessage("I0409")) == DialogButton.No)
                                {
                                    return false;
                                }
                            }
                            ShowWaitScreen();
                            SaveData();
                            CloseWaitScreen();
                            DialogResult = DialogResult.OK;
                            if (Dialog != null)
                                Dialog = null;
                            return true;

                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            return false;
        }
        public override bool OnCommandSaveACopy()
        {
            try
            {
                gdvTransitZone.CloseEditor();
                gdvTransitZone.UpdateCurrentRow();
                gdvCargoType.CloseEditor();
                gdvCargoType.UpdateCurrentRow();
                gdvMaterialPacking.CloseEditor();
                gdvMaterialPacking.UpdateCurrentRow();
                ProductInfo.ProductID = null;
                ProductInfo.SalePrice = null;
                ProductInfo.PurchasePrice = null;

                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), txtPartCode.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        
                        if (BusinessClass.CheckExistProduct((int)ownerControl.OwnerID, ProductInfo.ProductID, txtPartCode.Text))
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0151"));
                            return false;
                        }

                        SaveData();
                        DialogResult = DialogResult.OK;

                        if (Dialog != null)
                            Dialog = null;

                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            return false;
        }
        public override bool OnCommandClear()
        {

            try
            {
                errorProvider.ClearErrors();
                if (ScreenMode == Common.eScreenMode.Add)
                {
                    dlgXMSS050_Item_Load(this, new EventArgs());
                    ControlUtil.ClearControlData(this.Controls);
                    ControlUtil.EnableControl(true, ownerControl);
                    cboWarehouse.EditValue = null;
                    cboLocation.EditValue = null;
                    cboZone.EditValue = null;
                    cboItemCondition.EditValue = null;
                    rdoAfterRcv.Checked = true;
                    
                    if (Dialog != null)
                        Dialog = null;
                }
                else
                {
                    itemClassificationControl.DataLoading();

                    DataBinding();

                    DataLoading();

                    cboTypeUnit.SelectedIndex = 2;
                    ControlUtil.EnableControl(false, cboTypeUnit);
                    ControlUtil.ClearControlData(cboWarehouse, cboZone, cboLocation, cboItemCondition);
                    //ControlUtil.EnableControl(false, btnSearchPallet, cboWarehouse, cboZone, cboLocation, cboItemCondition, btnAddLocation);

                }
                ControlUtil.EnableControl(true, cboProductType);
            }
            catch (Exception ex)
            {
                base.CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }

            return base.OnCommandClear();
        }
        
        #endregion
                
        #region Event Handler Function

        #region Transit Zone
        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateTransiZone())
                {
                    DataRow dr = dtTransitZone.NewRow();
                   // dr[eTransitZone.ProductID.ToString()] = DBNull.Value;
                    dr[eTransitZone.ProductConditionID.ToString()] = cboItemCondition.EditValue;
                    dr[eTransitZone.ZoneID.ToString()] = cboZone.EditValue;

                    if (cboLocation.Enabled)
                        dr[eTransitZone.LocationID.ToString()] = cboLocation.EditValue;
                    else
                        dr[eTransitZone.LocationID.ToString()] = DBNull.Value;

                    dr[eTransitZone.ProductConditionDisplayName.ToString()] = cboItemCondition.Text;
                    dr[eTransitZone.ZoneDisplayName.ToString()] = cboZone.Text;
                    dr[eTransitZone.LocationDisplayName.ToString()] = cboLocation.Text;
                    dr[eTransitZone.WarehouseDisplayName.ToString()] = cboWarehouse.Text;

                    DataTable dt = grdTransitZone.DataSource as DataTable;


                    

                    if (cboLocation.Enabled)
                    {
                        string selectFilter = eTransitZone.ZoneID.ToString() + " = {0} AND " +
                                eTransitZone.ProductConditionID.ToString() + " = {1} AND " +
                                eTransitZone.LocationID.ToString() + " = {2} ";

                        DataRow[] drAlreadyAdd = dt.Select(string.Format(selectFilter, cboZone.EditValue, cboItemCondition.EditValue, cboLocation.EditValue)).ToArray();

                        if (drAlreadyAdd.Length > 0)
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, "The data already exist, cannot insert this data to table.");
                            return;
                        }
                    }
                    else
                    {
                        string selectFilter = eTransitZone.ZoneID.ToString() + " = {0} AND " +
                                eTransitZone.ProductConditionID.ToString() + " = {1}";

                        DataRow[] drAlreadyAdd = dt.Select(string.Format(selectFilter, cboZone.EditValue, cboItemCondition.EditValue)).ToArray();

                        if (drAlreadyAdd.Length > 0)
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, "The data already exist, cannot insert this data to table.");
                            return;
                        }
                    }


                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    if (row[eTransitZone.ZoneID.ToString()] == cboZone.EditValue
                    //        && row[eTransitZone.ProductConditionID.ToString()] == cboItemCondition.EditValue
                    //        && (!cboLocation.Enabled || row[eTransitZone.LocationID.ToString()] == cboLocation.EditValue))
                    //    {
                    //        MessageDialog.ShowBusinessErrorMsg(this, "The data already exist, cannot insert this data to table.");
                    //        return;
                    //    }


                    //}

                    dtTransitZone.Rows.Add(dr);

                    DataTable dtTrans = grdTransitZone.DataSource as DataTable;
                    if (dtTrans.Rows.Count > 0)
                    {
                        ControlUtil.EnableControl(false, cboProductType);
                    }
                    else
                    {
                        ControlUtil.EnableControl(true, cboProductType);
                    }

                    if (DataUtil.Convert<int>(cboProductType.EditValue) == 1 && dtTrans.Rows.Count >= 1)
                    {
                        ControlUtil.EnableControl(false, btnAddLocation);
                    }

                }
                
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnDeleteLocation_Click(object sender, EventArgs e)
        {
            try
            {
                gdvTransitZone.DeleteSelectedRows();

                DataTable dtTrans = grdTransitZone.DataSource as DataTable;
                if (dtTrans.Rows.Count == 0)
                {
                    if (cboProductType.EditValue != null)
                    {
                        if (Convert.ToInt32(cboProductType.EditValue) == 2)
                        {

                            ControlUtil.EnableControl(true, cboWarehouse, cboZone, cboItemCondition, btnAddLocation);
                            ControlUtil.EnableControl(false, cboLocation);
                            cboLocation.EditValue = null;
                        }
                        else
                        {
                            ControlUtil.EnableControl(true, cboWarehouse, cboZone, cboLocation,cboItemCondition, btnAddLocation);                            
                        }
                    }
                    ControlUtil.EnableControl(true, cboProductType, btnAddLocation);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void cboWarehouse_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboWarehouse.EditValue == null)
                {
                    cboZone.Properties.DataSource = null;
                    cboLocation.Properties.DataSource = null;
                }
                else
                {
                    cboZone.Properties.DataSource = ZoneCommonBusiness.DataLoading(ownerControl.OwnerID, DataUtil.Convert<int>(cboWarehouse.EditValue), null);
                    cboZone.Properties.DisplayMember = "ZoneDisplayName";
                    cboZone.Properties.ValueMember = "ZoneID";
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void cboZone_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboZone.EditValue == null)
                {
                    cboLocation.Properties.DataSource = null;
                }
                else
                {
                    cboLocation.Properties.DataSource = LocationCommonBusiness.DataLoading(ownerControl.OwnerID, DataUtil.Convert<int>(cboWarehouse.EditValue), DataUtil.Convert<int>(cboZone.EditValue));
                    cboLocation.Properties.ValueMember = "LocationID";
                    cboLocation.Properties.DisplayMember = "LocationDisplay";
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        #endregion

        #region Cargo Type
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {

                gdcPackaging.OptionsColumn.AllowEdit = false;
                gdcL2Unit.OptionsColumn.AllowEdit = false;
                gdcL3Number.OptionsColumn.AllowEdit = false;
                gdcL3Unit.OptionsColumn.AllowEdit = false;
                gdcL4Number.OptionsColumn.AllowEdit = false;
                gdvCargoType.OptionsBehavior.Editable = false;
                //gdcGrossWeight.OptionsColumn.AllowEdit = false;
                btnEdit.Visible = true;
                btnOK.Visible = false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                gdcCargoType.OptionsColumn.AllowEdit = false;
                gdcPackaging.OptionsColumn.AllowEdit = true;
                gdcL2Unit.OptionsColumn.AllowEdit = true;
                gdcL3Number.OptionsColumn.AllowEdit = true;
                gdcL3Unit.OptionsColumn.AllowEdit = true;
                gdcL4Number.OptionsColumn.AllowEdit = true;
                gdvCargoType.OptionsBehavior.Editable = true;
                //gdcGrossWeight.OptionsColumn.AllowEdit = true;
                btnEdit.Visible = false;
                btnOK.Visible = true;

            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void gdvCargoType_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool isValid = true;
            //ColumnView view = sender as ColumnView;
            //view.ClearColumnErrors();

            //e.ErrorText = Rubix.Screen.Common.GetMessage("I0353");
            ////Cargotype
            //if (view.GetRowCellValue(e.RowHandle, gdcCargoType).ToString().Trim() == String.Empty)
            //{
            //    isValid = false;
            //    view.SetColumnError(gdcCargoType, Rubix.Screen.Common.GetMessage(""));
            //}
            ////Package
            //if (view.GetRowCellValue(e.RowHandle, gdcPackaging).ToString().Trim() == String.Empty)
            //{
            //    isValid = false;
            //    view.SetColumnError(gdcPackaging, Rubix.Screen.Common.GetMessage(""));
            //}
            ////LV1Vol
            //if (view.GetRowCellValue(e.RowHandle, gdcL1Vol).ToString().Trim() == String.Empty)
            //{
            //    isValid = false;
            //    view.SetColumnError(gdcL1Vol, Rubix.Screen.Common.GetMessage(""));
            //}
            ////LV1Unit
            //if (view.GetRowCellValue(e.RowHandle, gdcL1Unit).ToString().Trim() == String.Empty)
            //{
            //    isValid = false;
            //    view.SetColumnError(gdcPackaging, Rubix.Screen.Common.GetMessage(""));
            //}
            ////LV2Vol
            //if (view.GetRowCellValue(e.RowHandle, gdcL1Vol).ToString().Trim() == String.Empty)
            //{
            //    isValid = false;
            //    view.SetColumnError(gdcPackaging, Rubix.Screen.Common.GetMessage(""));
            //}
            ////L2Number
            //if (view.GetRowCellValue(e.RowHandle, gdcL2Number).ToString().Trim() == String.Empty)
            //{
            //    isValid = false;
            //    view.SetColumnError(gdcL2Number, Rubix.Screen.Common.GetMessage(""));
            //}
            ////L2Unit
            //if (view.GetRowCellValue(e.RowHandle, gdcL2Unit).ToString().Trim() == String.Empty)
            //{
            //    isValid = false;
            //    view.SetColumnError(gdcL2Unit, Rubix.Screen.Common.GetMessage(""));
            //}
            ////L3Number
            //if (view.GetRowCellValue(e.RowHandle, gdcL3Number).ToString().Trim() == String.Empty)
            //{
            //    isValid = false;
            //    view.SetColumnError(gdcL3Number, Rubix.Screen.Common.GetMessage(""));
            //}
            ////L3Unit
            //if (view.GetRowCellValue(e.RowHandle, gdcL3Unit).ToString().Trim() == String.Empty)
            //{
            //    isValid = false;
            //    view.SetColumnError(gdcL3Unit, Rubix.Screen.Common.GetMessage(""));
            //}
            ////L4Number
            //if (view.GetRowCellValue(e.RowHandle, gdcL4Number).ToString().Trim() == String.Empty)
            //{
            //    isValid = false;
            //    view.SetColumnError(gdcL4Number, Rubix.Screen.Common.GetMessage(""));
            //}
            ////L4Unit
            //if (view.GetRowCellValue(e.RowHandle, gdcL4Unit).ToString().Trim() == String.Empty)
            //{
            //    isValid = false;
            //    view.SetColumnError(gdcL4Unit, Rubix.Screen.Common.GetMessage(""));
            //}

            e.Valid = isValid;
        }
        #endregion

        #region Material Packing
        private void gdvMaterialPacking_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gdcMaterialItemCode)
                {
                    
                    if (Util.IsNullOrEmpty(e.Value))
                    {
                        gdvMaterialPacking.SetRowCellValue(e.RowHandle, gdcMaterialItemName, "");
                        return;
                    }
                    DataRow[] dr = (repMaterialItem.DataSource as DataTable).Select(string.Format("ProductID = '{0}'", e.Value));
                    if (dr.Length > 0)
                    {
                        DataRow drr = gdvMaterialPacking.GetFocusedDataRow();
 
                        if (drr != null)
                        {
                           gdvMaterialPacking.SetRowCellValue(e.RowHandle, gdcMaterialUsage, drr["DefaultQty"]);
                           drr["Weight"] = dr[0]["Weight"];
                        }
                        gdvMaterialPacking.SetRowCellValue(e.RowHandle, gdcMaterialItemName, dr[0]["ProductName"]);
                        
                    }
                    else
                    {
                        gdvMaterialPacking.SetRowCellValue(e.RowHandle, gdcMaterialItemName, "");
                    }


                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void gdvMaterialPacking_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            bool isValid = true;
            ColumnView view = sender as ColumnView;
            view.ClearColumnErrors();

            if (view.GetRowCellValue(e.RowHandle, gdcMaterialItemCode).ToString().Trim() != String.Empty)
            {
                if (view.GetRowCellValue(e.RowHandle, gdcMaterialUsage).ToString().Trim() == String.Empty)
                {
                    isValid = false;
                    view.SetColumnError(gdcMaterialUsage, Rubix.Screen.Common.GetMessage("I0422"));
                }
                else if (DataUtil.Convert<int>(view.GetRowCellValue(e.RowHandle, gdcMaterialUsage).ToString().Trim()) <= 0)
                {
                    isValid = false;
                    view.SetColumnError(gdcMaterialUsage, Rubix.Screen.Common.GetMessage("I0422"));
                }
            }

            if (view.GetRowCellValue(e.RowHandle, gdcMaterialUsage).ToString().Trim() != String.Empty)
            {
                if (view.GetRowCellValue(e.RowHandle, gdcMaterialItemCode).ToString().Trim() == String.Empty)
                {
                    isValid = false;
                    view.SetColumnError(gdcMaterialItemCode, Rubix.Screen.Common.GetMessage("I0423"));
                }
            }

            isValidData = isValid;
            e.Valid = isValid;
        }

        private void gdvMaterialPacking_ShownEditor(object sender, EventArgs e)
        {
            if (gdvMaterialPacking.FocusedColumn.FieldName == "MaterialProductID" && gdvMaterialPacking.ActiveEditor is SearchLookUpEdit)
            {
                DevExpress.XtraEditors.SearchLookUpEdit edit;
                edit = (SearchLookUpEdit)gdvMaterialPacking.ActiveEditor;

                DataTable dtAll = edit.Properties.DataSource as DataTable;

                DataRow View = gdvMaterialPacking.GetFocusedDataRow() as DataRow;
                DataRow[] drrSelect = null;
                if (dtAll != null && dtAll.Rows.Count != 0)
                {
                    drrSelect = dtAll.Select(string.Format("ProductTypeID = {0}", View["ProductTypeID"]));

                }

                if (drrSelect != null && drrSelect.Length > 0)
                {
                    edit.Properties.DataSource = drrSelect.CopyToDataTable();
                }
                else
                {
                    edit.Properties.DataSource = null;

                }

            }
        }


        #endregion

        private void txtPackingTime_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                double? d = DataUtil.Convert<double>(e.NewValue);
                if (d.HasValue)
                {
                    if (!ValidTimeMinSec(d.Value))
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, "วินาทีต้องไม่เกิน 59");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
        }

        private void txtPrepareTime_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                double? d = DataUtil.Convert<double>(e.NewValue);
                if (d.HasValue)
                {
                    if (!ValidTimeMinSec(d.Value))
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, "วินาทีต้องไม่เกิน 59");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
        }

        private void txtPalletizeTime_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                double? d = DataUtil.Convert<double>(e.NewValue);
                if (d.HasValue)
                {
                    if (!ValidTimeMinSec(d.Value))
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, "วินาทีต้องไม่เกิน 59");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
        }

        private void txtRemark_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                if (e.NewValue.ToString().Length > 5)
                {
                    e.Cancel = true;
                }
            }
        }

        private void dlgXMSS050_Item_Load(object sender, EventArgs e)
        {
            try
            {
                itemClassificationControl.DataLoading();

                DataBinding();

                if (ScreenMode != Common.eScreenMode.Add)
                {
                    DataLoading();

                    if (ScreenMode == Common.eScreenMode.Edit)
                    {
                        ControlUtil.HiddenControl(false, m_toolBarSaveACopy);
                        if (DataUtil.Convert<int>(cboProductType.EditValue) != 4)
                        {
                            ControlUtil.EnableControl(false, btnSearchPallet);
                        }
                        
                    }

                    if (ScreenMode == Common.eScreenMode.View)
                    {
                        gdvMaterialPacking.OptionsBehavior.Editable = false;
                        gdvTransitZone.OptionsBehavior.Editable = false;

                        ControlUtil.EnableControl(false, this.Controls);
                        ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarClear);
                    }


                }
                else
                {
                    ControlUtil.EnableControl(false, btnSearchPallet, cboWarehouse, cboZone, cboLocation, cboItemCondition, btnAddLocation);

                }

                cboTypeUnit.SelectedIndex = 2;
                ControlUtil.EnableControl(false, cboTypeUnit);
                lblWhite.Text = Rubix.Screen.Common.GetMessage("A0010");
                lblOrange.Text = Rubix.Screen.Common.GetMessage("A0011");
                
            }
            catch (Exception ex)
            {
                base.CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        
        private void dlgXMSS050_Item_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnOK.Visible)
            {
                e.Cancel = (MessageDialog.ShowConfirmationMsg(this, Common.GetMessage("I0004")) != DialogButton.Yes);
            }

            pictureBox1.Image = null;
            pictureBox2.Image = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void ownerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            
            {

                cboWarehouse.Properties.DataSource = WarehouseCommonBusiness.DataLoading(ownerControl.OwnerID);
                cboWarehouse.Properties.DisplayMember = "DisplayMember";
                cboWarehouse.Properties.ValueMember = "WarehouseID";

                supplierControl.OwnerID = ownerControl.OwnerID;
                supplierControl.DataLoading();

                cboZone.Properties.DataSource = null;
                cboLocation.Properties.DataSource = null;

                if (this.eScrenMode == Common.eScreenMode.Edit || this.eScrenMode == Common.eScreenMode.View)
                {
                    ControlUtil.EnableControl(false, ownerControl);    
                }
                
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void itemGroupControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (itemGroupControl.ProductGroupID != null)
                {
                    ItemCategoryControl.ProductGroupID = itemGroupControl.ProductGroupID;
                    ItemCategoryControl.DataLoading();
                }
                else
                {
                    ItemCategoryControl.ProductGroupID = -1;
                    ItemCategoryControl.DataLoading();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
        
        private void btnBrowesr_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Imgage Files (*.gif,*.jpg,*.jpeg,*.tiff,*.bmp)|*.gif;*.jpg;*.jpeg;*.tiff;*.bmp";
            //Bitmap bm;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog1.FileName);

                long filesize = fileInfo.Length;
                if (filesize >= 4194340)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0200"));
                    return;
                }

                fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                pictureBox1.Image = Image.FromStream(fs);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            fs = null;
            pictureBox1.Image = null;
        }

        private void btnQCBrowsePicture_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Imgage Files (*.gif,*.jpg,*.jpeg,*.tiff,*.bmp)|*.gif;*.jpg;*.jpeg;*.tiff;*.bmp";
            //Bitmap bm;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog1.FileName);

                long filesize = fileInfo.Length;
                if (filesize >= 4194340)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0200"));
                    return;
                }

                fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                pictureBox2.Image = Image.FromStream(fs);
            }
        }

        private void btnQCDeletePicture_Click(object sender, EventArgs e)
        {
            fs = null;
            pictureBox2.Image = null;
        }
        
        private void txtShelfLife_Properties_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value is String)
            {
                e.Value = DataUtil.Convert<int>((string)e.Value);
                e.Handled = true;
            }
        }

        private void txtSafetyStock_Properties_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value is String)
            {
                e.Value = DataUtil.Convert<decimal>((string)e.Value);
                e.Handled = true;
            }
        }

        private void txtEstimateValue_Properties_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value is String)
            {
                e.Value = DataUtil.Convert<decimal>((string)e.Value);
                e.Handled = true;
            }
        }

        private void gdvCargoType_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                decimal Weight = 1;
                decimal Number2;
                decimal Number3;
                decimal Number4;

                if (e.Column == gdcPackaging || e.Column == gdcL2Number || e.Column == gdcL3Number || e.Column == gdcL4Number)
                {
                    if (e.Column == gdcPackaging)
                    {
                        sp_common_LoadPackaging_Result rs = (repPackaging.DataSource as List<sp_common_LoadPackaging_Result>).Where(c => c.PackageID == Convert.ToInt32(e.Value)).FirstOrDefault();
                        if (rs != null)
                        {
                            Weight = rs.Weight;
                        }
                    }

                    if (Util.IsNullOrEmpty(gdvCargoType.GetRowCellValue(e.RowHandle, gdcL2Number)))
                    {
                        Number2 = 1;
                    }
                    else
                    {
                        Number2 = Convert.ToDecimal(gdvCargoType.GetRowCellValue(e.RowHandle, gdcL2Number));
                    }

                    if (Util.IsNullOrEmpty(gdvCargoType.GetRowCellValue(e.RowHandle, gdcL3Number)))
                    {
                        Number3 = 1;
                    }
                    else
                    {
                        Number3 = Convert.ToDecimal(gdvCargoType.GetRowCellValue(e.RowHandle, gdcL3Number));
                    }

                    if (Util.IsNullOrEmpty(gdvCargoType.GetRowCellValue(e.RowHandle, gdcL4Number)))
                    {
                        Number4 = 1;
                    }
                    else
                    {
                        Number4 = Convert.ToDecimal(gdvCargoType.GetRowCellValue(e.RowHandle, gdcL4Number));
                    }
                    //Number of Unit Level3 * Number of Unit Level4
                    gdvCargoType.SetRowCellValue(e.RowHandle, gdcNetWeight, Number3 * Number4);                
                    //gdvCargoType.SetRowCellValue(e.RowHandle, gdcGrossWeight, (Number3 * Number4) + (Number2 * Weight));
                    //(Number of Unit Level3 * Number of Unit Level4) + Weight of Packaging --> 1 Box
                    //gdvCargoType.SetRowCellValue(e.RowHandle, gdcGrossWeight, ((Number3 * Number4)));
                    
                    CalGrossWeight();
                }
                else if (e.Column == gdcPallet)
                {
                    DataTable dt = repPallet.DataSource as DataTable;
                    DataRow[] drSelect = dt.Select(string.Format(" PalletID = {0} ", e.Value));
                    gdvCargoType.SetRowCellValue(e.RowHandle, gdcPalletWeightLimit, drSelect[0]["WeightLimit"]);     
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void cboProductType_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProductType.EditValue == null)
            {
                ControlUtil.EnableControl(false, cboWarehouse, cboZone, cboLocation, cboItemCondition, btnAddLocation);
            }
            else
            {
                ControlUtil.EnableControl(true, cboWarehouse, cboZone, cboLocation, cboItemCondition, btnAddLocation);

            }
            switch (DataUtil.Convert<int>(cboProductType.EditValue))
            {
                case 1: rdoShipTagType2.Checked = true;
                    rdoShipTagType0.Enabled = true;
                    rdoShipTagType1.Enabled = false;
                    rdoShipTagType2.Enabled = true;
                    rdoShipTagType3.Enabled = false;
                    break;
                case 2: rdoShipTagType3.Checked = true;
                    rdoShipTagType0.Enabled = true;
                    rdoShipTagType1.Enabled = true;
                    rdoShipTagType2.Enabled = false;
                    rdoShipTagType3.Enabled = true;
                    break;
                default : rdoShipTagType0.Checked = true;
                    rdoShipTagType0.Enabled = true;
                    rdoShipTagType1.Enabled = true;
                    rdoShipTagType2.Enabled = true;
                    rdoShipTagType3.Enabled = true;
                    break;
            }
            if (DataUtil.Convert<int>(cboProductType.EditValue) == 2)
            {
                cboLocation.Enabled = false;
                cboLocation.EditValue = null;
            }
            else
            {
                cboLocation.Enabled = true;

            }

            if (DataUtil.Convert<int>(cboProductType.EditValue) < 3)
            {
                reqFieldMinOrder.Visible = true;
            }
            else
            {
                reqFieldMinOrder.Visible = false;
            }

            if (DataUtil.Convert<int>(cboProductType.EditValue) == 4)
            {
                btnSearchPallet.Enabled = true;
            }
            else
            {
                btnSearchPallet.Enabled = false;
            }

            InitGrid();

            
        }

        private void btnSalePerchasePrise_Click(object sender, EventArgs e)
        {
            try
            {
                if (ownerControl.OwnerID == null)
                {
                    ownerControl.RequireField = true;
                    ownerControl.ErrorText = Rubix.Screen.Common.GetMessage("I0026");
                    if (!ownerControl.ValidateControl())
                    {
                        return;
                    }
                    //errorProvider.SetError(supplierControl, Rubix.Screen.Common.GetMessage("I0300"));
                    //return;
                }

                if (supplierControl.SupplierID == null)
                {
                    supplierControl.RequireField = true;
                    supplierControl.ErrorText = Rubix.Screen.Common.GetMessage("I0300");
                    if (!supplierControl.ValidateControl())
                    {
                        return;
                    }
                    //errorProvider.SetError(supplierControl, Rubix.Screen.Common.GetMessage("I0300"));
                    //return;
                }

               

                OpenDialog(ScreenMode);

            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }

        }

        private void btnSearchPallet_Click(object sender, EventArgs e)
        {
            try
            {

                if (PalletDialog.ShowDialog(this) == DialogResult.OK)
                {
                    txtPartCode.Text = PalletDialog.PalletCode;
                    txtPartName.Text = PalletDialog.PalletName;
                }


                // PalletDialog = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if (e.Page == tpCargoType)
            {
                CalGrossWeight();
            }
        }
        #endregion

        #region Generic Function

        private Boolean ValidateTransiZone()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();
            ////Warehouse
            if (cboWarehouse.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(cboWarehouse, Rubix.Screen.Common.GetMessage("I0045"));
                errFlag = false;
            }

            ////Zone
            if (cboZone.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(cboZone, Rubix.Screen.Common.GetMessage("I0055"));
                errFlag = false;
            }

            ////Location
            if (cboLocation.Enabled && cboLocation.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(cboLocation, Rubix.Screen.Common.GetMessage("I0107"));
                errFlag = false;
            }
            
            ////Product Condition
            if (cboItemCondition.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(cboItemCondition, Rubix.Screen.Common.GetMessage("I0302"));
                errFlag = false;
            }

            

            return errFlag;
        }

        private bool ValidTimeMinSec(double val)
        {
            try
            {
                if (val - Math.Floor(val) >= 0.6)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private Boolean ValidateData()
        {

            Boolean errFlag = true;
            errorProvider.ClearErrors();

            ////Customer Code
            ownerControl.RequireField = true;
            ownerControl.ErrorText = Rubix.Screen.Common.GetMessage("I0026");
            if (!ownerControl.ValidateControl())
            {
                errFlag = false;
            }

            ////Product Type
            if (cboProductType.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(cboProductType, Rubix.Screen.Common.GetMessage("I0382"));
                errFlag = false;
            }

            ////Product Code
            if (txtPartCode.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtPartCode, Rubix.Screen.Common.GetMessage("I0093"));
                errFlag = false;
            }

            ////Product Short Code
            if (txtPartShortCode.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtPartShortCode, Rubix.Screen.Common.GetMessage("I0381"));
                errFlag = false;
            }

            ////Product Name
            if (txtPartName.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtPartName, Rubix.Screen.Common.GetMessage("I0094"));
                errFlag = false;
            }

            if (txtWeightMinimumOrder.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtWeightMinimumOrder, Rubix.Screen.Common.GetMessage("I0094"));
                errFlag = false;
            }

            if (DataUtil.Convert<int>(txtWeightMinimumOrder.Text.Trim()) == 0)
            {
                errorProvider.SetError(txtWeightMinimumOrder, "WeightMinimumOrder ต้องมากกว่า 0");
                errFlag = false;
            }

            if (txtM3MinimumOrder.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtM3MinimumOrder, Rubix.Screen.Common.GetMessage("I0094"));
                errFlag = false;
            }

            if (txtPalletizeTime.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtPalletizeTime, "Palletize Time cannot empty");
                errFlag = false;
            }

            if (txtPackingTime.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtPackingTime, "Packing Time cannot empty");
                errFlag = false;
            }

            if (txtPrepareTime.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtPrepareTime, "Prepare Time cannot empty");
                errFlag = false;
            }

            if (DataUtil.Convert<int>(txtM3MinimumOrder.Text.Trim()) == 0)
            {
                errorProvider.SetError(txtM3MinimumOrder, "M3MinimumOrder ต้องมากกว่า 0");
                errFlag = false;
            }

            ////Item Group
            itemGroupControl.RequireField = true;
            itemGroupControl.ErrorText = Rubix.Screen.Common.GetMessage("I0149");
            if (!itemGroupControl.ValidateControl())
            {
                errFlag = false;
            }

            ////Item Classification
            itemClassificationControl.RequireField = true;
            itemClassificationControl.ErrorText = Rubix.Screen.Common.GetMessage("I0149");
            if (!itemClassificationControl.ValidateControl())
            {
                errFlag = false;
            }

            ////Supplier
            supplierControl.RequireField = true;
            supplierControl.ErrorText = Rubix.Screen.Common.GetMessage("I0300");
            if (!supplierControl.ValidateControl())
            {
                errFlag = false;
            }

            ////Min Order
            if (cboProductType.EditValue != null && DataUtil.Convert<int>(cboProductType.EditValue) < 3)
            {
                if (txtMinOrder.Text.Trim() == String.Empty)
                {
                    errorProvider.SetError(txtMinOrder, Rubix.Screen.Common.GetMessage("I0395"));
                    errFlag = false;
                }
            }

            ////Grid
            if (gdvTransitZone.RowCount <= 0)
            {
                //errorProvider.SetError(xtraTabControl1, Rubix.Screen.Common.GetMessage("Please add Transit Zone at least one data."));
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0397"));
                errFlag = false;

            }
            if (errFlag == true)
            {
                errFlag = ValidateCargo();
            }

            if (errFlag == true)
            {
                if (DataUtil.Convert<int>(cboProductType.EditValue) == 2)
                {
                    DataTable dt = grdCargoType.DataSource as DataTable;
                    double numLv2 = Convert.ToDouble(dt.Rows[1]["L2Number"]);

                    if (Convert.ToInt32(txtMinOrder.EditValue) % numLv2 != 0)
                    {
                        errorProvider.SetError(txtMinOrder, Rubix.Screen.Common.GetMessage("I0394"));
                        errFlag = false;
                    }
                }
            }

            if (errFlag == true)
            {
                errFlag = ValidateMetrial();
            }
            
            

            return errFlag;
        }

        private Boolean ValidateCargo()
        {
            DataTable dttCargo = grdCargoType.DataSource as DataTable;
            errorProvider.ClearErrors();
            foreach (DataRow data in dttCargo.Rows)
            {
                if (data["PackageID"] == DBNull.Value)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0182"));
                    return false;
                }
                if (data["L1Vol"] == DBNull.Value)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, string.Format(Rubix.Screen.Common.GetMessage("I0198"),"Level 1"));
                    return false;
                }
                if (data["L1Unit"] == DBNull.Value)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, string.Format(Rubix.Screen.Common.GetMessage("I0197"), "Level 1"));
                    return false;
                }
                if (data["L2Number"] == DBNull.Value)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, string.Format(Rubix.Screen.Common.GetMessage("I0198"), "Level 2"));
                    return false;
                }
                if (data["L2Unit"] == DBNull.Value)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, string.Format(Rubix.Screen.Common.GetMessage("I0197"), "Level 2"));
                    return false;
                }
                if (data["L3Number"] == DBNull.Value)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, string.Format(Rubix.Screen.Common.GetMessage("I0198"), "Level 3"));
                    return false;
                }
                if (data["L3Unit"] == DBNull.Value)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, string.Format(Rubix.Screen.Common.GetMessage("I0197"), "Level 3"));
                    return false;
                }
                if (data["L4Number"] == DBNull.Value)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, string.Format(Rubix.Screen.Common.GetMessage("I0198"), "Level 4"));
                    return false;
                }
                if (data["L4Unit"] == DBNull.Value)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, string.Format(Rubix.Screen.Common.GetMessage("I0197"), "Level 4"));
                    return false;
                }

                if (cboProductType.EditValue != null && DataUtil.Convert<int>(cboProductType.EditValue) <= 2)
                {
                    if ( data["PalletID"] == DBNull.Value)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, string.Format(Rubix.Screen.Common.GetMessage("I0396")));
                        return false;
                    }
                }

                if (data["PalletWeightLimit"] != DBNull.Value && data["CargoType"].ToString() == "Sale")
                {
                    if (Convert.ToDecimal(data["PalletWeightLimit"]) < Convert.ToDecimal(data["L2Number"]) * Convert.ToDecimal(data["L3Number"]) * Convert.ToDecimal(data["L4Number"]))
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0428"));
                        return false;                        
                    }
                }

                //if (!data.InventoryRecord.HasValue)
                //{
                //    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0188"));
                //    return false;
                //}
                //if (!BusinessClass.IsUnitOfVolumn(data.InventoryRecord.Value) && data.InventoryRecord != data.L1Unit && data.InventoryRecord != data.L2Unit && data.InventoryRecord != data.L3Unit && data.InventoryRecord != data.L4Unit)
                //// end 7 Feb 2013
                //{
                //    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0189"));
                //    return false;
                //}


            }
            return true;
        }

        private Boolean ValidateMetrial()
        {
            DataTable dttMatrial = grdMaterialPacking.DataSource as DataTable;
            errorProvider.ClearErrors();
            //DataRow[] dr = dttMatrial.Rows[0];
            //IF mix(1) and pure(2) require at least 1 packing material
            int pType = Convert.ToInt32(cboProductType.EditValue);
            if (pType == 1 || pType == 2)
            {
                if (dttMatrial.Select("MaterialProductID IS NOT NULL").Length > 0)
                {
                    return true;
                }
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0421"));
                return false;
            }
            else
            {
                return true;
                
            }
            
            

        }

        private void DataBinding()
        {
            try
            {
                m_statusBarUpdatedDate.Caption = "-";
                m_statusBarUpdatedUser.Caption = "-";
                ownerControl.Focus();
                InitCombobox();
                InitControl();


                DataSet ds = BusinessClass.LoadMaterial(null);
                ds.AcceptChanges();
                grdMaterialPacking.DataSource = ds.Tables[0];
                repMaterialItem.DataSource = ds.Tables[1];

                
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private decimal convertSecondTo100(decimal? val)
        {
            try
            {
                if (val.HasValue)
                {
                    decimal second = ((val.Value - Math.Floor(val.Value)) * 100 / 60);
                    return Math.Floor(val.Value) + second;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private decimal convert100ToSecond(decimal? val)
        {
            try
            {
                if (val.HasValue)
                {
                    decimal second = ((val.Value - Math.Floor(val.Value)) * 60 / 100);
                    return Math.Floor(val.Value) + second;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void SaveData()
        {
            DataSet dsTSZ = new DataSet("TransitZoneDataSet");
            DataSet dsPacking = new DataSet("PackingDataSet");
            DataSet dsCargo = new DataSet("CargoDataSet");

            try
            {
                
                ProductInfo.OwnerID = ownerControl.OwnerID;
                //ProductInfo.ProductID = BusinessClass.ProductID;
                ProductInfo.ProductTypeID = DataUtil.Convert<int>(cboProductType.EditValue);
                ProductInfo.Model = txtModel.Text;
                ProductInfo.ProductCode = txtPartCode.Text;
                ProductInfo.ProductShortCode = txtPartShortCode.Text;
                ProductInfo.ProductName = txtPartName.Text;
                ProductInfo.ProductGroupID = itemGroupControl.ProductGroupID;
                ProductInfo.SupplierID = supplierControl.SupplierID;
                ProductInfo.ProductCategoryID = ItemCategoryControl.ProductCategoryID;
                ProductInfo.ClassificationID = itemClassificationControl.ClassificationID;
                ProductInfo.MinOrder = DataUtil.Convert<int>(txtMinOrder.EditValue);
                ProductInfo.PackingTime = convertSecondTo100(DataUtil.Convert<decimal>(txtPackingTime.Text));
                ProductInfo.PrepareTime = convertSecondTo100(DataUtil.Convert<decimal>(txtPrepareTime.Text));
                ProductInfo.PalletizeTime = convertSecondTo100(DataUtil.Convert<decimal>(txtPalletizeTime.Text));
                ProductInfo.WeightMinimumOrder = DataUtil.Convert<decimal>(txtWeightMinimumOrder.Text);
                ProductInfo.M3MinimumOrder = DataUtil.Convert<decimal>(txtM3MinimumOrder.Text);
                ProductInfo.isSpecial = (ChkSpecialCaseMark.Checked) ? 1 : 0;

                int? _typeUnit = null;
                if (cboTypeUnit.EditValue != null)
                {

                    if (cboTypeUnit.EditValue.Equals("Lv. 1"))
                    {
                        _typeUnit = 1;
                    }
                    else if (cboTypeUnit.EditValue.Equals("Lv. 2"))
                    {
                        _typeUnit = 2;
                    }
                    else if (cboTypeUnit.EditValue.Equals("Lv. 3"))
                    {
                        _typeUnit = 3;
                    }
                    else if (cboTypeUnit.EditValue.Equals("Lv. 4"))
                    {
                        _typeUnit = 4;
                    }
                }
                ProductInfo.TypeOfUnit = _typeUnit;
                ProductInfo.PalletTypeID = DataUtil.Convert<int>(cboTypeOfPallet.EditValue);
                if (rdoAfterProduct.Checked)
                {
                    ProductInfo.ItemExpiredTypeID = 1;
                }
                else if (rdoAfterRcv.Checked)
                {
                    ProductInfo.ItemExpiredTypeID = 2;
                }
                else
                {
                    ProductInfo.ItemExpiredTypeID = 3;
                }

                if (rdoShipTagType0.Checked)
                {
                    ProductInfo.ShipTagTypeID = 0;
                }
                else if (rdoShipTagType1.Checked)
                {
                    ProductInfo.ShipTagTypeID = 1;
                }
                else if (rdoShipTagType2.Checked)
                {
                    ProductInfo.ShipTagTypeID = 2;
                }
                else 
                {
                    ProductInfo.ShipTagTypeID = 3;
                }

                ProductInfo.ShelfLife = DataUtil.Convert<int>(txtShelfLife.EditValue);
                ProductInfo.SafetyStock = DataUtil.Convert<int>(txtSafetyStock.EditValue);
                ProductInfo.UnitLevelReceivingLabel = DataUtil.Convert<int>(cboUnitLevel.EditValue);
                ProductInfo.LotControl = chkLot.Checked ? 1 : 0;
                ProductInfo.KanbanControl = chkKanban.Checked ? 1 : 0;
                ProductInfo.FreeOfCharge = DataUtil.Convert<int>(txtFreeOfCharge.EditValue);
                ProductInfo.EstimateValue = DataUtil.Convert<decimal>(txtEstimateValue.EditValue);
                ProductInfo.Remark = txtRemark.Text;
                ProductInfo.ImageFile = ControlUtil.ConvertImageByte(pictureBox1.Image);
                ProductInfo.QCImageFile = ControlUtil.ConvertImageByte(pictureBox2.Image);
                ProductInfo.CurrentUser = AppConfig.UserLogin;
                ProductInfo.IsShowGrossWeight = chkShowGrossWeight.Checked;

                ProductInfo.TransitXML = null;
                ProductInfo.CargoXML = null;
                ProductInfo.PackingXML = null;

                // SqlDateTime overflow. Must be between 1/1/1753 12:00:00 AM and 12/31/9999 11:59:59 PM.
                if (ProductInfo.SalePrice == null && ProductInfo.PurchasePrice == null)
                {  
                    ProductInfo.EffectiveDate_Sale = DateTime.Now;
                    ProductInfo.ImplementDate_Sale = DateTime.Now;
                    ProductInfo.EffectiveDate_Purchase = DateTime.Now;
                    ProductInfo.ImplementDate_Purchase = DateTime.Now;
                }

                if (ProductInfo.ImplementDate_Sale.Equals(new DateTime()))
                {
                    ProductInfo.ImplementDate_Sale = null;
                }
                if (ProductInfo.ImplementDate_Purchase.Equals(new DateTime()))
                {
                    ProductInfo.ImplementDate_Purchase = null;
                }

                dtTransitZone.TableName = "TransitZoneDataTable";
                dsTSZ.Tables.Add(dtTransitZone);

                ProductInfo.TransitXML = dsTSZ.GetXml();

                CalGrossWeight();

                //Cargo
                DataTable dtCargo = grdCargoType.DataSource as DataTable;
                dtCargo.TableName = "CargoDataTable";

                dsCargo.Tables.Add(dtCargo);
                ProductInfo.CargoXML = dsCargo.GetXml();

                //Material
                DataTable dtPackingMaterial = new DataTable();
                dtPackingMaterial = (grdMaterialPacking.DataSource as DataTable).Copy();
                dtPackingMaterial.TableName = "PackingDataTable";
                dsPacking.Tables.Add(dtPackingMaterial);
                ProductInfo.PackingXML = dsPacking.GetXml();



                BusinessClass.SaveData(ProductInfo);
            }
            finally
            {
                dsTSZ.Tables.Clear();
                dsCargo.Tables.Clear();
                dsPacking.Tables.Clear();
            }
        }

        private void DataLoading()
        {            
            DataSet ds = BusinessClass.DataLoadingDetail(Convert.ToInt32(BusinessClass.SelectedRow["ProductID"]));
            if (ds.Tables.Count > 0)
            {
                DataTable dtHeader = ds.Tables[0].Copy();
                DataTable dtSalePrice = ds.Tables[1].Copy();
                DataTable dtPurchasePrice = ds.Tables[2].Copy();
                DataTable dtTransitZone = ds.Tables[3].Copy();
                DataTable dtCargo = ds.Tables[4].Copy();
                DataTable dtPackingMaterial = ds.Tables[5].Copy();

                ownerControl.OwnerID                        = DataUtil.Convert<int>(dtHeader.Rows[0]["OwnerID"]);
                ProductInfo.ProductID                       = DataUtil.Convert<int>(dtHeader.Rows[0]["ProductID"]);
                cboProductType.EditValue                    = dtHeader.Rows[0]["ProductTypeID"];
                txtModel.Text                               = dtHeader.Rows[0]["Model"].ToString();
                txtPartCode.Text                            = dtHeader.Rows[0]["ProductCode"].ToString();
                txtPartShortCode.Text                       = dtHeader.Rows[0]["ProductShortCode"].ToString();
                txtPartName.Text                            = dtHeader.Rows[0]["ProductLongName"].ToString();
                itemGroupControl.ProductGroupID             = DataUtil.Convert<int>(dtHeader.Rows[0]["ProductGroupID"].ToString());
                supplierControl.SupplierID                  = DataUtil.Convert<int>(dtHeader.Rows[0]["SupplierID"].ToString());
                ItemCategoryControl.ProductCategoryID       = DataUtil.Convert<int>(dtHeader.Rows[0]["ProductCategoryID"].ToString());
                itemClassificationControl.ClassificationID  = DataUtil.Convert<int>(dtHeader.Rows[0]["ClassificationID"].ToString());
                txtMinOrder.EditValue                       = DataUtil.Convert<int>(dtHeader.Rows[0]["MinOrder"]);
                cboTypeUnit.EditValue                       = dtHeader.Rows[0]["TypeOfUnit"] != null ? "Lv. " + dtHeader.Rows[0]["TypeOfUnit"] : "";
                cboTypeOfPallet.EditValue                   = dtHeader.Rows[0]["PalletTypeID"];
                txtPackingTime.EditValue                    = convert100ToSecond(DataUtil.Convert<decimal>(dtHeader.Rows[0]["PackingTime"]));
                txtPrepareTime.EditValue                    = convert100ToSecond(DataUtil.Convert<decimal>(dtHeader.Rows[0]["PrepareTime"]));
                txtPalletizeTime.EditValue                  = convert100ToSecond(DataUtil.Convert<decimal>(dtHeader.Rows[0]["PalletizeTime"]));

                if (DataUtil.Convert<int>(dtHeader.Rows[0]["ItemExpiredTypeID"].ToString()) == 1)
                {
                    rdoAfterProduct.Checked = true;
                }
                else if (DataUtil.Convert<int>(dtHeader.Rows[0]["ItemExpiredTypeID"].ToString()) == 2)
                {
                    rdoAfterRcv.Checked = true;
                }
                else
                {
                    rdoFollowCOA.Checked = true;
                }

                int? Is_Special = DataUtil.Convert<int>(dtHeader.Rows[0]["Is_Special"]);
                if (Is_Special == 1)
                {
                    ChkSpecialCaseMark.Checked = true;
                }
                else
                {
                    ChkSpecialCaseMark.Checked = false;
                }

                int? ShipTagTypeID = DataUtil.Convert<int>(dtHeader.Rows[0]["ShipTagTypeID"].ToString());
                switch (ShipTagTypeID)
                {
                    case 0: rdoShipTagType0.Checked = true;
                        rdoShipTagType1.Checked = false;
                        rdoShipTagType2.Checked = false;
                        rdoShipTagType3.Checked = false;
                        break;
                    case 1: rdoShipTagType1.Checked = true;
                        rdoShipTagType0.Checked = false;
                        rdoShipTagType2.Checked = false;
                        rdoShipTagType3.Checked = false;
                        break;
                    case 2: rdoShipTagType2.Checked = true;
                        rdoShipTagType0.Checked = false;
                        rdoShipTagType1.Checked = false;
                        rdoShipTagType3.Checked = false;
                        break;
                    case 3: rdoShipTagType3.Checked = true;
                        rdoShipTagType0.Checked = false;
                        rdoShipTagType1.Checked = false;
                        rdoShipTagType2.Checked = false;
                        break;
                    default: rdoShipTagType0.Checked = true;
                        rdoShipTagType1.Checked = false;
                        rdoShipTagType2.Checked = false;
                        rdoShipTagType3.Checked = false;
                        break;
                }
                

                txtShelfLife.EditValue = DataUtil.Convert<int>(dtHeader.Rows[0]["ShelfLife"].ToString());
                txtSafetyStock.EditValue = DataUtil.Convert<int>(dtHeader.Rows[0]["SafetyStock"].ToString());
                cboUnitLevel.EditValue = DataUtil.Convert<int>(dtHeader.Rows[0]["UnitLevelReceivingLabel"].ToString());

                txtWeightMinimumOrder.EditValue = DataUtil.Convert<decimal>(dtHeader.Rows[0]["WeightMinimumOrder"].ToString());
                txtM3MinimumOrder.EditValue = DataUtil.Convert<decimal>(dtHeader.Rows[0]["M3MinimumOrder"].ToString());

                chkKanban.Checked = (Boolean)dtHeader.Rows[0]["KanbanControl"];
                chkLot.Checked = (Boolean)dtHeader.Rows[0]["LotControl"];
                txtFreeOfCharge.EditValue = DataUtil.Convert<int>(dtHeader.Rows[0]["FreeOfCharge"].ToString());
                txtEstimateValue.EditValue = DataUtil.Convert<decimal>(dtHeader.Rows[0]["EstimateValue"].ToString());
                txtRemark.Text = dtHeader.Rows[0]["Remark"].ToString();


                byte[] imageByte = BusinessClass.LoadImage(Convert.ToInt32(BusinessClass.SelectedRow["ProductID"]));
                byte[] QCimageByte = BusinessClass.LoadQCImage(dtHeader.Rows[0]["ProductCode"].ToString());

                pictureBox1.Image = ControlUtil.ConvertByteToImage(imageByte);
                pictureBox2.Image = ControlUtil.ConvertByteToImage(QCimageByte);

                chkShowGrossWeight.Checked = (Boolean)dtHeader.Rows[0]["IsShowGrossWeight"];

                //Binding Statusbar
                m_statusBarCreatedDate.Caption = Convert.ToDateTime(dtHeader.Rows[0]["CreateDate"]).ToString(Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = dtHeader.Rows[0]["CreateUser"].ToString();
                if (!string.IsNullOrEmpty(dtHeader.Rows[0]["UpdateDate"].ToString()))
                {
                    m_statusBarUpdatedDate.Caption = Convert.ToDateTime(dtHeader.Rows[0]["UpdateDate"]).ToString(Common.FullDatetimeFormat);
                    m_statusBarUpdatedUser.Caption = dtHeader.Rows[0]["UpdateUser"].ToString();
                }
                else if (string.IsNullOrEmpty(dtHeader.Rows[0]["UpdateDate"].ToString()) && ScreenMode == Common.eScreenMode.Edit)
                {
                    m_statusBarUpdatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                    m_statusBarUpdatedUser.Caption = AppConfig.UserLogin;
                }

                if (dtSalePrice.Rows.Count > 0)
                {
                    //Sale
                    ProductInfo.CustomerID = DataUtil.Convert<int>(dtSalePrice.Rows[0]["CustomerID"].ToString());
                    ProductInfo.SalePrice = DataUtil.Convert<decimal>(dtSalePrice.Rows[0]["SalePrice"].ToString());
                    ProductInfo.CurrencyID_Purchase = Convert.ToInt32(dtSalePrice.Rows[0]["CurrencyID"].ToString());
                    ProductInfo.EffectiveDate_Sale = Convert.ToDateTime(dtSalePrice.Rows[0]["EffectiveDate"]);
                    ProductInfo.ImplementDate_Sale = DataUtil.Convert<DateTime>(dtSalePrice.Rows[0]["ImplementDate"]);
                    ProductInfo.Incoterm_Sale = dtSalePrice.Rows[0]["Incoterm"].ToString();
                    ProductInfo.HSCode = dtSalePrice.Rows[0]["HSCode"].ToString();
                    ProductInfo.Remark_Sale = dtSalePrice.Rows[0]["Remark"].ToString();
                }
                else
                {

                    ProductInfo.EffectiveDate_Sale = DateTime.Now;
                    ProductInfo.ImplementDate_Sale = DateTime.Now;
                }

                if (dtPurchasePrice.Rows.Count > 0)
                {
                    //Purchase
                    ProductInfo.CurrencyID_Sale = Convert.ToInt32(dtPurchasePrice.Rows[0]["CurrencyID"].ToString());
                    ProductInfo.PurchasePrice = DataUtil.Convert<decimal>(dtPurchasePrice.Rows[0]["PurchasePrice"].ToString());
                    ProductInfo.EffectiveDate_Purchase = Convert.ToDateTime(dtPurchasePrice.Rows[0]["EffectiveDate"]);
                    ProductInfo.ImplementDate_Purchase = DataUtil.Convert<DateTime>(dtPurchasePrice.Rows[0]["ImplementDate"]);
                    ProductInfo.Incoterm_Purchase = dtPurchasePrice.Rows[0]["Incoterm"].ToString();
                    ProductInfo.Remark_Purchase = dtPurchasePrice.Rows[0]["Remark"].ToString();
                }
                else
                {
                    ProductInfo.EffectiveDate_Purchase = DateTime.Now;
                    ProductInfo.ImplementDate_Purchase = DateTime.Now;
                }

                this.dtTransitZone = dtTransitZone;
                this.dtCargoType = dtCargo;

                grdTransitZone.DataSource = dtTransitZone;
                grdCargoType.DataSource = dtCargo;

                if (dtPackingMaterial.Rows.Count != 0)
                {
                    grdMaterialPacking.DataSource = dtPackingMaterial;
                }

                if (DataUtil.Convert<int>(cboProductType.EditValue) == 1 && gdvTransitZone.RowCount >= 1)
                {
                    ControlUtil.EnableControl(false, btnAddLocation, cboWarehouse, cboZone, cboLocation, cboItemCondition);
                }

                CalGrossWeight();
                ControlUtil.SetBestWidth(gdvCargoType);

            }

            //productStc.TransitXML = null;
            //productStc.CargoXML = null;
            //productStc.PackingXML = null;

        }

        private void InitControl()
        {            
            ownerControl.ClearData();
            itemClassificationControl.ClearData();
            itemGroupControl.ClearData();
            ItemCategoryControl.ClearData();
            InitGrid();          
            if (ScreenMode == Common.eScreenMode.Add)
            {
                m_statusBarCreatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = AppConfig.UserLogin;
                m_statusBarUpdatedDate.Caption = "-";
                m_statusBarUpdatedUser.Caption = "-";

                // set default to itemClassification to Solid or SL, If have not SL so set to blank
                // If screen not show SL or Solid need to check in database and map ID to solid class
                itemClassificationControl.ClassificationID = 3;
            }
            else
            {
                //m_statusBarCreatedDate.Caption = this.Product.CreateDate.ToString(Common.FullDatetimeFormat);
                //m_statusBarCreatedUser.Caption = this.Product.CreateUser;
                //if (this.Product.UpdateDate != null)
                //{
                //    m_statusBarUpdatedDate.Caption = Convert.ToDateTime(this.Product.UpdateDate).ToString(Common.FullDatetimeFormat);
                //    m_statusBarUpdatedUser.Caption = this.Product.CreateUser;
                //}
                //else if (this.Product.UpdateDate == null && ScreenMode == Common.eScreenMode.Edit)
                //{
                //    m_statusBarUpdatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                //    m_statusBarUpdatedUser.Caption = AppConfig.UserLogin;
                //}
            }
           
            this.pictureBox1.Image = null;
            this.pictureBox2.Image = null;
        }

        private void InitCombobox()
        {
            cboItemCondition.Properties.DataSource = ProductConditionCommonBusiness.DataLoading();
            cboItemCondition.Properties.DisplayMember = "DisplayMember";
            cboItemCondition.Properties.ValueMember = "ProductConditionID";

            repPackaging.DataSource = Packaging.DataLoading();
            repPackaging.DisplayMember = "PackageName";
            repPackaging.ValueMember = "PackageID";

            repTypeOfUnit.DataSource = UnitType.DataLoading(null, null);
            repTypeOfUnit.DisplayMember = "UnitName";
            repTypeOfUnit.ValueMember = "UnitID";

            repPallet.DataSource = Pallet.DataLoading(null, null);
            repPallet.DisplayMember = "PalletCode";
            repPallet.ValueMember = "PalletID";

            DataSet ds = BusinessClass.LoadComboBoxData();

            cboProductType.Properties.DataSource = ds.Tables[0];
            cboProductType.Properties.ValueMember = "ProductTypeID";
            cboProductType.Properties.DisplayMember = "ProductTypeName";

            cboTypeOfPallet.Properties.DataSource = ds.Tables[1];
            cboTypeOfPallet.Properties.ValueMember = "PalletTypeID";
            cboTypeOfPallet.Properties.DisplayMember = "PalletTypeName";


        }

        private void InitGrid()
        {
            dtTransitZone.Columns.Clear();
            dtTransitZone.Rows.Clear();
            dtCargoType.Columns.Clear();
            dtCargoType.Rows.Clear();

            //dtTransitZone.Columns.Add(eTransitZone.ProductID.ToString(), typeof(int));
            dtTransitZone.Columns.Add(eTransitZone.ProductConditionID.ToString(), typeof(int));
            dtTransitZone.Columns.Add(eTransitZone.ZoneID.ToString(), typeof(int));
            dtTransitZone.Columns.Add(eTransitZone.LocationID.ToString(), typeof(int));
            dtTransitZone.Columns.Add(eTransitZone.ProductConditionDisplayName.ToString(), typeof(string));
            dtTransitZone.Columns.Add(eTransitZone.ZoneDisplayName.ToString(), typeof(string));
            dtTransitZone.Columns.Add(eTransitZone.LocationDisplayName.ToString(), typeof(string));
            dtTransitZone.Columns.Add(eTransitZone.WarehouseDisplayName.ToString(), typeof(string));
            grdTransitZone.DataSource = dtTransitZone;
                        
            dtCargoType.Columns.Add(eCargoType.ProductID.ToString(), typeof(int));
            dtCargoType.Columns.Add(eCargoType.CargoType.ToString(), typeof(string));
            dtCargoType.Columns.Add(eCargoType.PackageID.ToString(), typeof(int));
            dtCargoType.Columns.Add(eCargoType.PalletID.ToString(), typeof(int));
            dtCargoType.Columns.Add(eCargoType.L1Vol.ToString(), typeof(decimal));
            dtCargoType.Columns.Add(eCargoType.L1Unit.ToString(), typeof(int));
            dtCargoType.Columns.Add(eCargoType.rptTypeOfUnitLevel1.ToString(), typeof(Boolean));
            dtCargoType.Columns.Add(eCargoType.L2Number.ToString(), typeof(decimal));
            dtCargoType.Columns.Add(eCargoType.L2Unit.ToString(), typeof(int));
            dtCargoType.Columns.Add(eCargoType.rptTypeOfUnitLevel2.ToString(), typeof(Boolean));
            dtCargoType.Columns.Add(eCargoType.L3Number.ToString(), typeof(int));
            dtCargoType.Columns.Add(eCargoType.L3Unit.ToString(), typeof(int));
            dtCargoType.Columns.Add(eCargoType.rptTypeOfUnitLevel3.ToString(), typeof(Boolean));
            dtCargoType.Columns.Add(eCargoType.L4Number.ToString(), typeof(decimal));
            dtCargoType.Columns.Add(eCargoType.L4Unit.ToString(), typeof(int));
            dtCargoType.Columns.Add(eCargoType.rptTypeOfUnitLevel4.ToString(), typeof(Boolean));
            dtCargoType.Columns.Add(eCargoType.InventoryRecord.ToString(), typeof(int));
            dtCargoType.Columns.Add(eCargoType.NetWeight.ToString(), typeof(decimal));
            dtCargoType.Columns.Add(eCargoType.GrossWeight.ToString(), typeof(decimal));
            dtCargoType.Columns.Add(eCargoType.PalletWeightLimit.ToString(), typeof(decimal));

            DataRow dr = dtCargoType.NewRow();

            if (DataUtil.Convert<int>(cboProductType.EditValue) == 1)
            {
                dr[eCargoType.CargoType.ToString()] = "Purchase";
                dr[eCargoType.L1Vol.ToString()] = 1;
                dr[eCargoType.L1Unit.ToString()] = 40;
                dr[eCargoType.L4Unit.ToString()] = 1;
                dr[eCargoType.InventoryRecord.ToString()] = 1;
                dtCargoType.Rows.Add(dr);

                dr = dtCargoType.NewRow();
                dr[eCargoType.CargoType.ToString()] = "Sale";
                dr[eCargoType.L1Vol.ToString()] = 1;
                dr[eCargoType.L1Unit.ToString()] = 40;
                dr[eCargoType.L4Unit.ToString()] = 1;
                dr[eCargoType.InventoryRecord.ToString()] = 1;
                dtCargoType.Rows.Add(dr);

            }
            else if (DataUtil.Convert<int>(cboProductType.EditValue) == 2)
            {
                dr[eCargoType.CargoType.ToString()] = "Purchase";
                dr[eCargoType.L1Vol.ToString()] = 1;
                dr[eCargoType.L1Unit.ToString()] = 41;
                dr[eCargoType.L4Unit.ToString()] = 1;
                dr[eCargoType.InventoryRecord.ToString()] = 1;
                dtCargoType.Rows.Add(dr);

                dr = dtCargoType.NewRow();
                dr[eCargoType.CargoType.ToString()] = "Sale";
                dr[eCargoType.L1Vol.ToString()] = 1;
                dr[eCargoType.L1Unit.ToString()] = 41;
                dr[eCargoType.L4Unit.ToString()] = 1;
                dr[eCargoType.InventoryRecord.ToString()] = 1;
                dtCargoType.Rows.Add(dr);
            }
            else
            {
                dr[eCargoType.CargoType.ToString()] = "Purchase";
                dr[eCargoType.L1Vol.ToString()] = 1;
                dr[eCargoType.L1Unit.ToString()] = 30;
                dr[eCargoType.L4Unit.ToString()] = 1;
                dr[eCargoType.InventoryRecord.ToString()] = 1;
                dtCargoType.Rows.Add(dr);

                dr = dtCargoType.NewRow();
                dr[eCargoType.CargoType.ToString()] = "Sale";
                dr[eCargoType.L1Vol.ToString()] = 1;
                dr[eCargoType.L1Unit.ToString()] = 30;
                dr[eCargoType.L4Unit.ToString()] = 1;
                dr[eCargoType.InventoryRecord.ToString()] = 1;
                dtCargoType.Rows.Add(dr);
            }
            
            

            dtCargoType.AcceptChanges();
            grdCargoType.DataSource = dtCargoType;

        }

        public void ClearData()
        {
            errorProvider.ClearErrors();
        }

        private void OpenDialog(Common.eScreenMode ScreenMode)
        {
            try
            {

                Dialog.ScreenMode = ScreenMode;
                ProductInfo.SupplierID = supplierControl.SupplierID;
                ProductInfo.OwnerID = ownerControl.OwnerID;
                Dialog.ProductInfo = ProductInfo;
                
                if (Dialog.ShowDialog(this) == DialogResult.OK)
                {
                    MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), "Sale Price and Purchase Price"));
                }
                Dialog = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void CalGrossWeight()
        {
            gdvMaterialPacking.PostEditor();
            DataTable dt = grdMaterialPacking.DataSource as DataTable;
            if (dt.Columns["GrossNetWeight"] == null)
            {
                dt.Columns.Add("GrossNetWeight", typeof(decimal));
            }
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToBoolean(dr["IsPallet"]) == false
                    && dr["Usage"] != DBNull.Value
                    && dr["Weight"] != DBNull.Value)
                {
                    dr["GrossNetWeight"] = Convert.ToDecimal(dr["Usage"]) * Convert.ToDecimal(dr["Weight"]);
                }
                else
                {
                    dr["GrossNetWeight"] = 0;
                }
            }
            
            decimal? result = DataUtil.Convert<decimal>(dt.Compute("SUM(GrossNetWeight)", ""));

            decimal Number3;
            decimal Number4;

            if (Util.IsNullOrEmpty(gdvCargoType.GetRowCellValue(1, gdcL3Number)))
            {
                Number3 = 1;
            }
            else
            {
                Number3 = Convert.ToDecimal(gdvCargoType.GetRowCellValue(1, gdcL3Number));
            }

            if (Util.IsNullOrEmpty(gdvCargoType.GetRowCellValue(1, gdcL4Number)))
            {
                Number4 = 1;
            }
            else
            {
                Number4 = Convert.ToDecimal(gdvCargoType.GetRowCellValue(1, gdcL4Number));
            }

            //gdvCargoType.SetRowCellValue(0, gdcNetWeight, Number3 * Number4);
            gdvCargoType.SetRowCellValue(0, gdcGrossWeight, 0);

            //gdvCargoType.SetRowCellValue(1, gdcNetWeight, Number3 * Number4);
            gdvCargoType.SetRowCellValue(1, gdcGrossWeight, ((Number3 * Number4) + (result ?? 0)));            
        }

        #endregion                   


    }
}

/*
 * 12 Feb 2013: 
 * 1. show wait screen when search
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
namespace Rubix.Screen.Form.Operation.E_Stocktaking
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Export)]
    public partial class frmESTS030_InquiryInventory : FormBase
    {
        #region Member
        private InquiryInventory db;
        #endregion

        #region Enumeration
        private enum eColumn
        {
            OwnerID,
            WarehouseID,
            //WarehouseCode,
            Warehouse,
            Location,
            ProductConditionID,
            ProductID,
            //ProductCode,
            //ProductName,
            //ConditionOfProduct,
            ItemCode,
            ItemName,
            ItemCondition,
           
            LotNo,
            //PalletNoRef,
            //PalletNo,
            Inventory,
            LastMovement
        }
        private enum eColInventory
        {
            TypeName,
            Transit,
            StockActual,
            StockHold,
            Available,
            Shipping,
            Total
        }

        private enum eColumnItem
        {
            OwnerID,
            WarehouseID,
            Warehouse,
            ProductConditionID,
            ProductID,
            ItemCode,
            ItemName,
            ItemCondition,
            LotNo,
            Inventory,
            UOM,
            LastMovement
        }
        #endregion

        #region Properties
        private InquiryInventory BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new InquiryInventory();
                }
                return db;
            }
        }
        #endregion

        #region Constructor
        public frmESTS030_InquiryInventory()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarAdd, m_toolBarEdit, m_toolBarDelete, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
            base.GridControlSearchResult = new GridControl[] { grdSearchResult, grdInventoryStatus };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl3);
            grcTransit.DisplayFormat.FormatString = Common.QtyFormat;
            grcTransit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            grcTransit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            grcStockActual.DisplayFormat.FormatString = Common.QtyFormat;
            grcStockActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            grcStockActual.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            grcStockHold.DisplayFormat.FormatString = Common.QtyFormat;
            grcStockHold.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            grcStockHold.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            grcAvailable.DisplayFormat.FormatString = Common.QtyFormat;
            grcAvailable.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            grcAvailable.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            grcShipping.DisplayFormat.FormatString = Common.QtyFormat;
            grcShipping.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            grcShipping.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            grcTotal.DisplayFormat.FormatString = Common.QtyFormat;
            grcTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            grcTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            gdcInventory.DisplayFormat.FormatString = Common.QtyFormat;
            gdcInventory.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gdcInventory.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            ControlUtil.SetBestWidth(gdvInventoryStatus);
        }
        #endregion

        #region Event Handler Function
        private void frmESTS030_InquiryInventory_Load(object sender, EventArgs e)
        {
            try
            {
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                zoneControl.WarehouseID = Common.GetDefaultWarehouseID();
                itemControl.OwnerID = Common.GetDefaultOwnerID();
                locationControl.ZoneID = -1;
                
                warehouseControl.DataLoading();
                zoneControl.DataLoading();
                itemControl.DataLoading();
                locationControl.DataLoading();

                InitInventoryStatus();
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
        
        private void gdvSearchResult_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if ((grdInventoryStatus.DefaultView).DataRowCount > 0)
                {
                    setInventoryStatus();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void rdbItem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbItem.Checked)
                {
                    rdbLocation.Checked = false;
                    locationControl.ZoneID = -1;
                    locationControl.DataLoading();
                    ControlUtil.EnableControl(false, locationControl);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void rdbLocation_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbLocation.Checked)
                {
                    rdbItem.Checked = false;
                    locationControl.ZoneID = -1;
                    locationControl.DataLoading();
                    ControlUtil.EnableControl(true, locationControl);
                }
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
                if(ownerControl.OwnerID != null)
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

        private void warehouseControl_EditValueChanged(object sender, EventArgs e)
        {
             try
            {
                ShowWaitScreen();
                if (ownerControl.OwnerID != null)
                {
                    zoneControl.WarehouseID = warehouseControl.WarehouseID;
                    zoneControl.DataLoading();
                }
                else
                {
                    zoneControl.WarehouseID = Common.GetDefaultWarehouseID();
                    zoneControl.DataLoading();
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void zoneControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (zoneControl.ZoneID != null)
                {
                    locationControl.ZoneID = zoneControl.ZoneID;
                    locationControl.DataLoading();
                }
                else
                {
                    locationControl.ZoneID = -1;
                    locationControl.DataLoading();
                }
                CloseWaitScreen();
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
                grdSearchResult.DataSource = null;

                if (rdbLocation.Checked)
                {
                    grdSearchResult.DataSource = BusinessClass.DataLoading(ownerControl.OwnerID
                                                                           , warehouseControl.WarehouseID
                                                                           , zoneControl.ZoneID
                                                                           , itemControl.ProductID
                                                                           , itemConditionControl.ProductConditionID
                                                                           , locationControl.LocationID);
                }
                else if (rdbItem.Checked)
                {
                    grdSearchResult.DataSource = BusinessClass.DataLoadingByItem(ownerControl.OwnerID
                                                                                , warehouseControl.WarehouseID
                                                                                , zoneControl.ZoneID
                                                                                , itemControl.ProductID
                                                                                , itemConditionControl.ProductConditionID);
                }

                setInventoryStatus();
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

        private void InitInventoryStatus()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(eColInventory.TypeName.ToString(), Type.GetType("System.String"));
            dt.Columns.Add(eColInventory.Transit.ToString(), Type.GetType("System.Double"));
            dt.Columns.Add(eColInventory.StockActual.ToString(), Type.GetType("System.Double"));
            dt.Columns.Add(eColInventory.StockHold.ToString(), Type.GetType("System.Double"));
            dt.Columns.Add(eColInventory.Available.ToString(), Type.GetType("System.Double"));
            dt.Columns.Add(eColInventory.Shipping.ToString(), Type.GetType("System.Double"));
            dt.Columns.Add(eColInventory.Total.ToString(), Type.GetType("System.Double"));

            dr = dt.NewRow();
            dr[eColInventory.TypeName.ToString()] = "Qty (Packing Sale)";
            dr[eColInventory.Transit.ToString()] = 0.0;
            dr[eColInventory.StockActual.ToString()] = 0.0;
            dr[eColInventory.StockHold.ToString()] = 0.0;
            dr[eColInventory.Available.ToString()] = 0.0;
            dr[eColInventory.Shipping.ToString()] = 0.0;
            dr[eColInventory.Total.ToString()] = 0.0;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[eColInventory.TypeName.ToString()] = "Weight(Kg.)";
            dr[eColInventory.Transit.ToString()] = 0.0;
            dr[eColInventory.StockActual.ToString()] = 0.0;
            dr[eColInventory.StockHold.ToString()] = 0.0;
            dr[eColInventory.Available.ToString()] = 0.0;
            dr[eColInventory.Shipping.ToString()] = 0.0;
            dr[eColInventory.Total.ToString()] = 0.0;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[eColInventory.TypeName.ToString()] = "Measurment(M3)";
            dr[eColInventory.Transit.ToString()] = 0.0;
            dr[eColInventory.StockActual.ToString()] = 0.0;
            dr[eColInventory.StockHold.ToString()] = 0.0;
            dr[eColInventory.Available.ToString()] = 0.0;
            dr[eColInventory.Shipping.ToString()] = 0.0;
            dr[eColInventory.Total.ToString()] = 0.0;
            dt.Rows.Add(dr);

            grcType.FieldName = eColInventory.TypeName.ToString();
            grcTransit.FieldName = eColInventory.Transit.ToString();
            grcStockActual.FieldName = eColInventory.StockActual.ToString();
            grcAvailable.FieldName = eColInventory.Available.ToString();
            grcStockHold.FieldName = eColInventory.StockHold.ToString();
            grcShipping.FieldName = eColInventory.Shipping.ToString();
            grcTotal.FieldName = eColInventory.Total.ToString();

            if (grdInventoryStatus.DataSource != null)
            {
                grdInventoryStatus.DataSource = null;
            }
            grdInventoryStatus.DataSource = dt;
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

        private void ClearAll()
        {
            locationControl.ClearData();
            ownerControl.ClearData();
            warehouseControl.ClearData();
            itemControl.ClearData();
            itemConditionControl.ClearData();

            grdSearchResult.DataSource = null;

            ClearInventoryStatus();

            warehouseControl.OwnerID = null;
            warehouseControl.DataLoading();
            itemControl.OwnerID = null;
            itemControl.DataLoading();
        }

        private void ClearInventoryStatus()
        {
            DataTable dt = (DataTable)grdInventoryStatus.DataSource;
            foreach (DataRow dr in dt.Rows)
            {
                dr[eColInventory.Transit.ToString()] = 0.0;
                dr[eColInventory.StockActual.ToString()] = 0.0;
                dr[eColInventory.StockHold.ToString()] = 0.0;
                dr[eColInventory.Shipping.ToString()] = 0.0;
                dr[eColInventory.Total.ToString()] = 0.0;
            }
        }

        private sp_ESTS000_InventoryStatusProcess_Result GetInventoryStatus(int? iCustomerID, int? iWarehouseID, int? iProductID, int? iProductConditionID, string productCode)
        {
            return BusinessClass.GetInventoryStatus(iCustomerID, iWarehouseID, iProductID, iProductConditionID, productCode);
        }

        private void setInventoryStatus()
        {
            if (gdvSearchResult.GetFocusedRow() == null)
            {
                InitInventoryStatus();
                return;
            }
            BusinessClass.SelectData = gdvSearchResult.GetFocusedRow();
            int? iOwnerID = BusinessClass.OwnerID;
            int? iWarehouseID = BusinessClass.WarehouseID;
            int? iProductID = BusinessClass.ProductID < 0 ? null : DataUtil.Convert<int>(BusinessClass.ProductID);
            int? iProductConditionID = BusinessClass.ProductConditionID;
            string ProductCode = BusinessClass.ProductCode;

            this.ShowWaitScreen();

            sp_ESTS000_InventoryStatusProcess_Result InventoryStatus = GetInventoryStatus(iOwnerID, iWarehouseID, iProductID, iProductConditionID, ProductCode);
            
            DataTable dt = (DataTable)grdInventoryStatus.DataSource;

            foreach (DataRow dr in dt.Rows)
            {
                if (dr[eColInventory.TypeName.ToString()].ToString().Equals("Qty (Packing Sale)"))
                {
                    dr[eColInventory.Transit.ToString()] = InventoryStatus.TransitQuantity;
                    dr[eColInventory.StockActual.ToString()] = InventoryStatus.StockActualQuantity;
                    dr[eColInventory.StockHold.ToString()] = InventoryStatus.StockHoldQuantity;
                    dr[eColInventory.Available.ToString()] = InventoryStatus.AvailableQuantity;
                    dr[eColInventory.Shipping.ToString()] = InventoryStatus.ShippingQuantity;
                    dr[eColInventory.Total.ToString()] = InventoryStatus.TotalQuantity;
                }
                else if (dr[eColInventory.TypeName.ToString()].ToString().Equals("Weight(Kg.)"))
                {
                    dr[eColInventory.Transit.ToString()] = InventoryStatus.TransitWeight;
                    dr[eColInventory.StockActual.ToString()] = InventoryStatus.StockActualWeight;
                    dr[eColInventory.StockHold.ToString()] = InventoryStatus.StockHoldWeight;
                    dr[eColInventory.Available.ToString()] = InventoryStatus.AvailableWeight;
                    dr[eColInventory.Shipping.ToString()] = InventoryStatus.ShippingWeight;
                    dr[eColInventory.Total.ToString()] = InventoryStatus.TotalWeight;
                }
                else if (dr[eColInventory.TypeName.ToString()].ToString().Equals("Measurment(M3)"))
                {
                    dr[eColInventory.Transit.ToString()] = InventoryStatus.TransitM3;
                    dr[eColInventory.StockActual.ToString()] = InventoryStatus.StockActualM3;
                    dr[eColInventory.StockHold.ToString()] = InventoryStatus.StockHoldM3;
                    dr[eColInventory.Available.ToString()] = InventoryStatus.AvailableActualM3;
                    dr[eColInventory.Shipping.ToString()] = InventoryStatus.ShippingM3;
                    dr[eColInventory.Total.ToString()] = InventoryStatus.TotalM3;
                }
                

            }

            grdInventoryStatus.DataSource = null;
            grdInventoryStatus.DataSource = dt;
            this.CloseWaitScreen();
        }
        #endregion
    }
}
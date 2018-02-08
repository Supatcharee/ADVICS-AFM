/*
 * 23 Jan 2013: 
 * 1. add new function "GetSpecificStatusId"
 * 30 Jan 2013
 * 1. add validate transaction date
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Transactions;
using Rubix.Framework;
using System.Collections;
using System.Data;

namespace CSI.Business.Operation
{
    public class ConfirmShippingEntry
    {
        #region Member
        private ObjectResult<sp_ISHS030_ConfirmShipService_GetConfirmShip_Result> lt_Result = null;
        private sp_ISHS030_ConfirmShipService_GetConfirmShip_Result ta_Result = null;
        private BusinessCommon ims = null;
        #endregion

        #region Properties
        private BusinessCommon Database
        {
            get
            {
                if (ims == null)
                {
                    ims = new BusinessCommon();
                }
                return ims;
            }
        }

        private ObjectResult<sp_ISHS030_ConfirmShipService_GetConfirmShip_Result> ResultList
        {
            get { return lt_Result; }
            set { lt_Result = value; }
        }
        #endregion

        public int GetAllowShippingStatus()
        {
            try
            {
                return 11;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public ObjectResult<sp_ISHS030_ConfirmShipService_GetConfirmShip_Result> DataLoading(int? OwnerID, int? WarehouseID, String ShipmentNo, String PickingNo, 
                                                                                             int? ShipmentArea, DateTime? pickDateFrom, DateTime? pickDateTo
                                                                                             , int? CustomerID, DateTime? deliveryDateFrom, DateTime? deliveryDateTo, int ShippingComplete, String InvoiceNo)
        {
            try
            {
                ResultList = Database.ShippingEntity.sp_ISHS030_ConfirmShipService_GetConfirmShip(ownerID: OwnerID
                                                                                                 ,warehouseID: WarehouseID
                                                                                                 , shipmentNo: (ShipmentNo == String.Empty ? null : ShipmentNo)
                                                                                                 ,pickingNo: (PickingNo == String.Empty ? null : PickingNo)
                                                                                                 ,shippingAreaID: ShipmentArea
                                                                                                 ,pickDateFrom: pickDateFrom
                                                                                                 ,pickDateTo: pickDateTo
                                                                                                 ,customerID: CustomerID
                                                                                                 ,deliveryDateFrom: deliveryDateFrom
                                                                                                 ,deliveryDateTo: deliveryDateTo
                                                                                                 ,shippingComplete: ShippingComplete
                                                                                                 ,invoiceNo: InvoiceNo);
                return ResultList;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public int? CheckWorkMethod(int? OwnerID, int? WarehouseID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                Hashtable hsOut = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hsOut.Add("result", "");
                Database.ExecuteNonQuery("sp_ISHS030_ConfirmShipService_CheckWorkMethod", hs, ref hsOut);
                return Convert.ToInt16(hsOut["result"]);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        public bool Save(List<sp_ISHS030_ConfirmShipService_GetConfirmShip_Result> list
                        , int? customerId, int? warehouseId, int? installment, int? palletQty, string UserLogin)
        {

            try
            {
                foreach (sp_ISHS030_ConfirmShipService_GetConfirmShip_Result data in list)
                {
                    Hashtable hs = new Hashtable();
                    hs.Add("OwnerID", customerId);
                    hs.Add("WarehouseID", warehouseId);
                    hs.Add("shipmentNo", data.ShipmentNo);
                    hs.Add("installment", installment);
                    hs.Add("pickingNo", data.PickingNo);
                    hs.Add("lineNo", data.LineNo);
                    hs.Add("productId", data.ProductID);
                    hs.Add("productConditionId", data.ProductConditionID);
                    hs.Add("UnitOfOrderQty", data.UnitOfOrderQty);
                    hs.Add("actualQty", data.ShipQty);
                    hs.Add("user", UserLogin);
                    hs.Add("PalletQty", palletQty);

                    Database.ExecuteNonQuery("sp_ISHS030_ConfirmShipService_Save", hs);


                }
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        public DataTable GetDataExportToAccpect(int? OwnerID
                                                , int? WarehouseID
                                                , String ShipmentNo
                                                , String PickingNo
                                                , int? ShipmentArea
                                                , DateTime? pickDateFrom
                                                , DateTime? pickDateTo
                                                , int? CustomerID
                                                , DateTime? deliveryDateFrom
                                                , DateTime? deliveryDateTo
                                                , int ShippingComplete
                                                , string DisplayTypeXML)
        {

            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("PickingNo", PickingNo);
                hs.Add("ShipmentArea", ShipmentArea);
                hs.Add("pickDateFrom", pickDateFrom);
                hs.Add("pickDateTo", pickDateTo);
                hs.Add("CustomerID", CustomerID);
                hs.Add("deliveryDateFrom", deliveryDateFrom);
                hs.Add("deliveryDateTo", deliveryDateTo);
                hs.Add("ShippingComplete", ShippingComplete);
                hs.Add("DisplayTypeXML", DisplayTypeXML);

                return Database.ExecuteDataSet("sp_ISHS030_ConfirmShipService_ExportToAccpect", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Transactions;
using Rubix.Framework;
using System.Collections;
using Newtonsoft.Json;
using System.Data;

namespace CSI.Business.Operation
{
    public class ConfirmShippingEntry
    {
        public int GetAllowShippingStatus()
        {
            return 11;
        }  
 
        public List<sp_ISHS030_ConfirmShipService_GetConfirmShip_Result> DataLoading(   int? OwnerID, 
                                                                                        int? WarehouseID,
                                                                                        String ShipmentNo, 
                                                                                        String PickingNo, 
                                                                                        int? ShipmentArea, 
                                                                                        DateTime? pickDateFrom, 
                                                                                        DateTime? pickDateTo, 
                                                                                        int? CustomerID, 
                                                                                        DateTime? deliveryDateFrom, 
                                                                                        DateTime? deliveryDateTo,
                                                                                        int ShippingComplete,
                                                                                        String InvoiceNo)
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
            hs.Add("InvoiceNo", InvoiceNo);


            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmShippingEntry/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_ISHS030_ConfirmShipService_GetConfirmShip_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ValidateActualQty(sp_ISHS030_ConfirmShipService_GetConfirmShip_Result data, out string messageId)
        {
            messageId = string.Empty;
            if (data.PickQty3 < data.ShipQty)
            {
                messageId = "I0083"; // [Qty Actual] must be equal [Qty]
            }
        }

        public bool CheckWorkMethod(int? OwnerID, int? WarehouseID, out string messageId)
        {
            messageId = string.Empty;

            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmShippingEntry/CheckWorkMethod", hs);
                int? result = JsonConvert.DeserializeObject<int?>(strResult);

                if (result == null || Convert.ToInt32(result.Value) == 0)
                {
                    messageId = "I0084";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public bool Save(List<sp_ISHS030_ConfirmShipService_GetConfirmShip_Result> list, int? customerId, int? warehouseId, int? installment, out string messageId, int? palletQty)
        {
            messageId = string.Empty;

            if (ValidateBeforeSave(list) == false)
            {
                messageId = "I0085";  // no row selected
                return false;
            }

            messageId = "I0086";
            Hashtable hs = new Hashtable();
            hs.Add("customerId", customerId);
            hs.Add("warehouseId", warehouseId);
            hs.Add("installment", installment);
            hs.Add("palletQty", palletQty);
            hs.Add("user", Rubix.Framework.AppConfig.UserLogin);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmShippingEntry/Save", hs, JsonConvert.SerializeObject(list));
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidateBeforeSave(List<sp_ISHS030_ConfirmShipService_GetConfirmShip_Result> list)
        {
            return list.Count != 0;
        }

        public List<int?> GetSpecificStatusId()
        {
            List<int?> ListStatus = new List<int?>();
            ListStatus.AddRange(new int?[] { 
                Common.Status.DocumentShippingIssued
            });

            return ListStatus;
        }
        public List<int?> GetSpecificStatusIdForShippingComplete()
        {
            List<int?> ListStatus = new List<int?>();
            ListStatus.AddRange(new int?[] { 
                Common.Status.CompleteShipping
            });

            return ListStatus;
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

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmShippingEntry/GetDataExportToAccpect", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}

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

namespace CSI.Business.Operation
{
    public class OrderRefresh
    {
        #region Receiving
        public List<sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result> DataLoadReceiving(int? OwnerID, int? WarehouseID, string ReceivingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ReceivingNo", ReceivingNo);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("OrderRefresh/DataLoadReceiving", hs);
                return JsonConvert.DeserializeObject<List<sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveDataReceiving(List<sp_ROMS010_OrderRefresh_SearchAll_Receiving_Result> data)
        {
            try
            {
                RubixWebAPI.ExecuteObjectResult("OrderRefresh/SaveDataReceiving", JsonConvert.SerializeObject(data));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Shipping
        public List<sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result> DataLoadShipping(int? OwnerID,  int? WarehouseID, string ShipmentNo,  string PickingNo, int? CustomerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("CustomerID", CustomerID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("OrderRefresh/DataLoadShipping", hs);
                return JsonConvert.DeserializeObject<List<sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String SaveDataShipping(List<sp_ROMS010_OrderRefresh_SearchAll_Shipping_Result> data)
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("OrderRefresh/SaveDataShipping", JsonConvert.SerializeObject(data));
                return JsonConvert.DeserializeObject<string>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}

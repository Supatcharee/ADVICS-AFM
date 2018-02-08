/*
 * 23 Jan 2013: 
 * 1. add new function "GetSpecificStatusId"
 * 30 Jan 2013: 
 * 1. add validate number of row
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using System.Transactions;
using Rubix.Framework;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.Operation
{
    public class PrintPCIDriver : CSI.Business.BusinessFactory.Report.Base.BaseReport
    {
        #region Member
        private List<sp_ISHS060_PrintDeliveryOrder_SearchAll_Result> shippingList;
        #endregion
                
        #region Properties
        public string ShipmentNo { get; set; }
        #endregion

        public List<sp_ISHS060_PrintDeliveryOrder_SearchAll_Result> DataLoading(int? OwnerID, 
                                                                                int? WarehouseID, 
                                                                                String ShipmentNo, 
                                                                                String PickingNo, 
                                                                                DateTime? pickDateFrom, 
                                                                                DateTime? pickDateTo, 
                                                                                int? CustomerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("pickDateFrom", pickDateFrom);
            hs.Add("pickDateTo", pickDateTo);
            hs.Add("CustomerID", CustomerID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PrintPCIDriver/DataLoading", hs);
                shippingList = JsonConvert.DeserializeObject<List<sp_ISHS060_PrintDeliveryOrder_SearchAll_Result>>(strResult);
                return shippingList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean EntryDeliveryOrder(sp_ISHS060_PrintDeliveryOrder_SearchAll_Result data)
        {
            Hashtable hs = new Hashtable();
            hs.Add("UserLogin", AppConfig.UserLogin);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PrintPCIDriver/EntryDeliveryOrder", hs, JsonConvert.SerializeObject(data));
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable GetAttachList(string shipmentNo, string pickingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("shipmentNo", shipmentNo);
            hs.Add("pickingNo", pickingNo);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PrintPCIDriver/GetAttachList", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<int?> GetSpecificStatusId()
        {
            List<int?> ListStatus = new List<int?>();
            ListStatus.AddRange(new int?[] { 
                                Common.Status.CompletePicking,
                                Common.Status.CompleteShipping,
                                Common.Status.DeliveryNoteIssued}
                               );

            return ListStatus;
        }

        public byte[] LoadCOAImage(int COA_ID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("COA_ID", COA_ID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmProductStoring/LoadCOAImage", hs);
                return JsonConvert.DeserializeObject<byte[]>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT020_ShipmentLabel_GetData_Result> PrintShipmentLabel(string shipmentNo, string pickingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("shipmentNo", shipmentNo);
            hs.Add("pickingNo", pickingNo);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PrintPCIDriver/PrintShipmentLabel", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT020_ShipmentLabel_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

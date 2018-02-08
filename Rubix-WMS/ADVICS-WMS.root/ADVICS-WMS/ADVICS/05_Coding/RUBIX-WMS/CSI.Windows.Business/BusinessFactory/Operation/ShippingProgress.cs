using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using System.Collections;
using Newtonsoft.Json;
namespace CSI.Business.Operation
{
    public class ShippingProgress
    {
        #region Constant
        const int ORDER_CANCEL_STATUS = 19;
        #endregion
    
        public List<sp_LWPS020_ShippingProgress_SearchAll_Result> DataLoading(Nullable<Int32> OwnerID
                                                                            , Nullable<Int32> warehouseID
                                                                            , Nullable<Int32> portOfDischargeID
                                                                            , Nullable<Int32> finalDestinationID
                                                                            , String shipmentNo
                                                                            , String pickingNo
                                                                            , Nullable<Int32> shippingAreaID
                                                                            , Nullable<DateTime> transportDate
                                                                            , Nullable<DateTime> pickingDate
                                                                            , Nullable<DateTime> shippingDate
                                                                            , Nullable<DateTime> fromETADate
                                                                            , Nullable<DateTime> toETADate
                                                                            , String invoiceNo
                                                                            , int? CustomerID)
        {

            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("warehouseID", warehouseID);
            hs.Add("portOfDischargeID", portOfDischargeID);
            hs.Add("finalDestinationID", finalDestinationID);
            hs.Add("shipmentNo", shipmentNo);
            hs.Add("pickingNo", pickingNo);
            hs.Add("shippingAreaID", shippingAreaID);
            hs.Add("transportDate", transportDate);
            hs.Add("pickingDate", pickingDate);
            hs.Add("shippingDate", shippingDate);
            hs.Add("fromETADate", fromETADate);
            hs.Add("toETADate", toETADate);
            hs.Add("invoiceNo", invoiceNo);
            hs.Add("CustomerID", CustomerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingProgress/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_LWPS020_ShippingProgress_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<sp_LWPS020_ShippingProgress_SearchTotal_Result> GetSummary(Nullable<Int32> OwnerID
                                                                            , Nullable<Int32> warehouseID
                                                                            , Nullable<Int32> portOfDischargeID
                                                                            , Nullable<Int32> finalDestinationID
                                                                            , String shipmentNo
                                                                            , String pickingNo
                                                                            , Nullable<Int32> shippingAreaID
                                                                            , Nullable<DateTime> transportDate
                                                                            , Nullable<DateTime> pickingDate
                                                                            , Nullable<DateTime> shippingDate
                                                                            , Nullable<DateTime> fromETADate
                                                                            , Nullable<DateTime> toETADate
                                                                            , String invoiceNo
                                                                            , int? CustomerID)
            
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("warehouseID", warehouseID);
            hs.Add("portOfDischargeID", portOfDischargeID);
            hs.Add("finalDestinationID", finalDestinationID);
            hs.Add("shipmentNo", shipmentNo);
            hs.Add("pickingNo", pickingNo);
            hs.Add("shippingAreaID", shippingAreaID);
            hs.Add("transportDate", transportDate);
            hs.Add("pickingDate", pickingDate);
            hs.Add("shippingDate", shippingDate);
            hs.Add("fromETADate", fromETADate);
            hs.Add("toETADate", toETADate);
            hs.Add("invoiceNo", invoiceNo);
            hs.Add("CustomerID", CustomerID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingProgress/GetSummary", hs);
                return JsonConvert.DeserializeObject<List<sp_LWPS020_ShippingProgress_SearchTotal_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

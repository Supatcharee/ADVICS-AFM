using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.Operation
{
    public class ReceivingShippingHist
    {
        public List<sp_ESTS050_InquiryReceivingShippingHistory_SearchAll_Result> DataLoading(int? OwnerID, 
                                                                                            int? WarehouseID, 
                                                                                            int? ProductID, 
                                                                                            int? ConditionOfProductID, 
                                                                                            DateTime DateFrom, 
                                                                                            DateTime DateTo, 
                                                                                            String Location)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ProductID", ProductID);
            hs.Add("ConditionOfProductID", ConditionOfProductID);
            hs.Add("DateFrom", DateFrom);
            hs.Add("DateTo", DateTo);
            hs.Add("Location", Location);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingShippingHist/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_ESTS050_InquiryReceivingShippingHistory_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


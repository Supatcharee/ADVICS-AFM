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
    public class StatManage
    {
        public List<sp_MSTS010_HistoryView_Search_Result> DataLoading(int? OwnerID, 
                                                                      int? WarehouseID, 
                                                                      DateTime? TransFrom, 
                                                                      DateTime? TransTo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("TransFrom", TransFrom);
            hs.Add("TransTo", TransTo);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("StatManage/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_MSTS010_HistoryView_Search_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_MSTS010_HistoryView_Summary_Search_Result> DataSummaryLoading(int? OwnerID, 
                                                                                     int? WarehouseID, 
                                                                                     DateTime? TransFrom, 
                                                                                     DateTime? TransTo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("TransFrom", TransFrom);
            hs.Add("TransTo", TransTo);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("StatManage/DataSummaryLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_MSTS010_HistoryView_Summary_Search_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

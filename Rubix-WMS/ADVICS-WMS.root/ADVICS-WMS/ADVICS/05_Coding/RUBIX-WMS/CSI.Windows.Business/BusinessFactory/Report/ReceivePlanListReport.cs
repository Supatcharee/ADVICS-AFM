using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.BusinessFactory.Report
{
    public class ReceivePlanListReport : Base.BaseReport
    {
        public List<sp_RPT029_ReceivePlanList_GetData_Result> GetDataReport(int? OwnerID, int? WarehouseID, DateTime? dateFrom, DateTime? dateTo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("dateFrom", dateFrom);
            hs.Add("dateTo", dateTo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivePlanListReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT029_ReceivePlanList_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT029_ReceivePlanList_SubReport_GetData_Result> GetDataSubReport(int? OwnerID, int? WarehouseID, DateTime? dateFrom, DateTime? dateTo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("dateFrom", dateFrom);
            hs.Add("dateTo", dateTo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivePlanListReport/GetDataSubReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT029_ReceivePlanList_SubReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

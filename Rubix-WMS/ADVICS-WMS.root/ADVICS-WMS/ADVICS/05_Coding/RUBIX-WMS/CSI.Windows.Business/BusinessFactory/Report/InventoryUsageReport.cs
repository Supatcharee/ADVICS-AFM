using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.BusinessFactory.Report
{
    public class InventoryUsageReport : Base.BaseReport
    {
        public List<sp_RPT025_InventoryUsageReport_GetData_Result> GetDataReport(int? WarehouseID,int? OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("OwnerID", OwnerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("InventoryUsageReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT025_InventoryUsageReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT026_InventoryUsageReport_Chart_GetData_Result> GetDataChartReport(int? WarehouseID,int? OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("OwnerID", OwnerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("InventoryUsageReport/GetDataChartReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT026_InventoryUsageReport_Chart_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<DateTime?> GetMaxDailyPostDate()
        //{
        //    try
        //    {
        //        string strResult = RubixWebAPI.ExecuteObjectResult("InventoryUsageReport/GetMaxDailyPostDate");
        //        return JsonConvert.DeserializeObject<List<DateTime?>>(strResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<sp_RPT025_InventoryUsageReport_GetData_Sub_Report_Result> GetSubReport(int? WarehouseID,int? OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("OwnerID", OwnerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("InventoryUsageReport/GetSubReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT025_InventoryUsageReport_GetData_Sub_Report_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.BusinessFactory.Report
{
    public class MovementReport : Base.BaseReport
    {
        public List<sp_RPT023_MovementReport_GetData_Result> GetDataReport(int? OwnerID, int? WarehouseID, int? productID, DateTime? dateFrom, DateTime? dateTo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("productID", productID);
            hs.Add("dateFrom", dateFrom);
            hs.Add("dateTo", dateTo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("MovementReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT023_MovementReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT023_MovementReport_SubReport_GetData_Result> GetDataSubReport(int? OwnerID, int? WarehouseID, int? productID, DateTime? dateFrom, DateTime? dateTo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("productID", productID);
            hs.Add("dateFrom", dateFrom);
            hs.Add("dateTo", dateTo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("MovementReport/GetDataSubReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT023_MovementReport_SubReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT024_MovementReport_Chart_Result> GetChartReport(int? OwnerID, int? WarehouseID, int? productID, DateTime? dateFrom, DateTime? dateTo, int isMonthly)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("productID", productID);
            hs.Add("dateFrom", dateFrom);
            hs.Add("dateTo", dateTo);
            hs.Add("isMonthly", isMonthly);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("MovementReport/GetChartReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT024_MovementReport_Chart_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.BusinessFactory.Report
{
    public class EstimatePriceReport : Base.BaseReport
    {
        public List<sp_RPT012_EstimatePriceReport_GetData_Result> GetDataEstimatePriceReport(int? OwnerID, int? WarehouseID, DateTime? fromDate, DateTime? toDate)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("fromDate", fromDate);
            hs.Add("toDate", toDate);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("EstimatePriceReport/GetDataEstimatePriceReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT012_EstimatePriceReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

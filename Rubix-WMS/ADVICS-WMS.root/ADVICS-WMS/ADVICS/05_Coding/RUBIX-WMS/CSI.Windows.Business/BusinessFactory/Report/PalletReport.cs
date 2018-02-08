using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.BusinessFactory.Report
{
    public class PalletReport : Base.BaseReport
    {
        public List<sp_RPT028_PalletReport_GetData_Result> GetDataReport(int? customerID, int? WarehouseID, int? productID, DateTime? dateFrom, DateTime? dateTo, int isMonthly)
        {
            Hashtable hs = new Hashtable();
            hs.Add("customerID", customerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("productID", productID);
            hs.Add("dateFrom", dateFrom);
            hs.Add("dateTo", dateTo);
            hs.Add("isMonthly", isMonthly);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PalletReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT028_PalletReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }
}

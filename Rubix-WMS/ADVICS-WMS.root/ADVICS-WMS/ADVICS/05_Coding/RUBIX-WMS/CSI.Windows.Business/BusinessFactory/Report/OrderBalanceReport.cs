using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Collections;
using Newtonsoft.Json;


namespace CSI.Business.BusinessFactory.Report
{
    public class OrderBalanceReport : Base.BaseReport
    {
        public List<sp_RPT032_OrderBalance_GetData_Result> GetDataReport(int? OwnerID, int? WarehouseID, DateTime? dateFrom, DateTime? dateTo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("dateFrom", dateFrom);
            hs.Add("dateTo", dateTo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("OrderBalanceReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT032_OrderBalance_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

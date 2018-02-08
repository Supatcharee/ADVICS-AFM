using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Collections;
using Newtonsoft.Json;


namespace CSI.Business.BusinessFactory.Report
{
    public class SlowMovementReport : Base.BaseReport
    {
        public List<sp_RPT031_SlowMovement_GetData_Result> GetDataReport(int? OwnerID, int? WarehouseID, DateTime Date, Int32 period1, Int32 period2, Int32 period3, Int32 period4)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("Date", Date);
            hs.Add("period1", period1);
            hs.Add("period2", period2);
            hs.Add("period3", period3);
            hs.Add("period4", period4);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("SlowMovementReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT031_SlowMovement_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

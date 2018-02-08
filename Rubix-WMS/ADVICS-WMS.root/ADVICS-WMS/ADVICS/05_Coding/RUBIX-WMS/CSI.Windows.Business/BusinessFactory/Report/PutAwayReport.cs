using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.BusinessFactory.Report
{
    public class PutAwayReport : Base.BaseReport
    {
        public List<sp_RPT002_PutAwayReport_GetData_Result> GetDataReport(int? OwnerID, int? WarehouseID, int? ProductID, String ReceivingNo, DateTime? TransitDate1, DateTime? TransitDate2,int? zoneID, int TypeID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ProductID", ProductID);
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("TransitDate1", TransitDate1);
            hs.Add("TransitDate2", TransitDate2);
            hs.Add("zoneID", zoneID);
            hs.Add("TypeId", TypeID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PutAwayReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT002_PutAwayReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
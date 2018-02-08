using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.BusinessFactory.Report
{
    public class PickingListReport : Base.BaseReport
    {
        public List<sp_RPT021_PickingList_GetData_Result> GetDataReport(String shipmentNo, String pickingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("shipmentNo", shipmentNo);
            hs.Add("pickingNo", pickingNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PickingListReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT021_PickingList_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT021_PickingList_SubReport_GetData_Result> GetDataSubReport(String shipmentNo, String pickingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("shipmentNo", shipmentNo);
            hs.Add("pickingNo", pickingNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PickingListReport/GetDataSubReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT021_PickingList_SubReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.BusinessFactory.Report.Base;
using CSI.Business.DataObjects;
using Newtonsoft.Json;
using System.Collections;

namespace CSI.Business.Report
{
    public class PartDeliverySheetReport : BaseReport
    {
        public List<sp_RPT033_PartDeliverySheet_GetData_Result> GetDataReport(string PONo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PONo", PONo);
            

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PartDeliverySheetReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT033_PartDeliverySheet_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT033_PartDeliverySheet_GetSubData_Result> GetSubDataReport(string PONo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PONo", PONo);


            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PartDeliverySheetReport/GetSubDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT033_PartDeliverySheet_GetSubData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

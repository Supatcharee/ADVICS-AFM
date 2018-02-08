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
    public class LoadingInstructionReport : BaseReport
    {
        public List<sp_RPT036_LoadingInstruction_GetData_Result> GetDataReport(string shipmentNo, int installment, string containNo, string PlanOut, string ActualOut)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", shipmentNo);
            hs.Add("Installment", installment);
            hs.Add("ContainNo", containNo);
            hs.Add("PlanOut", PlanOut);
            hs.Add("ActualOut", ActualOut);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("LoadingInstructionReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT036_LoadingInstruction_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

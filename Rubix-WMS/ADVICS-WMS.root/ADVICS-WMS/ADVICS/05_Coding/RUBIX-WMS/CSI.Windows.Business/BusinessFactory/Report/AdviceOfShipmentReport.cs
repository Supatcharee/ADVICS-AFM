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
    public class AdviceOfShipmentReport : BaseReport
    {
        public List<sp_RPT042_AdivceOfShipment_GetData_Result> GetDataReport(string shipmentNo, int installment, string ContainerNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", shipmentNo);
            hs.Add("Installment", installment);
            hs.Add("ContainerNo", ContainerNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("AdviceOfShipmentReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT042_AdivceOfShipment_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

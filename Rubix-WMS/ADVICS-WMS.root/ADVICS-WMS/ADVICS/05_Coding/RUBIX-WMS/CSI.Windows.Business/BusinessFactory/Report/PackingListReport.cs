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
    public class PackingListReport : BaseReport
    {
        public List<sp_RPT044_PackingList_GetData_Result> GetDataReport(string ShipmentNo, int Installment, string ContainerNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("Installment", Installment);
            hs.Add("ContainerNo", ContainerNo);


            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PackingListReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT044_PackingList_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}

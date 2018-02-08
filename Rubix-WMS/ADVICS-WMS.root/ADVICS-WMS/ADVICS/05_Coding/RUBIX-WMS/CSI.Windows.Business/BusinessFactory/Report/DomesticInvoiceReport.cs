using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CSI.Business.BusinessFactory.Report.Base;
using CSI.Business.DataObjects;
using Newtonsoft.Json;
using System.Collections;

namespace CSI.Business.Report
{
    public class DomesticInvoiceReport : BaseReport
    {
        public DataSet GetDataReport(string ShipmentNo, int Installment, string ContainerNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("ContainerNo", ContainerNo);
            hs.Add("Installment", Installment);


            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("DomesticInvoiceReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

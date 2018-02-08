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
    public class ShippingInstructionReport : BaseReport
    {
        public DataSet GetCoverDataReport(string ShipmentNo, int Installment, string ContainerNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("Installment", Installment);
            hs.Add("ContainerNo", ContainerNo);


            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstructionReport/GetCoverDataReport", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetListDataReport(string ShipmentNo, int Installment, string ContainerNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("Installment", Installment);
            hs.Add("ContainerNo", ContainerNo);


            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstructionReport/GetListDataReport", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

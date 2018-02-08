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
    public class PrivilegeFormatReport : BaseReport
    {
        public List<sp_RPT043_PrivilegeFormat_GetData_Result> GetDataReport(string ShipmentNo, string ContainerNo)
        {

            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("ContainerNo", ContainerNo);

                string strResult = RubixWebAPI.ExecuteObjectResult("PrivilegeFormatReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT043_PrivilegeFormat_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

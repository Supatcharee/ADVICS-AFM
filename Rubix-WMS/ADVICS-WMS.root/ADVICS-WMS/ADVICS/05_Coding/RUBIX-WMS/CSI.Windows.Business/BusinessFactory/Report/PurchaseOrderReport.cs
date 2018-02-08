using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.BusinessFactory.Report.Base;
using CSI.Business.DataObjects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.Report
{
    public class PurchaseOrderReport : BaseReport
    {
        public List<sp_RPT034_PurchaseOrder_GetData_Result> GetDataReport(string ReceivingNoXML)
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PurchaseOrderReport/GetDataReport", JsonConvert.SerializeObject(ReceivingNoXML));
                return JsonConvert.DeserializeObject<List<sp_RPT034_PurchaseOrder_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;

namespace CSI.Business.Report
{
    public class PurchaseOrderReport : BusinessFactory.Report.Base.BaseReport
    {
        public List<sp_RPT034_PurchaseOrder_GetData_Result> GetDataReport(string ReceivingNoXML)
        {
            try
            {
                return Context.sp_RPT034_PurchaseOrder_GetData(ReceivingNoXML).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

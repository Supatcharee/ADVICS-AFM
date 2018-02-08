using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;

namespace CSI.Business.BusinessFactory.Report
{
    public class PutAwayReport : Base.BaseReport
    {

        public List<sp_RPT002_PutAwayReport_GetData_Result> GetDataReport(int? CustomerID, int? DCID, int? ProductID, String ReceivingNo, DateTime? TransitDate1, DateTime? TransitDate2, int? zoneID, int? TypeId)
        {
            try
            {
                return Context.sp_RPT002_PutAwayReport_GetData(CustomerID, DCID, ProductID, (ReceivingNo == String.Empty ? null : ReceivingNo), TransitDate1, TransitDate2, zoneID, TypeId).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
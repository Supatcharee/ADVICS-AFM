using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;

namespace CSI.Business.Report
{
    public class LoadingInstructionReport : BusinessFactory.Report.Base.BaseReport
    {
        public List<sp_RPT036_LoadingInstruction_GetData_Result> GetDataReport(string shipmentNo, int installment, string containNo, DateTime? PlanOut, DateTime? ActualOut)
        {
            try
            {
                return Context.sp_RPT036_LoadingInstruction_GetData(shipmentNo, installment, containNo, PlanOut, ActualOut).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

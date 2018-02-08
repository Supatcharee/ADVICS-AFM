using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;

namespace CSI.Business.Report
{
    public class PrivilegeFormatReport : BusinessFactory.Report.Base.BaseReport
    {
        public List<sp_RPT043_PrivilegeFormat_GetData_Result> GetDataReport(string ShipmentNo, string ContainerNo)
        {
            try
            {
                return Context.sp_RPT043_PrivilegeFormat_GetData(ShipmentNo, ContainerNo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

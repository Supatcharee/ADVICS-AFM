using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;

namespace CSI.Business.Report
{
    public class PartDeliverySheetReport : BusinessFactory.Report.Base.BaseReport
    {
        public List<sp_RPT033_PartDeliverySheet_GetData_Result> GetDataReport(string PONo)
        {
            try
            {
                return Context.sp_RPT033_PartDeliverySheet_GetData(PONo).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<sp_RPT033_PartDeliverySheet_GetSubData_Result> GetSubDataReport(string PONo)
        {
            try
            {
                return Context.sp_RPT033_PartDeliverySheet_GetSubData(PONo).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

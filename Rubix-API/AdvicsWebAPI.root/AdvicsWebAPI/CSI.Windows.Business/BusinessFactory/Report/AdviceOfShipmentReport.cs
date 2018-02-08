using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;

namespace CSI.Business.Report
{
    public class AdviceOfShipmentReport : BusinessFactory.Report.Base.BaseReport
    {
        public List<sp_RPT042_AdivceOfShipment_GetData_Result> GetDataReport(string shipmentNo, int installment, string ContainerNo)
        {
            try
            {
                return Context.sp_RPT042_AdivceOfShipment_GetData(shipmentNo, installment, ContainerNo).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

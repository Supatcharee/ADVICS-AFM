using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;

namespace CSI.Business.Report
{
    public class PackingListReport : BusinessFactory.Report.Base.BaseReport
    {
        public List<sp_RPT044_PackingList_GetData_Result> GetDataReport(string ShipmentNo, int Installment, string ContainerNo)
        {
            try
            {
                return Context.sp_RPT044_PackingList_GetData(ShipmentNo, Installment, ContainerNo).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }       
    }
}

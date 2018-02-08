using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;

namespace CSI.Business.BusinessFactory.Report
{
    public class EstimatePriceReport : Base.BaseReport
    {
        public List<sp_RPT012_EstimatePriceReport_GetData_Result> GetDataEstimatePriceReport(int? OwnerID, int? WarehouseID, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                return Context.sp_RPT012_EstimatePriceReport_GetData(ownerID: OwnerID, warehouseID: WarehouseID, fromDate: fromDate, toDate: toDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

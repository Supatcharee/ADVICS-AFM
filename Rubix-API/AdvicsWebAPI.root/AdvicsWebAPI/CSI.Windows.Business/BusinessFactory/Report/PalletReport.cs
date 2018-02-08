using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;

namespace CSI.Business.BusinessFactory.Report
{
    public class PalletReport : Base.BaseReport
    {
        public List<sp_RPT028_PalletReport_GetData_Result> GetDataReport(int? OwnerID, int? WarehouseID, int? productID, DateTime? dateFrom, DateTime? dateTo, int isMonthly)
        {
            try
            {
                return Context.sp_RPT028_PalletReport_GetData(ownerID:OwnerID , warehouseID:WarehouseID , productID:productID , dateFrom: dateFrom , dateTo:dateTo , isMonthly: isMonthly).ToList();
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
       
    }
}

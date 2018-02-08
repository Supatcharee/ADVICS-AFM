using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;


namespace CSI.Business.BusinessFactory.Report
{
    public class OrderBalanceReport : Base.BaseReport
    {
        public List<sp_RPT032_OrderBalance_GetData_Result> GetDataReport(int? OwnerID, int? WarehouseID, DateTime? dateFrom, DateTime? dateTo)
        {
            try
            {
                return Context.sp_RPT032_OrderBalance_GetData(ownerID: OwnerID, warehouseID: WarehouseID, dateForm: dateFrom, dateTo: dateTo).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

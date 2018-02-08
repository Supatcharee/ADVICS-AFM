using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;

namespace CSI.Business.BusinessFactory.Report
{
    public class MovementReport : Base.BaseReport
    {
        public List<sp_RPT023_MovementReport_GetData_Result> GetDataReport(int? OwnerID, int? WarehouseID, int? productID, DateTime? dateFrom, DateTime? dateTo)
        {
            try
            {
                return Context.sp_RPT023_MovementReport_GetData(ownerID:OwnerID , warehouseID:WarehouseID , productID:productID , dateFrom: dateFrom , dateTo:dateTo).ToList();
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<sp_RPT023_MovementReport_SubReport_GetData_Result> GetDataSubReport(int? OwnerID, int? WarehouseID, int? productID, DateTime? dateFrom, DateTime? dateTo)
        {
            try
            {
                return Context.sp_RPT023_MovementReport_SubReport_GetData(ownerID: OwnerID , warehouseID: WarehouseID , productID: productID , dateFrom: dateFrom , dateTo: dateTo).ToList();
                    }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT024_MovementReport_Chart_Result> GetChartReport(int? OwnerID, int? WarehouseID, int? productID, DateTime? dateFrom, DateTime? dateTo, int isMonthly)
        {
            try
            {
                return Context.sp_RPT024_MovementReport_Chart(ownerID: OwnerID , warehouseID: WarehouseID , productID: productID , dateFrom: dateFrom , dateTo: dateTo , isMonthly: isMonthly).ToList();
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
       
    }
}

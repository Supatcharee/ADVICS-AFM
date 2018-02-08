using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;

namespace CSI.Business.BusinessFactory.Report
{
    public class InventoryUsageReport : Base.BaseReport
    {
        public List<sp_RPT025_InventoryUsageReport_GetData_Result> GetDataReport(int? WarehouseID,int? OwnerID)
        {
            try
            {
                return Context.sp_RPT025_InventoryUsageReport_GetData(warehouseID: WarehouseID, ownerID: OwnerID).ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT026_InventoryUsageReport_Chart_GetData_Result> GetDataChartReport(int? WarehouseID,int? OwnerID)
        {
            try
            {
                return Context.sp_RPT026_InventoryUsageReport_Chart_GetData(warehouseID: WarehouseID, ownerID: OwnerID).ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<DateTime?> GetMaxDailyPostDate()
        //{
        //    try
        //    {
        //        return Context.sp_system_GetMaxDailyPostDate().ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<sp_RPT025_InventoryUsageReport_GetData_Sub_Report_Result> GetSubReport(int? WarehouseID,int? OwnerID)
        {
            try
            {
                return Context.sp_RPT025_InventoryUsageReport_GetData_Sub_Report(warehouseID: WarehouseID, ownerID: OwnerID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

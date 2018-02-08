using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;

namespace CSI.Business.BusinessFactory.Report
{
    public class ReceivePlanListReport : Base.BaseReport
    {

        public List<sp_RPT029_ReceivePlanList_GetData_Result> GetDataReport(int? OwnerID, int? WarehouseID, DateTime? dateFrom, DateTime? dateTo)
        {
            try
            {
                return Context.sp_RPT029_ReceivePlanList_GetData(ownerID: OwnerID , warehouseID: WarehouseID , dateForm: dateFrom , dateTo: dateTo).ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<sp_RPT029_ReceivePlanList_SubReport_GetData_Result> GetDataSubReport(int? OwnerID, int? WarehouseID, DateTime? dateFrom, DateTime? dateTo)
        {
            try
            {
                return Context.sp_RPT029_ReceivePlanList_SubReport_GetData(ownerID: OwnerID , warehouseID: WarehouseID , dateForm: dateFrom , dateTo: dateTo).ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

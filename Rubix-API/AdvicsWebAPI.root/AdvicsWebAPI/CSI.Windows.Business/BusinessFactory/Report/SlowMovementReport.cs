using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;


namespace CSI.Business.BusinessFactory.Report
{
    public class SlowMovementReport : Base.BaseReport
    {
        public List<sp_RPT031_SlowMovement_GetData_Result> GetDataReport(int? OwnerID, int? WarehouseID, DateTime dDate, Int32 period1, Int32 period2, Int32 period3, Int32 period4)
        {
            try
            {
                return Context.sp_RPT031_SlowMovement_GetData(ownerID: OwnerID, warehouseID: WarehouseID, date: dDate, period1: period1, period2: period2, period3: period3, period4: period4).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

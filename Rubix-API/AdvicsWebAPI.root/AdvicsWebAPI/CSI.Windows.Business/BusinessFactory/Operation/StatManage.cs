using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;

namespace CSI.Business.Operation
{
    public class StatManage
    {


        public ObjectResult<sp_MSTS010_HistoryView_Search_Result> DataLoading(int? OwnerID, int? WarehouseID, DateTime? TransFrom, DateTime? TransTo)
        {
            try
            {
                return Database.HistoryViewContext.sp_MSTS010_HistoryView_Search(ownerID: OwnerID, warehouseID: WarehouseID, transFrom: TransFrom, transTo: TransTo);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public ObjectResult<sp_MSTS010_HistoryView_Summary_Search_Result> DataSummaryLoading(int? OwnerID, int? WarehouseID, DateTime? TransFrom, DateTime? TransTo)
        {
            try
            {
                return Database.HistoryViewContext.sp_MSTS010_HistoryView_Summary_Search(ownerID: OwnerID, warehouseID: WarehouseID, transFrom: TransFrom, transTo: TransTo);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}

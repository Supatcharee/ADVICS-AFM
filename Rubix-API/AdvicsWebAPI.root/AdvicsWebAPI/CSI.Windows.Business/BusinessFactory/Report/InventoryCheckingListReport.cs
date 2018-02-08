using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data;
using System.Collections;

namespace CSI.Business.BusinessFactory.Report
{
    public class InvertoryCheckingListReport : Base.BaseReport
    {

        public List<sp_RPT016_InventoryCheckingListByProduct_GetData_Result> GetCheckingListByProductReport(int? OwnerID, int? WarehouseID, int? productID, DateTime? toDate)
        {
            try
            {
                return Context.sp_RPT016_InventoryCheckingListByProduct_GetData(ownerID: OwnerID ,warehouseID:  WarehouseID ,productID: productID ,date: toDate).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT017_InventoryCheckingListByZone_GetData_Result> GetCheckingListByZoneReport(int? OwnerID, int? WarehouseID, DateTime? Date,int? ZoneID,int? Floor)
        {
            try
            {
                return Context.sp_RPT017_InventoryCheckingListByZone_GetData(ownerID: OwnerID, warehouseID: WarehouseID , date: Date , zoneID: ZoneID , floor:Floor).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT017_InventoryCheckingListByZone_SubReport_GetData_Result> GetCheckingListByZoneSubReport(int? OwnerID, int? WarehouseID, DateTime? Date, int? ZoneID, int? Floor)
        {
            try
            {
                return Context.sp_RPT017_InventoryCheckingListByZone_SubReport_GetData(ownerID: OwnerID , warehouseID: WarehouseID , date: Date , zoneID: ZoneID , floor: Floor).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadFloor(int? WarehouseID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("WarehouseID", WarehouseID);
                return Database.ExecuteDataSet("sp_common_LoadFloor", hs).Tables[0];
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
    }
}

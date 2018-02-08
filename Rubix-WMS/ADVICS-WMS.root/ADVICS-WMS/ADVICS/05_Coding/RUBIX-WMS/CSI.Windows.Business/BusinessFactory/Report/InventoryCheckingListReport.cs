using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.BusinessFactory.Report
{
    public class InvertoryCheckingListReport : Base.BaseReport
    {
        public List<sp_RPT016_InventoryCheckingListByProduct_GetData_Result> GetCheckingListByProductReport(int? OwnerID, int? WarehouseID, int? productID, DateTime? toDate)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("productID", productID);
            hs.Add("toDate", toDate);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("InventoryCheckingListReport/GetCheckingListByProductReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT016_InventoryCheckingListByProduct_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT017_InventoryCheckingListByZone_GetData_Result> GetCheckingListByZoneReport(int? OwnerID, int? WarehouseID, DateTime? Date,int? ZoneID,int? Floor)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("Date", Date);
            hs.Add("ZoneID", ZoneID);
            hs.Add("Floor", Floor);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("InventoryCheckingListReport/GetCheckingListByZoneReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT017_InventoryCheckingListByZone_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT017_InventoryCheckingListByZone_SubReport_GetData_Result> GetCheckingListByZoneSubReport(int? OwnerID, int? WarehouseID, DateTime? Date, int? ZoneID, int? Floor)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("Date", Date);
            hs.Add("ZoneID", ZoneID);
            hs.Add("Floor", Floor);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("InventoryCheckingListReport/GetCheckingListByZoneSubReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT017_InventoryCheckingListByZone_SubReport_GetData_Result>>(strResult);
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
                return RubixWebAPI.ExecuteDataTable("InventoryCheckingListReport/LoadFloor", hs);
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
        //        string strResult = RubixWebAPI.ExecuteObjectResult("InventoryCheckingListReport/GetMaxDailyPostDate");
        //        return JsonConvert.DeserializeObject<List<DateTime?>>(strResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}

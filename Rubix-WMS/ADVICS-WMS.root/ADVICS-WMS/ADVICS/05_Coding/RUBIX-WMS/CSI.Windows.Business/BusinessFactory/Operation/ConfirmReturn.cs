 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using Rubix.Framework;
using System.Transactions;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.BusinessFactory.Operation
{
    public class ConfirmReturn
    {
        public int TransitSeq{ get; set; }
        public int? LocationID{ get; set; }
        public decimal? TotalCapacity { get; set; }
        public decimal? CurrentCapacity { get; set; }
        public decimal? StockActualQty { get; set; }
        public bool? FullCapacityFlag { get; set; }
        public int? ConditionID { get; set; }


        public List<sp_ISHS070_ReturnPick_Get_Result> Search(int? OwnerID, 
                                                            int? WarehouseID, 
                                                            string shipmentNo, 
                                                            string pickingNo, 
                                                            DateTime? shipFrom, 
                                                            DateTime? shipTo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("shipmentNo", shipmentNo);
            hs.Add("pickingNo", pickingNo);
            hs.Add("shipFrom", shipFrom);
            hs.Add("shipTo", shipTo);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmReturn/Search", hs);
                return JsonConvert.DeserializeObject<List<sp_ISHS070_ReturnPick_Get_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public sp_ISHS071_ReturnPick_Get_Result GetDetail(string shipmentNo, string pickingNo, int productID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("shipmentNo", shipmentNo);
            hs.Add("pickingNo", pickingNo);
            hs.Add("productID", productID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmReturn/GetDetail", hs);
                return JsonConvert.DeserializeObject<sp_ISHS071_ReturnPick_Get_Result>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public sp_DSRS010_ConfirmProductStoring_LoadStockByLocation_Result LoadDefaultTransitConfirm(int locationID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("locationID", locationID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmReturn/LoadDefaultTransitConfirm", hs);
                return JsonConvert.DeserializeObject<sp_DSRS010_ConfirmProductStoring_LoadStockByLocation_Result>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }    
        }

        public void Confirm(string shipmentNo, 
                            string pickingNo, 
                            int lineNo, 
                            int OwnerID, 
                            int WarehouseID, 
                            int productID, 
                            string lotNo, 
                            string palletNo,
                            List<ConfirmReturn> detail)
        {           

            Hashtable hs = new Hashtable();
            hs.Add("shipmentNo", shipmentNo);
            hs.Add("pickingNo", pickingNo);
            hs.Add("lineNo", lineNo);
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("productID", productID);
            hs.Add("lotNo", lotNo);
            hs.Add("palletNo", palletNo);
            hs.Add("user", AppConfig.UserLogin);

            RubixWebAPI.ExecuteObjectResult("ConfirmReturn/Confirm", hs, JsonConvert.SerializeObject(detail));
        }
    }
}

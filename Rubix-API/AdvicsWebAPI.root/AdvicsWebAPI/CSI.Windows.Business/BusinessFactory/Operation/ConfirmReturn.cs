using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using Rubix.Framework;
using System.Transactions;
using System.Collections;

namespace CSI.Business.BusinessFactory.Operation
{
    public class ConfirmReturn
    {
        public int TransitSeq { get; set; }
        public int? LocationID { get; set; }
        public decimal? TotalCapacity { get; set; }
        public decimal? CurrentCapacity { get; set; }
        public decimal? StockActualQty { get; set; }
        public bool? FullCapacityFlag { get; set; }
        public int? ConditionID { get; set; }

        public List<sp_ISHS070_ReturnPick_Get_Result> Search(int? OwnerID, int? WarehouseID, string shipmentNo, string pickingNo, DateTime? shipFrom, DateTime? shipTo)
        {
            try
            {
                return Database.ShippingContext.sp_ISHS070_ReturnPick_Get(ownerID: OwnerID, warehouseID: WarehouseID, shipmentNo: shipmentNo, pickingNo: pickingNo, shipFrom: shipFrom, shipTo: shipTo).ToList();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public sp_ISHS071_ReturnPick_Get_Result GetDetail(string shipmentNo, string pickingNo, int productID)
        {
            try
            {
                return Database.ShippingContext.sp_ISHS071_ReturnPick_Get(shipmentNo: shipmentNo, pickingNo: pickingNo, itemID: productID).FirstOrDefault();

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public sp_DSRS010_ConfirmProductStoring_LoadStockByLocation_Result LoadDefaultTransitConfirm(int locationID)
        {
            try
            {
                return Database.TransitContext.sp_DSRS010_ConfirmProductStoring_LoadStockByLocation(locationID: locationID).FirstOrDefault();

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public void Confirm(string shipmentNo, string pickingNo, int lineNo, int OwnerID, int WarehouseID, int productID, string lotNo, string palletNo, List<ConfirmReturn> detail, string UserLogin)
        {

            try
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<Tab>");
                foreach (ConfirmReturn rec in detail)
                {
                    xml.Append("<Rec>");
                    xml.Append(string.Format("<LocationID>{0}</LocationID>", rec.LocationID));
                    xml.Append(string.Format("<ConditionID>{0}</ConditionID>", rec.ConditionID));
                    xml.Append(string.Format("<Quantity>{0}</Quantity>", rec.StockActualQty));
                    xml.Append(string.Format("<FullCapacityFlag>{0}</FullCapacityFlag>", rec.FullCapacityFlag.Value ? 1 : 0));
                    xml.Append("</Rec>");
                }
                xml.Append("</Tab>");


                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", shipmentNo);
                hs.Add("PickingNo", pickingNo);
                hs.Add("LineNo", lineNo);
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ProductID", productID);
                hs.Add("LotNo", lotNo);
                hs.Add("PalletNo", palletNo);
                hs.Add("User", UserLogin);
                hs.Add("xml", xml.ToString());
                Database.ExecuteNonQuery("sp_ISHS071_ReturnPick_Confirm", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    
    }
}

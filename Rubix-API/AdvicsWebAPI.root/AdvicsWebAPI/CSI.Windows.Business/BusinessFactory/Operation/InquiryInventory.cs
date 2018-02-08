using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using System.Collections;

namespace CSI.Business.Operation
{
    public class InquiryInventory
    {
        #region Member
        private ObjectResult<sp_ESTS030_InquiryInventory_SearchAll_Result> lt_Result = null;
        private sp_ESTS030_InquiryInventory_SearchAll_Result ta_Result = null;
        private BusinessCommon ims = null;
        #endregion

        #region Properties
        private BusinessCommon Database
        {
            get
            {
                if (ims == null)
                {
                    ims = new BusinessCommon();
                }
                return ims;
            }
        }
        private sp_ESTS030_InquiryInventory_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_ESTS030_InquiryInventory_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        private ObjectResult<sp_ESTS030_InquiryInventory_SearchAll_Result> ResultList
        {
            get { return lt_Result; }
            set { lt_Result = value; }
        }
        public Object SelectData
        {
            set { ta_Result = (sp_ESTS030_InquiryInventory_SearchAll_Result)value; }
        }
        public int OwnerID
        {
            get { return ResultData.OwnerID; }
            set { ResultData.OwnerID = value; }
        }
        public int WarehouseID
        {
            get { return ResultData.WarehouseID; }
            set { ResultData.WarehouseID = value; }
        }
        public int ProductConditionID
        {
            get { return ResultData.ProductConditionID; }
            set { ResultData.ProductConditionID = value; }
        }
        public int ProductID
        {
            get { return ResultData.ProductID; }
            set { ResultData.ProductID = value; }
        }
        public String ProductCode
        {
            get { return ResultData.ItemCode; }
            set { ResultData.ItemCode = value; }
        }
        public String ProductName
        {
            get { return ResultData.ItemName; }
            set { ResultData.ItemName = value; }
        }
        public String ConditionOfProduct
        {
            get { return ResultData.ItemConditionName; }
            set { ResultData.ItemConditionName = value; }
        }
        public String Location
        {
            get { return ResultData.LocationCode; }
            set { ResultData.LocationCode = value; }
        }
        public decimal? Inventory
        {
            get { return ResultData.Inventory; }
            set { ResultData.Inventory = value; }
        }
        public DateTime? LastMovement
        {
            get { return ResultData.LastMovement; }
            set { ResultData.LastMovement = value; }
        }
        #endregion

        public List<sp_ESTS030_InquiryInventory_SearchAll_Result> DataLoading(int? OwnerID, int? WarehouseID, int? ZoneID, int? ProductID, int? ProductConditionID, int? LocationID)
        {
            try
            {
                return Database.StockEntity.sp_ESTS030_InquiryInventory_SearchAll( ownerID: OwnerID
                                                                                  ,warehouseID: WarehouseID
                                                                                  ,zoneID: ZoneID
                                                                                  ,productID: ProductID
                                                                                  ,productConditionID: ProductConditionID
                                                                                  ,location:LocationID).ToList();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public sp_ESTS000_InventoryStatusProcess_Result GetInventoryStatus(int? OwnerID, int? WarehouseID, int? ProductID, int? ProductConditionID, string productCode)
        {
            try
            {
                return Database.StockEntity.sp_ESTS000_InventoryStatusProcess(ownerID: OwnerID
                                                                             , warehouseID: WarehouseID
                                                                             , productID: ProductID
                                                                             , productConditionID: ProductConditionID
                                                                             , productCode: productCode).SingleOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<sp_ESTS030_InquiryInventory_ByItem_SearchAll_Result> DataLoadingByItem(int? OwnerID, int? WarehouseID, int? ZoneID, int? ProductID, int? ProductConditionID, DateTime? LastMovementFrom, DateTime? LastMovementTo)
        {
            try
            {
                return Database.StockEntity.sp_ESTS030_InquiryInventory_ByItem_SearchAll( ownerID: OwnerID
                                                                                         ,warehouseID: WarehouseID
                                                                                         ,zoneID: ZoneID
                                                                                         ,productID: ProductID
                                                                                         ,conditionOfProductID: ProductConditionID
                                                                                         ,lastMovementFrom: LastMovementFrom
                                                                                         ,lastMovementTo: LastMovementTo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public DataTable DataLoadingByItemDataTable(int? OwnerID, int? WarehouseID, int? ProductID, int? ProductConditionID, bool? ignorePrefix, DateTime? LastMovementFrom, DateTime? LastMovementTo)
        //{
        //    try
        //    {
        //        Hashtable hs = new Hashtable();
        //        hs.Add("OwnerID", OwnerID);
        //        hs.Add("WarehouseID", WarehouseID);
        //        hs.Add("ProductID", ProductID);
        //        hs.Add("ConditionOfProductID", ProductConditionID);
        //        hs.Add("IgnorePrefix", ignorePrefix);
        //        hs.Add("LastMovementFrom", "2014/06/01");
        //        hs.Add("LastMovementTo", "2014/06/27");

        //       return Database.ExecuteDataSet("sp_ESTS030_InquiryInventory_ByItem_SearchAll", hs).Tables[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}

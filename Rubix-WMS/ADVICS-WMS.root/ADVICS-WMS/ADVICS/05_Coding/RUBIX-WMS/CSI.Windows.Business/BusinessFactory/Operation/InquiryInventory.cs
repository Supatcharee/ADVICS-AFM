using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.Operation
{
    public class InquiryInventory
    {
        #region Member
        private sp_ESTS030_InquiryInventory_SearchAll_Result ta_Result = null;
        #endregion

        #region Properties
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
        public String LocationCode
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

        public List<sp_ESTS030_InquiryInventory_SearchAll_Result> DataLoading(int? OwnerID, int? WarehouseID, int? ZoneID, int? ProductID, int? ProductConditionID, int? Location)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ZoneID", ZoneID);
            hs.Add("ProductID", ProductID);
            hs.Add("ProductConditionID", ProductConditionID);
            hs.Add("Location", Location);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("InquiryInventory/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_ESTS030_InquiryInventory_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public sp_ESTS000_InventoryStatusProcess_Result GetInventoryStatus(int? OwnerID, int? WarehouseID, int? ProductID, int? ProductConditionID, string ProductCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ProductID", ProductID);
            hs.Add("ProductConditionID", ProductConditionID);
            hs.Add("ProductCode", ProductCode);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("InquiryInventory/GetInventoryStatus", hs);
                return JsonConvert.DeserializeObject<sp_ESTS000_InventoryStatusProcess_Result>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_ESTS030_InquiryInventory_SearchAll_Result> DataLoadingByItem(int? OwnerID,  int? WarehouseID, int? ZoneID, int? ProductID, int? ProductConditionID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ZoneID", ZoneID);
            hs.Add("ProductID", ProductID);
            hs.Add("ProductConditionID", ProductConditionID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("InquiryInventory/DataLoadingByItem", hs);
                return JsonConvert.DeserializeObject < List<sp_ESTS030_InquiryInventory_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

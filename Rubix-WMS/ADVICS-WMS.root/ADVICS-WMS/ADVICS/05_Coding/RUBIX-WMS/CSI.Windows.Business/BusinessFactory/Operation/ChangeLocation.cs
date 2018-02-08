/*
 6 Feb 2013:
 * 1. add new method for show report after save change location
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
using System.Data;
using CSI.Business.Common;
using System.Transactions;
using Rubix.Framework;
using Newtonsoft.Json;

namespace CSI.Business.Operation
{
    public class ChangeLocation : CSI.Business.BusinessFactory.Report.Base.BaseReport
    {
        #region Member
        private ObjectResult<sp_ESTS020_ChangeLocation_SearchAll_Result> lt_Result = null;
        private sp_ESTS020_ChangeLocation_SearchAll_Result ta_Result = null;
        #endregion

        #region Properties
        private sp_ESTS020_ChangeLocation_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_ESTS020_ChangeLocation_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        private ObjectResult<sp_ESTS020_ChangeLocation_SearchAll_Result> ResultList
        {
            get { return lt_Result; }
            set { lt_Result = value; }
        }
        public Object SelectData
        {
            set { ta_Result = (sp_ESTS020_ChangeLocation_SearchAll_Result)value; }
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
        public int LocationID
        {
            get { return ResultData.LocationID; }
            set { ResultData.LocationID = value; }
        }
        public String PalletNo
        {
            get { return ResultData.PalletNo; }
            set { ResultData.PalletNo = value; }
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
        public DateTime LastUpdateSince
        {
            get { return ResultData.LastUpdateSince; }
            set { ResultData.LastUpdateSince = value; }
        }
        public String OwnerCode
        {
            get { return ResultData.OwnerCode; }
            set { ResultData.OwnerCode = value; }
        }
        public String WarehouseCode
        {
            get { return ResultData.WarehouseCode; }
            set { ResultData.WarehouseCode = value; }
        }
        public String ProductConditionCode
        {
            get { return ResultData.ProductConditionCode; }
            set { ResultData.ProductConditionCode = value; }
        }
        public int? ZoneID
        {
            get { return ResultData.ZoneID; }
            set { ResultData.ZoneID = value; }
        }
        public String ZoneCode
        {
            get { return ResultData.ZoneCode; }
            set { ResultData.ZoneCode = value; }
        }
        public String RackNo
        {
            get { return ResultData.RackNo; }
            set { ResultData.RackNo = value; }
        }
        public int? Floor
        {
            get { return ResultData.Floor; }
            set { ResultData.Floor = value; }
        }
        public String ProductCode
        {
            get { return ResultData.ProductCode; }
            set { ResultData.ProductCode = value; }
        }
        public String ProductName
        {
            get { return ResultData.ProductName; }
            set { ResultData.ProductName = value; }
        }
        public String WarehouseName
        {
            get { return ResultData.WarehouseName; }
            set { ResultData.WarehouseName = value; }
        }
        public String LocationCode
        {
            get { return ResultData.LocationCode; }
            set { ResultData.LocationCode = value; }
        }
        public String ProductConditionName
        {
            get { return ResultData.ProductConditionName; }
            set { ResultData.ProductConditionName = value; }
        }
        public decimal Inventory
        {
            get { return Convert.ToDecimal(ResultData.Inventory); }
            set { ResultData.Inventory = value; }
        }
        public decimal InventoryBox
        {
            get { return Convert.ToDecimal(ResultData.InventoryBox); }
        }
        public String Level2UnitName
        {
            get { return ResultData.Level2UnitName; }
        }
        public decimal? RatioConvertInventory
        {
            get { return ResultData.RatioConvertInventory; }
        }
        public String LotNo
        {
            get { return ResultData.LotNo; }
            set { ResultData.LotNo = value; }
        }
        public String LocationCodeTo
        {
            get { return ResultData.LocationCodeTO; }
            set { ResultData.LocationCodeTO = value; }
        }
        public String ProductConditionNameTo
        {
            get { return ResultData.ProductConditionNameTo; }
            set { ResultData.ProductConditionNameTo = value; }
        }
        public Decimal? ChangeQty
        {
            get { return ResultData.ChangeQty; }
            set { ResultData.ChangeQty = value; }
        }
        public int? ToLocationID
        {
            get { return ResultData.ToLocationID; }
            set { ResultData.ToLocationID = value; }
        }
        public String ChangeStatus
        {
            get { return ResultData.ChangeStatus; }
            set { ResultData.ChangeStatus = value; }
        }
        public int? ToProductConditionID
        {
            get { return ResultData.ToProductConditionID; }
            set { ResultData.ToProductConditionID = value; }
        }
        public int? ChangeLocationID
        {
            get { return ResultData.ChangeLocationID; }
            set { ResultData.ChangeLocationID = value; }
        }
        public int? FromProductConditionID
        {
            get { return ResultData.FromProductConditionID; }
            set { ResultData.FromProductConditionID = value; }
        }
        public int? FromLocationID
        {
            get { return ResultData.FromLocationID; }
            set { ResultData.FromLocationID = value; }
        }
        public bool? FromFullCapacityFlag
        {
            get { return ResultData.FromFullCapacityFlag; }
            set { ResultData.FromFullCapacityFlag = value; }
        }
        public bool? ToFullCapacityFlag
        {
            get { return ResultData.ToFullCapacityFlag; }
            set { ResultData.ToFullCapacityFlag = value; }
        }
        public DateTime? ChangedDate
        {
            get { return ResultData.ChangedDate; }
            set { ResultData.ChangedDate = value; }
        }
        public String ChangedUser
        {
            get { return ResultData.ChangedUser; }
            set { ResultData.ChangedUser = value; }
        }
        public DateTime? ExpiryDate
        {
            get { return ResultData.ExpiryDate; }
            set { ResultData.ExpiryDate = value; }
        }

        //Add RackNoAndLevel Winai S.
        public String RackNoAndLevel
        {
            get { return ResultData.RackNoAndLevel; }
            set { ResultData.RackNoAndLevel = value; }
        }


        #endregion

        public List<sp_ESTS020_ChangeLocation_SearchAll_Result> DataLoading(int? OwnerID, int? WarehouseID, int? Floor, int? ZoneID, int? ProductID, int? ProductConditionID, String PalletNo, String PalletNoRef, String LotNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("Floor", Floor);
            hs.Add("ZoneID", ZoneID);
            hs.Add("ProductID", ProductID);
            hs.Add("ProductConditionID", ProductConditionID);
            hs.Add("PalletNo", PalletNo);
            hs.Add("PalletNoRef", PalletNoRef);
            hs.Add("LotNo", LotNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ChangeLocation/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_ESTS020_ChangeLocation_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                
        public DataTable LoadRack(int? ZoneID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ZoneID", ZoneID);
                return RubixWebAPI.ExecuteDataTable("ChangeLocation/LoadRack", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String LoadLocationCode(int? WarehouseID, int? ZoneID, String RackNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ZoneID", ZoneID);
            hs.Add("RackNo", RackNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ChangeLocation/LoadLocationCode", hs);
                return JsonConvert.DeserializeObject<String>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public int? LoadLocationID(int WarehouseID, String LocationCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("LocationCode", LocationCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ChangeLocation/LoadLocationID", hs);
                return JsonConvert.DeserializeObject<int?>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void SaveExpiryDate(string PalletNo, DateTime? ExpiryDate)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PalletNo", PalletNo);
            hs.Add("ExpiryDate", ExpiryDate);

            try
            {
                RubixWebAPI.ExecuteObjectResult("ChangeLocation/SaveExpiryDate", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public bool LoadFullCapacityFlag(int? WarehouseID, String LocationCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("LocationCode", LocationCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ChangeLocation/LoadFullCapacityFlag", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveLocationChange(int? OwnerID, int? WarehouseID, int? ProductID, string LotNo, String PalletNo, int? ProductConditionIDFrom
                                      , int? LocationIDFrom, bool? FullCapacityFlagFrom, int? ProductConditionIDTo, int? LocationIDTo
                                      , bool? FullCapacityFlagTo, decimal? Quantity)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ProductID", ProductID);
            hs.Add("LotNo", LotNo);
            hs.Add("PalletNo", PalletNo);
            hs.Add("ProductConditionIDFrom", ProductConditionIDFrom);
            hs.Add("LocationIDFrom", LocationIDFrom);
            hs.Add("FullCapacityFlagFrom", FullCapacityFlagFrom);
            hs.Add("ProductConditionIDTo", ProductConditionIDTo);
            hs.Add("LocationIDTo", LocationIDTo);
            hs.Add("FullCapacityFlagTo", FullCapacityFlagTo);
            hs.Add("Quantity", Quantity);
            hs.Add("ChangedUser", AppConfig.UserLogin);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ChangeLocation/SaveLocationChange", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

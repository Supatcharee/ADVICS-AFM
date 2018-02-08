using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
using System.Data;
using System.Transactions;
using Rubix.Framework;
using Newtonsoft.Json;

namespace CSI.Business.Operation
{
    public class CorrectInventory : CSI.Business.BusinessFactory.Report.Base.BaseReport
    {
        #region Member
        private sp_ESTS010_InventoryAdjustment_SearchAll_Result ta_Result = null;
        #endregion

        #region Properties
        private sp_ESTS010_InventoryAdjustment_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_ESTS010_InventoryAdjustment_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        public Object SelectData
        {
            set { ta_Result = (sp_ESTS010_InventoryAdjustment_SearchAll_Result)value; }
        }
        public bool? Select
        {
            get { return ResultData.Select; }
            set { ResultData.Select = value; }
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
        public String ZoneCode
        {
            get { return ResultData.ZoneCode; }
            set { ResultData.ZoneCode = value; }
        }
        public int? Floor
        {
            get { return ResultData.Floor; }
            set { ResultData.Floor = value; }
        }
        public String RackNo
        {
            get { return ResultData.RackNo; }
            set { ResultData.RackNo = value; }
        }
        public String ReceivingNo
        {
            get { return ResultData.ReceivingNo; }
            set { ResultData.ReceivingNo = value; }
        }
        public String ProductConditionCode
        {
            get { return ResultData.ProductConditionCode; }
            set { ResultData.ProductConditionCode = value; }
        }
        public String OwnerCode
        {
            get { return ResultData.OwnerCode; }
            set { ResultData.OwnerCode = value; }
        }
        public String CustomerName
        {
            get { return ResultData.OwnerName; }
            set { ResultData.OwnerName = value; }
        }
        public String WarehouseCode
        {
            get { return ResultData.WarehouseCode; }
            set { ResultData.WarehouseCode = value; }
        }
        public String WarehouseName
        {
            get { return ResultData.WarehouseName; }
            set { ResultData.WarehouseName = value; }
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
        public String ProductConditionName
        {
            get { return ResultData.ProductConditionName; }
            set { ResultData.ProductConditionName = value; }
        }
        public String PalletNo
        {
            get { return ResultData.PalletNo; }
            set { ResultData.PalletNo = value; }
        }
        public String LocationCode
        {
            get { return ResultData.LocationCode; }
            set { ResultData.LocationCode = value; }
        }
        public String LocationName
        {
            get { return ResultData.LocationName; }
            set { ResultData.LocationName = value; }
        }
        public decimal? InventoryQty
        {
            get { return ResultData.InventoryQty; }
            set { ResultData.InventoryQty = value; }
        }
        public decimal? InventoryQtyL3
        {
            get { return ResultData.InventoryQtyL3; }
            set { ResultData.InventoryQtyL3 = value; }
        }
        public DateTime? FinalUpdateDate
        {
            get { return ResultData.FinalUpdateDate; }
            set { ResultData.FinalUpdateDate = value; }
        }
        public string LotNo
        {
            get { return ResultData.LotNo; }
            set { ResultData.LotNo = value; }
        }
        public DateTime? ExpiredDate
        {
            get { return ResultData.ExpiredDate; }
            set { ResultData.ExpiredDate = value; }
        }
        #endregion

        public List<sp_ESTS010_InventoryAdjustment_SearchAll_Result> DataLoading(int? OwnerID, int? WarehouseID, string ReceivingNo, int? ProductID, string PalletNo)
        {

            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("ProductID", ProductID);
            hs.Add("PalletNo", PalletNo);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("CorrectInventory/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_ESTS010_InventoryAdjustment_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public sp_ESTS000_InventoryStatusProcess_Result GetInventoryStatus(int? OwnerID, int? WarehouseID, int? ProductID, int? ProductConditionID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ProductID", ProductID);
            hs.Add("ProductConditionID", ProductConditionID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("CorrectInventory/GetInventoryStatus", hs);
                return JsonConvert.DeserializeObject<sp_ESTS000_InventoryStatusProcess_Result>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveStockMoveMent(int? OwnerID, int? WarehouseID, String RefSlipNo, int? ProductID, int? ProductConditionID, String Action, decimal? Adjustment, String PalletNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("RefSlipNo", RefSlipNo);
            hs.Add("ProductID", ProductID);
            hs.Add("ProductConditionID", ProductConditionID);
            hs.Add("Action", Action);
            hs.Add("Adjustment", Adjustment);
            hs.Add("PalletNo", PalletNo);

            try
            {
                RubixWebAPI.ExecuteObjectResult("CorrectInventory/SaveStockMoveMent", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveStockByLocation(int? OwnerID, int? WarehouseID, int? LocationID, int? ProductID, int? ProductConditionID, String PalletNo, decimal? AfterAdjustment)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("LocationID", LocationID);
            hs.Add("ProductID", ProductID);
            hs.Add("ProductConditionID", ProductConditionID);
            hs.Add("PalletNo", PalletNo);
            hs.Add("AfterAdjustment", AfterAdjustment);
            try
            {
                RubixWebAPI.ExecuteObjectResult("CorrectInventory/SaveStockByLocation", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveStockHistory(int? OwnerID, int? WarehouseID, String RefSlipNo, int? ProductID, int? ProductConditionID, int? LocationID, String Action, decimal? Adjustment, decimal? AfterAdjustment)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("RefSlipNo", RefSlipNo);
            hs.Add("ProductID", ProductID);
            hs.Add("ProductConditionID", ProductConditionID);
            hs.Add("LocationID", LocationID);
            hs.Add("Action", Action);
            hs.Add("Adjustment", Adjustment);
            hs.Add("AfterAdjustment", AfterAdjustment);
            try
            {
                RubixWebAPI.ExecuteObjectResult("CorrectInventory/SaveStockHistory", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveData(int? OwnerID, int? WarehouseID, string ReceivingNo,int? ProductID,int? ProductConditionID,int? LocationID,String PalletNo,string LotNo,decimal? Adjustment,bool FullCapacity,DateTime? ExpiredDate,String Remark)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("ProductID", ProductID);
            hs.Add("ProductConditionID", ProductConditionID);
            hs.Add("LocationID", LocationID);
            hs.Add("PalletNo", PalletNo);
            hs.Add("LotNo", LotNo);
            hs.Add("Adjustment", Adjustment);
            hs.Add("FullCapacity", FullCapacity);
            hs.Add("UpdateUser", AppConfig.UserLogin);
            hs.Add("ExpiredDate", ExpiredDate);
            hs.Add("CreateUser", AppConfig.UserLogin);
            hs.Add("Remark", Remark);

            try
            {
                RubixWebAPI.ExecuteObjectResult("CorrectInventory/SaveData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadZone(int? OwnerID, int? WarehouseID, int? Floor)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("Floor", Floor);
            try
            {
                return RubixWebAPI.ExecuteDataTable("CorrectInventory/LoadZone", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadRack(int? ZoneID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ZoneID", ZoneID);
            try
            {
                return RubixWebAPI.ExecuteDataTable("CorrectInventory/LoadRack", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadLocationCode(int? ZoneID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ZoneID", ZoneID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("CorrectInventory/LoadLocationCode", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? LoadLocationID(String LocationCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("LocationCode", LocationCode);

                string strResult = RubixWebAPI.ExecuteObjectResult("CorrectInventory/LoadLocationID", hs);
                return JsonConvert.DeserializeObject<int?>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadLotNo(int OwnerID, int WarehouseID, int LocationID, int ProductID, int ProductConditionID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("LocationID", LocationID);
                hs.Add("ProductID", ProductID);
                hs.Add("ProductConditionID", ProductConditionID);

                return RubixWebAPI.ExecuteDataTable("CorrectInventory/LoadLotNo", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadZoneByItem(int OwnerID, int WarehouseID, int ProductID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ProductID", ProductID);

                return RubixWebAPI.ExecuteDataTable("CorrectInventory/LoadZoneByItem", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadDefaultUnit()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("CorrectInventory/LoadDefaultUnit");
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadAllUnitAdjust(int? ProductID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductID", ProductID);

                string strResult = RubixWebAPI.ExecuteObjectResult("CorrectInventory/LoadAllDefaultUnit", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal? GetConvertRatio(int? ConvertFrom, int ConvertTo, int? ProductID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ConvertFrom", ConvertFrom);
                hs.Add("ConvertTo", ConvertTo);
                hs.Add("ProductID", ProductID);

                string strResult = RubixWebAPI.ExecuteObjectResult("CorrectInventory/GetConvertRatio", hs);
                return JsonConvert.DeserializeObject<decimal?>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DateTime? LoadExpiryDate(String palletNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("palletNo", palletNo);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("CorrectInventory/LoadExpiryDate", hs);
                return JsonConvert.DeserializeObject<DateTime?>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

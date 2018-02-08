/*
 6 Feb 2013:
 * 1. modify method for show report after adjust inventory
 */
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

namespace CSI.Business.Operation
{
    public class CorrectInventory : CSI.Business.BusinessFactory.Report.Base.BaseReport
    {
        #region Member
        private ObjectResult<sp_ESTS010_InventoryAdjustment_SearchAll_Result> lt_Result = null;
        private sp_ESTS010_InventoryAdjustment_SearchAll_Result ta_Result = null;
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
        #endregion

        public List<sp_ESTS010_InventoryAdjustment_SearchAll_Result> DataLoading(int? OwnerID ,int? WarehouseID, string ReceivingNo, int? ProductID, string PalletNo)
        {
            try
            {
                return Database.StockEntity.sp_ESTS010_InventoryAdjustment_SearchAll(ownerID: OwnerID
                                                                                     ,warehouseID: WarehouseID
                                                                                     ,receivingNo: ReceivingNo == string.Empty ? null : ReceivingNo
                                                                                     ,productID: ProductID
                                                                                     ,palletNo: PalletNo == String.Empty ? null : PalletNo).ToList<sp_ESTS010_InventoryAdjustment_SearchAll_Result>();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public sp_ESTS000_InventoryStatusProcess_Result GetInventoryStatus(int? OwnerID, int? WarehouseID, int? ProductID, int? ProductConditionID)
        {
            try
            {
                return Database.StockEntity.sp_ESTS000_InventoryStatusProcess(ownerID: OwnerID
                                                                              , warehouseID: WarehouseID
                                                                              , productID: ProductID
                                                                              , productConditionID: ProductConditionID
                                                                              , productCode: null).SingleOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SaveStockMoveMent(int? OwnerID, int? WarehouseID, String RefSlipNo, int? ProductID, int? ProductConditionID, String iAction, decimal? iAdjustment,String PalletNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("RefSlipNo", RefSlipNo);
                hs.Add("ProductID", ProductID);
                hs.Add("ProductConditionID", ProductConditionID);
                hs.Add("Action", iAction);
                hs.Add("numQtyAdjustment", iAdjustment);
                hs.Add("PalletNo", PalletNo);
                Database.ExecuteNonQuery("sp_ESTS010_InventoryAdjustment_SaveStockMoveMent",hs);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SaveStockByLocation(int? OwnerID, int? WarehouseID, int? LocationID, int? ProductID, int? ProductConditionID, String PalletNo, decimal? iAfterAdjustment)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("LocationID", LocationID);
                hs.Add("ProductID", ProductID);
                hs.Add("ProductConditionID", ProductConditionID);
                hs.Add("PalletNo", PalletNo);
                hs.Add("QtyAfterAdjustment", iAfterAdjustment);
                Database.ExecuteNonQuery("sp_ESTS010_InventoryAdjustment_SaveStockByLocation", hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SaveStockHistory(int? OwnerID, int? WarehouseID, String RefSlipNo, int? ProductID, int? ProductConditionID, int? LocationID, String iAction, decimal? iAdjustment, decimal? iAfterAdjustment)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("RefSlipNo", RefSlipNo);
                hs.Add("ProductID", ProductID);
                hs.Add("ProductConditionID", ProductConditionID);
                hs.Add("LocationID", LocationID);
                hs.Add("Action", iAction);
                hs.Add("numQtyAdjustment", iAdjustment);
                hs.Add("numQtyAfterAdjustment", iAfterAdjustment);

                Database.ExecuteNonQuery("sp_ESTS010_InventoryAdjustment_SaveStockHistory", hs);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveData(int? OwnerID, int? WarehouseID, string ReceivingNo, int? ProductID, int? ProductConditionID,
                             int? LocationID, string LotNo, decimal? Adjustment, bool FullCapacity,
                             String PalletNo, String UpdateUser, DateTime? ExpiredDate, String CreateUser,
                             String Remark)
        {
            try
            {
                if (string.IsNullOrEmpty(PalletNo))
                {
                    PalletNo = null;
                }

                if (string.IsNullOrEmpty(ReceivingNo))
                {
                    ReceivingNo = null;
                }
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("ProductID", ProductID);
                hs.Add("ProductConditionID", ProductConditionID);
                hs.Add("numQtyAdjustment", Adjustment);
                hs.Add("LocationID", LocationID);
                hs.Add("PalletNo", PalletNo);
                hs.Add("LotNo", LotNo);
                hs.Add("FullCapacity", FullCapacity);
                hs.Add("CreateUser", CreateUser);
                ReceivingNo = Database.ExecuteScalar("sp_ESTS010_InventoryAdjustment_Save", hs).ToString();

                hs.Clear();
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("PalletNo", PalletNo);
                hs.Add("ProductID", ProductID);
                hs.Add("ProductConditionID", ProductConditionID);
                hs.Add("ExpiredDate", ExpiredDate);
                hs.Add("Remark", Remark);
                hs.Add("UpdateUser", UpdateUser);                
                Database.ExecuteNonQuery("sp_ESTS010_InventoryAdjustment_UpdateExpiredDate", hs);
            }
            catch
            {
                throw;
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

        public DataTable LoadZone(int? OwnerID, int? WarehouseID, int? Floor)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("Floor", Floor);
                return Database.ExecuteDataSet("sp_common_LoadZone", hs).Tables[0];
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
                return Database.ExecuteDataSet("sp_common_LoadRack", hs).Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public DataTable LoadLocationCode(int? ZoneID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ZoneID", ZoneID);
                return Database.ExecuteDataSet("sp_ESTS010_InventoryAdjustment_SearchLocation", hs).Tables[0];
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
                hs.Add("WarehouseID", null);
                hs.Add("ZoneID", null);
                hs.Add("RackNo", null);
                hs.Add("LocationCode", LocationCode);
                hs.Add("LocationName", null);

                return Convert.ToInt32(Database.ExecuteDataSet("sp_XMSS170_Location_SearchLocationLabel", hs).Tables[0].Rows[0]["LocationID"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistPalletNo(int? OwnerID,int? WarehouseID,int? LocationID,int? ProductID,int? ProductConditionID, String PalletNo, string LotNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("LocationID", LocationID);
                hs.Add("ProductID", ProductID);
                hs.Add("ProductConditionID", ProductConditionID);
                hs.Add("PalletNo", PalletNo);
                hs.Add("LotNo", LotNo);
                return (Database.ExecuteDataSet("sp_ESTS010_InventoryAdjustment_CheckExistPalletNo", hs).Tables[0].Rows.Count > 0);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ResetRcvNo()
        {
            try
            {
                Database.ExecuteNonQuery("sp_ESTS010_InventoryAdjustment_ResetSlipNo");
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

                return Database.ExecuteDataSet("sp_ESTS010_InventoryAdjustment_LoadLotNo", hs).Tables[0];
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

                return Database.ExecuteDataSet("sp_ESTS010_InventoryAdjustment_LoadZone", hs).Tables[0];
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
                return Database.ExecuteDataSet("sp_common_LoadDefaultLV4Unit").Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadAllDefaultUnit(int ProductID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductID", ProductID);
                return Database.ExecuteDataSet("sp_common_LoadUnit", hs).Tables[0];
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

                return DataUtil.Convert<decimal>(Database.ExecuteScalar("sp_common_ConvertRatio", hs));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public DateTime? LoadExpiryDate(String palletNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PalletNo", palletNo);

                DataSet ds = Database.ExecuteDataSet("sp_ESTS010_InventoryAdjustment_LoadExpiredDate", hs);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!String.IsNullOrEmpty(ds.Tables[0].Rows[0]["ExpiryDate"].ToString()))
                    {
                        return Convert.ToDateTime(ds.Tables[0].Rows[0]["ExpiryDate"]);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

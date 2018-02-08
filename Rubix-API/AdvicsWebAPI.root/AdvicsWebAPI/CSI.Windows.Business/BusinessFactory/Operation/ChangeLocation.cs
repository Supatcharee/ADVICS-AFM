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

namespace CSI.Business.Operation
{
    public class ChangeLocation : CSI.Business.BusinessFactory.Report.Base.BaseReport
    {
        #region Member
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

        public List<sp_ESTS020_ChangeLocation_SearchAll_Result> DataLoading(int? OwnerID, int? WarehouseID, int? Floor, int? ZoneID, int? ProductID, int? ProductConditionID, String PalletNo, String PalletNoRef, String LotNo)
        {
            try
            {
                return Database.StockEntity.sp_ESTS020_ChangeLocation_SearchAll( ownerID: OwnerID
                                                                                ,warehouseID: WarehouseID
                                                                                ,floor: Floor
                                                                                ,zoneID: ZoneID
                                                                                ,productID: ProductID
                                                                                ,conditionofProductID: ProductConditionID
                                                                                ,palletNo: string.IsNullOrWhiteSpace(PalletNo) ? null : PalletNo
                                                                                ,palletNoRef: string.IsNullOrWhiteSpace(PalletNoRef) ? null : PalletNoRef
                                                                                ,lotNo: string.IsNullOrWhiteSpace(LotNo) ? null : LotNo).ToList<sp_ESTS020_ChangeLocation_SearchAll_Result>();
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

        public String LoadLocationCode(int? WarehouseID, int? ZoneID, String RackNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ZoneID", ZoneID);
                hs.Add("RackNo", RackNo);
                hs.Add("LocationCode", null);
                hs.Add("LocationName", null);

                return Database.ExecuteDataSet("sp_XMSS170_Location_SearchLocationLabel", hs).Tables[0].Rows[0]["LocationCode"].ToString();
            }
            catch (Exception ex)
            {

                return string.Empty;
            }
        }
        
        public int? LoadLocationID(int WarehouseID, String LocationCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("WarehouseID", WarehouseID);
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

        public void SaveExpiryDate(string PalletNo, DateTime? ExpiryDate)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PalletNo", PalletNo);
                hs.Add("ExpiryDate", ExpiryDate);
                Database.ExecuteNonQuery("sp_ESTS020_ChangeLocation_SaveExpiryDate", hs);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
                
        public bool LoadFullCapacityFlag(int? WarehouseID, String LocationCode)
        {
            try
            {
                bool result;
                Hashtable hs = new Hashtable();
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ZoneID", null);
                hs.Add("RackNo", null);
                hs.Add("LocationCode", LocationCode);
                hs.Add("LocationName", null);
                DataTable dt = Database.ExecuteDataSet("sp_XMSS170_Location_SearchLocationLabel", hs).Tables[0];
                if (dt != null && dt.Rows.Count != 0)
                {
                    result = (bool)dt.Rows[0]["FullCapacityFlag"];
                }
                else
                {
                    result = false;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void SaveLocationChange(int? OwnerID, int? WarehouseID, int? ProductID, string LotNo, String PalletNo, int? ProductConditionIDFrom
                                            , int? LocationIDFrom, bool? FullCapacityFlagFrom, int? ProductConditionIDTo, int? LocationIDTo
                                            , bool? FullCapacityFlagTo, decimal? Quantity, string ChangedUser)
        {
            try
            {               
                    Hashtable hs = new Hashtable();
                    hs.Add("OwnerID", OwnerID);
                    hs.Add("WarehouseID", WarehouseID);
                    hs.Add("ProductID", ProductID);
                    hs.Add("LotNo", LotNo);
                    hs.Add("PalletNo", PalletNo);
                    hs.Add("FromProductConditionID", ProductConditionIDFrom);
                    hs.Add("FromLocationID", LocationIDFrom);
                    hs.Add("FromFullCapacityFlag", FullCapacityFlagFrom);
                    hs.Add("ToProductConditionID", ProductConditionIDTo);
                    hs.Add("ToLocationID", LocationIDTo);
                    hs.Add("ToFullCapacityFlag", FullCapacityFlagTo);
                    hs.Add("Quantity", Quantity);
                    hs.Add("ChangedDate", DateTime.Now.Date);
                    hs.Add("ChangedUser", ChangedUser);
                    Database.ExecuteNonQuery("sp_ESTS020_ChangeLocation_Save", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

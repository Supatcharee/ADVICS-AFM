using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using System.Collections;
using Rubix.Framework;
namespace CSI.Business.Master
{
    public class Zone
    {
        #region Member
        private ObjectResult<sp_XMSS120_Zone_SearchAll_Result> lt_Result = null;
        private ObjectResult<sp_XMSS120_Zone_LoadZoneCustomer_Result> lc_Result = null;
        private sp_XMSS120_Zone_SearchAll_Result ta_Result = null;
        private sp_XMSS120_Zone_LoadZoneCustomer_Result tc_Result = null;
        private BusinessCommon ims = null;

        //private sp_XMSS120_Zone_GetZoneIDForCustomer_Result Zid_Result = null;

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

        private ObjectResult<sp_XMSS120_Zone_SearchAll_Result> ResultList
        {
            get { return lt_Result; }
            set { lt_Result = value; }
        }

        private ObjectResult<sp_XMSS120_Zone_LoadZoneCustomer_Result> ResultCustomerList
        {
            get { return lc_Result; }
            set { lc_Result = value; }
        }

        public sp_XMSS120_Zone_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS120_Zone_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        
        private sp_XMSS120_Zone_LoadZoneCustomer_Result ResultCustomerData
        {
            get
            {
                if (tc_Result == null)
                {
                    tc_Result = new sp_XMSS120_Zone_LoadZoneCustomer_Result();
                }
                return tc_Result;
            }
            set { tc_Result = value; }
        }

        public Object SelectData
        {
            set { ta_Result = (sp_XMSS120_Zone_SearchAll_Result)value; }
        }

        public int ZoneID
        {
            get { return ResultData.ZoneID; }
            set { ResultData.ZoneID = value; }
        }

        public String WarehouseCode
        {
            get { return ResultData.WarehouseCode; }
            set { ResultData.WarehouseCode = value; }
        }

        public int Floor
        {
            get { return ResultData.Floor; }
            set { ResultData.Floor = value; }
        }

        public String ZoneCode
        {
            get { return ResultData.ZoneCode; }
            set { ResultData.ZoneCode = value; }
        }

        public String ZoneColor
        {
            get { return ResultData.ZoneColor; }
            set { ResultData.ZoneColor = value; }
        }

        public String ZoneName
        {
            get { return ResultData.ZoneName; }
            set { ResultData.ZoneName = value; }
        }

        public int? ZoneType
        {
            get { return ResultData.ZoneType; }
            set { ResultData.ZoneType = value; }
        }

        public DateTime CreateDate
        {
            get { return ResultData.CreateDate; }
            set { ResultData.CreateDate = value; }
        }

        public String CreateUser
        {
            get { return ResultData.CreateUser; }
            set { ResultData.CreateUser = value; }
        }

        public DateTime? UpdateDate
        {
            get { return ResultData.UpdateDate; }
            set { ResultData.UpdateDate = value; }
        }

        public String UpdateUser
        {
            get { return ResultData.UpdateUser; }
            set { ResultData.UpdateUser = value; }
        }

        // -- For Zone Customer \\
        public int ZoneIDC
        {
            get { return ResultCustomerData.ZoneID; }
            set { ResultCustomerData.ZoneID = value; }
        }

        public int CustomerIDC
        {
            get { return ResultCustomerData.CustomerID; }
            set { ResultCustomerData.CustomerID = value; }
        }

        public DateTime? CreateDateC
        {
            get { return ResultCustomerData.CreateDate; }
            set { ResultCustomerData.CreateDate = value; }
        }

        public String CreateUserC
        {
            get { return ResultCustomerData.CreateUser; }
            set { ResultCustomerData.CreateUser = value; }
        }

        public DateTime? UpdateDateC
        {
            get { return ResultCustomerData.UpdateDate; }
            set { ResultCustomerData.UpdateDate = value; }
        }

        public String UpdateUserC
        {
            get { return ResultCustomerData.UpdateUser; }
            set { ResultCustomerData.UpdateUser = value; }
        }

            #endregion

        public ObjectResult<sp_XMSS120_Zone_SearchAll_Result> DataLoading(int? OwnerID, int? WarehouseID, int? Floor, String ZoneCode, String ZoneName)
        {
            try
            {
                return Database.MasterEntity.sp_XMSS120_Zone_SearchAll(OwnerID, WarehouseID, (Floor == 0 ? null : Floor), ZoneCode == string.Empty ? null : ZoneCode, ZoneName == string.Empty ? null : ZoneName);
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public DataTable DataCustomerLoading(int ZoneID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ZoneID", ZoneID);
                return Database.ExecuteDataSet("sp_XMSS120_Zone_LoadZoneCustomer", hs).Tables[0];
            }
            catch (Exception)
            {                
                throw;
            }
        }

        public Boolean CheckExistZoneCode(String ZoneCode, int? WarehouseID, int Floor)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ZoneCode", ZoneCode);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("Floor", Floor);

                return (Database.ExecuteDataSet("sp_XMSS120_Zone_CheckExist", hs).Tables[0].Rows.Count > 0);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SaveZoneData(int? WarehouseID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ZoneID", ZoneID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("Floor", Floor);
                hs.Add("ZoneCode", ZoneCode);
                hs.Add("ZoneName", ZoneName);
                hs.Add("ZoneType", ZoneType);
                hs.Add("DeleteFlag", 0);
                hs.Add("CreateUser", CreateUser);
                hs.Add("UpdateUser", UpdateUser);
                hs.Add("ZoneColor", ZoneColor);
                Database.ExecuteNonQuery("sp_XMSS120_Zone_SaveZone",hs);                
                                                    
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SaveZoneCustomerData(string resultXML)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("xmlResult", resultXML);
                hs.Add("ZoneID", ZoneIDC);
                hs.Add("CustomerID", CustomerIDC);
                Database.ExecuteNonQuery("sp_XMSS120_Zone_SaveZoneCustomer",hs);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteZoneData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ZoneID", ZoneID);
                hs.Add("UpdateUser", UpdateUser);         
                Database.ExecuteNonQuery("sp_XMSS120_Zone_Delete",hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int? CheckReference(int? iZoneID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ZoneID", iZoneID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS120_Zone_CheckReference",hs));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

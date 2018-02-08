using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using System.Collections;
using Rubix.Framework;
using Newtonsoft.Json;
namespace CSI.Business.Master
{
    public class Zone
    {
        #region Member
        private ObjectResult<sp_XMSS120_Zone_SearchAll_Result> lt_Result = null;
        private sp_XMSS120_Zone_SearchAll_Result ta_Result = null;
        private BusinessCommon ims = null;
        #endregion

        #region Properties
        private sp_XMSS120_Zone_SearchAll_Result ResultData
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
        public Object SelectData
        {
            set { ta_Result = (sp_XMSS120_Zone_SearchAll_Result)value; }
        }
        public int ZoneID
        {
            get { return ResultData.ZoneID; }
            set { ResultData.ZoneID = value; }
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
        public String WarehouseCode
        {
            get { return ResultData.WarehouseCode; }
            set { ResultData.WarehouseCode = value; }
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
        #endregion

        public List<sp_XMSS120_Zone_SearchAll_Result> DataLoading(int? OwnerID, int? WarehouseID, int? Floor, String ZoneCode, String ZoneName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("Floor", Floor);
            hs.Add("ZoneCode", ZoneCode);
            hs.Add("ZoneName", ZoneName);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Zone/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS120_Zone_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DataCustomerLoading(int ZoneID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ZoneID", ZoneID);
                return RubixWebAPI.ExecuteDataTable("Zone/DataCustomerLoading", hs);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public Boolean CheckExistZoneCode(String ZoneCode, int? WarehouseID,int Floor)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ZoneCode", ZoneCode);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("Floor", Floor);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Zone/CheckExistZoneCode", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void SaveZoneData(int? WarehouseID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("WarehouseID", WarehouseID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("Zone/SaveZoneData", hs, JsonConvert.SerializeObject(ResultData));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void DeleteZoneData()
        {
            Hashtable hs = new Hashtable();
            hs.Add("ZoneID", ZoneID);
            hs.Add("UpdateUser", UpdateUser);

            try
            {
                RubixWebAPI.ExecuteObjectResult("Zone/DeleteZoneData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int? iZoneID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("iZoneID", iZoneID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Zone/CheckReference", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

/*
 20121224:
 * 1. Modify add paramter for UpdateUser on Delete 
 * 2. add constant section
 * 3. Modify IsDuplicatedDC function for add deleteFlag
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data;
using CSI.Business;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.Master
{
    public class Warehouse
    {     
        #region Member
        private sp_XMSS040_Warehouse_SearchAll_Result ta_Result = null; // For Select One Row
        struct WarehouseStruct
        {
            public sp_XMSS040_Warehouse_SearchAll_Result ResultData;
            public string xmlResult;
            public string xmlWorkMethod;
        }
        #endregion

        #region Constant
        private const int DELETE_FLAG_NO_DELETE = 0;
        #endregion

        #region Properties
        public sp_XMSS040_Warehouse_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS040_Warehouse_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }

        public Object SelectData
        {
            set { ta_Result = (sp_XMSS040_Warehouse_SearchAll_Result)value; }
        }  

        public int WarehouseID
        {
            get { return ResultData.WarehouseID; }
            set { ResultData.WarehouseID = value; }
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

        public String Mobile
        {
            get { return ResultData.Mobile; }
            set { ResultData.Mobile = value; }
        }

        public String PhoneNo
        {
            get { return ResultData.PhoneNo; }
            set { ResultData.PhoneNo = value; }
        }

        public String Extension
        {
            get { return ResultData.Extension; }
            set { ResultData.Extension = value; }
        }

        public String FaxNo
        {
            get { return ResultData.FaxNo; }
            set { ResultData.FaxNo = value; }
        }

        public String Address1
        {
            get { return ResultData.Address1; }
            set { ResultData.Address1 = value; }
        }

        public String Address2
        {
            get { return ResultData.Address2; }
            set { ResultData.Address2 = value; }
        }

        public String ContactName1
        {
            get { return ResultData.ContactName1; }
            set { ResultData.ContactName1 = value; }
        }

        public String ContactName2
        {
            get { return ResultData.ContactName2; }
            set { ResultData.ContactName2 = value; }
        }

        public String ContactName3
        {
            get { return ResultData.ContactName3; }
            set { ResultData.ContactName3 = value; }
        }

        public Decimal? MaxM3
        {
            get { return ResultData.MaxM3; }
            set { ResultData.MaxM3 = value; }
        }

        public Decimal? MaxM2
        {
            get { return ResultData.MaxM2; }
            set { ResultData.MaxM2 = value; }
        }

        public String Division
        {
            get { return ResultData.Division; }
            set { ResultData.Division = value; }
        }

       
        public DateTime CreateDate
        {
            get { return ResultData.CreateDate; }
            set { ResultData.CreateDate = value; }
        }

        public String InCharge
        {
            get { return ResultData.InChargeEmail; }
            set { ResultData.InChargeEmail = value; }
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

        public int? ManPower
        {
            get { return ResultData.ManPower; }
            set { ResultData.ManPower = value; }
        }

        public decimal? MaxCapacity
        {
            get { return ResultData.MaxCapacity; }
            set { ResultData.MaxCapacity = value; }
        }

        public int? MaxPallet
        {
            get { return ResultData.MaxPallet; }
            set { ResultData.MaxPallet = value; }
        }

        public int? NoOfForklift
        {
            get { return ResultData.NoOfForklift; }
            set { ResultData.NoOfForklift = value; }
        }

        public string Remark
        {
            get { return ResultData.Remark; }
            set { ResultData.Remark = value; }
        }
        #endregion

        public List<sp_XMSS040_Warehouse_SearchAll_Result> DataLoading(int? OwnerID, string WarehouseCode, string WarehouseName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseCode", WarehouseCode);
            hs.Add("WarehouseName", WarehouseName);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Warehouse/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS040_Warehouse_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadOwner(int? WarehouseID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("WarehouseID", WarehouseID);

            try
            {
                return RubixWebAPI.ExecuteDataTable("Warehouse/LoadOwner", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadWorkMethodData(int? iCustomerID, int? iDCID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", iCustomerID);
            hs.Add("WarehouseID", iDCID);

            try
            {
                return RubixWebAPI.ExecuteDataTable("Warehouse/LoadWorkMethodData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistWarehouseCode(int? WarehouseID, String WarehouseCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("WarehouseCode", WarehouseCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Warehouse/CheckExistWarehouseCode", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveWarehouseData(string xmlResult,string xmlWorkMethod)
        {
            WarehouseStruct stc;
            stc.ResultData = ResultData;
            stc.xmlResult = xmlResult;
            stc.xmlWorkMethod = xmlWorkMethod;

            try
            {
                RubixWebAPI.ExecuteObjectResult("Warehouse/SaveWarehouseData", JsonConvert.SerializeObject(stc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int? iWarehouseID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("WarehouseID", WarehouseID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Warehouse/CheckReference", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteWarehouseData(string CurrentUser)
        {
            Hashtable hs = new Hashtable();
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("CurrentUser", CurrentUser);

            try
            {
                RubixWebAPI.ExecuteObjectResult("Warehouse/DeleteWarehouseData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

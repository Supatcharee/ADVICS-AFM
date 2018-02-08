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
namespace CSI.Business.Master
{
    public class Warehouse
    {
        #region Member
        private sp_XMSS040_Warehouse_SearchByID_Result t_Result = null;
        private sp_XMSS040_Warehouse_SearchAll_Result ta_Result = null;
        private BusinessCommon ims = null;
        private BusinessCommon bc;
        #endregion

        #region Constant
        private const int DELETE_FLAG_NO_DELETE = 0;
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

        //sp_XMSS040_Warehouse_SearchByID_Result
        public sp_XMSS040_Warehouse_SearchAll_Result ResultData
        {
            get { return ta_Result; }
            set { ta_Result = value; }
        }

        //public object SetResultData
        //{
        //    set { ta_Result = (sp_XMSS040_Warehouse_SearchAll_Result)value; }
        //}
        
        public String Address1
        {
            get{return ResultData.Address1;}
            set { ResultData.Address1 = value; }
        }
        public String Address2
        {
            get { return ResultData.Address2; }
            set { ResultData.Address2 = value; }
        }

        //public String OwnerName
        //{
        //    get { return ResultData.OwnerName; }
        //    set { ResultData.OwnerName = value; }
        //}
        public String WarehouseCode
        {
            get { return (ResultData == null ? ta_Result.WarehouseCode : ResultData.WarehouseCode); }
            set { ResultData.WarehouseCode = value; }
        }
        public int WarehouseID
        {
            get { return (ResultData == null ? ta_Result.WarehouseID : ResultData.WarehouseID); }
            set { ResultData.WarehouseID = value; }
        }
        public String WarehouseName
        {
            get { return (ResultData == null ? ta_Result.WarehouseName : ResultData.WarehouseName); }
            set { ResultData.WarehouseName = value; }
        }
        public String CreateUser
        {
            get { return ResultData.CreateUser; }
            set { ResultData.CreateUser = value; }
        }
        public String Division
        {
            get { return ResultData.Division; }
            set { ResultData.Division = value; }
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
        public String PhoneNo
        {
            get { return ResultData.PhoneNo; }
            set { ResultData.PhoneNo = value; }
        }
        public String UpdateUser
        {
            get { return ResultData.UpdateUser; }
            set { ResultData.UpdateUser = value; }
        }
        public String MobileNo
        {
            get { return ResultData.Mobile; }
            set { ResultData.Mobile = value; }
        }
        
        //
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
        public decimal? MaxM3
        {
            get { return ResultData.MaxM3; }
            set { ResultData.MaxM3 = value; }
        }
        public decimal? MaxM2
        {
            get { return ResultData.MaxM2; }
            set { ResultData.MaxM2 = value; }
        }
        public int? MaxPallet
        {
            get { return ResultData.MaxPallet; }
            set { ResultData.MaxPallet = value; }
        }
        public decimal? MaxCapacity
        {
            get { return ResultData.MaxCapacity; }
            set { ResultData.MaxCapacity = value; }
        }
        public int? NoOfForklift
        {
            get { return ResultData.NoOfForklift; }
            set { ResultData.NoOfForklift = value; }
        }
        public int? ManPower
        {
            get { return ResultData.ManPower; }
            set { ResultData.ManPower = value; }
        }
        public String Remark
        {
            get { return ResultData.Remark; }
            set { ResultData.Remark = value; }
        }
        public String InChargeEmail
        {
            get { return ResultData.InChargeEmail; }
            set { ResultData.InChargeEmail = value; }
        }


        //public String WarehouseShortName
        //{
        //    get { return ResultData.WarehouseShortName; }
        //    set { ResultData.WarehouseShortName = value; }
        //}
        
        #endregion

        public ObjectResult<sp_XMSS040_Warehouse_SearchAll_Result> DataLoading(int? OwnerID, string WarehouseCode, string WarehouseName)
        {
            try
            {
                return Database.MasterEntity.sp_XMSS040_Warehouse_SearchAll(ownerID: OwnerID, warehouseCode: (WarehouseCode == string.Empty ? null : WarehouseCode), warehouseName: (WarehouseName == string.Empty ? null : WarehouseName));

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
                
        //public void SearchByID(int iCustomerID, int iWarehouseID)
        //{
        //    ResultData = Database.MasterEntity.sp_XMSS040_Warehouse_SearchByID(customerID: iCustomerID, warehouseID:iWarehouseID).First();
        //}

        public DataTable LoadWorkMethodData(int? OwnerID, int? WarehouseID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                return Database.ExecuteDataSet("sp_XMSS040_LoadWorkMethodSetting", hs).Tables[0];
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable LoadOwner(int? WarehouseID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("WarehouseID", WarehouseID);
                return Database.ExecuteDataSet("sp_XMSS040_Warehouse_LoadOwner", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistWarehouseCode(int? WarehouseID,String WarehouseCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("WarehouseCode", WarehouseCode);

                return (Database.ExecuteDataSet("sp_XMSS040_Warehouse_CheckExist", hs).Tables[0].Rows.Count > 0);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SaveWarehousData(string xmlResult, string xmlWorkMethod)
        {
            try
            {
                int DivisionAdd = 0;
                if (Division == "Internal")
                {
                    DivisionAdd = 0;
                }
                else if (Division == "External")
                {
                    DivisionAdd = 1;
                }

                Hashtable hs = new Hashtable();
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("WarehouseCode", WarehouseCode);
                hs.Add("WarehouseName", WarehouseName);
                hs.Add("MobileNo", MobileNo);
                hs.Add("PhoneNo", PhoneNo);
                hs.Add("Extension", Extension);
                hs.Add("FaxNo", FaxNo);
                hs.Add("Address1", Address1);
                hs.Add("Address2", Address2);
                hs.Add("ContactName1", ContactName1);
                hs.Add("ContactName2", ContactName2);
                hs.Add("ContactName3", ContactName3);
                hs.Add("MaxM3", MaxM3);
                hs.Add("MaxM2", MaxM2);
                hs.Add("ExternalDivisionFlag", DivisionAdd);
                hs.Add("CreateUser", CreateUser);
                hs.Add("MaxPallet", MaxPallet);
                hs.Add("MaxCapacity", MaxCapacity);
                hs.Add("NoOfForklift", NoOfForklift);
                hs.Add("ManPower", ManPower);
                hs.Add("Remark", Remark);
                hs.Add("xmlResult", xmlResult);
                hs.Add("xmlWorkMethod", xmlWorkMethod);
                hs.Add("InChargeEmail", InChargeEmail);

                Database.ExecuteNonQuery("sp_XMSS040_Warehouse_Save", hs);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int? CheckReference(int? WarehouseID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("WarehouseID", WarehouseID);

                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS040_Warehouse_CheckReference", hs));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteWarehouseData(String CurrentUser, int WarehouseID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("CurrentUser", CurrentUser);

                Database.ExecuteNonQuery("sp_XMSS040_Warehouse_Delete", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

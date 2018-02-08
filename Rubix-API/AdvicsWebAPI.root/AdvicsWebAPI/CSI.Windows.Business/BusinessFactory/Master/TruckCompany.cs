using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
namespace CSI.Business.Master
{
    public class TruckCompany
    {
        #region Member
        private ObjectResult<sp_XMSS020_TruckCompany_SearchAll_Result> lt_Result = null;
        private ObjectResult<sp_XMSS021_TruckTransportTypeMapping_SearchAll_Result> t_Result = null;
        private sp_XMSS020_TruckCompany_SearchAll_Result ta_Result = null;
        private BusinessCommon ims = null;
        private BusinessCommon bc;
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

        private ObjectResult<sp_XMSS020_TruckCompany_SearchAll_Result> ResultList
        {
            get { return lt_Result; }
            set { lt_Result = value; }
        }
        public sp_XMSS020_TruckCompany_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS020_TruckCompany_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        private ObjectResult<sp_XMSS021_TruckTransportTypeMapping_SearchAll_Result> TruckTypeList
        {
            get { return t_Result; }
            set { t_Result = value; }
        }
        private BusinessCommon ConnectionString
        {
            get
            {
                if (bc == null)
                {
                    bc = new BusinessCommon();
                }
                return bc;
            }
        }

        public Object SelectData
        {
            set { ta_Result = (sp_XMSS020_TruckCompany_SearchAll_Result)value; }
        }
        public int TruckCompanyID
        {
            get { return ResultData.TruckCompanyID; }
            set { ResultData.TruckCompanyID = value; }
        }
        public String TruckCompanyCode
        {
            get { return ResultData.TruckCompanyCode; }
            set { ResultData.TruckCompanyCode = value; }
        }
        public String TruckCompanyLongName
        {
            get { return ResultData.TruckCompanyName; }
            set { ResultData.TruckCompanyName = value; }
        }   
        public String TruckCompanyAddress
        {
            get { return ResultData.TruckCompanyAddress; }
            set { ResultData.TruckCompanyAddress = value; }
        }
        public String MobileNo
        {
            get { return ResultData.MobileNo; }
            set { ResultData.MobileNo = value; }
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
        public bool? IsSystem
        {
            get { return ResultData.IsSystem; }
            set { ResultData.IsSystem = value; }
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

        public ObjectResult<sp_XMSS020_TruckCompany_SearchAll_Result> DataLoading(String TruckCompanyCode, String TruckCompanyName)
        {
            try
            {
                return Database.MasterEntity.sp_XMSS020_TruckCompany_SearchAll(truckCompanyCode: (TruckCompanyCode == String.Empty ? null : TruckCompanyCode), truckCompanyName: (TruckCompanyName == String.Empty ? null : TruckCompanyName));

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public Boolean CheckExistTruckCompanyCode(String TruckCompanyCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("TruckCompanyCode", TruckCompanyCode);
                return (Database.ExecuteDataSet("sp_XMSS020_TruckCompany_CheckExist", hs).Tables[0].Rows.Count > 0);  
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SaveTruckCompanyData(string resultXML)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("TruckCompanyID", TruckCompanyID);
                hs.Add("TruckCompanyCode", TruckCompanyCode);
                hs.Add("TruckCompanyLongName", TruckCompanyLongName);
                hs.Add("TruckCompanyAddress", TruckCompanyAddress);
                hs.Add("MobileNo", MobileNo);
                hs.Add("PhoneNo", PhoneNo);
                hs.Add("Extension", Extension);
                hs.Add("FaxNo", FaxNo);
                hs.Add("ContactName1", ContactName1);
                hs.Add("ContactName2", ContactName2);
                hs.Add("ContactName3", ContactName3);
                hs.Add("CreateUser", CreateUser);
                hs.Add("xmlResult", resultXML);

                Database.ExecuteNonQuery("sp_XMSS020_TruckCompany_Save",hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteTruckCompanyData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("TruckCompanyID",TruckCompanyID);
                Database.ExecuteNonQuery("sp_XMSS020_TruckCompany_Delete",hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ObjectResult<sp_XMSS021_TruckTransportTypeMapping_SearchAll_Result> TruckTypeMappingLoad(int? TruckCompanyID)
        {
            try
            {
                return Database.MasterEntity.sp_XMSS021_TruckTransportTypeMapping_SearchAll(truckCompanyID: TruckCompanyID);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable LoadTruckTransportTypeData(int? pTruckCompanyID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("TruckCompanyID", pTruckCompanyID);
                return Database.ExecuteDataSet("sp_XMSS021_TruckTransportTypeMapping_SearchAll", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public int? CheckReference(int? iTruckCompanyID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("TruckCompanyID", iTruckCompanyID);

                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS020_TruckCompany_CheckReference",hs));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public tbm_TransportType GetTransportType(int transportTypeID)
        {
            try
            {
                return Database.MasterEntity.tbm_TransportType.Where(c => c.TransportTypeID == transportTypeID).FirstOrDefault();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}

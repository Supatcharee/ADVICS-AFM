using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Newtonsoft.Json;
namespace CSI.Business.Master
{
    public class TruckCompany
    {
        #region Member
        private sp_XMSS020_TruckCompany_SearchAll_Result ta_Result = null;
        struct TruckCompanyStruct
        {
            public sp_XMSS020_TruckCompany_SearchAll_Result ResultData;
            public string XML;
        }
        #endregion

        #region Properties
        private sp_XMSS020_TruckCompany_SearchAll_Result ResultData
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

        public List<sp_XMSS020_TruckCompany_SearchAll_Result> DataLoading(String TruckCompanyCode, String TruckCompanyName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("TruckCompanyCode", TruckCompanyCode);
            hs.Add("TruckCompanyName", TruckCompanyName);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("TruckCompany/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS020_TruckCompany_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistTruckCompanyCode(String TruckCompanyCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("TruckCompanyCode", TruckCompanyCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("TruckCompany/CheckExistTruckCompanyCode", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveTruckCompanyData(string resultXML)
        {
            TruckCompanyStruct stc;
            stc.ResultData = ResultData;
            stc.XML = resultXML;

            try
            {
                RubixWebAPI.ExecuteObjectResult("TruckCompany/SaveTruckCompanyData", JsonConvert.SerializeObject(stc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteTruckCompanyData()
        {
            Hashtable hs = new Hashtable();
            hs.Add("TruckCompanyID", TruckCompanyID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("TruckCompany/DeleteTruckCompanyData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_XMSS021_TruckTransportTypeMapping_SearchAll_Result> TruckTypeMappingLoad(int? TruckCompanyID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("TruckCompanyID", TruckCompanyID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("TruckCompany/TruckTypeMappingLoad", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS021_TruckTransportTypeMapping_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadTruckTransportTypeData(int? TruckCompanyID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("TruckCompanyID", TruckCompanyID);
                return RubixWebAPI.ExecuteDataTable("TruckCompany/LoadTruckTransportTypeData", hs);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        
        public int? CheckReference(int? TruckCompanyID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("TruckCompanyID", TruckCompanyID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("TruckCompany/CheckReference", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tbm_TransportType GetTransportType(int transportTypeID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("transportTypeID", transportTypeID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("TruckCompany/GetTransportType", hs);
                return JsonConvert.DeserializeObject<tbm_TransportType>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

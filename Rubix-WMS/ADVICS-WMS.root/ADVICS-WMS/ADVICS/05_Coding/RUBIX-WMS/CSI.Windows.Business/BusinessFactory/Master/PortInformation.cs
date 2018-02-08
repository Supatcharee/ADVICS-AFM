using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.Master
{
    public class PortInformation
    {
        #region Member
        int portID = 0;
        private sp_XMSS090_Port_SearchAll_Result ta_Result = null;
        private sp_XMSS090_Port_LoadPortOwner_Result tc_Result = null;
        struct PortInformationStruct
        {
            public sp_XMSS090_Port_SearchAll_Result ResultData;
            public string resultXML;
        }
        #endregion

        #region Properties
        private sp_XMSS090_Port_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS090_Port_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        private sp_XMSS090_Port_LoadPortOwner_Result ResultOwnerData
        {
            get
            {
                if (tc_Result == null)
                {
                    tc_Result = new sp_XMSS090_Port_LoadPortOwner_Result();
                }
                return tc_Result;
            }
            set { tc_Result = value; }
        }
        public Object SelectData
        {
            set { ta_Result = (sp_XMSS090_Port_SearchAll_Result)value; }
        }        
        public int PortID
        {
            get { return ResultData.PortID; }
            set { ResultData.PortID = value; }
        }
        public String PortCode
        {
            get { return ResultData.PortCode; }
            set { ResultData.PortCode = value; }
        }
        public String PortLongName
        {
            get { return ResultData.PortLongName; }
            set { ResultData.PortLongName = value; }
        }
        public int PortClassification
        {
            get { return ResultData.PortClassification; }
            set { ResultData.PortClassification = value; }
        }
        public String CountryCode
        {
            get { return ResultData.CountryCode; }
            set { ResultData.CountryCode = value; }
        }
        public int? LeadTimeDays
        {
            get { return ResultData.LeadTimeDays; }
            set { ResultData.LeadTimeDays = value; }
        }
        public String LeadTimeHr
        {
            get { return ResultData.LeadTimeHr; }
            set { ResultData.LeadTimeHr = value; }
        }
        public String PortAddress
        {
            get { return ResultData.PortAddress; }
            set { ResultData.PortAddress = value; }
        }
        public String PostalCode
        {
            get { return ResultData.PostalCode; }
            set { ResultData.PostalCode = value; }
        }
        public String Remark
        {
            get { return ResultData.Remark; }
            set { ResultData.Remark = value; }
        }
        public decimal? Freight
        {
            get { return ResultData.Freight; }
            set { ResultData.Freight = value; }
        }
        public int? CurrencyID
        {
            get { return ResultData.CurrencyID; }
            set { ResultData.CurrencyID = value; }
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

               // -- For Port Customer \\
        public int PortCusID
        {
            get { return ResultOwnerData.PortID; }
            set { ResultOwnerData.PortID = value; }
        }
        public int OwnerID
        {
            get { return ResultOwnerData.OwnerID; }
            set { ResultOwnerData.OwnerID = value; }
        }
        public String OwnerCode
        {
            get { return ResultOwnerData.OwnerCode; }
            set { ResultOwnerData.OwnerCode = value; }
        }
        public String OwnerName
        {
            get { return ResultOwnerData.OwnerName; }
            set { ResultOwnerData.OwnerName = value; }
        }
        #endregion

        public List<sp_XMSS090_Port_SearchAll_Result> DataLoading(int? OwnerID,String PortCode, String PortName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID",  OwnerID);
            hs.Add("PortCode", PortCode);
            hs.Add("PortName", PortName);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PortInformation/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS090_Port_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // List<sp_XMSS090_Port_LoadPortOwner_Result> Change to DataTable
        

        public Boolean CheckExistPortCode(String PortCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PortCode", PortCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PortInformation/CheckExistPortCode", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SavePortData(string resultXML)
        {
            PortInformationStruct stc;
            stc.ResultData = ResultData;
            stc.resultXML = resultXML;

            try
            {
                RubixWebAPI.ExecuteObjectResult("PortInformation/SavePortData", JsonConvert.SerializeObject(stc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SavePortCustomerData()
        {
            Hashtable hs = new Hashtable();
            hs.Add("PortCode", PortCode);
            hs.Add("OwnerID", OwnerID);
            hs.Add("CreateUser", CreateUser);

            try
            {
                RubixWebAPI.ExecuteObjectResult("PortInformation/SavePortCustomerData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletePortData()
        {
            Hashtable hs = new Hashtable();
            hs.Add("PortID", PortID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("PortInformation/DeletePortData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<sp_XMSS090_LoadPortClassification_Result> LoadPortClassification()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PortInformation/LoadPortClassification");
                return JsonConvert.DeserializeObject<List<sp_XMSS090_LoadPortClassification_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveCustomerData(string resultXML)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PortID", portID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("PortInformation/SaveCustomerData", hs, resultXML);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadCustomerData(int? portID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("portID", portID);

            try
            {
                return RubixWebAPI.ExecuteDataTable("PortInformation/LoadCustomerData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int? iPortID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("iPortID", iPortID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PortInformation/CheckReference", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
    

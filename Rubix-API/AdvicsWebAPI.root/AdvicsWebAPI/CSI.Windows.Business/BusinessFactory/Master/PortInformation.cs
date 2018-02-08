using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using System.Collections;

namespace CSI.Business.Master
{
    public class PortInformation
    {
        #region Member
        int portID = 0;
        private sp_XMSS090_Port_SearchAll_Result ta_Result = null;
        private sp_XMSS090_Port_LoadPortOwner_Result tc_Result = null;
        private BusinessCommon ims = null;
        private List<sp_XMSS090_LoadPortClassification_Result> _listPort = null;
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
        public sp_XMSS090_Port_SearchAll_Result ResultData
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
        private sp_XMSS090_Port_LoadPortOwner_Result ResultCustomerData
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
            get { return ResultCustomerData.PortID; }
            set { ResultCustomerData.PortID = value; }
        }
        public int OwnerID
        {
            get { return ResultCustomerData.OwnerID; }
            set { ResultCustomerData.OwnerID = value; }
        }
        public String OwnerCode
        {
            get { return ResultCustomerData.OwnerCode; }
            set { ResultCustomerData.OwnerCode = value; }
        }
        public String OwnerName
        {
            get { return ResultCustomerData.OwnerName; }
            set { ResultCustomerData.OwnerName = value; }
        }
        #endregion

        public ObjectResult<sp_XMSS090_Port_SearchAll_Result> DataLoading(int? OwnerID, String PortCode, String PortName)
        {
            try
            {
                return Database.MasterEntity.sp_XMSS090_Port_SearchAll(OwnerID, PortCode == string.Empty ? null : PortCode, PortName == string.Empty ? null : PortName);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public Boolean CheckExistPortCode(String PortCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PortCode", PortCode);

                return (Database.ExecuteDataSet("sp_XMSS090_Port_CheckExist", hs).Tables[0].Rows.Count > 0);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SavePortData(string resultXML)
        {
            
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PortID", PortID);
                hs.Add("PortCode", PortCode);
                hs.Add("PortLongName", PortLongName);
                hs.Add("PortClassification", PortClassification);
                hs.Add("CountryCode", CountryCode);
                hs.Add("LeadTimeDays", LeadTimeDays);
                hs.Add("LeadTimeHr", LeadTimeHr);
                hs.Add("PortAddress", PortAddress);
                hs.Add("PostalCode", PostalCode);
                hs.Add("Remark", Remark);
                hs.Add("Freight", Freight);
                hs.Add("CurrencyID", CurrencyID);
                hs.Add("CreateUser", CreateUser);
                hs.Add("xmlResult", resultXML);

                Database.ExecuteNonQuery("sp_XMSS090_Port_Save",hs);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SavePortCustomerData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PortCode", PortCode);
                hs.Add("OwnerID", OwnerID);
                hs.Add("CreateUser", CreateUser);
                Database.ExecuteNonQuery("sp_XMSS090_Port_SavePortCustomer",hs);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeletePortData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PortID", PortID);
                Database.ExecuteNonQuery("sp_XMSS090_Port_Delete",hs);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public List<sp_XMSS090_LoadPortClassification_Result> LoadPortClassification()
        {
            if (_listPort == null)
                _listPort = Database.MasterEntity.sp_XMSS090_LoadPortClassification().ToList<sp_XMSS090_LoadPortClassification_Result>();

            return _listPort;
        }

        public void SaveCustomerData(string resultXML)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("xmlResult", resultXML);
                hs.Add("PortID", portID);
                Database.ExecuteNonQuery("sp_XMSS090_Port_SaveCustomer",hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable LoadCustomerData(int? portID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PortID", portID);
                return Database.ExecuteDataSet("sp_XMSS090_Port_LoadPortOwner", hs).Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int? CheckReference(int? iPortID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PortID", iPortID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS090_Port_CheckReference",hs));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
    

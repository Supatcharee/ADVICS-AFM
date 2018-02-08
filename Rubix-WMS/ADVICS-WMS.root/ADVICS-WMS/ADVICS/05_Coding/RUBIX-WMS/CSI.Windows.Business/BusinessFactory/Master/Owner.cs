using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
using Newtonsoft.Json;
namespace CSI.Business.Master
{
    public class Owner
    {
        #region Member
        private sp_XMSS010_Owner_SearchAll_Result ta_Result = null;     
        #endregion

        #region Properties
        public sp_XMSS010_Owner_SearchAll_Result ResultData
        {
            get 
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS010_Owner_SearchAll_Result();
                }
                return ta_Result; 
            }
            set { ta_Result = value; }
        }

        public Object SelectData
        {
            set { ta_Result = (sp_XMSS010_Owner_SearchAll_Result)value; }
        }

        public int OwnerID
        {
            get { return ResultData.OwnerID; }
            set { ResultData.OwnerID = value; }
        }
        public String OwnerCode
        {
            get { return ResultData.OwnerCode; }
            set { ResultData.OwnerCode = value; }
        }
        public String OwnerName
        {
            get { return ResultData.OwnerName; }
            set { ResultData.OwnerName = value; }
        }
        public String BusinessType
        {
            get { return ResultData.BusinessType; }
            set { ResultData.BusinessType = value; }
        }
        public String Address
        {
            get { return ResultData.Address; }
            set { ResultData.Address = value; }
        }
        public String City
        {
            get { return ResultData.City; }
            set { ResultData.City = value; }
        }
        public String StateOrProvince
        {
            get { return ResultData.StateOrProvince; }
            set { ResultData.StateOrProvince = value; }
        }
        public String PostalCode
        {
            get { return ResultData.PostalCode; }
            set { ResultData.PostalCode = value; }
        }        
        public String Country
        {
            get { return ResultData.Country; }
            set { ResultData.Country = value; }
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
        public String MobileNo
        {
            get { return ResultData.MobileNo; }
            set { ResultData.MobileNo = value; }
        }      
        public String FaxNo
        {
            get { return ResultData.FaxNo; }
            set { ResultData.FaxNo = value; }
        } 
        public String EmailAddress
        {
            get { return ResultData.EmailAddress; }
            set { ResultData.EmailAddress = value; }
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
        public String CreateUser
        {
            get { return ResultData.CreateUser; }
            set { ResultData.CreateUser = value; }
        }
        public DateTime CreateDate
        {
            get { return ResultData.CreateDate; }
            set { ResultData.CreateDate = value; }
        }
        public String UpdateUser
        {
            get { return ResultData.UpdateUser; }
            set { ResultData.UpdateUser = value; }
        }
        public DateTime? UpdateDate
        {
            get { return ResultData.UpdateDate; }
            set { ResultData.UpdateDate = value; }
        }
        public String DefaultReceivingDate
        {
            get { return ResultData.DefaultReceivingDate; }
            set { ResultData.DefaultReceivingDate = value; }

        }
        public int? DefaultReceivingDateType
        {
            get { return ResultData.DefaultReceivingDateType; }
            set { ResultData.DefaultReceivingDateType = value; }

        }
        public int? LimitCapacity
        {
            get { return ResultData.LimitCapacity; }
            set { ResultData.LimitCapacity = value; }

        }

        public String BankAccount
        {
            get { return ResultData.BankAccount; }
            set { ResultData.BankAccount = value; }
        }
        #endregion

        public List<sp_XMSS010_Owner_SearchAll_Result> DataLoading(String OwnerCode, String OwnerName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerCode", OwnerCode);
            hs.Add("OwnerName", OwnerName);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Owner/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS010_Owner_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistOwnerCode(int? OwnerID, String OwnerCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("OwnerCode", OwnerCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Owner/CheckExistOwnerCode", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }    
        }

        public void SaveOwnerData()
        {
            try
            {
                RubixWebAPI.ExecuteObjectResult("Owner/SaveOwnerData", JsonConvert.SerializeObject(ResultData));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteOwnerData()
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("Owner/DeleteOwnerData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int? OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Owner/CheckReference", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

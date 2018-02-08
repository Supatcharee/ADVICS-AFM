using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
namespace CSI.Business.Master
{
    public class Owner
    {
        #region Member
        private sp_XMSS010_Owner_SearchAll_Result ta_Result = null;
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

        public ObjectResult<sp_XMSS010_Owner_SearchAll_Result> DataLoading(String OwnerCode, String OwnerName)
        {
            try
            {
                return Database.MasterEntity.sp_XMSS010_Owner_SearchAll(ownerCode: (OwnerCode == String.Empty ? null : OwnerCode), ownerName: (OwnerName == String.Empty ? null : OwnerName));
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public Boolean CheckExistOwnerCode(int? OwnerID, String OwnerCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("OwnerCode", OwnerCode);
                return (Database.ExecuteDataSet("sp_XMSS010_Owner_CheckExist", hs).Tables[0].Rows.Count > 0);
                
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
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("OwnerCode", OwnerCode);
                hs.Add("OwnerName", OwnerName);
                hs.Add("BusinessType", BusinessType);
                hs.Add("Address", Address);
                hs.Add("City", City);
                hs.Add("StateOrProvince", StateOrProvince);
                hs.Add("PostalCode", PostalCode);
                hs.Add("Country", Country);
                hs.Add("MobileNo", MobileNo);
                hs.Add("PhoneNo", PhoneNo);
                hs.Add("Extension", Extension);
                hs.Add("FaxNo", FaxNo);
                hs.Add("EmailAddress", EmailAddress);
                hs.Add("ContactName1", ContactName1);
                hs.Add("ContactName2", ContactName2);
                hs.Add("ContactName3", ContactName3);
                hs.Add("CreateUser", CreateUser);
                hs.Add("DefaultReceivingDateType", DefaultReceivingDateType);
                hs.Add("LimitCapacity", LimitCapacity);
                hs.Add("BankAccount", BankAccount);

                Database.ExecuteNonQuery("sp_XMSS010_Owner_Save", hs);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void DeleteOwnerData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                Database.ExecuteNonQuery("sp_XMSS010_Owner_Delete", hs);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public int? CheckReference()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS010_Owner_CheckReference", hs));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

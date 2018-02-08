using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;

namespace CSI.Business.Master
{
    public class Supplier
    {
        #region Member
        private sp_XMSS030_Supplier_SearchAll_Result ta_Result = null;
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
        public sp_XMSS030_Supplier_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS030_Supplier_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        public Object SelectData
        {
            set { ta_Result = (sp_XMSS030_Supplier_SearchAll_Result)value; }
        }
        public int SupplierID
        {
            get { return ResultData.SupplierID; }
            set { ResultData.SupplierID = value; }
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
        public String SupplierCode
        {
            get { return ResultData.SupplierCode; }
            set { ResultData.SupplierCode = value; }
        }
        public String SupplierLongName
        {
            get { return ResultData.SupplierName; }
            set { ResultData.SupplierName = value; }
        }
        public String SupplierAddress1
        {
            get { return ResultData.SupplierAddress1; }
            set { ResultData.SupplierAddress1 = value; }
        }
        public String SupplierAddress2
        {
            get { return ResultData.SupplierAddress2; }
            set { ResultData.SupplierAddress2 = value; }
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
        public String Country
        {
            get { return ResultData.Country; }
            set { ResultData.Country = value; }
        }
        public bool Monday
        {
            get { return ResultData.Monday; }
            set { ResultData.Monday = value; }
        }
        public bool Tuesday
        {
            get { return ResultData.Tuesday; }
            set { ResultData.Tuesday = value; }
        }
        public bool Wednesday
        {
            get { return ResultData.Wednesday; }
            set { ResultData.Wednesday = value; }
        }
        public bool Thursday
        {
            get { return ResultData.Thursday; }
            set { ResultData.Thursday = value; }
        }
        public bool Friday
        {
            get { return ResultData.Friday; }
            set { ResultData.Friday = value; }
        }
        public bool Saturday
        {
            get { return ResultData.Saturday; }
            set { ResultData.Saturday = value; }
        }
        public bool Sunday
        {
            get { return ResultData.Sunday; }
            set { ResultData.Sunday = value; }
        }
        
        public String PostalCode
        {
            get { return ResultData.PostalCode; }
            set { ResultData.PostalCode = value; }
        }
        public int? KM
        {
            get { return ResultData.KM; }
            set { ResultData.KM = value; }
        }

        public int? AdvLeadTime
        {
            get { return ResultData.AdvLeadTime; }
            set { ResultData.AdvLeadTime = value; }
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

        public String SupplierNo
        {
            get { return ResultData.SupplierNo; }
            set { ResultData.SupplierNo = value; }
        }
        public int ArrivalLeadTime
        {
            get { return ResultData.ArrivalLeadTime; }
            set { ResultData.ArrivalLeadTime = value; }
        }
         public TimeSpan ArrivalTime
        {
            get { return ResultData.ArrivalTime; }
            set { ResultData.ArrivalTime = value; }
        }     
        public TimeSpan CollectTime
        {
            get { return ResultData.CollectTime; }
            set { ResultData.CollectTime = value; }
        }
        public String CreditTerm
        {
            get { return ResultData.CreditTerm; }
            set { ResultData.CreditTerm = value; }
        }
        public String DeliveryPlace
        {
            get { return ResultData.DeliveryPlace; }
            set { ResultData.DeliveryPlace = value; }
        }
        public decimal? VAT
        {
            get { return ResultData.VAT; }
            set { ResultData.VAT = value; }
        }
        public bool isCalVat
        {
            get { return ResultData.isCalVAT; }
            set { ResultData.isCalVAT = value; }
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
        #endregion

        public ObjectResult<sp_XMSS030_Supplier_SearchAll_Result> DataLoading(String SupplierCode, String SupplierName, int? OwnerID)
        {
            try
            {
                return Database.MasterEntity.sp_XMSS030_Supplier_SearchAll(supplierCode: (SupplierCode == String.Empty ? null : SupplierCode), supplierName: (SupplierName == String.Empty ? null : SupplierName), ownerID: OwnerID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Boolean CheckExistSupplierCode(int? SupplierID, String SupplierCode, int? OwnerID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("SupplierID", SupplierID);
                hs.Add("SupplierCode", SupplierCode);
                hs.Add("OwnerID", OwnerID);
                return (Database.ExecuteDataSet("sp_XMSS030_Supplier_CheckExist", hs).Tables[0].Rows.Count > 0);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SaveSupplierData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("SupplierID", SupplierID);
                hs.Add("OwnerID", OwnerID);
                hs.Add("SupplierCode", SupplierCode);
                hs.Add("SupplierLongName", SupplierLongName);
                hs.Add("SupplierAddress1", SupplierAddress1);
                hs.Add("SupplierAddress2", SupplierAddress2);
                hs.Add("City", City);
                hs.Add("StateOrProvince", StateOrProvince);
                hs.Add("PostalCode", PostalCode);
                hs.Add("Country", Country);
                hs.Add("KM", KM);
                hs.Add("MobileNo", MobileNo);
                hs.Add("PhoneNo", PhoneNo);
                hs.Add("Extension", Extension);
                hs.Add("FaxNo", FaxNo);
                hs.Add("EmailAddress", EmailAddress);
                hs.Add("ContactName1", ContactName1);
                hs.Add("ContactName2",ContactName2);
                hs.Add("ContactName3",ContactName3);
                hs.Add("SupplierNo", SupplierNo);
                hs.Add("ArrivalLeadTime", ArrivalLeadTime);
                hs.Add("ArrivalTime", ArrivalTime);
                hs.Add("CollectTime", CollectTime);
                hs.Add("CreditTerm", CreditTerm);
                hs.Add("DeliveryPlace", DeliveryPlace);
                hs.Add("isCalVat", isCalVat);
                hs.Add("VAT", VAT);
                hs.Add("CreateUser",CreateUser);
                hs.Add("Monday", Monday);
                hs.Add("Tuesday", Tuesday);
                hs.Add("Wednesday", Wednesday);
                hs.Add("Thursday", Thursday);
                hs.Add("Friday", Friday);
                hs.Add("Saturday", Saturday);
                hs.Add("Sunday", Sunday);
                hs.Add("AdvLeadTime", AdvLeadTime);
                Database.ExecuteNonQuery("sp_XMSS030_Supplier_Save",hs);                                                           
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteSupplierData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("SupplierID", SupplierID);
                Database.ExecuteNonQuery("sp_XMSS030_Supplier_Delete",hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int? iSupplierID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("SupplierID", iSupplierID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS030_Supplier_CheckReference",hs));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using Newtonsoft.Json;

namespace CSI.Business.Master
{
    public class Customer
    {
        #region Member
        private sp_XMSS270_Customer_SearchAll_Result ta_Result = null;
        struct CustomerStruct
        {
            public sp_XMSS270_Customer_SearchAll_Result ResultData;
            public string OwnerXML;
            //public string PrivilegeXML;
        }
        #endregion

        #region Properties
        public sp_XMSS270_Customer_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS270_Customer_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        public Object SelectData
        {
            set { ta_Result = (sp_XMSS270_Customer_SearchAll_Result)value; }
        }
        public int? OwnerID
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
        public int CustomerID
        {
            get { return ResultData.CustomerID; }
            set { ResultData.CustomerID = value; }
        }
        public String CustomerCode
        {
            get { return ResultData.CustomerCode; }
            set { ResultData.CustomerCode = value; }
        }
        public String CustomerName
        {
            get { return ResultData.CustomerName; }
            set { ResultData.CustomerName = value; }
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
        public String Accountee
        {
            get { return ResultData.Accountee; }
            set { ResultData.Accountee = value; }
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
        public bool IsCalVat
        {
            get { return ResultData.IsCalVAT; }
            set { ResultData.IsCalVAT = value; }
        }
        public int? IsSpecial
        {
            get { return ResultData.Is_Special; }
            set { ResultData.Is_Special = value; }
        }
        public decimal? Vat
        {
            get { return ResultData.VAT; }
            set { ResultData.VAT = value; }
        }
        public decimal? Insurance
        {
            get { return ResultData.Insurance; }
            set { ResultData.Insurance = value; }
        }
        public decimal? Freight
        {
            get { return ResultData.Freight; }
            set { ResultData.Freight = value; }
        }
        public String PaymentTerm
        {
            get { return ResultData.PaymentTerm; }
            set { ResultData.PaymentTerm = value; }
        }
        public int? PickingLeadTime
        {
            get { return ResultData.PickingLeadTime; }
            set { ResultData.PickingLeadTime = value; }
        }
        public int? PackingLeadTime
        {
            get { return ResultData.PackingLeadTime; }
            set { ResultData.PackingLeadTime = value; }
        }
        public int? TransportLeadTime
        {
            get { return ResultData.TransportLeadTime; }
            set { ResultData.TransportLeadTime = value; }
        }
        public String InvoiceType
        {
            get { return ResultData.InvoiceType; }
            set { ResultData.InvoiceType = value; }
        }
        public String Remark
        {
            get { return ResultData.Remark; }
            set { ResultData.Remark = value; }
        }
        public int? CopyInvoice
        {
            get { return ResultData.CopyInvoice; }
            set { ResultData.CopyInvoice = value; }
        }
        public int? CopyPackList
        {
            get { return ResultData.CopyPackList; }
            set { ResultData.CopyPackList = value; }
        }
        public int? CopyM3
        {
            get { return ResultData.CopyM3; }
            set { ResultData.CopyM3 = value; }
        }
        public int? CopyCerOrigin
        {
            get { return ResultData.CopyCerOrigin; }
            set { ResultData.CopyCerOrigin = value; }
        }
        public int? CopyBillLadingOrigin
        {
            get { return ResultData.CopyBillLadingOrigin; }
            set { ResultData.CopyBillLadingOrigin = value; }
        }
        public int? CopyBillLading
        {
            get { return ResultData.CopyBillLading; }
            set { ResultData.CopyBillLading = value; }
        }
        public int? CopyPolicyOrigin
        {
            get { return ResultData.CopyPolicyOrigin; }
            set { ResultData.CopyPolicyOrigin = value; }
        }
        public int? CopyPolicy
        {
            get { return ResultData.CopyPolicy; }
            set { ResultData.CopyPolicy = value; }
        }
        public int? CopyCustomInvoice
        {
            get { return ResultData.CopyCustomInvoice; }
            set { ResultData.CopyCustomInvoice = value; }
        }
        public int? CopyCertificate
        {
            get { return ResultData.CopyCertificate; }
            set { ResultData.CopyCertificate = value; }
        }
        public String Branch
        {
            get{ return ResultData.Branch;}
            set { ResultData.Branch = value; }
        }
        public String TaxID
        {
            get { return ResultData.TaxID; }
            set { ResultData.TaxID = value; }
        }
        public int Priority
        {
            get { return ResultData.Priority; }
            set { ResultData.Priority = value; }
        }
        #endregion

        public List<sp_XMSS270_Customer_SearchAll_Result> DataLoading(int? OwnerID, String CustomerCode, string CustomerName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("CustomerCode", CustomerCode);
            hs.Add("CustomerName", CustomerName);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Customer/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS270_Customer_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DataLoadOwner()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("CustomerID", CustomerID);
                return RubixWebAPI.ExecuteDataSet("Customer/DataLoadOwner", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistCustomerCode(int? CustomerID, String CustomerCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("CustomerID", CustomerID);
            hs.Add("CustomerCode", CustomerCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Customer/CheckExistCustomerCode", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveCustomerData(string OwnerXML)
        {
            CustomerStruct stc;
            stc.ResultData = ResultData;
            stc.OwnerXML = OwnerXML;
            //stc.PrivilegeXML = PrivilegeXML;
            
            try
            {
                RubixWebAPI.ExecuteObjectResult("Customer/SaveCustomerData", JsonConvert.SerializeObject(stc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteCustomerData()
        {
            Hashtable hs = new Hashtable();
            hs.Add("CustomerID", CustomerID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("Customer/DeleteCustomerData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int CustomerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("CustomerID", CustomerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Customer/CheckReference", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;

namespace CSI.Business.Master
{
    public class Customer
    {
        #region Member
        private sp_XMSS270_Customer_SearchAll_Result ta_Result = null;
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
        public int? PackingLeadTime
        {
            get { return ResultData.PackingLeadTime; }
            set { ResultData.PackingLeadTime = value; }
        }
        public int? PickingLeadTime
        {
            get { return ResultData.PickingLeadTime; }
            set { ResultData.PickingLeadTime = value; }
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
            get { return ResultData.Branch; }
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

        public ObjectResult<sp_XMSS270_Customer_SearchAll_Result> DataLoading(int? OwnerID, String CustomerCode, String CustomerName)
        {
            try
            {
                return Database.MasterEntity.sp_XMSS270_Customer_SearchAll(ownerID: (OwnerID == null ? null : OwnerID), customerCode: (CustomerCode == String.Empty ? null : CustomerCode), 
                customerName: (CustomerName == String.Empty ? null : CustomerName));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet DataLoadOwner(int? CustomerID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("CustomerID", CustomerID);
                return Database.ExecuteDataSet("sp_XMSS270_LoadOwnerByCustomer", hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Boolean CheckExistCustomerCode(int? CustomerID,String CustomerCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("CustomerID", CustomerID);
                hs.Add("CustomerCode", CustomerCode);

                return (Database.ExecuteDataSet("sp_XMSS270_Customer_CheckExist", hs).Tables[0].Rows.Count > 0);               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SaveCustomerData(string ResultXML)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("CustomerID", CustomerID);
                hs.Add("CustomerCode", CustomerCode);
                hs.Add("CustomerName", CustomerName);
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
                hs.Add("IsCalVat", IsCalVat);
                hs.Add("Vat", Vat);
                hs.Add("PaymentTerm", PaymentTerm);
                hs.Add("PickingLeadTime", PickingLeadTime);
                hs.Add("PackingLeadTime", PackingLeadTime);
                hs.Add("TransportLeadTime", TransportLeadTime);
                hs.Add("InvoiceType", InvoiceType);
                hs.Add("Remark", Remark);
                hs.Add("OwnerXML", ResultXML);
                hs.Add("CopyInvoice", CopyInvoice);
                hs.Add("CopyPackList", CopyPackList);
                hs.Add("CopyM3", CopyM3);
                hs.Add("CopyCerOrigin", CopyCerOrigin);
                hs.Add("CopyBillLadingOrigin", CopyBillLadingOrigin);
                hs.Add("CopyBillLading", CopyBillLading);
                hs.Add("CopyPolicyOrigin", CopyPolicyOrigin);
                hs.Add("CopyPolicy", CopyPolicy);
                hs.Add("CopyCustomInvoice", CopyCustomInvoice);
                hs.Add("CopyCertificate", CopyCertificate);
                hs.Add("Branch", Branch);
                hs.Add("TaxID", TaxID);
                hs.Add("CustomerPriority", Priority);
                hs.Add("Insurance", Insurance);
                hs.Add("Freight", Freight);
                hs.Add("Accountee", Accountee);
                hs.Add("IsSpecial", IsSpecial);

                Database.ExecuteNonQuery("sp_XMSS270_Customer_Save",hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteCustomerData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("CustomerID", CustomerID);
                Database.ExecuteNonQuery("sp_XMSS270_Customer_Delete",hs);
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
                hs.Add("CustomerID", CustomerID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS270_Customer_CheckReference",hs));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

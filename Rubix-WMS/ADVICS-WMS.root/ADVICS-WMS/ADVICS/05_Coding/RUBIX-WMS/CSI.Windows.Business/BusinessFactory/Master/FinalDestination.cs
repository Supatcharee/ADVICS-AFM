using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;

namespace CSI.Business.Master
{
    public class FinalDestination
    {
        #region Member
        private sp_XMSS070_FinalDestination_SearchAll_Result ta_Result = null;
        #endregion

        #region Properties
        public sp_XMSS070_FinalDestination_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS070_FinalDestination_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        public Object SelectData
        {
            set { ta_Result = (sp_XMSS070_FinalDestination_SearchAll_Result)value; }
        }
        public int FinalDestinationID
        {
            get { return ResultData.FinalDestinationID; }
            set { ResultData.FinalDestinationID = value; }
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
        public String FinalDestinationCode
        {
            get { return ResultData.FinalDestinationCode; }
            set { ResultData.FinalDestinationCode = value; }
        }
        public String FinalDestinationLongName
        {
            get { return ResultData.FinalDestinationName; }
            set { ResultData.FinalDestinationName = value; }
        }
        public String FinalDestinationAddress
        {
            get { return ResultData.FinalDestinationAddress; }
            set { ResultData.FinalDestinationAddress = value; }
        }
        public String FinalDestinationDetail
        {
            get { return ResultData.FinalDestinationDetail; }
            set { ResultData.FinalDestinationDetail = value; }
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
        public Decimal? KM
        {
            get { return ResultData.Distance; }
            set { ResultData.Distance = value; }
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
        public bool IsSystem 
        {
            get { return ResultData.IsSystem; }
            set { ResultData.IsSystem = value; }
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
        public int? CustomerID
        {
            get { return ResultData.CustomerID; }
            set { ResultData.CustomerID = value; }
        }
        public string CustomerCode
        {
            get { return ResultData.CustomerCode; }
            set { ResultData.CustomerCode = value; }
        }
        public string CustomerName
        {
            get { return ResultData.CustomerName; }
            set { ResultData.CustomerName = value; }
        }
        public byte[] ImageFile
        {
            get { return ResultData.ImageFile; }
            set { ResultData.ImageFile = value; }
        }
        public decimal? Rate
        {
            get { return ResultData.Rate; }
            set { ResultData.Rate = value; }
        }
        #endregion

        public List<sp_XMSS070_FinalDestination_SearchAll_Result> DataLoading(String FinalDestinationCode,String FinalDestinationName,int? OwnerID, int? shippingCustomerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("FinalDestinationCode", FinalDestinationCode);
            hs.Add("FinalDestinationName", FinalDestinationName);
            hs.Add("OwnerID", OwnerID);
            hs.Add("shippingCustomerID", shippingCustomerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("FinalDestination/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS070_FinalDestination_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistFinalDestinationCode(String FinalDestinationCode, int? OwnerID, int? CustomerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("FinalDestinationCode", FinalDestinationCode);
            hs.Add("OwnerID", OwnerID);
            hs.Add("CustomerID", CustomerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("FinalDestination/CheckExistFinalDestinationCode", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveFinalDestinationData()
        {
            try
            {
                RubixWebAPI.ExecuteObjectResult("FinalDestination/SaveFinalDestinationData", JsonConvert.SerializeObject(ResultData));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteCustomerData()
        {
            Hashtable hs = new Hashtable();
            hs.Add("FinalDestinationID", FinalDestinationID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("FinalDestination/DeleteCustomerData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int? iFinalDestinationID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("iFinalDestinationID", iFinalDestinationID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("FinalDestination/CheckReference", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}

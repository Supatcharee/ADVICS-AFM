using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;

namespace CSI.Business.Master
{
    public class FinalDestination
    {
        #region Member
        private sp_XMSS070_FinalDestination_SearchAll_Result ta_Result = null;
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

        //public sp_XMSS070_FinalDestination_Save_Result ResultDataSave
        //{
        //    get
        //    {
        //        if (ta_Result_Save == null)
        //        {
        //            ta_Result_Save = new sp_XMSS070_FinalDestination_Save_Result();
        //        }
        //        return ta_Result_Save;
        //    }
        //    set { ta_Result_Save = value; }
        //}

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
        //public Object SelectData
        //{
        //    set { ta_Result_Save = (sp_XMSS070_FinalDestination_Save_Result)value; }
        //}

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
        public String OwnerName
        {
            get { return ResultData.OwnerName; }
            set { ResultData.OwnerName = value; }
        }
        public String CustomerCode
        {
            get { return ResultData.CustomerCode; }
            set { ResultData.CustomerCode = value; }
        }
        public string CustomerName
        {
            get { return ResultData.CustomerName; }
            set { ResultData.CustomerName = value; }
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
        public decimal? Rate
        {
            get { return ResultData.Rate; }
            set { ResultData.Rate = value; }
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
        public byte[] ImageFile
        {
            get { return ResultData.ImageFile; }
            set { ResultData.ImageFile = value; }
        } 

        #endregion

        public ObjectResult<sp_XMSS070_FinalDestination_SearchAll_Result> DataLoading(String FinalDestinationCode, String FinalDestinationName, int? OwnerID, int? shippingCustomerID)
        {
            try
            {
                return Database.MasterEntity.sp_XMSS070_FinalDestination_SearchAll((FinalDestinationCode == String.Empty ? null : FinalDestinationCode), (FinalDestinationName == String.Empty ? null : FinalDestinationName), OwnerID, shippingCustomerID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Boolean CheckExistFinalDestinationCode(String FinalDestinationCode, int? OwnerID, int? CustomerID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("FinalDestinationCode", FinalDestinationCode);
                hs.Add("OwnerID", OwnerID);
                hs.Add("CustomerID", CustomerID);

                return (Database.ExecuteDataSet("sp_XMSS070_FinalDestination_CheckExist", hs).Tables[0].Rows.Count > 0);

              
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SaveFinalDestinationData()
        {
            //bool result = false;
            //int x = 0;
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("FinalDestinationID", FinalDestinationID);
                hs.Add("OwnerID", OwnerID);
                hs.Add("FinalDestinationCode", FinalDestinationCode);
                hs.Add("FinalDestinationLongName", FinalDestinationLongName);
                hs.Add("FinalDestinationAddress", FinalDestinationAddress);
                hs.Add("FinalDestinationDetail", FinalDestinationDetail);
                hs.Add("City", City);
                hs.Add("StateOrProvince", StateOrProvince);
                hs.Add("PostalCode", PostalCode);
                hs.Add("Extension", Extension);
                hs.Add("FaxNo", FaxNo);
                hs.Add("ContactName1", ContactName1);
                hs.Add("ContactName2", ContactName2);
                hs.Add("ContactName3", ContactName3);
                hs.Add("Remark", Remark);
                hs.Add("PhoneNo", PhoneNo);
                hs.Add("Country", Country);
                hs.Add("KM", KM);
                hs.Add("MobileNo", MobileNo);
                hs.Add("LeadTimeDays", LeadTimeDays);
                hs.Add("LeadTimeHr", LeadTimeHr);
                hs.Add("CreateUser", CreateUser);
                hs.Add("CustomerID", CustomerID);
                hs.Add("Rate", Rate);
                if (ImageFile != null)
                {
                    hs.Add("ImageFile", ImageFile);
                }
                else
                {
                    hs.Add("ImageFile", new System.Byte[1]);
                }

                Database.ExecuteNonQuery("sp_XMSS070_FinalDestination_Save", hs);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return null;
            //return result;
        }

        public void DeleteCustomerData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("FinalDestinationID", FinalDestinationID);
               
                Database.ExecuteNonQuery("sp_XMSS070_FinalDestination_Delete",hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int? CheckReference(int? iFinalDestinationID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("FinalDestinationID", iFinalDestinationID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS070_FinalDestination_CheckReference",hs));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

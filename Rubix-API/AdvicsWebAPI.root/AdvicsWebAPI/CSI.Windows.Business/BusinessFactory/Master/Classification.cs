using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;

namespace CSI.Business.Master
{
    public class Classification
    {
        #region Member
        private sp_XMSS240_Classification_SearchAll_Result ta_Result = null;
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
        public sp_XMSS240_Classification_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS240_Classification_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        public Object SelectData
        {
            set { ta_Result = (sp_XMSS240_Classification_SearchAll_Result)value; }
        }
        public int ClassificationID
        {
            get { return ResultData.ClassificationID; }
            set { ResultData.ClassificationID = value; }
        }
        public string ClassificationCode
        {
            get { return ResultData.ClassificationCode; }
            set { ResultData.ClassificationCode = value; }
        }
        public string ClassificationName
        {
            get { return ResultData.ClassificationName; }
            set { ResultData.ClassificationName = value; }
        }
        public string Remark
        {
            get { return ResultData.Remark; }
            set { ResultData.Remark = value; }
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

        public ObjectResult<sp_XMSS240_Classification_SearchAll_Result> DataLoading(/*int? CustomerID ,*/String ClassificationCode, String ClassificationName)      // 2013-04-05  CustomerID is  not  use
        {
            try
            {
                return Database.MasterEntity.sp_XMSS240_Classification_SearchAll(/*customerID: CustomerID,*/ classificationCode: (ClassificationCode == String.Empty ? null : ClassificationCode), classificationName: (ClassificationName == String.Empty ? null : ClassificationName));     // 2013-04-05  CustomerID is  not  use
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public Boolean CheckExistClassificationCode(String ClassificationCode/*, int? customerID*/)             // 2013-04-05  CustomerID is  not  use
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ClassificationCode", ClassificationCode);

                return (Database.ExecuteDataSet("sp_XMSS240_Classification_CheckExist", hs).Tables[0].Rows.Count > 0);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public void SaveClassificationData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ClassificationID", ClassificationID);
                hs.Add("ClassificationCode", ClassificationCode);
                hs.Add("ClassificationName", ClassificationName);
                hs.Add("Remark", Remark);
                hs.Add("CreateUser", CreateUser);

                Database.ExecuteNonQuery("sp_XMSS240_Classification_Save", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteClassificationData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ClassificationID", ClassificationID);
                Database.ExecuteNonQuery("sp_XMSS240_Classification_Delete",hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int? iClassificationID)
        {
            try
            {
                 Hashtable hs = new Hashtable();
                hs.Add("ClassificationID", iClassificationID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS240_Classification_CheckReference",hs));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

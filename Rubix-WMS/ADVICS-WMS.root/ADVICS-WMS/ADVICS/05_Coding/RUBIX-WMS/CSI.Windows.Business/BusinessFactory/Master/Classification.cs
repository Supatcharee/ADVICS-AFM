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
    public class Classification
    {
        #region Member
        private sp_XMSS240_Classification_SearchAll_Result ta_Result = null;
        #endregion

        #region Properties
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

        public List<sp_XMSS240_Classification_SearchAll_Result> DataLoading(String ClassificationCode, String ClassificationName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ClassificationCode", ClassificationCode);
            hs.Add("ClassificationName", ClassificationName);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Classification/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS240_Classification_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistClassificationCode(String ClassificationCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ClassificationCode", ClassificationCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Classification/CheckExistClassificationCode", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
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
                RubixWebAPI.ExecuteObjectResult("Classification/SaveClassificationData", JsonConvert.SerializeObject(ResultData));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteClassificationData()
        {
            Hashtable hs = new Hashtable();
            hs.Add("ClassificationID", ClassificationID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("Classification/DeleteClassificationData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int? iClassificationID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("iClassificationID", iClassificationID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Classification/CheckReference", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

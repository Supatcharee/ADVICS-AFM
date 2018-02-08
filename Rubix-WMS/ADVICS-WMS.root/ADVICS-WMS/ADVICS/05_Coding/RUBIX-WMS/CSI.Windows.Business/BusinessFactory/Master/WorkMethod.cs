using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using Newtonsoft.Json;
using System.Collections;
namespace CSI.Business.Master
{
    public class WorkMethod
    {
        #region Member
        private sp_XMSS230_WorkMethod_SearchAll_Result ta_Result = null;
        #endregion

        #region Properties
        public sp_XMSS230_WorkMethod_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS230_WorkMethod_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        public Object SelectData
        {
            set { ta_Result = (sp_XMSS230_WorkMethod_SearchAll_Result)value; }
        }
        public int WorkMethodID
        {
            get { return ResultData.WorkMethodID; }
            set { ResultData.WorkMethodID = value; }
        }
        public string WorkMethodCode
        {
            get { return ResultData.WorkMethodCode; }
            set { ResultData.WorkMethodCode = value; }
        }
        public string WorkMethodName
        {
            get { return ResultData.WorkMethodName; }
            set { ResultData.WorkMethodName = value; }
        }
        public string Description
        {
            get { return ResultData.Description; }
            set { ResultData.Description = value; }
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

        public List<sp_XMSS230_WorkMethod_SearchAll_Result> DataLoading(String WorkMethodCode, String WorkMethodName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("WorkMethodCode", WorkMethodCode);
            hs.Add("WorkMethodName", WorkMethodName);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("WorkMethod/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS230_WorkMethod_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistWorkMethodCode(String WorkMethodCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("WorkMethodCode", WorkMethodCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("WorkMethod/CheckExistWorkMethodCode", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void SaveWorkMethodData()
        {
            try
            {
                RubixWebAPI.ExecuteObjectResult("WorkMethod/SaveWorkMethodData", JsonConvert.SerializeObject(ResultData));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteWorkMethodData()
        {
            Hashtable hs = new Hashtable();
            hs.Add("WorkMethodID", WorkMethodID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("WorkMethod/DeleteWorkMethodData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int? iWorkMethodID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("iWorkMethodID", iWorkMethodID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("WorkMethod/CheckReference", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

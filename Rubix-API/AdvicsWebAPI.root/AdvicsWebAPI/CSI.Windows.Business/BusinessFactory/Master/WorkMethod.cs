using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
namespace CSI.Business.Master
{
    public class WorkMethod
    {
        #region Member
        private sp_XMSS230_WorkMethod_SearchAll_Result ta_Result = null;
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

        public ObjectResult<sp_XMSS230_WorkMethod_SearchAll_Result> DataLoading(String WorkMethodCode, String WorkMethodName)
        {
            try
            {
                return Database.MasterEntity.sp_XMSS230_WorkMethod_SearchAll(workMethodCode: (WorkMethodCode == String.Empty ? null : WorkMethodCode), workMethodName:(WorkMethodName == String.Empty ? null : WorkMethodName));
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public Boolean CheckExistWorkMethodCode(String WorkMethodCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("WorkMethodCode", WorkMethodCode);
                return (Database.ExecuteDataSet("sp_XMSS230_WorkMethod_CheckExist", hs).Tables[0].Rows.Count > 0);               
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
                Hashtable hs = new Hashtable();
                hs.Add("WorkMethodID", WorkMethodID);
                hs.Add("WorkMethodCode", WorkMethodCode);
                hs.Add("WorkMethodName", WorkMethodName);
                hs.Add("Description", Description);
                hs.Add("CreateUser", CreateUser);

                Database.ExecuteNonQuery("sp_XMSS230_WorkMethod_Save",hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteWorkMethodData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("WorkMethodID", WorkMethodID);
                Database.ExecuteNonQuery("sp_XMSS230_WorkMethod_Delete",hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int? CheckReference(int? iWorkMethodID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("WorkMethodID", iWorkMethodID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS230_WorkMethod_CheckReference",hs));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

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
    public class Condition
    {
        #region Member
        private sp_XMSS110_ConditionOfProduct_SearchAll_Result ta_Result = null;
        
        #endregion

        #region Properties
        public sp_XMSS110_ConditionOfProduct_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS110_ConditionOfProduct_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        public Object SelectData
        {
            set { ta_Result = (sp_XMSS110_ConditionOfProduct_SearchAll_Result)value; }
        }
        public int ProductConditionID
        {
            get { return ResultData.ProductConditionID; }
            set { ResultData.ProductConditionID = value; }
        }
        public String ProductConditionCode
        {
            get { return ResultData.ProductConditionCode; }
            set { ResultData.ProductConditionCode = value; }
        }
        public String ProductConditionName
        {
            get { return ResultData.ProductConditionName; }
            set { ResultData.ProductConditionName = value; }
        }
        public String Remark
        {
            get { return ResultData.Remark; }
            set { ResultData.Remark = value; }
        }
        public bool IsSystem
        {
            get { return ResultData.IsSystem; }
            set { ResultData.IsSystem = value; }
        }
        public DateTime CreateDate
        {
            get { return ResultData.CreateDate; }
            set { ResultData.CreateDate = value; }
        }
        public String CreateUser
        {
            get { return ResultData.CreateUser; }
            set { ResultData.CreateUser = value; }
        }
        public DateTime? UpdateDate
        {
            get { return ResultData.UpdateDate; }
            set { ResultData.UpdateDate = value; }
        }
        public String UpdateUser
        {
            get { return ResultData.UpdateUser; }
            set { ResultData.UpdateUser = value; }
        }
        #endregion

        public List<sp_XMSS110_ConditionOfProduct_SearchAll_Result> DataLoading(String ConditionCode, String ConditionName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ConditionCode", ConditionCode);
            hs.Add("ConditionName", ConditionName);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Condition/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS110_ConditionOfProduct_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public Boolean CheckExistProductConditionCode(String ProductConditionCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductConditionCode", ProductConditionCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Condition/CheckExistProductConditionCode", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveConditionData()
        {
            try
            {
                RubixWebAPI.ExecuteObjectResult("Condition/SaveConditionData", JsonConvert.SerializeObject(ResultData));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteConditionData()
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductConditionID", ProductConditionID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("Condition/DeleteConditionData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int? iProductConditionID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("iProductConditionID", iProductConditionID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Condition/CheckReference", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

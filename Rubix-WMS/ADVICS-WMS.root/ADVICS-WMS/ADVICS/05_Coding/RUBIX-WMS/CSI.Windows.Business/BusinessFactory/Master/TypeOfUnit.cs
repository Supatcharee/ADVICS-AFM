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
    public class TypeOfUnit
    {
        #region Member
        private sp_XMSS220_TypeOfUnit_SearchAll_Result ta_Result = null;
        #endregion

        #region Properties
        public sp_XMSS220_TypeOfUnit_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS220_TypeOfUnit_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        public Object SelectData
        {
            set { ta_Result = (sp_XMSS220_TypeOfUnit_SearchAll_Result)value; }
        }       
        public int UnitID
        {
            get { return ResultData.UnitID; }
            set { ResultData.UnitID = value; }
        }
        public String UnitCode
        {
            get { return ResultData.UnitCode; }
            set { ResultData.UnitCode = value; }
        }
        public String UnitName
        {
            get { return ResultData.UnitName; }
            set { ResultData.UnitName = value; }
        }
        public String Remark
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
        public Boolean IsSystem
        {
            get { return ResultData.IsSystem; }
            set { ResultData.IsSystem = value; }
        }
        #endregion

        public List<sp_XMSS220_TypeOfUnit_SearchAll_Result> DataLoading(String UnitCode, String UnitName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("UnitCode", UnitCode);
            hs.Add("UnitName", UnitName);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("TypeOfUnit/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS220_TypeOfUnit_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistUnitCode(String UnitCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("UnitCode", UnitCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("TypeOfUnit/CheckExistUnitCode", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveUnitData()
        {
            try
            {
                RubixWebAPI.ExecuteObjectResult("TypeOfUnit/SaveUnitData", JsonConvert.SerializeObject(ResultData));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteUnitData()
        {
            Hashtable hs = new Hashtable();
            hs.Add("UnitID", UnitID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("TypeOfUnit/DeleteUnitData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int? iUnitID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("iUnitID", iUnitID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("TypeOfUnit/CheckReference", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

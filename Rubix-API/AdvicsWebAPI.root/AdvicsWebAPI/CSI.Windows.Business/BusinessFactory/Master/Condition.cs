using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
namespace CSI.Business.Master
{
    public class Condition
    {
        #region Member
        private sp_XMSS110_ConditionOfProduct_SearchAll_Result ta_Result = null;
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

        public ObjectResult<sp_XMSS110_ConditionOfProduct_SearchAll_Result> DataLoading(String ConditionCode, String ConditionName)
        {
            try
            {
                return Database.MasterEntity.sp_XMSS110_ConditionOfProduct_SearchAll((ConditionCode == String.Empty ? null : ConditionCode), (ConditionName == String.Empty ? null : ConditionName));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
        public Boolean CheckExistProductConditionCode(String ProductConditionCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductConditionCode", ProductConditionCode);
                return (Database.ExecuteDataSet("sp_XMSS110_ConditionOfProduct_CheckExist", hs).Tables[0].Rows.Count > 0);
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
                Hashtable hs = new Hashtable();
                hs.Add("ProductConditionID", ProductConditionID);
                hs.Add("ProductConditionCode", ProductConditionCode);
                hs.Add("ProductConditionName", ProductConditionName);
                hs.Add("Remark", Remark);
                hs.Add("CreateUser",CreateUser);

                Database.ExecuteNonQuery("sp_XMSS110_ConditionOfProduct_Save",hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteConditionData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductConditionID", ProductConditionID);
                Database.ExecuteNonQuery("sp_XMSS110_ConditionOfProduct_Delete",hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int? CheckReference(int? iProductConditionID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductConditionID", iProductConditionID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS110_ConditionOfProduct_CheckReference",hs));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

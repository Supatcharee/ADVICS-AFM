using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
namespace CSI.Business.Master
{
    public class TypeOfUnit
    {
        #region Member
        private sp_XMSS220_TypeOfUnit_SearchAll_Result ta_Result = null;
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

        public ObjectResult<sp_XMSS220_TypeOfUnit_SearchAll_Result> DataLoading(String UnitCode, String UnitName)
        {
            try
            {
                return Database.MasterEntity.sp_XMSS220_TypeOfUnit_SearchAll(unitCode: (UnitCode == String.Empty ? null : UnitCode), unitName: (UnitName == String.Empty ? null : UnitName));

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public Boolean CheckExistUnitCode(String UnitCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("UnitCode", UnitCode);
                return (Database.ExecuteDataSet("sp_XMSS220_TypeOfUnit_CheckExist", hs).Tables[0].Rows.Count > 0);          
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
                Hashtable hs = new Hashtable();
                hs.Add("UnitID", UnitID);
                hs.Add("UnitCode", UnitCode);
                hs.Add("UnitName", UnitName);
                hs.Add("Remark", Remark);
                hs.Add("CreateUser", CreateUser);

                Database.ExecuteNonQuery("sp_XMSS220_TypeOfUnit_Save",hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteUnitData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("UnitID", UnitID);
                Database.ExecuteNonQuery("sp_XMSS220_TypeOfUnit_Delete",hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int? CheckReference(int? iUnitID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("UnitID", iUnitID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS220_TypeOfUnit_CheckReference",hs));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

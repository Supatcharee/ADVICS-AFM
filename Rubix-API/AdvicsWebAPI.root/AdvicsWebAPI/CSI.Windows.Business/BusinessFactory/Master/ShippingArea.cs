using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
namespace CSI.Business.Master
{
    public class ShippingArea
    {
        #region Member
        private sp_XMSS150_ShippingArea_SearchAll_Result ta_Result = null;
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

        public sp_XMSS150_ShippingArea_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS150_ShippingArea_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }

        public Object SelectData
        {
            set { ta_Result = (sp_XMSS150_ShippingArea_SearchAll_Result)value; }
        }

        public int ShippingAreaID
        {
            get { return ResultData.ShippingAreaID; }
            set { ResultData.ShippingAreaID = value; }
        }
        public int WarehouseID
        {
            get { return ResultData.WarehouseID; }
            set { ResultData.WarehouseID = value; }
        }
        public String WarehouseCode
        {
            get { return ResultData.WarehouseCode; }
            set { ResultData.WarehouseCode = value; }
        }
        public String WarehouseName
        {
            get { return ResultData.WarehouseName; }
            set { ResultData.WarehouseName = value; }
        }
        public String ShippingAreaCode
        {
            get { return ResultData.ShippingAreaCode; }
            set { ResultData.ShippingAreaCode = value; }
        }
        public String ShippingAreaName
        {
            get { return ResultData.ShippingAreaName; }
            set { ResultData.ShippingAreaName = value; }
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
        #endregion

        public ObjectResult<sp_XMSS150_ShippingArea_SearchAll_Result> DataLoading(int? ShippingAreaID, int? WarehouseID, string ShippingAreaCode, string ShippingAreaname)
        {
            try
            {
                return Database.MasterEntity.sp_XMSS150_ShippingArea_SearchAll(ShippingAreaID, WarehouseID, (ShippingAreaCode == string.Empty ? null : ShippingAreaCode), (ShippingAreaname == string.Empty ? null : ShippingAreaname));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Boolean CheckExistShippingAreaCode(String ShippingAreaCode, int WarehouseID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShippingAreaCode", ShippingAreaCode);
                hs.Add("WarehouseId", WarehouseID);
                return (Database.ExecuteDataSet("sp_XMSS150_ShippingArea_CheckExist", hs).Tables[0].Rows.Count > 0);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SaveShippingAreaData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ShippingAreaID", ShippingAreaID);
                hs.Add("ShippingAreaCode", ShippingAreaCode);
                hs.Add("ShippingAreaName", ShippingAreaName);
                hs.Add("Remark", Remark);
                hs.Add("CreateUser", CreateUser);

                Database.ExecuteNonQuery("sp_XMSS150_ShippingArea_Save",hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteShippingAreaData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShippingAreaID", ShippingAreaID);
                Database.ExecuteNonQuery("sp_XMSS150_ShippingArea_Delete",hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int? CheckReference(int? iShippingAreaID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShippingAreaID", iShippingAreaID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS150_ShippingArea_CheckReference",hs));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

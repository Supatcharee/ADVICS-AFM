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
    public class ShippingArea
    {
        #region Member
        private sp_XMSS150_ShippingArea_SearchAll_Result ta_Result = null;
        #endregion

        #region Properties
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
        public bool? IsSystem
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
        #endregion

        public List<sp_XMSS150_ShippingArea_SearchAll_Result> DataLoading(int? ShippingAreaID, int? WarehouseID, string ShippingAreaCode, string ShippingAreaname)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShippingAreaID", ShippingAreaID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ShippingAreaCode", ShippingAreaCode);
            hs.Add("ShippingAreaname", ShippingAreaname);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingArea/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS150_ShippingArea_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistShippingAreaCode(String ShippingAreaCode, int WarehouseID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShippingAreaCode", ShippingAreaCode);
            hs.Add("WarehouseID", WarehouseID);
            
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingArea/CheckExistShippingAreaCode", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
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
                RubixWebAPI.ExecuteObjectResult("ShippingArea/SaveShippingAreaData", JsonConvert.SerializeObject(ResultData));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteShippingAreaData()
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShippingAreaID", ShippingAreaID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("ShippingArea/DeleteShippingAreaData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int? iShippingAreaID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("iShippingAreaID", iShippingAreaID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingArea/CheckReference", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

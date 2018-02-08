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
    public class Package
    {
        #region Member
        private sp_XMSS260_Package_SearchAll_Result ta_Result = null;
        #endregion

        #region Properties
        public sp_XMSS260_Package_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS260_Package_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        public Object SelectData
        {
            set { ta_Result = (sp_XMSS260_Package_SearchAll_Result)value; }
        }
        public int PackageID
        {
            get { return ResultData.PackageID; }
            set { ResultData.PackageID = value; }
        }
        public String PackageCode
        {
            get { return ResultData.PackageCode; }
            set { ResultData.PackageCode = value; }
        }
        public String PackageName
        {
            get { return ResultData.PackageName; }
            set { ResultData.PackageName = value; }
        }
        public decimal? Weight
        {
            get { return ResultData.Weight; }
            set { ResultData.Weight = value; }
        }
        public decimal? Length
        {
            get { return ResultData.Length; }
            set { ResultData.Length = value; }
        }
        public decimal? Width
        {
            get { return ResultData.Width; }
            set { ResultData.Width = value; }
        }
        public decimal? Height
        {
            get { return ResultData.Height; }
            set { ResultData.Height = value; }
        }
        public decimal? M3
        {
            get { return ResultData.M3; }
            set { ResultData.M3 = value; }
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
        public DateTime? CreateDate
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

        public List<sp_XMSS260_Package_SearchAll_Result> DataLoading(String PackageCode, String PackageName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PackageCode", PackageCode);
            hs.Add("PackageName", PackageName);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Package/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS260_Package_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistUnitCode(String PackageCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("PackageCode", PackageCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Package/CheckExistUnitCode", hs);
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
                RubixWebAPI.ExecuteObjectResult("Package/SaveUnitData", JsonConvert.SerializeObject(ResultData));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteUnitData()
        {
            Hashtable hs = new Hashtable();
            hs.Add("PackageID", PackageID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("Package/DeleteUnitData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int? iPackageID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("iPackageID", iPackageID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Package/CheckReference", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
namespace CSI.Business.Master

{
    public class Package
    {
        #region Member
        private sp_XMSS260_Package_SearchAll_Result ta_Result = null;
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

        public ObjectResult<sp_XMSS260_Package_SearchAll_Result> DataLoading(String PackageCode, String PackageName)
        {
            try
            {
                return Database.MasterEntity.sp_XMSS260_Package_SearchAll(packageCode: (PackageCode == String.Empty ? null : PackageCode), packageName: (PackageName == String.Empty ? null : PackageName));

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public Boolean CheckExistUnitCode(String PackageCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PackageCode", PackageCode);
                return (Database.ExecuteDataSet("sp_XMSS260_Package_CheckExist", hs).Tables[0].Rows.Count > 0);
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
                hs.Add("PackageID", PackageID);
                hs.Add("PackageCode", PackageCode);
                hs.Add("PackageName", PackageName);
                hs.Add("Weight", Weight);
                hs.Add("Length", Length);
                hs.Add("Width", Width);
                hs.Add("Height", Height);
                hs.Add("M3", M3);
                hs.Add("Remark", Remark);
                hs.Add("CreateUser", CreateUser);
                hs.Add("UpdateUser", UpdateUser);
                
                Database.ExecuteNonQuery("sp_XMSS260_Package_Save",hs);
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
                hs.Add("PackageID", PackageID);
                Database.ExecuteNonQuery("sp_XMSS260_Package_Delete",hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int? iPackageID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PackageID", iPackageID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS260_Package_CheckReference",hs));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
namespace CSI.Business.Master
{
    public class TransportType
    {
        #region Member
        private sp_XMSS130_TransportType_SearchAll_Result ta_Result = null;
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

        public sp_XMSS130_TransportType_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS130_TransportType_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }

        public Object SelectData
        {
            set { ta_Result = (sp_XMSS130_TransportType_SearchAll_Result)value; }
        }

        public int TransportTypeID
        {
            get { return ResultData.TransportTypeID; }
            set { ResultData.TransportTypeID = value; }
        }
        public String TransportTypeCode
        {
            get { return ResultData.TransportTypeCode; }
            set { ResultData.TransportTypeCode = value; }
        }
        public String TransportTypeName
        {
            get { return ResultData.TransportTypeName; }
            set { ResultData.TransportTypeName = value; }
        }
        public decimal? MaxM3
        {
            get { return ResultData.MaxM3; }
            set { ResultData.MaxM3 = value; }
        }
        public decimal? ContainerWeight
        {
            get { return ResultData.ContainerWeight; }
            set { ResultData.ContainerWeight = value; }
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
        public decimal? Width
        {
            get { return ResultData.Width; }
            set { ResultData.Width = value; }
        }
        public decimal? Length
        {
            get { return ResultData.Length; }
            set { ResultData.Length = value; }
        }
        public decimal? Height
        {
            get { return ResultData.Height; }
            set { ResultData.Height = value; }
        }
        public int? MaxPallet
        {
            get { return ResultData.MaxPallet; }
            set { ResultData.MaxPallet = value; }
        }
        public bool LGL
        {
            get { return ResultData.LGL; }
            set { ResultData.LGL = value; }
        }
        public bool IsSystem
        {
            get { return ResultData.IsSystem; }
            set { ResultData.IsSystem = value; }
        }
        #endregion

        public ObjectResult<sp_XMSS130_TransportType_SearchAll_Result> DataLoading(String TransportCode, String TransporteName)
        {
            try
            {
                return Database.MasterEntity.sp_XMSS130_TransportType_SearchAll((TransportCode == String.Empty ? null : TransportCode), (TransporteName == String.Empty ? null : TransporteName));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Boolean CheckExistTransportTypeCode(String TransportCode)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("TransportTypeCode", TransportCode);
                return (Database.ExecuteDataSet("sp_XMSS130_TransportType_CheckExist", hs).Tables[0].Rows.Count > 0);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SaveTransportTypeData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("TransportTypeID", TransportTypeID);
                hs.Add("TransportTypeCode", TransportTypeCode);
                hs.Add("TransportTypeName", TransportTypeName);
                hs.Add("MaxM3", MaxM3);
                hs.Add("ContainerWeight", ContainerWeight);
                hs.Add("Remark", Remark);
                hs.Add("CreateUser", CreateUser);
                hs.Add("Width", Width);
                hs.Add("Length", Length);
                hs.Add("Height", Height);
                hs.Add("MaxPallet", MaxPallet);
                hs.Add("LGL", LGL);

                Database.ExecuteNonQuery("sp_XMSS130_TransportType_Save",hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteTransportData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("TransportTypeID", TransportTypeID);
                Database.ExecuteNonQuery("sp_XMSS130_TransportType_Delete",hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int? iTransportTypeID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("TransportTypeID", iTransportTypeID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_XMSS130_TransportType_CheckReference",hs));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

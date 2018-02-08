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
    public class TransportType
    {
        #region Member
        private sp_XMSS130_TransportType_SearchAll_Result ta_Result = null;
        #endregion

        #region Properties
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

        public List<sp_XMSS130_TransportType_SearchAll_Result> DataLoading(String TransportCode, String TransporteName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("TransportCode", TransportCode);
            hs.Add("TransporteName", TransporteName);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("TransportType/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS130_TransportType_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistTransportTypeCode(String TransportCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("TransportCode", TransportCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("TransportType/CheckExistTransportTypeCode", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
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
                RubixWebAPI.ExecuteObjectResult("TransportType/SaveTransportTypeData", JsonConvert.SerializeObject(ResultData));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteTransportData()
        {
            Hashtable hs = new Hashtable();
            hs.Add("TransportTypeID", TransportTypeID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("TransportType/DeleteTransportData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckReference(int? iTransportTypeID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("iTransportTypeID", iTransportTypeID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("TransportType/CheckReference", hs);
                return JsonConvert.DeserializeObject<int>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

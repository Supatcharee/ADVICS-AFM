using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using System.Collections;
using Newtonsoft.Json;
namespace CSI.Business.Master
{
    public class TransportCharge
    {
        #region Member
        private sp_XMSS190_TransportCharge_SearchAll_Result ta_Result = null;
        struct TransportChargeStruct
        {
            public sp_XMSS190_TransportCharge_SearchAll_Result ResultData;
            public string resultXML;
        }
        #endregion

        #region Properties
        private sp_XMSS190_TransportCharge_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_XMSS190_TransportCharge_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        public Object SelectData
        {
            set { ta_Result = (sp_XMSS190_TransportCharge_SearchAll_Result)value; }
        }
        public int OwnerID
        {
            get { return ResultData.OwnerID; }
            set { ResultData.OwnerID = value; }
        }
        public int WarehouseID
        {
            get { return ResultData.WarehouseID; }
            set { ResultData.WarehouseID = value; }
        }      
        public String OwnerCode
        {
            get { return ResultData.OwnerCode; }
            set { ResultData.OwnerCode = value; }
        }
        public String CustomerName
        {
            get { return ResultData.CustomerName; }
            set { ResultData.CustomerName = value; }
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
        public DateTime EffectiveDate
        {
            get { return ResultData.EffectiveDate; }
            set { ResultData.EffectiveDate = value; }
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
        public int? CustomerID
        {
            get { return ResultData.CustomerID; }
            set { ResultData.CustomerID = value; }
        }
        public int? TruckCompanyID
        {
            get { return ResultData.TruckCompanyID; }
            set { ResultData.TruckCompanyID = value; }
        }
        public decimal? FuelPrice
        {
            get { return ResultData.FuelPrice; }
            set { ResultData.FuelPrice = value; }
        } 
        #endregion

        public List<sp_XMSS190_TransportCharge_SearchAll_Result> DataLoading(int? OwnerID, int? WarehouseID, int? CustomerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("CustomerID", CustomerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("TransportCharge/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS190_TransportCharge_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_XMSS190_TransportCharge_SearchByCondition_Result> LoadDialog(int? OwnerID, int? WarehouseID, DateTime? EffectiveDate, int? TruckCompID, int? CustomerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("EffectiveDate", EffectiveDate);
            hs.Add("TruckCompID", TruckCompID);
            hs.Add("CustomerID", CustomerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("TransportCharge/LoadDialog", hs);
                return JsonConvert.DeserializeObject<List<sp_XMSS190_TransportCharge_SearchByCondition_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadTransportCharge(int? iOwnerID, int CustomerID, int TruckCompanyID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", iOwnerID);
            hs.Add("CustomerID", CustomerID);
            hs.Add("TruckCompanyID", TruckCompanyID);
            
            try
            {
                return RubixWebAPI.ExecuteDataTable("TransportCharge/LoadTransportCharge", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<sp_XMSS190_TransportCharge_GetFinalDestinationID_Result> GetFinalDestinationID(int? OwnerID)
        //{
        //    Hashtable hs = new Hashtable();
        //    hs.Add("OwnerID", OwnerID);
        //    hs.Add("CustomerID", CustomerID);

        //    try
        //    {
        //        string strResult = RubixWebAPI.ExecuteObjectResult("TransportCharge/GetFinalDestinationID", hs);
        //        return JsonConvert.DeserializeObject<List<sp_XMSS190_TransportCharge_GetFinalDestinationID_Result>>(strResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public DataTable GetTransportTypeID(String strTransportTypeName)
        {
            Hashtable hs = new Hashtable();
            hs.Add("strTransportTypeName", strTransportTypeName);
            hs.Add("TruckCompanyID", TruckCompanyID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("TransportCharge/GetTransportTypeID", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveTransportChargeData(string resultXML)
        {
            TransportChargeStruct stc;
            stc.resultXML = resultXML;
            stc.ResultData = ResultData;

            try
            {
                RubixWebAPI.ExecuteObjectResult("TransportCharge/SaveTransportChargeData", JsonConvert.SerializeObject(stc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void Delete()
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("EffectiveDate", EffectiveDate);

            try
            {
                RubixWebAPI.ExecuteObjectResult("TransportCharge/Delete", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckExistBeforeSave(int? OwnerID, int? iWarehouseID, DateTime? iEffectiveDate, int? CustomerID, int? truckCompanyID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", iWarehouseID);
            hs.Add("iEffectiveDate", iEffectiveDate);
            hs.Add("CustomerID", CustomerID);
            hs.Add("truckCompanyID", truckCompanyID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("TransportCharge/CheckExistBeforeSave", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

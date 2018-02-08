using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using System.Collections;
namespace CSI.Business.Master
{
    public class TransportCharge
    {
        #region Member
        //private ObjectResult<sp_XMSS190_TransportCharge_SearchAll_Result> lt_Result = null;
        //private ObjectResult<sp_XMSS190_TransportCharge_SearchByCondition_Result> dg_Result = null;
        private sp_XMSS190_TransportCharge_SearchAll_Result ta_Result = null;
        private sp_XMSS190_TransportCharge_SearchByCondition_Result ts_Result = null;
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

        private sp_XMSS190_TransportCharge_SearchByCondition_Result ResultDialogData
        {
            get
            {
                if (ts_Result == null)
                {
                    ts_Result = new sp_XMSS190_TransportCharge_SearchByCondition_Result();
                }
                return ts_Result;
            }
            set { ts_Result = value; }
        }

        public sp_XMSS190_TransportCharge_SearchAll_Result ResultData
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
        public String CustomerCode
        {
            get { return ResultData.CustomerCode; }
            set { ResultData.CustomerCode = value; }
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
        public String DistributionCenterName
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

        public ObjectResult<sp_XMSS190_TransportCharge_SearchAll_Result> DataLoading(int? OwnerID, int? WarehouseID, int? CustomerID)
        {
            try
            {
                return Database.MasterEntity.sp_XMSS190_TransportCharge_SearchAll(ownerID: OwnerID, warehouseID: WarehouseID, customerID: CustomerID);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public List<sp_XMSS190_TransportCharge_SearchByCondition_Result> LoadDialog(int? OwnerID, int? WarehouseID, DateTime? EffectiveDate, int? truckCompID, int? CustomerID)
        {
            try
            {

                return Database.MasterEntity.sp_XMSS190_TransportCharge_SearchByCondition(ownerID: OwnerID, warehouseID: WarehouseID, effectiveDate: EffectiveDate, truckCompanyID: truckCompID, customerID: CustomerID).ToList<sp_XMSS190_TransportCharge_SearchByCondition_Result>();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable LoadTransportCharge(int? OwnerID, int CustomerID, int TruckCompanyID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("TruckCompanyID", TruckCompanyID);
                
                return Database.ExecuteDataSet("sp_XMSS190_TransportCharge_LoadCharge", hs).Tables[0];
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        //public List<sp_XMSS190_TransportCharge_GetFinalDestinationID_Result> GetFinalDestinationID(int? OwnerID)
        //{
        //    try
        //    {
        //        Hashtable hs = new Hashtable();
        //        hs.Add("OwnerID", OwnerID);
        //        hs.Add("CustomerID", CustomerID);

        //        return Database.ExecuteDataSet("sp_XMSS190_TransportCharge_GetFinalDestinationID", hs).Tables[0];

        //    }
        //    catch (Exception ex)
        //    {
                
        //        throw ex;
        //    }
        //}

        public DataTable GetTransportTypeID(String TransportName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("TransportName", TransportName);
                hs.Add("TruckCompanyID", TruckCompanyID);
                
                return Database.ExecuteDataSet("sp_XMSS190_TransportCharge_GetTransportTypeID", hs).Tables[0];
               
                //return Database.MasterEntity.sp_XMSS190_TransportCharge_GetTransportTypeID(transportName: strTransportTypeName, truckCompanyID: TruckCompanyID).ToList<sp_XMSS190_TransportCharge_GetTransportTypeID_Result>();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SaveTransportChargeData(string resultXML)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("EffectiveDate", EffectiveDate);
                hs.Add("CreateUser", CreateUser);
                hs.Add("UpdateUser", UpdateUser);
                hs.Add("xmlResult", resultXML);
                hs.Add("CustomerID", CustomerID);
                hs.Add("TruckCompanyID", TruckCompanyID);
                hs.Add("FuelPrice", FuelPrice);
                Database.ExecuteNonQuery("sp_XMSS190_TransportCharge_Save",hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public void Delete()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("EffectiveDate", EffectiveDate);
                Database.ExecuteNonQuery("sp_XMSS190_TransportCharge_Delete",hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Boolean CheckExistBeforeSave(int? OwnerID, int? WarehouseID, DateTime? iEffectiveDate, int? CustomerID, int? truckCompanyID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("EffectiveDate", iEffectiveDate);
                hs.Add("CustomerID", CustomerID);
                hs.Add("TruckCompanyID", truckCompanyID);
                return (Database.ExecuteDataSet("sp_XMSS190_TransportCharge_CheckExist", hs).Tables[0].Rows.Count > 0);
              
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

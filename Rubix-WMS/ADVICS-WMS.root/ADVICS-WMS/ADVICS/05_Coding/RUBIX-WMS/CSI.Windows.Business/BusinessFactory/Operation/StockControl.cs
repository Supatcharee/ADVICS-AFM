/*
 * 18 Jan 2013:
 * 1. change return type of method ViewDetail
 * 23 Jan 2013: 
 * 1. add new function "GetSpecificStatusId"
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Transactions;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.Operation
{
    public class StockControl
    {
        #region Member
        private sp_GSCS010_StockControlProcess_SearchAll_Result ta_Result = null;
        #endregion

        #region Properties
        public sp_GSCS010_StockControlProcess_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_GSCS010_StockControlProcess_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        public Object SelectData
        {
            set { ta_Result = (sp_GSCS010_StockControlProcess_SearchAll_Result)value; }
        }
        public bool? Select
        {
            get { return ResultData.Select; }
            set { ResultData.Select = value; }
        }
        public string ShipmentNo
        {
            get { return ResultData.ShipmentNo; }
            set { ResultData.ShipmentNo = value; }
        }
        public string PickingNo
        {
            get { return ResultData.PickingNo; }
            set { ResultData.PickingNo = value; }
        }
        public int? PortOfLoadingID
        {
            get { return ResultData.PortOfLoadingID; }
            set { ResultData.PortOfLoadingID = value; }
        }
        public string PortOfLoadingCode
        {
            get { return ResultData.PortOfLoadingCode; }
            set { ResultData.PortOfLoadingCode = value; }
        }
        public string PortOfLoadingName
        {
            get { return ResultData.PortOfLoadingName; }
            set { ResultData.PortOfLoadingName = value; }
        }
        public int? PortOfDischargeID
        {
            get { return ResultData.PortOfDischargeID; }
            set { ResultData.PortOfDischargeID = value; }
        }
        public string PortOfDischargeCode
        {
            get { return ResultData.PortOfDischargeCode; }
            set { ResultData.PortOfDischargeCode = value; }
        }
        public string PortOfDischargeName
        {
            get { return ResultData.PortOfDischargeName; }
            set { ResultData.PortOfDischargeName = value; }
        }
        public int? FinalDestinationID
        {
            get { return ResultData.FinalDestinationID; }
            set { ResultData.FinalDestinationID = value; }
        }
        public string FinalDestinationCode
        {
            get { return ResultData.FinalDestinationCode; }
            set { ResultData.FinalDestinationCode = value; }
        }
        public string FinalDestinationName
        {
            get { return ResultData.FinalDestinationName; }
            set { ResultData.FinalDestinationName = value; }
        }
        public DateTime? PickingDate
        {
            get { return ResultData.PickingDate; }
            set { ResultData.PickingDate = value; }
        }
        public DateTime? DeliveryDate
        {
            get { return ResultData.DeliveryDate; }
            set { ResultData.DeliveryDate = value; }
        }
        public int? NumberOfDetails
        {
            get { return ResultData.NumberOfDetails; }
            set { ResultData.NumberOfDetails = value; }
        }
        public decimal? SumQuantityFromStockByLocation
        {
            get { return ResultData.SumQuantityFromStockByLocation; }
            set { ResultData.SumQuantityFromStockByLocation = value; }
        }
        public decimal? SumAssignQtyFromShipping
        {
            get { return ResultData.SumAssignQtyFromShipping; }
            set { ResultData.SumAssignQtyFromShipping = value; }
        }
        #endregion

        public List<sp_GSCS010_StockControlProcess_SearchAll_Result> DataLoading(int? OwnerID, 
                                                                                int? WarehouseID, 
                                                                                String ShipmentNo, 
                                                                                DateTime? PickingDateFrom, 
                                                                                DateTime? PickingDateTo, 
                                                                                int? FinalDestinationID, 
                                                                                int? shippingCustomerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingDateFrom", PickingDateFrom);
            hs.Add("PickingDateTo", PickingDateTo);
            hs.Add("FinalDestinationID", FinalDestinationID);
            hs.Add("shippingCustomerID", shippingCustomerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("StockControl/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_GSCS010_StockControlProcess_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_GSCS012_StockControlDetail_Search_Result> ViewDetail(String ShipmentNo, String PickingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("StockControl/ViewDetail", hs);
                return JsonConvert.DeserializeObject<List<sp_GSCS012_StockControlDetail_Search_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void SavePickingData(string UpdateUser, string xml)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("UpdateUser", UpdateUser);
            try
            {
                RubixWebAPI.ExecuteObjectResult("StockControl/SavePickingData", hs, JsonConvert.SerializeObject(xml));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveBookStockData(string ShipmentNo, string PickingNo, int? WarehouseID, int? OwnerID, int LineNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("OwnerID", OwnerID);
            hs.Add("LineNo", LineNo);
            hs.Add("CreateUser", Rubix.Framework.AppConfig.UserLogin);
            try
            {
                RubixWebAPI.ExecuteObjectResult("StockControl/SaveBookStockData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<int?> GetSpecificStatusId()
        {
            List<int?> ListStatus = new List<int?>();
            ListStatus.AddRange(new int?[] {Common.Status.NewShippingEntry});

            return ListStatus;

        }
    }
}

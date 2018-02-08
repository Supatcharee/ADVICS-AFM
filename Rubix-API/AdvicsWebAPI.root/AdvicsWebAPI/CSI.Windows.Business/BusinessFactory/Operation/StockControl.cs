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

namespace CSI.Business.Operation
{
    public class StockControl
    {
        #region Member
        private ObjectResult<sp_GSCS010_StockControlProcess_SearchAll_Result> lt_Result = null;
        private sp_GSCS010_StockControlProcess_SearchAll_Result ta_Result = null;
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

        private ObjectResult<sp_GSCS010_StockControlProcess_SearchAll_Result> ResultList
        {
            get { return lt_Result; }
            set { lt_Result = value; }
        }

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

        public List<sp_GSCS010_StockControlProcess_SearchAll_Result> DataLoading(int? CustomerID, int? WarehouseID, String ShipmentNo, DateTime? PickingDateFrom, DateTime? PickingDateTo, int? FinalDestinationID, int? shippingCustomerID)
        {
            try
            {
                return Database.ShippingEntity.sp_GSCS010_StockControlProcess_SearchAll(customerID:CustomerID
                                                                                        , dCID:WarehouseID
                                                                                        , shipmentNo:ShipmentNo
                                                                                        , pickingDateFrom:PickingDateFrom
                                                                                        , pickingDateTo:PickingDateTo
                                                                                        , finalDestinationID:FinalDestinationID
                                                                                        , shippingCustomerID: shippingCustomerID).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //ResultList = Database.sp_GSCS010_StockControl_SearchAll(CustomerID, WarehouseID, PickingDateFrom, PickingDateTo, ShipmentNo, FinalDestinationID);
            //return ResultList;
        }

        public List<sp_GSCS012_StockControlDetail_Search_Result> ViewDetail(String ShipmentNo, String PickingNo)
        {
            try
            {
                return Database.ShippingEntity.sp_GSCS012_StockControlDetail_Search(shipmentNo: ShipmentNo, pickingNo: PickingNo).ToList();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void SavePickingData(string UpdateUser, string xml)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("PickingNo", PickingNo);
                hs.Add("UpdateUser", UpdateUser);
                hs.Add("XMLData", xml);
                Database.ExecuteNonQuery("sp_GSCS012_StockControlDetail_Save", hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SaveBookStockData(string ShipmentNo, string PickingNo, int? WarehouseID, int? OwnerID, int LineNo, string CreateUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("PickingNo", PickingNo);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("OwnerID", OwnerID);
                hs.Add("LineNo", LineNo);
                hs.Add("CreateUser", CreateUser);
                Database.ExecuteNonQuery("sp_GSCS010_StockControlEdit_BookStock", hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

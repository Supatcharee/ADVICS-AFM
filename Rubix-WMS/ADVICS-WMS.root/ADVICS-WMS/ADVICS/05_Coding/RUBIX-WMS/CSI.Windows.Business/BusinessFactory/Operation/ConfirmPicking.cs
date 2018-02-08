/*
 * 23 Jan 2013:
 * 1. add new function "GetSpecificStatusId"
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Runtime.Remoting.Contexts;
using Rubix.Framework;
using System.Transactions;
using System.Collections;
using Newtonsoft.Json;
using System.Data;

namespace CSI.Business.Operation
{
    public class ConfirmPicking : CSI.Business.BusinessFactory.Report.Base.BaseReport
    {
        #region Member
        private ObjectResult<sp_HPCS020_ConfirmPicking_SearchAll_Result> lt_Result = null;
        private sp_HPCS020_ConfirmPicking_SearchAll_Result ta_Result = null;
        #endregion

        #region Properties
        private ObjectResult<sp_HPCS020_ConfirmPicking_SearchAll_Result> ResultList
        {
            get { return lt_Result; }
            set { lt_Result = value; }
        }
        public sp_HPCS020_ConfirmPicking_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_HPCS020_ConfirmPicking_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        public Object SelectData
        {
            set { ta_Result = (sp_HPCS020_ConfirmPicking_SearchAll_Result)value; }
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
        public int LineNo
        {
            get { return ResultData.LineNo; }
            set { ResultData.LineNo = value; }
        }
        public long? SortedLineNo
        {
            get { return ResultData.SortedLineNo; }
            set { ResultData.SortedLineNo = value; }
        }
        public int Installment
        {
            get { return ResultData.Installment; }
            set { ResultData.Installment = value; }
        }
        public int? ProductID
        {
            get { return ResultData.ProductID; }
            set { ResultData.ProductID = value; }
        }
        public string ProductCode
        {
            get { return ResultData.ProductCode; }
            set { ResultData.ProductCode = value; }
        }
        public string ProductName
        {
            get { return ResultData.ProductName; }
            set { ResultData.ProductName = value; }
        }
        public int? ProductConditionID
        {
            get { return ResultData.ProductConditionID; }
            set { ResultData.ProductConditionID = value; }
        }
        public string ProductConditionName
        {
            get { return ResultData.ProductConditionName; }
            set { ResultData.ProductConditionName = value; }
        }
        public string PortOfLoadingName
        {
            get { return ResultData.PortOfLoadingName; }
            set { ResultData.PortOfLoadingName = value; }
        }
        public string PortOfDischargeName
        {
            get { return ResultData.PortOfDischargeName; }
            set { ResultData.PortOfDischargeName = value; }
        }
	    public string FinalDestinationName
        {
            get { return ResultData.FinalDestinationName; }
            set { ResultData.FinalDestinationName = value; }
        }
        public decimal? Qty
        {
            get { return ResultData.Qty; }
            set { ResultData.Qty = value; }
        }
        public int? LocationID
        {
            get { return ResultData.LocationID; }
            set { ResultData.LocationID = value; }
        }
        public string LocationCode
        {
            get { return ResultData.LocationCode; }
            set { ResultData.LocationCode = value; }
        }
        public decimal ActualQty
        {
            get { return ResultData.ActualQty; }
            set { ResultData.ActualQty = value; }
        }
        public int PickingLineSeq
        {
            get { return ResultData.PickingLineSeq; }
            set { ResultData.PickingLineSeq = value; }
        }
        public int OwnerID
        {
            get { return ResultData.OwnerID; }
            set { ResultData.OwnerID = value; }
        }
        public int? WarehouseID
        {
            get { return ResultData.WarehouseID; }
            set { ResultData.WarehouseID = value; }
        }
        public int? Kanban
        {
            get { return ResultData.Kanban; }
            set { ResultData.Kanban = value; }
        }
        public int Pallet
        {
            get { return ResultData.Pallet; }
            set { ResultData.Pallet = value; }
        }
        public int sumKanban
        {
            get { return ResultData.sumKanban; }
            set { ResultData.Kanban = value; }
        }
        public int sumPallet
        {
            get { return ResultData.sumPallet; }
            set { ResultData.Pallet = value; }
        }
        public int? UnitOfOrderQty
        {
            get { return ResultData.UnitOfOrderQty; }
            set { ResultData.UnitOfOrderQty = value; }
        }
        public string PalletNo
        {
            get { return ResultData.PalletNo; }
            set { ResultData.PalletNo = value; }
        }
        public string LotNo
        {
            get { return ResultData.LotNo; }
            set { ResultData.LotNo = value; }
        }
        #endregion  
        
       public DataTable DataLoading(int? OwnerID, int? WarehouseID, String ShipmentNo, String PickingNo, 
                                    DateTime? pickDateFrom, DateTime? pickDateTo, int allStatus, 
                                    int? shippingCustomerID, DateTime? deliveryDateFrom,  DateTime? deliveryDateTo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("pickDateFrom", pickDateFrom);
            hs.Add("pickDateTo", pickDateTo);
            hs.Add("allStatus", allStatus);
            hs.Add("shippingCustomerID", shippingCustomerID);
            hs.Add("deliveryDateFrom", deliveryDateFrom);
            hs.Add("deliveryDateTo", deliveryDateTo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmPicking/DataLoading", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

       public DataSet DetailLoading(string ShipmentNo, string PickingNo, int LineNo)
       {
           try
           {
               Hashtable hs = new Hashtable();
               hs.Add("ShipmentNo", ShipmentNo);
               hs.Add("PickingNo", PickingNo);
               hs.Add("LineNo", LineNo);
               string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmPicking/DetailLoading", hs);
               return JsonConvert.DeserializeObject<DataSet>(strResult);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public void SaveConfirmPicking(string ShipmentNo, string PickingNo, int LineNo, DataTable dtRMTag)
       {
           DataSet ds = new DataSet("DataSet");
           DataTable dt = new DataTable("DataTable");
           try
           {              
               Hashtable hs = new Hashtable();
               hs.Add("ShipmentNo", ShipmentNo);
               hs.Add("PickingNo", PickingNo);
               hs.Add("LineNo", LineNo);
               hs.Add("CurrentUser", AppConfig.UserLogin);

               dt = dtRMTag.Copy();
               dt.TableName = "DataTable";
               ds.Tables.Add(dt);

               string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmPicking/SaveConfirmPicking", hs, JsonConvert.SerializeObject(ds.GetXml()));
           }
           catch (Exception ex)
           {
               throw ex;
           }
           finally
           {
               ds.Tables.Clear();
               ds = null;
               dt = null;
           }
       }

        public bool CheckWorkMethod(int? OwnerID, int? WarehouseID, out string messageId)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);

            messageId = string.Empty;

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmPicking/CheckWorkMethod", hs);
                int? result = JsonConvert.DeserializeObject<int?>(strResult);

                if (result == null || Convert.ToInt32(result.Value) == 0)
                {
                    messageId = "I0106";
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }                       
        }

        public List<sp_HPCS020_ConfirmPicking_GetPickingDetail_Result> LoadDetailPicking(String ShipmentNo, String PickingNo ,int LineNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("LineNo", LineNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmPicking/LoadDetailPicking", hs);
                return JsonConvert.DeserializeObject<List<sp_HPCS020_ConfirmPicking_GetPickingDetail_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public List<sp_HPCS020_ConfirmPicking_GetLocation_Result> GetLocation(String ShipmentNo, String PickingNo, int? LineNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("LineNo", LineNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmPicking/GetLocation", hs);
                return JsonConvert.DeserializeObject<List<sp_HPCS020_ConfirmPicking_GetLocation_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public List<sp_HPCS020_ConfirmPicking_GetLocation_Result> GetQuantity(String ShipmentNo, String PickingNo, int? LineNo,string LocationCode)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("LineNo", LineNo);
            hs.Add("LocationCode", LocationCode);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmPicking/GetQuantity", hs);
                return JsonConvert.DeserializeObject<List<sp_HPCS020_ConfirmPicking_GetLocation_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveConfirmPickingData(string CreateUser,string resultXML)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("Installment", Installment);
            hs.Add("PickingNo", PickingNo);
            hs.Add("LineNo", LineNo);
            hs.Add("CreateUser", CreateUser);
            hs.Add("Kanban", Kanban);
            hs.Add("Pallet", Pallet);

            try
            {
                RubixWebAPI.ExecuteObjectResult("ConfirmPicking/SaveConfirmPickingData", hs, JsonConvert.SerializeObject(resultXML));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveConfirm()
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("LocationID", LocationID);
            hs.Add("ProductID", ProductID);
            hs.Add("ProductConditionID", ProductConditionID);
            hs.Add("LineNo", LineNo);
            hs.Add("PickingLineSeq", PickingLineSeq);
            hs.Add("ActualQty", ActualQty);
            hs.Add("UnitOfOrderQty", UnitOfOrderQty);
            hs.Add("PalletNo", PalletNo);
            hs.Add("User", AppConfig.UserLogin);
            hs.Add("LotNo", LotNo);
            
            try
            {
                RubixWebAPI.ExecuteObjectResult("ConfirmPicking/SaveConfirm", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Confirm(string resultXML)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("ProductID", ProductID);
            hs.Add("ProductConditionID", ProductConditionID);
            hs.Add("LineNo", LineNo);
            hs.Add("PickingLineSeq", PickingLineSeq);
            hs.Add("ActualQty", ActualQty);
            hs.Add("UnitOfOrderQty", UnitOfOrderQty);
            hs.Add("PalletNo", PalletNo);
            hs.Add("User", AppConfig.UserLogin);
            hs.Add("LotNo", LotNo);

            try
            {
                RubixWebAPI.ExecuteObjectResult("ConfirmPicking/Confirm", hs, JsonConvert.SerializeObject(resultXML));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ResetConfirmFlag()
        {
            try
            {
                RubixWebAPI.ExecuteObjectResult("ConfirmPicking/ResetConfirmFlag");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckActualQtyInStockQty()
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("LineNo", LineNo);
            hs.Add("PickingLineSeq", PickingLineSeq);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmPicking/CheckActualQtyInStockQty", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT020_ShipmentLabel_GetData_Result> PrintShipmentLabel(string shipmentNo, string pickingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("shipmentNo", shipmentNo);
            hs.Add("pickingNo", pickingNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ConfirmPicking/PrintShipmentLabel", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT020_ShipmentLabel_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<int?> GetSpecificStatusId(bool all)
        {
            List<int?> ListStatus = new List<int?>();
            if (all)
            {
                ListStatus.AddRange(new int?[] { 
                    Common.Status.PickingInstructionIssued
                    , Common.Status.CompletePicking
                    , Common.Status.CompleteShipping
                    , Common.Status.DeliveryNoteIssued});
            }
            else 
            {
                ListStatus.AddRange(new int?[] { 
                    Common.Status.PickingInstructionIssued});
            }
            return ListStatus;
        }
    }
}

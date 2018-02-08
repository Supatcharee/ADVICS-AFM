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
using System.Data;

namespace CSI.Business.Operation
{
    public class ConfirmPicking : CSI.Business.BusinessFactory.Report.Base.BaseReport
    {
        #region Member
        private ObjectResult<sp_HPCS020_ConfirmPicking_SearchAll_Result> lt_Result = null;
        private sp_HPCS020_ConfirmPicking_SearchAll_Result ta_Result = null;
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
        
        public DataTable DataLoading(int? OwnerID, int? WarehouseID, String ShipmentNo, String PickingNo, DateTime? PickDateFrom
                                     , DateTime? PickDateTo, int AllStatus, int? CustomerID, DateTime? DeliveryDateFrom, DateTime? DeliveryDateTo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("PickingNo", PickingNo);
                hs.Add("PickDateFrom", PickDateFrom);
                hs.Add("PickDateTo", PickDateTo);
                hs.Add("AllStatus", AllStatus);
                hs.Add("CustomerID", CustomerID);
                hs.Add("DeliveryDateFrom", DeliveryDateFrom);
                hs.Add("DeliveryDateTo", DeliveryDateTo);

                return Database.ExecuteDataSet("sp_HPCS020_ConfirmPicking_SearchAll", hs).Tables[0];
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        
        public DataSet DetailLoading(String ShipmentNo, String PickingNo, int LineNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("PickingNo", PickingNo);
                hs.Add("LineNo", LineNo);
                return Database.ExecuteDataSet("sp_HPCS022_ConfirmPickingDetail_GetDetail", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveConfirmPicking(string ShipmentNo, string PickingNo, int LineNo, string xmlRMTag, string CurrentUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("PickingNo", PickingNo);
                hs.Add("LineNo", LineNo);
                hs.Add("xmlRMTag", xmlRMTag);
                hs.Add("CurrentUser", CurrentUser);

                Database.ExecuteNonQuery("sp_HPCS022_ConfirmPickingDetail_Confirm", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int? CheckWorkMethod(int? OwnerID, int? WarehouseID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                Hashtable hsOut = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hsOut.Add("result", "");
                Database.ExecuteNonQuery("sp_HPCS020_ConfirmPicking_CheckWorkMethod", hs, ref hsOut);

                return Convert.ToInt32(hsOut["result"]);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }

        public List<sp_HPCS020_ConfirmPicking_GetPickingDetail_Result> LoadDetailPicking(String ShipmentNo, String PickingNo ,int LineNo)
        {
            try
            {
                return Database.PickingEntity.sp_HPCS020_ConfirmPicking_GetPickingDetail(shipmentNo: (ShipmentNo == String.Empty ? null : ShipmentNo)
                                                                                         , pickingNo: (PickingNo == String.Empty ? null : PickingNo)
                                                                                         , lineNo: LineNo).ToList();
            }
            catch (Exception ex)
            {                
                throw ex;
            }

        }

        public List<sp_HPCS020_ConfirmPicking_GetLocation_Result> GetLocation(String ShipmentNo, String PickingNo, int? LineNo)
        {
            try
            {
                return Database.PickingEntity.sp_HPCS020_ConfirmPicking_GetLocation(shipmentNO: (ShipmentNo == String.Empty ? null : ShipmentNo)
                                                                                     , pickingNo: (PickingNo == String.Empty ? null : PickingNo)
                                                                                     , lineNo: LineNo).ToList();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }

        public List<sp_HPCS020_ConfirmPicking_GetLocation_Result> GetQuantity(String ShipmentNo, String PickingNo, int? LineNo,string LocationCode)
        {
            try
            {
                return Database.PickingEntity.sp_HPCS020_ConfirmPicking_GetLocation(shipmentNO: (ShipmentNo == String.Empty ? null : ShipmentNo)
                                                                                      , pickingNo: (PickingNo == String.Empty ? null : PickingNo)
                                                                                      , lineNo: LineNo).Where(c => c.LocationCode == LocationCode).ToList();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public void SaveConfirmPickingData(string CreateUser,string resultXML)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("Installment", Installment);
                hs.Add("PickingNo", PickingNo);
                hs.Add("LineNo", LineNo);
                hs.Add("UpdateUser", CreateUser);
                hs.Add("Kanban", Kanban);
                hs.Add("Pallet", Pallet);
                hs.Add("xmlResult", resultXML);

                Database.ExecuteNonQuery("sp_HPCS021_ConfirmPicking_SavePickingDetail",hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SaveConfirm(string User)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ShipmentNO", ShipmentNo);
                hs.Add("PickingNo", PickingNo);
                hs.Add("LocationID", LocationID);
                hs.Add("ProductID", ProductID);
                hs.Add("ProductConditionID", ProductConditionID);
                hs.Add("LineNo", LineNo);
                hs.Add("PickingLineSeq", PickingLineSeq);
                hs.Add("ActualQty", ActualQty);
                hs.Add("UnitOfOrderQty", UnitOfOrderQty);
                hs.Add("PalletNo", PalletNo);
                hs.Add("User", User);
                hs.Add("LotNo", LotNo);
                Database.ExecuteNonQuery("sp_HPCS020_ConfirmPicking_SaveConfirm", hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Confirm(string resultXML, string User)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ShipmentNO", ShipmentNo);
                hs.Add("PickingNo", PickingNo);
                hs.Add("ProductID", ProductID);
                hs.Add("ProductConditionID", ProductConditionID);
                hs.Add("LineNo", LineNo);
                hs.Add("PickingLineSeq", PickingLineSeq);
                hs.Add("ActualQty", ActualQty);
                hs.Add("UnitOfOrderQty", UnitOfOrderQty);
                hs.Add("PalletNo", PalletNo);
                hs.Add("User", User);
                hs.Add("LotNo", LotNo);
                hs.Add("xml", resultXML);
                hs.Add("ByWindow", 1);

                Database.ExecuteNonQuery("sp_HPCS020_ConfirmPicking_Confirm", hs);
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
                Database.ExecuteNonQuery("sp_HPCS020_ConfirmPicking_ResetConfirmFlag");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean CheckActualQtyInStockQty()
        {
            try
            {
                Hashtable hs = new Hashtable();
                Hashtable hsOut = new Hashtable();
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("PickingNo", PickingNo);
                hs.Add("intLineNo", LineNo);
                hs.Add("intPickingLineSeq", PickingLineSeq);
                hsOut.Add("result", "");
                Database.ExecuteNonQuery("HPCS021_ConfirmPicking_CheckActualQtyInStockQty", hs, ref hsOut);

                // don't allow confirm by screen
                if (hsOut["result"] ==null || Convert.ToInt32(hsOut["result"]) == 0)//result????
                {                    
                    return false;
                }
                return true;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT020_ShipmentLabel_GetData_Result> PrintShipmentLabel(string shipmentNo, string pickingNo)
        {
            try
            {
                return Database.ReportEntity.sp_RPT020_ShipmentLabel_GetData(shipmentNo: shipmentNo, pickingNo: pickingNo).ToList();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }        
    }
}

/*
 * 18 Jan 2013: 
 * 1. add method for check whether can show qty level1
 * 22 Jan 2013: 
 * 1. add new method for get ratio for convert to inventory unit
 * 23 Jan 2013: 
 * 1. add new function "GetSpecificStatusId"
 * 7 Feb 2013:
 * 1. modify GetPickingHeader function
 * 12 Feb 2013:
 * 1. modify GetProduct Function
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
using System.Data;
using Newtonsoft.Json;
using System.IO;

namespace CSI.Business.Operation
{
    public class ShippingInstruction
    {
        #region Member
        private sp_FSES010_ShippingInstruction_SearchAll_Result ta_Result = null;

        struct ShippingInstructionStruct
        {
            public sp_FSES010_ShippingInstruction_SearchAll_Result ResultData;
            public string ResultXML;
        }

        struct TransferInstructionSaveStruct
        {
            public DataTable ItemList;
            public int NumberOfDetail;
            public List<sp_FSES012_TransportDetail_Search_Result> TransportChargeSaveList;
            public List<sp_FSES012_TransportDetail_Search_Result> TransportChargeDeleteList;
            public List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result> OtherChargeSaveList;
            public List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result> OtherChargeDeleteList;
            public sp_FSES010_ShippingInstruction_SearchAll_Result ResultData;
            public DateTime ArrivalDate;
            public string ReceivingNo;
            public int SupplierID;
        }

        struct TransferInstructionStruct
        {
            public int? OwnerID;
            public string ShipmentNo;
            public string PickingNo;
            public string ReceivingNo;
            public int? FromWarehouseID;
            public int? ToWarehouseID;
            public int IsShowAllStatus;
        }
        #endregion

        #region Properties
        public Object SelectData
        {
            set { ta_Result = (sp_FSES010_ShippingInstruction_SearchAll_Result)value; }
        }
        public sp_FSES010_ShippingInstruction_SearchAll_Result ResultData
        {
            get
            {
                if (ta_Result == null)
                {
                    ta_Result = new sp_FSES010_ShippingInstruction_SearchAll_Result();
                }
                return ta_Result;
            }
            set { ta_Result = value; }
        }
        public string PickingNo
        {
            get { return ResultData.PickingNo; }
            set { ResultData.PickingNo = value; }
        }
        public int? StatusID
        {
            get { return ResultData.StatusID; }
            set { ResultData.StatusID = value; }
        }
        public string SONo
        {
            get { return ResultData.SONo; }
            set { ResultData.SONo = value; }
        }
        public string StatusName
        {
            get { return ResultData.StatusName; }
            set { ResultData.StatusName = value; }
        }
        public string ShipmentNo
        {
            get { return ResultData.ShipmentNo; }
            set { ResultData.ShipmentNo = value; }
        }
        public int Installment
        {
            get { return ResultData.Installment; }
            set { ResultData.Installment = value; }
        }
        public int OwnerID
        {
            get { return ResultData.OwnerID; }
            set { ResultData.OwnerID = value; }
        }
        public string OwnerCode
        {
            get { return ResultData.OwnerCode; }
            set { ResultData.OwnerCode = value; }
        }
        public string OwnerName
        {
            get { return ResultData.OwnerName; }
            set { ResultData.OwnerName = value; }
        }
        public int CustomerID
        {
            get { return ResultData.CustomerID; }
            set { ResultData.CustomerID = value; }
        }
        public string CustomerCode
        {
            get { return ResultData.CustomerCode; }
            set { ResultData.CustomerCode = value; }
        }
        public string CustomerName
        {
            get { return ResultData.CustomerName; }
            set { ResultData.CustomerName = value; }
        }
        public int? WarehouseID
        {
            get { return ResultData.WarehouseID; }
            set { ResultData.WarehouseID = value; }
        }
        public string WarehouseCode
        {
            get { return ResultData.WarehouseCode; }
            set { ResultData.WarehouseCode = value; }
        }
        public string WarehouseName
        {
            get { return ResultData.WarehouseName; }
            set { ResultData.WarehouseName = value; }
        }
        public int? ShippingAreaID
        {
            get { return ResultData.ShippingAreaID; }
            set { ResultData.ShippingAreaID = value; }
        }
        public string ShippingAreaCode
        {
            get { return ResultData.ShippingAreaCode; }
            set { ResultData.ShippingAreaCode = value; }
        }
        public string ShippingAreaName
        {
            get { return ResultData.ShippingAreaName; }
            set { ResultData.ShippingAreaName = value; }
        }
        public DateTime? PickingDate
        {
            get { return ResultData.PickingDate; }
            set { ResultData.PickingDate = value; }
        }
        public DateTime? VanningDate
        {
            get { return ResultData.VanningDate; }
            set { ResultData.VanningDate = value; }
        }
        public DateTime? TransportationDate
        {
            get { return ResultData.TransportationDate; }
            set { ResultData.TransportationDate = value; }
        }
        public DateTime? CutDate
        {
            get { return ResultData.CutDate; }
            set { ResultData.CutDate = value; }
        }
        public DateTime ETD
        {
            get { return ResultData.ETD; }
            set { ResultData.ETD = value; }
        }

        public DateTime? ETDActual
        {
            get { return ResultData.ETDActual; }
            set { ResultData.ETDActual = value; }
        }

        public DateTime? ETA
        {
            get { return ResultData.DeliveryDate; }
            set { ResultData.DeliveryDate = value; }
        }
        public string AgentSeal
        {
            get { return ResultData.AgentSeal; }
            set { ResultData.AgentSeal = value; }
        }
        public string   InspectionSeal
        {
            get { return ResultData.InspectionSeal; }
            set { ResultData.InspectionSeal = value; }
        }
        public string InvoiceNo
        {
            get { return ResultData.InvoiceNo; }
            set { ResultData.InvoiceNo = value; }
        }
        public string BookingNo
        {
            get { return ResultData.BookingNo; }
            set { ResultData.BookingNo = value; }
        }
        public string VesselName1
        {
            get { return ResultData.VesselName1; }
            set { ResultData.VesselName1 = value; }
        }
        public string VesselName2
        {
            get { return ResultData.VesselName2; }
            set { ResultData.VesselName2 = value; }
        }
        public string AgentOwner
        {
            get { return ResultData.AgentOwner; }
            set { ResultData.AgentOwner = value; }
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
        public string FinalDestinationLongName
        {
            get { return ResultData.FinalDestinationLongName; }
            set { ResultData.FinalDestinationLongName = value; }
        }
        public string Remark
        {
            get { return ResultData.Remark; }
            set { ResultData.Remark = value; }
        }
        public bool ShipCompleteFlag
        {
            get { return ResultData.ShipCompleteFlag; }
            set { ResultData.ShipCompleteFlag = value; }
        }
        public DateTime? ShipCompleteDate
        {
            get { return ResultData.ShipCompleteDate; }
            set { ResultData.ShipCompleteDate = value; }
        }
        public decimal? Freight
        {
            get { return ResultData.Freight; }
            set { ResultData.Freight = value; }
        }
        public int? CurrencyID
        {
            get { return ResultData.CurrencyID; }
            set { ResultData.CurrencyID = value; }
        }
        public DateTime CreateDate
        {
            get { return ResultData.CreateDate; }
            set { ResultData.CreateDate = value; }
        }
        public string CreateUser
        {
            get { return ResultData.CreateUser; }
            set { ResultData.CreateUser = value; }
        }
        public DateTime? UpdateDate
        {
            get { return ResultData.UpdateDate; }
            set { ResultData.UpdateDate = value; }
        }
        public string UpdateUser
        {
            get { return ResultData.UpdateUser; }
            set { ResultData.UpdateUser = value; }
        }
       #endregion
        
        #region FSES010 Shipping Instruction
        public List<sp_FSES010_ShippingInstruction_SearchAll_Result> DataLoading(int? OwnerID
            , String ShipmentNo
            , String PickingNo
            , int? CustomerID
            , int? WarehouseID
            , int IsShowAllStatus
            , int IsActual)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("CustomerID", CustomerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("IsShowAllStatus", IsShowAllStatus);
            hs.Add("IsActual", IsActual);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_FSES010_ShippingInstruction_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteShippingData()
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("Installment", Installment);
            hs.Add("PickingNo", PickingNo);

            try
            {
                RubixWebAPI.ExecuteObjectResult("ShippingInstruction/DeleteShippingData", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CanShowQtyLevel1()
        {
            string canShow = Common.SystemConfig.GetShowQtyLevel1();
            return canShow == "1";
        }

        #endregion

        #region FSES011 Shipping Instruction
        public DataTable loadTransportCharge(string ShipmentNo, string PickingNo, int Installment)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("Installment", Installment);

            try
            {
                return RubixWebAPI.ExecuteDataTable("ShippingInstruction/loadTransportCharge", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable loadOtherCharge(string ShipmentNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);

            try
            {
                return RubixWebAPI.ExecuteDataTable("ShippingInstruction/loadOtherCharge", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<sp_FSES011_ShippingInstruction_SearchDetail_Result> DataloadingDetail(String ShipmentNo, String PickingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/DataloadingDetail", hs);
                return JsonConvert.DeserializeObject<List<sp_FSES011_ShippingInstruction_SearchDetail_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_FSES012_TransportDetail_Search_Result> GetShippingTransDetail(string ShipmentNo, string PickingNo, int Installment)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("Installment", Installment);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/GetShippingTransDetail", hs);
                return JsonConvert.DeserializeObject<List<sp_FSES012_TransportDetail_Search_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result> LoadShippingOtherCharge(string ShipmentNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/LoadShippingOtherCharge", hs);
                return JsonConvert.DeserializeObject<List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveShippingInstructionData(string ResultXML, int NumberOfDetail, List<string> fileList, out string outShipmentNo, out string outPickingNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("NumberOfDetail", NumberOfDetail);
                ResultData.OwnerCode = "OwnerCode";
                ResultData.CustomerCode = "CustomerCode";
                ResultData.CustomerName = "CustomerName";
                ShippingInstructionStruct stc;
                stc.ResultData = ResultData;
                stc.ResultXML = ResultXML;
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/SaveShippingInstructionData", hs, JsonConvert.SerializeObject(stc));
                string output = JsonConvert.DeserializeObject<string>(strResult);

                outShipmentNo = output.Split('|')[0];
                outPickingNo = output.Split('|')[1];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FSES011 : ShippingInstruction -- Transport Charge
        public void SaveTransportDetail(sp_FSES012_TransportDetail_Search_Result data)
        {
            try
            {
                RubixWebAPI.ExecuteObjectResult("ShippingInstruction/SaveTransportDetail", JsonConvert.SerializeObject(data));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteTransportDetail(int seq)
        {
            Hashtable hs = new Hashtable();
            hs.Add("seq", seq);

            try
            {
                RubixWebAPI.ExecuteObjectResult("ShippingInstruction/DeleteTransportDetail", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FSES011 : ShippingInstruction -- Other Charge
        public void SaveOtherChargeDetail(sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result data)
        {
            try
            {
                RubixWebAPI.ExecuteObjectResult("ShippingInstruction/SaveOtherChargeDetail", JsonConvert.SerializeObject(data));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteOtherChargeDetail(int seq)
        {
            Hashtable hs = new Hashtable();
            hs.Add("seq", seq);

            try
            {
                RubixWebAPI.ExecuteObjectResult("ShippingInstruction/DeleteOtherChargeDetail", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FSES020_TransferInstruction
        public DataTable TransferInstructionSearchAll(int? OwnerID, string ShipmentNo, string PickingNo, string ReceivingNo, int? FromWarehouseID, int? ToWarehouseID, int IsShowAllStatus)
        {
            TransferInstructionStruct stc;
            stc.OwnerID = OwnerID;
            stc.ShipmentNo = ShipmentNo;
            stc.PickingNo = PickingNo;
            stc.ReceivingNo = ReceivingNo;
            stc.FromWarehouseID = FromWarehouseID;
            stc.ToWarehouseID = ToWarehouseID;
            stc.IsShowAllStatus = IsShowAllStatus;

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/TransferInstructionSearchAll", JsonConvert.SerializeObject(stc));
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool TransferInstructionCheckStatus(string ShipmentNo, string PickingNo, string ReceivingNo)
        {

            TransferInstructionStruct stc;
            stc.ShipmentNo = ShipmentNo;
            stc.PickingNo = PickingNo;
            stc.ReceivingNo = ReceivingNo;
            stc.OwnerID = null;
            stc.FromWarehouseID = null;
            stc.ToWarehouseID = null;
            stc.IsShowAllStatus = 0;

            string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/TransferInstructionCheckStatus", JsonConvert.SerializeObject(stc));
            return JsonConvert.DeserializeObject<bool>(strResult);

        }

        public void TransferInstructionDelete()
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("Installment", Installment);
            hs.Add("PickingNo", PickingNo);
            hs.Add("UpdateUser", UpdateUser);

            try
            {
                RubixWebAPI.ExecuteObjectResult("ShippingInstruction/TransferInstructionDelete", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        #endregion

        #region FSES021_TransferInstruction
        public void SaveTransferInstructionData(DataTable ItemList, int NumberOfDetail,
                                        List<sp_FSES012_TransportDetail_Search_Result> TransportChargeSaveList,
                                        List<sp_FSES012_TransportDetail_Search_Result> TransportChargeDeleteList,
                                        List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result> OtherChargeSaveList,
                                        List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result> OtherChargeDeleteList,
                                        DateTime ArrivalDate, string ReceivingNo, int SupplierID)
        {
            try
            {
                TransferInstructionSaveStruct stc = new TransferInstructionSaveStruct();
                stc.ItemList = ItemList;
                stc.NumberOfDetail = NumberOfDetail;
                stc.TransportChargeSaveList = TransportChargeSaveList;
                stc.TransportChargeDeleteList = TransportChargeDeleteList;
                stc.OtherChargeSaveList = OtherChargeSaveList;
                stc.OtherChargeDeleteList = OtherChargeDeleteList;
                stc.ResultData = ResultData;
                stc.ArrivalDate = ArrivalDate;
                stc.ReceivingNo = ReceivingNo;
                stc.SupplierID = SupplierID;

                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/SaveTransferInstructionData", JsonConvert.SerializeObject(stc));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        
        public List<sp_HPCS030_UnplanPicking_SearchAll_Result> DataLoadingUnplan(int? OwnerID, String ShipmentNo, String PickingNo, int? CustomerID, int? WarehouseID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("CustomerID", CustomerID);
            hs.Add("WarehouseID", WarehouseID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/DataLoadingUnplan", hs);
                return JsonConvert.DeserializeObject<List<sp_HPCS030_UnplanPicking_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public tbt_PickingHeader GetPickingHeader(string ShipmentNo, int Installment, String PickingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("Installment", Installment);
            hs.Add("PickingNo", PickingNo);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/GetPickingHeader", hs);
                return JsonConvert.DeserializeObject<tbt_PickingHeader>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tbt_PickingHeader CreatePickingHeader()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/CreatePickingHeader");
                return JsonConvert.DeserializeObject<tbt_PickingHeader>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                
        public sp_FSES010_ShippingInstruction_LoadProductUnitInfo_Result LoadProductUnitInfo(int ProductID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/LoadProductUnitInfo", hs);
                return JsonConvert.DeserializeObject<sp_FSES010_ShippingInstruction_LoadProductUnitInfo_Result>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public sp_FSES010_ShippingInstruction_LoadFinalDestinationInfo_Result LoadFinalDesInfo(int FinalDestinationID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("FinalDestinationID", FinalDestinationID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/LoadFinalDesInfo", hs);
                return JsonConvert.DeserializeObject<sp_FSES010_ShippingInstruction_LoadFinalDestinationInfo_Result>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public string GetLastShipmentNo()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/GetLastShipmentNo");
                return JsonConvert.DeserializeObject<string>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }   
        }

        public string GetLastPickingNo()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/GetLastPickingNo");
                return JsonConvert.DeserializeObject<string>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
          
        public bool CanUpload()
        {           
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/CanUpload");
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<sp_Common_ProductUnit_Result> LoadProductUnit(int? TypeOfUnit, int? ProductID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("TypeOfUnit", TypeOfUnit);
            hs.Add("ProductID", ProductID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/LoadProductUnit", hs);
                return JsonConvert.DeserializeObject<List<sp_Common_ProductUnit_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public sp_FSES010_ShippingInstruction_GetInfoWhereShipmentNo_Result GetInfoWhereShippingNo(string ShipmentNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/GetInfoWhereShippingNo", hs);
                return JsonConvert.DeserializeObject<sp_FSES010_ShippingInstruction_GetInfoWhereShipmentNo_Result>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_common_LoadLot_Result> LoadLot(int? ProductID, int? WarehouseID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);
            hs.Add("WarehouseID", WarehouseID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/LoadLot", hs);
                return JsonConvert.DeserializeObject<List<sp_common_LoadLot_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_FSES010_LoadLotByProductCode_Result> LoadLotExcludePrefix(string ProductCode, int? WarehouseID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductCode", ProductCode);
            hs.Add("WarehouseID", WarehouseID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/LoadLotExcludePrefix", hs);
                return JsonConvert.DeserializeObject<List<sp_FSES010_LoadLotByProductCode_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsProductExists(string ProductCode, int OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductCode", ProductCode);
            hs.Add("OwnerID", OwnerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/IsProductExists", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tbm_Product GetProduct(string ProductCode, int OwnerID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductCode", ProductCode);
            hs.Add("OwnerID", OwnerID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/GetProduct", hs);
                return JsonConvert.DeserializeObject<tbm_Product>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tbm_ProductDefaultUnit GetProductDefaultUnit(int ProductID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/GetProductDefaultUnit", hs);
                return JsonConvert.DeserializeObject<tbm_ProductDefaultUnit>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tbm_ProductCondition GetDefaultProductCondition()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/GetDefaultProductCondition");
                return JsonConvert.DeserializeObject<tbm_ProductCondition>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_FSES013_ShippingByLot_Search_Result> GetLotList(int? ProductID, int? WarehouseID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ProductID", ProductID);
            hs.Add("WarehouseID", WarehouseID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/GetLotList", hs);
                return JsonConvert.DeserializeObject<List<sp_FSES013_ShippingByLot_Search_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public sp_FSES012_TransportDetail_TransportCharge_Search_Result getTransportCharge(int OwnerID, int CustomerID, int? WarehouseID, int TransportTypeID, int? FinalDestinationID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("CustomerID", CustomerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("TransportTypeID", TransportTypeID);
            hs.Add("FinalDestinationID", FinalDestinationID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/getTransportCharge", hs);
                return JsonConvert.DeserializeObject<sp_FSES012_TransportDetail_TransportCharge_Search_Result>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<int?> GetSpecificStatusId()
        {
            List<int?> ListStatus = new List<int?>();
            ListStatus.AddRange(new int?[] { 
                Common.Status.NewShippingEntry
                , Common.Status.StockHold
                , Common.Status.PickingInstructionIssued
                , Common.Status.CompletePicking
                , Common.Status.PackingInnstructionIssued
                , Common.Status.InCompletePacking
                , Common.Status.CompletePacking
                , Common.Status.DocumentShippingIssued
            });

            return ListStatus;
        }

        public List<int?> GetSpecificStatusIdNew()
        {
            List<int?> ListStatus = new List<int?>();
            ListStatus.AddRange(new int?[] { 
                Common.Status.NewShippingEntry
                , Common.Status.StockHold
                , Common.Status.PickingInstructionIssued
                , Common.Status.CompletePicking});

            return ListStatus;
        }
        public static decimal? GetRatioToInventoryUnit(int? TypeOfUnitID, int? ProductID)
        {
            return Common.UnitConvert.GetRatioToInventoryUnit(TypeOfUnitID, ProductID);
        }
        
        public DataTable TransferInstructionLoadDetail(String ShipmentNo, String PickingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingInstruction/TransferInstructionLoadDetail", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

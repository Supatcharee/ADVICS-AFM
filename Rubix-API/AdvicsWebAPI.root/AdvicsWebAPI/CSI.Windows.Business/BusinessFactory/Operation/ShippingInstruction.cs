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
using System.Transactions;
using Rubix.Framework;

namespace CSI.Business.Operation
{
    public class ShippingInstruction
    {
        #region Member
        private ObjectResult<sp_FSES010_ShippingInstruction_SearchAll_Result> lt_Result = null;
        private sp_FSES010_ShippingInstruction_SearchAll_Result ta_Result = null;
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
        public string CustomerCode
        {
            get { return ResultData.OwnerCode; }
            set { ResultData.OwnerCode = value; }
        }
        public string CustomerName
        {
            get { return ResultData.OwnerName; }
            set { ResultData.OwnerName = value; }
        }
        public int CustomerID
        {
            get { return ResultData.CustomerID; }
            set { ResultData.CustomerID = value; }
        }
        public string ShippingCustomerCode
        {
            get { return ResultData.CustomerCode; }
            set { ResultData.CustomerCode = value; }
        }
        public string ShippingCustomerName
        {
            get { return ResultData.CustomerName; }
            set { ResultData.CustomerName = value; }
        }
        public int? WarehouseID
        {
            get { return ResultData.WarehouseID; }
            set { ResultData.WarehouseID = value; }
        }
        public string DCCODE
        {
            get { return ResultData.WarehouseCode; }
            set { ResultData.WarehouseCode = value; }
        }
        public string DCLongName
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
        public DateTime? ETA
        {
            get { return ResultData.DeliveryDate; }
            set { ResultData.DeliveryDate = value; }
        }
        public DateTime? ETDActual
        {
            get { return ResultData.ETDActual; }
            set { ResultData.ETDActual = value; }
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
        
        #region Shipping Instruction
        public List<sp_FSES010_ShippingInstruction_SearchAll_Result> DataLoading(int? OwnerID, String ShipmentNo, String PickingNo, int? CustomerID, int? WarehouseID, int isShowAllStatus, int IsActual)
        {
            try
            {
                return Database.ShippingEntity.sp_FSES010_ShippingInstruction_SearchAll(ownerID: OwnerID, shipmentNo: (ShipmentNo == String.Empty ? null : ShipmentNo), pickingNo: (PickingNo == String.Empty ? null : PickingNo), customerID: CustomerID, warehouseID: WarehouseID, isShowAllStatus: isShowAllStatus, isActual: IsActual).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteShippingData()
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("Installment", Installment);
                hs.Add("PickingNo", PickingNo);
                Database.ExecuteNonQuery("sp_FSES010_ShippingInstruction_Delete", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public List<sp_HPCS030_UnplanPicking_SearchAll_Result> DataLoadingUnplan(int? OwnerID, String ShipmentNo, String PickingNo, int? CustomerID, int? WarehouseID)
        {
            try
            {
                return Database.PickingEntity.sp_HPCS030_UnplanPicking_SearchAll(ownerID: OwnerID, shipmentNo: (ShipmentNo == String.Empty ? null : ShipmentNo), pickingNo: (PickingNo == String.Empty ? null : PickingNo), customerID: CustomerID, warehouseID: WarehouseID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_FSES011_ShippingInstruction_SearchDetail_Result> DataloadingDetail(String ShipmentNo, String PickingNo)
        {
            try
            {
                return Database.ShippingEntity.sp_FSES011_ShippingInstruction_SearchDetail(shipmentNo: (ShipmentNo == String.Empty ? null : ShipmentNo), pickingNo: (PickingNo == String.Empty ? null : PickingNo)).ToList();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public tbt_PickingHeader GetPickingHeader(string ShipmentNo, int Installment ,  String PickingNo)
        {
            try
            {
                ObjectQuery<tbt_PickingHeader> query = (ObjectQuery<tbt_PickingHeader>)Database.PickingEntity.tbt_PickingHeader.Where(c => c.ShipmentNo == ShipmentNo && c.Installment == Installment && c.PickingNo == PickingNo);
                return query.Execute(MergeOption.OverwriteChanges).Single();
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
                return Database.PickingEntity.tbt_PickingHeader.CreateObject();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
                
        public sp_FSES010_ShippingInstruction_LoadProductUnitInfo_Result LoadProductUnitInfo(int ProductID)
        {
            try
            {
                return Database.ShippingEntity.sp_FSES010_ShippingInstruction_LoadProductUnitInfo(productID: ProductID).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public sp_FSES010_ShippingInstruction_LoadFinalDestinationInfo_Result LoadFinalDesInfo(int finalDestinationID)
        {
            try
            {
                return Database.ShippingEntity.sp_FSES010_ShippingInstruction_LoadFinalDestinationInfo(finalDestinationID:finalDestinationID).SingleOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SaveShippingInstructionData(string resultXML, int numberOfDetail, out string outShipmentNo, out string outPickingNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                Hashtable hsOut = new Hashtable();
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("PickingNo", PickingNo);
                hs.Add("Installment", Installment);
                hs.Add("OwnerID", OwnerID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ShippingAreaID", ShippingAreaID);
                hs.Add("PickingDate", PickingDate);
                hs.Add("VanningDate", VanningDate);
                hs.Add("TransportationDate", TransportationDate);
                hs.Add("CutDate", CutDate);
                hs.Add("ETD", ETD);
                hs.Add("ETDActual", ETDActual);
                hs.Add("ETA", ETA);
                hs.Add("AgentSeal", AgentSeal);
                hs.Add("InspectionSeal", InspectionSeal);
                hs.Add("InvoiceNo", InvoiceNo);
                hs.Add("BookingNo", BookingNo);
                hs.Add("VesselName1", VesselName1);
                hs.Add("VesselName2", VesselName2);
                hs.Add("AgentOwner", AgentOwner);
                hs.Add("PortOfLoadingID", PortOfLoadingID);
                hs.Add("PortOfDischargeID", PortOfDischargeID);
                hs.Add("FinalDestinationID", FinalDestinationID);
                hs.Add("Remark", Remark);
                hs.Add("ShipCompleteFlag", ShipCompleteFlag);
                hs.Add("ShipCompleteDate", ShipCompleteDate);
                hs.Add("Freight", Freight);
                hs.Add("CreateUser", CreateUser);
                hs.Add("NumberofDetails", numberOfDetail);
                hs.Add("xmlResult", resultXML);

                hsOut.Add("OutShipmentNo", "");
                hsOut.Add("OutPickingNo", "");
                Database.ExecuteNonQuery("sp_FSES011_ShippingInstruction_Save", hs, ref hsOut);

                outShipmentNo = hsOut["OutShipmentNo"].ToString();
                outPickingNo = hsOut["OutPickingNo"].ToString();
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
                Hashtable hs = new Hashtable();
                return Database.ExecuteDataSet("sp_FSES010_ShippingInstruction_GetShipmentNo", hs).Tables[0].Rows[0][0].ToString();

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
                Hashtable hs = new Hashtable();
                return Database.ExecuteDataSet("sp_FSES010_ShippingInstruction_GetPickingNo", hs).Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataTable loadTransportCharge(string ShipmentNo, string PickingNo , int Installment)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("PickingNo", PickingNo);
                hs.Add("Installment", Installment);
                return Database.ExecuteDataSet("sp_FSES010_TransportDetail_GetCharge", hs).Tables[0];

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        public DataTable loadOtherCharge(string iShipmentNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", iShipmentNo);
                return Database.ExecuteDataSet("sp_FSES010_ShippingInstruction_GetOtherCharge", hs).Tables[0];

            }
            catch (Exception ex)
            {
                 
                throw ex;
            }
        }
        
        public List<sp_FSES012_TransportDetail_Search_Result> GetShippingTransDetail(string ShipmentNo, string PickingNo, int installment)
        {
            try
            {
                return Database.ShippingEntity.sp_FSES012_TransportDetail_Search(shipmentNo: ShipmentNo, pickingNo: PickingNo, installment: installment).ToList();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        #region Shipping Instruction -- Transport Charge
        public void SaveTransportDetail(sp_FSES012_TransportDetail_Search_Result data)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("TransportSeq", data.TransportSeq);
                hs.Add("ShipmentNo", data.ShipmentNo);
                hs.Add("Installment", data.Installment);
                hs.Add("PickingNo", data.PickingNo);
                hs.Add("TruckCompanyID", data.TruckCompanyID);
                hs.Add("TransportTypeID", data.TransportTypeID);
                hs.Add("TransportCharge", data.TransportCharge);
                hs.Add("OutgoingCharge", data.OutgoingCharge);
                hs.Add("RegistrationNo", data.RegistrationNo);
                hs.Add("ContainerNo", data.ContainerNo);
                hs.Add("DriverName", data.DriverName);
                hs.Add("Remark", data.Remark);
                hs.Add("CreateUser", data.CreateUser);
                hs.Add("PlanIn", data.PlanIn);
                hs.Add("PlanOut", data.PlanOut);
                hs.Add("ActualIn", data.ActualIn);
                hs.Add("ActualOut", data.ActualOut);
                hs.Add("TotalShipWeight", data.TotalShipWeight);
                Database.ExecuteNonQuery("sp_FSES011_ShippingInstruction_TransportCharge_Save", hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteTransportDetail(int seq)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("TransportSeq", seq);
                Database.ExecuteNonQuery("sp_FSES011_ShippingInstruction_TransportCharge_Delete", hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        } 
        #endregion

        #region Shipping Instruction -- Other Charge
        public void SaveOtherChargeDetail(sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result data)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OtherChargeID", data.OtherChargeID);
                hs.Add("ShipmentNo", data.ShipmentNo);
                hs.Add("PickingNo", data.PickingNo);
                hs.Add("ChargeDate", data.ChargeDate);
                hs.Add("OtherCharge", data.OtherCharge);
                hs.Add("Remark", data.Remark);
                hs.Add("CreateUser", data.CreateUser);
                Database.ExecuteNonQuery("sp_FSES011_ShippingInstruction_OtherCharge_Save", hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteOtherChargeDetail(int seq)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OtherChargeID", seq);
                Database.ExecuteNonQuery("sp_FSES011_ShippingInstruction_OtherCharge_Delete", hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        
        public List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result> LoadShippingOtherCharge(string ShipmentNo)
        {
            try
            {
                return Database.ShippingEntity.sp_FSES012_ShippingOtherCharge_Other_Detail_Search(shipmentNo: ShipmentNo).ToList();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        public List<sp_Common_ProductUnit_Result> LoadProductUnit(int? typeOfUnit, int? ProductID)
        {
            try
            {
                return Database.CommonEntity.sp_Common_ProductUnit(selectUnitID: typeOfUnit, productID: ProductID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public sp_FSES010_ShippingInstruction_GetInfoWhereShipmentNo_Result GetInfoWhereShippingNo(string ShipmentNo)
        {
            try
            {
                return Database.ShippingEntity.sp_FSES010_ShippingInstruction_GetInfoWhereShipmentNo(shippingNo: ShipmentNo).SingleOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<sp_common_LoadLot_Result> LoadLot(int? ProductID, int? WarehouseID)
        {
            try
            {
                return Database.CommonEntity.sp_common_LoadLot(productID: ProductID, warehouseID: WarehouseID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<sp_FSES010_LoadLotByProductCode_Result> LoadLotExcludePrefix(string ProductCode, int? WarehouseID)
        {
            try
            {
                return Database.ShippingEntity.sp_FSES010_LoadLotByProductCode(productCode: ProductCode, warehouseID: WarehouseID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool IsProductExists(string ProductCode, int OwnerID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ProductCode", ProductCode);
                hs.Add("OwnerID", OwnerID);
                return (Database.ExecuteDataSet("sp_FSES010_IsProductCodeExists", hs).Tables[0].Rows.Count >= 1);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public tbm_Product GetProduct(string ProductCode, int OwnerID)
        {
            try
            {
                // 12 Feb 2013: add deleteFlag
                //tbm_Product prd = Database.MasterEntity.tbm_Product.FirstOrDefault(c => c.ProductCode == ProductCode && c.OwnerID == OwnerID);
                tbm_Product prd = Database.MasterEntity.tbm_Product.FirstOrDefault(c => c.ProductCode == ProductCode && c.OwnerID == OwnerID
                    && c.DeleteFlag == 0);

                tbm_Product result = null;
                if (prd != null)
                {
                    result = DataUtil.CopyEntity(prd);
                }

                // end 12 Feb 2013
                return result;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public tbm_ProductDefaultUnit GetProductDefaultUnit(int ProductID)
        {
            try
            {
                tbm_ProductDefaultUnit result = null;
                tbm_ProductDefaultUnit prd = Database.MasterEntity.tbm_ProductDefaultUnit.FirstOrDefault(c => c.ProductID == ProductID);
                if (prd != null)
                {
                    result = DataUtil.CopyEntity(prd);
                }
                return result;
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

                tbm_ProductCondition result = null;
                tbm_ProductCondition prd = Database.MasterEntity.tbm_ProductCondition.FirstOrDefault(c => c.ProductConditionID == 1);
                if (prd != null)
                {
                    result = DataUtil.CopyEntity(prd);
                }
                return result;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public List<sp_FSES013_ShippingByLot_Search_Result> GetLotList(int? ProductID, int? WarehouseID)
        {
            try
            {
                return Database.ShippingEntity.sp_FSES013_ShippingByLot_Search(productID: ProductID, warehouseID: WarehouseID).ToList();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        public sp_FSES012_TransportDetail_TransportCharge_Search_Result getTransportCharge(int OwnerID ,int? CustomerID , int? WarehouseID, int TransportTypeID, int? FinalDestinationID)
        {
            try
            {
                return Database.ShippingEntity.sp_FSES012_TransportDetail_TransportCharge_Search(ownerID: OwnerID
                                                                                                ,customerID: CustomerID
                                                                                                ,warehouseID:WarehouseID
                                                                                                ,transportTypeID:TransportTypeID
                                                                                                ,finalDestinationID: FinalDestinationID).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public bool CanShowQtyLevel1()
        {
            try
            {
                string canShow = Common.SystemConfig.GetShowQtyLevel1();
                return canShow == "1";
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public decimal? GetRatioToInventoryUnit(int? TypeOfUnitID, int? ProductID)
        {
            try
            {
                return Common.UnitConvert.GetRatioToInventoryUnit(TypeOfUnitID, ProductID);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        public DataTable TransferInstructionLoadDetail(string ShipmentNo, string PickingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            return Database.ExecuteDataSet("sp_FSES021_TransferInstruction_SearchDetail", hs).Tables[0];
        }

        public void TransferInstructionDelete()
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("Installment", Installment);
            hs.Add("UpdatedUser", UpdateUser);

            Database.ExecuteNonQuery("sp_FSES021_TransferInstruction_Delete", hs);
        }

        public bool TransferInstructionCheckStatus(string ShipmentNo, string PickingNo, string ReceivingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("ReceivingNo", ReceivingNo);
            return Convert.ToInt16(Database.ExecuteScalar("sp_FSES021_TransferInstruction_CheckStatus", hs)) == 1;
        }
        
        #region FSES021 : TransferInstruction
        public void SaveTransferInstructionData(DataTable ItemList, int NumberOfDetail,
                                        List<sp_FSES012_TransportDetail_Search_Result> TransportChargeSaveList,
                                        List<sp_FSES012_TransportDetail_Search_Result> TransportChargeDeleteList,
                                        List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result> OtherChargeSaveList,
                                        List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result> OtherChargeDeleteList,
                                        DateTime ArrivalDate, string ReceivingNo, int SupplierID)
        {
            try
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(ItemList);

                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("PickingNo", PickingNo);
                hs.Add("Installment", Installment);
                hs.Add("OwnerID", OwnerID);
                hs.Add("CustomerID", null);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("ShippingAreaID", ShippingAreaID);
                hs.Add("PickingDate", PickingDate);
                hs.Add("VanningDate", VanningDate);
                hs.Add("TransportationDate", TransportationDate);
                hs.Add("CutDate", CutDate);
                hs.Add("ETD", ETD);
                hs.Add("ETA", ETA);
                hs.Add("AgentSeal", AgentSeal);
                hs.Add("InspectionSeal", InspectionSeal);
                hs.Add("InvoiceNo", InvoiceNo);
                hs.Add("BookingNo", BookingNo);
                hs.Add("VesselName1", VesselName1);
                hs.Add("VesselName2", VesselName2);
                hs.Add("AgentOwner", AgentOwner);
                hs.Add("PortOfLoadingID", PortOfLoadingID);
                hs.Add("PortOfDischargeID", PortOfDischargeID);
                hs.Add("FinalDestinationID", FinalDestinationID);
                hs.Add("Remark", Remark);
                hs.Add("ShipCompleteFlag", ShipCompleteFlag);
                hs.Add("ShipCompleteDate", ShipCompleteDate);
                hs.Add("CreateUser", CreateUser);
                hs.Add("NumberofDetails", NumberOfDetail);
                hs.Add("ArrivalDate", ArrivalDate);
                hs.Add("ReceivingNo", ReceivingNo.Trim() == string.Empty ? null : ReceivingNo);
                hs.Add("SupplierID", SupplierID);
                hs.Add("xmlResult", ds.GetXml());

                DataTable dt = Database.ExecuteDataSet("sp_FSES021_TransferInstruction_Save", hs).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    this.ShipmentNo = ds.Tables[0].Rows[0]["ShipmentNo"].ToString();
                    this.PickingNo = ds.Tables[0].Rows[0]["PickingNo"].ToString();
                }

                ///////////////////////////////////////////////////////////////////
                ////////////Transport Charge Information
                if (TransportChargeSaveList != null)
                {
                    foreach (sp_FSES012_TransportDetail_Search_Result item in TransportChargeSaveList)
                    {
                        sp_FSES012_TransportDetail_Search_Result data = item;
                        data.ShipmentNo = this.ShipmentNo;
                        data.PickingNo = this.PickingNo;
                        data.Installment = 1;
                        data.CreateUser = CreateUser;
                        data.TruckCompanyCode = "";
                        data.TransportTypeName = "";
                        data.TruckCompanyCode = "";
                        data.TruckCompanyName = "";
                        data.TransportTypeCode = "";
                        data.TransportTypeName = "";
                        SaveTransportDetail(data);
                    }

                    foreach (sp_FSES012_TransportDetail_Search_Result data in TransportChargeDeleteList)
                    {
                        if (data.TransportSeq != 0)
                        {
                            DeleteTransportDetail(data.TransportSeq);
                        }
                    }
                }
                ///////////////////////////////////////////////////////////////////
                ////////////Other Charge Information

                if (OtherChargeSaveList != null)
                {
                    foreach (sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result item in OtherChargeSaveList)
                    {
                        sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result data = item;
                        data.ShipmentNo = this.ShipmentNo;
                        data.PickingNo = this.PickingNo;
                        data.CreateUser = CreateUser;
                        SaveOtherChargeDetail(data);
                    }

                    foreach (sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result data in OtherChargeDeleteList)
                    {
                        if (data.OtherChargeID != 0)
                        {
                            DeleteOtherChargeDetail(data.OtherChargeID);
                        }
                    }
                }
                ///////////////////////////////////////////////////////////////////
                ////////////Receiving Information
                hs.Clear();
                hs.Add("OwnerID", this.OwnerID);
                hs.Add("ReceivingNo", string.IsNullOrEmpty(ReceivingNo) ? null : ReceivingNo);
                hs.Add("Installment", this.Installment);
                hs.Add("WarehouseID", this.WarehouseID);
                hs.Add("SupplierID", SupplierID);
                hs.Add("ArrivalDate", ArrivalDate);
                hs.Add("Remark", this.Remark);
                hs.Add("CancelSlipFlag", 0);
                hs.Add("CreateUser", this.CreateUser);
                hs.Add("UpdateUser", this.UpdateUser);
                hs.Add("xmlDetail", ds.GetXml());
                hs.Add("XMLTrasport", null);
                hs.Add("XMLOther", null);
                Database.ExecuteNonQuery("sp_BRES011_ReceivingEntry_Save", hs).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion
                
        public DataTable TransferInstructionSearchAll(int? OwnerID, string ShipmentNo, string PickingNo, string ReceivingNo, int? fromWarehouseId, int? toWarehouseId, int isShowAllStatus)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("WarehouseIDFrom", fromWarehouseId);
            hs.Add("WarehouseIDTo", toWarehouseId);
            hs.Add("IsShowAllStatus", isShowAllStatus);
            return Database.ExecuteDataSet("sp_FSES020_TransferInstruction_SearchAll", hs).Tables[0];
        }

    }
}

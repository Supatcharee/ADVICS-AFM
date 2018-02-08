using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.Operation;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;

namespace RubixWebAPI.Controllers.Operation
{
    public class ShippingInstructionController : ApiController
    {
        struct ShippingInstructionStruct
        {
            public sp_FSES010_ShippingInstruction_SearchAll_Result ResultData;
            public string resultXML;
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

        ShippingInstruction obj = new ShippingInstruction();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID
            , String ShipmentNo
            , String PickingNo
            , int? CustomerID
            , int? WarehouseID
            , int IsShowAllStatus
            , int IsActual)
        {
            List<sp_FSES010_ShippingInstruction_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, ShipmentNo, PickingNo, CustomerID, WarehouseID, IsShowAllStatus, IsActual);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoadingUnplan(int? OwnerID, String ShipmentNo, String PickingNo, int? CustomerID, int? WarehouseID)
        {
            List<sp_HPCS030_UnplanPicking_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoadingUnplan(OwnerID, ShipmentNo, PickingNo, CustomerID, WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataloadingDetail(String ShipmentNo, String PickingNo)
        {
            List<sp_FSES011_ShippingInstruction_SearchDetail_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataloadingDetail(ShipmentNo, PickingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetPickingHeader(string ShipmentNo, int Installment, String PickingNo)
        {
            tbt_PickingHeader ResultReturn;

            try
            {
                ResultReturn = obj.GetPickingHeader(ShipmentNo, Installment, PickingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CreatePickingHeader()
        {
            tbt_PickingHeader ResultReturn;

            try
            {
                ResultReturn = obj.CreatePickingHeader();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadProductUnitInfo(int ProductID)
        {
            sp_FSES010_ShippingInstruction_LoadProductUnitInfo_Result ResultReturn;

            try
            {
                ResultReturn = obj.LoadProductUnitInfo(ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadFinalDesInfo(int FinalDestinationID)
        {
            sp_FSES010_ShippingInstruction_LoadFinalDestinationInfo_Result ResultReturn;

            try
            {
                ResultReturn = obj.LoadFinalDesInfo(FinalDestinationID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveShippingInstructionData(int NumberOfDetail)
        {
            string outShipmentNo;
            string outPickingNo;
            try
            {  
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                ShippingInstructionStruct stc = JsonConvert.DeserializeObject<ShippingInstructionStruct>(strParameterData);

                obj.ResultData = stc.ResultData;

                obj.SaveShippingInstructionData(stc.resultXML, NumberOfDetail, out outShipmentNo, out outPickingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, outShipmentNo + "|" + outPickingNo);
        }
                        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetLastShipmentNo()
        {
            string ResultReturn;

            try
            {
                ResultReturn = obj.GetLastShipmentNo();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetLastPickingNo()
        {
            string ResultReturn;

            try
            {
                ResultReturn = obj.GetLastPickingNo();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage loadTransportCharge(string ShipmentNo, string PickingNo, int Installment)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.loadTransportCharge(ShipmentNo, PickingNo, Installment);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage loadOtherCharge(string ShipmentNo)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.loadOtherCharge(ShipmentNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetShippingTransDetail(string ShipmentNo, string PickingNo, int Installment)
        {
            List<sp_FSES012_TransportDetail_Search_Result> ResultReturn;

            try
            {
                ResultReturn = obj.GetShippingTransDetail(ShipmentNo, PickingNo, Installment);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }



        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteShippingData(string ShipmentNo, int Installment, string PickingNo)
        {
            obj.ShipmentNo = ShipmentNo;
            obj.Installment = Installment;
            obj.PickingNo = PickingNo;

            try
            {
                obj.DeleteShippingData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadShippingOtherCharge(string ShipmentNo)
        {
            List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result> ResultReturn;

            try
            {
                ResultReturn = obj.LoadShippingOtherCharge(ShipmentNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadProductUnit(int? TypeOfUnit, int? ProductID)
        {
            List<sp_Common_ProductUnit_Result> ResultReturn;

            try
            {
                ResultReturn = obj.LoadProductUnit(TypeOfUnit, ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetInfoWhereShippingNo(string ShipmentNo)
        {
            sp_FSES010_ShippingInstruction_GetInfoWhereShipmentNo_Result ResultReturn;

            try
            {
                ResultReturn = obj.GetInfoWhereShippingNo(ShipmentNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadLot(int? ProductID, int? WarehouseID)
        {
            List<sp_common_LoadLot_Result> ResultReturn;

            try
            {
                ResultReturn = obj.LoadLot(ProductID, WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadLotExcludePrefix(string ProductCode, int? WarehouseID)
        {
            List<sp_FSES010_LoadLotByProductCode_Result> ResultReturn;

            try
            {
                ResultReturn = obj.LoadLotExcludePrefix(ProductCode, WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage IsProductExists(string ProductCode, int OwnerID)
        {
            bool ResultReturn;

            try
            {
                ResultReturn = obj.IsProductExists(ProductCode, OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetProduct(string ProductCode, int OwnerID)
        {
            tbm_Product ResultReturn;

            try
            {
                ResultReturn = obj.GetProduct(ProductCode, OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetProductDefaultUnit(int ProductID)
        {
            tbm_ProductDefaultUnit ResultReturn;

            try
            {
                ResultReturn = obj.GetProductDefaultUnit(ProductID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDefaultProductCondition()
        {
            tbm_ProductCondition ResultReturn;

            try
            {
                ResultReturn = obj.GetDefaultProductCondition();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetLotList(int? ProductID, int? WarehouseID)
        {
            List<sp_FSES013_ShippingByLot_Search_Result> ResultReturn;

            try
            {
                ResultReturn = obj.GetLotList(ProductID, WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage getTransportCharge(int OwnerID, int? CustomerID, int? WarehouseID, int TransportTypeID, int? FinalDestinationID)
        {
            sp_FSES012_TransportDetail_TransportCharge_Search_Result ResultReturn;

            try
            {
                ResultReturn = obj.getTransportCharge(OwnerID, CustomerID, WarehouseID, TransportTypeID, FinalDestinationID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage TransferInstructionLoadDetail(string ShipmentNo, string PickingNo)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.TransferInstructionLoadDetail(ShipmentNo, PickingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage TransferInstructionDelete(string ShipmentNo, int Installment, string PickingNo, string UpdateUser)
        {
            obj.ShipmentNo = ShipmentNo;
            obj.Installment = Installment;
            obj.PickingNo = PickingNo;
            obj.UpdateUser = UpdateUser;

            try
            {
                obj.TransferInstructionDelete();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage TransferInstructionCheckStatus()
        {
            bool isAllow;

            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            TransferInstructionStruct stc = JsonConvert.DeserializeObject<TransferInstructionStruct>(strParameterData);

            try
            {
                isAllow = obj.TransferInstructionCheckStatus(stc.ShipmentNo, stc.PickingNo, stc.ReceivingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, isAllow);
        }

        #region Shipping Instruction -- Transport Charge
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveTransportDetail()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            sp_FSES012_TransportDetail_Search_Result data = JsonConvert.DeserializeObject<sp_FSES012_TransportDetail_Search_Result>(strParameterData);

            try
            {
                obj.SaveTransportDetail(data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteTransportDetail(int seq)
        {
            try
            {
                obj.DeleteTransportDetail(seq);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        #endregion

        #region Shipping Instruction -- Other Charge
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveOtherChargeDetail()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result data = JsonConvert.DeserializeObject<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result>(strParameterData);

            try
            {
                obj.SaveOtherChargeDetail(data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteOtherChargeDetail(int seq)
        {
            try
            {
                obj.DeleteOtherChargeDetail(seq);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        #endregion
        
        #region FSES021 : TransferInstruction
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveTransferInstructionData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            TransferInstructionSaveStruct stc = JsonConvert.DeserializeObject<TransferInstructionSaveStruct>(strParameterData);

            obj.ResultData = stc.ResultData;

            try
            {
                obj.SaveTransferInstructionData(stc.ItemList, stc.NumberOfDetail, stc.TransportChargeSaveList, stc.TransportChargeDeleteList, stc.OtherChargeSaveList, stc.OtherChargeDeleteList, stc.ArrivalDate, stc.ReceivingNo, stc.SupplierID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        } 
        #endregion

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage TransferInstructionSearchAll()
        {
            DataTable ResultReturn;

            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            TransferInstructionStruct stc = JsonConvert.DeserializeObject<TransferInstructionStruct>(strParameterData);

            try
            {
                ResultReturn = obj.TransferInstructionSearchAll(stc.OwnerID, stc.ShipmentNo, stc.PickingNo, stc.ReceivingNo, stc.FromWarehouseID, stc.ToWarehouseID, stc.IsShowAllStatus);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
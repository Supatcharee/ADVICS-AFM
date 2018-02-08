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

namespace RubixWebAPI.Controllers.Operation
{
    public class ConfirmPickingController : ApiController
    {
        ConfirmPicking obj = new ConfirmPicking();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID, int? WarehouseID, String ShipmentNo, String PickingNo,
                                                                            DateTime? pickDateFrom, DateTime? pickDateTo, int allStatus,
                                                                            int? shippingCustomerID, DateTime? deliveryDateFrom, DateTime? deliveryDateTo)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID, ShipmentNo, PickingNo, pickDateFrom, pickDateTo, allStatus, shippingCustomerID, deliveryDateFrom, deliveryDateTo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DetailLoading(String ShipmentNo, String PickingNo, int LineNo)
        {
            DataSet ResultReturn;

            try
            {
                ResultReturn = obj.DetailLoading(ShipmentNo, PickingNo, LineNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveConfirmPicking(string ShipmentNo, string PickingNo, int LineNo, string CurrentUser)
        {
            string xmlRMTag;

            try
            {
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                xmlRMTag = JsonConvert.DeserializeObject<string>(strParameterData);
                obj.SaveConfirmPicking(ShipmentNo, PickingNo, LineNo, xmlRMTag, CurrentUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckWorkMethod(int? OwnerID, int? WarehouseID)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = obj.CheckWorkMethod(OwnerID, WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadDetailPicking(String ShipmentNo, String PickingNo, int LineNo)
        {
            List<sp_HPCS020_ConfirmPicking_GetPickingDetail_Result> ResultReturn;

            try
            {
                ResultReturn = obj.LoadDetailPicking(ShipmentNo, PickingNo, LineNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetLocation(String ShipmentNo, String PickingNo, int? LineNo)
        {
            List<sp_HPCS020_ConfirmPicking_GetLocation_Result> ResultReturn;

            try
            {
                ResultReturn = obj.GetLocation(ShipmentNo, PickingNo, LineNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetQuantity(String ShipmentNo, String PickingNo, int? LineNo, string LocationCode)
        {
            List<sp_HPCS020_ConfirmPicking_GetLocation_Result> ResultReturn;

            try
            {
                ResultReturn = obj.GetQuantity(ShipmentNo, PickingNo, LineNo, LocationCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveConfirmPickingData(string ShipmentNo, int Installment, string PickingNo, int LineNo, string CreateUser, int? Kanban, int Pallet)
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            string resultXML = JsonConvert.DeserializeObject<string>(strParameterData);

            obj.ShipmentNo = ShipmentNo;
            obj.Installment = Installment;
            obj.PickingNo = PickingNo;
            obj.LineNo = LineNo;
            obj.Kanban = Kanban;
            obj.Pallet = Pallet;
            
            try
            {
                obj.SaveConfirmPickingData(CreateUser, resultXML);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveConfirm(int OwnerID, int? WarehouseID, string ShipmentNo, string PickingNo, int? LocationID, int? ProductID, int? ProductConditionID,
                                               int LineNo, int PickingLineSeq, Decimal ActualQty, int? UnitOfOrderQty, string PalletNo, string User, string LotNo)
        {
            obj.OwnerID = OwnerID;
            obj.WarehouseID = WarehouseID;
            obj.ShipmentNo = ShipmentNo;
            obj.PickingNo = PickingNo;
            obj.LocationID = LocationID;
            obj.ProductID = ProductID;
            obj.ProductConditionID = ProductConditionID;
            obj.LineNo = LineNo;
            obj.PickingLineSeq = PickingLineSeq;
            obj.ActualQty = ActualQty;
            obj.UnitOfOrderQty = UnitOfOrderQty;
            obj.PalletNo = PalletNo;
            obj.LotNo = LotNo;

            try
            {
                obj.SaveConfirm(User);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage Confirm(int OwnerID, int? WarehouseID, string ShipmentNo, string PickingNo, int? ProductID, int? ProductConditionID,
                                           int LineNo, int PickingLineSeq, Decimal ActualQty, int? UnitOfOrderQty, string PalletNo, string User, string LotNo)
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            string resultXML = JsonConvert.DeserializeObject<string>(strParameterData);
            
            obj.OwnerID = OwnerID;
            obj.WarehouseID = WarehouseID;
            obj.ShipmentNo = ShipmentNo;
            obj.PickingNo = PickingNo;
            obj.ProductID = ProductID;
            obj.ProductConditionID = ProductConditionID;
            obj.LineNo = LineNo;
            obj.PickingLineSeq = PickingLineSeq;
            obj.ActualQty = ActualQty;
            obj.UnitOfOrderQty = UnitOfOrderQty;
            obj.PalletNo = PalletNo;
            obj.LotNo = LotNo;

            try
            {
                obj.Confirm(resultXML, User);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ResetConfirmFlag()
        {
            try
            {
                obj.ResetConfirmFlag();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckActualQtyInStockQty(string ShipmentNo, string PickingNo, int LineNo, int PickingLineSeq)
        {
            Boolean ResultReturn;

            obj.ShipmentNo = ShipmentNo;
            obj.PickingNo = PickingNo;
            obj.LineNo = LineNo;
            obj.PickingLineSeq = PickingLineSeq;

            try
            {
                ResultReturn = obj.CheckActualQtyInStockQty();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PrintShipmentLabel(string shipmentNo, string pickingNo)
        {
            List<sp_RPT020_ShipmentLabel_GetData_Result> ResultReturn;

            try
            {
                ResultReturn = obj.PrintShipmentLabel(shipmentNo, pickingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
    }
}
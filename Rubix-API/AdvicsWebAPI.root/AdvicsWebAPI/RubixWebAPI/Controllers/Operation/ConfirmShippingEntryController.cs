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
    public class ConfirmShippingEntryController : ApiController
    {
        ConfirmShippingEntry obj = new ConfirmShippingEntry();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID
                                            , int? WarehouseID
                                            , String ShipmentNo
                                            , String PickingNo
                                            , int? ShipmentArea
                                            , DateTime? pickDateFrom
                                            , DateTime? pickDateTo
                                            , int? CustomerID
                                            , DateTime? deliveryDateFrom
                                            , DateTime? deliveryDateTo
                                            , int ShippingComplete
                                            , String InvoiceNo)
        {
            ObjectResult<sp_ISHS030_ConfirmShipService_GetConfirmShip_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID, ShipmentNo, PickingNo, ShipmentArea, pickDateFrom, pickDateTo, CustomerID, deliveryDateFrom, deliveryDateTo, ShippingComplete, InvoiceNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
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
        public HttpResponseMessage Save(int? customerId, int? warehouseId, int? installment, int? palletQty, string user)
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            List<sp_ISHS030_ConfirmShipService_GetConfirmShip_Result> list = JsonConvert.DeserializeObject<List<sp_ISHS030_ConfirmShipService_GetConfirmShip_Result>>(strParameterData);

            bool ResultReturn;

            try
            {
                ResultReturn = obj.Save(list, customerId,  warehouseId, installment, palletQty, user);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataExportToAccpect(int? OwnerID
                                                , int? WarehouseID
                                                , String ShipmentNo
                                                , String PickingNo
                                                , int? ShipmentArea
                                                , DateTime? pickDateFrom
                                                , DateTime? pickDateTo
                                                , int? CustomerID
                                                , DateTime? deliveryDateFrom
                                                , DateTime? deliveryDateTo
                                                , int ShippingComplete
                                                , string DisplayTypeXML)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.GetDataExportToAccpect(OwnerID
                                                        , WarehouseID
                                                        , ShipmentNo
                                                        , PickingNo
                                                        , ShipmentArea
                                                        , pickDateFrom
                                                        , pickDateTo
                                                        , CustomerID
                                                        , deliveryDateFrom
                                                        , deliveryDateTo
                                                        , ShippingComplete
                                                        , DisplayTypeXML);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
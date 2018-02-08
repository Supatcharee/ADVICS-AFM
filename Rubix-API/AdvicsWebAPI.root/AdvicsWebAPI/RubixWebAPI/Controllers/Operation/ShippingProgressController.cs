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
    public class ShippingProgressController : ApiController
    {
        ShippingProgress obj = new ShippingProgress();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(Nullable<Int32> OwnerID
                                            , Nullable<Int32> warehouseID
                                            , Nullable<Int32> portOfDischargeID
                                            , Nullable<Int32> finalDestinationID
                                            , String shipmentNo
                                            , String pickingNo
                                            , Nullable<Int32> shippingAreaID
                                            , Nullable<DateTime> transportDate
                                            , Nullable<DateTime> pickingDate
                                            , Nullable<DateTime> shippingDate
                                            , Nullable<DateTime> fromETADate
                                            , Nullable<DateTime> toETADate
                                            , String invoiceNo                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          , int? CustomerID)
        {

            List<sp_LWPS020_ShippingProgress_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, 
                                                warehouseID
                                                ,portOfDischargeID
                                                ,finalDestinationID
                                                ,shipmentNo
                                                ,pickingNo
                                                ,shippingAreaID
                                                ,transportDate
                                                ,pickingDate
                                                ,shippingDate
                                                ,fromETADate,
                                                toETADate,
                                                invoiceNo, 
                                                CustomerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetSummary(Nullable<Int32> OwnerID
                                            , Nullable<Int32> warehouseID
                                            , Nullable<Int32> portOfDischargeID
                                            , Nullable<Int32> finalDestinationID
                                            , String shipmentNo
                                            , String pickingNo
                                            , Nullable<Int32> shippingAreaID
                                            , Nullable<DateTime> transportDate
                                            , Nullable<DateTime> pickingDate
                                            , Nullable<DateTime> shippingDate
                                            , Nullable<DateTime> fromETADate
                                            , Nullable<DateTime> toETADate
                                            , String invoiceNo
                                            , int? CustomerID)
        {
            List<sp_LWPS020_ShippingProgress_SearchTotal_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetSummary(OwnerID
                                                ,warehouseID
                                                ,portOfDischargeID
                                                ,finalDestinationID
                                                ,shipmentNo
                                                ,pickingNo
                                                ,shippingAreaID
                                                ,transportDate
                                                ,pickingDate
                                                ,shippingDate
                                                ,fromETADate
                                                ,toETADate
                                                ,invoiceNo
                                                ,CustomerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
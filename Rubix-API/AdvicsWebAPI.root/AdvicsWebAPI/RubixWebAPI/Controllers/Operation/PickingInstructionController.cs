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
    public class PickingInstructionController : ApiController
    {
        PickingInstruction obj = new PickingInstruction();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID, int? WarehouseID, String ShipmentNo, String PickingNo,
                                               int? CustomerID, DateTime? deliveryDateFrom, DateTime? deliveryDateTo, string invoiceNo)
        {
            List<sp_HPCS010_PickingInstruction_Search_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID, ShipmentNo, PickingNo, CustomerID, deliveryDateFrom, deliveryDateTo, invoiceNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoadingReprint(int? OwnerID, int? WarehouseID, String ShipmentNo, String PickingNo, int? portOfDischargeID,
                                                      int? finalDestinationID, DateTime? pickDateFrom, DateTime? pickingDateTo)
        {
            List<sp_HPCS011_PickingInstruction_SearchReprint_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoadingReprint(OwnerID, WarehouseID, ShipmentNo, PickingNo, portOfDischargeID, finalDestinationID, pickDateFrom, pickingDateTo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage UpdateStatusID(string shipmentNo, string pickingNo, int LineNo)
        {
            try
            {
                obj.UpdateStatusID(shipmentNo, pickingNo, LineNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataReport(String shipmentNo, String pickingNo)
        {
            List<sp_RPT021_PickingList_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataReport(shipmentNo, pickingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PickingListDataLoading(int? OwnerID
                                                        , int? WarehouseID
                                                        , int? CustomerID
                                                        , DateTime? PickingDateFrom
                                                        , DateTime? PickingDateTo
                                                        , bool isCompleteTransport
                                                        , bool isActual)
        {
            DataTable ResultReturn;
            try
            {
                ResultReturn = obj.PickingListDataLoading(OwnerID, WarehouseID, CustomerID, PickingDateFrom, PickingDateTo, isCompleteTransport, isActual);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }


    }
}
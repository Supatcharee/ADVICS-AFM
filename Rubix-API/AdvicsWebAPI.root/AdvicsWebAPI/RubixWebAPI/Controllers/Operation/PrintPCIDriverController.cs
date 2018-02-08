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
    public class PrintPCIDriverController : ApiController
    {
        PrintPCIDriver obj = new PrintPCIDriver();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID,
                                                int? WarehouseID,
                                                String ShipmentNo,
                                                String PickingNo,
                                                DateTime? pickDateFrom,
                                                DateTime? pickDateTo,
                                                int? CustomerID)
        {
            List<sp_ISHS060_PrintDeliveryOrder_SearchAll_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID, ShipmentNo, PickingNo, pickDateFrom, pickDateTo, CustomerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage EntryDeliveryOrder(string UserLogin)
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            sp_ISHS060_PrintDeliveryOrder_SearchAll_Result data = JsonConvert.DeserializeObject<sp_ISHS060_PrintDeliveryOrder_SearchAll_Result>(strParameterData);

            Boolean ResultReturn;
            try
            {
                ResultReturn = obj.EntryDeliveryOrder(data, UserLogin);
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

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetAttachList(string shipmentNo, string pickingNo)
        {
            DataTable ResultReturn;
            try
            {
                ResultReturn = obj.GetAttachList(shipmentNo, pickingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
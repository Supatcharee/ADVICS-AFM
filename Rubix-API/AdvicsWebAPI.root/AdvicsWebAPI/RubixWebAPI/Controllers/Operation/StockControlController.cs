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
    public class StockControlController : ApiController
    {
        StockControl obj = new StockControl();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage  DataLoading(int? CustomerID, int? WarehouseID, String ShipmentNo, DateTime? PickingDateFrom, DateTime? PickingDateTo, int? FinalDestinationID, int? shippingCustomerID)
        {
            List<sp_GSCS010_StockControlProcess_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(CustomerID, WarehouseID, ShipmentNo, PickingDateFrom, PickingDateTo, FinalDestinationID, shippingCustomerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ViewDetail(String ShipmentNo, String PickingNo)
        {
            List<sp_GSCS012_StockControlDetail_Search_Result> ResultReturn;

            try
            {
                ResultReturn = obj.ViewDetail(ShipmentNo, PickingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SavePickingData(string ShipmentNo, string PickingNo, string UpdateUser)
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            string xml = JsonConvert.DeserializeObject<string>(strParameterData);

            obj.ShipmentNo = ShipmentNo;
            obj.PickingNo = PickingNo;

            try
            {
                obj.SavePickingData(UpdateUser,xml);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveBookStockData(string ShipmentNo, string PickingNo, int? WarehouseID, int? OwnerID, int LineNo, string CreateUser)
        {
            try
            {
                obj.SaveBookStockData(ShipmentNo, PickingNo, WarehouseID, OwnerID, LineNo, CreateUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
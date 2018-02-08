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
    public class OrderCancelController : ApiController
    {
        OrderCancel obj = new OrderCancel();

        #region Receiving
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoadReceiving(int? OwnerID, int? WarehouseID, string ReceivingNo)
        {
            List<sp_ROMS020_OrderCancel_SearchAll_Receiving_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoadReceiving(OwnerID, WarehouseID, ReceivingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveDataReceiving()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            List<sp_ROMS020_OrderCancel_SearchAll_Receiving_Result> data = JsonConvert.DeserializeObject<List<sp_ROMS020_OrderCancel_SearchAll_Receiving_Result>>(strParameterData);
            
            string ResultReturn;
            try
            {
                ResultReturn = obj.SaveDataReceiving(data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        #endregion

        #region Shipping

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoadShipping(int? OwnerID, int? WarehouseID, string ShipmentNo, string PickingNo, int? CustomerID)
        {
            List<sp_ROMS020_OrderCancel_SearchAll_Shipping_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoadShipping(OwnerID, WarehouseID, ShipmentNo, PickingNo, CustomerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveDataShipping()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            List<sp_ROMS020_OrderCancel_SearchAll_Shipping_Result> data = JsonConvert.DeserializeObject<List<sp_ROMS020_OrderCancel_SearchAll_Shipping_Result>>(strParameterData);
            
            string ResultReturn;
            try
            {
                ResultReturn = obj.SaveDataShipping(data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        #endregion


    }
}
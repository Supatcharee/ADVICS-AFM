using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.Master;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Master
{
    public class ShippingAreaController : ApiController
    {
        ShippingArea obj = new ShippingArea();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? ShippingAreaID, int? WarehouseID, string ShippingAreaCode, string ShippingAreaname)
        {
            ObjectResult<sp_XMSS150_ShippingArea_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(ShippingAreaID, WarehouseID, ShippingAreaCode, ShippingAreaname);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistShippingAreaCode(String ShippingAreaCode, int WarehouseID)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistShippingAreaCode(ShippingAreaCode, WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveShippingAreaData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            sp_XMSS150_ShippingArea_SearchAll_Result ResultData = JsonConvert.DeserializeObject<sp_XMSS150_ShippingArea_SearchAll_Result>(strParameterData);

            obj.ResultData = ResultData;

            try
            {
                obj.SaveShippingAreaData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteShippingAreaData(int ShippingAreaID)
        {
            obj.ShippingAreaID = ShippingAreaID;

            try
            {
                obj.DeleteShippingAreaData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReference(int? iShippingAreaID)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = obj.CheckReference(iShippingAreaID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
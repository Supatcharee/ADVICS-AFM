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
    public class WarehouseController : ApiController
    {

        struct WarehouseStc
        {
            public sp_XMSS040_Warehouse_SearchAll_Result ResultData;
            public string xmlResult;
            public string xmlWorkMethod;
        }
        Warehouse obj = new Warehouse();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID, string WarehouseCode, string WarehouseName)
        {
            ObjectResult<sp_XMSS040_Warehouse_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseCode, WarehouseName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }


        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadWorkMethodData(int? OwnerID, int? WarehouseID)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.LoadWorkMethodData(OwnerID, WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadOwner(int? WarehouseID)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.LoadOwner(WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistWarehouseCode(int? WarehouseID, String WarehouseCode)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistWarehouseCode(WarehouseID, WarehouseCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveWarehouseData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            WarehouseStc stc = JsonConvert.DeserializeObject<WarehouseStc>(strParameterData);

            obj.ResultData = stc.ResultData;

            try
            {
                obj.SaveWarehousData(stc.xmlResult, stc.xmlWorkMethod);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReference(int? WarehouseID)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = obj.CheckReference(WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteWarehouseData(String CurrentUser, int WarehouseID)
        {
            try
            {
                obj.DeleteWarehouseData(CurrentUser, WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
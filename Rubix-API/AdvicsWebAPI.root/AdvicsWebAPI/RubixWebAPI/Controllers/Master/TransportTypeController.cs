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
    public class TransportTypeController : ApiController
    {
        CSI.Business.Master.TransportType obj = new CSI.Business.Master.TransportType();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(String TransportCode, String TransporteName)
        {
            ObjectResult<sp_XMSS130_TransportType_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(TransportCode, TransporteName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
            
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistTransportTypeCode(String TransportCode)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistTransportTypeCode(TransportCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveTransportTypeData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            sp_XMSS130_TransportType_SearchAll_Result ResultData = JsonConvert.DeserializeObject<sp_XMSS130_TransportType_SearchAll_Result>(strParameterData);
            
            obj.ResultData = ResultData;

            try
            {
                obj.SaveTransportTypeData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteTransportData(int TransportTypeID)
        {
            obj.TransportTypeID = TransportTypeID;
            try
            {
                obj.DeleteTransportData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
           
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReference(int? iTransportTypeID)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = obj.CheckReference(iTransportTypeID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }
    }
}
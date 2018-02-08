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
    public class WorkMethodController : ApiController
    {
        WorkMethod obj = new WorkMethod();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(String WorkMethodCode, String WorkMethodName)
        {
            ObjectResult<sp_XMSS230_WorkMethod_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(WorkMethodCode, WorkMethodName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistWorkMethodCode(String WorkMethodCode)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistWorkMethodCode(WorkMethodCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
            
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveWorkMethodData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            sp_XMSS230_WorkMethod_SearchAll_Result ResultData = JsonConvert.DeserializeObject<sp_XMSS230_WorkMethod_SearchAll_Result>(strParameterData);

            obj.ResultData = ResultData;

            try
            {
                obj.SaveWorkMethodData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteWorkMethodData(int WorkMethodID)
        {
            obj.WorkMethodID = WorkMethodID;

            try
            {
                obj.DeleteWorkMethodData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

          return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReference(int? iWorkMethodID)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = obj.CheckReference(iWorkMethodID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK,ResultReturn );

        }
    }
}
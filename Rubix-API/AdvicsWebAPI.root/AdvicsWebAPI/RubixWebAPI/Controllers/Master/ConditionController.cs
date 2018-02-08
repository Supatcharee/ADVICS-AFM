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
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Master
{
    public class ConditionController : ApiController
    {
        private Condition ct = new Condition();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(String ConditionCode, String ConditionName)
        {
            ObjectResult<sp_XMSS110_ConditionOfProduct_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = ct.DataLoading(ConditionCode, ConditionName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistProductConditionCode(String ProductConditionCode)
        {
            Boolean ResultReturn;
            try
            {
                ResultReturn = ct.CheckExistProductConditionCode(ProductConditionCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveConditionData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            sp_XMSS110_ConditionOfProduct_SearchAll_Result ResultData = JsonConvert.DeserializeObject<sp_XMSS110_ConditionOfProduct_SearchAll_Result>(strParameterData);

            ct.ResultData = ResultData;

            try
            {
                ct.SaveConditionData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteConditionData(int ProductConditionID)
        {
            ct.ProductConditionID = ProductConditionID;
            try
            {
                ct.DeleteConditionData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReference(int? iProductConditionID)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = ct.CheckReference(iProductConditionID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
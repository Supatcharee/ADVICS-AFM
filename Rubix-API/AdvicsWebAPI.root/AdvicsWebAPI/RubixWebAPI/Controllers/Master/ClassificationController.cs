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
    public class ClassificationController : ApiController
    {
        private Classification cf  = new Classification();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(String ClassificationCode, String ClassificationName)
        {
            ObjectResult<sp_XMSS240_Classification_SearchAll_Result> ResultReturn;
            try
            {
                ResultReturn = cf.DataLoading(ClassificationCode, ClassificationName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistClassificationCode(String ClassificationCode)
        {
            bool ResultReturn;
            try
            {
                ResultReturn = cf.CheckExistClassificationCode(ClassificationCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveClassificationData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            sp_XMSS240_Classification_SearchAll_Result ResultData = JsonConvert.DeserializeObject<sp_XMSS240_Classification_SearchAll_Result>(strParameterData);

            cf.ResultData = ResultData;

            try
            {
                cf.SaveClassificationData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteClassificationData(int ClassificationID)
        {

            cf.ClassificationID = ClassificationID;

            try
            {
                cf.DeleteClassificationData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReference(int? iClassificationID)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = cf.CheckReference(iClassificationID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

    }
}
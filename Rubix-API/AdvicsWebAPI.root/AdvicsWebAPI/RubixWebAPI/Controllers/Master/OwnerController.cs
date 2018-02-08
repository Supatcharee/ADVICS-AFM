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
using Rubix.Framework;

namespace RubixWebAPI.Controllers.Master
{
    public class OwnerController : ApiController
    {
        private Owner ct = new Owner();
        

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(String OwnerCode, String OwnerName)
        {
            ObjectResult<sp_XMSS010_Owner_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = ct.DataLoading(OwnerCode, OwnerName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            finally
            {
                ct = null;
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistOwnerCode(int? OwnerID ,String OwnerCode)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = ct.CheckExistOwnerCode(OwnerID, OwnerCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveOwnerData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            sp_XMSS010_Owner_SearchAll_Result ResultData = JsonConvert.DeserializeObject<sp_XMSS010_Owner_SearchAll_Result>(strParameterData);

            ct.ResultData = ResultData;

            try
            {
                ct.SaveOwnerData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteOwnerData(int OwnerID)
        {
            ct.OwnerID = OwnerID;

            try
            {
                ct.DeleteOwnerData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReference(int OwnerID)
        {
            ct.OwnerID = OwnerID;

            int? ResultReturn;

            try
            {
                ResultReturn = ct.CheckReference();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
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
using System.Drawing;
using System.IO;

namespace RubixWebAPI.Controllers.Master
{
    public class FinalDestinationController : ApiController
    {
        FinalDestination obj = new FinalDestination();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(String FinalDestinationCode, String FinalDestinationName, int? OwnerID, int? shippingCustomerID)
        {
            ObjectResult<sp_XMSS070_FinalDestination_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(FinalDestinationCode, FinalDestinationName, OwnerID, shippingCustomerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistFinalDestinationCode(String FinalDestinationCode, int? OwnerID, int? CustomerID)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistFinalDestinationCode(FinalDestinationCode, OwnerID, CustomerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveFinalDestinationData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            sp_XMSS070_FinalDestination_SearchAll_Result ResultData = JsonConvert.DeserializeObject<sp_XMSS070_FinalDestination_SearchAll_Result>(strParameterData);
               
            obj.ResultData = ResultData;

            try
            {
                obj.SaveFinalDestinationData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteCustomerData(int FinalDestinationID)
        {
            obj.FinalDestinationID = FinalDestinationID;

            try
            {
                obj.DeleteCustomerData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReference(int? iFinalDestinationID)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = obj.CheckReference(iFinalDestinationID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
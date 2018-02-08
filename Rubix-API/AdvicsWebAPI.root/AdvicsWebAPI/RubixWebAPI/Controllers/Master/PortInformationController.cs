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
    public class PortInformationController : ApiController
    {
        struct PortInformationStruct
        {
            public sp_XMSS090_Port_SearchAll_Result ResultData;
            public string resultXML;
        }

        PortInformation obj = new PortInformation();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID, String PortCode, String PortName)
        {
            ObjectResult<sp_XMSS090_Port_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, PortCode, PortName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }


        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistPortCode(String PortCode)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistPortCode(PortCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SavePortData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            PortInformationStruct stc = JsonConvert.DeserializeObject<PortInformationStruct>(strParameterData);

            obj.ResultData = stc.ResultData;

            try
            {
                obj.SavePortData(stc.resultXML);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SavePortCustomerData(int PortID, int OwnerID, string CreateUser)
        {
            obj.PortID = PortID;
            obj.OwnerID = OwnerID;
            obj.CreateUser = CreateUser;

            try
            {
                obj.SavePortCustomerData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeletePortData(int PortID)
        {
            obj.PortID = PortID;

            try
            {
                obj.DeletePortData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadPortClassification()
        {
            List<sp_XMSS090_LoadPortClassification_Result> ResultReturn;

            try
            {
                ResultReturn = obj.LoadPortClassification();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveCustomerData(int PortID)
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            string resultXML = JsonConvert.DeserializeObject<string>(strParameterData);

            obj.PortID = PortID;

            try
            {
                obj.SaveCustomerData(resultXML);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadCustomerData(int? portID)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.LoadCustomerData(portID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReference(int? iPortID)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = obj.CheckReference(iPortID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
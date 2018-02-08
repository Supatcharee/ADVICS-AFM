using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;
using CSI.Business.BusinessFactory.Master;


namespace RubixWebAPI.Controllers.Master
{
    public class CurrencyController : ApiController
    {
        Currency obj = new Currency();
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(string CurrencyCode, string CurrencyName)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(CurrencyCode, CurrencyName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
       
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveData(string CreateUser)
        {
            try
            {
                string CurrencyXML = Request.Content.ReadAsStringAsync().Result;

                obj.SaveData(CurrencyXML, CreateUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistCurrencyCode(int? CurrencyID, String CurrencyCode)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistCurrencyCode(CurrencyID, CurrencyCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteData()
        {
            try
            {
                string strParameterData = Request.Content.ReadAsStringAsync().Result;
                int stc = JsonConvert.DeserializeObject<int>(strParameterData);
                obj.CurrencyID = stc;

                obj.DeleteData();

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReference(int CurrencyID)
        {
            obj.CurrencyID = CurrencyID;
            int? ResultReturn;

            try
            {
                ResultReturn = obj.CheckReference();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}

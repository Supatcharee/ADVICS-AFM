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
    public class TruckCompanyController : ApiController
    {
        struct TruckCompanyStruct
        {
            public sp_XMSS020_TruckCompany_SearchAll_Result ResultData;
            public string XML;
        }
        
        TruckCompany obj = new TruckCompany();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(String TruckCompanyCode, String TruckCompanyName)
        {
            ObjectResult<sp_XMSS020_TruckCompany_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(TruckCompanyCode, TruckCompanyName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
          
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistTruckCompanyCode(String TruckCompanyCode)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistTruckCompanyCode(TruckCompanyCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
            
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveTruckCompanyData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            TruckCompanyStruct stc = JsonConvert.DeserializeObject<TruckCompanyStruct>(strParameterData);

            obj.ResultData = stc.ResultData;
            
            try
            {
                obj.SaveTruckCompanyData(stc.XML);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteTruckCompanyData(int TruckCompanyID)
        {
            obj.TruckCompanyID = TruckCompanyID;
            try
            {
                obj.DeleteTruckCompanyData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage TruckTypeMappingLoad(int? TruckCompanyID)
        {
            ObjectResult<sp_XMSS021_TruckTransportTypeMapping_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.TruckTypeMappingLoad(TruckCompanyID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadTruckTransportTypeData(int? TruckCompanyID)
        {
            DataTable ResultReturn;
            try
            {
                ResultReturn = obj.LoadTruckTransportTypeData(TruckCompanyID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReference(int? TruckCompanyID)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = obj.CheckReference(TruckCompanyID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetTransportType(int transportTypeID)
        {
            tbm_TransportType ResultReturn;
            try
            {
                ResultReturn = obj.GetTransportType(transportTypeID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
           
        }
    }
}
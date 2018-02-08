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
    public class SupplierController : ApiController
    {
        Supplier obj = new Supplier();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(String SupplierCode, String SupplierName, int? OwnerID)
        {

            ObjectResult<sp_XMSS030_Supplier_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(SupplierCode, SupplierName, OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistSupplierCode(int? SupplierID, String SupplierCode, int? OwnerID)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistSupplierCode(SupplierID, SupplierCode, OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveSupplierData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            sp_XMSS030_Supplier_SearchAll_Result ResultData = JsonConvert.DeserializeObject<sp_XMSS030_Supplier_SearchAll_Result>(strParameterData);

            obj.ResultData = ResultData;

            try
            {
                obj.SaveSupplierData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteSupplierData(int SupplierID)
        {
            obj.SupplierID = SupplierID;

            try
            {
                obj.DeleteSupplierData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReference(int? iSupplierID)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = obj.CheckReference(iSupplierID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
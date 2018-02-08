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
    public class CustomerController : ApiController
    {
        struct CustomerStruct
        {
            public sp_XMSS270_Customer_SearchAll_Result ResultData;
            public string OwnerXML;
            //public string PrivilegeXML;
        }

        Customer obj = new Customer();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID, String CustomerCode, String CustomerName)
        {
            ObjectResult<sp_XMSS270_Customer_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, CustomerCode, CustomerName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoadOwner(int? CustomerID)
        {
            DataSet ResultReturn;

            try
            {
                ResultReturn = obj.DataLoadOwner(CustomerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistCustomerCode(int? CustomerID, String CustomerCode)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistCustomerCode(CustomerID, CustomerCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveCustomerData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            CustomerStruct stc = JsonConvert.DeserializeObject<CustomerStruct>(strParameterData);

            obj.ResultData = stc.ResultData;

            try
            {
                obj.SaveCustomerData(stc.OwnerXML);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteCustomerData(int CustomerID)
        {
            obj.CustomerID = CustomerID;
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
        public HttpResponseMessage CheckReference(int CustomerID)
        {
            obj.CustomerID = CustomerID;
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
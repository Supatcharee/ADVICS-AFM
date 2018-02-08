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
    public class SalePriceController : ApiController
    {
        SalePrice obj = new SalePrice();
        
        struct ImportSave
        {
            public string XML;
            public string CurrentUser;
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID, int? CustomerID, DateTime? EffectiveFrom, DateTime? EffectiveTo)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, CustomerID, EffectiveFrom, EffectiveTo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExist(int? SalePriceID, int CustomerID, int ProductID, DateTime EffectiveDate)
        {
            bool ResultReturn;

            try
            {
                ResultReturn = obj.CheckExist(SalePriceID, CustomerID, ProductID, EffectiveDate);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckCurrency(int CustomerID, int ProductID)
        {
            int ResultReturn;

            try
            {
                ResultReturn = obj.CheckCurrency(CustomerID, ProductID);
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
            string SalePriceXML = Request.Content.ReadAsStringAsync().Result;

            try
            {
                obj.SaveData(SalePriceXML, CreateUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveImportData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            ImportSave SalePriceXML = JsonConvert.DeserializeObject<ImportSave>(strParameterData);

            try
            {
                obj.SaveImportData(SalePriceXML.XML, SalePriceXML.CurrentUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteData(int SalePriceID)
        {
            try
            {
                obj.DeleteData(SalePriceID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        


    }
}

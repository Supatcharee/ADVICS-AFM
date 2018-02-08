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
    public class PurchasePriceController : ApiController
    {
        PurchasePrice obj = new PurchasePrice();
        
        struct ImportSave
        {
            public string XML;
            public string CurrentUser;
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID,int? SupplierID, DateTime? EffectiveFrom, DateTime? EffectiveTo)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, SupplierID, EffectiveFrom, EffectiveTo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExist(int? PurchasePriceID, int SupplierID, int ProductID, DateTime EffectiveDate)
        {
            bool ResultReturn;

            try
            {
                ResultReturn = obj.CheckExist(PurchasePriceID, SupplierID, ProductID, EffectiveDate);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckCurrency(int SupplierID, int ProductID)
        {
            int ResultReturn;

            try
            {
                ResultReturn = obj.CheckCurrency(SupplierID, ProductID);
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
            string PurchasePriceXML = Request.Content.ReadAsStringAsync().Result;
            //string PurchasePriceXML = JsonConvert.DeserializeObject<string>(strParameterData);

            try
            {
                obj.SaveData(PurchasePriceXML, CreateUser);
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
            ImportSave PurchasePriceXML = JsonConvert.DeserializeObject<ImportSave>(strParameterData);

            try
            {
                obj.SaveImportData(PurchasePriceXML.XML, PurchasePriceXML.CurrentUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteData(int PurchasePriceID)
        {
            try
            {
                obj.DeleteData(PurchasePriceID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}

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
    public class ProductGroupController : ApiController
    {
        struct ProductGroupStruct
        {
            public sp_XMSS250_ProductGroup_SearchAll_Result ResultData;
            public string resultXML;
        }

        ProductGroup obj = new ProductGroup();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(string ProductGroupCode, string ProductGroupName)
        {
            ObjectResult<sp_XMSS250_ProductGroup_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(ProductGroupCode, ProductGroupName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }


        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoadingSubItem(int ProductGroupID)
        {

            DataTable ResultReturn;
            obj.ProductGroupID = ProductGroupID;
            try
            {
                ResultReturn = obj.DataLoadingSubItem();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
         
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistProductGroupCode(String ProductGroupCode)
        {

            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistProductGroupCode(ProductGroupCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
         
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveProductGroupData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            ProductGroupStruct stc = JsonConvert.DeserializeObject<ProductGroupStruct>(strParameterData);

            obj.ResultData = stc.ResultData;

            try
            {
                obj.SaveProductGroupData(stc.resultXML);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteProductGroupData(int ProductGroupID)
        {
            obj.ProductGroupID = ProductGroupID;
            try
            {
                obj.DeleteProductGroupData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
            
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReference(int? iProductGroupID)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = obj.CheckReference(iProductGroupID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReferenceCategory(int? ProductCategoryID)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = obj.CheckReferenceCategory(ProductCategoryID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteProductCategoryData(int ProductCategoryID)
        {
            obj.ProductCategoryID = ProductCategoryID;
            try
            {
                obj.DeleteProductCategoryData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }

    }
}
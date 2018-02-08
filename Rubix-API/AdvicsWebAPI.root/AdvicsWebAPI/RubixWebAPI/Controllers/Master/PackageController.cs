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
    public class PackageController : ApiController
    {
        Package obj = new Package();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(String PackageCode, String PackageName)
        {
            ObjectResult<sp_XMSS260_Package_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(PackageCode, PackageName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistUnitCode(String PackageCode)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistUnitCode(PackageCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveUnitData()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            sp_XMSS260_Package_SearchAll_Result ResultData = JsonConvert.DeserializeObject<sp_XMSS260_Package_SearchAll_Result>(strParameterData);

            obj.ResultData = ResultData;

            try
            {
                obj.SaveUnitData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteUnitData(int PackageID)
        {
            obj.PackageID = PackageID;

            try
            {
                obj.DeleteUnitData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReference(int? iPackageID)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = obj.CheckReference(iPackageID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
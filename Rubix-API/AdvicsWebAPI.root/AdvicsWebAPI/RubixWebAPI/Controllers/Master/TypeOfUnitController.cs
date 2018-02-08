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
    public class TypeOfUnitController: ApiController
    {
        TypeOfUnit obj = new TypeOfUnit();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(String UnitCode, String UnitName)
        {
            ObjectResult<sp_XMSS220_TypeOfUnit_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(UnitCode, UnitName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistUnitCode(String UnitCode)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistUnitCode(UnitCode);
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
            sp_XMSS220_TypeOfUnit_SearchAll_Result ResultData = JsonConvert.DeserializeObject<sp_XMSS220_TypeOfUnit_SearchAll_Result>(strParameterData);

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
        public HttpResponseMessage DeleteUnitData(int UnitID)
        {
            obj.UnitID = UnitID; 
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
        public HttpResponseMessage CheckReference(int? iUnitID)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = obj.CheckReference(iUnitID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
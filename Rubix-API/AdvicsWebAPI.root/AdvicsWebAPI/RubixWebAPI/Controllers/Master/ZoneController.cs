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
    public class ZoneController : ApiController
    {
        Zone obj = new Zone();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID, int? WarehouseID, int? Floor, String ZoneCode, String ZoneName)
        {
            ObjectResult<sp_XMSS120_Zone_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID, Floor, ZoneCode, ZoneName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataCustomerLoading(int ZoneID)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.DataCustomerLoading(ZoneID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistZoneCode(String ZoneCode, int? WarehouseID, int Floor)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistZoneCode(ZoneCode, WarehouseID, Floor);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }


        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveZoneData(Nullable<Int32> WarehouseID)
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            sp_XMSS120_Zone_SearchAll_Result ResultData = JsonConvert.DeserializeObject<sp_XMSS120_Zone_SearchAll_Result>(strParameterData);

            obj.ResultData = ResultData;

            try
            {
                obj.SaveZoneData(WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveZoneCustomerData(int ZoneID, int CustomerIDC)
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            string resultXML = JsonConvert.DeserializeObject<string>(strParameterData);

            obj.ZoneID = ZoneID;
            obj.CustomerIDC = CustomerIDC;

            try
            {
                obj.SaveZoneCustomerData(resultXML);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteZoneData(int ZoneID, string UpdateUser)
        {

            obj.ZoneID = ZoneID;
            obj.UpdateUser = UpdateUser;

            try
            {
                obj.DeleteZoneData();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReference(int? iZoneID)
        {
            int? ResultReturn;
            try
            {
                ResultReturn = obj.CheckReference(iZoneID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }

    }
}
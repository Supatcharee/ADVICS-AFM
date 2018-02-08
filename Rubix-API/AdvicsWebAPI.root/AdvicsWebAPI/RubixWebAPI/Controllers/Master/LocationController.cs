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
    public class LocationController : ApiController
    {
        Location obj = new Location();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SearchLocationDesigner(int WarehouseID)
        {
            DataSet ResultReturn;

            try
            {
                ResultReturn = obj.SearchLocationDesigner(WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        public HttpResponseMessage SearchLocationLabel(int? WarehouseID, int? ZoneID, string RackNo, string LocationCode, string LocationName)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.SearchLocationLabel(WarehouseID, ZoneID, RackNo, LocationCode, LocationName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadLocationType()
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.LoadLocationType();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckExistLocation(string LocationCode, int? WarehouseID, int? ZoneID)
        {
            Boolean ResultReturn;

            try
            {
                ResultReturn = obj.CheckExistLocation(LocationCode, WarehouseID, ZoneID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReferenceByLocation(int LocationID)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = obj.CheckReferenceByLocation(LocationID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage CheckReferenceByLayout()
        {
            int? ResultReturn;
            string strParameterData = Request.Content.ReadAsStringAsync().Result;

            try
            {
                ResultReturn = obj.CheckReferenceByLayout(strParameterData);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveZoneData(string CreateUser)
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            List<LocationGraphic> ResultData = JsonConvert.DeserializeObject<List<LocationGraphic>>(strParameterData);
            
            try
            {
                obj.SaveZoneData(ResultData, CreateUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }        
    }
}
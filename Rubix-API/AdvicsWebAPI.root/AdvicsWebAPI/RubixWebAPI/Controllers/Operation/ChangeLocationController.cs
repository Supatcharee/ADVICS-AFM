using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.Operation;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Operation
{
    public class ChangeLocationController : ApiController
    {
        ChangeLocation obj = new ChangeLocation();
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID, int? WarehouseID, int? Floor, int? ZoneID, int? ProductID,int? ProductConditionID, String PalletNo, String PalletNoRef, String LotNo)
        {
            List<sp_ESTS020_ChangeLocation_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID, Floor, ZoneID, ProductID, ProductConditionID, PalletNo, PalletNoRef, LotNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadRack(int? ZoneID)
        {
            DataTable ResultReturn;

            try
            {
                ResultReturn = obj.LoadRack(ZoneID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadLocationCode(int? WarehouseID, int? ZoneID, String RackNo)
        {
            String ResultReturn;

            try
            {
                ResultReturn = obj.LoadLocationCode(WarehouseID, ZoneID, RackNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadLocationID(int WarehouseID, String LocationCode)
        {
            int? ResultReturn;

            try
            {
                ResultReturn = obj.LoadLocationID(WarehouseID, LocationCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveExpiryDate(String PalletNo, DateTime? ExpiryDate)
        {
            try
            {
                obj.SaveExpiryDate(PalletNo, ExpiryDate);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
                
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadFullCapacityFlag(int? WarehouseID, String LocationCode)
        {
            bool ResultReturn;

            try
            {
                ResultReturn = obj.LoadFullCapacityFlag(WarehouseID, LocationCode);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveLocationChange(int? OwnerID, int? WarehouseID, int? ProductID, string LotNo, String PalletNo, int? ProductConditionIDFrom
                                            , int? LocationIDFrom, bool? FullCapacityFlagFrom, int? ProductConditionIDTo, int? LocationIDTo
                                            , bool? FullCapacityFlagTo, decimal? Quantity, string ChangedUser)
        {
            try
            {
                obj.SaveLocationChange(OwnerID, WarehouseID, ProductID, LotNo, PalletNo, ProductConditionIDFrom, LocationIDFrom, FullCapacityFlagFrom,
                                                        ProductConditionIDTo, LocationIDTo, FullCapacityFlagTo, Quantity, ChangedUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}
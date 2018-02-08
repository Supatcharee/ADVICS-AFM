using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.BusinessFactory.Report;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Report
{
    public class InventoryCheckingListReportController : ApiController
    {
        InvertoryCheckingListReport obj = new InvertoryCheckingListReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetCheckingListByProductReport(int? OwnerID, int? WarehouseID, int? productID, DateTime? toDate)
        {
            List<sp_RPT016_InventoryCheckingListByProduct_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetCheckingListByProductReport(OwnerID, WarehouseID, productID, toDate);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetCheckingListByZoneReport(int? OwnerID, int? WarehouseID, DateTime? Date, int? ZoneID, int? Floor)
        {
            List<sp_RPT017_InventoryCheckingListByZone_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetCheckingListByZoneReport(OwnerID, WarehouseID, Date, ZoneID, Floor);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetCheckingListByZoneSubReport(int? OwnerID, int? WarehouseID, DateTime? Date, int? ZoneID, int? Floor)
        {
            List<sp_RPT017_InventoryCheckingListByZone_SubReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetCheckingListByZoneSubReport(OwnerID, WarehouseID, Date, ZoneID, Floor);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadFloor(int? WarehouseID)
        {
            DataTable ResultReturn;
            try
            {
                ResultReturn = obj.LoadFloor(WarehouseID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        //[HttpPost, HttpGet, APIAuthorize]
        //public HttpResponseMessage GetMaxDailyPostDate()
        //{
        //    List<DateTime?> ResultReturn;
        //    try
        //    {
        //        ResultReturn = obj.GetMaxDailyPostDate();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        //}         
    }
}
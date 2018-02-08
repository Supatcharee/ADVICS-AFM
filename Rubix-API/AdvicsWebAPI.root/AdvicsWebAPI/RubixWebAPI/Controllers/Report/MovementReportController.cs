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
    public class MovementReportController : ApiController
    {
        MovementReport obj = new MovementReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataReport(int? OwnerID, int? WarehouseID, int? productID, DateTime? dateFrom, DateTime? dateTo)
        {
            List<sp_RPT023_MovementReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataReport(OwnerID, WarehouseID, productID, dateFrom, dateTo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataSubReport(int? OwnerID, int? WarehouseID, int? productID, DateTime? dateFrom, DateTime? dateTo)
        {
            List<sp_RPT023_MovementReport_SubReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataSubReport(OwnerID, WarehouseID, productID, dateFrom, dateTo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetChartReport(int? OwnerID, int? WarehouseID, int? productID, DateTime? dateFrom, DateTime? dateTo, int isMonthly)
        {
            List<sp_RPT024_MovementReport_Chart_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetChartReport(OwnerID, WarehouseID, productID, dateFrom, dateTo, isMonthly);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }
    }
}
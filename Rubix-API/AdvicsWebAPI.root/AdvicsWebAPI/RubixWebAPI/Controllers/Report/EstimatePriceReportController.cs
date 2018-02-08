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
    public class EstimatePriceReportController : ApiController
    {
        EstimatePriceReport obj = new EstimatePriceReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataEstimatePriceReport(int? OwnerID, int? WarehouseID, DateTime? fromDate, DateTime? toDate)
        {
            List<sp_RPT012_EstimatePriceReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataEstimatePriceReport(OwnerID, WarehouseID, fromDate, toDate);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
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
    public class PalletReportController : ApiController
    {
        PalletReport obj = new PalletReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataReport(int? customerID, int? DCID, int? productID, DateTime? dateFrom, DateTime? dateTo, int isMonthly)
        {
            List<sp_RPT028_PalletReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataReport(customerID, DCID, productID, dateFrom, dateTo, isMonthly);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
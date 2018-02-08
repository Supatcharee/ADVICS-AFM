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
    public class OrderBalanceReportController : ApiController
    {
        OrderBalanceReport obj = new OrderBalanceReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataReport(int? OwnerID, int? WarehouseID, DateTime? dateFrom, DateTime? dateTo)
        {
            List<sp_RPT032_OrderBalance_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataReport(OwnerID, WarehouseID, dateFrom, dateTo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
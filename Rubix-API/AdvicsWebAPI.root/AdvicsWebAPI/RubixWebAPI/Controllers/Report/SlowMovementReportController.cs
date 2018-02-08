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
    public class SlowMovementReportController : ApiController
    {
        SlowMovementReport obj = new SlowMovementReport();
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataReport(int? OwnerID, int? WarehouseID, DateTime Date, Int32 period1, Int32 period2, Int32 period3, Int32 period4)
        {
            List<sp_RPT031_SlowMovement_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataReport(OwnerID, WarehouseID, Date, period1, period2, period3, period4);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }

    }
}
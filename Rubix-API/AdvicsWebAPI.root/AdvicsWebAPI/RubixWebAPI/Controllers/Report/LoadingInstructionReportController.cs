using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.Report;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Report
{
    public class LoadingInstructionReportController : ApiController
    {
        LoadingInstructionReport obj = new LoadingInstructionReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataReport(string ShipmentNo, int Installment, string ContainNo, DateTime? PlanOut, DateTime? ActualOut)
        {
            List<sp_RPT036_LoadingInstruction_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataReport(ShipmentNo, Installment, ContainNo, PlanOut, ActualOut);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
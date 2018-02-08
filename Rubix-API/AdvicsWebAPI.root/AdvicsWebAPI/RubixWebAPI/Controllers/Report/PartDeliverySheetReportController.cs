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
    public class PartDeliverySheetReportController : ApiController
    {
        PartDeliverySheetReport obj = new PartDeliverySheetReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataReport(string PONo)
        {
            List<sp_RPT033_PartDeliverySheet_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataReport(PONo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetSubDataReport(string PONo)
        {
            List<sp_RPT033_PartDeliverySheet_GetSubData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetSubDataReport(PONo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

    }
}
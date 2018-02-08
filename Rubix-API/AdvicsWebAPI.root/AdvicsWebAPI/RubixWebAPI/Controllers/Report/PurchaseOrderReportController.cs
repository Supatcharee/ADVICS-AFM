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
    public class PurchaseOrderReportController : ApiController
    {
        PurchaseOrderReport obj = new PurchaseOrderReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataReport()
        {
            List<sp_RPT034_PurchaseOrder_GetData_Result> ResultReturn;
            string ReceivingNoXML = Request.Content.ReadAsStringAsync().Result;
            
            try
            {
                ResultReturn = obj.GetDataReport(ReceivingNoXML);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}

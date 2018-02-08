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
using CSI.Business;

namespace RubixWebAPI.Controllers.Report
{
    public class DeliveryOrderReportController : ApiController
    {
        DeliveryOrderReport obj = new DeliveryOrderReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PrintDeliveryOrder(string shipmentNo, String pickingNo)
        {
            List<sp_RPT022_DeliveryOrder_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.PrintDeliveryOrder(shipmentNo,pickingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
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
    public class ShippingDeliveryReportController : ApiController
    {
        ShippingDeliveryReport obj = new ShippingDeliveryReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataReport(int? OwnerID, int? WarehouseID, String shipmentNo, String invoicecNo, DateTime? transitDate1, DateTime? transitDate2, int? productID)
        {
            List<sp_RPT013_ShippingDeliveryReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataReport(OwnerID, WarehouseID, shipmentNo, invoicecNo, transitDate1, transitDate2, productID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
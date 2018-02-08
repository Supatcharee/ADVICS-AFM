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
    public class ShippingInstructionReportController : ApiController
    {
        private ShippingInstructionReport obj = new ShippingInstructionReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetCoverDataReport(string ShipmentNo, int Installment, string ContainerNo)
        {
            DataSet ResultReturn;

            try
            {
                ResultReturn = obj.GetCoverData_Report(ShipmentNo, Installment, ContainerNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetListDataReport(string ShipmentNo, int Installment, string ContainerNo)
        {
            DataSet ResultReturn;

            try
            {
                ResultReturn = obj.GetListData_Report(ShipmentNo, Installment, ContainerNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
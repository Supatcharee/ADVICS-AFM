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
    public class PrivilegeFormatReportController : ApiController
    {
        PrivilegeFormatReport obj = new PrivilegeFormatReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataReport(string ShipmentNo, string ContainerNo)
        {
            List<sp_RPT043_PrivilegeFormat_GetData_Result> ResultReturn;
            //string ShipmentNo = Request.Content.ReadAsStringAsync().Result;

            try
            {
                ResultReturn = obj.GetDataReport(ShipmentNo, ContainerNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }


    }
}

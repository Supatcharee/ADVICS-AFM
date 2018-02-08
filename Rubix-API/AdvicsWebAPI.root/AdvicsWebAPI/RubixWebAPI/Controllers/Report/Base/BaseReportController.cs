using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.BusinessFactory.Report.Base;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Report.Base
{
    public class BaseReportController : ApiController
    {
        BaseReport obj = new BaseReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetReportDefaultParams(string reportID)
        {
            List<ReportDefaultParam> ResultReturn;
            try
            {
                ResultReturn = obj.GetReportDefaultParams(reportID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetLabelHeader()
        {
            String ResultReturn;
            try
            {
                ResultReturn = obj.GetLabelHeader();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

    }
}
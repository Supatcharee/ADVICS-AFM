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
    public class ReceivingReportController : ApiController
    {
        ReceivingReport obj = new ReceivingReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage  DataLoading(int? OwnerID,int? WarehouseID,String ReceivingNo,DateTime? ReceivingDate1,DateTime? ReceivingDate2,DateTime? ReceivingDateActual1,DateTime? ReceivingDateActual2)
        {
            List<sp_RPT001_ReceivingReport_SearchAll_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID, ReceivingNo, ReceivingDate1, ReceivingDate2, ReceivingDateActual1, ReceivingDateActual2);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataReport(String ReceivingNo)
        {
            List<sp_RPT001_ReceivingReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataReport(ReceivingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }
    }
}
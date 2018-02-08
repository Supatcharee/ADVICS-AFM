using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using CSI.Business.BusinessFactory.Report;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;

namespace RubixWebAPI.Controllers.Report
{
    public class PickingListReportController : ApiController
    {
        PickingListReport obj = new PickingListReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataReport(String shipmentNo, String pickingNo)
        {
            List<sp_RPT021_PickingList_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataReport(shipmentNo, pickingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataSubReport(String shipmentNo, String pickingNo)
        {
            List<sp_RPT021_PickingList_SubReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataSubReport(shipmentNo, pickingNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

    }
}
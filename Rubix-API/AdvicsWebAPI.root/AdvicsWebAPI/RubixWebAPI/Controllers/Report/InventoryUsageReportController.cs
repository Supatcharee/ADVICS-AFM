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
    public class InventoryUsageReportController : ApiController
    {
        InventoryUsageReport obj = new InventoryUsageReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataReport(int? WarehouseID,int? OwnerID)
        {
            List<sp_RPT025_InventoryUsageReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataReport(WarehouseID, OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataChartReport(int? WarehouseID,int? OwnerID)
        {
            List<sp_RPT026_InventoryUsageReport_Chart_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataChartReport(WarehouseID, OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        //[HttpPost, HttpGet, APIAuthorize]
        //public HttpResponseMessage GetMaxDailyPostDate()
        //{
        //    List<DateTime?> ResultReturn;
        //    try
        //    {
        //        ResultReturn = obj.GetMaxDailyPostDate();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        //}
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetSubReport(int? WarehouseID,int? OwnerID)
        {
            List<sp_RPT025_InventoryUsageReport_GetData_Sub_Report_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetSubReport(WarehouseID, OwnerID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

    }
}
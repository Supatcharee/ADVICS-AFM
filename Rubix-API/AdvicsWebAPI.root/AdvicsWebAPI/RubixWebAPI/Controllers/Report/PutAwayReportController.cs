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
    public class PutAwayReportController : ApiController
    {
        PutAwayReport obj = new PutAwayReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataReport(int? OwnerID, int? WarehouseID, int? ProductID, String ReceivingNo, DateTime? TransitDate1, DateTime? TransitDate2, int? zoneID, int? TypeId)
        {
            List<sp_RPT002_PutAwayReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataReport(OwnerID, WarehouseID, ProductID, ReceivingNo, TransitDate1, TransitDate2, zoneID, TypeId);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    
    }
}
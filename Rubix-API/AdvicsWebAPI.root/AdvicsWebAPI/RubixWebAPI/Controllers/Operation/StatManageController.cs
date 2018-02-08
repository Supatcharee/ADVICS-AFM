using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.Operation;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Operation
{
    public class StatManageController : ApiController
    {
        StatManage obj = new StatManage();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID, int? WarehouseID, DateTime? TransFrom, DateTime? TransTo)
        {
            ObjectResult<sp_MSTS010_HistoryView_Search_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID, TransFrom, TransTo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataSummaryLoading(int? OwnerID, int? WarehouseID, DateTime? TransFrom, DateTime? TransTo)
        {
            ObjectResult<sp_MSTS010_HistoryView_Summary_Search_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataSummaryLoading(OwnerID, WarehouseID, TransFrom, TransTo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
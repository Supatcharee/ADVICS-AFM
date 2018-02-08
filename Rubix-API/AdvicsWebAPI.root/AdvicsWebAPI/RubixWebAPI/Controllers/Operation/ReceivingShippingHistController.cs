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
    public class ReceivingShippingHistController : ApiController
    {
        ReceivingShippingHist obj = new ReceivingShippingHist();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID, int? WarehouseID, int? ProductID, int? ConditionOfProductID, DateTime DateFrom, DateTime DateTo, String Location)
        {
            ObjectResult<sp_ESTS050_InquiryReceivingShippingHistory_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID, ProductID, ConditionOfProductID, DateFrom, DateTo, Location);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
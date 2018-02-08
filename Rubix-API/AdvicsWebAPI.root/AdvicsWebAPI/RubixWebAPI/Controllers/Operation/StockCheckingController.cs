using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business.BusinessFactory.Operation;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Net.Http;
using System.Net;
using System.Data;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Operation
{
    public class StockCheckingController : ApiController
    {
        StockChecking obj = new StockChecking();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? iCustomerID, int? iWarehouseID, int? iProductID, DateTime? dtdateFrom, DateTime? dtdateTo, bool? idiffFlage)
        {
            List<sp_ESTS040_StockChecking_Get_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(iCustomerID, iWarehouseID, iProductID, dtdateFrom, dtdateTo, idiffFlage);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

    }
}
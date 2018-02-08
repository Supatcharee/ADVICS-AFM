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
    public class CollectionASNController : ApiController
    {
        CollectionASN obj = new CollectionASN();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? iCustomerID, int? iWarehouseID, DateTime? dtArrivalDateFrom, DateTime? dtArrivalDateTo, string strSlipNo, int? iTruckCompanyID, int? iSupplierID)
        {
            ObjectResult<sp_CRCS010_CollectionASN_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(iCustomerID, iWarehouseID, dtArrivalDateFrom, dtArrivalDateTo, strSlipNo, iTruckCompanyID, iSupplierID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}
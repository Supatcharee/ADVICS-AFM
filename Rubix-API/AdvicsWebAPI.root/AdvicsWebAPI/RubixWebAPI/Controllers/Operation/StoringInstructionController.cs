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
    public class StoringInstructionController : ApiController
    {
        StoringInstruction obj = new StoringInstruction();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? iArrivalStatus, int? iCustomerID, int? iWarehouseID, DateTime? dtArrivalDateFrom, DateTime? dtArrivalDateTo,
                                               string strSlipNo, int? iTruckCompanyID, int? iSupplierID, int? productID, string lotNo)
        {
            List<sp_CRCS020_StoringInstruction_SearchAll_Result> ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading(iArrivalStatus, iCustomerID, iWarehouseID, dtArrivalDateFrom, dtArrivalDateTo,
                                               strSlipNo, iTruckCompanyID, iSupplierID, productID, lotNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage PrepareTransit(string ReceivingNo, int Installment, int OwnerID, string CreateUser)
        {
            try
            {
                obj.PrepareTransit(ReceivingNo, Installment, OwnerID, CreateUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);

        }

    }
}
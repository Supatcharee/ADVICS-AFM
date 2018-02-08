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
    public class ReceivingProgressController : ApiController
    {
        ReceivingProgress obj = new ReceivingProgress();
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID, int? WarehouseID, int? SupplierID, string ReceivingNo, DateTime? ArrivalDate
                                               , DateTime? ReceivingDate, DateTime? StoringDate, DateTime? TransitInstructionDate, string referenceNo)
        {
            List<sp_LWPS010_ReceivingProgress_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, WarehouseID, SupplierID, ReceivingNo, ArrivalDate, ReceivingDate, StoringDate, TransitInstructionDate, referenceNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

                        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadSummary(int? OwnerID, int? WarehouseID, int? SupplierID, string ReceivingNo, DateTime? ArrivalDate
                                                , DateTime? ReceivingDate, DateTime? StoringDate, DateTime? InstructionDate, string referenceNo)
        {
            List<sp_LWPS010_ReceivingProgress_SearchTotal_Result> ResultReturn;
            try
            {
                ResultReturn = obj.LoadSummary(OwnerID
                                            ,   WarehouseID
                                            ,   SupplierID
                                            ,   ReceivingNo
                                            ,   ArrivalDate
                                            ,   ReceivingDate
                                            ,   StoringDate
                                            ,   InstructionDate
                                            ,   referenceNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }

    }
}
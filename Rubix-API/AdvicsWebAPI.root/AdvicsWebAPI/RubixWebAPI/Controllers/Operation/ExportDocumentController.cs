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
    public class ExportDocumentController : ApiController
    {

        ExportDocument obj = new ExportDocument();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage Search(int? OwnerID
            , int? CustomerID
            , int? WarehouseID
            , string ShippingDateFrom
            , string ShippingDateTo
            , string CustomerPONo
            , string SONo
            , string ContainerNo)
        {
            List<sp_ISHS010_ExportDocument_SearchAll_Result> ResultReturn;

            try
            {
                ResultReturn = obj.DataLoading(OwnerID, CustomerID, WarehouseID, ShippingDateFrom, ShippingDateTo, CustomerPONo, SONo, ContainerNo);
            }
            catch (Exception ex)
            {
                
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage UpdatePrePrint(string ShipmentNo, int Installment, string ContainerNo)
        {
            try
            {
                obj.UpdatePrePrint(ShipmentNo, Installment, ContainerNo);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
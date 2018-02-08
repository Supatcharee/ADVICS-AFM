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
    public class PickingChargeReportController : ApiController
    {
        ChargeReport obj = new ChargeReport();

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataPickingChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            List<sp_RPT009_PickingChargeReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataPickingChargeReport(OwnerID, WarehouseID, Date1, Date2);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataOutgoingChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            List<sp_RPT010_OutgoingChargeReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataOutgoingChargeReport(OwnerID, WarehouseID, Date1, Date2);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataOutgoingChargeSubReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            List<sp_RPT010_OutgoingChargeReport_SubReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataOutgoingChargeSubReport(OwnerID, WarehouseID, Date1, Date2);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataIncomingChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            List<sp_RPT007_IncomingChargeReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataIncomingChargeReport(OwnerID, WarehouseID, Date1, Date2);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataIncomingChargeSubReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            List<sp_RPT007_IncomingChargeReport_SubReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataIncomingChargeSubReport(OwnerID, WarehouseID, Date1, Date2);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataUnstaffingChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            List<sp_RPT006_UnstaffingChargeReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataUnstaffingChargeReport(OwnerID, WarehouseID, Date1, Date2);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataTransitChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            List<sp_RPT008_TransitChargeReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataTransitChargeReport(OwnerID, WarehouseID, Date1, Date2);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataTransitChargeSubReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            List<sp_RPT008_TransitChargeReport_SubReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataTransitChargeSubReport(OwnerID, WarehouseID, Date1, Date2);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataTransportChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            List<sp_RPT011_TransportationChargeReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataTransportChargeReport(OwnerID, WarehouseID, Date1, Date2);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataOtherChargeReport(Nullable<Int32> OwnerID, Nullable<Int32> WarehouseID, Nullable<DateTime> transactionDateFrom, Nullable<DateTime> transactionDateTo)
        {
            List<sp_RPT003_OtherChargeReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataOtherChargeReport(OwnerID, WarehouseID, transactionDateFrom, transactionDateTo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataSummaryChargeReport(Nullable<Int32> OwnerID, Nullable<Int32> WarehouseID, Nullable<DateTime> transactionDateFrom, Nullable<DateTime> transactionDateTo)
        {
            List<sp_RPT004_SummaryChargeReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataSummaryChargeReport(OwnerID, WarehouseID, transactionDateFrom, transactionDateTo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetDataReceivingTransportChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            List<sp_RPT005_ReceivingTransportationChargeReport_GetData_Result> ResultReturn;
            try
            {
                ResultReturn = obj.GetDataReceivingTransportChargeReport(OwnerID, WarehouseID, Date1, Date2);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);

        }
    }
}
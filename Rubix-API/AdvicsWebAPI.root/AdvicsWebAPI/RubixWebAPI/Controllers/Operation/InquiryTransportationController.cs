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
    public class InquiryTransportationController : ApiController
    {
        InquiryTransportation obj = new InquiryTransportation();

        struct strInquiryTransportation
        {
            public string ShipmentNo;
            public int? TruckCompanyID;
            public int? TransportTypeID;
            public decimal? TransportCharge;
            public decimal? OutgoingCharge;
            public string RegistrationNo;
            public string ContainerNo;
            public string DriverName;
            public decimal? TotalShipWeight;
            public string Remark;
            public DateTime? PlanIn;
            public DateTime? PlanOut;
            public DateTime? ActualIn;
            public DateTime? ActualOut;
            public string TransportSeqXML;
            public string BookingNo;
            public string SealNo;
            public DateTime? VanningDate;
            public int? FinaldestinationID;
            public int ISRemoveInvoiceNo;
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading(int? OwnerID,
                                                int? WarehouseID,
                                                string DeliveryDateFrom,
                                                string DeliveryDateTo,
                                                int? FinalDestinationID,
                                                int? PortID,
                                                int? TruckCompanyID,
                                                int? CustomerID,
                                                int? NoTransportData,
                                                string ContainerNo,
                                                string TransportDateFrom,
                                                string TransportDateTo,
                                                bool isActual
            )
        {
            DataTable ResultReturn;
            try
            {
                ResultReturn = obj.DataLoading( OwnerID,
                                                WarehouseID,
                                                DeliveryDateFrom,
                                                DeliveryDateTo,
                                                FinalDestinationID,
                                                PortID,
                                                TruckCompanyID,
                                                CustomerID,
                                                NoTransportData,
                                                ContainerNo,
                                                TransportDateFrom,
                                                TransportDateTo,
                                                isActual);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }


        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoadingDetail()
        {
            DataTable ResultReturn;
            string TransportSeqXML = Request.Content.ReadAsStringAsync().Result;
            try
            {
                ResultReturn = obj.DataLoadingDetail(TransportSeqXML);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage SaveData()
        {
            try
            {
                string strResult = Request.Content.ReadAsStringAsync().Result;
                strInquiryTransportation stc = JsonConvert.DeserializeObject<strInquiryTransportation>(strResult);

                obj.SaveData(stc.ShipmentNo
                             , stc.TruckCompanyID
                             , stc.TransportTypeID
                             , stc.TransportCharge
                             , stc.OutgoingCharge
                             , stc.RegistrationNo
                             , stc.ContainerNo
                             , stc.DriverName
                             , stc.TotalShipWeight
                             , stc.Remark
                             , stc.PlanIn
                             , stc.PlanOut
                             , stc.ActualIn
                             , stc.ActualOut
                             , stc.TransportSeqXML
                             , stc.BookingNo
                             , stc.SealNo
                             , stc.VanningDate
                             , stc.FinaldestinationID
                             , stc.ISRemoveInvoiceNo);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
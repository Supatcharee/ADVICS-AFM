using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
using Newtonsoft.Json;
using System.Data;

namespace CSI.Business.Operation
{
    public class InquiryTransportation
    {
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

        public DataTable DataLoading(int? OwnerID
                                     ,int? WarehouseID
                                     ,string DeliveryDateFrom
                                     ,string DeliveryDateTo
                                     ,int? FinalDestinationID
                                     ,int? PortID
                                     ,int? TruckCompanyID
                                     ,int? CustomerID
                                     ,int? NoTransportData
                                     ,string ContainerNo
                                     ,string TransportDateFrom
                                     ,string TransportDateTo
                                     ,bool isActual
            )
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("DeliveryDateFrom", DeliveryDateFrom);
            hs.Add("DeliveryDateTo", DeliveryDateTo);
            hs.Add("FinalDestinationID", FinalDestinationID);
            hs.Add("PortID", PortID);
            hs.Add("TruckCompanyID", TruckCompanyID);
            hs.Add("CustomerID", CustomerID);
            hs.Add("NoTransportData", NoTransportData);
            hs.Add("ContainerNo", ContainerNo);
            hs.Add("TransportDateFrom", TransportDateFrom);
            hs.Add("TransportDateTo", TransportDateTo);
            hs.Add("isActual", isActual);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("InquiryTransportation/DataLoading", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable DataLoadingDetail(string TransportSeqXML)
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("InquiryTransportation/DataLoadingDetail", JsonConvert.SerializeObject(TransportSeqXML));
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveData(string ShipmentNo
                            ,int? TruckCompanyID
                            ,int? TransportTypeID
                            ,decimal? TransportCharge
                            ,decimal? OutgoingCharge
                            ,string RegistrationNo
                            ,string ContainerNo
                            ,string DriverName
                            ,decimal? TotalShipWeight
                            ,string Remark
                            ,DateTime? PlanIn
                            ,DateTime? PlanOut
                            ,DateTime? ActualIn
                            , DateTime? ActualOut
                            , string TransportSeqXML
                            , string BookingNo
                            , string SealNo
                            , DateTime? VanningDate
                            , int? FinaldestinationID
                            , int ISRemoveInvoiceNo)
        {
            strInquiryTransportation str = new strInquiryTransportation();
            Hashtable hs = new Hashtable();
            str.ShipmentNo = ShipmentNo;
            str.TruckCompanyID = TruckCompanyID;
            str.TransportTypeID = TransportTypeID;
            str.TransportCharge = TransportCharge;
            str.OutgoingCharge = OutgoingCharge;
            str.RegistrationNo = RegistrationNo;
            str.ContainerNo = ContainerNo;
            str.DriverName = DriverName;
            str.TotalShipWeight = TotalShipWeight;
            str.Remark = Remark;
            str.PlanIn = PlanIn;
            str.PlanOut = PlanOut;
            str.ActualIn = ActualIn;
            str.ActualOut = ActualOut;
            str.TransportSeqXML = TransportSeqXML;
            str.BookingNo = BookingNo;
            str.SealNo = SealNo;
            str.VanningDate = VanningDate;
            str.FinaldestinationID = FinaldestinationID;
            str.ISRemoveInvoiceNo = ISRemoveInvoiceNo;

            try
            {
                RubixWebAPI.ExecuteObjectResult("InquiryTransportation/SaveData", JsonConvert.SerializeObject(str));                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

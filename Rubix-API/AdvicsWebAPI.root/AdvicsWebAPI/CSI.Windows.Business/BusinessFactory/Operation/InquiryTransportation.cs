using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using System.Collections;

namespace CSI.Business.Operation
{
    public class InquiryTransportation
    {
        #region Member
        private ObjectResult<sp_JTRS010_InquiryTransportation_SearchAll_Result> lt_Result = null;
        private sp_JTRS010_InquiryTransportation_SearchAll_Result ta_Result = null;
        private BusinessCommon ims = null;
        #endregion

        #region Properties
        private BusinessCommon Database
        {
            get
            {
                if (ims == null)
                {
                    ims = new BusinessCommon();
                }
                return ims;
            }
        }

        private ObjectResult<sp_JTRS010_InquiryTransportation_SearchAll_Result> ResultList
        {
            get { return lt_Result; }
            set { lt_Result = value; }
        }

        #endregion


        public DataTable DataLoading(int? OwnerID, int? WarehouseID, string DeliveryDateFrom, string DeliveryDateTo, int? FinalDestinationID, int? PortID, int? TruckCompanyID, int? CustomerID, int? NoTransportData, string ContainerNo, string TransportDateFrom, string TransportDateTo, bool isActual)
        {

            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("DeliveryDateFrom", DeliveryDateFrom);
                hs.Add("DeliveryDateTo",DeliveryDateTo);
                hs.Add("FinalDestinationID",FinalDestinationID);
                hs.Add("PortID",PortID);
                hs.Add("TruckCompanyID",TruckCompanyID);
                hs.Add("CustomerID",CustomerID);
                hs.Add("NoTransportData", NoTransportData == 0 ? null : NoTransportData);
                hs.Add("ContainerNo",ContainerNo);
                hs.Add("TransportDateFrom",TransportDateFrom);
                hs.Add("TransportDateTo", TransportDateTo);
                hs.Add("isActual", isActual);

                return Database.ExecuteDataSet("sp_JTRS010_InquiryTransportation_SearchAll", hs).Tables[0];
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
                Hashtable hs = new Hashtable();
                hs.Add("TransportSeqXML", TransportSeqXML);

                return Database.ExecuteDataSet("sp_JTRS011_InquiryTransportation_SearchDetail", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveData(string ShipmentNo
                            , int? TruckCompanyID
                            , int? TransportTypeID
                            , decimal? TransportCharge
                            , decimal? OutgoingCharge
                            , string RegistrationNo
                            , string ContainerNo
                            , string DriverName
                            , decimal? TotalShipWeight
                            , string Remark
                            , DateTime? PlanIn
                            , DateTime? PlanOut
                            , DateTime? ActualIn
                            , DateTime? ActualOut
                            , string TransportSeqXML
                            , string BookingNo
                            , string SealNo
                            , DateTime? VanningDate
                            , int? FinaldestinationID
                            , int ISRemoveInvoiceNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", ShipmentNo);
                hs.Add("TruckCompanyID", TruckCompanyID);
                hs.Add("TransportTypeID", TransportTypeID);
                hs.Add("TransportCharge", TransportCharge);
                hs.Add("OutgoingCharge", OutgoingCharge);
                hs.Add("RegistrationNo", RegistrationNo);
                hs.Add("ContainerNo", ContainerNo);
                hs.Add("DriverName", DriverName);
                hs.Add("TotalShipWeight", TotalShipWeight);
                hs.Add("Remark", Remark);
                hs.Add("PlanIn", PlanIn);
                hs.Add("PlanOut", PlanOut);
                hs.Add("ActualIn", ActualIn);
                hs.Add("ActualOut", ActualOut);
                hs.Add("TransportSeqXML", TransportSeqXML);
                hs.Add("BookingNo", BookingNo);
                hs.Add("SealNo", SealNo);
                hs.Add("VanningDate", VanningDate);
                hs.Add("FinaldestinationID", FinaldestinationID);
                hs.Add("ISRemoveInvoiceNo", ISRemoveInvoiceNo);

                Database.ExecuteNonQuery("sp_JTRS011_InquiryTransportation_Save", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

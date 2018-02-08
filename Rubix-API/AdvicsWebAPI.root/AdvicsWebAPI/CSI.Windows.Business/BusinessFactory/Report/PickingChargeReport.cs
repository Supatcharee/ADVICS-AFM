using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using Rubix.Framework;

namespace CSI.Business.BusinessFactory.Report
{
    public class ChargeReport : Base.BaseReport
    {


        public List<sp_RPT009_PickingChargeReport_GetData_Result> GetDataPickingChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            try
            {
                return Context.sp_RPT009_PickingChargeReport_GetData(OwnerID, WarehouseID,Date1,Date2).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<sp_RPT010_OutgoingChargeReport_GetData_Result> GetDataOutgoingChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            try
            {
                return Context.sp_RPT010_OutgoingChargeReport_GetData(OwnerID, WarehouseID, Date1, Date2).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<sp_RPT010_OutgoingChargeReport_SubReport_GetData_Result> GetDataOutgoingChargeSubReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            try
            {
                return Context.sp_RPT010_OutgoingChargeReport_SubReport_GetData(OwnerID, WarehouseID, Date1, Date2).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<sp_RPT007_IncomingChargeReport_GetData_Result> GetDataIncomingChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            try
            {
                return Context.sp_RPT007_IncomingChargeReport_GetData(OwnerID, WarehouseID, Date1, Date2).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<sp_RPT007_IncomingChargeReport_SubReport_GetData_Result> GetDataIncomingChargeSubReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            try
            {
                return Context.sp_RPT007_IncomingChargeReport_SubReport_GetData(OwnerID, WarehouseID, Date1, Date2).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<sp_RPT006_UnstaffingChargeReport_GetData_Result> GetDataUnstaffingChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            try
            {
                return Context.sp_RPT006_UnstaffingChargeReport_GetData(OwnerID, WarehouseID, Date1, Date2).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<sp_RPT008_TransitChargeReport_GetData_Result> GetDataTransitChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            try
            {
                return Context.sp_RPT008_TransitChargeReport_GetData( ownerID: OwnerID, 
                                                                                    warehouseID:WarehouseID, 
                                                                                    dateStart:Date1, 
                                                                                    dateEnd:Date2).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<sp_RPT008_TransitChargeReport_SubReport_GetData_Result> GetDataTransitChargeSubReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            try
            {
                return Context.sp_RPT008_TransitChargeReport_SubReport_GetData(ownerID: OwnerID,
                                                                                    warehouseID: WarehouseID,
                                                                                    dateStart: Date1,
                                                                                    dateEnd: Date2).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<sp_RPT011_TransportationChargeReport_GetData_Result> GetDataTransportChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            try
            {
                List<sp_RPT011_TransportationChargeReport_GetData_Result> list =
                    Context.sp_RPT011_TransportationChargeReport_GetData(ownerID: OwnerID, warehouseID: WarehouseID, dateStart: Date1, dateEnd: Date2).ToList();
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<sp_RPT003_OtherChargeReport_GetData_Result> GetDataOtherChargeReport(Nullable<global::System.Int32> OwnerID
            , Nullable<global::System.Int32> WarehouseID
            , Nullable<global::System.DateTime> transactionDateFrom
            , Nullable<global::System.DateTime> transactionDateTo)
        {
            try
            {
                return Context.sp_RPT003_OtherChargeReport_GetData(
                    ownerID: OwnerID
                    , warehouseID: WarehouseID
                    , transactionDateFrom: transactionDateFrom
                    , transactionDateTo: transactionDateTo).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<sp_RPT004_SummaryChargeReport_GetData_Result> GetDataSummaryChargeReport(Nullable<global::System.Int32> OwnerID
            , Nullable<global::System.Int32> WarehouseID
            , Nullable<global::System.DateTime> transactionDateFrom
            , Nullable<global::System.DateTime> transactionDateTo)
        {
            try
            {
                return Context.sp_RPT004_SummaryChargeReport_GetData(
                    ownerID: OwnerID
                    , warehouseID: WarehouseID
                    , transactionDateFrom: transactionDateFrom
                    , transactionDateTo: transactionDateTo).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<sp_RPT005_ReceivingTransportationChargeReport_GetData_Result> GetDataReceivingTransportChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            try
            {
                List<sp_RPT005_ReceivingTransportationChargeReport_GetData_Result> list =
                   Context.sp_RPT005_ReceivingTransportationChargeReport_GetData(ownerID: OwnerID,
                                                                                   warehouseID: WarehouseID,
                                                                                   fromDate: Date1,
                                                                                   toDate: Date2).ToList();
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public decimal? OtherCharge_GetGrandTotal(List<sp_RPT003_OtherChargeReport_GetData_Result> list)
        {
            decimal? sumShipping = (from p in list
                                    select p.ShippingAmount).Sum();
            decimal? sumReceiving = (from p in list
                                     select p.ReceivingAmount).Sum();
            return sumReceiving + sumShipping;

        }
    }
}

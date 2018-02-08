using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using Rubix.Framework;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.BusinessFactory.Report
{
    public class ChargeReport : Base.BaseReport
    {  
        public List<sp_RPT009_PickingChargeReport_GetData_Result> GetDataPickingChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("Date1", Date1);
            hs.Add("Date2", Date2);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PickingChargeReport/GetDataPickingChargeReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT009_PickingChargeReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT010_OutgoingChargeReport_GetData_Result> GetDataOutgoingChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("Date1", Date1);
            hs.Add("Date2", Date2);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PickingChargeReport/GetDataOutgoingChargeReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT010_OutgoingChargeReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT010_OutgoingChargeReport_SubReport_GetData_Result> GetDataOutgoingChargeSubReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("Date1", Date1);
            hs.Add("Date2", Date2);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PickingChargeReport/GetDataOutgoingChargeSubReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT010_OutgoingChargeReport_SubReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT007_IncomingChargeReport_GetData_Result> GetDataIncomingChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("Date1", Date1);
            hs.Add("Date2", Date2);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PickingChargeReport/GetDataIncomingChargeReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT007_IncomingChargeReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT007_IncomingChargeReport_SubReport_GetData_Result> GetDataIncomingChargeSubReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("Date1", Date1);
            hs.Add("Date2", Date2);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PickingChargeReport/GetDataIncomingChargeSubReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT007_IncomingChargeReport_SubReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT006_UnstaffingChargeReport_GetData_Result> GetDataUnstaffingChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("Date1", Date1);
            hs.Add("Date2", Date2);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PickingChargeReport/GetDataUnstaffingChargeReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT006_UnstaffingChargeReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<sp_RPT008_TransitChargeReport_GetData_Result> GetDataTransitChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("Date1", Date1);
            hs.Add("Date2", Date2);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PickingChargeReport/GetDataTransitChargeReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT008_TransitChargeReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT008_TransitChargeReport_SubReport_GetData_Result> GetDataTransitChargeSubReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("Date1", Date1);
            hs.Add("Date2", Date2);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PickingChargeReport/GetDataTransitChargeSubReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT008_TransitChargeReport_SubReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT011_TransportationChargeReport_GetData_Result> GetDataTransportChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2, out int? NumResult)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("Date1", Date1);
            hs.Add("Date2", Date2);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PickingChargeReport/GetDataTransportChargeReport", hs);
                NumResult = 0;
                return JsonConvert.DeserializeObject<List<sp_RPT011_TransportationChargeReport_GetData_Result>>(strResult);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT003_OtherChargeReport_GetData_Result> GetDataOtherChargeReport(int? OwnerID, int? WarehouseID, DateTime? transactionDateFrom, DateTime? transactionDateTo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("transactionDateFrom", transactionDateFrom);
            hs.Add("transactionDateTo", transactionDateTo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PickingChargeReport/GetDataOtherChargeReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT003_OtherChargeReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT004_SummaryChargeReport_GetData_Result> GetDataSummaryChargeReport(int? OwnerID, int? WarehouseID, DateTime? transactionDateFrom, DateTime? transactionDateTo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("transactionDateFrom", transactionDateFrom);
            hs.Add("transactionDateTo", transactionDateTo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PickingChargeReport/GetDataSummaryChargeReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT004_SummaryChargeReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT005_ReceivingTransportationChargeReport_GetData_Result> GetDataReceivingTransportChargeReport(int? OwnerID, int? WarehouseID, DateTime? Date1, DateTime? Date2, out int? NumResult)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("Date1", Date1);
            hs.Add("Date2", Date2);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PickingChargeReport/GetDataTransportChargeReport", hs);
                NumResult = 0;
                return JsonConvert.DeserializeObject<List<sp_RPT005_ReceivingTransportationChargeReport_GetData_Result>>(strResult);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public decimal? OtherCharge_GetGrandTotal(List<sp_RPT003_OtherChargeReport_GetData_Result> list)
        //{
        //    decimal? sumShipping = (from p in list
        //                            select p.ShippingAmount).Sum();
        //    decimal? sumReceiving = (from p in list
        //                             select p.ReceivingAmount).Sum();
        //    return sumReceiving + sumShipping;

        //}
    }
}

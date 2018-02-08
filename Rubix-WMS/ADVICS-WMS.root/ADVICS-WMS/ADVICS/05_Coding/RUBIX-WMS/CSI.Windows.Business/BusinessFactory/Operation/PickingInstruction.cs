/*
 * 23 Jan 2013:
 * 1. add new function "GetSpecificStatusId"
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Transactions;
using Rubix.Framework;
using System.Collections;
using Newtonsoft.Json;
using System.Data;

namespace CSI.Business.Operation
{

    public class PickingInstruction
    {
        string LineNo { get; set; }
        public List<sp_HPCS010_PickingInstruction_Search_Result> DataLoading(int? OwnerID,
                                                                            int? WarehouseID, 
                                                                            String ShipmentNo, 
                                                                            String PickingNo,
                                                                            int? CustomerID, 
                                                                            DateTime? deliveryDateFrom, 
                                                                            DateTime? deliveryDateTo, 
                                                                            string invoiceNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("CustomerID", CustomerID);
            hs.Add("deliveryDateFrom", deliveryDateFrom);
            hs.Add("deliveryDateTo", deliveryDateTo);
            hs.Add("invoiceNo", invoiceNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PickingInstruction/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_HPCS010_PickingInstruction_Search_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public List<sp_HPCS011_PickingInstruction_SearchReprint_Result> DataLoadingReprint(int? OwnerID, 
                                                                                            int? WarehouseID, 
                                                                                            String ShipmentNo, 
                                                                                            String PickingNo, 
                                                                                            int? portOfDischargeID , 
                                                                                            int? finalDestinationID, 
                                                                                            DateTime? pickDateFrom, 
                                                                                            DateTime? pickingDateTo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("portOfDischargeID", portOfDischargeID);
            hs.Add("finalDestinationID", finalDestinationID);
            hs.Add("pickDateFrom", pickDateFrom);
            hs.Add("pickingDateTo", pickingDateTo);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PickingInstruction/DataLoadingReprint", hs);
                return JsonConvert.DeserializeObject<List<sp_HPCS011_PickingInstruction_SearchReprint_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void UpdateStatusID(string ShipmentNo,string PickingNo, int LineNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("PickingNo", PickingNo);
            hs.Add("LineNo", LineNo);

            try
            {
                RubixWebAPI.ExecuteObjectResult("PickingInstruction/UpdateStatusID", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT021_PickingList_GetData_Result>GetDataReport(String shipmentNo,String pickingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("shipmentNo", shipmentNo);
            hs.Add("pickingNo", pickingNo);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PickingInstruction/GetDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT021_PickingList_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT021_PickingList_GetData_Result> GetDataSubReport(List<sp_RPT021_PickingList_GetData_Result> listData)
        {
            try
            {
                var querySumQty =
                    (
                        from data in listData
                        group data by data.UnitCode into g
                        select new
                        {
                            UnitCode = g.Key,
                            sumInstructQty = g.Sum(a => Math.Round(a.AssignQty.Value, 3))
                        }
                    );


                List<sp_RPT021_PickingList_GetData_Result> summaryList = new List<sp_RPT021_PickingList_GetData_Result>();
                foreach (var record in querySumQty)
                {
                    sp_RPT021_PickingList_GetData_Result summary = new sp_RPT021_PickingList_GetData_Result()
                    {
                        UnitCode = record.UnitCode
                        ,
                        AssignQty = record.sumInstructQty
                    };
                    summaryList.Add(summary);
                }

                return summaryList;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<int?> GetSpecificStatusId()
        {
            List<int?> ListStatus = new List<int?>();
            ListStatus.AddRange(new int?[] {Common.Status.NewShippingEntry});
            return ListStatus;
        }

        public List<int?> GetSpecificStatusIdForRePrint()
        {
            List<int?> ListStatus = new List<int?>();
            ListStatus.AddRange(new int?[] { Common.Status.PickingInstructionIssued });
            ListStatus.AddRange(new int?[] { Common.Status.InCompletePicking });
            ListStatus.AddRange(new int?[] { Common.Status.CompletePicking });
            ListStatus.AddRange(new int?[] { Common.Status.PackingInnstructionIssued });
            return ListStatus;
        }

        public DataTable PickingListDataLoading(int? OwnerID,
                                                int? WarehouseID,
                                                int? CustomerID,
                                                DateTime? PickingDateFrom,
                                                DateTime? PickingDateTo,
                                                bool isCompleteTransport,
                                                bool isActual)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("CustomerID", CustomerID);
            hs.Add("PickingDateFrom", PickingDateFrom);
            hs.Add("PickingDateTo", PickingDateTo);
            hs.Add("isCompleteTransport", isCompleteTransport);
            hs.Add("isActual", isActual);


            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PickingInstruction/PickingListDataLoading", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable CheckStatus(string XmlCheckBookStatus)
        {
            
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("Common/CheckStatus", JsonConvert.SerializeObject(XmlCheckBookStatus));
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
    }
}

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
using System.Data;

namespace CSI.Business.Operation
{
    public class PickingInstruction
    {
        #region Member
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
        #endregion


        public List<sp_HPCS010_PickingInstruction_Search_Result> DataLoading(int? OwnerID,int? WarehouseID, String ShipmentNo, String PickingNo
            , int? CustomerID, DateTime? deliveryDateFrom, DateTime? deliveryDateTo, string invoiceNo)
        {
            try
            {
                return Database.PickingEntity.sp_HPCS010_PickingInstruction_Search(ownerID:OwnerID
                                                                                  ,warehouseID:WarehouseID
                                                                                  ,shipmentNo:(ShipmentNo == String.Empty ? null : ShipmentNo)
                                                                                  ,pickingNo:(PickingNo == String.Empty ? null : PickingNo)
                                                                                  ,customerID: CustomerID
                                                                                  ,deliveryDateFrom: deliveryDateFrom
                                                                                  ,deliveryDateTo: deliveryDateTo
                                                                                  ,invoiceNo: invoiceNo
                                                                                  ).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            } 
        }

        public List<sp_HPCS011_PickingInstruction_SearchReprint_Result> DataLoadingReprint(int? OwnerID, int? WarehouseID, String ShipmentNo, String PickingNo, int? portOfDischargeID , int? finalDestinationID, DateTime? pickDateFrom, DateTime? pickingDateTo)
        {
            try
            {
                return Database.PickingEntity.sp_HPCS011_PickingInstruction_SearchReprint(ownerID: OwnerID
                                                                                        , warehouseID: WarehouseID
                                                                                        , shipmentNo: (ShipmentNo == String.Empty ? null : ShipmentNo)
                                                                                        , pickingNo: (PickingNo == String.Empty ? null : PickingNo)
                                                                                        , portOfDischargeID: portOfDischargeID
                                                                                        , finalDestinationID: finalDestinationID
                                                                                        , pickingDateFrom: pickDateFrom
                                                                                        , pickingDateTo: pickingDateTo).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public void UpdateStatusID(string shipmentNo,string pickingNo, int LineNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", shipmentNo);
                hs.Add("PickingNo", pickingNo);
                hs.Add("LineNo", LineNo);
                Database.ExecuteNonQuery("sp_HPCS010_PickingInstruction_UpdateStatus", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT021_PickingList_GetData_Result>GetDataReport(String shipmentNo,String pickingNo)
        {
            try
            {
                return Database.ReportEntity.sp_RPT021_PickingList_GetData(shipmentNo:shipmentNo
                                                                           ,pickingNo:pickingNo).ToList();
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

        public DataTable PickingListDataLoading(int? OwnerID, int? WarehouseID, int? CustomerID, DateTime? PickingDateFrom, DateTime? PickingDateTo, bool isCompleteTransport, bool isActual)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("WarehouseID", WarehouseID);
                hs.Add("CustomerID", CustomerID);
                hs.Add("PickingDateFrom", PickingDateFrom);
                hs.Add("PickingDateTo", PickingDateTo);
                hs.Add("isCompleteTransport", isCompleteTransport);
                hs.Add("isActual", isActual);

                return Database.ExecuteDataSet("sp_HPCS040_PickingPlanList_SearchAll", hs).Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

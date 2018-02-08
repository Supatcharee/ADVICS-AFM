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
    public class ShippingProgress
    {
        #region Member
        private BusinessCommon ims = null;
        #endregion

        #region Constant
        const int ORDER_CANCEL_STATUS = 19;
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

        public List<sp_LWPS020_ShippingProgress_SearchAll_Result> DataLoading(Nullable<global::System.Int32> OwnerID
            , Nullable<global::System.Int32> warehouseID
            , Nullable<global::System.Int32> portOfDischargeID
            , Nullable<global::System.Int32> finalDestinationID
            , global::System.String shipmentNo
            , global::System.String pickingNo
            , Nullable<global::System.Int32> shippingAreaID
            , Nullable<global::System.DateTime> transportDate
            , Nullable<global::System.DateTime> pickingDate
            , Nullable<global::System.DateTime> shippingDate
            , Nullable<global::System.DateTime> fromETADate
            , Nullable<global::System.DateTime> toETADate
            ,String invoiceNo
            ,int? CustomerID)
        {
            try
            {
                return Database.HistoryViewEntity.sp_LWPS020_ShippingProgress_SearchAll(ownerID: OwnerID
                       , warehouseID: warehouseID
                       , portOfDischargeID: portOfDischargeID
                       , finalDestinationID: finalDestinationID
                       , shipmentNo: (string.IsNullOrEmpty(shipmentNo) ? null : shipmentNo)
                       , pickingNo: (string.IsNullOrEmpty(pickingNo) ? null : pickingNo)
                       , shippingAreaID: shippingAreaID
                       , transportDate: transportDate
                       , pickingDate: pickingDate
                       , shippingDate: shippingDate
                       , fromETADate: fromETADate
                       , toETADate: toETADate
                       , invoiceNo: (string.IsNullOrEmpty(invoiceNo) ? null : invoiceNo)
                       , customerID: CustomerID).ToList();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        public List<sp_LWPS020_ShippingProgress_SearchTotal_Result> GetSummary(Nullable<global::System.Int32> OwnerID
            , Nullable<global::System.Int32> warehouseID
            , Nullable<global::System.Int32> portOfDischargeID
            , Nullable<global::System.Int32> finalDestinationID
            , global::System.String shipmentNo
            , global::System.String pickingNo
            , Nullable<global::System.Int32> shippingAreaID
            , Nullable<global::System.DateTime> transportDate
            , Nullable<global::System.DateTime> pickingDate
            , Nullable<global::System.DateTime> shippingDate
            , Nullable<global::System.DateTime> fromETADate
            , Nullable<global::System.DateTime> toETADate
            ,String invoiceNo
            ,int? CustomerID)
            
        {
            try
            {
                return Database.HistoryViewEntity.sp_LWPS020_ShippingProgress_SearchTotal(ownerID: OwnerID,
                        warehouseID: warehouseID,
                        portOfDischargeID: portOfDischargeID,
                        finalDestinationID: finalDestinationID,
                        shipmentNo: shipmentNo,
                        pickingNo: pickingNo,
                        shippingAreaID: shippingAreaID,
                        transportDate: transportDate,
                        pickingDate: pickingDate,
                        shippingDate: shippingDate,
                        fromETADate: fromETADate,
                        toETADate: toETADate
                        , invoiceNo: (string.IsNullOrEmpty(invoiceNo) ? null : invoiceNo)
                        , customerID: CustomerID).ToList();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
               
        }
    }
}

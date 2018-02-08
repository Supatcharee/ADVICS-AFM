/*
 * 23 Jan 2013: 
 * 1. add new function "GetSpecificStatusId"
 * 30 Jan 2013: 
 * 1. add validate number of row
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using System.Transactions;
using Rubix.Framework;
using System.Collections;

namespace CSI.Business.Operation
{
    public class PrintPCIDriver : CSI.Business.BusinessFactory.Report.Base.BaseReport
    {
        #region Member
        private BusinessCommon ims = null;
        private List<sp_ISHS060_PrintDeliveryOrder_SearchAll_Result> shippingList;
        #endregion

        #region Constant
        const string COMPLETE_SHIPPING_STATUS = "14";
        const string PRINT_DO_STATUS = "16";
        const int ENTRY_DO_SUCCESS = 0;
        const int ENTRY_DO_FAIL = 1;
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
        public string ShipmentNo { get; set; }
        #endregion

        public List<sp_ISHS060_PrintDeliveryOrder_SearchAll_Result> DataLoading(int? OwnerID, int? WarehouseID, String ShipmentNo, String PickingNo, DateTime? pickDateFrom, DateTime? pickDateTo, int? CustomerID)
        {
            shippingList = Database.ShippingEntity.sp_ISHS060_PrintDeliveryOrder_SearchAll(ownerID: OwnerID
                , warehouseID: WarehouseID
                , shipmentNo: (ShipmentNo == String.Empty ? null : ShipmentNo)
                , pickingNo: (PickingNo == String.Empty ? null : PickingNo)
                , pickDateFrom: pickDateFrom
                , pickDateTo: pickDateTo
                , customerID: CustomerID).ToList();
            return shippingList;
        }

        public Boolean EntryDeliveryOrder(sp_ISHS060_PrintDeliveryOrder_SearchAll_Result data, string UserLogin)
        {
            try
            {
                sp_ISHS060_PrintDeliveryOrder_EntryDO_Result result
                       = Database.ShippingEntity.sp_ISHS060_PrintDeliveryOrder_EntryDO(shipmentNo: data.ShipmentNo
                       , pickingNo: data.PickingNo
                       , installment: data.Installment
                       , user: UserLogin).FirstOrDefault();
                return result.RESULT == ENTRY_DO_SUCCESS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAttachList(string shipmentNo, string pickingNo)
        {
            try
            {
                BusinessCommon db = new BusinessCommon();

                Hashtable hs = new Hashtable();
                hs.Add("ShipmentNo", shipmentNo);
                hs.Add("PickingNo", pickingNo);
                return db.ExecuteDataSet("sp_ISHS062_AttachFile_Get", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT020_ShipmentLabel_GetData_Result> PrintShipmentLabel(string shipmentNo, string pickingNo)
        {
            try
            {
                return Database.ReportEntity.sp_RPT020_ShipmentLabel_GetData(shipmentNo: shipmentNo, pickingNo: pickingNo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

    }
}

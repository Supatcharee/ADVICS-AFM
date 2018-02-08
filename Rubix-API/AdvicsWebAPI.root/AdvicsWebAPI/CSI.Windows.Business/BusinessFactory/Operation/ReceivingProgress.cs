using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;

namespace CSI.Business.Operation
{
    public class ReceivingProgress
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

        public List<sp_LWPS010_ReceivingProgress_SearchAll_Result> DataLoading(
            int? OwnerID
            , int? WarehouseID
            , int? SupplierID
            , string ReceivingNo
            , DateTime? ArrivalDate
            , DateTime? ReceivingDate
            , DateTime? StoringDate
            , DateTime? TransitInstructionDate
            , string referenceNo)
        {
            try
            {
                return Database.HistoryViewEntity.sp_LWPS010_ReceivingProgress_SearchAll(
                        ownerID: OwnerID
                        , warehouseID: WarehouseID
                        , supplierID: SupplierID
                        , receivingNo: (ReceivingNo == string.Empty ? null : ReceivingNo)
                        , arrivalDate: ArrivalDate
                        , receivingDate: ReceivingDate
                        , storingDate: StoringDate
                        , transitInstructionIssuedDate: TransitInstructionDate
                        , referenceNo: (referenceNo == string.Empty ? null : referenceNo)).ToList();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }

        public List<sp_LWPS010_ReceivingProgress_SearchTotal_Result> LoadSummary(
            int? OwnerID
            , int? WarehouseID
            , int? SupplierID
            , string ReceivingNo
            , DateTime? ArrivalDate
            , DateTime? ReceivingDate
            , DateTime? StoringDate
            , DateTime? InstructionDate
            , string referenceNo)
        {
            try
            {
                return Database.HistoryViewEntity.sp_LWPS010_ReceivingProgress_SearchTotal(
                        ownerID: OwnerID
                        , warehouseID: WarehouseID
                        , supplierID: SupplierID
                        , receivingNo: ReceivingNo
                        , arrivalDate: ArrivalDate
                        , receivingDate: ReceivingDate
                        , storingDate: StoringDate
                        , transitInstructionIssuedDate: InstructionDate
                        , referenceNo: referenceNo).ToList();

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}

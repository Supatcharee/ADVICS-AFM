using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;

namespace CSI.Business.Operation
{
    public class ReceivingShippingHist
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

        public ObjectResult<sp_ESTS050_InquiryReceivingShippingHistory_SearchAll_Result> DataLoading(int? OwnerID, int? WarehouseID, int? ProductID, int? ConditionOfProductID, DateTime DateFrom, DateTime DateTo, String Location)
        {
            try
            {
                return Database.StockEntity.sp_ESTS050_InquiryReceivingShippingHistory_SearchAll(ownerID: OwnerID
                                                                                                    , warehouseID: WarehouseID
                                                                                                    , productID: ProductID
                                                                                                    , conditionOfProductID: ConditionOfProductID
                                                                                                    , dateFrom: DateFrom
                                                                                                    , dateTo: DateTo
                                                                                                    , location: Location);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}

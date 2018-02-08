using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;

namespace CSI.Business.Operation
{
    public class CollectionASN
    {
        #region Member
        private BusinessCommon _context = null;
        #endregion

        #region Properties
        private BusinessCommon Database
        {
            get
            {
                if (_context == null)
                {
                    _context = new BusinessCommon();
                }
                return _context;
            }
        }
        #endregion

        public ObjectResult<sp_CRCS010_CollectionASN_SearchAll_Result> DataLoading(int? OwnerID, int? WarehouseID, DateTime? dtArrivalDateFrom, DateTime? dtArrivalDateTo, string strSlipNo, int? iTruckCompanyID, int? iSupplierID)
        {
            try
            {
                return Database.ReceivingEntity.sp_CRCS010_CollectionASN_SearchAll(ownerID: OwnerID, warehouseID: WarehouseID, arrivalDateFrom: dtArrivalDateFrom, arrivalDateTo: dtArrivalDateTo, slipNo: string.IsNullOrWhiteSpace(strSlipNo) ? null : strSlipNo, truckCompanyID: iTruckCompanyID, supplierID: iSupplierID);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}

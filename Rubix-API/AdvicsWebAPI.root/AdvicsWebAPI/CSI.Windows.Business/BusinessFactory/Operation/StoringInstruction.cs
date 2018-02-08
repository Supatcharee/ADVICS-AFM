using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Transactions;
using CSI.Business.BusinessFactory.Operation.Base;
using Rubix.Framework;
using System.Collections;
namespace CSI.Business.Operation
{
    public class StoringInstruction : BaseReceiving
    {
        public List<sp_CRCS020_StoringInstruction_SearchAll_Result> DataLoading(int? iArrivalStatus, int? OwnerID, int? WarehouseID, DateTime? dtArrivalDateFrom, DateTime? dtArrivalDateTo, string strSlipNo, int? iTruckCompanyID, int? iSupplierID, int? productID, string lotNo)
        {
            try
            {
                return Database.ReceivingContext.sp_CRCS020_StoringInstruction_SearchAll(arrivalStatus: iArrivalStatus, ownerID: OwnerID, warehouseID: WarehouseID
                                                                                           , arrivalDateFrom: dtArrivalDateFrom, arrivalDateTo: dtArrivalDateTo
                                                                                           , slipNo: string.IsNullOrWhiteSpace(strSlipNo) ? null : strSlipNo, truckCompanyID: iTruckCompanyID
                                                                                           , supplierID: iSupplierID, productID: productID
                                                                                           , lotNo: lotNo).ToList();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public void PrepareTransit(string ReceivingNo, int Installment, int OwnerID, string CreateUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("OwnerID", OwnerID);
                hs.Add("ReceivingNo", ReceivingNo);
                hs.Add("Installment", Installment);
                hs.Add("CreateUser", CreateUser);
                Database.ExecuteNonQuery("sp_CRCS020_Prepare_Transit", hs);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}

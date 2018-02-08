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
using Newtonsoft.Json;
namespace CSI.Business.Operation
{
    public class StoringInstruction : BaseReceiving
    {
        public List<sp_CRCS020_StoringInstruction_SearchAll_Result> DataLoading(int? iArrivalStatus, 
                                                                                int? iCustomerID, 
                                                                                int? iWarehouseID, 
                                                                                DateTime? dtArrivalDateFrom, 
                                                                                DateTime? dtArrivalDateTo, 
                                                                                string strSlipNo, 
                                                                                int? iTruckCompanyID, 
                                                                                int? iSupplierID, 
                                                                                int? productID, 
                                                                                string lotNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("iArrivalStatus", iArrivalStatus);
            hs.Add("iCustomerID", iCustomerID);
            hs.Add("iWarehouseID", iWarehouseID);
            hs.Add("dtArrivalDateFrom", dtArrivalDateFrom);
            hs.Add("dtArrivalDateTo", dtArrivalDateTo);
            hs.Add("strSlipNo", strSlipNo);
            hs.Add("iTruckCompanyID", iTruckCompanyID);
            hs.Add("iSupplierID", iSupplierID);
            hs.Add("productID", productID);
            hs.Add("lotNo", lotNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("StoringInstruction/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_CRCS020_StoringInstruction_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PrepareTransit(string ReceivingNo, int Installment, int OwnerID, string CreateUser)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("Installment", Installment);
            hs.Add("OwnerID", OwnerID);
            hs.Add("CreateUser", CreateUser);

            try
            {
                RubixWebAPI.ExecuteObjectResult("StoringInstruction/PrepareTransit", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

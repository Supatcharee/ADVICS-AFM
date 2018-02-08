using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Data;
using System.Collections;
using Newtonsoft.Json;
namespace CSI.Business.Operation
{
    public class ReceivingProgress
    {
        #region Member

        #endregion

        #region Constant
        const int ORDER_CANCEL_STATUS = 19;
        #endregion
        
        public List<sp_LWPS010_ReceivingProgress_SearchAll_Result> DataLoading(   int? OwnerID
                                                                                , int? WarehouseID
                                                                                , int? SupplierID
                                                                                , string ReceivingNo
                                                                                , DateTime? ArrivalDate
                                                                                , DateTime? ReceivingDate
                                                                                , DateTime? StoringDate
                                                                                , DateTime? TransitInstructionDate
                                                                                , string referenceNo)
        {

            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("SupplierID", SupplierID);
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("ArrivalDate", ArrivalDate);
            hs.Add("ReceivingDate", ReceivingDate);
            hs.Add("StoringDate", StoringDate);
            hs.Add("TransitInstructionDate", TransitInstructionDate);
            hs.Add("referenceNo", referenceNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingProgress/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_LWPS010_ReceivingProgress_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<sp_LWPS010_ReceivingProgress_SearchTotal_Result> LoadSummary(int? OwnerID
                                                                                , int? WarehouseID
                                                                                , int? SupplierID
                                                                                , string ReceivingNo
                                                                                , DateTime? ArrivalDate
                                                                                , DateTime? ReceivingDate
                                                                                , DateTime? StoringDate
                                                                                , DateTime? InstructionDate
                                                                                , string referenceNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("SupplierID", SupplierID);
            hs.Add("ReceivingNo", ReceivingNo);
            hs.Add("ArrivalDate", ArrivalDate);
            hs.Add("ReceivingDate", ReceivingDate);
            hs.Add("StoringDate", StoringDate);
            hs.Add("InstructionDate", InstructionDate);
            hs.Add("referenceNo", referenceNo);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingProgress/LoadSummary", hs);
                return JsonConvert.DeserializeObject<List<sp_LWPS010_ReceivingProgress_SearchTotal_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

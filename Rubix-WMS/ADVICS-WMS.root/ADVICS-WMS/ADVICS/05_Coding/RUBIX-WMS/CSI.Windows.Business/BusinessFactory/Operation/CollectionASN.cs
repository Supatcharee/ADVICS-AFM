using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.Operation
{
    public class CollectionASN
    {
        public List<sp_CRCS010_CollectionASN_SearchAll_Result> DataLoading(int? iCustomerID, int? iWarehouseID, DateTime? dtArrivalDateFrom, 
                                                                                   DateTime? dtArrivalDateTo, string strSlipNo, int? iTruckCompanyID, int? iSupplierID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("iCustomerID", iCustomerID);
            hs.Add("iWarehouseID", iWarehouseID);
            hs.Add("dtArrivalDateFrom", dtArrivalDateFrom);
            hs.Add("dtArrivalDateTo", dtArrivalDateTo);
            hs.Add("strSlipNo", strSlipNo);
            hs.Add("iTruckCompanyID", iTruckCompanyID);
            hs.Add("iSupplierID", iSupplierID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("CollectionASN/DataLoading", hs);
                return JsonConvert.DeserializeObject<List<sp_CRCS010_CollectionASN_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
  
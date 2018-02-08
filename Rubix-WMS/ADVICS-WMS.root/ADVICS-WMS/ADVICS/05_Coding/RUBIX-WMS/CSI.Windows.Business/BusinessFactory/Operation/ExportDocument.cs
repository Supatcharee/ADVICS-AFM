using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using Newtonsoft.Json;

namespace CSI.Business.Operation
{
    public class ExportDocument
    {
        public List<sp_ISHS010_ExportDocument_SearchAll_Result> Search(int? OwnerID,
                                                            int? CustomerID,
                                                            int? WarehouseID,
                                                            string ShippingDateFrom,
                                                            string ShippingDateTo,
                                                            string CustomerPONo,
                                                            string SONo,
                                                            string ContainerNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("CustomerID", CustomerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("ShippingDateFrom", ShippingDateFrom);
            hs.Add("ShippingDateTo", ShippingDateTo);
            hs.Add("CustomerPONo", CustomerPONo);
            hs.Add("SONo", SONo);
            hs.Add("ContainerNo", ContainerNo);
            
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ExportDocument/Search", hs);
                return JsonConvert.DeserializeObject<List<sp_ISHS010_ExportDocument_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePrePrint(string ShipmentNo, int Installment, string ContainerNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("ShipmentNo", ShipmentNo);
            hs.Add("Installment", Installment);
            hs.Add("ContainerNo", ContainerNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ExportDocument/UpdatePrePrint", hs);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

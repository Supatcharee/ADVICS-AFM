using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;

namespace CSI.Business.Operation
{
    public class ExportDocument
    {
        public List<sp_ISHS010_ExportDocument_SearchAll_Result> DataLoading(int? OwnerID, int? CustomerID, int? WarehouseID, string ShippingDateFrom, string ShippingDateTo, string CustomerPONo, string SONo, string ContainerNo)
        {            
            try
            {
                return Database.ShippingContext.sp_ISHS010_ExportDocument_SearchAll(OwnerID, CustomerID, WarehouseID, ShippingDateFrom, ShippingDateTo, CustomerPONo, SONo, ContainerNo).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdatePrePrint(string shipmentNo, int installment, string ContainerNo)
        {
            try
            {
                Database.ShippingContext.sp_ISHS010_ExportDocument_UpdatePrePrint(shipmentNo, installment, ContainerNo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

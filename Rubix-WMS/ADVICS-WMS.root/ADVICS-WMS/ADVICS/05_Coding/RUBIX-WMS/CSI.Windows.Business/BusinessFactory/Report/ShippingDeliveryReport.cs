using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.BusinessFactory.Report
{
    public class ShippingDeliveryReport : Base.BaseReport
    {
        public List<sp_RPT013_ShippingDeliveryReport_GetData_Result> GetDataReport(int? OwnerID, int? WarehouseID, String shipmentNo, String invoicecNo, DateTime? transitDate1, DateTime? transitDate2, int? productID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("OwnerID", OwnerID);
            hs.Add("WarehouseID", WarehouseID);
            hs.Add("shipmentNo", shipmentNo);
            hs.Add("invoicecNo", invoicecNo);
            hs.Add("transitDate1", transitDate1);
            hs.Add("transitDate2", transitDate2);
            hs.Add("productID", productID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ShippingDeliveryReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT013_ShippingDeliveryReport_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT013_ShippingDeliveryReport_GetData_Result> GetDataSubReport(List<sp_RPT013_ShippingDeliveryReport_GetData_Result> listData)
        {
            try
            {                
                var querySumQty =
                    (
                        from data in listData
                        group data by data.UOM into g

                        select new
                        {
                            UOM = g.Key,
                            sumReceivingQty = g.Sum(a => Math.Round(a.ReceivingQty.Value, 3)),
                            sumShippingQty = g.Sum(a => Math.Round(a.ShippingQty.Value, 3)),
                            sumBalanceQty = g.Sum(a => Math.Round(a.BalanceQty.Value, 3))
                        }
                    );


                List<sp_RPT013_ShippingDeliveryReport_GetData_Result> summaryList = new List<sp_RPT013_ShippingDeliveryReport_GetData_Result>();
                foreach (var record in querySumQty)
                {                    
                    sp_RPT013_ShippingDeliveryReport_GetData_Result summary = new sp_RPT013_ShippingDeliveryReport_GetData_Result()
                    {
                        UOM = record.UOM
                        , BalanceQty = record.sumBalanceQty
                        , ReceivingQty = record.sumReceivingQty
                        , ShippingQty = record.sumShippingQty
                    };
                    summaryList.Add(summary);
                }

                return summaryList;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

namespace CSI.Business.DataObjects
{
    public class RPT013SummaryUOM : System.Data.Objects.DataClasses.ComplexObject
    {
        public Nullable<Decimal> BeginQty;
        public Nullable<Decimal> ReceiveQty;
        public Nullable<Decimal> ShipQty;
        public Nullable<Decimal> BalanceQty;
        public String UOM;
    }

    public class RPTSummaryComparer : IEqualityComparer<RPT013SummaryUOM>
    {
        public bool Equals(RPT013SummaryUOM x, RPT013SummaryUOM y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.UOM == y.UOM;
        }

        public int GetHashCode(RPT013SummaryUOM obj)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(obj, null)) return 0;

            //Get hash code for the UOM field if it is not null.
            int hashUOM = obj.UOM == null ? 0 : obj.UOM.GetHashCode();

            //Calculate the hash code for the obj.
            return hashUOM;
        }
    }

}

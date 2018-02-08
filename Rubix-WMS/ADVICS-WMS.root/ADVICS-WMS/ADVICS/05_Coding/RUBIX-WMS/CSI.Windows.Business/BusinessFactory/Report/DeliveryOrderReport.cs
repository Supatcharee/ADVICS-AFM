using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.BusinessFactory.Report
{
    public class DeliveryOrderReport : CSI.Business.BusinessFactory.Report.Base.BaseReport
    {
        public List<sp_RPT022_DeliveryOrder_GetData_Result> PrintDeliveryOrder(string shipmentNo,String pickingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("shipmentNo", shipmentNo);
            hs.Add("pickingNo", pickingNo);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("DeliveryOrderReport/PrintDeliveryOrder", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT022_DeliveryOrder_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<sp_RPT022_DeliveryOrder_GetData_Result> GetDataSubReport(List<sp_RPT022_DeliveryOrder_GetData_Result> listData)
        {
            try
            {
                var querySumQty =
                    (
                        from data in listData
                        group data by data.UnitCode into g
                        select new
                        {
                            UnitCode = g.Key,
                            sumShippingQty = g.Sum(a => Math.Round(a.ShipQty.Value, 3))
                        }
                    );


                List<sp_RPT022_DeliveryOrder_GetData_Result> summaryList = new List<sp_RPT022_DeliveryOrder_GetData_Result>();
                foreach (var record in querySumQty)
                {
                    sp_RPT022_DeliveryOrder_GetData_Result summary = new sp_RPT022_DeliveryOrder_GetData_Result()
                    {
                        UnitCode = record.UnitCode
                        ,
                        ShipQty = record.sumShippingQty
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

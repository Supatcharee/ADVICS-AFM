using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;

namespace CSI.Business.BusinessFactory.Report
{
    public class DeliveryOrderReport : CSI.Business.BusinessFactory.Report.Base.BaseReport
    {
        //#region Member
        //private ReportModelContainer ims = null;
        ////private ReportModelContainer reportContext = null;
        //#endregion

        //private ReportModelContainer Database
        //{
        //    get
        //    {
        //        if (ims == null)
        //        {
        //            ims = new BusinessCommon().ReportEntity;
        //        }
        //        return ims;
        //    }
        //}

        public List<sp_RPT022_DeliveryOrder_GetData_Result> PrintDeliveryOrder(string shipmentNo,String pickingNo)
        {
            //return Database.ReportContext.sp_RPT022_DeliveryOrder_GetData(shipmentNo: shipmentNo).ToList();
            return Database.ReportContext.sp_RPT022_DeliveryOrder_GetData(shipmentNo: shipmentNo, pickingNo: pickingNo).ToList();
        }

        //public List<sp_RPT022_DeliveryOrder_SubReport_GetData_Result> PrintSubDeliveryOrder(string shipmentNo)
        //{
        //    return Database.ReportContext.sp_RPT022_DeliveryOrder_SubReport_GetData(shipmentNo: shipmentNo).ToList();
        //}

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

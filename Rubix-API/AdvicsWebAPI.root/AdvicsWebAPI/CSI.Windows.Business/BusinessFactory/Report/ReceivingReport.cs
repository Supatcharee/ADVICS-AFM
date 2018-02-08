using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using CSI.Business.DataObjects;

namespace CSI.Business.BusinessFactory.Report
{
    public class ReceivingReport : Base.BaseReport
    {
        public List<sp_RPT001_ReceivingReport_SearchAll_Result> DataLoading(int? CustomerID,int? DCID,String ReceivingNo,DateTime? ReceivingDate1,DateTime? ReceivingDate2,DateTime? ReceivingDateActual1,DateTime? ReceivingDateActual2)
        {
            try
            {
                return Context.sp_RPT001_ReceivingReport_SearchAll(CustomerID, DCID, (ReceivingNo == String.Empty ? null : ReceivingNo), ReceivingDate1, ReceivingDate2, ReceivingDateActual1, ReceivingDateActual2).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<sp_RPT001_ReceivingReport_GetData_Result> GetDataReport(String iReceivingNo)
        {
            try
            {
                return Context.sp_RPT001_ReceivingReport_GetData(iReceivingNo).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<int?> GetDistinctCustomerID(List<sp_RPT001_ReceivingReport_SearchAll_Result> DataSource)
        {
            Dictionary<int?, bool> dic = new Dictionary<int?, bool>();
            foreach (sp_RPT001_ReceivingReport_SearchAll_Result data in DataSource)
            {
                dic[data.OwnerID] = true;
            }

            return new List<int?>(dic.Keys);
        }

        public List<sp_RPT001_ReceivingReport_GetData_Result> GetDataSubReport(List<sp_RPT001_ReceivingReport_GetData_Result> listData)
        {
            try
            {
                // calculate sum qty by Unit
                var querySumQty =
                    (
                        from data in listData
                        group data by data.UnitName into g
                        select new
                        {
                            UnitName = g.Key,
                            sumQty = g.Sum(a => Math.Round(a.SQty.Value,3))
                        }
                    );

                var queryDistinctM3 =
                    (
                        from data in listData
                        select new 
                        { 
                            data.LineNo, data.UnitVolume
                        }
                    ).Distinct();

                var querySumM3 = 
                    (
                        from data in queryDistinctM3
                        select data.UnitVolume
                    ).Sum();


                List<sp_RPT001_ReceivingReport_GetData_Result> summaryList = new List<sp_RPT001_ReceivingReport_GetData_Result>();
                foreach (var record in querySumQty)
                {
                    sp_RPT001_ReceivingReport_GetData_Result summary = new sp_RPT001_ReceivingReport_GetData_Result()
                    {
                        UnitName = record.UnitName,
                        SQty = record.sumQty,
                        UnitVolume = querySumM3
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

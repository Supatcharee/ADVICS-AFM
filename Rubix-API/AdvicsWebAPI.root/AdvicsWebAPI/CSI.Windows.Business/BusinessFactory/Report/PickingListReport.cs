using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;

namespace CSI.Business.BusinessFactory.Report
{
    public class PickingListReport : Base.BaseReport
    {
        public List<sp_RPT021_PickingList_GetData_Result> GetDataReport(String shipmentNo, String pickingNo)
        {
            try
            {
                return Context.sp_RPT021_PickingList_GetData(shipmentNo: shipmentNo
                                                                           , pickingNo: pickingNo).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<sp_RPT021_PickingList_SubReport_GetData_Result> GetDataSubReport(String shipmentNo, String pickingNo)
        {
            try
            {
                return Context.sp_RPT021_PickingList_SubReport_GetData(shipmentNo: shipmentNo
                                                                           , pickingNo: pickingNo).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;

namespace CSI.Business.BusinessFactory.Report
{
    public class ReceivingInstruction : Base.BaseReport
    {
        public List<sp_RPT018_ReceivingInstruction_GetData_Result> GetReceivingInstruction(string receivingNo, int installment)
        {
            return Database.ReportContext.sp_RPT018_ReceivingInstruction_GetData(receivingNo: receivingNo, installment: installment).ToList();
        }

        public List<sp_RPT019_ReceivingLabel_GetData_Result> GetReceivingLabel(string palletNo,int? locationID,int? productID,string lotNo,int? productConditonID,int? flag)
        {
            return Database.ReportContext.sp_RPT019_ReceivingLabel_GetData(palletNo: palletNo
                , locationID: locationID
                , productID: productID
                , lotNo: lotNo
                , productConditionID: productConditonID
                , flag: flag).ToList();
        }
    }
}

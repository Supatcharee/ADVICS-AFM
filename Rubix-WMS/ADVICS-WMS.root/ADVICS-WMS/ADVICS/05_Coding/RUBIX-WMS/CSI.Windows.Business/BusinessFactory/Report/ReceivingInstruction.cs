using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Collections;
using Newtonsoft.Json;

namespace CSI.Business.BusinessFactory.Report
{
    public class ReceivingInstruction : Base.BaseReport
    {
        public List<sp_RPT018_ReceivingInstruction_GetData_Result> GetReceivingInstruction(string receivingNo, int installment)
        {
            Hashtable hs = new Hashtable();
            hs.Add("receivingNo", receivingNo);
            hs.Add("installment", installment);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingInstruction/GetReceivingInstruction", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT018_ReceivingInstruction_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT019_ReceivingLabel_GetData_Result> GetReceivingLabel(string palletNo,int? locationID,int? productID,string lotNo,int? productConditonID,int? flag)
        {
            Hashtable hs = new Hashtable();
            hs.Add("palletNo", palletNo);
            hs.Add("locationID", locationID);
            hs.Add("productID", productID);
            hs.Add("lotNo", lotNo);
            hs.Add("productConditonID", productConditonID);
            hs.Add("flag", flag);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("ReceivingInstruction/GetReceivingLabel", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT019_ReceivingLabel_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

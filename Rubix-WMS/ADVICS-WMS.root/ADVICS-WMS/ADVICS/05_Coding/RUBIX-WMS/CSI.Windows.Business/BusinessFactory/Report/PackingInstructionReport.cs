using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.BusinessFactory.Report.Base;
using CSI.Business.DataObjects;
using Newtonsoft.Json;
using System.Collections;
using System.Data.Objects;

namespace CSI.Business.Report
{
    public class PackingInstructionReport : BaseReport
    {
        public List<sp_RPT035_PackingInstruction_GetData_Result> GetDataReport(string packingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("packingNo", packingNo);


            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PackingInstructionReport/GetDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT035_PackingInstruction_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT035_PackingInstruction_Material_GetData_Result> GetMaterialDataReport(string packingNo)
        {
            Hashtable hs = new Hashtable();
            hs.Add("packingNo", packingNo);
            
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("PackingInstructionReport/GetMaterialDataReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT035_PackingInstruction_Material_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT037_CaseMark_GetData_Result> GetCaseMarkReport(string PalletNo)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("PalletNo", PalletNo);
                string strResult = RubixWebAPI.ExecuteObjectResult("PackingInstructionReport/GetCaseMarkReport", hs);
                return JsonConvert.DeserializeObject<List<sp_RPT037_CaseMark_GetData_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

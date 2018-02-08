using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;

namespace CSI.Business.Report
{
    public class PackingInstructionReport : BusinessFactory.Report.Base.BaseReport
    {
        public List<sp_RPT035_PackingInstruction_GetData_Result> GetDataReport(string packingNo)
        {
            try
            {
                return Context.sp_RPT035_PackingInstruction_GetData(packingNo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT035_PackingInstruction_Material_GetData_Result> GetMaterialDataReport(string packingNo)
        {
            try
            {
                return Context.sp_RPT035_PackingInstruction_Material_GetData(packingNo).ToList();
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

                return Database.ReportContext.sp_RPT037_CaseMark_GetData(PalletNo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;

namespace CSI.Business.Report
{
    public class LabelStickerReport : BusinessFactory.Report.Base.BaseReport
    {
        public List<sp_RPT045_LabelSticker_GetData_Result> GetDataReport(string PackingNo)
        {
            try
            {
                return Context.sp_RPT045_LabelSticker_GetData(PackingNo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT045_LabelSticker_GetData_Result> GetDataByRMTagReport(string PackingNo, string RMTagStart, string RMTagEnd, int? ProductID)
        {
            try
            {
                return Context.sp_RPT045_LabelStickerByRMTag_GetData(PackingNo, RMTagStart, RMTagEnd, ProductID).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_RPT046_UserStickerLaber_GetData_Result> GetUserStickerLaberReport()
        {
            try
            {
                return Context.sp_RPT046_UserStickerLaber_GetData().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data.Objects;

namespace CSI.Business.BusinessFactory.Report.Base
{
    public class BaseReport
    {
        #region Member
        private ReportModelContainer _context = null;
        #endregion

        #region Properties
        protected ReportModelContainer Context
        {
            get
            {
                if (_context == null)
                {
                    _context = Database.ReportContext;
                }
                return _context;
            }
        }
        #endregion

        public List<ReportDefaultParam> GetReportDefaultParams(string reportID)
        {
            List<ReportDefaultParam> list = new List<ReportDefaultParam>();
            ObjectResult<sp_common_LoadReportAddress_Result> addrList = Database.CommonContext.sp_common_LoadReportAddress();
            ObjectResult<sp_common_LoadReportISO_Result> isoList = Database.CommonContext.sp_common_LoadReportISO(reportID);
            foreach (sp_common_LoadReportAddress_Result addr in addrList)
                list.Add(new ReportDefaultParam() { Name = addr.ConfigItem, Value = addr.ConfigValue });
            foreach (sp_common_LoadReportISO_Result iso in isoList)
                list.Add(new ReportDefaultParam() { Name = "ISO", Value = iso.ConfigValue });
            return list;
        }
        public String GetLabelHeader()
        {
            Object obj = Database.ExecuteScalar("sp_common_LoadLabelHeader");

            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return string.Empty;
            }
            
            //List<sp_common_LoadLabelHeader_Result> LabelHeaderList = Database.CommonContext.sp_common_LoadLabelHeader().ToList();
            //if (LabelHeaderList.Count != 0)
            //    return LabelHeaderList[0].ToString();
            //else
            //    return null;

        }
    }
}

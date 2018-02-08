using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;

namespace Rubix.Framework
{
    public class ReportUtil
    {

        public static void ShowPreview(IReport rpt)
        {
            
            ReportPrintTool pt = new ReportPrintTool(rpt);
            pt.AutoShowParametersPanel = false;
            pt.ShowPreview();
        }

        public static XtraReport CombineReport(XtraReport mainReport, XtraReport secondaryReport)
        {
            if (mainReport.Pages.Count == 0)
                mainReport.CreateDocument();
            secondaryReport.CreateDocument();
            mainReport.Pages.AddRange(secondaryReport.Pages);
            mainReport.PrintingSystem.ContinuousPageNumbering = false;
            return mainReport;

        }
    }
}

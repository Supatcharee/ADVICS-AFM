using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using System.Collections.Generic;
using System.Data;

namespace Rubix.Screen.Report
{
    public partial class rptRPT025_InventoryUsageReport : Base.BaseReport
    {
        #region Member
        private String warehouse;
        private int pageCount;
        List<sp_RPT025_InventoryUsageReport_GetData_Sub_Report_Result> listSubReport;
        #endregion

        #region Constructor
        public rptRPT025_InventoryUsageReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
            warehouse = String.Empty;
            pageCount = 1;
            listSubReport = new List<sp_RPT025_InventoryUsageReport_GetData_Sub_Report_Result>();
        }

        public rptRPT025_InventoryUsageReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
            warehouse = String.Empty;
            pageCount = 1;
            listSubReport = new List<sp_RPT025_InventoryUsageReport_GetData_Sub_Report_Result>();
        } 
        #endregion
        
        #region Event Handler Function
        private void GroupHeader3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (warehouse != GetCurrentColumnValue("WarehouseName").ToString() && pageCount != 1)
            //{
            //    Report.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            //}
            //else
            //{
            //    warehouse = GetCurrentColumnValue("WarehouseName").ToString();
            //}
            if (warehouse != xrLabel2.Text && pageCount != 1)
            {
                Report.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            }
            else
            {
                warehouse = xrLabel2.Text;
            }

            pageCount++;
        }


        private void GroupFooter3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            rptRPT025_InventoryUsageReport_Sub_Report2.DataSource = null;
            List<sp_RPT025_InventoryUsageReport_GetData_Sub_Report_Result> subReportList = new List<sp_RPT025_InventoryUsageReport_GetData_Sub_Report_Result>();
            foreach (sp_RPT025_InventoryUsageReport_GetData_Sub_Report_Result sub in listSubReport)
            {
                if (sub.WarehouseName == warehouse)
                {
                    subReportList.Add(sub);
                }
            }

            if (subReportList.Count == 0)
            {
                e.Cancel = true;
            }
            else
            {
                rptRPT025_InventoryUsageReport_Sub_Report2.DataSource = subReportList;
            }
        }

        private void xrLabel2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            warehouse = xrLabel2.Text;
        }
        
        #endregion
        
        #region Generic Function
        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }

        public void SubReportDatasource(object source)
        {
            listSubReport = (List<sp_RPT025_InventoryUsageReport_GetData_Sub_Report_Result>)source;
            //rptRPT025_InventoryUsageReport_Sub_Report2.DataSource = source;
        } 
        #endregion

        
        
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Report
{
    public partial class rptRPT033_PartDeliverySheetReport : Base.BaseReport
    {
        #region Constructor

        public rptRPT033_PartDeliverySheetReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }

        public rptRPT033_PartDeliverySheetReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }

        #endregion

        #region Generic Function

        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }

        public void SetSubReportDatasource(object source)
        {
            xrSubreport1.ReportSource.DataSource = source;
        }


        #endregion

        private void xrSubreport1_BeforePrint_1(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            ((rptRPT033_PartDeliverySheet_SubReport) ((XRSubreport) sender).ReportSource).PDSNo.Value = Convert.ToString(GetCurrentColumnValue("PDSNo"));
        }           

    }
}

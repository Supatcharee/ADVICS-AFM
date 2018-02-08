using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using System.Collections.Generic;

namespace Rubix.Screen.Report
{
    public partial class rptRPT010_OutgoingChargeReport : Base.BaseReport
    {
        #region Constructor
        public rptRPT010_OutgoingChargeReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
        }
        public rptRPT010_OutgoingChargeReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
        } 
        #endregion

        #region Generic Function
        public void SubReportDatasource(object source)
        {
            //rptRPT010_OutgoingChargeReport_SubReport1.DataSource = source;
        }
        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val; 
        #endregion
        }
    }
}

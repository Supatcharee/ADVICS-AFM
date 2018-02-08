using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using System.Collections.Generic;
using DevExpress.XtraCharts;

namespace Rubix.Screen.Report
{
    public partial class rptRPT026_InventoryUsageReport_Chart : Base.BaseReport
    {
        #region Member
        
        #endregion

        #region Constructor
        public rptRPT026_InventoryUsageReport_Chart()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }

        public rptRPT026_InventoryUsageReport_Chart(List<ReportDefaultParam> rptParams)
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

        public void SetChartReport(object source)
        {
            xrChart1.DataSource = source;

            xrChart1.Series[0].DataSource = source;

        }
        #endregion




    }
}

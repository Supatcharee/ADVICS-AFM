using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Report
{
    public partial class rptRPT027_SlowMovementReport : Base.BaseReport
    {
        #region Constructor
        public rptRPT027_SlowMovementReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }
        public rptRPT027_SlowMovementReport(List<ReportDefaultParam> rptParams)
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
            bindingSource1.DataSource = source;
        } 
        #endregion
    }
}

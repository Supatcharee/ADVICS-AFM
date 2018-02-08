using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using System.Collections.Generic;

namespace Rubix.Screen.Report
{
    public partial class rptRPT006_UnstaffingChargeReport : Base.BaseReport
    {
        #region Constructor
        public rptRPT006_UnstaffingChargeReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
        }
        public rptRPT006_UnstaffingChargeReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
        } 
        #endregion


        #region Generic Function
        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        } 
        #endregion
    }
}

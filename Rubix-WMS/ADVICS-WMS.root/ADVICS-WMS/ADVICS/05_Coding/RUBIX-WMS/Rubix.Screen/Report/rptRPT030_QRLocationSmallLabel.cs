using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Report
{
    public partial class rptRPT030_QRLocationSmallLabel : Base.BaseReport
    {
        #region Constructor
        public rptRPT030_QRLocationSmallLabel()
        {
            InitializeComponent();
        }
        public rptRPT030_QRLocationSmallLabel(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
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

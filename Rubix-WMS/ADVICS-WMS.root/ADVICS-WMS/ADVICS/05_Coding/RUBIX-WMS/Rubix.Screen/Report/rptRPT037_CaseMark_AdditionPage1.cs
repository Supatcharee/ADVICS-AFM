using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Report
{
    public partial class rptRPT037_CaseMark_AdditionPage1 : Base.BaseReport
    {
        public rptRPT037_CaseMark_AdditionPage1()
        {
            InitializeComponent();
        }

        public rptRPT037_CaseMark_AdditionPage1(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
        }

        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }
    }
}

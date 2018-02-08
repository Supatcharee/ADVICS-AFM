using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Report
{
    public partial class rptRPT037_CaseMark : Base.BaseReport
    {
        public rptRPT037_CaseMark()
        {
            InitializeComponent();
        }

        public rptRPT037_CaseMark(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
        }

        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }

        private void xrLabel8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;

            label.Text = this.GetCurrentColumnValue("Special_Code").ToString().Replace("\\r\\n", Environment.NewLine);
        }

    }
}

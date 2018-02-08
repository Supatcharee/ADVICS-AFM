using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Report
{
    public partial class rptRPT043_PrivilegeFormatReport : Base.BaseReport
    {
        public rptRPT043_PrivilegeFormatReport()
        {
            InitializeComponent();
        }

        public rptRPT043_PrivilegeFormatReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }

        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }

        private void lblFormat1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string code = Convert.ToString(this.GetCurrentColumnValue("PVCode"));
            
                XRLabel lbl = (XRLabel)sender;
                lbl.Visible = code == "FORM-D";
            
        }

        private void xrLabel7_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string code = Convert.ToString(this.GetCurrentColumnValue("PVCode"));

            XRLabel lbl = (XRLabel)sender;
            lbl.Visible = code == "FORM-AI";
        }

        private void xrLabel8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string code = Convert.ToString(this.GetCurrentColumnValue("PVCode"));

            XRLabel lbl = (XRLabel)sender;
            lbl.Visible = code == "TAX-COUPON";
        }

        private void xrLabel10_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string code = Convert.ToString(this.GetCurrentColumnValue("PVCode"));

            XRLabel lbl = (XRLabel)sender;
            lbl.Visible = code == "FORM-XX";
        }


    }
}

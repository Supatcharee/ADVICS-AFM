using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Text;
using CSI.Business.DataObjects;
using DevExpress.XtraReports.UI;

namespace Rubix.Screen.Report
{
    public partial class rptRPT039_DomesticInvoiceReport : Base.BaseReport
    {
        #region Constructor

        public rptRPT039_DomesticInvoiceReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }

        public rptRPT039_DomesticInvoiceReport(List<ReportDefaultParam> rptParams)
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

        #endregion

        private void rptRPT039_DomesticInvoiceReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrCrossBandLine1.Visible = false;
            xrCrossBandLine2.Visible = false;
            xrCrossBandLine3.Visible = false;
            xrCrossBandLine4.Visible = false;
            xrCrossBandLine5.Visible = false;
            xrCrossBandLine6.Visible = false;
            xrLabel3.Visible = false;
            xrLabel1.Visible = false;
            xrLabel2.Visible = false;
            xrPictureBox1.Visible = false;
            xrLabel4.Visible = false;
            xrLabel5.Visible = false;
            xrLabel43.Visible = false;
            xrLabel6.Visible = false;
            lblWMSAddress1.Visible = false;
            xrLabel9.Visible = false;
            xrLabel14.Visible = false;
            xrLabel8.Visible = false;
            xrLabel10.Visible = false;
            xrLabel11.Visible = false;
            xrLabel12.Visible = false;
            xrLabel13.Visible = false;
            xrLabel15.Visible = false;
            xrTableCell1.Visible = false;
            xrTableCell2.Visible = false;
            xrTableCell3.Visible = false;
            xrTableCell4.Visible = false;
            xrTableCell5.Visible = false;
            xrLabel41.Visible = false;
            xrTableCell20.Visible = false;
            xrLabel24.Visible = false;
            xrLabel25.Visible = false;
            xrLabel26.Visible = false;
            xrLabel42.Visible = false;
            xrLabel30.Visible = false;
            xrLabel35.Visible = false;
            xrLabel38.Visible = false;
            xrLabel31.Visible = false;
            xrLabel36.Visible = false;
            xrLabel39.Visible = false;
            xrLabel32.Visible = false;
            xrLabel37.Visible = false;
            xrLabel40.Visible = false;
            xrLabel33.Visible = false;
        }

        private void xrLabel44_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                xrLabel44.Visible = false;
            }
        }

        private void xrLabel27_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                xrLabel27.Visible = false;
            }
        }

        private void xrLabel28_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                xrLabel28.Visible = false;
            }
        }

        private void xrLabel29_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                xrLabel29.Visible = false;
            }
        }

        private void xrLabel45_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                xrLabel45.Visible = false;
            }
        }

    }
}

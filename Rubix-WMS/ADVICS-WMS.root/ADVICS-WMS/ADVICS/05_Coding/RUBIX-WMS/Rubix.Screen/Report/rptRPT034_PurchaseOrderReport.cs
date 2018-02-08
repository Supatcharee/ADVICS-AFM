using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using CSI.Business.DataObjects;
using Rubix.Framework;

namespace Rubix.Screen.Report
{
    public partial class rptRPT034_PurchaseOrderReport : Base.BaseReport
    {
        private decimal m_total = 0;

        public rptRPT034_PurchaseOrderReport( )
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }

        public rptRPT034_PurchaseOrderReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }

        #region Generic Function

        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            m_total += DataUtil.Convert<decimal>(this.GetCurrentColumnValue("Amount")) ?? 0;
        }


        #endregion

        private void GroupFooter1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal vat = DataUtil.Convert<decimal>(this.GetCurrentColumnValue("VAT")) ?? 0;
            lblTotal.Text = m_total.ToString("n2");

            decimal totalVat = m_total * (vat / 100);
            lblTotalVat.Text = totalVat.ToString("n2");

            lblGrandTotal.Text = (m_total + totalVat).ToString("n2");
        }
    }
}

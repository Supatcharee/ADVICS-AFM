using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Text;
using CSI.Business.DataObjects;
using DevExpress.XtraReports.UI;
using Rubix.Framework;

namespace Rubix.Screen.Report
{
    public partial class rptRPT038_ExportInvoiceReport : Base.BaseReport
    {
        #region Constructor

        public rptRPT038_ExportInvoiceReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }

        public rptRPT038_ExportInvoiceReport(List<ReportDefaultParam> rptParams)
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

        private void xrTableCell17_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void calcTextTotalQty_GetValue(object sender, GetValueEventArgs e)
        {
            DataRowView drv = e.Row as DataRowView;
            if (drv != null)
            {
                string text = Convert.ToString(drv["TextTotalQty"]);
                string[] tokens = text.Split(',');

                StringBuilder sb = new StringBuilder();

                foreach (string token in tokens)
                {
                    sb.AppendLine(token.Trim());
                }

                e.Value = sb.ToString();
            }
        }

        private void Detail1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport.GetCurrentColumnValue("CurrencyCode") != null)
            {
                if (DetailReport.GetCurrentColumnValue("CurrencyCode").ToString() == "THB")
                {
                    xrTableCell11.DataBindings["Text"].FormatString = "{0:n2}";
                }
                else
                {
                    xrTableCell11.DataBindings["Text"].FormatString = "{0:n3}";
                }
            }

        }

    }
}

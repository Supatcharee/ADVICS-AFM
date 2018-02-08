using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using System.Collections.Generic;

namespace Rubix.Screen.Report
{
    public partial class rptRPT018_ReceivingInstruction : Base.BaseReport
    {

        #region Constructor
        public rptRPT018_ReceivingInstruction()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);

        }

        public rptRPT018_ReceivingInstruction(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);

        } 
        #endregion

        #region Event Handler Function

        private void xrBarCode2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //xrBarCode2.Text = string.Format("{0}-{1}", xrBarCode1.Text, xrBarCode2.Text);
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {


        }

        private void xrLabel9_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(GetCurrentColumnValue("TruckCompanyLongName").ToString()))
            if (string.IsNullOrEmpty(xrLabel9.Text))
            {
                xrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            }
        }

        private void xrLabel18_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (string.IsNullOrEmpty(xrLabel18.Text))
            {
                xrLabel18.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            }
        }

        private void xrLabel21_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (string.IsNullOrEmpty(xrLabel21.Text))
            {
                xrLabel21.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            }
        }

        private void xrLabel3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (string.IsNullOrEmpty(xrLabel3.Text))
            {
                xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            }
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

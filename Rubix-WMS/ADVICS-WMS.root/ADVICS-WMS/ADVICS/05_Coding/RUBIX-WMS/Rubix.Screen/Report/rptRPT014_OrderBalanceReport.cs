using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Report
{
    public partial class rptRPT014_OrderBalanceReport : Base.BaseReport
    {
        #region Constructor
        public rptRPT014_OrderBalanceReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }
        public rptRPT014_OrderBalanceReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        } 
        #endregion

        #region Event Handler Function
        private void Detail_AfterPrint(object sender, EventArgs e)
        {
            //if (xrTableCellPick.Text == "0.00")
            //{
            //    xrTableCellPick.Text = String.Empty;
            //    xrTableCellShortage.Text = String.Empty;
            //}

            //if (xrTableCellShip.Text == "0.00")
            //{
            //    xrTableCellShip.Text = String.Empty;
            //    xrTableCellUndelivery.Text = String.Empty;
            //}
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (xrTableCellPick.Text == "0.00")
            //{
            //    xrTableCellPick.Text = String.Empty;
            //    xrTableCellShortage.Text = String.Empty;
            //}

            //if (xrTableCellShip.Text == "0.00")
            //{
            //    xrTableCellShip.Text = String.Empty;
            //    xrTableCellUndelivery.Text = String.Empty;
            //}
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

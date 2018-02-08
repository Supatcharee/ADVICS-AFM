using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Report
{
    public partial class rptRPT007_IncomingChargeReport : Base.BaseReport
    {
        #region Member
        int recordNo = 0; 
        #endregion

        #region Constructor
        public rptRPT007_IncomingChargeReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
        }
        public rptRPT007_IncomingChargeReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
            recordNo = 0;
        } 
        #endregion

        #region Event Handler Function
        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }

        private void Detail_AfterPrint(object sender, EventArgs e)
        {
        }

        private void tbcNo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (this.CurrentRowIndex != 0 && GetCurrentColumnValue("PalletNo").ToString() == GetPreviousColumnValue("PalletNo").ToString())
            //{
            //    setCellToEmpty();

            // Comment By Siriwatchara ChargeByPallet is not used 2013-05-15
            /*
            if (GetCurrentColumnValue("ChargeByPallet").ToString() == "1")
            {
                tbcAmount.Text = string.Empty;
                tbcRate.Text = string.Empty;
                tbcRateUOM.Text = string.Empty;
                //tbcRate.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
                //tbcRateUOM.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
                //tbcAmount.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            }
                
            else
            {
                //tbcRate.Borders = tbcRate.Borders | DevExpress.XtraPrinting.BorderSide.Top;
                //tbcRateUOM.Borders = tbcRateUOM.Borders | DevExpress.XtraPrinting.BorderSide.Top;
                //tbcAmount.Borders = tbcAmount.Borders | DevExpress.XtraPrinting.BorderSide.Top;
            }
            //tbcProductCode.Borders = tbcProductCode.Borders | DevExpress.XtraPrinting.BorderSide.Top;
            //tbcProductName.Borders = tbcProductName.Borders | DevExpress.XtraPrinting.BorderSide.Top;
            //tbcQty.Borders = tbcQty.Borders | DevExpress.XtraPrinting.BorderSide.Top;
            //tbcRemark.Borders = tbcRemark.Borders | DevExpress.XtraPrinting.BorderSide.Top;
             *  End Comment */
            //}
            //else
            //{
            tbcNo.Text = (++recordNo).ToString();
            //tbcProductCode.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            //tbcProductName.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            //tbcQty.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            //tbcRemark.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;

            //tbcRate.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            //tbcRateUOM.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            //tbcAmount.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            //}
        }

        private void tbcReceiveDate_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }
        #endregion

        #region Generic Function
        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }
        public void SubReportDatasource(object source)
        {
            // rptRPT007_IncomingChargeReport_SubReport1.DataSource = source;
        }
          private void setCellToEmpty()
        {
            tbcNo.Text = string.Empty;
            tbcReciveDate.Text = string.Empty;
            tbcPalletNo.Text = string.Empty;
            //tbcPalletRef.Text = string.Empty;
            tbcVolumn.Text = string.Empty;


        }
        #endregion

 


    }
}

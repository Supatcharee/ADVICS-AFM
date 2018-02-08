using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using System.Collections.Generic;

namespace Rubix.Screen.Report
{
    public partial class rptRPT008_TransitServiceChargeReport : Base.BaseReport
    {

        #region Member
        public decimal sumBalance = 0;
        public decimal sumAmount = 0;
        public int recordNo = 0;
        #endregion

        #region Constructor
        public rptRPT008_TransitServiceChargeReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
            recordNo = 0;
        }
        public rptRPT008_TransitServiceChargeReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
        } 
        #endregion

        #region Event Handler Function
        private void xrTableCell6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }
        private void xrTableCell5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (this.CurrentRowIndex != 0 && GetCurrentColumnValue("PalletNo").ToString() == GetPreviousColumnValue("PalletNo").ToString())
            //{
            //    setCellToEmpty();

            //    if (GetCurrentColumnValue("ChargeByPallet").ToString() == "1")
            //    {
            //        tbcAmount.Text = string.Empty;
            //        tbcRate.Text = string.Empty;
            //        tbcRateUOM.Text = string.Empty;
            //        //tbcRate.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            //        //tbcRateUOM.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            //        //tbcAmount.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            //    }
            //    else
            //    {
            //        //tbcRate.Borders = tbcRate.Borders | DevExpress.XtraPrinting.BorderSide.Top;
            //        //tbcRateUOM.Borders = tbcRateUOM.Borders | DevExpress.XtraPrinting.BorderSide.Top;
            //        //tbcAmount.Borders = tbcAmount.Borders | DevExpress.XtraPrinting.BorderSide.Top;
            //    }
            //    //tbcProduct.Borders = tbcProduct.Borders | DevExpress.XtraPrinting.BorderSide.Top;
            //    //tbcLotNo.Borders = tbcLotNo.Borders | DevExpress.XtraPrinting.BorderSide.Top;
            //    //tbcBalance.Borders = tbcBalance.Borders | DevExpress.XtraPrinting.BorderSide.Top;
            //    //tbcShippingDate.Borders = tbcShippingDate.Borders | DevExpress.XtraPrinting.BorderSide.Top;
            //}
            //else
            //{
            tbcNo.Text = (++recordNo).ToString();
            //tbcProduct.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            //tbcLotNo.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            //tbcBalance.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            //tbcShippingDate.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;

            //tbcRate.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            //tbcRateUOM.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            //tbcAmount.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            //}
        }

        private void Detail_AfterPrint(object sender, EventArgs e)
        {
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        } 
        #endregion

        #region generate
        private void setCellToEmpty()
        {
            tbcNo.Text = string.Empty;
            tbcReceiveDate.Text = string.Empty;

            //tbcPalletRef.Text = string.Empty;
            //tbcPalletNo.Text = string.Empty;
            tbcZVolume.Text = string.Empty;
            tbcStockDay.Text = string.Empty;


        }
        private void ResetBorder()
        {
            tbcReceiveDate.Borders = DevExpress.XtraPrinting.BorderSide.None;
            //tbcPalletNo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            //tbcPalletNo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            tbcZVolume.Borders = DevExpress.XtraPrinting.BorderSide.None;
            tbcLotNo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            tbcShippingDate.Borders = DevExpress.XtraPrinting.BorderSide.None;
            tbcRate.Borders = DevExpress.XtraPrinting.BorderSide.None;
            tbcRateUOM.Borders = DevExpress.XtraPrinting.BorderSide.None;
            tbcStockDay.Borders = DevExpress.XtraPrinting.BorderSide.None;
            tbcAmount.Borders = DevExpress.XtraPrinting.BorderSide.None;//NO
        }
        private void setBorderRight()
        {
            tbcReceiveDate.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            //tbcPalletNo.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            tbcZVolume.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            tbcLotNo.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            tbcShippingDate.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            tbcRate.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            tbcRateUOM.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            tbcStockDay.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            tbcAmount.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;//NO\
        }
        private void setBorderTopRight()
        {
            tbcReceiveDate.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;
            //tbcPalletNo.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;
            tbcZVolume.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;
            tbcLotNo.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;
            tbcShippingDate.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;
            tbcRate.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;
            tbcRateUOM.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;
            tbcStockDay.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;
            tbcAmount.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;//NO\
        }
        public void SubReportDatasource(object source)
        {

            //rptRPT008_TransitServiceChargeReport_SubReport1.DataSource = source;

        }
        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }
        #endregion
    }
}

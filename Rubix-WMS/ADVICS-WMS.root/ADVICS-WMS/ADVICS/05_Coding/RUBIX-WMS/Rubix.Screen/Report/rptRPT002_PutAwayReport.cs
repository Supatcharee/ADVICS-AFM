using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using System.Collections.Generic;

namespace Rubix.Screen.Report
{
    public partial class rptRPT002_PutAwayReport : Base.BaseReport
    {
        #region Member
        int CurrentRecordOnPage = 1; //บอกว่าตอนนี้เป็นการ print record ที่เท่าไหร่ของหน้านั้นๆ
        int RecordPerPage = 16; 
        #endregion

        #region Constructor

        public rptRPT002_PutAwayReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }
        public rptRPT002_PutAwayReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        } 
        #endregion

        #region Event Handler Function

        private void xrTableCell17_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xtcLot.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;

            if (this.CurrentRowIndex != 0 //&& GetCurrentColumnValue("PalletNo").ToString() == GetPreviousColumnValue("PalletNo").ToString()
                 && GetCurrentColumnValue("ReceivingNo").ToString() == GetPreviousColumnValue("ReceivingNo").ToString()
                 && GetCurrentColumnValue("TransitDate").ToString() == GetPreviousColumnValue("TransitDate").ToString()
                 && GetCurrentColumnValue("ProductCode").ToString() == GetPreviousColumnValue("ProductCode").ToString()
                 && GetCurrentColumnValue("OwnerName").ToString() == GetPreviousColumnValue("OwnerName").ToString()
                 && GetCurrentColumnValue("DetailRemark").ToString() == GetPreviousColumnValue("DetailRemark").ToString()
                 && GetCurrentColumnValue("LotNo").ToString() == GetPreviousColumnValue("LotNo").ToString())
            {
                setCellToEmpty();
                if (GetCurrentColumnValue("LocationCode").ToString() != GetPreviousColumnValue("LocationCode").ToString())
                {
                    xtcLot.Borders = xtcLot.Borders | DevExpress.XtraPrinting.BorderSide.Top;
                }
                else
                {
                    xtcLot.Text = string.Empty;
                }
                xtcStockActual.Borders = xtcStockActual.Borders | DevExpress.XtraPrinting.BorderSide.Top;
                xtcUOM.Borders = xtcUOM.Borders | DevExpress.XtraPrinting.BorderSide.Top;
                xtcQty.Borders = xtcQty.Borders | DevExpress.XtraPrinting.BorderSide.Top;
            }
            else
            {
                xtcStockActual.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
                xtcUOM.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
                xtcQty.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
            }

        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.CurrentRowIndex + 1 <= RecordPerPage)
            {
                // last record of first page
                if (((CurrentRecordOnPage) % RecordPerPage == 0))
                {
                    Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
                    CurrentRecordOnPage = 0;
                    //LastRecordInPage = true;
                }
                else
                {
                    Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
                    //LastRecordInPage = false;
                }
            }
            else
            {
                // last record of  page
                if (((CurrentRecordOnPage) % RecordPerPage == 0))
                {
                    Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
                    CurrentRecordOnPage = 0;
                    //LastRecordInPage = true;
                }
                else
                {
                    Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
                    //LastRecordInPage = false;
                }
            }
            CurrentRecordOnPage++;
        }
        
        #endregion

        #region Generic Function
        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }
        private void setCellToEmpty()
        {
            xrTableCell17.Text = string.Empty;
            xrTableCell18.Text = string.Empty;
            xrTableCell25.Text = string.Empty;
            xrTableCell28.Text = string.Empty;
            xrTableCell29.Text = string.Empty;
            xrTableCell30.Text = string.Empty;
            xrTableCell31.Text = string.Empty;
            //xrTableCell32.Text = string.Empty;
            //xtcLot.Text = string.Empty;
            xrTableCell36.Text = string.Empty;
            xrTableTransitUser.Text = string.Empty;
        }
        #endregion
    }
}

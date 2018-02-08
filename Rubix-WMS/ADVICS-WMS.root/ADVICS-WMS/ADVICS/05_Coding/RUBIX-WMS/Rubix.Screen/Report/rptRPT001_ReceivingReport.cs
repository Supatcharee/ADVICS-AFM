using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using System.Collections.Generic;

namespace Rubix.Screen.Report
{
    public partial class rptRPT001_ReceivingReport : Base.BaseReport
    {
        #region Member
        int RealRowIndex = 0; // ใช้เป็นข้อมูลใน column no
        int CurrentRecordOnPage = 1; //บอกว่าตอนนี้เป็นการ print record ที่เท่าไหร่ของหน้านั้นๆ
        int RecordPerPage = 15;
        int RecordPerPage2 = 18;
        bool LastRecordInPage = false; 
        #endregion

        #region Constructor
        public rptRPT001_ReceivingReport()
        {
            InitializeComponent();
            SetFormatStringToControl();
            SetImageLogoReport(xrPictureBox2);
        }

        public rptRPT001_ReceivingReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetFormatStringToControl();
            SetImageLogoReport(xrPictureBox2);
        }
        
        #endregion

        #region Event Handler Function
        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //// page break
            //if (this.CurrentRowIndex + 1 <= RecordPerPage)
            //{
            //    // last record of first page
            //    if (((CurrentRecordOnPage) % RecordPerPage == 0))
            //    {
            //        Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            //        CurrentRecordOnPage = 0;
            //        LastRecordInPage = true;
            //    }
            //    else
            //    {
            //        Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
            //        LastRecordInPage = false;
            //    }
            //}
            //else
            //{
            //    // last record of  page
            //    if (((CurrentRecordOnPage) % RecordPerPage2 == 0))
            //    {
            //        Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            //        CurrentRecordOnPage = 0;
            //        LastRecordInPage = true;
            //    }
            //    else
            //    {
            //        Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
            //        LastRecordInPage = false;
            //    }
            //}
            //CurrentRecordOnPage++;
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.RealRowIndex = 0;
        }

        private void xrTableCellNo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRTableCell[] cells = new XRTableCell[] { xrTableCellNo, xrTableCellCondition, xrTableCellLotNo, 
                xrTableCellPalletRef, xrTableCellProductCode, xrTableCellDescription, xrTableCellM3, xrTableCellDetailRemark};

            if (this.CurrentRowIndex != 0
                    && Convert.ToInt32(GetCurrentColumnValue("LineNo")) == Convert.ToInt32(GetPreviousColumnValue("LineNo"))
                   )
            {
                xrTableCellNo.Text = string.Empty;
            }
            else
            {
                RealRowIndex++;
                xrTableCellNo.Text = RealRowIndex.ToString();
            }

            //if (this.CurrentRowIndex != 0
            //    && Convert.ToInt32(GetCurrentColumnValue("LineNo")) == Convert.ToInt32(GetPreviousColumnValue("LineNo"))
            //   )
            //{
            //    for (int i = 0; i < cells.Length; i++)
            //    {
            //        cells[i].Text = string.Empty;
            //    }
            //    xrTableCellQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //        | DevExpress.XtraPrinting.BorderSide.Right
            //        | DevExpress.XtraPrinting.BorderSide.Top;
            //    xrTableCellUOM.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //        | DevExpress.XtraPrinting.BorderSide.Right
            //        | DevExpress.XtraPrinting.BorderSide.Top;
            //}
            //else
            //{
            //    xrTableCellQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //        | DevExpress.XtraPrinting.BorderSide.Right;
            //    xrTableCellUOM.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //        | DevExpress.XtraPrinting.BorderSide.Right;
            //}
        }
        #endregion

        #region Generic Function
        private void SetFormatStringToControl()
        {
            xrLabel67.XlsxFormatString = Common.FullDateFormat;
            xrTableCellPalletRef.XlsxFormatString = Common.FullDateFormat;
        }

        public void SetSubReport(object val)
        {
            //this.rptRPT001_ReceivingReport_SubReport1.DataSource = val;
        }

        public void SetTotalRecord(object val)
        {
            this.TotalRecord.Value = val;
        }

        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        } 
        #endregion



    }
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using System.Collections.Generic;

namespace Rubix.Screen.Report
{
    public partial class rptRPT017_InventoryCheckListByZoneReport : Base.BaseReport
    {
        #region Member
        int No = 1;
        int recordCount = 0;
        bool newPage = true;
        const int RecPerPage = 26;
        const int RecPerPage2 = 29;
        int CurrentRecordOnPage = 1; //บอกว่าตอนนี้เป็นการ print record ที่เท่าไหร่ของหน้านั้นๆ
        #endregion

        #region Constructor
        public rptRPT017_InventoryCheckListByZoneReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }

        public rptRPT017_InventoryCheckListByZoneReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        } 
        #endregion

        #region Event Handler Function

        private void xrTableCell5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //check duplicate
            if (this.CurrentRowIndex != 0
                    && Convert.ToString(GetCurrentColumnValue("LocationCode")) == Convert.ToString(GetPreviousColumnValue("LocationCode"))
                    && Convert.ToString(GetCurrentColumnValue("ProductCode")) == Convert.ToString(GetPreviousColumnValue("ProductCode"))
                    && Convert.ToString(GetCurrentColumnValue("Description")) == Convert.ToString(GetPreviousColumnValue("Description"))
                    && Convert.ToString(GetCurrentColumnValue("ProductConditionName")) == Convert.ToString(GetPreviousColumnValue("ProductConditionName"))
                    && Convert.ToString(GetCurrentColumnValue("LotNo")) == Convert.ToString(GetPreviousColumnValue("LotNo"))

                )
            {
                SetBorder();
                setCellToEmpty();
                if (this.CurrentRecordOnPage != 1)
                {
                    xrTableCell30.Borders = xrTableCell30.Borders | DevExpress.XtraPrinting.BorderSide.Top;
                    xrTableCell16.Borders = xrTableCell16.Borders | DevExpress.XtraPrinting.BorderSide.Top;
                }
            }
            else
            {
                xrTableCell5.Text = Convert.ToString(No);
                No++;
                if (this.CurrentRowIndex == 0)
                {
                    SetBorder();
                }
                else if (Convert.ToString(GetCurrentColumnValue("LocationCode")) != Convert.ToString(GetPreviousColumnValue("LocationCode"))
                    || Convert.ToString(GetCurrentColumnValue("ProductCode")) != Convert.ToString(GetPreviousColumnValue("ProductCode"))
                    || Convert.ToString(GetCurrentColumnValue("Description")) != Convert.ToString(GetPreviousColumnValue("Description"))
                    || Convert.ToString(GetCurrentColumnValue("ProductConditionName")) != Convert.ToString(GetPreviousColumnValue("ProductConditionName"))
                    || Convert.ToString(GetCurrentColumnValue("LotNo")) != Convert.ToString(GetPreviousColumnValue("LotNo"))
                    )
                {

                    SetBorderTop();
                }


            }
            if (((CurrentRecordOnPage) % RecPerPage == 1))
            {
                SetLastRecOnPageBordor();
            }
            if (CurrentRecordOnPage == 2)
            {
                SetBorder();
            }
            //if (CurrentRowIndex != 0 && CurrentRowIndex == RecPerPage)
            //{
            //    xrTableCell7.Borders = xrTableCell7.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    xrTableCell8.Borders = xrTableCell8.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    xrTableCell29.Borders = xrTableCell29.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    xrTableCell11.Borders = xrTableCell11.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    xrTableCell14.Borders = xrTableCell14.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;


            //    xrTableCell17.Borders = xrTableCell17.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    xrTableCell30.Borders = xrTableCell30.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    xrTableCell16.Borders = xrTableCell16.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    xrTableCell5.Borders = xrTableCell5.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            //}
            //else if (CurrentRowIndex != 0 && CurrentRowIndex != RecPerPage2 && CurrentRowIndex % RecPerPage2 == 26)
            //{
            //    xrTableCell7.Borders = xrTableCell7.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    xrTableCell8.Borders = xrTableCell8.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    xrTableCell29.Borders = xrTableCell29.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    xrTableCell11.Borders = xrTableCell11.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    xrTableCell14.Borders = xrTableCell14.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;

            //    //xrTableCell26.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            //    xrTableCell17.Borders = xrTableCell17.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    xrTableCell30.Borders = xrTableCell30.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    xrTableCell16.Borders = xrTableCell16.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    xrTableCell5.Borders = xrTableCell5.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            //}

        }


        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.CurrentRowIndex + 1 <= RecPerPage)
            {
                // last record of first page
                if (((CurrentRecordOnPage) % RecPerPage == 0))
                {
                    Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
                    CurrentRecordOnPage = 0;
                    newPage = true;
                }
                else
                {
                    Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
                    newPage = false;
                }
            }
            else
            {
                // last record of  page
                if (((CurrentRecordOnPage) % RecPerPage == 0))
                {
                    Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
                    CurrentRecordOnPage = 0;
                    newPage = true;
                }
                else
                {
                    Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
                    newPage = false;
                }
            }
            CurrentRecordOnPage++;
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        } 
        #endregion
    
        #region generate
        private void setCellToEmpty()
        {
            xrTableCell5.Text = string.Empty;
            xrTableCell7.Text = string.Empty;
            xrTableCell8.Text = string.Empty;
            xrTableCell29.Text = string.Empty;
            xrTableCell11.Text = string.Empty;
            xrTableCell14.Text = string.Empty;
        }
        private void SetBorder()
        {
            xrTableCell7.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            xrTableCell8.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            xrTableCell29.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            xrTableCell11.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            xrTableCell14.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            xrTableCell30.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            xrTableCell16.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            xrTableCell5.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
        }
        private void SetLastRecOnPageBordor()
        {
            xrTableCell7.Borders = xrTableCell7.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            xrTableCell8.Borders = xrTableCell8.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            xrTableCell29.Borders = xrTableCell29.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            xrTableCell11.Borders = xrTableCell11.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            xrTableCell14.Borders = xrTableCell14.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
            xrTableCell30.Borders = xrTableCell30.Borders | DevExpress.XtraPrinting.BorderSide.Bottom | DevExpress.XtraPrinting.BorderSide.Top;
            xrTableCell16.Borders = xrTableCell16.Borders | DevExpress.XtraPrinting.BorderSide.Bottom | DevExpress.XtraPrinting.BorderSide.Top;
            xrTableCell5.Borders = xrTableCell5.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
        }
        private void SetBoderFirstRecOnPage()
        {
            xrTableCell7.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
            xrTableCell8.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
            xrTableCell29.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
            xrTableCell11.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
            xrTableCell14.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
            xrTableCell30.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
            xrTableCell16.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
            xrTableCell5.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
        }
        private void SetBorderTop()
        {
            xrTableCell7.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;
            xrTableCell8.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;
            xrTableCell29.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;
            xrTableCell11.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;
            xrTableCell14.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;
            xrTableCell30.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;
            xrTableCell16.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;
            xrTableCell5.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;
        }
      
        public void SubReportDatasource(object source)
        {
            rptRPT017_InventoryCheckListByZoneReport_SubReport1.DataSource = source;

        }
        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }  
        #endregion
    
    
    }
}

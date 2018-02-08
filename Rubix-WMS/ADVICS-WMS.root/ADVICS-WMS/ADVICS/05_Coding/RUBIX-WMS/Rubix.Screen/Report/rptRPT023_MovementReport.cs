/*
 * 21 Jan 2013:
 * 1. Hide Pallet no ref when duplicate
 */
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using System.Collections.Generic;

namespace Rubix.Screen.Report
{
    public partial class rptRPT023_MovementReport : Base.BaseReport
    {
        #region Member
        int recordCount = 1;
        bool chkfirstPage = true;
        
        #endregion
        
        #region Constructor
        public rptRPT023_MovementReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        } 
        public rptRPT023_MovementReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }
       #endregion

        #region Event Handler Function
        private void xrTableCell22_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            //xrTableCell22.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
            //xrTableCell23.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            //xrTableCell24.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            //xrTableCell30.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            ////xrTableCell31.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            //xrTableCell25.Borders = DevExpress.XtraPrinting.BorderSide.Right;
            ////xrTableCell34.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;//stock day
            //xrTableCell35.Borders = DevExpress.XtraPrinting.BorderSide.Right;//remark
            if (this.CurrentRowIndex != 0
                    && Convert.ToDateTime(GetPreviousColumnValue("TransactionDate")) == Convert.ToDateTime(GetCurrentColumnValue("TransactionDate"))
                    && Convert.ToString(GetPreviousColumnValue("ProductCode")) == Convert.ToString(GetCurrentColumnValue("ProductCode"))
                    && Convert.ToString(GetPreviousColumnValue("LocationCode")) == Convert.ToString(GetCurrentColumnValue("LocationCode"))
                    && Convert.ToString(GetPreviousColumnValue("LotNo")) == Convert.ToString(GetCurrentColumnValue("LotNo"))
                //&& Convert.ToString(GetPreviousColumnValue("PalletNo")) == Convert.ToString(GetCurrentColumnValue("PalletNo"))
                )
            {
                setCellToEmpty();

                xrTableCell26.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;
                xrTableCell32.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
                xrTableCell36.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
                xrTableCell28.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
                xrTableCell29.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;

            }
            else
            {
                xrTableCell26.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
                xrTableCell32.Borders = DevExpress.XtraPrinting.BorderSide.Right;
                xrTableCell36.Borders = DevExpress.XtraPrinting.BorderSide.Right;
                xrTableCell28.Borders = DevExpress.XtraPrinting.BorderSide.Right;
                xrTableCell29.Borders = DevExpress.XtraPrinting.BorderSide.Right;
                //if (this.CurrentRowIndex != 0)
                //{
                //    xrTableCell6.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
                //    xrTableCell23.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
                //    xrTableCell24.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
                //    xrTableCell30.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
                //    xrTableCell25.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
                //    xrTableCell22.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Left;
                //}
            }
        } 
        #endregion
        
        #region generate
        private void setCellToEmpty()
        {
            xrTableCell6.Text = string.Empty;
            xrTableCell23.Text = string.Empty;
            xrTableCell24.Text = string.Empty;
            xrTableCell30.Text = string.Empty;
            //xrTableCell31.Text = string.Empty;
            xrTableCell25.Text = string.Empty;
            // 21 Jan 2013: uncomment this line
            //xrTableCell34.Text = string.Empty;
            //xrTableCell34.Text = string.Empty;
            // end 21 Jan 2013: uncomment this line
            xrTableCell22.Text = string.Empty;

        }
        //private void ResetBorder()
        //{
        //    xrTableCell22.Borders = DevExpress.XtraPrinting.BorderSide.None;
        //    xrTableCell23.Borders = DevExpress.XtraPrinting.BorderSide.None;
        //    xrTableCell24.Borders = DevExpress.XtraPrinting.BorderSide.None;
        //    xrTableCell30.Borders = DevExpress.XtraPrinting.BorderSide.None;
        //    //xrTableCell31.Borders = DevExpress.XtraPrinting.BorderSide.None;
        //    xrTableCell25.Borders = DevExpress.XtraPrinting.BorderSide.None;
        //    //xrTableCell34.Borders = DevExpress.XtraPrinting.BorderSide.None;
        //    xrTableCell35.Borders = DevExpress.XtraPrinting.BorderSide.None;

        //    xrTableCell26.Borders = DevExpress.XtraPrinting.BorderSide.None;
        //    xrTableCell32.Borders = DevExpress.XtraPrinting.BorderSide.None;
        //    xrTableCell36.Borders = DevExpress.XtraPrinting.BorderSide.None;
        //    xrTableCell28.Borders = DevExpress.XtraPrinting.BorderSide.None;
        //    xrTableCell29.Borders = DevExpress.XtraPrinting.BorderSide.None;
        //}
        //private void setBorderRight()
        //{
        //    xrTableCell22.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell23.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell24.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell30.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    //xrTableCell31.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell25.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    //xrTableCell34.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;//stock day
        //    xrTableCell35.Borders = DevExpress.XtraPrinting.BorderSide.Right;//remark

        //    xrTableCell26.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top;
        //    xrTableCell32.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
        //    xrTableCell36.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
        //    xrTableCell28.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
        //    xrTableCell29.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
        //}
        //private void setBorderRightFirstRow()
        //{
        //    xrTableCell22.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell23.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell24.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell30.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    //xrTableCell31.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell25.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    //xrTableCell34.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;//stock day
        //    xrTableCell35.Borders = DevExpress.XtraPrinting.BorderSide.Right;//remark

        //    xrTableCell26.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left;
        //    xrTableCell32.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell36.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell28.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell29.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //}
        //private void setBorderRightLastRow()
        //{
        //    xrTableCell22.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    xrTableCell23.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    xrTableCell24.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    xrTableCell30.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    //xrTableCell31.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    xrTableCell25.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    //xrTableCell34.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom;//stock day
        //    xrTableCell35.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom;//remark

        //    xrTableCell26.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    xrTableCell32.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    xrTableCell36.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    xrTableCell28.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    xrTableCell29.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
        //}
        //private void setBorderTopAndRight()
        //{
        //    xrTableCell22.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
        //    xrTableCell23.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
        //    xrTableCell24.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
        //    xrTableCell30.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
        //    //xrTableCell31.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
        //    xrTableCell25.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
        //    //xrTableCell34.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;//stock day
        //    xrTableCell35.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;//remark

        //    xrTableCell26.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
        //    xrTableCell32.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
        //    xrTableCell36.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
        //    xrTableCell28.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
        //    xrTableCell29.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top;
        //}
        //private void setBorderTopAndRightFirstRow()
        //{
        //    xrTableCell22.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell23.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell24.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell30.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    //xrTableCell31.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell25.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    //xrTableCell34.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;//stock day
        //    xrTableCell35.Borders = DevExpress.XtraPrinting.BorderSide.Right;//remark

        //    xrTableCell26.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell32.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell36.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell28.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //    xrTableCell29.Borders = DevExpress.XtraPrinting.BorderSide.Right;
        //}
        //private void setBorderTopAndRightLastRow()
        //{
        //    xrTableCell22.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    xrTableCell23.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    xrTableCell24.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    xrTableCell30.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    //xrTableCell31.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    xrTableCell25.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    //xrTableCell34.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;//stock day
        //    xrTableCell35.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;//remark

        //    xrTableCell26.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    xrTableCell32.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    xrTableCell36.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    xrTableCell28.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
        //    xrTableCell29.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
        //}
     
        public void SubReportDatasource(object source)
        {
            //rptRPT023_MovementReport_SubReport1.DataSource = source;

        }

       
        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }
#endregion

    }
}

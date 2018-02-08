using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Report
{
    public partial class rptRPT012_EstimatePriceReport : Base.BaseReport // DevExpress.XtraReports.UI.XtraReport
    {
        #region Member
        int CurrentRecordOnPage = 1; //บอกว่าตอนนี้เป็นการ print record ที่เท่าไหร่ของหน้านั้นๆ
        int RecordPerPage = 33;
        int RecordPerPage2 = 37;

        bool LastRecordInPage = false;  
        #endregion

        #region Constructor
        public rptRPT012_EstimatePriceReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }

        public rptRPT012_EstimatePriceReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }

        
        #endregion

        #region Event Handler Function
        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.CurrentRowIndex + 1 <= RecordPerPage)
            {
                // last record of first page
                if (((CurrentRecordOnPage) % RecordPerPage == 0))
                {
                    Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
                    CurrentRecordOnPage = 0;
                    LastRecordInPage = true;
                }
                else
                {
                    Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
                    LastRecordInPage = false;
                }
            }
            else
            {
                // last record of  page
                if (((CurrentRecordOnPage) % RecordPerPage == 0))
                {
                    Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
                    CurrentRecordOnPage = 0;
                    LastRecordInPage = true;
                }
                else
                {
                    Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
                    LastRecordInPage = false;
                }
            }
            CurrentRecordOnPage++;
        } 
        #endregion

        #region Generic Function
        public void SetWarehouseName(object value)
        {
            this.Parameters["WarehouseName"].Value = value;
        }

        public void SetFromDateParameter(object value)
        {
            this.Parameters["FromDate"].Value = value;
        }

        public void SetToDateParameter(object value)
        {
            this.Parameters["ToDate"].Value = value;
        }

        public void SetUserNameParameter(object val)
        {
            this.Parameters["UserName"].Value = val;
        }

        public void SetOwnerNameParameter(object val)
        {
            this.Parameters["OwnerName"].Value = val;
        }
        #endregion
    }
}

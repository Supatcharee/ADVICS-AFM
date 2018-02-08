using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using System.Collections.Generic;

namespace Rubix.Screen.Report
{
    public partial class rptRPT011_TransportationChargeReport : Base.BaseReport
    {
        #region Member
        int CurrentRecordOnPage = 1; //บอกว่าตอนนี้เป็นการ print record ที่เท่าไหร่ของหน้านั้นๆ
        int RecordPerPage = 30;
        int RecordPerPage2 = 35;

        bool LastRecordInPage = false;  
        #endregion

        #region Constructormm
        public rptRPT011_TransportationChargeReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
        }
        public rptRPT011_TransportationChargeReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
        } 
        #endregion

        #region Event Handler Function
        private void GroupFooter1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (GetCurrentColumnValue("WarehouseCode") == null)
                e.Cancel = true;

        }

        private void xrTableCell5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            if (this.CurrentRowIndex != 0
                && Convert.ToDateTime(GetCurrentColumnValue("TransportationDate")) == Convert.ToDateTime(GetPreviousColumnValue("TransportationDate"))
                && GetCurrentColumnValue("WarehouseCode").ToString().Equals(GetPreviousColumnValue("WarehouseCode").ToString())
                && GetCurrentColumnValue("FinalDestinationLongName").ToString().Equals(GetPreviousColumnValue("FinalDestinationLongName").ToString())
                && GetCurrentColumnValue("TransportTypeName").ToString().Equals(GetPreviousColumnValue("TransportTypeName").ToString())

                )
            {
                xrTableCell5.Text = string.Empty;
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
                if (((CurrentRecordOnPage) % RecordPerPage2 == 0))
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
        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        } 
        #endregion
    }
}

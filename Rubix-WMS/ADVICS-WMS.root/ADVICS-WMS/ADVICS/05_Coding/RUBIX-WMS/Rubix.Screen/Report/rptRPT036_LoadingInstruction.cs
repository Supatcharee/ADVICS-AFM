using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using CSI.Business.DataObjects;
using DevExpress.XtraReports.UI;

namespace Rubix.Screen.Report
{
    public partial class rptRPT036_LoadingInstruction : Base.BaseReport
    {
        #region Variables

        private const string COL_UNITLEVEL2 = "UnitLevel2";
        private const string COL_UNITLEVEL3 = "UnitLevel3";



        private string m_strUnitLevel3 = "";
        private string m_strUnitLevel2 = "";

        #endregion


        #region Constructor

        public rptRPT036_LoadingInstruction()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }

        public rptRPT036_LoadingInstruction(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }

        #endregion

        #region Generic Function

        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }
        
        #endregion

        #region Custom Summary Min: UnitLevel3

        private void cellSumUnitLevel3_SummaryReset(object sender, EventArgs e)
        {
            m_strUnitLevel3 = "";
        }

        private void cellSumUnitLevel3_SummaryRowChanged(object sender, EventArgs e)
        {
            string valUnit = Convert.ToString(this.GetCurrentColumnValue(COL_UNITLEVEL3));
            if (string.IsNullOrEmpty(valUnit))
                return;

            if (string.IsNullOrEmpty(m_strUnitLevel3))
                m_strUnitLevel3 = valUnit;

            else if (String.Compare(valUnit, m_strUnitLevel3, StringComparison.Ordinal) < 0)
            {
                m_strUnitLevel3 = valUnit;
            }

        }

        private void cellSumUnitLevel3_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = m_strUnitLevel3;
            e.Handled = true;
        }       

        #endregion

        #region Custom Summary Min: UnitLevel2

        private void cellSumUnitLevel2_SummaryReset(object sender, EventArgs e)
        {
            m_strUnitLevel2 = "";
        }

        private void cellSumUnitLevel2_SummaryRowChanged(object sender, EventArgs e)
        {
            string valUnit = Convert.ToString(this.GetCurrentColumnValue(COL_UNITLEVEL2));
            if (string.IsNullOrEmpty(valUnit))
                return;

            if (string.IsNullOrEmpty(m_strUnitLevel2))
                m_strUnitLevel2 = valUnit;

            else if (String.Compare(valUnit, m_strUnitLevel2, StringComparison.Ordinal) < 0)
            {
                m_strUnitLevel2 = valUnit;
            }
        }

        private void cellSumUnitLevel2_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            e.Result = m_strUnitLevel2;
            e.Handled = true;
        }

        #endregion

        private void xrTableCell35_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                xrTableCell35.Visible = false;
            }
        }

        private void xrTableCell51_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                xrTableCell51.Visible = false;
            }
        }

        private void xrTableCell39_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                xrTableCell39.Visible = false;
            }
        }

        private void cellSumUnitLevel3_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                cellSumUnitLevel3.Visible = false;
            }
        }

        private void xrTableCell56_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                xrTableCell56.Visible = false;
            }
        }

        private void cellSumUnitLevel2_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                cellSumUnitLevel2.Visible = false;
            }
        }

        private void xrTableCell40_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                xrTableCell40.Visible = false;
            }
        }

        private void xrLine3_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 == e.PageIndex)
            {
                xrLine3.Visible = false;
            }
        }

        private void xrLine4_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 == e.PageIndex)
            {
                xrLine4.Visible = false;
            }
        }

        private void xrLine5_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 == e.PageIndex)
            {
                xrLine5.Visible = false;
            }
        }

              
    }
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Report
{
    public partial class rptRPT015_StockCardReport : Base.BaseReport
    {
        #region Member
        Decimal m_AccumalateBalance;
        Decimal packingSumGroup, packingSumReport;

        #endregion

        #region Constructor
        public rptRPT015_StockCardReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
            m_AccumalateBalance = 0;
            packingSumGroup = 0;
            packingSumReport = 0;
        }
        public rptRPT015_StockCardReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
            m_AccumalateBalance = 0;
            packingSumGroup = 0;
            packingSumReport = 0;
        } 
        #endregion

        #region Event Handler Function
        private void xrLabelBalance_AfterPrint(object sender, EventArgs e)
        {
            
        }


        private void xrTableCell15_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //comment test store ใหม่ 
            //if (xrLabelBalance.Text != String.Empty)
            //{
            //    //Decimal balance = Convert.ToDecimal(xrLabelBalance.Text);
            //    Decimal balance = m_AccumalateBalance;
            //    Decimal numberOfLevel = Convert.ToDecimal(lbNumberOfLevel.Text);
            //    Decimal packing = balance / numberOfLevel;
            //    xrTableCell15.Text = packing.ToString(Common.QtyReportFormat);
            //    packingSumReport += packing;
            //    packingSumGroup += packing;
            //}
        }

        private void xrTableCellPackingGroup_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (packingSumGroup != 0)
            //{
            //    xrTableCellPackingGroup.Text = packingSumGroup.ToString(Common.QtyReportFormat);
            //}
            //decimal balance = m_AccumalateBalance / Convert.ToDecimal(lbNumberOfLevel.Text);
            //xrTableCellPackingGroup.Text = balance.ToString(Common.QtyReportFormat);
        }

        private void xrTableCellPackingReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrTableCell22_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //decimal balance = m_AccumalateBalance / Convert.ToDecimal(lbNumberOfLevel.Text);
            //xrTableCell22.Text = balance.ToString(Common.QtyReportFormat);
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

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.GetCurrentColumnValue("PDSNo").ToString().Equals("Previous Balance"))
            {
                e.Cancel = true;
            }
        }

        private void xrTableCellBalance_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string sto_in = this.GetCurrentColumnValue("Stock_In").ToString();
            string sto_out = this.GetCurrentColumnValue("Stock_Out").ToString();
            if (!string.IsNullOrEmpty(sto_in) && !string.IsNullOrEmpty(sto_out))
            {
                Decimal dBalanceRow = Convert.ToDecimal(sto_in) - Convert.ToDecimal(sto_out);
                m_AccumalateBalance = m_AccumalateBalance + dBalanceRow;
                xrTableCellBalance.XlsxFormatString = "#,##0.00";
                xrTableCellBalance.Text = m_AccumalateBalance.ToString(Common.QtyReportFormat);
            }
        }

        private void xrTableCell33_AfterPrint(object sender, EventArgs e)
        {
            string Balance = this.GetCurrentColumnValue("Balance").ToString();
            if (!string.IsNullOrEmpty(Balance))
            {
                Decimal dBalanceRow = Convert.ToDecimal(Balance);
                m_AccumalateBalance = m_AccumalateBalance + dBalanceRow;
            }
        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            m_AccumalateBalance = 0;
        }

    }
}

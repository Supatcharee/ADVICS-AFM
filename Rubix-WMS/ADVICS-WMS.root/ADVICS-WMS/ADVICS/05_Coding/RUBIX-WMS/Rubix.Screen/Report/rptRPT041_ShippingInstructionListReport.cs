using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using CSI.Business.DataObjects;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace Rubix.Screen.Report
{
    public partial class rptRPT041_ShippingInstructionListReport : Base.BaseReport
    {
        int RowIndex = 0;
        int ColumnIndex = 0;

        #region Constructor

        public rptRPT041_ShippingInstructionListReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }

        public rptRPT041_ShippingInstructionListReport(List<ReportDefaultParam> rptParams)
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

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            

            BorderSide border = BorderSide.None;

            string InvoiceNoCurr = GetCurrentColumnValue("InvoiceNo").ToString();
            string ContainerNoCurr = GetCurrentColumnValue("ContainerNo").ToString();
            string ActualOutCurr = Convert.ToDateTime(GetCurrentColumnValue("ActualOut")).ToString("yyyy/MM/dd");

            string InvoiceNoPre = GetPreviousColumnValue("InvoiceNo").ToString();
            string ContainerNoPre = GetPreviousColumnValue("ContainerNo").ToString();
            string ActualOutPre = Convert.ToDateTime(GetPreviousColumnValue("ActualOut")).ToString("yyyy/MM/dd");


            bool isGroupChange = InvoiceNoCurr != InvoiceNoPre
                                    || ContainerNoCurr != ContainerNoPre
                                    || ActualOutCurr != ActualOutPre;

            if (this.CurrentRowIndex == 0 || isGroupChange)
            {
                RowIndex = 0;
                ColumnIndex = 0;
            }
            else
            {
                RowIndex++;
                ColumnIndex = RowIndex % 3;
            }

            if (RowIndex < 3)
            {
                border |= BorderSide.Top;
            }

            if (ColumnIndex == 0)
            {
                border |= BorderSide.Left | BorderSide.Right | BorderSide.Bottom;
            }
            else
            {
                border |= BorderSide.Right | BorderSide.Bottom;
            }


            xrCrossBandBox.Borders = border;

        }

    }
}

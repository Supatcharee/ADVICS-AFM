using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using System.Collections.Generic;

namespace Rubix.Screen.Report
{
    public partial class rptRPT005_ReceivingTransportationChargeReport : Base.BaseReport//DevExpress.XtraReports.UI.XtraReport
    {
        #region Member
        private int totalContainer = 0; 
        #endregion

        #region Constructor
        public rptRPT005_ReceivingTransportationChargeReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
        }

        public rptRPT005_ReceivingTransportationChargeReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
        } 
        #endregion

        #region Event Handler Function
        private void GroupFooter1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (GetPreviousColumnValue("ReceiveQty") == string.Empty || GetPreviousColumnValue("ReceiveQty") == null)
            //    e.Cancel = true;
            if (totalContainer == 0)
            {
                e.Cancel = true;
            }

        }

        private void xrTableCell24_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (xrTableCell24.Text != string.Empty || xrTableCell24.Text != null)
            {
                if (xrTableCell24.Text.Trim() != string.Empty)
                {
                    totalContainer = Convert.ToInt32(xrTableCell24.Text);
                }
            }
        }
        #endregion

        #region Generic Function
        public void SetOwnerNameParameter(object val)
        {
            this.Parameters["OwnerName"].Value = val;
        }

        public void SetWarehouseNameParameter(object val)
        {
            this.Parameters["WarehouseName"].Value = val;
        }

        public void SetDateFromParameter(object val)
        {
            this.Parameters["DateFrom"].Value = val;
        }

        public void SetDateToParameter(object val)
        {
            this.Parameters["DateTo"].Value = val;
        }

        public void SetUserNameParameter(object val)
        {
            this.Parameters["UserName"].Value = val;
        }
        
        #endregion
    
    }
}

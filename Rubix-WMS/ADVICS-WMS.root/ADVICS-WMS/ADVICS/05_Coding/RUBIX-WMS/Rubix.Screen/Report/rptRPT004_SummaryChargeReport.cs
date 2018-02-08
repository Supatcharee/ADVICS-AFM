using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Report
{
    public partial class rptRPT004_SummaryChargeReport : Base.BaseReport //DevExpress.XtraReports.UI.XtraReport
    {
        #region Constructor
        public rptRPT004_SummaryChargeReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
        }

        public rptRPT004_SummaryChargeReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
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

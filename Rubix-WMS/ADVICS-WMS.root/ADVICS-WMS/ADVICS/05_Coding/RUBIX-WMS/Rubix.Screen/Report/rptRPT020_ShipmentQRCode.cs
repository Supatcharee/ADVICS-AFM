using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using System.Collections.Generic;

namespace Rubix.Screen.Report
{
    public partial class rptRPT020_ShipmentQRCode : Base.BaseReport
    {
        #region Constructor
        public rptRPT020_ShipmentQRCode()
        {
            InitializeComponent();
            SetFormatString();
        } 
        public rptRPT020_ShipmentQRCode(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetFormatString();
        }
        #endregion


        #region Generic Function

        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }

        private void SetFormatString()
        {
            //xrLabel13.XlsxFormatString = Common.FullDateFormat;
        } 
        #endregion


    }
}

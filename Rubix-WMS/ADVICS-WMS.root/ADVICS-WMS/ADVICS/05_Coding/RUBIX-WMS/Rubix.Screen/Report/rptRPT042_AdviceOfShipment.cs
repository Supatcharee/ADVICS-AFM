using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using CSI.Business.DataObjects;
using DevExpress.XtraReports.UI;

namespace Rubix.Screen.Report
{
    public partial class rptRPT042_AdviceOfShipment : Base.BaseReport
    {
        #region Constructor

        public rptRPT042_AdviceOfShipment()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }

        public rptRPT042_AdviceOfShipment(List<ReportDefaultParam> rptParams)
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

    }
}

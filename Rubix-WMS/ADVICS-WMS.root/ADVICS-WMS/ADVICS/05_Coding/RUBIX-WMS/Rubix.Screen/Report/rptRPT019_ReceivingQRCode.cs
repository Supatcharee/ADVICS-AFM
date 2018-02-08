using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using CSI.Business.DataObjects;
using System.Data.Objects;

namespace Rubix.Screen.Report
{
    public partial class rptRPT019_ReceivingQRCode : Base.BaseReport
    {
        #region Constructor
        public rptRPT019_ReceivingQRCode()
        {
            InitializeComponent();

        }
        public rptRPT019_ReceivingQRCode(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
        }
        
        #endregion

        #region Event Handler Function
        
        #endregion

        #region Generic Function
        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }

        public void SetParameterLabelHeader(object val)
        {
            this.Parameters["LabelHeader"].Value = val;
        } 
        #endregion


    }
}

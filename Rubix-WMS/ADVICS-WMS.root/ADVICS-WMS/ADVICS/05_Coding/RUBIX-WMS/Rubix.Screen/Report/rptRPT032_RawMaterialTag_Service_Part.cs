using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Report
{
    public partial class rptRPT032_RawMaterialTag_Service_Part : Base.BaseReport
    {
        public rptRPT032_RawMaterialTag_Service_Part()
        {
            InitializeComponent();
        }

        public rptRPT032_RawMaterialTag_Service_Part(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();            
        }

        #region Generic Function

        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }

        #endregion
    }
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Report
{
    public partial class rptRPT046_PackingCommandInstruction : Base.BaseReport
    {
        #region Constructor
        public rptRPT046_PackingCommandInstruction()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
        }
        public rptRPT046_PackingCommandInstruction(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
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

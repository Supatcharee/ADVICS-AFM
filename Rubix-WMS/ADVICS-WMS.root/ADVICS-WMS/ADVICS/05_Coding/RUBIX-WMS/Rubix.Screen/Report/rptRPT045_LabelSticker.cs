using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Globalization;
using CSI.Business.DataObjects;
using DevExpress.XtraReports.UI;
using Rubix.Framework;

namespace Rubix.Screen.Report
{
    public partial class rptRPT045_LabelSticker : Base.BaseReport
    {
        #region Constructor

        public rptRPT045_LabelSticker()
        {
            InitializeComponent();            
        }

        public rptRPT045_LabelSticker(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();            
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

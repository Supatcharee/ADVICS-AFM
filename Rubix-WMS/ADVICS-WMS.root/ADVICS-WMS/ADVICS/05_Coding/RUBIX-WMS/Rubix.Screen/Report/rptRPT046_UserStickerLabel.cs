using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Report
{
    public partial class rptRPT046_UserStickerLabel : Base.BaseReport
    {
        #region Constructor
        public rptRPT046_UserStickerLabel()
        {
            InitializeComponent();
        }
        public rptRPT046_UserStickerLabel(List<ReportDefaultParam> rptParams)
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

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrBarcodeUser.Text = string.Format("USERNAME-{0}", this.GetCurrentColumnValue("UserID"));
        }
    }
}

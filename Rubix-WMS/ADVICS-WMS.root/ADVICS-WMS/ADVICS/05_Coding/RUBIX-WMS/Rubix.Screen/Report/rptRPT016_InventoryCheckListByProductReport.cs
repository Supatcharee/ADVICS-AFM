using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using System.Collections.Generic;

namespace Rubix.Screen.Report
{
    public partial class rptRPT016_InventoryCheckListByProductReport : Base.BaseReport
    {
        #region Constructor
        public rptRPT016_InventoryCheckListByProductReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox3);
        }
        public rptRPT016_InventoryCheckListByProductReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox3);
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

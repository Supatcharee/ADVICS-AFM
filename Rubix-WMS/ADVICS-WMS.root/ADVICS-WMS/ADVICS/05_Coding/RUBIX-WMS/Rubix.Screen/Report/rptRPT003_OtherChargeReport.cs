using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using System.Collections.Generic;

namespace Rubix.Screen.Report
{
    public partial class rptRPT003_OtherChargeReport : Base.BaseReport//DevExpress.XtraReports.UI.XtraReport
    {

        #region Constructor
        public rptRPT003_OtherChargeReport()
        {
            InitializeComponent();
            SetFormatStringToControl();
            SetImageLogoReport(xrPictureBox2);
        }

        public rptRPT003_OtherChargeReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetFormatStringToControl();
            SetImageLogoReport(xrPictureBox2);
        } 
        #endregion

        #region Generic Function

        private void SetFormatStringToControl()
        {
            xrTableCell28.XlsxFormatString = Common.FullDateFormat;
            xrLabel11.XlsxFormatString = "Period From : {0:" + Common.FullDateFormat + "}";
            xrLabel9.XlsxFormatString = "- {0:" + Common.FullDateFormat + "}";
        }

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

        //public void SetGrandTotalParameter(object val)
        //{
        //    this.Parameters["GrandTotal"].Value = val;
        //}

        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        } 
        #endregion
    }
}

using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using CSI.Business.DataObjects;
using DevExpress.XtraReports.UI;

namespace Rubix.Screen.Report
{
    public partial class rptRPT032_RawMaterialTag : Base.BaseReport
    {
        #region Constructor

        public rptRPT032_RawMaterialTag()
        {
            InitializeComponent();
            
        }

        public rptRPT032_RawMaterialTag(List<ReportDefaultParam> rptParams)
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

        private void Detail_Pallet_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Pallet.GetCurrentColumnValue("ProductType") != null)
            {
                if (DetailReport_Pallet.GetCurrentColumnValue("ProductType").ToString() == "1")
                {
                    xrTable2.Visible = false;
                    xrTable1.Visible = true;

                    xrTable3.Visible = false;
                    xrTable5.Visible = true;

                    xrTable4.Visible = false;
                    xrTable20.Visible = true;
                }
                else if (DetailReport_Pallet.GetCurrentColumnValue("ProductType").ToString() == "2")
                {
                    xrTable2.Visible = true;
                    xrTable1.Visible = false;

                    xrTable3.Visible = true;
                    xrTable5.Visible = false;

                    xrTable4.Visible = true;
                    xrTable20.Visible = false;
                }
                else
                {
                    xrTable2.Visible = false;
                    xrTable1.Visible = true;

                    xrTable3.Visible = false;
                    xrTable5.Visible = true;

                    xrTable4.Visible = false;
                    xrTable20.Visible = true;
                }
            }
            
        }


    }
}

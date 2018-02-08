using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Rubix.Screen.Report
{
    public partial class rptRPT017_InventoryCheckListByZoneReport_SubReport : DevExpress.XtraReports.UI.XtraReport
    {
        #region Constructor
        public rptRPT017_InventoryCheckListByZoneReport_SubReport()
        {
            InitializeComponent();
        } 
        #endregion

        #region Event Handler Function
        private void xrTableCell14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            System.Reflection.PropertyInfo pi = this.GetType().GetProperty("DisplayableRowCount", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            int displayableRowCount = Convert.ToInt32(pi.GetValue(this, null));
            if (displayableRowCount > 1)
            {
                if (this.CurrentRowIndex != 0)
                {
                    xrTableCell14.Text = string.Empty;
                    xrTableCell14.Borders = DevExpress.XtraPrinting.BorderSide.None;
                    xrTableCell14.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
                    //xrTableCell17.Borders = DevExpress.XtraPrinting.BorderSide.Right;
                }
                ///if last row
                if (this.CurrentRowIndex == (displayableRowCount - 1))
                {
                    xrTableCell14.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCell30.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom | DevExpress.XtraPrinting.BorderSide.Top;
                    xrTableCell16.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom | DevExpress.XtraPrinting.BorderSide.Top;
                    //xrTableCell17.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom;
                }
            }
            else
            {
                xrTableCell14.Borders = DevExpress.XtraPrinting.BorderSide.All;
                xrTableCell30.Borders = DevExpress.XtraPrinting.BorderSide.All;
                xrTableCell16.Borders = DevExpress.XtraPrinting.BorderSide.All;
                //xrTableCell17.Borders = DevExpress.XtraPrinting.BorderSide.All;

            }
        }
        
        #endregion
        
    }
}

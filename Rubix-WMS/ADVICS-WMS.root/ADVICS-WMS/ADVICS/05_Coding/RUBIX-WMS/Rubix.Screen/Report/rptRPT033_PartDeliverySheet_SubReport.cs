using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace Rubix.Screen.Report
{
    public partial class rptRPT033_PartDeliverySheet_SubReport : DevExpress.XtraReports.UI.XtraReport
    {
        #region Constructor
        public rptRPT033_PartDeliverySheet_SubReport()
        {
            InitializeComponent();
            
        } 
        #endregion

        private int rowNo = 0;

        private void xrTableCell_Total_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (CurrentRowIndex == 0)
                rowNo = 0;            

            XRTableCell cell = sender as XRTableCell;

            //##################
            //# แสดงกรอบของ Total ให้ครอบทุกแถว
            //##################
            //if (cell != null)
            //{
            //    if (rowNo == 0)
            //    {
            //        if (rowNo == RowCount - 1)
            //        {
            //            cell.Borders = BorderSide.Bottom | BorderSide.Right | BorderSide.Left;
            //        }
            //        else
            //        {
            //            cell.Borders = BorderSide.Right | BorderSide.Left;  // ไม่ต้องใช้เส้นบน เพราะอาศัยเส้นบนจาก Detail ก่อนหน้า
            //        }
            //    }
            //    else if (rowNo == RowCount - 1)
            //    {
            //        cell.Borders = BorderSide.Bottom | BorderSide.Right | BorderSide.Left;
            //    }
            //    else
            //    {
            //        cell.Borders = BorderSide.Right | BorderSide.Left;
            //    }

            //    rowNo++;
            //}


            //##################
            //# แสดงกรอบของ Total แค่แถวเดียว
            //##################
            if (cell != null)
            {
                if (rowNo == 0)
                {
                    cell.Borders = BorderSide.Bottom | BorderSide.Right | BorderSide.Left;
                }
                else
                {
                    cell.Borders = BorderSide.Right;
                }

                rowNo++;
            }
        }
    
         
    }
}

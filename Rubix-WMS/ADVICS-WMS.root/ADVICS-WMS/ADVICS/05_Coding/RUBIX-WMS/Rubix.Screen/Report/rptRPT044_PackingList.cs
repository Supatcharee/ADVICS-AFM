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
using DevExpress.XtraPrinting;

namespace Rubix.Screen.Report
{
    public partial class rptRPT044_PackingList : Base.BaseReport
    {
        private const int C_LIMIT_PAGE1 = 13;  // 15
        private const int C_LIMIT_PAGE2 = 17;  // 19

        #region Member

        /// <summary>
        /// Flag บอกว่าเป็นการแสดงรายการ Detail รายการแรกของแต่ละหน้ากระดาษ
        /// Flag นี้ใช้สำหรับวาดเส้นแบ่ง Header กับ Detail 
        ///   เนื่องจาก Header Column จะแสดงเส้นล่าง
        ///   และแต่ละ Detail จะมีเส้นบน 
        ///   ดังนั้นถ้าให้แสดงพร้อมกัน  จะเกิดเส้นหนาขึ้น  จึงจำเป็นต้องเลือกแสดงอย่างใดอย่างหนึ่ง
        /// </summary>
        private bool IsFirstRecordOnPage = true;

        /// <summary>
        /// Running No : สำหรับนับจำนวนรายการภายใน 1 หน้า เมื่อขึ้นหน้าใหม่จะเริ่มนับ 1 ใหม่
        /// </summary>
        private int RecordNumberByPage = 0;

        /// <summary>
        /// RunningNo แสดงลำดับ Row ตั้งแต่แถวแรกจนถึงแถวสุดท้าย
        /// </summary>
        private int RecordNumberTotal = 0;

        /// <summary>
        /// RunningNo: สำหรับนับจำนวนใน Pallet เดียวกัน
        /// </summary>
        private int RecordNumberByPallet = 0;


        private decimal SumGrossWeight = 0;
        private decimal SumM3 = 0;

        #endregion

        #region Constructor

        public rptRPT044_PackingList()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);            
        }

        public rptRPT044_PackingList(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }

        #endregion

        #region Generic Function

        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }

        public void SetSubReportDatasource(object source)
        {
            //xrSubreport.ReportSource.DataSource = source;
        }
        #endregion

        #region Report Events     

        

        /// <summary>
        /// Hidden Line เมื่อ RowNumber ของ Group = 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lineDetail_BeforePrint(object sender, PrintEventArgs e)
        {
            XRLine line = sender as XRLine;
            if (line == null)
                return;
            
            // จะซ่อนเส้นเมื่อ RecByPage = 1 (Record แรกเมื่อปัดหน้าใหม่)
            //              และ RecByPallet (Record แรกเมื่อขึ้น Pallet ใหม่)
            line.Visible = (RecordNumberByPage > 1) && (RecordNumberByPallet > 1);

        }

        private void linePalletNo_BeforePrint(object sender, PrintEventArgs e)
        {
            XRLine line = sender as XRLine;
            if (line == null)
                return;

            line.Visible = !IsFirstRecordOnPage;
        }

        private void lineDetailPalletBottom_BeforePrint(object sender, PrintEventArgs e)
        {
            XRLine line = sender as XRLine;
            if (line == null)
                return;

            // เส้นนี้จะแสดงเป็นเส้นปิดท้ายกระดาษ เมื่อพบว่ามีการกำหนดให้ขึ้นหน้าใหม่
            if (Detail.PageBreak == PageBreak.AfterBand)
                line.Visible = true;
            else line.Visible = false;
        }
        

        private void Detail_BeforePrint(object sender, PrintEventArgs e)
        {
            // เมื่อเริ่มแสดงรายการ Detail จะเปลี่ยน flag = false
            IsFirstRecordOnPage = false;

            // ค่านี้จะเพิ่มขึ้นเรื่อยๆ เมื่อมีการ Fetch Record
            // และจะ Reset ค่า เมื่อจบ Group Pallet (Footer)      
            RecordNumberTotal++;
            RecordNumberByPallet++;

            // ตรวจสอบข้อจำกัดการแสดง Detail ภายในหน้า
            // หน้าแรก ต้องแสดงไม่เกิน C_LIMIT_PAGE1
            // หน้าอื่นๆ ต้องแสดงไม่เกิน C_LIMIT_PAGE2
            //if (RecordNumberTotal <= C_LIMIT_PAGE1)
            //{
            //    RecordNumberByPage++;

            //    // เมื่อ Print จำนวนรายการครบ Limit แล้วจะสั่งให้ปัดหน้าใหม่
            //    if (RecordNumberByPage == C_LIMIT_PAGE1)
            //    {
            //        Detail.PageBreak = PageBreak.AfterBand;
            //    }
            //    else
            //    {
             //       Detail.PageBreak = PageBreak.None;
            //    }
            //}
            //else if (RecordNumberTotal > C_LIMIT_PAGE1)
            //{
            //    RecordNumberByPage = ((RecordNumberTotal - C_LIMIT_PAGE1 - 1) % C_LIMIT_PAGE2) + 1;

            //    if (RecordNumberByPage == C_LIMIT_PAGE2)
            //    {
            //        Detail.PageBreak = PageBreak.AfterBand;
            //    }
            //    else
            //    {
            //        Detail.PageBreak = PageBreak.None;
            //    }
            //}

            // Summary GrossWeight/M3 each row
            SumGrossWeight += DataUtil.Convert<decimal>(this.GetCurrentColumnValue("GrossWeight")) ?? 0;
            SumM3 += DataUtil.Convert<decimal>(this.GetCurrentColumnValue("M3")) ?? 0;

            // First Record of each Group PalletNo
            if (RecordNumberByPallet == 1)
            {
                // Visible
                lblGrossWeight.Visible = true;
                lblM3.Visible = true;
            }
            else
            {
                // Not Visible
                lblGrossWeight.Visible = false;
                lblM3.Visible = false;
            }

            //=============================================
            // แสดงค่าสำหรับ Test
            //=============================================
            lblRecTotal.Text = RecordNumberTotal.ToString();
            lblRecByPage.Text = RecordNumberByPage.ToString();
            lblRecByPallet.Text = RecordNumberByPallet.ToString();

            
        }
       
        private void GroupFooter_Report_BeforePrint(object sender, PrintEventArgs e)
        {
            // แสดงค่าผลลัพธ์ให้ Label
            lblTotalGrossWeight.Text = SumGrossWeight.ToString("n4");
            lblTotalM3.Text = SumM3.ToString("n4");
        }

        private void GroupFooter_PalletNo_BeforePrint(object sender, PrintEventArgs e)
        {
            // เมื่อการมี Print GroupFooter_PalletNo 
            // จะทำการ Reset ค่า RecordNumberByPallet เพื่อเตรียมใช้นับ Pallet ถัดไป
            RecordNumberByPallet = 0;
        }

        #endregion       

        private void xrPanel2_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                xrPanel2.Visible = false;
            }
        }

        private void xrLabel38_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                xrLabel38.Visible = false;
            }
        }

        private void xrLabel39_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                xrLabel39.Visible = false;
            }
        }

        private void lblSummaryQty_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                lblSummaryQty.Visible = false;
            }
        }

        private void xrLabel41_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                xrLabel41.Visible = false;
            }
        }

        private void lblSummaryNetWeight_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                lblSummaryNetWeight.Visible = false;
            }
        }

        private void xrLabel42_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                xrLabel42.Visible = false;
            }
        }

        private void lblTotalGrossWeight_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                lblTotalGrossWeight.Visible = false;    //tot
            }

            
        }

        private void xrLabel36_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                xrLabel36.Visible = false;
            }
        }

        private void lblTotalM3_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                lblTotalM3.Visible = false;   //tot
            }
        }

        private void xrLine7_PrintOnPage(object sender, PrintOnPageEventArgs e)
        {
            if (e.PageCount - 1 != e.PageIndex)
            {
                xrLine7.Visible = false;
            }
        }

        private void ReportFooter_BeforePrint(object sender, PrintEventArgs e)
        {
            lblTotalGrossWeight2.Text = SumGrossWeight.ToString("n4");
            lblTotalM32.Text = SumM3.ToString("n4");
            lblTotalM3.Visible = true;
            lblTotalGrossWeight.Visible = true;    
        }

        private void PageFooter_BeforePrint(object sender, PrintEventArgs e)
        {
            //Detail.PageBreak = PageBreak.AfterBand;
         
        }

        private void rptRPT044_PackingList_BeforePrint(object sender, PrintEventArgs e)
        {
            //PrintingSystemBase printingSystem1 = report.PrintingSystem;

            //// Obtain the current export options.
            //ExportOptions options = printingSystem1.ExportOptions;
        }

        private void ReportFooter_AfterPrint(object sender, EventArgs e)
        {
            Detail.PageBreak = PageBreak.AfterBand;
        }
    }
}

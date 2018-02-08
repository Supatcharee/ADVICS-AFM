using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using System.Collections.Generic;

namespace Rubix.Screen.Report
{
    public partial class rptRPT022_DeliveryOrder : Base.BaseReport
    {
        #region Member
        int RealRowIndex = 0;
        int CurrentRecordOnPage = 1; //บอกว่าตอนนี้เป็นการ print record ที่เท่าไหร่ของหน้านั้นๆ
        int RecordPerPage = 10;
        int RecordPerPage2 = 25;
        bool LastRecordInPage = false; 
        #endregion

        #region Constructor
        public rptRPT022_DeliveryOrder()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }
        public rptRPT022_DeliveryOrder(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        } 
        #endregion

        #region Override Method
        private void xrTableCellNo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRTableCell[] cells = new XRTableCell[] { xrTableCellNo, xrTableCellProductCode, xrTableCellProductName, 
                xrTableCellLotNo,xrTableCellShipQty,xrTableCellUnit,xrTablePackingSize,xrTablePackingSale, xrTableCellDetailRemark};

            if (this.CurrentRowIndex != 0
                //&& Convert.ToString(GetCurrentColumnValue("PickingNo")) == Convert.ToString(GetPreviousColumnValue("PickingNo"))
                    && Convert.ToInt32(GetCurrentColumnValue("LineNo")) == Convert.ToInt32(GetPreviousColumnValue("LineNo"))
                   )
            {
                xrTableCellNo.Text = string.Empty;
                xrTableCellShipQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Top;
                xrTableCellUnit.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Top;
                xrTablePackingSale.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Top;
                xrTablePackingSize.Borders = DevExpress.XtraPrinting.BorderSide.Left
                       | DevExpress.XtraPrinting.BorderSide.Right
                       | DevExpress.XtraPrinting.BorderSide.Top;
            }
            else
            {
                xrTableCellShipQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right;
                xrTableCellUnit.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right;
                xrTablePackingSale.Borders = DevExpress.XtraPrinting.BorderSide.Left
                     | DevExpress.XtraPrinting.BorderSide.Right;
                xrTablePackingSize.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right;
                RealRowIndex++;
                xrTableCellNo.Text = RealRowIndex.ToString();
            }


            if (this.CurrentRowIndex != 0
                //&& Convert.ToString(GetCurrentColumnValue("PickingNo")) == Convert.ToString(GetPreviousColumnValue("PickingNo"))
                && Convert.ToInt32(GetCurrentColumnValue("LineNo")) == Convert.ToInt32(GetPreviousColumnValue("LineNo"))
               )
            {
                //for (int i = 0; i < cells.Length; i++)
                //{
                //    cells[i].Text = string.Empty;
                //}
                xrTableCellProductCode.Text = string.Empty;
                xrTableCellProductName.Text = string.Empty;
            }
        }

        private void ReportHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.RealRowIndex = 0;
        } 
        #endregion

        #region Generic Function
        public void SubReportDatasource(object source)
        {
            //rptRPT022_DeliveryOrder_SubReport1.DataSource = source;
        }
        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }

        public void SetTotalRecordParameter(object val)
        {
            this.TotalRecord.Value = val;
        } 
        #endregion   
    }
}

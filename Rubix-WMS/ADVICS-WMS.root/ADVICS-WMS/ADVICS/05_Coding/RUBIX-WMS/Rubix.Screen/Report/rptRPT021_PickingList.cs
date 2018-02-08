using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using System.Collections.Generic;
using Rubix.Framework;

namespace Rubix.Screen.Report
{
    public partial class rptRPT021_PickingList : Base.BaseReport
    {
        #region Member
        int RealRowIndex = 0; // ใช้เป็นข้อมูลใน column no 
        #endregion

        #region Constructor
        public rptRPT021_PickingList()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
        }
        public rptRPT021_PickingList(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
            //xrlPrintByR.Text = string.Format(xrlPrintByR.Text, AppConfig.UserLogin);
            //xrlPrintByP.Text = string.Format(xrlPrintByR.Text, AppConfig.UserLogin);
        } 
        #endregion

        #region Generic Function
        public void SubReportDatasource(object source)
        {
            rptRPT021_PickingList_SubReport1.DataSource = source;
        }
        public void SetPickingNoParameter(object val)
        {
            this.Parameters["pickingNo"].Value = val;
        }
        public void SetShipmentNoParameter(object val)
        {
            this.Parameters["shipmentNo"].Value = val;
        }

        public void SetTotalRecordParameter(object val)
        {
            this.Parameters["TotalRecord"].Value = val;
        }

        public void SetPrintByParameter(object val)
        {
            this.Parameters["pPrintBy"].Value = val;
        } 
        #endregion

        #region Event Handler Function
        private void xrTableCellNo1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.CurrentRowIndex != 0
                    && (Convert.ToString(GetCurrentColumnValue("PickingLineNo")) == Convert.ToString(GetPreviousColumnValue("PickingLineNo"))))
            {
                //xrBarCodeProduct.Visible = false;

                xrTableCellNo1.Text = string.Empty;
                //xrTableCellPickingLineNo.Text = string.Empty;
                xrTableCellProductCode.Text = string.Empty;
                xrTableCellProductName.Text = string.Empty;
                xrTableCellLotNo1.Text = string.Empty;
                //xrTableCellPalletNo.Text = string.Empty;
                //xrTableCellStockQty1.Text = string.Empty;
                xrTableCellStockUOM1.Text = string.Empty;
                xrTableCellPO1.Text = string.Empty;
                xrTableCellDetailRemark1.Text = string.Empty;

                //xrTableCellNo2.Text = string.Empty;
                //xrTableCellBarcode.Text = string.Empty;
                //xrTableCellLotNo2.Text = string.Empty;
                //xrTableCellPalletRef.Text = string.Empty;
                //xrTableCellStockQty2.Text = string.Empty;
                //xrTableCellStockUOM2.Text = string.Empty;
                //xrTableCellPO2.Text = string.Empty;
                //xrTableCellDetailRemark2.Text = string.Empty;
                if (Convert.ToString(GetCurrentColumnValue("LocationCode")) == Convert.ToString(GetPreviousColumnValue("LocationCode")))
                {
                    xrTableCellLocation1.Text = string.Empty;
                    //xrTableCellLocation2.Text = string.Empty;
                    xrTableCellLocation1.Borders = DevExpress.XtraPrinting.BorderSide.Left
                            | DevExpress.XtraPrinting.BorderSide.Right;

                    xrTableCellStockQty1.Text = string.Empty;
                    xrTableCellStockQty1.Borders = DevExpress.XtraPrinting.BorderSide.Left
                           | DevExpress.XtraPrinting.BorderSide.Right;
                }
                else
                {
                    xrTableCellLocation1.Borders = DevExpress.XtraPrinting.BorderSide.Left
                            | DevExpress.XtraPrinting.BorderSide.Right
                            | DevExpress.XtraPrinting.BorderSide.Top;
                    xrTableCellStockQty1.Borders = DevExpress.XtraPrinting.BorderSide.Left
                           | DevExpress.XtraPrinting.BorderSide.Right
                           | DevExpress.XtraPrinting.BorderSide.Top;
                }

                //xrTableCellPickingLineNo.Borders = DevExpress.XtraPrinting.BorderSide.Left;
                xrTableCellProductCode.Borders = DevExpress.XtraPrinting.BorderSide.Right;
                xrTableCellProductName.Borders = DevExpress.XtraPrinting.BorderSide.Right;
                //xrTableCellPalletNo.Borders = DevExpress.XtraPrinting.BorderSide.Left
                //        | DevExpress.XtraPrinting.BorderSide.Right;

                xrTableCell32.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Top;

                xrTableCell27.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Top;

                xrTableCell36.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Top;

                xrTableCell28.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Top;

            }
            else
            {
                RealRowIndex++;

                xrTableCellNo1.Text = RealRowIndex.ToString();

                //xrBarCodeProduct.Visible = true;
                //xrTableCellPalletNo.Borders = DevExpress.XtraPrinting.BorderSide.Left
                //        | DevExpress.XtraPrinting.BorderSide.Right;

                xrTableCell32.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right;

                xrTableCell27.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right;

                xrTableCell36.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right;

                xrTableCell28.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right;

                //xrTableCellPickingLineNo.Borders = DevExpress.XtraPrinting.BorderSide.Left
                //        | DevExpress.XtraPrinting.BorderSide.Right
                //        | DevExpress.XtraPrinting.BorderSide.Bottom;
                xrTableCellProductCode.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right;
                xrTableCellProductName.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right;
                //xrTableCellPalletNo.Borders = DevExpress.XtraPrinting.BorderSide.Left
                //        | DevExpress.XtraPrinting.BorderSide.Right
                //        | DevExpress.XtraPrinting.BorderSide.Bottom;
                xrTableCellLocation1.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right;
                xrTableCellStockQty1.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right;
            }
        } 
        #endregion
    }
}

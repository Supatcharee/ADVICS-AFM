using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Report
{
    public partial class rptRPT013_ShippingDeliveryReport : Base.BaseReport//DevExpress.XtraReports.UI.XtraReport
    {
        #region Member
        int RowNo = 0;
        const int RecPerPage = 16;
        bool show, newPage, printGroup, borderQtyBottom;
        int LastRec, NoRec, CurrentNo, CurrentRow, NoRecField;
        string Invoice, ProductCode, ProductName, ReceiveDate, DeleveryDate; 
        private Dictionary<string, decimal> balance = new Dictionary<string, decimal>();
        #endregion

        #region Constructor
        public rptRPT013_ShippingDeliveryReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
            NoRec = 0;
            Invoice = string.Empty;
            ProductCode = string.Empty;
            ProductName = string.Empty;
            ReceiveDate = string.Empty;
            DeleveryDate = string.Empty;
            newPage = false;
            printGroup = false;
        }
        public rptRPT013_ShippingDeliveryReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
            NoRec = 0;
            Invoice = string.Empty;
            ProductCode = string.Empty;
            ProductName = string.Empty;
            ReceiveDate = string.Empty;
            DeleveryDate = string.Empty;
            newPage = false;
            printGroup = false;
        } 
        #endregion

        #region Event Handler Function
        private void xrTableCellNo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            LastRec = (Int32)this.Parameters["TotalRecord"].Value - 1;


            CurrentNo = Convert.ToInt32(xrTableCellNo.Text);
            if (NoRec.ToString() == xrTableCellNo.Text)
            {
                xrTableCellNo.Text = string.Empty;
                show = true;
                if (this.CurrentRowIndex == LastRec)
                {
                    xrTableCellNo.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellInvoiceNo.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellProductCode.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellProductName.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellLocation.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellDeliveryDate.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellReceivingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                      | DevExpress.XtraPrinting.BorderSide.Right
                      | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellShippingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                      | DevExpress.XtraPrinting.BorderSide.Right
                      | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellBalanceQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                      | DevExpress.XtraPrinting.BorderSide.Right
                      | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellUOM.Borders = DevExpress.XtraPrinting.BorderSide.Left
                      | DevExpress.XtraPrinting.BorderSide.Right
                      | DevExpress.XtraPrinting.BorderSide.Bottom;
                }
                else
                {
                    xrTableCellNo.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right;
                    xrTableCellInvoiceNo.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right;
                    xrTableCellProductCode.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right;
                    xrTableCellProductName.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right;
                    xrTableCellLocation.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right;
                    xrTableCellDeliveryDate.Borders = DevExpress.XtraPrinting.BorderSide.Left
                       | DevExpress.XtraPrinting.BorderSide.Right;
                }
                //if (CurrentRow % RecPerPage == 0)
                if (RowNo != 0 && RowNo % RecPerPage == 0)
                {
                    xrTableCellNo.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                          | DevExpress.XtraPrinting.BorderSide.Right
                                          | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellInvoiceNo.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellProductCode.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellProductName.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellLocation.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellDeliveryDate.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellReceivingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                      | DevExpress.XtraPrinting.BorderSide.Right
                      | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellShippingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                      | DevExpress.XtraPrinting.BorderSide.Right
                      | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellBalanceQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                      | DevExpress.XtraPrinting.BorderSide.Right
                      | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellUOM.Borders = DevExpress.XtraPrinting.BorderSide.Left
                      | DevExpress.XtraPrinting.BorderSide.Right
                      | DevExpress.XtraPrinting.BorderSide.Bottom;
                    borderQtyBottom = true;
                }
                else
                    borderQtyBottom = false;
            }
            else
            {
                NoRec = Convert.ToInt32(xrTableCellNo.Text);
                NoRecField++;
                xrTableCellNo.Text = NoRecField.ToString();
                show = false;
                if (this.CurrentRowIndex == LastRec)
                {
                    xrTableCellNo.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellInvoiceNo.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellProductCode.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellProductName.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellLocation.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Bottom;
                    xrTableCellDeliveryDate.Borders = DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Right
                        | DevExpress.XtraPrinting.BorderSide.Bottom;
                }
            }

            if (newPage)
            {
                xrTableCellNo.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                         | DevExpress.XtraPrinting.BorderSide.Right;
                xrTableCellInvoiceNo.Borders = DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Right;
                xrTableCellProductCode.Borders = DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Right;
                xrTableCellProductName.Borders = DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Right;
                xrTableCellLocation.Borders = DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Right;
                xrTableCellDeliveryDate.Borders = DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Right;
                xrTableCellReceivingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                  | DevExpress.XtraPrinting.BorderSide.Right
                  | DevExpress.XtraPrinting.BorderSide.Bottom;
                xrTableCellShippingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                  | DevExpress.XtraPrinting.BorderSide.Right
                  | DevExpress.XtraPrinting.BorderSide.Bottom;
                xrTableCellBalanceQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                  | DevExpress.XtraPrinting.BorderSide.Right
                  | DevExpress.XtraPrinting.BorderSide.Bottom;
                xrTableCellUOM.Borders = DevExpress.XtraPrinting.BorderSide.Left
                  | DevExpress.XtraPrinting.BorderSide.Right
                  | DevExpress.XtraPrinting.BorderSide.Bottom;
            }
        }

        private void GroupFooter2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            printGroup = true;
            if (RowNo % RecPerPage == 0 && this.CurrentRowIndex != 0)
            {
                GroupHeader1.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
                newPage = true;
                xrTableCell8.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                       | DevExpress.XtraPrinting.BorderSide.Right
                                       | DevExpress.XtraPrinting.BorderSide.Bottom;
                RowNo = 0;
            }
            else
            {


                GroupHeader1.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
                newPage = false;
                if (RowNo != 0)
                    xrTableCell8.Borders = DevExpress.XtraPrinting.BorderSide.Left
                            | DevExpress.XtraPrinting.BorderSide.Right
                            | DevExpress.XtraPrinting.BorderSide.Top
                            | DevExpress.XtraPrinting.BorderSide.Bottom;
                else
                    xrTableCell8.Borders = DevExpress.XtraPrinting.BorderSide.Left
                      | DevExpress.XtraPrinting.BorderSide.Right
                      | DevExpress.XtraPrinting.BorderSide.Bottom;
                RowNo += 2;
            }
            CurrentRow = CurrentRow + 2;
            NoRecField = 0;

            //if (this.CurrentRowIndex != 0)
            //{
            //    if (CurrentRow % RecPerPage != 0)
            //    {
            //        xrTableCell8.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //            | DevExpress.XtraPrinting.BorderSide.Right
            //            | DevExpress.XtraPrinting.BorderSide.Top;
            //    }
            //    else
            //    {
            //        xrTableCell8.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                              | DevExpress.XtraPrinting.BorderSide.Right
            //                              | DevExpress.XtraPrinting.BorderSide.Top
            //                              | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    }
            //}
        }

        private void GroupHeader2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.CurrentRowIndex != 0 && !printGroup)
            {
                xrTableCellNo.Borders = DevExpress.XtraPrinting.BorderSide.Left
                          | DevExpress.XtraPrinting.BorderSide.Right
                          | DevExpress.XtraPrinting.BorderSide.Top;
                xrTableCellInvoiceNo.Borders = DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Right
                    | DevExpress.XtraPrinting.BorderSide.Top;
                xrTableCellProductCode.Borders = DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Right
                    | DevExpress.XtraPrinting.BorderSide.Top;
                xrTableCellProductName.Borders = DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Right
                    | DevExpress.XtraPrinting.BorderSide.Top;
                xrTableCellLocation.Borders = DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Right
                    | DevExpress.XtraPrinting.BorderSide.Top;
                xrTableCellDeliveryDate.Borders = DevExpress.XtraPrinting.BorderSide.Left
                   | DevExpress.XtraPrinting.BorderSide.Right
                   | DevExpress.XtraPrinting.BorderSide.Top;
            }
        }

        private void xrTableCellReceivingQty_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (this.CurrentRowIndex == 0)
            //{
            //    xrTableCellReceivingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //        | DevExpress.XtraPrinting.BorderSide.Right;
            //}
            //else if (this.CurrentRowIndex != LastRec)
            //{
            //    if (CurrentRow % RecPerPage != 0)
            //    {
            //        if (!newPage && !printGroup)
            //        {
            //            xrTableCellReceivingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                               | DevExpress.XtraPrinting.BorderSide.Right
            //                               | DevExpress.XtraPrinting.BorderSide.Top;
            //        }
            //        else
            //        {
            //            xrTableCellReceivingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                                                      | DevExpress.XtraPrinting.BorderSide.Right;
            //        }
            //    }
            //    else
            //    {
            //        if (!printGroup)
            //            xrTableCellReceivingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                                                  | DevExpress.XtraPrinting.BorderSide.Right
            //                                                  | DevExpress.XtraPrinting.BorderSide.Top
            //                                                  | DevExpress.XtraPrinting.BorderSide.Bottom;
            //        else
            //            xrTableCellReceivingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                                             | DevExpress.XtraPrinting.BorderSide.Right
            //                                             | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    }

            //}
            //else
            //{
            //    if (!printGroup)
            //        xrTableCellReceivingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                            | DevExpress.XtraPrinting.BorderSide.Right
            //                            | DevExpress.XtraPrinting.BorderSide.Top
            //                            | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    else
            //        xrTableCellReceivingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                                         | DevExpress.XtraPrinting.BorderSide.Right
            //                                         | DevExpress.XtraPrinting.BorderSide.Bottom;

            //}
            if (RowNo % RecPerPage == 0)
                xrTableCellReceivingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                                         | DevExpress.XtraPrinting.BorderSide.Right
                                                         | DevExpress.XtraPrinting.BorderSide.Top
                                                         | DevExpress.XtraPrinting.BorderSide.Bottom;
            else
            {
                if (!printGroup && !newPage)
                    xrTableCellReceivingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                                            | DevExpress.XtraPrinting.BorderSide.Right
                                                            | DevExpress.XtraPrinting.BorderSide.Top;
                else
                    xrTableCellReceivingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                                       | DevExpress.XtraPrinting.BorderSide.Right;

                if (this.CurrentRowIndex == LastRec)
                {
                    xrTableCellReceivingQty.Borders = xrTableCellReceivingQty.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
                }
                if (RowNo == 1)
                {
                    xrTableCellReceivingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
                }
            }
        }

        private void xrTableCellShippingQty_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (this.CurrentRowIndex == 0)
            //{
            //    xrTableCellShippingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //        | DevExpress.XtraPrinting.BorderSide.Right;
            //}
            //else if (this.CurrentRowIndex != LastRec)
            //{
            //    if (CurrentRow % RecPerPage != 0)
            //    {
            //        if (!newPage && !printGroup)
            //        {
            //            xrTableCellShippingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                               | DevExpress.XtraPrinting.BorderSide.Right
            //                               | DevExpress.XtraPrinting.BorderSide.Top;
            //        }
            //        else
            //        {
            //            xrTableCellShippingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                               | DevExpress.XtraPrinting.BorderSide.Right;
            //        }
            //    }
            //    else
            //    {
            //        if (!printGroup)
            //            xrTableCellShippingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                                                  | DevExpress.XtraPrinting.BorderSide.Right
            //                                                  | DevExpress.XtraPrinting.BorderSide.Top
            //                                                  | DevExpress.XtraPrinting.BorderSide.Bottom;
            //        else
            //            xrTableCellShippingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                                             | DevExpress.XtraPrinting.BorderSide.Right
            //                                             | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    }
            //}
            //else
            //{
            //    if (!printGroup)
            //        xrTableCellShippingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                            | DevExpress.XtraPrinting.BorderSide.Right
            //                            | DevExpress.XtraPrinting.BorderSide.Top
            //                            | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    else
            //        xrTableCellShippingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                      | DevExpress.XtraPrinting.BorderSide.Right
            //                      | DevExpress.XtraPrinting.BorderSide.Bottom;
            //}
            //if (RowNo % RecPerPage == 0)
            //    xrTableCellShippingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                                             | DevExpress.XtraPrinting.BorderSide.Right
            //                                             | DevExpress.XtraPrinting.BorderSide.Top
            //                                             | DevExpress.XtraPrinting.BorderSide.Bottom;
            if (RowNo % RecPerPage == 0)
                xrTableCellShippingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                                         | DevExpress.XtraPrinting.BorderSide.Right
                                                         | DevExpress.XtraPrinting.BorderSide.Top
                                                         | DevExpress.XtraPrinting.BorderSide.Bottom;
            else
            {
                if (!printGroup && !newPage)
                    xrTableCellShippingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                                            | DevExpress.XtraPrinting.BorderSide.Right
                                                            | DevExpress.XtraPrinting.BorderSide.Top;
                else
                    xrTableCellShippingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                                       | DevExpress.XtraPrinting.BorderSide.Right;

                if (this.CurrentRowIndex == LastRec)
                {
                    xrTableCellShippingQty.Borders = xrTableCellShippingQty.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
                }
                if (RowNo == 1)
                {
                    xrTableCellShippingQty.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
                }
            }
        }

        private void xrTableCellBalanceQty_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (this.CurrentRowIndex == 0)
            //{
            //    xrTableCellBalanceQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //        | DevExpress.XtraPrinting.BorderSide.Right;
            //}
            //else if (this.CurrentRowIndex != LastRec)
            //{
            //    if (CurrentRow % RecPerPage != 0)
            //    {
            //        if (!newPage && !printGroup)
            //        {
            //            xrTableCellBalanceQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                               | DevExpress.XtraPrinting.BorderSide.Right
            //                               | DevExpress.XtraPrinting.BorderSide.Top;
            //        }
            //        else
            //        {
            //            xrTableCellBalanceQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                                                      | DevExpress.XtraPrinting.BorderSide.Right;
            //        }
            //    }
            //    else
            //    {
            //        if (!printGroup)
            //            xrTableCellBalanceQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                                                  | DevExpress.XtraPrinting.BorderSide.Right
            //                                                  | DevExpress.XtraPrinting.BorderSide.Top
            //                                                  | DevExpress.XtraPrinting.BorderSide.Bottom;
            //        else
            //            xrTableCellBalanceQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                                                                     | DevExpress.XtraPrinting.BorderSide.Right
            //                                                                     | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    }
            //}
            //else
            //{
            //    if (!printGroup)
            //        xrTableCellBalanceQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                            | DevExpress.XtraPrinting.BorderSide.Right
            //                            | DevExpress.XtraPrinting.BorderSide.Top
            //                            | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    else
            //        xrTableCellBalanceQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                        | DevExpress.XtraPrinting.BorderSide.Right
            //                        | DevExpress.XtraPrinting.BorderSide.Bottom;
            //}

            //if (RowNo % RecPerPage == 0)
            //    xrTableCellBalanceQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                                             | DevExpress.XtraPrinting.BorderSide.Right
            //                                             | DevExpress.XtraPrinting.BorderSide.Top
            //                                             | DevExpress.XtraPrinting.BorderSide.Bottom;
            if (RowNo % RecPerPage == 0)
                xrTableCellBalanceQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                                         | DevExpress.XtraPrinting.BorderSide.Right
                                                         | DevExpress.XtraPrinting.BorderSide.Top
                                                         | DevExpress.XtraPrinting.BorderSide.Bottom;
            else
            {
                if (!printGroup && !newPage)
                    xrTableCellBalanceQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                                            | DevExpress.XtraPrinting.BorderSide.Right
                                                            | DevExpress.XtraPrinting.BorderSide.Top;
                else
                    xrTableCellBalanceQty.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                                       | DevExpress.XtraPrinting.BorderSide.Right;

                if (this.CurrentRowIndex == LastRec)
                {
                    xrTableCellBalanceQty.Borders = xrTableCellBalanceQty.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
                }
                if (RowNo == 1)
                {
                    xrTableCellBalanceQty.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
                }
            }
        }

        private void xrTableCellUOM_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (this.CurrentRowIndex == 0)
            //{
            //    xrTableCellUOM.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //        | DevExpress.XtraPrinting.BorderSide.Right;
            //}
            //else if (this.CurrentRowIndex != LastRec)
            //{
            //    if (CurrentRow % RecPerPage != 0)
            //    {
            //        if (!newPage && !printGroup)
            //        {
            //            xrTableCellUOM.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                               | DevExpress.XtraPrinting.BorderSide.Right
            //                               | DevExpress.XtraPrinting.BorderSide.Top;
            //        }
            //        else
            //        {
            //            xrTableCellUOM.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                                                      | DevExpress.XtraPrinting.BorderSide.Right;
            //        }
            //    }
            //    else
            //    {
            //        if (!printGroup)
            //            xrTableCellUOM.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                                                  | DevExpress.XtraPrinting.BorderSide.Right
            //                                                  | DevExpress.XtraPrinting.BorderSide.Top
            //                                                  | DevExpress.XtraPrinting.BorderSide.Bottom;
            //        else
            //            xrTableCellUOM.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                                             | DevExpress.XtraPrinting.BorderSide.Right
            //                                             | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    }
            //}
            //else
            //{
            //    if (!printGroup)
            //        xrTableCellUOM.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                            | DevExpress.XtraPrinting.BorderSide.Right
            //                            | DevExpress.XtraPrinting.BorderSide.Top
            //                            | DevExpress.XtraPrinting.BorderSide.Bottom;
            //    else
            //        xrTableCellUOM.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                                             | DevExpress.XtraPrinting.BorderSide.Right
            //                                             | DevExpress.XtraPrinting.BorderSide.Bottom;
            //}


            //if (RowNo % RecPerPage == 0)
            //    xrTableCellUOM.Borders = DevExpress.XtraPrinting.BorderSide.Left
            //                                             | DevExpress.XtraPrinting.BorderSide.Right
            //                                             | DevExpress.XtraPrinting.BorderSide.Top
            //                                             | DevExpress.XtraPrinting.BorderSide.Bottom;
            if (RowNo % RecPerPage == 0)
                xrTableCellUOM.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                                         | DevExpress.XtraPrinting.BorderSide.Right
                                                         | DevExpress.XtraPrinting.BorderSide.Top
                                                         | DevExpress.XtraPrinting.BorderSide.Bottom;
            else
            {
                if (!printGroup && !newPage)
                    xrTableCellUOM.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                                            | DevExpress.XtraPrinting.BorderSide.Right
                                                            | DevExpress.XtraPrinting.BorderSide.Top;
                else
                    xrTableCellUOM.Borders = DevExpress.XtraPrinting.BorderSide.Left
                                                       | DevExpress.XtraPrinting.BorderSide.Right;

                if (this.CurrentRowIndex == LastRec)
                {
                    xrTableCellUOM.Borders = xrTableCellUOM.Borders | DevExpress.XtraPrinting.BorderSide.Bottom;
                }
                if (RowNo == 1)
                {
                    xrTableCellUOM.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right;
                }
            }
        }

        private void xrTableCellInvoiceNo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.CurrentRowIndex != 0 && Invoice == xrTableCellInvoiceNo.Text && NoRec == CurrentNo && show)
            {
                xrTableCellInvoiceNo.Text = string.Empty;
            }
            else
            {
                Invoice = xrTableCellInvoiceNo.Text;
            }
        }

        private void xrTableCellProductCode_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.CurrentRowIndex != 0 && ProductCode == xrTableCellProductCode.Text && NoRec == CurrentNo && show)
            {
                xrTableCellProductCode.Text = string.Empty;
            }
            else
            {
                ProductCode = xrTableCellProductCode.Text;
            }
        }

        private void xrTableCellProductName_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.CurrentRowIndex != 0 && ProductName == xrTableCellProductName.Text && NoRec == CurrentNo && show)
            {
                xrTableCellProductName.Text = string.Empty;
            }
            else
            {
                ProductName = xrTableCellProductName.Text;
            }
        }

        private void xrTableCellLocation_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.CurrentRowIndex != 0 && ReceiveDate == xrTableCellLocation.Text && NoRec == CurrentNo && show)
            {
                xrTableCellLocation.Text = string.Empty;
            }
            else
            {
                ReceiveDate = xrTableCellLocation.Text;
            }
        }

        private void xrTableCellDeliveryDate_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.CurrentRowIndex != 0 && DeleveryDate == xrTableCellDeliveryDate.Text && NoRec == CurrentNo && show)
            {
                xrTableCellDeliveryDate.Text = string.Empty;
            }
            else
            {
                DeleveryDate = xrTableCellDeliveryDate.Text;
            }
        }

        private void GroupFooter2_AfterPrint(object sender, EventArgs e)
        {
        }

        private void xrTableCell8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            if (RowNo != 0 && RowNo % RecPerPage == 0)
            {
                Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
                newPage = true;
            }
            else
            {
                Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.None;
                newPage = false;
            }
            RowNo++;
            CurrentRow++;
        }

        private void xrTableCellUOM_AfterPrint(object sender, EventArgs e)
        {
            printGroup = false;
        }

        
        #endregion

        #region Generic Function
        public void SubReportDatasource(object source)
        {
            //rptRPT013_ShippingDeliveryReport_SubReport1.DataSource = source;

        }
        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }
        
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using CSI.Business.DataObjects;
using DevExpress.XtraReports.UI;
using System.Linq;
using Rubix.Framework;

namespace Rubix.Screen.Report
{
    public partial class rptRPT035_PackingInstruction : Base.BaseReport
    {
        #region member
        decimal? Palletize = 0;
        decimal? Prepare = 0;
        decimal? Packing = 0;

        #endregion

        #region Constructor

        public rptRPT035_PackingInstruction()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
        }

        public rptRPT035_PackingInstruction(List<ReportDefaultParam> rptParams)
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
            xrSubReport.ReportSource.DataSource = source;

            //List<sp_RPT035_PackingInstruction_GetData_Result> lst = (List<sp_RPT035_PackingInstruction_GetData_Result>)(this.DataSource);
            //xrLabel10.Text = Convert.ToInt32(lst.Select(c => c.PlanQty).Distinct().Sum()).ToString("#,##0");
        }
        #endregion

        #region Envent Handler
        private void xrSumPCSBox_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!this.GetCurrentColumnValue("ProductTypeID").Equals("2"))
            {
                List<sp_RPT035_PackingInstruction_GetData_Result> lst = (List<sp_RPT035_PackingInstruction_GetData_Result>)(this.DataSource);
                xrSumPCSBox.Text = Convert.ToInt32(lst.Select(c => new { c.PartCode, c.TotalBox }).Distinct().Select(c => c.TotalBox).Sum()).ToString("#,##0");
            }
            else
            {
                List<sp_RPT035_PackingInstruction_GetData_Result> lst = (List<sp_RPT035_PackingInstruction_GetData_Result>)(this.DataSource);
                xrSumPCSBox.Text = Convert.ToInt32(lst.Select(c => new { c.PartCode, c.TotalBox }).Distinct().Select(c => c.TotalBox)).ToString("#,##0");
            }
        }

        private void xrSumOrderQty_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!this.GetCurrentColumnValue("ProductTypeID").Equals("2"))
            {
                List<sp_RPT035_PackingInstruction_GetData_Result> lst = (List<sp_RPT035_PackingInstruction_GetData_Result>)(this.DataSource);
                xrSumOrderQty.Text = Convert.ToInt32(lst.Select(c => new { c.PartCode, c.PlanQty }).Distinct().Select(c => c.PlanQty).Sum()).ToString("#,##0");
            }
            else
            {
                List<sp_RPT035_PackingInstruction_GetData_Result> lst = (List<sp_RPT035_PackingInstruction_GetData_Result>)(this.DataSource);
                xrSumOrderQty.Text = Convert.ToInt32(lst.Select(c => new { c.PartCode, c.PlanQty }).Distinct().Select(c => c.PlanQty)).ToString("#,##0");
            }
        }

        private void xrSumPackedQty_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!this.GetCurrentColumnValue("ProductTypeID").Equals("2"))
            {
                List<sp_RPT035_PackingInstruction_GetData_Result> lst = (List<sp_RPT035_PackingInstruction_GetData_Result>)(this.DataSource);
                xrSumPackedQty.Text = Convert.ToInt32(lst.Select(c => new { c.PartCode, c.PackedQty }).Distinct().Select(c => c.PackedQty).Sum()).ToString("#,##0");
            }
            else
            {
                List<sp_RPT035_PackingInstruction_GetData_Result> lst = (List<sp_RPT035_PackingInstruction_GetData_Result>)(this.DataSource);
                xrSumPackedQty.Text = Convert.ToInt32(lst.Select(c => new { c.PartCode, c.PackedQty }).Distinct().Select(c => c.PackedQty)).ToString("#,##0");
            }
        }
        
        private void xrSumWeight_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!this.GetCurrentColumnValue("ProductTypeID").Equals("2"))
            {
                List<sp_RPT035_PackingInstruction_GetData_Result> lst = (List<sp_RPT035_PackingInstruction_GetData_Result>)(this.DataSource);
                xrSumWeight.Text = Convert.ToDecimal(lst.Select(c => new { c.PartCode, c.Weight }).Distinct().Select(c => c.Weight).Sum()).ToString("#,##0.0000");
            }
            else
            {
                List<sp_RPT035_PackingInstruction_GetData_Result> lst = (List<sp_RPT035_PackingInstruction_GetData_Result>)(this.DataSource);
                xrSumWeight.Text = Convert.ToDecimal(lst.Select(c => new { c.PartCode, c.Weight }).Distinct().Select(c => c.Weight)).ToString("#,##0.0000");
            }
        }

        private void xrTableCell43_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!this.GetCurrentColumnValue("ProductTypeID").Equals("2"))
            {
                List<sp_RPT035_PackingInstruction_GetData_Result> lst = (List<sp_RPT035_PackingInstruction_GetData_Result>)(this.DataSource);
                xrTableCell43.Text = Convert.ToDecimal(lst.Select(c => new { c.PartCode, c.PickedQty }).Distinct().Select(c => c.PickedQty).Sum()).ToString("#,##0");
            }
            else
            {
                List<sp_RPT035_PackingInstruction_GetData_Result> lst = (List<sp_RPT035_PackingInstruction_GetData_Result>)(this.DataSource);
                xrTableCell43.Text = Convert.ToDecimal(lst.Select(c => new { c.PartCode, c.PickedQty }).Distinct().Select(c => c.PickedQty)).ToString("#,##0");
            }
        }

        private void xrTableCell16_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = Math.Floor((double)Packing).ToString(); 
        }

        private void xrTableCellProductCode_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.CurrentRowIndex != 0
                    && (Convert.ToString(GetCurrentColumnValue("PartCode")) == Convert.ToString(GetPreviousColumnValue("PartCode"))))
            {
                xrTableCellPlanQty.ProcessDuplicates = ValueSuppressType.Suppress;
                xrTableCellPackQty.ProcessDuplicates = ValueSuppressType.Suppress;
                //xrTableCellPackRemain.ProcessDuplicates = ValueSuppressType.Suppress;
            }
            else
            {
                xrTableCellPlanQty.ProcessDuplicates = ValueSuppressType.Leave;
                xrTableCellPackQty.ProcessDuplicates = ValueSuppressType.Leave;
                //xrTableCellPackRemain.ProcessDuplicates = ValueSuppressType.Leave;
            }
        }
        #endregion

        private void xrLabel83_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double second = 0;
            decimal? total = Prepare + Packing + Palletize;
            if (total.HasValue)
            {
                second = Math.Floor(((((double)total - Math.Floor((double)total)) * 100) * 60) / 100);
            }

            if (total != null)
            {
                double hour = Math.Floor((double)total / 60);
                double min = Math.Floor((double)total % 60);
                string hourtxt = (hour != 0) ? hour.ToString() + " hrs. " : "";
                string mintxt = (min != 0) ? min.ToString() + " mins. " : "";
                string sectxt = (second != 0) ? second.ToString() + " sec. " : "";
                ((XRLabel)sender).Text = hourtxt + mintxt + sectxt;
            }
            
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!this.GetCurrentColumnValue("ProductTypeID").Equals(2))
            {
                Packing += DataUtil.Convert<decimal>(this.GetCurrentColumnValue("PackingTime")) * DataUtil.Convert<decimal>(this.GetCurrentColumnValue("TotalBox"));
            }
            else
            {
                if (this.CurrentRowIndex > 0)
                {
                    xrTableCell1.Visible = false;
                    xrTableCellProductCode.Visible = false;
                    xrTableCell4.Visible = false;
                    xrTableCellPlanQty.Visible = false;
                    xrTotalBox.Visible = false;
                    xrTableCell42.Visible = false;
                    xrTableCellPackQty.Visible = false;
                    xrTableCell9.Visible = false;
                    txtCTime.Visible = false;
                    xrTableCell10.Visible = false;
                }
                xrLine2.Visible = false;
                Packing = DataUtil.Convert<decimal>(this.GetCurrentColumnValue("PackingTime")) * DataUtil.Convert<decimal>(this.GetCurrentColumnValue("TotalBox"));
            }
            Prepare = DataUtil.Convert<decimal>(this.GetCurrentColumnValue("PrepareTime"));
            Palletize = DataUtil.Convert<decimal>(this.GetCurrentColumnValue("PalletizeTime")); 
        }

        private void xrLabel81_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double second = 0;
            decimal? total = Prepare;
            if (total.HasValue)
            {
                second = Math.Floor(((((double)Prepare - Math.Floor((double)Prepare)) * 100) * 60) / 100);
            }
            if (Prepare != null)
            {
                double hour = Math.Floor((double)Prepare / 60);
                double min = Math.Floor((double)Prepare % 60);
                string hourtxt = (hour != 0) ? hour.ToString() + " hrs. " : "";
                string mintxt = (min != 0) ? min.ToString() + " mins. " : "";
                string sectxt = (second != 0) ? second.ToString() + " sec. " : ""; 
                ((XRLabel)sender).Text = hourtxt + mintxt + sectxt;
            }
        }

        private void xrLabel82_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double second = 0;
            decimal? total = Packing;
            if (total.HasValue)
            {
                second = Math.Floor(((((double)Packing - Math.Floor((double)Packing)) * 100) * 60) / 100);
            }

            if (Packing != null)
            {
                double hour = Math.Floor((double)Packing / 60);
                double min = Math.Floor((double)Packing % 60);
                string hourtxt = (hour != 0) ? hour.ToString() + " hrs. " : "";
                string mintxt = (min != 0) ? min.ToString() + " mins. " : "";
                string sectxt = (second != 0) ? second.ToString() + " sec. " : "";
                ((XRLabel)sender).Text = hourtxt + mintxt + sectxt;
            }
        }

        private void xrLabel85_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double second = 0;
            decimal? total = Prepare + Packing + Palletize;
            if (total.HasValue)
            {
                second = Math.Floor(((((double)Palletize - Math.Floor((double)Palletize)) * 100) * 60) / 100);
            }

            if (Palletize != null)
            {
                double hour = Math.Floor((double)Palletize / 60);
                double min = Math.Floor((double)Palletize % 60);
                string hourtxt = (hour != 0) ? hour.ToString() + " hrs. " : "";
                string mintxt = (min != 0) ? min.ToString() + " mins. " : "";
                string sectxt = (second != 0) ? second.ToString() + " sec. " : "";
                ((XRLabel)sender).Text = hourtxt + mintxt + sectxt;
            }
        }

    }
}

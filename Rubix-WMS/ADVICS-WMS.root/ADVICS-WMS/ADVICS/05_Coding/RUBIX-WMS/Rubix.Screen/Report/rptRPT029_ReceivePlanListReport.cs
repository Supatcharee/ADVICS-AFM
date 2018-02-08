using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using CSI.Business.DataObjects;
using System.Data;
using System.Text;


namespace Rubix.Screen.Report
{
    public partial class rptRPT029_ReceivePlanListReport : Base.BaseReport
    {
        #region Member
        DataTable m_TransportationTable;
        private String receiveNo, invoiceNo, supplier, truckcompany, transportationType, arrivalDate;
        private const int RecordPerPage = 27;
        private int CurrentRecordOnPage;

        List<sp_RPT029_ReceivePlanList_SubReport_GetData_Result> listSubReport; 
        #endregion

        #region Constructor
        public rptRPT029_ReceivePlanListReport()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
            m_TransportationTable = new DataTable("m_TransportationTable");
            m_TransportationTable.Columns.Add("Code", typeof(string));
            m_TransportationTable.Columns.Add("Count", typeof(Int32));
            receiveNo = string.Empty;
            invoiceNo = string.Empty;
            supplier = string.Empty;
            truckcompany = string.Empty;
            transportationType = string.Empty;
            listSubReport = new List<sp_RPT029_ReceivePlanList_SubReport_GetData_Result>();
            CurrentRecordOnPage = 0;
        }

        public rptRPT029_ReceivePlanListReport(List<ReportDefaultParam> rptParams)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox1);
            m_TransportationTable = new DataTable("m_TransportationTable");
            m_TransportationTable.Columns.Add("Code", typeof(string));
            m_TransportationTable.Columns.Add("Count", typeof(Int32));
            receiveNo = string.Empty;
            invoiceNo = string.Empty;
            supplier = string.Empty;
            truckcompany = string.Empty;
            transportationType = string.Empty;
            listSubReport = new List<sp_RPT029_ReceivePlanList_SubReport_GetData_Result>();
            CurrentRecordOnPage = 0;
        } 
        #endregion

        #region Event Handler Function
        private void Detail_AfterPrint(object sender, EventArgs e)
        {
        }

        private void xrTableCellTrasportation_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }

        private void xrTableCell15_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            CurrentRecordOnPage++;
            if (this.CurrentRowIndex != 0
                  && xrTableCell15.Text == receiveNo
                 )
            {
                xrTableCell15.Text = string.Empty;
            }
            else
            {
                receiveNo = xrTableCell15.Text;
            }

            if (CurrentRecordOnPage % RecordPerPage == 0 && this.CurrentRowIndex != 0)
            {
                xrTableCell15.Borders = DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Right
                    | DevExpress.XtraPrinting.BorderSide.Bottom;
                xrTableCell16.Borders = DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Right
                    | DevExpress.XtraPrinting.BorderSide.Bottom;
                xrTableCell17.Borders = DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Right
                    | DevExpress.XtraPrinting.BorderSide.Bottom;
                xrTableCell18.Borders = DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Right
                    | DevExpress.XtraPrinting.BorderSide.Bottom;
                xrTableCell19.Borders = DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Right
                    | DevExpress.XtraPrinting.BorderSide.Bottom;
            }
            else
            {
                xrTableCell15.Borders = DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Right;
                xrTableCell16.Borders = DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Right;
                xrTableCell17.Borders = DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Right;
                xrTableCell18.Borders = DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Right;
                xrTableCell19.Borders = DevExpress.XtraPrinting.BorderSide.Left
                | DevExpress.XtraPrinting.BorderSide.Right;
            }
        }

        private void xrTableCell16_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.CurrentRowIndex != 0
                  && xrTableCell16.Text == invoiceNo
                 )
            {
                xrTableCell16.Text = string.Empty;
            }
            else
            {
                invoiceNo = xrTableCell16.Text;
            }
        }

        private void xrTableCell17_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.CurrentRowIndex != 0
                 && xrTableCell17.Text == supplier
                )
            {
                xrTableCell17.Text = string.Empty;

            }
            else
            {
                supplier = xrTableCell17.Text;
            }
        }

        private void xrTableCell18_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (this.CurrentRowIndex != 0
                  && xrTableCell18.Text == truckcompany
                 )
            {
                xrTableCell18.Text = string.Empty;

            }
            else
            {
                truckcompany = xrTableCell18.Text;
            }
        }

        private void xrLabel1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            String text = String.Empty;
            StringBuilder strBuilder = new StringBuilder();
            //if (m_TransportationTable.Rows.Count != 0)
            //{
            //    foreach (DataRow row in m_TransportationTable.Rows)
            //    {
            //        text = text + row["Code"] + row["Count"] + "\n";

            //    }
            //    strBuilder.Append(text);
            //    m_TransportationTable.Rows.Clear();
            //}
            foreach (sp_RPT029_ReceivePlanList_SubReport_GetData_Result item in listSubReport)
            {
                if (item.ArrivalDate.ToString() == arrivalDate)
                {
                    text = item.ContainerNoList;
                    text = text.Replace(',', '\n');
                    strBuilder.Append(text);
                }
            }
            xrLabel1.Text = strBuilder.ToString();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            supplier = string.Empty;
        }

        private void xrLabel6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //arrivalDate = xrLabel6.Text;
        }


        private void xrTableCell19_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            StringBuilder strBuilder = new StringBuilder();
            String contrainNo = xrTableCell19.Text;
            contrainNo = contrainNo.Replace('+', '\n');
            strBuilder.Append(contrainNo);
            xrTableCell19.Text = strBuilder.ToString();
            if (this.CurrentRowIndex != 0
                 && xrTableCell19.Text == transportationType
                )
            {
                xrTableCell19.Text = string.Empty;
            }
            else
            {
                transportationType = xrTableCell19.Text;
            }
        }

        private void xrTableCell14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            CurrentRecordOnPage++;
        }

        private void xrTableCell28_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            CurrentRecordOnPage++;
        }

        private void xrTableCell43_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            CurrentRecordOnPage++;
        } 
        #endregion

        #region Generic Function
        public void SetSubReport(object source)
        {
            listSubReport = (List<sp_RPT029_ReceivePlanList_SubReport_GetData_Result>)source;
        }

        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }

        public void SetChartReport(object source)
        {
            bindingSource1.DataSource = source;
        } 
        #endregion

   
    }
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using System.Collections.Generic;
using DevExpress.XtraCharts;

namespace Rubix.Screen.Report
{
    public partial class rptRPT024_MovementReport_Chart : Base.BaseReport
    {
        #region Constructor
        public rptRPT024_MovementReport_Chart()
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
        }
        public rptRPT024_MovementReport_Chart(List<ReportDefaultParam> rptParams, int isMonthly)
            : base(rptParams)
        {
            InitializeComponent();
            SetImageLogoReport(xrPictureBox2);
            DevExpress.XtraCharts.XYDiagram diagram = (XYDiagram)this.xrChart1.Diagram;
            if (isMonthly == 1)
            {
                diagram.AxisX.DateTimeOptions.Format = DevExpress.XtraCharts.DateTimeFormat.MonthAndYear;
                diagram.AxisX.DateTimeGridAlignment = DateTimeMeasurementUnit.Month;
                diagram.AxisX.DateTimeMeasureUnit = DateTimeMeasurementUnit.Month;
            }
            else
            {
                //diagram.AxisX.DateTimeOptions.Format = DevExpress.XtraCharts.DateTimeFormat.Custom;
                diagram.AxisX.DateTimeGridAlignment = DateTimeMeasurementUnit.Day;
                diagram.AxisX.DateTimeMeasureUnit = DateTimeMeasurementUnit.Day;
            }
        } 
        #endregion

        #region Generic Function
        public void SetParameterReport(string parameterName, object val)
        {
            this.Parameters[parameterName].Value = val;
        }
        public void SetChartReport(object source)
        {
            xrChart1.DataSource = source;

            xrChart1.Series[0].DataSource = source;
            xrChart1.Series[1].DataSource = source;

            xrChart1.Series[2].DataSource = source;

        }      
        #endregion

       
    }
}

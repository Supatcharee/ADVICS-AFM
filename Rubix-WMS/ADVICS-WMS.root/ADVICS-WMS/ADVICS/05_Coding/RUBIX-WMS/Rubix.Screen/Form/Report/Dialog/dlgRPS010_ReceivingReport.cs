using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSI.Business.Operation;
using CSI.Business.DataObjects;
using Rubix.Framework;
using CSI.Business.BusinessFactory.Report;
using DevExpress.XtraReports.UI;

namespace Rubix.Screen.Form.Report.Dialog
{
    public partial class dlgRPS010_ReceivingReport : DialogBase
    {
        #region Member
        private ReceivingReport db = null;
        #endregion

        #region Properties
        public List<sp_RPT001_ReceivingReport_SearchAll_Result> DataSource { get; set; }
        public ReceivingReport BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ReceivingReport();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new ReceivingReport();
                }
                db = value;
            }
        }
        #endregion

        #region Constructor
        public dlgRPS010_ReceivingReport()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(false, m_toolBarPrint);
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarClear, m_toolBarClose);
            ControlUtil.HiddenControl(true, m_statusBar);
        }
        #endregion

        #region Event Handler Function
        public override bool OnCommandPrint()
        {
            XtraReport rpt = null;
            foreach (sp_RPT001_ReceivingReport_SearchAll_Result data in DataSource)
            {
                List<sp_RPT001_ReceivingReport_GetData_Result> tempReport = BusinessClass.GetDataReport(data.ReceivingNo);
                if (tempReport.Count > 0)
                {
                    SetAttention(tempReport);
                    
                    List<sp_RPT001_ReceivingReport_GetData_Result> tempSubReport =
                        BusinessClass.GetDataSubReport(tempReport);

                    Rubix.Screen.Report.rptRPT001_ReceivingReport report = new Rubix.Screen.Report.rptRPT001_ReceivingReport(BusinessClass.GetReportDefaultParams("RPT001"));
                    report.SetParameterReport("PrintBy", AppConfig.Name);
                    report.DataSource = tempReport;
                    report.SetTotalRecord(tempReport.Count);
                    report.SetSubReport(tempSubReport);
                    if (rpt != null)
                    {
                        ReportUtil.CombineReport(rpt, report);
                    }
                    else
                    {
                        rpt = report;
                    }
                }
            }

            if (rpt != null)
            {
                ReportUtil.ShowPreview(rpt);
            }
            else
            {
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0170")); //หน้า Dialog นี้ผ่านการ search จาก หน้าหลักแล้ว ต้องใช้ msg นี้ 
            }

            return true;
        }

        private void dlgRPS010_ReceivingReport_Load(object sender, EventArgs e)
        {
            try
            {
                attentionControl.DistinctOwnerIDs = BusinessClass.GetDistinctOwnerID(DataSource);
                attentionControl.DataLoading();
            }
            catch (Exception ex)
            {                
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        #endregion

        #region Generic Function
        private void SetAttention(List<sp_RPT001_ReceivingReport_GetData_Result> list)
        {
            // get selected attention
            Dictionary<int?, List<string>> selectedAttention = attentionControl.AttentionList;

            foreach(sp_RPT001_ReceivingReport_GetData_Result data in list)
            {
                // set selected attention 
                List<string> attentions = new List<string>();
                selectedAttention.TryGetValue(data.OwnerID, out attentions);
                data.Attention = string.Join(",", attentions.ToArray());
            }
        }
        #endregion
    }
}
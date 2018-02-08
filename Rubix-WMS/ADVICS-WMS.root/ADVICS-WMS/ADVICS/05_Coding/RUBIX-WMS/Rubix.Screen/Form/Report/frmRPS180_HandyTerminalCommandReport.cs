using System;
using System.Collections.Generic;
using Rubix.Framework;
using Rubix.Screen.Report;
using CSI.Business.BusinessFactory.Report.Base;
using CSI.Business.Report;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Form.Report
{
    [ScreenPermissionAttribute(Permission.OpenScreen)]
    public partial class frmRPS180_HandyTerminalCommandReport : FormBase
    {
        #region Member
        BaseReport baseReport = null;
        #endregion

        #region Properties
        private BaseReport BusinessClass
        {
            get
            {
                if (baseReport == null)
                {
                    baseReport = new BaseReport();
                }
                return baseReport;
            }
        }
        #endregion

        #region Constructor
        public frmRPS180_HandyTerminalCommandReport()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarCancel, m_toolBarDelete, m_toolBarEdit, m_toolBarExport, m_toolBarRefresh, m_toolBarSave, m_toolBarView);
            ControlUtil.HiddenControl(true, m_toolBarPaintStyls, m_toolBarThemeStyls);            
        }
        #endregion
        
        #region Event Handler Function
        private void frmRPS180_HandyTerminalCommandReport_Load(object sender, EventArgs e)
        {

        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdoHandy.Checked)
                {
                    rptRPT031_HandyTerminalCommand rpt = new rptRPT031_HandyTerminalCommand(BusinessClass.GetReportDefaultParams("RPT310"));
                    ReportUtil.ShowPreview(rpt);
                }
                else if (rdoPackingCommand.Checked)
                {
                    rptRPT046_PackingCommandInstruction rpt = new rptRPT046_PackingCommandInstruction(BusinessClass.GetReportDefaultParams("RPT046"));
                    ReportUtil.ShowPreview(rpt);
                }
                else
                {
                    LabelStickerReport Database = new LabelStickerReport();
                    List<sp_RPT046_UserStickerLaber_GetData_Result> tempReport = Database.GetUserStickerLaberReport();                    
                    rptRPT046_UserStickerLabel rpt = new rptRPT046_UserStickerLabel(BusinessClass.GetReportDefaultParams("RPT046"));
                    rpt.DataSource = tempReport;
                    ReportUtil.ShowPreview(rpt);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
        #endregion

        private void frmRPS180_HandyTerminalCommandReport_Load_1(object sender, EventArgs e)
        {

        }
          
        #region Generic Function

        #endregion

    }
}

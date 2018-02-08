using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using CSI.Business.BusinessFactory.Report;
using CSI.Business.DataObjects;
using Rubix.Screen.Report;
using System.Linq;
namespace Rubix.Screen.Form.Report
{
    [ScreenPermissionAttribute(Permission.OpenScreen)]
    public partial class frmRPS100_InventoryUsageReport : FormBase
    {
        #region Member
        private InventoryUsageReport db;
        const string DATE_EDIT_FORMAT = "dd/MM/yyyy";
        #endregion

        #region Properties
        private InventoryUsageReport BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new InventoryUsageReport();
                }
                return db;
            }
        }
        #endregion

        #region Constructor
        public frmRPS100_InventoryUsageReport()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarCancel, m_toolBarDelete, m_toolBarEdit, m_toolBarExport, m_toolBarRefresh, m_toolBarSave, m_toolBarView);
            ControlUtil.HiddenControl(true, m_toolBarPaintStyls, m_toolBarThemeStyls);
            foreach (System.Windows.Forms.Control ctrl in this.groupControl3.Controls)
            {
                if (ctrl is DateEdit)
                {
                    DateEdit de = (DateEdit)ctrl;
                    de.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
                    de.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    de.Properties.EditFormat.FormatString = Common.FullDateFormat;
                    de.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    de.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    de.Properties.Mask.EditMask = Common.FullDateFormat;
                }
            }
        }
        #endregion

        #region Event Handler Function

        private void frmRPS100_InventoryUsageReport_Load(object sender, EventArgs e)
        {

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int? WarehouseID;
                string WarehouseName;
                int? OwnerID;
                String OwnerName;

                Cursor.Current = Cursors.WaitCursor;
                if (!ValidateData())
                {
                    WarehouseID = warehouseControl.WarehouseID;
                    WarehouseName = warehouseControl.WarehouseName;
                    OwnerName = ownerControl.OwnerName;
                    OwnerID = ownerControl.OwnerID;
                    ////report by Table
                    if (chkTable.Checked == true)
                    {
                        List<sp_RPT025_InventoryUsageReport_GetData_Result> tempReport = BusinessClass.GetDataReport(WarehouseID, OwnerID);

                        if (tempReport.Count > 0)
                        {
                            List<sp_RPT025_InventoryUsageReport_GetData_Sub_Report_Result> tempSubReport = BusinessClass.GetSubReport(WarehouseID, OwnerID);
                            rptRPT025_InventoryUsageReport rcvInstr = new rptRPT025_InventoryUsageReport(BusinessClass.GetReportDefaultParams("RPT025"));
                            rcvInstr.DataSource = tempReport;

                            rcvInstr.SetParameterReport("WarehouseName", WarehouseName);
                            rcvInstr.SetParameterReport("OwnerName", ownerControl.OwnerName);
                            rcvInstr.SetParameterReport("PrintBy", AppConfig.Name);
                            rcvInstr.SubReportDatasource(tempSubReport);
                            ReportUtil.ShowPreview(rcvInstr);
                        }
                        else
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                        }
                    }

                    //report by zone

                    if (chkGraph.Checked == true)
                    {
                        List<sp_RPT026_InventoryUsageReport_Chart_GetData_Result> tempReport = BusinessClass.GetDataChartReport(WarehouseID, OwnerID);
                        if (tempReport.Count > 0)
                        {
                            DevExpress.XtraReports.UI.XtraReport report = new DevExpress.XtraReports.UI.XtraReport();

                            foreach (int iWarehouseID in tempReport.Select(c => c.WarehouseID).Distinct())
                            {
                                rptRPT026_InventoryUsageReport_Chart rcvInstr = new rptRPT026_InventoryUsageReport_Chart(BusinessClass.GetReportDefaultParams("RPT026"));
                                rcvInstr.DataSource = tempReport.Where(c => c.WarehouseID == iWarehouseID).ToList();
                                rcvInstr.SetParameterReport("WarehouseName", tempReport.Where(c => c.WarehouseID == iWarehouseID).FirstOrDefault().WarehouseName);
                                rcvInstr.SetParameterReport("OwnerName", ownerControl.OwnerName);
                                rcvInstr.SetParameterReport("PrintBy", AppConfig.Name);
                                rcvInstr.SetChartReport(rcvInstr.DataSource);
                                ReportUtil.CombineReport(report, rcvInstr);
                            }

                            ReportUtil.ShowPreview(report);
                        }
                        else
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                        }
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            warehouseControl.ClearData();
            chkGraph.Checked = false;
            chkTable.Checked = false;
            SetMovementDate();
            dxErrorProviderMovement.ClearErrors();
            //dxErrorProviderMovement.SetError(dpkMovementDate, String.Empty);
            errorProvider.ClearErrors();
        }
        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            warehouseControl.OwnerID = ownerControl.OwnerID;
            warehouseControl.DataLoading();
        }


        #endregion

        #region Generic Function

        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            bool choosedReport = true;
            // clear all error
            errorProvider.ClearErrors();

            // set require field
            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;
            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            #region Distribution Center
            //Distribution Center
            if (!warehouseControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(warehouseControl, String.Empty);
            }
            #endregion
            
            #region Customer

            if (ownerControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(ownerControl, String.Empty);
            }
            #endregion

            if (chkGraph.Checked == false && chkTable.Checked == false)
            {
                choosedReport = false;
            }
            if (false == choosedReport)
            {
                //MessageDialog.ShowBusinessErrorMsg(this, "Please select at least one report.");
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0211"));
            }

            return errFlag;
        }

        private void SetMovementDate()
        {
            //DateTime yesterday;
            //List<DateTime?> listDate = BusinessClass.GetMaxDailyPostDate();
            //if (listDate != null && listDate.Count != 0)
            //{
            //    yesterday = DateTime.Parse(listDate[0].ToString());
            //}
            //else
            //{
            //    yesterday = DateTime.Today.AddDays(-1);

            //}
            //dpkMovementDate.DateTime = yesterday;
        }

        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using CSI.Business.DataObjects;
using CSI.Business.BusinessFactory.Report;
using Rubix.Screen.Report;
namespace Rubix.Screen.Form.Report
{
    [ScreenPermissionAttribute(Permission.OpenScreen)]
    public partial class frmRPS050_MovementReport : FormBase
    {

        #region Member
        private MovementReport db;
        #endregion

        #region Properties
        private MovementReport BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new MovementReport();
                }
                return db;
            }
        }
        #endregion

        #region Constructor
        public frmRPS050_MovementReport()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarCancel, m_toolBarDelete, m_toolBarEdit, m_toolBarExport, m_toolBarRefresh, m_toolBarSave, m_toolBarView);
            ControlUtil.HiddenControl(true, m_toolBarPaintStyls, m_toolBarThemeStyls);

            dtReceivedDateFrom.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtReceivedDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtReceivedDateFrom.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtReceivedDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtReceivedDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtReceivedDateFrom.Properties.Mask.EditMask = Common.FullDateFormat;

            dtReceivedDateTo.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtReceivedDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtReceivedDateTo.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtReceivedDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtReceivedDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtReceivedDateTo.Properties.Mask.EditMask = Common.FullDateFormat;
        }
        #endregion

        #region Event Handler Function
        private void frmRPS050_MovementReport_Load(object sender, EventArgs e)
        {
            chkGraph.Checked = false;
            chkTable.Checked = true;
            grpMode.Enabled = false;
            DateTime from = ControlUtil.GetStartDate();
            DateTime to = ControlUtil.GetEndDate();
            dtReceivedDateFrom.DateTime = from;
            dtReceivedDateTo.DateTime = to;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int? OwnerID, WarehouseID, productID;
                DateTime? dateFrom, dateTo;
                string OwnerName, WarehouseName, productName;
                Cursor.Current = Cursors.WaitCursor;
                if (ValidateData())
                {
                    OwnerID = ownerControl.OwnerID;
                    WarehouseID = warehouseControl.WarehouseID;
                    OwnerName = ownerControl.OwnerName;
                    WarehouseName = warehouseControl.WarehouseName;
                    dateFrom = dtReceivedDateFrom.DateTime;
                    dateTo = dtReceivedDateTo.DateTime;
                    productID = itemControl.ProductID;
                    productName = itemControl.ProductLongName == String.Empty ? "All Item" : itemControl.ProductLongName;

                    ////report by Table
                    if (chkTable.Checked == true)
                    {
                        List<sp_RPT023_MovementReport_GetData_Result> tempReport = BusinessClass.GetDataReport(OwnerID, WarehouseID, productID, dateFrom, dateTo);

                        if (tempReport.Count > 0)
                        {
                            //List<sp_RPT023_MovementReport_SubReport_GetData_Result> tempSubReport = BusinessClass.GetDataSubReport(OwnerID, WarehouseID, productID, dateFrom, dateTo);
                            rptRPT023_MovementReport rcvInstr = new rptRPT023_MovementReport(BusinessClass.GetReportDefaultParams("RPT023"));
                            rcvInstr.DataSource = tempReport;
                            rcvInstr.SetParameterReport("OwnerName", OwnerName);
                            rcvInstr.SetParameterReport("WarehouseName", WarehouseName);
                            rcvInstr.SetParameterReport("DateFrom", dateFrom);
                            rcvInstr.SetParameterReport("DateTo", dateTo);
                            rcvInstr.SetParameterReport("PrintBy", AppConfig.Name);
                            //rcvInstr.SubReportDatasource(tempSubReport);
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
                        int isMonthly = 0;
                        if (chkMonthly.Checked)
                            isMonthly = 1;
                        List<sp_RPT024_MovementReport_Chart_Result> tempReport = BusinessClass.GetChartReport(OwnerID, WarehouseID, productID, dateFrom, dateTo, isMonthly);


                        if (tempReport.Count > 0)
                        {
                            rptRPT024_MovementReport_Chart rcvInstr = new rptRPT024_MovementReport_Chart(BusinessClass.GetReportDefaultParams("RPT024"), isMonthly);
                            rcvInstr.DataSource = tempReport;
                            rcvInstr.SetParameterReport("OwnerName", OwnerName);
                            rcvInstr.SetParameterReport("WarehouseName", WarehouseName);
                            rcvInstr.SetParameterReport("ProductName", productName);
                            rcvInstr.SetParameterReport("DateFrom", String.Format("{0:dd/MM/yyyy}", dateFrom));
                            rcvInstr.SetParameterReport("DateTo", String.Format("{0:dd/MM/yyyy}", dateTo));
                            rcvInstr.SetParameterReport("PrintBy", AppConfig.Name);
                            rcvInstr.SetChartReport(tempReport);
                            ReportUtil.ShowPreview(rcvInstr);
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
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ControlUtil.ClearControlData(dtReceivedDateFrom
                                        , dtReceivedDateTo);
            ownerControl.ClearData();
            warehouseControl.ClearData();
            itemControl.ClearData();
            DateTime from = DateTime.Today.AddDays(1 - DateTime.Today.Day);
            DateTime to = DateTime.Today.AddMonths(1).AddDays(-DateTime.Today.Day);
            dtReceivedDateFrom.DateTime = from;
            dtReceivedDateTo.DateTime = to;
            chkGraph.Checked = false;
            chkTable.Checked = true;

            grpMode.Enabled = false;
        }

        private void chkGraph_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGraph.Checked)
                grpMode.Enabled = true;
            else
                grpMode.Enabled = false;
        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            warehouseControl.OwnerID = ownerControl.OwnerID;
            warehouseControl.DataLoading();
            itemControl.OwnerID = ownerControl.OwnerID;
            itemControl.DataLoading();
        }
        #endregion

        #region Generic Function

        private Boolean ValidateData()
        {
            Boolean errFlag = true;

            // clear all error
            errorProvider.ClearErrors();
            bool choosedReport = true;

            // set require field
            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;
            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            if (!ownerControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(ownerControl, String.Empty);
            }

            if (!warehouseControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(warehouseControl, String.Empty);
            }

            if (dtReceivedDateFrom.EditValue == null)
            {
                errorProvider.SetError(dtReceivedDateFrom, Common.GetMessage("I0265"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(dtReceivedDateFrom, String.Empty);
            }
            if (dtReceivedDateTo.EditValue == null)
            {
                errorProvider.SetError(dtReceivedDateTo, Common.GetMessage("I0266"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(dtReceivedDateTo, String.Empty);
            }
            
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

        #endregion

    }
}
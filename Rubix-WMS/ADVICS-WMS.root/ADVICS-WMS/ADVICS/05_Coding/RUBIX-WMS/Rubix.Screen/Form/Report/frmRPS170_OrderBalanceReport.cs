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
    public partial class frmRPS170_OrderBalanceReport : FormBase
    {
        #region Member
        private OrderBalanceReport db;
        #endregion

        #region Properties
        private OrderBalanceReport BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new OrderBalanceReport();
                }
                return db;
            }
        }
        #endregion

        #region Constructor
        public frmRPS170_OrderBalanceReport()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarCancel, m_toolBarDelete, m_toolBarEdit, m_toolBarExport, m_toolBarRefresh, m_toolBarSave, m_toolBarView);
            ControlUtil.HiddenControl(true, m_toolBarPaintStyls, m_toolBarThemeStyls);
            foreach (System.Windows.Forms.Control ctrl in this.grpEdit.Controls)
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

        #region Generic Function

        private Boolean ValidateData()
        {
            Boolean errFlag = true;

            // clear all error
            errorProvider.ClearErrors();
            //bool choosedReport = true;

            // set require field
            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;
            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            #region Customer
            //Customer 
            if (!ownerControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(ownerControl, String.Empty);
            }
            #endregion

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

            #region Date

            if (dteDateFrom.EditValue == null)
            {
                errorProvider.SetError(dteDateFrom, Common.GetMessage("I0265"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(dteDateFrom, String.Empty);
            }
            if (dteDateTo.EditValue == null)
            {
                errorProvider.SetError(dteDateTo, Common.GetMessage("I0266"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(dteDateTo, String.Empty);
            }
            #endregion


            return errFlag;
        }

        private void ClearData()
        {
            ControlUtil.ClearControlData(dteDateFrom
                                     , dteDateTo);
            ownerControl.ClearData();
            warehouseControl.ClearData();

            DateTime from = DateTime.Today.AddDays(1 - DateTime.Today.Day);
            DateTime to = DateTime.Today.AddMonths(1).AddDays(-DateTime.Today.Day);
            dteDateFrom.DateTime = from;
            dteDateTo.DateTime = to;
        }
        #endregion

        #region Event Handler Function
        private void frmRPS170_OrderBalanceReport_Load(object sender, EventArgs e)
        {
            ownerControl.RequireField = true;
            warehouseControl.RequireField = true;
            dteDateFrom.DateTime = ControlUtil.GetStartDate();
            dteDateTo.DateTime = ControlUtil.GetEndDate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int? OwnerID, WarehouseID;
                DateTime? dateFrom, dateTo;
                string OwnerName, WarehouseName;
                Cursor.Current = Cursors.WaitCursor;
                if (ValidateData())
                {
                    OwnerID = ownerControl.OwnerID;
                    WarehouseID = warehouseControl.WarehouseID;
                    OwnerName = ownerControl.OwnerName;
                    WarehouseName = warehouseControl.WarehouseName;
                    dateFrom = dteDateFrom.DateTime;
                    dateTo = dteDateTo.DateTime;

                    List<sp_RPT032_OrderBalance_GetData_Result> tempReport = BusinessClass.GetDataReport(OwnerID, WarehouseID, dateFrom, dateTo);
                    if (tempReport.Count > 0)
                    {
                        rptRPT014_OrderBalanceReport rcvInstr = new rptRPT014_OrderBalanceReport(BusinessClass.GetReportDefaultParams("RPT014"));
                        rcvInstr.DataSource = tempReport;
                        rcvInstr.SetChartReport(tempReport);
                        rcvInstr.SetParameterReport("OwnerName", OwnerName);
                        rcvInstr.SetParameterReport("WarehouseName", WarehouseName);
                        rcvInstr.SetParameterReport("PeriodFrom", dateFrom);
                        rcvInstr.SetParameterReport("PeriodTo", dateTo);
                        rcvInstr.SetParameterReport("PrintBy", AppConfig.Name);
                        ReportUtil.ShowPreview(rcvInstr);
                    }
                    else
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                    }
                }
                Cursor.Current = Cursors.Default;

            }
            catch (Exception ex)
            {
                if (ex.InnerException is System.Data.SqlClient.SqlException && ex.InnerException.Message.Contains("Timeout"))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0288"));
                }
                else
                {
                    MessageDialog.ShowSystemErrorMsg(this, ex);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            warehouseControl.OwnerID = ownerControl.OwnerID;
            warehouseControl.DataLoading();
        }

        #endregion

     
    }
}

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
    public partial class frmRPS160_SlowMovementReport : FormBase
    {
        #region Member
        private SlowMovementReport db;
        #endregion

        #region Properties
        private SlowMovementReport BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new SlowMovementReport();
                }
                return db;
            }
        }
        #endregion

        #region Constructor
        public frmRPS160_SlowMovementReport()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarCancel, m_toolBarDelete, m_toolBarEdit, m_toolBarExport, m_toolBarRefresh, m_toolBarSave, m_toolBarView);
            ControlUtil.HiddenControl(true, m_toolBarPaintStyls, m_toolBarThemeStyls);
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

            //Distribution Center
            if (!warehouseControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(warehouseControl, String.Empty);
            }

            #region Month-Year

            if (txtMonth.Text == String.Empty)
            {
                errorProvider.SetError(txtMonth, Common.GetMessage("I0326"));
                errFlag = false;
            }
            else if (Convert.ToInt32(txtMonth.Text) < 1 || Convert.ToInt32(txtMonth.Text) > 12)
            {
                errorProvider.SetError(txtMonth, Common.GetMessage("I0327"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtMonth, String.Empty);
            }

            if (txtYear.Text == String.Empty)
            {
                errorProvider.SetError(txtYear, Common.GetMessage("I0328"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtYear, String.Empty);
            }

            #endregion

            #region Period
            if (txtMonthPeriod1.Text == String.Empty || txtMonthPeriod1.Text == "0")
            {
                errorProvider.SetError(txtMonthPeriod1, Common.GetMessage("I0329"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtMonthPeriod1, String.Empty);
            }

            if (txtMonthPeriod2.Text == String.Empty || txtMonthPeriod2.Text == "0")
            {
                errorProvider.SetError(txtMonthPeriod2, Common.GetMessage("I0329"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtMonthPeriod2, String.Empty);
            }

            if (txtMonthPeriod3.Text == String.Empty || txtMonthPeriod3.Text == "0")
            {
                errorProvider.SetError(txtMonthPeriod3, Common.GetMessage("I0329"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtMonthPeriod3, String.Empty);
            }

            if (txtMonthPeriod4.Text == String.Empty || txtMonthPeriod4.Text == "0")
            {
                errorProvider.SetError(txtMonthPeriod4, Common.GetMessage("I0329"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtMonthPeriod4, String.Empty);
            }
            #endregion

            return errFlag;
        }

        private void ClearData()
        {
            ControlUtil.ClearControlData(txtMonth
                                     , txtYear
                                     , txtMonthPeriod1
                                     , txtMonthPeriod2
                                     , txtMonthPeriod3
                                     , txtMonthPeriod4);
            ownerControl.ClearData();
            warehouseControl.ClearData();
            txtMonth.Text = DateTime.Now.Month.ToString();
            txtYear.Text = DateTime.Now.Year.ToString();
            txtMonthPeriod1.Text = "0";
            txtMonthPeriod2.Text = "0";
            txtMonthPeriod3.Text = "0";
            txtMonthPeriod4.Text = "0";


        }
        #endregion

        #region Event Handler Function

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int? OwnerID, WarehouseID;
                DateTime dateMonthStart;
                string OwnerName, WarehouseName;
                Cursor.Current = Cursors.WaitCursor;
                if (ValidateData())
                {
                    OwnerID = ownerControl.OwnerID;
                    WarehouseID = warehouseControl.WarehouseID;
                    OwnerName = ownerControl.OwnerName;
                    WarehouseName = warehouseControl.WarehouseName;
                    dateMonthStart = new DateTime(Convert.ToInt32(txtYear.Text), Convert.ToInt32(txtMonth.Text), 1);

                    List<sp_RPT031_SlowMovement_GetData_Result> tempReport = BusinessClass.GetDataReport(OwnerID,
                        WarehouseID,
                        dateMonthStart,
                        Convert.ToInt32(txtMonthPeriod1.Text),
                        Convert.ToInt32(txtMonthPeriod2.Text),
                        Convert.ToInt32(txtMonthPeriod3.Text),
                        Convert.ToInt32(txtMonthPeriod4.Text));
                    if (tempReport.Count > 0)
                    {
                        rptRPT027_SlowMovementReport rcvInstr = new rptRPT027_SlowMovementReport(BusinessClass.GetReportDefaultParams("RPT027"));
                        rcvInstr.DataSource = tempReport;
                        rcvInstr.SetChartReport(tempReport);
                        rcvInstr.SetParameterReport("OwnerName", OwnerName);
                        if (string.IsNullOrWhiteSpace(WarehouseName))
                            rcvInstr.SetParameterReport("WarehouseName", "All");
                        else
                            rcvInstr.SetParameterReport("WarehouseName", WarehouseName);
                        rcvInstr.SetParameterReport("PrintBy", AppConfig.Name);
                        rcvInstr.SetParameterReport("Period1", txtMonthPeriod1.Text + " " + "Months");
                        rcvInstr.SetParameterReport("Period2", txtMonthPeriod2.Text + " " + "Months");
                        rcvInstr.SetParameterReport("Period3", txtMonthPeriod3.Text + " " + "Months");
                        rcvInstr.SetParameterReport("Period4", txtMonthPeriod4.Text + " " + "Months");
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

        private void frmRPS160_SlowMovementReport_Load(object sender, EventArgs e)
        {
            txtMonth.Text = DateTime.Now.Month.ToString();
            txtYear.Text = DateTime.Now.Year.ToString();
            txtMonthPeriod1.Text = "0";
            txtMonthPeriod2.Text = "0";
            txtMonthPeriod3.Text = "0";
            txtMonthPeriod4.Text = "0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearData();
        }


        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            warehouseControl.OwnerID = ownerControl.OwnerID;
            warehouseControl.DataLoading();
        }

        #endregion


    }
}

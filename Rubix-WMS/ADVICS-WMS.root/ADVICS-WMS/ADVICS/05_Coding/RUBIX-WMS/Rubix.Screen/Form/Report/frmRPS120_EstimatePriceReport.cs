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
    public partial class frmRPS120_EstimatePriceReport : FormBase
    {

        #region Member
        private EstimatePriceReport db;
        #endregion

        #region Properties
        private EstimatePriceReport BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new EstimatePriceReport();
                }
                return db;
            }
        }
        #endregion

        #region Constructor
        public frmRPS120_EstimatePriceReport()
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

        #region Generic Function

        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            // clear all error
            errorProvider.ClearErrors();
            bool choosedReport = false;

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
                errorProvider.SetError(ownerControl, String.Empty);
            }
            #endregion
            #region  Date
            //Unstaffing Charge Date
            if (dtDateFrom.EditValue == null)
            {
                errorProvider.SetError(dtDateFrom, Rubix.Screen.Common.GetMessage("I0265"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(dtDateFrom, String.Empty);
            }

            if (dtDateTo.EditValue == null)
            {
                errorProvider.SetError(dtDateTo, Rubix.Screen.Common.GetMessage("I0266"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(dtDateTo, String.Empty);
            }
            #endregion
            
            return errFlag;
        }

        private void SetDateToControl()
        {
            DateTime from = ControlUtil.GetStartDate();
            DateTime to = ControlUtil.GetEndDate();
            dtDateFrom.DateTime = from;
            dtDateTo.DateTime = to;
        }
        #endregion

        #region Event Handler
        private void btnClear_Click(object sender, EventArgs e)
        {
            ControlUtil.ClearControlData(this.Controls);
            errorProvider.ClearErrors();
            SetDateToControl();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int? OwnerID, WarehouseID;
                DateTime? date1, date2;
                string OwnerName, WarehouseName;
                Cursor.Current = Cursors.WaitCursor;
                if (ValidateData())
                {
                    OwnerID = ownerControl.OwnerID;
                    WarehouseID = warehouseControl.WarehouseID;
                    OwnerName = ownerControl.OwnerName;
                    WarehouseName = warehouseControl.WarehouseName;

                    #region Report
                    date1 = DataUtil.Convert<DateTime>(dtDateFrom.EditValue);
                    date2 = DataUtil.Convert<DateTime>(dtDateTo.EditValue);

                    List<sp_RPT012_EstimatePriceReport_GetData_Result> tempReport = BusinessClass.GetDataEstimatePriceReport(OwnerID, WarehouseID, date1, date2);
                    if (tempReport.Count > 0)
                    {
                        rptRPT012_EstimatePriceReport rpt = new rptRPT012_EstimatePriceReport(BusinessClass.GetReportDefaultParams("RPT012"));
                        rpt.DataSource = tempReport;
                        rpt.SetWarehouseName(WarehouseName);
                        rpt.SetFromDateParameter(date1);
                        rpt.SetToDateParameter(date2);
                        rpt.SetUserNameParameter(AppConfig.Name);
                        if (string.IsNullOrWhiteSpace(OwnerName))
                            OwnerName = "All";
                        rpt.SetOwnerNameParameter(OwnerName);
                        ReportUtil.ShowPreview(rpt);
                    }
                    else
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                    }
                    #endregion

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

        private void frmRPS120_EstimatePriceReport_Load(object sender, EventArgs e)
        {
            SetDateToControl();
        }
        
        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            warehouseControl.OwnerID = ownerControl.OwnerID;
            warehouseControl.DataLoading();
        }

        #endregion
    }
}
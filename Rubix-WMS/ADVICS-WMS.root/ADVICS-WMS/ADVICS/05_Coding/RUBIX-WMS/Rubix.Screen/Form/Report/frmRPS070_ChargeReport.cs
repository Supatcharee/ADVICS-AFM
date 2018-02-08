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
using System.Linq;

namespace Rubix.Screen.Form.Report
{
    [ScreenPermissionAttribute(Permission.OpenScreen)]
    public partial class frmRPS070_ChargeReport : FormBase
    {
        #region Member
        private ChargeReport db;
        #endregion

        #region Properties
        private ChargeReport BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ChargeReport();
                }
                return db;
            }
        }
        #endregion

        #region Constructor
        public frmRPS070_ChargeReport()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarCancel, m_toolBarDelete, m_toolBarEdit, m_toolBarExport, m_toolBarRefresh, m_toolBarSave, m_toolBarView);
            ControlUtil.HiddenControl(true, m_toolBarPaintStyls, m_toolBarThemeStyls);
            foreach(System.Windows.Forms.Control ctrl in this.pnlDate.Controls)
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
        private void frmRPS070_ChargeReport_Load(object sender, EventArgs e)
        {
            SetDateToControl();

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int? OwnerID, WarehouseID;
                DateTime? date1, date2;
                string OwnerName, WarehouseName;
                int? numResult;
                bool hasAtLeastOneReport = false;
                Cursor.Current = Cursors.WaitCursor;
                if (ValidateData())
                {
                    OwnerID = ownerControl.OwnerID;
                    WarehouseID = warehouseControl.WarehouseID;
                    OwnerName = ownerControl.OwnerName;
                    WarehouseName = warehouseControl.WarehouseName;

                    #region UnstaffingChargeReport
                    //UnstaffingChargeReport
                    if (chkUnstaffingCharge.Checked == true)
                    {
                        date1 = DataUtil.Convert<DateTime>(dtUnstaffingChargeFrom.EditValue);
                        date2 = DataUtil.Convert<DateTime>(dtUnstaffingChargeTo.EditValue);

                        List<sp_RPT006_UnstaffingChargeReport_GetData_Result> tempReport = BusinessClass.GetDataUnstaffingChargeReport(OwnerID, WarehouseID, date1, date2);
                        if (tempReport.Count > 0)
                        {
                            hasAtLeastOneReport = true;
                            rptRPT006_UnstaffingChargeReport rpt = new rptRPT006_UnstaffingChargeReport(BusinessClass.GetReportDefaultParams("RPT006"));
                            rpt.DataSource = tempReport;
                            rpt.SetParameterReport("OwnerName", OwnerName);
                            rpt.SetParameterReport("WarehouseName", WarehouseName);
                            rpt.SetParameterReport("date1", (String.Format("{0:dd/MM/yyyy}", date1)));
                            rpt.SetParameterReport("date2", (String.Format("{0:dd/MM/yyyy}", date2)));
                            rpt.SetParameterReport("printBy", AppConfig.Name);
                            ReportUtil.ShowPreview(rpt);
                        }
                    }
                    #endregion
                    #region IncomingChargeReport
                    //IncomingChargeReport
                    if (chkIncomingCharge.Checked == true)
                    {
                        date1 = DataUtil.Convert<DateTime>(dtIncomingChargeFrom.EditValue);
                        date2 = DataUtil.Convert<DateTime>(dtIncomingChargeTo.EditValue);
                        ChargeReport dalReport = new ChargeReport();
                        List<sp_RPT007_IncomingChargeReport_GetData_Result> tempReport = BusinessClass.GetDataIncomingChargeReport(OwnerID, WarehouseID, date1, date2);
                        if (tempReport.Count > 0)
                        {
                            hasAtLeastOneReport = true;
                            rptRPT007_IncomingChargeReport rpt = new rptRPT007_IncomingChargeReport(BusinessClass.GetReportDefaultParams("RPT007"));
                            rpt.DataSource = tempReport;
                            List<sp_RPT007_IncomingChargeReport_SubReport_GetData_Result> tempSubReport = BusinessClass.GetDataIncomingChargeSubReport(OwnerID, WarehouseID, date1, date2);
                            rpt.SubReportDatasource(tempSubReport);
                            rpt.SetParameterReport("OwnerName", OwnerName);
                            rpt.SetParameterReport("WarehouseName", WarehouseName);
                            rpt.SetParameterReport("date1", (String.Format("{0:dd/MM/yyyy}", date1)));
                            rpt.SetParameterReport("date2", (String.Format("{0:dd/MM/yyyy}", date2)));
                            rpt.SetParameterReport("printBy", AppConfig.Name);
                            ReportUtil.ShowPreview(rpt);
                        }
                    }
                    #endregion
                    #region PickingChargeReport
                    //PickingChargeReport

                    if (chkPickingCharge.Checked == true)
                    {
                        date1 = DataUtil.Convert<DateTime>(dtPickingChargeFrom.EditValue);
                        date2 = DataUtil.Convert<DateTime>(dtPickingChargeTo.EditValue);

                        List<sp_RPT009_PickingChargeReport_GetData_Result> tempReport = BusinessClass.GetDataPickingChargeReport(OwnerID, WarehouseID, date1, date2);
                        if (tempReport.Count > 0)
                        {
                            hasAtLeastOneReport = true;
                            rptRPT009_PickingChargeReport rpt = new rptRPT009_PickingChargeReport(BusinessClass.GetReportDefaultParams("RPT009"));
                            rpt.DataSource = tempReport;
                            rpt.SetParameterReport("OwnerName", OwnerName);
                            rpt.SetParameterReport("WarehouseName", WarehouseName);
                            rpt.SetParameterReport("date1", (String.Format("{0:dd/MM/yyyy}", date1)));
                            rpt.SetParameterReport("date2", (String.Format("{0:dd/MM/yyyy}", date2)));
                            rpt.SetParameterReport("PrintBy", AppConfig.Name);
                            ReportUtil.ShowPreview(rpt);
                        }
                    }
                    #endregion
                    #region OutgoingChargeReport
                    //OutgoingChargeReport
                    if (chkOutgoingCharge.Checked == true)
                    {
                        date1 = DataUtil.Convert<DateTime>(dtOutgoingChargeFrom.EditValue);
                        date2 = DataUtil.Convert<DateTime>(dtOutgoingChargeTo.EditValue);

                        List<sp_RPT010_OutgoingChargeReport_GetData_Result> tempReport = BusinessClass.GetDataOutgoingChargeReport(OwnerID, WarehouseID, date1, date2);
                        if (tempReport.Count > 0)
                        {
                            hasAtLeastOneReport = true;
                            rptRPT010_OutgoingChargeReport rpt = new rptRPT010_OutgoingChargeReport(BusinessClass.GetReportDefaultParams("RPT010"));
                            rpt.DataSource = tempReport;
                            //List<sp_RPT010_OutgoingChargeReport_SubReport_GetData_Result> tempSubReport = BusinessClass.GetDataOutgoingChargeSubReport(OwnerID, WarehouseID, date1, date2);
                            rpt.SetParameterReport("OwnerName", OwnerName);
                            rpt.SetParameterReport("WarehouseName", WarehouseName);
                            rpt.SetParameterReport("date1", (String.Format("{0:dd/MM/yyyy}", date1)));
                            rpt.SetParameterReport("date2", (String.Format("{0:dd/MM/yyyy}", date2)));
                            rpt.SetParameterReport("printBy", AppConfig.Name);
                            //rpt.SubReportDatasource(tempSubReport);
                            ReportUtil.ShowPreview(rpt);
                        }
                    }
                    #endregion
                    #region TransitChargeReport
                    //TransitChargeReport
                    if (chkTransitServiceCharge.Checked == true)
                    {
                        date1 = DataUtil.Convert<DateTime>(dtTransitServiceChargeFrom.EditValue);
                        date2 = DataUtil.Convert<DateTime>(dtTransitServiceChargeTo.EditValue);
                        ChargeReport dalReport = new ChargeReport();

                        List<sp_RPT008_TransitChargeReport_GetData_Result> tempReport = BusinessClass.GetDataTransitChargeReport(OwnerID, WarehouseID, date1, date2);
                        if (tempReport.Count > 0)
                        {
                            hasAtLeastOneReport = true;
                            rptRPT008_TransitServiceChargeReport rpt = new rptRPT008_TransitServiceChargeReport(BusinessClass.GetReportDefaultParams("RPT008"));
                            rpt.DataSource = tempReport;
                            //List<sp_RPT008_TransitChargeReport_SubReport_GetData_Result> tempSubReport = BusinessClass.GetDataTransitChargeSubReport(OwnerID, WarehouseID, date1, date2);

                            rpt.SetParameterReport("OwnerName", OwnerName);
                            rpt.SetParameterReport("DateTo", String.Format("{0:dd/MM/yyyy}", date2));
                            rpt.SetParameterReport("DateFrom", String.Format("{0:dd/MM/yyyy}", date1));
                            rpt.SetParameterReport("PrintBy", AppConfig.Name);
                            rpt.SetParameterReport("WarehouseName", WarehouseName);
                            //rpt.SubReportDatasource(tempSubReport);
                            ReportUtil.ShowPreview(rpt);
                        }
                    }
                    #endregion
                    #region TransportChargeReport
                    //TransitChargeReport
                    if (chkTransportCharge.Checked == true)
                    {
                        date1 = DataUtil.Convert<DateTime>(dtTransportChargeFrom.EditValue);
                        date2 = DataUtil.Convert<DateTime>(dtTransportChargeTo.EditValue);
                        List<sp_RPT011_TransportationChargeReport_GetData_Result> tempReport = BusinessClass.GetDataTransportChargeReport(OwnerID, WarehouseID, date1, date2, out numResult);
                        if (tempReport.Count > 0)
                        {
                            hasAtLeastOneReport = true;
                            rptRPT011_TransportationChargeReport rpt = new rptRPT011_TransportationChargeReport(BusinessClass.GetReportDefaultParams("RPT011"));
                            rpt.DataSource = tempReport;
                            rpt.SetParameterReport("OwnerName", OwnerName);
                            rpt.SetParameterReport("DateFrom", String.Format("{0:dd MMMM yyyy}", date1));
                            rpt.SetParameterReport("DateTo", String.Format("{0:dd MMMM yyyy}", date2));
                            rpt.SetParameterReport("PrintBy", AppConfig.Name);
                            ReportUtil.ShowPreview(rpt);
                        }
                    }
                    #endregion
                    #region ReceivingTransportChargeReport
                    //ReceivingTransportChargeReport
                    if (chkReceivingTransportationCharge.Checked == true)
                    {
                        date1 = DataUtil.Convert<DateTime>(dtReceivingTransportChargeFrom.EditValue);
                        date2 = DataUtil.Convert<DateTime>(dtReceivingTransportChargeTo.EditValue);

                        List<sp_RPT005_ReceivingTransportationChargeReport_GetData_Result> tempReport = BusinessClass.GetDataReceivingTransportChargeReport(OwnerID, WarehouseID, date1, date2, out numResult);
                        if (tempReport.Count > 0)
                        {
                            hasAtLeastOneReport = true;
                            rptRPT005_ReceivingTransportationChargeReport rpt = new rptRPT005_ReceivingTransportationChargeReport(BusinessClass.GetReportDefaultParams("RPT005"));
                            rpt.DataSource = tempReport;

                            rpt.SetOwnerNameParameter(OwnerName);
                            rpt.SetWarehouseNameParameter(WarehouseName);
                            rpt.SetDateFromParameter(date1);
                            rpt.SetDateToParameter(date2);
                            rpt.SetUserNameParameter(AppConfig.Name);
                            ReportUtil.ShowPreview(rpt);
                        }
                    }
                    #endregion
                    #region OtherChargeReport
                    //OtherChargeReport
                    if (chkOtherCharge.Checked == true)
                    {
                        date1 = DataUtil.Convert<DateTime>(dtOtherChargeFrom.EditValue);
                        date2 = DataUtil.Convert<DateTime>(dtOtherChargeTo.EditValue);

                        List<sp_RPT003_OtherChargeReport_GetData_Result> tempReport = BusinessClass.GetDataOtherChargeReport(OwnerID, WarehouseID, date1, date2);
                        if (tempReport.Count > 0)
                        {
                            hasAtLeastOneReport = true;
                            rptRPT003_OtherChargeReport rpt = new rptRPT003_OtherChargeReport(BusinessClass.GetReportDefaultParams("RPT003"));
                            rpt.DataSource = tempReport;
                            rpt.SetOwnerNameParameter(OwnerName);
                            rpt.SetWarehouseNameParameter(WarehouseName);
                            rpt.SetDateFromParameter(date1);
                            rpt.SetDateToParameter(date2);
                            rpt.SetUserNameParameter(AppConfig.Name);
                            //rpt.SetGrandTotalParameter(BusinessClass.OtherCharge_GetGrandTotal(tempReport));

                            ReportUtil.ShowPreview(rpt);
                        }
                    }
                    #endregion
                    #region SummaryChargeReport
                    //SummaryChargeReport
                    if (chkSummaryCharge.Checked == true)
                    {
                        date1 = DataUtil.Convert<DateTime>(dtSummaryChargeFrom.EditValue);
                        date2 = DataUtil.Convert<DateTime>(dtSummaryChargeTo.EditValue);

                        List<sp_RPT004_SummaryChargeReport_GetData_Result> tempReport = BusinessClass.GetDataSummaryChargeReport(OwnerID, WarehouseID, date1, date2);
                        if (tempReport.Count > 0)
                        {
                            hasAtLeastOneReport = true;
                            rptRPT004_SummaryChargeReport rpt = new rptRPT004_SummaryChargeReport(BusinessClass.GetReportDefaultParams("RPT004"));
                            rpt.DataSource = tempReport;
                            rpt.SetOwnerNameParameter(OwnerName);
                            rpt.SetWarehouseNameParameter(WarehouseName);
                            rpt.SetDateFromParameter(date1);
                            rpt.SetDateToParameter(date2);
                            rpt.SetUserNameParameter(AppConfig.Name);
                            ReportUtil.ShowPreview(rpt);
                        }
                    }
                    #endregion

                    if (hasAtLeastOneReport == false)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
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
            ControlUtil.ClearControlData(this.Controls);
            errorProvider.ClearErrors();
            SetDateToControl();
        }
        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            if (ownerControl.OwnerID != null)
            {
                warehouseControl.OwnerID = ownerControl.OwnerID;
                warehouseControl.DataLoading();

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
            #region Unstaffing Charge Date
            //Unstaffing Charge Date
            if (chkUnstaffingCharge.Checked == true)
            {
                choosedReport = true;
                if (dtUnstaffingChargeFrom.EditValue == null)
                {
                    errorProvider.SetError(dtUnstaffingChargeFrom, Rubix.Screen.Common.GetMessage("I0265"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(dtIncomingChargeFrom, String.Empty);
                }

                if (dtUnstaffingChargeTo.EditValue == null)
                {
                    errorProvider.SetError(dtUnstaffingChargeTo, Rubix.Screen.Common.GetMessage("I0266"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(dtUnstaffingChargeTo, String.Empty);
                }
            }
            #endregion 
            #region Incoming Charge date
            //Incoming Charge Date
            if (chkIncomingCharge.Checked == true)
            {
                choosedReport = true;
                if (dtIncomingChargeFrom.EditValue == null)
                {
                    errorProvider.SetError(dtIncomingChargeFrom, Rubix.Screen.Common.GetMessage("I0265"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(dtIncomingChargeFrom, String.Empty);
                }

                if (dtIncomingChargeTo.EditValue == null)
                {
                    errorProvider.SetError(dtIncomingChargeTo, Rubix.Screen.Common.GetMessage("I0266"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(dtIncomingChargeTo, String.Empty);
                }
            }
            #endregion
            #region transit charge date
            //transit Charge Date
            if (chkTransitServiceCharge.Checked == true)
            {
                choosedReport = true;
                if (dtTransitServiceChargeFrom.EditValue == null)
                {

                    errorProvider.SetError(dtTransitServiceChargeFrom, Rubix.Screen.Common.GetMessage("I0265"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(dtTransitServiceChargeFrom, String.Empty);
                }

                if (dtTransitServiceChargeTo.EditValue == null)
                {
                    errorProvider.SetError(dtTransitServiceChargeTo, Rubix.Screen.Common.GetMessage("I0266"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(dtTransitServiceChargeTo, String.Empty);
                }
            }
            #endregion
            #region Picking Charge Date
            //Picking Charge Date
            if (chkPickingCharge.Checked == true)
            {
                choosedReport = true;
                if (dtPickingChargeFrom.EditValue == null)
                {
                    errorProvider.SetError(dtPickingChargeFrom, Rubix.Screen.Common.GetMessage("I0265"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(dtPickingChargeFrom, String.Empty);
                }

                if (dtPickingChargeTo.EditValue == null)
                {
                    errorProvider.SetError(dtPickingChargeTo, Rubix.Screen.Common.GetMessage("I0266"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(dtPickingChargeTo, String.Empty);
                }
            }
            #endregion
            #region Outgoing Charge Date
            //Outgoing Charge Date
            if (chkOutgoingCharge.Checked == true)
            {
                choosedReport = true;
                if (dtOutgoingChargeFrom.EditValue == null)
                {
                    errorProvider.SetError(dtOutgoingChargeFrom, Rubix.Screen.Common.GetMessage("I0265"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(dtOutgoingChargeFrom, String.Empty);
                }

                if (dtOutgoingChargeTo.EditValue == null)
                {
                    errorProvider.SetError(dtOutgoingChargeTo, Rubix.Screen.Common.GetMessage("I0266"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(dtOutgoingChargeTo, String.Empty);
                }
            }
            #endregion
            #region transport charge date
            //transit Charge Date

            if (chkTransportCharge.Checked == true)
            {

                choosedReport = true;
                if (dtTransportChargeFrom.EditValue == null)
                {
                    errorProvider.SetError(dtTransportChargeFrom, Rubix.Screen.Common.GetMessage("I0265"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(dtTransportChargeFrom, String.Empty);
                }

                if (dtTransportChargeTo.EditValue == null)
                {
                    errorProvider.SetError(dtTransportChargeTo, Rubix.Screen.Common.GetMessage("I0266"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(dtTransportChargeTo, String.Empty);
                }
            }
            #endregion
            #region Receiving transport charge date
            //transit Charge Date

            if (chkReceivingTransportationCharge.Checked == true)
            {

                choosedReport = true;
                if (dtReceivingTransportChargeFrom.EditValue == null)
                {
                    errorProvider.SetError(dtReceivingTransportChargeFrom, Rubix.Screen.Common.GetMessage("I0265"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(dtReceivingTransportChargeFrom, String.Empty);
                }

                if (dtReceivingTransportChargeTo.EditValue == null)
                {
                    errorProvider.SetError(dtReceivingTransportChargeTo, Rubix.Screen.Common.GetMessage("I0266"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(dtReceivingTransportChargeTo, String.Empty);
                }
            }
            #endregion
            #region Other Charge Date
            //Other Charge Date
            if (chkOtherCharge.Checked == true)
            {
                choosedReport = true;
                if (dtOtherChargeFrom.EditValue == null)
                {
                    errorProvider.SetError(dtOtherChargeFrom, Rubix.Screen.Common.GetMessage("I0265"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(dtOtherChargeFrom, String.Empty);
                }

                if (dtOtherChargeTo.EditValue == null)
                {
                    errorProvider.SetError(dtOtherChargeTo, Rubix.Screen.Common.GetMessage("I0266"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(dtOtherChargeTo, String.Empty);
                }
            }
            #endregion
            #region Summary Charge Date
            //Summary Charge Date
            if (chkSummaryCharge.Checked == true)
            {
                choosedReport = true;
                if (dtSummaryChargeFrom.EditValue == null)
                {
                    errorProvider.SetError(dtSummaryChargeFrom, Rubix.Screen.Common.GetMessage("I0265"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(dtSummaryChargeFrom, String.Empty);
                }

                if (dtSummaryChargeTo.EditValue == null)
                {
                    errorProvider.SetError(dtSummaryChargeTo, Rubix.Screen.Common.GetMessage("I0266"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(dtSummaryChargeTo, String.Empty);
                }
            }
            #endregion


            if (false == choosedReport)
            {
                errFlag = false;
                //MessageDialog.ShowBusinessErrorMsg(this, "Please select at least one report.");
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0211"));
            }

            return errFlag;
        }
        private void SetDateToControl()
        {
            DateTime from = ControlUtil.GetStartDate();
            DateTime to = ControlUtil.GetEndDate();

            dtIncomingChargeFrom.DateTime = from;
            dtOtherChargeFrom.DateTime = from;
            dtOutgoingChargeFrom.DateTime = from;
            dtPickingChargeFrom.DateTime = from;
            dtReceivingTransportChargeFrom.DateTime = from;
            dtSummaryChargeFrom.DateTime = from;
            dtTransitServiceChargeFrom.DateTime = from;
            dtTransportChargeFrom.DateTime = from;
            dtUnstaffingChargeFrom.DateTime = from;

            dtIncomingChargeTo.DateTime = to;
            dtOtherChargeTo.DateTime = to;
            dtOutgoingChargeTo.DateTime = to;
            dtPickingChargeTo.DateTime = to;
            dtReceivingTransportChargeTo.DateTime = to;
            dtSummaryChargeTo.DateTime = to;
            dtTransitServiceChargeTo.DateTime = to;
            dtTransportChargeTo.DateTime = to;
            dtUnstaffingChargeTo.DateTime = to;
        }
        #endregion        

    }
}
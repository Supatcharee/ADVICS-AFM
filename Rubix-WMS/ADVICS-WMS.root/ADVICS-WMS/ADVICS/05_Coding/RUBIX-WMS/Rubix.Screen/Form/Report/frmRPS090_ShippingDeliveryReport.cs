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
namespace Rubix.Screen.Form.Report
{
    [ScreenPermissionAttribute(Permission.OpenScreen)]
    public partial class frmRPS090_ShippingDeliveryReport : FormBase
    {

        #region Member
        private ShippingDeliveryReport db;
        const string DATE_EDIT_FORMAT = "dd/MM/yyyy";
        #endregion

        #region Constant
        const int RecordPerPage = 11; // 11
        #endregion

        #region Properties
        private ShippingDeliveryReport BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ShippingDeliveryReport();
                }
                return db;
            }
        }
        #endregion

        #region Constructor
        public frmRPS090_ShippingDeliveryReport()
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
        private void frmRPS090_ShippingDeliveryReport_Load(object sender, EventArgs e)
        {
            dtReceivedDateFrom.Properties.Mask.EditMask = DATE_EDIT_FORMAT;
            dtReceivedDateTo.Properties.Mask.EditMask = DATE_EDIT_FORMAT;
            dtReceivedDateFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtReceivedDateTo.Properties.Mask.UseMaskAsDisplayFormat = true;
            SetDateToControl();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int? OwnerID, WarehouseID;
                String shipmentNo, invoicecNo;
                DateTime? deliveryDate1, deliveryDate2;
                Cursor.Current = Cursors.WaitCursor;
                if (ValidateData())
                {
                    OwnerID = ownerControl.OwnerID;
                    WarehouseID = warehouseControl.WarehouseID;
                    shipmentNo = txtSlipNo.Text.Trim();
                    invoicecNo = textEdit1.Text.Trim();
                    deliveryDate1 = DataUtil.Convert<DateTime>(dtReceivedDateFrom.EditValue);
                    deliveryDate2 = DataUtil.Convert<DateTime>(dtReceivedDateTo.EditValue);

                    List<sp_RPT013_ShippingDeliveryReport_GetData_Result> tempReport = BusinessClass.GetDataReport(OwnerID, WarehouseID, shipmentNo, invoicecNo, deliveryDate1, deliveryDate2, itemControl.ProductID);

                    if (tempReport.Count == 0)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                        return;
                    }

                    rptRPT013_ShippingDeliveryReport rpt = new rptRPT013_ShippingDeliveryReport(BusinessClass.GetReportDefaultParams("RPT013"));
                    rpt.DataSource = tempReport;

                    List<sp_RPT013_ShippingDeliveryReport_GetData_Result> tempSubReport =
                        BusinessClass.GetDataSubReport(tempReport);

                    rpt.SetParameterReport("TotalRecord", tempReport.Count);
                    rpt.SetParameterReport("OwnerName", ownerControl.OwnerName);
                    rpt.SetParameterReport("WarehouseName", warehouseControl.WarehouseName);
                    rpt.SetParameterReport("transitDateFrom", deliveryDate1);
                    rpt.SetParameterReport("transitDateTo", deliveryDate2);
                    rpt.SetParameterReport("UserName", AppConfig.Name);
                    rpt.SetParameterReport("RecordPerPage", RecordPerPage);
                    rpt.SubReportDatasource(tempSubReport);
                    ReportUtil.ShowPreview(rpt);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            warehouseControl.OwnerID = ownerControl.OwnerID;
            warehouseControl.DataLoading();
            itemControl.OwnerID = ownerControl.OwnerID;
            itemControl.DataLoading();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ownerControl.ClearData();
            warehouseControl.ClearData();
            itemControl.ClearData();
            ControlUtil.ClearControlData(txtSlipNo, dtReceivedDateFrom, dtReceivedDateTo, textEdit1);
            SetDateToControl();
        }
        private void warehouseControl_EditValueChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Generic Function
        private Boolean ValidateData()
        {
            Boolean errFlag = true;

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
            //Distribution Center
            if (!warehouseControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(ownerControl, String.Empty);
            }
            //Transit Date
            if (dtReceivedDateFrom.EditValue == null)
            {
                errorProvider.SetError(dtReceivedDateFrom, Rubix.Screen.Common.GetMessage("I0037"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(dtReceivedDateFrom, String.Empty);
            }

            if (dtReceivedDateTo.EditValue == null)
            {
                errorProvider.SetError(dtReceivedDateTo, Rubix.Screen.Common.GetMessage("I0037"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(dtReceivedDateTo, String.Empty);
            }
            return errFlag;
        }
        private void SetDateToControl()
        {
            DateTime from = ControlUtil.GetStartDate();
            DateTime to = ControlUtil.GetEndDate();
            dtReceivedDateFrom.DateTime = from;
            dtReceivedDateTo.DateTime = to;
        }
        #endregion
    }

}
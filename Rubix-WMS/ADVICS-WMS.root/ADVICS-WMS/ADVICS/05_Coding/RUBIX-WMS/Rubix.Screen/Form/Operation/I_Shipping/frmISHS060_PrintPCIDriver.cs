/*
 * 23 Jan 2013:
 * 1. correct filter of every controls
 * 30 Jan 2013:
 * 1. add validate transaction date
 * 13 Feb 2013:
 * 1. add wait screen when search
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using CSI.Business.Operation;
using Rubix.Framework;
using DevExpress.XtraGrid.Views.Grid;
using CSI.Business.DataObjects;
using DevExpress.XtraReports.UI;
using Rubix.Screen.Report;
using CSI.Business.BusinessFactory.Report;
using System.Linq;
namespace Rubix.Screen.Form.Operation.I_Shipping
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Export, Permission.OpenReport, Permission.Print)]
    public partial class frmISHS060_PrintPCIDriver : FormBase
    {
        #region Enumeration
        // Column order in grid
        private enum eColumns
        {
            Select
            ,
            StatusID
                ,
            StatusName
                ,
            PortOfLoading
                ,
            PortOfDischarge
                ,
            FinalDestination
                ,
            ShipmentNo
                ,
            PickingNo
                ,
            DeliveryNo
                ,
            Installment
                , NumberOfDetail
        }

        #endregion

        #region Member
        private PrintPCIDriver db;
        private Dialog.frmISHS062_DownloadAttachFileDialog m_AttachDialog = null;
        private Color COLOR_PRINTED = Color.FromArgb(255, 255, 192); // yellow
        private Color COLOR_DISABLE_ROW = Common.CompleteColor(); // orange
        private Color COLOR_TEXT = Color.Black; // orange
        #endregion

        #region Constant
        const string SHIPMENT_LABEL_PARAMETER_NAME = "shipmentNo";
        const string DELIVERY_ORDER_ENG_PARAMETER_NAME = "engStr";
        const string DELIVERY_ORDER_TH_PARAMETER_NAME = "thStr";
        const int MAX_ITEM_OF_SHIPMENT_LABEL_1 = 5;
        #endregion

        #region Properties
        private PrintPCIDriver BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new PrintPCIDriver();
                }
                return db;
            }
        }
        private Dialog.frmISHS062_DownloadAttachFileDialog AttachDialog
        {
            get
            {
                if (m_AttachDialog == null)
                {
                    return m_AttachDialog = new Dialog.frmISHS062_DownloadAttachFileDialog();
                }
                return m_AttachDialog;
            }
        }
        #endregion

        #region Constructor
        public frmISHS060_PrintPCIDriver()
        {
            InitializeComponent();            
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl1);

            dtPickingFrom.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtPickingFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingFrom.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtPickingFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtPickingFrom.Properties.Mask.EditMask = Common.FullDateFormat;

            dtPickingTo.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtPickingTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingTo.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtPickingTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtPickingTo.Properties.Mask.EditMask = Common.FullDateFormat;

            gdcPickingDate.DisplayFormat.FormatString = Common.FullDatetimeFormat;
            gdcPickingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarAdd, m_toolBarEdit, m_toolBarDelete, m_toolBarRefresh, m_toolBarSave, m_toolBarCancel);
        }
        #endregion
        
        #region Event Handler Function
        private void frmISHS060_PrintPCIDriver_Load(object sender, EventArgs e)
        {
            try
            {
                ControlUtil.HiddenControl(true, m_toolBarPrint);
                if (base.CanPrint)
                {
                    btnPrintDO.Visible = true;
                    btnPrintLabel.Visible = true;
                }
                else
                {
                    btnPrintDO.Visible = false;
                    btnPrintLabel.Visible = false;
                }
                InitControl();
                gdvSearchResult.OptionsBehavior.Editable = true;
                gdcDownload.OptionsColumn.AllowEdit = true;                
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (true == ValidateDataWhenSearch())
                {
                    DataLoading();
                    if (gdvSearchResult.RowCount == 0)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SetSelectColumn(true);
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            SetSelectColumn(false);
        }

        private void btnPrintDO_Click(object sender, EventArgs e)
        {

            if (gdvSearchResult.IsEmpty)
                return;

            XtraReport rpt = null;
            DeliveryOrderReport dalReport = new DeliveryOrderReport();
            List<sp_ISHS060_PrintDeliveryOrder_SearchAll_Result> lstShipping
                = (List<sp_ISHS060_PrintDeliveryOrder_SearchAll_Result>)gdvSearchResult.DataSource;

            // 30 Jan 2013: add list for collect ship
            List<sp_ISHS060_PrintDeliveryOrder_SearchAll_Result> lstSelectShipping = new List<sp_ISHS060_PrintDeliveryOrder_SearchAll_Result>();
            // end 30 Jan 2013:
            foreach (sp_ISHS060_PrintDeliveryOrder_SearchAll_Result ship in lstShipping)
            {
                // ignore uncheck row
                if (ship.Select == null || ship.Select.Value == false)
                {
                    continue;
                }
                lstSelectShipping.Add(ship);
            }

            foreach (sp_ISHS060_PrintDeliveryOrder_SearchAll_Result ship in lstSelectShipping)
            {
                // ignore uncheck row
                if (ship.Select == null || ship.Select.Value == false)
                {
                    continue;
                }

                Boolean result = BusinessClass.EntryDeliveryOrder(ship);
                if (result)
                {
                    Rubix.Screen.Report.rptRPT022_DeliveryOrder reportOriginal = new Rubix.Screen.Report.rptRPT022_DeliveryOrder(dalReport.GetReportDefaultParams("RPT022"));
                    Rubix.Screen.Report.rptRPT022_DeliveryOrder reportCopy = new Rubix.Screen.Report.rptRPT022_DeliveryOrder(dalReport.GetReportDefaultParams("RPT022"));
                    List<sp_RPT022_DeliveryOrder_GetData_Result> deliveryOrder = dalReport.PrintDeliveryOrder(ship.ShipmentNo, ship.PickingNo);

                    List<sp_RPT022_DeliveryOrder_GetData_Result> subDeliveryOrder = dalReport.GetDataSubReport(deliveryOrder);

                    foreach (sp_RPT022_DeliveryOrder_GetData_Result item in deliveryOrder)
                    {
                        item.ShipQty = item.ShipQty.HasValue ? Math.Round(Convert.ToDecimal(item.ShipQty), 3) : item.ShipQty;
                        item.Weight = item.Weight.HasValue ? Math.Round(Convert.ToDecimal(item.Weight), 3) : item.Weight;
                        item.M3 = item.M3.HasValue ? Math.Round(Convert.ToDecimal(item.M3), 3) : item.M3;
                    }

                    foreach (sp_RPT022_DeliveryOrder_GetData_Result item in subDeliveryOrder)
                    {
                        item.ShipQty = item.ShipQty.HasValue ? Math.Round(Convert.ToDecimal(item.ShipQty), 3) : item.ShipQty;
                    }

                    reportOriginal.DataSource = deliveryOrder;
                    reportOriginal.SubReportDatasource(subDeliveryOrder);

                    // set report parameter
                    reportOriginal.SetParameterReport(DELIVERY_ORDER_ENG_PARAMETER_NAME, "Original");
                    reportOriginal.SetParameterReport(DELIVERY_ORDER_TH_PARAMETER_NAME, "ต้นฉบับ");
                    reportOriginal.SetTotalRecordParameter(deliveryOrder.Count);

                    if (rpt != null)
                    {
                        ReportUtil.CombineReport(rpt, reportOriginal);
                    }
                    else
                    {
                        rpt = reportOriginal;
                    }

                    // report copy
                    reportCopy.DataSource = deliveryOrder;
                    reportCopy.SubReportDatasource(subDeliveryOrder);

                    reportCopy.SetParameterReport(DELIVERY_ORDER_ENG_PARAMETER_NAME, "Copy");
                    reportCopy.SetParameterReport(DELIVERY_ORDER_TH_PARAMETER_NAME, "สำเนา");
                    reportCopy.SetTotalRecordParameter(deliveryOrder.Count);

                    ReportUtil.CombineReport(rpt, reportCopy);

                    DataLoading();
                }

            }

            // end 30 Jan 2013: move commented code to here

            if (rpt != null)
            {
                ReportUtil.ShowPreview(rpt);
            }
        }

        private void ownerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (ownerControl.OwnerID != null)
                {
                    warehouseControl.OwnerID = ownerControl.OwnerID;
                    warehouseControl.DataLoading();
                    shipmentControl.OwnerID = ownerControl.OwnerID;
                    shipmentControl.DataLoading();
                    customerControl.OwnerID = ownerControl.OwnerID;
                    customerControl.DataLoading();
                }
                else
                {
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                    shipmentControl.DataLoading();
                    customerControl.OwnerID = Common.GetDefaultOwnerID();
                    customerControl.DataLoading();
                    pickingControl.ShipmentNo = "-1";
                    pickingControl.DataLoading();
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                shipmentControl.CustomerID = customerControl.CustomerID;
                shipmentControl.DataLoading();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void btnPrintLabel_Click(object sender, EventArgs e)
        {
            if (gdvSearchResult.IsEmpty)
            {
                return;
            }
            XtraReport rpt = null;
            string strKey = string.Empty;
            List<string> printShipmentNo = new List<string>();

            List<sp_ISHS060_PrintDeliveryOrder_SearchAll_Result> lstShipping = ((List<sp_ISHS060_PrintDeliveryOrder_SearchAll_Result>)gdvSearchResult.DataSource).Where(c=> c.Select == true).ToList();
            foreach (sp_ISHS060_PrintDeliveryOrder_SearchAll_Result ship in lstShipping)
            {
                strKey = string.Format("{0}|{1}", ship.ShipmentNo, ship.PickingNo);
                // ignore uncheck row
                if (ship.Select == null || ship.Select.Value == false)
                {
                    continue;
                }

                if (printShipmentNo.Contains(strKey) == false)
                {
                    printShipmentNo.Add(strKey);
                }
                else
                {
                    // no print shipment which is already printed
                    continue;
                }

                // load shipment label
                //Edit By Winai S. 23/04/2013
                //List<sp_RPT020_ShipmentLabel_GetData_Result> lstShipmentLabel = BusinessClass.PrintShipmentLabel(ship.ShipmentNo);
                List<sp_RPT020_ShipmentLabel_GetData_Result> lstShipmentLabel = BusinessClass.PrintShipmentLabel(ship.ShipmentNo, ship.PickingNo);

                //var queryDistinct = (from Data in lstShipmentLabel
                //                     select Data.PalletNoRef).Distinct();

                //foreach (var record in queryDistinct)
                //{
                rptRPT020_ShipmentQRCode rptShipmentLabel1 = new rptRPT020_ShipmentQRCode(BusinessClass.GetReportDefaultParams("RPT020"));
                rptRPT020_ShipmentQRCode rptShipmentLabel2 = new rptRPT020_ShipmentQRCode(BusinessClass.GetReportDefaultParams("RPT020"));
                //List<sp_RPT020_ShipmentLabel_GetData_Result> lstLabel = lstShipmentLabel.Where(a => a.PalletNoRef == record).ToList();
                List<sp_RPT020_ShipmentLabel_GetData_Result> lstLabel = lstShipmentLabel;
                // split report label
                if (lstLabel.Count > MAX_ITEM_OF_SHIPMENT_LABEL_1)
                {
                    rptShipmentLabel1.DataSource = lstLabel.GetRange(0, MAX_ITEM_OF_SHIPMENT_LABEL_1);
                    rptShipmentLabel2.DataSource = lstLabel.GetRange(MAX_ITEM_OF_SHIPMENT_LABEL_1
                        , lstLabel.Count - MAX_ITEM_OF_SHIPMENT_LABEL_1);
                }
                else
                {
                    rptShipmentLabel1.DataSource = lstLabel;
                }

                // bind report parameter
                //rptShipmentLabel1.SetParameterReport(SHIPMENT_LABEL_PARAMETER_NAME, ship.ShipmentNo);
                rptShipmentLabel1.SetParameterReport(SHIPMENT_LABEL_PARAMETER_NAME, ship.PickingNo);
                // combine report
                if (rpt != null)
                {
                    List<ReportDefaultParam> lstParam = BusinessClass.GetReportDefaultParams("RPT020");
                    if (lstParam != null && lstParam.Count != 0)
                        rptShipmentLabel1.SetParameterReport("ISO", lstParam[7].Value);
                    ReportUtil.CombineReport(rpt, rptShipmentLabel1);
                }
                else
                {
                    rpt = rptShipmentLabel1;
                }

                if (rptShipmentLabel2.RowCount != 0)
                {
                    // bind report parameter
                    rptShipmentLabel2.SetParameterReport(SHIPMENT_LABEL_PARAMETER_NAME, ship.ShipmentNo);
                    ReportUtil.CombineReport(rpt, rptShipmentLabel2);
                }
                //}
            }

            if (rpt != null)
            {
                ReportUtil.ShowPreview(rpt);
            }
        }

        private void gdvSearchResult_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            // set back color
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                int statusID = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns[(int)eColumns.StatusID]));
                e.Appearance.Options.UseBackColor = true;
                e.Appearance.Options.UseForeColor = true;
                if (statusID == CSI.Business.Common.Status.CompleteShipping)
                {
                    // do nothing
                }
                else if (statusID == CSI.Business.Common.Status.DeliveryNoteIssued)
                {
                    e.Appearance.BackColor = COLOR_PRINTED;
                }
                else
                {
                    e.Appearance.BackColor = COLOR_DISABLE_ROW;
                }
                e.Appearance.ForeColor = COLOR_TEXT;
            }
        }

        private void gdvSearchResult_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView View = sender as GridView;

            // disable checkbox for specified status
            if (View.FocusedColumn.AbsoluteIndex == (int)eColumns.Select || View.FocusedColumn == gdcDownload)
            {
                int statusId = Convert.ToInt32(View.GetRowCellDisplayText(View.FocusedRowHandle, View.Columns[(int)eColumns.StatusID]));
                e.Cancel = !(statusId == CSI.Business.Common.Status.CompleteShipping || statusId == CSI.Business.Common.Status.DeliveryNoteIssued);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dtPickingFrom_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                shipmentControl.PickDateFrom = DataUtil.Convert<DateTime>(dtPickingFrom.EditValue);
                shipmentControl.DataLoading();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void dtPickingTo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                shipmentControl.PickDateTo = DataUtil.Convert<DateTime>(dtPickingTo.EditValue);
                shipmentControl.DataLoading();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void shipmentControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (!string.IsNullOrEmpty(shipmentControl.ShipmentNo))
                {
                    pickingControl.ShipmentNo = shipmentControl.ShipmentNo;
                    pickingControl.DataLoading();
                }
                else
                {
                    pickingControl.ShipmentNo = "-1";
                    pickingControl.DataLoading();
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                sp_ISHS060_PrintDeliveryOrder_SearchAll_Result focus = (sp_ISHS060_PrintDeliveryOrder_SearchAll_Result)gdvSearchResult.GetFocusedRow();
                this.AttachDialog.ShipmentNo = focus.ShipmentNo;
                this.AttachDialog.PickingNo = focus.PickingNo;
                this.AttachDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        #endregion

        #region Generic Function
        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                grdSearchResult.DataSource = BusinessClass.DataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, shipmentControl.ShipmentNo
                                                                        , pickingControl.PickingNo, DataUtil.Convert<DateTime>(dtPickingFrom.EditValue)
                                                                        , DataUtil.Convert<DateTime>(dtPickingTo.EditValue), customerControl.CustomerID);
                
                if (gdvSearchResult.RowCount != 0)
                {
                    // set enable all columns first
                    gdvSearchResult.OptionsBehavior.Editable = true;
                    // hide unused columns
                    ControlUtil.HiddenControl(true, gdvSearchResult, (int)eColumns.StatusID, (int)eColumns.Installment);
                }
                base.GridViewOnChangeLanguage(grdSearchResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseWaitScreen();
            }
        }

        private Boolean ValidateDataWhenSearch()
        {
            errorProvider.ClearErrors();
            Boolean noError = true;
            // set require field
            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            //customerControl.ErrorText = Common.GetMessage("I0249");
            //customerControl.RequireField = true;

            noError &= ownerControl.ValidateControl();
            noError &= warehouseControl.ValidateControl();
            //noError &= customerControl.ValidateControl();

            return noError;
        }

        private void InitControl()
        {
            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();
            customerControl.OwnerID = Common.GetDefaultOwnerID();
            customerControl.DataLoading();
            pickingControl.ShipmentNo = "-1";
            pickingControl.DataLoading();
            shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusId();
            shipmentControl.OwnerID = Common.GetDefaultOwnerID();
            shipmentControl.DataLoading();

            dtPickingFrom.EditValue = ControlUtil.GetStartDate();
            dtPickingTo.EditValue = ControlUtil.GetEndDate();
        }

        private void ClearAll()
        {
            ShowWaitScreen();
            ownerControl.ClearData();
            grdSearchResult.DataSource = null;

            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();
            customerControl.OwnerID = Common.GetDefaultOwnerID();
            customerControl.DataLoading();
            pickingControl.ShipmentNo = "-1";
            pickingControl.DataLoading();
            shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusId();
            shipmentControl.OwnerID = Common.GetDefaultOwnerID();
            shipmentControl.DataLoading();

            dtPickingFrom.EditValue = ControlUtil.GetStartDate();
            dtPickingTo.EditValue = ControlUtil.GetEndDate();
            CloseWaitScreen();
        }

        private void SetSelectColumn(bool select)
        {
            // 20 Feb 2013: clear sort before select all
            gdvSearchResult.ClearSorting();
            // end 20 Feb 2013
            for (int rowIndex = 0; rowIndex < gdvSearchResult.RowCount; rowIndex++)
            {
                int statusId = Convert.ToInt32(gdvSearchResult.GetRowCellDisplayText(rowIndex, gdvSearchResult.Columns[(int)eColumns.StatusID]));
                if (statusId == CSI.Business.Common.Status.CompleteShipping || statusId == CSI.Business.Common.Status.DeliveryNoteIssued)
                {
                    gdvSearchResult.SetRowCellValue(rowIndex, gdvSearchResult.Columns[(int)eColumns.Select], select);
                }
            }
        }
        #endregion

    }
}
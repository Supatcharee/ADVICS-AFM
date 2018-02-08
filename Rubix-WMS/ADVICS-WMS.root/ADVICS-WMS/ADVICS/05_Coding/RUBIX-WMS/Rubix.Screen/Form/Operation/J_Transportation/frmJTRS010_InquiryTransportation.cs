using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CSI.Business.Report;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using CSI.Business.Operation;
using Rubix.Framework;
using Rubix.Screen.Form.Operation.F_ShippingEntry.Dialog;
using CSI.Business.DataObjects;
using Rubix.Screen.Report;
using CSI.Business.BusinessFactory.Common;

namespace Rubix.Screen.Form.Operation.J_Transportation
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Export, Permission.Edit)]
    public partial class frmJTRS010_InquiryTransportation : FormBase
    {
        #region Enumeration
        private enum eColumns
        {
            TransportationDate
            , ShipmentNo
            , PickingNo
            , PortOfDischarge
            , FinalDestination
            , Weight
            , Measurement
            , QTY
            , TransportationData
        }
        #endregion

        #region Constant
        const string DATE_EDIT_FORMAT = "dd/MM/yyyy";
        #endregion

        #region Member
        private InquiryTransportation  db;
        private dlgJTRS010_InquiryTransportation m_Dialog;
        private String ShipmentBase;
        private LoadingInstructionReport m_ReportClass = null;
        #endregion

        #region Properties
        private InquiryTransportation BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new InquiryTransportation();
                }
                return db;
            }
        }

        private dlgJTRS010_InquiryTransportation Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new dlgJTRS010_InquiryTransportation();
                }
                return m_Dialog;
            }
            set
            {
                m_Dialog = value;
            }
        }

        private LoadingInstructionReport ReportBusiness
         {
             get
             {
                 if (m_ReportClass == null)
                 {
                     m_ReportClass = new LoadingInstructionReport();
                 }
                 return m_ReportClass;
             }
         }
        #endregion
        
        #region Constructor
        public frmJTRS010_InquiryTransportation()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarAdd, m_toolBarDelete, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl1);

            dtDeliveryDateFrom.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtDeliveryDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtDeliveryDateFrom.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtDeliveryDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtDeliveryDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtDeliveryDateFrom.Properties.Mask.EditMask = Common.FullDateFormat;

            dtDeliveryDateTo.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtDeliveryDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtDeliveryDateTo.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtDeliveryDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtDeliveryDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtDeliveryDateTo.Properties.Mask.EditMask = Common.FullDateFormat;

            iv = new IdleValidator("tbt_ShippingTransportation", "UpdateDate", "TransportSeq");
        }
        #endregion

        #region Event Handler Function
        private void frmJTRS010_InquiryTransportation_Load(object sender, EventArgs e)
        {
            try
            {
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                finalDestinationControl.OwnerID = Common.GetDefaultOwnerID();
                finalDestinationControl.DataLoading();
          
                gdvSearchResult.OptionsBehavior.Editable = true;

                dtDeliveryDateFrom.EditValue = ControlUtil.GetStartDate();
                dtDeliveryDateTo.EditValue = ControlUtil.GetEndDate();

                dtTransportDateFrom.EditValue = ControlUtil.GetStartDate();
                dtTransportDateTo.EditValue = ControlUtil.GetEndDate();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void ownerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (ownerControl.OwnerID != null)
                {
                    customerControl.OwnerID = ownerControl.OwnerID;
                    customerControl.DataLoading();
                    warehouseControl.OwnerID = ownerControl.OwnerID;
                    warehouseControl.DataLoading();
                    finalDestinationControl.OwnerID = ownerControl.OwnerID;
                    finalDestinationControl.DataLoading();
                }
                else
                {
                    customerControl.OwnerID = Common.GetDefaultOwnerID();
                    customerControl.DataLoading();
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    finalDestinationControl.OwnerID = Common.GetDefaultOwnerID();
                    finalDestinationControl.DataLoading();
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        
        private void gdvSearchResult_ShowingEditor(object sender, CancelEventArgs e)
        {
            DataRow dr = gdvSearchResult.GetFocusedDataRow();
            DataTable dt = grdSearchResult.DataSource as DataTable;

            DataRow[] drSelected = dt.Select("SELECT = true");

            if (drSelected.Length == 0)
            {
                this.ShipmentBase = string.Empty;
            }

            if (string.IsNullOrEmpty(this.ShipmentBase))
            {
                this.ShipmentBase = dr["ShipmentNo"].ToString();
            }
            else
            {
                if (!this.ShipmentBase.Equals(dr["ShipmentNo"].ToString()))
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (true == ValidateDataWhenSearch())
                {
                    DataLoading();
                    base.GridViewOnChangeLanguage(grdSearchResult);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());

            }
        }

        private void gdvSearchResult_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            e.Handled = true;
            DataRow firstRow = gdvSearchResult.GetDataRow(e.RowHandle1);
            DataRow secondRow = gdvSearchResult.GetDataRow(e.RowHandle2);

            if (e.Column == gdcDeliveryDate
                || e.Column == gdcShipmentNo
                || e.Column == gdcFinalDestination
                || e.Column == gdcTransportationData
                || e.Column == gdcShippingRemark
                || e.Column == gdcContainerNo

                )
            {
                if (firstRow["DeliveryDate"].Equals(secondRow["DeliveryDate"])
                    && firstRow["ShipmentNo"].Equals(secondRow["ShipmentNo"])
                    && firstRow["FinalDestination"].Equals(secondRow["FinalDestination"])
                    && firstRow["TransportationData"].Equals(secondRow["TransportationData"])
                    && firstRow["ContainerNo"].Equals(secondRow["ContainerNo"])

                    )
                {
                    e.Merge = true;
                }
                else
                {
                    e.Merge = false;
                }
            }
            else if (e.Column == gdcPlanIn ||
                     e.Column == gdcPlanOut ||
                     e.Column == gdcActualIn ||
                     e.Column == gdcActualOut ||
                     e.Column == gdcTruckCompanyLongName ||
                     e.Column == gdcTransportTypeName ||
                     e.Column == gdcContainerNo ||
                     e.Column == gdcRegistrationNo ||
                     e.Column == gdcDriverName)
            {
                if (firstRow["PlanIn"].Equals(secondRow["PlanIn"])
                    && firstRow["PlanOut"].Equals(secondRow["PlanOut"])
                    && firstRow["ActualIn"].Equals(secondRow["ActualIn"])
                    && firstRow["ActualOut"].Equals(secondRow["ActualOut"])
                    )
                {
                    e.Merge = true;
                }
                else
                    e.Merge = false;
            }
            else
            {
                e.Merge = false;
            }
        }

        private void btnPrintPackingInstruction_Click(object sender, EventArgs e)
        {

            try
            {
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return;
                }


                DataRow selectedRow = gdvSearchResult.GetFocusedDataRow();
                if (selectedRow == null)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return;
                }

                // Input Parameter
                string shipmentNo = selectedRow["ShipmentNo"].ToString();
                int installment = Convert.ToInt32(selectedRow["Installment"]);
                string containNo = selectedRow["ContainerNo"].ToString();
                string PlanOut = Convert.ToDateTime(selectedRow["PlanOut"]).ToString("yyyy/MM/dd");
                string ActualOut = selectedRow["ActualOut"] == DBNull.Value ? null : Convert.ToDateTime(selectedRow["ActualOut"]).ToString("yyyy/MM/dd");

                List<sp_RPT036_LoadingInstruction_GetData_Result> lstReport = ReportBusiness.GetDataReport(shipmentNo, installment, containNo, PlanOut, ActualOut);

                rptRPT036_LoadingInstruction rpt = new rptRPT036_LoadingInstruction(ReportBusiness.GetReportDefaultParams("RPT036"));
                rpt.DataSource = lstReport;
                rpt.SetParameterReport("printBy", AppConfig.Name);
                rpt.SetParameterReport("ISO", "FM-LED-08(Rev.00)");

                ReportUtil.ShowPreview(rpt);

            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                btnUnselectAll_Click(sender, e);

                DataRow drSelect = gdvSearchResult.GetFocusedDataRow();
                if (drSelect != null)
                {
                    DataTable dt = grdSearchResult.DataSource as DataTable;
                    DataRow[] dr;
                    if (drSelect["ActualOut"] == DBNull.Value || drSelect["ContainerNo"] == DBNull.Value)
                    {
                        if (drSelect["ActualOut"] != DBNull.Value && drSelect["ContainerNo"] == DBNull.Value)
                        {
                            dr = dt.Select(string.Format("ShipmentNo = '{0}' AND ActualOut = '{1}' AND ContainerNo IS NULL", drSelect["ShipmentNo"], drSelect["ActualOut"]));
                        }
                        else if (drSelect["ActualOut"] == DBNull.Value && drSelect["ContainerNo"] != DBNull.Value)
                        {
                            dr = dt.Select(string.Format("ShipmentNo = '{0}' AND PlanOut = '{1}' AND ActualOut IS NULL AND ContainerNo = '{2}'", drSelect["ShipmentNo"], drSelect["PlanOut"], drSelect["ContainerNo"]));
                        }
                        else
                        {
                            dr = dt.Select(string.Format("ShipmentNo = '{0}' AND PlanOut = '{1}' AND ActualOut IS NULL AND ContainerNo IS NULL", drSelect["ShipmentNo"], drSelect["PlanOut"]));
                        }
                    }
                    else
                    {
                        dr = dt.Select(string.Format("ShipmentNo = '{0}' AND ActualOut = '{1}' AND ContainerNo = '{2}'", drSelect["ShipmentNo"], drSelect["ActualOut"], drSelect["ContainerNo"]));
                    }
                    foreach (DataRow d in dr)
                    {
                        d["SELECT"] = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                for (int i = 0; i < gdvSearchResult.RowCount; i++)
                {
                    gdvSearchResult.SetRowCellValue(i, gdcSelect, false);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void chkCompletePack_EditValueChanged(object sender, EventArgs e)
        {
            grdSearchResult.DataSource = null;
            if (chkCompletePack.Checked)
            {
                ControlUtil.HiddenControl(false, m_toolBarEdit);
                gdcSelect.VisibleIndex = 6;
                gdcSelect.Visible = true;
            }
            else
            {
                ControlUtil.HiddenControl(true, m_toolBarEdit);
                gdcSelect.VisibleIndex = 6;
                gdcSelect.Visible = false;
            }
        }

        private void rdoTransportStatus_EditValueChanged(object sender, EventArgs e)
        {
            grdSearchResult.DataSource = null;
        }
        #endregion

        #region Override Method
        public override bool OnCommandEdit()
        {
            try
            {                
                OpenDialog(Common.eScreenMode.Edit);
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        #endregion

        #region Generic Function
        private void DataLoading()
        {
            try
            {
                if (!DesignMode)
                {
                    this.ShowWaitScreen();
                    DataTable detailData = BusinessClass.DataLoading(ownerControl.OwnerID
                                                                           ,warehouseControl.WarehouseID
                                                                           ,dtDeliveryDateFrom.DateTime.ToString("yyyy/MM/dd")
                                                                           ,dtDeliveryDateTo.DateTime.ToString("yyyy/MM/dd")
                                                                           ,finalDestinationControl.FinalDestinationID
                                                                           ,portOfDischarge.PortID
                                                                           ,truckCompanyControl.TruckCompanyID
                                                                           ,customerControl.CustomerID
                                                                           ,Convert.ToInt32(((rdoAll.Checked ? 1 : 2).ToString()) + (chkCompletePack.Checked ? 1 : 2).ToString())
                                                                           ,txtContainerNo.Text.Trim()
                                                                           ,dtTransportDateFrom.DateTime.ToString("yyyy/MM/dd")
                                                                           ,dtTransportDateTo.DateTime.ToString("yyyy/MM/dd")
                                                                           ,chkActual.Checked);

                    grdSearchResult.DataSource = detailData;

                    //IdleValidator
                    iv.ClearTicket();
                    foreach (DataRow dtr in detailData.Rows)
                    {
                        iv.PushTicket(Convert.ToDateTime(dtr["DateForValiDate"]), dtr["TransportSeq"].ToString());
                    }

                    if (gdvSearchResult.RowCount == 0)
                    {
                        //ClearAll();
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                    }
                }
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

        private void ClearAll()
        {
            ControlUtil.ClearControlData(this.Controls);
            rdoAll.Checked = true;
            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();
            finalDestinationControl.OwnerID = Common.GetDefaultOwnerID();
            finalDestinationControl.DataLoading();

            dtDeliveryDateFrom.EditValue = ControlUtil.GetStartDate();
            dtDeliveryDateTo.EditValue = ControlUtil.GetEndDate();

            dtTransportDateFrom.EditValue = ControlUtil.GetStartDate();
            dtTransportDateTo.EditValue = ControlUtil.GetEndDate();
            
            grdSearchResult.DataSource = null;
            errorProvider.ClearErrors();
            chkActual.Checked = true;
        }

        private Boolean ValidateDataWhenSearch()
        {
            Boolean noError = true;
            errorProvider.ClearErrors();

            // set require field
            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            //customerControl.ErrorText = Common.GetMessage("I0249");
            //customerControl.RequireField = true;

            noError &= ownerControl.ValidateControl();
            noError &= warehouseControl.ValidateControl();
            //if (false == customerControl.ValidateControl())
            //{
            //    noError = false;
            //}

            if (dtDeliveryDateFrom.EditValue == null)
            {
                errorProvider.SetError(dtDeliveryDateFrom, Common.GetMessage("I0136"));
                noError = false;
            }
            if (dtDeliveryDateTo.EditValue == null)
            {
                errorProvider.SetError(dtDeliveryDateTo, Common.GetMessage("I0136"));
                noError = false;
            }

            if (dtTransportDateFrom.EditValue == null)
            {
                errorProvider.SetError(dtTransportDateFrom, Common.GetMessage("I0237"));
                noError = false;
            }
            if (dtTransportDateTo.EditValue == null)
            {
                errorProvider.SetError(dtTransportDateTo, Common.GetMessage("I0237"));
                noError = false;
            }
            
            return noError;
        }
        
        private void OpenDialog(Common.eScreenMode ScreenMode)
        {
            try
            {
                this.ShowWaitScreen();
                if ((grdSearchResult.DefaultView).DataRowCount == 0 && ScreenMode != Common.eScreenMode.Add)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                }
                else
                {
                    gdvSearchResult.PostEditor();
                    gdvSearchResult.CloseEditor();
                    gdvSearchResult.UpdateCurrentRow();
                    DataTable dt = grdSearchResult.DataSource as DataTable;
                    DataRow[] drr = dt.Select("SELECT = 1");

                    if (drr.Length <= 0)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                        return;
                    }

                    foreach (var dr in drr)
                    {
                        if (!iv.ValidateTicket(dr["TransportSeq"].ToString()))
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                            return;
                        }
                    }                    

                    if (drr.Length > 0)
                    {
                        int[] tranSeq = new int[drr.Length];

                        for (int i = 0; i < drr.Length; i++)
                        {
                            tranSeq[i] = Convert.ToInt32(drr[i]["TransportSeq"]);
                        }

                        Dialog.TransportSeq = tranSeq;
                        Dialog.ScreenMode = ScreenMode;
                        Dialog.IdleValidatorControl = iv;
                        CloseWaitScreen();
                        if (Dialog.ShowDialog(this) == DialogResult.OK)
                        {
                            DataLoading();
                            MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), ""));
                        }
                        Dialog = null;
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.ToString());
            }
            finally
            {
                this.CloseWaitScreen();
            }
        }
        #endregion      
    }
}
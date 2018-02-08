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
using CSI.Business.DataObjects;
using CSI.Business.BusinessFactory.Report;
using DevExpress.XtraReports.UI;
namespace Rubix.Screen.Form.Operation.H_Picking.Dialog
{
    public partial class dlgHPCS011_ReprintPickingList : DialogBase
    {

        #region Member
        private PickingInstruction db;
        #endregion

        #region Properties
        private PickingInstruction BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new PickingInstruction();
                }
                return db;
            }
        }
        #endregion

        #region Constructor
        public dlgHPCS011_ReprintPickingList()
        {
            InitializeComponent();
            dtPickingDateFrom.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtPickingDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingDateFrom.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtPickingDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtPickingDateFrom.Properties.Mask.EditMask = Common.FullDateFormat;

            dtPickingDateTo.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtPickingDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingDateTo.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtPickingDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtPickingDateTo.Properties.Mask.EditMask = Common.FullDateFormat;

            ControlUtil.HiddenControl(true, m_toolBarSave);
            ControlUtil.HiddenControl(false, m_toolBarPrint);
        }
        #endregion

        #region Override Method
        public override bool OnCommandClear()
        {
            try
            {
                ClearAll();
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }

        public override bool OnCommandPrint()
        {
            try
            {
                if (ValidateData())
                {
                    printData();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        #endregion

        #region Event Handler Function
        private void dlgHPCS011_ReprintPickingList_Load(object sender, EventArgs e)
        {
            try
            {
                dtPickingDateFrom.EditValue = ControlUtil.GetStartDate();
                dtPickingDateTo.EditValue = ControlUtil.GetEndDate();

                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                finalDestinationControl.OwnerID = Common.GetDefaultOwnerID();
                finalDestinationControl.DataLoading();
                shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusIdForRePrint();
                shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                shipmentControl.DataLoading();
                pickingControl.StatusIdList = BusinessClass.GetSpecificStatusIdForRePrint();
                pickingControl.ShipmentNo = "-1";
                pickingControl.DataLoading();

                base.HideStatusBar();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
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
                    finalDestinationControl.OwnerID = ownerControl.OwnerID;
                    finalDestinationControl.DataLoading();
                    shipmentControl.OwnerID = ownerControl.OwnerID;
                    shipmentControl.DataLoading();
                    pickingControl.ShipmentNo = "-1";
                    pickingControl.DataLoading();
                }
                else
                {
                    finalDestinationControl.OwnerID = Common.GetDefaultOwnerID();
                    finalDestinationControl.DataLoading();
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                    shipmentControl.DataLoading();
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

        private void shipmentControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (ownerControl.OwnerID != null)
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

        private void dtPickingDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                shipmentControl.PickDateFrom = DataUtil.Convert<DateTime>(dtPickingDateFrom.EditValue);
                shipmentControl.DataLoading();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void dtPickingDateTo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                shipmentControl.PickDateTo = DataUtil.Convert<DateTime>(dtPickingDateTo.EditValue);
                shipmentControl.DataLoading();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
        #endregion
        
        #region Generic Function
        private void printData()
        {
            List<sp_HPCS011_PickingInstruction_SearchReprint_Result> temp = DataLoading();
            PickingListReport dalReport = new PickingListReport();
            if (temp.Count == 0)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0274"));
            }
            else
            {                
                XtraReport rptAll = null;
                foreach (sp_HPCS011_PickingInstruction_SearchReprint_Result item in temp)
                {
                    //Print fuction
                    List<sp_RPT021_PickingList_GetData_Result> tempReport = BusinessClass.GetDataReport(item.ShipmentNo, item.PickingNo);//BusinessClass.GetDataReport(item.ShipmentNo,item.PickingNo);

                    if (tempReport.Count > 0)
                    {
                        Rubix.Screen.Report.rptRPT021_PickingList rpt = new Rubix.Screen.Report.rptRPT021_PickingList(dalReport.GetReportDefaultParams("RPT021"));

                        rpt.DataSource = tempReport;
                        rpt.SetShipmentNoParameter(item.ShipmentNo);
                        rpt.SetPickingNoParameter(item.PickingNo);
                        rpt.SetTotalRecordParameter(tempReport.Count);
                        rpt.SetPrintByParameter(AppConfig.Name);
                        rpt.SubReportDatasource(BusinessClass.GetDataSubReport(tempReport));
                        //ReportUtil.ShowPreview(rpt);

                        // combine report
                        if (rptAll != null)
                        {
                            ReportUtil.CombineReport(rptAll, rpt);
                        }
                        else
                        {
                            rptAll = rpt;
                        }




                    }
                    else
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                        return;
                    }
                }

                if (rptAll != null)
                {
                    ReportUtil.ShowPreview(rptAll);
                }
            }

        }
        private List<sp_HPCS011_PickingInstruction_SearchReprint_Result> DataLoading()
        {
            List<sp_HPCS011_PickingInstruction_SearchReprint_Result> temp = BusinessClass.DataLoadingReprint(ownerControl.OwnerID
                                                                                                                , warehouseControl.WarehouseID
                                                                                                                , shipmentControl.ShipmentNo
                                                                                                                , pickingControl.PickingNo
                                                                                                                , portOfDischargeControl.GetPortID
                                                                                                               , finalDestinationControl.FinalDestinationID
                                                                                                               , DataUtil.Convert<DateTime>(dtPickingDateFrom.EditValue)
                                                                                                               , DataUtil.Convert<DateTime>(dtPickingDateTo.EditValue));
            return temp;

        }
        private void ClearAll()
        {
            ShowWaitScreen();
            ownerControl.ClearData();
            finalDestinationControl.OwnerID = Common.GetDefaultOwnerID();
            finalDestinationControl.DataLoading();
            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();
            shipmentControl.OwnerID = Common.GetDefaultOwnerID();
            shipmentControl.DataLoading();
            pickingControl.ShipmentNo = "-1";
            pickingControl.DataLoading();
            CloseWaitScreen();

        }
        private Boolean ValidateData()
        {
            errorProvider.ClearErrors();
            Boolean noError = true;
            // set require field
            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            if (false == ownerControl.ValidateControl())
            {
                noError = false;
            }
            if (false == warehouseControl.ValidateControl())
            {
                noError = false;
            }

            return noError;
        }
        #endregion
    }
}
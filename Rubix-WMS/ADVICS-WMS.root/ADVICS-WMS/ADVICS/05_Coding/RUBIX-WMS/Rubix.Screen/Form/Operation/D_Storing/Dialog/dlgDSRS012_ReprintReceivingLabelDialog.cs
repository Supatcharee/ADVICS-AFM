/*
20121225:
 * 1. Modify PrintData function for print only pallet selected
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
using CSI.Business.DataObjects;
using DevExpress.XtraReports.UI;
using CSI.Business.BusinessFactory.Report;
using System.Data.Objects;
namespace Rubix.Screen.Form.Operation.D_Storing.Dialog
{
    public partial class dlgDSRS012_ReprintReceivingLabelDialog : DialogBase
    {

        #region Member
        private ConfirmProductStoring db;
        #endregion

        #region Properties
        public ConfirmProductStoring BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ConfirmProductStoring();
                }
                return db;
            }
            set
            {
                db = value;
            }
        }
        public int? OwnerID { get; set; }
        public int? WarehouseID { get; set; }
        public DataTable dtReceivingNo { get; set; }
        #endregion

        #region Constructor
        public dlgDSRS012_ReprintReceivingLabelDialog()
        {
            InitializeComponent();
            this.m_statusBar.Visible = false;
            ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
            ControlUtil.HiddenControl(false, m_toolBarPrint);
            ControlUtil.HiddenControl(true, m_statusBar);
        }
        #endregion

        #region Override Method
        public override bool OnCommandPrint()
        {
            try
            {
                ShowWaitScreen();
                PrintData();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
            return true;
        }
        public override bool OnCommandClear()
        {
            ControlUtil.ClearControlData(this.Controls);
            return true;
        }
        #endregion

        #region Event Handler Function

        private void dlgDSRS012_ReprintReceivingLabelDialog_Load(object sender, EventArgs e)
        {
            try
            {
                base.HideStatusBar();
                ownerControl.ClearData();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                deArrivalDateFrom.EditValue = ControlUtil.GetStartDate();
                deArrivalDateTo.EditValue = ControlUtil.GetEndDate();
                ownerControl.OwnerID = OwnerID;
                warehouseControl.WarehouseID = WarehouseID;
                grdSearchResult.DataSource = dtReceivingNo;
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
                if (ownerControl.OwnerID != null)
                {
                    warehouseControl.OwnerID = ownerControl.OwnerID;
                    warehouseControl.DataLoading();
                }
                else
                {
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                }
            }
            catch (Exception ex)
            {
                 MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSearchCriteria())
                {
                    ShowWaitScreen();
                    grdSearchResult.DataSource = BusinessClass.ReprintReceivingLabelDataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, deArrivalDateFrom.DateTime.ToString("yyyy/MM/dd"), deArrivalDateTo.DateTime.ToString("yyyy/MM/dd"));
                    CloseWaitScreen();

                    if (gdvSearchResult.RowCount <= 0)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ControlUtil.ClearControlData(this.Controls);
                ownerControl.ClearData();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                grdSearchResult.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
        #endregion

        #region Generic Function
        private void PrintData()
        {           
            if (gdvSearchResult.GetFocusedDataRow() == null)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0235"));
                return;
            }

            XtraReport rpt = null;
            ReceivingInstruction dalReport = new ReceivingInstruction();
            string palletNo = null;
            DataRow dr = gdvSearchResult.GetFocusedDataRow();
            
            List<sp_CRCS020_StoringInstruction_Pallet_Search_Result> palletList = new List<sp_CRCS020_StoringInstruction_Pallet_Search_Result>();
            if (string.IsNullOrWhiteSpace(palletNo))
            {
                palletList = BusinessClass.GetPalletList(dr["ReceivingNo"].ToString());
            }
            else
            {
                palletList.Add(new sp_CRCS020_StoringInstruction_Pallet_Search_Result()
                {
                    PalletNo = palletNo
                });
            }

            foreach (sp_CRCS020_StoringInstruction_Pallet_Search_Result pallet in palletList)
            {
                List<sp_RPT019_ReceivingLabel_GetData_Result> labelList = dalReport.GetReceivingLabel(pallet.PalletNo, null, null, null, null, null);

                if (labelList.Count > 0)
                {
                    for (int i = 0; i < labelList[0].LabelCnt; i++)
                    {
                        Rubix.Screen.Report.rptRPT019_ReceivingQRCode rcvLabelCover = new Rubix.Screen.Report.rptRPT019_ReceivingQRCode(BusinessClass.GetReportDefaultParams("RPT019"));
                        rcvLabelCover.DataSource = labelList;
                        String header = BusinessClass.GetLabelHeader();
                        rcvLabelCover.SetParameterLabelHeader(header);

                        if (rpt != null)
                            rpt = ReportUtil.CombineReport(rpt, rcvLabelCover);
                        else
                        {
                            rpt = rcvLabelCover;
                            rpt.CreateDocument();
                        }
                    }
                }
            }
            if (rpt != null)
            {
                ReportUtil.ShowPreview(rpt);
            }
            else
            {
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0345"));
            }
        }

        private bool ValidateSearchCriteria()
        {
            errorProvider.ClearErrors();
            bool validate = true;

            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;
            
            if (!ownerControl.ValidateControl())
            {
                validate = false;
            }
            if (!warehouseControl.ValidateControl())
            {
                validate = false;
            }

            return validate;
        }
        #endregion

    }
}
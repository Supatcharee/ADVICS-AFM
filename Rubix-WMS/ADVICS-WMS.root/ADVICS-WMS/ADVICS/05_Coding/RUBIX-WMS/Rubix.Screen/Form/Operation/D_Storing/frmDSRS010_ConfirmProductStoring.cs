using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using CSI.Business.Operation;
using Rubix.Framework;
using CSI.Business.DataObjects;
using DevExpress.XtraReports.UI;
using CSI.Business.BusinessFactory.Report;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
namespace Rubix.Screen.Form.Operation.D_Storing
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Edit, Permission.Export, Permission.Confirm, Permission.Print)]
    public partial class frmDSRS010_ConfirmProductStoring : FormBase
    {
        #region Member
        //rcv-line-seq
        private const string KEY_FORMAT = "{0}-{1}-{2}";
        private ConfirmProductStoring db;
        private Dialog.dlgDSRS011_ConfirmProdStoring m_Dialog = null;
        private Dialog.dlgDSRS012_ReprintReceivingLabelDialog m_RePrintDialog = null;
        private Dialog.dlgDSRS013_COADownloadDialog m_COADownload  = null;
        private Dictionary<string, List<sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result>> detail;
        #endregion

        #region Properties
        private ConfirmProductStoring BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ConfirmProductStoring();
                }
                return db;
            }
        }
        private Dialog.dlgDSRS011_ConfirmProdStoring Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgDSRS011_ConfirmProdStoring();
                }
                return m_Dialog;
            }
            set
            {
                m_Dialog = value;
            }
        }
        private Dialog.dlgDSRS013_COADownloadDialog COADownload
        {
            get
            {
                if (m_COADownload == null)
                {
                    return m_COADownload = new Dialog.dlgDSRS013_COADownloadDialog();
                }
                return m_COADownload;
            }
        }
        private Dialog.dlgDSRS012_ReprintReceivingLabelDialog RePrintDialog
        {
            get
            {
                if (m_RePrintDialog == null)
                {
                    return m_RePrintDialog = new Dialog.dlgDSRS012_ReprintReceivingLabelDialog();
                }
                return m_RePrintDialog;
            }
            set
            {
                m_RePrintDialog = null;
            }
        }
        private List<CSI.Business.DataObjects.sp_DSRS010_ConfirmProductStoring_SearchAll_Result> DataSource { get; set; }
        private List<CSI.Business.DataObjects.sp_DSRS010_ConfirmProductStoring_SearchAll_Result> DisplayDataSource
        {
            get;
            set;
        }

        #endregion
        
        #region Constructor
        public frmDSRS010_ConfirmProductStoring()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarAdd, m_toolBarDelete, m_toolBarSave, m_toolBarConfirm, m_toolBarCancel, m_toolBarRefresh);
            ControlUtil.HiddenControl(false, m_toolBarEdit, m_toolBarConfirm, m_toolBarExport);

            base.SetExpandGroupControl(grpCriteria);
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            detail = new Dictionary<string, List<sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result>>();
            
            gdcTransitDate.DisplayFormat.FormatString = Common.FullDateFormat;
            gdcTransitDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
        }
        #endregion

        #region Override Method
        public override bool OnCommandEdit()
        {
            try
            {
                sp_DSRS010_ConfirmProductStoring_SearchAll_Result data = (sp_DSRS010_ConfirmProductStoring_SearchAll_Result)gdvSearchResult.GetFocusedRow();
                if (data != null)
                {
                    if (data.StatusID == BusinessClass.GetConfirmTransitStatusID() || data.TransitCompleteFlag)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0139"));
                        return false;
                    }
                    OpenDialog(Common.eScreenMode.Edit);
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            } 
        }
        public override bool OnCommandConfirm()
        {
            try
            {
                if (ValidateData())
                {
                    if (BusinessClass.Confirm(this.DisplayDataSource) != 0)
                    {
                        //comment ออก เพราะ ADVICS ไม่ได้ใช้ --> eed comment เอง
                        //if (base.CanPrint)
                        //{
                        //    Print();
                        //}
                    }
                    MessageDialog.ShowInformationMsg(Common.GetMessage("I0264"));
                    DataLoading();
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException is SqlException && ((SqlException)ex.InnerException).Number == 50001)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0270"));
                    }
                    else
                    {
                        MessageDialog.ShowSystemErrorMsg(this, ex);
                    }

                }
                else
                {
                    MessageDialog.ShowSystemErrorMsg(this, ex);
                }
            }
            return base.OnCommandConfirm();
        }
        public override bool OnCommandCancel()
        {
            //BusinessClass.ClearData(this.DataSource);
            return base.OnCommandCancel();
        }
        #endregion

        #region Event Handler Function
        private void frmDSRS010_ConfirmProductStoring_Load(object sender, EventArgs e)
        {
            try
            {
                ownerControl.Focus();
                CSI.Business.Common.Product prod = new CSI.Business.Common.Product();
                repProductCode.DataSource = prod.DataLoading(null);
                repProductCode.DisplayMember = "ProductCode";
                repProductCode.ValueMember = "ProductID";
                repProductName.DataSource = prod.DataLoading(null);
                repProductName.DisplayMember = "ProductLongName";
                repProductName.ValueMember = "ProductID";
                CSI.Business.Common.ProductCondition con = new CSI.Business.Common.ProductCondition();
                repProductCondition.DataSource = con.DataLoading();
                repProductCondition.DisplayMember = "ProductConditionName";
                repProductCondition.ValueMember = "ProductConditionID";
                CSI.Business.Common.Location loc = new CSI.Business.Common.Location();
                repLocation.DataSource = loc.DataLoading(null);
                repLocation.DisplayMember = "LocationCode";
                repLocation.ValueMember = "LocationID";

                gdvSearchResult.OptionsBehavior.Editable = true;

                detail.Clear();

                ControlUtil.HiddenControl(true, m_toolBarPrint);
                btnPrintReceivingLabel.Visible = base.CanPrint;

                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                supplierControl.OwnerID = Common.GetDefaultOwnerID();
                supplierControl.DataLoading();
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
                if (ValidateSearchCriteria())
                {
                    DataLoading();
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
                ShowWaitScreen();
                ControlUtil.ClearControlData(this.Controls);
                chkUnconfirm.Checked = true;
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                supplierControl.OwnerID = Common.GetDefaultOwnerID();
                supplierControl.DataLoading();
                dtTransitDateFrom.EditValue = ControlUtil.GetStartDate();
                dtTransitDateTo.EditValue = ControlUtil.GetEndDate();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnUnselect_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                for (int i = 0; i < gdvSearchResult.RowCount; i++)
                {
                    gdvSearchResult.SetRowCellValue(i, gdcSelect, false);
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gdvSearchResult.RowCount; i++)
                {
                    sp_DSRS010_ConfirmProductStoring_SearchAll_Result data = (sp_DSRS010_ConfirmProductStoring_SearchAll_Result)gdvSearchResult.GetRow(i);
                    if (data != null)
                        if (!data.LocationID.HasValue)
                        {
                            continue;
                        }
                    if (data.StatusID == BusinessClass.GetConfirmTransitStatusID() || data.TransitCompleteFlag)
                    {
                        continue;
                    }
                    gdvSearchResult.SetRowCellValue(i, gdcSelect, true);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        
        private void repCheck_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                sp_DSRS010_ConfirmProductStoring_SearchAll_Result data = (sp_DSRS010_ConfirmProductStoring_SearchAll_Result)gdvSearchResult.GetFocusedRow();
                if (data != null)
                {
                    if ((bool)e.NewValue)
                    {
                        e.Cancel = !data.LocationID.HasValue;
                        if (e.Cancel)
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0138"));
                            return;
                        }
                        e.Cancel = (data.StatusID == BusinessClass.GetConfirmTransitStatusID() || data.TransitCompleteFlag);
                        if (e.Cancel)
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0139"));
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void repView_Click(object sender, EventArgs e)
        {
            try
            {
                sp_DSRS010_ConfirmProductStoring_SearchAll_Result data = (sp_DSRS010_ConfirmProductStoring_SearchAll_Result)gdvSearchResult.GetFocusedRow();
                COADownload.ReceivingNo = data.ReceivingNo;
                COADownload.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnPrintReceivingLabel_Click(object sender, EventArgs e)
        {
            OpenRePrintDialog();
        }

        private void repCheck_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gdvSearchResult.PostEditor();
                sp_DSRS010_ConfirmProductStoring_SearchAll_Result data = (sp_DSRS010_ConfirmProductStoring_SearchAll_Result)gdvSearchResult.GetFocusedRow();
                foreach (sp_DSRS010_ConfirmProductStoring_SearchAll_Result rec in this.DisplayDataSource.Where(c => c.ReceivingNo.Equals(data.ReceivingNo, StringComparison.InvariantCultureIgnoreCase) && c.LineNo == data.LineNo && c.Installment == data.Installment && c.ReceiveSeq == data.ReceiveSeq).ToList())
                {
                    rec.Select = data.Select;
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

            if (e.Column == gdcReceivingNo)
            {
                sp_DSRS010_ConfirmProductStoring_SearchAll_Result firstRow = (sp_DSRS010_ConfirmProductStoring_SearchAll_Result)gdvSearchResult.GetRow(e.RowHandle1);
                sp_DSRS010_ConfirmProductStoring_SearchAll_Result secondRow = (sp_DSRS010_ConfirmProductStoring_SearchAll_Result)gdvSearchResult.GetRow(e.RowHandle2);
                if (firstRow.ReceivingNo.Equals(secondRow.ReceivingNo))
                    e.Merge = true;
                else
                    e.Merge = false;
            }
            else if (e.Column == gdcLineNo || e.Column == gdcPalletNo || e.Column == gdcLotNo || e.Column == gdcProductCode || e.Column == gdcProductName || e.Column == gdcProductCondition || e.Column == gdcQtyInstruction)
            {
                sp_DSRS010_ConfirmProductStoring_SearchAll_Result firstRow = (sp_DSRS010_ConfirmProductStoring_SearchAll_Result)gdvSearchResult.GetRow(e.RowHandle1);
                sp_DSRS010_ConfirmProductStoring_SearchAll_Result secondRow = (sp_DSRS010_ConfirmProductStoring_SearchAll_Result)gdvSearchResult.GetRow(e.RowHandle2);
                if (firstRow.ReceivingNo.Equals(secondRow.ReceivingNo) && firstRow.LineNo == secondRow.LineNo)
                    e.Merge = true;
                else
                    e.Merge = false;
            }
            else if (e.Column == gdcQtyReceiving)
            {
                sp_DSRS010_ConfirmProductStoring_SearchAll_Result firstRow = (sp_DSRS010_ConfirmProductStoring_SearchAll_Result)gdvSearchResult.GetRow(e.RowHandle1);
                sp_DSRS010_ConfirmProductStoring_SearchAll_Result secondRow = (sp_DSRS010_ConfirmProductStoring_SearchAll_Result)gdvSearchResult.GetRow(e.RowHandle2);
                if (firstRow.ReceivingNo.Equals(secondRow.ReceivingNo) && firstRow.LineNo == secondRow.LineNo && firstRow.ReceiveSeq == secondRow.ReceiveSeq)
                    e.Merge = true;
                else
                    e.Merge = false;
            }
            else
                e.Merge = false;
        }

        private void chkUnconfirm_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ControlUtil.EnableControl(true, m_toolBarConfirm, m_toolBarEdit);
                grdSearchResult.DataSource = null;
                this.DisplayDataSource = null;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ControlUtil.EnableControl(false, m_toolBarConfirm, m_toolBarEdit);
                grdSearchResult.DataSource = null;
                this.DisplayDataSource = null;
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
                    supplierControl.OwnerID = ownerControl.OwnerID;
                    supplierControl.DataLoading();
                }
                else
                {
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    supplierControl.OwnerID = Common.GetDefaultOwnerID();
                    supplierControl.DataLoading();
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void gdvSearchResult_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            sp_DSRS010_ConfirmProductStoring_SearchAll_Result sel = (sp_DSRS010_ConfirmProductStoring_SearchAll_Result)gdvSearchResult.GetRow(e.RowHandle);
            if (sel != null && sel.TransitSeq.HasValue && sel.TransitSeq.Value != 0)
            {
                if (e.Column == gdcLocation || e.Column == gdcTransitDate || e.Column == gdcTransitStatus || e.Column == gdcActualQty || e.Column == grcView || e.Column == gdcTransitUnit)
                    e.Appearance.BackColor = Common.CompleteColor();
            }
        }
        #endregion

        #region Generic Function
        private void OpenDialog(Common.eScreenMode ScreenMode)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (gdvSearchResult.GetFocusedRow() == null)
                {
                    MessageDialog.ShowInformationMsg(Common.GetMessage("I0011"));
                    return;
                }
                Dialog.BusinessClass = this.BusinessClass;
                Dialog.Header = (sp_DSRS010_ConfirmProductStoring_SearchAll_Result)gdvSearchResult.GetFocusedRow();
                Dialog.Detail = DataUtil.CloneListOfComplexType<sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result>(detail[string.Format(KEY_FORMAT, Dialog.Header.ReceivingNo, Dialog.Header.LineNo, Dialog.Header.ReceiveSeq)]);
                Dialog.UnitCode = Dialog.Header.UnitCode;

                if (Dialog.ShowDialog(this) == DialogResult.OK)
                {
                    detail[string.Format(KEY_FORMAT, Dialog.Header.ReceivingNo, Dialog.Header.LineNo, Dialog.Header.ReceiveSeq)] = Dialog.Detail;
                    this.DisplayDataSource = GenDisplayDataSource(this.DataSource);
                    BindingSource bs = new BindingSource();
                    bs.DataSource = this.DisplayDataSource;
                    grdSearchResult.DataSource = bs;
                }
                Dialog = null;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void OpenRePrintDialog()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                RePrintDialog.BusinessClass = this.BusinessClass;
                RePrintDialog.OwnerID = ownerControl.OwnerID;
                RePrintDialog.WarehouseID = warehouseControl.WarehouseID;
                DataTable dt = new DataTable();
                dt.Columns.Add("ReceivingNo", typeof(string));

                if (this.DisplayDataSource != null)
                {
                    List<string> SelectList = this.DisplayDataSource.Where(c => c.Select == true).Select(c => c.ReceivingNo).Distinct().ToList();
                    
                    foreach(string select in SelectList)
                    {
                        DataRow dr = dt.NewRow();
                        dr["ReceivingNo"] = select;
                        dt.Rows.Add(dr);
                    }
                    dt.AcceptChanges();
                    RePrintDialog.dtReceivingNo = dt.Copy();                    
                }
                dt = null;

                RePrintDialog.ShowDialog(this);
                RePrintDialog = null;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void DataLoading()
        {
            try
            {
                BindingSource bs = new BindingSource();
                this.ShowWaitScreen();
                detail.Clear();
                int? AMFlg = chkAfterMarket.Checked ? (int?)1 : 0;
                int? PMFlg = chkPM.Checked ? (int?)1 : 0;
                int? PartFlg = chkPart.Checked ? (int?)1 : 0;

                this.DataSource = BusinessClass.DataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, txtSlipNo.Text.Trim(), DataUtil.Convert<int>(txtLineNo.EditValue), supplierControl.SupplierID, !chkUnconfirm.Checked, AMFlg, DataUtil.Convert<DateTime>(dtTransitDateFrom.EditValue), DataUtil.Convert<DateTime>(dtTransitDateTo.EditValue), PMFlg, PartFlg);
                
                foreach (sp_DSRS010_ConfirmProductStoring_SearchAll_Result rec in this.DataSource)
                {
                    if (!detail.ContainsKey(string.Format(KEY_FORMAT, rec.ReceivingNo, rec.LineNo, rec.ReceiveSeq)))
                    {
                        detail.Add(string.Format(KEY_FORMAT, rec.ReceivingNo, rec.LineNo, rec.ReceiveSeq), new List<sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result>());
                    }
                    if (!rec.LocationID.HasValue)
                    {
                        List<sp_DSRS010_ConfirmProductStoring_LoadSuggest_Result> list = BusinessClass.LoadSuggestion(rec.ReceivingNo, rec.LineNo, rec.ReceiveSeq);
                        foreach (sp_DSRS010_ConfirmProductStoring_LoadSuggest_Result l in list)
                        {
                            sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result RowAdd = new sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result();
                            RowAdd.CurrentCapacity = l.CurrentCapacity;
                            RowAdd.FullCapacityFlag = l.FullCapacityFlag;
                            RowAdd.LocationID = l.LocationID;
                            RowAdd.LocationTypeID = l.LocationTypeID;
                            RowAdd.StockActualQty = l.StockActualQty;
                            RowAdd.TotalCapacity = l.TotalCapacity;
                            RowAdd.TransitSeq = l.TransitSeq;
                            RowAdd.UnitCode = l.UnitCode;
                            detail[string.Format(KEY_FORMAT, rec.ReceivingNo, rec.LineNo, rec.ReceiveSeq)].Add(RowAdd);
                        }
                    }

                }
                this.DisplayDataSource = GenDisplayDataSource(this.DataSource);
                bs.DataSource = this.DisplayDataSource;
                grdSearchResult.DataSource = bs;

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

        private bool ValidateData()
        {
            if (this.DisplayDataSource == null)
                return false;
            //check seq in the same line must be select
            List<sp_DSRS010_ConfirmProductStoring_SearchAll_Result> selectList = this.DisplayDataSource.Where(c => c.Select.HasValue && c.Select.Value).ToList();
            foreach(sp_DSRS010_ConfirmProductStoring_SearchAll_Result tranSeq in selectList) {

                if (this.DisplayDataSource.Exists(c => (!c.Select.HasValue || !c.Select.Value) && c.ReceivingNo == tranSeq.ReceivingNo && c.LineNo == tranSeq.LineNo && c.ReceiveSeq == tranSeq.ReceiveSeq)) 
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0167"));
                    return false;
                }

                // 30 Jan 2013: add validate transaction date 
                // 15 Mar 2016 remove valid transit date
                //if (false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(tranSeq.TransitDate)) {
                //    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0236"));
                //    return false;
                //}
                // end 15 Mar 2016
                // end 30 Jan 2013
            }
            // 20121217: add for warn user that don't select record to confirm
            if (selectList.Count == 0)
            {
                // 20130104: use I0199 message
                //MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0235"));
                // end 20130104
                return false;
            }
            // end 20121217
            return true;
        }

        private void Print()
        {
            if (this.DisplayDataSource == null)
            {
                return;
            }
            ShowWaitScreen();
            XtraReport rpt = null;
            ReceivingInstruction dalReport = new ReceivingInstruction();
            List<string> palletList = new List<string>();
            foreach (sp_DSRS010_ConfirmProductStoring_SearchAll_Result data in this.DisplayDataSource)
            {
                if (data.Select.HasValue && data.Select.Value)
                {
                    if (palletList.Contains(data.PalletNo))
                    {
                        continue;
                    }

                    palletList.Add(data.PalletNo);
                    List<sp_RPT019_ReceivingLabel_GetData_Result> labelList = dalReport.GetReceivingLabel(data.PalletNo, data.LocationID, data.ProductID, data.LotNo, data.ProductConditionID, null);
                    List<sp_RPT019_ReceivingLabel_GetData_Result> coverList = new List<sp_RPT019_ReceivingLabel_GetData_Result>();
                    int removeCnt = 0;
                    for (removeCnt = 0; removeCnt < 3 && removeCnt < labelList.Count; removeCnt++)
                    {
                        coverList.Add(labelList[removeCnt]);
                    }
                    labelList.RemoveRange(0, removeCnt);
                    if (removeCnt > 0)
                    {
                        for (int i = 0; i < coverList[0].LabelCnt; i++)
                        {
                            Rubix.Screen.Report.rptRPT019_ReceivingQRCode rcvLabelCover = new Rubix.Screen.Report.rptRPT019_ReceivingQRCode(BusinessClass.GetReportDefaultParams("RPT019"));
                            String header = BusinessClass.GetLabelHeader();
                            rcvLabelCover.SetParameterLabelHeader(header);
                            rcvLabelCover.DataSource = coverList;

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
            }
            
            if (rpt != null)
            {
                ReportUtil.ShowPreview(rpt);
            }
            CloseWaitScreen();
        }

        public List<sp_DSRS010_ConfirmProductStoring_SearchAll_Result> GenDisplayDataSource(List<sp_DSRS010_ConfirmProductStoring_SearchAll_Result> list)
        {
            List<sp_DSRS010_ConfirmProductStoring_SearchAll_Result> result = new List<sp_DSRS010_ConfirmProductStoring_SearchAll_Result>();
            int line = 0;
            foreach (sp_DSRS010_ConfirmProductStoring_SearchAll_Result data in list)
            {
                if (this.detail[string.Format(KEY_FORMAT, data.ReceivingNo, data.LineNo, data.ReceiveSeq)].Count > 0)
                {
                    foreach (sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result confirm in this.detail[string.Format(KEY_FORMAT, data.ReceivingNo, data.LineNo, data.ReceiveSeq)])
                    {

                        sp_DSRS010_ConfirmProductStoring_SearchAll_Result newdata = new sp_DSRS010_ConfirmProductStoring_SearchAll_Result();
                        newdata.OwnerID = data.OwnerID;
                        newdata.WarehouseID = data.WarehouseID;
                        newdata.Installment = data.Installment;
                        newdata.LineNo = data.LineNo;
                        newdata.LotNo = data.LotNo;
                        newdata.PalletNo = data.PalletNo;
                        newdata.ProductConditionID = data.ProductConditionID;
                        newdata.ProductID = data.ProductID;
                        newdata.Qty = data.Qty;
                        newdata.ReceiveQty = data.ReceiveQty;
                        newdata.ReceiveSeq = data.ReceiveSeq;
                        newdata.ReceivingNo = data.ReceivingNo;
                        newdata.Select = data.Select;
                        newdata.SortedLineNo = ++line;
                        newdata.StatusID = data.StatusID;
                        newdata.TransitDate = data.TransitDate;
                        newdata.TransitStatus = data.TransitStatus;

                        newdata.LocationID = confirm.LocationID;
                        newdata.TransitQty = confirm.StockActualQty;
                        newdata.FullFlag = confirm.FullCapacityFlag;
                        newdata.TransitSeq = confirm.TransitSeq;
                        newdata.UnitCode = confirm.UnitCode;
                        if (confirm.TransitSeq != 0)
                            newdata.TransitStatus = "Transited";
                        else
                            newdata.TransitStatus = "Not Transited";
                        result.Add(newdata);
                    }
                }
                else
                {
                    data.SortedLineNo = ++line;
                    result.Add(data);
                }
            }
            return result;
        }

        private bool ValidateSearchCriteria()
        {
            errorProvider.ClearErrors();
            bool validate = true;

            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            //supplierControl.ErrorText = Common.GetMessage("I0300");
            //supplierControl.RequireField = true;

            validate &= ownerControl.ValidateControl();
            validate &= warehouseControl.ValidateControl();

            //if (!supplierControl.ValidateControl())
            //{
            //    validate = false;
            //}

            return validate;
        }
        #endregion      

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSI.Business.Operation;
using DevExpress.XtraGrid;
using Rubix.Framework;
using CSI.Business.DataObjects;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using CSI.Business.BusinessFactory.Common;
using System.Data;
using Rubix.Screen.Report;
using CSI.Business.Report;
namespace Rubix.Screen.Form.Operation.C_Receiving
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Edit, Permission.Export, Permission.Confirm)]
    public partial class frmCRCS050_ProductReceiveEntry : FormBase
    {
        #region Member
        private ProductReceiveEntry db;
        private Dialog.frmCRCS051_ConfirmReceiveDetail m_Dialog = null;
        private Dictionary<string, ConfirmDetail> detail;
        private PurchaseOrderReport m_rptPurchaseOrderReport = null;
        #endregion

        #region Properties
        private Dialog.frmCRCS051_ConfirmReceiveDetail Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.frmCRCS051_ConfirmReceiveDetail();
                }
                return m_Dialog;
            }
            set
            {
                m_Dialog = value;
            }
        }
        private ProductReceiveEntry BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ProductReceiveEntry();
                }
                return db;
            }
        }
        private PurchaseOrderReport ReportBusiness
        {
            get
            {
                if (m_rptPurchaseOrderReport == null)
                {
                    m_rptPurchaseOrderReport = new PurchaseOrderReport();
                }
                return m_rptPurchaseOrderReport;
            }
        }
        private Common.eScreenMode ScreenMode { get; set; }

        private List<CSI.Business.DataObjects.sp_CRCS050_ProductReceiveEntry_SearchAll_Result> DataSource { get; set; }
        #endregion
        
        #region Constructor
        public frmCRCS050_ProductReceiveEntry()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarAdd, m_toolBarDelete, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(grpSearchCriteria);
            iv = new IdleValidator("tbt_ReceivingInstructionHeader", "UpdateDate", "ReceivingNo", "Installment");
        }
        #endregion

        #region Override Method
        public override bool OnCommandEdit()
        {
            try
            {
                if (gdvSearchResult.GetFocusedRow() == null)
                {
                    return false;
                }
                sp_CRCS050_ProductReceiveEntry_SearchAll_Result data = (sp_CRCS050_ProductReceiveEntry_SearchAll_Result)gdvSearchResult.GetFocusedRow();

                if (!iv.ValidateTicket(data.ReceivingNo, data.Installment.ToString()))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));      
                    return false;
                }

                Dialog.IdleValidatorControl = iv;
                Dialog.Line = data.LineNo;
                Dialog.ReceivingNo = data.ReceivingNo;
                Dialog.Installment = data.Installment;
                string revKey = string.Format("{0}|{1}", data.ReceivingNo, data.Installment);

                if (detail.ContainsKey(revKey) && detail[revKey].Data.Count > 0)
                {
                    List<sp_CRCS051_ConfirmReceivingDetail_Get_Result> list = new List<sp_CRCS051_ConfirmReceivingDetail_Get_Result>();
                    list.AddRange(detail[revKey].Data);
                    Dialog.Data = list;
                    Dialog.ReceivingNo = detail[revKey].ReceivingNo;
                    Dialog.ReceivingDate = detail[revKey].ReceivingDate;
                    Dialog.NoOfPallet = detail[revKey].NoOfPallet;
                    Dialog.ConfirmAll = detail[revKey].IsConfirmCompletely;
                }
                else
                {
                    Dialog.Data = null;
                    Dialog.NoOfPallet = 0;
                }
                if (Dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (detail.ContainsKey(revKey))
                    {
                        detail[revKey].Data.Clear();
                    }
                    else
                    {
                        detail.Add(revKey, new ConfirmDetail());
                    }
                    List<sp_CRCS051_ConfirmReceivingDetail_Get_Result> list = new List<sp_CRCS051_ConfirmReceivingDetail_Get_Result>();
                    list.AddRange(Dialog.Data);
                    detail[revKey].Data.AddRange(list);
                    detail[revKey].ReceivingDate = Dialog.ReceivingDate;
                    detail[revKey].ReceivingNo = Dialog.ReceivingNo;
                    detail[revKey].NoOfPallet = Dialog.NoOfPallet;
                    detail[revKey].IsConfirmCompletely = Dialog.ConfirmAll;

                    ShowWaitScreen();
                    foreach (sp_CRCS050_ProductReceiveEntry_SearchAll_Result rec in this.DataSource.Where(c => c.Installment == data.Installment && c.ReceivingNo.Equals(data.ReceivingNo, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        decimal? rcvQty = detail[revKey].Data.Where(c => c.LineNo == rec.LineNo).Sum(c => c.ReceiveQty);
                        decimal? NumberOfUnitLevel3 = detail[revKey].Data.Where(c => c.LineNo == rec.LineNo).Max(c => c.NumberOfUnitLevel3);

                        if (this.Dialog.ReceivingDate.HasValue)
                        {
                            rec.ReceivedDate = this.Dialog.ReceivingDate.Value;
                        }

                        if (rcvQty.HasValue && NumberOfUnitLevel3.HasValue)
                        {
                            rec.ReceiveQtyLv3 = (rcvQty.Value * NumberOfUnitLevel3.Value)  + rec.BaseReceiveQtyLv3;
                            rec.ReceiveQtyLv2 = rcvQty.Value + rec.BaseReceiveQtyLv2;
                        }

                        if (detail[revKey].NoOfPallet.HasValue)
                        {
                            if (rec.BaseNoOfPallet.HasValue)
                            {
                                rec.NoOfPallet = detail[revKey].NoOfPallet + rec.BaseNoOfPallet;
                            }
                            else
                            {
                                rec.NoOfPallet = detail[revKey].NoOfPallet;
                            }
                        }
                        else
                        {
                            if (rec.BaseNoOfPallet.HasValue)
                            {
                                rec.NoOfPallet = detail[revKey].NoOfPallet + rec.BaseNoOfPallet;
                            }
                            else
                            {
                                rec.NoOfPallet = detail[revKey].NoOfPallet;
                            }
                        }
                    }
                    CloseWaitScreen();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        public override bool OnCommandConfirm()
        {
            if (true == ValidateOnConfirm())
            {
                gdvSearchResult.PostEditor();
                Confirm();
            }
            return true;
        }
        #endregion

        #region Event Handler Function
        private void frmCRCS050_ProductReceiveEntry_Load(object sender, EventArgs e)
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
                this.ScreenMode = Common.eScreenMode.View;
                InitControl();

                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                supplierControl.OwnerID = Common.GetDefaultOwnerID();
                supplierControl.DataLoading();

                dtArrivalDateFrom.EditValue = ControlUtil.GetStartDate();
                dtArrivalDateTo.EditValue = ControlUtil.GetEndDate();
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
                    detail = new Dictionary<string, ConfirmDetail>();
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

                this.DataSource = null;
                detail = new Dictionary<string, ConfirmDetail>();
                ControlUtil.ClearControlData(this.Controls);
                BusinessClass.ResetContext();
                rdoReceivingIncomplete.Checked = true;

                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                supplierControl.OwnerID = Common.GetDefaultOwnerID();
                supplierControl.DataLoading();

                dtArrivalDateFrom.EditValue = ControlUtil.GetStartDate();
                dtArrivalDateTo.EditValue = ControlUtil.GetEndDate();

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
                ShowWaitScreen();
                //for (int i = 0; i < gdvSearchResult.RowCount; i++)
                //{
                //    sp_CRCS050_ProductReceiveEntry_SearchAll_Result data = (sp_CRCS050_ProductReceiveEntry_SearchAll_Result)gdvSearchResult.GetRow(i);

                //    string msgID;
                //    bool canCheck = true;
                //    //if (BusinessClass.CheckWorkMethod(data.OwnerID, data.WarehouseID, out msgID))
                //    //{
                //    //    canCheck = true;
                //    //}
                //    if (data.ReceiveQtyLv3 <= 0 || data.StatusID >= CSI.Business.Common.Status.CompleteReceiving)
                //    {
                //        canCheck = false;
                //    }
                //    gdvSearchResult.SetRowCellValue(i, gdcSelect, canCheck);
                //}

                if (rdoReceivingIncomplete.Checked)
                {
                    foreach (sp_CRCS050_ProductReceiveEntry_SearchAll_Result rec in this.DataSource.Where(c => c.ReceiveQtyLv3 > 0 && c.StatusID < CSI.Business.Common.Status.CompleteReceiving).ToList())
                    {
                        rec.SELECT = true;
                    }
                }
                else
                {
                    foreach (sp_CRCS050_ProductReceiveEntry_SearchAll_Result rec in this.DataSource.Where(c => c.StatusID >= CSI.Business.Common.Status.CompleteReceiving).ToList())
                    {
                        rec.SELECT = true;
                    }
                }
                grdSearchResult.RefreshDataSource();

                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void frmCRCS050_ProductReceiveEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.ScreenMode == Common.eScreenMode.Edit)
            {
                e.Cancel = (MessageDialog.ShowConfirmationMsg(this, Common.GetMessage("I0004")) != DialogButton.Yes);
            }
        }
        
        private void gdvSearchResult_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                e.Handled = true;
                if (e.Column == gdcReceivingNo 
                    || e.Column == gdcInstallment 
                    || e.Column == gdcPONo 
                    || e.Column == gdcPDSNo
                    || e.Column == gdcLineNo
                    || e.Column == gdcArrivalDate
                    || e.Column == gdcSupplierCode
                    || e.Column == gdcSupplierLongName)
                {
                    sp_CRCS050_ProductReceiveEntry_SearchAll_Result firstRow = (sp_CRCS050_ProductReceiveEntry_SearchAll_Result)gdvSearchResult.GetRow(e.RowHandle1);
                    sp_CRCS050_ProductReceiveEntry_SearchAll_Result secondRow = (sp_CRCS050_ProductReceiveEntry_SearchAll_Result)gdvSearchResult.GetRow(e.RowHandle2);


                    if (firstRow.ReceivingNo.Equals(secondRow.ReceivingNo) && e.Column != gdcInstallment && e.Column != gdcLineNo)
                    {
                        e.Merge = true;
                    }
                    else if (firstRow.ReceivingNo.Equals(secondRow.ReceivingNo) && firstRow.Installment.Equals(secondRow.Installment) && e.Column == gdcInstallment)
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }

                    if (firstRow.ReceivingNo.Equals(secondRow.ReceivingNo)
                        && firstRow.LineNo.Equals(secondRow.LineNo) 
                        && e.Column == gdcLineNo)
                    {
                        e.Merge = true;
                    }
                    
                }
                else
                {
                    e.Merge = false;
                }
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

        private void repReceiveDate_DateTimeChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.DataSource != null && this.DataSource.Count > 0)
                {
                    sp_CRCS050_ProductReceiveEntry_SearchAll_Result sel = (sp_CRCS050_ProductReceiveEntry_SearchAll_Result)gdvSearchResult.GetFocusedRow();
                    foreach (sp_CRCS050_ProductReceiveEntry_SearchAll_Result data in this.DataSource.Where(c => c.ReceivingNo == sel.ReceivingNo))
                    {
                        data.ReceivedDate = ((DateEdit)sender).DateTime;
                    }
                }
                gdvSearchResult.RefreshData();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void repReceiveDate_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (this.DataSource != null && this.DataSource.Count > 0)
                {
                    sp_CRCS050_ProductReceiveEntry_SearchAll_Result sel = (sp_CRCS050_ProductReceiveEntry_SearchAll_Result)gdvSearchResult.GetFocusedRow();
                    if (false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(DataUtil.Convert<DateTime>(e.NewValue)))
                    {
                        e.Cancel = true;
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0248", "Receiving Date"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void gdvSearchResult_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                sp_CRCS050_ProductReceiveEntry_SearchAll_Result sel = (sp_CRCS050_ProductReceiveEntry_SearchAll_Result)gdvSearchResult.GetFocusedRow();
                if (sel.StatusID == CSI.Business.Common.Status.CompleteReceiving && rdoReceivingIncomplete.Checked)
                {
                    e.Cancel = true;
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0247"));
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void gdvSearchResult_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                sp_CRCS050_ProductReceiveEntry_SearchAll_Result sel = (sp_CRCS050_ProductReceiveEntry_SearchAll_Result)gdvSearchResult.GetRow(e.RowHandle);
                if (sel != null && (sel.StatusID == CSI.Business.Common.Status.CompleteReceiving || sel.StatusID == CSI.Business.Common.Status.CompleteTransit))
                {
                    //if (e.Column != gdcReceivingNo && e.Column != gdcNumberOfPallet && e.Column != gdcInstallment)
                    //{
                        e.Appearance.BackColor = Common.CompleteColor();
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void repSelect_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gdvSearchResult.PostEditor();
                sp_CRCS050_ProductReceiveEntry_SearchAll_Result data = (sp_CRCS050_ProductReceiveEntry_SearchAll_Result)gdvSearchResult.GetFocusedRow();
                if (rdoReceivingCompleted.Checked)
                {
                    foreach (sp_CRCS050_ProductReceiveEntry_SearchAll_Result rec in this.DataSource.Where(c => c.ReceivingNo.Equals(data.ReceivingNo, StringComparison.InvariantCultureIgnoreCase)).ToList())
                    {
                        rec.SELECT = data.SELECT;
                    }
                }
                else
                {
                    foreach (sp_CRCS050_ProductReceiveEntry_SearchAll_Result rec in this.DataSource.Where(c => c.ReceivingNo.Equals(data.ReceivingNo, StringComparison.InvariantCultureIgnoreCase) && c.ReceiveQtyLv3 > 0 && c.StatusID < CSI.Business.Common.Status.CompleteReceiving).ToList())
                    {
                        rec.SELECT = data.SELECT;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnPrintPO_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                gdvSearchResult.PostEditor();
                if (this.DataSource == null || this.DataSource.Count <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                    return;
                }

                List<sp_CRCS050_ProductReceiveEntry_SearchAll_Result> selectList = this.DataSource.Where(c => c.SELECT.HasValue && c.SELECT.Value).ToList();

                if (selectList.Count <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return;
                }
                else
                {                    
                    DataSet ds = new DataSet("ReceivingDataSet");
                    DataTable dt = this.ConvertToDataTable(selectList);
                    
                    dt.TableName = "ReceivingDataTable";
                    ds.Tables.Add(dt);

                    List<sp_RPT034_PurchaseOrder_GetData_Result> lstReport = ReportBusiness.GetDataReport(ds.GetXml());

                    rptRPT034_PurchaseOrderReport rpt = new rptRPT034_PurchaseOrderReport(ReportBusiness.GetReportDefaultParams("RPT034"));
                    rpt.DataSource = lstReport;

                    ReportUtil.ShowPreview(rpt);
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        
        private void RadioCheckChange(object sender, EventArgs e)
        {
            try
            {
                if (rdoReceivingIncomplete.Checked)
                {
                    grdSearchResult.DataSource = null;
                    //ControlUtil.EnableControl(false, btnPrintPO);
                    ControlUtil.EnableControl(true, m_toolBarEdit, m_toolBarConfirm);
                }
                else
                {
                    grdSearchResult.DataSource = null;
                    //ControlUtil.EnableControl(true, btnPrintPO);
                    ControlUtil.EnableControl(false, m_toolBarEdit, m_toolBarConfirm);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
           
        }
        #endregion
        
        #region Generic Function
        private bool ValidateOnConfirm()
        {
            if (this.DataSource == null)
            {
                return false;
            }
            foreach (sp_CRCS050_ProductReceiveEntry_SearchAll_Result data in this.DataSource.Where(c => c.SELECT == true))
            {
                if (false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(data.ReceivedDate))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0248", "Receiving Date"));
                    return false;
                }
                string msgID;
                if (!BusinessClass.CheckWorkMethod(data.OwnerID, data.WarehouseID, out msgID))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage(msgID));
                    return false;
                }

                if (this.detail[string.Format("{0}|{1}", data.ReceivingNo, data.Installment)].Data.Count <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0243"));
                    return false;
                }
                if (data.StatusID == 6)
                {

                }

            }
            return true;
        }

        private void InitControl()
        {
            gdcReceivedDate.OptionsColumn.AllowEdit = false;
            gdcReceiveQtyLv2.OptionsColumn.AllowEdit = false;
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel);
            gdcReceiveQtyLv2.AppearanceCell.BackColor = Common.ReadOnlyCellColor();
            gdcReceivedDate.AppearanceCell.BackColor = Common.ReadOnlyCellColor();
            ControlUtil.EnableControl(true, grpSearchCriteria.Controls);
            gdvSearchResult.OptionsBehavior.Editable = false;
        }

        private void Confirm()
        {
            if (this.DataSource == null || this.DataSource.Count <= 0)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                return;
            }

            List<sp_CRCS050_ProductReceiveEntry_SearchAll_Result> selectList = this.DataSource.Where(c => c.SELECT.HasValue && c.SELECT.Value).ToList();


            if (selectList.Count > 0)
            {
                if (MessageDialog.ShowConfirmationMsg(this, Common.GetMessage("I0159")) == DialogButton.Yes)
                {
                    if (!iv.ValidateTicket(selectList[0].ReceivingNo, selectList[0].Installment.ToString()))
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                        return;
                    }
                    try
                    {
                        this.ShowWaitScreen();
                        BusinessClass.Confirm(selectList, detail);
                        this.CloseWaitScreen();
                        MessageDialog.ShowInformationMsg(Common.GetMessage("I0263"));
                        DataLoading();
                    }
                    catch(Exception ex)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                    }
                    finally
                    {
                        this.CloseWaitScreen();
                    }
                }
            }
            else
            {
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0128"));
            }
        }

        private void DataLoading()
        {
            try
            {
                Dialog = null;
                this.ShowWaitScreen();
                BindingSource bs = new BindingSource();
                this.DataSource = BusinessClass.DataLoading(ownerControl.OwnerID
                    , warehouseControl.WarehouseID
                    , supplierControl.SupplierID
                    , txtReceivingNo.Text.Trim()
                    , null
                    , (rdoReceivingIncomplete.Checked ? 0 : 1)
                    , dtArrivalDateFrom.DateTime
                    , dtArrivalDateTo.DateTime
                    , txtPDSNo.Text.Trim()
                    , txtPONo.Text.Trim()
                    , txtCustomerPONo.Text.Trim()
                    , DataUtil.Convert<DateTime>(dtCustomerPOIssueDateFrom.EditValue)
                    , DataUtil.Convert<DateTime>(dtCustomerPOIssueDateTo.EditValue)
                    , chkAfterMarket.Checked ? 1 : 0
                    , chkPackingMaterial.Checked ? 1 : 0
                    , chkPart.Checked ? 1 : 0);

                bs.DataSource = this.DataSource;
                grdSearchResult.DataSource = bs;
                for (int i = 0; i < gdvSearchResult.Columns.Count; i++)
                {
                    if (gdvSearchResult.Columns[i].ColumnType == typeof(DateTime) || gdvSearchResult.Columns[i].ColumnType == typeof(DateTime?))
                    {
                        gdvSearchResult.Columns[i].DisplayFormat.FormatString = Common.FullDateFormat;
                        gdvSearchResult.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    }
                }


                iv.ClearTicket();
                for(int i = 0; i < gdvSearchResult.RowCount; i++)
                {
                    iv.PushTicket(Convert.ToDateTime(gdvSearchResult.GetRowCellValue(i, "UpdateDate"))
                                  , gdvSearchResult.GetRowCellValue(i, "ReceivingNo").ToString()
                                  , gdvSearchResult.GetRowCellValue(i, "Installment").ToString());

                    sp_CRCS050_ProductReceiveEntry_SearchAll_Result rec = (sp_CRCS050_ProductReceiveEntry_SearchAll_Result)gdvSearchResult.GetRow(i);
                    if (detail.ContainsKey(string.Format("{0}|{1}", rec.ReceivingNo, rec.Installment)))
                    {
                        detail.Remove(string.Format("{0}|{1}", rec.ReceivingNo, rec.Installment));
                    }
                    ConfirmDetail cd = new ConfirmDetail();
                    detail.Add(string.Format("{0}|{1}", rec.ReceivingNo, rec.Installment), cd);
                }
                gdvSearchResult.OptionsBehavior.Editable = true;

                base.GridViewOnChangeLanguage(grdSearchResult);
                ControlUtil.SetBestWidth(gdvSearchResult);
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

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        private bool ValidateSearchCriteria()
        {
            errorProvider.ClearErrors();
            bool validate = true;

            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            //Cancel Date : 3/3/2015 
            //supplierControl.ErrorText = Common.GetMessage("I0300");
            //supplierControl.RequireField = true;

            if (!ownerControl.ValidateControl())
            {
                validate = false;
            }
            if (!warehouseControl.ValidateControl())
            {
                validate = false;
            }
            //if (!supplierControl.ValidateControl())
            //{
            //    validate = false;
            //}

            return validate;
        }
        #endregion      

    }
}
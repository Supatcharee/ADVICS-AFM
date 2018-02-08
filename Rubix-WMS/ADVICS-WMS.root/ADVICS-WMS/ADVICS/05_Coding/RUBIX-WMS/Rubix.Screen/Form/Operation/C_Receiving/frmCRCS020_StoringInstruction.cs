using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CSI.Business.Operation;
using DevExpress.XtraGrid;
using Rubix.Framework;
using DevExpress.XtraReports.UI;
using CSI.Business.DataObjects;
using CSI.Business.BusinessFactory.Report;
using System.Linq;
namespace Rubix.Screen.Form.Operation.C_Receiving
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Export)]
    public partial class frmCRCS020_StoringInstruction : FormBase
    {
        #region Member
        private StoringInstruction db;
        private decimal _weight;
        private decimal _vol;
        private decimal _qty;
        private decimal _cnt;
        #endregion

        #region Properties
        private StoringInstruction BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new StoringInstruction();
                }
                return db;
            }
        }

        private List<CSI.Business.DataObjects.sp_CRCS020_StoringInstruction_SearchAll_Result> DataSource { get; set; }
        #endregion

        #region Constructor
        public frmCRCS020_StoringInstruction()
        {
            InitializeComponent();            
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(grpCriteria);
            dtArrivalDateFrom.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtArrivalDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtArrivalDateFrom.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtArrivalDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtArrivalDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtArrivalDateFrom.Properties.Mask.EditMask = Common.FullDateFormat;
            dtArrivalDateTo.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtArrivalDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtArrivalDateTo.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtArrivalDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtArrivalDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtArrivalDateTo.Properties.Mask.EditMask = Common.FullDateFormat;
            ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarAdd, m_toolBarEdit, m_toolBarDelete, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
        }
        #endregion

        #region Override Method
        public override bool OnCommandAdd()
        {
            try
            {
                OpenDialog(Common.eScreenMode.Add);
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
        public override bool OnCommandEdit()
        {
            try
            {
                if (gdvSearchResult.RowCount > 0)
                {

                    OpenDialog(Common.eScreenMode.Edit);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }

        }
        #endregion

        #region Event Handler Function
        private void frmCRCS020_StoringInstruction_Load(object sender, EventArgs e)
        {
            try
            {
                chkUnarrival.Focus();
                CSI.Business.Common.Owner cust = new CSI.Business.Common.Owner();
                repCustomer.DataSource = cust.DataLoading(null);
                repCustomer.DisplayMember = "OwnerName";
                repCustomer.ValueMember = "OwnerID";
                repCustomerName.DataSource = cust.DataLoading(null);
                repCustomerName.DisplayMember = "OwnerName";
                repCustomerName.ValueMember = "OwnerID";
                CSI.Business.Common.Warehouse wh = new CSI.Business.Common.Warehouse();
                repDC.DataSource = wh.DataLoading(null);
                repDC.DisplayMember = "WarehouseCode";
                repDC.ValueMember = "WarehouseID";
                repDCName.DataSource = wh.DataLoading(null);
                repDCName.DisplayMember = "WarehouseName";
                repDCName.ValueMember = "WarehouseID";
                CSI.Business.Common.Supplier sup = new CSI.Business.Common.Supplier();
                repSupplier.DataSource = sup.DataLoading(null);
                repSupplier.DisplayMember = "SupplierCode";
                repSupplier.ValueMember = "SupplierID";
                repSupplierName.DataSource = sup.DataLoading(null);
                repSupplierName.DisplayMember = "SupplierLongName";
                repSupplierName.ValueMember = "SupplierID";

                this.DataSource = null;

                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                supplierControl.OwnerID = Common.GetDefaultOwnerID();
                supplierControl.DataLoading();
                itemControl.OwnerID = Common.GetDefaultOwnerID();
                itemControl.DataLoading();

                dtArrivalDateFrom.EditValue = ControlUtil.GetStartDate();
                dtArrivalDateTo.EditValue = ControlUtil.GetEndDate();
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
                chkUnarrival.Checked = true;
                dtArrivalDateFrom.EditValue = ControlUtil.GetStartDate();
                dtArrivalDateTo.EditValue = ControlUtil.GetEndDate();

                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                supplierControl.OwnerID = Common.GetDefaultOwnerID();
                supplierControl.DataLoading();
                itemControl.OwnerID = Common.GetDefaultOwnerID();
                itemControl.DataLoading();
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
                for (int i = 0; i < gdvSearchResult.RowCount; i++)
                {
                    gdvSearchResult.SetRowCellValue(i, gdcSelect, true);
                }
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            XtraReport rpt = null;
            try
            {
                this.ShowWaitScreen();
                gdvSearchResult.PostEditor();
                ReceivingInstruction dalReport = new ReceivingInstruction();
                if (this.DataSource == null)
                {
                    return;
                }

                foreach (sp_CRCS020_StoringInstruction_SearchAll_Result data in this.DataSource.Where(c => c.Select == true))
                {
                    Rubix.Screen.Report.rptRPT018_ReceivingInstruction rcvInstr = new Rubix.Screen.Report.rptRPT018_ReceivingInstruction(dalReport.GetReportDefaultParams("RPT018"));

                    //create transit data
                    BusinessClass.PrepareTransit(data.ReceivingNo, data.Installment.Value, data.OwnerID.Value, AppConfig.UserLogin);
                    List<sp_RPT018_ReceivingInstruction_GetData_Result> reportList = dalReport.GetReceivingInstruction(data.ReceivingNo, data.Installment.Value);
                    if (reportList.Count > 0)
                    {
                        rcvInstr.DataSource = reportList;
                        List<ReportDefaultParam> lstParam = BusinessClass.GetReportDefaultParams("RPT018");
                        rcvInstr.SetParameterReport("PrintBy", AppConfig.Name);
                        if (lstParam != null && lstParam.Count != 0)
                        {
                            rcvInstr.SetParameterReport("ISO", lstParam[9].Value);
                        }
                        if (rpt != null)
                        {
                            rpt = ReportUtil.CombineReport(rpt, rcvInstr);
                        }
                        else
                        {
                            rpt = rcvInstr;
                            rpt.CreateDocument();
                        }
                    }
                }

                if (rpt != null)
                {
                    ReportUtil.ShowPreview(rpt);
                }
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
                
        private void gdvSearchResult_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                ShowWaitScreen();
                ShowFocusRow();
                CloseWaitScreen();
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
                    itemControl.OwnerID = ownerControl.OwnerID;
                    itemControl.DataLoading();
                }
                else
                {
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    supplierControl.OwnerID = Common.GetDefaultOwnerID();
                    supplierControl.DataLoading();
                    itemControl.OwnerID = Common.GetDefaultOwnerID();
                    itemControl.DataLoading();
                }
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
        #endregion

        #region Generic Function
        private void OpenDialog(Common.eScreenMode ScreenMode)
        {
            //Cursor = Cursors.WaitCursor;
            //try
            //{
            //    if (ScreenMode == Common.eScreenMode.Add)
            //    {

            //    }
            //    else
            //    {
            //    }

            //    //Dialog.ScreenMode = ScreenMode;

            //    if (Dialog.ShowDialog(this) == DialogResult.OK)
            //    {

            //    }
            //    //return true;
            //}
            //catch (Exception ex)
            //{
            //    //MessageDialog.ShowSystemErrorMsg(this, ex);
            //    //return false;
            //}
            //finally
            //{
            //    Cursor = Cursors.Default;
            //}
        }

        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                BindingSource bs = new BindingSource();
                this.DataSource = BusinessClass.DataLoading((chkUnarrival.Checked ? 0 : 1), ownerControl.OwnerID, warehouseControl.WarehouseID, DataUtil.Convert<DateTime>(dtArrivalDateFrom.EditValue), DataUtil.Convert<DateTime>(dtArrivalDateTo.EditValue), txtSlipNo.Text.Trim(), truckCompanyControl.TruckCompanyID, supplierControl.SupplierID, itemControl.ProductID, null);
                bs.DataSource = this.DataSource;
                grdSearchResult.DataSource = bs;
                this.CloseWaitScreen();

                ShowFocusRow();
                gdvSearchResult.OptionsBehavior.Editable = true;
                _weight = 0;
                _vol = 0;
                _qty = 0;
                _cnt = 0;               

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

        private void ShowFocusRow()
        {
            if (gdvSearchResult.GetFocusedRow() != null)
            {
                sp_CRCS020_StoringInstruction_SearchAll_Result data = (sp_CRCS020_StoringInstruction_SearchAll_Result)gdvSearchResult.GetFocusedRow();
                txtQty.EditValue = data.Qty;
                txtWeight.EditValue = data.NetWeight;
                txtMeasurement.EditValue = data.UnitVolumn;
                txtNumberOfDetail.EditValue = data.NoOfDetail;
            }
            else
            {
                txtQty.EditValue = 0;
                txtWeight.EditValue = 0;
                txtMeasurement.EditValue = 0;
                txtNumberOfDetail.EditValue = 0;
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
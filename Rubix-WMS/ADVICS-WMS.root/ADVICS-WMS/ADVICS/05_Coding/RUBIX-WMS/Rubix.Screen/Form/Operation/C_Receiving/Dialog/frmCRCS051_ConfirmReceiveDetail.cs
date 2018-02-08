using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rubix.Framework;
using CSI.Business.Operation;
using CSI.Business.DataObjects;
using DevExpress.XtraGrid.Views.Grid;
using CSI.Business.Common;

namespace Rubix.Screen.Form.Operation.C_Receiving.Dialog
{
    public partial class frmCRCS051_ConfirmReceiveDetail : DialogBase
    {
        #region Member
        private ProductReceiveEntry db;
        private ProductCondition productCondition;
        int lastFocusRow = -1;
        #endregion

        #region Properties
        private ProductCondition ProductCondition
        {
            get
            {
                if (productCondition == null)
                {
                    productCondition = new ProductCondition();
                }
                return productCondition;
            }
        }

        public List<sp_CRCS051_ConfirmReceivingDetail_Get_Result> Data { get; set; }
        private List<sp_CRCS051_ConfirmReceivingDetail_Get_Result> Original { get; set; }
        private int? OriginalNoOfPallet { get; set; }
        private DateTime? OriginalReceivingDate { get; set; }
        private bool OriginalConfirmAll { get; set; }

        public string ReceivingNo { get; set; }
        public int Installment { get; set; }

        public DateTime? ReceivingDate
        {
            get
            {
                return Convert.ToDateTime(dtpReceivingDate.EditValue).Date.AddHours(Convert.ToDouble(txtRecevingTime.Text.Substring(0, 2))).AddMinutes(Convert.ToDouble(txtRecevingTime.Text.Substring(3, 2))); ;
            }
            set
            {
                dtpReceivingDate.EditValue = Convert.ToDateTime(value).Date;
                txtRecevingTime.Text = Convert.ToDateTime(value).ToString("HH:mm");
            }
        }
        public int Line { get; set; }
        public int? NoOfPallet
        {
            get
            {
                int pallet;
                if (Int32.TryParse(txtNoOfPallet.Text, out pallet))
                    return pallet;
                else
                    return null;
            }
            set
            {
                if (value.HasValue)
                    txtNoOfPallet.Text = value.Value.ToString();
                else
                    txtNoOfPallet.Text = string.Empty;
            }
        }
        public bool ConfirmAll 
        { 
            get
            {
                return chkConfirm.Checked;
            }
            set
            {
                chkConfirm.Checked = value;
            } 
        }

        public ProductReceiveEntry BusinessClass
        {
            get
            {
                if (db == null)
                    db = new ProductReceiveEntry();
                return db;
            }
            set
            {
                db = value;
            }
        }
        #endregion

        #region Contructure
        public frmCRCS051_ConfirmReceiveDetail()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarPrint, m_toolBarSaveACopy);
            ControlUtil.HiddenControl(false, m_toolBarSave, m_toolBarClear, m_toolBarClose);

            cboProductCondition.DisplayMember = "ProductConditionCode";
            cboProductCondition.ValueMember = "ProductConditionID";
            cboProductCondition.DataSource = this.ProductCondition.DataLoading().ToList<sp_common_LoadProductCondition_Result>();

        } 
        #endregion

        #region Overide Method
        public override bool OnCommandSave()
        {
            gdvRecDetail.PostEditor();
            if (ValidateData())
            {
                if (!iv.ValidateTicket(this.ReceivingNo, this.Installment.ToString()))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                    return false;
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            return base.OnCommandSave();
        }

        public override bool OnCommandClear()
        {
            try
            {
                this.Data = Original;
                this.NoOfPallet = this.OriginalNoOfPallet;
                this.ConfirmAll = this.OriginalConfirmAll;
                this.ReceivingDate = this.OriginalReceivingDate;
                frmCRCS051_ConfirmReceiveDetail_Load(this, new EventArgs());
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            return base.OnCommandClear();
        }
        #endregion

        #region Event Handle
        private void frmCRCS051_ConfirmReceiveDetail_Load(object sender, EventArgs e)
        {
            base.HideStatusBar();
            gdvRecDetail.ClearColumnErrors();
            txtReceivingNo.Text = this.ReceivingNo;
            DateTime rcvDate;
            int? noOfPallet;
            BindingSource bs = new BindingSource();
            if (this.Data == null)
            {
                this.Data = BusinessClass.GetDetail(this.ReceivingNo, out rcvDate, out noOfPallet, this.Installment);
                //this.NoOfPallet = noOfPallet;
                this.ReceivingDate = rcvDate;
                this.Original = null;
            }
            else
            {
                this.Original = DataUtil.CloneListOfComplexType<sp_CRCS051_ConfirmReceivingDetail_Get_Result>(this.Data);
            }
            bs.DataSource = this.Data;
            grdRecDetail.DataSource = bs;
            InitialControlFormat();
            this.OriginalNoOfPallet = this.NoOfPallet;
            this.OriginalConfirmAll = this.ConfirmAll;
            this.OriginalReceivingDate = this.ReceivingDate;
            ControlUtil.SetBestWidth(gdvRecDetail);
        }

        private void gdvRecDetail_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {

            e.Handled = true;
            if (e.Column == colLineNo || e.Column == colItemCode || e.Column == colItemName
                 || e.Column == colConditionOfItem || e.Column == colLotNo
                 || e.Column == colInstructionQty || e.Column == colRemainQty || e.Column == colUnitName)
            {
                sp_CRCS051_ConfirmReceivingDetail_Get_Result firstRow = (sp_CRCS051_ConfirmReceivingDetail_Get_Result)gdvRecDetail.GetRow(e.RowHandle1);
                sp_CRCS051_ConfirmReceivingDetail_Get_Result secondRow = (sp_CRCS051_ConfirmReceivingDetail_Get_Result)gdvRecDetail.GetRow(e.RowHandle2);
                if (firstRow.LineNo.Equals(secondRow.LineNo))
                {
                    e.Merge = true;
                }
                else
                    e.Merge = false;
            }
            else
                e.Merge = false;
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            sp_CRCS051_ConfirmReceivingDetail_Get_Result selectedRow = (sp_CRCS051_ConfirmReceivingDetail_Get_Result)gdvRecDetail.GetFocusedRow();
            if (selectedRow != null && selectedRow.IsDeletable == 0)
            {
                lastFocusRow = gdvRecDetail.GetFocusedDataSourceRowIndex();
                gdvRecDetail.AddNewRow();
                gdvRecDetail.UpdateCurrentRow(); 
                lastFocusRow = -1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sp_CRCS051_ConfirmReceivingDetail_Get_Result selectedRow = (sp_CRCS051_ConfirmReceivingDetail_Get_Result)gdvRecDetail.GetFocusedRow();
            if (selectedRow != null && selectedRow.IsDeletable == 1)
            {
                gdvRecDetail.DeleteRow(gdvRecDetail.GetFocusedDataSourceRowIndex());
            }
        }

        private void gdvRecDetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            int focusRow = lastFocusRow;
            view.SetRowCellValue(e.RowHandle, colLineNo, view.GetRowCellValue(focusRow, colLineNo));
            view.SetRowCellValue(e.RowHandle, colItemCode, view.GetRowCellValue(focusRow, colItemCode));
            view.SetRowCellValue(e.RowHandle, colItemName, view.GetRowCellValue(focusRow, colItemName));
            view.SetRowCellValue(e.RowHandle, colConditionOfItem, view.GetRowCellValue(focusRow, colConditionOfItem));
            view.SetRowCellValue(e.RowHandle, colLotNo, view.GetRowCellValue(focusRow, colLotNo));
            view.SetRowCellValue(e.RowHandle, colInstructionQty, view.GetRowCellValue(focusRow, colInstructionQty));
            view.SetRowCellValue(e.RowHandle, colRemainQty, view.GetRowCellValue(focusRow, colRemainQty));
            view.SetRowCellValue(e.RowHandle, colUnitName, view.GetRowCellValue(focusRow, colUnitName));
            view.SetRowCellValue(e.RowHandle, colExpiredDate, view.GetRowCellValue(focusRow, colExpiredDate));
            view.SetRowCellValue(e.RowHandle, colIsDeletable, 1);
            this.Data = this.Data.OrderBy(c => c.LineNo).ThenBy(c => c.IsDeletable).ToList();

            BindingSource bs = new BindingSource();
            bs.DataSource = this.Data;
            grdRecDetail.DataSource = bs;
        }

        private void gdvRecDetail_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            sp_CRCS051_ConfirmReceivingDetail_Get_Result selectedRow = (sp_CRCS051_ConfirmReceivingDetail_Get_Result)gdvRecDetail.GetFocusedRow();
            if (selectedRow != null)
            {
                if (selectedRow.IsDeletable == 1)
                {
                    btnDelete.Enabled = true;
                    btnSplit.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = false;
                    btnSplit.Enabled = true;
                }
            }
            else
            {
                btnDelete.Enabled = false;
                btnSplit.Enabled = false;
            }
        }

        private void dtpReceivingDate_DateTimeChanged(object sender, EventArgs e)
        {
            if (this.Data == null)
            {
                return;
            }

            foreach (sp_CRCS051_ConfirmReceivingDetail_Get_Result rec in this.Data)
            {
                if (rec.ItemExpiredTypeID == 2)
                {
                    try
                    {
                        rec.ExpiredDate = dtpReceivingDate.DateTime.AddMonths(rec.ShelfLife);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0119"));
                    }
                }
            }
        }

        private void gdvRecDetail_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column == colActualLotNo || e.Column == colActualProductConditionID || e.Column == colExpiredDate || e.Column == colReceiveQty)
            {
                e.Appearance.BackColor = Common.EditableCellColor();
            }
        }

        private void txtNoOfPallet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
                e.Handled = true;
        }

        private void txtReceiveQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
                e.Handled = true;
        }
        #endregion

        #region Generic Function
        private void InitialControlFormat()
        {
            dtpReceivingDate.Properties.NullText = Common.FullDateFormat;
            dtpReceivingDate.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtpReceivingDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtpReceivingDate.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtpReceivingDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtpReceivingDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtpReceivingDate.Properties.Mask.EditMask = Common.FullDateFormat;

            txtNoOfPallet.Properties.DisplayFormat.FormatString = Common.DecimalFormat;
            txtNoOfPallet.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtNoOfPallet.Properties.EditFormat.FormatString = Common.DecimalFormat;
            txtNoOfPallet.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            colExpiredDate.DisplayFormat.FormatString = Common.FullDateFormat;
            colExpiredDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            
            txtReceiveQty.DisplayFormat.FormatString = Common.QtyFormat;
            txtReceiveQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtReceiveQty.EditFormat.FormatString = Common.QtyFormat;
            txtReceiveQty.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            ControlUtil.SetGridColumnFormat(colInstructionQty, Common.QtyFormat);
            ControlUtil.SetGridColumnFormat(colRemainQty, Common.QtyFormat);
            ControlUtil.SetGridColumnFormat(colReceiveQty, Common.QtyFormat);

        }        

        private bool ValidateData()
        {
            bool validate = true;
            errorProvider.ClearErrors();
            if (string.IsNullOrWhiteSpace(dtpReceivingDate.Text.Replace("dd/MM/yyyy",string.Empty)))
            {
                errorProvider.SetError(dtpReceivingDate, Common.GetMessage("I0213"));
                validate = false;
            }
            bool isOK = false;
            for (int row = 0; row < gdvRecDetail.RowCount; row++)
            {
                sp_CRCS051_ConfirmReceivingDetail_Get_Result rec = (sp_CRCS051_ConfirmReceivingDetail_Get_Result)gdvRecDetail.GetRow(row);
                gdvRecDetail.FocusedRowHandle = row;
                gdvRecDetail.ClearColumnErrors();
                if (rec.ReceiveQty.HasValue || !string.IsNullOrWhiteSpace(rec.ActualLotNo))
                {
                    if (!rec.ReceiveQty.HasValue)
                    {
                        gdvRecDetail.SetColumnError(colReceiveQty, Common.GetMessage("I0206"), DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                        //MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0206"));
                        validate = false;
                    }
                    if (string.IsNullOrWhiteSpace(rec.ActualLotNo))
                    {
                        gdvRecDetail.SetColumnError(colActualLotNo, Common.GetMessage("I0206"), DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                        //MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0206"));
                        validate = false;
                    }
                    //if (!rec.ExpiredDate.HasValue)
                    //{
                    //    gdvRecDetail.SetColumnError(colExpiredDate, Common.GetMessage("I0206"), DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                    //    //MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0206"));
                    //    validate = false;
                    //}
                    //if (!rec.ActualProductConditionID.HasValue)
                    //{
                    //    gdvRecDetail.SetColumnError(colActualProductConditionID, Common.GetMessage("I0206"), DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
                    //    //MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0206"));
                    //    validate = false;
                    //}
                    if (gdvRecDetail.HasColumnErrors)
                        break;
                    isOK = true;
                }
                else
                {
                    isOK = true;
                }
            }
            if (!isOK) 
            {
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0206"));
                validate = false;
            }
            return validate;
        }
        #endregion
        
    }
}
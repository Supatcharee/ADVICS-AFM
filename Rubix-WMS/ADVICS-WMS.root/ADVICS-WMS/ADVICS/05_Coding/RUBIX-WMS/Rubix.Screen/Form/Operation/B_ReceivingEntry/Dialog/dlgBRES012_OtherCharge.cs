/*
 * 15 Jan 2013:
 * 1. correct ValidateData function on validate qty
 * 30 Jan 2013:
 * 1. add validate transaction date
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSI.Business.Operation;
using Rubix.Framework;
using CSI.Business.DataObjects;
using DevExpress.XtraGrid;

namespace Rubix.Screen.Form.Operation.B_ReceivingEntry.Dialog
{
    public partial class dlgBRES012_OtherCharge : DialogBase
    {
        #region Members
        private ReceivingEntry db;
        private DataTable _detail;
        #endregion

        #region enumeration
        enum eReceivingOtherCharge
        {
            OtherChargeID,
            ChargeDate,
            OtherCharge,
            Remark
        }
        #endregion

        #region Properties
        public ReceivingEntry BusinessClass
        {
            get
            {
                if (db == null)
                    db = new ReceivingEntry();
                return db;
            }
            set
            {
                db = value;
            }
        }
        public string ReceivingNo
        {
            get;
            set;
        }
        public int Installment
        {
            get;
            set;
        }
        public DataTable OtherDetail
        {
            get
            {
                if (_detail == null)
                {
                    _detail = BusinessClass.GetReceivingOtherDetail(this.ReceivingNo, this.Installment);
                }
                if (_detail.Rows.Count <= 0)
                {
                    _detail.Columns.Clear();
                    _detail.Columns.Add(eReceivingOtherCharge.OtherChargeID.ToString(), typeof(int));
                    _detail.Columns.Add(eReceivingOtherCharge.ChargeDate.ToString(), typeof(DateTime));
                    _detail.Columns.Add(eReceivingOtherCharge.OtherCharge.ToString(), typeof(decimal));
                    _detail.Columns.Add(eReceivingOtherCharge.Remark.ToString(), typeof(string));
                }
                return _detail;
            }
            set
            {
                _detail = value;
            }
        }
        public Common.eScreenMode ScreenMode
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        public dlgBRES012_OtherCharge()
        {
            InitializeComponent();
            base.GridViewControl = new GridControl[] { grdOtherCharge };
            ControlUtil.HiddenControl(true, m_statusBar);

            dtChargeDate.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtChargeDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtChargeDate.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtChargeDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtChargeDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtChargeDate.Properties.Mask.EditMask = Common.FullDateFormat;

            grcEffectiveDate.DisplayFormat.FormatString = Common.FullDateFormat;
            grcEffectiveDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            return base.OnCommandSave();
        }
        public override bool OnCommandClose()
        {
            bool result = base.OnCommandClose();
            if (result)
                this.DialogResult = System.Windows.Forms.DialogResult.No;
            return result;
        }
        public override bool OnCommandClear()
        {
            ControlUtil.ClearControlData(this.Controls);
            errorProvider.ClearErrors();
            DataLoading();
            return base.OnCommandClear();
        }
        #endregion
        
        #region Event Handler
        private void dlgBRES012_OtherCharge_Load(object sender, EventArgs e)
        {
            InitControl();
            DataLoading();
        }

        private void dlgBRES012_OtherCharge_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnOK.Visible)
            {
                e.Cancel = (MessageDialog.ShowConfirmationMsg(this, Common.GetMessage("I0004")) != DialogButton.Yes);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    DataRow dr = OtherDetail.NewRow();
                    OtherDetail.Rows.Add(dr);
                    Control2Grid(dr);                    
                    ControlUtil.ClearControlData(this.pnlEdit.Controls);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdvOtherCharge.GetFocusedRow() != null)
                {
                    Grid2Control(gdvOtherCharge.GetFocusedDataRow());
                    ControlUtil.EnableControl(false, grdOtherCharge);
                    ToggleMode();
                }
                else
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gdvOtherCharge.GetFocusedRow() != null)
            {
                gdvOtherCharge.DeleteSelectedRows();
            }
            else
            {
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    Control2Grid(gdvOtherCharge.GetFocusedDataRow());
                    ToggleMode();
                    ControlUtil.ClearControlData(this.pnlEdit.Controls);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleMode();
                ControlUtil.ClearControlData(this.pnlEdit.Controls);
                
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
        #endregion

        #region Generic Function
        private bool ValidateData()
        {
            bool validate = true;
            errorProvider.ClearErrors();
            if (string.IsNullOrWhiteSpace(dtChargeDate.Text))
            {
                errorProvider.SetError(dtChargeDate, Common.GetMessage("I0313"));
                validate = false;
            }
            // 30 Jan 2013: add validate transaction date
            else
            {
                if (false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(DataUtil.Convert<DateTime>(dtChargeDate.EditValue), true))
                {
                    errorProvider.SetError(dtChargeDate, Common.GetMessage("I0236"));
                    validate = false;
                }
            }
            // end 30 Jan 2013
            if (string.IsNullOrWhiteSpace(txtOtherCharge.Text))
            {
                errorProvider.SetError(txtOtherCharge, Common.GetMessage("I0311"));
                validate = false;
            }
            // Edit by chalermchai c. // 11/30/2012
            // Edit for othercharge is not negative

            // 15 Jan 2013: add "else" for validate negative when there is any text only
            else
            {
                if (Convert.ToDecimal(txtOtherCharge.EditValue) < 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0234"));
                    validate = false;
                }
            }
            // end 15 Jan 2013: add "else" for validate negative when there is any text only
            if (string.IsNullOrWhiteSpace(txtRemark.Text))
            {
                errorProvider.SetError(txtRemark, Common.GetMessage("I0312"));
                validate = false;
            }
            return validate;
        }

        private void Grid2Control(DataRow dr)
        {
            dtChargeDate.EditValue = dr["ChargeDate"];
            txtOtherCharge.EditValue = dr["OtherCharge"];
            txtRemark.Text = dr["Remark"].ToString();
        }

        private void Control2Grid(DataRow dr)
        {
            dr[eReceivingOtherCharge.ChargeDate.ToString()] = dtChargeDate.DateTime.Date;
            dr[eReceivingOtherCharge.OtherCharge.ToString()] = Convert.ToDecimal(txtOtherCharge.EditValue);
            dr[eReceivingOtherCharge.Remark.ToString()] = txtRemark.Text;
        }

        private void ToggleMode()
        {
            btnAdd.Visible = btnOK.Visible;
            btnDelete.Visible = btnOK.Visible;
            btnUpdate.Visible = btnOK.Visible;
            grdOtherCharge.Enabled = btnOK.Visible;
            m_toolBarSave.Enabled = btnOK.Visible;
            m_toolBarClose.Enabled = btnOK.Visible;
            m_toolBarClear.Enabled = btnOK.Visible;
            btnOK.Visible = !btnOK.Visible;
            btnCancel.Visible = btnOK.Visible;
        }

        private void InitControl()
        {
            ControlUtil.ClearControlData(this.Controls);
            errorProvider.ClearErrors();
            //_detail.Clear();
            btnOK.Visible = false;
            btnCancel.Visible = btnOK.Visible;
            btnAdd.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            
            if (this.ScreenMode == Common.eScreenMode.View)
            {
                ControlUtil.EnableControl(false, this.Controls);
                m_toolBarClear.Enabled = false;
                m_toolBarSave.Enabled = false;
            }
            else
            {
                ControlUtil.EnableControl(true, this.Controls);
                ControlUtil.ClearControlData(this.Controls);
                m_toolBarClear.Enabled = true;
                m_toolBarSave.Enabled = true;
            }
        }

        public void DataLoading()
        {
            grdOtherCharge.DataSource = this.OtherDetail; ;
            gdvOtherCharge.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            gdvOtherCharge.BestFitColumns();
        }
        #endregion


    }
}
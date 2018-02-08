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
namespace Rubix.Screen.Form.Operation.B_ReceivingEntry.Dialog
{
    public partial class dlgBRES011_TransportDetail : DialogBase
    {
        #region Members
        private ReceivingEntry db;
        private DataTable _detail = null;
        #endregion

        #region enumeration
        enum eReceivingTransportation
        {
            ReceivingTransportID,
            TruckCompanyID,
            TransportTypeID,
            TransportCharge,
            UnstaffingCharge,
            RegistrationNo,
            ContainerNo,
            DriverName,
            Remark,
            PlanIn,
            PlanOut,
            ActualIn,
            ActualOut,
            TotalReceiveWeight
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
        public int OwnerID
        {
            get;
            set;
        }
        public int WarehouseID
        {
            get;
            set;
        }
        public DataTable TransDetail
        {
            get
            {
                if (_detail == null)
                {
                    _detail = BusinessClass.GetReceivingTransDetail(ReceivingNo, Installment);                    
                }

                if (_detail.Rows.Count <= 0)
                {
                    _detail.Columns.Clear();
                    _detail.Columns.Add(eReceivingTransportation.ReceivingTransportID.ToString(), typeof(int));
                    _detail.Columns.Add(eReceivingTransportation.TruckCompanyID.ToString(), typeof(int));
                    _detail.Columns.Add(eReceivingTransportation.TransportTypeID.ToString(), typeof(int));
                    _detail.Columns.Add(eReceivingTransportation.TransportCharge.ToString(), typeof(decimal));
                    _detail.Columns.Add(eReceivingTransportation.UnstaffingCharge.ToString(), typeof(decimal));
                    _detail.Columns.Add(eReceivingTransportation.RegistrationNo.ToString(), typeof(string));
                    _detail.Columns.Add(eReceivingTransportation.ContainerNo.ToString(), typeof(string));
                    _detail.Columns.Add(eReceivingTransportation.DriverName.ToString(), typeof(string));
                    _detail.Columns.Add(eReceivingTransportation.Remark.ToString(), typeof(string));
                    _detail.Columns.Add(eReceivingTransportation.PlanIn.ToString(), typeof(DateTime));
                    _detail.Columns.Add(eReceivingTransportation.PlanOut.ToString(), typeof(DateTime));
                    _detail.Columns.Add(eReceivingTransportation.ActualIn.ToString(), typeof(DateTime));
                    _detail.Columns.Add(eReceivingTransportation.ActualOut.ToString(), typeof(DateTime));
                    _detail.Columns.Add(eReceivingTransportation.TotalReceiveWeight.ToString(), typeof(decimal));
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
        public dlgBRES011_TransportDetail()
        {
            InitializeComponent();
            base.GridViewControl = new GridControl[] { grdTransportDetail };
            ControlUtil.HiddenControl(true, m_statusBar);


            //deInActual.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            //deInActual.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //deInActual.Properties.EditFormat.FormatString = Common.FullDateFormat;
            //deInActual.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //deInActual.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            //deInActual.Properties.Mask.EditMask = Common.FullDateFormat;

            //deOutActual.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            //deOutActual.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //deOutActual.Properties.EditFormat.FormatString = Common.FullDateFormat;
            //deOutActual.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //deOutActual.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            //deOutActual.Properties.Mask.EditMask = Common.FullDateFormat;

            //deInPlan.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            //deInPlan.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //deInPlan.Properties.EditFormat.FormatString = Common.FullDateFormat;
            //deInPlan.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //deInPlan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            //deInPlan.Properties.Mask.EditMask = Common.FullDateFormat;

            //deOutPlan.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            //deOutPlan.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //deOutPlan.Properties.EditFormat.FormatString = Common.FullDateFormat;
            //deOutPlan.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            //deOutPlan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            //deOutPlan.Properties.Mask.EditMask = Common.FullDateFormat;


            txtTransportCharge.Properties.DisplayFormat.FormatString = Common.AmountFormat;
            txtTransportCharge.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtTransportCharge.Properties.EditFormat.FormatString = Common.AmountFormat;
            txtTransportCharge.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtTransportCharge.Properties.Mask.EditMask = Common.AmountFormat;
            txtTransportCharge.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

            txtUnstaffingCharge.Properties.DisplayFormat.FormatString = Common.AmountFormat;
            txtUnstaffingCharge.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtUnstaffingCharge.Properties.EditFormat.FormatString = Common.AmountFormat;
            txtUnstaffingCharge.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtUnstaffingCharge.Properties.Mask.EditMask = Common.AmountFormat;
            txtUnstaffingCharge.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

            txtTotalReceiveWeight.Properties.DisplayFormat.FormatString = Common.QtyFormat;
            txtTotalReceiveWeight.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtTotalReceiveWeight.Properties.EditFormat.FormatString = Common.QtyFormat;
            txtTotalReceiveWeight.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtTotalReceiveWeight.Properties.Mask.EditMask = Common.QtyFormat;
            txtTotalReceiveWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
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
        private void dlgBRES011_TransportDetail_Load(object sender, EventArgs e)
        {
            InitControl();
            DataLoading();
            errorProvider.ClearErrors();
            truckCompanyControl.RequireField = false;
            transportTypeControl.RequireField = false;
        }

        private void truckCompanyControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                transportTypeControl.TruckCompanyID = truckCompanyControl.TruckCompanyID;
                transportTypeControl.DataLoading();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void dlgBRES011_TransportDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnOK.Visible)
            {
                e.Cancel = (MessageDialog.ShowConfirmationMsg(this, Common.GetMessage("I0004")) != DialogButton.Yes);
                errorProvider.ClearErrors();

            }
            transportTypeControl.RequireField = false;
            InitControl();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    DataRow dr = TransDetail.NewRow();
                    TransDetail.Rows.Add(dr);
                    Control2Grid(dr);
                    ControlUtil.ClearControlData(this.pnlEdit.Controls);                    
                }
                ControlUtil.SetBestWidth(gdvTransportDetail);
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
                if (gdvTransportDetail.GetFocusedRow() != null && !gdvTransportDetail.IsEmpty)
                {
                    Grid2Control(gdvTransportDetail.GetFocusedDataRow());
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
            try
            {
                if (gdvTransportDetail.GetFocusedRow() != null)
                {
                    gdvTransportDetail.DeleteSelectedRows();
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    DataRow dr = gdvTransportDetail.GetFocusedDataRow();
                    Control2Grid(dr);
                    ToggleMode();
                    ControlUtil.ClearControlData(this.pnlEdit.Controls);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void transportTypeControl_EditValueChanged(object sender, EventArgs e)
        {
            //Load default unstaffing
            if (transportTypeControl.TransportTypeID.HasValue)
            {
                DataTable transCharge = BusinessClass.GetTransportCharge(this.OwnerID, this.WarehouseID, transportTypeControl.TransportTypeID.Value);
                if (transCharge.Rows.Count >= 1)
                {
                    txtUnstaffingCharge.EditValue = transCharge.Rows[0]["Charge"];
                }
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

        #region Generic function
        private bool ValidateData()
        {
            bool validate = true;
            errorProvider.ClearErrors();
            truckCompanyControl.RequireField = true;
            truckCompanyControl.ErrorText = Common.GetMessage("I0088");

            if (!truckCompanyControl.ValidateControl())
            {
                validate = false;
            }
            transportTypeControl.RequireField = true;
            transportTypeControl.ErrorText = Common.GetMessage("I0060");
            if (!transportTypeControl.ValidateControl())
            {
                validate = false;
            }
            if (string.IsNullOrWhiteSpace(txtTransportCharge.Text) || Convert.ToDecimal(txtTransportCharge.EditValue) < 0)
            {
                errorProvider.SetError(txtTransportCharge, Common.GetMessage("I0303"));
                validate = false;
            }
            if (string.IsNullOrWhiteSpace(txtUnstaffingCharge.Text) || Convert.ToDecimal(txtUnstaffingCharge.EditValue) < 0)
            {
                errorProvider.SetError(txtUnstaffingCharge, Common.GetMessage("I0304"));
                validate = false;
            }
            //if (string.IsNullOrWhiteSpace(txtRegistratorNo.Text))
            //{
            //    errorProvider.SetError(txtRegistratorNo, "Please input Registrator Number.");
            //    validate = false;
            //}
            if (string.IsNullOrWhiteSpace(deInPlan.Text))
            {
                errorProvider.SetError(deInPlan, Common.GetMessage("I0305"));
                validate = false;
            }
            else
            {
                if (!DataUtil.IsTime(txtTimeInPlan.Text))
                {
                    errorProvider.SetError(txtTimeInPlan, Common.GetMessage("I0306"));
                    validate = false;
                }
            }

            if (string.IsNullOrWhiteSpace(deOutPlan.Text))
            {
                errorProvider.SetError(deOutPlan, Common.GetMessage("I0307"));
                validate = false;
            }
            else
            {
                if (!DataUtil.IsTime(txtTimeOutPlan.Text))
                {
                    errorProvider.SetError(txtTimeOutPlan, Common.GetMessage("I0308"));
                    validate = false;
                }
            }



            if (!string.IsNullOrWhiteSpace(deInActual.Text))
            {
                if (!DataUtil.IsTime(txtTimeInAct.Text))
                {
                    errorProvider.SetError(txtTimeInAct, Common.GetMessage("I0309"));
                    validate = false;
                }
            }
            if (!string.IsNullOrWhiteSpace(deOutActual.Text))
            {
                if (!DataUtil.IsTime(txtTimeOutAct.Text))
                {
                    errorProvider.SetError(txtTimeOutAct, Common.GetMessage("I0310"));
                    validate = false;
                }
            }
            return validate;
        }
        
        private void Grid2Control(DataRow dr)
        {
            truckCompanyControl.TruckCompanyID = Convert.ToInt32(dr[eReceivingTransportation.TruckCompanyID.ToString()]);
            transportTypeControl.TransportTypeID = Convert.ToInt32(dr[eReceivingTransportation.TransportTypeID.ToString()]);
            txtDriverName.Text = dr[eReceivingTransportation.DriverName.ToString()].ToString();
            txtContainerNo.Text = dr[eReceivingTransportation.ContainerNo.ToString()].ToString();
            txtRegistratorNo.Text = dr[eReceivingTransportation.RegistrationNo.ToString()].ToString();
            txtUnstaffingCharge.EditValue = dr[eReceivingTransportation.UnstaffingCharge.ToString()];
            txtTransportCharge.EditValue = dr[eReceivingTransportation.TransportCharge.ToString()];
            txtRemark.Text = dr[eReceivingTransportation.Remark.ToString()].ToString();

            deInActual.EditValue = dr[eReceivingTransportation.ActualIn.ToString()];
            deOutActual.EditValue = dr[eReceivingTransportation.ActualOut.ToString()];
            deInPlan.EditValue = dr[eReceivingTransportation.PlanIn.ToString()];
            deOutPlan.EditValue = dr[eReceivingTransportation.PlanOut.ToString()];

            if (deInPlan.EditValue != null)
            {
                //deInPlan.DateTime = Convert.ToDateTime(data.PlanIn);
                txtTimeInPlan.Text = deInPlan.DateTime.ToString("HH:mm");
            }
            if (deOutPlan.EditValue != null)
            {
                //deOutPlan.DateTime = Convert.ToDateTime(data.PlanOut);
                txtTimeOutPlan.Text = deOutPlan.DateTime.ToString("HH:mm");
            }
            if (deInActual.EditValue != null)
            {
                //deInActual.DateTime = Convert.ToDateTime(data.ActualIn);
                txtTimeInAct.Text = deInActual.DateTime.ToString("HH:mm");
            }
            if (deOutActual.EditValue != null)
            {
                //deOutActual.DateTime = Convert.ToDateTime(data.ActualOut);
                txtTimeOutAct.Text = deOutActual.DateTime.ToString("HH:mm");
            }

            txtTotalReceiveWeight.EditValue = dr[eReceivingTransportation.TotalReceiveWeight.ToString()];
        }

        private void Control2Grid(DataRow dr)
        {
            dr[eReceivingTransportation.TruckCompanyID.ToString()] = truckCompanyControl.TruckCompanyID.Value;
            dr[eReceivingTransportation.TransportTypeID.ToString()] = transportTypeControl.TransportTypeID.Value;
            dr[eReceivingTransportation.DriverName.ToString()] = txtDriverName.Text;
            dr[eReceivingTransportation.ContainerNo.ToString()] = txtContainerNo.Text;
            dr[eReceivingTransportation.RegistrationNo.ToString()] = txtRegistratorNo.Text;
            dr[eReceivingTransportation.UnstaffingCharge.ToString()] = Convert.ToDecimal(txtUnstaffingCharge.EditValue);
            dr[eReceivingTransportation.TransportCharge.ToString()] = Convert.ToDecimal(txtTransportCharge.EditValue);
            dr[eReceivingTransportation.Remark.ToString()] = txtRemark.Text;

            if (!string.IsNullOrWhiteSpace(deInActual.Text))
            {
                dr[eReceivingTransportation.ActualIn.ToString()]= deInActual.DateTime.Date;
                if (txtTimeInAct.Text.Length > 0 && dr[eReceivingTransportation.ActualIn.ToString()] != DBNull.Value)
                {
                    dr[eReceivingTransportation.ActualIn.ToString()] = deInActual.DateTime.Date.AddHours(Convert.ToDouble(txtTimeInAct.Text.Substring(0, 2))).AddMinutes(Convert.ToDouble(txtTimeInAct.Text.Substring(3, 2)));
                }
            }

            if (!string.IsNullOrWhiteSpace(deOutActual.Text))
            {
                dr[eReceivingTransportation.ActualOut.ToString()] = deOutActual.DateTime.Date;
                if (txtTimeOutAct.Text.Length > 0 && dr[eReceivingTransportation.ActualOut.ToString()] != DBNull.Value)
                {
                    dr[eReceivingTransportation.ActualOut.ToString()] = deOutActual.DateTime.Date.AddHours(Convert.ToDouble(txtTimeOutAct.Text.Substring(0, 2))).AddMinutes(Convert.ToDouble(txtTimeOutAct.Text.Substring(3, 2)));
                }
            }

            if (!string.IsNullOrWhiteSpace(deInPlan.Text))
            {
                dr[eReceivingTransportation.PlanIn.ToString()] = deInPlan.DateTime.Date;
                if (txtTimeInPlan.Text.Length > 0 && dr[eReceivingTransportation.PlanIn.ToString()] != DBNull.Value)
                {
                    dr[eReceivingTransportation.PlanIn.ToString()] = deInPlan.DateTime.Date.AddHours(Convert.ToDouble(txtTimeInPlan.EditValue.ToString().Substring(0, 2))).AddMinutes(Convert.ToDouble(txtTimeInPlan.EditValue.ToString().Substring(3, 2)));
                }
            }

            if (!string.IsNullOrWhiteSpace(deOutPlan.Text))
            {
                dr[eReceivingTransportation.PlanOut.ToString()] = deOutPlan.DateTime.Date;
                if (txtTimeOutPlan.Text.Length > 0 && dr[eReceivingTransportation.PlanOut.ToString()] != DBNull.Value)
                {
                    dr[eReceivingTransportation.PlanOut.ToString()] = deOutPlan.DateTime.Date.AddHours(Convert.ToDouble(txtTimeOutPlan.Text.Substring(0, 2))).AddMinutes(Convert.ToDouble(txtTimeOutPlan.Text.Substring(3, 2)));
                }
            }
            if (txtTotalReceiveWeight.EditValue == null || string.IsNullOrEmpty(txtTotalReceiveWeight.Text))
            {
                dr[eReceivingTransportation.TotalReceiveWeight.ToString()] = DBNull.Value;
            }
            else
            {
                dr[eReceivingTransportation.TotalReceiveWeight.ToString()] = Convert.ToDecimal(txtTotalReceiveWeight.EditValue);
            }
        }

        private void ToggleMode()
        {
            btnAdd.Visible = btnOK.Visible;
            btnDelete.Visible = btnOK.Visible;
            btnUpdate.Visible = btnOK.Visible;
            grdTransportDetail.Enabled = btnOK.Visible;
            m_toolBarSave.Enabled = btnOK.Visible;
            m_toolBarClose.Enabled = btnOK.Visible;
            m_toolBarClear.Enabled = btnOK.Visible;
            btnOK.Visible = !btnOK.Visible;
            btnCancel.Visible = btnOK.Visible;
        }

        private void InitControl()
        {
            ControlUtil.ClearControlData(this.Controls);
            btnOK.Visible = false;
            btnAdd.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnCancel.Visible = btnOK.Visible;
            CSI.Business.Common.TruckCompany truck = new CSI.Business.Common.TruckCompany();
            repTruckCompany.DataSource = truck.DataLoading();
            repTruckCompany.ValueMember = "TruckCompanyID";
            repTruckCompany.DisplayMember = "TruckCompanyCode";
            CSI.Business.Common.TransportType trans = new CSI.Business.Common.TransportType();
            repTransType.DataSource = trans.DataLoading(null);
            repTransType.ValueMember = "TransportTypeID";
            repTransType.DisplayMember = "TransportTypeCode";
            ControlUtil.ClearControlData(pnlEdit);
            //_detail.Clear();
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
            gdvTransportDetail.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            grdTransportDetail.DataSource = this.TransDetail;            
            gdvTransportDetail.BestFitColumns();
        }
    #endregion        

    }
}
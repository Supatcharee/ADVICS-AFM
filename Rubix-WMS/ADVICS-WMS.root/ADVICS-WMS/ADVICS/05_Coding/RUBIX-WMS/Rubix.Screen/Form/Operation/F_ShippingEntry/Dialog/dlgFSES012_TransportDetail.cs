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
using DevExpress.Data;

namespace Rubix.Screen.Form.Operation.F_ShippingEntry.Dialog
{
    public partial class dlgFSES012_TransportDetail : DialogBase
    {
        #region Member

        private ShippingInstruction db;
        private List<sp_FSES012_TransportDetail_Search_Result> l_transport = null;
        private string m_shipmentNo;
        private int? m_installmentNo;
        #endregion

        #region Enumeration
        
        private enum eColTransport
        { 
             TruckCompanyID
            ,TransportTypeID
            ,RegistrationNo
            ,ContainerNo
            ,DriverName
            ,TransportCharge
            ,OutgoingCharge
            ,Remark
        }

        #endregion

        #region Propreties
        public ShippingInstruction BusinessClass
        {
            get
            {
                if (db == null)                    
                    db = new ShippingInstruction();
                return db;
            }
            set
            {
                db = value;
            }
        }  
        public tbt_ShippingInstruction ShipHeader
        {
            get;
            set;
        }
        public decimal sumTransportCharge
        {
            get;
            set;
        }
        public decimal sumOutgoingCharge
        {
            get;
            set;
        }
        public List<sp_FSES012_TransportDetail_Search_Result> TransportChargeList
        {
            get
            {
                if (l_transport == null)
                    l_transport = new List<sp_FSES012_TransportDetail_Search_Result>();
                return l_transport;
            }
            set
            {
                l_transport = value;
            }
        }
        public Common.eScreenMode ScreenMode
        {
            get;
            set;
        }
        public List<sp_FSES012_TransportDetail_Search_Result> DeleteList { get; set; }
        private List<sp_FSES012_TransportDetail_Search_Result> InternalDeleteList { get; set; }
        #endregion

        #region Constructor
        public dlgFSES012_TransportDetail()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_statusBar);
            ControlUtil.HiddenControl(true, m_toolBarClear);

            deInActual.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            deInActual.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            deInActual.Properties.EditFormat.FormatString = Common.FullDateFormat;
            deInActual.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            deInActual.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            deInActual.Properties.Mask.EditMask = Common.FullDateFormat;

            deOutActual.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            deOutActual.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            deOutActual.Properties.EditFormat.FormatString = Common.FullDateFormat;
            deOutActual.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            deOutActual.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            deOutActual.Properties.Mask.EditMask = Common.FullDateFormat;

            deInPlan.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            deInPlan.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            deInPlan.Properties.EditFormat.FormatString = Common.FullDateFormat;
            deInPlan.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            deInPlan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            deInPlan.Properties.Mask.EditMask = Common.FullDateFormat;

            deOutPlan.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            deOutPlan.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            deOutPlan.Properties.EditFormat.FormatString = Common.FullDateFormat;
            deOutPlan.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            deOutPlan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            deOutPlan.Properties.Mask.EditMask = Common.FullDateFormat;

            txtTransCharge.Properties.DisplayFormat.FormatString = Common.AmountFormat;
            txtTransCharge.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtTransCharge.Properties.EditFormat.FormatString = Common.AmountFormat;
            txtTransCharge.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtTransCharge.Properties.Mask.EditMask = Common.AmountFormat;
            txtTransCharge.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

            txtOutCharge.Properties.DisplayFormat.FormatString = Common.AmountFormat;
            txtOutCharge.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtOutCharge.Properties.EditFormat.FormatString = Common.AmountFormat;
            txtOutCharge.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtOutCharge.Properties.Mask.EditMask = Common.AmountFormat;
            txtOutCharge.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

            txtTotalReceiveWeight.Properties.DisplayFormat.FormatString = Common.QtyFormat;
            txtTotalReceiveWeight.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtTotalReceiveWeight.Properties.EditFormat.FormatString = Common.QtyFormat;
            txtTotalReceiveWeight.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtTotalReceiveWeight.Properties.Mask.EditMask = Common.QtyFormat;
            txtTotalReceiveWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

            DeleteList = new List<sp_FSES012_TransportDetail_Search_Result>();
        }
        #endregion               

        #region Event Handler Function
        private void dlgFSES012_TransportDetail_Load(object sender, EventArgs e)
        {
            InternalDeleteList = new List<sp_FSES012_TransportDetail_Search_Result>();
            InternalDeleteList.AddRange(DeleteList);
            foreach (sp_FSES012_TransportDetail_Search_Result rec in InternalDeleteList)
                TransportChargeList.Remove(rec);
            InitControl();
            BindingSource bs = new BindingSource();           
            bs.DataSource = TransportChargeList;
            grdTransportDetail.DataSource = bs;

            for (int i = 0; i < gdvTransportDetail.Columns.Count; i++)
            {
                if (gdvTransportDetail.Columns[i].ColumnType == typeof(DateTime) || gdvTransportDetail.Columns[i].ColumnType == typeof(DateTime?))
                {
                    gdvTransportDetail.Columns[i].DisplayFormat.FormatString = Common.FullDatetimeFormat;
                    gdvTransportDetail.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                }
            }
            base.GridViewOnChangeLanguage(grdTransportDetail);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                if (checkGrid())
                {
                    gdvTransportDetail.AddNewRow();
                    gdvTransportDetail.UpdateCurrentRow();

                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Grid2Control();
            grdTransportDetail.Enabled = false;
            ToggleMode();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                int iRow = gdvTransportDetail.FocusedRowHandle;
                sp_FSES012_TransportDetail_Search_Result data = (sp_FSES012_TransportDetail_Search_Result)gdvTransportDetail.GetFocusedRow();
                if (data.TransportTypeID == transportTypeControl.TransportTypeID 
                        && data.TruckCompanyID == truckCompanyControl.TruckCompanyID 
                            && data.RegistrationNo == txtRegistratorNo.Text.Trim())
                {
                    Control2Grid(data);
                    ToggleMode();
                    grdTransportDetail.Enabled = true;
                    ControlUtil.ClearControlData(grpEditDetail.Controls);                    
                }
                else 
                {
                    if (checkGrid())
                    {
                        Control2Grid(data);
                        ToggleMode();
                        grdTransportDetail.Enabled = true;
                        ControlUtil.ClearControlData(grpEditDetail.Controls);
                    } 
                }
                
                gdvTransportDetail.FocusedRowHandle = iRow;
            }
        }

        private void gdvTransportDetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            sp_FSES012_TransportDetail_Search_Result data = (sp_FSES012_TransportDetail_Search_Result)gdvTransportDetail.GetRow(e.RowHandle);
            data.TruckCompanyCode = "";
            Control2Grid(data);
            data.TransportSeq = 0;
            ControlUtil.SetBestWidth(gdvTransportDetail);
            ControlUtil.ClearControlData(grpEditDetail.Controls);
        }

        private void truckCompanyControl_EditValueChanged(object sender, EventArgs e)
        {
            transportTypeControl.TruckCompanyID = truckCompanyControl.TruckCompanyID;
            transportTypeControl.DataLoading();
            txtTransCharge.EditValue = 0;
        }

        private void transportTypeControl_EditValueChanged(object sender, EventArgs e)
        {
            if (transportTypeControl.TransportTypeID.HasValue)
            {
                sp_FSES012_TransportDetail_TransportCharge_Search_Result transCharge = BusinessClass.getTransportCharge(BusinessClass.OwnerID
                                                                                                                        , BusinessClass.CustomerID
                                                                                                                        , BusinessClass.WarehouseID
                                                                                                                        , transportTypeControl.TransportTypeID.Value
                                                                                                                        , BusinessClass.FinalDestinationID);
                if (transCharge != null && transCharge.Charge.HasValue)
                {
                    txtTransCharge.EditValue = transCharge.Charge.Value;
                }
           }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gdvTransportDetail.GetFocusedRow() != null)
            {
                InternalDeleteList.Add((sp_FSES012_TransportDetail_Search_Result)gdvTransportDetail.GetFocusedRow());
                gdvTransportDetail.DeleteRow(gdvTransportDetail.GetFocusedDataSourceRowIndex());
            }
            else
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                int iRow = gdvTransportDetail.FocusedRowHandle;
                ToggleMode();
                grdTransportDetail.Enabled = true;
                ControlUtil.ClearControlData(grpEditDetail.Controls);

                gdvTransportDetail.FocusedRowHandle = iRow;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
                
            }
        }

        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
               
                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), BusinessClass.ShipmentNo)) == DialogButton.Yes)
                {
                    //sumColumn
                    gdvTransportDetail.Columns[eColTransport.TransportCharge.ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, eColTransport.TransportCharge.ToString(), "{0}");
                    gdvTransportDetail.Columns[eColTransport.OutgoingCharge.ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, eColTransport.OutgoingCharge.ToString(), "{0}");
                    sumTransportCharge = Convert.ToDecimal((gdvTransportDetail.Columns[eColTransport.TransportCharge.ToString()].SummaryItem).SummaryValue);
                    sumOutgoingCharge = Convert.ToDecimal((gdvTransportDetail.Columns[eColTransport.OutgoingCharge.ToString()].SummaryItem).SummaryValue);
                    //SaveData();
                    DialogResult = DialogResult.OK;
                    DeleteList.Clear();
                    DeleteList.AddRange(InternalDeleteList);
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
            if (string.IsNullOrWhiteSpace(txtTransCharge.Text) || DataUtil.Convert<decimal>(txtTransCharge.EditValue) < 0)
            {
                errorProvider.SetError(txtTransCharge, Common.GetMessage("I0303"));
                validate = false;
            }
            if (string.IsNullOrWhiteSpace(txtOutCharge.Text) || DataUtil.Convert<decimal>(txtOutCharge.EditValue) < 0)
            {
                errorProvider.SetError(txtOutCharge, Common.GetMessage("I0316"));
                validate = false;
            }
            if (string.IsNullOrWhiteSpace(deInPlan.Text))
            {
                errorProvider.SetError(deInPlan, Common.GetMessage("I0305"));
                validate = false;
            }
            if (string.IsNullOrWhiteSpace(deOutPlan.Text))
            {
                errorProvider.SetError(deOutPlan, Common.GetMessage("I0307"));
                validate = false;
            }
            if (string.IsNullOrWhiteSpace(txtTimeInPlan.Text))
            {
                errorProvider.SetError(deInPlan, Common.GetMessage("I0317"));
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

            if (string.IsNullOrWhiteSpace(txtTimeOutPlan.Text))
            {
                errorProvider.SetError(deOutPlan, Common.GetMessage("I0318"));
                validate = false;
            }
            else
            {
                if (!DataUtil.IsTime(txtTimeOutPlan.Text))
                {
                    errorProvider.SetError(txtTimeOutPlan, Common.GetMessage("I0306"));
                    validate = false;
                }
            }


            if (!string.IsNullOrWhiteSpace(txtTimeInAct.Text))
            {
                if (!DataUtil.IsTime(txtTimeInAct.Text))
                {
                    errorProvider.SetError(txtTimeInAct, Common.GetMessage("I0309"));
                    validate = false;
                }
            }
            if (!string.IsNullOrWhiteSpace(txtTimeOutAct.Text))
            {
                if (!DataUtil.IsTime(txtTimeOutAct.Text))
                {
                    errorProvider.SetError(txtTimeOutAct, Common.GetMessage("I0310"));
                    validate = false;
                }
            }
            return validate;
        }

        private void Control2Grid(sp_FSES012_TransportDetail_Search_Result data)
        {
            if (!Util.IsNullOrEmpty(db.PickingNo))
            {
                data.PickingNo = db.PickingNo;
            }
            data.TruckCompanyID = truckCompanyControl.TruckCompanyID.Value;
            data.TransportTypeID = transportTypeControl.TransportTypeID.Value;
            data.TransportCharge = DataUtil.Convert<decimal>(txtTransCharge.EditValue).Value;
            data.OutgoingCharge = DataUtil.Convert<decimal>(txtOutCharge.EditValue).Value;
            data.RegistrationNo = txtRegistratorNo.Text;
            data.ContainerNo = txtContainerNo.Text;
            data.DriverName = txtDriverName.Text;           
            data.Remark = txtRemark.Text;

            if (!string.IsNullOrWhiteSpace(deInActual.Text))
            {
                data.ActualIn = deInActual.DateTime.Date;

                if (txtTimeInAct.Text.Length > 0 && data.ActualIn != null)
                {
                    //data.ActualIn = deInActual.DateTime.AddHours(-deInActual.DateTime.Hour).AddMinutes(-deInActual.DateTime.Minute);
                    data.ActualIn = deInActual.DateTime.Date.AddHours(Convert.ToDouble(txtTimeInAct.Text.Substring(0, 2))).AddMinutes(Convert.ToDouble(txtTimeInAct.Text.Substring(3, 2)));
                }
            }

            if (!string.IsNullOrWhiteSpace(deOutActual.Text))
            {
                data.ActualOut = deOutActual.DateTime.Date;
                if (txtTimeOutAct.Text.Length > 0 && data.ActualOut != null)
                {
                    //data.ActualOut = deOutActual.DateTime.AddHours(-deOutActual.DateTime.Hour).AddMinutes(-deOutActual.DateTime.Minute);
                    data.ActualOut = deOutActual.DateTime.Date.AddHours(Convert.ToDouble(txtTimeOutAct.Text.Substring(0, 2))).AddMinutes(Convert.ToDouble(txtTimeOutAct.Text.Substring(3, 2)));
                }
            }

            if (!string.IsNullOrWhiteSpace(deInPlan.Text))
            {
                data.PlanIn = deInPlan.DateTime.Date;
                if (txtTimeInPlan.Text.Length > 0 && data.PlanIn != null)
                {
                    //data.PlanIn = deInPlan.DateTime.AddHours(-deInPlan.DateTime.Hour).AddMinutes(-deInPlan.DateTime.Minute);
                    data.PlanIn = deInPlan.DateTime.Date.AddHours(Convert.ToDouble(txtTimeInPlan.Text.Substring(0, 2))).AddMinutes(Convert.ToDouble(txtTimeInPlan.Text.Substring(3, 2)));
                }
            }

            if (!string.IsNullOrWhiteSpace(deOutPlan.Text))
            {
                data.PlanOut = deOutPlan.DateTime.Date;
                if (txtTimeOutPlan.Text.Length > 0 && data.PlanOut != null)
                {
                    //data.PlanOut = deOutPlan.DateTime.AddHours(-deOutPlan.DateTime.Hour).AddMinutes(-deOutPlan.DateTime.Minute);
                    data.PlanOut = deOutPlan.DateTime.Date.AddHours(Convert.ToDouble(txtTimeOutPlan.Text.Substring(0, 2))).AddMinutes(Convert.ToDouble(txtTimeOutPlan.Text.Substring(3, 2)));
                }
            }
            data.TotalShipWeight = (decimal?)txtTotalReceiveWeight.EditValue;
            gdvTransportDetail.RefreshData();
            gdvTransportDetail.BestFitColumns();
        }

        private void ToggleMode()
        {
            ControlUtil.EnableControl(btnOK.Visible, grdTransportDetail);
            btnAdd.Visible = btnOK.Visible;
            btnUpdate.Visible = btnOK.Visible;
            btnDelete.Visible = btnOK.Visible;
            btnOK.Visible = !btnOK.Visible;
            btnCancel.Visible = btnOK.Visible;
        }

        private void Grid2Control()
        {
            if (!gdvTransportDetail.IsEmpty)
            {
                sp_FSES012_TransportDetail_Search_Result data = (sp_FSES012_TransportDetail_Search_Result)gdvTransportDetail.GetFocusedRow();
                truckCompanyControl.TruckCompanyID = data.TruckCompanyID;
                transportTypeControl.TransportTypeID = data.TransportTypeID;
                txtTransCharge.EditValue = data.TransportCharge;
                txtOutCharge.EditValue = data.OutgoingCharge;
                txtRegistratorNo.Text = data.RegistrationNo;
                txtContainerNo.Text = data.ContainerNo;
                txtDriverName.Text = data.DriverName;
                txtRemark.Text = data.Remark;

                if (data.PlanIn.HasValue)
                {
                    deInPlan.DateTime = Convert.ToDateTime(data.PlanIn);
                    txtTimeInPlan.Text = data.PlanIn.Value.ToString("HH:mm");
                }
                if (data.PlanOut.HasValue)
                {
                    deOutPlan.DateTime = Convert.ToDateTime(data.PlanOut);
                    txtTimeOutPlan.Text = data.PlanOut.Value.ToString("HH:mm");
                }
                if (data.ActualIn.HasValue)
                {
                    deInActual.DateTime = Convert.ToDateTime(data.ActualIn);
                    txtTimeInAct.Text = data.ActualIn.Value.ToString("HH:mm");
                }
                if (data.ActualOut.HasValue)
                {
                    deOutActual.DateTime = Convert.ToDateTime(data.ActualOut);
                    txtTimeOutAct.Text = data.ActualOut.Value.ToString("HH:mm");
                }
                txtTotalReceiveWeight.EditValue = data.TotalShipWeight;
            }
        }

        private bool checkGrid()
        {            
            if (gdvTransportDetail.RowCount > 0)
            {
                //filter TruckCompany and TransportType
                //gdvTransportDetail.ActiveFilterString = string.Format("TruckCompanyID = {0} AND TransportTypeID = {1}", truckCompanyControl.TruckCompanyID, transportTypeControl.TransportTypeID);
                
                //if (gdvTransportDetail.RowCount > 0)
                //{
                //    gdvTransportDetail.ActiveFilterEnabled = false;
                //    return false;
                //}
            }
            gdvTransportDetail.ActiveFilterEnabled = false;
            return true;
        }

        private void SaveData()
        {
            //for (int i = 0; i < gdvTransportDetail.RowCount; i++)
            //{
            //    sp_FSES012_TransportDetail_Search_Result data = (sp_FSES012_TransportDetail_Search_Result)gdvTransportDetail.GetRow(i);

            //    data.ShipmentNo = BusinessClass.ShipmentNo;
            //    data.Installment = 1;
            //    data.CreateUser = AppConfig.UserLogin;
            //    BusinessClass.SaveTransportDetail(data);
                
            //}
            
            
            //sp_FSES012_TransportDetail_Search_Result data = (sp_FSES012_TransportDetail_Search_Result)gdvTransportDetail.GetRow(e.RowHandle);
        }

        private void InitControl()
        {
            ControlUtil.ClearControlData(this.Controls);
            errorProvider.ClearErrors();
            btnOK.Visible = false;
            btnCancel.Visible = btnOK.Visible;
            btnAdd.Visible = true;
            btnUpdate.Visible = true;

            CSI.Business.Common.TruckCompany truck = new CSI.Business.Common.TruckCompany();
            repTruckCompany.DataSource = truck.DataLoading();
            repTruckCompany.ValueMember = "TruckCompanyID";
            repTruckCompany.DisplayMember = "TruckCompanyCode";
            CSI.Business.Common.TransportType trans = new CSI.Business.Common.TransportType();
            repTransportType.DataSource = trans.DataLoading(null);
            repTransportType.ValueMember = "TransportTypeID";
            repTransportType.DisplayMember = "TransportTypeCode";
            if (this.ScreenMode == Common.eScreenMode.View)
            {
                ControlUtil.EnableControl(false, this.Controls);
                truckCompanyControl.EnableControl = false;
                transportTypeControl.EnableControl = false;
                m_toolBarClear.Enabled = false;
                m_toolBarSave.Enabled = false;
            }
            else
            {
                ControlUtil.EnableControl(true, this.Controls);
                truckCompanyControl.EnableControl = true;
                transportTypeControl.EnableControl = true;
                ControlUtil.ClearControlData(this.Controls);
                m_toolBarClear.Enabled = true;
                m_toolBarSave.Enabled = true;
            }
        }
        #endregion

        
        
    }
}
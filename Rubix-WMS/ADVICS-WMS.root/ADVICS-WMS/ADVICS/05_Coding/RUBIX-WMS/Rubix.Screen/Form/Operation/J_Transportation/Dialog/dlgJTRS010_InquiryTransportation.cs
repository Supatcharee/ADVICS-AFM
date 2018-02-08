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
using System.Transactions;
using CSI.Business.BusinessFactory.Common;
using System.Xml;

namespace Rubix.Screen.Form.Operation.F_ShippingEntry.Dialog
{
    public partial class dlgJTRS010_InquiryTransportation : DialogBase
    {
        #region Member

        private InquiryTransportation db;
        private List<sp_FSES012_TransportDetail_Search_Result> l_transport = null;
        private string m_shipmentNo;
        private string m_pickingNo;
        private int m_installmentNo;
        private int[] transportSeq;
        private DataTable DetailTable;
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
        
        public int[] TransportSeq { get; set; }
        public InquiryTransportation BusinessClass
        {
            get
            {
                if (db == null)
                    db = new InquiryTransportation();
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
        public Common.eScreenMode ScreenMode
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        public dlgJTRS010_InquiryTransportation()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_statusBar);
            ControlUtil.HiddenControl(true, m_toolBarClear);
            InitControl();

            
        }
        #endregion               

        #region Event Handler Function
        private void dlgFSES010_TransportDetail_Load(object sender, EventArgs e)
        {
            try
            {
                DataLoading();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void truckCompanyControl_EditValueChanged(object sender, EventArgs e)
        {
            transportTypeControl.TruckCompanyID = truckCompanyControl.TruckCompanyID;
            transportTypeControl.DataLoading();
            txtTransCharge.EditValue = 0.00m;
        }

        private void transportTypeControl_EditValueChanged(object sender, EventArgs e)
        {
           // if (transportTypeControl.TransportTypeID.HasValue)
           // {
           //     sp_FSES012_TransportDetail_TransportCharge_Search_Result transCharge = BusinessClass.getTransportCharge(BusinessClass.OwnerID
           //                                                                                                            , BusinessClass.FinalDestinationID);
           //     if (transCharge != null && transCharge.Charge.HasValue)
           //     {
           //         txtTransCharge.EditValue = transCharge.Charge.Value;
           //     }
           //}
        }

        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
               
                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), "")) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        SaveData();
                        DialogResult = DialogResult.OK;
                        return true;
                    }
                    
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
            truckCompanyControl.ErrorText = Rubix.Screen.Common.GetMessage("I0088");
            if (!truckCompanyControl.ValidateControl())
            {
                
                errorProvider.SetError(truckCompanyControl, Rubix.Screen.Common.GetMessage("I0088"));
                validate = false;
            }
            transportTypeControl.RequireField = true;
            transportTypeControl.ErrorText = Rubix.Screen.Common.GetMessage("I0089");
            if (!transportTypeControl.ValidateControl())
            {
                errorProvider.SetError(transportTypeControl, Rubix.Screen.Common.GetMessage("I0089"));
                validate = false;
            }
            if (string.IsNullOrWhiteSpace(txtTransCharge.Text) || DataUtil.Convert<decimal>(txtTransCharge.EditValue) < 0)
            {
                errorProvider.SetError(txtTransCharge, Common.GetMessage("I0303"));
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
            if (string.IsNullOrWhiteSpace(txtTimeOutPlan.Text))
            {
                errorProvider.SetError(deOutPlan, Common.GetMessage("I0318"));
                validate = false;
            }

            if (!string.IsNullOrEmpty(deVanningDate.Text) && string.IsNullOrEmpty(txtTimeVanningDate.Text))
            {
                errorProvider.SetError(txtTimeVanningDate, Common.GetMessage("I0134"));
                validate = false;
            }

            if (!finalDestinationControl.ValidateControl())
            {
                validate = false;
            }


            if (!chkRemoveInv.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtContainerNo.Text))
                {
                    errorProvider.SetError(txtContainerNo, Common.GetMessage("I0426"));
                    validate = false;
                }

                if (string.IsNullOrWhiteSpace(txtOutCharge.Text) || DataUtil.Convert<decimal>(txtOutCharge.EditValue) < 0)
                {
                    errorProvider.SetError(txtOutCharge, Common.GetMessage("I0185"));
                    validate = false;
                }

                if (string.IsNullOrEmpty(deVanningDate.Text) || string.IsNullOrEmpty(txtTimeVanningDate.Text))
                {
                    errorProvider.SetError(deVanningDate, "Please Input Vanning Date.");
                    validate = false;
                }

                if (!string.IsNullOrEmpty(deInActual.Text) && string.IsNullOrEmpty(txtTimeInAct.Text))
                {
                    errorProvider.SetError(txtTimeInAct, Common.GetMessage("I0134"));
                    validate = false;
                }

                if (!string.IsNullOrEmpty(deOutActual.Text) && string.IsNullOrEmpty(txtTimeOutAct.Text))
                {
                    errorProvider.SetError(txtTimeOutAct, Common.GetMessage("I0134"));
                    validate = false;
                }
            }

            return validate;
        }

        private void SaveData()
        {

            foreach (var validate in this.TransportSeq)
            {
                if (!iv.ValidateTicket(validate.ToString()))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                    return;
                }
            }

            string ShipmentNo = shipmentControl.ShipmentNo;
            int? TruckCompanyID = truckCompanyControl.TruckCompanyID;
            int? TransportTypeID = transportTypeControl.TransportTypeID;
            decimal? TransportCharge = DataUtil.Convert<decimal>(txtTransCharge.EditValue);
            decimal? OutgoingCharge = DataUtil.Convert<decimal>(txtOutCharge.EditValue);
            string RegistrationNo = txtRegistratorNo.Text;
            string ContainerNo = txtContainerNo.Text;
            string DriverName = txtDriverName.Text;
            decimal? TotalShipWeight = DataUtil.Convert<decimal>(txtTotalShipWeight.Text);
            string Remark = txtRemark.Text;
            string BookingNo = txtBookingNo.Text;
            string SealNo = txtSealNo.Text;
            int? FinaldestinationID = finalDestinationControl.GetFinalDestinationID;
            int ISRemoveInvoiceNo = chkRemoveInv.Checked ? 1 : 0;

            DateTime? PlanIn = DataUtil.CombineDateAndTime(Convert.ToDateTime(deInPlan.EditValue), Convert.ToDateTime(txtTimeInPlan.EditValue));
            DateTime? PlanOut = DataUtil.CombineDateAndTime(Convert.ToDateTime(deOutPlan.EditValue), Convert.ToDateTime(txtTimeOutPlan.EditValue));
            
            DateTime? ActualIn = null, ActualOut = null, Vanning = null;
                            
            if (!string.IsNullOrEmpty(deInActual.Text))
            {
                ActualIn = DataUtil.CombineDateAndTime(Convert.ToDateTime(deInActual.EditValue), Convert.ToDateTime(txtTimeInAct.EditValue));

            }
            if (!string.IsNullOrEmpty(deOutActual.Text))
            {
                ActualOut = DataUtil.CombineDateAndTime(Convert.ToDateTime(deOutActual.EditValue), Convert.ToDateTime(txtTimeOutAct.EditValue));

            }
            if (!string.IsNullOrEmpty(deVanningDate.Text))
            {
                Vanning = DataUtil.CombineDateAndTime(Convert.ToDateTime(deVanningDate.EditValue), Convert.ToDateTime(txtTimeVanningDate.EditValue));
            }

            
            DataTable dtTransportSeq = new DataTable("TransportSeqDataTable");
            dtTransportSeq.Columns.Add("TransportSeq", typeof(int));
            DataRow dr;
            foreach (int ts in this.TransportSeq)
            {
                dr = dtTransportSeq.NewRow();
                dr["TransportSeq"] = ts;
                dtTransportSeq.Rows.Add(dr);

            }

            DataSet dsTransportSeq = new DataSet("TransportSeqDataSet");
            dsTransportSeq.Tables.Add(dtTransportSeq);

            string TransportSeqXML = dsTransportSeq.GetXml();

            BusinessClass.SaveData(ShipmentNo
                                , TruckCompanyID
                                , TransportTypeID
                                , TransportCharge
                                , OutgoingCharge
                                , RegistrationNo
                                , ContainerNo
                                , DriverName
                                , TotalShipWeight
                                , Remark
                                , PlanIn
                                , PlanOut
                                , ActualIn
                                , ActualOut
                                , TransportSeqXML
                                , BookingNo
                                , SealNo
                                , Vanning
                                , FinaldestinationID
                                , ISRemoveInvoiceNo);
            
        }

        private void DataLoading()
        {
            DataTable dt = new DataTable("TransportSeqDataTable");
            DataSet ds = new DataSet("TransportSeqDataSet");

            dt.Columns.Add("TransportSeq", typeof(int));

            DataRow dr;

            foreach (var item in this.TransportSeq)
            {
                dr = dt.NewRow();
                dr["TransportSeq"] = Convert.ToInt32(item);
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);
            
            DataTable detailData = BusinessClass.DataLoadingDetail(ds.GetXml());
            DetailTable = detailData;
            shipmentControl.ShipmentNo = detailData.Rows[0]["ShipmentNo"].ToString();
            truckCompanyControl.TruckCompanyID = DataUtil.Convert<int>(detailData.Rows[0]["TruckCompanyID"]);
            transportTypeControl.TransportTypeID = DataUtil.Convert<int>(detailData.Rows[0]["TransportTypeID"]);
            txtTransCharge.Text = detailData.Rows[0]["TransportCharge"].ToString();
            txtRegistratorNo.Text = detailData.Rows[0]["RegistrationNo"].ToString();
            txtDriverName.Text = detailData.Rows[0]["DriverName"].ToString();
            txtOutCharge.EditValue = detailData.Rows[0]["OutgoingCharge"];
            txtContainerNo.Text = detailData.Rows[0]["ContainerNo"].ToString();
            txtTotalShipWeight.EditValue = detailData.Rows[0]["TotalShipWeight"];
            txtRemark.Text = detailData.Rows[0]["Remark"].ToString();
            txtBookingNo.Text = detailData.Rows[0]["BookingNo"].ToString();
            txtSealNo.Text = detailData.Rows[0]["SealNo"].ToString();
            finalDestinationControl.FinalDestinationID = DataUtil.Convert<int>(detailData.Rows[0]["FinalDestinationID"]);

            DateTime? PlanIn = DataUtil.Convert<DateTime>(detailData.Rows[0]["PlanIn"]);
            if (PlanIn != null)
            {
                deInPlan.EditValue = PlanIn;
                txtTimeInPlan.Text = Convert.ToDateTime(PlanIn).ToString("HH:mm");
            }

            DateTime? ActualIn = DataUtil.Convert<DateTime>(detailData.Rows[0]["ActualIn"]);
            if (ActualIn != null)
            {
                deInActual.EditValue = ActualIn;
                txtTimeInAct.Text = Convert.ToDateTime(ActualIn).ToString("HH:mm");
            }
            

            DateTime? PlanOut = DataUtil.Convert<DateTime>(detailData.Rows[0]["PlanOut"]);
            if (PlanOut != null)
            {
                deOutPlan.EditValue = PlanOut;
                txtTimeOutPlan.Text = Convert.ToDateTime(PlanOut).ToString("HH:mm");
            }
            DateTime? ActualOut = DataUtil.Convert<DateTime>(detailData.Rows[0]["ActualOut"]);
            if (ActualOut != null)
            {
                deOutActual.EditValue = ActualOut;
                txtTimeOutAct.Text = Convert.ToDateTime(ActualOut).ToString("HH:mm");
            }

            DateTime? Vanning = DataUtil.Convert<DateTime>(detailData.Rows[0]["VanningDate"]);
            if (Vanning != null)
            {
                deVanningDate.EditValue = Vanning;
                txtTimeVanningDate.Text = Convert.ToDateTime(Vanning).ToString("HH:mm");
            }
        }

        private void InitControl()
        {

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

            deVanningDate.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            deVanningDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            deVanningDate.Properties.EditFormat.FormatString = Common.FullDateFormat;
            deVanningDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            deVanningDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            deVanningDate.Properties.Mask.EditMask = Common.FullDateFormat;

            txtTransCharge.Properties.DisplayFormat.FormatString = Common.AmountFormat;
            txtTransCharge.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtTransCharge.Properties.EditFormat.FormatString = Common.AmountFormat;
            txtTransCharge.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtTransCharge.Properties.Mask.EditMask = Common.AmountFormat;
            txtTransCharge.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtTransCharge.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;

            txtOutCharge.Properties.DisplayFormat.FormatString = Common.AmountFormat;
            txtOutCharge.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtOutCharge.Properties.EditFormat.FormatString = Common.AmountFormat;
            txtOutCharge.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtOutCharge.Properties.Mask.EditMask = Common.AmountFormat;
            txtOutCharge.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtOutCharge.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;

            txtTotalShipWeight.Properties.DisplayFormat.FormatString = Common.QtyFormat;
            txtTotalShipWeight.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtTotalShipWeight.Properties.EditFormat.FormatString = Common.QtyFormat;
            txtTotalShipWeight.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtTotalShipWeight.Properties.Mask.EditMask = Common.QtyFormat;
            txtTotalShipWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtTotalShipWeight.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
        }
        #endregion

        private void chkRemoveInv_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRemoveInv.Checked)
            {
                txtContainerNo.Text = string.Empty;
                txtOutCharge.EditValue = 0;
                deVanningDate.EditValue = string.Empty;
                txtTimeVanningDate.Text = string.Empty;
                deInActual.EditValue = string.Empty;
                txtTimeInAct.Text = string.Empty;
                deOutActual.EditValue = string.Empty;
                txtTimeOutAct.Text = string.Empty;
                txtRemark.Text = string.Empty;
                txtSealNo.Text = string.Empty;
                txtBookingNo.Text = string.Empty;
                txtDriverName.Text = string.Empty;
                txtRegistratorNo.Text = string.Empty;

                txtContainerNo.Enabled = false;
                txtOutCharge.Enabled = false;
                deVanningDate.Enabled = false;
                txtTimeVanningDate.Enabled = false;
                deInActual.Enabled = false;
                txtTimeInAct.Enabled = false;
                deOutActual.Enabled = false;
                txtTimeOutAct.Enabled = false;
                txtRemark.Enabled = false;
                txtSealNo.Enabled = false;
                txtBookingNo.Enabled = false;
                txtDriverName.Enabled = false;
                txtRegistratorNo.Enabled = false;
                requireField4.Visible = false;
                requireField7.Visible = false;
                requireField9.Visible = false;
            }
            else
            {
                txtContainerNo.Enabled = true;
                txtOutCharge.Enabled = true;
                deVanningDate.Enabled = true;
                txtTimeVanningDate.Enabled = true;
                deInActual.Enabled = true;
                txtTimeInAct.Enabled = true;
                deOutActual.Enabled = true;
                txtTimeOutAct.Enabled = true;
                txtRemark.Enabled = true;
                txtSealNo.Enabled = true;
                txtBookingNo.Enabled = true;
                txtDriverName.Enabled = true;
                txtRegistratorNo.Enabled = true;
                requireField4.Visible = true;
                requireField7.Visible = true;
                requireField9.Visible = true;
            }
        }


    }
}
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


namespace Rubix.Screen.Form.Operation.F_ShippingEntry.Dialog
{
    public partial class dlgFSES013_OtherCharge : DialogBase
    {
        #region Member
        private ShippingInstruction db;
        private List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result> l_otherCharge = null;

        public List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result> DeleteList { get; set; }
        private List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result> InternalDeleteList { get; set; }
        #endregion

        #region Enumeration
        
        private enum eColOtherCharge
        {
            OtherChargeID
            ,ShipmentNo
			,ChargeDate
			,OtherCharge
			,Remark
			,CreateDate
			,CreateUser
        }

        #endregion
        
        #region Constructor
        public dlgFSES013_OtherCharge()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_statusBar);
            ControlUtil.HiddenControl(true, m_toolBarClear);

            dtEffective.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtEffective.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtEffective.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtEffective.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtEffective.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtEffective.Properties.Mask.EditMask = Common.FullDateFormat;

            grcChargeDate.DisplayFormat.FormatString = Common.FullDateFormat;
            grcChargeDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            txtOtherCharge.Properties.DisplayFormat.FormatString = Common.AmountFormat;
            txtOtherCharge.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtOtherCharge.Properties.EditFormat.FormatString = Common.AmountFormat;
            txtOtherCharge.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtOtherCharge.Properties.Mask.EditMask = Common.AmountFormat;
            txtOtherCharge.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            DeleteList = new List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result>();
        }
        #endregion

        #region Prepreties
        public Common.eScreenMode ScreenMode
        {
            get;
            set;
        }
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
        public decimal sumOtherCharge
        {
            get;
            set;
        }
        public List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result> OtherChargeList
        {
            get
            {
                if (l_otherCharge == null)
                    l_otherCharge = new List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result>();
                return l_otherCharge;
            }
            set
            {
                l_otherCharge = value;
            }
        }
       
        #endregion

        #region Event Handler
        private void dlgBRES013_OtherCharge_Load(object sender, EventArgs e)
        {
            InternalDeleteList = new List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result>();
            InternalDeleteList.AddRange(DeleteList);
            foreach (sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result rec in InternalDeleteList)
                OtherChargeList.Remove(rec);
            InitControl();
            List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result> list_charge = OtherChargeList;
            BindingSource bs = new BindingSource();
            bs.DataSource = list_charge;
            //bs.DataSource = BusinessClass.LoadShippingOtherCharge(BusinessClass.ShipmentNo);
            grdOtherCharge.DataSource = bs;
            ControlUtil.SetBestWidth(gdvOtherCharge);
        }

        private void dlgBRES013_OtherCharge_FormClosing(object sender, FormClosingEventArgs e)
        {
            ControlUtil.ClearControlData(grdOtherCharge);
            if (btnOK.Visible)
            {
                e.Cancel = true;
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0285"));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                if (checkGrid())
                {
                    gdvOtherCharge.AddNewRow();
                    gdvOtherCharge.UpdateCurrentRow();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (gdvOtherCharge.GetFocusedRow() != null)
            {
                Grid2Control();
                ControlUtil.EnableControl(false, grdOtherCharge);
                ToggleMode();
            }
            else
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
        }
       
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                int iRow = gdvOtherCharge.FocusedRowHandle;
                sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result data = (sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result)gdvOtherCharge.GetFocusedRow();
                if (data.ChargeDate == Convert.ToDateTime(dtEffective.EditValue))
                {
                    Control2Grid(data);
                    ToggleMode();
                    grdOtherCharge.Enabled = true;
                    ControlUtil.ClearControlData(pnlEdit.Controls);
                }
                else
                {
                    if (checkGrid())
                    {
                        Control2Grid(data);
                        ToggleMode();
                        grdOtherCharge.Enabled = true;
                        ControlUtil.ClearControlData(pnlEdit.Controls);
                    }
                }
                gdvOtherCharge.FocusedRowHandle = iRow;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {

                int iRow = gdvOtherCharge.FocusedRowHandle;

                ToggleMode();
                grdOtherCharge.Enabled = true;
                ControlUtil.ClearControlData(pnlEdit.Controls);

                gdvOtherCharge.FocusedRowHandle = iRow;

            }
            catch (Exception ex)
            {

                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gdvOtherCharge.GetFocusedRow() != null)
            {
                InternalDeleteList.Add((sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result)gdvOtherCharge.GetFocusedRow());
                gdvOtherCharge.DeleteRow(gdvOtherCharge.GetFocusedDataSourceRowIndex());
            }
            else
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
        }


        private void gdvOtherCharge_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result data = (sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result)gdvOtherCharge.GetRow(e.RowHandle);
            Control2Grid(data);
            ControlUtil.SetBestWidth(gdvOtherCharge);
            ControlUtil.ClearControlData(this.pnlEdit.Controls);
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

                    gdvOtherCharge.Columns[eColOtherCharge.OtherCharge.ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, eColOtherCharge.OtherCharge.ToString(), "{0}");
                    sumOtherCharge = Convert.ToDecimal((gdvOtherCharge.Columns[eColOtherCharge.OtherCharge.ToString()].SummaryItem).SummaryValue);
                    
                    SaveData();
                    DialogResult = DialogResult.OK;
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

        #region Generic Function

        private bool ValidateData()
        {
            bool validate = true;
            errorProvider.ClearErrors();
            if (dtEffective.EditValue == null)
            {
                errorProvider.SetError(dtEffective, Common.GetMessage("I0319"));
                validate = false;
            }
            // 30 Jan 2013: add validate transaction date
            else if(false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(DataUtil.Convert<DateTime>(dtEffective.EditValue), true))
            {
                errorProvider.SetError(dtEffective, "I0236");
                validate = false;
            }
            // end 30 Jan 2013
            if (string.IsNullOrWhiteSpace(txtOtherCharge.Text))
            {
                errorProvider.SetError(txtOtherCharge, Common.GetMessage("I0311"));
                validate = false;
            }
            if (string.IsNullOrWhiteSpace(memoRemark.Text))
            {
                errorProvider.SetError(memoRemark, Common.GetMessage("I0312"));
                validate = false;
            }
            return validate ;
        }
               
        private void Grid2Control()
        {
            if (!gdvOtherCharge.IsEmpty)
            {
                sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result data = (sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result)gdvOtherCharge.GetFocusedRow();
                dtEffective.EditValue = data.ChargeDate;
                txtOtherCharge.EditValue = data.OtherCharge;
                memoRemark.EditValue = data.Remark;                
            }
        }

        private void Control2Grid(sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result data)
        {
            data.ChargeDate = (DateTime)dtEffective.EditValue;
            data.OtherCharge = (decimal)txtOtherCharge.EditValue;
            data.Remark = memoRemark.Text;
            gdvOtherCharge.RefreshData();
            gdvOtherCharge.BestFitColumns();
        }

        private void ToggleMode()
        {
            btnAdd.Visible = btnOK.Visible;
            btnUpdate.Visible = btnOK.Visible;
            btnDelete.Visible = btnOK.Visible;
            grdOtherCharge.Enabled = btnOK.Visible;
            m_toolBarSave.Enabled = btnOK.Visible;
            m_toolBarClose.Enabled = btnOK.Visible;
            m_toolBarClear.Enabled = btnOK.Visible;
            btnOK.Visible = !btnOK.Visible;
            btnCancel.Visible = btnOK.Visible;
        }

        private void InitControl()
        {
            btnOK.Visible = false;
            btnCancel.Visible = btnOK.Visible;
            btnAdd.Visible = true;            
            btnUpdate.Visible = true;
            errorProvider.ClearErrors();
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

        private void SaveData()
        {
            //for (int i = 0; i < gdvOtherCharge.RowCount; i++)
            //{

            //    sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result data = (sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result)gdvOtherCharge.GetRow(i);

            //    data.ShipmentNo = BusinessClass.ShipmentNo;
            //    data.CreateUser = AppConfig.UserLogin;
            //    BusinessClass.SaveShippingOtherChargeDetail(data);

            //}
        }

        private bool checkGrid()
        {

            if (gdvOtherCharge.RowCount > 0)
            {
                //filter TruckCompany and TransportType
                gdvOtherCharge.ActiveFilterString = string.Format("ChargeDate = {0} ", dtEffective.Text.Trim());

                if (gdvOtherCharge.RowCount > 0)
                {
                    gdvOtherCharge.ActiveFilterEnabled = false;
                    return false;
                }
            }
            gdvOtherCharge.ActiveFilterEnabled = false;
            return true;
        }
        #endregion

        

    }
}
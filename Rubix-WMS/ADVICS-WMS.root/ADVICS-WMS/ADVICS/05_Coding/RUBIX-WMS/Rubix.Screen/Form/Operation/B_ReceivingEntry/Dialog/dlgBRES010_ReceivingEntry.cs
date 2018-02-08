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
using System.IO;
using CSI.Business.BusinessFactory.Common;
namespace Rubix.Screen.Form.Operation.B_ReceivingEntry.Dialog
{
    public partial class dlgBRES010_ReceivingEntry : DialogBase
    {        
        #region Member
        private Dialog.dlgBRES011_TransportDetail m_TransDialog = null;
        private Dialog.dlgBRES012_OtherCharge m_ChargeDialog = null;
        private Dialog.dlgBRES013_ReceivingEntry_SearchByPONo m_PONoDialog = null;

        private ReceivingEntry db;
        private DataTable dtDetail = null;
        private List<string> _filePath = new List<string>();
        private decimal? _vol;
        private string statusName;
        private bool isAutoPalletRef = true;
        #endregion

        #region Enumeration
        public enum ExcelCol
        {
              LineNo = 1
            , PalletNoRef
            , InvoiceNo
            , PONo
            , ReferenceNo
            , ItemCode
            , ItemConditionCode
            , LotNo
            , Qty
            , QtyUnitCode
            , ExpiryDate
            , DetailRemark
        }

        enum eReceivingInstructionDetail
        {
            LineNo
		    ,SortedLineNo
		    ,ProductID
		    ,ProductCode
		    ,ProductLongName
		    ,ProductConditionID
		    ,ProductConditionName
		    ,ActualProductConditionName
		    ,LotNo 
		    ,ActualLotNo
		    ,Qty
		    ,ReceiveQty
		    ,QtyUnitID
		    ,QtyUnit
		    ,NetWeight
		    ,UnitVolume
		    ,PackageID
		    ,PackageName
		    ,InPackage
		    ,InPackageUnitID
		    ,InPackageUnit
		    ,ReferenceNo
		    ,PONo
		    ,DetailRemark
		    ,PalletNoRef
		    ,InvoiceNo
		    ,StatusID
		    ,ExpiredDate
        }
        #endregion

        #region Properties
        public bool ShowActual
        {
            get;
            set;
        }        
        private Dialog.dlgBRES011_TransportDetail TransportDialog
        {
            get
            {
                if (m_TransDialog == null)
                {
                    return m_TransDialog = new Dialog.dlgBRES011_TransportDetail();
                }
                return m_TransDialog;
            }
        }
        private Dialog.dlgBRES012_OtherCharge OtherChargeDialog
        {
            get
            {
                if (m_ChargeDialog == null)
                {
                    return m_ChargeDialog = new Dialog.dlgBRES012_OtherCharge();
                }
                return m_ChargeDialog;
            }
        }
        private Dialog.dlgBRES013_ReceivingEntry_SearchByPONo PONoDialog
        {
            get
            {
                if (m_PONoDialog == null)
                {
                    return m_PONoDialog = new Dialog.dlgBRES013_ReceivingEntry_SearchByPONo();
                }
                return m_PONoDialog;
            }
            set
            {
                m_PONoDialog = value;
            }
        }
        public Common.eScreenMode ScreenMode
        {
            get;
            set;
        }
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
        public string ReceivingNo{get;set;}
        public int Installment{get;set;}
        public int OwnerID { get; set; }
        private DataTable ReceivingDetail
        {
            get
            {
                if (dtDetail == null || dtDetail.Rows.Count == 0)
                {
                    if (dtDetail == null)
                    {
                        dtDetail = new DataTable();
                    }
                    dtDetail.Columns.Clear();
                    dtDetail.Columns.Add(eReceivingInstructionDetail.LineNo.ToString(), typeof(int));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.SortedLineNo.ToString(), typeof(int));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.ReferenceNo.ToString(), typeof(string));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.InvoiceNo.ToString(), typeof(string));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.PONo.ToString(), typeof(string));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.ProductID.ToString(), typeof(int));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.ProductCode.ToString(), typeof(string));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.ProductLongName.ToString(), typeof(string));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.LotNo.ToString(), typeof(string));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.ActualLotNo.ToString(), typeof(string));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.PalletNoRef.ToString(), typeof(string));
                    //dtDetail.Columns.Add(eReceivingInstructionDetail.PalletNo.ToString(), typeof(string));
                    //dtDetail.Columns.Add(eReceivingInstructionDetail.TypeOfPackageID.ToString(), typeof(int));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.NetWeight.ToString(), typeof(decimal));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.UnitVolume.ToString(), typeof(decimal));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.InPackage.ToString(), typeof(decimal));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.InPackageUnit.ToString(), typeof(string));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.InPackageUnitID.ToString(), typeof(int));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.ProductConditionID.ToString(), typeof(int));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.ProductConditionName.ToString(), typeof(string));
                    //dtDetail.Columns.Add(eReceivingInstructionDetail.ActualProductConditionID.ToString(), typeof(int));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.Qty.ToString(), typeof(decimal));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.QtyUnitID.ToString(), typeof(int));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.QtyUnit.ToString(), typeof(string));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.PackageID.ToString(), typeof(int));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.PackageName.ToString(), typeof(string));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.ReceiveQty.ToString(), typeof(decimal));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.DetailRemark.ToString(), typeof(string));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.StatusID.ToString(), typeof(int));
                    dtDetail.Columns.Add(eReceivingInstructionDetail.ExpiredDate.ToString(), typeof(string));
                }
                return dtDetail;
            }
            set
            {
                dtDetail = value;
            }
        }
        #endregion

        #region Constructor
        public dlgBRES010_ReceivingEntry()
        {
            InitializeComponent();
            this.ShowActual = false;
            base.GridViewControl = new GridControl[] { grdRecInstructionDetail };

            CSI.Business.Common.Packaging package = new CSI.Business.Common.Packaging();
            cboTypeOfPackage.Properties.DataSource = package.DataLoading();
            cboTypeOfPackage.Properties.DisplayMember = "PackageName";
            cboTypeOfPackage.Properties.ValueMember = "PackageID";

            CSI.Business.Master.TypeOfUnit unit = new CSI.Business.Master.TypeOfUnit();
            cboInPackageUnit.Properties.DataSource = BusinessClass.LoadUnit(itemControl.ProductID);
            cboInPackageUnit.Properties.DisplayMember = "UnitName";
            cboInPackageUnit.Properties.ValueMember = "UnitID";

            cboQtyUnit.Properties.DataSource = BusinessClass.LoadUnit(itemControl.ProductID);
            cboQtyUnit.Properties.DisplayMember = "UnitName";
            cboQtyUnit.Properties.ValueMember = "UnitID";

            dtArrivalDate.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtArrivalDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtArrivalDate.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtArrivalDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtArrivalDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtArrivalDate.Properties.Mask.EditMask = Common.FullDateFormat;

            deExpiredDate.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            deExpiredDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            deExpiredDate.Properties.EditFormat.FormatString = Common.FullDateFormat;
            deExpiredDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            deExpiredDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            deExpiredDate.Properties.Mask.EditMask = Common.FullDateFormat;

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

            txtOtherCharge.Properties.DisplayFormat.FormatString = Common.AmountFormat;
            txtOtherCharge.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtOtherCharge.Properties.EditFormat.FormatString = Common.AmountFormat;
            txtOtherCharge.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtOtherCharge.Properties.Mask.EditMask = Common.AmountFormat;
            txtOtherCharge.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), string.Empty)) == DialogButton.Yes)
            {
                if (this.ScreenMode == Common.eScreenMode.Edit)
                {
                    if (!iv.ValidateTicket(BusinessClass.ReceivingNo, BusinessClass.Installment.ToString()))
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                        return false;
                    }
                }
                if (ValidateHeader())
                {
                    Control2Entity();
                    bool result = false;
                    try
                    {
                        if (this.ScreenMode == Common.eScreenMode.Add)
                        {
                            BusinessClass.CreateUser = AppConfig.UserLogin;
                        }
                        else
                        {
                            BusinessClass.UpdateUser = AppConfig.UserLogin;                            
                        }

                        result = BusinessClass.SaveChanges(ReceivingDetail, TransportDialog.TransDetail, OtherChargeDialog.OtherDetail, _filePath);

                        if (result)
                        {
                            _filePath.Clear();
                            DialogResult = DialogResult.OK;
                            BusinessClass.ReceivingNo = BusinessClass.ReceivingNo;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageDialog.ShowSystemErrorMsg(this, ex);

                    }
                }
            }
            return false;
        }
        public override bool OnCommandClear()
        {
            dlgBRES010_ReceivingEntry_Load(this, new EventArgs());
            return base.OnCommandClear();
        }
        #endregion

        #region Event Handler Function
        private void dlgBRES010_ReceivingEntry_Load(object sender, EventArgs e)
        {
            try
            {
                itemControl.EnableControl = true;
                InitControl();
                dtArrivalDate.Focus();
                lblCount.Text = string.Empty;

                if (this.ScreenMode != Common.eScreenMode.Add)
                {
                    DataTable dt = BusinessClass.GetReceivingInstructionHeader(this.ReceivingNo, this.Installment);
                    if (dt.Rows.Count > 0)
                    {
                        BusinessClass.ResultData = dt;
                    }
                    Entity2Control();
                }
                else
                {
                    dtArrivalDate.DateTime = DateTime.Today;
                    txtArrivalTime.Text = DateTime.Now.ToString("HH:mm");
                }
                if (this.ScreenMode != Common.eScreenMode.View)
                {
                    itemConditionControl.ProductConditionCode = "NM";
                }

                TransportDialog.ReceivingNo = this.ReceivingNo;
                TransportDialog.Installment = this.Installment;
                OtherChargeDialog.ReceivingNo = this.ReceivingNo;
                OtherChargeDialog.Installment = this.Installment;

                SetTransportCharge();
                SetOtherCharge();

                ReceivingDetail = BusinessClass.GetReceivingInstructionDetail(this.ReceivingNo, this.Installment, this.OwnerID, out statusName);
                txtStatus.Text = statusName;
                grdRecInstructionDetail.DataSource = ReceivingDetail;

                if (this.ScreenMode != Common.eScreenMode.View && ownerControl.OwnerID != null)
                {
                    ownerControl.EnableControl = false;
                    warehouseControl.EnableControl = ownerControl.OwnerID != null;
                    supplierControl.EnableControl = ownerControl.OwnerID != null;
                    itemControl.EnableControl = ownerControl.OwnerID != null;
                    btnImport.Enabled = ownerControl.OwnerID != null;
                    btnAdd.Enabled = ownerControl.OwnerID != null;
                    btnAddByPONo.Enabled = ownerControl.OwnerID != null;
                    btnUpdate.Enabled = ownerControl.OwnerID != null;
                    btnOK.Enabled = ownerControl.OwnerID != null;
                    btnCancel.Enabled = btnOK.Enabled;
                    btnDelete.Enabled = ownerControl.OwnerID != null;
                    btnOtherCharge.Enabled = true;
                    btnTransportDetail.Enabled = true;
                }
                isAutoPalletRef = true;
                if (this.ScreenMode != Common.eScreenMode.View && isAutoPalletRef)
                {
                    txtPalletRef.EditValue = ReceivingDetail.Rows.Count + 1;
                }

                if (this.ShowActual)
                {
                    gcActualLotNo.Visible = true;
                    gcActualLotNo.OptionsColumn.ShowInCustomizationForm = true;
                    gcActualLotNo.OptionsColumn.ShowInExpressionEditor = true;
                    gcActualProductCondition.Visible = true;
                    gcActualProductCondition.OptionsColumn.ShowInCustomizationForm = true;
                    gcActualProductCondition.OptionsColumn.ShowInExpressionEditor = true;
                    gcReceiveQty.Visible = true;
                    gcReceiveQty.OptionsColumn.ShowInCustomizationForm = true;
                    gcReceiveQty.OptionsColumn.ShowInExpressionEditor = true;
                }
                else
                {
                    gcActualLotNo.Visible = false;
                    gcActualLotNo.OptionsColumn.ShowInCustomizationForm = false;
                    gcActualLotNo.OptionsColumn.ShowInExpressionEditor = false;
                    gcActualProductCondition.Visible = false;
                    gcActualProductCondition.OptionsColumn.ShowInCustomizationForm = false;
                    gcActualProductCondition.OptionsColumn.ShowInExpressionEditor = false;
                    gcReceiveQty.Visible = false;
                    gcReceiveQty.OptionsColumn.ShowInCustomizationForm = false;
                    gcReceiveQty.OptionsColumn.ShowInExpressionEditor = false;
                }

                ControlUtil.SetBestWidth(gdvRecInstructionDetail);
                //ControlUtil.EnableControl(true, btnImport, btnAdd, btnUpdate, btnOK);

                if (ScreenMode == Common.eScreenMode.Add)
                {
                    m_statusBarCreatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                    m_statusBarCreatedUser.Caption = AppConfig.UserLogin;
                    m_statusBarUpdatedDate.Caption = "-";
                    m_statusBarUpdatedUser.Caption = "-";

                }
                else
                {
                    m_statusBarCreatedDate.Caption = BusinessClass.CreateDate.Value.ToString(Common.FullDatetimeFormat);
                    m_statusBarCreatedUser.Caption = BusinessClass.CreateUser;
                    if (BusinessClass.UpdateDate != null)
                    {
                        m_statusBarUpdatedDate.Caption = Convert.ToDateTime(BusinessClass.UpdateDate).ToString(Common.FullDatetimeFormat);
                        m_statusBarUpdatedUser.Caption = BusinessClass.UpdateUser;
                    }
                    else if (BusinessClass.UpdateDate == null && ScreenMode == Common.eScreenMode.Edit)
                    {
                        m_statusBarUpdatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                        m_statusBarUpdatedUser.Caption = AppConfig.UserLogin;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void dlgBRES010_ReceivingEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnOK.Visible)
            {
                e.Cancel = (MessageDialog.ShowConfirmationMsg(this, Common.GetMessage("I0004")) != DialogButton.Yes);
            }
        }

        private void btnTransportDetail_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                TransportDialog.BusinessClass = this.BusinessClass;
                TransportDialog.ScreenMode = this.ScreenMode;
                DataTable original = TransportDialog.TransDetail.Copy();
                if (TransportDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    SetTransportCharge();
                }
                else
                {
                    this.TransportDialog.TransDetail = original;
                }
                this.Enabled = true;
            }
            catch (Exception ex)
            {                
                MessageBox.Show(this, ex.Message);
            }
        }

        private void btnOtherCharge_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                OtherChargeDialog.BusinessClass = this.BusinessClass;
                OtherChargeDialog.ScreenMode = this.ScreenMode;
                DataTable original = OtherChargeDialog.OtherDetail.Copy();
                if (OtherChargeDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    SetOtherCharge();
                }
                else
                {
                    this.OtherChargeDialog.OtherDetail = original;
                }
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void btnAttachCOA_Click(object sender, EventArgs e)
        {
            if (ofdCOA.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(ofdCOA.FileName);

                long filesize = fileInfo.Length;
                if (filesize >= 4194340)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0200"));
                    return;
                }

                _filePath.Add(ofdCOA.FileName);
                lblCount.Text = string.Format("{0}", _filePath.Count);
            }
        }

        private void supplierControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtAddress1.Text = supplierControl.SupplierAddress1;
                txtAddress2.Text = supplierControl.SupplierAddress2;
                txtPostalCode.Text = supplierControl.PostalCode;
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
                warehouseControl.OwnerID = ownerControl.OwnerID;
                warehouseControl.DataLoading();
                supplierControl.OwnerID = ownerControl.OwnerID;
                supplierControl.DataLoading();
                itemControl.OwnerID = ownerControl.OwnerID;
                itemControl.DataLoading();
                if (ReceivingDetail != null)
                {
                    ReceivingDetail.Rows.Clear();
                    ControlUtil.SetBestWidth(gdvRecInstructionDetail);
                }
                if (this.ScreenMode != Common.eScreenMode.View && ownerControl.OwnerID != null)
                {
                    ownerControl.EnableControl = false;
                    warehouseControl.EnableControl = ownerControl.OwnerID != null;
                    supplierControl.EnableControl = ownerControl.OwnerID != null;
                    itemControl.EnableControl = ownerControl.OwnerID != null;
                    btnImport.Enabled = ownerControl.OwnerID != null;
                    btnAdd.Enabled = ownerControl.OwnerID != null;
                    btnAddByPONo.Enabled = ownerControl.OwnerID != null;
                    btnUpdate.Enabled = ownerControl.OwnerID != null;
                    btnOK.Enabled = ownerControl.OwnerID != null;
                    btnCancel.Enabled = btnOK.Enabled;
                    btnDelete.Enabled = ownerControl.OwnerID != null;
                    btnOtherCharge.Enabled = true;
                    btnTransportDetail.Enabled = true;
                    BusinessClass.OwnerID = ownerControl.OwnerID.Value;
                    }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void cboQtyUnit_EditValueChanged(object sender, EventArgs e)
        {
            LoadUnitOfMeasure();
        }

        private void txtQty_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (gdvUnit.RowCount > 0)
                {
                    UpdateUnitOfMeasure(gdvUnit.GetDataRow(0));
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
        
        private void productControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtQty.EditValue = string.Empty;
                cboInPackageUnit.Properties.DataSource = BusinessClass.LoadUnit(itemControl.ProductID);
                cboQtyUnit.Properties.DataSource = BusinessClass.LoadUnit(itemControl.ProductID);

                if (itemControl.ProductID.HasValue)
                {
                    DataTable prodInfo = BusinessClass.LoadProductInfo(itemControl.ProductID.Value);
                    if (prodInfo != null)
                    {
                        cboTypeOfPackage.EditValue = Convert.ToInt32(prodInfo.Rows[0]["PackageID"]);
                        cboInPackageUnit.EditValue = prodInfo.Rows[0]["TypeOfUnitLevel2"];
                        txtInPackage.EditValue = prodInfo.Rows[0]["NumberOfUnitLevel2"];
                        cboQtyUnit.EditValue = prodInfo.Rows[0]["TypeOfUnitLevel2"];
                        _vol = DataUtil.Convert<decimal>(prodInfo.Rows[0]["VolumeOfUnitLevel1"]);
                        LoadUnitOfMeasure();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void warehouseControl_EditValueChanged(object sender, EventArgs e)
        {
            if (warehouseControl.WarehouseID.HasValue)
            {
                BusinessClass.WarehouseID = warehouseControl.WarehouseID.Value;
            }
        }

        private void txtPalletRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            isAutoPalletRef = false;
        }

        private void txtQty_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal val = Convert.ToDecimal(e.NewValue);
            e.Cancel = val > ((SpinEdit)sender).Properties.MaxValue ||
                val < ((SpinEdit)sender).Properties.MinValue;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateDetail())
                {
                    if (this.ScreenMode == Common.eScreenMode.Edit && !BusinessClass.CanAddDetail(BusinessClass.ReceivingNo, BusinessClass.Installment, BusinessClass.OwnerID))
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0131"));
                        return;
                    }

                    DataRow dr = ReceivingDetail.NewRow();
                    if (gdvUnit.RowCount > 0)
                    {
                        DataRow unit = ((DataRowView)(gdvUnit.GetRow(0))).Row;
                        dr[eReceivingInstructionDetail.NetWeight.ToString()] = unit["NetWeight"];
                        txtNetWeight.EditValue = unit["NetWeight"];
                    }
                    ReceivingDetail.Rows.Add(dr);
                    SetDetail(dr);
                    if (isAutoPalletRef)
                    {
                        txtPalletRef.EditValue = gdvRecInstructionDetail.RowCount + 1;
                    }
                }
                ControlUtil.SetBestWidth(gdvRecInstructionDetail);
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
                if (gdvRecInstructionDetail.GetFocusedRow() != null)
                {
                    DeleteDetail(gdvRecInstructionDetail.GetFocusedDataRow());
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdvRecInstructionDetail.GetFocusedRow() != null)
                {
                    DataRow dr = gdvRecInstructionDetail.GetFocusedDataRow();
                    if (this.ScreenMode == Common.eScreenMode.Edit && !BusinessClass.CanUpdateDetail(BusinessClass.ReceivingNo, BusinessClass.Installment, BusinessClass.OwnerID, Convert.ToInt32(dr["LineNo"])))
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0131"));
                        return;
                    }

                    if (dr["StatusID"] != DBNull.Value)
                    {


                        if (Convert.ToInt32(dr["StatusID"]) == CSI.Business.Common.Status.NewReceivingEntry
                            || Convert.ToInt32(dr["StatusID"]) == CSI.Business.Common.Status.ReceiveInstrunctionIssued)
                        {
                            txtReferenceNo.Properties.ReadOnly = false;
                            txtInvoiceNo.Properties.ReadOnly = false;
                            txtPONo.Properties.ReadOnly = false;
                            txtLotNo.Properties.ReadOnly = false;
                            itemControl.EnableControl = true;
                            itemConditionControl.EnableControl = true;
                            txtPalletRef.Properties.ReadOnly = false;
                            cboTypeOfPackage.Properties.ReadOnly = true;
                            txtQty.Properties.ReadOnly = false;
                            cboQtyUnit.Properties.ReadOnly = false;
                            deExpiredDate.Properties.ReadOnly = false;
                        }
                        else if (Convert.ToInt32(dr["StatusID"]) == CSI.Business.Common.Status.IncompleteReceiving || Convert.ToInt32(dr["StatusID"]) == CSI.Business.Common.Status.CompleteReceiving)
                        {
                            txtReferenceNo.Properties.ReadOnly = false;
                            txtInvoiceNo.Properties.ReadOnly = false;
                            txtPONo.Properties.ReadOnly = false;
                            txtLotNo.Properties.ReadOnly = false;
                            itemControl.EnableControl = false;
                            itemConditionControl.EnableControl = false;
                            deExpiredDate.Properties.ReadOnly = false;
                            txtPalletRef.Properties.ReadOnly = true;
                            cboTypeOfPackage.Properties.ReadOnly = true;
                            txtQty.Properties.ReadOnly = true;
                            cboQtyUnit.Properties.ReadOnly = true;
                        }
                    }
                    ToggleMode();

                    txtDetailRemark.Text = dr[eReceivingInstructionDetail.DetailRemark.ToString()].ToString();
                    itemControl.ProductID = DataUtil.Convert<int>(dr[eReceivingInstructionDetail.ProductID.ToString()]);
                    itemConditionControl.ProductConditionID = DataUtil.Convert<int>(dr[eReceivingInstructionDetail.ProductConditionID.ToString()]);
                    txtQty.EditValue = dr[eReceivingInstructionDetail.Qty.ToString()];
                    cboQtyUnit.EditValue = dr[eReceivingInstructionDetail.QtyUnitID.ToString()];
                    txtReferenceNo.Text = dr[eReceivingInstructionDetail.ReferenceNo.ToString()].ToString();
                    txtPONo.Text = dr[eReceivingInstructionDetail.PONo.ToString()].ToString();
                    cboTypeOfPackage.EditValue = Convert.ToInt32(dr[eReceivingInstructionDetail.PackageID.ToString()]);
                    txtLotNo.Text = dr[eReceivingInstructionDetail.LotNo.ToString()].ToString();
                    txtLineNo.EditValue = dr[eReceivingInstructionDetail.SortedLineNo.ToString()];
                    txtInPackage.EditValue = dr[eReceivingInstructionDetail.InPackage.ToString()];
                    cboInPackageUnit.EditValue = dr[eReceivingInstructionDetail.InPackageUnitID.ToString()];
                    _vol = DataUtil.Convert<decimal>(dr[eReceivingInstructionDetail.UnitVolume.ToString()]);
                    txtPalletRef.Text = dr[eReceivingInstructionDetail.PalletNoRef.ToString()].ToString();
                    txtInvoiceNo.Text = dr[eReceivingInstructionDetail.InvoiceNo.ToString()].ToString();
                    deExpiredDate.EditValue = dr[eReceivingInstructionDetail.ExpiredDate.ToString()];

                    LoadUnitOfMeasure();
                    
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
                if (ValidateDetail())
                {
                    ToggleMode();
                    DataRow dr = gdvRecInstructionDetail.GetFocusedDataRow();
                    if (gdvUnit.RowCount > 0)
                    {
                        DataRow unit = ((DataRowView)(gdvUnit.GetRow(0))).Row;
                        dr[eReceivingInstructionDetail.NetWeight.ToString()] = unit["NetWeight"];
                        txtNetWeight.EditValue = unit["NetWeight"];
                    }
                    SetDetail(dr);
                    ControlUtil.ClearControlData(grpEditDetail.Controls);
                    itemConditionControl.ProductConditionCode = "NM";
                    isAutoPalletRef = true;
                    txtPalletRef.EditValue = gdvRecInstructionDetail.RowCount + 1;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
                
        private void btnImport_Click(object sender, EventArgs e)
        {
            string errorMsg = string.Empty;
            Rubix.Framework.ExcelManager excel = new ExcelManager();
            try
            {
                if (ofdImport.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {

                    this.ShowWaitScreen();
                    if (this.ScreenMode == Common.eScreenMode.Edit && !BusinessClass.CanAddDetail(BusinessClass.ReceivingNo, BusinessClass.Installment, BusinessClass.OwnerID))
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0131"));
                        return;
                    }
                    CSI.Business.Common.Packaging package = new CSI.Business.Common.Packaging();
                    CSI.Business.Common.ProductCondition condition = new CSI.Business.Common.ProductCondition();
                    CSI.Business.Common.Product product = new CSI.Business.Common.Product();
                    CSI.Business.Common.TypeOfUnit unit = new CSI.Business.Common.TypeOfUnit();

                    using (excel)
                    {
                        excel.OpenExcel(ofdImport.FileName);
                        //read header
                        int maxCol = 1, row = 1;
                        while (!string.IsNullOrWhiteSpace(excel.ReadData(1, maxCol)))
                        {
                            maxCol++;
                        }
                        row++;
                        while (!string.IsNullOrWhiteSpace(excel.ReadData(row, (int)ExcelCol.LineNo)))
                        {
                            string strPalletRefNo = excel.ReadData(row, (int)ExcelCol.PalletNoRef).Trim();
                            string strItemCode = excel.ReadData(row, (int)ExcelCol.ItemCode).Trim();
                            string strLotNo = excel.ReadData(row, (int)ExcelCol.LotNo).Trim();
                            decimal? iQty = Rubix.Framework.DataUtil.Convert<decimal>(excel.ReadData(row, (int)ExcelCol.Qty));
                            string strQtyUnitCode = excel.ReadData(row, (int)ExcelCol.QtyUnitCode).Trim();
                            string strItemConditionCode = excel.ReadData(row, (int)ExcelCol.ItemConditionCode).Trim();
                            string strDetailRemark = excel.ReadData(row, (int)ExcelCol.DetailRemark).Trim();
                            string strPONO = excel.ReadData(row, (int)ExcelCol.PONo).Trim();
                            string strInvoiceNo = excel.ReadData(row, (int)ExcelCol.InvoiceNo);

                            ////Validate Pallet Ref No
                            if (string.IsNullOrEmpty(strPalletRefNo))
                            {
                                //Please input Pallet No.(Ref).
                                errorMsg = Common.GetMessage("I0299");
                                return;
                            }
                            
                            ////Validate Item Code
                            if (string.IsNullOrEmpty(strItemCode))
                            {
                                //Product is null in row '{0}'
                                errorMsg = Common.GetMessage("I0330", row.ToString());
                                return;
                            }
                            tbm_Product productData = product.GetProductInfo(strItemCode, ownerControl.OwnerID);
                            if (productData == null)
                            {
                                errorMsg = Rubix.Screen.Common.GetMessage("I0279", "Item", strItemCode);
                                return;
                            }

                            ////Validate Item Condition Code
                            if (string.IsNullOrEmpty(strItemConditionCode))
                            {
                                errorMsg = Rubix.Screen.Common.GetMessage("I0279", "Item Condition", strItemConditionCode);
                                return;
                            }
                            tbm_ProductCondition conditionData = condition.GetProductConditionInfo(strItemConditionCode);
                            if (conditionData == null)
                            {
                                errorMsg = Rubix.Screen.Common.GetMessage("I0279", "Item Condition", strItemConditionCode);
                                return;
                            }

                            /////Validate Order QTY
                            if (iQty == null)
                            {
                                errorMsg = Common.GetMessage("I0279", "Order Qty", strItemCode);
                                return;
                            }
                            
                            ////Validate QTY Unit Code
                            tbm_TypeOfUnit qtyUnit = unit.GetUnitInfo(excel.ReadData(row, (int)ExcelCol.QtyUnitCode));
                            if (qtyUnit == null)
                            {
                                errorMsg = Rubix.Screen.Common.GetMessage("I0279", "Type Of Unit", strQtyUnitCode);
                                return;
                            }
                            
                            if (!product.IsUnitInProduct(productData.ProductID, qtyUnit.UnitID))
                            {
                                errorMsg = Rubix.Screen.Common.GetMessage("I0279", "Item Default Unit", strQtyUnitCode);
                                return;
                            }
                            if (!product.IsProductOK(productData.ProductID))
                            {
                                errorMsg = Common.GetMessage("I0126") + " (" + strItemCode + ")";
                                return;
                            }

                            /////Validate Detail Remark
                            if (!string.IsNullOrWhiteSpace(strDetailRemark) && strDetailRemark.Length > 100)
                            {
                                errorMsg = Rubix.Screen.Common.GetMessage("I0280");
                                return;
                            }

                            /////Validate Expiry Date
                            if(!DataUtil.IsDate(excel.ReadData(row, (int)ExcelCol.ExpiryDate)))
                            {
                                errorMsg = string.Format(Rubix.Screen.Common.GetMessage("I0284"), excel.ReadData(row, (int)ExcelCol.ExpiryDate));
                                return;
                            }

                            DataRow detail = ReceivingDetail.NewRow();

                            detail[eReceivingInstructionDetail.LineNo.ToString()] = ReceivingDetail.Rows.Count + (row - 1);
                            detail[eReceivingInstructionDetail.DetailRemark.ToString()] = strDetailRemark;
                            detail[eReceivingInstructionDetail.InvoiceNo.ToString()] = strInvoiceNo;
                            detail[eReceivingInstructionDetail.LotNo.ToString()] =strLotNo;
                            
                            //Load Item Detail
                            itemControl.ProductCode = strItemCode;

                            detail[eReceivingInstructionDetail.InPackageUnit.ToString()] = cboInPackageUnit.Text;
                            detail[eReceivingInstructionDetail.InPackageUnitID.ToString()] = DataUtil.Convert<int>(cboInPackageUnit.EditValue);
                            detail[eReceivingInstructionDetail.InPackage.ToString()] = DataUtil.Convert<decimal>(txtInPackage.EditValue);

                            detail[eReceivingInstructionDetail.PackageID.ToString()] = (int)cboTypeOfPackage.EditValue;
                            detail[eReceivingInstructionDetail.PackageName.ToString()] = cboTypeOfPackage.Text;

                            detail[eReceivingInstructionDetail.NetWeight.ToString()] = DataUtil.Convert<decimal>(txtNetWeight.EditValue);
                            
                            detail[eReceivingInstructionDetail.PalletNoRef.ToString()] = excel.ReadData(row, (int)ExcelCol.PalletNoRef);
                            detail[eReceivingInstructionDetail.PONo.ToString()] = strPONO;
                            detail[eReceivingInstructionDetail.ProductCode.ToString()] = strItemCode;
                            detail[eReceivingInstructionDetail.ProductConditionID.ToString()] = conditionData.ProductConditionID;
                            detail[eReceivingInstructionDetail.ProductConditionName.ToString()] = conditionData.ProductConditionName;
                            detail[eReceivingInstructionDetail.ProductID.ToString()] = productData.ProductID;
                            detail[eReceivingInstructionDetail.ProductLongName.ToString()] = productData.ProductLongName;
                            detail[eReceivingInstructionDetail.Qty.ToString()] = Convert.ToDecimal(iQty);
                            detail[eReceivingInstructionDetail.QtyUnit.ToString()] = strQtyUnitCode;
                            detail[eReceivingInstructionDetail.QtyUnitID.ToString()] = qtyUnit.UnitID;
                            detail[eReceivingInstructionDetail.SortedLineNo.ToString()] = detail[eReceivingInstructionDetail.LineNo.ToString()];
                            detail[eReceivingInstructionDetail.DetailRemark.ToString()] = strDetailRemark;
                            detail[eReceivingInstructionDetail.UnitVolume.ToString()] = _vol;

                            detail[eReceivingInstructionDetail.ExpiredDate.ToString()] = DataUtil.ConvertToDate(excel.ReadData(row, (int)ExcelCol.ExpiryDate));

                            ReceivingDetail.Rows.Add(detail);
                            row++;
                        }
                        if ((row - 1) == 1)
                            MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                        else
                        {
                            ControlUtil.SetBestWidth(gdvRecInstructionDetail);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
            finally
            {
                excel.Dispose();
                this.CloseWaitScreen();
                if (!string.IsNullOrWhiteSpace(errorMsg))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, errorMsg);
                }
            }
        }

        private void btnAddByPONo_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidateAddByPONo())
                {
                    PONoDialog.OwnerID = ownerControl.OwnerID ?? -1;
                    PONoDialog.WarehouseID = warehouseControl.WarehouseID ?? -1;
                    PONoDialog.SupplierID = supplierControl.SupplierID ?? -1;
                    if (PONoDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        DataTable dt = BusinessClass.LoadDetailPDSNo(PONoDialog.PDSNo);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            ReceivingDetail.Rows.Clear();

                            foreach (DataRow dr in dt.Rows)
                            {
                                itemControl.ProductID = DataUtil.Convert<int>(dr["ProductID"]);
                                txtQty.Text = dr["OrderQty"].ToString();
                                cboQtyUnit.EditValue = dr["UnitID"]; //DataUtil.Convert<int>(dr["UnitID"]);
                                txtPONo.Text = PONoDialog.PONo;
                                txtLotNo.Text = PONoDialog.PDSNo;
                                btnAdd_Click(sender, e);
                            }

                            ControlUtil.EnableControl(false, btnImport, btnAdd, btnUpdate, btnDelete, btnOK,warehouseControl,supplierControl,btnCancel);
                        }
                        else
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, "No item in this PO No.");
                        }

                    }

                    this.PONoDialog = null;

                }



            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleMode();
                DataRow dr = gdvRecInstructionDetail.GetFocusedDataRow();
                if (gdvUnit.RowCount > 0)
                {
                    DataRow unit = ((DataRowView)(gdvUnit.GetRow(0))).Row;
                    dr[eReceivingInstructionDetail.NetWeight.ToString()] = unit["NetWeight"];
                    txtNetWeight.EditValue = unit["NetWeight"];
                }
                ControlUtil.ClearControlData(grpEditDetail.Controls);
                itemConditionControl.ProductConditionCode = "NM";
                isAutoPalletRef = true;
                txtPalletRef.EditValue = gdvRecInstructionDetail.RowCount + 1;

            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        #endregion
                
        #region Generic Function
        private void Entity2Control()
        {
            txtReceivingNo.Text = BusinessClass.ReceivingNo;
            ownerControl.OwnerID = BusinessClass.OwnerID;
            warehouseControl.WarehouseID = BusinessClass.WarehouseID;
            supplierControl.SupplierID = BusinessClass.SupplierID;
            dtArrivalDate.EditValue = BusinessClass.ArrivalDate;
            txtArrivalTime.Text = BusinessClass.ArrivalDate.ToString("HH:mm");
            txtRemark.Text = BusinessClass.Remark;

            m_statusBarCreatedDate.Caption = BusinessClass.CreateDate.Value.ToString(Rubix.Screen.Common.FullDatetimeFormat);
            m_statusBarCreatedUser.Caption = BusinessClass.CreateUser;
            if (BusinessClass.UpdateDate.HasValue)
                m_statusBarUpdatedDate.Caption = BusinessClass.UpdateDate.Value.ToString(Rubix.Screen.Common.FullDatetimeFormat);
            else
                m_statusBarUpdatedDate.Caption = "-";
            if (String.IsNullOrWhiteSpace(BusinessClass.UpdateUser))
                m_statusBarUpdatedUser.Caption = "-";
            else
                m_statusBarUpdatedUser.Caption = BusinessClass.UpdateUser;

        }

        private void Control2Entity()
        {
            BusinessClass.ReceivingNo = txtReceivingNo.Text;
            BusinessClass.OwnerID = ownerControl.OwnerID.Value;
            BusinessClass.WarehouseID = warehouseControl.WarehouseID.Value;
            BusinessClass.SupplierID = supplierControl.SupplierID.Value;
            BusinessClass.ArrivalDate = ((DateTime)dtArrivalDate.EditValue).Date.AddHours(Convert.ToDouble(txtArrivalTime.Text.Substring(0, 2))).AddMinutes(Convert.ToDouble(txtArrivalTime.Text.Substring(3, 2)));

            BusinessClass.Remark = txtRemark.Text;
            BusinessClass.CancelSlipFlag = false;
            BusinessClass.Installment = 1;
        }

        private void ToggleMode()
        {
            btnAdd.Visible = btnOK.Visible;
            btnDelete.Visible = btnOK.Visible;
            btnImport.Visible = btnOK.Visible;
            btnUpdate.Visible = btnOK.Visible;
            btnAddByPONo.Visible = btnOK.Visible;
            m_toolBarClear.Enabled = btnOK.Visible;
            m_toolBarClose.Enabled = btnOK.Visible;
            m_toolBarSave.Enabled = btnOK.Visible;
            grdRecInstructionDetail.Enabled = btnOK.Visible;
            btnOK.Visible = !btnOK.Visible;
            btnCancel.Visible = btnOK.Visible;
        }

        private bool ValidateHeader()
        {
            errorProvider.ClearErrors();
            bool validate = true;
            if (!ownerControl.ValidateControl())
            {
                validate = false;
            }
            if (!warehouseControl.ValidateControl())
            {
                validate = false;
            }
            if (!supplierControl.ValidateControl())
            {
                validate = false;
            }
            if (string.IsNullOrWhiteSpace(dtArrivalDate.Text) || string.IsNullOrWhiteSpace(txtArrivalTime.Text))
            {
                errorProvider.SetError(dtArrivalDate, Common.GetMessage("I0163"));
                validate = false;
            }
            else 
            { 
                if(false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(DataUtil.Convert<DateTime>(dtArrivalDate.EditValue), true))
                {
                    errorProvider.SetError(dtArrivalDate, Common.GetMessage("I0236"));
                    validate = false;
                }
            }

            if (ReceivingDetail.Rows.Count <= 0)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0162"));
                validate = false;
            }
            return validate;
        }

        private bool ValidateDetail()
        {
            bool isOK = true;
            errorProvider.ClearErrors();
            if (!itemControl.ValidateControl())
            {
                isOK = false;
            }
            if (!itemConditionControl.ValidateControl())
            {
                isOK = false;
            }

            //if (string.IsNullOrWhiteSpace(txtLotNo.Text))
            //{
            //    if (MessageDialog.ShowConfirmationMsg(this, "Lot No. is empty. Do you want to use default Lot No ?") == DialogButton.Yes)
            //        txtLotNo.Text = "-";
            //    else
            //    {
            //        errorProvider.SetError(txtLotNo, "Please input Lot No.");
            //        isOK = false;
            //    }
            //}
            int? pck = DataUtil.Convert<int>(cboTypeOfPackage.EditValue);
            if (!pck.HasValue)
            {
                errorProvider.SetError(cboTypeOfPackage, Common.GetMessage("I0182"));
                isOK = false;
            }
            //if (string.IsNullOrWhiteSpace(txtDetailRemark.Text))
            //{
            //    errorProvider.SetError(txtDetailRemark, "Please input Detail Remark.");
            //    return false;
            //}
            if (string.IsNullOrWhiteSpace(txtQty.Text))
            {
                errorProvider.SetError(txtQty, Common.GetMessage("I0298"));
                isOK = false;
            }
            if (!DataUtil.IsValidDecimal(txtQty.Text, 18, 3))
            {
                errorProvider.SetError(txtQty, Common.GetMessage("I0277"));
                isOK = false;
            }
            //if (string.IsNullOrWhiteSpace(txtInPackage.Text))
            //{
            //    errorProvider.SetError(txtInPackage, "Please input In Package.");
            //    isOK = false;
            //}
            //if (!DataUtil.IsValidDecimal(txtInPackage.Text, 18, 3))
            //{
            //    errorProvider.SetError(txtInPackage, "Incorrect decimal value for In Package");
            //    isOK = false;
            //}
            //if (string.IsNullOrWhiteSpace(txtPalletRef.Text))
            //{
            //    errorProvider.SetError(txtPalletRef, Common.GetMessage("I0299"));
            //    isOK = false;
            //}

            if (string.IsNullOrWhiteSpace(txtPONo.Text))
            {
                errorProvider.SetError(txtPONo, Common.GetMessage("I0418"));
                isOK = false;
            }

            return isOK;
        }

        private bool ValidateAddByPONo()
        {
            errorProvider.ClearErrors();
            bool validate = true;
            if (!ownerControl.ValidateControl())
            {
                validate = false;
            }
            if (!warehouseControl.ValidateControl())
            {
                validate = false;
            }
            if (!supplierControl.ValidateControl())
            {
                validate = false;
            }
            return validate;
        }

        private void InitControl()
        {
            ShowQtyLevel1();

            ControlUtil.ClearControlData(this.Controls);
            btnAdd.Visible = true;
            btnAddByPONo.Visible = true;

            btnDelete.Visible = true;
            btnImport.Visible = true;
            btnUpdate.Visible = true;
            btnOK.Visible = false;
            btnCancel.Visible = btnOK.Visible;
            grdRecInstructionDetail.Enabled = true;

            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            supplierControl.ErrorText = Common.GetMessage("I0300");
            supplierControl.RequireField = true;

            itemControl.ErrorText = Common.GetMessage("I0301");
            itemControl.RequireField = true;

            itemConditionControl.ErrorText = Common.GetMessage("I0302");
            itemConditionControl.RequireField = true;

            if (this.ScreenMode == Common.eScreenMode.View)
            {
                //header
                ownerControl.EnableControl = false;
                warehouseControl.EnableControl = false;
                supplierControl.EnableControl = false;               
                ControlUtil.EnableControl(false, txtReceivingNo, deExpiredDate, btnAttachCOA, dtArrivalDate, txtRemark, txtArrivalTime);
                ControlUtil.EnableControl(true, btnOtherCharge, btnTransportDetail);

                //detail
                ControlUtil.EnableControl(false, txtReferenceNo, txtPONo, txtInPackage, txtQty, cboTypeOfPackage
                                        , txtLotNo, txtInvoiceNo, txtDetailRemark, txtPalletRef, cboQtyUnit);

                itemConditionControl.EnableControl = false;
                itemControl.EnableControl = false;
                
                ControlUtil.EnableControl(false, btnDelete, btnUpdate, btnAdd, btnImport,btnAddByPONo);
                ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);

            }
            else 
            {
                //header
                txtReceivingNo.Properties.ReadOnly = true;
                //not allow to edit
                ownerControl.EnableControl = (this.ScreenMode == Common.eScreenMode.Add);
                warehouseControl.EnableControl = (ownerControl.OwnerID != null);
                supplierControl.EnableControl = (ownerControl.OwnerID != null);

                ControlUtil.EnableControl(true, dtArrivalDate, deExpiredDate, txtArrivalTime, txtRemark, btnAttachCOA);
                ControlUtil.EnableControl((this.ScreenMode != Common.eScreenMode.Add), btnOtherCharge, btnTransportDetail);

                //detail
                ControlUtil.EnableControl(true, txtReferenceNo, txtPONo, txtQty, txtLotNo, txtInvoiceNo, txtDetailRemark, txtPalletRef, cboQtyUnit);
                ControlUtil.EnableControl((ownerControl.OwnerID != null), btnDelete, btnUpdate, btnAdd, btnImport,btnAddByPONo);
                ControlUtil.EnableControl(false, cboTypeOfPackage, txtInPackage);

                itemConditionControl.EnableControl = true;
                itemControl.EnableControl = true;

                ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);
            }
        }

        private void SetDetail(DataRow data)
        {            
            data[eReceivingInstructionDetail.DetailRemark.ToString()] = txtDetailRemark.Text;
            data[eReceivingInstructionDetail.ProductID.ToString()] = itemControl.ProductID.Value;
            data[eReceivingInstructionDetail.ProductCode.ToString()] = itemControl.ProductCode;
            data[eReceivingInstructionDetail.ProductConditionID.ToString()] = itemConditionControl.ProductConditionID.Value;
            data[eReceivingInstructionDetail.ProductConditionName.ToString()] = itemConditionControl.ProductConditionName;
            data[eReceivingInstructionDetail.ProductLongName.ToString()] = itemControl.ProductLongName;
            data[eReceivingInstructionDetail.Qty.ToString()] = Decimal.Parse(txtQty.EditValue.ToString());
            data[eReceivingInstructionDetail.QtyUnitID.ToString()] = Convert.ToInt32(cboQtyUnit.EditValue);
            data[eReceivingInstructionDetail.QtyUnit.ToString()] = cboQtyUnit.Text;
            data[eReceivingInstructionDetail.ReferenceNo.ToString()] = txtReferenceNo.Text;
            data[eReceivingInstructionDetail.PONo.ToString()] = txtPONo.Text;
            data[eReceivingInstructionDetail.PackageID.ToString()] = Convert.ToInt32(cboTypeOfPackage.EditValue);
            data[eReceivingInstructionDetail.PackageName.ToString()] = cboTypeOfPackage.Text;
            if (string.IsNullOrEmpty(txtNetWeight.Text.Trim()))
            {
                data[eReceivingInstructionDetail.NetWeight.ToString()] = DBNull.Value;
            }
            else
            {
                data[eReceivingInstructionDetail.NetWeight.ToString()] = Convert.ToDecimal(txtNetWeight.EditValue);
            }

            data[eReceivingInstructionDetail.LotNo.ToString()] = "L-" + itemControl.ProductCode;
            if (data[eReceivingInstructionDetail.LineNo.ToString()] == DBNull.Value)
            {
                if (false == string.IsNullOrWhiteSpace(BusinessClass.ReceivingNo))
                {
                    int maxFromDb = BusinessClass.GetMaxLineNo(BusinessClass.ReceivingNo);
                    int maxFromScreen = GetMaxLineFromGrid();
                    data[eReceivingInstructionDetail.LineNo.ToString()] = maxFromDb > maxFromScreen ? maxFromDb + 1 : maxFromScreen + 1;
                }
                else
                {
                    data[eReceivingInstructionDetail.LineNo.ToString()] = GetMaxLineFromGrid() + 1;
                }
            }
            if (data[eReceivingInstructionDetail.SortedLineNo.ToString()] == DBNull.Value)
            {
                data[eReceivingInstructionDetail.SortedLineNo.ToString()] = gdvRecInstructionDetail.RowCount;
            }

            data[eReceivingInstructionDetail.InPackageUnit.ToString()] = cboInPackageUnit.Text;
            if (cboInPackageUnit.EditValue == null)
            {
                data[eReceivingInstructionDetail.InPackageUnitID.ToString()] = DBNull.Value;
            }
            else
            {
                data[eReceivingInstructionDetail.InPackageUnitID.ToString()] =Convert.ToInt32(cboInPackageUnit.EditValue);
            }
            if (string.IsNullOrEmpty(txtInPackage.Text.Trim()))
            {
                data[eReceivingInstructionDetail.InPackage.ToString()] = DBNull.Value;
            }
            else
            {
                data[eReceivingInstructionDetail.InPackage.ToString()] = Convert.ToDecimal(txtInPackage.EditValue);
            }
            data[eReceivingInstructionDetail.UnitVolume.ToString()] = _vol;
            data[eReceivingInstructionDetail.PalletNoRef.ToString()] = txtPalletRef.Text;
            data[eReceivingInstructionDetail.InvoiceNo.ToString()] = txtInvoiceNo.Text;
            if (deExpiredDate.EditValue == null)
            {
                data[eReceivingInstructionDetail.ExpiredDate.ToString()] = DBNull.Value;
            }
            else
            {
                data[eReceivingInstructionDetail.ExpiredDate.ToString()] = DataUtil.Convert<DateTime>(deExpiredDate.EditValue);
            }
        }

        private int GetMaxLineFromGrid()
        {
            int maxLine = 0;

            foreach (DataRow dr in ReceivingDetail.Rows)
            {
                int lineNo = dr["LineNo"] == DBNull.Value ? 0 : Convert.ToInt32(dr["LineNo"]);
                if (lineNo > maxLine)
                {
                    maxLine = lineNo;
                }
            }
            return maxLine;
        }
        
        private void DeleteDetail(DataRow row)
        {
            int deletedLine = Convert.ToInt32(row[eReceivingInstructionDetail.LineNo.ToString()]);
            long sortedDeletedLine = Convert.ToInt32(row[eReceivingInstructionDetail.SortedLineNo.ToString()]);
            if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0002"), BusinessClass.ReceivingNo + " line " + sortedDeletedLine)) == DialogButton.Yes)
            {
                if (BusinessClass.CanDeleteDetail(BusinessClass.ReceivingNo, BusinessClass.Installment, BusinessClass.OwnerID, deletedLine))
                {
                    if (gdvRecInstructionDetail.GetSelectedRows().Length > 0)
                    {
                        gdvRecInstructionDetail.DeleteSelectedRows();
                    }

                    for (int i = 0; i < gdvRecInstructionDetail.RowCount; i++)
                    {
                        DataRow data = gdvRecInstructionDetail.GetDataRow(i);
                        if (Convert.ToInt32(data[eReceivingInstructionDetail.LineNo.ToString()]) > deletedLine)
                        {
                            row[eReceivingInstructionDetail.SortedLineNo.ToString()] = Convert.ToInt32(row[eReceivingInstructionDetail.SortedLineNo.ToString()]) - 1;
                        }
                    }
                    gdvRecInstructionDetail.RefreshData();

                    if (isAutoPalletRef)
                    {
                        txtPalletRef.EditValue = gdvRecInstructionDetail.RowCount + 1;
                    }
                }
                else
                {
                    MessageDialog.ShowBusinessErrorMsg(this, string.Format(Rubix.Screen.Common.GetMessage("I0254"), BusinessClass.ReceivingNo + " line " + deletedLine));
                }
            }
        }

        private void SetTransportCharge()
        {
            txtUnstaffingCharge.EditValue = TransportDialog.TransDetail.Compute("SUM(UnstaffingCharge)", "");
            txtTransportCharge.EditValue = TransportDialog.TransDetail.Compute("SUM(TransportCharge)", "");
        }

        private void SetOtherCharge()
        {
            txtOtherCharge.EditValue = OtherChargeDialog.OtherDetail.Compute("SUM(OtherCharge)", "");
        }
        
        private void ShowQtyLevel1()
        {
            bool canShow = BusinessClass.CanShowQtyLevel1();
            grdBandQtyLv1.Visible = canShow;
            grdBandQtyLv1.OptionsBand.ShowInCustomizationForm = canShow;
        }
 
        private void LoadUnitOfMeasure()
        {
            int? unitID = DataUtil.Convert<int>(cboQtyUnit.EditValue);
            if (itemControl.ProductID.HasValue && unitID.HasValue)
            {
                grdUnit.DataSource = BusinessClass.GetUnitOfMeasure(unitID.Value, itemControl.ProductID.Value);
                grdUnit.RefreshDataSource();
                if (gdvUnit.RowCount > 0)
                {
                    UpdateUnitOfMeasure(gdvUnit.GetDataRow(0));
                }
            }
        }

        private void UpdateUnitOfMeasure(DataRow data)
        {
            decimal? qty = DataUtil.Convert<decimal>(txtQty.EditValue);
            if (qty.HasValue && qty.Value > 0)
            {
                data["QtyLvl1"] = DataUtil.Convert<decimal>(data["UnitRatioToLvl1"]) * qty.Value;
                data["QtyLvl2"] = DataUtil.Convert<decimal>(data["UnitRatioToLvl2"]) * qty.Value;
                data["QtyLvl3"] = DataUtil.Convert<decimal>(data["UnitRatioToLvl3"]) * qty.Value;
                data["QtyLvl4"] = DataUtil.Convert<decimal>(data["UnitRatioToLvl4"]) * qty.Value;
                ControlUtil.SetBestWidth(gdvUnit);
            }
        }
        
        #endregion                     


    }
}
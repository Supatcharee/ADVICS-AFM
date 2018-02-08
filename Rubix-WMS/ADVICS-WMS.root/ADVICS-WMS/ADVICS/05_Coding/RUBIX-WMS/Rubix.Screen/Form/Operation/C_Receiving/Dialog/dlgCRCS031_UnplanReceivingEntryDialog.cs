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
namespace Rubix.Screen.Form.Operation.C_Receiving.Dialog
{
    public partial class dlgCRCS031_UnplanReceivingEntryDialog : DialogBase
    {        
        #region Member
        private B_ReceivingEntry.Dialog.dlgBRES011_TransportDetail m_TransDialog = null;
        private B_ReceivingEntry.Dialog.dlgBRES012_OtherCharge m_ChargeDialog = null;
        private ReceivingEntry db;
        private ProductReceiveEntry db1;
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
        private B_ReceivingEntry.Dialog.dlgBRES011_TransportDetail TransportDialog
        {
            get
            {
                if (m_TransDialog == null)
                {
                    return m_TransDialog = new B_ReceivingEntry.Dialog.dlgBRES011_TransportDetail();
                }
                return m_TransDialog;
            }
        }
        private B_ReceivingEntry.Dialog.dlgBRES012_OtherCharge OtherChargeDialog
        {
            get
            {
                if (m_ChargeDialog == null)
                {
                    return m_ChargeDialog = new B_ReceivingEntry.Dialog.dlgBRES012_OtherCharge();
                }
                return m_ChargeDialog;
            }
        }
        public Common.eScreenMode ScreenMode{get;set;}
        public string ReceivingNo{get;set;}
        public int Installment{get;set;}
        public int OwnerID { get; set; }
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
        public ProductReceiveEntry BusinessClassProductReceivingEntry
        {
            get
            {
                if (db1 == null)
                    db1 = new ProductReceiveEntry();
                return db1;
            }
            set
            {
                db1 = value;
            }
        }
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
        public dlgCRCS031_UnplanReceivingEntryDialog()
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
                //add by pichaya s. 20130625
                if (this.ScreenMode == Common.eScreenMode.Edit)
                {
                    if (!iv.ValidateTicket(this.ReceivingNo, this.Installment.ToString()))
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
                            result = BusinessClass.SaveChanges(ReceivingDetail, TransportDialog.TransDetail, OtherChargeDialog.OtherDetail, _filePath);
                        }
                        if (result)
                        {
                            _filePath.Clear();
                            //Receiving Instrunction status
                            StoringInstruction st = new StoringInstruction();
                            st.PrepareTransit(BusinessClass.ReceivingNo, this.Installment, Convert.ToInt32(ownerControl.OwnerID), AppConfig.UserLogin);
                            st = null;

                            //Confirm Receiving
                            ProductReceiveEntry pr = new ProductReceiveEntry();

                            #region "GenXML"
                            string XML_TEMPLATE = "<Tab xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">{0}</Tab>";
                            string REC_TEMPLATE = "<Rec>{0}</Rec>";
                            string LINE_NO_TEMPLATE = "<LineNo><![CDATA[{0}]]></LineNo>";
                            string RECEIVE_QTY_TEMPLATE = "<ReceiveQty><![CDATA[{0}]]></ReceiveQty>";
                            string LOT_NO_TEMPLATE = "<LotNo><![CDATA[{0}]]></LotNo>";
                            string CONDITION_TEMPLATE = "<Condition><![CDATA[{0}]]></Condition>";
                            string EXPIRED_DATE_TEMPLATE = "<ExpDate><![CDATA[{0}]]></ExpDate>";
                            string EXPIRED_DATE_NULL_TEMPLATE = "<ExpDate xsi:nil=\"true\" />";
                            //string NEW_LINE_TEMPLATE = "<NewLine>{0}</NewLine>";

                            StringBuilder record = new StringBuilder();
                            foreach (DataRow dr in ReceivingDetail.Rows)
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append(string.Format(LINE_NO_TEMPLATE, dr[eReceivingInstructionDetail.LineNo.ToString()]));
                                sb.Append(string.Format(RECEIVE_QTY_TEMPLATE, dr[eReceivingInstructionDetail.Qty.ToString()]));
                                sb.Append(string.Format(LOT_NO_TEMPLATE, dr[eReceivingInstructionDetail.LotNo.ToString()]));
                                sb.Append(string.Format(CONDITION_TEMPLATE, dr[eReceivingInstructionDetail.ProductConditionID.ToString()]));

                                if (string.IsNullOrEmpty(dr[eReceivingInstructionDetail.ExpiredDate.ToString()].ToString()))
                                {
                                    sb.Append(EXPIRED_DATE_NULL_TEMPLATE);
                                }
                                else
                                {
                                    sb.Append(string.Format(EXPIRED_DATE_TEMPLATE, dr[eReceivingInstructionDetail.ExpiredDate.ToString()]));
                                }

                                record.AppendLine(string.Format(REC_TEMPLATE, sb.ToString()));
                            }
                            #endregion
                            
                            pr.SaveDetail(BusinessClass.ReceivingNo, dtArrivalDate.DateTime, DataUtil.Convert<int>(txtNoOfPallet.Text), false, string.Format(XML_TEMPLATE, record.ToString()), BusinessClass.Installment);
                            
                            DialogResult = DialogResult.OK;
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
            dlgCRCS031_UnplanReceivingEntryDialog_Load(this, new EventArgs());
            return base.OnCommandClear();
        }
        #endregion

        #region Event Handler Function
        private void dlgCRCS031_UnplanReceivingEntryDialog_Load(object sender, EventArgs e)
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
                    btnAdd.Enabled = ownerControl.OwnerID != null;
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
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
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
            txtAddress1.Text = supplierControl.SupplierAddress1;
            txtAddress2.Text = supplierControl.SupplierAddress2;
            txtPostalCode.Text = supplierControl.PostalCode;
        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
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
                btnAdd.Enabled = ownerControl.OwnerID != null;
                btnUpdate.Enabled = ownerControl.OwnerID != null;
                btnOK.Enabled = ownerControl.OwnerID != null;
                btnCancel.Enabled = btnOK.Enabled;
                btnDelete.Enabled = ownerControl.OwnerID != null;
                btnOtherCharge.Enabled = true;
                btnTransportDetail.Enabled = true;
                BusinessClass.OwnerID = ownerControl.OwnerID.Value;
            }
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
                        DataRow unit = gdvUnit.GetDataRow(0);
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

                    if (Convert.ToInt32(dr["StatusID"]) == 1
                        || Convert.ToInt32(dr["StatusID"]) == 2
                        || Convert.ToInt32(dr["StatusID"]) == 3
                        || Convert.ToInt32(dr["StatusID"]) == 4)
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
                    else if (Convert.ToInt32(dr["StatusID"]) == 5 || Convert.ToInt32(dr["StatusID"]) == 6)
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
                        DataRow unit = gdvUnit.GetDataRow(0);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                    ToggleMode();
                    
                    ControlUtil.ClearControlData(grpEditDetail.Controls);
                    itemConditionControl.ProductConditionCode = "NM";
                    isAutoPalletRef = true;
                    txtPalletRef.EditValue = gdvRecInstructionDetail.RowCount + 1;
                
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
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
            txtNoOfPallet.EditValue = BusinessClass.PalletQty;
            txtRemark.Text = BusinessClass.Remark;

            m_statusBarCreatedDate.Caption = BusinessClass.CreateDate.Value.ToString(Rubix.Screen.Common.FullDatetimeFormat);
            m_statusBarCreatedUser.Caption = BusinessClass.CreateUser;
            if (BusinessClass.UpdateDate.HasValue)
            {
                m_statusBarUpdatedDate.Caption = BusinessClass.UpdateDate.Value.ToString(Rubix.Screen.Common.FullDatetimeFormat);
            }
            else
            {
                m_statusBarUpdatedDate.Caption = "-";
            }
            if (String.IsNullOrWhiteSpace(BusinessClass.UpdateUser))
            {
                m_statusBarUpdatedUser.Caption = "-";
            }
            else
            {
                m_statusBarUpdatedUser.Caption = BusinessClass.UpdateUser;
            }
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
            BusinessClass.PalletQty = Convert.ToInt32(txtNoOfPallet.Text);
        }

        private void ToggleMode()
        {
            btnAdd.Visible = btnOK.Visible;
            btnDelete.Visible = btnOK.Visible;
            btnUpdate.Visible = btnOK.Visible;
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

            if (this.ReceivingDetail.Rows.Count <= 0)
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

            if (string.IsNullOrWhiteSpace(txtLotNo.Text))
            {
                errorProvider.SetError(txtLotNo, Common.GetMessage("I0314"));
                isOK = false;
            }

            itemConditionControl.ErrorText = Common.GetMessage("I0026");
            itemConditionControl.RequireField = true;
            if (!itemConditionControl.ValidateControl())
            {
                errorProvider.SetError(itemConditionControl, Rubix.Screen.Common.GetMessage("I0026"));
                isOK = false;
            }

            int? pck = DataUtil.Convert<int>(cboTypeOfPackage.EditValue);
            if (!pck.HasValue)
            {
                errorProvider.SetError(cboTypeOfPackage, Common.GetMessage("I0182"));
                isOK = false;
            }

            if (string.IsNullOrWhiteSpace(txtQty.Text))
            {
                errorProvider.SetError(txtQty, Common.GetMessage("I0298"));
                isOK = false;
            }

            if (Convert.ToInt32(txtQty.EditValue) == 0)
            {
                errorProvider.SetError(txtQty, Common.GetMessage("I0298"));
                isOK = false;
            }

            if (!DataUtil.IsValidDecimal(txtQty.Text, 18, 3))
            {
                errorProvider.SetError(txtQty, Common.GetMessage("I0277"));
                isOK = false;
            }

            if (string.IsNullOrWhiteSpace(txtPalletRef.Text))
            {
                errorProvider.SetError(txtPalletRef, Common.GetMessage("I0299"));
                isOK = false;
            }

            return isOK;
        }

        private void InitControl()
        {
            // 17 Jan 2013: add for show qty level1 
            ShowQtyLevel1();
            //end 17 Jan 2013

            ControlUtil.ClearControlData(this.Controls);
            ControlUtil.HiddenControl(false, btnAdd, btnDelete, btnUpdate, btnOK,btnCancel);

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
                ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
                ControlUtil.EnableControl(false, this.Controls);
                ControlUtil.EnableControl(true, btnTransportDetail, btnOtherCharge);
            }
            else 
            {
                txtNoOfPallet.EditValue = 0;
                //not allow to edit
                ownerControl.EnableControl = (this.ScreenMode == Common.eScreenMode.Add);
                warehouseControl.EnableControl = (ownerControl.OwnerID != null);
                supplierControl.EnableControl = (ownerControl.OwnerID != null);

                ControlUtil.EnableControl(true, dtArrivalDate, deExpiredDate, txtArrivalTime, txtRemark, btnAttachCOA);
                ControlUtil.EnableControl((this.ScreenMode != Common.eScreenMode.Add), btnOtherCharge, btnTransportDetail);

                //detail
                ControlUtil.EnableControl(true, txtReferenceNo, txtPONo, txtQty, txtLotNo, txtInvoiceNo, txtDetailRemark, txtPalletRef, cboQtyUnit, itemConditionControl, itemControl);
                ControlUtil.EnableControl((ownerControl.OwnerID != null), btnDelete, btnUpdate, btnAdd);

                ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);

                //Binding Statusbar
                m_statusBarCreatedDate.Caption = AppConfig.UserLogin;
                m_statusBarCreatedUser.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarUpdatedDate.Caption = "-";
                m_statusBarUpdatedUser.Caption = "-";
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

            data[eReceivingInstructionDetail.LotNo.ToString()] = txtLotNo.Text;
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
                data[eReceivingInstructionDetail.InPackageUnitID.ToString()] = Convert.ToInt32(cboInPackageUnit.EditValue);
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

        private void SetOtherCharge()
        {
            txtOtherCharge.EditValue = OtherChargeDialog.OtherDetail.Compute("SUM(OtherCharge)", "");
        }
        
        private void SetTransportCharge()
        {
            txtUnstaffingCharge.EditValue = TransportDialog.TransDetail.Compute("SUM(UnstaffingCharge)", "");
            txtTransportCharge.EditValue = TransportDialog.TransDetail.Compute("SUM(TransportCharge)", "");
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
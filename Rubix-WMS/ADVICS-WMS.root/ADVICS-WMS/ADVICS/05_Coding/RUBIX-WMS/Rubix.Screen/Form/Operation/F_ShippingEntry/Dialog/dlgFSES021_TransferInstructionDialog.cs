using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using CSI.Business.Operation;
using CSI.Business.DataObjects;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using System.Linq;
using System.Transactions;
using CSI.Business.Common;

namespace Rubix.Screen.Form.Operation.F_ShippingEntry.Dialog
{
    public partial class dlgFSES021_TransferInstructionDialog : DialogBase
    {

        #region Member
        private ShippingInstruction db;
        private Common.eScreenMode eScrenMode;
        public decimal otherCharge = 0;
        private Dialog.dlgFSES012_TransportDetail m_TransDialog = null;
        private Dialog.dlgFSES013_OtherCharge m_ChargeDialog = null;
        public decimal transCharge = 0;
        public decimal outgoingCharge = 0;
        private DataTable _detail = null;
        private List<sp_Common_ProductUnit_Result> qtyUnitList;
        public bool chkDetailUpdate = false;
        private bool isUpdateDetailMode = false;
        private string outShipmentNo;
        private string outPickingNo;


        #endregion

        #region Enumeration
        private enum eColUnit
        {
            VolumnOfUnitLevel1
              ,
            QtyLvl1 // 18 Jan 2013: add for support show qty lv1
                ,
            TypeOfUnitLevel1
                ,
            UnitCode1
                ,
            QtyLvl2
                ,
            UnitRatioToLvl2
                ,
            TypeOfUnitLevel2
                ,
            UnitCode2
                ,
            QtyLvl3
                ,
            UnitRatioToLvl3
                ,
            TypeOfUnitToLevel3
                ,
            UnitCode3
                ,
            QtyLvl4
                ,
            UnitRatioToLvl4
                ,
            TypeOfUnitToLevel4
                , UnitCode4
        }
        private enum eColImport
        {
            LineNo = 1,
            PoNo,
            ProductCode,
            LotNo,
            OrderQty,
            UnitOfQty,
            ItemConditionCode,
            DetailRemark

        }


        #endregion

        #region Properties
        public ShippingInstruction BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ShippingInstruction();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new ShippingInstruction();
                }
                db = value;
            }
        }
        public Common.eScreenMode ScreenMode
        {
            get { return eScrenMode; }
            set { eScrenMode = value; }
        }

        private Dialog.dlgFSES012_TransportDetail TransportDialog
        {
            get
            {
                if (m_TransDialog == null)
                {
                    return m_TransDialog = new Dialog.dlgFSES012_TransportDetail();
                }
                return m_TransDialog;
            }
        }
        private Dialog.dlgFSES013_OtherCharge OtherChargeDialog
        {
            get
            {
                if (m_ChargeDialog == null)
                {
                    return m_ChargeDialog = new Dialog.dlgFSES013_OtherCharge();
                }
                return m_ChargeDialog;
            }
        }

        private List<sp_FSES012_TransportDetail_Search_Result> TransportChargeList
        {
            get;
            set;
        }
        private List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result> OtherChargeList
        {
            get;
            set;
        }

        public DataRow TransferInstrunctionHeader { get; set; }
        #endregion

        #region Constructor
        public dlgFSES021_TransferInstructionDialog()
        {
            InitializeComponent();

            CSI.Business.Common.Packaging package = new CSI.Business.Common.Packaging();
            cboTypeOfPackage.Properties.DataSource = package.DataLoading();
            cboTypeOfPackage.Properties.DisplayMember = "PackageName";
            cboTypeOfPackage.Properties.ValueMember = "PackageID";

            CSI.Business.Master.TypeOfUnit unit = new CSI.Business.Master.TypeOfUnit();
            cboUnitOfInPackage.Properties.DataSource = unit.DataLoading(string.Empty, string.Empty);
            cboUnitOfInPackage.Properties.DisplayMember = "UnitName";
            cboUnitOfInPackage.Properties.ValueMember = "UnitID";

            cboUnitInventory.Properties.DataSource = unit.DataLoading(string.Empty, string.Empty);
            cboUnitInventory.Properties.DisplayMember = "UnitCode";
            cboUnitInventory.Properties.ValueMember = "UnitID";

            repUnitOfInventory.DataSource = unit.DataLoading(string.Empty, string.Empty);
            repUnitOfInventory.DisplayMember = "UnitCode";
            repUnitOfInventory.ValueMember = "UnitID";

            repUnitOfQty.DataSource = unit.DataLoading(string.Empty, string.Empty);
            repUnitOfQty.DisplayMember = "UnitCode";
            repUnitOfQty.ValueMember = "UnitID";

            repTypeOfPackage1.DataSource = package.DataLoading();
            repTypeOfPackage1.DisplayMember = "PackageName";
            repTypeOfPackage1.ValueMember = "PackageID";

            repUnitOfPackage.DataSource = unit.DataLoading(string.Empty, string.Empty);
            repUnitOfPackage.DisplayMember = "UnitName";
            repUnitOfPackage.ValueMember = "UnitID";

            InitControl();

            datePicking.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            datePicking.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            datePicking.Properties.EditFormat.FormatString = Common.FullDateFormat;
            datePicking.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            datePicking.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            datePicking.Properties.Mask.EditMask = Common.FullDateFormat;

            dateVanning.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dateVanning.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dateVanning.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dateVanning.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dateVanning.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dateVanning.Properties.Mask.EditMask = Common.FullDateFormat;

            dateTrans.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dateTrans.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dateTrans.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dateTrans.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dateTrans.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dateTrans.Properties.Mask.EditMask = Common.FullDateFormat;

            ETADestination.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            ETADestination.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ETADestination.Properties.EditFormat.FormatString = Common.FullDateFormat;
            ETADestination.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ETADestination.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            ETADestination.Properties.Mask.EditMask = Common.FullDateFormat;

            ETDPort.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            ETDPort.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ETDPort.Properties.EditFormat.FormatString = Common.FullDateFormat;
            ETDPort.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            ETDPort.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            ETDPort.Properties.Mask.EditMask = Common.FullDateFormat;

            dateCut.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dateCut.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dateCut.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dateCut.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dateCut.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dateCut.Properties.Mask.EditMask = Common.FullDateFormat;

            dateExpiry.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dateExpiry.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dateExpiry.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dateExpiry.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dateExpiry.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dateExpiry.Properties.Mask.EditMask = Common.FullDateFormat;

            colInventory.DisplayFormat.FormatString = Common.QtyFormat;
            colInventory.DisplayFormat.FormatType = FormatType.Custom;

            colInPackage.DisplayFormat.FormatString = Common.QtyFormat;
            colInPackage.DisplayFormat.FormatType = FormatType.Custom;

            txtQty.Properties.DisplayFormat.FormatString = Common.QtyFormat;
            txtQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtQty.Properties.EditFormat.FormatString = Common.QtyFormat;
            txtQty.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtQty.Properties.Mask.EditMask = Common.QtyFormat;

            txtInPackage.Properties.DisplayFormat.FormatString = Common.QtyFormat;
            txtInPackage.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtInPackage.Properties.EditFormat.FormatString = Common.QtyFormat;
            txtInPackage.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtInPackage.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtInPackage.Properties.Mask.EditMask = Common.QtyFormat;

            txtInventory.Properties.DisplayFormat.FormatString = Common.QtyFormat;
            txtInventory.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtInventory.Properties.EditFormat.FormatString = Common.QtyFormat;
            txtInventory.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtInventory.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtInventory.Properties.Mask.EditMask = Common.QtyFormat;

            txtTransCharge.Properties.DisplayFormat.FormatString = Common.AmountFormat;
            txtTransCharge.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtTransCharge.Properties.EditFormat.FormatString = Common.AmountFormat;
            txtTransCharge.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtTransCharge.Properties.Mask.EditMask = Common.AmountFormat;
            txtTransCharge.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

            txtOutgoingCharge.Properties.DisplayFormat.FormatString = Common.AmountFormat;
            txtOutgoingCharge.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtOutgoingCharge.Properties.EditFormat.FormatString = Common.AmountFormat;
            txtOutgoingCharge.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtOutgoingCharge.Properties.Mask.EditMask = Common.AmountFormat;
            txtOutgoingCharge.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

            txtOtherCharge.Properties.DisplayFormat.FormatString = Common.AmountFormat;
            txtOtherCharge.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtOtherCharge.Properties.EditFormat.FormatString = Common.AmountFormat;
            txtOtherCharge.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtOtherCharge.Properties.Mask.EditMask = Common.AmountFormat;
            txtOtherCharge.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;

            itemConditionControl.EnableControl = false;

            //m_toolBarClear.Enabled = true;
            //m_toolBarClose.Enabled = true;
            //m_toolBarSave.Enabled = true;
        }
        #endregion

        #region Event Handler Function
        private void dlgFSES021_TransferInstructionDialog_Load(object sender, EventArgs e)
        {
            try
            {
                ShowQtyLevel1();

                lotControl.ClearData();
                itemControl.ClearData();
                shippingAreaControl.ClearData();
                itemConditionControl.ClearData();
                ControlUtil.ClearControlData(this.Controls);
                errorProvider.ClearErrors();

                cboQtyUnit.EditValue = null;
                cboUnitOfInPackage.EditValue = null;
                cboTypeOfPackage.EditValue = null;
                cboUnitInventory.EditValue = null;
                txtQty.EditValue = null;
                txtReferenceNo.EditValue = null;
                txtRemark.EditValue = null;
                dateExpiry.EditValue = null;

                btnAdd.Visible = true;
                btnDelete.Visible = true;
                btnImport.Visible = true;
                btnOK.Visible = false;
                btnCancel.Visible = btnOK.Visible;
                if (ScreenMode == Common.eScreenMode.View)
                {
                    ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
                    ControlUtil.EnableControl(false, Controls);
                    ControlUtil.EnableControl(true, btnTransportDetail, btnOtherCharge);


                }
                else
                {
                    ownerControl.EnableControl = true;
                    warehouseControl.EnableControl = true;
                    ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);
                }

                if (ScreenMode == Common.eScreenMode.Add)
                {
                    m_statusBarCreatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                    m_statusBarCreatedUser.Caption = AppConfig.UserLogin;
                    m_statusBarUpdatedDate.Caption = "-";
                    m_statusBarUpdatedUser.Caption = "-";

                    ControlUtil.EnableControl(false, txtPickingNo, cboUnitOfInPackage, cboUnitInventory, txtShippingStatus, txtReceivingStatus, txtReceivingNo, cboTypeOfPackage, txtInventory, txtInPackage, txtQty, cboQtyUnit);
                    itemConditionControl.EnableControl = false;
                    itemControl.EnableControl = false;
                    lotControl.EnableControl = false;

                    txtOtherCharge.EditValue = 0;
                    txtTransCharge.EditValue = 0;
                    txtOutgoingCharge.EditValue = 0;

                    LoadDetail(); //Load grid detail

                }
                else
                {
                    DataBinding(); //Load Header
                    ControlUtil.EnableControl(false, ownerControl, txtShippingStatus, warehouseControl, shipmentControl, txtPickingNo, finalDestinationControl, txtFinalAddress, txtReceivingStatus, warehouseControl2, txtReceivingNo);
                    LoadDetail(); //Load grid detail
                    LoadTransportChargeInfo(); //load grid transport
                    LoadOtherChargeInfo(); //load grid other charge
                    loadTransportCharge(); //bind data to textbox
                    loadOtherCharge(); //bind data to textbox
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnOtherCharge_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                OtherChargeDialog.BusinessClass = this.BusinessClass;
                OtherChargeDialog.OtherChargeList = DataUtil.Clone<List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result>>(OtherChargeList);
                OtherChargeDialog.ScreenMode = ScreenMode;
                if (OtherChargeDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    txtOtherCharge.EditValue = OtherChargeDialog.sumOtherCharge;
                    OtherChargeList = OtherChargeDialog.OtherChargeList;
                }
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void btnTransportDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateTransportCharge())
                {
                    this.Enabled = false;
                    BusinessClass.OwnerID = ownerControl.OwnerID.Value;
                    BusinessClass.WarehouseID = warehouseControl.WarehouseID.Value;
                    BusinessClass.FinalDestinationID = finalDestinationControl.FinalDestinationID.Value;
                    TransportDialog.BusinessClass = this.BusinessClass;
                    TransportDialog.TransportChargeList = DataUtil.Clone<List<sp_FSES012_TransportDetail_Search_Result>>(TransportChargeList); //TransportChargeList;
                    TransportDialog.ScreenMode = this.ScreenMode;
                    if (TransportDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        decimal sumOutgoingCharge = TransportDialog.sumOutgoingCharge;
                        decimal sumTransportCharge = TransportDialog.sumTransportCharge;
                        TransportChargeList = TransportDialog.TransportChargeList;
                        //decimal unstaffingTotal = 0, transportCharge = 0;
                        //foreach (tbt_ReceivingTransportation charge in this.RcvHeader.tbt_ReceivingTransportation)
                        //{
                        //    unstaffingTotal += charge.UnstaffingCharge;
                        //    transportCharge += charge.TransportCharge;
                        //}

                        txtTransCharge.EditValue = sumTransportCharge;
                        txtOutgoingCharge.EditValue = sumOutgoingCharge;
                    }
                    this.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }


        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {


            itemControl.OwnerID = ownerControl.OwnerID;
            itemControl.DataLoading();

            shipmentControl.OwnerID = ownerControl.OwnerID;
            shipmentControl.DataLoading();

            warehouseControl.OwnerID = ownerControl.OwnerID;
            warehouseControl.DataLoading();



            if (this.ScreenMode != Common.eScreenMode.View && ownerControl.OwnerID != null)
            {
                ownerControl.EnableControl = false;
                itemControl.Enabled = ownerControl.OwnerID != null;
                btnImport.Enabled = ownerControl.OwnerID != null;
                btnOtherCharge.Enabled = true;
                btnTransportDetail.Enabled = true;
                shipmentControl.Enabled = ownerControl.OwnerID != null;
                warehouseControl.Enabled = ownerControl.OwnerID != null;

                //2013-11-26 By Porntip 
                itemControl.EnableControl = true;
                lotControl.EnableControl = true;
                ControlUtil.EnableControl(true, txtQty);

                //grdShippingInstruction.DataSource = null;

            }


        }

        private void productControl_EditValueChanged(object sender, EventArgs e)
        {
            if (itemControl.ProductID.HasValue)
            {
                lotControl.ClearData();
                ControlUtil.ClearControlData(txtInventory);
                ////////////////////////set lot control//////////////////////////
                cboUnitInventory.EditValue = null;
                itemConditionControl.ClearData();
                lotControl.ProductID = itemControl.ProductID;
                if (lotControl.ProductID.HasValue)
                {
                    lotControl.DataLoading();
                    lotControl.SelectFirst();
                    txtInventory.EditValue = lotControl.GetInventory;
                    cboUnitInventory.EditValue = lotControl.GetUnitID;
                    itemConditionControl.ProductConditionID = lotControl.ProductConditionID;
                    cboQtyUnit.EditValue = lotControl.GetUnitID;
                }


                /////////////////////////////////////////////////////////////////
                //    getCustomerOrder(itemControl.ProductID.Value);
                sp_FSES010_ShippingInstruction_LoadProductUnitInfo_Result prodInfo = BusinessClass.LoadProductUnitInfo(itemControl.ProductID.Value);
                if (prodInfo != null)
                {

                    txtInPackage.EditValue = prodInfo.NumberOfUnitLevel2;
                    cboUnitOfInPackage.EditValue = prodInfo.TypeOfUnitLevel2;
                    cboTypeOfPackage.EditValue = prodInfo.PackageID;
                    //txtInventory.EditValue = prodInfo.Inventory;
                    //cboUnitInventory.EditValue = prodInfo.TypeOfUnitInventory;
                    cboQtyUnit.EditValue = prodInfo.TypeOfUnitLevel2;
                    /////gen cboQtyUnit
                    genQtyUnitcbo(prodInfo.TypeOfUnitLevel2);
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdvShippingInstruction.GetFocusedRow() != null)
                {
                    DeleteDetail();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateDetail(gdvShippingInstruction.GetFocusedDataRow()["SortedLineNo"].ToString()))
                {
                    btnAdd.Visible = true;
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnImport.Visible = true;
                    btnAddByLot.Visible = true;
                    btnOK.Visible = false;
                    btnCancel.Visible = btnOK.Visible;
                    grdShippingInstruction.Enabled = true;

                    SetDetail(gdvShippingInstruction.GetFocusedDataRow());

                    clearDetailControl();
                    m_toolBarClear.Enabled = true;
                    m_toolBarClose.Enabled = true;
                    m_toolBarSave.Enabled = true;

                    // 22 Jan 2013: add for set value to be false
                    isUpdateDetailMode = false;
                    // end 22 Jan 2013
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                    btnAdd.Visible = true;
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnImport.Visible = true;
                    btnAddByLot.Visible = true;
                    btnOK.Visible = false;
                    btnCancel.Visible = btnOK.Visible;
                    grdShippingInstruction.Enabled = true;

                    clearDetailControl();
                    m_toolBarClear.Enabled = true;
                    m_toolBarClose.Enabled = true;
                    m_toolBarSave.Enabled = true;

                    // 22 Jan 2013: add for set value to be false
                    isUpdateDetailMode = false;
                    // end 22 Jan 2013
                
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdvShippingInstruction.RowCount > 0 && gdvShippingInstruction.GetFocusedRow() != null)
                {
                    DataRow dr = gdvShippingInstruction.GetFocusedDataRow();
                    btnAdd.Visible = false;
                    btnDelete.Visible = false;
                    btnImport.Visible = false;
                    btnUpdate.Visible = false;
                    btnAddByLot.Visible = false;
                    btnOK.Visible = true;
                    btnCancel.Visible = btnOK.Visible;
                    grdShippingInstruction.Enabled = false;
                    chkDetailUpdate = true;
                    m_toolBarClear.Enabled = false;
                    m_toolBarClose.Enabled = false;
                    m_toolBarSave.Enabled = false;

                    txtQty.EditValue = Convert.ToDecimal(dr["OrderQty"]);
                    itemControl.ProductID = Convert.ToInt32(dr["ProductID"]);
                    lotControl.setLotNoControl(dr["ReceivingNo"].ToString(), Convert.ToInt32(dr["RecInstallment"]), Convert.ToInt32(dr["RecLineNo"]), Convert.ToInt32(dr["ProductConditionID"]));
                    itemConditionControl.ProductConditionID = Convert.ToInt32(dr["ProductConditionID"]);

                    txtReferenceNo.EditValue = dr["ReferenceNo"].ToString();

                    if (!string.IsNullOrEmpty(dr["ExpiryDate"].ToString()))
                    {
                        dateExpiry.EditValue = Convert.ToDateTime(dr["ExpiryDate"]);
                    }

                    cboQtyUnit.EditValue = Convert.ToInt32(dr["UnitOfQty"]);
                    //txtInventory.EditValue = Convert.ToDecimal(dr["Inventory"]);
                    cboUnitInventory.EditValue = Convert.ToInt32(dr["UnitOfInventory"]);

                    cboTypeOfPackage.EditValue = Convert.ToInt32(dr["TypeOfPackage"]);
                    txtInPackage.EditValue = Convert.ToDecimal(dr["InPackage"]);
                    cboUnitOfInPackage.EditValue = Convert.ToInt32(dr["UnitOfInPackage"]);

                    txtRemark.EditValue = dr["DetailRemark"].ToString();

                    // 22 Jan 2013: add for set value (set false when click OK or ending edit)
                    isUpdateDetailMode = true;
                    // end 22 Jan 2013
                }
                chkDetailUpdate = false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateDetail(string.Empty))
                {
                    DataRow dr = _detail.NewRow();
                    SetDetail(dr);
                    dr["LineNo"] = this._detail.Rows.Count + 1;
                    dr["SortedLineNo"] = dr["LineNo"];
                    _detail.Rows.Add(dr);
                    _detail.AcceptChanges();
                    ControlUtil.SetBestWidth(gdvShippingInstruction);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnAddByLot_Click(object sender, EventArgs e)
        {
            bool isError = false;
            if (!ownerControl.ValidateControl())
            {
                isError = true;
            }
            if (!warehouseControl.ValidateControl())
            {
                isError = true;
            }
            itemControl.RequireField = true;
            if (!itemControl.ValidateControl())
            {
                isError = true;
            }
            if (cboQtyUnit.EditValue == null)
            {
                isError = true;
            }
            if (isError)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0173"));
                return;
            }

            dlgFSES014_ShippingByLot dialog = new dlgFSES014_ShippingByLot();
            dialog.ProductID = itemControl.ProductID;
            dialog.WarehouseID = warehouseControl.WarehouseID;
            if (dialog.ShowDialog(this.Parent) == System.Windows.Forms.DialogResult.OK)
            {
                int line;
                if (gdvShippingInstruction.RowCount <= 0)
                {
                    line = 1;
                }
                else
                {
                    line = this._detail.Rows.Count;
                }
                int sortedLine = gdvShippingInstruction.RowCount + 1;

                sp_FSES010_ShippingInstruction_LoadProductUnitInfo_Result prodInfo = BusinessClass.LoadProductUnitInfo(dialog.ProductID.Value);

                List<sp_FSES011_ShippingInstruction_SearchDetail_Result> lstDetail = new List<sp_FSES011_ShippingInstruction_SearchDetail_Result>();

                foreach (sp_FSES013_ShippingByLot_Search_Result data in dialog.Result)
                {
                    sp_FSES011_ShippingInstruction_SearchDetail_Result detail = new sp_FSES011_ShippingInstruction_SearchDetail_Result();

                    DataRow dr = _detail.NewRow();
                    dr["LineNo"] = this._detail.Rows.Count + 1;
                    dr["SortedLineNo"] = dr["LineNo"];
                    dr["ProductCode"] = itemControl.ProductCode;
                    dr["ProductID"] = dialog.ProductID;
                    dr["ProductLongName"] = itemControl.ProductLongName;
                    dr["LotNo"] = data.LotNo;
                    dr["OrderQty"] = data.ShippingQty;
                    dr["UnitOfQty"] = data.UnitID;
                    dr["Inventory"] = data.Inventory;
                    dr["UnitOfInventory"] = data.UnitID;
                    dr["TypeOfPackage"] = prodInfo.PackageID;
                    dr["InPackage"] = prodInfo.NumberOfUnitLevel2;
                    dr["UnitOfInPackage"] = prodInfo.TypeOfUnitLevel2;
                    dr["Measurement"] = prodInfo.M3;
                    dr["ReferenceNo"] = null;
                    dr["DetailRemark"] = string.Empty;
                    dr["ShipingPalletNo"] = "";
                    dr["ReceivingPalletNo"] = "";
                    dr["ProductConditionID"] = data.ProductConditionID;
                    dr["ReceivingNo"] = data.ReceivingNo;
                    dr["RecInstallment"] = data.RecInstallment;
                    dr["RecLineNo"] = data.RecLineNo;

                    _detail.Rows.Add(dr);
                    _detail.AcceptChanges();

                }

                btnAdd.Visible = true;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnImport.Visible = true;
                btnAddByLot.Visible = true;
                btnOK.Visible = false;
                btnCancel.Visible = btnOK.Visible;
                grdShippingInstruction.Enabled = true;

                clearDetailControl();
                m_toolBarClear.Enabled = true;
                m_toolBarClose.Enabled = true;
                m_toolBarSave.Enabled = true;

                // 22 Jan 2013: add for set value to be false
                isUpdateDetailMode = false;
                gdvShippingInstruction.RefreshData();
            }
            ControlUtil.SetBestWidth(gdvShippingInstruction);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string errorMsg = string.Empty;
            Rubix.Framework.ExcelManager excel = new ExcelManager();
            try
            {
                if (ownerControl.OwnerID == null)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0026"));
                }
                else
                {
                    if (ofdImport.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.ShowWaitScreen();

                        Packaging package = new Packaging();
                        ProductCondition condition = new ProductCondition();
                        Product product = new Product();
                        TypeOfUnit unit = new TypeOfUnit();

                        using (excel)
                        {
                            excel.OpenExcel(ofdImport.FileName);
                            //read header
                            int maxCol = 1, row = 1, lineNo = 1;
                            List<sp_FSES011_ShippingInstruction_SearchDetail_Result> lstDetail = new List<sp_FSES011_ShippingInstruction_SearchDetail_Result>();
                            while (!string.IsNullOrWhiteSpace(excel.ReadData(1, maxCol)))
                            {
                                maxCol++;
                            }
                            row++;
                            ////////////////////////////////////////////////////////////////
                            ///gen list for productCode and sum OrderQty from file import///
                            ///////////////////////////////////////////////////////////////
                            while (!string.IsNullOrWhiteSpace(excel.ReadData(row, (int)eColImport.ItemConditionCode)) || !string.IsNullOrWhiteSpace(excel.ReadData(row, (int)eColImport.OrderQty)))
                            {
                                string strItemCode = excel.ReadData(row, (int)eColImport.ProductCode).Trim();
                                string strLotNo = excel.ReadData(row, (int)eColImport.LotNo).Trim();
                                decimal? iOrderQty = Rubix.Framework.DataUtil.Convert<decimal>(excel.ReadData(row, (int)eColImport.OrderQty));
                                string strUnitOfQTY = excel.ReadData(row, (int)eColImport.UnitOfQty).Trim();
                                string strItemConditionCode = excel.ReadData(row, (int)eColImport.ItemConditionCode).Trim();
                                string strDetailRemark = excel.ReadData(row, (int)eColImport.DetailRemark).Trim();
                                string strPONO = excel.ReadData(row, (int)eColImport.PoNo).Trim();
                                
                                /////Validate Item Code
                                if (string.IsNullOrEmpty(strItemCode))
                                {
                                    //Product is null in row '{0}'
                                    errorMsg = Common.GetMessage("I0330", row.ToString());
                                    return;
                                }
                                tbm_Product productData = product.GetProductInfo(strItemCode, ownerControl.OwnerID);
                                if (productData == null)
                                {
                                    errorMsg = Common.GetMessage("I0279", "Item", strItemCode);
                                    return;
                                }
                                bool isProductExists = BusinessClass.IsProductExists(strItemCode, ownerControl.OwnerID.Value);
                                if (!isProductExists)
                                {
                                    errorMsg = Common.GetMessage("I0279", "Item", strItemCode);
                                    return;
                                }

                                /////Validate Order QTY
                                if (iOrderQty == null)
                                {
                                    errorMsg = Common.GetMessage("I0279", "Order Qty", strItemCode);
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

                                /////Validate LotNo
                                if (string.IsNullOrWhiteSpace(strLotNo))
                                {
                                    errorMsg = Common.GetMessage("I0279", "Lot No.", strLotNo);
                                    return;
                                }
                                lotControl.ProductID = productData.ProductID;
                                if (lotControl.ProductID.HasValue)
                                {
                                    lotControl.DataLoading();
                                    if (!lotControl.ValidateLotNo(strLotNo, conditionData.ProductConditionID))
                                    {
                                        errorMsg = Common.GetMessage("I0279", "Lot No.", strLotNo);
                                        return;
                                    }
                                }
                                else
                                {
                                    errorMsg = Common.GetMessage("I0279", "Lot No.", strLotNo);
                                    return;
                                }

                                /////Validate Unit of Qty
                                tbm_TypeOfUnit qtyUnit = unit.GetUnitInfo(strUnitOfQTY);
                                tbm_ProductDefaultUnit pdu = BusinessClass.GetProductDefaultUnit(productData.ProductID);

                                if (qtyUnit == null)
                                {
                                    errorMsg = Rubix.Screen.Common.GetMessage("I0279", "Type Of Unit", strUnitOfQTY);
                                    return;
                                }

                                if ((int)pdu.TypeOfUnitLevel2 != (int)qtyUnit.UnitID &&
                                    (int)pdu.TypeOfUnitLevel3 != (int)qtyUnit.UnitID &&
                                    (int)pdu.TypeOfUnitLevel4 != (int)qtyUnit.UnitID)
                                {
                                    errorMsg = Rubix.Screen.Common.GetMessage("I0279", "Type Of Unit", strUnitOfQTY);
                                    return;
                                }

                                ////Validate Remark
                                if (!string.IsNullOrWhiteSpace(strDetailRemark) && strDetailRemark.Length > 100)
                                {
                                    errorMsg = Rubix.Screen.Common.GetMessage("I0280");
                                    return;
                                }
                                lotControl.SetEditValueByLot(strLotNo, conditionData.ProductConditionID);

                                DataRow dtr = _detail.NewRow();
                                dtr["LineNo"] = lineNo;
                                dtr["SortedLineNo"] = lineNo;
                                dtr["ProductCode"] = productData.ProductCode; ;
                                dtr["ProductID"] = productData.ProductID;
                                dtr["ProductLongName"] = productData.ProductLongName;
                                dtr["LotNo"] = strLotNo;
                                dtr["OrderQty"] = iOrderQty;
                                dtr["UnitOfQty"] = qtyUnit.UnitID;
                                dtr["ExpiryDate"] = DBNull.Value;
                                dtr["Inventory"] = lotControl.GetInventory;
                                dtr["UnitOfInventory"] = pdu.TypeOfUnitInventory;
                                dtr["TypeOfPackage"] = pdu.PackageID;// itemLot;
                                dtr["InPackage"] = pdu.NumberOfUnitLevel2;
                                dtr["UnitOfInPackage"] = pdu.TypeOfUnitLevel2;
                                dtr["Measurement"] = pdu.VolumeOfUnitLevel1;
                                dtr["ReferenceNo"] = string.Empty;
                                dtr["DetailRemark"] = strDetailRemark;
                                dtr["ShipingPalletNo"] = lotControl.GetPalletNo;
                                dtr["ReceivingPalletNo"] = string.Empty;
                                dtr["ProductConditionID"] = conditionData.ProductConditionID;
                                dtr["ReceivingNo"] = lotControl.GetReceivingNo;
                                dtr["RecInstallment"] = lotControl.GetRecInstallment;
                                dtr["RecLineNo"] = lotControl.GetRecLineNo;
                                lineNo++;
                                lotControl.ClearData();
                                row++;

                                _detail.Rows.Add(dtr);
                            } //while

                            ///
                            if ((row - 1) == 1)
                            {
                                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                            }
                            else
                            {
                                grdShippingInstruction.RefreshDataSource();
                            }
                        } //using excel
                    }// if open dialog
                } //else              
            }
            catch (Exception ex)
            {
                this.CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
            finally
            {
                excel.Dispose();
                ControlUtil.SetBestWidth(gdvShippingInstruction);
                this.CloseWaitScreen();
                if (!string.IsNullOrWhiteSpace(errorMsg))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, errorMsg);
                }
            }
        }
       
        private void txtQty_EditValueChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(txtQty, string.Empty);
            //changeQtyOrCustomerOrder();
            decimal val;
            if (Decimal.TryParse(txtQty.Text, out val))
            {
                if (val < 0)
                    txtQty.EditValue = -val;
            }
            resetQty();

        }

        private void shipmentControl_EditValueChanged(object sender, EventArgs e)
        {
            if (this.ScreenMode == Common.eScreenMode.Add)
            {
                if (!Util.IsNullOrEmpty(shipmentControl.ShipmentNo))
                {
                    sp_FSES010_ShippingInstruction_GetInfoWhereShipmentNo_Result info = BusinessClass.GetInfoWhereShippingNo(shipmentControl.ShipmentNo);

                    if (info != null)
                    {
                        dateCut.EditValue = info.CutDate;
                        ETDPort.EditValue = info.ETD;
                        ETADestination.EditValue = info.ETA;
                        finalDestinationControl.FinalDestinationID = info.FinalDestinationID;
                        txtRemark.EditValue = info.Remark;
                    }
                }
            }
        }

        private void finalDestinationControl_EditValueChanged(object sender, EventArgs e)
        {
            if (finalDestinationControl.GetFinalDestinationID.HasValue)
            {
                sp_FSES010_ShippingInstruction_LoadFinalDestinationInfo_Result finalInfo = BusinessClass.LoadFinalDesInfo(finalDestinationControl.GetFinalDestinationID.Value);
                txtFinalAddress.EditValue = finalInfo.FinalDestinationAddress;
            }

        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), string.Empty)) == DialogButton.Yes)
                {
                    if (this.ScreenMode == Common.eScreenMode.Edit)
                    {
                        if (!iv.ValidateTicket(TransferInstrunctionHeader["ShipmentNo"].ToString(), TransferInstrunctionHeader["PickingNo"].ToString()))
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                            return false;
                        }
                    }
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

        public override bool OnCommandClear()
        {

            dlgFSES021_TransferInstructionDialog_Load(this, new EventArgs());
            //clearControl();
            return base.OnCommandClear();
        }
        #endregion

        #region Generic Function
        private void InitControl()
        {
            // set require field
            ownerControl.RequireField = true;

            warehouseControl.RequireField = true;

            itemConditionControl.RequireField = true;
            itemControl.RequireField = true;
            shippingAreaControl.RequireField = true;

            finalDestinationControl.RequireField = true;
            lotControl.RequireField = true;

            //23 Jan 2013: add for filter  
            shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusId();
            //end 23 Jan 2013
        }

        private void loadTransportCharge()
        {
            DataTable dtCharge = BusinessClass.loadTransportCharge(TransferInstrunctionHeader["ShipmentNo"].ToString(), TransferInstrunctionHeader["PickingNo"].ToString(), Convert.ToInt32(TransferInstrunctionHeader["Installment"]));
            if (dtCharge.Rows.Count != 0)
            {
                transCharge = Util.IsNullOrEmpty(dtCharge.Rows[0][0]) ? 0.0m : Convert.ToDecimal(dtCharge.Rows[0][0]);// dtCharge.Rows[0][0];
                outgoingCharge = (Util.IsNullOrEmpty(dtCharge.Rows[0][1]) ? 0.0m : Convert.ToDecimal(dtCharge.Rows[0][1]));
            }
        }

        private void loadOtherCharge()
        {
            DataTable dtCharge = BusinessClass.loadOtherCharge(TransferInstrunctionHeader["ShipmentNo"].ToString());
            if (dtCharge.Rows.Count != 0)
            {
                otherCharge = (Util.IsNullOrEmpty(dtCharge.Rows[0][0]) ? 0.0m : Convert.ToDecimal(dtCharge.Rows[0][0]));// dtCharge.Rows[0][0];
            }
        }

        private void LoadTransportChargeInfo()
        {
            //if (this.ScreenMode == Common.eScreenMode.Add)
            //{
            //    TransportChargeList = new List<sp_FSES012_TransportDetail_Search_Result>();
            //}
            //else
            //{
            //    TransportChargeList = BusinessClass.GetShippingTransDetail(BusinessClass.ShipmentNo, BusinessClass.PickingNo, BusinessClass.Installment);
            //}
            //}

            TransportChargeList = BusinessClass.GetShippingTransDetail(TransferInstrunctionHeader["ShipmentNo"].ToString(), TransferInstrunctionHeader["PickingNo"].ToString(), Convert.ToInt32(TransferInstrunctionHeader["Installment"]));
        }

        private void LoadOtherChargeInfo()
        {
            //if (this.ScreenMode == Common.eScreenMode.Add)
            //{
            //    OtherChargeList = new List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result>();
            //}
            //else
            //{
            //    OtherChargeList = BusinessClass.LoadShippingOtherCharge(BusinessClass.ShipmentNo);
            //}
            OtherChargeList = BusinessClass.LoadShippingOtherCharge(TransferInstrunctionHeader["ShipmentNo"].ToString());
        }

        private void LoadDetail()
        {
            if (this.ScreenMode == Common.eScreenMode.Add)
            {
                _detail = new DataTable();
                _detail.Columns.Add("LineNo", typeof(int));
                _detail.Columns.Add("SortedLineNo", typeof(int));
                _detail.Columns.Add("ProductCode", typeof(string));
                _detail.Columns.Add("ProductID", typeof(int));
                _detail.Columns.Add("ProductLongName", typeof(string));
                _detail.Columns.Add("LotNo", typeof(string));
                _detail.Columns.Add("OrderQty", typeof(decimal));
                _detail.Columns.Add("UnitOfQty", typeof(int));
                _detail.Columns.Add("ExpiryDate", typeof(DateTime));
                _detail.Columns.Add("Inventory", typeof(decimal));
                _detail.Columns.Add("UnitOfInventory", typeof(int));
                _detail.Columns.Add("TypeOfPackage", typeof(int));
                _detail.Columns.Add("InPackage", typeof(decimal));
                _detail.Columns.Add("UnitOfInPackage", typeof(int));
                _detail.Columns.Add("Measurement", typeof(decimal));
                _detail.Columns.Add("ReferenceNo", typeof(string));
                _detail.Columns.Add("DetailRemark", typeof(string));
                _detail.Columns.Add("ShipingPalletNo", typeof(string));
                _detail.Columns.Add("ReceivingPalletNo", typeof(string));
                _detail.Columns.Add("ProductConditionID", typeof(int));
                _detail.Columns.Add("ReceivingNo", typeof(string));
                _detail.Columns.Add("RecInstallment", typeof(int));
                _detail.Columns.Add("RecLineNo", typeof(int));
            }
            else
                _detail = BusinessClass.TransferInstructionLoadDetail(TransferInstrunctionHeader["ShipmentNo"].ToString(), TransferInstrunctionHeader["PickingNo"].ToString());

            ////Binding Detail            
            //product control
            itemControl.OwnerID = ownerControl.OwnerID;
            itemControl.DataLoading();
            BindingSource bs = new BindingSource();
            bs.DataSource = _detail;
            grdShippingInstruction.DataSource = bs;

            Rubix.Framework.ControlUtil.SetBestWidth(gdvShippingInstruction);

        }

        private void DataBinding()
        {
            ownerControl.OwnerCode = TransferInstrunctionHeader["OwnerCode"].ToString();
            txtShippingStatus.Text = TransferInstrunctionHeader["ShippingStatus"].ToString();
            warehouseControl.WarehouseCode = TransferInstrunctionHeader["WarehouseCodeFrom"].ToString();
            shipmentControl.ShipmentNo = TransferInstrunctionHeader["ShipmentNo"].ToString();
            txtPickingNo.Text = TransferInstrunctionHeader["PickingNo"].ToString();
            shippingAreaControl.ShippingAreaID = Convert.ToInt32(TransferInstrunctionHeader["ShippingAreaID"]);


            ///finalDestinationControl
            finalDestinationControl.OwnerID = Convert.ToInt32(TransferInstrunctionHeader["OwnerID"]);
            finalDestinationControl.DataLoading();
            finalDestinationControl.FinalDestinationID = Convert.ToInt32(TransferInstrunctionHeader["FinalDestinationID"]);

            if (!string.IsNullOrEmpty(TransferInstrunctionHeader["PickingDate"].ToString()))
            {
                datePicking.EditValue = Convert.ToDateTime(TransferInstrunctionHeader["PickingDate"]);
                txtPickingDate.Text = Convert.ToDateTime(TransferInstrunctionHeader["PickingDate"]).ToString("HH:mm");
            }

            if (!string.IsNullOrEmpty(TransferInstrunctionHeader["DeliveryDate"].ToString()))
            {
                ETADestination.EditValue = Convert.ToDateTime(TransferInstrunctionHeader["DeliveryDate"]);
                txtETA.Text = Convert.ToDateTime(TransferInstrunctionHeader["DeliveryDate"]).ToString("HH:mm");
            }

            if (!string.IsNullOrEmpty(TransferInstrunctionHeader["CutDate"].ToString()))
            {
                dateCut.EditValue = Convert.ToDateTime(TransferInstrunctionHeader["CutDate"]);
                txtCusDate.Text = Convert.ToDateTime(TransferInstrunctionHeader["CutDate"]).ToString("HH:mm");
            }

            if (!string.IsNullOrEmpty(TransferInstrunctionHeader["ETD"].ToString()))
            {
                ETDPort.EditValue = Convert.ToDateTime(TransferInstrunctionHeader["ETD"]);
                txtETD.Text = Convert.ToDateTime(TransferInstrunctionHeader["ETD"]).ToString("HH:mm");
            }

            if (!string.IsNullOrEmpty(TransferInstrunctionHeader["VanningDate"].ToString()))
            {
                dateVanning.EditValue = Convert.ToDateTime(TransferInstrunctionHeader["VanningDate"]);
                txtVanningDate.Text = Convert.ToDateTime(TransferInstrunctionHeader["VanningDate"]).ToString("HH:mm");
            }

            if (!string.IsNullOrEmpty(TransferInstrunctionHeader["TransportationDate"].ToString()))
            {
                dateTrans.EditValue = Convert.ToDateTime(TransferInstrunctionHeader["TransportationDate"]);
                txtTransDate.Text = Convert.ToDateTime(TransferInstrunctionHeader["TransportationDate"]).ToString("HH:mm");
            }

            //transport Charge 
            txtTransCharge.EditValue = transCharge;
            txtOutgoingCharge.EditValue = outgoingCharge;
            ///other Charge
            txtOtherCharge.EditValue = otherCharge;

            txtReceivingStatus.Text = TransferInstrunctionHeader["ReceivingStatus"].ToString();
            warehouseControl2.WarehouseCode = TransferInstrunctionHeader["WarehouseCodeTo"].ToString();
            txtReceivingNo.Text = TransferInstrunctionHeader["ReceivingNo"].ToString();
            dateArrival.EditValue = Convert.ToDateTime(TransferInstrunctionHeader["ArrivalDate"]);
            txtHeaderRemark.Text = TransferInstrunctionHeader["Remark"].ToString();


            //Binding Statusbar 
            string createDate = Convert.ToDateTime(TransferInstrunctionHeader["CreateDate"]).ToString(Common.FullDatetimeFormat);
            m_statusBarCreatedDate.Caption = createDate;
            m_statusBarCreatedUser.Caption = TransferInstrunctionHeader["CreateUser"].ToString();
            if (TransferInstrunctionHeader["UpdateDate"] != DBNull.Value)
            {
                m_statusBarUpdatedDate.Caption = Convert.ToDateTime(TransferInstrunctionHeader["UpdateDate"]).ToString(Common.FullDatetimeFormat);
                m_statusBarUpdatedUser.Caption = TransferInstrunctionHeader["UpdateUser"].ToString();
            }
            else if (TransferInstrunctionHeader["UpdateDate"] == DBNull.Value && ScreenMode == Common.eScreenMode.Edit)
            {
                m_statusBarUpdatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarUpdatedUser.Caption = AppConfig.UserLogin;
            }
        }

        private Boolean ValidateTransportCharge()
        {
            Boolean noError = true;
            string messageId = string.Empty;
            if (!ownerControl.ValidateControl())
            {
                noError = false;
            }
            if (!warehouseControl.ValidateControl())
            {
                noError = false;
            }
            if (!finalDestinationControl.ValidateControl())
            {
                noError = false;
            }
            return noError;
        }

        private void ShowQtyLevel1()
        {
            bool canShow = BusinessClass.CanShowQtyLevel1();
            grdBandQty1.Visible = canShow;
            grdBandQty1.OptionsColumn.ShowInCustomizationForm = canShow;
        }

        private Boolean ValidateData()
        {
            errorProvider.ClearErrors();
            Boolean noError = true;
            string messageId = string.Empty;
            ownerControl.RequireField = true;
            if (!ownerControl.ValidateControl())
            {
                noError = false;
            }

            warehouseControl.RequireField = true;
            if (!warehouseControl.ValidateControl())
            {
                noError = false;
            }
            warehouseControl2.RequireField = true;
            if (!warehouseControl2.ValidateControl())
            {
                noError = false;
            }

            if (warehouseControl.WarehouseCode == warehouseControl2.WarehouseCode)
            {
                warehouseControl2.IsError(true, Common.GetMessage("I0344"));
                noError = false;
            }
            else
            {
                warehouseControl2.IsError(true, string.Empty);
            }

            shippingAreaControl.RequireField = true;
            if (!shippingAreaControl.ValidateControl())
            {
                noError = false;
            }

            if (!finalDestinationControl.ValidateControl())
            {
                noError = false;
            }

            if (dateArrival.Text == string.Empty)
            {
                errorProvider.SetError(dateArrival, Rubix.Screen.Common.GetMessage("I0163"));
                noError = false;
            }

            if (ETDPort.Text == string.Empty)
            {
                errorProvider.SetError(ETADestination, Rubix.Screen.Common.GetMessage("I0136"));
                noError = false;
            }
            else if (false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(DataUtil.Convert<DateTime>(ETDPort.EditValue), true))
            {
                errorProvider.SetError(ETDPort, Rubix.Screen.Common.GetMessage("I0236"));
                noError = false;
            }

            if (txtETD.Text == string.Empty)
            {
                errorProvider.SetError(txtETD, Rubix.Screen.Common.GetMessage("I0134"));
                noError = false;
            }

            if (txtPickingDate.Text == string.Empty)
            {
                errorProvider.SetError(txtPickingDate, Rubix.Screen.Common.GetMessage("I0135"));
                noError = false;
            }

            if (datePicking.Text == string.Empty)
            {
                errorProvider.SetError(datePicking, Rubix.Screen.Common.GetMessage("I0134"));
                noError = false;
            }
            else if (false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(DataUtil.Convert<DateTime>(datePicking.EditValue), true))
            {
                errorProvider.SetError(datePicking, Rubix.Screen.Common.GetMessage("I0236"));
                noError = false;
            }
           
            if (txtVanningDate.Text != string.Empty && dateVanning.EditValue == null)
            {
                errorProvider.SetError(dateVanning, Rubix.Screen.Common.GetMessage("I0134"));
                noError = false;
            }
            else if (dateVanning.EditValue != null
                && false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(DataUtil.Convert<DateTime>(dateVanning.EditValue), true))
            {
                errorProvider.SetError(dateVanning, Rubix.Screen.Common.GetMessage("I0236"));
                noError = false;
            }

            if (txtTransDate.Text != string.Empty && dateTrans.EditValue == null)
            {
                errorProvider.SetError(dateTrans, Rubix.Screen.Common.GetMessage("I0134"));
                noError = false;
            }
            else if (dateTrans.EditValue != null
                && false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(DataUtil.Convert<DateTime>(dateTrans.EditValue), true))
            {
                errorProvider.SetError(dateTrans, Rubix.Screen.Common.GetMessage("I0236"));
                noError = false;
            }

            if (txtCusDate.Text != string.Empty && dateCut.EditValue == null)
            {
                errorProvider.SetError(dateCut, Rubix.Screen.Common.GetMessage("I0134"));
                noError = false;
            }
            else if (dateCut.EditValue != null
                && false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(DataUtil.Convert<DateTime>(dateCut.EditValue), true))
            {
                errorProvider.SetError(dateCut, Rubix.Screen.Common.GetMessage("I0236"));
                noError = false;
            }

            if (txtETA.Text != string.Empty && ETADestination.EditValue == null)
            {
                errorProvider.SetError(ETADestination, Rubix.Screen.Common.GetMessage("I0134"));
                noError = false;
            }
            else if (ETADestination.EditValue != null
                && false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(DataUtil.Convert<DateTime>(txtETA.EditValue), true))
            {
                errorProvider.SetError(ETADestination, Rubix.Screen.Common.GetMessage("I0236"));
                noError = false;
            }

            if (gdvShippingInstruction.RowCount == 0)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0112"));
                noError = false;
            }
            
            if (ETADestination.EditValue != null)
            {
                if (!DataUtil.IsTime(txtETA.Text))
                {
                    errorProvider.SetError(txtETA, Common.GetMessage("I0261", "Delivery"));
                    noError = false;
                }
            }

            if (ETDPort.EditValue != null)
            {
                if (!DataUtil.IsTime(txtETD.Text))
                {
                    errorProvider.SetError(txtETD, Common.GetMessage("I0261", "ETD L/D Port"));
                    noError = false;
                }
            }

            if (dateCut.EditValue != null)
            {
                if (!DataUtil.IsTime(txtCusDate.Text))
                {
                    errorProvider.SetError(txtCusDate, Common.GetMessage("I0261", "Cut"));
                    noError = false;
                }
            }

            if (dateTrans.EditValue != null)
            {
                if (!DataUtil.IsTime(txtTransDate.Text))
                {
                    errorProvider.SetError(txtTransDate, Common.GetMessage("I0261", "Transportation"));
                    noError = false;
                }
            }

            if (dateVanning.EditValue != null)
            {
                if (!DataUtil.IsTime(txtVanningDate.Text))
                {
                    errorProvider.SetError(txtVanningDate, Common.GetMessage("I0261", "Vanning"));
                    noError = false;
                }
            }

            if (datePicking.EditValue != null)
            {
                if (!DataUtil.IsTime(txtPickingDate.Text))
                {
                    errorProvider.SetError(txtPickingDate, Common.GetMessage("I0261", "Picking"));
                    noError = false;
                }
            }

            return noError;
        }

        private Boolean ValidateDetail(string EditRowNumber)
        {
            Boolean noError = true;
            string messageId = string.Empty;

            itemControl.RequireField = true;
            if (!itemControl.ValidateControl())
            {
                errorProvider.SetError(itemControl, Rubix.Screen.Common.GetMessage("I0301"));
                noError = false;
            }
            itemConditionControl.RequireField = true;
            if (!itemConditionControl.ValidateControl())
            {
                errorProvider.SetError(itemConditionControl, Rubix.Screen.Common.GetMessage("I0026"));
                noError = false;
            }
            lotControl.RequireField = true;
            if (!lotControl.ValidateControl())
            {
                errorProvider.SetError(itemControl, Rubix.Screen.Common.GetMessage("I0172"));
                noError = false;
            }

            if (txtQty.Text.Trim() == string.Empty)
            {
                errorProvider.SetError(txtQty, Rubix.Screen.Common.GetMessage("I0026"));
                noError = false;
            }
            if (cboQtyUnit.Text.Trim() == string.Empty)
            {
                errorProvider.SetError(txtQty, Rubix.Screen.Common.GetMessage("I0176"));
                noError = false;
            }

            // validate duplicate lot 
            foreach (DataRow dr in _detail.Rows)
            {
                if (Convert.ToInt32(dr["ProductID"]) == itemControl.ProductID
                    && Convert.ToInt32(dr["ProductConditionID"]) == itemConditionControl.ProductConditionID
                    && dr["LotNo"].ToString().Equals(lotControl.GetLotNo)
                    && (EditRowNumber == string.Empty || EditRowNumber != dr["SortedLineNo"].ToString())
                    )
                {
                    if (MessageDialog.ShowConfirmationMsg(this, Rubix.Screen.Common.GetMessage("I0196"), DialogButton.No) != DialogButton.Yes)
                    {
                        noError = false;
                    }
                    break;
                }
            }

            return noError;
        }

        private void SaveData()
        {
            try
            {
                BusinessClass.ShipmentNo = shipmentControl.ShipmentNo;
                BusinessClass.Installment = 1;
                BusinessClass.OwnerID = Convert.ToInt32(ownerControl.OwnerID);
                BusinessClass.CustomerCode = "";
                BusinessClass.CustomerName = "";
                BusinessClass.CustomerID = -1;
                BusinessClass.CustomerCode = "";
                BusinessClass.CustomerName = "";
                BusinessClass.PickingNo = txtPickingNo.Text.Trim();
                BusinessClass.WarehouseID = Convert.ToInt32(warehouseControl.WarehouseID);
                BusinessClass.PickingDate = shkDatetime(datePicking.EditValue, txtPickingDate.EditValue);
                BusinessClass.VanningDate = shkDatetime(dateVanning.EditValue, txtVanningDate.EditValue);
                BusinessClass.TransportationDate = shkDatetime(dateTrans.EditValue, txtTransDate.EditValue);
                BusinessClass.CutDate = shkDatetime(dateCut.EditValue, txtCusDate.EditValue);
                BusinessClass.ETD = Convert.ToDateTime(shkDatetime(ETDPort.EditValue, txtETD.EditValue));
                BusinessClass.ShippingAreaID = shippingAreaControl.ShippingAreaID;
                BusinessClass.ShippingAreaCode = "";
                BusinessClass.ShippingAreaName = "";
                BusinessClass.PortOfLoadingID = null;
                BusinessClass.PortOfDischargeID = null;
                BusinessClass.FinalDestinationID = finalDestinationControl.GetFinalDestinationID;
                BusinessClass.FinalDestinationCode = "";
                BusinessClass.FinalDestinationLongName = "";
                BusinessClass.ETA = Rubix.Framework.DataUtil.CombineDateAndTime((DateTime)ETADestination.EditValue, Convert.ToDateTime(txtETA.EditValue));
                BusinessClass.AgentSeal = string.Empty;
                BusinessClass.InspectionSeal = string.Empty;
                BusinessClass.InvoiceNo = string.Empty;
                BusinessClass.BookingNo = string.Empty;
                BusinessClass.VesselName1 = string.Empty;
                BusinessClass.VesselName2 = string.Empty;
                BusinessClass.AgentOwner = string.Empty;
                BusinessClass.PortOfLoadingID = null;
                BusinessClass.PortOfDischargeID = null;
                BusinessClass.Remark = txtHeaderRemark.Text.Trim();
                BusinessClass.ShipCompleteFlag = false;
                BusinessClass.ShipCompleteDate = null;
                BusinessClass.CreateUser = AppConfig.UserLogin;
                BusinessClass.UpdateUser = AppConfig.UserLogin;
                BusinessClass.StatusName = "";

                BusinessClass.SaveTransferInstructionData(_detail, gdvShippingInstruction.RowCount, 
                                                          this.TransportChargeList, this.TransportDialog.DeleteList,
                                                          this.OtherChargeList, this.OtherChargeDialog.DeleteList,
                                                          Convert.ToDateTime(dateArrival.EditValue),
                                                          txtReceivingNo.Text,
                                                          Convert.ToInt32(TransferInstrunctionHeader["SupplierID"]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DateTime? shkDatetime(Object date, Object time)
        {
            if (date != null)
            {
                if (time != null && time.ToString() != string.Empty)
                {
                    return Rubix.Framework.DataUtil.CombineDateAndTime((DateTime)date, Convert.ToDateTime(time));
                }
                else
                    return (DateTime)date;
            }
            else
                return null;
        }

        private void genQtyUnitcbo(int? qtyUnit)
        {
            qtyUnitList = BusinessClass.LoadProductUnit(qtyUnit == null ? null : DataUtil.Convert<int>(qtyUnit), itemControl.ProductID == null ? null : itemControl.ProductID);

            DataTable dtUnit = new DataTable();
            dtUnit.Columns.Add("UnitID", typeof(int));
            dtUnit.Columns.Add("UnitCode", typeof(string));
            foreach (sp_Common_ProductUnit_Result List in qtyUnitList)
            {
                //if (List.TypeOfUnitLevel1 != null)
                //{
                //    dtUnit.Rows.Add(List.TypeOfUnitLevel1, List.UnitCode1);
                //}
                if (List.TypeOfUnitLevel2 != null)
                {
                    dtUnit.Rows.Add(List.TypeOfUnitLevel2, List.UnitCode2);
                }
                if (List.TypeOfUnitLevel3 != null)
                {
                    dtUnit.Rows.Add(List.TypeOfUnitLevel3, List.UnitCode3);
                }
                if (List.TypeOfUnitLevel4 != null)
                {
                    dtUnit.Rows.Add(List.TypeOfUnitLevel4, List.UnitCode4);
                }
            }
            cboQtyUnit.Properties.Columns.Clear();
            cboQtyUnit.Properties.Columns.Add(new LookUpColumnInfo("UnitCode", "UnitCode", 200));

            cboQtyUnit.Properties.DataSource = dtUnit;
            cboQtyUnit.Properties.DisplayMember = "UnitCode";
            cboQtyUnit.Properties.ValueMember = "UnitID";
            cboQtyUnit.EditValue = qtyUnit;

            ///set DataGrid for show
            grdUnit.DataSource = qtyUnitList;

        }

        private void resetQty()
        {
            decimal Qty = string.IsNullOrWhiteSpace(txtQty.Text) ? 0 : Convert.ToDecimal(txtQty.EditValue);
            List<sp_Common_ProductUnit_Result> productUnit = (List<sp_Common_ProductUnit_Result>)grdUnit.DataSource;
            if (productUnit != null)
            {
                foreach (sp_Common_ProductUnit_Result item in productUnit)
                {
                    // 18 Jan 2013: modify and add for support show qty level1
                    //grvUnit.SetRowCellValue(0, eColUnit.VolumnOfUnitLevel1.ToString(), Qty);
                    grvUnit.SetRowCellValue(0, eColUnit.VolumnOfUnitLevel1.ToString(), item.VolumeOfUnitLevel1);
                    grvUnit.SetRowCellValue(0, eColUnit.QtyLvl1.ToString(), item.UnitRatioToLvl1 * Qty);
                    // end 18 Jan 2013: modify and add for support show qty level1
                    grvUnit.SetRowCellValue(0, eColUnit.QtyLvl2.ToString(), item.UnitRatioToLvl2 * Qty);
                    grvUnit.SetRowCellValue(0, eColUnit.QtyLvl3.ToString(), item.UnitRatioToLvl3 * Qty);
                    grvUnit.SetRowCellValue(0, eColUnit.QtyLvl4.ToString(), item.UnitRatioToLvl4 * Qty);

                }
            }
        }

        private void clearDetailControl()
        {
            ControlUtil.ClearControlData(txtInPackage
                                              , txtQty
                                              , txtInventory
                                              , txtRemark
                                              , txtReferenceNo);
            itemControl.ClearData();
            lotControl.ClearData();
            itemConditionControl.ClearData();
            cboTypeOfPackage.EditValue = null;
            cboUnitOfInPackage.EditValue = null;
            cboQtyUnit.EditValue = null;
            cboUnitInventory.EditValue = null;
            grdUnit.DataSource = null;
            dateExpiry.EditValue = null;

            errorProvider.SetError(txtQty, string.Empty);
            errorProvider.SetError(txtTransCharge, string.Empty);
        }

        private void DeleteDetail()
        {
            DataRow dr = gdvShippingInstruction.GetFocusedDataRow();
            int deletedLine = Convert.ToInt32(dr["SortedLineNo"]);
            gdvShippingInstruction.DeleteSelectedRows();

            _detail.AcceptChanges();

            foreach (DataRow data in _detail.Rows)
            {
                if (Convert.ToInt32(data["SortedLineNo"]) > deletedLine)
                {
                    data["SortedLineNo"] = Convert.ToInt32(data["SortedLineNo"]) - 1;
                }
            }

            _detail.AcceptChanges();

        }

        private void SetDetail(DataRow dr)
        {
            try
            {
                dr["ProductCode"] = itemControl.ProductCode;
                dr["ProductID"] = itemControl.ProductID;
                dr["ProductLongName"] = itemControl.ProductLongName;
                dr["LotNo"] = lotControl.GetLotNo;
                dr["OrderQty"] = DataUtil.Convert<decimal>(txtQty.EditValue);
                dr["UnitOfQty"] = DataUtil.Convert<int>(cboQtyUnit.EditValue);
                dr["Inventory"] = DataUtil.Convert<decimal>(txtInventory.EditValue);
                dr["UnitOfInventory"] = DataUtil.Convert<int>(cboUnitInventory.EditValue);
                dr["TypeOfPackage"] = DataUtil.Convert<int>(cboTypeOfPackage.EditValue);
                dr["InPackage"] = DataUtil.Convert<decimal>(txtInPackage.EditValue);
                dr["UnitOfInPackage"] = DataUtil.Convert<int>(cboUnitOfInPackage.EditValue);
                dr["Measurement"] = qtyUnitList[0].VolumeOfUnitLevel1;
                dr["ReferenceNo"] = txtReferenceNo.Text.Trim();
                dr["DetailRemark"] = txtRemark.Text.Trim();
                dr["ShipingPalletNo"] = lotControl.GetPalletNo;
                dr["ReceivingPalletNo"] = "";
                dr["ProductConditionID"] = itemConditionControl.ProductConditionID;
                dr["ReceivingNo"] = lotControl.GetReceivingNo;
                dr["RecInstallment"] = lotControl.GetRecInstallment;
                dr["RecLineNo"] = lotControl.GetRecLineNo;

                if (dateExpiry.EditValue != null)
                {
                    dr["ExpiryDate"] = dateExpiry.DateTime;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        #endregion

        

    }
}
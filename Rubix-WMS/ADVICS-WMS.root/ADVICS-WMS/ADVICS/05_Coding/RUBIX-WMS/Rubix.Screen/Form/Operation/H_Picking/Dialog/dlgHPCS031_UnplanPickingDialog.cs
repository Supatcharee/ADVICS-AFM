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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using CSI.Business.Common;
using DevExpress.Utils;
using System.Linq;
using System.Transactions;
namespace Rubix.Screen.Form.Operation.H_Picking.Dialog
{
    public partial class dlgHPCS031_UnplanPickingDialog : DialogBase
    {

        #region Member
        private ShippingInstruction db;
        private StockControl m_dbBookStock;
        private PickingInstruction m_dbPicking;
        private ConfirmPicking m_dbConfirmPicking;
        private F_ShippingEntry.Dialog.dlgFSES012_TransportDetail m_TransDialog = null;
        private F_ShippingEntry.Dialog.dlgFSES013_OtherCharge m_ChargeDialog = null;
        private Common.eScreenMode eScrenMode;
        private List<sp_FSES011_ShippingInstruction_SearchDetail_Result> _detail = null;
        private List<string> _filePath = new List<string>();
        private List<sp_FSES012_TransportDetail_Search_Result> l_transport = null;
        private List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result> l_otherCharge = null;
        public decimal transCharge = 0;
        public decimal outgoingCharge = 0;
        public decimal otherCharge = 0;
        private string outShipmentNo;
        private string outPickingNo;
        public bool chkDetailUpdate = false;
        // 22 Jan 2013: add for check whether is update detail  (no use chkDetailUpdate because it relates with getCustomerOrder function)
        private bool isUpdateDetailMode = false;
        // end 22 Jan 2013 
        #endregion

        #region Enumeration
        private enum eColImport
        {     
             LineNo = 1
            ,PONo
			,ItemCode
            ,LotNo
			,OrderQty
            ,UnitOfQTY
            ,ItemConditionCode
            ,DetailRemark			
        }

        private enum eColUnit
        { 
              VolumnOfUnitLevel1
                ,QtyLvl1 // 18 Jan 2013: add for support show qty lv1
                ,TypeOfUnitLevel1
                ,UnitCode1
                ,QtyLvl2
                ,UnitRatioToLvl2
                ,TypeOfUnitLevel2
                ,UnitCode2
                ,QtyLvl3
                ,UnitRatioToLvl3
                ,TypeOfUnitToLevel3
                ,UnitCode3
                ,QtyLvl4
                ,UnitRatioToLvl4
                ,TypeOfUnitToLevel4
                ,UnitCode4
        }
        #endregion

        #region Properties
        public bool ShowActual
        {
            get;
            set;
        }

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

        private StockControl BookStockBusinessClass
        {
            get
            {
                if (m_dbBookStock == null)
                {
                    m_dbBookStock = new StockControl();
                }
                return m_dbBookStock;
            }
        }

        private PickingInstruction PickingBusinessClass
        {
            get
            {
                if (m_dbPicking == null)
                {
                    m_dbPicking = new PickingInstruction();
                }
                return m_dbPicking;
            }
        }

        private ConfirmPicking ConfirmPickingBusinessClass
        {
            get
            {
                if (m_dbConfirmPicking == null)
                {
                    m_dbConfirmPicking = new ConfirmPicking();
                }
                return m_dbConfirmPicking;
            }
        }

        private F_ShippingEntry.Dialog.dlgFSES012_TransportDetail TransportDialog
        {
            get
            {
                if (m_TransDialog == null)
                {
                    return m_TransDialog = new F_ShippingEntry.Dialog.dlgFSES012_TransportDetail();
                }
                return m_TransDialog;
            }
        }

        private F_ShippingEntry.Dialog.dlgFSES013_OtherCharge OtherChargeDialog
        {
            get
            {
                if (m_ChargeDialog == null)
                {
                    return m_ChargeDialog = new F_ShippingEntry.Dialog.dlgFSES013_OtherCharge();
                }
                return m_ChargeDialog;
            }
        }

        public Common.eScreenMode ScreenMode
        {
            get { return eScrenMode; }
            set { eScrenMode = value; }
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

        List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result> OtherChargeList = null;

        #endregion

        #region Constructor
        public dlgHPCS031_UnplanPickingDialog()
        {
            InitializeComponent();
            this.ShowActual = false;
            base.GridViewControl = new GridControl[] { grdShippingInstruction };

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

            colOrderQty.DisplayFormat.FormatString = Common.QtyFormat;
            colOrderQty.DisplayFormat.FormatType = FormatType.Custom;

            colInventory.DisplayFormat.FormatString = Common.QtyFormat;
            colInventory.DisplayFormat.FormatType = FormatType.Custom;

            colInPackage.DisplayFormat.FormatString = Common.QtyFormat;
            colInPackage.DisplayFormat.FormatType = FormatType.Custom;

            colWeight.DisplayFormat.FormatString = Common.QtyFormat;
            colWeight.DisplayFormat.FormatType = FormatType.Custom;

            colMeasurement.DisplayFormat.FormatString = Common.QtyFormat;
            colMeasurement.DisplayFormat.FormatType = FormatType.Custom;

            colM3.DisplayFormat.FormatString = Common.QtyFormat;
            colM3.DisplayFormat.FormatType = FormatType.Custom;

            colNetWeight.DisplayFormat.FormatString = Common.QtyFormat;
            colNetWeight.DisplayFormat.FormatType = FormatType.Custom;

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

            txtWeight.Properties.DisplayFormat.FormatString = Common.QtyFormat;
            txtWeight.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtWeight.Properties.EditFormat.FormatString = Common.QtyFormat;
            txtWeight.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtWeight.Properties.Mask.EditMask = Common.QtyFormat;

            txtMeasure.Properties.DisplayFormat.FormatString = Common.QtyFormat;
            txtMeasure.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtMeasure.Properties.EditFormat.FormatString = Common.QtyFormat;
            txtMeasure.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            txtMeasure.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txtMeasure.Properties.Mask.EditMask = Common.QtyFormat;

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

            ControlUtil.EnableControl(false, itemConditionControl);
            InitControl();
        } 
        #endregion

        #region Event Handler Function

        private void dlgHPCS030_UnplanPickingDialog_Load(object sender, EventArgs e)
        {
            // 18 Jan 2013: add for show qty level1 
            ShowQtyLevel1();
            //end 18 Jan 2013
            lotControl.ClearData();
            itemControl.ClearData();
            itemConditionControl.ClearData();
            cboQtyUnit.EditValue = null;
            cboUnitOfInPackage.EditValue = null;
            cboTypeOfPackage.EditValue = null;
            cboUnitInventory.EditValue = null;
            txtQty.EditValue = null;
            txtLineNo.EditValue = null;
            txtPONo.EditValue = null;
            txtRemark.EditValue = null;
            portOfDischarge.ClearData();
            portOfLoading.ClearData();

            itemConditionControl.EnableControl = false; //always disabled

            tabShip.SelectedTabPage = pageHeader;

            btnAdd.Visible = true;
            btnDelete.Visible = true;
            btnOK.Visible = false;

            m_toolBarClear.Enabled = true;
            m_toolBarClose.Enabled = true;
            m_toolBarSave.Enabled = true;
            ControlUtil.ClearControlData(this.Controls);
            ControlUtil.ClearControlData(this.pageHeader);
            ControlUtil.ClearControlData(this.pageDetail);
            
            loadTransportCharge();
            loadOtherCharge();
            if (ScreenMode == Common.eScreenMode.View)
            {
                ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
                ControlUtil.EnableControl(false, Controls);
                //20121218: add for enable button
                ControlUtil.EnableControl(true, btnTransportDetail, btnOtherCharge);
                //end 20121218
                pnlEdit.Visible = false;
            }
            else
            {
                pnlEdit.Visible = true;
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

                itemControl.Enabled = false;
                lotControl.Enabled = false;
                itemConditionControl.Enabled = false;
                txtQty.Enabled = false;
                //Enable after Owner selected

                ControlUtil.EnableControl(false, txtStatus, txtPickingNo, txtPortDischargeAddress, txtPortLoadingAddress, txtFinalAddress, txtPhone, txtExtension, txtMobile);
                
                if (BusinessClass.ShipmentNo != null)
                {
                    BusinessClass = new ShippingInstruction();
                }
                //this.PickHeader = BusinessClass.CreatePickingHeader();
                txtOtherCharge.EditValue = 0;
                txtTransCharge.EditValue = 0;
                txtOutgoingCharge.EditValue = 0;
                
            }
            else
            {
                // 20121218: Add for fill data before set enable/disable
                DataBinding();
                // end 20121218
                if (BusinessClass.StatusID.ToString() != "3" && BusinessClass.StatusID.ToString() != "2")
                {
                    ///can not Edit data
                    //ControlUtil.EnableControl(false, Controls);
                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                    //20121218: add for enable button
                    ControlUtil.EnableControl(true, btnTransportDetail, btnOtherCharge);
                    //end 20121218
                    //ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
                    pnlEdit.Visible = false;
                }
                else
                    pnlEdit.Visible = true;
                shipmentControl.EnableControl = false;
                ownerControl.EnableControl = false;            
            }
            LoadDetail();
            LoadTransportChargeInfo();
            LoadOtherChargeInfo();

            if (this.ShowActual)
            {
                colShipQty.Visible = true;
                colShipQty.OptionsColumn.ShowInCustomizationForm = true;
                colShipQty.OptionsColumn.ShowInExpressionEditor = true;
            }
            else
            {
                colShipQty.Visible = false;
                colShipQty.OptionsColumn.ShowInCustomizationForm = false;
                colShipQty.OptionsColumn.ShowInExpressionEditor = false;
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
                if(ValidateTransportCharge())
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateDetail())
            {
                gdvShippingInstruction.AddNewRow();
                gdvShippingInstruction.UpdateCurrentRow();
                clearDetailControlAdd();
                lotControl_EditValueChanged(this, new EventArgs());
            }
        }
       
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gdvShippingInstruction.GetFocusedRow() != null)
                DeleteDetail((sp_FSES011_ShippingInstruction_SearchDetail_Result)gdvShippingInstruction.GetFocusedRow());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateDetail())
            {
                btnAdd.Visible = true;
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnOK.Visible = false;
                grdShippingInstruction.Enabled = true;

                sp_FSES011_ShippingInstruction_SearchDetail_Result data = (sp_FSES011_ShippingInstruction_SearchDetail_Result)gdvShippingInstruction.GetFocusedRow();
                SetDetail(data);
                clearDetailControl();
                m_toolBarClear.Enabled = true;
                m_toolBarClose.Enabled = true;
                m_toolBarSave.Enabled = true;

                // 22 Jan 2013: add for set value to be false
                isUpdateDetailMode = false;
                // end 22 Jan 2013
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if (gdvShippingInstruction.RowCount > 0 && gdvShippingInstruction.GetFocusedRow() != null)
            {
                sp_FSES011_ShippingInstruction_SearchDetail_Result data = (sp_FSES011_ShippingInstruction_SearchDetail_Result)gdvShippingInstruction.GetFocusedRow();
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnOK.Visible = true;
                grdShippingInstruction.Enabled = false;
                chkDetailUpdate = true;
                m_toolBarClear.Enabled = false;
                m_toolBarClose.Enabled = false;
                m_toolBarSave.Enabled = false;

                //getRemainingOrder(data);
                txtQty.EditValue = data.OrderQty;
                itemControl.ProductID = data.ProductID;
                lotControl.setLotNoControl(data.ReceivingNo,data.RecInstallment,data.RecLineNo, data.ProductConditionID);
                itemConditionControl.ProductConditionCode = data.ProductConditionCode;
                
                txtLineNo.EditValue = data.SortedLineNo;
                txtPONo.Text = data.PONo;
                txtPalletNo.Text = data.PalletNo;
                
                //cboQtyUnit.EditValue = data.UnitOfQty;
                cboQtyUnit.EditValue = data.UnitOfQty;
                txtInventory.EditValue = data.Inventory;
                cboUnitInventory.EditValue = data.UnitOfInventory;
                //itemConditionControl.ProductConditionID = data.ProductConditionID;                
                //itemConditionControl.ProductConditionCode = data.ProductConditionCode;
                cboTypeOfPackage.EditValue = data.TypeOfPackage;
                txtInPackage.EditValue = data.InPackage;
                cboUnitOfInPackage.EditValue = data.UnitOfInPackage;                
                txtNetWeight.EditValue = data.NetWeight;
                txtNetMeasure.EditValue = data.Measurement;
                txtWeight.EditValue = data.Weight;
                txtMeasure.EditValue = data.M3;
                txtRemark.EditValue = data.DetailRemark;
                
                // 22 Jan 2013: add for set value (set false when click OK or ending edit)
                isUpdateDetailMode = true;
                // end 22 Jan 2013
            }
            chkDetailUpdate = false;
        }

        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            if (BusinessClass.CanUpload())
            {
                if (ofdCOA.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    _filePath.Add(ofdCOA.FileName);
                }
            }
            else
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0190"));
        }
       
        private void gdvShippingInstruction_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            sp_FSES011_ShippingInstruction_SearchDetail_Result data = (sp_FSES011_ShippingInstruction_SearchDetail_Result)gdvShippingInstruction.GetRow(e.RowHandle);
            SetDetail(data);
            grdShippingInstruction.RefreshDataSource();
            ControlUtil.SetBestWidth(gdvShippingInstruction);   
        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            //finalDestinationControl.OwnerID = ownerControl.OwnerID;
            //finalDestinationControl.DataLoading();

            customerControl.OwnerID = ownerControl.OwnerID;
            customerControl.DataLoading();

            itemControl.OwnerID = ownerControl.OwnerID;
            itemControl.DataLoading();

            shipmentControl.OwnerID = ownerControl.OwnerID;
            shipmentControl.DataLoading();

            warehouseControl.OwnerID = ownerControl.OwnerID;
            warehouseControl.DataLoading();
            if (this.ScreenMode != Common.eScreenMode.View && ownerControl.OwnerID != null)
            {
                ownerControl.EnableControl = false;
                customerControl.Enabled = ownerControl.OwnerID != null;
                itemControl.Enabled = ownerControl.OwnerID != null;
                btnOtherCharge.Enabled = true;
                btnTransportDetail.Enabled = true;
                shipmentControl.Enabled = ownerControl.OwnerID != null;
                warehouseControl.Enabled = ownerControl.OwnerID != null;

                //2013-11-26 By Porntip 
                itemControl.Enabled = true;
                lotControl.Enabled = true;
                itemConditionControl.Enabled = true;
                txtQty.Enabled = true;
                //grdShippingInstruction.DataSource = null;

            }
            
        }

        private void finalDestinationControl_EditValueChanged(object sender, EventArgs e)
        {
            if (finalDestinationControl.GetFinalDestinationID.HasValue)
            {
                sp_FSES010_ShippingInstruction_LoadFinalDestinationInfo_Result finalInfo = BusinessClass.LoadFinalDesInfo(finalDestinationControl.GetFinalDestinationID.Value);
                txtFinalAddress.EditValue = finalInfo.FinalDestinationAddress;
                txtPhone.EditValue = finalInfo.PhoneNo;
                txtExtension.EditValue = finalInfo.Extension;
                txtMobile.EditValue = finalInfo.MobileNo;
            }


        }

        private void portOfDischarge_EditValueChanged(object sender, EventArgs e)
        {
            txtPortDischargeAddress.Text = portOfDischarge.GetPortAddress;
        }

        private void portOfLoading_EditValueChanged(object sender, EventArgs e)
        {
            txtPortLoadingAddress.Text = portOfLoading.GetPortAddress;
        }
        
        private void productControl_EditValueChanged(object sender, EventArgs e)
        {
        
            if (itemControl.ProductID.HasValue)
                {   
              
                    ControlUtil.ClearControlData(txtPalletNo
                                                    , txtPalletNoRef
                                                    , txtInventory);
                    ////////////////////////set lot control//////////////////////////
                    cboUnitInventory.EditValue = null;
                    itemConditionControl.ClearData();
                    lotControl.ProductID = itemControl.ProductID;
                    if (lotControl.ProductID.HasValue)
                    {
                        lotControl.DataLoading();
                        lotControl.SelectFirst();
                        txtPalletNo.EditValue = lotControl.GetPalletNo;
                        txtPalletNoRef.EditValue = lotControl.PalletNoRef;
                        txtInventory.EditValue = lotControl.GetInventory;
                        cboUnitInventory.EditValue = lotControl.GetUnitID;
                        itemConditionControl.ProductConditionID = lotControl.ProductConditionID;
                        cboQtyUnit.EditValue = lotControl.GetUnitID;
                    }


                    /////////////////////////////////////////////////////////////////
                    sp_FSES010_ShippingInstruction_LoadProductUnitInfo_Result prodInfo = BusinessClass.LoadProductUnitInfo(itemControl.ProductID.Value);
                    if (prodInfo != null)
                    {

                        txtInPackage.EditValue = prodInfo.NumberOfUnitLevel2;
                        cboUnitOfInPackage.EditValue = prodInfo.TypeOfUnitLevel2;
                        txtNetWeight.EditValue = prodInfo.NetWeight;
                        txtNetMeasure.EditValue = prodInfo.VolumeOfUnitLevel1;
                        cboTypeOfPackage.EditValue = prodInfo.PackageID;
                        //txtInventory.EditValue = prodInfo.Inventory;
                        //cboUnitInventory.EditValue = prodInfo.TypeOfUnitInventory;
                        txtWeight.EditValue = prodInfo.Weight;
                        txtMeasure.EditValue = prodInfo.M3;
                        cboQtyUnit.EditValue = prodInfo.TypeOfUnitLevel2;
                        /////gen cboQtyUnit
                        genQtyUnitcbo(prodInfo.TypeOfUnitLevel2);
                    }

                }
            
        }
        
        private void warehouseControl_EditValueChanged(object sender, EventArgs e)
        {
            shippingAreaControl.WarehouseID = warehouseControl.WarehouseID;
            shippingAreaControl.DataLoading();
            if (warehouseControl.WarehouseID.HasValue)
            {
                warehouseControl.EnableControl = false;
                lotControl.WarehouseID = warehouseControl.WarehouseID.Value;
            }
            else
            {
                warehouseControl.EnableControl = true;
            }
        }
        
        private void txtQty_EditValueChanged(object sender, EventArgs e)
        {
            //changeQtyOrCustomerOrder();
            decimal val;
            if (Decimal.TryParse(txtQty.Text, out val))
            {
                if (val < 0)
                    txtQty.EditValue = -val;
            }
            resetQty();
            
        }

        private void lotControl_EditValueChanged(object sender, EventArgs e)
        {
            txtPalletNo.EditValue = lotControl.GetPalletNo;
            txtPalletNoRef.EditValue = lotControl.PalletNoRef;
            txtInventory.EditValue = lotControl.GetInventory;
            //cboUnitInventory.EditValue = lotControl.GetUnitID;
            itemConditionControl.ProductConditionID = lotControl.ProductConditionID;
            //cboQtyUnit.EditValue = lotControl.GetUnitID;
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
                        txtInvoiceNo.EditValue = info.InvoiceNo;
                        txtBookingNo.EditValue = info.BookingNo;
                        txtVesselName1.EditValue = info.VesselName1;
                        txtVesselName2.EditValue = info.VesselName2;
                        txtAgent.EditValue = info.AgentOwner;
                        portOfDischarge.PortID = info.PortOfDischargeID;
                        portOfLoading.PortID = info.PortOfLoadingID;
                        finalDestinationControl.FinalDestinationID = info.FinalDestinationID;
                        txtRemark.EditValue = info.Remark;
                    }
                }
            }
        }

        private void cboQtyUnit_EditValueChanged(object sender, EventArgs e)
        {
            int? unitID = Rubix.Framework.DataUtil.Convert<int>(cboQtyUnit.EditValue);
            resetRatio(unitID);
            resetQty();
        }

        private void txtPickingDate_Enter(object sender, EventArgs e)
        {
            txtPickingDate.SelectAll();
        }
                
        private void gdvShippingInstruction_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                if (View.GetRowCellDisplayText(e.RowHandle, LotNo).Equals(string.Empty))
                {
                    e.Appearance.BackColor = Color.LightSalmon;
                }
            }
        }

        private void shippingCustomerControl1_EditValueChanged(object sender, EventArgs e)
        {
            finalDestinationControl.CustomerID = customerControl.CustomerID;
            finalDestinationControl.OwnerID = ownerControl.OwnerID;
            finalDestinationControl.DataLoading();
            if (this.ScreenMode != Common.eScreenMode.View && customerControl.CustomerID != null)
            {
                finalDestinationControl.Enabled = customerControl.CustomerID != null;
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('-'))
                e.Handled = true;
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            { 
                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), string.Empty)) == DialogButton.Yes)
                {
                    //add by pichaya s. 20130625
                    if (this.ScreenMode == Common.eScreenMode.Edit)
                    {
                        if (!iv.ValidateTicket(this.BusinessClass.ShipmentNo, this.BusinessClass.PickingNo))
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

            dlgHPCS030_UnplanPickingDialog_Load(this, new EventArgs());
            //clearControl();
            return base.OnCommandClear();
        }
        #endregion

        #region Generic Function
        private void InitControl()
        { 
            shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusId();
        }

        private void DataBinding()
        {
            if (BusinessClass.StatusName != null)
            {
                txtStatus.Text = BusinessClass.StatusName;
            }
            else 
            {
                txtStatus.Text = "New : By Screen Entry";
            }
            
            
            txtPickingNo.Text = BusinessClass.PickingNo;
            ownerControl.OwnerCode = BusinessClass.CustomerCode;
            shipmentControl.ShipmentNo = BusinessClass.ShipmentNo;
            warehouseControl.WarehouseCode = BusinessClass.WarehouseCode;
            shippingAreaControl.ShippingAreaID = BusinessClass.ShippingAreaID;


            customerControl.OwnerID = BusinessClass.OwnerID;
            customerControl.DataLoading();
            customerControl.CustomerID = BusinessClass.CustomerID;

            datePicking.EditValue = BusinessClass.PickingDate;
            if (BusinessClass.PickingDate != null)
            {
                txtPickingDate.Text = Convert.ToDateTime(BusinessClass.PickingDate).ToString("HH:mm");
            }
            dateVanning.EditValue = BusinessClass.VanningDate;
            if (BusinessClass.VanningDate != null)
            {
                txtVanningDate.Text = Convert.ToDateTime(BusinessClass.VanningDate).ToString("HH:mm");
            }
            dateTrans.EditValue = BusinessClass.TransportationDate;
            if (BusinessClass.TransportationDate != null)
            {
                txtTransDate.Text = Convert.ToDateTime(BusinessClass.TransportationDate).ToString("HH:mm");
            }
            dateCut.EditValue = BusinessClass.CutDate;
            if (BusinessClass.CutDate != null)
            {
                txtCusDate.Text = Convert.ToDateTime(BusinessClass.CutDate).ToString("HH:mm");
            }           
            ETDPort.EditValue = BusinessClass.ETD;
            if (BusinessClass.ETD != null)
            { 
                txtETD.Text = Convert.ToDateTime(BusinessClass.ETD).ToString("HH:mm");
            }
            ETADestination.EditValue = BusinessClass.ETA;
            if (BusinessClass.ETA != null)
            {
                txtETA.Text = Convert.ToDateTime(BusinessClass.ETA).ToString("HH:mm");
            }            

            txtAgentSeal.Text = BusinessClass.AgentSeal;            
            txtInspectSeal.Text = BusinessClass.InspectionSeal;            

            txtInvoiceNo.Text = BusinessClass.InvoiceNo;
            txtBookingNo.Text = BusinessClass.BookingNo;
            txtVesselName1.Text = BusinessClass.VesselName1;
            txtVesselName2.Text = BusinessClass.VesselName2;
            if (BusinessClass.PortOfLoadingID.HasValue)
                portOfLoading.SetPortID = BusinessClass.PortOfLoadingID.Value;
            txtPortLoadingAddress.Text = portOfLoading.GetPortAddress;
            portOfDischarge.SetPortCode = BusinessClass.PortOfDischargeCode;
            //txtPortDischargeAddress.Text = txtPortDischargeAddress.
            txtAgent.EditValue = BusinessClass.AgentOwner;
            txtHeaderRemark.EditValue = BusinessClass.Remark;

            ///finalDestinationControl
            finalDestinationControl.OwnerID = BusinessClass.OwnerID;
            finalDestinationControl.DataLoading();
            finalDestinationControl.FinalDestinationID = BusinessClass.FinalDestinationID;
            

            //transport Charge
            txtTransCharge.EditValue = transCharge;
            txtOutgoingCharge.EditValue = outgoingCharge;

            ///other Charge
            txtOtherCharge.EditValue = otherCharge;

            //Binding Statusbar
            string createDate = Convert.ToDateTime(BusinessClass.CreateDate).ToString(Common.FullDatetimeFormat);
            m_statusBarCreatedDate.Caption = createDate;
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

        private void SetDetail(sp_FSES011_ShippingInstruction_SearchDetail_Result data)
        {
            data.LineNo = txtLineNo.EditValue == null ? this._detail.Max(c => c.LineNo) + 1 : data.LineNo;
            data.SortedLineNo = txtLineNo.EditValue == null ? gdvShippingInstruction.RowCount : data.SortedLineNo;
            data.PONo = txtPONo.Text.Trim();
            data.ProductID = itemControl.ProductID;
            data.ProductCode = itemControl.ProductCode;
            data.ProductLongName = itemControl.ProductLongName;
            data.LotNo = lotControl.GetLotNo;
            data.OrderQty = DataUtil.Convert<decimal>(txtQty.EditValue);
            data.UnitOfQty = DataUtil.Convert<int>(cboQtyUnit.EditValue);
            data.Inventory = DataUtil.Convert<decimal>(txtInventory.EditValue);
            data.UnitOfInventory = DataUtil.Convert<int>(cboUnitInventory.EditValue);
            data.ProductConditionID = itemConditionControl.ProductConditionID;
            data.ProductConditionCode = itemConditionControl.ProductConditionCode;
            data.ProductConditionName = itemConditionControl.ProductConditionName;
            data.PalletNo = txtPalletNo.Text.Trim();
            data.TypeOfPackage = DataUtil.Convert<int>(cboTypeOfPackage.EditValue);
            data.InPackage = DataUtil.Convert<decimal>(txtInPackage.EditValue);
            data.UnitOfInPackage = DataUtil.Convert<int>(cboUnitOfInPackage.EditValue);
            data.NetWeight = DataUtil.Convert<decimal>(txtNetWeight.EditValue);
            data.Measurement = DataUtil.Convert<decimal>(txtNetMeasure.EditValue);
            data.Weight = DataUtil.Convert<decimal>(txtWeight.EditValue);
            data.M3 = DataUtil.Convert<decimal>(txtMeasure.EditValue);
            data.DetailRemark = txtRemark.Text.Trim();
            data.LocationID = lotControl.GetLocationID;
            // 6 Feb 2013: 
            //data.ReferenceNo = txtPONo.Text.Trim();
            // end 6 Feb 2013
            data.DatasourceFlag = 1;
            data.ReceivingNo = lotControl.GetReceivingNo;
            data.RecInstallment = lotControl.GetRecInstallment;
            data.RecLineNo = lotControl.GetRecLineNo;
        }

        private DataSet ToDataSet(IList<sp_FSES011_ShippingInstruction_SearchDetail_Result> list)
        {

            Type elementType = typeof(sp_FSES011_ShippingInstruction_SearchDetail_Result);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                t.Columns.Add(propInfo.Name, ColType);
            }

            //go through each property on T and add each value to the table
            foreach (sp_FSES011_ShippingInstruction_SearchDetail_Result item in list)
            {
                DataRow row = t.NewRow();

                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }

                t.Rows.Add(row);
            }

            return ds;
        }

        private void LoadDetail()
        {
            if (this.ScreenMode == Common.eScreenMode.Add)
            {
                _detail = new List<sp_FSES011_ShippingInstruction_SearchDetail_Result>();
            }
            else
            {
                _detail = BusinessClass.DataloadingDetail(BusinessClass.ShipmentNo, BusinessClass.PickingNo);
            }

            ////Binding Detail            
            //product control
            itemControl.OwnerID = ownerControl.OwnerID;
            itemControl.DataLoading();
            BindingSource bs = new BindingSource();
            bs.DataSource = _detail;
            grdShippingInstruction.DataSource = bs;

            Rubix.Framework.ControlUtil.SetBestWidth(gdvShippingInstruction);

        }

        private void LoadTransportChargeInfo()
        {
            if (this.ScreenMode == Common.eScreenMode.Add)
                l_transport = new List<sp_FSES012_TransportDetail_Search_Result>();
            else
                l_transport = BusinessClass.GetShippingTransDetail(BusinessClass.ShipmentNo, BusinessClass.PickingNo, BusinessClass.Installment);
            
        }

        private void LoadOtherChargeInfo()
        {
            if (this.ScreenMode == Common.eScreenMode.Add)
                OtherChargeList = new List<sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result>();
            else
                OtherChargeList = BusinessClass.LoadShippingOtherCharge(BusinessClass.ShipmentNo);

        }

        private void loadTransportCharge()
        {
            DataTable dtCharge = BusinessClass.loadTransportCharge(BusinessClass.ShipmentNo, BusinessClass.PickingNo, BusinessClass.Installment);
            if (dtCharge.Rows.Count != 0)
            {
                transCharge = Util.IsNullOrEmpty(dtCharge.Rows[0][0]) ? 0.0m : Convert.ToDecimal(dtCharge.Rows[0][0]);// dtCharge.Rows[0][0];
                outgoingCharge = (Util.IsNullOrEmpty(dtCharge.Rows[0][1]) ? 0.0m : Convert.ToDecimal(dtCharge.Rows[0][1]));
            }
        }

        private void loadOtherCharge()
        {
            DataTable dtCharge = BusinessClass.loadOtherCharge(BusinessClass.ShipmentNo);
            if (dtCharge.Rows.Count != 0)
            {
                otherCharge = (Util.IsNullOrEmpty(dtCharge.Rows[0][0]) ? 0.0m : Convert.ToDecimal(dtCharge.Rows[0][0]));// dtCharge.Rows[0][0];
            }
        }
        
        private void genQtyUnitcbo(int? qtyUnit)
        {
            List<sp_Common_ProductUnit_Result> qtyUnitList = BusinessClass.LoadProductUnit(qtyUnit == null ? null : DataUtil.Convert<int>(qtyUnit)
                                                                                            , itemControl.ProductID == null ? null : itemControl.ProductID);

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

        private void resetRatio(int? qtyUnit)
        {
            List<sp_Common_ProductUnit_Result> qtyUnitList = BusinessClass.LoadProductUnit(qtyUnit == null ? null : DataUtil.Convert<int>(qtyUnit)
                                                                                            , itemControl.ProductID == null ? null : itemControl.ProductID);
            
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
                
        private void SaveData()
        {
            BusinessClass.ShipmentNo = shipmentControl.ShipmentNo == null ? string.Empty : shipmentControl.ShipmentNo;
            BusinessClass.Installment = 1;
            BusinessClass.OwnerID = Convert.ToInt32(ownerControl.OwnerID);
            BusinessClass.CustomerCode = "";
            BusinessClass.CustomerName = "";
            BusinessClass.CustomerID = Convert.ToInt32(customerControl.CustomerID);
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
            BusinessClass.PortOfLoadingID = portOfLoading.GetPortID;
            BusinessClass.PortOfDischargeID = portOfDischarge.GetPortID;
            BusinessClass.FinalDestinationID = finalDestinationControl.GetFinalDestinationID;
            BusinessClass.FinalDestinationCode = "";
            BusinessClass.FinalDestinationLongName = "";
            BusinessClass.ETA = Rubix.Framework.DataUtil.CombineDateAndTime((DateTime)ETADestination.EditValue, Convert.ToDateTime(txtETA.EditValue));
            BusinessClass.AgentSeal = txtAgentSeal.Text.Trim();
            BusinessClass.InspectionSeal = txtInspectSeal.Text.Trim();
            BusinessClass.InvoiceNo = txtInvoiceNo.Text.Trim();
            BusinessClass.BookingNo = txtBookingNo.Text.Trim();
            BusinessClass.VesselName1 = txtVesselName1.Text.Trim();
            BusinessClass.VesselName2 = txtVesselName2.Text.Trim();
            BusinessClass.AgentOwner = txtAgent.Text.Trim();
            BusinessClass.PortOfLoadingID = portOfLoading.GetPortID;
            BusinessClass.PortOfDischargeID = portOfDischarge.GetPortID;
            BusinessClass.Remark = txtHeaderRemark.Text.Trim();
            //BusinessClass.ShipCompleteFlag = BusinessClass.ShipCompleteFlag;
            BusinessClass.ShipCompleteFlag = false;
            BusinessClass.ShipCompleteDate = BusinessClass.ShipCompleteDate;
            BusinessClass.CreateUser = AppConfig.UserLogin;
            BusinessClass.StatusName = "";
            //set to dataset
            DataSet ds = ToDataSet(_detail);
            BusinessClass.SaveShippingInstructionData(ds.GetXml(), gdvShippingInstruction.RowCount, _filePath, out outShipmentNo, out outPickingNo);
            if (outShipmentNo != string.Empty && outPickingNo != string.Empty)
            {
                BusinessClass.ShipmentNo = outShipmentNo;
                BusinessClass.PickingNo = outPickingNo;

                SaveTransport(outShipmentNo, outPickingNo);
                SaveOtherCharge(outShipmentNo, outPickingNo);

                //Book Stock////////////////////////////////
                //---BookStockBusinessClass.SaveBookStockData(BusinessClass.ShipmentNo, BusinessClass.PickingNo, BusinessClass.WarehouseID, BusinessClass.OwnerID);
                //Picking///////////////////////////////////
                //--PickingBusinessClass.UpdateStatusID(BusinessClass.ShipmentNo, BusinessClass.PickingNo);
                //Confirm Picking///////////////////////////
                Type elementType = typeof(sp_HPCS020_ConfirmPicking_GetPickingDetail_Result);
                DataSet dsConfirm = new DataSet();
                DataTable t = new DataTable();
                dsConfirm.Tables.Add(t);
                //add a column to table for each public property on T
                foreach (var propInfo in elementType.GetProperties())
                {
                    Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                    t.Columns.Add(propInfo.Name, ColType);
                }
                int seq = 1;
                foreach (sp_FSES011_ShippingInstruction_SearchDetail_Result line in _detail)
                {
                    DataRow row = t.NewRow();
                    row["LocationID"] = line.LocationID;
                    row["Quantity"] = line.OrderQty;
                    row["PickingQty"] = line.OrderQty;
                    row["PickingLineSeq"] = seq;
                    row["FullCapacityFlag"] = 0;
                    t.Rows.Add(row);

                    ConfirmPickingBusinessClass.OwnerID = Convert.ToInt32(ownerControl.OwnerID);
                    ConfirmPickingBusinessClass.WarehouseID = warehouseControl.WarehouseID;
                    ConfirmPickingBusinessClass.ShipmentNo = BusinessClass.ShipmentNo;
                    ConfirmPickingBusinessClass.PickingNo = BusinessClass.PickingNo;
                    ConfirmPickingBusinessClass.ProductID = line.ProductID;
                    ConfirmPickingBusinessClass.ProductConditionID = line.ProductConditionID;
                    ConfirmPickingBusinessClass.LineNo = line.LineNo;
                    ConfirmPickingBusinessClass.PickingLineSeq = seq;
                    ConfirmPickingBusinessClass.ActualQty = Convert.ToDecimal(line.OrderQty);
                    ConfirmPickingBusinessClass.UnitOfOrderQty = line.UnitOfQty;
                    ConfirmPickingBusinessClass.PalletNo = line.PalletNo;
                    ConfirmPickingBusinessClass.LotNo = line.LotNo;
                    seq++;

                    ConfirmPickingBusinessClass.Confirm(dsConfirm.GetXml());
                    ConfirmPickingBusinessClass.ResetConfirmFlag();
                    dsConfirm.Tables.Clear();
                    t.Rows.Clear();
                }
            }
        }

        private void SaveTransport(string shipmentNo ,string pickingNo)
        {
            foreach (sp_FSES012_TransportDetail_Search_Result item in TransportChargeList)
            {
                sp_FSES012_TransportDetail_Search_Result data = item;
                data.ShipmentNo = shipmentNo;
                data.PickingNo = pickingNo;
                data.Installment = 1;
                data.CreateUser = AppConfig.UserLogin;
                data.TruckCompanyCode = "";
                data.TransportTypeName = "";
                data.TruckCompanyCode = "";
                data.TruckCompanyName = "";
                data.TransportTypeCode = "";
                data.TransportTypeName = "";
                BusinessClass.SaveTransportDetail(data);
            }

            foreach (sp_FSES012_TransportDetail_Search_Result data in this.TransportDialog.DeleteList)
            {
                if (data.TransportSeq != 0)
                    BusinessClass.DeleteTransportDetail(data.TransportSeq);
            }

        }

        private void SaveOtherCharge(string shipmentNo,string pickingNo)
        {
            foreach (sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result item in OtherChargeList)
            {
                sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result data = item;
                data.ShipmentNo = shipmentNo;
                data.PickingNo = pickingNo;
                data.CreateUser = AppConfig.UserLogin;
                BusinessClass.SaveOtherChargeDetail(data);
            }

            foreach (sp_FSES012_ShippingOtherCharge_Other_Detail_Search_Result data in this.OtherChargeDialog.DeleteList)
            {
                if (data.OtherChargeID != 0)
                    BusinessClass.DeleteOtherChargeDetail(data.OtherChargeID);
            }

        }        

        private Boolean ValidateData()
        {
            Boolean noError = true;
               
            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;
            if (!ownerControl.ValidateControl())
            {
                noError = false;
            }
            customerControl.ErrorText = Common.GetMessage("I0249");
            customerControl.RequireField = true;
            if (!customerControl.ValidateControl())
            {
                noError = false;
            }
            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;
            if (!warehouseControl.ValidateControl())
            {
                noError = false;
            }
            shippingAreaControl.ErrorText = Common.GetMessage("I0334");
            shippingAreaControl.RequireField = true;
            if (!shippingAreaControl.ValidateControl()) 
            {
                noError = false;
            }

            finalDestinationControl.ErrorText = Common.GetMessage("I0335");
            finalDestinationControl.RequireField = true;
            if (!finalDestinationControl.ValidateControl())
            {
                noError = false;
            }
            
            if (ETADestination.Text == string.Empty)
            {
                errorProvider.SetError(ETADestination, Rubix.Screen.Common.GetMessage("I0136"));
                noError = false;
            }
            // 30 Jan 2013: add validate transaction date
            else if (false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(DataUtil.Convert<DateTime>(ETADestination.EditValue), true))
            {
                errorProvider.SetError(ETADestination, Rubix.Screen.Common.GetMessage("I0236"));
                noError = false;
            }
            // end 30 Jan 2013
            if (txtETA.Text == string.Empty)
            {
                errorProvider.SetError(txtETA, Rubix.Screen.Common.GetMessage("I0134"));
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
            // 30 Jan 2013: add validate transaction date
            else if (false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(DataUtil.Convert<DateTime>(datePicking.EditValue), true))
            {
                errorProvider.SetError(datePicking, Rubix.Screen.Common.GetMessage("I0236"));
                noError = false;
            }
            // end 30 Jan 2013
            ///check date and time            
            if (txtVanningDate.Text != string.Empty && dateVanning.EditValue == null)
            {
                errorProvider.SetError(dateVanning, Rubix.Screen.Common.GetMessage("I0134"));
                noError = false;
            }
            // 30 Jan 2013: add validate transaction date
            else if(dateVanning.EditValue != null
                && false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(DataUtil.Convert<DateTime>(dateVanning.EditValue), true))
            {
                errorProvider.SetError(dateVanning, Rubix.Screen.Common.GetMessage("I0236"));
                noError = false;
            }
            // end 30 Jan 2013
            if (txtTransDate.Text != string.Empty && dateTrans.EditValue == null)
            {
                errorProvider.SetError(dateTrans, Rubix.Screen.Common.GetMessage("I0134"));
                noError = false;
            }
            // 30 Jan 2013: add validate transaction date
            else if (dateTrans.EditValue != null
                && false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(DataUtil.Convert<DateTime>(dateTrans.EditValue), true))
            {
                errorProvider.SetError(dateTrans, Rubix.Screen.Common.GetMessage("I0236"));
                noError = false;
            }
            // end 30 Jan 2013
            if (txtCusDate.Text != string.Empty && dateCut.EditValue == null)
            {
                errorProvider.SetError(dateCut, Rubix.Screen.Common.GetMessage("I0134"));
                noError = false;
            }
            // 30 Jan 2013: add validate transaction date
            else if (dateCut.EditValue != null
                && false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(DataUtil.Convert<DateTime>(dateCut.EditValue), true))
            {
                errorProvider.SetError(dateCut, Rubix.Screen.Common.GetMessage("I0236"));
                noError = false;
            }
            // end 30 Jan 2013
            if (txtETD.Text != string.Empty && ETDPort.EditValue == null)
            {
                errorProvider.SetError(ETDPort, Rubix.Screen.Common.GetMessage("I0134"));
                noError = false;
            }
            // 30 Jan 2013: add validate transaction date
            else if (ETDPort.EditValue != null
                && false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(DataUtil.Convert<DateTime>(ETDPort.EditValue), true))
            {
                errorProvider.SetError(ETDPort, Rubix.Screen.Common.GetMessage("I0236"));
                noError = false;
            }
            // end 30 Jan 2013
            if (gdvShippingInstruction.RowCount == 0)
            {
                MessageDialog.ShowBusinessErrorMsg(this,Rubix.Screen.Common.GetMessage("I0112"));
                noError = false;
            }


            if (ETADestination.EditValue != null)
            {
                if (!DataUtil.IsTime(txtETA.Text))
                {
                    errorProvider.SetError(txtETA, Common.GetMessage("I0261", "Delivery"));
                    noError = false;
                }
                else
                    errorProvider.SetError(txtETA, string.Empty);
            }
            if (ETDPort.EditValue != null)
            {
                if (!DataUtil.IsTime(txtETD.Text))
                {
                    errorProvider.SetError(txtETD, Common.GetMessage("I0261", "ETD L/D Port"));
                    noError = false;
                }
                else
                    errorProvider.SetError(txtETD, string.Empty);
            }
            if (dateCut.EditValue != null)
            {
                if (!DataUtil.IsTime(txtCusDate.Text))
                {
                    errorProvider.SetError(txtCusDate, Common.GetMessage("I0261", "Cut"));
                    noError = false;
                }
                else
                    errorProvider.SetError(txtCusDate, string.Empty);
            }
            if (dateTrans.EditValue != null)
            {
                if (!DataUtil.IsTime(txtTransDate.Text))
                {
                    errorProvider.SetError(txtTransDate, Common.GetMessage("I0261", "Transportation"));
                    noError = false;
                }
                else
                    errorProvider.SetError(txtTransDate, string.Empty);
            }
            if (dateVanning.EditValue != null)
            {
                if (!DataUtil.IsTime(txtVanningDate.Text))
                {
                    errorProvider.SetError(txtVanningDate, Common.GetMessage("I0261", "Vanning"));
                    noError = false;
                }
                else
                    errorProvider.SetError(txtVanningDate, string.Empty);
            }
            if (datePicking.EditValue != null)
            {
                if (!DataUtil.IsTime(txtPickingDate.Text))
                {
                    errorProvider.SetError(txtPickingDate, Common.GetMessage("I0261", "Picking"));
                    noError = false;
                }
                else
                    errorProvider.SetError(txtPickingDate, string.Empty);
            }
            return noError;
        }

        private Boolean ValidateDetail()
        {
            Boolean noError = true;
               
            itemControl.ErrorText = Common.GetMessage("I0315");
            itemControl.RequireField = true;
            if (!itemControl.ValidateControl())
            {
                errorProvider.SetError(txtTransCharge, Common.GetMessage("I0315"));
                noError = false;
            }

            itemConditionControl.ErrorText = Common.GetMessage("I0026");
            itemConditionControl.RequireField = true;
            if (!itemConditionControl.ValidateControl())
            {
                errorProvider.SetError(itemConditionControl, Rubix.Screen.Common.GetMessage("I0026"));
                noError = false;
            }

            lotControl.ErrorText = Common.GetMessage("I0314");
            lotControl.RequireField = true;
            if (!lotControl.ValidateControl())
            {
                errorProvider.SetError(txtTransCharge, Common.GetMessage("I0314"));
                noError = false;
            }
            
            if (txtQty.Text.Trim() == string.Empty)
            {
                errorProvider.SetError(txtQty, Rubix.Screen.Common.GetMessage("I0026"));
                noError = false;
            }

            if (Convert.ToDecimal(txtQty.EditValue) == 0)
            {
                errorProvider.SetError(txtQty, Rubix.Screen.Common.GetMessage("I0026"));
                noError = false;
            }

            if (Convert.ToDecimal(txtQty.EditValue) > lotControl.GetAvailableQty)
            {
                //Order Qty must less than or equal Available Qty.
                errorProvider.SetError(txtQty, Rubix.Screen.Common.GetMessage("I0346"));
                noError = false;
            }
            
            if (cboQtyUnit.Text.Trim() == string.Empty)
            {
                errorProvider.SetError(txtQty, Rubix.Screen.Common.GetMessage("I0176"));
                noError = false;
            }
            
            // validate duplicate lot 
            for(int i =0; i < gdvShippingInstruction.RowCount; i++) 
            {
                sp_FSES011_ShippingInstruction_SearchDetail_Result detail = (sp_FSES011_ShippingInstruction_SearchDetail_Result)gdvShippingInstruction.GetRow(i);
                if (detail.ProductID == itemControl.ProductID
                    && detail.ProductConditionID == itemConditionControl.ProductConditionID
                    && detail.PalletNo.Equals(txtPalletNo.Text)
                    && detail.LotNo.Equals(lotControl.GetLotNo)
                    && (string.IsNullOrWhiteSpace(txtLineNo.Text) || detail.SortedLineNo != Int32.Parse(txtLineNo.Text)))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0347"));
                    noError = false;
                    break;
                }
            }

            return noError;
        }
        
        private Boolean ValidateTransportCharge()
        {
            Boolean noError = true;
            string messageId = string.Empty;
            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;
            if (!ownerControl.ValidateControl())
            {
                noError = false;
            }

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;
            if (!warehouseControl.ValidateControl())
            {
                noError = false;
            }

            finalDestinationControl.ErrorText = Common.GetMessage("I0335");
            finalDestinationControl.RequireField = true;
            if (!finalDestinationControl.ValidateControl())
            {
                noError = false;
            }            
            return noError;
        }
        
        private void clearDetailControl()
        {
            ControlUtil.ClearControlData(txtLineNo
                                              , txtPONo
                                              , txtPalletNo
                                              , txtPalletNoRef
                                              , txtInPackage
                                              , txtQty
                                              , txtInventory
                                              , txtNetWeight
                                              , txtNetMeasure
                                              , txtWeight
                                              , txtMeasure
                                              , txtRemark);
            itemControl.ClearData();
            lotControl.ClearData();
            itemConditionControl.ClearData();
            cboTypeOfPackage.EditValue = null;
            cboUnitOfInPackage.EditValue = null;
            cboQtyUnit.EditValue = null;
            cboUnitInventory.EditValue = null;
            grdUnit.DataSource = null;
            
            
        }

        private void clearDetailControlAdd()
        {

            ControlUtil.ClearControlData(txtLineNo
                                                  , txtPalletNo
                                                  , txtPalletNoRef
                                                  , txtQty
                                                  , txtInventory
                                                  , txtRemark);
            errorProvider.ClearErrors();
            //lotControl.ClearData();
            //itemConditionControl.ClearData();
            //cboUnitInventory.EditValue = null;
        }

        private void DeleteDetail(sp_FSES011_ShippingInstruction_SearchDetail_Result row)
        {
            long deletedLine = row.SortedLineNo.Value;
            //foreach (tbt_PickingDetail data in this.PickHeader.tbt_PickingDetail)
            //{
            //    //if (data.ShipmentNo == BusinessClass.ShipmentNo && data.LineNo == row.LineNo && data.Installment == BusinessClass.Installment)
            //    if (data.LineNo == deletedLine)
            //    {
            //        this.PickHeader.tbt_PickingDetail.Remove(data);
            //        gdvShippingInstruction.DeleteSelectedRows();
            //        break;
            //    }
            //}
            gdvShippingInstruction.DeleteSelectedRows();
            //foreach (tbt_PickingDetail data in this.PickHeader.tbt_PickingDetail)
            //{
            //    if (data.LineNo > deletedLine)
            //        data.LineNo--;
            //}
            foreach (sp_FSES011_ShippingInstruction_SearchDetail_Result data in _detail)
            {
                if (data.SortedLineNo > deletedLine)
                    data.SortedLineNo--;
            }
            gdvShippingInstruction.RefreshData();
        }
       
        private DateTime? shkDatetime(Object date,Object time)
        {
            if (date != null)
            {
                if (time != null && time.ToString() != string.Empty)
                {
                    return Rubix.Framework.DataUtil.CombineDateAndTime((DateTime)date, Convert.ToDateTime(time));
                }
                else
                {
                    return (DateTime)date;
                }
            }
            else
            {
                return null;
            }
        }
        
        private void ShowQtyLevel1()
        {
            bool canShow = BusinessClass.CanShowQtyLevel1();
            grdBandQty1.Visible = canShow;
            grdBandQty1.OptionsColumn.ShowInCustomizationForm = canShow;
        }
        #endregion
    }
}
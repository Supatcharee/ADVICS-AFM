/* 13 Feb 2013:
 * 1. add wait screen when search
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using CSI.Business.Master;
using Rubix.Framework;
using CSI.Business.Operation;
using CSI.Business.BusinessFactory.Common;
using CSI.Business.DataObjects;
namespace Rubix.Screen.Form.Operation.H_Picking
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Add, Permission.Export)]
    public partial class frmHPCS030_UnplanPicking : FormBase
    {
        #region Member
        private ShippingInstruction db;
        private Dialog.dlgHPCS031_UnplanPickingDialog m_Dialog = null;
        #endregion

        #region Enumeration
        private enum eColShippingHeader
        {
            StatusName	
            ,StatusID
			,ShipmentNo
			,PickingNo
            ,Installment
            ,Remark
            ,OwnerID
			,OwnerCode
			,OwnerName
			,CustomerCode
			,CustomerName
			,WarehouseID
			,WarehouseCode
			,WarehouseName
			,ShippingAreaID
			,ShippingAreaCode
			,ShippingAreaName
			,PickingDate
			,VanningDate
			,TransportationDate
			,CutDate
			,ETD
			,ETA
			,AgentSeal
			,InspectionSeal
			,InvoiceNo
			,BookingNo
			,VesselName1
			,VesselName2
			,AgentOwner
			,PortOfLoadingID
			,PortOfLoadingCode
			,PortOfLoadingName
			,PortOfDischargeID
			,PortOfDischargeCode
			,PortOfDischargeName
			,FinalDestinationID
			,FinalDestinationCode
			,FinalDestinationLongName
			,ShipCompleteFlag
            ,PalletQty
			,ShipCompleteDate
			,CreateDate
			,CreateUser
			,UpdateDate
			,UpdateUser
            ,CustomerID
        }
        #endregion

        #region Properties
        private ShippingInstruction BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ShippingInstruction();
                }
                return db;
            }
        }

        private Dialog.dlgHPCS031_UnplanPickingDialog Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgHPCS031_UnplanPickingDialog();
                }
                return m_Dialog;
            }
            set
            {
                m_Dialog = value;
            }
        }
        #endregion
        
        #region Constructor
        public frmHPCS030_UnplanPicking()
        {
            InitializeComponent();            
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl1);
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh, m_toolBarDelete, m_toolBarEdit);
        }
        #endregion

        #region Event Handler Function
        private void frmHPCS030_UnplanPicking_Load(object sender, EventArgs e)
        {
            try
            {
                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                shipmentControl.DataLoading();
                pickingControl.ShipmentNo = "-1";
                pickingControl.DataLoading();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    DataLoading();
                }
                
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                warehouseControl.ClearData();
                customerControl.ClearData();
                ownerControl.ClearData();
                shipmentControl.ClearData();
                pickingControl.ClearData();
                grdSearchResult.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void ownerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ownerControl.OwnerID != null)
                {
                    warehouseControl.OwnerID = ownerControl.OwnerID;
                    warehouseControl.DataLoading();
                    customerControl.OwnerID = ownerControl.OwnerID;
                    customerControl.DataLoading();
                    shipmentControl.OwnerID = ownerControl.OwnerID;
                    shipmentControl.DataLoading();
                    pickingControl.ShipmentNo = "-1";
                    pickingControl.DataLoading();
                }
                else
                {
                    customerControl.OwnerID = Common.GetDefaultOwnerID();
                    customerControl.DataLoading();
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                    shipmentControl.DataLoading();
                    pickingControl.ShipmentNo = "-1";
                    pickingControl.DataLoading();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void shipmentControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ownerControl.OwnerID != null)
                {
                    pickingControl.ShipmentNo = shipmentControl.ShipmentNo;
                    pickingControl.DataLoading();
                }
                else
                {
                    pickingControl.ShipmentNo = "-1";
                    pickingControl.DataLoading();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        #endregion

        #region Override Method
        public override bool OnCommandAdd()
        {
            try
            {
                OpenDialog(Common.eScreenMode.Add);
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }

        public override bool OnCommandView()
        {
            try
            {
                OpenDialog(Common.eScreenMode.View);
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        #endregion

        #region Generic Function
        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();

                grdSearchResult.DataSource = BusinessClass.DataLoadingUnplan(ownerControl.OwnerID, shipmentControl.ShipmentNo, pickingControl.PickingNo, customerControl.CustomerID, warehouseControl.WarehouseID);
                
                base.GridViewOnChangeLanguage(grdSearchResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }          
            finally 
            {
                this.CloseWaitScreen();
            }
        }

        private void OpenDialog(Common.eScreenMode ScreenMode)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if ((grdSearchResult.DefaultView).DataRowCount == 0 && ScreenMode != Common.eScreenMode.Add)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                }
                else
                {
                    //this.ShowWaitScreen();
                    if(ScreenMode != Common.eScreenMode.Add)
                    {
                        sp_HPCS030_UnplanPicking_SearchAll_Result getRow = gdvSearchResult.GetFocusedRow() as sp_HPCS030_UnplanPicking_SearchAll_Result;
                        BusinessClass.AgentOwner = getRow.AgentOwner;
                        BusinessClass.AgentSeal = getRow.AgentSeal;
                        BusinessClass.BookingNo = getRow.BookingNo;
                        //BusinessClass.CanShowQtyLevel1 = getRow.CanShowQtyLevel1;
                        //BusinessClass.CanUpload = getRow.CanUpload;
                        BusinessClass.CreateDate = Convert.ToDateTime(getRow.CreateDate);
                        BusinessClass.CreateUser = getRow.CreateUser;
                        BusinessClass.OwnerCode = getRow.OwnerCode;
                        BusinessClass.OwnerID = getRow.OwnerID;
                        BusinessClass.OwnerName = getRow.OwnerName;
                        BusinessClass.CustomerCode = getRow.CustomerCode;
                        BusinessClass.CustomerID = getRow.CustomerID;
                        BusinessClass.CustomerName = getRow.CustomerName;
                        BusinessClass.CutDate = getRow.CutDate;
                        BusinessClass.WarehouseCode = getRow.WarehouseCode;
                        BusinessClass.WarehouseID = getRow.WarehouseID;
                        //BusinessClass.WarehouseName = getRow.WarehouseName;
                        //BusinessClass.ETA = getRow.ETA;
                        BusinessClass.ETD = getRow.ETD;
                        BusinessClass.FinalDestinationCode = getRow.FinalDestinationCode;
                        BusinessClass.FinalDestinationID = getRow.FinalDestinationID;
                        BusinessClass.FinalDestinationLongName = getRow.FinalDestinationLongName;
                        BusinessClass.InspectionSeal = getRow.InspectionSeal;
                        BusinessClass.Installment = getRow.Installment;
                        BusinessClass.InvoiceNo = getRow.InvoiceNo;
                        //BusinessClass.IsProductExists = getRow.IsProductExists;
                        BusinessClass.PickingDate = getRow.PickingDate;
                        BusinessClass.PickingNo = getRow.PickingNo;
                        BusinessClass.PortOfDischargeCode = getRow.PortOfDischargeCode;
                        BusinessClass.PortOfDischargeID = getRow.PortOfDischargeID;
                        BusinessClass.PortOfDischargeName = getRow.PortOfDischargeName;
                        BusinessClass.PortOfLoadingCode = getRow.PortOfLoadingCode;
                        BusinessClass.PortOfLoadingID = getRow.PortOfLoadingID;
                        BusinessClass.PortOfLoadingName = getRow.PortOfLoadingName;
                        BusinessClass.Remark = getRow.Remark;
                        BusinessClass.ShipCompleteDate = getRow.ShipCompleteDate;
                        BusinessClass.ShipCompleteFlag = getRow.ShipCompleteFlag;
                        BusinessClass.ShipmentNo = getRow.ShipmentNo;
                        BusinessClass.ShippingAreaCode = getRow.ShippingAreaCode;
                        BusinessClass.ShippingAreaID = getRow.ShippingAreaID;
                        BusinessClass.ShippingAreaName = getRow.ShippingAreaName;
                        //BusinessClass.CustomerCode = getRow.CustomerCode;
                        BusinessClass.CustomerID = getRow.CustomerID;
                        //BusinessClass.CustomerName = getRow.CustomerName;
                        //BusinessClass.StatusID = getRow.StatusID;
                        BusinessClass.StatusName = getRow.StatusName;
                        BusinessClass.TransportationDate = getRow.TransportationDate;
                        BusinessClass.UpdateDate = getRow.UpdateDate;
                        BusinessClass.UpdateUser = getRow.UpdateUser;
                        BusinessClass.VanningDate = getRow.VanningDate;
                        BusinessClass.VesselName1 = getRow.VesselName1;
                        BusinessClass.VesselName2 = getRow.VesselName2;
                    }
                    
                    Dialog.ScreenMode = ScreenMode;
                    Dialog.BusinessClass = BusinessClass;
                    //this.CloseWaitScreen();

                    if (Dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        DataLoading();
                        MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), Dialog.BusinessClass.ShipmentNo));
                    }
                    Dialog = null;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.ToString());
            }
            finally
            {
                Cursor = Cursors.Default;
            }
                
        }

        private Boolean ValidateData()
        {
            errorProvider.ClearErrors();
            Boolean validate = true;
            // set require field
            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            //customerControl.ErrorText = Common.GetMessage("I0249");
            //customerControl.RequireField = true;

            validate &= ownerControl.ValidateControl();
            validate &= warehouseControl.ValidateControl();

            //if (false == customerControl.ValidateControl())
            //{
            //    validate = false;
            //}

            return validate;
        }
        #endregion      

    }
}
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
namespace Rubix.Screen.Form.Operation.F_ShippingEntry
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Add, Permission.Edit, Permission.Delete, Permission.Export)]
    public partial class frmFSES010_ShippingInstruction : FormBase
    {
        #region Member
        private ShippingInstruction db;
        private Dialog.dlgFSES011_ShippingInstruction m_Dialog = null;
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
        private Dialog.dlgFSES011_ShippingInstruction Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgFSES011_ShippingInstruction();
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
        public frmFSES010_ShippingInstruction()
        {
            InitializeComponent();            
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl1);
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);

            iv = new IdleValidator("tbt_PickingHeader", "UpdateDate", "ShipmentNo", "PickingNo");
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
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }
        public override bool OnCommandEdit()
        {
            try
            {
                if (gdvSearchResult.GetFocusedRow() != null)
                {
                    sp_FSES010_ShippingInstruction_SearchAll_Result data = ((sp_FSES010_ShippingInstruction_SearchAll_Result)gdvSearchResult.GetFocusedRow());

                    if (!iv.ValidateTicket(data.ShipmentNo, data.PickingNo))
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                        return false;
                    }
                    OpenDialog(Common.eScreenMode.Edit);
                }
                else
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }
        public override bool OnCommandView()
        {
            try
            {
                OpenDialog(Common.eScreenMode.View);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }
        public override bool OnCommandDelete()
        {
            try
            {
                if ((grdSearchResult.DefaultView).DataRowCount == 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }
                else
                {
                    if (gdvSearchResult.GetFocusedRow() == null)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                        return false;
                    }
                    BusinessClass.SelectData = gdvSearchResult.GetFocusedRow();
                    sp_FSES010_ShippingInstruction_SearchAll_Result data = ((sp_FSES010_ShippingInstruction_SearchAll_Result)gdvSearchResult.GetFocusedRow());

                    if (!iv.ValidateTicket(data.ShipmentNo, data.PickingNo))
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                        return false;
                    }
                    if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0002"), BusinessClass.ShipmentNo)) == DialogButton.Yes)
                    {
                        if (BusinessClass.StatusID == CSI.Business.Common.Status.NewShippingEntry)
                        {
                            BusinessClass.DeleteShippingData();
                            DataLoading();
                            MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0013"), BusinessClass.ShipmentNo));
                        }
                        else
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0254"), "ShipmentNo"));
                            return false;
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        #endregion

        #region Event Handler Function
        private void frmFSES010_ShippingInstruction_Load(object sender, EventArgs e)
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
                shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusIdNew();
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
                if (ValidateSearchCriteria())
                {
                    DataLoading();
                    if (gdvSearchResult.RowCount == 0)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                    }
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
                ownerControl.ClearData();
                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                shipmentControl.DataLoading();
                pickingControl.ShipmentNo = "-1";
                pickingControl.DataLoading();
                chkUnconfirm.Checked = true;
                grdSearchResult.DataSource = null;
                chkActual.Checked = true;
                //gdvSearchResult.Columns.Clear();
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
                ShowWaitScreen();
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
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                shipmentControl.CustomerID = customerControl.CustomerID;
                shipmentControl.DataLoading();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void shipmentControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
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
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void chkChange_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (chkUnconfirm.Checked)
                {
                    shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusIdNew();
                    shipmentControl.DataLoading();
                }
                else
                {
                    shipmentControl.StatusIdList = null;
                    shipmentControl.DataLoading();
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }           
        }

        private void ShippingPlanActual_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                grdSearchResult.DataSource = null;
                if (chkPlan.Checked)
                {
                    ControlUtil.EnableControl(false, m_toolBarEdit, m_toolBarDelete, m_toolBarAdd);                    
                }
                else if (chkActual.Checked)
                {
                    ControlUtil.EnableControl(true, m_toolBarEdit, m_toolBarDelete, m_toolBarAdd);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        #endregion
        
        #region Generic Function
        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();

                grdSearchResult.DataSource = BusinessClass.DataLoading(ownerControl.OwnerID
                    , shipmentControl.ShipmentNo
                    , pickingControl.PickingNo
                    , customerControl.CustomerID
                    , warehouseControl.WarehouseID
                    , (chkUnconfirm.Checked ? 0: 1)
                    , (chkActual.Checked ? 1 : 0));
                
                iv.ClearTicket();

                for (int i = 0; i < gdvSearchResult.RowCount; i++)
                {
                    iv.PushTicket(Convert.ToDateTime(gdvSearchResult.GetRowCellValue(i, "UpdateDate"))
                                  , gdvSearchResult.GetRowCellValue(i, "ShipmentNo").ToString()
                                  , gdvSearchResult.GetRowCellValue(i, "PickingNo").ToString());
                }
               
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
                    Dialog.IdleValidatorControl = this.iv;

                    //this.ShowWaitScreen();
                    if(ScreenMode != Common.eScreenMode.Add)
                    {
                        BusinessClass.SelectData = gdvSearchResult.GetFocusedRow();
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

        private bool ValidateSearchCriteria()
        {
            errorProvider.ClearErrors();
            bool validate = true;

            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            //customerControl.ErrorText = Common.GetMessage("I0249");
            //customerControl.RequireField = true;

            validate &= ownerControl.ValidateControl();
            validate &= warehouseControl.ValidateControl();
            //if (!customerControl.ValidateControl())
            //{
            //    validate = false;
            //}

            return validate;
        }
        #endregion      
    }
}
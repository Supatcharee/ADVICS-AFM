using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSI.Business.BusinessFactory.Operation;
using Rubix.Framework;
using CSI.Business.DataObjects;
using Rubix.Screen.Form.Operation.I_Shipping.Dialog;
using CSI.Business.BusinessFactory.Common;

namespace Rubix.Screen.Form.Operation.I_Shipping
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Confirm, Permission.Export)]
    public partial class frmISHS070_ConfirmReturnShipping : FormBase
    {

        #region Member
        private ConfirmReturn _bc = null;
        private dlgISHS071_ConfirmReturnShipping _dialog = null; 
        #endregion

        #region Properties
        public ConfirmReturn BusinessClass
        {
            get
            {
                if (_bc == null)
                    _bc = new ConfirmReturn();
                return _bc;
            }
        }
        public dlgISHS071_ConfirmReturnShipping Dialog
        {
            get
            {
                if (_dialog == null)
                    _dialog = new dlgISHS071_ConfirmReturnShipping();
                return _dialog;
            }
            set
            {
                _dialog = value;
            }
        } 
        #endregion

        #region Constructor
        public frmISHS070_ConfirmReturnShipping()
        {
            InitializeComponent();
            gdcShippingDate.DisplayFormat.FormatString = Common.FullDateFormat;
            gdcShippingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gdcQty2.DisplayFormat.FormatString = Common.QtyFormat;
            gdcQty2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl1);
            ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarAdd, m_toolBarDelete, m_toolBarRefresh, m_toolBarCancel, m_toolBarEdit, m_toolBarSave);
            ControlUtil.HiddenControl(false, m_toolBarConfirm);

            dtpShippingFrom.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtpShippingFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtpShippingFrom.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtpShippingFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtpShippingFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtpShippingFrom.Properties.Mask.EditMask = Common.FullDateFormat;
            dtpShippingTo.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtpShippingTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtpShippingTo.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtpShippingTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtpShippingTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtpShippingTo.Properties.Mask.EditMask = Common.FullDateFormat;

            //add by pichaya s. 20130627
            iv = new IdleValidator("tbt_ReturnPickingDetail", "UpdateDate", "ShipmentNo", "PickingNo", "Cast([LineNo] as varchar(10))");
        } 
        #endregion

        #region Override Method
        public override bool OnCommandConfirm()
        {
            sp_ISHS070_ReturnPick_Get_Result focus = (sp_ISHS070_ReturnPick_Get_Result)gdvSearchResult.GetFocusedRow();
            if (focus != null)
            {
                //add by pichaya s. 20130625
                if (!iv.ValidateTicket(focus.ShipmentNo, focus.PickingNo, focus.LineNo.ToString()))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                    return false;
                }
                this.Dialog.IdleValidatorControl = iv;
                this.Dialog.ShipmentNo = focus.ShipmentNo;
                this.Dialog.PickingNo = focus.PickingNo;
                this.Dialog.ItemID = focus.ProductID;
                this.Dialog.OwnerID = focus.OwnerID;
                this.Dialog.WarehouseID = focus.WarehouseID;
                this.Dialog.PalletNo = focus.PalletNo;
                if (this.Dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    MessageDialog.ShowInformationMsg(Common.GetMessage("I0272"));
                }
               
                DataLoading();
                Dialog = null;
            }
            else
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
            return base.OnCommandConfirm();
        } 
        #endregion

        #region Event Handler
         private void frmISHS070_ConfirmReturnShipping_Load(object sender, EventArgs e)
        {
            try
            {
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                shipmentControl.DataLoading();
                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();
                pickingControl.ShipmentNo = "-1";
                pickingControl.DataLoading();

                dtpShippingFrom.EditValue = ControlUtil.GetStartDate();
                dtpShippingTo.EditValue = ControlUtil.GetEndDate();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }       
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
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
                ShowWaitScreen();
                ControlUtil.ClearControlData(this.groupControl1);
                ownerControl.ClearData();
                grdSearchResult.DataSource = null;

                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                shipmentControl.DataLoading();
                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();
                pickingControl.ShipmentNo = "-1";
                pickingControl.DataLoading();

                dtpShippingFrom.EditValue = ControlUtil.GetStartDate();
                dtpShippingTo.EditValue = ControlUtil.GetEndDate();

                CloseWaitScreen();
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
                    shipmentControl.OwnerID = ownerControl.OwnerID;
                    shipmentControl.DataLoading();
                    customerControl.OwnerID = ownerControl.OwnerID;
                    customerControl.DataLoading();
                }
                else
                {
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                    shipmentControl.DataLoading();
                    customerControl.OwnerID = Common.GetDefaultOwnerID();
                    customerControl.DataLoading();
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
                if (!string.IsNullOrEmpty(shipmentControl.ShipmentNo))
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

        private void dtpShippingFrom_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                shipmentControl.ShippingDateFrom = DataUtil.Convert<DateTime>(dtpShippingFrom.EditValue);
                shipmentControl.DataLoading();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void dtpShippingTo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                shipmentControl.ShippingDateTo = DataUtil.Convert<DateTime>(dtpShippingTo.EditValue);
                shipmentControl.DataLoading();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        #endregion

        #region Genneric Function
        private bool ValidateData()
        {
            bool result = true;
            // set require field
            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            //customerControl.ErrorText = Common.GetMessage("I0249");
            //customerControl.RequireField = true;

            result &= ownerControl.ValidateControl();
            result &= warehouseControl.ValidateControl();
            //result &= customerControl.ValidateControl();
            return result;
        }

        private void DataLoading()
        {
            ShowWaitScreen();
            List<sp_ISHS070_ReturnPick_Get_Result> lst = BusinessClass.Search(ownerControl.OwnerID, warehouseControl.WarehouseID, shipmentControl.ShipmentNo, pickingControl.PickingNo, (DateTime?)dtpShippingFrom.EditValue, (DateTime?)dtpShippingTo.EditValue);
            grdSearchResult.DataSource = lst;

            if (lst.Count > 0)
            {
                gdcShippingDate.DisplayFormat.FormatString = Common.FullDateFormat;
                gdcQty2.DisplayFormat.FormatString = Common.QtyFormat;

                iv.ClearTicket();
                for (int i = 0; i < gdvSearchResult.RowCount; i++)
                {
                    iv.PushTicket(Convert.ToDateTime(gdvSearchResult.GetRowCellValue(i, "UpdateDate"))
                                  , gdvSearchResult.GetRowCellValue(i, "ShipmentNo").ToString()
                                  , gdvSearchResult.GetRowCellValue(i, "PickingNo").ToString()
                                  , gdvSearchResult.GetRowCellValue(i, "LineNo").ToString());

                }
            }

            base.GridViewOnChangeLanguage(grdSearchResult);
            CloseWaitScreen();
        }
        #endregion

    }
}

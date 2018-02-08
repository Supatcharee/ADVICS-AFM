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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using CSI.Business.DataObjects;
using DevExpress.XtraGrid.Views.Grid;
namespace Rubix.Screen.Form.Operation.L_WorkProgress
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Export)]
    public partial class frmLWPS020_ShippingProgress : FormBase
    {
        #region Enumeration
        private enum eColumns
        { 
            Date
            , ShipmentNo
            , PickingNo
            , ShippingAreaCode
            , ShippingAreaName
            , InstructionDate
            , StockControlDate
            , PickInstDate
            , PickingDate
            , ShippingDate
            , TransportationDate
            , IsOrderCancelStatus
            , Installment
        }
        private enum eColumnSummary
        {
            TypeOrder
            ,
            Type
                ,
            Measurement
                ,
            Weight
                ,
            Order
                ,
            Line
                , Qty
        }
        #endregion

        #region Member
        private ShippingProgress db;
        private Rubix.Screen.Form.Operation.F_ShippingEntry.Dialog.dlgFSES011_ShippingInstruction m_Dialog = null;
        private Color ORDER_CANCEL_STATUS_COLOR = Color.Red;
        #endregion

        #region Properties
        private ShippingProgress BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ShippingProgress();
                }
                return db;
            }
        }
        private Rubix.Screen.Form.Operation.F_ShippingEntry.Dialog.dlgFSES011_ShippingInstruction Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    m_Dialog = new Rubix.Screen.Form.Operation.F_ShippingEntry.Dialog.dlgFSES011_ShippingInstruction();
                }
                m_Dialog.ShowActual = true;
                return m_Dialog;
            }
            set
            {
                m_Dialog = value;
            }

        }
        #endregion

        #region Constructor
        public frmLWPS020_ShippingProgress()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarEdit, m_toolBarDelete, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
            base.GridControlSearchResult = new GridControl[] { grdSearchResult, grdTotal };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl3);
        }
        #endregion

        #region Event Handler Function
        private void frmLWPS020_ShippingProgress_Load(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
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
                    finalDestinationControl.OwnerID = ownerControl.OwnerID;
                    finalDestinationControl.DataLoading();
                    shipmentControl.OwnerID = ownerControl.OwnerID;
                    shipmentControl.DataLoading();
                }
                else
                {
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    customerControl.OwnerID = Common.GetDefaultOwnerID();
                    customerControl.DataLoading();
                    finalDestinationControl.OwnerID = Common.GetDefaultOwnerID();
                    finalDestinationControl.DataLoading();
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

        private void warehouseControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (warehouseControl.WarehouseID != null)
                {
                    shippingAreaControl.WarehouseID = warehouseControl.WarehouseID;
                    shippingAreaControl.DataLoading();
                }
                else
                {
                    shippingAreaControl.WarehouseID = Common.GetDefaultWarehouseID();
                    shippingAreaControl.DataLoading();
                }
                CloseWaitScreen();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
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
                if (true == ValidateDataWhenSearch())
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

        private void gdvSearchResult_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            // set back color
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                Boolean? statusID = DataUtil.Convert<Boolean>(View.GetRowCellValue(e.RowHandle, View.Columns[(int)eColumns.IsOrderCancelStatus]));
                e.Appearance.Options.UseBackColor = true;
                if (statusID != null && statusID.Value)
                {
                    e.Appearance.BackColor = ORDER_CANCEL_STATUS_COLOR;
                }
            }
        }
        #endregion

        #region Override Method

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

        private void ClearAll()
        {
            ShowWaitScreen();
            ownerControl.ClearData();
            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();
            customerControl.OwnerID = Common.GetDefaultOwnerID();
            customerControl.DataLoading();
            finalDestinationControl.OwnerID = Common.GetDefaultOwnerID();
            finalDestinationControl.DataLoading();
            shipmentControl.OwnerID = Common.GetDefaultOwnerID();
            shipmentControl.DataLoading();
            pickingControl.ShipmentNo = "-1";
            pickingControl.DataLoading();

            ControlUtil.ClearControlData(this.Controls);

            grdSearchResult.DataSource = null;
            grdTotal.DataSource = null;

            dtFromETADate.EditValue = ControlUtil.GetStartDate();
            dtToETADate.EditValue = ControlUtil.GetEndDate();

            CloseWaitScreen();
        }
        
        private Boolean ValidateDataWhenSearch()
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
            //validate &= customerControl.ValidateControl();

            return validate;
        }

        private void DataLoading()
        {
            try
            {
                if (!DesignMode)
                {
                    this.ShowWaitScreen();
                    grdSearchResult.DataSource = BusinessClass.DataLoading(ownerControl.OwnerID
                                                                        , warehouseControl.WarehouseID
                                                                        , portOfDischarge.PortID
                                                                        , finalDestinationControl.FinalDestinationID
                                                                        , string.IsNullOrWhiteSpace(shipmentControl.ShipmentNo) ? null : shipmentControl.ShipmentNo
                                                                        , pickingControl.PickingNo
                                                                        , shippingAreaControl.ShippingAreaID
                                                                        , DataUtil.Convert<DateTime>(dtTransportDate.EditValue)
                                                                        , DataUtil.Convert<DateTime>(dtPickingDate.EditValue)
                                                                        , DataUtil.Convert<DateTime>(dtShippingDate.EditValue)
                                                                        , DataUtil.Convert<DateTime>(dtFromETADate.EditValue)
                                                                        , DataUtil.Convert<DateTime>(dtToETADate.EditValue)
                                                                        , txtInvoiceNo.Text
                                                                        , customerControl.CustomerID
                                                                    );


                    grdTotal.DataSource = BusinessClass.GetSummary(ownerControl.OwnerID
                                                                    , warehouseControl.WarehouseID
                                                                    , portOfDischarge.PortID
                                                                    , finalDestinationControl.FinalDestinationID
                                                                    , string.IsNullOrWhiteSpace(shipmentControl.ShipmentNo) ? null : shipmentControl.ShipmentNo
                                                                    , pickingControl.PickingNo
                                                                    , shippingAreaControl.ShippingAreaID
                                                                    , DataUtil.Convert<DateTime>(dtTransportDate.EditValue)
                                                                    , DataUtil.Convert<DateTime>(dtPickingDate.EditValue)
                                                                    , DataUtil.Convert<DateTime>(dtShippingDate.EditValue)
                                                                    , DataUtil.Convert<DateTime>(dtFromETADate.EditValue)
                                                                    , DataUtil.Convert<DateTime>(dtToETADate.EditValue)
                                                                    , txtInvoiceNo.Text
                                                                    , customerControl.CustomerID
                                                                );

                    if (gdvSearchResult.RowCount != 0)
                    {
                        ControlUtil.HiddenControl(true, gdvSearchResult, (int)eColumns.Installment, (int)eColumns.IsOrderCancelStatus);
                        ControlUtil.HiddenControl(true, gdvTotal, (int)eColumnSummary.TypeOrder);
                    }
                }

                base.GridViewOnChangeLanguage(grdSearchResult);
                base.GridViewOnChangeLanguage(grdTotal);
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
                if (ScreenMode == Common.eScreenMode.View)
                {
                    // no data found
                    if (gdvSearchResult.RowCount == 0)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                        return;
                    }

                    sp_LWPS020_ShippingProgress_SearchAll_Result data =
                        (sp_LWPS020_ShippingProgress_SearchAll_Result)gdvSearchResult.GetFocusedRow();


                    Dialog.ScreenMode = ScreenMode;
                    Dialog.BusinessClass = new ShippingInstruction();
                    List<sp_FSES010_ShippingInstruction_SearchAll_Result> shp = Dialog.BusinessClass.DataLoading(null, data.ShipmentNo, data.PickingNo, null, null, 1,1);
                    if (shp != null && shp.Count > 0)
                    {
                        Dialog.BusinessClass.ResultData = shp[0];
                        Dialog.ShowDialog(this);
                    }
                  
                }
                Dialog = null;
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
        #endregion      

    }
}
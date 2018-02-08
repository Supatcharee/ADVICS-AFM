/*
 * 13 Feb 2013:
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
using CSI.Business.Operation;
using Rubix.Framework;
using DevExpress.XtraEditors.Repository;
using CSI.Business.DataObjects;
using DevExpress.XtraGrid.Views.Grid;
using System.Xml;
namespace Rubix.Screen.Form.Operation.L_WorkProgress
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Export)]
    public partial class frmLWPS010_StoringProgress : FormBase
    {
        #region Enumeration
        private enum eColumns
        { 
            Date
            //, DistributionCode
            //, CustomerCode
            , ReceivingNo
            , ReferenceNo
            , SupplierCode
            , SupplierName
            , InstructionDate
            , ReceivingDate
            , TransitDate
            , Installment
            , IsOrderCancelStatus
        }
        private enum eColumnSummary
        { 
            TypeOrder
            , Type
            , Measurement
            , Weight
            , Order
            , Line
            , Qty
        }
        #endregion

        #region Member
        private ReceivingProgress db;
        private Rubix.Screen.Form.Operation.B_ReceivingEntry.Dialog.dlgBRES010_ReceivingEntry m_Dialog = null;
        private Color ORDER_CANCEL_STATUS_COLOR = Color.Red;
        #endregion

        #region Properties
        private ReceivingProgress BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ReceivingProgress();
                }
                return db;
            }
        }
        private Rubix.Screen.Form.Operation.B_ReceivingEntry.Dialog.dlgBRES010_ReceivingEntry Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    m_Dialog = new Rubix.Screen.Form.Operation.B_ReceivingEntry.Dialog.dlgBRES010_ReceivingEntry();
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

        #region Constant
        const string DATE_EDIT_FORMAT = "dd/MM/yyyy";
        #endregion

        #region Constructor
        public frmLWPS010_StoringProgress()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarEdit, m_toolBarDelete, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
            base.GridControlSearchResult = new GridControl[] { grdSearchResult, grdTotal };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl3);
        }
        #endregion

        #region Event Handler Function
        private void frmLWPS010_StoringProgress_Load(object sender, EventArgs e)
        {
           InitControl();
        }

        private void onwerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (ownerControl.OwnerID != null)
                {
                    warehouseControl.OwnerID = ownerControl.OwnerID;
                    warehouseControl.DataLoading();
                    supplierControl.OwnerID = ownerControl.OwnerID;
                    supplierControl.DataLoading();
                }
                else
                {
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    supplierControl.OwnerID = Common.GetDefaultOwnerID();
                    supplierControl.DataLoading();
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex); ;
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

                    sp_LWPS010_ReceivingProgress_SearchAll_Result data =
                        (sp_LWPS010_ReceivingProgress_SearchAll_Result)gdvSearchResult.GetFocusedRow();

                    Dialog.ReceivingNo = data.ReceivingNo;
                    Dialog.Installment = data.Installment.Value;
                    Dialog.OwnerID = data.OwnerID;
                    Dialog.ScreenMode = ScreenMode;
                    Dialog.BusinessClass = new ReceivingEntry();

                    Dialog.ShowDialog(this);
                    
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

        private void DataLoading()
        {
            try
            {
                if (!DesignMode)
                {
                    this.ShowWaitScreen();
                    grdSearchResult.DataSource = BusinessClass.DataLoading(ownerControl.OwnerID
                                                                           ,warehouseControl.WarehouseID
                                                                           ,supplierControl.SupplierID
                                                                           ,txtReceivingNo.EditValue == null ? null : Convert.ToString(txtReceivingNo.EditValue)
                                                                           ,DataUtil.Convert<DateTime>(dtArrivalDate.EditValue)
                                                                           ,DataUtil.Convert<DateTime>(dtReceivingDate.EditValue)
                                                                           ,DataUtil.Convert<DateTime>(dtStoringDate.EditValue)
                                                                           ,DataUtil.Convert<DateTime>(dtInstructionDate.EditValue)
                                                                           ,txtReferenceNo.EditValue == null ? null : txtReferenceNo.EditValue.ToString());
                    grdTotal.DataSource = BusinessClass.LoadSummary(ownerControl.OwnerID
                                                                    ,warehouseControl.WarehouseID
                                                                    ,supplierControl.SupplierID
                                                                    ,txtReceivingNo.EditValue == null ? null : Convert.ToString(txtReceivingNo.EditValue)
                                                                    ,DataUtil.Convert<DateTime>(dtArrivalDate.EditValue)
                                                                    ,DataUtil.Convert<DateTime>(dtReceivingDate.EditValue)
                                                                    ,DataUtil.Convert<DateTime>(dtStoringDate.EditValue)
                                                                    ,DataUtil.Convert<DateTime>(dtInstructionDate.EditValue)
                                                                    ,txtReferenceNo.EditValue == null ? null : txtReferenceNo.EditValue.ToString());


                    if (gdvSearchResult.RowCount != 0)
                    {                        
                        InitGrid();
                    }

                    base.GridViewOnChangeLanguage(grdSearchResult);
                    base.GridViewOnChangeLanguage(grdTotal);
                }
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

        private void InitControl()
        {
            // set dateEdit format
            dtArrivalDate.Properties.Mask.EditMask = DATE_EDIT_FORMAT;
            dtReceivingDate.Properties.Mask.EditMask = DATE_EDIT_FORMAT;
            dtStoringDate.Properties.Mask.EditMask = DATE_EDIT_FORMAT;
            dtInstructionDate.Properties.Mask.EditMask = DATE_EDIT_FORMAT;
            dtArrivalDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtReceivingDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtStoringDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtInstructionDate.Properties.Mask.UseMaskAsDisplayFormat = true;

            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();
            supplierControl.OwnerID = Common.GetDefaultOwnerID();
            supplierControl.DataLoading();
        }

        private void ClearAll()
        {
            ownerControl.ClearData();

            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();
            supplierControl.OwnerID = Common.GetDefaultOwnerID();
            supplierControl.DataLoading();

            ControlUtil.ClearControlData(this.Controls);
            grdSearchResult.DataSource = null;
            grdTotal.DataSource = null;
        }

        private Boolean ValidateDataWhenSearch()
        {
            errorProvider.ClearErrors();
            Boolean validate = true;
            // set require field
            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;
            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;
            //supplierControl.ErrorText = Common.GetMessage("I0300");
            //supplierControl.RequireField = true;

            validate &= ownerControl.ValidateControl();
            validate &= warehouseControl.ValidateControl();
            //validate &= supplierControl.ValidateControl();

            return validate;
        }

        private void InitGrid()
        {
            // set format column
            gdvSearchResult.Columns[(int)eColumns.Date].ColumnEdit = arrivalDateTextEdit;
            gdvSearchResult.Columns[(int)eColumns.InstructionDate].ColumnEdit = InstructionDateTextEdit;
            gdvSearchResult.Columns[(int)eColumns.ReceivingDate].ColumnEdit = receivingDateTextEdit;
            gdvSearchResult.Columns[(int)eColumns.TransitDate].ColumnEdit = TransitDateTextEdit;

            // hide unused column
            //gdvSearchResult.Columns[(int)eColumns.Installment].Visible = false;
            //gdvSearchResult.Columns[(int)eColumns.IsOrderCancelStatus].Visible = false;
            //gdvTotal.Columns[(int)eColumnSummary.TypeOrder].Visible = false;
            ControlUtil.HiddenControl(true, gdvSearchResult, (int)eColumns.Installment
                , (int)eColumns.IsOrderCancelStatus);

            ControlUtil.HiddenControl(true, gdvTotal, (int)eColumnSummary.TypeOrder);

            // change caption
           // gdvTotal.Columns[(int)eColumnSummary.Measurement].Caption = "Measurement (M3)";
           // gdvTotal.Columns[(int)eColumnSummary.Weight].Caption = "Weight (Kg)";
        }
        #endregion      
    }
}
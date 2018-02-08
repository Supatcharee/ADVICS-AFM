/*
 20121219:
 * 1. set format cell qty
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
using CSI.Business.DataObjects;

namespace Rubix.Screen.Form.Operation.C_Receiving
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Export)]
    public partial class frmCRCS010_CollectionASN : FormBase
    {
        #region Member
        private CollectionASN db;
        #endregion

        #region Properties
        private CollectionASN BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new CollectionASN();
                }
                return db;
            }
        }
        #endregion
        
        #region Constructor
        public frmCRCS010_CollectionASN()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarEdit, m_toolBarDelete, m_toolBarView, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl1);
            dtArrivalDateFrom.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtArrivalDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtArrivalDateFrom.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtArrivalDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtArrivalDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtArrivalDateFrom.Properties.Mask.EditMask = Common.FullDateFormat;
            dtArrivalDateTo.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtArrivalDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtArrivalDateTo.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtArrivalDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtArrivalDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtArrivalDateTo.Properties.Mask.EditMask = Common.FullDateFormat;

            gdcArrivalDate.DisplayFormat.FormatString = Common.FullDateFormat;
            gdcArrivalDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
        }
        #endregion

        #region Override Method

        #endregion

        #region Event Handler Function
        private void frmCRCS010_CollectionASN_Load(object sender, EventArgs e)
        {
            try
            {
                CSI.Business.Common.ProductCondition condition = new CSI.Business.Common.ProductCondition();
                repCondition.DataSource = condition.DataLoading();
                repCondition.DisplayMember = "ProductConditionName";
                repCondition.ValueMember = "ProductConditionID";

                CSI.Business.Common.Packaging package = new CSI.Business.Common.Packaging();
                repPack.DataSource = package.DataLoading();
                repPack.DisplayMember = "PackageName";
                repPack.ValueMember = "PackageID";

                CSI.Business.Master.TypeOfUnit unit = new CSI.Business.Master.TypeOfUnit();
                repUnit.DataSource = unit.DataLoading(string.Empty, string.Empty);
                repUnit.DisplayMember = "UnitName";
                repUnit.ValueMember = "UnitID";

                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                supplierControl.OwnerID = Common.GetDefaultOwnerID();
                supplierControl.DataLoading();

                dtArrivalDateFrom.EditValue = ControlUtil.GetStartDate();
                dtArrivalDateTo.EditValue = ControlUtil.GetEndDate();
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
                if (ValidateSearchCriteria())
                {
                    DataLoading();
                    if (gdvSearchResult.RowCount <= 0)
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
                ControlUtil.ClearControlData(this.Controls);
                dtArrivalDateFrom.EditValue = ControlUtil.GetStartDate();
                dtArrivalDateTo.EditValue = ControlUtil.GetEndDate();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                supplierControl.OwnerID = Common.GetDefaultOwnerID();
                supplierControl.DataLoading();
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

        private void gdvSearchResult_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            e.Handled = true;
            if (e.Column == gdcStatus || e.Column == gdcReceivingNo || e.Column == gdcArrivalDate || e.Column == gdcInstallment || e.Column == gdcSupplierCode || e.Column == gdcSupplierLongName)
            {
                sp_CRCS010_CollectionASN_SearchAll_Result firstRow = (sp_CRCS010_CollectionASN_SearchAll_Result)gdvSearchResult.GetRow(e.RowHandle1);
                sp_CRCS010_CollectionASN_SearchAll_Result secondRow = (sp_CRCS010_CollectionASN_SearchAll_Result)gdvSearchResult.GetRow(e.RowHandle2);

                if (firstRow.ReceivingNo.Equals(secondRow.ReceivingNo) && 
                    firstRow.Status.Equals(secondRow.Status) && 
                    firstRow.ArrivalDate.Equals(secondRow.ArrivalDate) &&
                    firstRow.SupplierCode.Equals(secondRow.SupplierCode) &&
                    firstRow.SupplierLongName.Equals(secondRow.SupplierLongName) && 
                    e.Column != gdcInstallment && 
                    e.Column != gdcArrivalDate )
                {
                    e.Merge = true;
                    
                }
                else if (firstRow.ReceivingNo.Equals(secondRow.ReceivingNo) && 
                         firstRow.Status.Equals(secondRow.Status) && 
                        firstRow.Installment.Equals(secondRow.Installment) &&
                        firstRow.SupplierCode.Equals(secondRow.SupplierCode) &&
                        firstRow.SupplierLongName.Equals(secondRow.SupplierLongName) && 
                        (e.Column == gdcInstallment || e.Column == gdcArrivalDate))
                {
                    e.Merge = true;
                }
                else
                    e.Merge = false;
            }
            else
                e.Merge = false;
        }
        #endregion
        
        #region Generic Function
        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                grdSearchResult.DataSource = BusinessClass.DataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID,
                                                                        DataUtil.Convert<DateTime>(dtArrivalDateFrom.EditValue), 
                                                                        DataUtil.Convert<DateTime>(dtArrivalDateTo.EditValue), 
                                                                        txtSlipNo.Text.Trim(), truckCompanyControl.TruckCompanyID, 
                                                                        supplierControl.SupplierID);
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

        private bool ValidateSearchCriteria()
        {
            errorProvider.ClearErrors();
            bool validate = true;

            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            //Cancel Date : 3/3/2015 
            //supplierControl.ErrorText = Common.GetMessage("I0300");
            //supplierControl.RequireField = true;

            if (!ownerControl.ValidateControl())
            {
                validate = false;
            }
            if (!warehouseControl.ValidateControl())
            {
                validate = false;
            }
            //if (!supplierControl.ValidateControl())
            //{
            //    validate = false;
            //}

            return validate;
        }
        #endregion      

    }
}
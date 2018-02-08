/*
 06 Feb 2013:
 * 1. clear dialog variable after using dialog
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
using CSI.Business.BusinessFactory.Common;

namespace Rubix.Screen.Form.Operation.B_ReceivingEntry
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Add, Permission.Edit, Permission.Delete, Permission.Export)]
    public partial class frmBRES010_ReceivingEntry : FormBase
    {
        #region Member
        private ReceivingEntry db;
        private Dialog.dlgBRES010_ReceivingEntry m_Dialog = null;
        #endregion

        #region Properties
        private ReceivingEntry BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ReceivingEntry();
                }
                return db;
            }
        }
        private Dialog.dlgBRES010_ReceivingEntry Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgBRES010_ReceivingEntry();
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
        public frmBRES010_ReceivingEntry()
        {
            InitializeComponent();
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            ControlUtil.HiddenControl(true, m_toolBarCancel, m_toolBarRefresh, m_toolBarSave);
            base.SetExpandGroupControl(groupControl1);
            deArrivalDateFrom.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            deArrivalDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            deArrivalDateFrom.Properties.EditFormat.FormatString = Common.FullDateFormat;
            deArrivalDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            deArrivalDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            deArrivalDateFrom.Properties.Mask.EditMask = Common.FullDateFormat;
            deArrivalDateTo.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            deArrivalDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            deArrivalDateTo.Properties.EditFormat.FormatString = Common.FullDateFormat;
            deArrivalDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            deArrivalDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            deArrivalDateTo.Properties.Mask.EditMask = Common.FullDateFormat;

            iv = new IdleValidator("tbt_ReceivingInstructionHeader", "UpdateDate", "ReceivingNo", "Installment");
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
                if (gdvSearchResult.RowCount > 0)
                {
                    DataRow data = gdvSearchResult.GetFocusedDataRow();

                    if (!iv.ValidateTicket(data["ReceivingNo"].ToString(), data["Installment"].ToString()))
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
            catch (Exception ex)
            {
                return false;
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        public override bool OnCommandView()
        {
            try
            {
                if (gdvSearchResult.RowCount > 0)
                {
                    OpenDialog(Common.eScreenMode.View);
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
        public override bool OnCommandDelete()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }

                DataRow data = gdvSearchResult.GetFocusedDataRow();

                if (!iv.ValidateTicket(data["ReceivingNo"].ToString(), data["Installment"].ToString()))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                    return false;
                }

                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0002"), data["ReceivingNo"].ToString())) == DialogButton.Yes)
                {
                    if (BusinessClass.CanDelete(data["ReceivingNo"].ToString(), Convert.ToInt32(data["Installment"]), Convert.ToInt32(data["OwnerID"])))
                    {
                        if (BusinessClass.Delete(data["ReceivingNo"].ToString(), Convert.ToInt32(data["Installment"])))
                            MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0013"), data["ReceivingNo"].ToString()));
                        DataLoading();
                    }
                    else
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, string.Format(Rubix.Screen.Common.GetMessage("I0254"), "Receiving"));
                        return false;
                    }
                }
                return base.OnCommandDelete();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Event Handler Function
        private void frmBRES010_ReceivingEntry_Load(object sender, EventArgs e)
        {
            try
            {
                txtReceivingNo.Focus();

                itemControl.OwnerID = Common.GetDefaultOwnerID();
                itemControl.DataLoading();
                supplierControl.OwnerID = Common.GetDefaultOwnerID();
                supplierControl.DataLoading();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();

                deArrivalDateFrom.EditValue = ControlUtil.GetStartDate();
                deArrivalDateTo.EditValue = ControlUtil.GetEndDate();
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
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                ControlUtil.ClearControlData(this.Controls);
                chkIncomplete.Checked = true;
                deArrivalDateFrom.EditValue = ControlUtil.GetStartDate();
                deArrivalDateTo.EditValue = ControlUtil.GetEndDate();
                itemControl.OwnerID = Common.GetDefaultOwnerID();
                itemControl.DataLoading();
                supplierControl.OwnerID = Common.GetDefaultOwnerID();
                supplierControl.DataLoading();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
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
                    itemControl.OwnerID = ownerControl.OwnerID;
                    itemControl.DataLoading();
                    supplierControl.OwnerID = ownerControl.OwnerID;
                    supplierControl.DataLoading();
                    warehouseControl.OwnerID = ownerControl.OwnerID;
                    warehouseControl.DataLoading();
                }
                else
                {
                    itemControl.OwnerID = Common.GetDefaultOwnerID();
                    itemControl.DataLoading();
                    supplierControl.OwnerID = Common.GetDefaultOwnerID();
                    supplierControl.DataLoading();
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
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
        #endregion
        
        #region Generic Function
        private void OpenDialog(Common.eScreenMode ScreenMode)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                Dialog.IdleValidatorControl = this.iv;
                if (ScreenMode == Common.eScreenMode.Add)
                {
                    Dialog.Installment = 0;
                }
                else
                {
                    DataRow dr = gdvSearchResult.GetFocusedDataRow();
                    Dialog.ReceivingNo = dr["ReceivingNo"].ToString();
                    Dialog.Installment = Convert.ToInt32(dr["Installment"]);
                    Dialog.OwnerID = Convert.ToInt32(dr["OwnerID"]);
                }

                if (ScreenMode == Common.eScreenMode.Edit)
                {
                    if (!BusinessClass.CanUpdate(Dialog.ReceivingNo, Dialog.Installment, Dialog.OwnerID))
                    {
                        MessageDialog.ShowBusinessErrorMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0130"), Dialog.ReceivingNo));
                        return;
                    }
                }
                Dialog.ScreenMode = ScreenMode;
                Dialog.BusinessClass = this.BusinessClass;
                if (Dialog.ShowDialog(this) == DialogResult.OK)
                {
                    DataLoading();
                    MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), BusinessClass.ReceivingNo));
                }

                Dialog = null;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
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
                this.ShowWaitScreen();
                int statusFilter = 0;
                if (chkAll.Checked)
                {
                    statusFilter = 1;
                }
                grdSearchResult.DataSource = BusinessClass.DataLoading(ownerControl.OwnerID, txtReceivingNo.Text.Trim(), itemControl.ProductID, supplierControl.SupplierID, DataUtil.Convert<DateTime>(deArrivalDateFrom.EditValue), DataUtil.Convert<DateTime>(deArrivalDateTo.EditValue), statusFilter, warehouseControl.WarehouseID, txtInvoiceNo.Text);

                iv.ClearTicket();

                for (int i = 0; i < gdvSearchResult.RowCount; i++)
                {
                    DateTime? lastUpdate;
                    if (gdvSearchResult.GetRowCellValue(i, "UpdateDate") == DBNull.Value)
                    {
                        lastUpdate = null;
                    }
                    else
                    {
                        lastUpdate = DataUtil.Convert<DateTime>(gdvSearchResult.GetRowCellValue(i, "UpdateDate"));
                    }
                    iv.PushTicket(lastUpdate, gdvSearchResult.GetRowCellValue(i, "ReceivingNo").ToString(), gdvSearchResult.GetRowCellValue(i, "Installment").ToString());
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
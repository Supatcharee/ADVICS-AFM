using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using CSI.Business.Operation;
using Rubix.Framework;
using CSI.Business.DataObjects;
namespace Rubix.Screen.Form.Operation.C_Receiving
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Add, Permission.Export)]
    public partial class frmCRCS030_UnplanReceivingEntry : FormBase
    {

        #region Member
        private ReceivingEntry db;
        private Dialog.dlgCRCS031_UnplanReceivingEntryDialog m_Dialog = null;
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

        private Dialog.dlgCRCS031_UnplanReceivingEntryDialog Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgCRCS031_UnplanReceivingEntryDialog();
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
        public frmCRCS030_UnplanReceivingEntry()
        {
            InitializeComponent();
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            ControlUtil.HiddenControl(true, m_toolBarCancel, m_toolBarRefresh, m_toolBarSave, m_toolBarDelete, m_toolBarEdit);
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
        #endregion

        #region Event Handler Function
        private void frmCRCS030_UnplanReceivingEntry_Load(object sender, EventArgs e)
        {
            try
            {
                txtReceivingNo.Focus();
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
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ControlUtil.ClearControlData(this.Controls);
                warehouseControl.OwnerID = ownerControl.OwnerID;
                warehouseControl.DataLoading();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            itemControl.OwnerID = ownerControl.OwnerID;
            itemControl.DataLoading();
            supplierControl.OwnerID = ownerControl.OwnerID;
            supplierControl.DataLoading();
            warehouseControl.OwnerID = ownerControl.OwnerID;
            warehouseControl.DataLoading();
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
                    Dialog.Installment = 1;
                }
                else
                {
                    Dialog.ReceivingNo = GetFocusReceivingNo();
                    Dialog.Installment = GetFocusInstallment();
                    Dialog.OwnerID = GetFocusCustomerID();
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

        private string GetFocusReceivingNo()
        {
            sp_CRCS030_UnplanReceivingEntry_SearchAll_Result data = (sp_CRCS030_UnplanReceivingEntry_SearchAll_Result)gdvSearchResult.GetFocusedRow();
            return data.ReceivingNo;
        }

        private int GetFocusInstallment()
        {
            sp_CRCS030_UnplanReceivingEntry_SearchAll_Result data = (sp_CRCS030_UnplanReceivingEntry_SearchAll_Result)gdvSearchResult.GetFocusedRow();
            return data.Installment;
        }

        private int GetFocusCustomerID()
        {
            sp_CRCS030_UnplanReceivingEntry_SearchAll_Result data = (sp_CRCS030_UnplanReceivingEntry_SearchAll_Result)gdvSearchResult.GetFocusedRow();
            return data.OwnerID;
        }

        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                grdSearchResult.DataSource = BusinessClass.UnplanReceivingEntryDataLoading(ownerControl.OwnerID, txtReceivingNo.Text.Trim(), itemControl.ProductID, (DateTime?)deArrivalDateFrom.EditValue, (DateTime?)deArrivalDateTo.EditValue, supplierControl.SupplierID, warehouseControl.WarehouseID, txtInvoiceNo.Text);
                
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
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

            //supplierControl.ErrorText = Common.GetMessage("I0300");
            //supplierControl.RequireField = true;

            validate &= ownerControl.ValidateControl();
            validate &= warehouseControl.ValidateControl();
            //validate &= supplierControl.ValidateControl();
            

            return validate;
        }
        #endregion      
    }
}
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
using CSI.Business.Operation;
using Rubix.Framework;
namespace Rubix.Screen.Form.Operation.M_StatisticalManagement
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Export)]
    public partial class frmMSTS010_StatManage : FormBase
    {
        #region Member
        private StatManage  db;
        #endregion

        #region Properties
        private StatManage BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new StatManage();
                }
                return db;
            }
        }
        #endregion
        
        #region Constructor
        public frmMSTS010_StatManage()
        {
            InitializeComponent();
            base.GridControlSearchResult = new DevExpress.XtraGrid.GridControl[] { grdSearchResult, grdTotal };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl3);
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarEdit, m_toolBarDelete, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh,m_toolBarView);

            dtTransFrom.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtTransFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtTransFrom.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtTransFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtTransFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtTransFrom.Properties.Mask.EditMask = Common.FullDateFormat;


            dtTransTo.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtTransTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtTransTo.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtTransTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtTransTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtTransTo.Properties.Mask.EditMask = Common.FullDateFormat;


            colTransactionDate.DisplayFormat.FormatString = Common.FullDateFormat;
            colTransactionDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
        }
        #endregion

        #region Override Method

        #endregion

        #region Event Handler Function
        private void frmMSTS010__StatManage_Load(object sender, EventArgs e)
        {
            try
            {
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                dtTransFrom.EditValue = ControlUtil.GetStartDate();
                dtTransTo.EditValue = ControlUtil.GetEndDate();

                ControlUtil.SetBestWidth(gdvSearchResult);
                ControlUtil.SetBestWidth(gdvTotal);
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
                if (ValidateDataWhenSearch())
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
                ControlUtil.ClearControlData(this.Controls);
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                dtTransFrom.EditValue = ControlUtil.GetStartDate();
                dtTransTo.EditValue = ControlUtil.GetEndDate();
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
                }
                else
                {
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                }
                CloseWaitScreen();
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
                grdSearchResult.DataSource = BusinessClass.DataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, DataUtil.Convert<DateTime>(dtTransFrom.EditValue), DataUtil.Convert<DateTime>(dtTransTo.EditValue));
                grdTotal.DataSource = BusinessClass.DataSummaryLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, DataUtil.Convert<DateTime>(dtTransFrom.EditValue), DataUtil.Convert<DateTime>(dtTransTo.EditValue));

                grdSearchResult.Refresh();
                grdTotal.Refresh();

                ControlUtil.SetBestWidth(gdvSearchResult);
                ControlUtil.SetBestWidth(gdvTotal);

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

        private Boolean ValidateDataWhenSearch()
        {
            errorProvider.ClearErrors();
            Boolean validate = true;
            // set require field
            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;
            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            validate &= ownerControl.ValidateControl();
            validate &= warehouseControl.ValidateControl();

            return validate;
        }
        #endregion      
    }
}
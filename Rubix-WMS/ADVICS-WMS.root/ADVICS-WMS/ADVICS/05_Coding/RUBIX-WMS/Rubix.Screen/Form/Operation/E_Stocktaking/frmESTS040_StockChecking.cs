using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using DevExpress.XtraGrid;
using CSI.Business.Operation;
using CSI.Business.BusinessFactory.Operation;
using DevExpress.XtraGrid.Views.Grid;

namespace Rubix.Screen.Form.Operation.E_Stocktaking
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Export)]
    public partial class frmESTS040_StockChecking : FormBase
    {    
        #region Member
        private StockChecking db;
        #endregion  

        #region Enumeration
        private enum eColumn
        {
            OwnerID,
            WarehouseID,
            DCCode,
            WarehouseName,
            CheckedDate,
            CheckedBy,
            ProductID,
            ProductCode,
            ProductLongName,
            ProductConditionID,
            ProductConditionCode,
            ProductConditionName,
            LocationID,
            LocationCode,
            LotNo,
            InventoryQty,
            CheckedQty,
            TypeOfUnitInventory,
            UnitCode,
            UnitName,
            Remark,
            DiffFlag

        }

        #endregion

        #region Properties
        private StockChecking BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new StockChecking();
                }
                return db;
            }
        }
        #endregion

        #region Constructor
        public frmESTS040_StockChecking()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarAdd, m_toolBarEdit, m_toolBarDelete, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh, q_toolBarView, q_toolBarAdd, q_toolBarEdit, q_toolBarDelete);
           

            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl1);

            dteCheckingDateFrom.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dteCheckingDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dteCheckingDateFrom.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dteCheckingDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dteCheckingDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dteCheckingDateFrom.Properties.Mask.EditMask = Common.FullDateFormat;

            dteCheckingTo.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dteCheckingTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dteCheckingTo.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dteCheckingTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dteCheckingTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dteCheckingTo.Properties.Mask.EditMask = Common.FullDateFormat;
        }
        #endregion

        #region Event Handler Function
        private void frmESTS040_StockChecking_Load(object sender, EventArgs e)
        {
            try
            {
                itemControl.OwnerID = null;
                itemControl.DataLoading();
                dteCheckingDateFrom.EditValue = ControlUtil.GetStartDate();
                dteCheckingTo.EditValue = ControlUtil.GetEndDate();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void customerControl_Enter(object sender, EventArgs e)
        {
            warehouseControl.OwnerID = null;
            warehouseControl.DataLoading();
            itemControl.OwnerID = null;
            itemControl.DataLoading();
        }

        private void customerControl_Leave(object sender, EventArgs e)
        {
            warehouseControl.OwnerID = ownerControl.OwnerID;
            warehouseControl.DataLoading();
            itemControl.OwnerID = ownerControl.OwnerID;
            itemControl.DataLoading();
        }

        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAll.Checked)
            {
                rdbDifferent.Checked = false;
            }
        }

        private void rdbDifferent_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDifferent.Checked)
            {
                rdbAll.Checked = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataLoading();
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

        private void gdvSearchResult_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            int intDiff = (int)View.GetRowCellValue(e.RowHandle, View.Columns["DiffFlag"]);
            if (intDiff == 1)
            {
                e.Appearance.BackColor = Color.Orange;
                //e.Appearance.BackColor2 = Color.Orange;
            }
        }
        #endregion

        #region Generic Function
        private void ClearAll()
        {
            ownerControl.ClearData();
            warehouseControl.ClearData();
            itemControl.ClearData();
           

            dteCheckingDateFrom.Text = string.Empty;
            dteCheckingTo.Text = string.Empty;

            errorProvider.SetError(dteCheckingDateFrom, String.Empty);
            errorProvider.SetError(dteCheckingTo, String.Empty);

            grdSearchResult.DataSource = null;
            //gdvSearchResult.Columns.Clear();

            warehouseControl.OwnerID = null;
            warehouseControl.DataLoading();
            itemControl.OwnerID = null;
            itemControl.DataLoading();
        }

        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                if (ValidateData())
                {
                    grdSearchResult.DataSource = BusinessClass.DataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, itemControl.ProductID, dteCheckingDateFrom.DateTime, dteCheckingTo.DateTime, rdbDifferent.Checked);

                    for (int i = 0; i < gdvSearchResult.Columns.Count; i++)
                    {
                        if (gdvSearchResult.Columns[i].ColumnType == typeof(DateTime) || gdvSearchResult.Columns[i].ColumnType == typeof(DateTime?))
                        {
                            gdvSearchResult.Columns[i].DisplayFormat.FormatString = Common.FullDatetimeFormat;
                            gdvSearchResult.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                        }
                    }                   
                    this.CloseWaitScreen();

                    if (gdvSearchResult.RowCount == 0)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                    }
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

        private bool ValidateData()
        {
            Boolean errFlag = true;
            ownerControl.RequireField = true;
            ownerControl.ErrorText = Rubix.Screen.Common.GetMessage("I0026");
            //if (!ownerControl.ValidateControl())
            //{
            //    errFlag = false;
            //}
            //else
            //{
            //    errorProvider.SetError(ownerControl, String.Empty);
            //}

            warehouseControl.RequireField = true;
            warehouseControl.ErrorText = Rubix.Screen.Common.GetMessage("I0045");
            if (!warehouseControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(warehouseControl, String.Empty);
            }
          
            if (dteCheckingDateFrom.Text == string.Empty)
            {
                errFlag = false;
                errorProvider.SetError(dteCheckingDateFrom, Rubix.Screen.Common.GetMessage("I0255"));
            }
            else
            {
                errorProvider.SetError(dteCheckingDateFrom, String.Empty);
            }
            if (dteCheckingTo.Text == string.Empty)
            {
                errFlag = false;
                errorProvider.SetError(dteCheckingTo, Rubix.Screen.Common.GetMessage("I0255"));
            }
            else
            {
                errorProvider.SetError(dteCheckingTo, String.Empty);
            }
            return errFlag;
        }
        #endregion
    }
}
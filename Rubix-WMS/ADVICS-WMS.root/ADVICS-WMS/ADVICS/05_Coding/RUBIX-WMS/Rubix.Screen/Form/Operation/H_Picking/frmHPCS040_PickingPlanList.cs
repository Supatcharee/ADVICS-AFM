using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using CSI.Business.Operation;
using DevExpress.XtraGrid;

namespace Rubix.Screen.Form.Operation.H_Picking
{
     [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Export)]
    public partial class frmHPCS040_PickingPlanList : FormBase
    {
        #region Member

        private PickingInstruction db;

        #endregion

        #region Properties

        private PickingInstruction BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new PickingInstruction();
                }
                return db;
            }
        }

        #endregion

        #region Constructor

        public frmHPCS040_PickingPlanList()
        {
            InitializeComponent();
            
            Clear();
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarView, m_toolBarRefresh, m_toolBarDelete, m_toolBarCancel, m_toolBarEdit, m_toolBarSave, m_toolBarConfirm);

            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl1);
        }

        #endregion

        #region Event Handler

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
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

        private void ownerControl_EditValueChanged(object sender, EventArgs e)
        {
            if (ownerControl.OwnerID != null)
            {
                warehouseControl.OwnerID = ownerControl.OwnerID;
                warehouseControl.DataLoading();

                customerControl.OwnerID = ownerControl.OwnerID;
                customerControl.DataLoading();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }


        private void gdvSearchResult_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            e.Handled = true;
            if (e.Column == gdcPickingNo)
            {
                DataRow firstRow = gdvSearchResult.GetDataRow(e.RowHandle1);
                DataRow secondRow = gdvSearchResult.GetDataRow(e.RowHandle2);

                if (firstRow["PickingNo"].ToString() == secondRow["PickingNo"].ToString())
                {
                    e.Merge = true;
                }
                else
                {
                    e.Merge = false;
                }
            }


            if (e.Column == gdcStatus
                || e.Column == gdcShipmentNo
                || e.Column == gdcInstallment
                || e.Column == gdcETD)
            {
                DataRow firstRow = gdvSearchResult.GetDataRow(e.RowHandle1);
                DataRow secondRow = gdvSearchResult.GetDataRow(e.RowHandle2);

                if (firstRow["StatusName"].ToString() == secondRow["StatusName"].ToString() &&
                    firstRow["ShipmentNo"].ToString() == secondRow["ShipmentNo"].ToString() &&
                    firstRow["Installment"].ToString() == secondRow["Installment"].ToString() &&
                    firstRow["ETD"].ToString() == secondRow["ETD"].ToString())
                {
                    e.Merge = true;

                }
                else
                {
                    e.Merge = false;
                }
            }

            if (e.Column == gdcPickingDate)
            {
                DataRow firstRow = gdvSearchResult.GetDataRow(e.RowHandle1);
                DataRow secondRow = gdvSearchResult.GetDataRow(e.RowHandle2);

                if (firstRow["ShipmentNo"].ToString() == secondRow["ShipmentNo"].ToString() &&
                    firstRow["PickingDate"].ToString() == secondRow["PickingDate"].ToString())
                {
                    e.Merge = true;
                }
                else
                {
                    e.Merge = false;
                }
            }
        }




        #endregion

        #region Generic Function

        private void DataLoading()
        {
            this.ShowWaitScreen();
            grdSearchResult.DataSource = BusinessClass.PickingListDataLoading(ownerControl.OwnerID
                                                , warehouseControl.WarehouseID
                                                , customerControl.CustomerID
                                                , DataUtil.Convert<DateTime>(dtPickingDateFrom.EditValue)
                                                , DataUtil.Convert<DateTime>(dtPickingDateTo.EditValue)
                                                , chkCompleteTransport.Checked
                                                , chkActual.Checked);
            base.GridViewOnChangeLanguage(grdSearchResult);
            this.CloseWaitScreen();
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
            //    noError = false;
            //}

            return validate;
        }


        private void Clear()
        {
            ownerControl.ClearData();
            customerControl.OwnerID = Common.GetDefaultOwnerID();
            customerControl.DataLoading();
            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();

            customerControl.CustomerID = null;

            dtPickingDateFrom.EditValue = ControlUtil.GetStartDate();
            dtPickingDateTo.EditValue = ControlUtil.GetEndDate();

            chkActual.Checked = true;
        }


        #endregion

        


     }
}
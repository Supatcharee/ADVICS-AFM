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
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using CSI.Business.Operation;

namespace Rubix.Screen.Form.Operation.A_Order
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Export)]
    public partial class frmASO030_CheckingSaleOrder : FormBase
    {
        #region Member
        //for test
        DataTable dtMaster = new DataTable();
        DataTable dtDetail = new DataTable();
        private SalePurchaseOrder db;
        Dialog.dlgASO031_SaleOrderByContainer m_Dialog = null;
        #endregion
        
        #region Properties
        private SalePurchaseOrder BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new SalePurchaseOrder();
                }
                return db;
            }
        }
        private Dialog.dlgASO031_SaleOrderByContainer Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgASO031_SaleOrderByContainer();
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
        public frmASO030_CheckingSaleOrder()
        {
            InitializeComponent();
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh, m_toolBarAdd, m_toolBarEdit);
            base.SetExpandGroupControl(groupControl1);
        } 
        #endregion

        #region Override Method
        public override bool OnCommandView()
        {
            try
            {
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }

                OpenDialog();
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
                return false;
            }
        }
        #endregion

        #region Event Handler
        private void frmASO030_CheckingSaleOrder_Load(object sender, EventArgs e)
        {
            try
            {
                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                gdvSearchResult.OptionsDetail.ShowDetailTabs = false;
                dtCustomerPOIssueDateFrom.EditValue = ControlUtil.GetStartDate();
                dtCustomerPOIssueDateTo.EditValue = ControlUtil.GetEndDate();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void ownerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (ownerControl.OwnerID != null)
                {
                    customerControl.OwnerID = ownerControl.OwnerID;
                    customerControl.DataLoading();
                    warehouseControl.OwnerID = ownerControl.OwnerID;
                    warehouseControl.DataLoading();
                }
                else
                {
                    customerControl.OwnerID = Common.GetDefaultOwnerID();
                    customerControl.DataLoading();
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex); ;
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
                ownerControl.ClearData();
                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                ControlUtil.ClearControlData(dtCustomerPOIssueDateFrom, dtCustomerPOIssueDateTo, txtCustomerPONo, txtSONo, chkAllStatus);
                grdSearchResult.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void gdvSearchResult_CellMerge(object sender, CellMergeEventArgs e)
        {
            try
            {
                e.Handled = true;
                if (e.Column == gdcStatusName || e.Column == gdcSONo || e.Column == gdcCustomerPONo || e.Column == gdcOwnerCode ||
                    e.Column == gdcOwnerName || e.Column == gdcWarehouseCode || e.Column == gdcWarehouseName || e.Column == gdcCustomerCode ||
                    e.Column == gdcCustomerName || e.Column == gdcShippingDate || e.Column == gdcCustPOIssDate || e.Column == gdcRemark ||
                    e.Column == gdcCreateDate || e.Column == gdcCreateUser || e.Column == gdcUpdateDate || e.Column == gdcUpdateUser
                   )
                {
                    DataRow firstRow = gdvSearchResult.GetDataRow(e.RowHandle1);
                    DataRow secondRow = gdvSearchResult.GetDataRow(e.RowHandle2);

                    if (firstRow["StatusName"].ToString() == secondRow["StatusName"].ToString() &&
                        firstRow["SONo"].ToString() == secondRow["SONo"].ToString() &&
                        firstRow["CustomerPONo"].ToString() == secondRow["CustomerPONo"].ToString() &&
                        firstRow["OwnerCode"].ToString() == secondRow["OwnerCode"].ToString() &&
                        firstRow["OwnerName"].ToString() == secondRow["OwnerName"].ToString() &&
                        firstRow["WarehouseCode"].ToString() == secondRow["WarehouseCode"].ToString() &&
                        firstRow["WarehouseName"].ToString() == secondRow["WarehouseName"].ToString() &&
                        firstRow["CustomerCode"].ToString() == secondRow["CustomerCode"].ToString() &&
                        firstRow["CustomerName"].ToString() == secondRow["CustomerName"].ToString() &&
                        firstRow["ShippingPeriod"].ToString() == secondRow["ShippingPeriod"].ToString() &&
                        firstRow["CustomerPOIssueDate"].ToString() == secondRow["CustomerPOIssueDate"].ToString() &&
                        firstRow["Remark"].ToString() == secondRow["Remark"].ToString() &&
                        firstRow["CreateDate"].ToString() == secondRow["CreateDate"].ToString() &&
                        firstRow["CreateUser"].ToString() == secondRow["CreateUser"].ToString() &&
                        firstRow["UpdateDate"].ToString() == secondRow["UpdateDate"].ToString() &&
                        firstRow["UpdateUser"].ToString() == secondRow["UpdateUser"].ToString())
                    {
                        e.Merge = true;

                    }
                    else
                    {
                        e.Merge = false;
                    }
                }
                else
                {
                    e.Merge = false;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void gdvSearchResult_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                base.GridViewChildOnChangeLanguage(grdSearchResult, e.RowHandle);
                GridView grv = ((GridView)(((GridView)grdSearchResult.Views[0]).GetDetailView(e.RowHandle, 0)));
                if (grv != null)
                {
                    grv.Columns["SONo"].Visible = false;
                }
            }
        }
        #endregion

        #region Generic Function
        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                grdSearchResult.DataSource = null;

                DataSet ds = BusinessClass.CheckingSaleDataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, customerControl.CustomerID,
                                                                    dtShippingPeriod.EditValue == null ? null : dtShippingPeriod.DateTime.ToString("yyyy/MM/01"),
                                                                    dtCustomerPOIssueDateFrom.EditValue == null ? null : dtCustomerPOIssueDateFrom.DateTime.ToString("yyyy/MM/dd"),
                                                                    dtCustomerPOIssueDateTo.EditValue == null ? null : dtCustomerPOIssueDateTo.DateTime.ToString("yyyy/MM/dd"),
                                                                    txtCustomerPONo.Text.Trim(), txtSONo.Text, chkAllStatus.Checked ? null : DataUtil.Convert<int>(1));

                dtMaster = ds.Tables[0];
                dtDetail = ds.Tables[1];

                if (dtMaster.Rows.Count <= 0)
                {
                    return;
                }

                dtDetail.ParentRelations.Add(dtMaster.Columns["SONo"], dtDetail.Columns["SONo"]);

                grdSearchResult.DataSource = dtMaster;

                //((GridView)grdSearchResult.Views[1]).Columns["SONo"].Visible = false;
                
                grdSearchResult.DataSource = dtMaster;
                base.GridViewOnChangeLanguage(grdSearchResult);

                //Check duplicate Owner and Warehouse
                DataTable distinctTable1 = dtMaster.DefaultView.ToTable(true, "OwnerCode");
                DataTable distinctTable2 = dtMaster.DefaultView.ToTable(true, "WarehouseCode");

                gdcOwnerCode.Visible = distinctTable1.Rows.Count > 1;
                gdcOwnerName.Visible = distinctTable1.Rows.Count > 1;
                gdcWarehouseCode.Visible = distinctTable2.Rows.Count > 1;
                gdcWarehouseName.Visible = distinctTable2.Rows.Count > 1;

                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OpenDialog()
        {
            Dialog.SONo = gdvSearchResult.GetFocusedDataRow()["SONo"].ToString();

            if (Dialog.ShowDialog(this) == DialogResult.OK)
            {
                //DataLoading();
            }
            Dialog = null;          
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
            //validate &= customerControl.ValidateControl();

            return validate;
        }
        #endregion
    }
}
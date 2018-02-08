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
using CSI.Business.BusinessFactory.Common;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Rubix.Screen.Form.Operation.A_Order
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Confirm, Permission.Export)]
    public partial class frmASO050_PurchaseOrderConfirm : FormBase
    {
        #region Member
        private Dialog.dlgASO041_PurchaseOrder m_Dialog = null;
        private SalePurchaseOrder db;
        private DataTable dtSearchResult;
        #endregion

        #region Properties
        private Dialog.dlgASO041_PurchaseOrder Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgASO041_PurchaseOrder();
                }
                return m_Dialog;
            }
            set
            {
                m_Dialog = value;
            }
        }
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
        #endregion

        #region Constructor
        public frmASO050_PurchaseOrderConfirm()
        {
            InitializeComponent();
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
            base.SetExpandGroupControl(groupControl1);

            iv = new IdleValidator("tbt_PurchaseOrderHeader", "UpdateDate", "PONo");
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

                OpenDialog(Common.eScreenMode.View);
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
                return false;
            }
        }
        public override bool OnCommandConfirm()
        {
            try
            {               
                gdvSearchResult.CloseEditor();
                gdvSearchResult.UpdateCurrentRow();

                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }

                DataTable dt = grdSearchResult.DataSource as DataTable;
                DataRow[] dr = dt.Select("Select = 1");
                DataRow[] dr1;
                bool IsError = false;
                if (dr.Length <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }
                else
                {
                    for (int i = 0; i < dr.Length; i++)
                    {
                        if (!iv.ValidateTicket(dr[i]["PONo"].ToString()))
                        {
                            IsError = true;
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                            break;
                        }

                        dr1 = dtSearchResult.Select(string.Format("PONo = '{0}' ", dr[i]["PONo"]));

                        if (dr.Length > 0 && !string.IsNullOrEmpty(dr1[0]["SONo"].ToString()))
                        {
                            IsError = true;
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0399", "Purchase Order", dr[i]["PONo"].ToString()));
                            break;
                        }
                    }
                    if (IsError)
                    {                        
                        return false;
                    }
                    else
                    {
                        DataSet ds = new DataSet("PurchaseDataSet");
                        DataTable dtNew = dr.CopyToDataTable().DefaultView.ToTable(true, "PONo");
                        dtNew.TableName = "PurchaseDataTable";
                        ds.Tables.Add(dtNew);
                        BusinessClass.PurchaseOrderConfirm(ds.GetXml());
                        DataLoading();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
                return false;
            }
        }
        #endregion

        #region Event Handler Function
        private void frmASO050_PurchaseOrderConfirm_Load(object sender, EventArgs e)
        {
            try
            {
                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                supplierControl.OwnerID = Common.GetDefaultOwnerID();
                supplierControl.DataLoading();
                dtPOIssueDateFrom.EditValue = ControlUtil.GetStartDate();
                dtPOIssueDateTo.EditValue = ControlUtil.GetEndDate();
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
                    supplierControl.OwnerID = ownerControl.OwnerID;
                    supplierControl.DataLoading();
                }
                else
                {
                    customerControl.OwnerID = Common.GetDefaultOwnerID();
                    customerControl.DataLoading();
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
                supplierControl.OwnerID = Common.GetDefaultOwnerID();
                supplierControl.DataLoading();
                ControlUtil.ClearControlData(txtSONo, txtPONo, txtCustomerPONo, dtPOIssueDateFrom, dtPOIssueDateTo);
                grdSearchResult.DataSource = null;

                dtPOIssueDateFrom.EditValue = ControlUtil.GetStartDate();
                dtPOIssueDateTo.EditValue = ControlUtil.GetEndDate();
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
                if (e.Column == gdcSelect || e.Column == gdcStatusName || e.Column == gdcPONo || e.Column == gdcOwnerCode || e.Column == gdcOwnerName ||
                    e.Column == gdcWarehouseCode || e.Column == gdcWarehouseName || e.Column == gdcSupplierCode || e.Column == gdcSupplierName || e.Column == gdcCustomerCode || e.Column == gdcCustomerName ||
                    e.Column == gdcPOIssueDate || e.Column == gdcCurrency || e.Column == gdcVat || e.Column == gdcArrivalDate || e.Column == gdcCollectDate || e.Column == gdcRemark ||
                    e.Column == gdcCreateDate || e.Column == gdcCreateUser || e.Column == gdcUpdateDate || e.Column == gdcUpdateUser
                   )
                {
                    DataRow firstRow = gdvSearchResult.GetDataRow(e.RowHandle1);
                    DataRow secondRow = gdvSearchResult.GetDataRow(e.RowHandle2);

                    if (firstRow["Select"].ToString() == secondRow["Select"].ToString() &&
                        firstRow["StatusName"].ToString() == secondRow["StatusName"].ToString() &&
                        firstRow["PONo"].ToString() == secondRow["PONo"].ToString() &&
                        //firstRow["SONo"].ToString() == secondRow["SONo"].ToString() &&
                        firstRow["OwnerCode"].ToString() == secondRow["OwnerCode"].ToString() &&
                        firstRow["OwnerName"].ToString() == secondRow["OwnerName"].ToString() &&
                        firstRow["WarehouseCode"].ToString() == secondRow["WarehouseCode"].ToString() &&
                        firstRow["WarehouseName"].ToString() == secondRow["WarehouseName"].ToString() &&
                        firstRow["SupplierCode"].ToString() == secondRow["SupplierCode"].ToString() &&
                        firstRow["SupplierName"].ToString() == secondRow["SupplierName"].ToString() &&
                        firstRow["CustomerCode"].ToString() == secondRow["CustomerCode"].ToString() &&
                        firstRow["CustomerName"].ToString() == secondRow["CustomerName"].ToString() &&
                        //firstRow["ShippingDate"].ToString() == secondRow["ShippingDate"].ToString() &&
                        firstRow["IssuedDate"].ToString() == secondRow["IssuedDate"].ToString() &&
                        firstRow["CurrencyCode"].ToString() == secondRow["CurrencyCode"].ToString() &&
                        firstRow["Vat"].ToString() == secondRow["Vat"].ToString() &&
                        firstRow["ArrivalDate"].ToString() == secondRow["ArrivalDate"].ToString() &&
                        firstRow["CollectDate"].ToString() == secondRow["CollectDate"].ToString() &&
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
        
        private void gdvSearchResult_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                if (e.Column == gdcSelect)
                {
                    DataRow dr = gdvSearchResult.GetFocusedDataRow();
                    if (dr != null)
                    {
                        DataRow[] drr = dtSearchResult.Select(string.Format(" PONo = '{0}'", dr["PONo"]));
                        if (drr.Length > 0)
                        {
                            for (int i = 0; i < drr.Length; i++)
                            {
                                if (drr[i]["Select"] == DBNull.Value || Convert.ToInt16(drr[i]["Select"]) == 0)
                                {
                                    drr[i]["Select"] = 1;
                                }
                                else
                                {
                                    drr[i]["Select"] = 0;
                                }
                            }
                        }
                    }
                }
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
                grdSearchResult.DataSource = null;
                iv.ClearTicket();
                dtSearchResult = BusinessClass.PurchaseOrderDataLoadingConfirm(ownerControl.OwnerID, warehouseControl.WarehouseID, supplierControl.SupplierID, customerControl.CustomerID,
                                                                               dtPOIssueDateFrom.EditValue == null ? null : dtPOIssueDateFrom.DateTime.ToString("yyyy/MM/dd"),
                                                                               dtPOIssueDateTo.EditValue == null ? null : dtPOIssueDateTo.DateTime.ToString("yyyy/MM/dd"),
                                                                               txtSONo.Text.Trim(), txtPONo.Text.Trim(), txtCustomerPONo.Text.Trim());

                if (dtSearchResult.Rows.Count <= 0)
                {
                    CloseWaitScreen();
                    return;
                }

                grdSearchResult.DataSource = dtSearchResult;
                gdvSearchResult.OptionsBehavior.Editable = true;

                //Check duplicate Owner and Warehouse
                DataTable distinctTable1 = dtSearchResult.DefaultView.ToTable(true, "OwnerCode");
                DataTable distinctTable2 = dtSearchResult.DefaultView.ToTable(true, "WarehouseCode");

                gdcOwnerCode.Visible = distinctTable1.Rows.Count > 1;
                gdcOwnerName.Visible = distinctTable1.Rows.Count > 1;
                gdcWarehouseCode.Visible = distinctTable2.Rows.Count > 1;
                gdcWarehouseName.Visible = distinctTable2.Rows.Count > 1;

                //IdleValidator
                foreach (DataRow dr in dtSearchResult.Rows)
                {
                    iv.PushTicket(Convert.ToDateTime(dr["DateForValiDate"]), dr["PONo"].ToString());
                }
                base.GridViewOnChangeLanguage(grdSearchResult);
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OpenDialog(Common.eScreenMode ScreenMode)
        {
            Dialog.ScreenMode = ScreenMode;

            if (ScreenMode != Common.eScreenMode.Add)
            {
                Dialog.PONo = gdvSearchResult.GetFocusedDataRow()["PONo"].ToString();                
            }

            if (Dialog.ShowDialog(this) == DialogResult.OK)
            {
                DataLoading();
                MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), Dialog.PONo));
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
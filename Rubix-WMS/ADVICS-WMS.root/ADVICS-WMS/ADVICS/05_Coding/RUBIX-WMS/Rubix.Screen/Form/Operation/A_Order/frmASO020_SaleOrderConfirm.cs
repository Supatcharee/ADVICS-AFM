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
using DevExpress.XtraGrid.Views.Grid;
using CSI.Business.BusinessFactory.Common;

namespace Rubix.Screen.Form.Operation.A_Order
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Confirm, Permission.Export)]
    public partial class frmASO020_SaleOrderConfirm : FormBase
    {
        #region Member
        private Dialog.dlgASO011_SaleOrder m_Dialog = null;
        private Dialog.dlgASO021_SaleOrderPreConfirm Pre_Dialog = null;
        private SalePurchaseOrder db;
        private DataTable dtSearchResult;
        #endregion

        #region Properties
        private Dialog.dlgASO011_SaleOrder Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgASO011_SaleOrder();
                }
                return m_Dialog;
            }
            set
            {
                m_Dialog = value;
            }
        }

        private Dialog.dlgASO021_SaleOrderPreConfirm PreconfirmDialog
        {
            get
            {
                if (Pre_Dialog == null)
                {
                    return Pre_Dialog = new Dialog.dlgASO021_SaleOrderPreConfirm();
                }
                return Pre_Dialog;
            }
            set
            {
                Pre_Dialog = value;
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
        public frmASO020_SaleOrderConfirm()
        {
            InitializeComponent();
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh, m_toolBarAdd, m_toolBarEdit);
            base.SetExpandGroupControl(groupControl1);

            iv = new IdleValidator("tbt_SaleOrderHeader", "UpdateDate", "SONo");
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
                this.ShowWaitScreen();
                gdvSearchResult.CloseEditor();
                gdvSearchResult.UpdateCurrentRow();

                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }
                DataTable dt = grdSearchResult.DataSource as DataTable;
                DataRow[] dr = dt.Select("Select = 1");
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
                        if (!iv.ValidateTicket(dr[i]["SONo"].ToString()))
                        {
                            IsError = true;
                            break;
                        }
                        if (dr[i]["ShippingPeriod"].ToString() != dr[0]["ShippingPeriod"].ToString())
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, "Shipping Date ต้องเป็นเดือนเดียวกัน");
                            return false;
                        }
                    }
                    if (IsError)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                        return false;
                    }
                    else
                    {
                        DataSet ds = new DataSet("SaleDataSet");
                        DataTable dtNew = dr.CopyToDataTable();
                        dtNew.TableName = "SaleDataTable";
                        ds.Tables.Add(dtNew);
                        PreconfirmDialog = new A_Order.Dialog.dlgASO021_SaleOrderPreConfirm();
                        PreconfirmDialog.SONO = dtNew;
                        PreconfirmDialog.OwnerID = customerControl.OwnerID;
                        this.CloseWaitScreen();
                        PreconfirmDialog.ShowDialog(this);
                        this.ShowWaitScreen();
                        if (PreconfirmDialog.DialogResult == System.Windows.Forms.DialogResult.OK)
                        {
                            BusinessClass.SaleOrderConfirm(ds.GetXml());
                            DataLoading();
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
                return false;
            }
            finally
            {
                this.CloseWaitScreen();
            }
        }
        #endregion

        #region Event Handler
        private void frmASO020_SaleOrderConfirm_Load(object sender, EventArgs e)
        {
            try
            {
                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                gdcSelect.OptionsColumn.AllowEdit = true;
                //dtCustomerPOIssueDateFrom.EditValue = ControlUtil.GetStartDate();
                //dtCustomerPOIssueDateTo.EditValue = ControlUtil.GetEndDate();
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
                ControlUtil.ClearControlData(dtCustomerPOIssueDateFrom, dtCustomerPOIssueDateTo, txtCustomerPONo, txtSONo);
                grdSearchResult.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void gdvSearchResult_CellMerge(object sender, CellMergeEventArgs e)
        {
            //try
            //{
            //    e.Handled = true;
            //    if (e.Column == gdcSelect || e.Column == gdcStatusName || e.Column == gdcSONo || e.Column == gdcCustomerPONo || e.Column == gdcOwnerCode ||
            //        e.Column == gdcOwnerName || e.Column == gdcWarehouseCode || e.Column == gdcWarehouseName || e.Column == gdcCustomerCode ||
            //        e.Column == gdcCustomerName || e.Column == gdcShippingDate || e.Column == gdcCustPOIssDate || e.Column == gdcRemark ||
            //        e.Column == gdcCreateDate || e.Column == gdcCreateUser || e.Column == gdcUpdateDate || e.Column == gdcUpdateUser
            //       )
            //    {
            //        DataRow firstRow = gdvSearchResult.GetDataRow(e.RowHandle1);
            //        DataRow secondRow = gdvSearchResult.GetDataRow(e.RowHandle2);

            //        if (firstRow["Select"].ToString() == secondRow["Select"].ToString() &&
            //            firstRow["StatusName"].ToString() == secondRow["StatusName"].ToString() &&
            //            firstRow["SONo"].ToString() == secondRow["SONo"].ToString() &&
            //            firstRow["CustomerPONo"].ToString() == secondRow["CustomerPONo"].ToString() &&
            //            firstRow["OwnerCode"].ToString() == secondRow["OwnerCode"].ToString() &&
            //            firstRow["OwnerName"].ToString() == secondRow["OwnerName"].ToString() &&
            //            firstRow["WarehouseCode"].ToString() == secondRow["WarehouseCode"].ToString() &&
            //            firstRow["WarehouseName"].ToString() == secondRow["WarehouseName"].ToString() &&
            //            firstRow["CustomerCode"].ToString() == secondRow["CustomerCode"].ToString() &&
            //            firstRow["CustomerName"].ToString() == secondRow["CustomerName"].ToString() &&
            //            firstRow["ShippingPeriod"].ToString() == secondRow["ShippingPeriod"].ToString() &&
            //            firstRow["CustomerPOIssueDate"].ToString() == secondRow["CustomerPOIssueDate"].ToString() &&
            //            firstRow["Remark"].ToString() == secondRow["Remark"].ToString() &&
            //            firstRow["CreateDate"].ToString() == secondRow["CreateDate"].ToString() &&
            //            firstRow["CreateUser"].ToString() == secondRow["CreateUser"].ToString() &&
            //            firstRow["UpdateDate"].ToString() == secondRow["UpdateDate"].ToString() &&
            //            firstRow["UpdateUser"].ToString() == secondRow["UpdateUser"].ToString())
            //        {
            //            e.Merge = true;

            //        }
            //        else
            //        {
            //            e.Merge = false;
            //        }
            //    }
            //    else
            //    {
            //        e.Merge = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageDialog.ShowSystemErrorMsg(this, ex);
            //}
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gdvSearchResult.RowCount; i++)
                {
                    gdvSearchResult.SetRowCellValue(i, gdcSelect, true);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnUnselect_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gdvSearchResult.RowCount; i++)
                {
                    gdvSearchResult.SetRowCellValue(i, gdcSelect, false);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
        
        private void gdvSearchResult_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            //try
            //{
            //    if (e.Column == gdcSelect)
            //    {
            //        DataRow dr = gdvSearchResult.GetFocusedDataRow();
            //        if (dr != null)
            //        {
            //            DataRow[] drr = dtSearchResult.Select(string.Format(" SONo = '{0}'", dr["SONo"]));
            //            if (drr.Length > 0)
            //            {
            //                for (int i = 0; i < drr.Length; i++)
            //                {
            //                    if (drr[i]["Select"] == DBNull.Value || Convert.ToInt16(drr[i]["Select"]) == 0)
            //                    {
            //                        drr[i]["Select"] = 1;
            //                    }
            //                    else
            //                    {
            //                        drr[i]["Select"] = 0;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            //}
        }

        private void repSelect_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gdvSearchResult.PostEditor();
                DataRow dr = gdvSearchResult.GetFocusedDataRow();
                DataTable dt = grdSearchResult.DataSource as DataTable;
                DataRow[] drSelect = dt.Select(string.Format(" PONo = '{0}' ", dr["PONo"]));
                foreach (DataRow r in drSelect)
                {
                    r["Select"] = dr["Select"];
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this,ex.Message.ToString());
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
                dtSearchResult = BusinessClass.SaleOrderDataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, customerControl.CustomerID,
                                                                  dtShippingPeriod.EditValue == null ? null : dtShippingPeriod.DateTime.ToString("yyyy/MM/01"),
                                                                  dtCustomerPOIssueDateFrom.EditValue == null ? null : dtCustomerPOIssueDateFrom.DateTime.ToString("yyyy/MM/dd"),
                                                                  dtCustomerPOIssueDateTo.EditValue == null ? null : dtCustomerPOIssueDateTo.DateTime.ToString("yyyy/MM/dd"),
                                                                  txtCustomerPONo.Text.Trim(), txtSONo.Text, 1, 0, 0);

                if (dtSearchResult.Rows.Count <= 0)
                {
                    return;
                }

                grdSearchResult.DataSource = dtSearchResult;
                base.GridViewOnChangeLanguage(grdSearchResult);
                //Check duplicate Owner and Warehouse
                DataTable distinctTable1 = dtSearchResult.DefaultView.ToTable(true, "OwnerCode");
                DataTable distinctTable2 = dtSearchResult.DefaultView.ToTable(true, "WarehouseCode");

                gdcOwnerCode.Visible = distinctTable1.Rows.Count > 1;
                gdcOwnerName.Visible = distinctTable1.Rows.Count > 1;
                gdcWarehouseCode.Visible = distinctTable2.Rows.Count > 1;
                gdcWarehouseName.Visible = distinctTable2.Rows.Count > 1;

                gdvSearchResult.OptionsBehavior.Editable = true;

                //IdleValidator
                foreach (DataRow dr in dtSearchResult.Rows)
                {
                    iv.PushTicket(Convert.ToDateTime(dr["DateForValiDate"]), dr["SONo"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void OpenDialog(Common.eScreenMode ScreenMode)
        {
            Dialog.ScreenMode = ScreenMode;

            if (ScreenMode != Common.eScreenMode.Add)
            {
                Dialog.SONo = gdvSearchResult.GetFocusedDataRow()["SONo"].ToString();
            }

            if (Dialog.ShowDialog(this) == DialogResult.OK)
            {
                DataLoading();
                MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), Dialog.SONo));
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
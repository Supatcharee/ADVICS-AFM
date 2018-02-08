using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Rubix.Framework;
using CSI.Business.Operation;
using CSI.Business.BusinessFactory.Common;

namespace Rubix.Screen.Form.Operation.A_Order
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Add, Permission.Delete, Permission.Export)]
    public partial class frmASO070_SaleOrderAfterMarket : FormBase
    {
       
         #region Member
        private Dialog.dlgASO071_SaleOrderAfterMarket m_Dialog = null;
        private SalePurchaseOrder db;
        #endregion

        #region Properties
        private Dialog.dlgASO071_SaleOrderAfterMarket Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgASO071_SaleOrderAfterMarket();
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
        public frmASO070_SaleOrderAfterMarket()
        {
            InitializeComponent();
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh, m_toolBarEdit);
            base.SetExpandGroupControl(groupControl1);

            iv = new IdleValidator("tbt_SaleOrderHeader", "UpdateDate", "SONo");

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
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
                return false;
            }
        }
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
        public override bool OnCommandEdit()
        {
            try
            {
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }

                if (CheckCanEditOrDelete(Common.eScreenMode.Edit))
                {
                    OpenDialog(Common.eScreenMode.Edit);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
                return false;
            }
        }
        public override bool OnCommandDelete()
        {
            try
            {
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }

                DataRow data = gdvSearchResult.GetFocusedDataRow();

                if (!iv.ValidateTicket(data["SONo"].ToString()))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                    return false;
                }

                if (CheckCanEditOrDelete(Common.eScreenMode.View))
                {
                    if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0002"), data["SONo"].ToString())) == DialogButton.Yes)
                    {
                        ShowWaitScreen();
                        BusinessClass.SaleOrderDeleteData(data["SONo"].ToString());
                        MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0013"), data["SONo"].ToString()));
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
        private void frmAS070_SaleOrderAfterMarket_Load(object sender, EventArgs e)
        {
            try
            {
                ClearData();
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
                ClearData();
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
            //    if (e.Column == gdcStatusName || e.Column == gdcSONo || e.Column == gdcCustomerPONo || e.Column == gdcOwnerCode ||
            //        e.Column == gdcOwnerName || e.Column == gdcWarehouseCode || e.Column == gdcWarehouseName || e.Column == gdcCustomerCode ||
            //        e.Column == gdcCustomerName || e.Column == gdcShippingDate || e.Column == gdcCustPOIssDate || e.Column == gdcRemark ||
            //        e.Column == gdcCreateDate || e.Column == gdcCreateUser || e.Column == gdcUpdateDate || e.Column == gdcUpdateUser
            //       )
            //    {
            //        DataRow firstRow = gdvSearchResult.GetDataRow(e.RowHandle1);
            //        DataRow secondRow = gdvSearchResult.GetDataRow(e.RowHandle2);

            //        if (firstRow["StatusName"].ToString() == secondRow["StatusName"].ToString() &&
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
        #endregion
        
        #region Generic Function
        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                grdSearchResult.DataSource = null;
                iv.ClearTicket();
                DataTable dt = BusinessClass.SaleOrderDataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, customerControl.CustomerID,
                                                                  dtShippingPeriod.EditValue == null ? null : dtShippingPeriod.DateTime.ToString("yyyy/MM/01"),
                                                                  dtCustomerPOIssueDateFrom.EditValue == null ? null : dtCustomerPOIssueDateFrom.DateTime.ToString("yyyy/MM/dd"),
                                                                  dtCustomerPOIssueDateTo.EditValue == null ? null : dtCustomerPOIssueDateTo.DateTime.ToString("yyyy/MM/dd"),
                                                                  txtCustomerPONo.Text.Trim(), txtSONo.Text, chkAllStatus.Checked ? null : DataUtil.Convert<int>(1), 0, 1);

                if (dt.Rows.Count <= 0)
                {
                    return;
                }

                grdSearchResult.DataSource = dt;
                base.GridViewOnChangeLanguage(grdSearchResult);
                //Check duplicate Owner and Warehouse
                DataTable distinctTable1 = dt.DefaultView.ToTable(true, "OwnerCode");
                DataTable distinctTable2 = dt.DefaultView.ToTable(true, "WarehouseCode");

                gdcOwnerCode.Visible = distinctTable1.Rows.Count > 1;
                gdcOwnerName.Visible = distinctTable1.Rows.Count > 1;
                gdcWarehouseCode.Visible = distinctTable2.Rows.Count > 1;
                gdcWarehouseName.Visible = distinctTable2.Rows.Count > 1;

                //IdleValidator
                foreach (DataRow dr in dt.Rows)
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

            Dialog.IdleValidatorControl = this.iv;
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

        private bool CheckCanEditOrDelete(Common.eScreenMode ScreenMode)
        {
            DataRow data = gdvSearchResult.GetFocusedDataRow();

            if (!iv.ValidateTicket(data["SONo"].ToString()))
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                return false;
            }

            

            if(Convert.ToInt32(data["StatusID"]) != CSI.Business.Common.Status.NewSaleOrder)
            {
                if (ScreenMode == Common.eScreenMode.Edit)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, string.Format(Rubix.Screen.Common.GetMessage("I0417"), "Sale Order"));
                }
                else
                {
                    MessageDialog.ShowBusinessErrorMsg(this, string.Format(Rubix.Screen.Common.GetMessage("I0254"), "Sale Order"));
                }
                return false;
            }

            return true;
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

        private void ClearData()
        {
            ownerControl.ClearData();
            customerControl.OwnerID = Common.GetDefaultOwnerID();
            customerControl.DataLoading();
            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();
            ControlUtil.ClearControlData(dtCustomerPOIssueDateFrom, dtCustomerPOIssueDateTo, txtCustomerPONo, txtSONo, chkAllStatus, dtShippingPeriod);
            dtCustomerPOIssueDateFrom.EditValue = ControlUtil.GetStartDate();
            dtCustomerPOIssueDateTo.EditValue = ControlUtil.GetEndDate();
            grdSearchResult.DataSource = null;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSI.Business.Operation;
using Rubix.Framework;

namespace Rubix.Screen.Form.Operation.A_Order.Dialog
{
    public partial class dlgASO042_PurchaseOrderSearchSaleOrder : SubDialogBase
    {
        #region Member
        private SalePurchaseOrder db;
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
        public int? OwnerID { get; set; }
        public int? WarehouseID { get; set; }
        public int? SupplierID { get; set; }
        public DataTable ProductDetial { get; set; }
        #endregion

        #region Constructor
        public dlgASO042_PurchaseOrderSearchSaleOrder()
        {
            InitializeComponent();
        }
        #endregion

        #region Override Method
        public override bool OnCommandOK()
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

                if (dr.Length <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }

                DataSet ds = new DataSet("SaleDataSet");
                DataTable dtNew = dr.CopyToDataTable();
                dtNew.TableName = "SaleDataTable";
                ds.Tables.Add(dtNew);
                ProductDetial = BusinessClass.PurchaseOrderLoadProductBySONo(ds.GetXml(), SupplierID);
                DialogResult = DialogResult.OK;
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
        private void dlgASO042_PurchaseOrderSearchSaleOrder_Load(object sender, EventArgs e)
        {
            try
            {
                customerControl.OwnerID = OwnerID;
                customerControl.DataLoading();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
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
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();
                ControlUtil.ClearControlData(dtCustomerPOIssueDateFrom, dtCustomerPOIssueDateTo, txtCustomerPONo, txtSONo);
                grdSearchResult.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
        #endregion

        #region Generic Method
        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                grdSearchResult.DataSource = null;
                DataTable dt = BusinessClass.PurchaseOrderLoadSONo(OwnerID, WarehouseID, customerControl.CustomerID,
                                                                  dtShippingPeriod.EditValue == null ? null : dtShippingPeriod.DateTime.ToString("yyyy/MM/01"),
                                                                  dtCustomerPOIssueDateFrom.EditValue == null ? null : dtCustomerPOIssueDateFrom.DateTime.ToString("yyyy/MM/dd"),
                                                                  dtCustomerPOIssueDateTo.EditValue == null ? null : dtCustomerPOIssueDateTo.DateTime.ToString("yyyy/MM/dd"),
                                                                  txtCustomerPONo.Text.Trim(), txtSONo.Text);

                if (dt.Rows.Count <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                    return;
                }

                grdSearchResult.DataSource = dt;
                base.GridViewOnChangeLanguage(grdSearchResult);
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
        #endregion
    }
}

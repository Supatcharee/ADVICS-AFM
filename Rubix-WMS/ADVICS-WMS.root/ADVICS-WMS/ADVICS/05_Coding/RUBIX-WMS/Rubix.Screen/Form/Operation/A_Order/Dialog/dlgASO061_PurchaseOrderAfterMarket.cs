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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using CSI.Business.Common;
using DevExpress.Utils;
using System.Linq;
using System.Transactions;
using System.Globalization;


namespace Rubix.Screen.Form.Operation.A_Order.Dialog
{
    public partial class dlgASO061_PurchaseOrderAfterMarket : DialogBase
    {
        #region Member
        private Common.eScreenMode eScrenMode;
        private Dialog.dlgASO042_PurchaseOrderSearchSaleOrder m_Dialog = null;
        private CSI.Business.Master.CalendarShipping clBusiness;
        private SalePurchaseOrder db;
        private ProductPrice pp;
        private TypeOfUnit tu;
        private DataTable dtDetail = null;
        private DataRow dtForEdit = null;
        private decimal deMinOrder = 0;
        private CSI.Business.Master.Product pdBusiness;
        #endregion

        #region Enumeration
        enum eDetail
        {
            No,
            LineNo,
            ProductID,
            UnitPrice,
            CurrencyID,
            OrderQty,
            UnitID,
            RemarkDetail,
            StatusID
        }

        enum eColImport
        {
            IssueDate = 1,
            DuePeriod,
            OwnerCode,
            SupplierCode,
            WarehouseCode,
            HeaderRemark,
            ProductCode,
            Qty, 
            Remarks
        }
        #endregion

        #region Properties
        public Common.eScreenMode ScreenMode
        {
            get { return eScrenMode; }
            set { eScrenMode = value; }
        }
        private Dialog.dlgASO042_PurchaseOrderSearchSaleOrder Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgASO042_PurchaseOrderSearchSaleOrder();
                }
                return m_Dialog;
            }
            set
            {
                m_Dialog = value;
            }
        }

        private CSI.Business.Master.CalendarShipping CalendarBusinessClass
        {
            get
            {
                if (clBusiness == null)
                {
                    clBusiness = new CSI.Business.Master.CalendarShipping();
                }
                return clBusiness;
            }
            set
            {
                if (clBusiness == null)
                {
                    clBusiness = new CSI.Business.Master.CalendarShipping();
                }
                clBusiness = value;
            }
        }
        public string PONo { get; set; }
        public bool CanEdit { get; set; }
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
            set
            {
                if (db == null)
                {
                    db = new SalePurchaseOrder();
                }
                db = value;
            }
        }
        private ProductPrice ProductPriceBusiness
        {
            get
            {
                if (pp == null)
                {
                    pp = new ProductPrice();
                }
                return pp;
            }
            set
            {
                if (pp == null)
                {
                    pp = new ProductPrice();
                }
                pp = value;
            }
        }
        private CSI.Business.Master.Product ProductBusiness
        {
            get
            {
                if (pdBusiness == null)
                {
                    pdBusiness = new CSI.Business.Master.Product();
                }
                return pdBusiness;
            }
            set
            {
                if (pdBusiness == null)
                {
                    pdBusiness = new CSI.Business.Master.Product();
                }
                pdBusiness = value;
            }
        }
        private TypeOfUnit TypeUnitBusiness
        {
            get
            {
                if (tu == null)
                {
                    tu = new TypeOfUnit();
                }
                return tu;
            }
            set
            {
                if (tu == null)
                {
                    tu = new TypeOfUnit();
                }
                tu = value;
            }
        }
        #endregion

        #region Constructor
        public dlgASO061_PurchaseOrderAfterMarket()
        {
            InitializeComponent();
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (this.CanEdit)
                {
                    if (!ValidateHeader())
                    {
                        return false;
                    }
                }

                if (!ValidateCalendar())
                {
                    MessageDialog.ShowBusinessErrorMsg(this, "Shipping Calendar not setup on target Month");
                    ControlUtil.EnableControl(true, dtShippingPeriod);
                    return false;
                }

                if (dtDetail == null || dtDetail.Rows.Count <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0385"));
                    return false;
                }

                if (MessageDialog.ShowConfirmationMsg(this, Rubix.Screen.Common.GetMessage("I0015")) == DialogButton.Yes)
                {
                    ShowWaitScreen();
                    if (this.CanEdit)
                    {
                        SaveData();
                    }
                    else
                    {
                        SavePOInvoiceData();
                    }
                    CloseWaitScreen();
                    DialogResult = DialogResult.OK;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }

        public override bool OnCommandImport()
        {
            errorProvider.ClearErrors();
            string errorMsg = string.Empty;
            string errorDetailMsg = string.Empty;
            ExcelManager excel = new ExcelManager();
            try
            {
                if (ofdImport.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.ShowWaitScreen();
                    grdPurchaseOrderDetail.DataSource = null;
                    dtDetail.Rows.Clear();

                    using (excel)
                    {
                        excel.OpenExcel(ofdImport.FileName);
                        int row = 2;

                        string IssueDate = excel.ReadData(row, (int)eColImport.IssueDate).Trim();
                        string DuePeriod = excel.ReadData(row, (int)eColImport.DuePeriod).Trim();
                        string SupplierCode = excel.ReadData(row, (int)eColImport.SupplierCode).Trim();
                        string HeaderRemark = excel.ReadData(row, (int)eColImport.HeaderRemark).Trim();
                        //==========================================================================================================================

                        try
                        {
                            if (DateTime.ParseExact(IssueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) == null)
                            {
                                errorMsg += Common.GetMessage("I0279", "Due Date", IssueDate) + Environment.NewLine;
                            }
                            else
                            {
                                DateTime ShippingPeriod = DateTime.ParseExact(IssueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                DateTime dtNow = DateTime.Now.Date;
                                dtNow = dtNow.AddDays(-1 * (dtNow.Day - 1));

                                if (ShippingPeriod.Date.CompareTo(dtNow) < 0)
                                {
                                    errorMsg += Common.GetMessage("I0386") + Environment.NewLine;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            errorMsg += Common.GetMessage("I0279", "Issue Date", IssueDate) + Environment.NewLine;
                        }

                        try
                        {
                            if (DateTime.ParseExact("01/" + DuePeriod, "dd/MM/yyyy", CultureInfo.InvariantCulture) == null)
                            {
                                errorMsg += Common.GetMessage("I0279", "Due Period", DuePeriod) + Environment.NewLine;
                            }
                            else
                            {
                                DateTime ShippingPeriod = DateTime.ParseExact("01/" + DuePeriod, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                DateTime dtNow = DateTime.Now.Date;
                                dtNow = dtNow.AddDays(-1 * (dtNow.Day - 1));

                                if (ShippingPeriod.Date.CompareTo(dtNow) < 0)
                                {
                                    errorMsg += Common.GetMessage("I0386") + Environment.NewLine;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            errorMsg += Common.GetMessage("I0279", "Due Period", DuePeriod) + Environment.NewLine;
                        }

                        supplierControl.SupplierCode = SupplierCode;
                        if (supplierControl.SupplierID == null)
                        {
                            errorMsg += Common.GetMessage("I0279", "Supplier Code", SupplierCode) + Environment.NewLine;
                        }
                        
                        if (errorMsg != string.Empty)
                        {
                            dtDetail.Clear();
                            ControlUtil.ClearControlData(groupControl1.Controls);
                            ControlUtil.ClearControlData(groupControl2.Controls);
                            return false;
                        }
                        else
                        {
                            dtIssueDate.EditValue = DateTime.ParseExact(IssueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            dtShippingPeriod.EditValue = DateTime.ParseExact("01/" + DuePeriod, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            txtRemarkHeader.Text = HeaderRemark;
                        }

                        while (!string.IsNullOrWhiteSpace(excel.ReadData(row, (int)eColImport.ProductCode)))
                        {
                            errorDetailMsg = string.Empty;
                            string ProductCode = excel.ReadData(row, (int)eColImport.ProductCode).Trim();
                            string Qty = excel.ReadData(row, (int)eColImport.Qty).Trim();
                            string DetailRemark = excel.ReadData(row, (int)eColImport.Remarks).Trim();

                            /////Validate Item
                            if (ProductBusiness.DataLoading(ownerControl.OwnerID, ProductCode, null, null).Rows.Count <= 0)
                            {
                                errorDetailMsg += Common.GetMessage("I0279", "Product Code", ProductCode) + Environment.NewLine;
                            }
                            else
                            {
                                itemPriceControl.ProductCode = ProductCode;
                                if (itemPriceControl.ProductID == null)
                                {
                                    //Cannot find Item Code information, Sale Price or Purchase Price for {0}.
                                    errorDetailMsg += Common.GetMessage("I0411", ProductCode) + Environment.NewLine;
                                }
                                else
                                {
                                    DataTable dt = grdUnit.DataSource as DataTable;
                                    if (dt != null)
                                    {
                                        cboQtyUnit.EditValue = dt.Rows[0]["UnitID3"];
                                    }

                                    Decimal outQty;
                                    if (!Decimal.TryParse(Qty, out outQty))
                                    {
                                        errorDetailMsg += Common.GetMessage("I0279", "Qty", Qty) + Environment.NewLine;
                                    }
                                    else
                                    {
                                        txtQty.EditValue = Qty;
                                    }

                                    if (!ValidateOrderQty())
                                    {
                                        errorDetailMsg += Common.GetMessage("I0383") + Environment.NewLine;
                                    }
                                }
                            }

                            txtDetailRemark.Text = DetailRemark;

                            if (errorDetailMsg == string.Empty)
                            {
                                DataRow dr = dtDetail.NewRow();
                                SetDetail(dr);
                                if (dtDetail.Rows.Count > 0)
                                {
                                    dr[eDetail.LineNo.ToString()] = Convert.ToInt32(dtDetail.Compute("MAX(LineNo)", string.Empty)) + 1;
                                }
                                else
                                {
                                    dr[eDetail.LineNo.ToString()] = 1;
                                }
                                dr[eDetail.No.ToString()] = this.dtDetail.Rows.Count + 1;
                                dtDetail.Rows.Add(dr);

                                ControlUtil.ClearControlData(itemPriceControl, txtPurchasePrice, txtPurchasePriceCurrency, txtDetailRemark, txtQty, cboQtyUnit, txtMinOrder);
                                grdUnit.DataSource = null;
                            }
                            else
                            {
                                errorMsg += string.Format("Row{0}-{1}{2}{3}", row, ProductCode, Environment.NewLine, errorDetailMsg);
                            }
                            row++;
                        }
                    }
                }// if open dialog
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
                return false;
            }
            finally
            {
                excel.Dispose();
                excel = null;
                if (!string.IsNullOrWhiteSpace(errorMsg))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0387"), errorMsg);
                    dtDetail.Clear();
                    ControlUtil.ClearControlData(groupControl1.Controls);
                    ControlUtil.ClearControlData(groupControl2.Controls);
                }
                else
                {
                    CloseWaitScreen();
                    grdPurchaseOrderDetail.DataSource = dtDetail;
                    ControlUtil.SetBestWidth(gdvPurchaseOrderDetail);
                }
            }
        }

        public override bool OnCommandClear()
        {
            try
            {
                if (ScreenMode == Common.eScreenMode.Edit)
                {
                    DataLoading();
                }
                else
                {
                    dtDetail = null;
                    ControlUtil.ClearControlData(groupControl1.Controls);
                    ControlUtil.ClearControlData(groupControl2.Controls);
                    ControlUtil.EnableControl(true, dtIssueDate/*, dtArrivalDate, dtCollectDate*/);
                    ownerControl.EnableControl = true;
                    warehouseControl.EnableControl = true;
                    supplierControl.EnableControl = true;
                    DataLoading();
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
                return false;
            }
        }
        #endregion
        
        #region Event Handler
        private void dlgASO061_PurchaseOrderAfterMarket_Load(object sender, EventArgs e)
        {
            try
            {
                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                supplierControl.OwnerID = Common.GetDefaultOwnerID();
                supplierControl.DataLoading();
                itemPriceControl.PriceType = Control.ItemPriceControl.ePriceType.Purchase;
                itemPriceControl.OwnerID = Common.GetDefaultOwnerID();
                itemPriceControl.WarehouseID = Common.GetDefaultWarehouseID();
                itemPriceControl.DataLoading();
                InitCombobox();
                DataLoading();
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
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void warehouseControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ownerControl.OwnerID != null && warehouseControl.WarehouseID != null && supplierControl.SupplierID != null)
                {
                    itemPriceControl.OwnerID = ownerControl.OwnerID;
                    itemPriceControl.WarehouseID = warehouseControl.WarehouseID;
                    itemPriceControl.CustomerSupplierID = supplierControl.SupplierID;
                    itemPriceControl.DataLoading();
                    List<sp_common_LoadProductPrice_Result> list = ProductPriceBusiness.DataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, supplierControl.SupplierID, Control.ItemPriceControl.ePriceType.Purchase.ToString());
                    repProductCode.DataSource = list;
                    repProductName.DataSource = list;

                }
                else
                {
                    itemPriceControl.OwnerID = Common.GetDefaultOwnerID();
                    itemPriceControl.WarehouseID = Common.GetDefaultWarehouseID();
                    itemPriceControl.DataLoading();
                    repProductCode.DataSource = null;
                    repProductName.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void supplierControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ownerControl.OwnerID != null && warehouseControl.WarehouseID != null && supplierControl.SupplierID != null)
                {
                    itemPriceControl.OwnerID = ownerControl.OwnerID;
                    itemPriceControl.WarehouseID = warehouseControl.WarehouseID;
                    itemPriceControl.CustomerSupplierID = supplierControl.SupplierID;
                    itemPriceControl.DataLoading();
                    List<sp_common_LoadProductPrice_Result> list = ProductPriceBusiness.DataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, supplierControl.SupplierID, Control.ItemPriceControl.ePriceType.Purchase.ToString());
                    repProductCode.DataSource = list;
                    repProductName.DataSource = list;

                }
                else
                {
                    itemPriceControl.OwnerID = Common.GetDefaultOwnerID();
                    itemPriceControl.WarehouseID = Common.GetDefaultWarehouseID();
                    itemPriceControl.DataLoading();
                    repProductCode.DataSource = null;
                    repProductName.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void itemPriceControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (itemPriceControl.ProductID != null)
                {
                    txtPurchasePrice.EditValue = itemPriceControl.UnitPrice;
                    txtPurchasePriceCurrency.Text = itemPriceControl.CurrencyName;

                    DataSet ds = TypeUnitBusiness.LoadUnitPurchase(itemPriceControl.ProductID == null ? -1 : itemPriceControl.ProductID);
                    if (ds.Tables.Count == 2)
                    {
                        cboQtyUnit.Properties.DataSource = ds.Tables[0];
                        cboQtyUnit.Properties.DisplayMember = "UnitName";
                        cboQtyUnit.Properties.ValueMember = "UnitID";

                        grdUnit.DataSource = ds.Tables[1];
                        deMinOrder = Convert.ToDecimal(ds.Tables[1].Rows[0]["MinOrder"]);
                        txtMinOrder.EditValue = Convert.ToDecimal(ds.Tables[1].Rows[0]["MinOrder"]);
                        lblUnitName.Text = ds.Tables[1].Rows[0]["UnitCode2"].ToString();
                    }
                }
                else
                {
                    txtPurchasePrice.EditValue = null;
                    txtPurchasePriceCurrency.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateDetail() && ValidateHeader())
                {
                    DataRow dr = dtDetail.NewRow();
                    SetDetail(dr);
                    if (dtDetail.Rows.Count > 0)
                    {
                        dr[eDetail.LineNo.ToString()] = Convert.ToInt32(dtDetail.Compute("MAX(LineNo)", string.Empty)) + 1;
                    }
                    else
                    {
                        dr[eDetail.LineNo.ToString()] = 1;
                    }
                    dr[eDetail.No.ToString()] = this.dtDetail.Rows.Count + 1;
                    dtDetail.Rows.Add(dr);

                    ControlUtil.SetBestWidth(gdvPurchaseOrderDetail);
                    ControlUtil.ClearControlData(itemPriceControl, txtPurchasePrice, txtPurchasePriceCurrency, txtDetailRemark, txtQty, cboQtyUnit, txtMinOrder);
                    grdUnit.DataSource = null;
                    if (dtDetail.Rows.Count > 0)
                    {
                        ControlUtil.EnableControl(false, dtIssueDate/*, dtArrivalDate, dtCollectDate*/);
                        ownerControl.EnableControl = false;
                        warehouseControl.EnableControl = false;
                        supplierControl.EnableControl = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdvPurchaseOrderDetail.RowCount > 0 && CheckCanEditOrDelete())
                {
                    DataRow dr = gdvPurchaseOrderDetail.GetFocusedDataRow();

                    if (dr != null)
                    {
                        dtForEdit = dr;
                        itemPriceControl.ProductID = DataUtil.Convert<int>(dr[eDetail.ProductID.ToString()]);
                        txtPurchasePrice.EditValue = dr[eDetail.UnitPrice.ToString()];
                        txtPurchasePriceCurrency.EditValue = itemPriceControl.CurrencyName;
                        txtQty.EditValue = dr[eDetail.OrderQty.ToString()];
                        cboQtyUnit.EditValue = dr[eDetail.UnitID.ToString()].ToString();
                        txtDetailRemark.Text = dr[eDetail.RemarkDetail.ToString()].ToString();
                        EditMode(true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = gdvPurchaseOrderDetail.GetFocusedDataRow();
                if (dr != null)
                {
                    if (dr.RowState == DataRowState.Added || CheckCanEditOrDelete())
                    {
                        gdvPurchaseOrderDetail.DeleteSelectedRows();
                    }

                    if (dtDetail.Rows.Count <= 0)
                    {
                        ControlUtil.EnableControl(true, dtIssueDate/*, dtArrivalDate, dtCollectDate*/);
                        ownerControl.EnableControl = true;
                        warehouseControl.EnableControl = true;
                        supplierControl.EnableControl = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {                
                if (ValidateDetail())
                {
                    SetDetail(dtForEdit);
                    ControlUtil.SetBestWidth(gdvPurchaseOrderDetail);
                    ControlUtil.ClearControlData(itemPriceControl, txtPurchasePrice, txtPurchasePriceCurrency, txtDetailRemark, txtQty, cboQtyUnit, txtMinOrder);
                    grdUnit.DataSource = null;
                    EditMode(false);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ControlUtil.SetBestWidth(gdvPurchaseOrderDetail);
                ControlUtil.ClearControlData(itemPriceControl, txtPurchasePrice, txtPurchasePriceCurrency, txtDetailRemark, txtQty, cboQtyUnit, txtMinOrder);
                grdUnit.DataSource = null;
                EditMode(false);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }


        #endregion

        #region Generic Function
        private void InitCombobox()
        {
            CSI.Business.Master.Currency cuBusiness = new CSI.Business.Master.Currency();
            repCurrencyID.DataSource = cuBusiness.DataLoading(null, null);
            repUnitID.DataSource = TypeUnitBusiness.LoadTypeOfUnit();
        }

        private void DataLoading()
        {
            if (this.ScreenMode == Common.eScreenMode.Add)
            {
                m_statusBarCreatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = AppConfig.UserLogin;
                m_statusBarUpdatedDate.Caption = "-";
                m_statusBarUpdatedUser.Caption = "-";
                ControlUtil.HiddenControl(false, m_toolBarImport);

                dtDetail = new DataTable();
                dtDetail.Columns.Add(eDetail.No.ToString(), typeof(Int64));
                dtDetail.Columns.Add(eDetail.LineNo.ToString(), typeof(int));
                dtDetail.Columns.Add(eDetail.ProductID.ToString(), typeof(Int64));
                dtDetail.Columns.Add(eDetail.UnitPrice.ToString(), typeof(double));
                dtDetail.Columns.Add(eDetail.CurrencyID.ToString(), typeof(Int64));
                dtDetail.Columns.Add(eDetail.OrderQty.ToString(), typeof(double));
                dtDetail.Columns.Add(eDetail.UnitID.ToString(), typeof(Int64));
                dtDetail.Columns.Add(eDetail.RemarkDetail.ToString(), typeof(string));
                dtDetail.Columns.Add(eDetail.StatusID.ToString(), typeof(Int64));

            }
            else
            {
                DataSet ds = BusinessClass.PurchaseOrderDataLoadingDetail(this.PONo);
                dtDetail = ds.Tables[1].Copy();

                txtStatus.Text = ds.Tables[0].Rows[0]["StatusName"].ToString();
                txtPONo.Text = ds.Tables[0].Rows[0]["PONo"].ToString();
                ownerControl.OwnerID = Convert.ToInt32(ds.Tables[0].Rows[0]["OwnerID"]);
                customerControl.CustomerID = DataUtil.Convert<int>(ds.Tables[0].Rows[0]["CustomerID"]);
                warehouseControl.WarehouseID = Convert.ToInt32(ds.Tables[0].Rows[0]["WarehouseID"]);
                supplierControl.SupplierID = Convert.ToInt32(ds.Tables[0].Rows[0]["SupplierID"]);
                dtIssueDate.EditValue = ds.Tables[0].Rows[0]["IssuedDate"];
                txtRemarkHeader.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                txtPOInvoiceNo.Text = ds.Tables[0].Rows[0]["POInvoiceNo"].ToString();

                if (dtDetail.Rows.Count > 0)
                {
                    ControlUtil.EnableControl(false, /*dtArrivalDate, dtCollectDate,*/ dtIssueDate);
                    ownerControl.EnableControl = false;
                    warehouseControl.EnableControl = false;
                    supplierControl.EnableControl = false;

                }

                if (this.ScreenMode == Common.eScreenMode.View || !this.CanEdit)
                {
                    ControlUtil.EnableControl(false, groupControl1.Controls);
                    ControlUtil.EnableControl(false, itemPriceControl, txtQty, cboQtyUnit, txtDetailRemark, txtPOInvoiceNo);
                    ControlUtil.EnableControl(false, btnAdd, btnDelete, btnOK, btnUpdate,btnCancel);
                    ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarClear, m_toolBarImport);
                }

                if (!this.CanEdit && this.ScreenMode == Common.eScreenMode.Edit)
                {
                    ControlUtil.EnableControl(true, txtPOInvoiceNo);
                    ControlUtil.HiddenControl(false, m_toolBarSave);
                }

                //Binding Statusbar
                m_statusBarCreatedDate.Caption = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreateDate"]).ToString(Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = ds.Tables[0].Rows[0]["CreateUser"].ToString();
                if (ds.Tables[0].Rows[0]["UpdateDate"] != DBNull.Value)
                {
                    m_statusBarUpdatedDate.Caption = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdateDate"]).ToString(Common.FullDatetimeFormat);
                    m_statusBarUpdatedUser.Caption = ds.Tables[0].Rows[0]["UpdateUser"].ToString(); ;
                }
                else if (ds.Tables[0].Rows[0]["UpdateDate"] != DBNull.Value == null && ScreenMode == Common.eScreenMode.Edit)
                {
                    m_statusBarUpdatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                    m_statusBarUpdatedUser.Caption = AppConfig.UserLogin;
                }
            }

            grdPurchaseOrderDetail.DataSource = dtDetail;
            ControlUtil.SetBestWidth(gdvPurchaseOrderDetail);
        }

        private void SetDetail(DataRow dr)
        {
            dr[eDetail.ProductID.ToString()] = itemPriceControl.ProductID;
            dr[eDetail.UnitPrice.ToString()] = DataUtil.Convert<decimal>(txtPurchasePrice.EditValue);
            dr[eDetail.CurrencyID.ToString()] = itemPriceControl.CurrencyID;
            dr[eDetail.OrderQty.ToString()] = DataUtil.Convert<decimal>(txtQty.EditValue);
            dr[eDetail.UnitID.ToString()] = cboQtyUnit.EditValue;
            dr[eDetail.RemarkDetail.ToString()] = txtDetailRemark.Text;
            dr[eDetail.StatusID.ToString()] = 10;
        }

        private bool CheckCanEditOrDelete()
        {
            DataRow data = gdvPurchaseOrderDetail.GetFocusedDataRow();

            if (!iv.ValidateTicket(this.PONo))
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                return false;
            }

            if (data["StatusID"].ToString() != "10")
            {
                MessageDialog.ShowBusinessErrorMsg(this, string.Format(Rubix.Screen.Common.GetMessage("I0254"), "Purchase Order"));
                return false;
            }

            return true;
        }

        private void SaveData()
        {
            DataSet ds = new DataSet("SaleDataSet");
            try
            {
                dtDetail.TableName = "SaleDataTable";
                ds.Tables.Add(dtDetail);
                BusinessClass.SaleOrderSaveData(null, ownerControl.OwnerID, warehouseControl.WarehouseID, -999, dtShippingPeriod.DateTime.ToString("yyyy/MM/01"),
                                                          dtIssueDate.EditValue != null ? dtIssueDate.DateTime.ToString("yyyy/MM/dd") : null,
                                                          txtPONo.Text.Trim(),
                                                          null,
                                                          txtRemarkHeader.Text.Trim(), 1, ds.GetXml());
            }
            finally
            {
                ds.Tables.Clear();
                ds = null;
            }
        }

        private void SavePOInvoiceData()
        {
                BusinessClass.PurchaseOrderEditPOInvoice(this.PONo, txtPOInvoiceNo.Text.Trim());
        }

        private bool ValidateHeader()
        {
            errorProvider.ClearErrors();
            bool validate = true;

            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            supplierControl.ErrorText = Common.GetMessage("I0300");
            supplierControl.RequireField = true;

            //customerControl.ErrorText = Common.GetMessage("I0249");
            //customerControl.RequireField = true;

            if (!ownerControl.ValidateControl())
            {
                validate = false;
            }
            if (!warehouseControl.ValidateControl())
            {
                validate = false;
            }
            if (!supplierControl.ValidateControl())
            {
                validate = false;
            }
            //if (!customerControl.ValidateControl())
            //{
            //    validate = false;
            //}

            //if (string.IsNullOrEmpty(dtArrivalDate.Text))
            //{
            //    errorProvider.SetError(dtArrivalDate, Common.GetMessage("I0163"));
            //    validate = false;
            //}
            //if (string.IsNullOrEmpty(dtCollectDate.Text))
            //{
            //    errorProvider.SetError(dtCollectDate, Common.GetMessage("I0388"));
            //    validate = false;
            //}
            if (string.IsNullOrEmpty(dtIssueDate.Text))
            {
                errorProvider.SetError(dtIssueDate, Common.GetMessage("I0389"));
                validate = false;
            }
            return validate;
        }

        private Boolean ValidateDetail()
        {
            Boolean noError = true;
            errorProvider.ClearErrors();
            itemPriceControl.RequireField = true;
            itemPriceControl.ErrorText = Rubix.Screen.Common.GetMessage("I0301");

            if (!itemPriceControl.ValidateControl())
            {
                errorProvider.SetError(itemPriceControl, Rubix.Screen.Common.GetMessage("I0301"));
                noError = false;
            }

            if (txtQty.Text.Trim() == string.Empty)
            {
                errorProvider.SetError(txtQty, Rubix.Screen.Common.GetMessage("I0026"));
                noError = false;
            }

            if (cboQtyUnit.Text.Trim() == string.Empty)
            {
                errorProvider.SetError(cboQtyUnit, Rubix.Screen.Common.GetMessage("I0176"));
                noError = false;
            }

            if (noError &&  btnAdd.Visible)
            {
                DataRow[] dr = dtDetail.Select(string.Format(" ProductID = {0}", itemPriceControl.ProductID));
                if (dr.Length > 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0205"));
                    noError = false;
                }
            }

            if (noError && !ValidateOrderQty())
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0383"));
                noError = false;
            }

            return noError;
        }

        private bool ValidateOrderQty()
        {
            Boolean noError = true;
            DataTable dt = grdUnit.DataSource as DataTable;
            decimal OrderQty;
            decimal NumberOfUnitLevel2;
            decimal NumberOfUnitLevel3;
            decimal MinOrder;
            int ProductType;

            if (dt == null)
            {
                return false;
            }

            NumberOfUnitLevel2 = Convert.ToDecimal(dt.Rows[0]["NumberOfUnitLevel2"]);
            NumberOfUnitLevel3 = Convert.ToDecimal(dt.Rows[0]["NumberOfUnitLevel3"]);
            MinOrder = Convert.ToDecimal(dt.Rows[0]["MinOrder"]);
            ProductType = Convert.ToInt16(dt.Rows[0]["ProductTypeID"]);

            //Lv
            DataRow dr = (cboQtyUnit.GetSelectedDataRow() as DataRowView).Row;
            if (Convert.ToInt16(dr["Lv"]) == 1)
            {
                OrderQty = Convert.ToDecimal(txtQty.EditValue) * NumberOfUnitLevel2 * NumberOfUnitLevel3;
            }
            else if (Convert.ToInt16(dr["Lv"]) == 2)
            {
                OrderQty = Convert.ToDecimal(txtQty.EditValue) * NumberOfUnitLevel3;
            }
            else
            {
                OrderQty = Convert.ToDecimal(txtQty.EditValue);
            }

            if (Convert.ToInt32(dt.Rows[0]["ProductTypeID"]) == 2)
            {
                if (OrderQty % (NumberOfUnitLevel2 * NumberOfUnitLevel3) != 0)
                {
                    noError = false;
                }
                else if (OrderQty % (MinOrder*NumberOfUnitLevel3) != 0)
                {
                    noError = false;
                }
            }
            else
            {
                if (OrderQty % NumberOfUnitLevel3 != 0)
                {
                    noError = false;
                }
                else if (OrderQty % (MinOrder * NumberOfUnitLevel3) != 0)
                {
                    noError = false;
                }
            }

            return noError;
        }

        private void EditMode(bool On)
        {
            ControlUtil.HiddenControl(!On, btnOK,btnCancel);
            ControlUtil.HiddenControl(On, btnAdd, btnDelete, btnUpdate);
        }

        private bool ValidateCalendar()
        {
            try
            {
                errorProvider.ClearErrors();
                bool validate = true;
                //DateTime? ShippingDate = DataUtil.Convert<DateTime>(dtShippingPeriod.Text);
                //DataSet CalendarDS = CalendarBusinessClass.LoadShippingCalendar(ownerControl.OwnerID, customerControl.CustomerID, ShippingDate.Value);
                //if (CalendarDS.Tables.Count == 0)
                //{
                //    validate = false;
                //    return validate;
                //}
                //foreach (DataTable item in CalendarDS.Tables)
                //{
                //    if (item.Rows.Count == 0)
                //    {
                //        validate = false;
                //        return validate;
                //    }
                //}


                return validate;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion        
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CSI.Business.Operation;
using Rubix.Framework;
using CSI.Business.DataObjects;
using CSI.Business.Common;
using System.Linq;
using System.Globalization;

namespace Rubix.Screen.Form.Operation.A_Order.Dialog
{
    public partial class dlgASO071_SaleOrderAfterMarket : DialogBase
    {
        #region Member
        private Common.eScreenMode eScrenMode;
        private CSI.Business.Master.Product pdBusiness;
        private CSI.Business.Master.CalendarShipping clBusiness;
        private SalePurchaseOrder db;
        private ProductPrice pp;
        private TypeOfUnit tu;
        private DataTable dtDetail = null;
        private DataRow dtForEdit = null;
        private decimal deMinOrder = 0;
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
             CustomerPONo = 1
            ,CustomerPOIssueDate
            ,Validity
            ,DueDate
            ,OwnerCode
            ,CustomerCode
            ,WarehouseCode
            ,HeaderRemark
            ,ProductCode
            ,Qty
            ,Remarks
        }
        #endregion

        #region Properties
        public Common.eScreenMode ScreenMode
        {
            get { return eScrenMode; }
            set { eScrenMode = value; }
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
            set
            {
                if (db == null)
                {
                    db = new SalePurchaseOrder();
                }
                db = value;
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
        public string SONo { get; set; }
        #endregion

        #region Constructor
        public dlgASO071_SaleOrderAfterMarket()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(false, m_toolBarImport);
        }
        #endregion
        
        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (!ValidateHeader())
                {
                    return false;
                }

                if (!ValidateCalendar())
                {
                    MessageDialog.ShowBusinessErrorMsg(this, "Shipping Calendar not setup on target Month");
                    ControlUtil.EnableControl(true, dtShippingPeriod);
                    return false;
                }
                
                if (!string.IsNullOrEmpty(this.SONo) && !CheckCanEditOrDelete())
                {
                    return false;
                }

                if (dtDetail == null || dtDetail.Rows.Count <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this,Common.GetMessage("I0385"));
                    return false;
                }

                if (MessageDialog.ShowConfirmationMsg(this, Rubix.Screen.Common.GetMessage("I0015")) == DialogButton.Yes)
                {
                    ShowWaitScreen();
                    SaveData();
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

        public override bool OnCommandClear()
        {
            try
            {
                if (ScreenMode == Common.eScreenMode.Edit)
                {
                    DataLoading();
                }
                else if (ScreenMode == Common.eScreenMode.Add)
                {
                    //dtDetail.Rows.Clear();
                    dtDetail = null;
                    DataLoading();
                    ControlUtil.ClearControlData(groupControl1.Controls);
                    ControlUtil.ClearControlData(groupControl2.Controls);
                    errorProvider.ClearErrors();
                    grdSaleOrderDetail.DataSource = null;

                    ControlUtil.EnableControl(true, dtShippingPeriod);
                    ownerControl.EnableControl = true;
                    customerControl.EnableControl = true;
                    warehouseControl.EnableControl = true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
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
                    grdSaleOrderDetail.DataSource = null;
                    dtDetail.Rows.Clear();
                    
                    using (excel)
                    {
                        excel.OpenExcel(ofdImport.FileName);
                        int row = 2;
                        //SO header
                        string CustomerPONo = excel.ReadData(row, (int)eColImport.CustomerPONo).Trim();
                        string CustomerPOIssueDate = excel.ReadData(row, (int)eColImport.CustomerPOIssueDate);
                        string Validity = excel.ReadData(row, (int)eColImport.Validity);
                        string DueDate = excel.ReadData(row, (int)eColImport.DueDate).Trim();
                        string OwnerCode = excel.ReadData(row, (int)eColImport.OwnerCode).Trim();
                        string CustomerCode = excel.ReadData(row, (int)eColImport.CustomerCode).Trim();
                        string WarehouseCode = excel.ReadData(row, (int)eColImport.WarehouseCode).Trim();
                        string HeaderRemark = excel.ReadData(row, (int)eColImport.HeaderRemark).Trim();
                        
                        if(CustomerPONo == string.Empty)
                        {
                            errorMsg += Common.GetMessage("I0279", "Customer PO Number", CustomerPONo) + Environment.NewLine;
                        }                       
                        //==========================================================================================================================
                        try
                        {
                            if (DateTime.ParseExact(CustomerPOIssueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) == null)
                            {
                                errorMsg += Common.GetMessage("I0279", "Customer PO Issue Date", CustomerPOIssueDate) + Environment.NewLine;
                            }
                        }
                        catch (Exception ex)
                        {                            
                            errorMsg += Common.GetMessage("I0279", "Customer PO Issue Date", CustomerPOIssueDate) + Environment.NewLine;
                        }
                        //==========================================================================================================================
                        try
                        {
                            if (DateTime.ParseExact( DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) == null)
                            {
                                errorMsg += Common.GetMessage("I0279", "Due Date", DueDate) + Environment.NewLine;
                            }
                            else
                            {
                                DateTime ShippingPeriod = DateTime.ParseExact(DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
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
                            errorMsg += Common.GetMessage("I0279", "Due Date", DueDate) + Environment.NewLine;
                        }
                        //==========================================================================================================================
                        try
                        {
                            if (!BusinessClass.SaleOrderCheckValidCustomerPO(CustomerPONo, DateTime.ParseExact(DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                            {
                                //I0400 --Customer PO No. {0} has already imported and confirmed Sale Order.
                                errorMsg += Common.GetMessage("I0400", CustomerPONo) + Environment.NewLine;
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                        //==========================================================================================================================
                        ownerControl.OwnerCode = OwnerCode;
                        if (ownerControl.OwnerID == null)
                        {
                            errorMsg += Common.GetMessage("I0279", "Owner Code", OwnerCode) + Environment.NewLine;
                        }

                        customerControl.CustomerCode = CustomerCode;
                        if (customerControl.CustomerID == null)
                        {
                            errorMsg += Common.GetMessage("I0279", "Customer Code", CustomerCode) + Environment.NewLine;
                        }

                        warehouseControl.WarehouseCode = WarehouseCode;
                        if (warehouseControl.WarehouseID == null)
                        {
                            errorMsg += Common.GetMessage("I0279", "Warehouse Code", WarehouseCode) + Environment.NewLine;
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
                            txtCustomerPONo.Text = CustomerPONo;
                            dtCustomerPOIssueDate.EditValue = DateTime.ParseExact(CustomerPOIssueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            dtShippingPeriod.EditValue = DateTime.ParseExact(DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            txtValidity.Text = Validity;
                            txtRemark.Text = HeaderRemark;
                               
                            if (!BusinessClass.SaleOrderCheckCompanyCalendar(ownerControl.OwnerID, dtShippingPeriod.DateTime.ToString("yyyy/MM/dd")))
                            {
                                //I0401 --You must be set working date on "Company Calendar Screen" for month "{0}" and "{1}"
                                errorMsg += Common.GetMessage("I0412", dtShippingPeriod.DateTime.ToString("MMMM"), dtShippingPeriod.DateTime.AddMonths(1).ToString("MMMM")) + Environment.NewLine;
                                dtDetail.Clear();
                                ControlUtil.ClearControlData(groupControl1.Controls);
                                ControlUtil.ClearControlData(groupControl2.Controls);
                                return false;
                            }
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
                                else if (!BusinessClass.SaleOrderCheckShippingCalendar(ownerControl.OwnerID, customerControl.CustomerID, itemPriceControl.ProductID, dtShippingPeriod.DateTime.ToString("yyyy/MM/dd")))
                                {
                                    //I0401 --You must be set Shipping Calendar of Product "{0}" for month "{1}""
                                    errorDetailMsg += Common.GetMessage("I0401", ProductCode, dtShippingPeriod.DateTime.ToString("MMMM")) + Environment.NewLine;
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
                                                                
                                ControlUtil.ClearControlData(itemPriceControl, txtSalePrice, txtSalePriceCurrency, txtDetailRemark, txtQty, cboQtyUnit, txtMinOrder);
                                grdUnit.DataSource = null;
                            }
                            else
                            {
                                errorMsg += string.Format("Row{0}-{1}{2}{3}", row, ProductCode, Environment.NewLine, errorDetailMsg);
                            }
                            row++;
                        } //while
                    } //using excel                    
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
                    grdSaleOrderDetail.DataSource = dtDetail;
                    ControlUtil.SetBestWidth(gdvSaleOrderDetail);
                }
            }
        }
        #endregion

        #region Event Handler

        private void dlgASO071_SaleOrderAfterMarket_Load(object sender, EventArgs e)
        {
            try
            {
                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                itemPriceControl.PriceType = Control.ItemPriceControl.ePriceType.Sale;
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
                    itemPriceControl.OwnerID = ownerControl.OwnerID;
                    itemPriceControl.DataLoading();
                }
                else
                {
                    customerControl.OwnerID = Common.GetDefaultOwnerID();
                    customerControl.DataLoading();
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    itemPriceControl.OwnerID = Common.GetDefaultOwnerID();
                    itemPriceControl.DataLoading();
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
                if (ownerControl.OwnerID != null)
                {
                    itemPriceControl.OwnerID = ownerControl.OwnerID;
                    itemPriceControl.WarehouseID = warehouseControl.WarehouseID;
                    itemPriceControl.DataLoading();
                    List<sp_common_LoadProductPrice_Result> list = ProductPriceBusiness.DataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, customerControl.CustomerID, Control.ItemPriceControl.ePriceType.Sale.ToString());
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

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (customerControl.CustomerID != null)
                {
                    itemPriceControl.CustomerSupplierID = customerControl.CustomerID;
                    itemPriceControl.DataLoading();
                    List<sp_common_LoadProductPrice_Result> list = ProductPriceBusiness.DataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, customerControl.CustomerID, Control.ItemPriceControl.ePriceType.Sale.ToString());
                    repProductCode.DataSource = list;
                    repProductName.DataSource = list;

                }
                else
                {
                    itemPriceControl.CustomerSupplierID = -1;
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
                    txtSalePrice.EditValue = itemPriceControl.UnitPrice;
                    txtSalePriceCurrency.Text = itemPriceControl.CurrencyName;

                    DataSet ds = TypeUnitBusiness.LoadUnitSale(itemPriceControl.ProductID == null ? -1 : itemPriceControl.ProductID);
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
                    txtSalePrice.EditValue = null;
                    txtSalePriceCurrency.Text = string.Empty;
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

                    ControlUtil.SetBestWidth(gdvSaleOrderDetail);
                    ControlUtil.ClearControlData(itemPriceControl, txtSalePrice, txtSalePriceCurrency, txtDetailRemark, txtQty, cboQtyUnit, txtMinOrder);
                    grdUnit.DataSource = null;
                    if (dtDetail.Rows.Count > 0)
                    {
                        ControlUtil.EnableControl(false, dtShippingPeriod);
                        ownerControl.EnableControl = false;
                        customerControl.EnableControl = false;
                        warehouseControl.EnableControl = false;
                    }

                    grdSaleOrderDetail.DataSource = dtDetail;
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
                if (gdvSaleOrderDetail.RowCount > 0 && CheckCanEditOrDelete())
                {
                    DataRow dr = gdvSaleOrderDetail.GetFocusedDataRow();

                    if (dr != null)
                    {
                        dtForEdit = dr;
                        itemPriceControl.ProductID = DataUtil.Convert<int>(dr[eDetail.ProductID.ToString()]);
                        txtSalePrice.EditValue = dr[eDetail.UnitPrice.ToString()];
                        txtSalePriceCurrency.EditValue = itemPriceControl.CurrencyName;
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
                DataRow dr = gdvSaleOrderDetail.GetFocusedDataRow();
                if (dr != null)
                {
                    if (dr.RowState == DataRowState.Added || CheckCanEditOrDelete())
                    {
                        gdvSaleOrderDetail.DeleteSelectedRows();
                    }

                    if (dtDetail.Rows.Count <= 0)
                    {
                        ControlUtil.EnableControl(true, dtShippingPeriod);
                        ownerControl.EnableControl = true;
                        customerControl.EnableControl = true;
                        warehouseControl.EnableControl = true;
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
                    ControlUtil.SetBestWidth(gdvSaleOrderDetail);
                    ControlUtil.ClearControlData(itemPriceControl, txtSalePrice, txtSalePriceCurrency, txtDetailRemark, txtQty, cboQtyUnit, txtMinOrder);
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
                ControlUtil.SetBestWidth(gdvSaleOrderDetail);
                ControlUtil.ClearControlData(itemPriceControl, txtSalePrice, txtSalePriceCurrency, txtDetailRemark, txtQty, cboQtyUnit, txtMinOrder);
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

                if (dtDetail == null)
                {
                    dtDetail = new DataTable();
                    dtDetail.Columns.Add(eDetail.No.ToString(), typeof(int));
                    dtDetail.Columns.Add(eDetail.LineNo.ToString(), typeof(int));
                    dtDetail.Columns.Add(eDetail.ProductID.ToString(), typeof(int));
                    dtDetail.Columns.Add(eDetail.UnitPrice.ToString(), typeof(decimal));
                    dtDetail.Columns.Add(eDetail.CurrencyID.ToString(), typeof(int));
                    dtDetail.Columns.Add(eDetail.OrderQty.ToString(), typeof(int));
                    dtDetail.Columns.Add(eDetail.UnitID.ToString(), typeof(int));
                    dtDetail.Columns.Add(eDetail.RemarkDetail.ToString(), typeof(string));
                    dtDetail.Columns.Add(eDetail.StatusID.ToString(), typeof(int));
                }
            }
            else
            {
                DataSet ds = BusinessClass.SaleOrderDataLoadingDetail(this.SONo);
                dtDetail = ds.Tables[1].Copy();

                txtStatus.Text = ds.Tables[0].Rows[0]["StatusName"].ToString();
                txtSONo.Text = ds.Tables[0].Rows[0]["SONo"].ToString();
                ownerControl.OwnerID = Convert.ToInt32(ds.Tables[0].Rows[0]["OwnerID"]);
                customerControl.CustomerID = Convert.ToInt32(ds.Tables[0].Rows[0]["CustomerID"]);
                warehouseControl.WarehouseID = Convert.ToInt32(ds.Tables[0].Rows[0]["WarehouseID"]);
                dtShippingPeriod.EditValue = ds.Tables[0].Rows[0]["ShippingPeriod"];
                txtCustomerPONo.Text = ds.Tables[0].Rows[0]["CustomerPO"].ToString();
                dtCustomerPOIssueDate.EditValue = DataUtil.Convert<DateTime>(ds.Tables[0].Rows[0]["CustomerPOIssueDate"]);
                txtValidity.Text = ds.Tables[0].Rows[0]["Validity"].ToString();
                txtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();

                if (dtDetail.Rows.Count > 0)
                {
                    ControlUtil.EnableControl(false, dtShippingPeriod);
                    ownerControl.EnableControl = false;
                    customerControl.EnableControl = false;
                    warehouseControl.EnableControl = false;
                }

                if (this.ScreenMode == Common.eScreenMode.View)
                {
                    ControlUtil.EnableControl(false, groupControl1.Controls);
                    ControlUtil.EnableControl(false, itemPriceControl, txtQty, cboQtyUnit, txtDetailRemark);
                    ControlUtil.EnableControl(false, btnAdd, btnDelete, btnOK, btnUpdate,btnCancel);
                    ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarClear, m_toolBarImport);
                }

                //Binding Statusbar
                m_statusBarCreatedDate.Caption = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreateDate"]).ToString(Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = ds.Tables[0].Rows[0]["CreateUser"].ToString();
                if (ds.Tables[0].Rows[0]["UpdateDate"] != DBNull.Value)
                {
                    m_statusBarUpdatedDate.Caption = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdateDate"]).ToString(Common.FullDatetimeFormat);
                    m_statusBarUpdatedUser.Caption = ds.Tables[0].Rows[0]["UpdateUser"].ToString();;
                }
                else if (ds.Tables[0].Rows[0]["UpdateDate"] != DBNull.Value == null && ScreenMode == Common.eScreenMode.Edit)
                {
                    m_statusBarUpdatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                    m_statusBarUpdatedUser.Caption = AppConfig.UserLogin;
                }
            }

            grdSaleOrderDetail.DataSource = dtDetail;
            ControlUtil.SetBestWidth(gdvSaleOrderDetail);
        }

        private void SetDetail(DataRow dr)
        {
            dr[eDetail.ProductID.ToString()] = itemPriceControl.ProductID;
            dr[eDetail.ProductID.ToString()] = itemPriceControl.ProductID;
            dr[eDetail.UnitPrice.ToString()] = DataUtil.Convert<decimal>(txtSalePrice.EditValue);
            dr[eDetail.CurrencyID.ToString()] = itemPriceControl.CurrencyID;
            dr[eDetail.OrderQty.ToString()] = DataUtil.Convert<decimal>(txtQty.EditValue);
            dr[eDetail.UnitID.ToString()] = cboQtyUnit.EditValue;
            dr[eDetail.RemarkDetail.ToString()] = txtDetailRemark.Text;
            dr[eDetail.StatusID.ToString()] = 1;
        }

        private bool CheckCanEditOrDelete()
        {
            DataRow data = gdvSaleOrderDetail.GetFocusedDataRow();

            if (!iv.ValidateTicket(this.SONo))
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                return false;
            }

            if (Convert.ToInt32(data["StatusID"]) != Status.NewSaleOrder)
            {
                MessageDialog.ShowBusinessErrorMsg(this, string.Format(Rubix.Screen.Common.GetMessage("I0254"), "Sale Order"));
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
                BusinessClass.SaleOrderSaveDataAfterMarket(this.SONo, ownerControl.OwnerID, warehouseControl.WarehouseID, customerControl.CustomerID,
                                                dtShippingPeriod.DateTime.ToString("yyyy/MM/dd"),
                                                dtCustomerPOIssueDate.EditValue != null ? dtCustomerPOIssueDate.DateTime.ToString("yyyy/MM/dd") : null,
                                                txtCustomerPONo.Text.Trim(), txtValidity.Text.Trim(), txtRemark.Text.Trim(),1, ds.GetXml());
            }
            finally
            {
                ds.Tables.Clear();
                ds = null;
            }
        }

        private bool ValidateCalendar()
        {
            try
            {
                errorProvider.ClearErrors();
                bool validate = true;
                //DateTime? ShippingDate = DataUtil.Convert<DateTime>(dtShippingPeriod.Text);
                DateTime? ShippingDate = dtShippingPeriod.DateTime;
                DataSet CalendarDS = CalendarBusinessClass.LoadShippingCalendar(ownerControl.OwnerID, customerControl.CustomerID, ShippingDate.Value);
                if (CalendarDS.Tables.Count == 0)
                {
                    validate = false;
                    return validate;
                }
                foreach (DataTable item in CalendarDS.Tables)
                {
                    if (item.Rows.Count == 0)
                    {
                        validate = false;
                        return validate;
                    }
                }
                

                return validate;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private bool ValidateHeader()
        {
            errorProvider.ClearErrors();
            bool validate = true;

            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            customerControl.ErrorText = Common.GetMessage("I0249");
            customerControl.RequireField = true;

            validate &= ownerControl.ValidateControl();
            validate &= warehouseControl.ValidateControl();
            validate &= customerControl.ValidateControl();

            if (string.IsNullOrEmpty(txtCustomerPONo.Text))
            {
                errorProvider.SetError(txtCustomerPONo, Common.GetMessage("I0416"));
                validate = false;
            }

            if (string.IsNullOrEmpty(dtCustomerPOIssueDate.Text))
            {
                errorProvider.SetError(dtCustomerPOIssueDate, Common.GetMessage("I0425"));
                validate = false;
            }

            if (string.IsNullOrEmpty(dtShippingPeriod.Text))
            {
                errorProvider.SetError(dtShippingPeriod, Common.GetMessage("I0329"));
                validate = false;
            }
            else if (dtShippingPeriod.DateTime < DateTime.Today)
            {
                errorProvider.SetError(dtShippingPeriod, Common.GetMessage("I0386"));
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
                errorProvider.SetError(txtQty, Rubix.Screen.Common.GetMessage("I0298"));
                noError = false;
            }

            if (cboQtyUnit.Text.Trim() == string.Empty)
            {
                errorProvider.SetError(cboQtyUnit, Rubix.Screen.Common.GetMessage("I0176"));
                noError = false;
            }

            if (noError && btnAdd.Visible)
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
                else if (OrderQty % (MinOrder * NumberOfUnitLevel3) != 0)
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
        #endregion        
    }
}
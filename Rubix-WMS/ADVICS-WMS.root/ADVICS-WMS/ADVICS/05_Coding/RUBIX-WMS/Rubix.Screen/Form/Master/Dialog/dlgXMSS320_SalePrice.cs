using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSI.Business.Master;
using Rubix.Framework;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using CSI.Business.DataObjects;

namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS320_SalePrice : DialogBase
    {
        
        
        #region Enum

        enum eColImport
        {
            CustomerID = 1 
            ,ProductID
            ,SalePrice
            ,CurrencyID
            ,Incoterm
            ,EffectiveDate
            ,ImplementDate
            ,HSCode
            ,PVID
            ,Remark
            ,ErrorDetail

        }

        #endregion

        #region Member
       
        private Customer customerdb = null;
        private Product productdb = null;
        private DataTable dtResult = null;
        private Currency currencydb = null;
        private SalePrice salepricedb = null;
        private Privilege pvdb = null;
        private String FileName;
        private bool isValidData = true;

        #endregion

        #region Properties
        public SalePrice SalePriceBusinessClass
        {
            get
            {
                if (salepricedb == null)
                {
                    salepricedb = new SalePrice();
                }
                return salepricedb;
            }
            set
            {
                salepricedb = value;
            }
        }
        public Customer CustomerBusinessClass
        {
            get
            {
                if (customerdb == null)
                {
                    customerdb = new Customer();
                }
                return customerdb;
            }
            set
            {
                customerdb = value;
            }
        }
        public Product ProductBusinessClass
        {
            get
            {
                if (productdb == null)
                {
                    productdb = new Product();
                }
                return productdb;
            }
            set
            {
                productdb = value;
            }
        }
        public Currency CurrencyBusinessClass
        {
            get
            {
                if (currencydb == null)
                {
                    currencydb = new Currency();
                }
                return currencydb;
            }
            set
            {
                currencydb = value;
            }
        }
        public Privilege PrivilegeBusinessClass
        {
            get
            {
                if (pvdb == null)
                {
                    pvdb = new Privilege();
                }
                return pvdb;
            }
            set
            {
                pvdb = value;
            }
        }
        #endregion

        #region Constructor
        
        public dlgXMSS320_SalePrice(string fileName)
        {
            InitializeComponent();
            this.FileName = fileName;
        }


        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {

            try
            {
                gdvResult.CloseEditor();
                gdvResult.UpdateCurrentRow();
                bool isError = false;
                foreach (DataRow item in dtResult.Rows)
                {
                    if (!string.IsNullOrEmpty(item["ErrorDetail"].ToString()))
                        isError = true;

                }

                if (gdvResult.RowCount <= 0 || isError)
                    return false;

                if (isValidData)
                {

                    if (MessageDialog.ShowConfirmationMsg(this, Rubix.Screen.Common.GetMessage("I0015")) == DialogButton.Yes)
                    {
                        base.ShowWaitScreen();
                        DataTable dtAdd = null;

                        DataRow[] drAdd = dtResult.Select();

                        if (drAdd.Length > 0)
                        {
                            dtAdd = drAdd.CopyToDataTable();
                        }

                        if (dtAdd != null)
                        {
                            DataSet ds = new DataSet("SalePriceDataSet");
                            dtAdd.TableName = "SalePriceDataTable";
                            dtAdd.Columns["EffectiveDate"].DateTimeMode = DataSetDateTime.Unspecified;
                            dtAdd.Columns["ImplementDate"].DateTimeMode = DataSetDateTime.Unspecified;
                            
                            ds.Tables.Add(dtAdd);

                            SalePriceBusinessClass.SaveData(ds.GetXml(), AppConfig.UserLogin);

                            MessageDialog.ShowInformationMsg(Rubix.Screen.Common.GetMessage("I0003"));
                            ds.Tables.Clear();
                        }
                        base.CloseWaitScreen();

                        gdvResult.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                        DialogResult = DialogResult.OK;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                base.CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }

        } 
        #endregion

        #region Event Handler
        
        private void dlgXMSS320_SalePrice_Load(object sender, EventArgs e)
        {
            InitialCombobox();
            dtResult = new DataTable();
            if (dtResult.Rows.Count <= 0)
            {
                dtResult.Columns.Add("CustomerID", typeof(int));
                dtResult.Columns.Add("ProductID", typeof(int));
                dtResult.Columns.Add("SalePrice", typeof(string));
                dtResult.Columns.Add("CurrencyID", typeof(int));
                dtResult.Columns.Add("Incoterm", typeof(string));
                dtResult.Columns.Add("EffectiveDate", typeof(DateTime));
                dtResult.Columns.Add("ImplementDate", typeof(DateTime));
                dtResult.Columns.Add("HSCode", typeof(string));
                dtResult.Columns.Add("PVID", typeof(int));
                dtResult.Columns.Add("Remark", typeof(string));
                dtResult.Columns.Add("ErrorDetail", typeof(string));
            }

            grdResult.DataSource = dtResult;

            ImportFile();

            base.GridViewOnChangeLanguage(grdResult);

            ControlUtil.HiddenControl(true, m_toolBarClear);
        }

        private void gdvResult_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            DataRow dr = gdvResult.GetFocusedDataRow();

            if (view.FocusedColumn.FieldName == "EffectiveDate")
            {
                if (Convert.ToDateTime(e.Value) < DateTime.Today)
                {
                    e.Valid = false;
                    e.ErrorText = Rubix.Screen.Common.GetMessage("I0354");
                }
                //else
                //{

                //    if (string.IsNullOrEmpty(dr["ImplementDate"].ToString()))
                //    {
                //        dr["ImplementDate"] = e.Value;
                //    }
                //}
            }
            else if (view.FocusedColumn.FieldName == "ImplementDate")
            {
                if (dr["EffectiveDate"] == DBNull.Value)
                {
                    e.Value = null;
                }
                else if (e.Value != null && Convert.ToDateTime(e.Value) < Convert.ToDateTime(dr["EffectiveDate"]))
                {
                    e.Valid = false;
                    e.ErrorText = Rubix.Screen.Common.GetMessage("I0379");
                }


            }
        }

        private void gdvResult_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool isValid = true;
            string errMsg = string.Empty;
            ColumnView view = sender as ColumnView;
            view.ClearColumnErrors();

            e.ErrorText = Rubix.Screen.Common.GetMessage("I0353");

            if (view.GetRowCellValue(e.RowHandle, gdcCustomerCode).ToString().Trim() == String.Empty)
            {
                isValid = false;
                errMsg += Rubix.Screen.Common.GetMessage("I0256");
                view.SetColumnError(gdcCustomerCode, Rubix.Screen.Common.GetMessage("I0256"));

            }

            if (view.GetRowCellValue(e.RowHandle, gdcProductCode).ToString().Trim() == String.Empty)
            {
                isValid = false;
                if (!string.IsNullOrEmpty(errMsg))
                    errMsg += Environment.NewLine;
                errMsg += Rubix.Screen.Common.GetMessage("I0291");
                view.SetColumnError(gdcProductCode, Rubix.Screen.Common.GetMessage("I0291"));
            }

            //EffectiveDate
            if (view.GetRowCellValue(e.RowHandle, gdcEffectiveDate).ToString().Trim() == String.Empty)
            {
                isValid = false;
                if (!string.IsNullOrEmpty(errMsg))
                    errMsg += Environment.NewLine;
                errMsg += Rubix.Screen.Common.GetMessage("I0319");
                view.SetColumnError(gdcEffectiveDate, Rubix.Screen.Common.GetMessage("I0319"));
            }
            else if (Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, gdcEffectiveDate)) < DateTime.Today)
            {
                isValid = false;
                if (!string.IsNullOrEmpty(errMsg))
                    errMsg += Environment.NewLine;
                errMsg += Rubix.Screen.Common.GetMessage("I0354");
                view.SetColumnError(gdcEffectiveDate, Rubix.Screen.Common.GetMessage("I0354"));
            }

            //ImplementDate
            if (view.GetRowCellValue(e.RowHandle, gdcImplementDate) != DBNull.Value)
            {
                if (view.GetRowCellValue(e.RowHandle, gdcEffectiveDate) != DBNull.Value
                    && view.GetRowCellValue(e.RowHandle, gdcImplementDate) != DBNull.Value
                    && Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, gdcImplementDate)) < Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, gdcEffectiveDate)))
                {
                    isValid = false;
                    if (!string.IsNullOrEmpty(errMsg))
                        errMsg += Environment.NewLine;
                    errMsg += Rubix.Screen.Common.GetMessage("I0379");
                    view.SetColumnError(gdcImplementDate, Rubix.Screen.Common.GetMessage("I0379"));
                }
            }

            if (view.GetRowCellValue(e.RowHandle, gdcSalePrice).ToString().Trim() == String.Empty)
            {
                isValid = false;
                if (!string.IsNullOrEmpty(errMsg))
                    errMsg += Environment.NewLine;
                errMsg += Rubix.Screen.Common.GetMessage("I0355");
                view.SetColumnError(gdcSalePrice, Rubix.Screen.Common.GetMessage("I0355"));
            }

            if (view.GetRowCellValue(e.RowHandle, gdcCurrencyCode).ToString().Trim() == String.Empty)
            {
                isValid = false;
                if (!string.IsNullOrEmpty(errMsg))
                    errMsg += Environment.NewLine;
                errMsg += Rubix.Screen.Common.GetMessage("I0356");
                view.SetColumnError(gdcCurrencyCode, Rubix.Screen.Common.GetMessage("I0356"));
            }



            if (isValid)
            {

                int iCustomerID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, gdcCustomerCode));
                int iProductID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, gdcProductCode));
                DateTime EffectiveDate = Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, gdcEffectiveDate));



                if (SalePriceBusinessClass.CheckExist(null, iCustomerID, iProductID, Convert.ToDateTime(EffectiveDate.ToString("dd/MM/yyyy"))))
                {
                    isValid = false;
                    if (!string.IsNullOrEmpty(errMsg))
                        errMsg += Environment.NewLine;
                    errMsg += Rubix.Screen.Common.GetMessage("I0205");
                    view.SetColumnError(gdcCustomerCode, Rubix.Screen.Common.GetMessage("I0205"));
                    view.SetColumnError(gdcProductCode, Rubix.Screen.Common.GetMessage("I0205"));
                }

            }
            //this.isValidData = isValid;
            e.Valid = true;

            if (isValid)
                errMsg = string.Empty;

            view.SetRowCellValue(e.RowHandle, gdcErrorDetail, errMsg);
            base.GridViewOnChangeLanguage(grdResult);
            //gdvResult.GetFocusedDataRow()["ErrorDetail"] = errMsg;
            //dtResult.AcceptChanges();
        }

        #endregion

        #region Generic function

        private void ImportFile()
        {

            ExcelManager excel = new ExcelManager();
            try
            {
                this.ShowWaitScreen();
                //grdSearchResult.DataSource = null;
                dtResult.Clear();

                using (excel)
                {

                    ////////////////////////////////////////////////////////////////
                    ///        list for Purchase Price from file import          ///
                    ////////////////////////////////////////////////////////////////

                    excel.OpenExcel(FileName);

                    //read header
                    int row = 2;
                    while (!string.IsNullOrWhiteSpace(excel.ReadData(row, (int)eColImport.CustomerID)))
                    {
                        DataRow dr = dtResult.NewRow();
                        string errorMsg = string.Empty;

                        string CustomerCode = excel.ReadData(row, (int)eColImport.CustomerID).Trim();
                        string ProductCode = excel.ReadData(row, (int)eColImport.ProductID).Trim();
                        string SalePrice = excel.ReadData(row, (int)eColImport.SalePrice).Trim();
                        string EffectiveDate = excel.ReadData(row, (int)eColImport.EffectiveDate).Trim();
                        string ImplementDate = excel.ReadData(row, (int)eColImport.ImplementDate).Trim();
                        string CurrencyCode = excel.ReadData(row, (int)eColImport.CurrencyID).Trim();
                        string Incoterm = excel.ReadData(row, (int)eColImport.Incoterm).Trim();
                        string HSCode = excel.ReadData(row, (int)eColImport.HSCode).Trim();
                        string PVCode = excel.ReadData(row, (int)eColImport.PVID).Trim();
                        string Remark = excel.ReadData(row, (int)eColImport.Remark).Trim();



                        /////Validate CustomerCode
                        List<sp_XMSS270_Customer_SearchAll_Result> _customer= CustomerBusinessClass.DataLoading(null,CustomerCode,null);

                        if (string.IsNullOrEmpty(CustomerCode) || _customer.Count == 0)
                        {
                            errorMsg += Common.GetMessage("I0279", "Customer Code", CustomerCode);
                        }
                        else
                        {
                            dr[eColImport.CustomerID.ToString()] = _customer[0].CustomerID;

                        }

                        /////Validate ItemCode
                        DataTable _product = ProductBusinessClass.DataLoading(null, ProductCode, null,null);
                        if (string.IsNullOrEmpty(ProductCode) || _product.Rows.Count == 0)
                        {
                            if (!string.IsNullOrEmpty(errorMsg))
                                errorMsg += Environment.NewLine;
                            errorMsg += Common.GetMessage("I0279", "Part Number", ProductCode);
                        }
                        else
                        {
                            dr[eColImport.ProductID.ToString()] = Convert.ToInt32(_product.Rows[0]["ProductID"]);
                        }

                        /////Validate EffectiveDate
                        DateTime _date;
                        if (string.IsNullOrEmpty(EffectiveDate) || !DateTime.TryParse(EffectiveDate, out _date))
                        {
                            if (!string.IsNullOrEmpty(errorMsg))
                                errorMsg += Environment.NewLine;
                            errorMsg += Common.GetMessage("I0279", "Effective Date", EffectiveDate);
                        }
                        else
                        {
                            dr[eColImport.EffectiveDate.ToString()] = DataUtil.Convert<DateTime>(EffectiveDate);

                            if (DataUtil.Convert<DateTime>(EffectiveDate) < DateTime.Today)
                            {
                                if (!string.IsNullOrEmpty(errorMsg))
                                    errorMsg += Environment.NewLine;
                                errorMsg += Rubix.Screen.Common.GetMessage("I0354");
                            }

                            if (SalePriceBusinessClass.CheckExist(null, _customer[0].CustomerID, Convert.ToInt32(_product.Rows[0]["ProductID"]), Convert.ToDateTime(DateTime.Parse(EffectiveDate).ToString("yyyy/MM/dd"))))
                            {
                                if (!string.IsNullOrEmpty(errorMsg))
                                    errorMsg += Environment.NewLine;
                                errorMsg += Rubix.Screen.Common.GetMessage("I0205");
                            }
                        }

                        /////Validate ImplementDate

                        //if (string.IsNullOrEmpty(ImplementDate) || !DateTime.TryParse(ImplementDate, out _date))
                        //{
                        //    if (!string.IsNullOrEmpty(errorMsg))
                        //        errorMsg += Environment.NewLine;
                        //    errorMsg += Common.GetMessage("I0279", "ImplementDate", ImplementDate);
                        //}
                        //else
                        //{
                        if (!string.IsNullOrEmpty(ImplementDate))
                        {
                            if ((!string.IsNullOrEmpty(EffectiveDate) && DateTime.TryParse(EffectiveDate, out _date))
                                && !string.IsNullOrEmpty(ImplementDate) && DateTime.TryParse(ImplementDate, out _date)
                                && DataUtil.Convert<DateTime>(ImplementDate) < DataUtil.Convert<DateTime>(EffectiveDate))
                            {
                                if (!string.IsNullOrEmpty(errorMsg))
                                    errorMsg += Environment.NewLine;
                                errorMsg += Rubix.Screen.Common.GetMessage("I0379");
                            }
                                
                            dr[eColImport.ImplementDate.ToString()] = DataUtil.Convert<DateTime>(ImplementDate);

                        }
                            
                        //}


                        /////Validate SalePrice
                        Decimal _decimal;
                        if (string.IsNullOrEmpty(SalePrice) || !Decimal.TryParse(SalePrice, out _decimal))
                        {
                            if (!string.IsNullOrEmpty(errorMsg))
                                errorMsg += Environment.NewLine;
                            errorMsg += Common.GetMessage("I0279", "Sale Price", SalePrice);
                        }
                        else
                        {
                            dr[eColImport.SalePrice.ToString()] = SalePrice;
                        }

                        ////Validate CurrencyCode
                        DataTable dtCurrency = CurrencyBusinessClass.DataLoading(CurrencyCode, null);
                        if (string.IsNullOrEmpty(CurrencyCode) || dtCurrency.Rows.Count == 0)
                        {
                            if (!string.IsNullOrEmpty(errorMsg))
                                errorMsg += Environment.NewLine;
                            errorMsg += Rubix.Screen.Common.GetMessage("I0279", "CurrencyCode", CurrencyCode);
                        }
                        else
                        {
                            dr[eColImport.CurrencyID.ToString()] = dtCurrency.Rows[0]["CurrencyID"];
                        }

                        /////Validate CustomerCode
                        DataTable _pv = PrivilegeBusinessClass.DataLoading(PVCode, null);

                        if (string.IsNullOrEmpty(PVCode) || _pv.Rows.Count == 0)
                        {
                            if (!string.IsNullOrEmpty(errorMsg))
                                errorMsg += Environment.NewLine;
                            errorMsg += Common.GetMessage("I0279", "Privilege Code", PVCode);
                        }
                        else
                        {
                            dr[eColImport.PVID.ToString()] = _pv.Rows[0]["PVID"];

                        }

                        ////Validate Incoterm
                        if (!string.IsNullOrWhiteSpace(Incoterm) && Incoterm.Length > 50)
                        {
                            if (!string.IsNullOrEmpty(errorMsg))
                                errorMsg += Environment.NewLine;
                            errorMsg += Rubix.Screen.Common.GetMessage("I0378");
                        }
                        else
                        {
                            dr[eColImport.Incoterm.ToString()] = Incoterm;
                        }

                        ////Validate HSCode
                        if (!string.IsNullOrWhiteSpace(HSCode) && HSCode.Length > 50)
                        {
                            if (!string.IsNullOrEmpty(errorMsg))
                                errorMsg += Environment.NewLine;
                            errorMsg += Rubix.Screen.Common.GetMessage("I0380");
                        }
                        else
                        {
                            dr[eColImport.HSCode.ToString()] = HSCode;
                        }
                        ////Validate Remark
                        if (!string.IsNullOrWhiteSpace(Remark) && Remark.Length > 200)
                        {
                            if (!string.IsNullOrEmpty(errorMsg))
                                errorMsg += Environment.NewLine;
                            errorMsg += Rubix.Screen.Common.GetMessage("I0280");
                        }
                        else
                        {
                            dr[eColImport.Remark.ToString()] = Remark;
                        }

                        //if (SalePriceBusinessClass.CheckExist(null
                        //        ,Convert.ToInt32(dr[eColImport.CustomerID.ToString()])
                        //        ,Convert.ToInt32(dr[eColImport.ProductID.ToString()])
                        //        ,Convert.ToDateTime(Convert.ToDateTime(dr[eColImport.CustomerID.ToString()]).ToString("dd/MM/yyyy"))))
                        //{
                        //    if (!string.IsNullOrEmpty(errorMsg))
                        //        errorMsg += Environment.NewLine;
                        //    errorMsg += Rubix.Screen.Common.GetMessage("I0205");
                        //    view.SetColumnError(gdcCustomerCode, Rubix.Screen.Common.GetMessage("I0205"));
                        //    view.SetColumnError(gdcProductCode, Rubix.Screen.Common.GetMessage("I0205"));
                        //}
                        
                        dr[eColImport.ErrorDetail.ToString()] = errorMsg;

                        dtResult.Rows.Add(dr);


                        row++;
                    }


                } //using excel
                //else              
            }
            catch (Exception ex)
            {

                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
            finally
            {
                this.CloseWaitScreen();
                excel.Dispose();
            }

        }

        private void InitialCombobox()
        {
            repCustomerCode.DataSource = CustomerBusinessClass.DataLoading(null, null, null);
            repItemCode.DataSource = ProductBusinessClass.DataLoading(null, null, null,null);
            repCurrencyCode.DataSource = CurrencyBusinessClass.DataLoading(null, null);
            repPVCode.DataSource = PrivilegeBusinessClass.DataLoading(null, null);
        }

        #endregion

        
    }
}
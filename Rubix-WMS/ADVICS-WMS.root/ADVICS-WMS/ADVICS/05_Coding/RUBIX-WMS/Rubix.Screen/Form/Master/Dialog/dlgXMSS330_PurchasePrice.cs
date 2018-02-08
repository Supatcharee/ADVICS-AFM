using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using Rubix.Framework;
using CSI.Business.Master;
using CSI.Business.DataObjects;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS330_PurchasePrice : DialogBase
    {

        #region Enum
        enum eColImport
        {
             OwnerID = 1
            ,SupplierID 
            ,ProductID
            ,PurchasePrice
            ,CurrencyID
            , Incoterm
            ,EffectiveDate
            ,ImplementDate
            ,Remark
            ,ErrorDetail

        }
        #endregion

        #region Member
        private Supplier supplierdb = null;
        private Product productdb = null;
        private DataTable dtResult = null;
        private Currency currencydb = null;
        private PurchasePrice db = null;
        private Owner ownerdb = null;
        private String FileName; 
        #endregion

        #region Properties
        public PurchasePrice BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new PurchasePrice();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new PurchasePrice();
                }
                db = value;
            }
        }
        public Supplier SupplierBusinessClass
        {
            get
            {
                if (supplierdb == null)
                {
                    supplierdb = new Supplier();
                }
                return supplierdb;
            }
            set
            {
                supplierdb = value;
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
        public Owner OwnerBusinessClass
        {
            get
            {
                if (ownerdb == null)
                {
                    ownerdb = new Owner();
                }
                return ownerdb;
            }
            set
            {
                ownerdb = value;
            }
        }
        #endregion

        #region Constructor

        public dlgXMSS330_PurchasePrice(String fileName)
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
                        DataSet ds = new DataSet("PurchasePriceDataSet");
                        dtAdd.TableName = "PurchasePriceDataTable";
                        dtAdd.Columns["EffectiveDate"].DateTimeMode = DataSetDateTime.Unspecified;
                        dtAdd.Columns["ImplementDate"].DateTimeMode = DataSetDateTime.Unspecified;
                            
                        ds.Tables.Add(dtAdd);

                        BusinessClass.SaveData(ds.GetXml(), AppConfig.UserLogin);

                        MessageDialog.ShowInformationMsg(Rubix.Screen.Common.GetMessage("I0003"));
                        ds.Tables.Clear();
                    }

                    base.CloseWaitScreen();

                    gdvResult.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    DialogResult = DialogResult.OK;
                    return true;
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
        private void dlgXMSS330_PurchasePrice_Load(object sender, EventArgs e)
        {
            dtResult = new DataTable();
            if (dtResult.Rows.Count <= 0)
            {
                dtResult.Columns.Add("OwnerID", typeof(int));
                dtResult.Columns.Add("OwnerCode", typeof(string));                
                dtResult.Columns.Add("SupplierID", typeof(int));
                dtResult.Columns.Add("SupplierCode", typeof(string));
                dtResult.Columns.Add("ProductID", typeof(int));
                dtResult.Columns.Add("ProductCode", typeof(string));
                dtResult.Columns.Add("PurchasePrice", typeof(string));
                dtResult.Columns.Add("CurrencyID", typeof(int));
                dtResult.Columns.Add("CurrencyCode", typeof(string));
                dtResult.Columns.Add("Incoterm", typeof(string));
                dtResult.Columns.Add("EffectiveDate", typeof(DateTime));
                dtResult.Columns.Add("ImplementDate", typeof(DateTime));
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

            if (view.GetRowCellValue(e.RowHandle, gdcSupplierCode).ToString().Trim() == String.Empty)
            {
                isValid = false;
                errMsg += Rubix.Screen.Common.GetMessage("I0024");
                view.SetColumnError(gdcSupplierCode, Rubix.Screen.Common.GetMessage("I0024"));

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
            


            if (view.GetRowCellValue(e.RowHandle, gcPurchasePrice).ToString().Trim() == String.Empty)
            {
                isValid = false;
                if (!string.IsNullOrEmpty(errMsg))
                    errMsg += Environment.NewLine;
                errMsg += Rubix.Screen.Common.GetMessage("I0359");
                view.SetColumnError(gcPurchasePrice, Rubix.Screen.Common.GetMessage("I0359"));
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

                int iSupplierID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, gdcSupplierCode));
                int iProductID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, gdcProductCode));
                DateTime EffectiveDate = Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, gdcEffectiveDate));



                if (BusinessClass.CheckExist(null, iSupplierID, iProductID, Convert.ToDateTime(EffectiveDate.ToString("yyyy/MM/dd"))))
                {
                    isValid = false;
                    if (!string.IsNullOrEmpty(errMsg))
                        errMsg += Environment.NewLine;
                    errMsg += Rubix.Screen.Common.GetMessage("I0205");
                    view.SetColumnError(gdcSupplierCode, Rubix.Screen.Common.GetMessage("I0205"));
                    view.SetColumnError(gdcProductCode, Rubix.Screen.Common.GetMessage("I0205"));
                }

            }

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
                    while (!string.IsNullOrWhiteSpace(excel.ReadData(row, (int)eColImport.SupplierID)))
                    {
                        DataRow dr = dtResult.NewRow();
                        string errorMsg = string.Empty;
                        string OwnerCode = excel.ReadData(row, (int)eColImport.OwnerID).Trim();
                        string SupplierCode = excel.ReadData(row, (int)eColImport.SupplierID).Trim();
                        string EffectiveDate = excel.ReadData(row, (int)eColImport.EffectiveDate).Trim();
                        string ImplementDate = excel.ReadData(row, (int)eColImport.ImplementDate).Trim();
                        string ProductCode = excel.ReadData(row, (int)eColImport.ProductID).Trim();
                        string PurchasePrice = excel.ReadData(row, (int)eColImport.PurchasePrice).Trim();
                        string CurrencyCode = excel.ReadData(row, (int)eColImport.CurrencyID).Trim();
                        string Incoterm = excel.ReadData(row, (int)eColImport.Incoterm).Trim();
                        string Remark = excel.ReadData(row, (int)eColImport.Remark).Trim();
                        int ProductID = -1;

                        ////Validate Owner Code
                        List<sp_XMSS010_Owner_SearchAll_Result> lst = OwnerBusinessClass.DataLoading(OwnerCode, null);
                        if (lst == null || lst.Count <= 0)
                        {
                            errorMsg += Common.GetMessage("I0279", "Owner Code", OwnerCode) + Environment.NewLine;
                        }
                        else
                        {
                            dr[eColImport.OwnerID.ToString()] = lst[0].OwnerID;
                            dr["OwnerCode"] = lst[0].OwnerCode;

                            /////Validate SupplierCode
                            List<sp_XMSS030_Supplier_SearchAll_Result> _supplier = SupplierBusinessClass.DataLoading(SupplierCode, null, lst[0].OwnerID);

                            if (string.IsNullOrEmpty(SupplierCode) || _supplier.Count == 0)
                            {
                                errorMsg += Common.GetMessage("I0279", "Supplier Code", SupplierCode) + Environment.NewLine;
                            }
                            else
                            {
                                dr[eColImport.SupplierID.ToString()] = _supplier[0].SupplierID;
                                dr["SupplierCode"] = _supplier[0].SupplierCode;

                                /////Validate ItemCode
                                DataTable _product = ProductBusinessClass.DataLoading(lst[0].OwnerID, ProductCode, null, _supplier[0].SupplierID);
                                if (string.IsNullOrEmpty(ProductCode) || _product == null || _product.Rows.Count <= 0)
                                {
                                    errorMsg += Common.GetMessage("I0279", "Item Code", ProductCode) + Environment.NewLine;
                                }
                                else
                                {
                                    ProductID = Convert.ToInt32(_product.Rows[0]["ProductID"]);
                                    dr[eColImport.ProductID.ToString()] = ProductID;
                                    dr["ProductCode"] = _product.Rows[0]["ProductCode"];
                                }

                                /////Validate EffectiveDate
                                DateTime _date;
                                if (string.IsNullOrEmpty(EffectiveDate) || !DateTime.TryParse(EffectiveDate, out _date))
                                {
                                    errorMsg += Common.GetMessage("I0279", "EffectiveDate", EffectiveDate) + Environment.NewLine;
                                }
                                else
                                {
                                    dr[eColImport.EffectiveDate.ToString()] = DataUtil.Convert<DateTime>(EffectiveDate);

                                    if (DataUtil.Convert<DateTime>(EffectiveDate) < DateTime.Today)
                                    {
                                        errorMsg += Rubix.Screen.Common.GetMessage("I0354") + Environment.NewLine;
                                    }

                                    if (BusinessClass.CheckExist(null, _supplier[0].SupplierID, ProductID, Convert.ToDateTime(DateTime.Parse(EffectiveDate).ToString("yyyy/MM/dd"))))
                                    {
                                        errorMsg += Rubix.Screen.Common.GetMessage("I0205") + Environment.NewLine;
                                    }
                                }

                                if (!string.IsNullOrEmpty(ImplementDate))
                                {
                                    if ((!string.IsNullOrEmpty(EffectiveDate) && DateTime.TryParse(EffectiveDate, out _date))
                                        && DataUtil.Convert<DateTime>(ImplementDate) < DataUtil.Convert<DateTime>(EffectiveDate))
                                    {
                                        errorMsg += Rubix.Screen.Common.GetMessage("I0379") + Environment.NewLine;
                                    }

                                    dr[eColImport.ImplementDate.ToString()] = DataUtil.Convert<DateTime>(ImplementDate);

                                }
                            } 
                        }                       

                        /////Validate PurchasePrice
                        Decimal _decimal;
                        if (string.IsNullOrEmpty(PurchasePrice) || !Decimal.TryParse(PurchasePrice, out _decimal))
                        {
                            errorMsg += Common.GetMessage("I0279", "PurchasePrice", PurchasePrice) + Environment.NewLine;
                        }
                        else
                        {
                            dr[eColImport.PurchasePrice.ToString()] = PurchasePrice;
                        }

                        ////Validate CurrencyCode
                        DataTable dtCurrency = CurrencyBusinessClass.DataLoading(CurrencyCode, null);
                        if (string.IsNullOrEmpty(CurrencyCode) || dtCurrency.Rows.Count == 0)
                        {
                            errorMsg += Rubix.Screen.Common.GetMessage("I0279", "CurrencyCode", CurrencyCode) + Environment.NewLine;
                        }
                        else
                        {
                            dr[eColImport.CurrencyID.ToString()] = dtCurrency.Rows[0]["CurrencyID"];
                            dr["CurrencyCode"] = dtCurrency.Rows[0]["CurrencyCode"];
                        }

                        ////Validate Incoterm
                        if (!string.IsNullOrWhiteSpace(Incoterm) && Incoterm.Length > 50)
                        {
                            errorMsg += Rubix.Screen.Common.GetMessage("I0378") + Environment.NewLine;
                        }
                        ////Validate Remark
                        if (!string.IsNullOrWhiteSpace(Remark) && Remark.Length > 200)
                        {
                            errorMsg += Rubix.Screen.Common.GetMessage("I0280") + Environment.NewLine;
                        }
                        
                        dr[eColImport.Incoterm.ToString()] = Incoterm;
                        dr[eColImport.Remark.ToString()] = Remark;
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
        #endregion
    }
}
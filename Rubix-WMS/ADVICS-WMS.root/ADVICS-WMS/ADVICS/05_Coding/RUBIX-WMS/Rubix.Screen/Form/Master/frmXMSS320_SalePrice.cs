using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using CSI.Business.Master;
using Rubix.Framework;
using CSI.Business.BusinessFactory.Master;
using CSI.Business.DataObjects;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace Rubix.Screen.Form.Master
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Add, Permission.Edit, Permission.Export, Permission.Import)]
    public partial class frmXMSS320_SalePrice : FormBase
    {
        #region Member
        private SalePrice db = null;
        private CSI.Business.Common.Customer customerdb = null;
        private CSI.Business.Common.Product productdb = null;
        private CSI.Business.Common.Owner ownerdb = null;
        private Privilege privilege = null;
        private Currency currencydb = null;
        private DataTable dtResult = null;
        private int iCount = 0;
        private Dialog.dlgXMSS320_SalePrice m_Dialog = null;
        private bool isValidData = true;
        private DataTable ListClone;
        #endregion

        #region Properties
        public SalePrice BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new SalePrice();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new SalePrice();
                }
                db = value;
            }
        }
        public CSI.Business.Common.Owner OwnerBusinessClass
        {
            get
            {
                if (ownerdb == null)
                {
                    ownerdb = new CSI.Business.Common.Owner();
                }
                return ownerdb;
            }
            set
            {
                ownerdb = value;
            }
        }
        public CSI.Business.Common.Customer CustomerBusinessClass
        {
            get
            {
                if (customerdb == null)
                {
                    customerdb = new CSI.Business.Common.Customer();
                }
                return customerdb;
            }
            set
            {
                customerdb = value;
            }
        }
        public CSI.Business.Common.Product ProductBusinessClass
        {
            get
            {
                if (productdb == null)
                {
                    productdb = new CSI.Business.Common.Product();
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
                if (privilege == null)
                {
                    privilege = new Privilege();
                }
                return privilege;
            }
            set
            {
                privilege = value;
            }
        }
        #endregion

        #region Constructor
        public frmXMSS320_SalePrice()
        {
            InitializeComponent();
            base.GridExportExcel = gdvSearchResult;
            //base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.SetExpandGroupControl(groupControl1);
            ofdImport.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofdImport.Multiselect = false;
            ofdImport.ValidateNames = true;
            ofdImport.DereferenceLinks = false;
            ofdImport.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
        }
        #endregion

        #region Override Method
        public override bool OnCommandEdit()
        {
            try
            {
                ShowWaitScreen();
                DataLoading();
                EnbleEditMode(true);
                if (base.CanAdd)
                {
                    gdvSearchResult.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
            finally
            {
                CloseWaitScreen();
            }
        }
        public override bool OnCommandSave()
        {
            try
            {
                gdvSearchResult.CloseEditor();
                gdvSearchResult.UpdateCurrentRow();
                if (gdvSearchResult.RowCount <= 0)
                {
                    return false;
                }

                if (isValidData)
                {
                    if (MessageDialog.ShowConfirmationMsg(this, Rubix.Screen.Common.GetMessage("I0015")) == DialogButton.Yes)
                    {
                        base.ShowWaitScreen();
                        DataTable dtAdd = null;
                        DataTable dttUpdate = null;

                        DataRow[] drAdd = dtResult.Select("", "", DataViewRowState.Added);
                        DataRow[] drUpdate = dtResult.Select("", "", DataViewRowState.ModifiedCurrent);

                        if (drAdd.Length > 0)
                        {
                            dtAdd = drAdd.CopyToDataTable();
                        }
                        if (drUpdate.Length > 0)
                        {
                            dttUpdate = drUpdate.CopyToDataTable();
                        }

                        if (dttUpdate != null)
                        {
                            if (dtAdd == null)
                            {
                                dtAdd = dttUpdate;
                            }
                            else
                            {
                                dtAdd.Merge(dttUpdate);
                            }
                        }
                        if (dtAdd != null)
                        {
                            DataSet ds = new DataSet("SalePriceDataSet");
                            dtAdd.TableName = "SalePriceDataTable";
                            dtAdd.Columns["EffectiveDate"].DateTimeMode = DataSetDateTime.Unspecified;
                            dtAdd.Columns["ImplementDate"].DateTimeMode = DataSetDateTime.Unspecified;
                            
                            ds.Tables.Add(dtAdd);

                            BusinessClass.SaveData(ds.GetXml(), AppConfig.UserLogin);

                            MessageDialog.ShowInformationMsg(Rubix.Screen.Common.GetMessage("I0003"));
                            ds.Tables.Clear();
                            DataLoading();
                        }
                        base.CloseWaitScreen();
                        EnbleEditMode(false);
                        gdvSearchResult.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
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
        public override bool OnCommandCancel()
        {
            EnbleEditMode(false);
            gdvSearchResult.CloseEditor();
            gdvSearchResult.CancelUpdateCurrentRow();
            gdvSearchResult.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            DataLoading();
            return true;
        }
        public override bool OnCommandDelete()
        {
            try
            {
                if (gdvSearchResult.RowCount <= 0)
                {
                    return false;
                }
                else
                {
                    DataRow dr = gdvSearchResult.GetFocusedDataRow();
                    if (dr == null)
                    {
                        return false;
                    }
                    if (MessageDialog.ShowConfirmationMsg(this, Rubix.Screen.Common.GetMessage("I0016")) == DialogButton.Yes)
                    {
                        base.ShowWaitScreen();
                        BusinessClass.DeleteData(Convert.ToInt32(dr["SalePriceID"]));
                        gdvSearchResult.DeleteSelectedRows();
                        base.CloseWaitScreen();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                base.CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        public override bool OnCommandImport()
        {
            try
            {
                this.ShowWaitScreen();
                if (ImportExceltoDataBase())
                {
                    MessageDialog.ShowInformationMsg("Import Complete");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
                return false;
            }
            finally
            {
                this.CloseWaitScreen();
            }
        }
        #endregion

        #region Event Handler
        private void frmXMSS320_SalePrice_Load(object sender, EventArgs e)
        {
            try
            {
                //ทำตอน constructor ไม่ได้เพราะปุ่ม add จะไม่หายไป มี permission add แต่ไม่ show ปุ่ม add
                ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarAdd, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
                ControlUtil.HiddenControl(true, q_toolBarView, q_toolBarAdd);
                ControlUtil.HiddenControl(false, m_toolBarImport);
                
                SetEditTableColor(false);
                dtEffectiveFrom.EditValue = ControlUtil.GetStartDate();
                dtEffectiveTo.EditValue = ControlUtil.GetEndDate();
            }
            catch (Exception ex)
            {
                base.CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowWaitScreen();  
                DataLoading();
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                }
                this.CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void gdvSearchResult_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column == gdcOwnerID)
            {
                gdvSearchResult.SetRowCellValue(e.RowHandle, gdcCustomerID, null);
                gdvSearchResult.SetRowCellValue(e.RowHandle, gdcProductID, null);
            }
        }

        private void gdvSearchResult_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == gdcOwnerID)
                {
                    if (Util.IsNullOrEmpty(e.Value))
                    {
                        gdvSearchResult.SetRowCellValue(e.RowHandle, gdcOwnerName, "");
                        return;
                    }
                    sp_common_LoadOwner_Result rs = (repOwnerCode.DataSource as List<sp_common_LoadOwner_Result>).Where(c => c.OwnerID == Convert.ToInt32(e.Value)).FirstOrDefault();
                    if (rs != null)
                    {
                        gdvSearchResult.SetRowCellValue(e.RowHandle, gdcOwnerName, rs.OwnerName);
                    }
                    else
                    {
                        gdvSearchResult.SetRowCellValue(e.RowHandle, gdcOwnerName, "");
                    }

                }
                else if (e.Column == gdcCustomerID)
                {
                    if (Util.IsNullOrEmpty(e.Value))
                    {
                        gdvSearchResult.SetRowCellValue(e.RowHandle, gdcCustomerName, "");
                        return;
                    }
                    sp_common_LoadCustomer_Result rs = (repCustomerCode.DataSource as List<sp_common_LoadCustomer_Result>).Where(c => c.CustomerID == Convert.ToInt32(e.Value)).FirstOrDefault();
                    if (rs != null)
                    {
                        gdvSearchResult.SetRowCellValue(e.RowHandle, gdcCustomerName, rs.CustomerName);
                    }
                    else
                    {
                        gdvSearchResult.SetRowCellValue(e.RowHandle, gdcCustomerName, "");
                    }
                    //gdvSearchResult.SetRowCellValue(e.RowHandle, gdcProductID, 0);
                }
                else if (e.Column == gdcProductID)
                {
                    if (Util.IsNullOrEmpty(e.Value))
                    {
                        gdvSearchResult.SetRowCellValue(e.RowHandle, gdcPartName, "");
                        return;
                    }
                    sp_common_LoadProduct_Result rs = (repItemCode.DataSource as List<sp_common_LoadProduct_Result>).Where(c => c.ProductID == Convert.ToInt32(e.Value)).FirstOrDefault();
                    if (rs != null)
                    {
                        gdvSearchResult.SetRowCellValue(e.RowHandle, gdcPartName, rs.ProductLongName);
                    }
                    else
                    {
                        gdvSearchResult.SetRowCellValue(e.RowHandle, gdcPartName, "");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void gdvSearchResult_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView View = sender as GridView;
            DataRow dr = gdvSearchResult.GetFocusedDataRow();
            if (dr != null)
            {
                if (!string.IsNullOrEmpty(dr["SalePriceID"].ToString()))
                {
                    if ((string.IsNullOrEmpty(dr["ImplementDate"].ToString()) || 
                         (dr.RowState == DataRowState.Modified && 
                          !string.IsNullOrEmpty(dr["ImplementDate"].ToString())
                         ))
                        && View.FocusedColumn == gdcImplementDate)
                    {

                    }
                    else if (!string.IsNullOrEmpty(dr["ImplementDate"].ToString()) 
                        && View.FocusedColumn == gdcImplementDate
                        && Convert.ToDateTime(dr["ImplementDate"]) < DateTime.Today)
                    {
                        e.Cancel = true;
                    }
                    else if (!string.IsNullOrEmpty(dr["EffectiveDate"].ToString())
                        && Convert.ToDateTime(dr["EffectiveDate"]) < DateTime.Today)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void gdvSearchResult_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            bool isValid = true;
            ColumnView view = sender as ColumnView;
            view.ClearColumnErrors();

            e.ErrorText = Rubix.Screen.Common.GetMessage("I0353");


            if (view.GetRowCellValue(e.RowHandle, gdcOwnerID).ToString().Trim() == String.Empty)
            {
                isValid = false;
                view.SetColumnError(gdcOwnerID, Rubix.Screen.Common.GetMessage("I0018"));
            }

            if (view.GetRowCellValue(e.RowHandle, gdcCustomerID).ToString().Trim() == String.Empty)
            {
                isValid = false;
                view.SetColumnError(gdcCustomerID, Rubix.Screen.Common.GetMessage("I0256"));
            }

            if (view.GetRowCellValue(e.RowHandle, gdcProductID).ToString().Trim() == String.Empty)
            {
                isValid = false;
                view.SetColumnError(gdcProductID, Rubix.Screen.Common.GetMessage("I0093"));
            }
            //Effective
            if (view.GetRowCellValue(e.RowHandle, gdcEffectiveDate).ToString().Trim() == String.Empty)
            {
                isValid = false;
                view.SetColumnError(gdcEffectiveDate, Rubix.Screen.Common.GetMessage("I0319"));
            }
            //check in add mode only
            else if (DataUtil.Convert<int>(view.GetRowCellValue(e.RowHandle, gdcSalePriceID)) == null && Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, gdcEffectiveDate)) < DateTime.Today)
            {
                isValid = false;
                view.SetColumnError(gdcEffectiveDate, Rubix.Screen.Common.GetMessage("I0354"));
            }

            if (view.GetRowCellValue(e.RowHandle, gdcImplementDate) != DBNull.Value)
            {


                if (view.GetRowCellValue(e.RowHandle, gdcEffectiveDate) != DBNull.Value
                    && view.GetRowCellValue(e.RowHandle, gdcImplementDate) != DBNull.Value
                    && Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, gdcImplementDate)) < Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, gdcEffectiveDate)))
                {
                    isValid = false;
                    view.SetColumnError(gdcImplementDate, Rubix.Screen.Common.GetMessage("I0379"));
                }
            }

            if (view.GetRowCellValue(e.RowHandle, gdcSalePrice).ToString().Trim() == String.Empty)
            {
                isValid = false;
                view.SetColumnError(gdcSalePrice, Rubix.Screen.Common.GetMessage("I0355"));
            }

            if (view.GetRowCellValue(e.RowHandle, gdcCurrencyID).ToString().Trim() == String.Empty)
            {
                isValid = false;
                view.SetColumnError(gdcCurrencyID, Rubix.Screen.Common.GetMessage("I0356"));
            }

            if (view.GetRowCellValue(e.RowHandle, gdcConvertor).ToString().Trim() == String.Empty)
            {
                isValid = false;
                view.SetColumnError(gdcConvertor, "Convertor cannot null");
            }

            if (isValid)
            {
                DataRow[] dr;
                int? iSalePriceID = DataUtil.Convert<int>(view.GetRowCellValue(e.RowHandle, gdcSalePriceID));
                int iCustomerID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, gdcCustomerID));
                int iProductID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, gdcProductID));
                int iRowID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, gdcROWID));
                DateTime EffectiveDateStart = Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, gdcEffectiveDate));
                DateTime EffectiveDateEnd = EffectiveDateStart.AddDays(1);
                int iCurrencyID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, gdcCurrencyID));

                if (iSalePriceID == null)
                {
                    dr = dtResult.Select(string.Format("CustomerID = {0} AND ROWID <> {1} ", iCustomerID, iRowID));
                }
                else
                {
                    dr = dtResult.Select(string.Format("CustomerID = {0} AND SalePriceID <> {1} ", iCustomerID, iSalePriceID));
                }

                if (dr.Length > 0 && Convert.ToInt32(dr[0]["CurrencyID"]) != iCurrencyID)
                {
                    isValid = false;
                    view.SetColumnError(gdcCurrencyID, Rubix.Screen.Common.GetMessage("I0392"));
                }
                int chkcur = BusinessClass.CheckCurrency(iCustomerID,iProductID);
                if (chkcur != iCurrencyID && chkcur != 0)
                {
                    isValid = false;
                    view.SetColumnError(gdcCurrencyID, Rubix.Screen.Common.GetMessage("I0392"));
                }

                if (isValid)
                {

                    if (iSalePriceID == null)
                    {
                        dr = dtResult.Select(string.Format("CustomerID = {0} AND ProductID = {1} AND EffectiveDate >= '{2}' AND EffectiveDate < '{3}' AND ROWID <> {4} ", iCustomerID, iProductID, EffectiveDateStart, EffectiveDateEnd, iRowID));
                    }
                    else
                    {
                        dr = dtResult.Select(string.Format("CustomerID = {0} AND ProductID = {1} AND EffectiveDate >= '{2}' AND EffectiveDate < '{3}' AND SalePriceID <> {4} ", iCustomerID, iProductID, EffectiveDateStart, EffectiveDateEnd, iSalePriceID));
                    }

                    if (dr.Length > 0)
                    {

                        isValid = false;
                        view.SetColumnError(gdcCustomerID, Rubix.Screen.Common.GetMessage("I0205"));
                        view.SetColumnError(gdcProductID, Rubix.Screen.Common.GetMessage("I0205"));
                    }
                    else
                    {
                        if (BusinessClass.CheckExist(iSalePriceID, iCustomerID, iProductID, Convert.ToDateTime(EffectiveDateStart.ToString("yyyy/MM/dd"))))
                        {
                            isValid = false;
                            view.SetColumnError(gdcCustomerID, Rubix.Screen.Common.GetMessage("I0205"));
                            view.SetColumnError(gdcProductID, Rubix.Screen.Common.GetMessage("I0205"));
                        }
                    } 
                }
            }
            this.isValidData = isValid;
            e.Valid = isValid;
        }

        private void gdvSearchResult_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            iCount++;
            view.SetRowCellValue(e.RowHandle, gdcROWID, iCount);
        }

        private void gdvSearchResult_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            DataRow dr = gdvSearchResult.GetFocusedDataRow();

            if (e.Value == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(e.Value.ToString()))
            {
                if (view.FocusedColumn.FieldName == "EffectiveDate")
                {
                    if (Convert.ToDateTime(e.Value) < DateTime.Today)
                    {
                        e.Valid = false;
                        e.ErrorText = Rubix.Screen.Common.GetMessage("I0354");
                    }
                }
                else if (view.FocusedColumn.FieldName == "ImplementDate")
                {
                    if (e.Value != null && Convert.ToDateTime(e.Value) < Convert.ToDateTime(dr["EffectiveDate"]))
                    {
                        e.Valid = false;
                        e.ErrorText = Rubix.Screen.Common.GetMessage("I0379");
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //ControlUtil.ClearControlData(customerControl);
            //grdSearchResult.DataSource = null;
            //dtEffectiveFrom.EditValue = ControlUtil.GetStartDate();
            //dtEffectiveTo.EditValue = ControlUtil.GetEndDate();
            ClearData();
        }
        
        private void gdvSearchResult_ShownEditor(object sender, EventArgs e)
        {
            DataRow View = gdvSearchResult.GetFocusedDataRow();

            if (View != null)
            {
               
                if (gdvSearchResult.FocusedColumn.FieldName == "CustomerID" && gdvSearchResult.ActiveEditor is SearchLookUpEdit)
                {
                    DevExpress.XtraEditors.SearchLookUpEdit edit;
                    edit = (SearchLookUpEdit)gdvSearchResult.ActiveEditor;

                    List<sp_common_LoadCustomer_Result> ListAll = CustomerBusinessClass.DataLoading(null, DataUtil.Convert<int>(View["OwnerID"]));

                    List<sp_common_LoadCustomer_Result> ListClone = new List<sp_common_LoadCustomer_Result>();

                    ListClone = ListAll;

                    edit.Properties.DataSource = ListClone;


                }
                else if (gdvSearchResult.FocusedColumn.FieldName == "ProductID" && gdvSearchResult.ActiveEditor is SearchLookUpEdit)
                {
                    DevExpress.XtraEditors.SearchLookUpEdit edit;
                    edit = (SearchLookUpEdit)gdvSearchResult.ActiveEditor;

                    List<sp_common_LoadProduct_Result> ListAll = ProductBusinessClass.DataLoading(DataUtil.Convert<int>(View["OwnerID"]));

                    List<sp_common_LoadProduct_Result> ListClone = new List<sp_common_LoadProduct_Result>();

                    ListClone = ListAll;

                    edit.Properties.DataSource = ListClone;
                }
            }
        }

        private void ownerControl_EditValueChanged(object sender, EventArgs e)
        {
            if (ownerControl.OwnerID != null)
            {
                customerControl.OwnerID = ownerControl.OwnerID;
                customerControl.DataLoading();
            }
            else
            {
                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();
            }

        }

        private void ofdImport_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog fileDialog = sender as OpenFileDialog;
            string selectedFile = fileDialog.FileName;
            if (string.IsNullOrEmpty(selectedFile) || selectedFile.Contains(".lnk"))
            {
                MessageBox.Show("Please select a valid Excel File");
                e.Cancel = true;
            }
            return;
        }
        #endregion

        #region Generic Function
        private void InitialCombobox()
        {
            repOwnerCode.DataSource = OwnerBusinessClass.DataLoading(null);
            repCustomerCode.DataSource = CustomerBusinessClass.DataLoading(null, null);
            repItemCode.DataSource = ProductBusinessClass.DataLoading(null);
            repCurrencyCode.DataSource = CurrencyBusinessClass.DataLoading(null, null);
            repPVCode.DataSource = PrivilegeBusinessClass.DataLoading(null, null);
            
        }
        private void OpenDialog(string fileName)
        {
            try
            {

                if (m_Dialog == null)
                {
                    m_Dialog = new Dialog.dlgXMSS320_SalePrice(fileName);
                }

                if (m_Dialog.ShowDialog(this) == DialogResult.OK)
                {
                    DataLoading();
                    //MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), Dialog.BusinessClass.ConfigItem));
                }

                m_Dialog = null;

            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.ToString());
            }
        }
        private void DataLoading()
        {
            InitialCombobox();            
            dtResult = BusinessClass.DataLoading(ownerControl.OwnerID,customerControl.CustomerID, DataUtil.Convert<DateTime>(dtEffectiveFrom.EditValue), DataUtil.Convert<DateTime>(dtEffectiveTo.EditValue));
            if (dtResult.Rows.Count <= 0)
            {
                dtResult.Columns.Add("ROWID", typeof(int));
                dtResult.Columns.Add("OwnerID", typeof(int));
                dtResult.Columns.Add("OwnerName", typeof(string));
                dtResult.Columns.Add("SalePriceID", typeof(int));
                dtResult.Columns.Add("CustomerID", typeof(int));
                dtResult.Columns.Add("CustomerName", typeof(string));
                dtResult.Columns.Add("ProductID", typeof(int));
                dtResult.Columns.Add("ProductName", typeof(string));
                dtResult.Columns.Add("SalePrice", typeof(double));
                dtResult.Columns.Add("CurrencyID", typeof(int));
                dtResult.Columns.Add("Convertor", typeof(string));
                dtResult.Columns.Add("Incoterm", typeof(string));
                dtResult.Columns.Add("EffectiveDate", typeof(DateTime));
                dtResult.Columns.Add("ExpiryDate", typeof(DateTime));
                dtResult.Columns.Add("ImplementDate", typeof(DateTime));
                dtResult.Columns.Add("HSCode", typeof(string));
                dtResult.Columns.Add("PVID", typeof(int));
                dtResult.Columns.Add("Remark", typeof(string));
                dtResult.Columns.Add("CreateDate", typeof(DateTime));
                dtResult.Columns.Add("CreateUser", typeof(string));
                dtResult.Columns.Add("UpdateDate", typeof(DateTime));
                dtResult.Columns.Add("UpdateUser", typeof(string));
            }
            else
            {
                DataTable dtClone = new DataTable();
                dtClone.Columns.Add("ROWID", typeof(int));
                dtClone.Columns.Add("OwnerID", typeof(int));
                dtClone.Columns.Add("OwnerName", typeof(string));
                dtClone.Columns.Add("SalePriceID", typeof(int));
                dtClone.Columns.Add("CustomerID", typeof(int));
                dtClone.Columns.Add("CustomerName", typeof(string));
                dtClone.Columns.Add("ProductID", typeof(int));
                dtClone.Columns.Add("ProductName", typeof(string));
                dtClone.Columns.Add("SalePrice", typeof(double));
                dtClone.Columns.Add("CurrencyID", typeof(int));
                dtClone.Columns.Add("Convertor", typeof(string));
                dtClone.Columns.Add("Incoterm", typeof(string));
                dtClone.Columns.Add("EffectiveDate", typeof(DateTime));
                dtClone.Columns.Add("ExpiryDate", typeof(DateTime));
                dtClone.Columns.Add("ImplementDate", typeof(DateTime));
                dtClone.Columns.Add("HSCode", typeof(string));
                dtClone.Columns.Add("PVID", typeof(int));
                dtClone.Columns.Add("Remark", typeof(string));
                dtClone.Columns.Add("CreateDate", typeof(DateTime));
                dtClone.Columns.Add("CreateUser", typeof(string));
                dtClone.Columns.Add("UpdateDate", typeof(DateTime));
                dtClone.Columns.Add("UpdateUser", typeof(string));

                //Implement date เป็น null ได้ทำให้ datatype ที่ดึงออกมาจาก database เป็น string ทำให้ตอนแก้ไขแสดงวันที่ และ เวลา
                //แก้ไขโดย clone มาใส่ datatable ที่มี type แน่นอน แล้ว clone กลับไป
                dtClone.Load(dtResult.CreateDataReader(), System.Data.LoadOption.OverwriteChanges);
                dtResult.Clear();
                dtResult = dtClone.Copy();
                dtClone = null;
            }

            dtResult.AcceptChanges();
            grdSearchResult.DataSource = dtResult;
            iCount = dtResult.Rows.Count;
            base.GridViewOnChangeLanguage(grdSearchResult);
        }
        private void SetEditTableColor(bool IsEdit)
        {
            if (IsEdit)
            {
                //สีเหลืองเสมอ
                gdcOwnerID.AppearanceCell.BackColor = Color.Yellow;
                gdcCustomerID.AppearanceCell.BackColor = Color.Yellow;
                gdcProductID.AppearanceCell.BackColor = Color.Yellow;
                gdcEffectiveDate.AppearanceCell.BackColor = Color.Yellow;
                gdcImplementDate.AppearanceCell.BackColor = Color.Yellow;
                gdcSalePrice.AppearanceCell.BackColor = Color.Yellow;
                gdcCurrencyID.AppearanceCell.BackColor = Color.Yellow;
                gdcHSCode.AppearanceCell.BackColor = Color.Yellow;
                gdcIncoterm.AppearanceCell.BackColor = Color.Yellow;
                gdcPVID.AppearanceCell.BackColor = Color.Yellow;
                gdcConvertor.AppearanceCell.BackColor = Color.Yellow;
                gdcRemark.AppearanceCell.BackColor = Color.Yellow;
            }
            else
            {
                for (int i = 0; i < gdvSearchResult.Columns.Count; i++)
                {
                    gdvSearchResult.Columns[i].AppearanceCell.BackColor = Color.White;
                }
            }

            gdcOwnerID.OptionsColumn.AllowEdit = IsEdit;
            gdcCustomerID.OptionsColumn.AllowEdit = IsEdit;
            gdcProductID.OptionsColumn.AllowEdit = IsEdit;
            gdcEffectiveDate.OptionsColumn.AllowEdit = IsEdit;
            gdcImplementDate.OptionsColumn.AllowEdit = IsEdit;
            gdcSalePrice.OptionsColumn.AllowEdit = IsEdit;
            gdcCurrencyID.OptionsColumn.AllowEdit = IsEdit;
            gdcHSCode.OptionsColumn.AllowEdit = IsEdit;
            gdcIncoterm.OptionsColumn.AllowEdit = IsEdit;
            gdcPVID.OptionsColumn.AllowEdit = IsEdit;
            gdcConvertor.OptionsColumn.AllowEdit = IsEdit;
            gdcRemark.OptionsColumn.AllowEdit = IsEdit;
        }
        private void EnbleEditMode(bool enble)
        {

            ControlUtil.HiddenControl(!enble, m_toolBarSave, m_toolBarCancel);
            ControlUtil.HiddenControl(enble, m_toolBarEdit, m_toolBarDelete, m_toolBarImport, m_toolBarExport);
            ControlUtil.HiddenControl(enble, q_toolBarEdit, q_toolBarDelete);

            ControlUtil.HiddenControl(enble, gdcOwnerCode, gdcCustomerCode, gdcProductCode, gdcCurrencyCode, gdcPVCode);
            ControlUtil.HiddenControl(!enble, gdcOwnerID, gdcCustomerID, gdcProductID, gdcCurrencyID, gdcPVID);
            SetEditTableColor(enble);

            if (enble)
            {
                gdcOwnerID.VisibleIndex         = 0;
                gdcOwnerName.VisibleIndex       = 1;
                gdcCustomerID.VisibleIndex      = 2;
                gdcCustomerName.VisibleIndex    = 3;
                gdcProductID.VisibleIndex       = 4;
                gdcPartName.VisibleIndex        = 5;
                gdcSalePrice.VisibleIndex       = 6;
                gdcCurrencyID.VisibleIndex      = 7;
                gdcConvertor.VisibleIndex       = 8;
                gdcIncoterm.VisibleIndex        = 9;
                gdcEffectiveDate.VisibleIndex   = 10;
                gdcExpiryDate.VisibleIndex      = 11;
                gdcImplementDate.VisibleIndex   = 12;
                gdcHSCode.VisibleIndex          = 13;
                gdcPVID.VisibleIndex            = 14;
                gdcRemark.VisibleIndex          = 15;
                gdcCreateDate.VisibleIndex      = 16;
                gdcCreateUser.VisibleIndex      = 17;
                gdcUpdateDate.VisibleIndex      = 18;
                gdcUpdateUser.VisibleIndex      = 19;
            }
            else
            {
                gdcOwnerCode.VisibleIndex       = 0;
                gdcOwnerName.VisibleIndex       = 1;
                gdcCustomerCode.VisibleIndex    = 2;
                gdcCustomerName.VisibleIndex    = 3;
                gdcProductCode.VisibleIndex     = 4;
                gdcPartName.VisibleIndex        = 5;
                gdcSalePrice.VisibleIndex       = 6;
                gdcCurrencyCode.VisibleIndex    = 7;
                gdcConvertor.VisibleIndex       = 8;
                gdcIncoterm.VisibleIndex        = 9;
                gdcEffectiveDate.VisibleIndex   = 10;
                gdcExpiryDate.VisibleIndex      = 11;
                gdcImplementDate.VisibleIndex   = 12;
                gdcHSCode.VisibleIndex          = 13;
                gdcPVCode.VisibleIndex          = 14;
                gdcRemark.VisibleIndex          = 15;
                gdcCreateDate.VisibleIndex      = 16;
                gdcCreateUser.VisibleIndex      = 17;
                gdcUpdateDate.VisibleIndex      = 18;
                gdcUpdateUser.VisibleIndex      = 19;
            }

        }
        private void ClearData()
        {
            ownerControl.ClearData();
            customerControl.ClearData();
            dtEffectiveFrom.EditValue = ControlUtil.GetStartDate();
            dtEffectiveTo.EditValue = ControlUtil.GetEndDate();
            grdSearchResult.DataSource = null;
        }
        private bool ImportExceltoDataBase()
        {
            try
            {
                errorProvider.ClearErrors();
                string errorMsg = string.Empty;
                string errorDetailMsg = string.Empty;
                ExcelManager excel = new ExcelManager();
                if (ofdImport.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    DataTable dtImport = new DataTable();
                    dtImport.Columns.Add("CustomerCode", typeof(string));
                    dtImport.Columns.Add("ProductCode", typeof(string));
                    dtImport.Columns.Add("EffectiveDate", typeof(DateTime));
                    dtImport.Columns.Add("ImplementDate", typeof(DateTime));
                    dtImport.Columns.Add("SalePrice", typeof(decimal));
                    dtImport.Columns.Add("Currency", typeof(string));
                    dtImport.Columns.Add("Incoterm", typeof(string));
                    dtImport.Columns.Add("Remark", typeof(string));
                    dtImport.Columns.Add("Convertor", typeof(decimal));
                    dtImport.Columns.Add("HSCode", typeof(string));
                    dtImport.Columns.Add("PVCode", typeof(string));

                    using (excel)
                    {
                        excel.OpenExcel(ofdImport.FileName);
                        int row = 2;

                        while (!string.IsNullOrWhiteSpace(excel.ReadData(row, 1)))
                        {
                            dtImport.Rows.Add(excel.ReadData(row, 1).ToLower().Trim(), excel.ReadData(row, 2).ToLower().Trim(), DateTime.ParseExact(excel.ReadData(row, 3).ToLower().Trim(), "dd/MM/yyyy", new System.Globalization.CultureInfo("en-US")), DateTime.ParseExact(excel.ReadData(row, 4).ToLower().Trim(), "dd/MM/yyyy", new System.Globalization.CultureInfo("en-US")), excel.ReadData(row, 5).ToLower().Trim(), excel.ReadData(row, 6).ToLower().Trim(), excel.ReadData(row, 7).ToLower().Trim(), excel.ReadData(row, 8).ToLower().Trim(), excel.ReadData(row, 9).ToLower().Trim(), excel.ReadData(row, 10).ToLower().Trim(), excel.ReadData(row, 11).ToLower().Trim());
                            row++;
                        }
                    }
                    dtImport.Columns["EffectiveDate"].DateTimeMode = DataSetDateTime.Unspecified;
                    dtImport.Columns["ImplementDate"].DateTimeMode = DataSetDateTime.Unspecified;
                    DataSet ds = new DataSet();
                    ds.DataSetName = "SaleDataSet";
                    dtImport.TableName = "SaleDataTable";
                    ds.Tables.Add(dtImport);
                    foreach (DataRow dr in dtImport.Rows)
                    {
                        DataRow[] drChk = dtImport.Select("CustomerCode = '" + dr["CustomerCode"].ToString().ToLower().Trim() + "' and ProductCode = '" + dr["ProductCode"].ToString().ToLower().Trim() + "'");

                        if (drChk.Length > 1)
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, "CustomerCode " + dr["CustomerCode"] + " มี ProductCode " + dr["ProductCode"] + " มากกว่า 1 แถว");
                            return false;
                        }
                    }

                    BusinessClass.SaveImportData(ds.GetXml(), AppConfig.UserLogin);

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}

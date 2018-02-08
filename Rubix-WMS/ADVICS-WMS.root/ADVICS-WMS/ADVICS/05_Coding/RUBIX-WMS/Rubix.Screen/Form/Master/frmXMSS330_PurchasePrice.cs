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
    public partial class frmXMSS330_PurchasePrice : FormBase
    {
        #region Member
        private PurchasePrice db = null;
        private CSI.Business.Common.Supplier supplierdb = null;
        private CSI.Business.Common.Owner ownerdb = null;
        private CSI.Business.Common.Product productdb = null;
        private CSI.Business.Master.Product productMaster = null;
        private DataTable dtResult = null;
        private Currency currencydb = null;
        private int iCount = 0;
        private Dialog.dlgXMSS330_PurchasePrice m_Dialog = null;
        private bool isValidData = true;
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
        public CSI.Business.Common.Supplier SupplierBusinessClass
        {
            get
            {
                if (supplierdb == null)
                {
                    supplierdb = new CSI.Business.Common.Supplier();
                }
                return supplierdb;
            }
            set
            {
                supplierdb = value;
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
        private CSI.Business.Master.Product ProductMasterBusinessClass
        {
            get
            {
                if (productMaster == null)
                {
                    productMaster = new CSI.Business.Master.Product();
                }
                return productMaster;
            }
        }
        #endregion
        
        #region Constructor
        public frmXMSS330_PurchasePrice()
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
                this.ShowWaitScreen();                
                DataLoading();
                EnbleEditMode(true);
                if (base.CanAdd)
                {
                    gdvSearchResult.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                }

                this.CloseWaitScreen();
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
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
                            DataSet ds = new DataSet("PurchasePriceDataSet");
                            dtAdd.TableName = "PurchasePriceDataTable";
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
                        BusinessClass.DeleteData(Convert.ToInt32(dr["PurchasePriceID"]));
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
        private void frmXMSS330_PurchasePrice_Load(object sender, EventArgs e)
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
                gdvSearchResult.SetRowCellValue(e.RowHandle, gdcSupplierID, null);
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
                    
                    gdvSearchResult.SetRowCellValue(e.RowHandle, gdcSupplierLongName, "");
                    gdvSearchResult.SetRowCellValue(e.RowHandle, gdcProductName, "");
                    gdvSearchResult.SetRowCellValue(e.RowHandle, gdcProductCode, "");
                }
                else if (e.Column == gdcSupplierID)
                {
                    if (Util.IsNullOrEmpty(e.Value))
                    {
                        gdvSearchResult.SetRowCellValue(e.RowHandle, gdcSupplierLongName, "");
                        return;
                    }
                    sp_common_LoadSupplier_Result rs = (repSupplierCode.DataSource as List<sp_common_LoadSupplier_Result>).Where(c => c.SupplierID == Convert.ToInt32(e.Value)).FirstOrDefault();
                    if (rs != null)
                    {
                        gdvSearchResult.SetRowCellValue(e.RowHandle, gdcSupplierLongName, rs.SupplierLongName);
                    }
                    else
                    {
                        gdvSearchResult.SetRowCellValue(e.RowHandle, gdcSupplierLongName, "");
                    }

                    gdvSearchResult.SetRowCellValue(e.RowHandle, gdcProductName, "");
                    gdvSearchResult.SetRowCellValue(e.RowHandle, gdcProductCode, "");
                }
                else if (e.Column == gdcProductID)
                {
                    if (Util.IsNullOrEmpty(e.Value))
                    {
                        gdvSearchResult.SetRowCellValue(e.RowHandle, gdcProductName, "");
                        return;
                    }

                    DataRow[] data = (repItemCode.DataSource as DataTable).Select(string.Format(" ProductID = {0} ", Convert.ToInt32(e.Value)));//.Where(a => a.ProductID == Convert.ToInt32(e.Value)).FirstOrDefault();

                    if (data.Length > 0)
                    {
                        gdvSearchResult.SetRowCellValue(e.RowHandle, gdcProductName, data[0]["ProductLongName"]);
                    }
                    else
                    {
                        gdvSearchResult.SetRowCellValue(e.RowHandle, gdcProductName, "");
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
                if (!string.IsNullOrEmpty(dr["PurchasePriceID"].ToString()))
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

            if (view.GetRowCellValue(e.RowHandle, gdcSupplierID).ToString().Trim() == String.Empty)
            {
                isValid = false;
                view.SetColumnError(gdcSupplierID, Rubix.Screen.Common.GetMessage("I0024"));
            }

            if (view.GetRowCellValue(e.RowHandle, gdcProductID).ToString().Trim() == String.Empty)
            {
                isValid = false;
                view.SetColumnError(gdcProductID, Rubix.Screen.Common.GetMessage("I0291"));
            }

            //EffectiveDate
            if (view.GetRowCellValue(e.RowHandle, gdcEffectiveDate).ToString().Trim() == String.Empty)
            {
                isValid = false;
                view.SetColumnError(gdcEffectiveDate, Rubix.Screen.Common.GetMessage("I0319"));
            }
            else if (DataUtil.Convert<int>(view.GetRowCellValue(e.RowHandle, gdcPurchasePriceID)) == null &&  Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, gdcEffectiveDate)) < DateTime.Today)
            {
                isValid = false;
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
                    view.SetColumnError(gdcImplementDate, Rubix.Screen.Common.GetMessage("I0379"));
                }
            }

            if (view.GetRowCellValue(e.RowHandle, gdcPurchasePrice).ToString().Trim() == String.Empty)
            {
                isValid = false;
                view.SetColumnError(gdcPurchasePrice, Rubix.Screen.Common.GetMessage("I0359"));
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
                int? iPurchasePriceID = DataUtil.Convert<int>(view.GetRowCellValue(e.RowHandle, gdcPurchasePriceID));
                int iSupplierID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, gdcSupplierID));
                int iProductID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, gdcProductID));
                int iRowID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, gdcROWID));
                DateTime EffectiveDateStart = Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, gdcEffectiveDate));
                DateTime EffectiveDateEnd = EffectiveDateStart.AddDays(1);
                int iCurrencyID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, gdcCurrencyID));

                if (iPurchasePriceID == null)
                {
                    dr = dtResult.Select(string.Format("SupplierID = {0} AND ROWID <> {1} ", iSupplierID, iRowID));
                }
                else
                {
                    dr = dtResult.Select(string.Format("SupplierID = {0} AND PurchasePriceID <> {1} ", iSupplierID, iPurchasePriceID));
                }

                if (dr.Length > 0 && Convert.ToInt32(dr[0]["CurrencyID"]) != iCurrencyID)
                {
                    isValid = false;
                    view.SetColumnError(gdcCurrencyID, Rubix.Screen.Common.GetMessage("I0393"));
                }
                int chkcur = BusinessClass.CheckCurrency(iSupplierID,iProductID);
                if (chkcur != iCurrencyID && chkcur != 0)
                {
                    isValid = false;
                    view.SetColumnError(gdcCurrencyID, Rubix.Screen.Common.GetMessage("I0393"));
                }

                if (isValid)
                {
                    if (iPurchasePriceID == null)
                    {
                        dr = dtResult.Select(string.Format("SupplierID = {0} AND ProductID = {1} AND EffectiveDate >= '{2}' AND EffectiveDate < '{3}' AND ROWID <> {4} ", iSupplierID, iProductID, EffectiveDateStart, EffectiveDateEnd, iRowID));
                    }
                    else
                    {
                        dr = dtResult.Select(string.Format("SupplierID = {0} AND ProductID = {1} AND EffectiveDate >= '{2}' AND EffectiveDate < '{3}' AND PurchasePriceID <> {4} ", iSupplierID, iProductID, EffectiveDateStart, EffectiveDateEnd, iPurchasePriceID));
                    }

                    if (dr.Length > 0)
                    {
                        isValid = false;
                        view.SetColumnError(gdcSupplierID, Rubix.Screen.Common.GetMessage("I0205"));
                        view.SetColumnError(gdcProductID, Rubix.Screen.Common.GetMessage("I0205"));
                    }
                    else
                    {
                        if (BusinessClass.CheckExist(iPurchasePriceID, iSupplierID, iProductID, Convert.ToDateTime(EffectiveDateStart.ToString("yyyy/MM/dd"))))
                        {
                            isValid = false;
                            view.SetColumnError(gdcSupplierID, Rubix.Screen.Common.GetMessage("I0205"));
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
            ControlUtil.ClearControlData(supplierControl);
            grdSearchResult.DataSource = null;
            dtEffectiveFrom.EditValue = ControlUtil.GetStartDate();
            dtEffectiveTo.EditValue = ControlUtil.GetEndDate();
        }
        
        private void ownerControl1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ownerControl.OwnerID != null)
                {
                    supplierControl.OwnerID = ownerControl.OwnerID;
                    supplierControl.DataLoading();
                }
                else
                {
                    supplierControl.OwnerID = Common.GetDefaultOwnerID();
                    supplierControl.DataLoading();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
        }

        private void gdvSearchResult_ShownEditor(object sender, EventArgs e)
        {
            DataRow View = gdvSearchResult.GetFocusedDataRow();

            if (View != null)
            {

                if (gdvSearchResult.FocusedColumn.FieldName == "SupplierID" && gdvSearchResult.ActiveEditor is SearchLookUpEdit)
                {
                    DevExpress.XtraEditors.SearchLookUpEdit edit;
                    edit = (SearchLookUpEdit)gdvSearchResult.ActiveEditor;

                    List<sp_common_LoadSupplier_Result> ListAll = SupplierBusinessClass.DataLoading(DataUtil.Convert<int>(View["OwnerID"]));

                    List<sp_common_LoadSupplier_Result> ListClone = new List<sp_common_LoadSupplier_Result>();

                    ListClone = ListAll;

                    edit.Properties.DataSource = ListClone;
                }
                else if (gdvSearchResult.FocusedColumn.FieldName == "ProductID" && gdvSearchResult.ActiveEditor is SearchLookUpEdit)
                {
                    DevExpress.XtraEditors.SearchLookUpEdit edit;
                    edit = (SearchLookUpEdit)gdvSearchResult.ActiveEditor;

                    DataTable dt = ProductMasterBusinessClass.DataLoading(DataUtil.Convert<int>(View["OwnerID"]), null, null, DataUtil.Convert<int>(View["SupplierID"]));
                    
                    DataView view = new DataView(dt);
                    DataTable distinctValues = view.ToTable(true, "ProductID", "ProductCode", "ProductLongName");
                    edit.Properties.DataSource = distinctValues.Copy();
                }
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
            repSupplierCode.DataSource = SupplierBusinessClass.DataLoading(null);
            //repItemCode.DataSource = ProductBusinessClass.DataLoading(null);
            repItemCode.DataSource = ProductMasterBusinessClass.DataLoading(null, null, null, null);
            repCurrencyCode.DataSource = CurrencyBusinessClass.DataLoading(null, null);
        }
        private void DataLoading()
        {
            //grdSearchResult.DataSource = BusinessClass.DataLoading(supplierControl.SupplierID, DataUtil.Convert<DateTime>(dtEffectiveFrom.EditValue), DataUtil.Convert<DateTime>(dtEffectiveTo.EditValue));
            //base.GridViewOnChangeLanguage(grdSearchResult);
            InitialCombobox();
            dtResult = BusinessClass.DataLoading(ownerControl.OwnerID,supplierControl.SupplierID, DataUtil.Convert<DateTime>(dtEffectiveFrom.EditValue), DataUtil.Convert<DateTime>(dtEffectiveTo.EditValue));
            if (dtResult.Rows.Count <= 0)
            {
                dtResult.Columns.Add("ROWID", typeof(int));
                dtResult.Columns.Add("PurchasePriceID", typeof(int));
                dtResult.Columns.Add("OwnerID", typeof(int));
                dtResult.Columns.Add("OwnerName", typeof(string));
                dtResult.Columns.Add("SupplierID", typeof(int));
                dtResult.Columns.Add("SupplierCode", typeof(string));
                dtResult.Columns.Add("SupplierLongName", typeof(string));
                dtResult.Columns.Add("ProductID", typeof(int));
                dtResult.Columns.Add("ProductName", typeof(string));
                dtResult.Columns.Add("PurchasePrice", typeof(double));
                dtResult.Columns.Add("CurrencyID", typeof(int));
                dtResult.Columns.Add("Convertor", typeof(string));
                dtResult.Columns.Add("Incoterm", typeof(string));
                dtResult.Columns.Add("EffectiveDate", typeof(DateTime));
                dtResult.Columns.Add("ExpiryDate", typeof(DateTime));
                dtResult.Columns.Add("ImplementDate", typeof(DateTime));
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
                dtClone.Columns.Add("PurchasePriceID", typeof(int));
                dtClone.Columns.Add("OwnerID", typeof(int));
                dtClone.Columns.Add("OwnerName", typeof(string));
                dtClone.Columns.Add("SupplierID", typeof(int));
                dtClone.Columns.Add("SupplierCode", typeof(string));
                dtClone.Columns.Add("SupplierLongName", typeof(string));
                dtClone.Columns.Add("ProductID", typeof(int));
                dtClone.Columns.Add("ProductName", typeof(string));
                dtClone.Columns.Add("PurchasePrice", typeof(double));
                dtClone.Columns.Add("CurrencyID", typeof(int));
                dtClone.Columns.Add("Convertor", typeof(string));
                dtClone.Columns.Add("Incoterm", typeof(string));
                dtClone.Columns.Add("EffectiveDate", typeof(DateTime));
                dtClone.Columns.Add("ExpiryDate", typeof(DateTime));
                dtClone.Columns.Add("ImplementDate", typeof(DateTime));
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
                gdcSupplierID.AppearanceCell.BackColor = Color.Yellow;
                gdcProductID.AppearanceCell.BackColor = Color.Yellow;
                gdcEffectiveDate.AppearanceCell.BackColor = Color.Yellow;
                gdcImplementDate.AppearanceCell.BackColor = Color.Yellow;
                gdcPurchasePrice.AppearanceCell.BackColor = Color.Yellow;
                gdcCurrencyID.AppearanceCell.BackColor = Color.Yellow;
                gdcConvertor.AppearanceCell.BackColor = Color.Yellow;
                gdcIncoterm.AppearanceCell.BackColor = Color.Yellow;
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
            gdcSupplierID.OptionsColumn.AllowEdit = IsEdit;
            gdcProductID.OptionsColumn.AllowEdit = IsEdit;
            gdcEffectiveDate.OptionsColumn.AllowEdit = IsEdit;
            gdcImplementDate.OptionsColumn.AllowEdit = IsEdit;
            gdcPurchasePrice.OptionsColumn.AllowEdit = IsEdit;
            gdcCurrencyID.OptionsColumn.AllowEdit = IsEdit;
            gdcConvertor.OptionsColumn.AllowEdit = IsEdit;
            gdcIncoterm.OptionsColumn.AllowEdit = IsEdit;
            gdcRemark.OptionsColumn.AllowEdit = IsEdit;
        }
        private void OpenDialog(string fileName)
        {
            try
            {

                if (m_Dialog == null)
                {
                    m_Dialog = new Dialog.dlgXMSS330_PurchasePrice(fileName);
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
        private void EnbleEditMode(bool enble)
        {

            ControlUtil.HiddenControl(!enble, m_toolBarSave, m_toolBarCancel);
            ControlUtil.HiddenControl(enble, m_toolBarEdit, m_toolBarDelete, m_toolBarImport, m_toolBarExport);
            ControlUtil.HiddenControl(enble, q_toolBarEdit, q_toolBarDelete);
            
            ControlUtil.HiddenControl(enble, gdcOwnerCode, gdcSupplierCode, gdcProductCode, gdcCurrencyCode);
            ControlUtil.HiddenControl(!enble, gdcOwnerID, gdcSupplierID, gdcProductID, gdcCurrencyID);
            SetEditTableColor(enble);

            if (enble)
            {
                gdcOwnerID.VisibleIndex             = 0;
                gdcOwnerName.VisibleIndex           = 1;
                gdcSupplierID.VisibleIndex          = 2;
                gdcSupplierLongName.VisibleIndex    = 3;
                gdcProductID.VisibleIndex           = 4;
                gdcProductName.VisibleIndex         = 5;
                gdcPurchasePrice.VisibleIndex       = 6;
                gdcCurrencyID.VisibleIndex          = 7;
                gdcConvertor.VisibleIndex           = 8;
                gdcIncoterm.VisibleIndex            = 9;
                gdcEffectiveDate.VisibleIndex       = 10;
                gdcExpiryDate.VisibleIndex          = 11;
                gdcImplementDate.VisibleIndex       = 12;
                gdcRemark.VisibleIndex              = 13;
                gdcCreateDate.VisibleIndex          = 14;
                gdcCreateUser.VisibleIndex          = 15;
                gdcUpdateDate.VisibleIndex          = 16;
                gdcUpdateUser.VisibleIndex          = 17;
            }
            else
            {
                gdcOwnerCode.VisibleIndex           = 0;
                gdcOwnerName.VisibleIndex           = 1;
                gdcSupplierCode.VisibleIndex        = 2;
                gdcSupplierLongName.VisibleIndex    = 3;
                gdcProductCode.VisibleIndex         = 4;
                gdcProductName.VisibleIndex         = 5;
                gdcPurchasePrice.VisibleIndex       = 6;
                gdcCurrencyCode.VisibleIndex        = 7;
                gdcConvertor.VisibleIndex           = 8;
                gdcIncoterm.VisibleIndex            = 9;
                gdcEffectiveDate.VisibleIndex       = 10;
                gdcExpiryDate.VisibleIndex          = 11;
                gdcImplementDate.VisibleIndex       = 12;
                gdcRemark.VisibleIndex              = 13;
                gdcCreateDate.VisibleIndex          = 14;
                gdcCreateUser.VisibleIndex          = 15;
                gdcUpdateDate.VisibleIndex          = 16;
                gdcUpdateUser.VisibleIndex          = 17;
            }
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
                    dtImport.Columns.Add("SupplierCode", typeof(string));
                    dtImport.Columns.Add("ProductCode", typeof(string));
                    dtImport.Columns.Add("EffectiveDate", typeof(DateTime));
                    dtImport.Columns.Add("ImplementDate", typeof(DateTime));
                    dtImport.Columns.Add("PurchasePrice", typeof(decimal));
                    dtImport.Columns.Add("Currency", typeof(string));
                    dtImport.Columns.Add("Incoterm", typeof(string));
                    dtImport.Columns.Add("Remark", typeof(string));
                    dtImport.Columns.Add("Convertor", typeof(decimal));

                    using (excel)
                    {
                        excel.OpenExcel(ofdImport.FileName);
                        int row = 2;
                        
                        while (!string.IsNullOrWhiteSpace(excel.ReadData(row, 1)))
                        {
                            dtImport.Rows.Add(excel.ReadData(row, 1).ToLower().Trim(), excel.ReadData(row, 2).ToLower().Trim(), DateTime.ParseExact(excel.ReadData(row, 3).ToLower().Trim(), "dd/MM/yyyy", new System.Globalization.CultureInfo("en-US")), DateTime.ParseExact(excel.ReadData(row, 4).ToLower().Trim(), "dd/MM/yyyy", new System.Globalization.CultureInfo("en-US")), excel.ReadData(row, 5).ToLower().Trim(), excel.ReadData(row, 6).ToLower().Trim(), excel.ReadData(row, 7).ToLower().Trim(), excel.ReadData(row, 8).ToLower().Trim(), excel.ReadData(row, 9).ToLower().Trim());
                            row++;
                        }
                    }
                    dtImport.Columns["EffectiveDate"].DateTimeMode = DataSetDateTime.Unspecified;
                    dtImport.Columns["ImplementDate"].DateTimeMode = DataSetDateTime.Unspecified;
                    DataSet ds = new DataSet();
                    ds.DataSetName = "PurchaseDataSet";
                    dtImport.TableName = "PurchaseDataTable";
                    ds.Tables.Add(dtImport);
                    foreach (DataRow dr in dtImport.Rows)
                    {
                        DataRow[] drChk = dtImport.Select("SupplierCode = '" + dr["SupplierCode"].ToString().ToLower().Trim() + "' and ProductCode = '" + dr["ProductCode"].ToString().ToLower().Trim() + "'");

                        if (drChk.Length > 1)
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, "SupplierCode " + dr["SupplierCode"] + " มี ProductCode " +dr["ProductCode"] + " มากกว่า 1 แถว");
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

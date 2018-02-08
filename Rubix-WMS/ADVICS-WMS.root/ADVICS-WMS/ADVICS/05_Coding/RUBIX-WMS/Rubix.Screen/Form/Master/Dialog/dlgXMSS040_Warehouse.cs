/*
 * 20121226:
 * 1. change MaxM3, MaxM2 to SpinEdit and implement OnEditValueChanging event on them
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using CSI.Business.Master;
using CSI.Business;
using Rubix.Framework;
using System.Xml;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using System.Text.RegularExpressions;
namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS040_Warehouse : DialogBase, Rubix.Framework.IClearable
    {
        #region Member
        String strCustomerID = String.Empty; // For select Work Method Setting
        String strDCID = String.Empty; // For select Work Method Setting

        private Warehouse db;
        private Common.eScreenMode eScrenMode;
        //create temp DataTable           
        private DataTable temp = new DataTable();
        #endregion

        #region Enumeration
        private enum eColOwner
        {
            WarehouseID,
            OwnerID,
            OwnerCode,
            OwnerName        
        }
        private enum eColWorkMethod
        {
            ModuleID,
            ModultName,
            OwnerID,
            WarehouseID
        }
        #endregion

        #region Properties
        public String OwnerID
        {
            get { return strCustomerID; }
            set { strCustomerID = value; }
        }
        public String WarehouseID
        {
            get { return strDCID; }
            set { strDCID = value; }
        }


        public Warehouse BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Warehouse();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new Warehouse();
                }
                db = value;
            }
        }
        public Common.eScreenMode ScreenMode
        {
            get { return eScrenMode; }
            set { eScrenMode = value; }
        }
        
        #endregion

        #region Constructor
        public dlgXMSS040_Warehouse()
        {
            InitializeComponent();
            base.GridViewControl = new GridControl[] { grdOwner, grdWorkMethod };
        }
        #endregion

        #region Event Handler Function
        private void dlgXMSS040_Warehouse_Load(object sender, EventArgs e)
        {
            try
            {
                loadDivision();
                gdvWorkMethod.OptionsBehavior.Editable = true;
                temp = (DataTable)BusinessClass.LoadWorkMethodData(null, null).Clone();

                if (ScreenMode == Common.eScreenMode.View)
                {
                    ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
                    ControlUtil.EnableControl(false, Controls);
                    gdvWorkMethod.OptionsBehavior.Editable = false;
                }
                else
                {
                    ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);
                }
                if (ScreenMode == Common.eScreenMode.Add)
                {
                    m_statusBarCreatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                    m_statusBarCreatedUser.Caption = AppConfig.UserLogin;
                    m_statusBarUpdatedDate.Caption = "-";
                    m_statusBarUpdatedUser.Caption = "-";
                    ownerControl.DataLoading();
                    if (BusinessClass.WarehouseCode != null)
                    {
                        BusinessClass = new Warehouse();
                    }
                    clearControl();
                }
                else
                {
                    DataBinding();
                }
                //load Customer Data
                if (BusinessClass.WarehouseID != 0)
                {
                    grdOwner.DataSource = BusinessClass.LoadOwner(Convert.ToInt32(BusinessClass.WarehouseID));
                    Rubix.Framework.ControlUtil.SetBestWidth(gdvOwner);

                    if (grdOwner.DataSource != null)
                    {
                        //Load WorkMethod Detail
                        loadWorkMethod();
                    }

                }           
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.ToString());
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkGrid())
            {
                if (gdvOwner.DataSource == null || gdvOwner.RowCount <= 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("WarehouseID", typeof(int));
                    dt.Columns.Add("OwnerID", typeof(int));
                    dt.Columns.Add("OwnerCode", typeof(string));
                    dt.Columns.Add("OwnerName", typeof(string));
                    
                    grdOwner.DataSource = dt;

                    gdvOwner.Columns[(int)eColOwner.WarehouseID].Visible = false;
                    gdvOwner.Columns[(int)eColOwner.OwnerID].Visible = false;

                    ControlUtil.SetBestWidth(gdvOwner);
                    ControlUtil.SetBestWidth(gdvWorkMethod);
                }
                gdvOwner.AddNewRow();
                gdvOwner.UpdateCurrentRow();
                int? pCustomerID = ownerControl.OwnerID;
                addNewTemp(pCustomerID);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (gdvOwner.RowCount > 0)
            {
                int rows = gdvOwner.GetFocusedDataSourceRowIndex();
                string pCustomer = gdvOwner.GetRowCellValue(rows, eColOwner.OwnerID.ToString()).ToString();
                deleteRowTemp(Convert.ToInt32(pCustomer));
                gdvOwner.DeleteRow(rows);
                if (gdvOwner.SelectedRowsCount > 0)
                {
                    gdvOwner.FocusedRowHandle = 0;
                    setGridWorkMethod(gdvOwner.GetRowCellValue(0, eColOwner.OwnerID.ToString()).ToString());
                }
                else  //no data
                {
                    grdWorkMethod.DataSource = null;
                    gdvWorkMethod.Columns.Clear();
                }
            }
        }

        private void gdvCustomer_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColOwner.WarehouseID], BusinessClass.WarehouseID);
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColOwner.OwnerID], ownerControl.OwnerID);
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColOwner.OwnerCode], ownerControl.OwnerCode);
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColOwner.OwnerName], ownerControl.OwnerName);
        }

        private void gdvCustomer_RowClick(object sender, RowClickEventArgs e)
        {
            string pcustomerID = gdvOwner.GetRowCellValue(e.RowHandle, gdvOwner.Columns[(int)eColOwner.OwnerID]).ToString();
            saveWorkMethodToTemp();
            setGridWorkMethod(pcustomerID);
            
            
        }

        private void gdvWorkMethod_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.AbsoluteIndex > 3)
            {
                int column = Convert.ToInt32(e.Column.AbsoluteIndex) + 1;
                System.Data.DataRow row = gdvWorkMethod.GetDataRow(e.RowHandle);
                row[column] = e.Value;
            }
        }

        private void txtMaxM3_EditValueChanging(object sender, ChangingEventArgs e)
        {
            decimal value = Convert.ToDecimal(e.NewValue);
            e.Cancel = value > ((SpinEdit)sender).Properties.MaxValue ||
                value < ((SpinEdit)sender).Properties.MinValue;
        }

        private void txtMaxM2_EditValueChanging(object sender, ChangingEventArgs e)
        {
            decimal value = Convert.ToDecimal(e.NewValue);
            e.Cancel = value > ((SpinEdit)sender).Properties.MaxValue ||
                value < ((SpinEdit)sender).Properties.MinValue;
        }

        #endregion

        #region Override Method
        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
        }
        public override bool ValidateChildren()
        {
            return base.ValidateChildren();
        }
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), txtWarehouseLongName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistWarehouseCode(BusinessClass.WarehouseID ,txtWarehouseCode.Text.Trim()) && BusinessClass.WarehouseCode != txtWarehouseCode.Text.Trim())
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0142"));
                            return false;
                        }
                        
                        SaveData();
                        DialogResult = DialogResult.OK;
                        return true;


                    }
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
            ControlUtil.ClearControlData(this);
            return base.OnCommandClear();
        }
        
        #endregion

        #region Generic Function
        private void EnableControl(Common.eScreenMode ScreenMode)
        {
            switch (ScreenMode)
            {
                case Common.eScreenMode.View:
                    ControlUtil.EnableControl(false, txtWarehouseCode,txtWarehouseLongName,txtMobile,txtPhoneNo,txtExt,
                                       txtFax,txtAddress1,txtAddress2,txtContactName1,txtContactName2,txtContactName3);
                    break;
            }
        }
        private void DataBinding()
        {
            
            txtWarehouseCode.Text = BusinessClass.WarehouseCode;
            txtWarehouseLongName.Text = BusinessClass.WarehouseName;
            txtMobile.Text = BusinessClass.Mobile;
            txtPhoneNo.Text = BusinessClass.PhoneNo;
            txtExt.Text = BusinessClass.Extension;
            txtFax.Text = BusinessClass.FaxNo;
            txtAddress1.Text = BusinessClass.Address1;
            txtAddress2.Text = BusinessClass.Address2;
            txtContactName1.Text = BusinessClass.ContactName1;
            txtContactName2.Text = BusinessClass.ContactName2;
            txtContactName3.Text = BusinessClass.ContactName3;            
            cmbDivision.EditValue = BusinessClass.Division;
            txtManPow.Text = Convert.ToString(BusinessClass.ManPower);
            txtMaxCap.Text = Convert.ToString(BusinessClass.MaxCapacity);
            txtMaxPallet.Text = Convert.ToString(BusinessClass.MaxPallet);
            txtNoofForldift.Text = Convert.ToString(BusinessClass.NoOfForklift);
            txtInCharge.Text = BusinessClass.InCharge;
            txtRemark.Text = BusinessClass.Remark;

            if(BusinessClass.MaxM3 != null)
            {
                txtMaxM3.Text = Convert.ToString(BusinessClass.MaxM3);
            }
            if(BusinessClass.MaxM2 != null)
            {
                txtMaxM2.Text = Convert.ToString(BusinessClass.MaxM2);
            }
            //Binding Statusbar
            m_statusBarCreatedDate.Caption = BusinessClass.CreateDate.ToString(Common.FullDatetimeFormat);
            m_statusBarCreatedUser.Caption = BusinessClass.CreateUser;
            if (BusinessClass.UpdateDate != null)
            {
                m_statusBarUpdatedDate.Caption = Convert.ToDateTime(BusinessClass.UpdateDate).ToString(Common.FullDatetimeFormat);
                m_statusBarUpdatedUser.Caption = BusinessClass.CreateUser;
            }
            else if (BusinessClass.UpdateDate == null && ScreenMode == Common.eScreenMode.Edit)
            {
                m_statusBarUpdatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarUpdatedUser.Caption = AppConfig.UserLogin;
            }
            
        }
        private void SaveData()
        {
            saveWorkMethodToTemp();
            DataSet dsWorkMethod = setDataWorkMethodToSave(temp);
            BusinessClass.WarehouseCode = txtWarehouseCode.Text;
            BusinessClass.WarehouseName = txtWarehouseLongName.Text;
            BusinessClass.Mobile = txtMobile.Text;
            BusinessClass.PhoneNo = txtPhoneNo.Text;
            BusinessClass.Extension = txtExt.Text;
            BusinessClass.FaxNo = txtFax.Text;
            BusinessClass.Address1 = txtAddress1.Text;
            BusinessClass.Address2 = txtAddress2.Text;
            BusinessClass.ContactName1 = txtContactName1.Text;
            BusinessClass.ContactName2 = txtContactName2.Text;
            BusinessClass.ContactName3 = txtContactName3.Text;
            //BusinessClass.Division = cmbDivision.EditValue;
            BusinessClass.InCharge = txtInCharge.Text;
            BusinessClass.Remark = txtRemark.Text;
            if (cmbDivision.EditValue == null)
            {
                //BusinessClass.Division = null;
            }
            else
            {
                BusinessClass.Division = Convert.ToString(cmbDivision.EditValue);
            }
            if (txtMaxPallet.Text == string.Empty)
            {
                BusinessClass.MaxPallet = null;
            }
            else
            {
               //BusinessClass.MaxPallet = Convert.ToInt32(txtMaxPallet.Text.Trim());
                int val;
                if (Int32.TryParse(txtMaxPallet.EditValue.ToString(), out val))
                    BusinessClass.MaxPallet = val;
                
            }
            if (txtNoofForldift.Text == string.Empty)
            {
                BusinessClass.NoOfForklift = null;
            }
            else
            {
                //BusinessClass.NoOfForklift = Convert.ToInt32(txtNoofForldift.Text.Trim());
                int val;
                if (Int32.TryParse(txtNoofForldift.EditValue.ToString(), out val))
                    BusinessClass.NoOfForklift = val;
            }
            if (txtManPow.Text == string.Empty)
            {
                BusinessClass.ManPower = null;
            }
            else
            {
                //BusinessClass.ManPower = Convert.ToInt32(txtManPow.Text.Trim());
                int val;
                if (Int32.TryParse(txtManPow.EditValue.ToString(), out val))
                    BusinessClass.ManPower = val;
            }
            if (txtMaxCap.Text == string.Empty)
            {
                BusinessClass.MaxCapacity = null;
            }
            else
            {
                BusinessClass.MaxCapacity = Convert.ToDecimal(txtMaxCap.Text.Trim());
            }

            if (txtMaxM3.Text == string.Empty)
            {
                BusinessClass.MaxM3 = null;
            }
            else
            {
                BusinessClass.MaxM3 = Convert.ToDecimal(txtMaxM3.Text.Trim());          
            }

            if (txtMaxM2.Text == string.Empty)
            {
                BusinessClass.MaxM2 = null;
            }
            else
            {
                BusinessClass.MaxM2 = Convert.ToDecimal(txtMaxM2.Text.Trim());
            }
            BusinessClass.CreateUser = AppConfig.UserLogin;

            string xmlCustomer = null;
            if (false == gdvOwner.IsEmpty) 
            {
                DataSet ds = new DataSet("NewDataSet");
                ds.Clear();
                DataTable dt = ((DataTable)grdOwner.DataSource);
                dt.TableName = "Table";
                ds.Tables.Add(dt);
                xmlCustomer = ds.GetXml();
            }
            dsWorkMethod.Tables[0].TableName = "Table";
            BusinessClass.SaveWarehouseData(xmlCustomer, dsWorkMethod.GetXml());         
            
        }
        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();
            ////Warehouse Code
            if (string.IsNullOrWhiteSpace(txtWarehouseCode.Text))
            {
                errorProvider.SetError(txtWarehouseCode, Common.GetMessage("I0143"));
                errFlag = false;
            }

            ////Warehouse Name
            if (string.IsNullOrWhiteSpace(txtWarehouseLongName.Text))
            {
                errorProvider.SetError(txtWarehouseLongName, Common.GetMessage("I0144"));
                errFlag = false;
            }

            ////Division Code
            //if (cmbDivision.EditValue == null)
            //{
            //    errorProvider.SetError(cmbDivision, Common.GetMessage("I0145"));
            //    errFlag = false;
            //}
            //else
            //{
            //    errorProvider.SetError(cmbDivision, String.Empty);
            //}

            //if (txtMaxM2.EditValue  == null || DataUtil.Convert<decimal>(txtMaxM2.EditValue) <= 0)
            //{
            //    errorProvider.SetError(txtMaxM2, Common.GetMessage("I0147"));
            //    errFlag = false;
            //}
            //else
            //{
            //    errorProvider.SetError(txtMaxM2, String.Empty);
            //}

            //if (txtMaxM3.EditValue == null || DataUtil.Convert<decimal>(txtMaxM3.EditValue) <= 0)
            //{
            //    errorProvider.SetError(txtMaxM3, Common.GetMessage("I0148"));
            //    errFlag = false;
            //}
            //else
            //{
            //    errorProvider.SetError(txtMaxM3, String.Empty);
            //}

            if (txtInCharge.EditValue != null && !string.IsNullOrWhiteSpace(txtInCharge.Text))
            {
                foreach(string email in txtInCharge.Text.Split(';')) {
                    if (string.IsNullOrWhiteSpace(email))
                        continue;
                    if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$"))
                    {
                        errFlag = false;
                    }
                }
                if (!errFlag)
                    errorProvider.SetError(txtInCharge, Common.GetMessage("I0267"));
            }
            return errFlag;
        }       
        private void loadDivision()
        {
            
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox properties = cmbDivision.Properties;
            properties.Items.AddRange(new string[] {"Internal", "External"});
            //Select the first item 
            cmbDivision.SelectedIndex = -1;
            //Disable editing 
            //properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            
        }
        private bool checkGrid()
        {
            if (ownerControl.OwnerID == null)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0026"));
                return false;
            }
            if (gdvOwner.RowCount != 0)
            {
                DataRow[] dr = ((DataTable)grdOwner.DataSource).Select(String.Format("OwnerID = {0}", ownerControl.OwnerID));

                if (dr.Length > 0)
                {
                    return false;
                }
            }
            return true;

        }
        
        private void loadWorkMethod()
        { 
            int flag = 0;
            int? pCustomerID = null;
            int? pDCID = null ;
            DataTable dt = (DataTable)grdOwner.DataSource;
            
            if (dt.Rows.Count != 0)
            {
                ///for insert in temp table
                foreach (DataRow row in dt.Rows)
                {
                    pCustomerID = Convert.ToInt32(row[(int)eColOwner.OwnerID].ToString());
                    pDCID = Convert.ToInt32(row[(int)eColOwner.WarehouseID].ToString());
                    DataTable dtLoad = (DataTable)BusinessClass.LoadWorkMethodData(pCustomerID, pDCID);
                    DataRow dr = temp.NewRow();

                    foreach (DataRow rowLoad in dtLoad.Rows)
                    {
                        //temp.ImportRow(rowLoad);
                        DataRow newRow = temp.NewRow();
                        newRow.ItemArray = rowLoad.ItemArray;
                        temp.Rows.Add(newRow);
                    }

                }
                setGridWorkMethod(dt.Rows[0][(int)eColOwner.OwnerID].ToString());
            }
            
        }        
        private void setGridWorkMethod(string OwnerID)
        {            
            string filter = eColWorkMethod.OwnerID.ToString() + "=" + OwnerID;
            DataView dv = new DataView(temp, filter, "", DataViewRowState.CurrentRows);
            grdWorkMethod.DataSource = dv.ToTable();

            ///set show grid and hide colune not use
            Rubix.Framework.ControlUtil.SetBestWidth(gdvWorkMethod);
            gdvWorkMethod.Columns[(int)eColWorkMethod.ModuleID].Visible = false;
            gdvWorkMethod.Columns[(int)eColWorkMethod.OwnerID].Visible = false;
            gdvWorkMethod.Columns[(int)eColWorkMethod.WarehouseID].Visible = false;
            gdvWorkMethod.Columns[(int)eColWorkMethod.ModultName].OptionsColumn.AllowEdit = false;
            for (int i = 0; i < gdvWorkMethod.Columns.Count; i++)
            {
                if (i > 3)
                {
                    if ((i % 2) == 0)
                    {
                        ///hide Method id column
                        gdvWorkMethod.Columns[i+1].Visible = false;
                    }
                }
            }
            
        }

        private void saveWorkMethodToTemp()
        {
            DataTable dtGrd = (DataTable)grdWorkMethod.DataSource;
            if (dtGrd != null)
            {
                for (int i = 0; i < dtGrd.Rows.Count; i++)
                {
                    DataRow row = dtGrd.Rows[i];
                    for (int j = 0; j < temp.Rows.Count; j++)
                    {
                        DataRow rowTemp = temp.Rows[j];
                        if (row[eColWorkMethod.WarehouseID.ToString()].ToString() == rowTemp[eColWorkMethod.WarehouseID.ToString()].ToString() &&
                            row[eColWorkMethod.OwnerID.ToString()].ToString() == rowTemp[eColWorkMethod.OwnerID.ToString()].ToString() &&
                              row[eColWorkMethod.ModuleID.ToString()].ToString() == rowTemp[eColWorkMethod.ModuleID.ToString()].ToString())
                        {
                            for (int k = 0; k < temp.Columns.Count; k++)
                            {
                                rowTemp[k] = row[k];
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void addNewTemp(int? OwnerID)
        {
            saveWorkMethodToTemp();
            DataTable dtLoad = (DataTable)BusinessClass.LoadWorkMethodData(OwnerID, BusinessClass.WarehouseID);
            DataRow dr = temp.NewRow();
            foreach (DataRow rowLoad in dtLoad.Rows)
            {
                //temp.ImportRow(rowLoad);
                DataRow newRow = temp.NewRow();
                for (int i = 4; i < dtLoad.Columns.Count; i ++ )
                {
                    rowLoad[i] = true;
                }
                newRow.ItemArray = rowLoad.ItemArray;
                temp.Rows.Add(newRow);
            }
            setGridWorkMethod(Convert.ToString(OwnerID));
        }
        private void deleteRowTemp(int? OwnerID) 
        {
            string filter = eColWorkMethod.OwnerID.ToString() + "=" + OwnerID;
            DataView dv = new DataView(temp, filter, "", DataViewRowState.CurrentRows);
            // Delete these rows.
            foreach (DataRowView row in dv)
            {
                row.Delete();
            }
        }
        private DataSet setDataWorkMethodToSave(DataTable TempTable) 
        {
            DataTable dtWorkMethod = new DataTable();
            DataSet dsWorkMethod = new DataSet();
            dtWorkMethod = TempTable.Copy();
            foreach (DataColumn column in TempTable.Columns)
            {
                if (column.Ordinal > 3)
                {
                    if ((column.Ordinal % 2) == 0)
                    {
                        dtWorkMethod.Columns.Remove(column.ColumnName);
                    }
                }
            }
            dsWorkMethod.Tables.Add(dtWorkMethod);
            return dsWorkMethod;
        }
        private void clearControl()
        {
            ControlUtil.ClearControlData(txtWarehouseCode
                                            , txtWarehouseLongName
                                            , txtMobile
                                            , txtPhoneNo
                                            , txtExt
                                            , txtFax
                                            , txtAddress1
                                            , txtAddress2
                                            , txtContactName1
                                            , txtContactName2
                                            , txtContactName3
                                            , cmbDivision
                                            , txtMaxM3
                                            , txtMaxM2
                                            , txtManPow
                                            , txtMaxCap
                                            , txtMaxPallet
                                            , txtNoofForldift
                                            , txtRemark
                                            , txtInCharge);
            grdOwner.DataSource = null;
            grdWorkMethod.DataSource = null;
            gdvOwner.Columns.Clear();
            gdvWorkMethod.Columns.Clear();
            ownerControl.ClearData();
            temp.Clear();
        }
        public void ClearData()
        {
            errorProvider.ClearErrors();
            if (ScreenMode == Common.eScreenMode.Add)
            {
                clearControl();
            }
            else
            {
                DataBinding();
            }
        }
        #endregion             

    }
}
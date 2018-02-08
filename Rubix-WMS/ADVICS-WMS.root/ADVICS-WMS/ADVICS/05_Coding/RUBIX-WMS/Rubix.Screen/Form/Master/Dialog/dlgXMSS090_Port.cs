using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using CSI.Business.Master;
using Rubix.Framework;
using CSI.Business.DataObjects;
using System.Data.Objects;
using DevExpress.XtraGrid.Views.Grid;

namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS090_Port : DialogBase, Rubix.Framework.IClearable
    {
        #region Member
        int iPortID = 0;
        String strPortCode = String.Empty;
        private PortInformation db;
        private Common.eScreenMode eScrenMode;
        private Currency db_currency;
        #endregion

        #region Enum
        public enum eColCustomer
        {
            PortID,
            OwnerID,
            OwnerCode,
            OwnerName
        }
        #endregion

        #region Properties
        public int PortID
        {
            get { return iPortID; }
            set { iPortID = value; }
        }
        public String PortCode
        {
            get { return strPortCode; }
            set { strPortCode = value; }
        }
        public PortInformation BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new PortInformation();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new PortInformation();
                }
                db = value;
            }
        }
        public Currency CurrencyBusinessClass
        {
            get
            {
                if (db_currency == null)
                {
                    db_currency = new Currency();
                }
                return db_currency;
            }
            set
            {
                if (db_currency == null)
                {
                    db_currency = new Currency();
                }
                db_currency = value;
            }
        }
        public Common.eScreenMode ScreenMode
        {
            get { return eScrenMode; }
            set { eScrenMode = value; }
        }
        #endregion

        #region Constructor
        public dlgXMSS090_Port()
        {
            InitializeComponent();
            base.GridViewControl = new GridControl[] { grdCustomer };
        }
        #endregion

        #region Event Handler Function
        private void dlgXMSS090_Port_Load(object sender, EventArgs e)
        {
            ownerControl.DataLoading();
           
            if (ScreenMode == Common.eScreenMode.View)
            {
                ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
                ControlUtil.EnableControl(false, Controls);
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
                ControlUtil.ClearControlData(txtPortCode, txtPortName);
                gdvCustomer.Columns.Clear();
                grdCustomer.DataSource = null;
                if (BusinessClass.PortCode != null)
                {
                    BusinessClass = new PortInformation();
                }
            }
            else
            {
                DataBinding();
            }
            if (txtPortCode.Enabled == false)
            {
                txtPortCode.Focus();
            }
            else
            {
                txtPortName.Focus();
            }
            //load data
            DataBindingCustomer();
            LoadPortClassification();
            LoadCurrency();
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (checkGrid())
            {
                gdvCustomer.AddNewRow();
                gdvCustomer.UpdateCurrentRow();
            }
        }
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (gdvCustomer.RowCount > 0)
            {
                int rows = gdvCustomer.GetFocusedDataSourceRowIndex();
                gdvCustomer.DeleteRow(rows);
            }
        }
        private void gdvCustomer_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColCustomer.PortID], BusinessClass.PortID);
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColCustomer.OwnerID], ownerControl.OwnerID);
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColCustomer.OwnerCode], ownerControl.OwnerCode);
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColCustomer.OwnerName], ownerControl.OwnerName);
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0047"),txtPortName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistPortCode(txtPortCode.Text.Trim()) && BusinessClass.PortCode != txtPortCode.Text.Trim() )
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0038"));
                            return false;
                        }
                        
                        SavaData();
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
        private void LoadCurrency()
        {
            
            cboCurrency.Properties.DataSource = CurrencyBusinessClass.DataLoading(null,null);
            cboCurrency.Properties.DisplayMember = "CurrencyCode";
            cboCurrency.Properties.ValueMember = "CurrencyID";

        }
        
        private void clearControl()
        {
            ControlUtil.ClearControlData(txtPortCode
                                            , txtPortName
                                            , txtPostalCode
                                            , txtCountryCode
                                            , txtLeadTimeDays
                                            , txtLeadTimeHour
                                            , memAddress1
                                            , memRemark);
            cboPortClassification.EditValue = null;
            //grdCustomer.DataSource = null;
        }        

        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            //Port Code
            if (txtPortCode.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtPortCode, Rubix.Screen.Common.GetMessage("I0035"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtPortCode, String.Empty);
            }

            //Port Name
            if (txtPortName.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtPortName, Rubix.Screen.Common.GetMessage("I0036"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtPortName, String.Empty);
            }

            //Port Classification
            if (cboPortClassification.EditValue == null)
            {
                errorProvider.SetError(cboPortClassification, Rubix.Screen.Common.GetMessage("I0037"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(cboPortClassification, String.Empty);
            }
            return errFlag;
        }

        private void DataBinding()
        {
            txtPortCode.Text = BusinessClass.PortCode;
            txtPortName.Text = BusinessClass.PortLongName;
            cboPortClassification.EditValue = BusinessClass.PortClassification;
            txtCountryCode.Text = BusinessClass.CountryCode;
            txtLeadTimeDays.Text = BusinessClass.LeadTimeDays.ToString();
            txtLeadTimeHour.Text = BusinessClass.LeadTimeHr;
            memAddress1.Text = BusinessClass.PortAddress;
            txtPostalCode.Text = BusinessClass.PostalCode;
            memRemark.Text = BusinessClass.Remark;
            txtFreight.EditValue = BusinessClass.Freight;
            cboCurrency.EditValue = BusinessClass.CurrencyID;

            //grdCustomer.DataSource = BusinessClass.
            //Binding Statusbar
            m_statusBarCreatedDate.Caption = BusinessClass.CreateDate.ToString(Common.FullDatetimeFormat);
            m_statusBarCreatedUser.Caption = BusinessClass.CreateUser;
            if (BusinessClass.UpdateDate != null)
            {
                m_statusBarUpdatedDate.Caption = Convert.ToDateTime(BusinessClass.UpdateDate).ToString(Common.FullDatetimeFormat);
                m_statusBarUpdatedUser.Caption = BusinessClass.UpdateUser;
            }
            else if (BusinessClass.UpdateDate == null && ScreenMode == Common.eScreenMode.Edit)
            {
                m_statusBarUpdatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                m_statusBarUpdatedUser.Caption = AppConfig.UserLogin;
            }
        }

        private void DataBindingCustomer()
        { 
            if (ScreenMode != Common.eScreenMode.Add)
            {
                DataTable dtt = BusinessClass.LoadCustomerData(BusinessClass.PortID);
                if (dtt.Rows.Count > 0)
                {
                    grdCustomer.DataSource = dtt;
                }
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("PortID", typeof(int));
                dt.Columns.Add("OwnerID", typeof(int));
                dt.Columns.Add("OwnerCode", typeof(string));
                dt.Columns.Add("OwnerName", typeof(string));
                grdCustomer.DataSource = dt;

                gdvCustomer.Columns["PortID"].Visible = false;
                gdvCustomer.Columns["OwnerID"].Visible = false;
            }
        }

        private void SavaData()
        {
            //DataSet result = new DataSet();
            try
            {
                BusinessClass.PortCode = txtPortCode.Text.Trim();
                BusinessClass.PortLongName = txtPortName.Text.Trim();
                BusinessClass.PortClassification = Convert.ToInt32(cboPortClassification.EditValue.ToString());
                BusinessClass.CountryCode = txtCountryCode.Text.Trim();
                BusinessClass.LeadTimeDays = DataUtil.Convert<int>(txtLeadTimeDays.Text.Trim());
 
                BusinessClass.LeadTimeHr = txtLeadTimeHour.Text.Trim();
                BusinessClass.PortAddress = memAddress1.Text.Trim();
                BusinessClass.PostalCode = txtPostalCode.Text.Trim();
                BusinessClass.Remark = memRemark.Text.Trim();
                BusinessClass.CreateUser = AppConfig.UserLogin;
                BusinessClass.Freight = DataUtil.Convert<decimal>(txtFreight.EditValue);
                BusinessClass.CurrencyID = DataUtil.Convert<int>(cboCurrency.EditValue);

                DataSet ds = new DataSet("NewDataSet");
                ds.Clear();
                DataTable dt = ((DataTable)grdCustomer.DataSource);
                dt.TableName = "Table1";
                ds.Tables.Add(dt);
                BusinessClass.SavePortData((ds.GetXml()));
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        private void SaveCustomerData()
        {
            if (gdvCustomer.RowCount > 0)
            {
                DataTable temp = (DataTable)grdCustomer.DataSource;

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    BusinessClass.PortCode = txtPortCode.Text.Trim();
                    BusinessClass.OwnerID = Convert.ToInt32(temp.Rows[i][(int)eColCustomer.OwnerID].ToString());
                    BusinessClass.CreateUser = AppConfig.UserLogin;
                    BusinessClass.SavePortCustomerData();
                }

            }
        }

        private void LoadPortClassification()
        {
            cboPortClassification.Properties.DataSource = BusinessClass.LoadPortClassification();
            cboPortClassification.Properties.ValueMember = "PortClassificationID";
            cboPortClassification.Properties.DisplayMember = "PortClassificationName";
            gdcPortClassificationName.FieldName = "PortClassificationID";
            gdcPortClassificationName.FieldName = "PortClassificationName";

        }

        private bool checkGrid()
        {
            if (ownerControl.OwnerID == null)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0026"));
                return false;
            }

            if (gdvCustomer.RowCount != 0)
            {
                DataRow[] dr = ((DataTable)grdCustomer.DataSource).Select(String.Format("OwnerID = {0}", ownerControl.OwnerID));
                if (dr.Length > 0)
                {
                    return false;
                }
            }
            return true;

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
            DataBindingCustomer();
        }
        #endregion

    }
}
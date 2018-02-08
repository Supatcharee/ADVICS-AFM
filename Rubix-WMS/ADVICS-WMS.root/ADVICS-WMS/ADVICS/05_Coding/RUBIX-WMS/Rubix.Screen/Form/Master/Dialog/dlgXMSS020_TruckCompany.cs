using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using CSI.Business.Master;
using Rubix.Framework;
using DevExpress.XtraGrid.Views.Grid;
using CSI.Business.DataObjects;
using System.Collections.Generic;
using CSI.Business;
using System.Text.RegularExpressions;
namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS020_TruckCompany : DialogBase, Rubix.Framework.IClearable
    {
        #region Member
        private TruckCompany db;
        private Common.eScreenMode eScrenMode;

        #endregion

        #region Enumeration
        private enum eColTruckType
        {
             TruckCompanyID
			,TransportTypeID
			,TransportTypeCode
			,TransportTypeName
            , Width
            , Length
            , Height
            , Capacity
        }
        #endregion

        #region Properties
        public TruckCompany BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new TruckCompany();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new TruckCompany();
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
        public dlgXMSS020_TruckCompany()
        {
            InitializeComponent();
            base.GridViewControl = new GridControl[] { grdTransportType };
        } 
        #endregion

        #region Event Handler Function
        private void dlgXMSS020_TruckCompany_Load(object sender, EventArgs e)
        {
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
                clearControl();
                grdTransportType.DataSource = null;
                //gdvTransportType.Columns.Clear();
                
                if (BusinessClass.TruckCompanyCode != null)
                {
                    BusinessClass = new TruckCompany();
                }
            }
            else
            {
                DataBinding();
            }
            BindingDetail();
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (checkGrid())
            {
                gdvTransportType.AddNewRow();
                gdvTransportType.UpdateCurrentRow();
                ControlUtil.SetBestWidth(gdvTransportType);
            }
        }
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (gdvTransportType.RowCount > 0)
            {
                int rows = gdvTransportType.GetFocusedDataSourceRowIndex();
                gdvTransportType.DeleteRow(rows);
            }
        }
        private void gdvTransportType_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColTruckType.TruckCompanyID], BusinessClass.TruckCompanyID);
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColTruckType.TransportTypeID], transportTypeControl.TransportTypeID);
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColTruckType.TransportTypeCode], transportTypeControl.TransportTypeCode);
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColTruckType.TransportTypeName], transportTypeControl.TransportTypeName);

            if (transportTypeControl.TransportTypeID.HasValue)
            {
                tbm_TransportType tt = BusinessClass.GetTransportType(transportTypeControl.TransportTypeID.Value);
                view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColTruckType.Width], tt.Width);
                view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColTruckType.Length], tt.Length);
                view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColTruckType.Height], tt.Height);
                view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColTruckType.Capacity], tt.Width * tt.Length * tt.Height);
            }
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0047"),txtTruckLongName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistTruckCompanyCode(txtTruckCode.Text.Trim()) && BusinessClass.TruckCompanyCode != txtTruckCode.Text.Trim())
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0023"));
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
            BindingDetail();
            return base.OnCommandClear();
        }
        #endregion

        #region Generic Function
        private void DataBinding()
        {
            txtTruckCode.Text = BusinessClass.TruckCompanyCode;
            txtTruckLongName.Text = BusinessClass.TruckCompanyLongName;
            txtAddress.Text = BusinessClass.TruckCompanyAddress;
            txtMobile.Text = BusinessClass.MobileNo;
            txtPhone.Text = BusinessClass.PhoneNo;
            txtExt.Text = BusinessClass.Extension;
            txtFax.Text = BusinessClass.FaxNo;
            txtContactName1.Text = BusinessClass.ContactName1;
            txtContactName2.Text = BusinessClass.ContactName2;
            txtContactName3.Text = BusinessClass.ContactName3;            

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
        private void BindingDetail()
        {           
            //load data
            if (BusinessClass.TruckCompanyID == 0)
            {
                 DataTable dt = new  DataTable();
                 dt.Columns.Add("TruckCompanyID", typeof(int));
                 dt.Columns.Add("TransportTypeID", typeof(int));
                 dt.Columns.Add("TransportTypeCode", typeof(string));
                 dt.Columns.Add("TransportTypeName", typeof(string));
                 dt.Columns.Add("Width", typeof(decimal));
                 dt.Columns.Add("Length", typeof(decimal));
                 dt.Columns.Add("Height", typeof(decimal));
                 dt.Columns.Add("Capacity", typeof(decimal));
                grdTransportType.DataSource = dt;
            }
             else
            {
                grdTransportType.DataSource = BusinessClass.LoadTruckTransportTypeData(BusinessClass.TruckCompanyID);
            }
            base.GridViewOnChangeLanguage(grdTransportType);
        }
        private void SaveData()
        {
            //DataSet result = new DataSet(); 
            try
            {
                BusinessClass.TruckCompanyCode = txtTruckCode.Text.Trim();
                BusinessClass.TruckCompanyLongName = txtTruckLongName.Text.Trim();
                BusinessClass.TruckCompanyAddress = txtAddress.Text.Trim();
                BusinessClass.MobileNo = txtMobile.Text.Trim();
                BusinessClass.PhoneNo = txtPhone.Text.Trim();
                BusinessClass.Extension = txtExt.Text.Trim();
                BusinessClass.FaxNo = txtFax.Text.Trim();
                BusinessClass.ContactName1 = txtContactName1.Text.Trim();
                BusinessClass.ContactName2 = txtContactName2.Text.Trim();
                BusinessClass.ContactName3 = txtContactName3.Text.Trim();
                BusinessClass.CreateUser = AppConfig.UserLogin;
                
                BusinessClass.SaveTruckCompanyData(getXML());
            }   
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                //result.Tables.Clear();
                //result = null; 
            }
            
        }
        private string getXML()
        {
            string xml;
            if (gdvTransportType.RowCount == 0)
            {
                xml = null;
            }
            else
            {
                DataSet ds = new DataSet("NewDataSet");
                ds.Tables.Clear();
                DataTable dt = ((DataTable)grdTransportType.DataSource);
                dt.TableName = "Table";
                ds.Tables.Add(dt);
                xml = ds.GetXml();
            }
            return xml;
        
        }
        private void clearControl()
        {
            ControlUtil.ClearControlData(txtTruckCode
                                            , txtTruckLongName
                                            , txtAddress
                                            , txtMobile
                                            , txtPhone
                                            , txtExt
                                            , txtFax
                                            , txtContactName1
                                            , txtContactName2
                                            , txtContactName3);
        }        
        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            ////Truck Code
            if ( txtTruckCode.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtTruckCode, Rubix.Screen.Common.GetMessage("I0021"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtTruckCode, String.Empty);
            }

            ////Truck Name
            if (txtTruckLongName.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtTruckLongName, Rubix.Screen.Common.GetMessage("I0022"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtTruckLongName, String.Empty);
            }
            return errFlag;
        }
        private bool checkGrid()
        {
            if (transportTypeControl.TransportTypeID == null)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0060"));
                return false;
            }
            if (gdvTransportType.RowCount > 0)///if have data
            {
                DataRow[] dr = ((DataTable)grdTransportType.DataSource).Select(String.Format("TransportTypeID = {0}", transportTypeControl.TransportTypeID));
                if (dr.Length > 0)
                {
                    return false;
                }
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("TruckCompanyID",typeof(int));
                dt.Columns.Add("TransportTypeID",typeof(int));
                dt.Columns.Add("TransportTypeCode",typeof(string));
                dt.Columns.Add("TransportTypeName",typeof(string));
                dt.Columns.Add("Width",typeof(decimal));
                dt.Columns.Add("Length", typeof(decimal));
                dt.Columns.Add("Height", typeof(decimal));
                dt.Columns.Add("Capacity", typeof(decimal));

                grdTransportType.DataSource = dt;
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
        }

        #endregion           

      
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;
using Rubix.Framework;
using CSI.Business.Admin;
using System.Xml;

namespace Rubix.Screen.Form.Admin.Dialog
{
    public partial class dlgADM060_UserWebMaintenance : DialogBase
    {
        #region "Member"
        private UserWebMaintenance db;
        #endregion

        #region "Properties"
        public Common.eScreenMode ScreenMode { get; set; }

        public string UserID { get; set; }

        public UserWebMaintenance BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new UserWebMaintenance();
                }
                return db;
            }
            set
            {
                db = value;
            }
        }
        #endregion

        #region "Constructor"
        public dlgADM060_UserWebMaintenance()
        {
            InitializeComponent();
        }
        #endregion

        #region "Overrides"
        public override bool OnCommandSave()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), txtUserID.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        dt = (gdvWarehouse.DataSource as DataView).Table.Copy();
                        dt.TableName = "UserMapping";
                        ds.Tables.Add(dt);
                        string xml = ds.GetXml();

                        if (this.ScreenMode == Common.eScreenMode.Add)
                        {
                            BusinessClass.AddUser(txtUserID.Text.Trim(), txtPassword.Text.Trim(), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim(), txtEmail.Text.Trim(), txtMobile.Text.Trim(), txtTel.Text.Trim(), (int)ownerControl.OwnerID, xml, AppConfig.UserLogin);
                        }
                        else
                        {
                            BusinessClass.EditUser(txtUserID.Text.Trim(), txtPassword.Text.Trim(), txtFirstName.Text.Trim(), txtLastName.Text.Trim(), txtAddress.Text.Trim(), txtEmail.Text.Trim(), txtMobile.Text.Trim(), txtTel.Text.Trim(), (int)ownerControl.OwnerID, xml, AppConfig.UserLogin);
                        }

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
            finally
            {
                ds.Clear();
                ds = null;
                dt.Clear();
                dt = null;
            }
        }

        public override bool OnCommandClear()
        {
            if (this.ScreenMode == Common.eScreenMode.Add)
            {
                ClearControl();
            }
            else
            {
                DataBinding();
            }
            return true;
        }
        #endregion

        #region "Event handler"
        private void dlgADM010_UserMaintenance_Load(object sender, EventArgs e)
        {
            errorProvider.ClearErrors();
            warehouseControl.OwnerID = Common.GetDefaultOwnerID();

            if (ScreenMode == Common.eScreenMode.View)
            {
                ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
                ControlUtil.EnableControl(false, this.Controls);             
                DataBinding();
            }
            else if (ScreenMode == Common.eScreenMode.Add)
            {
                ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);
                ControlUtil.EnableControl(true, this.Controls);    
                txtUserID.Focus();
                ClearControl();

                m_statusBarCreatedDate.Caption = DateTime.Now.ToString(Rubix.Screen.Common.FullDatetimeFormat);
                m_statusBarCreatedUser.Caption = AppConfig.UserLogin;
                m_statusBarUpdatedDate.Caption = "-";
                m_statusBarUpdatedUser.Caption = "-";
                InitialWarehouseGrid();
            }
            else
            {
                ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);
                ControlUtil.EnableControl(true, this.Controls);
                ControlUtil.EnableControl(false, txtUserID);
                txtPassword.Focus();
                DataBinding();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ownerControl.OwnerID == null)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0026"));
                    return;
                }
                if (warehouseControl.WarehouseID != null)
                {
                    DataTable dt = new DataTable();
                    dt = grdWarehouse.DataSource as DataTable;

                    DataRow[] drSelect = dt.Select(string.Format("WarehouseID = {0}", warehouseControl.WarehouseID));

                    if (drSelect.Length <= 0)
                    {
                        DataRow dr = dt.NewRow();
                        dr["WarehouseID"] = warehouseControl.WarehouseID;
                        dr["DCCode"] = warehouseControl.WarehouseCode;
                        dr["WarehouseName"] = warehouseControl.WarehouseName;

                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        //nothing
                    }

                    ControlUtil.EnableControl(false, ownerControl);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdvWarehouse.RowCount > 0)
                {
                    gdvWarehouse.DeleteSelectedRows();
                }

                if (gdvWarehouse.RowCount > 0)
                {
                    ControlUtil.EnableControl(false, ownerControl);
                }
                else
                {
                    ControlUtil.EnableControl(true, ownerControl);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void ownerControl_EditValueChanged(object sender, EventArgs e)
        {
            if (ownerControl.OwnerID != null)
            {
                grdWarehouse.DataSource = null;
                warehouseControl.OwnerID = ownerControl.OwnerID;
                warehouseControl.DataLoading();
            }
            else
            {
                grdWarehouse.DataSource = null;
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
            }
        }
        #endregion

        #region "Generic function"
        private void ClearControl()
        {
            if (this.ScreenMode != Common.eScreenMode.Edit)
            {
                txtUserID.Text = String.Empty;
            }

            txtPassword.Text = String.Empty;
            txtComfirmPassword.Text = string.Empty;
            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtMobile.Text = String.Empty;
            txtTel.Text = String.Empty;
            txtAddress.Text = String.Empty;
            warehouseControl.ClearData();
            grdWarehouse.DataSource = null;
            errorProvider.ClearErrors();
        }

        private void InitialWarehouseGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("WarehouseID", typeof(int));
            dt.Columns.Add("DCCode", typeof(string));
            dt.Columns.Add("WarehouseName", typeof(string));

            grdWarehouse.DataSource = dt;
        }

        private void DataBinding()
        {
            DataSet ds = BusinessClass.LoadUserWebInformation(this.UserID);

            if (ds.Tables.Count == 2)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtUserID.Text = ds.Tables[0].Rows[0]["UserID"].ToString();
                    txtPassword.Text = string.Empty;
                    txtComfirmPassword.Text = string.Empty;
                    txtFirstName.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    txtLastName.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                    txtTel.Text = ds.Tables[0].Rows[0]["Tel"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    ownerControl.OwnerID = Convert.ToInt32(ds.Tables[0].Rows[0]["OwnerID"]);
                    warehouseControl.OwnerID = Convert.ToInt32(ds.Tables[0].Rows[0]["OwnerID"]);
                    warehouseControl.DataLoading();

                    m_statusBarCreatedDate.Caption = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreateDate"]).ToString(Rubix.Screen.Common.FullDatetimeFormat);
                    m_statusBarCreatedUser.Caption = ds.Tables[0].Rows[0]["CreateUser"].ToString();

                    if (ds.Tables[0].Rows[0]["UpdateDate"].ToString() != string.Empty)
                    {
                        m_statusBarUpdatedDate.Caption = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdateDate"]).ToString(Rubix.Screen.Common.FullDatetimeFormat);
                    }
                    else
                    {
                        m_statusBarUpdatedDate.Caption = "-";
                    }
                    if (ds.Tables[0].Rows[0]["UpdateUser"].ToString() != string.Empty)
                    {
                        m_statusBarUpdatedUser.Caption = ds.Tables[0].Rows[0]["UpdateUser"].ToString();
                    }
                    else
                    {
                        m_statusBarUpdatedUser.Caption = "-";
                    }
                }

                grdWarehouse.DataSource = ds.Tables[1];
                if (gdvWarehouse.RowCount > 0)
                {
                    ControlUtil.EnableControl(false, ownerControl);
                }
            }
        }

        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            if (String.IsNullOrWhiteSpace(txtUserID.Text))
            {
                errorProvider.SetError(txtUserID, Rubix.Screen.Common.GetMessage("I0005"));
                errFlag = false;
            }
            else
            {
                if (BusinessClass.LoadUserWebInformation(txtUserID.Text).Tables[0].Rows.Count > 0 && this.ScreenMode == Common.eScreenMode.Add)
                {
                    errorProvider.SetError(txtUserID, Rubix.Screen.Common.GetMessage("I0141"));
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0141"));
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(txtUserID, string.Empty);
                }
            }

            if (String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, Rubix.Screen.Common.GetMessage("I0281"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtPassword, string.Empty);
            }

            if (!txtPassword.Text.Equals(txtComfirmPassword.Text) || String.IsNullOrWhiteSpace(txtComfirmPassword.Text))
            {
                errorProvider.SetError(txtComfirmPassword, Rubix.Screen.Common.GetMessage("I0140"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtComfirmPassword, string.Empty);
            }                       
            
            if (String.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorProvider.SetError(txtFirstName, Rubix.Screen.Common.GetMessage("I0006"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(txtFirstName, string.Empty);
            }

            if (gdvWarehouse.RowCount <= 0)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0045"));
                errFlag = false;
            }

            return errFlag;
        }
        #endregion
    }
}
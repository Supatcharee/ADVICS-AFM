using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSI.Business.Master;
using CSI.Business;
using Rubix.Framework;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Text.RegularExpressions;

namespace Rubix.Screen.Form.Master.Dialog
{
    public partial class dlgXMSS270_Customer : DialogBase,Rubix.Framework.IClearable
    {
        #region Member
        String strCustomerID = String.Empty;
        String strCustomerCode = String.Empty;
        private Customer db;
        private Common.eScreenMode eScrenMode;
        #endregion

        #region Enum
        public enum eColOwner
        {
            OwnerID,
            OwnerCode,
            OwnerName,
        }
        #endregion

        #region Properties
        public String OwnerID
        {
            get { return strCustomerID; }
            set { strCustomerID = value; }
        }
        public String CustomerCode
        {
            get { return strCustomerCode; }
            set { strCustomerCode = value; }
        }
        public Customer BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Customer();
                }
                return db;
            }
            set 
            {
                if (db == null)
                {
                    db = new Customer();
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
        public dlgXMSS270_Customer()
        {
            InitializeComponent();
            base.GridViewControl = new GridControl[] { grdCustomer };
        } 
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this,String.Format(Rubix.Screen.Common.GetMessage("I0047"),txtCustomerName.Text.Trim())) == DialogButton.Yes)
                {
                    if (ValidateData())
                    {
                        if (BusinessClass.CheckExistCustomerCode(BusinessClass.CustomerID, txtCustomerCode.Text.Trim()))
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0260"));
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
            ClearData();
            return base.OnCommandClear();
        }
        #endregion
        
        #region Event Handler Function
        private void dlgXMSS010_Customer_Load(object sender, EventArgs e)
        {
            try
            {
                if (ScreenMode == Common.eScreenMode.Add)
                {

                    m_statusBarCreatedDate.Caption = DateTime.Now.ToString(Common.FullDatetimeFormat);
                    m_statusBarCreatedUser.Caption = AppConfig.UserLogin;
                    m_statusBarUpdatedDate.Caption = "-";
                    m_statusBarUpdatedUser.Caption = "-";
                    ControlUtil.ClearControlData(this.Controls);
                    rdoDomestic.Checked = true;
                }
                else
                {
                    DataBinding();
                }

                if (ScreenMode == Common.eScreenMode.View)
                {
                    ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarSave);
                    ControlUtil.EnableControl(false, this.Controls);
                }
                else
                {
                    ControlUtil.HiddenControl(false, m_toolBarClear, m_toolBarSave);
                }

                
                DataBindingCustomer();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
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

            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColOwner.OwnerID], ownerControl.OwnerID);
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColOwner.OwnerCode], ownerControl.OwnerCode);
            view.SetRowCellValue(e.RowHandle, view.Columns[(int)eColOwner.OwnerName], ownerControl.OwnerName);

        }

        private void chkCalculateVat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCalculateVat.Checked)
            {
                reqCalculateVate.Visible = true;
                ControlUtil.EnableControl(true, txtCalculateVat);
            }
            else
            {
                reqCalculateVate.Visible = false;
                ControlUtil.EnableControl(false, txtCalculateVat);
                txtCalculateVat.EditValue = null;
            }
        }
        #endregion
        
        #region Generic Function
        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();
            if (txtCustomerCode.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtCustomerCode, Rubix.Screen.Common.GetMessage("I0256"));
                errFlag = false;
            }

            if (txtCustomerName.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtCustomerName, Rubix.Screen.Common.GetMessage("I0257"));
                errFlag = false;
            }

            if (txtPickingLeadTime.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtPickingLeadTime, Rubix.Screen.Common.GetMessage("I0413"));
                errFlag = false;
            }

            if (txtPackingLeadTime.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtPackingLeadTime, Rubix.Screen.Common.GetMessage("I0414"));
                errFlag = false;
            }

            if (txtTransportLeadTime.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtTransportLeadTime, Rubix.Screen.Common.GetMessage("I0415"));
                errFlag = false;
            }

            if (chkCalculateVat.Checked && txtCalculateVat.EditValue == null)
            {
                errorProvider.SetError(txtCalculateVat, Rubix.Screen.Common.GetMessage("I0357"));
                errFlag = false;
            }

            ////Email
            if (txtEmail.EditValue != null && !string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, String.Empty);
                foreach (string email in txtEmail.Text.Split(';'))
                {
                    if (string.IsNullOrWhiteSpace(email))
                        continue;
                    if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$"))
                    {
                        errFlag = false;
                        errorProvider.SetError(txtEmail, Common.GetMessage("I0267"));
                        break;
                    }
                }
            }

            if (txtCustomerPriority.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(txtCustomerPriority, Rubix.Screen.Common.GetMessage("I0427"));
                errFlag = false;
            }

            if (txtInsurance.EditValue == null)
            {
                errorProvider.SetError(txtInsurance, "Please Input Insurance.");
                errFlag = false;
            }

            if (txtFreight.EditValue == null)
            {
                errorProvider.SetError(txtFreight, "Please Input Freight.");
                errFlag = false;
            }

            if (string.IsNullOrWhiteSpace(txtAccountee.Text) && txtAccountee.EditValue == null)
            {
                errorProvider.SetError(txtAccountee, "Please Input Accountee.");
                errFlag = false;           
            }

            return errFlag;
        }

        private void DataBindingCustomer()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("OwnerID", typeof(int));
            dt.Columns.Add("OwnerCode", typeof(string));
            dt.Columns.Add("OwnerName", typeof(string));

            grdCustomer.DataSource = dt;

            DataSet ds = BusinessClass.DataLoadOwner();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdCustomer.DataSource = ds.Tables[0];
            }
         
            gdvCustomer.Columns[(int)eColOwner.OwnerID].Visible = false;
          
        }

        private void DataBinding()
        {
            txtCustomerCode.Text            = BusinessClass.CustomerCode;
            txtCustomerName.Text            = BusinessClass.CustomerName;
            txtBusinessType.Text            = BusinessClass.BusinessType;
            txtAddress.Text                 = BusinessClass.Address;
            txtAccountee.Text               = BusinessClass.Accountee;
            txtCity.Text                    = BusinessClass.City;
            txtProvince.Text                = BusinessClass.StateOrProvince;
            txtPostal.Text                  = BusinessClass.PostalCode;
            txtCountry.Text                 = BusinessClass.Country;
            txtMobile.Text                  = BusinessClass.MobileNo;
            txtPhone.Text                   = BusinessClass.PhoneNo;
            txtExtension.Text               = BusinessClass.Extension;
            txtFax.Text                     = BusinessClass.FaxNo;
            txtEmail.Text                   = BusinessClass.EmailAddress;
            txtContactName1.Text            = BusinessClass.ContactName1;
            txtContactName2.Text            = BusinessClass.ContactName2;
            txtContactName3.Text            = BusinessClass.ContactName3;
            chkCalculateVat.Checked         = BusinessClass.IsCalVat;
            txtCalculateVat.EditValue       = BusinessClass.Vat;
            txtPaymentTerm.Text             = BusinessClass.PaymentTerm;
            txtPickingLeadTime.EditValue    = BusinessClass.PickingLeadTime;
            txtPackingLeadTime.EditValue    = BusinessClass.PackingLeadTime;
            txtTransportLeadTime.EditValue  = BusinessClass.TransportLeadTime;
            txtRemark.Text                  = BusinessClass.Remark;
            txtCustomerPriority.EditValue = BusinessClass.Priority;
            txtInsurance.EditValue = BusinessClass.Insurance;
            txtFreight.EditValue = BusinessClass.Freight;

            if (BusinessClass.InvoiceType.Equals("Domestic"))
                rdoDomestic.Checked = true;
            else
                rdoExport.Checked = true;

            if (BusinessClass.IsSpecial == 1 )
            {
                ChkSpecialCaseMark.Checked = true;
            }
            else
            {
                ChkSpecialCaseMark.Checked = false;
            }

            txtCopyInvoice.EditValue                = BusinessClass.CopyInvoice;
            txtCopyPackList.EditValue               = BusinessClass.CopyPackList;
            txtCopyM3.EditValue                     = BusinessClass.CopyM3;
            txtCopyCerOriginal.EditValue            = BusinessClass.CopyCerOrigin;
            txtCopyBillLadingOrigin.EditValue       = BusinessClass.CopyBillLadingOrigin;
            txtCopyBillLading.EditValue             = BusinessClass.CopyBillLading;
            txtCopyPolicyOrigin.EditValue           = BusinessClass.CopyPolicyOrigin;
            txtCopyPolicy.EditValue                 = BusinessClass.CopyPolicy;
            txtCopyCustomInvoice.EditValue          = BusinessClass.CopyCustomInvoice;
            txtCopyCertificate.EditValue            = BusinessClass.CopyCertificate;
            txtBranch.Text                          = BusinessClass.Branch;
            txtTaxID.Text                           = BusinessClass.TaxID;
            
            ControlUtil.EnableControl(BusinessClass.IsCalVat, txtCalculateVat);

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

        private void SavaData()
        {
            BusinessClass.CustomerCode          = txtCustomerCode.Text.Trim();
            BusinessClass.CustomerName          = txtCustomerName.Text.Trim();
            BusinessClass.BusinessType          = txtBusinessType.Text.Trim();
            BusinessClass.Branch                = txtBranch.Text.Trim();
            BusinessClass.TaxID                 = txtTaxID.Text.Trim();
            BusinessClass.Address               = txtAddress.Text.Trim();
            BusinessClass.Accountee             = txtAccountee.Text.Trim();
            BusinessClass.City                  = txtCity.Text.Trim();
            BusinessClass.StateOrProvince       = txtProvince.Text.Trim();
            BusinessClass.PostalCode            = txtPostal.Text.Trim();
            BusinessClass.Country               = txtCountry.Text.Trim();
            BusinessClass.MobileNo              = txtMobile.Text.Trim();
            BusinessClass.PhoneNo               = txtPhone.Text.Trim();
            BusinessClass.Extension             = txtExtension.Text.Trim();
            BusinessClass.FaxNo                 = txtFax.Text.Trim();
            BusinessClass.EmailAddress          = txtEmail.Text.Trim();
            BusinessClass.ContactName1          = txtContactName1.Text.Trim();
            BusinessClass.ContactName2          = txtContactName2.Text.Trim();
            BusinessClass.ContactName3          = txtContactName3.Text.Trim();
            BusinessClass.CreateUser            = AppConfig.UserLogin;
            BusinessClass.IsCalVat              = chkCalculateVat.Checked;
            BusinessClass.Vat                   = DataUtil.Convert<decimal>(txtCalculateVat.EditValue);
            BusinessClass.PaymentTerm           = txtPaymentTerm.Text.Trim();
            BusinessClass.PickingLeadTime       = DataUtil.Convert<int>(txtPickingLeadTime.EditValue);
            BusinessClass.PackingLeadTime       = DataUtil.Convert<int>(txtPackingLeadTime.EditValue);
            BusinessClass.TransportLeadTime     = DataUtil.Convert<int>(txtTransportLeadTime.EditValue);
            BusinessClass.InvoiceType           = rdoDomestic.Checked ? "D" : "E";
            BusinessClass.Remark                = txtRemark.Text;
            BusinessClass.CopyInvoice           = DataUtil.Convert<int>(txtCopyInvoice.EditValue);
            BusinessClass.CopyPackList          = DataUtil.Convert<int>(txtCopyPackList.EditValue);
            BusinessClass.CopyM3                = DataUtil.Convert<int>(txtCopyM3.EditValue);
            BusinessClass.CopyCerOrigin         = DataUtil.Convert<int>(txtCopyCerOriginal.EditValue);
            BusinessClass.CopyBillLadingOrigin  = DataUtil.Convert<int>(txtCopyBillLadingOrigin.EditValue);
            BusinessClass.CopyBillLading        = DataUtil.Convert<int>(txtCopyBillLading.EditValue);
            BusinessClass.CopyPolicyOrigin      = DataUtil.Convert<int>(txtCopyPolicyOrigin.EditValue);
            BusinessClass.CopyPolicy            = DataUtil.Convert<int>(txtCopyPolicy.EditValue);
            BusinessClass.CopyCustomInvoice     = DataUtil.Convert<int>(txtCopyCustomInvoice.EditValue);
            BusinessClass.CopyCertificate       = DataUtil.Convert<int>(txtCopyCertificate.EditValue);
            BusinessClass.Priority              = Convert.ToInt32(txtCustomerPriority.EditValue);
            BusinessClass.Insurance             = DataUtil.Convert<decimal>(txtInsurance.EditValue);
            BusinessClass.Freight               = DataUtil.Convert<decimal>(txtFreight.EditValue);
            BusinessClass.IsSpecial             = (ChkSpecialCaseMark.Checked) ? 1 : 0;

            gdvCustomer.CloseEditor();
            gdvCustomer.UpdateCurrentRow();
         
            DataTable dtCustomer = (grdCustomer.DataSource as DataTable).Copy();
            
            DataSet dsCustomer = new DataSet("OwnerSet");
            
            dtCustomer.TableName = "OwnerTable";
          
            dsCustomer.Tables.Add(dtCustomer);
            BusinessClass.SaveCustomerData(dsCustomer.GetXml());

        }

        private bool checkGrid()
        {
            if (ownerControl.OwnerID == null)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0208"));
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
                ControlUtil.ClearControlData(txtCustomerCode
                                                , txtCustomerName
                                                , txtBusinessType
                                                , txtAddress
                                                , txtCity
                                                , txtProvince
                                                , txtPostal
                                                , txtCountry
                                                , txtMobile
                                                , txtMobile
                                                , txtPhone
                                                , txtExtension
                                                , txtFax
                                                , txtEmail
                                                , txtContactName1
                                                , txtContactName2
                                                , txtContactName3
                                                , txtInsurance
                                                , txtFreight
                                                , txtAccountee);
            }
            else
            {
                DataBinding();
            }
            DataBindingCustomer();
            ownerControl.ClearData();
        }
        #endregion

    }
}
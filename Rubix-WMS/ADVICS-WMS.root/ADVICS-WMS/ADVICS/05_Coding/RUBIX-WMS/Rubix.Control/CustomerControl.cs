using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSI.Business.Common;
using CSI.Business;
using CSI.Business.DataObjects;
using Rubix.Framework;
using System.Data.Objects;
using DevExpress.XtraEditors;

namespace Rubix.Control
{
    public partial class CustomerControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
         #region Member
        private Customer db;
        private int? iCDID = null;
        //add by Souwanee S. 11/04/2012
        private List<sp_common_LoadCustomer_Result> _list = null;
        private sp_common_LoadCustomer_Result col;
        private Boolean RequireFlag;
        private String errText;
        private int? ownerID;
        private bool updateDataSource = false;
        public event EventHandler EditValueChanged;
        public event EventHandler SetShippingCustomerIDChanged;
        #endregion

        #region Properties
        private Customer BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Customer();
                }
                return db;
            }
        }

        private List<sp_common_LoadCustomer_Result> Datasource
        {
            get
            {
                if (_list == null)
                    _list = BusinessClass.DataLoading(ShippingID,OwnerID).ToList<sp_common_LoadCustomer_Result>();
                return _list;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String CustomerCode
        {
            get
            {
                int val;
                if (cboCustomerCode.EditValue != null && Int32.TryParse(cboCustomerCode.EditValue.ToString(), out val))
                {
                    sp_common_LoadCustomer_Result data = Datasource.Where(d => d.CustomerID == val).SingleOrDefault();
                    if (data == null)
                        return string.Empty;
                    return data.CustomerCode;
                }
                else
                    return string.Empty;
            }
            set
            {
                cboCustomerCode.EditValue = value;
                col = Datasource.Where(d => d.CustomerCode == value).SingleOrDefault();
                if (col != null)
                {
                    cboCustomerCode.EditValue = col.CustomerID;
                    txtCustomerName.Text = col.CustomerName;

                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String CustomerName
        {
            get
            {
                int val;
                if (cboCustomerCode.EditValue != null && Int32.TryParse(cboCustomerCode.EditValue.ToString(), out val))
                {
                    sp_common_LoadCustomer_Result data = Datasource.Where(d => d.CustomerID == val).SingleOrDefault();
                    if (data == null)
                        return string.Empty;
                    return data.CustomerName;
                }
                else
                    return string.Empty;
            }
        }

        public Boolean RequireField
        {
            get
            {
                return RequireFlag;
            }
            set
            {
                RequireFlag = value;
            }
        }

        public int? OwnerID
        {
            get
            {
                return ownerID;
            }
            set
            {
                ownerID = value;
            }
        }

        public String ErrorText
        {
            get
            {
                if (string.IsNullOrEmpty(errText))
                {
                    return "Customer Control is Require Field";
                }
                else
                {
                    return errText;
                }
            }
            set
            {
                errText = value;
            }
        }
               
        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? CustomerID
        {
            get
            {
                return DataUtil.Convert<int>(cboCustomerCode.EditValue);
            }
            set
            {
                try
                {
                    if (cboCustomerCode.EditValue != null && cboCustomerCode.EditValue.Equals(value))
                        return;
                    col = Datasource.Where(d => d.CustomerID == value).SingleOrDefault();
                    if (col != null)
                    {
                        cboCustomerCode.EditValue = value;
                        txtCustomerName.Text = col.CustomerName;
                    }
                    else
                    {
                        this.ClearData();
                    }
                }
                finally
                {
                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? ShippingID
        {
            get { return iCDID; }
            set { iCDID = value; }
        }

        public bool EnableControl
        {
            set { ControlUtil.EnableControl(value, cboCustomerCode); }
        }

        public bool ReadOnly
        {
            get
            {
                return cboCustomerCode.Properties.ReadOnly;
            }
            set
            {
                cboCustomerCode.Properties.ReadOnly = value;
            }
        }

        [DefaultValue(false)]
        public bool IsShowAddNewButton
        {
            get
            {
                return cboCustomerCode.Properties.ShowAddNewButton;
            }
            set
            {
                cboCustomerCode.Properties.ShowAddNewButton = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DevExpress.XtraEditors.XtraForm AddNewForm { get; set; }
        #endregion

        #region Constructor
        public CustomerControl()
        {
            InitializeComponent();
            cboCustomerCode.AddNewValue += control_AddNewValue;
        } 
        #endregion
          
        #region Event Handler Function
         private void CustomerControl_Load(object sender, EventArgs e)
        {
            try
            {
                errorProvider.ClearErrors();
                DataLoading();
                ControlUtil.EnableControl(false, txtCustomerName);
            }
            catch (Exception ex)
            {
                
            }
        }

          private void cboCustomerCode_EditValueChanged(object sender, EventArgs e)
        {
            txtCustomerName.Text = (cboCustomerCode.Text.Trim() == String.Empty ? String.Empty : CustomerName);
            OnSetShippingCustomerIDChanged();
            if (!updateDataSource)
                OnEditValueChanged();
            //RequireField = false;
        }

          private void control_AddNewValue(object sender, DevExpress.XtraEditors.Controls.AddNewValueEventArgs e)
          {
              if (AddNewForm != null)
              {
                  if (AddNewForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                  {
                      DataLoading();
                  }
              }
          }
        #endregion

        #region Generic Function
        public void DataLoading()
        {
            try
            {
                if (!DesignMode)
                {
                    updateDataSource = true;
                    cboCustomerCode.Properties.DisplayMember = "CustomerCode";
                    cboCustomerCode.Properties.ValueMember = "CustomerID";
                    gdcCustomerCode.FieldName = "CustomerCode";
                    gdcCustomerName.FieldName = "CustomerName";

                    _list = BusinessClass.DataLoading(ShippingID, OwnerID).ToList<sp_common_LoadCustomer_Result>();
                    cboCustomerCode.Properties.DataSource = Datasource;
                    updateDataSource = false;
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public void ClearData()
        {
            cboCustomerCode.EditValue = null;
            txtCustomerName.Text = String.Empty;
            errorProvider.SetError(cboCustomerCode, string.Empty);
        }

        public bool ValidateControl()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();
            if (RequireField)
            {
                if (cboCustomerCode.EditValue == null)
                {
                    errorProvider.SetError(cboCustomerCode, ErrorText);
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(cboCustomerCode, string.Empty);
                }
            }
            return errFlag;
        }

        private void OnSetShippingCustomerIDChanged()
        {
            if (SetShippingCustomerIDChanged != null)
                SetShippingCustomerIDChanged(this, new EventArgs());
        }

        private void OnEditValueChanged()
        {
            if (EditValueChanged != null)
                EditValueChanged(this, new EventArgs());
        }
        #endregion
    }
}

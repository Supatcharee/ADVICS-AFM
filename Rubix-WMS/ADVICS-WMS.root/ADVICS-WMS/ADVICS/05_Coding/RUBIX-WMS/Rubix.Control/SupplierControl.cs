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
namespace Rubix.Control
{
    public partial class SupplierControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private Supplier  db;
        private int? iCustomerID = 0;
        private int? iDistrictID = 0;
        private Boolean RequireFlag;
        private String errText;
        private List<sp_common_LoadSupplier_Result> _list = null;
        private sp_common_LoadSupplier_Result LSR;
        public event EventHandler EditValueChanged;
        #endregion

        #region Properties
        private Supplier BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Supplier();
                }
                return db;
            }
        }

        private List<sp_common_LoadSupplier_Result> Datasource
        {
            get
            {
                if (_list == null)
                    _list = BusinessClass.DataLoading(OwnerID).ToList();
                return _list;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? OwnerID
        {
            get { return iCustomerID; }
            set { iCustomerID = value; }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? DistrictID
        {
            get { return iDistrictID; }
            set { iDistrictID = value; }
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

        public String ErrorText
        {
            get
            {
                if (string.IsNullOrEmpty(errText))
                {
                    return "Supplier is Require Field";
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

        public bool EnableControl
        {
            set { ControlUtil.EnableControl(value, cboSupplierCode); }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? SupplierID
        {
            set
            {
            	cboSupplierCode.EditValue = value;
            }
            get
            {
                return DataUtil.Convert<int>(cboSupplierCode.EditValue);
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String SupplierCode
        {
            get
            {
                int val;
                if (cboSupplierCode.EditValue != null && Int32.TryParse(cboSupplierCode.EditValue.ToString(), out val))
                {
                    sp_common_LoadSupplier_Result data = Datasource.Where(d => d.SupplierID == val).SingleOrDefault();
                    if (data != null)
                        return data.SupplierCode;
                    else
                        return string.Empty;
                }
                else
                    return string.Empty;
            }
            set
            {
                cboSupplierCode.EditValue = value;
                LSR = Datasource.Where(d => d.SupplierCode == value).SingleOrDefault();
                if (LSR != null)
                {
                    cboSupplierCode.EditValue = LSR.SupplierID;
                    txtSupplierName.Text = LSR.SupplierLongName;
                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String SupplierLongName
        {
            get
            {
                int val;
                if (cboSupplierCode.EditValue != null && Int32.TryParse(cboSupplierCode.EditValue.ToString(), out val))
                {
                    sp_common_LoadSupplier_Result data = Datasource.Where(d => d.SupplierID == val).SingleOrDefault();
                    if (data != null)
                        return data.SupplierLongName;
                    else
                        return string.Empty;
                }
                else
                    return string.Empty;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String SupplierAddress1
        {
            get
            {
                int val;
                if (cboSupplierCode.EditValue != null && Int32.TryParse(cboSupplierCode.EditValue.ToString(), out val))
                {
                    sp_common_LoadSupplier_Result data = Datasource.Where(d => d.SupplierID == val).SingleOrDefault();
                    if (data != null)
                        return data.SupplierAddress1;
                    else
                        return string.Empty;
                }
                else
                    return string.Empty;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String SupplierAddress2
        {
            get
            {
                int val;
                if (cboSupplierCode.EditValue != null && Int32.TryParse(cboSupplierCode.EditValue.ToString(), out val))
                {
                    sp_common_LoadSupplier_Result data = Datasource.Where(d => d.SupplierID == val).SingleOrDefault();
                    if (data != null)
                        return data.SupplierAddress2;
                    else
                        return string.Empty;
                }
                else
                    return string.Empty;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String PostalCode
        {
            get
            {
                int val;
                if (cboSupplierCode.EditValue != null && Int32.TryParse(cboSupplierCode.EditValue.ToString(), out val))
                {
                    sp_common_LoadSupplier_Result data = Datasource.Where(d => d.SupplierID == val).SingleOrDefault();
                    if (data != null)
                        return data.PostalCode;
                    else
                        return string.Empty;
                }
                else
                    return string.Empty;
            }
        }

        public bool ReadOnly
        {
            get
            {
                return cboSupplierCode.Properties.ReadOnly;
            }
            set
            {
                cboSupplierCode.Properties.ReadOnly = value;
            }
        }

        [DefaultValue(false)]
        public bool IsShowAddNewButton
        {
            get
            {
                return cboSupplierCode.Properties.ShowAddNewButton;
            }
            set
            {
                cboSupplierCode.Properties.ShowAddNewButton = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DevExpress.XtraEditors.XtraForm AddNewForm { get; set; }
        #endregion
        
        #region Constructor
        public SupplierControl()
        {
            InitializeComponent();
            cboSupplierCode.AddNewValue += control_AddNewValue;
        }
        #endregion

        #region Event Handler Function
        private void cboSupplierCode_EditValueChanged(object sender, EventArgs e)
        {
            txtSupplierName.Text = SupplierLongName;
            OnEditValueChanged();
        }

        private void SupplierControl_Load(object sender, EventArgs e)
        {
            try
            {
                DataLoading();
                ControlUtil.EnableControl(false, txtSupplierName);
                RequireField = false;
            }
            catch (Exception ex)
            {
                
            }
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
                    cboSupplierCode.Properties.DisplayMember = "SupplierCode";
                    cboSupplierCode.Properties.ValueMember = "SupplierID";
                    gdcSupplierCode.FieldName = "SupplierCode";
                    gdcSupplierShortName.FieldName = "SupplierLongName";
                    _list = BusinessClass.DataLoading(OwnerID).ToList();
                    cboSupplierCode.Properties.DataSource = this.Datasource;
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public void ClearData()
        {
            cboSupplierCode.EditValue = null;
            txtSupplierName.Text = String.Empty;
            errorProvider.SetError(cboSupplierCode, string.Empty);
        }
        public bool ValidateControl()
        {
            errorProvider.ClearErrors();
            Boolean errFlag = true;
            if (RequireField)
            {
                if (cboSupplierCode.EditValue == null)
                {
                    errorProvider.SetError(cboSupplierCode, ErrorText);
                    errFlag = false;
                }
            }
            return errFlag;
        }
        private void OnEditValueChanged()
        {
            if (EditValueChanged != null)
                EditValueChanged(this, new EventArgs());
        }
        #endregion             
    }
}

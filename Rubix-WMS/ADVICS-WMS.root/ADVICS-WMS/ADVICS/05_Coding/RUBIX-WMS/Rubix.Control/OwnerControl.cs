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
using DevExpress.XtraEditors.Controls;

namespace Rubix.Control
{
    public partial class OwnerControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private Owner db;
        private int? iWarehouseID = null;
        //add by Souwanee S. 11/04/2012
        private List<sp_common_LoadOwner_Result> _list = null;
        private sp_common_LoadOwner_Result col;
        private Boolean RequireFlag;
        private String errText;
        private bool updateDataSource = false;
        public event EventHandler SetCustomerIDChanged;
        public event EventHandler EditValueChanged;
        #endregion

        #region Properties
        private Owner BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Owner();
                }
                return db;
            }
        }

        public bool IsLoginScreen { get; set; }

        private List<sp_common_LoadOwner_Result> Datasource
        {
            get
            {
                if (_list == null)
                    _list = BusinessClass.DataLoading(WarehouseID).ToList<sp_common_LoadOwner_Result>();
                return _list;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String OwnerCode
        {
            get
            {
                int val;
                try
                {
                    if (cboOwnerCode.EditValue != null && Int32.TryParse(cboOwnerCode.EditValue.ToString(), out val))
                    {
                        sp_common_LoadOwner_Result data = Datasource.Where(d => d.OwnerID == val).SingleOrDefault();
                        if (data == null)
                            return string.Empty;
                        return data.OwnerCode;
                    }
                    else
                        return string.Empty;
                }
                catch (Exception ex)
                {                    
                    throw ex;
                }
            }
            set
            {
                //cboOwnerCode.EditValue = value;
                col = Datasource.Where(d => d.OwnerCode == value).SingleOrDefault();
                if (col != null)
                {
                    cboOwnerCode.EditValue = col.OwnerID;
                    txtOwnerName.Text = col.OwnerName;

                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String OwnerName
        {
            get
            {
                int val;
                if (cboOwnerCode.EditValue != null && Int32.TryParse(cboOwnerCode.EditValue.ToString(), out val))
                {
                    sp_common_LoadOwner_Result data = Datasource.Where(d => d.OwnerID == val).SingleOrDefault();
                    if (data == null)
                        return string.Empty;
                    return data.OwnerName;
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

        public String ErrorText
        {
            get
            {
                if (string.IsNullOrEmpty(errText))
                {
                    return "Owner Control is Require Field";
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
        public int? OwnerID
        {
            get
            {
                if (cboOwnerCode.EditValue == null || cboOwnerCode.EditValue.ToString() == string.Empty)
                    return null;
                else
                    return DataUtil.Convert<int>(cboOwnerCode.EditValue);
            }
            set
            {
                try
                {
                    //if (cboOwnerCode.EditValue != null && cboOwnerCode.EditValue.Equals(value))
                    //    return;
                    col = Datasource.Where(d => d.OwnerID == value).SingleOrDefault();
                    if (col != null)
                    {
                        cboOwnerCode.EditValue = value;
                        txtOwnerName.Text = col.OwnerName;
                    }
                    else
                    {
                        cboOwnerCode.EditValue = null;
                        txtOwnerName.Text = String.Empty;
                    }
                }
                finally
                {
                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? WarehouseID
        {
            get { return iWarehouseID; }
            set { iWarehouseID = value; }
        }

        public bool EnableControl
        {
            set { ControlUtil.EnableControl(value, cboOwnerCode); }
        }

        public bool ReadOnly
        {
            get
            {
                return cboOwnerCode.Properties.ReadOnly;
            }
            set
            {
                cboOwnerCode.Properties.ReadOnly = value;
            }
        }

        public bool IsForEdit { get; set; }

        [DefaultValue(false)]
        public bool IsShowAddNewButton
        {
            get
            {
                return cboOwnerCode.Properties.ShowAddNewButton;
            }
            set
            {
                cboOwnerCode.Properties.ShowAddNewButton = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DevExpress.XtraEditors.XtraForm AddNewForm { get; set; }


        #endregion

        #region Constructor
        public OwnerControl()
        {
            InitializeComponent();
            IsLoginScreen = false;
            cboOwnerCode.AddNewValue += control_AddNewValue;
            
        }

        private void OnSetCustomerIDChanged()
        {
            if (SetCustomerIDChanged != null)
                SetCustomerIDChanged(this, new EventArgs());
        }

        private void OnEditValueChanged()
        {
            if (EditValueChanged != null)
                EditValueChanged(this, new EventArgs());
        }
        #endregion

        #region Event Handler Function
        private void OwnerControl_Load(object sender, EventArgs e)
        {
            try
            {
                errorProvider.ClearErrors();
                DataLoading();
                ControlUtil.EnableControl(false, txtOwnerName);
            }
            catch (Exception ex)
            {

            }
        }

        private void cboOwnerCode_EditValueChanged(object sender, EventArgs e)
        {
            txtOwnerName.Text = (cboOwnerCode.Text.Trim() == String.Empty ? String.Empty : OwnerName);
            OnSetCustomerIDChanged();
            errorProvider.ClearErrors();
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
            if (!DesignMode)
            {
                try
                {
                    updateDataSource = true;
                    cboOwnerCode.Properties.DisplayMember = "OwnerCode";
                    cboOwnerCode.Properties.ValueMember = "OwnerID";
                    gdcOwnerCode.FieldName = "OwnerCode";
                    gdcOwnerName.FieldName = "OwnerName";
                    _list = BusinessClass.DataLoading(WarehouseID).ToList<sp_common_LoadOwner_Result>();
                    cboOwnerCode.Properties.DataSource = Datasource;
                    updateDataSource = false;
                    ClearData();
                }
                catch (Exception ex)
                {
                    //if (!IsLoginScreen)
                    //    throw ex;
                }
            }
        }

        public void ClearData()
        {
            if (AppConfig.DefaultOwnerID == null)
            {
                cboOwnerCode.EditValue = null;
                txtOwnerName.Text = String.Empty;
            }
            else
            {
                this.OwnerID = AppConfig.DefaultOwnerID;
                if (!IsForEdit)
                {
                   // ControlUtil.EnableControl(false, cboOwnerCode);
                    cboOwnerCode.Tag = "no control";
                }
            }
            errorProvider.SetError(cboOwnerCode, string.Empty);
        }

        public bool ValidateControl()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();
            if (RequireField)
            {
                if (cboOwnerCode.EditValue == null)
                {
                    errorProvider.SetError(cboOwnerCode, ErrorText);
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(cboOwnerCode, string.Empty);
                }
            }
            return errFlag;
        }
        #endregion
    }
}

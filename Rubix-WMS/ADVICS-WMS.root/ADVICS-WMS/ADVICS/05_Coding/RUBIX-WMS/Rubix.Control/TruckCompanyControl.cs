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
    public partial class TruckCompanyControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private TruckCompany  db;
        private Boolean RequireFlag;
        private String errText;
        private List<sp_common_LoadTruckCompany_Result> _list = null;
        public event EventHandler EditValueChanged;
        #endregion

        #region Properties
        private TruckCompany BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new TruckCompany();
                }
                return db;
            }
        }

        private List<sp_common_LoadTruckCompany_Result> Datasource
        {
            get
            {
                if (_list == null)
                    _list = BusinessClass.DataLoading().ToList();
                return _list;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String TruckCompanyCode
        {
            get
            {
                int val;
                if (cboTruckCompany.EditValue != null && Int32.TryParse(cboTruckCompany.EditValue.ToString(), out val))
                {
                    sp_common_LoadTruckCompany_Result data = Datasource.Where(d => d.TruckCompanyID == val).SingleOrDefault();
                    return data.TruckCompanyCode;
                }
                else
                    return string.Empty;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String TruckCompanyLongName
        {
            get
            {
                int val;
                if (cboTruckCompany.EditValue != null && Int32.TryParse(cboTruckCompany.EditValue.ToString(), out val))
                {
                    sp_common_LoadTruckCompany_Result data = Datasource.Where(d => d.TruckCompanyID == val).SingleOrDefault();
                    return data.TruckCompanyLongName;
                }
                else
                    return string.Empty;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? TruckCompanyID
        {
            get
            {
                return DataUtil.Convert<int>(cboTruckCompany.EditValue);
            }
            set
            {
                if (cboTruckCompany.EditValue != null && cboTruckCompany.EditValue.Equals(value))
                    return;
                sp_common_LoadTruckCompany_Result col = Datasource.Where(d => d.TruckCompanyID == value).SingleOrDefault();
                if (col != null)
                {
                    cboTruckCompany.EditValue = value;
                    txtTruckCompanyName.Text = col.TruckCompanyLongName;
                }
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
                    return "Truck Company Control is Require Field";
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
            set { ControlUtil.EnableControl(value, cboTruckCompany); }
        }

        [DefaultValue(false)]
        public bool IsShowAddNewButton
        {
            get
            {
                return cboTruckCompany.Properties.ShowAddNewButton;
            }
            set
            {
                cboTruckCompany.Properties.ShowAddNewButton = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DevExpress.XtraEditors.XtraForm AddNewForm { get; set; }
        #endregion
        
        #region Constructor
        public TruckCompanyControl()
        {
            InitializeComponent();
            cboTruckCompany.AddNewValue += control_AddNewValue;
        }
        #endregion

        #region Event Handler Function
        private void TruckCompanyControl_Load(object sender, EventArgs e)
        {
            try
            {
                ControlUtil.EnableControl(false, txtTruckCompanyName);
                DataLoading();
                RequireField = false;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void cboTruckCompany_EditValueChanged(object sender, EventArgs e)
        {
            txtTruckCompanyName.Text = (cboTruckCompany.Text.Trim() == String.Empty ? String.Empty : TruckCompanyLongName);
            OnEditValueChanged();
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
        private void DataLoading()
        {
            try
            {
                if (!DesignMode)
                {
                    cboTruckCompany.Properties.DisplayMember = "TruckCompanyCode";
                    cboTruckCompany.Properties.ValueMember = "TruckCompanyID";
                    gdcTruckCompanyCode.FieldName = "TruckCompanyCode";
                    gdcTruckCompanyShortName.FieldName = "TruckCompanyLongName";
                    _list = BusinessClass.DataLoading().ToList();
                    cboTruckCompany.Properties.DataSource = Datasource;
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public void ClearData()
        {
            cboTruckCompany.EditValue = null;
            txtTruckCompanyName.Text = String.Empty;
            errorProvider.SetError(cboTruckCompany, string.Empty);
        }
        public bool ValidateControl()
        {
            Boolean errFlag = true;
            if (RequireField)
            {
                if (cboTruckCompany.EditValue == null)
                {
                    errorProvider.SetError(cboTruckCompany, ErrorText);
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(cboTruckCompany, string.Empty);
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSI.Business.Common;
using CSI.Business.DataObjects;
using CSI.Business;
using Rubix.Framework;
namespace Rubix.Control
{
    public partial class TransportTypeControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private TransportType  db;
        private Boolean RequireFlag;
        private String errText;
        private List<sp_common_LoadTransportType_Result> _list = null;
        public event EventHandler EditValueChanged;
        #endregion

        #region Properties
        private TransportType BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new TransportType();
                }
                return db;
            }
        }

        private List<sp_common_LoadTransportType_Result> Datasource
        {
            get
            {
                if (_list == null)
                    _list = BusinessClass.DataLoading(TruckCompanyID).ToList();
                return _list;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String TransportTypeCode
        {
            get
            {
                int val;
                if (cboTransportType.EditValue != null && Int32.TryParse(cboTransportType.EditValue.ToString(), out val))
                {
                    sp_common_LoadTransportType_Result data = Datasource.Where(d => d.TransportTypeID == val).SingleOrDefault();
                    return data.TransportTypeCode;
                }
                else
                    return string.Empty;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String TransportTypeName
        {
            get
            {
                int val;
                if (cboTransportType.EditValue != null && Int32.TryParse(cboTransportType.EditValue.ToString(), out val))
                {
                    sp_common_LoadTransportType_Result data = Datasource.Where(d => d.TransportTypeID == val).SingleOrDefault();
                    return data.TransportTypeName;
                }
                else
                    return string.Empty;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? TransportTypeID
        {
            get
            {
                return DataUtil.Convert<int>(cboTransportType.EditValue);
            }
            set
            {
                if (cboTransportType.EditValue != null && cboTransportType.EditValue.Equals(value))
                    return;
                sp_common_LoadTransportType_Result col = Datasource.Where(d => d.TransportTypeID == value).SingleOrDefault();
                if (col != null)
                {
                    cboTransportType.EditValue = value;
                    txtTransportTypeName.Text = col.TransportTypeName;
                }
            }
        }  

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? TruckCompanyID
        {
            get;
            set;
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
                    return "Transport Type Control is Require Field";
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
            set { ControlUtil.EnableControl(value, cboTransportType); }
        }

        [DefaultValue(false)]
        public bool IsShowAddNewButton
        {
            get
            {
                return cboTransportType.Properties.ShowAddNewButton;
            }
            set
            {
                cboTransportType.Properties.ShowAddNewButton = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DevExpress.XtraEditors.XtraForm AddNewForm { get; set; }
        #endregion
        
        #region Constructor
        public TransportTypeControl()
        {
            InitializeComponent();
            cboTransportType.AddNewValue += control_AddNewValue;
        }
        #endregion

        #region Event Handler Function
        private void TransportTypeControl_Load(object sender, EventArgs e)
        {
            try
            {
                ControlUtil.EnableControl(false, txtTransportTypeName);
                DataLoading();
                RequireField = false;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void cboTransportType_EditValueChanged(object sender, EventArgs e)
        {
            txtTransportTypeName.Text = (cboTransportType.Text.Trim() == String.Empty ? String.Empty : TransportTypeName);
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
        public void DataLoading()
        {
            try
            {
                if (!DesignMode)
                {
                    cboTransportType.Properties.DisplayMember = "TransportTypeCode";
                    cboTransportType.Properties.ValueMember = "TransportTypeID";
                    gdcTransportTypeCode.FieldName = "TransportTypeCode";
                    gdcTransportTypeName.FieldName = "TransportTypeName";
                    _list = BusinessClass.DataLoading(TruckCompanyID).ToList();
                    cboTransportType.Properties.DataSource = Datasource;
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public void ClearData()
        {
            cboTransportType.EditValue = null;
            txtTransportTypeName.Text = String.Empty;
            errorProvider.SetError(cboTransportType, string.Empty);
        }
        public bool ValidateControl()
        {
            Boolean errFlag = true;
            if (RequireField)
            {
                if (cboTransportType.EditValue == null)
                {
                    errorProvider.SetError(cboTransportType, ErrorText);
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(cboTransportType, string.Empty);
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

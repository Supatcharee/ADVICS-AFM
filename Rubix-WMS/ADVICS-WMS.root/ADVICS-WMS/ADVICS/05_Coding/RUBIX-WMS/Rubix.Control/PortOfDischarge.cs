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
    public partial class PortOfDischarge : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private PortInformation  db;
        private Boolean RequireFlag;
        private String errText;
        private List<sp_common_LoadPortOfDischarge_Result> _list = null;
        private sp_common_LoadPortOfDischarge_Result col;
        public event EventHandler EditValueChanged;
        #endregion

        #region Properties
        private PortInformation BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new PortInformation();
                }
                return db;
            }
        }

        private List<sp_common_LoadPortOfDischarge_Result> Datasource
        {
            get
            {
                if (_list == null)
                    _list = BusinessClass.LoadPortOfDischarge().ToList<sp_common_LoadPortOfDischarge_Result>();
                return _list;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? GetPortID
        {
            get
            {
                try
                {
                    return DataUtil.Convert<int>(cboPort.EditValue);
                }
                catch (Exception)
                {                    
                    return null;
                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String GetPortCode
        {
            get
            {
                int val;
                if (cboPort.EditValue != null && Int32.TryParse(cboPort.EditValue.ToString(), out val))
                {
                    sp_common_LoadPortOfDischarge_Result data = Datasource.Where(d => d.PortID == val).SingleOrDefault();
                    if (data == null)
                        return string.Empty;
                    return data.PortCode;
                }
                else
                    return string.Empty;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String GetPortName
        {
            get
            {
                int val;
                if (cboPort.EditValue != null && Int32.TryParse(cboPort.EditValue.ToString(), out val))
                {
                    sp_common_LoadPortOfDischarge_Result data = Datasource.Where(d => d.PortID == val).SingleOrDefault();
                    if (data == null)
                        return string.Empty;
                    return data.PortLongName;
                }
                else
                    return string.Empty;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String GetPortAddress
        {
            get
            {
                int val;
                if (cboPort.EditValue != null && Int32.TryParse(cboPort.EditValue.ToString(), out val))
                {
                    sp_common_LoadPortOfDischarge_Result data = Datasource.Where(d => d.PortID == val).SingleOrDefault();
                    if (data == null)
                        return string.Empty;
                    return data.PortAddress;
                }
                else
                    return string.Empty;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String SetPortCode
        {
            set
            {
                cboPort.EditValue = value;
                col = Datasource.Where(d => d.PortCode == value).SingleOrDefault();
                if (col != null)
                {
                    cboPort.EditValue = col.PortID;
                    txtPortName.Text = col.PortLongName;

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
                    return "Port of Discharge Control is Require Field";
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
            set { ControlUtil.EnableControl(value, cboPort); }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? PortID
        {
            get
            {
                return DataUtil.Convert<int>(cboPort.EditValue);
            }
            set
            {
                col = Datasource.Where(d => d.PortID == value).FirstOrDefault();
                if (col != null)
                {
                    cboPort.EditValue = value;
                    txtPortName.Text = col.PortLongName;
                }
            }
        }

        [DefaultValue(false)]
        public bool IsShowAddNewButton
        {
            get
            {
                return cboPort.Properties.ShowAddNewButton;
            }
            set
            {
                cboPort.Properties.ShowAddNewButton = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DevExpress.XtraEditors.XtraForm AddNewForm { get; set; }
        #endregion
        
        #region Constructor
        public PortOfDischarge()
        {
            InitializeComponent();
            cboPort.AddNewValue += control_AddNewValue;
        }
        #endregion

        #region Event Handler Function
        private void PortOfDischarge_Load(object sender, EventArgs e)
        {
            try
            {
                DataLoading();
                ControlUtil.EnableControl(false, txtPortName);
            }
            catch (Exception ex)
            {
                
            }
        }

        private void cboPort_EditValueChanged(object sender, EventArgs e)
        {
            txtPortName.Text = (cboPort.Text.Trim() == String.Empty ? String.Empty : GetPortName);
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
        private void DataLoading()
        {
            try
            {
                if (!DesignMode)
                {
                    cboPort.Properties.ValueMember = "PortID";
                    cboPort.Properties.DisplayMember = "PortCode";
                    gdcPortCode.FieldName = "PortCode";
                    gdcPortName.FieldName = "PortLongName";
                    cboPort.Properties.DataSource = BusinessClass.LoadPortOfDischarge();
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public void ClearData()
        {
            //DataLoading();
            cboPort.EditValue = null;
            txtPortName.Text = String.Empty;
            errorProvider.SetError(cboPort, string.Empty);
        }
        public bool ValidateControl()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();
            if (RequireField)
            {
                if (cboPort.EditValue == null)
                {
                    errorProvider.SetError(cboPort, ErrorText);
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

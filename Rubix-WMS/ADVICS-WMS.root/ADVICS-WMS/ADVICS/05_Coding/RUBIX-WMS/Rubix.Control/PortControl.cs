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
    public partial class PortControl : DevExpress.XtraEditors.XtraUserControl
    {        
        #region Member
        private PortInformation  db;
        private Boolean RequireFlag;
        private String errText;
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

        public int? GetPortID
        {
            get
            {
                try
                {
                    if (cboPort.Text.Trim() == String.Empty)
                        return null;

                    return ((sp_common_LoadPort_Result)(GridSearch.GetFocusedRow())).PortID;
                }
                catch (Exception)
                {                    
                    return null;
                }
            }
        }

        public String GetPortCode
        {
            get
            {
                try
                {
                    if (cboPort.Text.Trim() == String.Empty)
                        return null;

                    return ((sp_common_LoadPort_Result)(GridSearch.GetFocusedRow())).PortCode;
                }
                catch (Exception)
                {                    
                    return null;
                }
            }
        }

        public String GetPortName
        {
            get
            {
                try
                {
                    if (cboPort.Text.Trim() == String.Empty)
                        return null;

                    return ((sp_common_LoadPort_Result)(GridSearch.GetFocusedRow())).PortLongName;
                }
                catch (Exception)
                {
                    
                    return null;
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
                    return "Port Control is Require Field";
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
        public PortControl()
        {
            InitializeComponent();
            cboPort.AddNewValue += control_AddNewValue;
        }
        #endregion

        #region Event Handler Function
        private void PortControl_Load(object sender, EventArgs e)
        {
            try
            {
                DataLoading();
                ControlUtil.EnableControl(false, txtPortName);
                RequireField = false;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void cboPort_EditValueChanged(object sender, EventArgs e)
        {
            txtPortName.Text = (cboPort.Text.Trim() == String.Empty ? String.Empty : GetPortName);
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
                    cboPort.Properties.DisplayMember = "PortCode";
                    gdcPortCode.FieldName = "PortCode";
                    gdcPortName.FieldName = "PortShortName";
                    cboPort.Properties.DataSource = BusinessClass.LoadPort();
                    txtPortName.Text = String.Empty;
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public void ClearData()
        {
            DataLoading();
            cboPort.EditValue = -1;
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
        #endregion              
    }
}

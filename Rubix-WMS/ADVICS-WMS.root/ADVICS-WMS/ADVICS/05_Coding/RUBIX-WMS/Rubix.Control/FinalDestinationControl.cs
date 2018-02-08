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
    public partial class FinalDestinationControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private FinalDestination  db;
        private int? iCusID = null;
        private Boolean RequireFlag;
        private String errText;
        private List<sp_common_LoadFinalDestination_Result> _list = null;
        private sp_common_LoadFinalDestination_Result col;
        #endregion

        #region Properties
        private FinalDestination BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new FinalDestination();
                }
                return db;
            }
        }

        private List<sp_common_LoadFinalDestination_Result> Datasource
        {
            get
            {
                if (_list == null)
                    _list = BusinessClass.DataLoading(this.OwnerID, this.CustomerID).ToList<sp_common_LoadFinalDestination_Result>();
                return _list;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? GetFinalDestinationID
        {
            get
            {
                try
                {
                    return DataUtil.Convert<int>(cboFinalDestination.EditValue); 
                }
                catch (Exception)
                {                   
                    return null;
                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String GetFinalDestinationCode
        {
            get
            {
                try
                {
                    if (cboFinalDestination.Text.Trim() == String.Empty)
                        return null;

                    return ((sp_common_LoadFinalDestination_Result)(GridSearch.GetFocusedRow())).FinalDestinationCode;
                }
                catch (Exception)
                {                    
                    return null;
                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String GetFinalDestinationShortName
        {
            get
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(cboFinalDestination.Text.Trim()))
                        return null;
                    if (GridSearch.GetFocusedRow() == null)
                        return null;
                    else
                        return ((sp_common_LoadFinalDestination_Result)(GridSearch.GetFocusedRow())).FinalDestinationLongName;
                }
                catch (Exception)
                {                    
                    return null;
                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String GetFinalDestinationLongName
        {
            get
            {
                try
                {
                    if (cboFinalDestination.Text.Trim() == String.Empty)
                        return null;

                    return ((sp_common_LoadFinalDestination_Result)(GridSearch.GetFocusedRow())).FinalDestinationLongName;
                }
                catch (Exception)
                {                    
                    return null;
                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String GetFinalDestinationAddress
        {
            get
            {
                try
                {
                    if (cboFinalDestination.Text.Trim() == String.Empty)
                        return null;

                    return ((sp_common_LoadFinalDestination_Result)(GridSearch.GetFocusedRow())).FinalDestinationAddress;
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
                    return "Final Destionation Control is Require Field";
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
        public int? CustomerID{get; set;}

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? OwnerID { get; set; }

        public bool EnableControl
        {
            set { ControlUtil.EnableControl(value, cboFinalDestination); }
        }
        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public int? FinalDestinationID
        {
            get
            {
                return DataUtil.Convert<int>(cboFinalDestination.EditValue);
            }
            set
            {
                col = Datasource.Where(d => d.FinalDestinationID == value).FirstOrDefault();
                if (col != null)
                {
                    cboFinalDestination.EditValue = value;
                    txtFinalDestinationName.Text = col.FinalDestinationLongName;
                }
            }
        }

        public bool ReadOnly
        {
            get
            {
                return cboFinalDestination.Properties.ReadOnly;
            }
            set
            {
                cboFinalDestination.Properties.ReadOnly = value;
            }
        }

        [DefaultValue(false)]
        public bool IsShowAddNewButton
        {
            get
            {
                return cboFinalDestination.Properties.ShowAddNewButton;
            }
            set
            {
                cboFinalDestination.Properties.ShowAddNewButton = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DevExpress.XtraEditors.XtraForm AddNewForm { get; set; }
        #endregion
        
        #region Constructor
        public FinalDestinationControl()
        {
            InitializeComponent();
            cboFinalDestination.AddNewValue += control_AddNewValue;
        }
        #endregion

        #region Event Handler Function
        private void FinalDestinationControl_Load(object sender, EventArgs e)
        {
            try
            {
                DataLoading();
                ControlUtil.EnableControl(false, txtFinalDestinationName);
            }
            catch (Exception ex)
            {

            }
        }

        private void cboFinalDestination_EditValueChanged(object sender, EventArgs e)
        {
            txtFinalDestinationName.Text = (cboFinalDestination.Text.Trim() == String.Empty ? String.Empty : GetFinalDestinationShortName);
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
                    cboFinalDestination.Properties.ValueMember = "FinalDestinationID";
                    cboFinalDestination.Properties.DisplayMember = "FinalDestinationCode";
                    gdcFinalDestinationCode.FieldName = "FinalDestinationCode";
                    gdcFinalDestinationShortName.FieldName = "FinalDestinationLongName";
                    cboFinalDestination.Properties.DataSource = BusinessClass.DataLoading(this.OwnerID, this.CustomerID);
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public void ClearData()
        {
            cboFinalDestination.EditValue = null;
            txtFinalDestinationName.Text = String.Empty;
            errorProvider.SetError(cboFinalDestination, string.Empty);
        }
        public bool ValidateControl()
        {
            //Boolean errFlag = true;
            //if (RequireField)
            //{
            //    if (cboFinalDestination.EditValue == null)
            //    {
            //        errorProvider.SetError(cboFinalDestination, ErrorText);
            //        errFlag = false;
            //    }
            //}
            //return errFlag;
            Boolean errFlag = true;
            errorProvider.ClearErrors();
            if (RequireField)
            {
                if (cboFinalDestination.EditValue == null)
                {
                    errorProvider.SetError(cboFinalDestination, ErrorText);
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(cboFinalDestination, string.Empty);
                }
            }
            return errFlag;
        }
        
        public event EventHandler EditValueChanged;
        private void OnEditValueChanged()
        {
            if (EditValueChanged != null)
                EditValueChanged(this, new EventArgs());
        }
        #endregion
    }
}

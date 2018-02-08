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
    public partial class ShippingAreaControl : DevExpress.XtraEditors.XtraUserControl
    {
        #region Member
        private ShipmentArea db;
        private List<sp_common_LoadShipmentArea_Result> _list = null;
        private sp_common_LoadShipmentArea_Result col;
        private Boolean RequireFlag;
        private String errText;
        #endregion

        #region Properties
        private ShipmentArea BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ShipmentArea();
                }
                return db;
            }
        }

        private List<sp_common_LoadShipmentArea_Result> Datasource
        {
            get
            {
                if (_list == null)
                    _list = BusinessClass.DataLoading(WarehouseID).ToList<sp_common_LoadShipmentArea_Result>();
                return _list;
            }
        }

        [System.ComponentModel.Bindable(true), System.ComponentModel.Browsable(false), DefaultValue(null)]
        public String GetShippingAreaName
        {
            get
            {
                try
                {
                    if (cboShippingAreaCode.Text.Trim() == String.Empty)
                        return null;

                    if (GridSearch.RowCount == 0)
                    {
                        return txtShippingAreaName.Text.Trim();
                    }
                    else
                    {
                        return ((sp_common_LoadShipmentArea_Result)(GridSearch.GetFocusedRow())).ShippingAreaName;
                    }
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
                    return "Shipping Area Control is Require Field";
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

        [System.ComponentModel.Bindable(true), System.ComponentModel.Browsable(false), DefaultValue(null)]
        public int? ShippingAreaID
        {
            get
            {
                return DataUtil.Convert<int>(cboShippingAreaCode.EditValue);
            }
            set
            {
                try
                {
                    col = Datasource.Where(d => d.ShippingAreaID == value).FirstOrDefault();
                    if (col != null)
                    {
                        cboShippingAreaCode.EditValue = value;
                        txtShippingAreaName.Text = col.ShippingAreaName;
                    }
                }
                finally
                {
                }
            }
        }
       
        public bool EnableControl
        {
            set { ControlUtil.EnableControl(value, cboShippingAreaCode); }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? WarehouseID{get; set;}

        public bool ReadOnly
        {
            get
            {
                return cboShippingAreaCode.Properties.ReadOnly;
            }
            set
            {
                cboShippingAreaCode.Properties.ReadOnly = value;
            }
        }

        [DefaultValue(false)]
        public bool IsShowAddNewButton
        {
            get
            {
                return cboShippingAreaCode.Properties.ShowAddNewButton;
            }
            set
            {
                cboShippingAreaCode.Properties.ShowAddNewButton = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DevExpress.XtraEditors.XtraForm AddNewForm { get; set; }
        #endregion

        #region Constructor
        public ShippingAreaControl()
        {
            InitializeComponent();
            cboShippingAreaCode.AddNewValue += control_AddNewValue;
        }
        #endregion

        #region Event Handler Function
        private void ShippingAreaControl_Load(object sender, EventArgs e)
        {
            try
            {
                DataLoading();
                ControlUtil.EnableControl(false, txtShippingAreaName);
            }
            catch (Exception ex)
            {
                
            }
        }

        private void cboSupplierCode_EditValueChanged(object sender, EventArgs e)
        {
            txtShippingAreaName.Text = (cboShippingAreaCode.Text.Trim() == String.Empty ? String.Empty : GetShippingAreaName);
            OnSetCustomerIDChanged();
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
                    cboShippingAreaCode.Properties.DisplayMember = "ShippingAreaCode";
                    cboShippingAreaCode.Properties.ValueMember = "ShippingAreaID";
                    gdcShippingAreaCode.FieldName = "ShippingAreaCode";
                    gdcShippingAreaName.FieldName = "ShippingAreaName";

                    _list = BusinessClass.DataLoading(WarehouseID).ToList<sp_common_LoadShipmentArea_Result>();
                    cboShippingAreaCode.Properties.DataSource = Datasource;
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
            cboShippingAreaCode.EditValue = null;
            txtShippingAreaName.Text = String.Empty;
            errorProvider.SetError(cboShippingAreaCode, string.Empty);
        }
        public bool ValidateControl()
        {
            Boolean errFlag = true;
            if (RequireField)
            {
                if (cboShippingAreaCode.EditValue == null)
                {
                    errorProvider.SetError(cboShippingAreaCode, ErrorText);
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(cboShippingAreaCode, string.Empty);
                }
            }
            return errFlag;
        }
        public event EventHandler SetCustomerIDChanged;
        private void OnSetCustomerIDChanged()
        {
            if (SetCustomerIDChanged != null)
                SetCustomerIDChanged(this, new EventArgs());
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

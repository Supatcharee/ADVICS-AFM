/*
 23 Jan 2013:
 * 1. modify and add new property for support filter specific status 
 */
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
    public partial class ShipmentControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private Shipment db;
        private Boolean RequireFlag;
        private String errText;
        private List<sp_common_LoadShippingNo_Result> _list = null;
        public event EventHandler EditValueChanged;
        #endregion

        #region Properties
        private Shipment BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Shipment();
                }
                return db;
            }
        }
        private List<sp_common_LoadShippingNo_Result> Datasource
        {
            get
            {
                if (_list == null)
                {
                    _list = BusinessClass.DataLoading(this.OwnerID, this.CustomerID, this.ShippingDateFrom, this.ShippingDateTo, this.PickDateFrom, this.PickDateTo, this.PackDateFrom, this.PackDateTo, StatusIdList).ToList<sp_common_LoadShippingNo_Result>();
                }
                return _list;
            }
            set
            {
                _list = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? OwnerID { get; set; }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? CustomerID { get; set; }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<int?> StatusIdList{ get; set; }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? ShippingDateFrom { get; set; }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? ShippingDateTo { get; set; }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? PickDateFrom { get; set; }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? PickDateTo { get; set; }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? PackDateFrom { get; set; }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? PackDateTo { get; set; }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ShipmentNo
        {
            get
            {
                if (cboShipmentNo.EditValue != null)
                {
                    return cboShipmentNo.Text.Trim();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if (cboShipmentNo.EditValue != null && cboShipmentNo.EditValue.Equals(value))
                    return;
                sp_common_LoadShippingNo_Result col = Datasource.Where(d => d.ShipmentNo == value).SingleOrDefault();
                if (col != null)
                {
                    cboShipmentNo.EditValue = value;
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
                    return "Shipment Control is Require Field";
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
            set { ControlUtil.EnableControl(value, cboShipmentNo); }
        }
        #endregion
        
        #region Constructor
        public ShipmentControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handler Function
        private void ShipmentControl_Load(object sender, EventArgs e)
        {
            try
            {
                // Bundid C. 20120502 : Load data
                DataLoading();
                RequireField = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void cboShipmentNo_EditValueChanged(object sender, EventArgs e)
        {
            OnEditValueChanged();
        }
        #endregion

        #region Generic Function
        public void DataLoading()
        {
            try
            {
                if (!DesignMode)
                {
                    cboShipmentNo.Properties.DisplayMember = "ShipmentNo";
                    cboShipmentNo.Properties.ValueMember = "ShipmentNo";
                    gdcShipmentNo.FieldName = "ShipmentNo";
                    Datasource = BusinessClass.DataLoading(this.OwnerID, this.CustomerID, this.ShippingDateFrom, this.ShippingDateTo, this.PickDateFrom, this.PickDateTo, this.PackDateFrom, this.PackDateTo, StatusIdList);
                    cboShipmentNo.Properties.DataSource = Datasource;
                    cboShipmentNo.EditValue = null;
                    errorProvider.SetError(cboShipmentNo, string.Empty);
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void ClearData()
        {
            DataLoading();
            cboShipmentNo.EditValue = null;
        }
        public bool ValidateControl()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();
            if (RequireField)
            {
                if (cboShipmentNo.EditValue == null || cboShipmentNo.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(cboShipmentNo, ErrorText);
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

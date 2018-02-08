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
    public partial class PackingControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private Packaging db = null;
        private List<sp_common_LoadPackingNo_Result> _list = null;
        private Boolean RequireFlag;
        private String errText;
        public event EventHandler EditValueChanged;
        #endregion

        #region Properties
        private Packaging BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Packaging();
                }
                return db;
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
        private List<sp_common_LoadPackingNo_Result> Datasource
        {
            get
            {
                if (_list == null)
                {
                    _list = BusinessClass.PackingNoDataLoading(ShipmentNo, ShippingDateFrom, ShippingDateTo, PackingDateFrom, PackingDateTo, StatusIdList).ToList<sp_common_LoadPackingNo_Result>();
                }
                return _list;
            }
            set
            {
                _list = value;
            }
        }

        public string PackingNo
        {
            get
            {
                if (cboPackingNo.EditValue != null)
                {
                    return cboPackingNo.Text.Trim();
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                if (cboPackingNo.EditValue != null && cboPackingNo.EditValue.Equals(value))
                {
                    return;
                }
                sp_common_LoadPackingNo_Result col = Datasource.Where(d => d.PackingNo == value).SingleOrDefault();
                if (col != null)
                {
                    cboPackingNo.EditValue = value;
                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ShipmentNo { get; set; }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? ShippingDateFrom { get; set; }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? ShippingDateTo { get; set; }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? PackingDateFrom { get; set; }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? PackingDateTo { get; set; }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<int?> StatusIdList { get; set; }
        #endregion
        
        #region Constructor
        public PackingControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handler Function
        private void PackingControl_Load(object sender, EventArgs e)
        {
            try
            {
                DataLoading();
                RequireField = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void cboPackingNo_EditValueChanged(object sender, EventArgs e)
        {
            OnEditValueChanged();
        }
        #endregion

        #region Generic Function
        public void ClearData()
        {
            DataLoading();
            cboPackingNo.EditValue = null;
        }

        public void DataLoading()
        {
            try
            {
                if (!DesignMode)
                {
                    cboPackingNo.Properties.DisplayMember = "PackingNo";
                    cboPackingNo.Properties.ValueMember = "PackingNo";
                    gdcPackingNo.FieldName = "PackingNo";

                    this.Datasource = BusinessClass.PackingNoDataLoading(ShipmentNo, ShippingDateFrom, ShippingDateTo, PackingDateFrom, PackingDateTo, StatusIdList).ToList<sp_common_LoadPackingNo_Result>();
                    cboPackingNo.Properties.DataSource = this.Datasource;
                    cboPackingNo.EditValue = null;
                    errorProvider.SetError(cboPackingNo, string.Empty);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public String ErrorText
        {
            get
            {
                if (string.IsNullOrEmpty(errText))
                {
                    return "Packing No. is Require Field";
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
            set { ControlUtil.EnableControl(value, cboPackingNo); }
        }

        public bool ValidateControl()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();
            if (RequireField)
            {
                if (cboPackingNo.EditValue == null || cboPackingNo.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(cboPackingNo, ErrorText);
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

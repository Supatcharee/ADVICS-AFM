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
    public partial class LocationControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private Location db;
        private List<sp_common_LoadLocation_Result> _list = null; // Add by Chalermchai C. // 04/19/2012
        private sp_common_LoadLocation_Result col; // Add by Chalermchai C. // 04/19/2012
        private int? iCustomerID = null;
        private int? iWarehouseID = null;
        private int? iZoneID = null;
        private Boolean RequireFlag;
        private String errText;
        #endregion

        #region Properties
        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? OwnerID
        {
            get { return iCustomerID; }
            set { iCustomerID = value; }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? WarehouseID
        {
            get { return iWarehouseID; }
            set { iWarehouseID = value; }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? ZoneID
        {
            get { return iZoneID; }
            set { iZoneID = value; }
        }
        
        private Location BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Location();
                }
                return db;
            }
        }

        private List<sp_common_LoadLocation_Result> Datasource
        {
            get
            {
                if (_list == null || _list.Count == 0)
                    _list = BusinessClass.DataLoading(OwnerID, WarehouseID, ZoneID).ToList<sp_common_LoadLocation_Result>();
                return _list;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? LocationID
        {
            get
            {
                return DataUtil.Convert<int>(cboLocationCode.EditValue);
            }
            set
            {
                if (cboLocationCode.EditValue != null && cboLocationCode.EditValue.Equals(value))
                    return;
                sp_common_LoadLocation_Result col = Datasource.Where(d => d.LocationID == value).SingleOrDefault();
                if (col != null)
                {
                    cboLocationCode.EditValue = value;
                    txtLocationName.Text = col.LocationName;
                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String LocationCode
        {
            get
            {
                int val;
                if (cboLocationCode.EditValue != null && Int32.TryParse(cboLocationCode.EditValue.ToString(), out val))
                {
                    sp_common_LoadLocation_Result data = Datasource.Where(d => d.LocationID == val).SingleOrDefault();
                    return data.LocationCode;
                }
                else
                    return string.Empty;
            }
            set
            {
                cboLocationCode.EditValue = value;
                col = Datasource.Where(d => d.LocationCode == value).FirstOrDefault();
                if (col != null)
                {
                    cboLocationCode.EditValue = col.LocationID;
                    txtLocationName.Text = col.LocationName;
                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String LocationName
        {
            get
            {   

                int val;
                if (cboLocationCode.EditValue != null && Int32.TryParse(cboLocationCode.EditValue.ToString(), out val))
                {
                    sp_common_LoadLocation_Result data = Datasource.Where(d => d.LocationID == val).SingleOrDefault();
                    if (data == null)
                        return string.Empty;
                    return data.LocationName;
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
                    return "Location Control is Require Field";
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
            set { ControlUtil.EnableControl(value, cboLocationCode); }
        }

        [DefaultValue(false)]
        public bool IsShowAddNewButton
        {
            get
            {
                return cboLocationCode.Properties.ShowAddNewButton;
            }
            set
            {
                cboLocationCode.Properties.ShowAddNewButton = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DevExpress.XtraEditors.XtraForm AddNewForm { get; set; }
        #endregion

        #region Construction
        public LocationControl()
        {
            InitializeComponent();
            cboLocationCode.AddNewValue += control_AddNewValue;
        }
        #endregion

        #region Event Handler Function
        private void LocationControl_Load(object sender, EventArgs e)
        {
            ControlUtil.EnableControl(false, txtLocationName);
            RequireField = false;
        }

        private void cboLocationCode_EditValueChanged(object sender, EventArgs e)
        {
            txtLocationName.Text = (cboLocationCode.Text.Trim() == String.Empty ? String.Empty : LocationName);
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
                    cboLocationCode.Properties.DisplayMember = "LocationCode";
                    cboLocationCode.Properties.ValueMember = "LocationID";
                    gdcLocationCode.FieldName = "LocationCode";
                    gdcLocationName.FieldName = "LocationName";
                    _list = BusinessClass.DataLoading(OwnerID, WarehouseID, ZoneID).ToList<sp_common_LoadLocation_Result>();
                    cboLocationCode.Properties.DataSource = Datasource;
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public void ClearData()
        {
            cboLocationCode.EditValue = null;
            txtLocationName.Text = String.Empty;
            errorProvider.SetError(cboLocationCode, string.Empty);
        }
        // Add by Chalermchai C. // 04/19/2012 .. For View Mode , Edit Mode in Location Dialog
        public bool HavingText()
        {
            if (txtLocationName.Text == string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidateControl()
        {
            Boolean errFlag = true;
            if (RequireField)
            {
                if (cboLocationCode.EditValue == null)
                {
                    errorProvider.SetError(cboLocationCode, ErrorText);
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(cboLocationCode, string.Empty);
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

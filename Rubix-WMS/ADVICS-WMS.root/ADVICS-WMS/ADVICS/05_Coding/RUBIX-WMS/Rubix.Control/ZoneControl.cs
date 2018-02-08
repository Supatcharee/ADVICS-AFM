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
    public partial class ZoneControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private Zone db;
        private List<sp_common_LoadZone_Result> _list = null; // Add by Chalermchai C. // 04/19/2012
        private sp_common_LoadZone_Result col; // Add by Chalermchai C. // 04/19/2012
        private int? iCustomerID = null;
        private int? iWarehouseID = null;
        private int? iFloor = null;
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
        public int? Floor
        {
            get { return iFloor; }
            set { iFloor = value; }
        }
        
        private Zone BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Zone();
                }
                return db;
            }
        }

        private List<sp_common_LoadZone_Result> Datasource
        {
            get
            {
                if (_list == null || _list.Count == 0)
                    _list = BusinessClass.DataLoading(OwnerID, WarehouseID, Floor).ToList<sp_common_LoadZone_Result>();
                return _list;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? ZoneID
        {
            get
            {
                return DataUtil.Convert<int>(cboZoneCode.EditValue);
            }
            set
            {
                if (cboZoneCode.EditValue != null && cboZoneCode.EditValue.Equals(value))
                    return;
                sp_common_LoadZone_Result col = Datasource.Where(d => d.ZoneID == value).SingleOrDefault();
                if (col != null)
                {
                    cboZoneCode.EditValue = value;
                    txtZoneName.Text = col.ZoneName;
                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ZoneCode
        {
            get
            {
                int val;
                if (cboZoneCode.EditValue != null && Int32.TryParse(cboZoneCode.EditValue.ToString(), out val))
                {
                    sp_common_LoadZone_Result data = Datasource.Where(d => d.ZoneID == val).SingleOrDefault();
                    return data.ZoneCode;
                }
                else
                    return string.Empty;
            }
            set
            {
                cboZoneCode.EditValue = value;
                col = Datasource.Where(d => d.ZoneCode == value).FirstOrDefault();
                if (col != null)
                {
                    cboZoneCode.EditValue = col.ZoneID;
                    txtZoneName.Text = col.ZoneName;
                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ZoneName
        {
            get
            {   // 2013-04-11 : comment  to test edit  2013-04-11
                //try
                //{
                //    if (cboZoneCode.Text.Trim() == String.Empty)
                //        return null;
                //    //String check = ((sp_common_LoadZone_Result)(GridSearch.GetFocusedRow())).ZoneName;
                //    //return check;
                //    return ((sp_common_LoadZone_Result)(GridSearch.GetFocusedRow())).ZoneName;
                //}
                //catch (Exception)
                //{
                //    return null;
                //}

                int val;
                if (cboZoneCode.EditValue != null && Int32.TryParse(cboZoneCode.EditValue.ToString(), out val))
                {
                    sp_common_LoadZone_Result data = Datasource.Where(d => d.ZoneID == val).SingleOrDefault();
                    if (data == null)
                        return string.Empty;
                    return data.ZoneName;
                }
                else
                    return string.Empty;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ZoneColor
        {
            get
            {
                int val;
                if (cboZoneCode.EditValue != null && Int32.TryParse(cboZoneCode.EditValue.ToString(), out val))
                {
                    sp_common_LoadZone_Result data = Datasource.Where(d => d.ZoneID == val).SingleOrDefault();
                    if (data == null)
                        return string.Empty;
                    return data.ZoneColor;
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
                    return "Zone Control is Require Field";
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
            set { ControlUtil.EnableControl(value, cboZoneCode); }
        }

        [DefaultValue(false)]
        public bool IsShowAddNewButton
        {
            get
            {
                return cboZoneCode.Properties.ShowAddNewButton;
            }
            set
            {
                cboZoneCode.Properties.ShowAddNewButton = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DevExpress.XtraEditors.XtraForm AddNewForm { get; set; }
        #endregion

        #region Construction
        public ZoneControl()
        {
            InitializeComponent();
            cboZoneCode.AddNewValue += control_AddNewValue;
        }
        #endregion

        #region Event Handler Function
        private void ZoneControl_Load(object sender, EventArgs e)
        {
            ControlUtil.EnableControl(false, txtZoneName);
            RequireField = false;
        }

        private void cboZoneCode_EditValueChanged(object sender, EventArgs e)
        {
            txtZoneName.Text = (cboZoneCode.Text.Trim() == String.Empty ? String.Empty : ZoneName);
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
                    cboZoneCode.Properties.DisplayMember = "ZoneCode";
                    cboZoneCode.Properties.ValueMember = "ZoneID";
                    gdcZoneCode.FieldName = "ZoneCode";
                    gdcZoneName.FieldName = "ZoneName";
                    _list = BusinessClass.DataLoading(OwnerID, WarehouseID, Floor).ToList<sp_common_LoadZone_Result>();
                    cboZoneCode.Properties.DataSource = Datasource;
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public void ClearData()
        {
            cboZoneCode.EditValue = null;
            txtZoneName.Text = String.Empty;
            errorProvider.SetError(cboZoneCode, string.Empty);
        }
        // Add by Chalermchai C. // 04/19/2012 .. For View Mode , Edit Mode in Location Dialog
        public bool HavingText()
        {
            if (txtZoneName.Text == string.Empty)
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
                if (cboZoneCode.EditValue == null)
                {
                    errorProvider.SetError(cboZoneCode, ErrorText);
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(cboZoneCode, string.Empty);
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

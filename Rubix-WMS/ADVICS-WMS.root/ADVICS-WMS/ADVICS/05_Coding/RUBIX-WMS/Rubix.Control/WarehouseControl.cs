using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CSI.Business.Common;
using CSI.Business;
using CSI.Business.DataObjects;
using Rubix.Framework;

namespace Rubix.Control
{
    public partial class WarehouseControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private Warehouse  db;
        private int? iOwnerID = null;
        private List<sp_common_LoadWarehouse_Result> _list = null;
        private sp_common_LoadWarehouse_Result col;
        private Boolean RequireFlag;
        private String errText;
        private bool updateDataSource = false;
        public event EventHandler EditValueChanged;
        #endregion

        #region Properties
        private Warehouse BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Warehouse();
                }
                return db;
            }
        }

        private List<sp_common_LoadWarehouse_Result> Datasource
        {
            get
            {
                if (_list == null)
                    _list = BusinessClass.DataLoading(OwnerID).ToList<sp_common_LoadWarehouse_Result>();
                return _list;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String WarehouseCode
        {
            get
            {
                int val;
                if (cboWarehouse.EditValue != null && Int32.TryParse(cboWarehouse.EditValue.ToString(), out val))
                {
                    sp_common_LoadWarehouse_Result data = Datasource.Where(d => d.WarehouseID == val).SingleOrDefault();
                    if (data == null)
                        return string.Empty;
                    return data.WarehouseCode;
                }
                else
                    return string.Empty;
            }
            set
            {
                cboWarehouse.EditValue = value;
                col = Datasource.Where(d => d.WarehouseCode == value).FirstOrDefault();
                if (col != null)
                {
                    cboWarehouse.EditValue = col.WarehouseID;
                    txtWarehouseName.Text = col.WarehouseName;
                }
            }
        }

        public String WarehouseName
        {
            get
            {
                int val;
                if (cboWarehouse.EditValue != null && Int32.TryParse(cboWarehouse.EditValue.ToString(), out val))
                {
                    sp_common_LoadWarehouse_Result data = Datasource.Where(d => d.WarehouseID == val).SingleOrDefault();
                    if (data == null)
                        return string.Empty;
                    return data.WarehouseName;
                }
                else
                    return string.Empty;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? WarehouseID
        {
            get
            {
                return DataUtil.Convert<int>(cboWarehouse.EditValue);
            }
            set
            {
                col = Datasource.Where(d => d.WarehouseID == value).FirstOrDefault();
                if (col != null)
                {
                    cboWarehouse.EditValue = value;
                    txtWarehouseName.Text = col.WarehouseName;
                }
                else
                {
                    cboWarehouse.EditValue = null;
                    txtWarehouseName.Text = string.Empty;
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
                    return "Warehouse Control is Require Field";
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
        public int? OwnerID
        {
            set {iOwnerID = value; }
            get { return iOwnerID; }
        }

        public bool EnableControl
        {
            set { ControlUtil.EnableControl(value, cboWarehouse); }
        }

        public bool IsForEdit { get; set; }
        
        [DefaultValue(false)]
        public bool IsShowAddNewButton 
        {
            get 
            {
                return cboWarehouse.Properties.ShowAddNewButton;
            }
            set
            {
                cboWarehouse.Properties.ShowAddNewButton = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DevExpress.XtraEditors.XtraForm AddNewForm { get; set; }
        #endregion
        
        #region Constructor
        public WarehouseControl()
        {
            InitializeComponent();
            IsForEdit = false;
            IsShowAddNewButton = false;
            cboWarehouse.AddNewValue += control_AddNewValue;
        }
        #endregion

        #region Event Handler Function
        private void WarehouseControl_Load(object sender, EventArgs e)
        {
            try
            {
                DataLoading();
                ControlUtil.EnableControl(false, txtWarehouseName);
            }
            catch (Exception ex)
            {
                
            }
        }

        private void cboWarehouse_EditValueChanged(object sender, EventArgs e)
        {
            txtWarehouseName.Text = (cboWarehouse.Text.Trim() == String.Empty ? String.Empty : WarehouseName);
            // Bundid C. 20120508 : call event
            if (!updateDataSource)
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
                    updateDataSource = true;
                    cboWarehouse.Properties.DisplayMember = "WarehouseCode";
                    cboWarehouse.Properties.ValueMember = "WarehouseID";
                    gdcWarehouseCode.FieldName = "WarehouseCode";
                    gdcWarehouseShortName.FieldName = "WarehouseName";

                    //OwnerID = (OwnerID != null && OwnerID > 0 ? OwnerID : AppConfig.DefaultOwnerID);
                    _list = BusinessClass.DataLoading(OwnerID).ToList<sp_common_LoadWarehouse_Result>();
                    
                    cboWarehouse.Properties.DataSource = Datasource;
                    ClearData();
                    updateDataSource = false;
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public void ClearData()
        {
            if (AppConfig.DefaultWarehouseID == null || AppConfig.DefaultOwnerID == null)
            {
                cboWarehouse.EditValue = null; 
                txtWarehouseName.Text = string.Empty;
            }
            else
            {
                this.OwnerID = AppConfig.DefaultOwnerID;
                this.WarehouseID = AppConfig.DefaultWarehouseID;
                if (!IsForEdit)
                {
                    //ControlUtil.EnableControl(false, cboWarehouse);
                    cboWarehouse.Tag = "no control";
                }
            }
            errorProvider.SetError(cboWarehouse, string.Empty);
        }

        public bool HavingText()
        {
            if (txtWarehouseName.Text == string.Empty)
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
            errorProvider.ClearErrors();
            if (RequireField)
            {
                if (Util.IsNullOrEmpty(cboWarehouse.EditValue))
                {
                    errorProvider.SetError(cboWarehouse, ErrorText);
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(cboWarehouse, string.Empty);
                }
            }
            return errFlag;
        }
                
        private void OnEditValueChanged()
        {
            if (EditValueChanged != null)
                EditValueChanged(this, new EventArgs());
        }

        public void IsError(bool bError, string ErrorMessage)
        {
            if (bError)
            {
                errorProvider.SetError(cboWarehouse, ErrorMessage);
            }
            else
            {
                errorProvider.SetError(cboWarehouse, string.Empty);
            }
        }
        #endregion        
    }
}

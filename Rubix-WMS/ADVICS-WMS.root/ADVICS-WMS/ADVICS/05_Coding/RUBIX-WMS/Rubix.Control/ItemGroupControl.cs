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
    public partial class ItemGroupControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private ProductGroup db;
        private List<sp_common_LoadProductGroup_Result> _list = null;
        private Boolean RequireFlag;
        private String errText;
        private bool updateDataSource = false;
        public event PropertyChangedEventHandler ProductGroupIDChanged;
        public event EventHandler ProductGroupIDChangeds;
        public event EventHandler EditValueChanged;
        #endregion

        #region Properties
        private ProductGroup BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ProductGroup();
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

        private List<sp_common_LoadProductGroup_Result> Datasource
        {
            get
            {
                if (_list == null)
                    _list = BusinessClass.DataLoading();
                return _list;
            }
        }
        
        public String ErrorText
        {
            get
            {
                if (string.IsNullOrEmpty(errText))
                {
                    return "Product Group Control is Require Field";
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
        public int? ProductGroupID
        {
            get
            {
                return DataUtil.Convert<int>(cboItemGroupCode.EditValue);
            }
            set
            {
                cboItemGroupCode.EditValue = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ProductGroupName
        {
            get
            {
                int val;
                if (cboItemGroupCode.EditValue != null && Int32.TryParse(cboItemGroupCode.EditValue.ToString(), out val))
                {
                    sp_common_LoadProductGroup_Result data = Datasource.Where(d => d.ProductGroupID == val).SingleOrDefault();
                    if (data != null)
                        return data.ProductGroupName;
                    else
                        return string.Empty;
                }
                else
                    return string.Empty;
            }
        }

        public bool EnableControl
        {
            set { ControlUtil.EnableControl(value, cboItemGroupCode); }
        }

        [DefaultValue(false)]
        public bool IsShowAddNewButton
        {
            get
            {
                return cboItemGroupCode.Properties.ShowAddNewButton;
            }
            set
            {
                cboItemGroupCode.Properties.ShowAddNewButton = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DevExpress.XtraEditors.XtraForm AddNewForm { get; set; }
        #endregion
        
        #region Constructor
        public ItemGroupControl()
        {
            InitializeComponent();
            cboItemGroupCode.AddNewValue += control_AddNewValue;
        }
        #endregion

        #region Event Handler Function
        private void ItemGroup_Load(object sender, EventArgs e)
        {
            try
            {
                errorProvider.ClearErrors();
                ControlUtil.EnableControl(false, txtItemGroupName);
                DataLoading();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void cboItemGroupCode_EditValueChanged(object sender, EventArgs e)
        {
            txtItemGroupName.Text = (cboItemGroupCode.Text.Trim() == String.Empty ? String.Empty : ProductGroupName);
            OnProductGroupIDChanged();
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
        private void DataLoading()
        {
            try
            {
                if (!DesignMode)
                {
                    updateDataSource = true;
                    cboItemGroupCode.Properties.DisplayMember = "ProductGroupCode";
                    cboItemGroupCode.Properties.ValueMember = "ProductGroupID";
                    gdcItemGroupCode.FieldName = "ProductGroupCode";
                    gdcItemGroupName.FieldName = "ProductGroupName";
                    cboItemGroupCode.Properties.DataSource = Datasource;
                    updateDataSource = false;
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public void ClearData()
        {
            cboItemGroupCode.EditValue = null;
            txtItemGroupName.Text = String.Empty;
            errorProvider.SetError(cboItemGroupCode, string.Empty);
        }

        public void OnProductGroupIDChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (ProductGroupIDChanged != null)
                ProductGroupIDChanged(this, e);
        }

        public void OnProductGroupIDChanged()
        {
            if (ProductGroupIDChangeds != null)
                ProductGroupIDChangeds(this, new EventArgs());
        }

        public bool ValidateControl()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();
            if (RequireField)
            {
                if (cboItemGroupCode.EditValue == null)
                {
                    errorProvider.SetError(cboItemGroupCode, ErrorText);
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(cboItemGroupCode, string.Empty);
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

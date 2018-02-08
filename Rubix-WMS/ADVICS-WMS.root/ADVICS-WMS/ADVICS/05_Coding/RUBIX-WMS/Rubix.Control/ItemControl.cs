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
    public partial class ItemControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private Product  db;
        private int? iCustomerID;
        private Boolean RequireFlag;
        private String errText;
        private List<sp_common_LoadProduct_Result> _list = null;
        private sp_common_LoadProduct_Result col;
        public event EventHandler EditValueChanged;
        private Boolean isSaleItem;
        private Boolean isPurchaseItem;
        #endregion

        #region Properties
        private Product BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Product();
                }
                return db;
            }
        }

        private List<sp_common_LoadProduct_Result> Datasource
        {
            get
            {
                if (_list == null)
                    _list = BusinessClass.DataLoading(OwnerID).ToList();
                return _list;
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
                    return "Item Control is Require Field";
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
            get { return iCustomerID; }
            set { iCustomerID = value; }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ProductCode
        {
            get
            {
                int val;
                if (cboItem.EditValue != null && Int32.TryParse(cboItem.EditValue.ToString(), out val))
                {
                    sp_common_LoadProduct_Result data = Datasource.Where(d => d.ProductID == val).SingleOrDefault();
                    if (data == null)
                        return string.Empty;
                    return data.ProductCode;
                }
                else
                    return string.Empty;
            }
            set
            {
                cboItem.EditValue = value;
                col = Datasource.Where(d => d.ProductCode == value).SingleOrDefault();
                if (col != null)
                {
                    cboItem.EditValue = col.ProductID;
                    txtItemName.Text = col.ProductLongName;

                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ProductLongName
        {
            get
            {
                int val;
                if (cboItem.EditValue != null && Int32.TryParse(cboItem.EditValue.ToString(), out val))
                {
                    sp_common_LoadProduct_Result data = Datasource.Where(d => d.ProductID == val).SingleOrDefault();
                    if (data == null)
                        return string.Empty;
                    return data.ProductLongName;
                }
                else
                    return string.Empty;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? ProductID
        {
            get
            {
                return DataUtil.Convert<int>(cboItem.EditValue);
            }
            set
            {
                if (cboItem.EditValue != null && cboItem.EditValue.Equals(value))
                    return;
                sp_common_LoadProduct_Result col = Datasource.Where(d => d.ProductID == value).SingleOrDefault();
                if (col != null)
                {
                    cboItem.EditValue = value;
                    txtItemName.Text = col.ProductLongName;
                }
            }
        }    

        public bool EnableControl
        {
            set { ControlUtil.EnableControl(value, cboItem); }
        }

        [DefaultValue(false)]
        public bool IsShowAddNewButton
        {
            get
            {
                return cboItem.Properties.ShowAddNewButton;
            }
            set
            {
                cboItem.Properties.ShowAddNewButton = value;
            }
        }

        [DefaultValue(false)]
        public bool IsSaleItem
        {
            get
            {
                return isSaleItem;
            }
            set
            {
                isSaleItem = value;
            }
        }

        [DefaultValue(false)]
        public bool IsPurchaseItem
        {
            get
            {
                return isPurchaseItem;
            }
            set
            {
                isPurchaseItem = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DevExpress.XtraEditors.XtraForm AddNewForm { get; set; }
        #endregion
        
        #region Constructor
        public ItemControl()
        {
            InitializeComponent();
            cboItem.AddNewValue += control_AddNewValue;
        }
        #endregion

        #region Event Handler Function
        private void ItemControl_Load(object sender, EventArgs e)
        {
            try
            {
                DataLoading();
                ControlUtil.EnableControl(false, txtItemName);
                RequireField = false;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void cboItem_EditValueChanged(object sender, EventArgs e)
        {
            txtItemName.Text = (cboItem.Text.Trim() == String.Empty ? String.Empty : ProductLongName);
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
                    cboItem.Properties.DisplayMember = "ProductCode";
                    cboItem.Properties.ValueMember = "ProductID";
                    gdcItemCode.FieldName = "ProductCode";
                    gdcItemShortName.FieldName = "ProductLongName";
                    _list = BusinessClass.DataLoading(OwnerID).ToList();
                    cboItem.Properties.DataSource = _list;
                    ClearData();

                }
            }
            catch (Exception ex)
            {

            }
        }
        public void ClearData()
        {
            cboItem.EditValue = null;
            txtItemName.Text = String.Empty;
            errorProvider.SetError(cboItem, string.Empty);
        }
        public bool ValidateControl()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();
            if (RequireField)
            {
                if (cboItem.EditValue == null)
                {
                    errorProvider.SetError(cboItem, ErrorText);
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

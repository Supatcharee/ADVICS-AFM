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
    public partial class ItemPriceControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private ProductPrice db;
        private int? iCustomerID;
        private Boolean RequireFlag;
        private String errText;
        private List<sp_common_LoadProductPrice_Result> _list = null;
        private sp_common_LoadProductPrice_Result col;
        public event EventHandler EditValueChanged;
        #endregion

        public enum ePriceType
        {
            Sale,
            Purchase,
            ImportSale
        }

        #region Properties
        private ProductPrice BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ProductPrice();
                }
                return db;
            }
        }
        
        private List<sp_common_LoadProductPrice_Result> Datasource
        {
            get
            {
                if (_list == null)
                    _list = new List<sp_common_LoadProductPrice_Result>();
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
        public List<sp_common_LoadProductPrice_Result> ListData
        {
            get { return _list; }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? OwnerID { get; set; }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? WarehouseID { get; set; }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? CustomerSupplierID { get; set; }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ProductCode
        {
            get
            {
                int val;
                if (cboItem.EditValue != null && Int32.TryParse(cboItem.EditValue.ToString(), out val))
                {
                    sp_common_LoadProductPrice_Result data = Datasource.Where(d => d.ProductID == val).SingleOrDefault();
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
                    sp_common_LoadProductPrice_Result data = Datasource.Where(d => d.ProductID == val).SingleOrDefault();
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
                sp_common_LoadProductPrice_Result col = Datasource.Where(d => d.ProductID == value).SingleOrDefault();
                if (col != null)
                {
                    cboItem.EditValue = value;
                    txtItemName.Text = col.ProductLongName;
                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal? UnitPrice
        {
            get
            {
                int val;
                if (cboItem.EditValue != null && Int32.TryParse(cboItem.EditValue.ToString(), out val))
                {
                    sp_common_LoadProductPrice_Result data = Datasource.Where(d => d.ProductID == val).SingleOrDefault();
                    if (data == null)
                        return null;
                    return data.UnitPrice;
                }
                else
                    return null;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? CurrencyID
        {
            get
            {
                int val;
                if (cboItem.EditValue != null && Int32.TryParse(cboItem.EditValue.ToString(), out val))
                {
                    sp_common_LoadProductPrice_Result data = Datasource.Where(d => d.ProductID == val).SingleOrDefault();
                    if (data == null)
                    {
                        return 0;
                    }
                    return data.CurrencyID;
                }
                else
                    return 0;
            }
        }   

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CurrencyName
        {
            get
            {
                int val;
                if (cboItem.EditValue != null && Int32.TryParse(cboItem.EditValue.ToString(), out val))
                {
                    sp_common_LoadProductPrice_Result data = Datasource.Where(d => d.ProductID == val).SingleOrDefault();
                    if (data == null)
                        return string.Empty;
                    return data.CurrencyName;
                }
                else
                    return string.Empty;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal? UnitPrice2
        {
            get
            {
                int val;
                if (cboItem.EditValue != null && Int32.TryParse(cboItem.EditValue.ToString(), out val))
                {
                    sp_common_LoadProductPrice_Result data = Datasource.Where(d => d.ProductID == val).SingleOrDefault();
                    if (data == null)
                        return null;
                    return data.UnitPrice2;
                }
                else
                    return null;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? CurrencyID2
        {
            get
            {
                int val;
                if (cboItem.EditValue != null && Int32.TryParse(cboItem.EditValue.ToString(), out val))
                {
                    sp_common_LoadProductPrice_Result data = Datasource.Where(d => d.ProductID == val).SingleOrDefault();
                    if (data == null)
                    {
                        return 0;
                    }
                    return data.CurrencyID2;
                }
                else
                    return 0;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CurrencyName2
        {
            get
            {
                int val;
                if (cboItem.EditValue != null && Int32.TryParse(cboItem.EditValue.ToString(), out val))
                {
                    sp_common_LoadProductPrice_Result data = Datasource.Where(d => d.ProductID == val).SingleOrDefault();
                    if (data == null)
                        return string.Empty;
                    return data.CurrencyName2;
                }
                else
                    return string.Empty;
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

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ePriceType PriceType { get; set; }


        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DevExpress.XtraEditors.XtraForm AddNewForm { get; set; }
        #endregion
        
        #region Constructor
        public ItemPriceControl()
        {
            InitializeComponent();
            cboItem.AddNewValue += control_AddNewValue;
        }
        #endregion

        #region Event Handler Function
        private void ItemPriceControl_Load(object sender, EventArgs e)
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

                    _list = BusinessClass.DataLoading(OwnerID, WarehouseID, CustomerSupplierID, PriceType.ToString()).ToList();
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

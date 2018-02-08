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
    public partial class ItemCategoryControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private ItemCategory db;
        private List<sp_common_LoadProductCategory_Result> _list = null;
        private Boolean RequireFlag;
        private String errText;
        public event EventHandler EditValueChanged;
        #endregion

        #region Properties
        private ItemCategory BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ItemCategory();
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

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? ProductGroupID { get; set; }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? ProductCategoryID
        {
            get
            {
                return DataUtil.Convert<int>(cboItemCategory.EditValue);
            }
            set
            {
                cboItemCategory.EditValue = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ProductCategoryName
        {
            get
            {
                if (txtCategoryName.Text == string.Empty)
                {
                    return Datasource.Where(c => c.ProductCategoryID == ProductCategoryID).FirstOrDefault().ProductCategoryName;
                }
                else
                {
                    return txtCategoryName.Text;
                }
            }
        }

        private List<sp_common_LoadProductCategory_Result> Datasource
        {
            get
            {
                if (_list == null)
                    _list = BusinessClass.DataLoading(/*ItemCatelogID null, */ ProductGroupID).ToList<sp_common_LoadProductCategory_Result>();
                return _list;
            }
        }

        public String ErrorText
        {
            get
            {
                if (string.IsNullOrEmpty(errText))
                {
                    return "Type Of Goods Control is Require Field";
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
            set { ControlUtil.EnableControl(value, cboItemCategory); }
        }

        [DefaultValue(false)]
        public bool IsShowAddNewButton
        {
            get
            {
                return cboItemCategory.Properties.ShowAddNewButton;
            }
            set
            {
                cboItemCategory.Properties.ShowAddNewButton = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DevExpress.XtraEditors.XtraForm AddNewForm { get; set; }
        #endregion

        #region Constructor
        public ItemCategoryControl()
        {
            InitializeComponent();
            cboItemCategory.AddNewValue += control_AddNewValue;
        }
        #endregion

        #region Event Handler Function
        private void ItemCategoryControl_Load(object sender, EventArgs e)
        {
            errorProvider.ClearErrors();
            ControlUtil.EnableControl(false, txtCategoryName);
        }

        private void cboTypeOfGoods_EditValueChanged(object sender, EventArgs e)
        {
            txtCategoryName.Text = (cboItemCategory.Text.Trim() == String.Empty ? String.Empty : ProductCategoryName);
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
                    cboItemCategory.Properties.DisplayMember = "ProductCategoryCode";
                    cboItemCategory.Properties.ValueMember = "ProductCategoryID";
                    gdcItemCategoryCode.FieldName = "ProductCategoryCode";
                    gdcItemCategoryName.FieldName = "ProductCategoryName";
                    //cboItemCategory.Properties.DataSource = Datasource;
                    _list = BusinessClass.DataLoading(/*20,*/ ProductGroupID).ToList();
                    cboItemCategory.Properties.DataSource = _list;
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public void ClearData()
        {
            cboItemCategory.EditValue = null;
            txtCategoryName.Text = String.Empty;
            errorProvider.SetError(cboItemCategory, string.Empty);
        }

        public bool ValidateControl()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();
            if (RequireField)
            {
                if (cboItemCategory.EditValue == null)
                {
                    errorProvider.SetError(cboItemCategory, ErrorText);
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(cboItemCategory, string.Empty);
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

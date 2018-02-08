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
    public partial class ItemConditionControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private ProductCondition db;
        private List<sp_common_LoadProductCondition_Result> _list = null; // Add by Chalermchai C. // 04/19/2012
        private sp_common_LoadProductCondition_Result col; // Add by Chalermchai C. // 04/19/2012
        private Boolean RequireFlag;
        private String errText;
        public event EventHandler EditValueChanged;
        #endregion

        #region Properties
        private ProductCondition BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ProductCondition();
                }
                return db;
            }
        }

        public int? ProductID { get; set; }

        private List<sp_common_LoadProductCondition_Result> Datasource
        {
            get
            {
                if (_list == null)
                    _list = BusinessClass.DataLoading(this.ProductID).ToList<sp_common_LoadProductCondition_Result>();
                return _list;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ProductConditionCode
        {
            get
            {
                int val;
                if (cboItemCondition.EditValue != null && Int32.TryParse(cboItemCondition.EditValue.ToString(), out val))
                {
                    sp_common_LoadProductCondition_Result data = Datasource.Where(d => d.ProductConditionID == val).SingleOrDefault();
                    if (data == null)
                        return string.Empty;
                    return data.ProductConditionCode;
                }
                else
                    return string.Empty;
                
                //try
                //{
                //    if (cboProductCondition.Text.Trim() == String.Empty)
                //        return null;

                //    return ((sp_common_LoadProductCondition_Result)(GridSearch.GetFocusedRow())).ProductConditionCode;
                //}
                //catch (Exception)
                //{                    
                //    return null;
                //}
            }
            set
            {
                cboItemCondition.EditValue = value;
                col = Datasource.Where(d => d.ProductConditionCode == value).FirstOrDefault();
                if (col != null)
                {
                    cboItemCondition.EditValue = col.ProductConditionID;
                    txtItemConditionName.Text = col.ProductConditionName;

                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ProductConditionName
        {
            get
            {
                int val;
                if (cboItemCondition.EditValue != null && Int32.TryParse(cboItemCondition.EditValue.ToString(), out val))
                {
                    sp_common_LoadProductCondition_Result data = Datasource.Where(d => d.ProductConditionID == val).SingleOrDefault();
                    if (data == null)
                        return string.Empty;
                    return data.ProductConditionName;
                }
                else
                    return string.Empty;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? ProductConditionID
        {
            get
            {
                return DataUtil.Convert<int>(cboItemCondition.EditValue);
            }
            set
            {
                if (cboItemCondition.EditValue != null && cboItemCondition.EditValue.Equals(value))
                    return;
                sp_common_LoadProductCondition_Result col = Datasource.Where(d => d.ProductConditionID == value).SingleOrDefault();
                if (col != null)
                {
                    cboItemCondition.EditValue = value;
                    txtItemConditionName.Text = col.ProductConditionName;
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
                    return "Item Condition Control is Require Field";
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
            set { ControlUtil.EnableControl(value, cboItemCondition); }
        }

        [DefaultValue(false)]
        public bool IsShowAddNewButton
        {
            get
            {
                return cboItemCondition.Properties.ShowAddNewButton;
            }
            set
            {
                cboItemCondition.Properties.ShowAddNewButton = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DevExpress.XtraEditors.XtraForm AddNewForm { get; set; }
        #endregion

        #region Construction
        public ItemConditionControl()
        {
            InitializeComponent();
            ProductID = null;
            cboItemCondition.AddNewValue += control_AddNewValue;
        }
        #endregion

        #region Event Handler Function
        private void ItemCondition_Load(object sender, EventArgs e)
        {
            try
            {
                ControlUtil.EnableControl(false, txtItemConditionName);
                DataLoading();
                //RequireField = false;
            }
            catch (Exception ex)
            {
                
            }
        }

        private void cboItemCondition_EditValueChanged(object sender, EventArgs e)
        {
            txtItemConditionName.Text = (cboItemCondition.Text.Trim() == String.Empty ? String.Empty : ProductConditionName);
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
                     cboItemCondition.Properties.DisplayMember = "ProductConditionCode";
                     cboItemCondition.Properties.ValueMember = "ProductConditionID";
                     gdcItemConditionCode.FieldName = "ProductConditionCode";
                     gdcItemConditionName.FieldName = "ProductConditionName";
                     _list = BusinessClass.DataLoading(this.ProductID).ToList<sp_common_LoadProductCondition_Result>();
                     cboItemCondition.Properties.DataSource = Datasource;
                     ClearData();
                 }
             }
             catch (Exception ex)
             {
                 
             }
         }
         public void ClearData()
         {
             cboItemCondition.EditValue = null;
             txtItemConditionName.Text = String.Empty;
             errorProvider.SetError(cboItemCondition, string.Empty);
         }
         public bool ValidateControl()
         {
             Boolean errFlag = true;
             errorProvider.ClearErrors();
             if (RequireField)
             {
                 if (cboItemCondition.EditValue == null)
                 {
                     errorProvider.SetError(cboItemCondition, ErrorText);
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

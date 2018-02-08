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
using DevExpress.XtraEditors;

namespace Rubix.Control
{
    public partial class ItemClassificationControl : XtraUserControl, IClearable
    {
        #region Member
        private Classification db;
        private int? iCustomerID;
        private List<sp_common_LoadClassification_Result> _list = null;
        private Boolean RequireFlag;
        private String errText;
        public event EventHandler ClassificationIDChanged;
        public event EventHandler EditValueChanged;
        #endregion

        #region Properties
        private Classification BusinessClass 
        {
            get
            {
                if (db == null)
                {
                    db = new Classification();
                }
                return db;
            }
        }

        private List<sp_common_LoadClassification_Result> Datasource
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
                    return "Classification Control is Require Field";
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
        public String ClassificationName
        {
            get
            {
                int val;
                if (cboItemClassification.EditValue != null && Int32.TryParse(cboItemClassification.EditValue.ToString(), out val))
                {
                    sp_common_LoadClassification_Result data = Datasource.Where(d => d.ClassificationID == val).SingleOrDefault();
                    return data.ClassificationName;
                }
                else
                    return string.Empty;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? ClassificationID
        {
            get
            {
                return DataUtil.Convert<int>(cboItemClassification.EditValue);
            }
            set
            {
                if (cboItemClassification.EditValue != null && cboItemClassification.EditValue.Equals(value))
                    return;
                sp_common_LoadClassification_Result col = Datasource.Where(d => d.ClassificationID == value).SingleOrDefault();
                if (col != null)
                {
                    cboItemClassification.EditValue = value;
                    txtItemClassificationName.Text = col.ClassificationName;
                }
                else
                {
                    this.ClearData();
                }
            }
        }    

        public bool EnableControl
        {
            set { ControlUtil.EnableControl(value, cboItemClassification); }
        }

        [DefaultValue(false)]
        public bool IsShowAddNewButton
        {
            get
            {
                return cboItemClassification.Properties.ShowAddNewButton;
            }
            set
            {
                cboItemClassification.Properties.ShowAddNewButton = value;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DevExpress.XtraEditors.XtraForm AddNewForm { get; set; }
        #endregion

        #region Constructor
         public ItemClassificationControl()
        {
            InitializeComponent();
            cboItemClassification.AddNewValue += control_AddNewValue;
        }       

         public void OnClassificationIDChanged()
         {
             //Raise the employeeIDChanged event.
             if (ClassificationIDChanged != null)
                 ClassificationIDChanged(this, new EventArgs());
         }
                 
         private void OnEditValueChanged()
         {
             if (EditValueChanged != null)
                 EditValueChanged(this, new EventArgs());
         }
        #endregion

        #region Event Handler Function
         private void ItemClassificationControl_Load(object sender, EventArgs e)
         {
             try
             {
                 errorProvider.ClearErrors();
                 ControlUtil.EnableControl(false, txtItemClassificationName);
             }
             catch (Exception ex)
             {  

             }
         }

         private void cboItemClassification_EditValueChanged(object sender, EventArgs e)
         {
             txtItemClassificationName.Text = this.ClassificationName;
             OnClassificationIDChanged();
             OnEditValueChanged();
             //RequireField = false;
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
             if (!DesignMode)
             {
                 cboItemClassification.Properties.DisplayMember = "ClassificationCode";
                 cboItemClassification.Properties.ValueMember = "ClassificationID";
                 gdcItemClassificationCode.FieldName = "ClassificationCode";
                 gdcItemClassificationName.FieldName = "ClassificationName";
                 _list = BusinessClass.DataLoading(OwnerID).ToList();
                 cboItemClassification.Properties.DataSource = _list;
                 ClearData();    
             }
         }

         public void ClearData()
         {
             //DataLoading();
             cboItemClassification.EditValue = null;
             txtItemClassificationName.Text = string.Empty;
             errorProvider.SetError(cboItemClassification, string.Empty);
         }

         public bool ValidateControl()
         {
             Boolean errFlag = true;
             errorProvider.ClearErrors();
             if (RequireField)
             {
                 if (cboItemClassification.EditValue == null)
                 {
                     errorProvider.SetError(cboItemClassification, ErrorText);
                     errFlag = false;
                 }
             }
             return errFlag;
         }
         #endregion                            
    }
}

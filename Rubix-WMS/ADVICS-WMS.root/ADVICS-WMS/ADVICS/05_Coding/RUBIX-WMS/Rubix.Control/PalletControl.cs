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
    public partial class PalletControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private Pallet db;
        private Boolean RequireFlag;
        private String errText;
        private sp_common_LoadPallet_Result col;
        private List<sp_common_LoadPallet_Result> _list = null;
        public event EventHandler EditValueChanged;
        #endregion

        #region Properties
        private Pallet BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Pallet();
                }
                return db;
            }
        }
        private List<sp_common_LoadPallet_Result> Datasource
        {
            get
            {
                if (_list == null)
                    _list = BusinessClass.DataLoading(OwnerID, WarehouseID, ReceivingNo).ToList();
                return _list;
            }
        }
        public int? OwnerID {get;set;}
        public int? WarehouseID {get;set;}
        public string ReceivingNo {get;set;}
        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String PalletNo
        {
            get
            {
                return (string)(cboPalletNo.EditValue);
            }
            set
            {
                cboPalletNo.EditValue = value;
                col = Datasource.Where(d => d.PalletNo == value).SingleOrDefault();
                if (col != null)
                {
                    cboPalletNo.EditValue = col.PalletNo;
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
                    return "Pallet No. is Require Field";
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
            set { ControlUtil.EnableControl(value, cboPalletNo); }
        }
        #endregion
        
        #region Constructor
        public PalletControl()
        {
            InitializeComponent();
            RequireField = false;
        }
        #endregion

        #region Event Handler Function
        private void PalletControl_Load(object sender, EventArgs e)
        {
            try
            {
                DataLoading();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void cboPalletNo_EditValueChanged(object sender, EventArgs e)
        {
            OnEditValueChanged();
        }
        #endregion

        #region Generic Function
        public void DataLoading()
        {
            try
            {
                if (!DesignMode)
                {
                    cboPalletNo.Properties.DisplayMember = "PalletNo";
                    cboPalletNo.Properties.ValueMember = "PalletNo";
                    gdcPalletNo.FieldName = "PalletNo";
                    _list = null;
                    cboPalletNo.Properties.DataSource = this.Datasource;
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public void ClearData()
        {
            cboPalletNo.EditValue = null;
        }
        public bool ValidateControl()
        {
            Boolean errFlag = true;
            if (RequireField)
            {
                if (cboPalletNo.EditValue == null)
                {
                    errorProvider.SetError(cboPalletNo, ErrorText);
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

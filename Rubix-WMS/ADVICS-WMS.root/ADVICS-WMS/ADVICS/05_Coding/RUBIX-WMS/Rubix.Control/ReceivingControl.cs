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
    public partial class ReceivingControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private Receive db;
        private Boolean RequireFlag;
        private String errText;
        private sp_common_LoadReceiving_Result col;
        private List<sp_common_LoadReceiving_Result> _list = null;
        public event EventHandler EditValueChanged;
        #endregion

        #region Properties
        private Receive BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Receive();
                }
                return db;
            }
        }
        private List<sp_common_LoadReceiving_Result> Datasource
        {
            get
            {
                if (_list == null)
                    _list = BusinessClass.DataLoading(OwnerID, WarehouseID).ToList();
                return _list;
            }
        }
        public int? OwnerID {get;set;}
        public int? WarehouseID {get;set;}
        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ReceivingNo
        {
            get
            {
                return (string)(cboReceivingNo.EditValue);
            }
            set
            {
                cboReceivingNo.EditValue = value;
                col = Datasource.Where(d => d.ReceivingNo == value).SingleOrDefault();
                if (col != null)
                {
                    cboReceivingNo.EditValue = col.ReceivingNo;
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
                    return "Receiving No. is Require Field";
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
            set { ControlUtil.EnableControl(value, cboReceivingNo); }
        }
        #endregion
        
        #region Constructor
        public ReceivingControl()
        {
            InitializeComponent();
            RequireField = false;
        }
        #endregion

        #region Event Handler Function
        private void ReceivingControl_Load(object sender, EventArgs e)
        {
            try
            {
                DataLoading();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void cboReceivingNo_EditValueChanged(object sender, EventArgs e)
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
                    cboReceivingNo.Properties.DisplayMember = "ReceivingNo";
                    cboReceivingNo.Properties.ValueMember = "ReceivingNo";
                    gdcReceivingNo.FieldName = "ReceivingNo";
                    _list = null;
                    cboReceivingNo.Properties.DataSource = this.Datasource;
                    ClearData();
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public void ClearData()
        {
            cboReceivingNo.EditValue = null;
            errorProvider.SetError(cboReceivingNo, string.Empty);
        }
        public bool ValidateControl()
        {
            Boolean errFlag = true;
            if (RequireField)
            {
                if (cboReceivingNo.EditValue == null)
                {
                    errorProvider.SetError(cboReceivingNo, ErrorText);
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

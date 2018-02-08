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
    public partial class PickingControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        public enum eComboType
        { 
            Screen
            , Report
        }

        #region Member
        private Picking  db;
        private Boolean RequireFlag;
        private String errText;
        // Bundid C. 20120502
        private String shipmentNo;
        private eComboType comboType = eComboType.Screen;
        public event EventHandler EditValueChanged;
        #endregion

        #region Properties
        private Picking BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new Picking();
                }
                return db;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String PickingNo
        {
            get
            {
                try
                {
                    if (cboPickingNo.Text.Trim() == String.Empty)
                        return null;

                    return ((sp_common_LoadPickingNo_Result)(GridSearch.GetFocusedRow())).PickingNo;
                }
                catch (Exception)
                {                    
                    return null;
                }
            }
            set {
                cboPickingNo.EditValue = value;
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
                    return "Picking Control is Require Field";
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
            set { ControlUtil.EnableControl(value, cboPickingNo); }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String ShipmentNo 
        {
            get { return shipmentNo; }
            set { shipmentNo = value; }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<int?> StatusIdList { get; set; }

        public eComboType ComboType
        {
            get {return comboType;}
            set {comboType = value;}
        }

        public int? OwnerID
        {
            get;
            set;
        }

        public int? WarehouseID
        {
            get;
            set;
        }
        #endregion
        
        #region Constructor
        public PickingControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handler Function
        private void PickingControl_Load(object sender, EventArgs e)
        {
            try
            {
                DataLoading();
                RequireField = false;
            }
            catch (Exception ex)
            {
                
            }
        }
        private void cboPickingNo_EditValueChanged(object sender, EventArgs e)
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
                    cboPickingNo.Properties.DisplayMember = "PickingNo";
                    gdcPickingNo.FieldName = "PickingNo";
                    switch (comboType)
                    {
                        case eComboType.Screen:
                            cboPickingNo.Properties.DataSource = BusinessClass.DataLoading(shipmentNo, StatusIdList);
                            break;
                        case eComboType.Report:
                            cboPickingNo.Properties.DataSource = BusinessClass.DataLoading(OwnerID, WarehouseID);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public void ClearData()
        {
            cboPickingNo.EditValue = null;
            errorProvider.SetError(cboPickingNo, string.Empty);
        }
        public bool ValidateControl()
        {
            Boolean errFlag = true;
            errorProvider.ClearErrors();
            if (RequireField)
            {
                if (cboPickingNo.EditValue == null)
                {
                    errorProvider.SetError(cboPickingNo, ErrorText);
                    errFlag = false;
                }
                else
                {
                    errorProvider.SetError(cboPickingNo, string.Empty);
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

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
    public partial class LotControl : DevExpress.XtraEditors.XtraUserControl, IClearable
    {
        #region Member
        private LotInformation  db;
        private int? iProductID = null;
        private Boolean RequireFlag;
        private String errText;
        private List<sp_common_LoadLot_Result> _list = null;
        private sp_common_LoadLot_Result col;
        public event EventHandler EditValueChanged;
        public event EventHandler FocusedRowChanged;
        #endregion

        #region Properties
        private List<sp_common_LoadLot_Result> Datasource
        {
            get
            {
                if (_list == null)
                    _list = BusinessClass.DataLoading(iProductID, WarehouseID).ToList<sp_common_LoadLot_Result>();
                return _list;
            }
        }

        private LotInformation BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new LotInformation();
                }
                return db;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? GetReceiveDate
        {
            get
            {
                try
                {
                    if (cboLotNo.Text == String.Empty)
                        return null;

                    return ((sp_common_LoadLot_Result)(GridSearch.GetFocusedRow())).ReceivingDate;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? ProductID
        {
            get { return iProductID; }
            set { iProductID = value; }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? WarehouseID
        {
            get;
            set;
        }
        
        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String GetLotNo
        {
            get
            {
                try
                {
                    if (cboLotNo.EditValue != null)
                    {
                        return cboLotNo.Text;
                    }
                    else
                        return string.Empty;
                    
                }
                catch (Exception)
                {                    
                    return null;
                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string GetPalletNo
        {
            get
            {
                string val;
                if (cboLotNo.EditValue != null)
                {
                    val = cboLotNo.EditValue.ToString();
                    sp_common_LoadLot_Result data = Datasource.Where(d => d.LotKey == val).SingleOrDefault();
                    if (data == null)
                        return null;
                    return data.PalletNo;
                }
                else
                    return null;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal? GetQTY
        {
            get
            {
                string val;
                if (cboLotNo.EditValue != null)
                {
                    val = cboLotNo.EditValue.ToString();
                    sp_common_LoadLot_Result data = Datasource.Where(d => d.LotKey == val).SingleOrDefault();
                    if (data == null)
                        return null;
                    return data.ReceiveQty;
                }
                else
                    return null;
            }
        }

        //[System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal? GetAvailableQty
        {
            get
            {
                string val;
                if (cboLotNo.EditValue != null)
                {
                    val = cboLotNo.EditValue.ToString();
                    sp_common_LoadLot_Result data = Datasource.Where(d => d.LotKey == val).SingleOrDefault();
                    if (data == null)
                    {
                        return null;
                    }
                    return data.AvalQty;
                }
                else
                {
                    return null;
                }
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PalletNoRef
        {
            get
            {
                string val;
                if (cboLotNo.EditValue != null)
                {
                    val = cboLotNo.EditValue.ToString();
                    sp_common_LoadLot_Result data = Datasource.Where(d => d.LotKey == val).SingleOrDefault();
                    if (data == null)
                        return null;
                    return data.PalletNoRef;
                }
                else
                    return null;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal? GetInventory
        {
            get
            {
                string val;
                if (cboLotNo.EditValue != null)
                {
                    val = cboLotNo.EditValue.ToString();
                    sp_common_LoadLot_Result data = Datasource.Where(d => d.LotKey == val).SingleOrDefault();
                    if (data == null)
                        return null;
                    return data.Inventory;
                }
                else
                    return null;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string GetUnitCode
        {
            get
            {
                string val;
                if (cboLotNo.EditValue != null)
                {
                    val = cboLotNo.EditValue.ToString();
                    sp_common_LoadLot_Result data = Datasource.Where(d => d.LotKey == val).SingleOrDefault();
                    if (data == null)
                        return null;
                    return data.UnitCode;
                }
                else
                    return null;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? GetUnitID
        {
            get
            {
                string val;
                if (cboLotNo.EditValue != null)
                {
                    val = cboLotNo.EditValue.ToString();
                    sp_common_LoadLot_Result data = Datasource.Where(d => d.LotKey == val).SingleOrDefault();
                    if (data == null)
                        return null;
                    return data.UnitID;
                }
                else
                    return null;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? ProductConditionID
        {
            set
            {
                cboLotNo.EditValue = value;
                col = Datasource.Where(d => d.ProductConditionID == value).SingleOrDefault();
                if (col != null)
                {
                    cboLotNo.EditValue = col.LotNo;

                }
            }
            get
            {
                string val;
                if (cboLotNo.EditValue != null)
                {
                    val = cboLotNo.EditValue.ToString();
                    sp_common_LoadLot_Result data = Datasource.Where(d => d.LotKey == val).SingleOrDefault();
                    if (data == null)
                        return null;
                    return data.ProductConditionID;
                }
                else
                    return null;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public String GetReceivingNo
        {
            get
            {
                string val;
                if (cboLotNo.EditValue != null)
                {
                    val = cboLotNo.EditValue.ToString();
                    sp_common_LoadLot_Result data = Datasource.Where(d => d.LotKey == val).SingleOrDefault();
                    if (data == null)
                        return null;
                    return data.ReceivingNo;
                }
                else
                    return null;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? GetRecInstallment
        {
            get
            {
                string val;
                if (cboLotNo.EditValue != null)
                {
                    val = cboLotNo.EditValue.ToString();
                    sp_common_LoadLot_Result data = Datasource.Where(d => d.LotKey == val).SingleOrDefault();
                    if (data == null)
                        return null;
                    return data.RecInstallment;
                }
                else
                    return null;
            }
        }

        [System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? GetRecLineNo
        {
            get
            {
                string val;
                if (cboLotNo.EditValue != null)
                {
                    val = cboLotNo.EditValue.ToString();
                    sp_common_LoadLot_Result data = Datasource.Where(d => d.LotKey == val).SingleOrDefault();
                    if (data == null)
                        return null;
                    return data.RecLineNo;
                }
                else
                    return null;
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
                    return "Lot Control is Require Field";
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
            set { ControlUtil.EnableControl(value, cboLotNo); }
        }
        #endregion
        
        #region Constructor
        public LotControl()
        {
            InitializeComponent();
        }

        private void OnEditValueChanged()
        {
            if (EditValueChanged != null)
                EditValueChanged(this, new EventArgs());
        }

        private void OnFocusedRowChanged()
        {
            if (FocusedRowChanged != null)
                FocusedRowChanged(this, new EventArgs());
        }
        #endregion

        #region Event Handler Function
        private void LotControl_Load(object sender, EventArgs e)
        {
            try
            {
                ControlUtil.EnableControl(false, txtPalletNo);
                RequireField = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void cboLotNo_EditValueChanged(object sender, EventArgs e)
        {
            txtPalletNo.Text = (cboLotNo.Text == String.Empty ? String.Empty : GetPalletNo);
            OnEditValueChanged();
        }

        private void GridSearch_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            OnFocusedRowChanged();
        }
        #endregion

        #region Generic Function
        public void DataLoading()
        {
            try
            {
                if (!DesignMode)
                {
                    cboLotNo.Properties.DisplayMember = "LotNo";
                    cboLotNo.Properties.ValueMember = "LotKey";

                    _list = null;
                    cboLotNo.Properties.DataSource = this.Datasource;
                    txtPalletNo.Text = String.Empty;
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        public void setLotNoControl(string ReceivingNo, int? RecInstallment, int? RecLineNo, int? ItemConditionID)
        {

            col = Datasource.Where(d => d.ReceivingNo == ReceivingNo && d.RecInstallment == RecInstallment && d.RecLineNo == RecLineNo && d.ProductConditionID == ItemConditionID).SingleOrDefault();
            if (col != null)
            {
                cboLotNo.EditValue = col.LotKey;
                txtPalletNo.Text = col.PalletNo;
            }
            else
                cboLotNo.EditValue = null;
        }
        public bool ValidateLotNo(string LotNo, int ProductConditionID)
        {
            bool bReturn = false;
            col = Datasource.Where(d => d.LotNo == LotNo && d.ProductConditionID == ProductConditionID).SingleOrDefault();
            if (col != null)
            {
                bReturn = true;
            }
            return bReturn;
        }
        public void ClearData()
        {
            DataLoading();
            cboLotNo.EditValue = null;
        }
        public bool ValidateControl()
        {
            Boolean errFlag = true;
            if (RequireField)
            {
                if (cboLotNo.EditValue == null)
                {
                    errorProvider.SetError(cboLotNo, ErrorText);
                    errFlag = false;
                }
            }
            return errFlag;
        }
        public void SelectFirst()
        {
            if (this.Datasource != null && this.Datasource.Count > 0)
            {
                sp_common_LoadLot_Result lot = this.Datasource.FirstOrDefault();
                cboLotNo.EditValue = lot.LotKey;
            }
        }
        //public decimal? GetInventoryByLot(string LotNo, int ProductConditionID)
        //{
        //    sp_common_LoadLot_Result data = Datasource.Where(d => d.LotNo == LotNo && d.ProductConditionID == ProductConditionID).SingleOrDefault();
        //    if (data == null)
        //    {
        //        return null;
        //    }
        //    return data.Inventory;
        //}
        public void SetEditValueByLot(string LotNo, int ProductConditionID)
        {
            sp_common_LoadLot_Result data = Datasource.Where(d => d.LotNo == LotNo && d.ProductConditionID == ProductConditionID).SingleOrDefault();
            if (data == null)
            {
                return;
            }
            cboLotNo.EditValue= data.LotKey;
        }
        
        #endregion              
    }
}

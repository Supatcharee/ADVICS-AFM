using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CSI.Business.Operation;
using Rubix.Framework;
using CSI.Business.DataObjects;
using System.IO;
using System.Linq;
using DevExpress.XtraGrid;
namespace Rubix.Screen.Form.Operation.D_Storing.Dialog
{
    public partial class dlgDSRS011_ConfirmProdStoring : DialogBase
    {
        #region Member
        ///for set default qty
        private decimal _tmpDefaultActualQty = 0;
        private List<string> _filePath = new List<string>();
        private ConfirmProductStoring db;
        private int? rcvSeq = null;
        private bool m_bIsEdit = false;
        private List<sp_common_LoadByLocationType_Result> ListClone;
        #endregion

        #region Properties
        public ConfirmProductStoring BusinessClass
        {
            get
            {
                if (db == null)
                    db = new ConfirmProductStoring();
                return db;
            }
            set
            {
                db = value;
            }
        }
        public sp_DSRS010_ConfirmProductStoring_SearchAll_Result Header { get; set; }
        public List<sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result> Detail { get; set; }
        public string UnitCode { get; set; } 
        #endregion

        #region Constructor
        public dlgDSRS011_ConfirmProdStoring()
        {
            InitializeComponent();
            base.GridViewControl = new GridControl[] { grdLocation };
            ControlUtil.EnableControl(false, itemControl, itemConditionControl);
        } 
        #endregion

        #region Overrice Method
        public override bool OnCommandSave()
        {
            gdvLocation.PostEditor();
            if (ValidateSave())
            {
                BusinessClass.UploadFile(txtReceivingNo.Text, _filePath);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else if (!m_bIsEdit)
            {
                if (_filePath.Count > 0)
                {
                    BusinessClass.UploadFile(txtReceivingNo.Text, _filePath);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            return true;
        }

        public override bool OnCommandClose()
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            return base.OnCommandClose();
        }

        public override bool OnCommandClear()
        {
            Dataloading();
            return base.OnCommandClear();
        }
        #endregion

        #region Event Handler
        private void dlgDSRS012_ConfirmProdStoring_Load(object sender, EventArgs e)
        {
            try
            {
                _filePath.Clear();
                CSI.Business.Common.Location loc = new CSI.Business.Common.Location();
                cboDefaultLocation.Properties.DataSource = loc.DataLoading(Header.OwnerID, Header.WarehouseID);
                cboDefaultLocation.Properties.DisplayMember = "LocationCode";
                cboDefaultLocation.Properties.ValueMember = "LocationID";

                repLocation.DataSource = BusinessClass.LoadAllLocation(Header.OwnerID, Header.WarehouseID);
                repLocation.DisplayMember = "LocationCode";
                repLocation.ValueMember = "LocationID";

                repLocationType.DataSource = BusinessClass.LoadLocationType();
                repLocationType.DisplayMember = "LocationTypeName";
                repLocationType.ValueMember = "LocationTypeID";

                Dataloading();
                gdvLocation.OptionsBehavior.Editable = true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            AddNewLocation(0);
        }

        private void btnDeleteLocation_Click(object sender, EventArgs e)
        {
            if (gdvLocation.GetFocusedRow() != null)
            {
                gdvLocation.DeleteSelectedRows();
                CalEntryQty();
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdAttach.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(ofdAttach.FileName);

                    long filesize = fileInfo.Length;
                    if (filesize >= 4194340)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0200"));
                        return;
                    }
                    _filePath.Add(ofdAttach.FileName);
                }
            }
            catch (Exception ex)
            {
                
            }          
        }

        private void gdvLocation_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {           
            CalEntryQty();
        }

        private void repActualQty_EditValueChanged(object sender, EventArgs e)
        {
            gdvLocation.PostEditor();
            if (gdvLocation.GetFocusedRow() != null)
            {
                sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result data = (sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result)gdvLocation.GetFocusedRow();
                if (data.TotalCapacity.HasValue && data.CurrentCapacity.HasValue && data.StockActualQty.HasValue)
                {
                    if (data.TotalCapacity - data.CurrentCapacity < data.StockActualQty)
                    {
                        if (data.TotalCapacity - data.CurrentCapacity < 0)
                            data.StockActualQty = 0;
                        else
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0348"));
                            data.StockActualQty = data.TotalCapacity - data.CurrentCapacity;
                            gdvLocation.CloseEditor();
                            gdvLocation.UpdateCurrentRow();

                            //MessageBox.Show(gcActualQty.);
                        }
                            
                    }
                }
                CalEntryQty();
                m_bIsEdit = true;
            }
        }

        private void repLocation_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            int? locationID = DataUtil.Convert<int>(e.NewValue);
            if (locationID.HasValue)
            {
                List<sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result> AllLocation = (List<sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result>)((System.Windows.Forms.BindingSource)(grdLocation.DataSource)).List;

                if (AllLocation.Where(c => c.LocationID == locationID).Count() > 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0195"));
                    e.Cancel = true;
                }
                LoadStockByLocation(locationID);
                m_bIsEdit = true;
            }
        }

        private void txtQtyRec_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal value = Convert.ToDecimal(e.NewValue);
            e.Cancel = value > ((SpinEdit)sender).Properties.MaxValue ||
                value < ((SpinEdit)sender).Properties.MinValue;
        }

        private void txtQtyEntry_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal value = Convert.ToDecimal(e.NewValue);
            e.Cancel = value > ((SpinEdit)sender).Properties.MaxValue ||
                value < ((SpinEdit)sender).Properties.MinValue;
        }

        private void txtQtyRemain_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            decimal value = Convert.ToDecimal(e.NewValue);
            e.Cancel = value > ((SpinEdit)sender).Properties.MaxValue ||
                value < ((SpinEdit)sender).Properties.MinValue;
        }

        private void gdvLocation_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result rec = (sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result)gdvLocation.GetRow(e.RowHandle);
            if (rec.TransitSeq != 0)
                return;

            if (e.Column == gcActualQty || e.Column == gcFullCapacity || e.Column == gcLocation || e.Column == gcLocationType)
            {
                e.Appearance.BackColor = Common.EditableCellColor();
            }
        }

        private void gdvLocation_ShowingEditor(object sender, CancelEventArgs e)
        {
            sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result rec = (sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result)gdvLocation.GetFocusedRow();
            e.Cancel = (rec.TransitSeq != 0);
        
        }

        private void repLocationType_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            
            sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result View = gdvLocation.GetFocusedRow() as sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result;
            View.LocationID = null;
        }

        private void gdvLocation_ShownEditor(object sender, System.EventArgs e)
        {

            if (gdvLocation.FocusedColumn.FieldName == "LocationID" && gdvLocation.ActiveEditor is LookUpEdit)
            {
                DevExpress.XtraEditors.LookUpEdit edit;
                edit = (LookUpEdit)gdvLocation.ActiveEditor;

                List<sp_common_LoadByLocationType_Result> ListAll = edit.Properties.LookUpData.DataSource as List<sp_common_LoadByLocationType_Result>;

                List<sp_common_LoadByLocationType_Result> ListClone = new List<sp_common_LoadByLocationType_Result>();

                sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result View = gdvLocation.GetFocusedRow() as sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result;

                ListClone = ListAll.Where(c => c.LocationTypeID == View.LocationTypeID).ToList();

                edit.Properties.LookUpData.DataSource = ListClone;
            }
        }

        private void gdvLocation_HiddenEditor(object sender, System.EventArgs e)
        {

            if (ListClone != null)
            {
                ListClone = null;
            }
        }
        #endregion

        #region Generic Function
        private bool ValidateAdd()
        {
            return true;
        }

        private bool ValidateSave()
        {
            if (m_bIsEdit)
            {
                decimal sumQty = 0;
                foreach (sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result data in this.Detail)
                {
                    if (!data.LocationID.HasValue)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0193"));
                        return false;
                    }
                    if (data.StockActualQty.HasValue)
                        sumQty += data.StockActualQty.Value;
                }
                //I0214
                foreach (sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result data in this.Detail)
                {
                    if (this.Detail.Where(c => c.LocationID == data.LocationID).Count() > 1)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0214"));
                    }
                }

                if (sumQty != Header.ReceiveQty)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0127"));
                    return false;
                }
                return true;
            }
            return false;
        }

        private void Dataloading()
        {

            txtReceivingNo.Text = Header.ReceivingNo;
            txtLineNo.EditValue = Header.LineNo;
            cboDefaultLocation.EditValue = Header.LocationID;
            txtLotNo.Text = Header.LotNo;
            txtQtyEntry.EditValue = 0;
            txtQtyRemain.EditValue = 0;
            txtQtyRec.EditValue = Header.ReceiveQty;
            itemConditionControl.ProductConditionID = Header.ProductConditionID;
            itemControl.ProductID = Header.ProductID;
            rcvSeq = Header.ReceiveSeq;
            lblUnitQty1.Text = Header.UnitCode;
            lblUnitQty2.Text = Header.UnitCode;
            lblUnitQty3.Text = Header.UnitCode;

            //Load location stock
            BindingSource bs = new BindingSource();
            if (this.Detail == null || this.Detail.Count <= 0)
                this.Detail = BusinessClass.LoadTransitConfirm(Header.OwnerID, Header.ReceivingNo, Header.Installment, Header.LineNo, Header.ReceiveSeq);
            bs.DataSource = this.Detail;
            grdLocation.DataSource = bs;
            CalEntryQty();
            // for new, add new location (default location from main screen)
            if (this.Detail.Count == 0 && Header.LocationID.HasValue)
            {
                AddNewLocation(this.Header.TransitQty.Value);
            }
        }

        private void CalEntryQty()
        {
            decimal decSum = 0;
            foreach (sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result data in this.Detail)
            {
                if (data.StockActualQty.HasValue)
                    decSum += data.StockActualQty.Value;
            }
            txtQtyEntry.EditValue = decSum;
            if (DataUtil.Convert<decimal>(txtQtyRec.Text).HasValue)
                txtQtyRemain.EditValue = DataUtil.Convert<decimal>(txtQtyRec.Text).Value - decSum;
        }

        private void LoadStockByLocation(int? locationID)
        {
            sp_DSRS010_ConfirmProductStoring_LoadStockByLocation_Result stock = BusinessClass.LoadDefaultTransitConfirm(locationID.Value);
            sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result data = (sp_DSRS010_ConfirmProductStoring_LoadTransitConfirm_Result)gdvLocation.GetFocusedRow();
            if (stock != null)
            {
                data.CurrentCapacity = stock.CurrentCapacity;
                data.TotalCapacity = stock.TotalCapacity;
                data.FullCapacityFlag = stock.FullCapacityFlag;
                data.UnitCode = UnitCode;
                if ((bool)stock.FullCapacityFlag)
                {
                    data.StockActualQty = null;
                }
                data.LocationID = locationID;
            }
            else
            {
                //Should not fall into this case
                data.CurrentCapacity = 0;
                data.TotalCapacity = 0;
                data.FullCapacityFlag = false;
                data.UnitCode = string.Empty;
                data.StockActualQty = null;
                data.LocationID = locationID;
            }
        }

        private void AddNewLocation(decimal defaultActualQty)
        {
            _tmpDefaultActualQty = defaultActualQty;
            if (ValidateAdd())
            {
                gdvLocation.BeginUpdate();
                gdvLocation.AddNewRow();
                gdvLocation.EndUpdate();
            }
            // clear default actual qty
            _tmpDefaultActualQty = 0;
        }

        private void LoadLocationByLocationType(int? locationTypeId)
        {
            
        }
        #endregion
    }
}
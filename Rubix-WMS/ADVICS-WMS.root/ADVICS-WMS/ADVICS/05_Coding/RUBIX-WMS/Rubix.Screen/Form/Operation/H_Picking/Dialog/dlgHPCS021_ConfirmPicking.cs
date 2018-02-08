using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using CSI.Business.Operation;
using Rubix.Framework;
using CSI.Business.DataObjects;
using System.Linq;
namespace Rubix.Screen.Form.Operation.H_Picking.Dialog
{
    public partial class dlgHPCS021_ConfirmPicking : DialogBase
    {

        #region Member
        private ConfirmPicking db;
        public sp_HPCS020_ConfirmPicking_SearchAll_Result Data { get; set; }
        private List<sp_HPCS020_ConfirmPicking_GetPickingDetail_Result> _detail = null;
        private List<sp_HPCS020_ConfirmPicking_GetPickingDetail_Result> _original = null;
        
        ///for set default qty
        private decimal? _tmpDefaultActualQty = 0;
        #endregion

        #region Enumeration
        private enum eColPickingView
        {
             LocationID
			,LocationCode
			,Quantity
            ,PickingQty
            ,PickingLineSeq
        }
        
        
        #endregion

        #region Properties
        public ConfirmPicking BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ConfirmPicking();
                }
                return db;
            }
            set
            {
                db = value;
            }
        }

        public List<sp_HPCS020_ConfirmPicking_GetPickingDetail_Result> Detail { get { return _detail; } set { _detail = value; } }
        
        #endregion

        #region Constructor
        public dlgHPCS021_ConfirmPicking()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarPrint);
            base.GridViewControl = new GridControl[] { grdQtyActual };
            ControlUtil.HiddenControl(true, m_toolBarClear);
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0047"), BusinessClass.ShipmentNo)) == DialogButton.Yes)
                {
                    if (ValidateSave())
                    {
                        if (BusinessClass.CheckActualQtyInStockQty())
                        {
                            SaveData();
                            DialogResult = DialogResult.OK;
                            return true;
                        }
                        else 
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0152"));
                            return false;
                        }
                    }
                    
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        
        public override bool  OnCommandClear()
        {
            ClearAll();
            return true;
        }
        #endregion

        #region Event Handler Function
        private void dlgHPCS021_ConfirmPicking_Load(object sender, EventArgs e)
        {
            try
            {
                ControlUtil.EnableControl(false, txtShipmentNo, txtPickingNo, txtSumKanban, txtSumPallet, txtLineNo, txtQty, txtQtyActual, txtLocationCode);
                itemControl.EnableControl = false;
                itemConditionControl.EnableControl = false;
                BindingData();
                LoadDetail();
                InitConditionCombobox();
                grvQtyActual.OptionsBehavior.Editable = true;

                // add default location
                if (this._detail.Count == 0 && this.Data.LocationID.HasValue)
                {
                    AddNewLocation(this.Data.ActualQty);
                }
                this._original = _detail.ToList();
                base.HideStatusBar();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }         

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewLocation(0);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void repLocation_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                grvQtyActual.PostEditor();
                sp_HPCS020_ConfirmPicking_GetPickingDetail_Result temp = (sp_HPCS020_ConfirmPicking_GetPickingDetail_Result)grvQtyActual.GetFocusedRow();
                if (checkGrid())
                {
                    List<sp_HPCS020_ConfirmPicking_GetLocation_Result> _listQty = BusinessClass.GetQuantity(BusinessClass.ShipmentNo, BusinessClass.PickingNo, BusinessClass.LineNo, temp.LocationCode);

                    if (_listQty.Count != 0)
                    {
                        temp.Quantity = _listQty[0].Quantity;
                        temp.LocationID = _listQty[0].LocationID;
                        temp.FullCapacityFlag = _listQty[0].FullCapacityFlag;
                    }
                }
                else
                {
                    temp.LocationCode = null;
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0286"));
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnDeleteLocation_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvQtyActual.GetFocusedRow() != null)
                {
                    DeleteDetail((sp_HPCS020_ConfirmPicking_GetPickingDetail_Result)grvQtyActual.GetFocusedRow());
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void grvQtyActual_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                sp_HPCS020_ConfirmPicking_GetPickingDetail_Result data = (sp_HPCS020_ConfirmPicking_GetPickingDetail_Result)grvQtyActual.GetRow(e.RowHandle);
                data.PickingQty = _tmpDefaultActualQty.HasValue ? _tmpDefaultActualQty.Value : 0;
                data.PickingLineSeq = 0;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void grvQtyActual_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == eColPickingView.PickingQty.ToString())
                {
                    grvQtyActual.PostEditor();
                    grvQtyActual.Columns[eColPickingView.PickingQty.ToString()].Summary.Add(DevExpress.Data.SummaryItemType.Sum, eColPickingView.PickingQty.ToString(), "{0}");
                    txtQtyActual.EditValue = Convert.ToDecimal((grvQtyActual.Columns[eColPickingView.PickingQty.ToString()].SummaryItem).SummaryValue);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void repQty_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal decSum = 0;
                grvQtyActual.PostEditor();
                foreach (sp_HPCS020_ConfirmPicking_GetPickingDetail_Result data in this._detail)
                {
                    decSum += data.PickingQty;
                }
                txtQtyActual.EditValue = decSum;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        #endregion
        
        #region Generic Function
        private void BindingData()
        {
            txtShipmentNo.Text = BusinessClass.ShipmentNo;
            txtSumKanban.EditValue = BusinessClass.sumKanban;
            txtKanban.EditValue = BusinessClass.Kanban;
            txtPallet.EditValue = BusinessClass.Pallet;
            txtSumPallet.EditValue = BusinessClass.sumPallet;
            txtPickingNo.Text = BusinessClass.PickingNo;
            txtLineNo.EditValue = BusinessClass.SortedLineNo;
            itemControl.ProductID = BusinessClass.ProductID;
            itemConditionControl.ProductConditionID = BusinessClass.ProductConditionID;
            txtLocationCode.Text = BusinessClass.LocationCode;
            txtQty.EditValue = BusinessClass.Qty;
            txtQtyActual.EditValue = BusinessClass.ActualQty;
            txtLotNo.EditValue = BusinessClass.LotNo;
        }
        
        private void ClearAll()
        {
            ControlUtil.ClearControlData(txtKanban,txtPallet);
            grdQtyActual.DataSource = null;

            _detail = this._original.ToList();
            BindingSource bs = new BindingSource();
            bs.DataSource = _detail;
            grdQtyActual.DataSource = bs;
        }

        private void LoadDetail()
        {
            _detail = BusinessClass.LoadDetailPicking(BusinessClass.ShipmentNo, BusinessClass.PickingNo, BusinessClass.LineNo);
            BindingSource bs = new BindingSource();
            bs.DataSource = _detail;   
            grdQtyActual.DataSource = bs;
            
            //gcSeq.FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo("PickingLineSeq = 0");
            //grvQtyActual.ActiveFilterString = "PickingLineSeq = 0";            
        }

        private void InitConditionCombobox()
        {
            repLocation.DataSource = BusinessClass.GetLocation(BusinessClass.ShipmentNo, BusinessClass.PickingNo, BusinessClass.LineNo);
            repLocation.DisplayMember = "LocationCode";
            repLocation.ValueMember = "LocationCode";
        }
        
        private bool ValidateAdd()
        {           
            return true;
        }

        private bool ValidateSave()
        {
            decimal sumQty = 0;
            grvQtyActual.PostEditor();
            foreach (sp_HPCS020_ConfirmPicking_GetPickingDetail_Result data in this._detail)
            {
                if (data.LocationID == null)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0107"));
                    return false;
                }
                if (data.PickingQty <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0120"));
                    return false;
                }
                if (data.PickingQty != null)
                {
                    sumQty += data.PickingQty;
                }
            }
            if (sumQty < (decimal)txtQty.EditValue)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0108"));
                return false;
            }
            else if (sumQty > (decimal)txtQty.EditValue)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0109"));
                return false;
            }
            return true;
        }
         
        private bool checkGrid()
        {
            sp_HPCS020_ConfirmPicking_GetPickingDetail_Result temp = (sp_HPCS020_ConfirmPicking_GetPickingDetail_Result)grvQtyActual.GetFocusedRow();
            
            if (grvQtyActual.RowCount > 1)
            {
                if (_detail.Where(c => c.LocationCode == temp.LocationCode).Count() > 1)
                {
                    return false;
                }
            }
            return true;
        }

        private void SaveData()
        {            
            BusinessClass.Kanban = (txtKanban.Text.Trim() == String.Empty ? 0 : (int)txtKanban.EditValue);
            BusinessClass.Pallet = (txtPallet.Text.Trim() == String.Empty ? 0 : (int)txtPallet.EditValue);
            DataSet ds = ToDataSet(_detail);            
        }

        private DataSet ToDataSet(IList<sp_HPCS020_ConfirmPicking_GetPickingDetail_Result> list)
        {
            Type elementType = typeof(sp_HPCS020_ConfirmPicking_GetPickingDetail_Result);
            DataSet ds = new DataSet();
            DataTable t = new DataTable();
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                t.Columns.Add(propInfo.Name, ColType);
            }

            //go through each property on T and add each value to the table
            foreach (sp_HPCS020_ConfirmPicking_GetPickingDetail_Result item in list)
            {
                DataRow row = t.NewRow();

                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }

                t.Rows.Add(row);
            }

            return ds;
        }

        private void DeleteDetail(sp_HPCS020_ConfirmPicking_GetPickingDetail_Result row)
        {
            int deletedLine = row.PickingLineSeq;
            grvQtyActual.DeleteSelectedRows();
            foreach (sp_HPCS020_ConfirmPicking_GetPickingDetail_Result data in _detail)
            {
                if (data.PickingLineSeq > deletedLine)
                    data.PickingLineSeq--;
            }
            grvQtyActual.RefreshData();
        }

        private void AddNewLocation(decimal? defaultActualQty)
        {
            _tmpDefaultActualQty = defaultActualQty;
            if (ValidateAdd())
            {
                grvQtyActual.BeginUpdate();
                grvQtyActual.AddNewRow();
                grvQtyActual.EndUpdate();

            }
            _tmpDefaultActualQty = 0;
        }
        #endregion       
    }
}
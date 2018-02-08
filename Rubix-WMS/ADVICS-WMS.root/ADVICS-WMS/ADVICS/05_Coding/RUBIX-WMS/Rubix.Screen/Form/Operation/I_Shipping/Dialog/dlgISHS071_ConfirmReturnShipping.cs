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
using CSI.Business.BusinessFactory.Operation;
using System.Linq;

namespace Rubix.Screen.Form.Operation.I_Shipping.Dialog
{
    public partial class dlgISHS071_ConfirmReturnShipping : DialogBase
    {

        #region Member
        private ConfirmReturn db;        
        decimal? NumberOfUnitLevel4;
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
        public ConfirmReturn BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ConfirmReturn();
                }
                return db;
            }
        }
        public string ShipmentNo { get; set; }
        public string PickingNo { get; set; }
        public int ItemID { get; set; }
        public int OwnerID { get; set; }
        public int WarehouseID { get; set; }
        public string PalletNo { get; set; }
        public List<ConfirmReturn> DataSource { get; set; }
        public sp_ISHS071_ReturnPick_Get_Result Data { get; set; }        
        #endregion

        #region Constructor

        public dlgISHS071_ConfirmReturnShipping()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true,m_toolBarPrint);
            base.GridViewControl = new GridControl[] { grdQtyActual };
            this.DataSource = new List<ConfirmReturn>();
            BindingSource bs = new BindingSource();
            bs.DataSource = this.DataSource;
            grdQtyActual.DataSource = bs;
            ControlUtil.HiddenControl(true, m_toolBarClear);
        }
  
        #endregion

        #region Event Handler Function
        private void dlgISHS071_ConfirmReturnShipping_Load(object sender, EventArgs e)
        {
            gdvQtyActual.OptionsBehavior.Editable = true;
            this.DataSource.Clear();
            ControlUtil.EnableControl(false, txtShipmentNo, txtPickingNo, txtLineNo, txtQty, txtQtyActual);
            itemControl.EnableControl = false;
            itemConditionControl.EnableControl = false;
            gdvQtyActual.OptionsBehavior.Editable = true;
            sp_ISHS071_ReturnPick_Get_Result data = BusinessClass.GetDetail(this.ShipmentNo, this.PickingNo, this.ItemID);
            txtLineNo.EditValue = data.LineNo;
            txtLotNo.EditValue = data.LotNo;
            txtPickingNo.EditValue = data.PickingNo;
            txtShipmentNo.EditValue = data.ShipmentNo;
            txtQty.EditValue = data.OrderQty;
            itemControl.ProductID = data.ProductID;
            itemConditionControl.ProductConditionID = data.ProductConditionID;
            NumberOfUnitLevel4 = data.NumberOfUnitLevel4;

            groupControl2.Text = string.Format(groupControl2.Text, data.UnitName);

            CSI.Business.Common.Location loc = new CSI.Business.Common.Location();
            repLocation.DataSource = loc.DataLoading(data.OwnerID, data.WarehouseID);
            repLocation.DisplayMember = "LocationCode";
            repLocation.ValueMember = "LocationID";
            CSI.Business.Common.ProductCondition proc = new CSI.Business.Common.ProductCondition();
            repCondition.DataSource = proc.DataLoading(null);
            repCondition.DisplayMember = "ProductConditionCode";
            repCondition.ValueMember = "ProductConditionID";
            CalEntryQty();
            base.HideStatusBar();
        } 

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            gdvQtyActual.AddNewRow();
        }

        private void btnDeleteLocation_Click(object sender, EventArgs e)
        {
            if (gdvQtyActual.GetFocusedRow() != null)
            {
                gdvQtyActual.DeleteSelectedRows();
                CalEntryQty();
            }
        }

        private void gdvQtyActual_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            ConfirmReturn sel = (ConfirmReturn)gdvQtyActual.GetRow(e.RowHandle);
            if (sel != null && sel.TransitSeq != 0)
            {
                if (e.Column == gdcLocation || e.Column == gdcFullCap || e.Column == gdcActual)
                    e.Appearance.BackColor = Common.EditableCellColor();
            }
        }

        private void repLocation_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            int? locationID = DataUtil.Convert<int>(e.NewValue);
            if (locationID.HasValue)
            {
                foreach (ConfirmReturn con in this.DataSource)
                {
                    if (con.LocationID == locationID.Value)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0195"));
                        e.Cancel = true;
                        break;
                    }
                }
                LoadStockByLocation(locationID);
            }
        }

        private void repActualQty_Leave(object sender, EventArgs e)
        {
            if (gdvQtyActual.GetFocusedRow() != null)
            {
                ConfirmReturn data = (ConfirmReturn)gdvQtyActual.GetFocusedRow();
                if (data != null && data.TotalCapacity.HasValue && data.CurrentCapacity.HasValue && data.StockActualQty.HasValue)
                {

                    if (data.TotalCapacity - data.CurrentCapacity < data.StockActualQty)
                    {
                        if (data.TotalCapacity - data.CurrentCapacity < 0)
                            data.StockActualQty = 0;
                        else
                            data.StockActualQty = data.TotalCapacity - data.CurrentCapacity;
                    }
                }
            }
            CalEntryQty();
        }
        #endregion

        #region Override Method
        public override bool OnCommandClear()
        {
            this.DataSource.Clear();
            return base.OnCommandClear();
        }

        public override bool OnCommandSave()
        {
            try
            {
                gdvQtyActual.PostEditor();
                gdvQtyActual.FocusedColumn = gdcLocation;

                if (gdvQtyActual.GetFocusedRow() != null)
                {
                    ConfirmReturn data = (ConfirmReturn)gdvQtyActual.GetFocusedRow();
                    if (data != null && data.TotalCapacity.HasValue && data.CurrentCapacity.HasValue && data.StockActualQty.HasValue)
                    {
                        if (data.TotalCapacity - data.CurrentCapacity < (data.StockActualQty * NumberOfUnitLevel4))
                        {
                            if (data.TotalCapacity - data.CurrentCapacity < 0)
                            {
                                data.StockActualQty = 0;
                            }
                            else
                            {
                                data.StockActualQty = (data.TotalCapacity - data.CurrentCapacity) / NumberOfUnitLevel4;
                            }
                        }
                    }
                }
                CalEntryQty();
                gdvQtyActual.FocusedColumn = gdcActual;

                if (ValidateSave())
                {
                    if (!iv.ValidateTicket(this.ShipmentNo, this.PickingNo, this.txtLineNo.Text))
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                        return false;
                    }
                    BusinessClass.Confirm(this.ShipmentNo, this.PickingNo, Int32.Parse(this.txtLineNo.Text), this.OwnerID, this.WarehouseID, this.ItemID, this.txtLotNo.Text, this.PalletNo, this.DataSource);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        #endregion

        #region Generic Function
        private void LoadStockByLocation(int? locationID)
        {
            sp_DSRS010_ConfirmProductStoring_LoadStockByLocation_Result bs = BusinessClass.LoadDefaultTransitConfirm(locationID.Value);
            ConfirmReturn stock = new ConfirmReturn();
            stock.CurrentCapacity = bs.CurrentCapacity;
            stock.FullCapacityFlag = bs.FullCapacityFlag;
            stock.LocationID = bs.LocationID;
            stock.StockActualQty = bs.StockActualQty;
            stock.TotalCapacity = bs.TotalCapacity;
            stock.TransitSeq = bs.TransitSeq;
            ConfirmReturn data = (ConfirmReturn)gdvQtyActual.GetFocusedRow();
            if (stock != null)
            {
                data.CurrentCapacity = stock.CurrentCapacity;
                data.TotalCapacity = stock.TotalCapacity;
                data.FullCapacityFlag = stock.FullCapacityFlag;
            }
            else
            {
                //Should not fall into this case
                data.CurrentCapacity = 0;
                data.TotalCapacity = 0;
                data.FullCapacityFlag = false;
            }
        }

        private void CalEntryQty()
        {
            decimal decSum = 0;
            gdvQtyActual.PostEditor();
            foreach (ConfirmReturn data in this.DataSource)
            {
                if (data.StockActualQty.HasValue)
                    decSum += data.StockActualQty.Value;
            }
            txtQtyActual.EditValue = decSum;
        }

        private bool ValidateSave()
        {
            decimal sumQty = 0;
            foreach (ConfirmReturn data in this.DataSource)
            {
                if (!data.LocationID.HasValue)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0193"));
                    return false;
                }
                if (!data.ConditionID.HasValue)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0252"));
                    return false;
                }
                if (data.StockActualQty.HasValue)
                    sumQty += data.StockActualQty.Value;
            }
            //I0214
            foreach (ConfirmReturn data in this.DataSource)
            {
                if (this.DataSource.Where(c => c.LocationID == data.LocationID).Count() > 1)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0214"));
                }
            }

            if (sumQty != Decimal.Parse(txtQty.Text))
            {
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0253"));
                return false;
            }
            return true;
        } 
        #endregion
    }
}
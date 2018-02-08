using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSI.Business.DataObjects;
using CSI.Business.Operation;
using Rubix.Framework;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Rubix.Screen.Form.Operation.F_ShippingEntry.Dialog
{
    public partial class dlgFSES014_ShippingByLot : DialogBase
    {
        #region "Members" 

        
        private ShippingInstruction db;
        private List<sp_FSES013_ShippingByLot_Search_Result> _result = new List<sp_FSES013_ShippingByLot_Search_Result>();
        private List<sp_FSES013_ShippingByLot_Search_Result> _detail;
#endregion

        #region Properties
        public int? WarehouseID
        {
            get;
            set;
        }

        public int? ProductID
        {
            get;
            set;
        }
        public List<sp_FSES013_ShippingByLot_Search_Result> Result
        {
            get
            {
                return _result;
            }
        }
        public ShippingInstruction BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ShippingInstruction();
                }
                return db;
            }
            set
            {
                if (db == null)
                {
                    db = new ShippingInstruction();
                }
                db = value;
            }
        }
        #endregion

        #region Constructor
        public dlgFSES014_ShippingByLot()
        {
            InitializeComponent();
            this.GridViewControl = new DevExpress.XtraGrid.GridControl[] { grdLot };

            gcReceivingDate.DisplayFormat.FormatString = Common.FullDateFormat;
            gcReceivingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
        }
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            gdvLot.PostEditor();
            if (gdvLot.RowCount > 0)
            {
                _result.Clear();
                _result = _detail.Where(c => c.Select.HasValue && c.Select.Value).ToList();
                if (_result.TrueForAll(c => c.ShippingQty.HasValue && c.ShippingQty.Value <= c.InventoryRcv && c.ShippingQty.Value > 0))
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    _result.Clear();
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0174"));
                }
            }
            else
            {
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0172"));
            }
            return base.OnCommandSave();
        }

        public override bool OnCommandClear()
        {
            DataLoading();
            return base.OnCommandClear();
        } 
        #endregion

        #region Event Handler
        private void gdvLot_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridColumnSummaryItem item = e.Item as GridColumnSummaryItem;
            GridView view = sender as GridView;
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                e.TotalValue = 0;
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
            {
                if (Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, gcSelect)))
                {
                    e.TotalValue = DataUtil.Convert<decimal>(e.TotalValue) + DataUtil.Convert<decimal>(view.GetRowCellValue(e.RowHandle, gcShippingQty));
                }
            }
            //if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            //    e.TotalValue = validRowCount;
        }

        private void repSelect_CheckedChanged(object sender, EventArgs e)
        {
            gdvLot.PostEditor();
            gdvLot.UpdateTotalSummary();
        }

        private void repQty_EditValueChanged(object sender, EventArgs e)
        {
            gdvLot.PostEditor();
            gdvLot.UpdateTotalSummary();
        }

        private void dlgFSES014_ShippingByLot_Load(object sender, EventArgs e)
        {
            gdvLot.OptionsBehavior.Editable = true;
            gcSelect.OptionsColumn.AllowEdit = true;
            gcShippingQty.OptionsColumn.AllowEdit = true;
            gcShippingQty.AppearanceCell.BackColor = Common.EditableCellColor();

            DataLoading();
        }
        #endregion

        #region Generic Function
        private bool ValidateData()
        {
            return true;
        }



        private void DataLoading()
        {
            _detail = BusinessClass.GetLotList(this.ProductID, this.WarehouseID);
            BindingSource bs = new BindingSource();
            bs.DataSource = _detail;
            grdLot.DataSource = bs;
            ControlUtil.SetBestWidth(gdvLot);
        }
        
        #endregion

    }
}

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
    public partial class dlgHPCS022_ConfirmPickingDetail : DialogBase
    {
        #region Member
        private ConfirmPicking db;
        private int? iCurrentActual = 0;
        private int? PartType = 0;
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
        public DataRow SelectRow { get; set; }
        #endregion

        #region Constructor
        public dlgHPCS022_ConfirmPickingDetail()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarPrint, m_toolBarClear);
        } 
        #endregion

        #region Override Method
        public override bool OnCommandSave()
        {
            try
            {
                if (checkBeforeConfirm())
                {
                    ShowWaitScreen();
                    DataTable dt = (grdRMTagResult.DataSource as DataTable).Select(" Select = 1 ").CopyToDataTable();
                    BusinessClass.SaveConfirmPicking(SelectRow["ShipmentNo"].ToString(), SelectRow["PickingNo"].ToString(), Convert.ToInt32(SelectRow["LineNo"]), dt);
                    DialogResult = DialogResult.OK;
                    CloseWaitScreen();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        #endregion

        #region Event Handler
        private void dlgHPCS022_ConfirmPickingDetail_Load(object sender, EventArgs e)
        {
            try
            {
                ControlUtil.EnableControl(false, itemControl, itemConditionControl);
                base.HideStatusBar();
                Dataloading();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void recCheck_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gdvgrdRMTagResult.PostEditor();
                DataTable dt = grdRMTagResult.DataSource as DataTable;
                int iSelectRow = 0;
                if (DataUtil.Convert<int>(txtQty.EditValue) == DataUtil.Convert<int>(txtQtyActual.EditValue))
                {
                    DataRow dr = gdvgrdRMTagResult.GetFocusedDataRow();
                    iSelectRow = gdvgrdRMTagResult.GetSelectedRows()[0];
                    dr["Select"] = 0;
                    dt.AcceptChanges();
                    grdRMTagResult.DataSource = null;
                    grdRMTagResult.DataSource = dt;
                    gdvgrdRMTagResult.FocusedRowHandle = iSelectRow;
                }
                dt.AcceptChanges();
                if (PartType == 2)
                {
                    DataRow dr_Focus = gdvgrdRMTagResult.GetFocusedDataRow();
                    DataRow[] drs = ((DataTable)grdRMTagResult.DataSource).Select("LocationID = " + dr_Focus["LocationID"]);
                    foreach (DataRow dr in drs)
                    {
                        dr["Select"] = dr_Focus["Select"];
                    }
                }
                txtQtyActual.EditValue = DataUtil.Convert<int>(dt.Compute(" SUM(Qty) ", "Select = 1")) + iCurrentActual;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        #endregion

        #region Generic Function
        private void Dataloading()
        {
            DataSet ds = BusinessClass.DetailLoading(SelectRow["ShipmentNo"].ToString(), SelectRow["PickingNo"].ToString(), Convert.ToInt32(SelectRow["LineNo"]));
            //Header--
            txtShipmentNo.Text = SelectRow["ShipmentNo"].ToString();
            txtPickingNo.Text = SelectRow["PickingNo"].ToString();
            txtLineNo.EditValue = SelectRow["SortedLineNo"];
            itemControl.ProductID = DataUtil.Convert<int>(ds.Tables[0].Rows[0]["ProductID"]);
            itemConditionControl.ProductConditionID = DataUtil.Convert<int>(ds.Tables[0].Rows[0]["ProductConditionID"]);
            txtQty.EditValue = ds.Tables[0].Rows[0]["AssignQty"];
            txtQtyActual.EditValue = ds.Tables[0].Rows[0]["PickingQty"];
            iCurrentActual = DataUtil.Convert<int>(ds.Tables[0].Rows[0]["PickingQty"]);
            PartType = DataUtil.Convert<int>(ds.Tables[0].Rows[0]["ProductTypeID"]);
            //Detail--
            grdRMTagResult.DataSource = ds.Tables[1];
        }
        
        private Boolean checkBeforeConfirm()
        {
            if (DataUtil.Convert<int>(txtQty.EditValue) != DataUtil.Convert<int>(txtQtyActual.EditValue))
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0108"));
                return false;
            }

            return true;
        }        
        #endregion


    }
}
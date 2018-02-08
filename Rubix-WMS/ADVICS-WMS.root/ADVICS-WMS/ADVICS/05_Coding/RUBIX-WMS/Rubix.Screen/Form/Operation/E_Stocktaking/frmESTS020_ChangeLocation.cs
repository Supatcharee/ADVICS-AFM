/*
 * 13 Feb 2013:
 * 1. add wait screen when search
 */
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
using DevExpress.XtraGrid.Views.Grid;
using CSI.Business.DataObjects;
using DevExpress.XtraReports.UI;
using CSI.Business.BusinessFactory.Report;
using CSI.Business.BusinessFactory.Common;
using System.Data.SqlClient;
using System.Transactions;
namespace Rubix.Screen.Form.Operation.E_Stocktaking
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Edit, Permission.Export)]
    public partial class frmESTS020_ChangeLocation : FormBase
    {
        #region Member
        private ChangeLocation db;
        private Dialog.dlgESTS020_ChangeLocation m_Dialog = null;
        #endregion

        #region Enumeration
        private enum eColumn
        {
            OwnerID,
            WarehouseID,
            LocationID,
            PalletNo,
            ProductConditionID,
            ProductID,
            LastUpdateSince,
            CustomerCode,
            WarehouseCode,
            ProductConditionCode,
            ZoneID,
            ZoneCode,
            RackNo,
            Floor,
            ProductCode,
            ProductName,
            WarehouseName,
            LocationCode,
            ConditionOfProduct,
            Inventory
        }
        #endregion

        #region Properties
        private ChangeLocation BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ChangeLocation();
                }
                return db;
            }
        }
        private Dialog.dlgESTS020_ChangeLocation Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgESTS020_ChangeLocation();
                }
                return m_Dialog;
            }
            set
            {
                m_Dialog = value;
            }
        }
        #endregion

        #region Constructor
        public frmESTS020_ChangeLocation()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarAdd, m_toolBarDelete, m_toolBarSave, m_toolBarRefresh, m_toolBarCancel);
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl3);
            
            gdcInventory.DisplayFormat.FormatString = Common.QtyFormat;
            gdcInventory.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gdcInventory.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            gdcInventoryTo.DisplayFormat.FormatString = Common.QtyFormat;
            gdcInventoryTo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gdcInventoryTo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            iv = new IdleValidator("tbt_stockbylocation", "LastUpdateSince", "Cast(OwnerID as varchar(10))", "Cast(WarehouseID as varchar(10))", "Cast(LocationID as varchar(10))", "Cast(ProductID as varchar(10))", "Cast(ProductConditionID as varchar(10))", "PalletNo");
        }
        #endregion

        #region Override Method
        public override bool OnCommandEdit()
        {
            try
            {
                if (gdvSearchResult.GetFocusedRow() == null)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                }
                else
                {

                    sp_ESTS020_ChangeLocation_SearchAll_Result data = (sp_ESTS020_ChangeLocation_SearchAll_Result)gdvSearchResult.GetFocusedRow();

                    //add by pichaya s. 20130625
                    if (!iv.ValidateTicket(data.OwnerID.ToString(), data.WarehouseID.ToString()
                        , data.LocationID.ToString(), data.ProductID.ToString()
                        , data.ProductConditionID.ToString(), data.PalletNo))
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                        return false;
                    }
                    else
                    {
                        OpenDialog(Common.eScreenMode.Edit);
                    }
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
        
        #region Event Handler Function
        private void frmESTS020_ChangeLocation_Load(object sender, EventArgs e)
        {
            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();
            zoneControl.OwnerID = Common.GetDefaultOwnerID();
            zoneControl.WarehouseID = Common.GetDefaultWarehouseID();
            zoneControl.Floor = null;
            zoneControl.DataLoading();
            itemControl.OwnerID = Common.GetDefaultOwnerID();
            itemControl.DataLoading();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSearchCriteria())
                {
                    DataLoading();
                    if (gdvSearchResult.RowCount == 0)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();

                ownerControl.ClearData();

                itemControl.OwnerID = Common.GetDefaultOwnerID();
                itemControl.DataLoading();

                grdSearchResult.DataSource = null;

                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                zoneControl.OwnerID = Common.GetDefaultOwnerID();
                zoneControl.WarehouseID = Common.GetDefaultWarehouseID();
                zoneControl.Floor = -1;
                zoneControl.DataLoading();
                txtLotNo.Text = String.Empty;
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());

            }
        }

        private void ownerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (ownerControl.OwnerID != null)
                {
                    warehouseControl.OwnerID = ownerControl.OwnerID;
                    warehouseControl.DataLoading();
                    zoneControl.OwnerID = Common.GetDefaultOwnerID();
                    zoneControl.WarehouseID = Common.GetDefaultWarehouseID();
                    zoneControl.Floor = null;
                    zoneControl.DataLoading();
                    itemControl.OwnerID = ownerControl.OwnerID;
                    itemControl.DataLoading();
                }
                else
                {
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    zoneControl.OwnerID = Common.GetDefaultOwnerID();
                    zoneControl.WarehouseID = Common.GetDefaultWarehouseID();
                    zoneControl.Floor = null;
                    zoneControl.DataLoading();
                    itemControl.OwnerID = Common.GetDefaultOwnerID();
                    itemControl.DataLoading();
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void warehouseControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (warehouseControl.WarehouseID != null)
                {
                    zoneControl.OwnerID = ownerControl.OwnerID;
                    zoneControl.WarehouseID = warehouseControl.WarehouseID;
                    zoneControl.Floor = null;
                    zoneControl.DataLoading();
                }
                else
                {
                    zoneControl.OwnerID = Common.GetDefaultOwnerID();
                    zoneControl.WarehouseID = Common.GetDefaultWarehouseID();
                    zoneControl.Floor = null;
                    zoneControl.DataLoading();
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
        
        private void gdvSearchResult_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.Column.FieldName == "LocationCodeTO" || e.Column.FieldName == "ConditionOfProductTO" ||
                e.Column.FieldName == "ChangeQty" || e.Column.FieldName == "ChangeStatus")
            {
                string strLocationTo = View.GetRowCellDisplayText(e.RowHandle, View.Columns["LocationCodeTO"]);
                string strConditionTo = View.GetRowCellDisplayText(e.RowHandle, View.Columns["ConditionOfProductTO"]);
                string strChangeQty = View.GetRowCellDisplayText(e.RowHandle, View.Columns["ChangeQty"]);
                if (strLocationTo != String.Empty || strConditionTo != String.Empty || strChangeQty != String.Empty)
                {

                    e.Appearance.BackColor = Color.Orange;
                }
            }
        }

        #region PrintReport
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SetSelectColumn(true);
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            SetSelectColumn(false);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (true == gdvSearchResult.IsEmpty)
                {
                    return;
                }

                List<sp_ESTS020_ChangeLocation_SearchAll_Result> temp = (List<sp_ESTS020_ChangeLocation_SearchAll_Result>)grdSearchResult.DataSource;
                List<sp_ESTS020_ChangeLocation_SearchAll_Result> selectedList = temp.FindAll(c => c.SELECT == true);
                if (selectedList.Count != 0)
                {
                    ShowWaitScreen();
                    XtraReport rpt = null;
                    ReceivingInstruction dalReport = new ReceivingInstruction();
                    foreach (sp_ESTS020_ChangeLocation_SearchAll_Result data in selectedList)
                    {
                        List<sp_RPT019_ReceivingLabel_GetData_Result> labelList = new List<sp_RPT019_ReceivingLabel_GetData_Result>();
                        int? locationID = null;
                        if (data.ToLocationID != null)
                        {
                            locationID = data.ToLocationID;
                            labelList = dalReport.GetReceivingLabel(data.PalletNo, locationID, data.ProductID, data.LotNo, data.ToProductConditionID, data.ChangeLocationID);
                        }
                        else
                        {
                            locationID = data.LocationID;
                            labelList = dalReport.GetReceivingLabel(data.PalletNo, locationID, data.ProductID, data.LotNo, data.ProductConditionID, null);
                        }

                        if (labelList.Count != 0)
                        {
                            for (int i = 0; i < labelList[0].LabelCnt; i++)
                            {
                                Rubix.Screen.Report.rptRPT019_ReceivingQRCode rcvLabelCover = new Rubix.Screen.Report.rptRPT019_ReceivingQRCode(BusinessClass.GetReportDefaultParams("RPT019"));
                                String header = BusinessClass.GetLabelHeader();
                                rcvLabelCover.SetParameterLabelHeader(header);
                                rcvLabelCover.DataSource = labelList;

                                if (rpt != null)
                                    rpt = ReportUtil.CombineReport(rpt, rcvLabelCover);
                                else
                                {
                                    rpt = rcvLabelCover;
                                    rpt.CreateDocument();
                                }
                            }
                            labelList.Clear();
                        }
                    }

                    if (rpt != null)
                    {
                        CloseWaitScreen();
                        ReportUtil.ShowPreview(rpt);
                    }
                    else
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));

                }
                else
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message.ToString());
            }
        }
        #endregion
        #endregion
        
        #region Generic Function
        private void OpenDialog(Common.eScreenMode ScreenMode)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if ((grdSearchResult.DefaultView).DataRowCount == 0 && ScreenMode != Common.eScreenMode.Add)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                }
                else
                {
                    if (ScreenMode != Common.eScreenMode.Add)
                    {
                        BusinessClass.SelectData = gdvSearchResult.GetFocusedRow();
                    }

                    if (BusinessClass.LocationCodeTo != null)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0215"));
                    }
                    else
                    {
                        Dialog.BusinessClass = BusinessClass;
                        Dialog.IdleValidatorControl = iv;
                        Dialog.ScreenMode = ScreenMode;

                        if (Dialog.ShowDialog(this) == DialogResult.OK)
                        {
                            DataLoading();
                            MessageDialog.ShowInformationMsg(Rubix.Screen.Common.GetMessage("I0003"));
                        }
                        Dialog = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);                
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                iv.ClearTicket();

                grdSearchResult.DataSource = BusinessClass.DataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, null
                                                                        , zoneControl.ZoneID, itemControl.ProductID, itemConditionControl.ProductConditionID
                                                                        ,null, null, txtLotNo.Text.Trim());
                
                for (int i = 0; i < gdvSearchResult.RowCount; i++)
                {
                    DateTime? lastUpdate;
                    if (gdvSearchResult.GetRowCellValue(i, "LastUpdateSince") == DBNull.Value)
                        lastUpdate = null;
                    else
                        lastUpdate = (DateTime?)gdvSearchResult.GetRowCellValue(i, "LastUpdateSince");

                    iv.PushTicket(lastUpdate, gdvSearchResult.GetRowCellValue(i, "OwnerID").ToString()
                        , gdvSearchResult.GetRowCellValue(i, "WarehouseID").ToString()
                        , gdvSearchResult.GetRowCellValue(i, "LocationID").ToString()
                        , gdvSearchResult.GetRowCellValue(i, "ProductID").ToString()
                        , gdvSearchResult.GetRowCellValue(i, "ProductConditionID").ToString()
                        , gdvSearchResult.GetRowCellValue(i, "PalletNo").ToString());
                }

                gdvSearchResult.OptionsBehavior.Editable = true;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                base.GridViewOnChangeLanguage(grdSearchResult);
                this.CloseWaitScreen();                
            }
        }

        private void SetSelectColumn(bool select)
        {
            ShowWaitScreen();
            gdvSearchResult.ClearSorting();

            for (int rowIndex = 0; rowIndex < gdvSearchResult.RowCount; rowIndex++)
            {
                gdvSearchResult.SetRowCellValue(rowIndex, gdcSelect, select);
            }
            CloseWaitScreen();
        }
        
        private bool ValidateSearchCriteria()
        {
            errorProvider.ClearErrors();
            bool validate = true;

            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            if (!ownerControl.ValidateControl())
            {
                validate = false;
            }
            if (!warehouseControl.ValidateControl())
            {
                validate = false;
            }

            return validate;
        }
        #endregion

    }
}
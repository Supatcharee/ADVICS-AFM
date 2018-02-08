/*
 * 18 Jan 2013: 
 * 1. modify gdvSearchResult_ShowingEditor event
 * 23 Jan 2013: 
 * 1. filter shipment status
 * 30 Jan 2013:
 * 1. add validate transaction date
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
using System.Data.SqlClient;

namespace Rubix.Screen.Form.Operation.G_StockControl
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Confirm, Permission.Edit, Permission.Export)]
    public partial class frmGSCS010_StockControl : FormBase
    {
        #region Member
        private StockControl db;
        private Dialog.dlgGSCS012_StockControlDetail m_DialogEdit;
        private Boolean bPickingDateIsRequired = false;
        #endregion

        #region Constant
        const string DATE_EDIT_FORMAT = "dd/MM/yyyy";
        #endregion

        #region Enumeration
        private enum eColStockControl
        {
             Select
            ,StockOut
			,ShipmentNo
			,PickingNo
			,PortOfLoadingCode
			,PortOfLoadingName
			,PortOfDischargeCode
			,PortOfDischargeName
			,PickingDate
			,NumberOfDetails
            , DeliveryDate
        }
        private enum eColStockControlData
        {
            Select
            ,StockOut
			,ShipmentNo
			,PickingNo
            ,WarehouseID
            ,OwnerID
			,PortOfLoadingID
			,PortOfLoadingCode
			,PortOfLoadingName
			,PortOfDischargeID
			,PortOfDischargeCode
			,PortOfDischargeName
			,FinalDestinationID
			,FinalDestinationCode
			,FinalDestinationName
			,PickingDate
			,NumberOfDetails
            ,DeliveryDate
			,SumAssignQtyFromShipping
            ,SumQuantityFromStockByLocation
        }
        
        #endregion

        #region Properties
        private StockControl BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new StockControl();
                }
                return db;
            }
        }
        private Dialog.dlgGSCS012_StockControlDetail DialogEdit
        {
            get
            {
                if (m_DialogEdit == null)
                {
                    return m_DialogEdit = new Dialog.dlgGSCS012_StockControlDetail();
                }
                return m_DialogEdit;
            }
            set
            {
                m_DialogEdit = value;
            }
        }
        
        #endregion
        
        #region Constructor
        public frmGSCS010_StockControl()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarDelete, m_toolBarCancel, m_toolBarRefresh, q_toolBarAdd, q_toolBarDelete,m_toolBarView, m_toolBarSave);
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl1);
            //m_toolBarSave.Caption = "Book Stock";           
            //m_toolBarSave.Glyph = imageList1.Images[0];
            dtPickingDateFrom.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtPickingDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingDateFrom.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtPickingDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtPickingDateFrom.Properties.Mask.EditMask = Common.FullDateFormat;

            dtPickingDateTo.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtPickingDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingDateTo.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtPickingDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtPickingDateTo.Properties.Mask.EditMask = Common.FullDateFormat;
                        
            m_toolBarBookStock.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }
        #endregion

        #region Event Handler Function
        private void frmGSCS010_StockControl_Load(object sender, EventArgs e)
        {
            try
            {
                m_toolBarConfirm.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                InitGrid();
                InitControl();
                dtPickingDateFrom.EditValue = ControlUtil.GetStartDate();
                dtPickingDateTo.EditValue = ControlUtil.GetEndDate();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    DataLoading();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());

            }
        }       

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());

            }
        }

        private void gdvSearchResult_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            
            if (e.RowHandle >= 0)
            {
                string SumQtyLocation = View.GetRowCellValue(e.RowHandle, eColStockControlData.SumQuantityFromStockByLocation.ToString()).ToString();
                string SumQtyInstruction = View.GetRowCellValue(e.RowHandle, eColStockControlData.SumAssignQtyFromShipping.ToString()).ToString();
                if (Convert.ToDecimal(SumQtyLocation) < Convert.ToDecimal(SumQtyInstruction))
                {
                    e.Appearance.BackColor = Color.DarkOrange;
                    //View.SetRowCellValue(e.RowHandle, gdvSearchResult.Columns[1], 1);
                    //View.SetRowCellValue(e.RowHandle, gdvSearchResult.Columns[(int)eColStockControl.StockOut], "Stock Out");                    
                }
            }
        }

        private void repCheckEdit_EditValueChanged(object sender, EventArgs e)
        {
            gdvSearchResult.PostEditor();
        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            warehouseControl.OwnerID = ownerControl.OwnerID;
            warehouseControl.DataLoading();

            customerControl.OwnerID = ownerControl.OwnerID;
            customerControl.DataLoading();

            shipmentControl.OwnerID = ownerControl.OwnerID;
            shipmentControl.DataLoading();

            finalDestinationControl.OwnerID = ownerControl.OwnerID;
            finalDestinationControl.DataLoading();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SetSelectColumn(true);
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            SetSelectColumn(false);
        }

        private void gdvSearchResult_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView View = sender as GridView;

            // 18 Jan 2013: comment and change method
            //string SumQtyLocation = View.GetRowCellValue(View.GetRowHandle(0), eColStockControlData.SumQuantityFromStockByLocation.ToString()).ToString();
            //string SumQtyInstruction = View.GetRowCellValue(View.GetRowHandle(0), eColStockControlData.SumAssignQtyFromShipping.ToString()).ToString();
            string SumQtyLocation = View.GetFocusedRowCellValue(eColStockControlData.SumQuantityFromStockByLocation.ToString()).ToString();
            string SumQtyInstruction = View.GetFocusedRowCellValue(eColStockControlData.SumAssignQtyFromShipping.ToString()).ToString();
            // end 18 Jan 2013: comment and change method
            if (Convert.ToDecimal(SumQtyLocation) < Convert.ToDecimal(SumQtyInstruction))
            {
                e.Cancel = true;
            }
        }

        private void shippingCustomerControl1_EditValueChanged(object sender, EventArgs e)
        {
            finalDestinationControl.CustomerID = customerControl.CustomerID;
            finalDestinationControl.DataLoading();
        }
        #endregion

        #region Override Method
        public override bool OnCommandEdit()
        {
            try
            {
                OpenDialog(Common.eScreenMode.Edit);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            } 
        }
        public override bool OnCommandBookStock()
        {
            try
            {
                // Edit by Chalermchai : 11/23/2012
                // Edit check spread to have data to book
                if (grdSearchResult.DataSource == null || grdSearchResult.DefaultView.RowCount == 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0233"));
                    return false;
                }

                if ((sp_GSCS010_StockControlProcess_SearchAll_Result)gdvSearchResult.GetFocusedRow() == null)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                    return false;
                }

                // 30 Jan 2013: add validate on save
                if (true == ValidateOnSave())
                {
                    if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0097"), BusinessClass.ShipmentNo)) == DialogButton.Yes)
                    {
                        try
                        {
                            SaveData();
                            DialogResult = DialogResult.OK;
                        }
                        catch (Exception ex)
                        {
                            if (ex.InnerException != null)
                            {
                                if (ex.InnerException is SqlException && ((SqlException)ex.InnerException).Number == 50002)
                                {
                                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0273"));
                                }
                                else if (ex.InnerException is SqlException && ((SqlException)ex.InnerException).Number == 50003)
                                {
                                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                                }
                                else
                                    MessageDialog.ShowSystemErrorMsg(this, ex);

                            }
                            else
                                MessageDialog.ShowSystemErrorMsg(this, ex);
                        }
                        ReDataLoading();
                        return true;
                    }
                }
                // end 30 Jan 2013
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
        }
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
                    DialogEdit.ScreenMode = ScreenMode;
                    DialogEdit.BusinessClass = BusinessClass;

                    if (DialogEdit.ShowDialog(this) == DialogResult.OK)
                    {
                        DataLoading();
                        MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), DialogEdit.BusinessClass.ShipmentNo));
                    }
                    DialogEdit = null;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
                //return false;
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
                // 13 Feb 2013: add wait screen
                //this.ShowWaitScreen();
                this.ShowWaitScreen();
                // end 13 Feb 2013
                List<sp_GSCS010_StockControlProcess_SearchAll_Result> data = BusinessClass.DataLoading(ownerControl.OwnerID
                                                                                                        , warehouseControl.WarehouseID
                                                                                                        , shipmentControl.ShipmentNo == string.Empty ? null:shipmentControl.ShipmentNo
                                                                                                        , dtPickingDateFrom.DateTime
                                                                                                        , dtPickingDateTo.DateTime
                                                                                                        , finalDestinationControl.GetFinalDestinationID
                                                                                                        , customerControl.CustomerID);
                if (data.Count == 0)
                {
                    //this.CloseWaitScreen();
                    grdSearchResult.DataSource = null;
                    grdSearchResult.RefreshDataSource();
                    // 13 Feb 2013: add wait screen
                    this.CloseWaitScreen();
                    // end 13 Feb 2013
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                }
                else
                {
                    grdSearchResult.DataSource = data;
                    InitGrid();
                }
                for (int i = 0; i < gdvSearchResult.Columns.Count; i++)
                {
                    if (gdvSearchResult.Columns[i].ColumnType == typeof(DateTime) || gdvSearchResult.Columns[i].ColumnType == typeof(DateTime?))
                    {
                        gdvSearchResult.Columns[i].DisplayFormat.FormatString = Common.FullDatetimeFormat;
                        gdvSearchResult.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    }
                }
                // 13 Feb 2013: add wait screen
                this.CloseWaitScreen();
                // end 13 Feb 2013

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // 13 Feb 2013: add wait screen
                //this.CloseWaitScreen();
                this.CloseWaitScreen();
                // end 13 Feb 2013
            }
        }

        private void ReDataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                List<sp_GSCS010_StockControlProcess_SearchAll_Result> data = BusinessClass.DataLoading(ownerControl.OwnerID
                                                                                                        , warehouseControl.WarehouseID
                                                                                                        , shipmentControl.ShipmentNo == string.Empty ? null : shipmentControl.ShipmentNo
                                                                                                        , dtPickingDateFrom.DateTime
                                                                                                        , dtPickingDateTo.DateTime
                                                                                                        , finalDestinationControl.GetFinalDestinationID
                                                                                                        , customerControl.CustomerID);
                grdSearchResult.DataSource = data;
                InitGrid();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                this.CloseWaitScreen();
            }
        } 

        private Boolean ValidateData()
        {
            Boolean noError = true;
            string messageId = string.Empty;

            // set require field
            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;
            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;
            
            if (false == ownerControl.ValidateControl())
            {
                noError = false;
            }
            //if (false == customerControl.ValidateControl())
            //{
            //    noError = false;
            //}
            if (false == warehouseControl.ValidateControl())
            {
                noError = false;
            }
            if (bPickingDateIsRequired && (dtPickingDateFrom.EditValue == null || dtPickingDateTo.EditValue == null))
            {
                errorProvider.SetError(dtPickingDateFrom, Common.GetMessage("I0320"));
                noError = false;
            }
            else
            {
                errorProvider.SetError(dtPickingDateFrom, string.Empty);
            }
            return noError;
        }
        // 30 Jan 2013: add validate transaction date
        private Boolean ValidateOnSave()
        {
            Boolean noError = true;
            //List<sp_GSCS010_StockControlProcess_SearchAll_Result> temp = (List<sp_GSCS010_StockControlProcess_SearchAll_Result>)grdSearchResult.DataSource;
            //foreach (sp_GSCS010_StockControlProcess_SearchAll_Result item in temp)
            //{
            //    if (item.Select == true)
            //    {
            //        if (false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(item.DeliveryDate, true))
            //        {
            //            MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0236"));
            //            return false;
            //        }
            //        if (false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(item.PickingDate, true))
            //        {
            //            MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0236"));
            //            return false;
            //        }
            //    }
            //}

            sp_GSCS010_StockControlProcess_SearchAll_Result item = (sp_GSCS010_StockControlProcess_SearchAll_Result)gdvSearchResult.GetFocusedRow();
            if (item == null)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0233"));
                return false;
            }
            if (item.StockOut.Trim().Length > 0)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0273"));
                return false;
            }

            if (false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(item.DeliveryDate, true))
            {
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0236"));
                return false;
            }
            if (false == CSI.Business.Common.DateValidator.IsTrancyValidTransactionDate(item.PickingDate, true))
            {
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0236"));
                return false;
            }
            return noError;
        }
        // end 30 Jan 2013
        private void InitControl()
        {            
            //customerControl.RequireField = true;
            bPickingDateIsRequired = true;
            // set dateEdit format

            dtPickingDateFrom.Properties.Mask.EditMask = DATE_EDIT_FORMAT;
            dtPickingDateTo.Properties.Mask.EditMask = DATE_EDIT_FORMAT;
            dtPickingDateFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtPickingDateTo.Properties.Mask.UseMaskAsDisplayFormat = true;

            // 23 Jan 2013: filter status
            shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusId();
            shipmentControl.DataLoading();
            // end 23 Jan 2013: filter status
        }

        private void InitGrid()
        {
            // set enable all columns first
            ControlUtil.SetBestWidth(gdvSearchResult);
            gdvSearchResult.OptionsBehavior.Editable = true;
            string[] columnNames = Enum.GetNames(typeof(eColStockControl));
            Select.OptionsColumn.AllowEdit = true;

        }

        private void SaveData()
        {
            //sp_GSCS010_StockControlProcess_SearchAll_Result item = (sp_GSCS010_StockControlProcess_SearchAll_Result)gdvSearchResult.GetFocusedRow();
            //BusinessClass.SaveBookStockData(item.ShipmentNo.ToString()
            //                                , item.PickingNo.ToString()
            //                                , Rubix.Framework.DataUtil.Convert<int>(item.WarehouseID)
            //                                , Rubix.Framework.DataUtil.Convert<int>(item.OwnerID));
            //MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0099")));
        }
        
        private void ClearAll()
        {            
            ownerControl.ClearData();
            shipmentControl.ClearData();
            customerControl.ClearData();
            warehouseControl.ClearData();
            warehouseControl.OwnerID = ownerControl.OwnerID;
            warehouseControl.DataLoading();
            finalDestinationControl.ClearData();
            finalDestinationControl.OwnerID = ownerControl.OwnerID;
            finalDestinationControl.CustomerID = customerControl.CustomerID;
            finalDestinationControl.DataLoading();
            ControlUtil.ClearControlData(dtPickingDateTo, dtPickingDateFrom);
            grdSearchResult.DataSource = null;
            errorProvider.ClearErrors();
        }

        private void SetSelectColumn(bool select)
        {
            Boolean noError = true;
            for (int rowIndex = 0; rowIndex < gdvSearchResult.RowCount; rowIndex++)
            {
                sp_GSCS010_StockControlProcess_SearchAll_Result data = (sp_GSCS010_StockControlProcess_SearchAll_Result)gdvSearchResult.GetRow(rowIndex);
                if (data.ShipmentNo != null)
                {
                    if (string.IsNullOrWhiteSpace(data.StockOut))
                        gdvSearchResult.SetRowCellValue(rowIndex, gdvSearchResult.Columns[(int)eColStockControl.Select], select);
                }
                else
                    noError = false;
            }
            if (noError == false)
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0107"));
        }
        #endregion      
        
    }
}
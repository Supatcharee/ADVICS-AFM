using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using CSI.Business.Operation;
using DevExpress.XtraReports.UI;
using Rubix.Framework;
using CSI.Business.DataObjects;
using DevExpress.XtraGrid.Views.Grid;
using CSI.Business.BusinessFactory.Report;
using System.Linq;
using System.Data;

namespace Rubix.Screen.Form.Operation.H_Picking
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Export, Permission.Print, Permission.Confirm)]
    public partial class frmHPCS010_PickingInstruction : FormBase
    {

        #region Member
        private PickingInstruction db;
        private StockControl dbStock;
        private Dialog.dlgHPCS011_ReprintPickingList m_Dialog = null;
        #endregion

        #region Properties
        private PickingInstruction BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new PickingInstruction();
                }
                return db;
            }
        }

        private StockControl BusinessStockClass
        {
            get
            {
                if (dbStock == null)
                {
                    dbStock = new StockControl();
                }
                return dbStock;
            }
        }
        private Dialog.dlgHPCS011_ReprintPickingList Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgHPCS011_ReprintPickingList();
                }
                return m_Dialog;
            }
            set
            {
                 m_Dialog = value;
            }
        }
        #endregion

        #region Enumeration
        private enum eColStockPicking
        {
             Select
			,PortOfLoadingID
			,PortOfLoadingCode
			,PortOfLoadingName
			,PortOfDischargeID
			,PortOfDischargeCode
			,PortOfDischargeName
			,FinalDestinationID
			,FinalDestinationCode
			,FinalDestinationName
			,ShipmentNo
			,PickingNo
			,NumberOfDetails
			,StockOutControlFlag
        }
        private enum eColStockPickingView
        {
             Select			
			,PortOfLoadingCode
			,PortOfLoadingName
			,PortOfDischargeCode
			,PortOfDischargeName
			,ShipmentNo
			,PickingNo
			,NumberOfDetails
        }
        #endregion

        #region Constructor
        public frmHPCS010_PickingInstruction()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarView, m_toolBarRefresh, m_toolBarDelete, m_toolBarCancel, m_toolBarEdit, m_toolBarSave, m_toolBarConfirm);

            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(grpControl);

            dtpDeliveryFrom.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtpDeliveryFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtpDeliveryFrom.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtpDeliveryFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtpDeliveryFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtpDeliveryFrom.Properties.Mask.EditMask = Common.FullDateFormat;

            dtpDeliveryTo.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtpDeliveryTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtpDeliveryTo.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtpDeliveryTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtpDeliveryTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtpDeliveryTo.Properties.Mask.EditMask = Common.FullDateFormat;

            customerControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusId();
            shipmentControl.OwnerID = Common.GetDefaultOwnerID();
            pickingControl.ShipmentNo = "-1";

            dtpDeliveryFrom.EditValue = ControlUtil.GetStartDate();
            dtpDeliveryTo.EditValue = ControlUtil.GetEndDate();

            
        }
        #endregion

        #region Override Method 
        public override bool OnCommandCancel()
        {
            try
            {
                InitControl(Common.eScreenMode.View);
                SetSelectColumn(false);
                EnableCheckbok(false);
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        public override bool OnCommandEdit()
        {
             try
             {
                 InitControl(Common.eScreenMode.Edit);
                 EnableCheckbok(true);
                 return true;
             }
             catch (Exception ex)
             {
                 MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                 return false;
             }
        }
        public override bool OnCommandConfirm()
        {
            try
            {
                gdvSearchResult.PostEditor();
                if (checkSelect())
                {
                    if (checkStockOut())
                    {
                        if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0101"))) == DialogButton.Yes)
                        {
                            if(checkStatus())
                            {
                                ShowWaitScreen();
                                printData();
                                DataLoading();
                                InitControl(Common.eScreenMode.View);
                                EnableCheckbok(false);
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0153"));
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
            finally
            {
                CloseWaitScreen();
            }
        }
    #endregion

        #region Event Handler Function
        private void frmHPCS010_PickingInstruction_Load(object sender, EventArgs e)
        {
            try
            {
                btnReprint.Visible = base.CanPrint;
                ControlUtil.HiddenControl(true, m_toolBarPrint);

                InitControl(Common.eScreenMode.View);


            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
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

        private void repChkEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gdvSearchResult.PostEditor();
                sp_HPCS010_PickingInstruction_Search_Result dr = gdvSearchResult.GetFocusedRow() as sp_HPCS010_PickingInstruction_Search_Result;
                List<sp_HPCS010_PickingInstruction_Search_Result> DataSource = grdSearchResult.DataSource as List<sp_HPCS010_PickingInstruction_Search_Result>;
                List<sp_HPCS010_PickingInstruction_Search_Result> DataSelect = DataSource.Where(c => c.PickingNo == dr.PickingNo).ToList();
                foreach (sp_HPCS010_PickingInstruction_Search_Result r in DataSelect)
                {
                    r.Select = dr.Select;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message.ToString());
            }
        }

        private void gdvSearchResult_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            string StockOutControlFlag = string.Empty;
            if (e.RowHandle >= 0)
            {
                if(View.GetRowCellValue(e.RowHandle, eColStockPicking.StockOutControlFlag.ToString()) != null)
                {
                    StockOutControlFlag = View.GetRowCellValue(e.RowHandle, eColStockPicking.StockOutControlFlag.ToString()).ToString();
                }                
                if (StockOutControlFlag == "True")
                {
                    e.Appearance.BackColor = Common.StockOutColor();
                }
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
                    customerControl.OwnerID = ownerControl.OwnerID;
                    customerControl.DataLoading();
                    shipmentControl.OwnerID = ownerControl.OwnerID;
                    shipmentControl.DataLoading();
                    pickingControl.ShipmentNo = "-1";
                    pickingControl.DataLoading();
                }
                else
                {
                    customerControl.OwnerID = Common.GetDefaultOwnerID();
                    customerControl.DataLoading();
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                    shipmentControl.DataLoading();
                    pickingControl.ShipmentNo = "-1";
                    pickingControl.DataLoading();
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                shipmentControl.CustomerID = customerControl.CustomerID;
                shipmentControl.DataLoading();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void shipmentControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (ownerControl.OwnerID != null)
                {
                    pickingControl.ShipmentNo = shipmentControl.ShipmentNo;
                    pickingControl.DataLoading();
                }
                else
                {
                    pickingControl.ShipmentNo = "-1";
                    pickingControl.DataLoading();
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void dtpDeliveryFrom_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                shipmentControl.ShippingDateFrom = dtpDeliveryFrom.DateTime;
                shipmentControl.DataLoading();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void dtpDeliveryTo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                shipmentControl.ShippingDateTo = dtpDeliveryTo.DateTime;
                shipmentControl.DataLoading();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            try
            {
                OpenDialog();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SetSelectColumn(true);
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            SetSelectColumn(false);
        }

        private void gdvSearchResult_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sp_HPCS010_PickingInstruction_Search_Result row = gdvSearchResult.GetFocusedRow() as sp_HPCS010_PickingInstruction_Search_Result;
            if (row != null)
            {
                if (row.StockOut == "Stock Out")
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion
        
        #region Generic Function
        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                grdSearchResult.DataSource = BusinessClass.DataLoading(ownerControl.OwnerID
                                                                       ,warehouseControl.WarehouseID
                                                                       ,shipmentControl.ShipmentNo
                                                                       ,pickingControl.PickingNo
                                                                       ,customerControl.CustomerID
                                                                       , DataUtil.Convert<DateTime>(dtpDeliveryFrom.EditValue)
                                                                       , DataUtil.Convert<DateTime>(dtpDeliveryTo.EditValue)
                                                                       ,txtInvoiceNo.Text);

                if (gdvSearchResult.RowCount == 0)
                {
                    ControlUtil.HiddenControl(true, m_toolBarConfirm);
                }
                else
                {
                    ControlUtil.HiddenControl(false, m_toolBarConfirm);
                }
                base.GridViewOnChangeLanguage(grdSearchResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseWaitScreen();
            }
        }
    
        private void InitControl(Common.eScreenMode ScreenMode)
        {
            btnSelectAll.Enabled = true;
            btnUnselectAll.Enabled = true;
            gdvSearchResult.OptionsBehavior.Editable = true;   
        }       

        private void ClearAll()
        {
            ownerControl.ClearData();

            customerControl.OwnerID = Common.GetDefaultOwnerID();
            customerControl.DataLoading();
            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();
            shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusId();
            shipmentControl.OwnerID = Common.GetDefaultOwnerID();
            shipmentControl.DataLoading();
            pickingControl.ShipmentNo = "-1";
            pickingControl.DataLoading();

            dtpDeliveryFrom.EditValue = ControlUtil.GetStartDate();
            dtpDeliveryTo.EditValue = ControlUtil.GetEndDate();

            grdSearchResult.DataSource = null;
            errorProvider.ClearErrors();
        }

        private void EnableCheckbok(bool status)
        {
            // set enable all columns first
            ControlUtil.SetBestWidth(gdvSearchResult);
            gdvSearchResult.OptionsBehavior.Editable = true;
            string[] columnNames = Enum.GetNames(typeof(eColStockPickingView));
            Select.OptionsColumn.AllowEdit = true;
        }

        private void SetSelectColumn(bool select)
        {
            try
            {
                ShowWaitScreen();
                for (int rowIndex = 0; rowIndex < gdvSearchResult.RowCount; rowIndex++)
                {
                    sp_HPCS010_PickingInstruction_Search_Result row = gdvSearchResult.GetRow(rowIndex) as sp_HPCS010_PickingInstruction_Search_Result;
                    if (row.StockOut != "Stock Out")
                    {
                        gdvSearchResult.SetRowCellValue(rowIndex, gdvSearchResult.Columns[(int)eColStockPickingView.Select], select);
                    }
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        
        private void printData()
        {
            List<sp_HPCS010_PickingInstruction_Search_Result> temp = ((List<sp_HPCS010_PickingInstruction_Search_Result>)grdSearchResult.DataSource).Where(c => c.Select == true).ToList();
            //PickingListReport dalReport = new PickingListReport();

            //XtraReport mainReport = null;
            
            // Loop all selected data and combine into one data.
            foreach (sp_HPCS010_PickingInstruction_Search_Result item in temp)
            {
                updateStatus(item.ShipmentNo, item.PickingNo, item.LineNo);

                //Advics ไม่ได้ใช้ เลย comment ออกไปก่อน
                ////Print function
                //List<sp_RPT021_PickingList_GetData_Result> dataReport = BusinessClass.GetDataReport(item.ShipmentNo, item.PickingNo);

                //if (dataReport.Count > 0)
                //{
                //    Rubix.Screen.Report.rptRPT021_PickingList tmpReport = new Rubix.Screen.Report.rptRPT021_PickingList(dalReport.GetReportDefaultParams("RPT021"));
                //    tmpReport.DataSource = dataReport;
                //    tmpReport.SetShipmentNoParameter(item.ShipmentNo);
                //    tmpReport.SetPickingNoParameter(item.PickingNo);
                //    tmpReport.SetTotalRecordParameter(dataReport.Count);
                //    tmpReport.SetPrintByParameter(AppConfig.Name);
                //    tmpReport.SubReportDatasource(BusinessClass.GetDataSubReport(dataReport));

                //    // Merge report
                //    if (mainReport == null)
                //        mainReport = tmpReport;
                //    else
                //    {
                //        mainReport = ReportUtil.CombineReport(mainReport, tmpReport);
                //    }
                //}                                
            }

            //// Show Report
            //if (mainReport != null)
            //    ReportUtil.ShowPreview(mainReport);
        }
        
        private void updateStatus(string shipmentNo,string pickingNo, int LineNo)
        {
            try
            {
                BusinessStockClass.SaveBookStockData(shipmentNo, pickingNo, warehouseControl.WarehouseID, ownerControl.OwnerID, LineNo);
                BusinessClass.UpdateStatusID(shipmentNo, pickingNo, LineNo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Boolean checkSelect()
        {
            bool chkSelect = false;
            List<sp_HPCS010_PickingInstruction_Search_Result> temp = ((List<sp_HPCS010_PickingInstruction_Search_Result>)grdSearchResult.DataSource).Where(c => c.Select == true).ToList();

            if (temp.Count() > 0)
            {
                chkSelect = true;
            }
            return chkSelect;
        }

        private Boolean checkStockOut()
        {
            Boolean checkStock = true;
            List<sp_HPCS010_PickingInstruction_Search_Result> temp = ((List<sp_HPCS010_PickingInstruction_Search_Result>)grdSearchResult.DataSource).Where(c=> c.Select == true && c.StockOut == "Stock Out").ToList();
            if (temp.Count() > 0)
            {
                 MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0273"));
                checkStock = false;
            }         
            return checkStock;
        }

        private void OpenDialog()
        {
            Cursor = Cursors.WaitCursor;
            try
            {

                if (Dialog.ShowDialog(this) == DialogResult.OK)
                {
                    DataLoading();
                    //MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), DialogEdit.BusinessClass.ShipmentNo));
                }
                Dialog = null;                
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

        private Boolean ValidateData()
        {
            errorProvider.ClearErrors();
            Boolean validate = true;
            // set require field
            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            //customerControl.ErrorText = Common.GetMessage("I0249");
            //customerControl.RequireField = true;

            validate &= ownerControl.ValidateControl();
            validate &= warehouseControl.ValidateControl();
            //if (false == customerControl.ValidateControl())
            //{
            //    noError = false;
            //}

            return validate;
        }

        public Boolean checkStatus()
        {
            bool chkStatus = false;
            List<sp_HPCS010_PickingInstruction_Search_Result> temp = ((List<sp_HPCS010_PickingInstruction_Search_Result>)grdSearchResult.DataSource).Where(c => c.Select == true).ToList();

            DataTable dt = new DataTable("DataTable");
            dt.Columns.Add("ShipmentNo", typeof(System.String));
            dt.Columns.Add("PickingNo", typeof(System.String));
            dt.Columns.Add("LineNo", typeof(System.Int32));

            foreach (sp_HPCS010_PickingInstruction_Search_Result item in temp)
            {
                DataRow dr = dt.NewRow();
                dr["ShipmentNo"] = item.ShipmentNo;
                dr["PickingNo"] = item.PickingNo;
                dr["LineNo"] = item.LineNo;
                dt.Rows.Add(dr);
            }
            DataSet RollbackDS = new DataSet("DataSet");
            
            RollbackDS.Tables.Add(dt);
            DataTable dtResult = BusinessClass.CheckStatus(RollbackDS.GetXml());

            int status = 65;

            DataRow row = dtResult.Rows[0];
            int rowValue = Convert.ToInt32(row["Column1"]);
            if (rowValue == status)
            { 
                chkStatus = true; 
            }
            else
            {
               MessageDialog.ShowBusinessErrorMsg(this, "Some Pallet(s) have been booked/picked. Please check again.");
               DataLoading();
               return false;
            }
            return chkStatus;
        }
        #endregion      

    }
}
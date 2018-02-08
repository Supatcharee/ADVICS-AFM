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
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;

namespace Rubix.Screen.Form.Operation.I_Shipping
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Edit, Permission.Confirm, Permission.Export)]
    public partial class frmISHS030_confirmShippingEntry : FormBase
    {
        #region Enumeration
        // Column order in grid
        //private enum eColumns 
        //{
        //     Select
        //    , PickingDate
        //    , ShipmentNo
        //    , PickingNo
        //    , LineNo
        //    , SortedLineNo
        //    , ProductCode
        //    , ProductName
        //    , ProductConditionCode
        //    , Qty
        //    , DefaultAssignQty
        //    , ProductID
        //    , ProductConditionID
        //    , UnitOfOrderQty
        //}

        #endregion

        #region Constant
        const int DEFAULT_INSTALLMENT = 1;
        #endregion

        #region Member
        private ConfirmShippingEntry  db;
        private Color backColorDefaultAssignQtyColumn = Color.Empty;
        private Color foreColorDefaultAssignQtyColumn = Color.Empty;
        private DataTable dtResultExportToAccpact = null;
        #endregion

        #region Properties
        private ConfirmShippingEntry BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ConfirmShippingEntry();
                }
                return db;
            }
        }
        private DataTable DtResultExportToAccpect
        {
            get
            {
                if (dtResultExportToAccpact == null)
                {
                    dtResultExportToAccpact = new DataTable();
                }
                return dtResultExportToAccpact;
            }
            set
            {
                dtResultExportToAccpact = value;
            }
        }
        public int? PalletQty { get; set; }
        public List<sp_ISHS030_ConfirmShipService_GetConfirmShip_Result> Datasource { get; set; }
        #endregion
        
        #region Constructor
        public frmISHS030_confirmShippingEntry()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarAdd, m_toolBarDelete, m_toolBarRefresh, m_toolBarCancel, m_toolBarSave);
            ControlUtil.HiddenControl(false, m_toolBarConfirm, m_toolBarEdit);

            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl1);

            dtPickingFrom.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtPickingFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingFrom.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtPickingFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtPickingFrom.Properties.Mask.EditMask = Common.FullDateFormat;

            dtPickingTo.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtPickingTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingTo.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtPickingTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtPickingTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtPickingTo.Properties.Mask.EditMask = Common.FullDateFormat;

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

            gdcPickingDate.DisplayFormat.FormatString = Common.FullDatetimeFormat;
            gdcPickingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
        }
        #endregion
        
        #region Override Method
        public override bool OnCommandCancel()
        {
            try
            {
                backColorDefaultAssignQtyColumn = Color.Empty;
                DataLoading();
                gdcShipQty.OptionsColumn.AllowEdit = false;
                gdvSearchResult.RefreshData();
                ControlUtil.HiddenControl(false, m_toolBarEdit);
                ControlUtil.HiddenControl(true, m_toolBarCancel);
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
            string messageId = string.Empty;
            try
            {
                List<sp_ISHS030_ConfirmShipService_GetConfirmShip_Result> list = GetData();
                ShowWaitScreen();
                bool result = BusinessClass.Save(list, ownerControl.OwnerID, warehouseControl.WarehouseID, DEFAULT_INSTALLMENT, out messageId, this.PalletQty);
                CloseWaitScreen();
                if (result == false)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage(messageId));
                }
                else
                {
                    MessageDialog.ShowInformationMsg(Common.GetMessage(messageId));
                }

                DataLoading();
                return true;

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    if (ex.InnerException is SqlException && ((SqlException)ex.InnerException).Number == 50005)
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0270"));
                    }
                    else
                    {
                        MessageDialog.ShowSystemErrorMsg(this, ex);
                    }

                }
                else
                {
                    MessageDialog.ShowSystemErrorMsg(this, ex);
                }
            }

            return false;

        }
        public override bool OnCommandEdit()
        {
            try
            {
                backColorDefaultAssignQtyColumn = Common.EditableCellColor();
                //DataLoading();
                if (gdvSearchResult.RowCount != 0)
                {
                    gdcShipQty.OptionsColumn.AllowEdit = true;
                    gdcShipQty.ColumnEdit = defaultAssignQtyTextEdit;
                }
                gdvSearchResult.RefreshData();
                ControlUtil.HiddenControl(true, m_toolBarEdit);
                ControlUtil.HiddenControl(false, m_toolBarCancel);

                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
                return false;
            }
        }
        #endregion

        #region Event Handler Function
        private void frmISHS030_ConfirmShippingEntry_Load(object sender, EventArgs e)
        {
            try
            {
                dtpDeliveryFrom.EditValue = ControlUtil.GetStartDate();
                dtpDeliveryTo.EditValue = ControlUtil.GetEndDate();
                dtPickingFrom.EditValue = ControlUtil.GetStartDate();
                dtPickingTo.EditValue = ControlUtil.GetEndDate();

                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();
                shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusId();
                shipmentControl.DataLoading();
                pickingControl.ShipmentNo = "-1";
                pickingControl.DataLoading();
                shippingAreaControl.WarehouseID = Common.GetDefaultWarehouseID();
                shippingAreaControl.DataLoading();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateDataWhenSearch())
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

        private void gdvSearchResult_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                // validate qty
                if (e.Column ==  gdcShipQty)
                {
                    sp_ISHS030_ConfirmShipService_GetConfirmShip_Result data
                        = (sp_ISHS030_ConfirmShipService_GetConfirmShip_Result) gdvSearchResult.GetFocusedRow();
                    string messageId = string.Empty;
                    BusinessClass.ValidateActualQty(data, out messageId);
                    if (messageId != string.Empty)
                    {
                        string errorText = Common.GetMessage(messageId);
                        MessageDialog.ShowBusinessErrorMsg(this, errorText);
                        //e.ErrorText = errorText;
                        //e.Valid = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void gdvSearchResult_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    // set backcolor
                    if (e.Column == gdcShipQty)
                    {
                        e.Appearance.BackColor = backColorDefaultAssignQtyColumn;
                    }
                }
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
                    customerControl.OwnerID = ownerControl.OwnerID;
                    customerControl.DataLoading();
                    shipmentControl.OwnerID = ownerControl.OwnerID;
                    shipmentControl.DataLoading();
                    pickingControl.ShipmentNo = "-1";
                    pickingControl.DataLoading();
                }
                else
                {
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    customerControl.OwnerID = Common.GetDefaultOwnerID();
                    customerControl.DataLoading();
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
                if (!string.IsNullOrEmpty(shipmentControl.ShipmentNo))
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

        private void warehouseControl_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (warehouseControl.WarehouseID != null)
                {
                    shippingAreaControl.WarehouseID = warehouseControl.WarehouseID;
                    shippingAreaControl.DataLoading();
                }
                else
                {
                    shippingAreaControl.WarehouseID = Common.GetDefaultWarehouseID();
                    shippingAreaControl.DataLoading();
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void dtPickingFrom_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                shipmentControl.PickDateFrom = DataUtil.Convert<DateTime>(dtPickingFrom.EditValue);
                shipmentControl.DataLoading();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void dtPickingTo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                shipmentControl.PickDateTo = DataUtil.Convert<DateTime>(dtPickingTo.EditValue);
                shipmentControl.DataLoading();
                shipmentControl.ClearData();
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
                shipmentControl.ShippingDateFrom = DataUtil.Convert<DateTime>(dtPickingFrom.EditValue);
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
                shipmentControl.ShippingDateTo = DataUtil.Convert<DateTime>(dtPickingTo.EditValue);
                shipmentControl.DataLoading();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void chkSelect_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                sp_ISHS030_ConfirmShipService_GetConfirmShip_Result rec = (sp_ISHS030_ConfirmShipService_GetConfirmShip_Result) gdvSearchResult.GetFocusedRow();
                e.Cancel = !(rec.StatusID >= CSI.Business.Common.Status.CompletePacking && rec.StatusID <= CSI.Business.Common.Status.InCompleteShipping);
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnExportDataToACCPACT_Click(object sender, EventArgs e)
        {
            try
            {
                if (DtResultExportToAccpect != null && DtResultExportToAccpect.Rows.Count > 0)
                {

                    grdExportResult.DataSource = DtResultExportToAccpect;

                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.AddExtension = true;
                    saveFile.CheckPathExists = true;
                    saveFile.DefaultExt = "xlsx";
                    saveFile.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls";

                    saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            // 18 Jan 2013: expand excel column size
                            gdvExportResult.OptionsPrint.AutoWidth = false;
                            gdvExportResult.BestFitColumns();
                            gdvExportResult.OptionsPrint.PrintHeader = gdvExportResult.OptionsView.ShowColumnHeaders;

                            // end 18 Jan 2013: expand excel column size
                            if (saveFile.FilterIndex == 1)
                            {
                                gdvExportResult.ExportToXlsx(saveFile.FileName);
                            }
                            else if (saveFile.FilterIndex == 2)
                            {
                                gdvExportResult.ExportToXls(saveFile.FileName);
                            }
                            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                            excel.Visible = true;
                            excel.Workbooks.Open(saveFile.FileName);
                            Rubix.Framework.ControlUtil.SetBestWidth(gdvExportResult);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, ex.Message, ex.ToString());
                        }
                    }
                }
                else
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0333"));
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
        }

        private void chkShippingCompleted_EditValueChanged(object sender, EventArgs e)
        {
            ControlUtil.EnableControl(!chkShippingCompleted.Checked, m_toolBarConfirm, m_toolBarEdit);
            if (chkShippingCompleted.Checked)
            {
                shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusIdForShippingComplete();
                shipmentControl.DataLoading();
            }
            else
            {
                shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusId();
                shipmentControl.DataLoading();
            }
            grdSearchResult.DataSource = null;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SetSelectColumn(true);
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            SetSelectColumn(false);
        }


        #endregion
        
        #region Generic Function
        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                this.Datasource = BusinessClass.DataLoading(ownerControl.OwnerID
                                                            , warehouseControl.WarehouseID
                                                            , string.IsNullOrWhiteSpace(shipmentControl.ShipmentNo) ? null : shipmentControl.ShipmentNo
                                                            , pickingControl.PickingNo
                                                            , shippingAreaControl.ShippingAreaID
                                                            , DataUtil.Convert<DateTime>(dtpDeliveryFrom.EditValue), DataUtil.Convert<DateTime>(dtpDeliveryTo.EditValue)
                                                            , customerControl.CustomerID
                                                            , DataUtil.Convert<DateTime>(dtpDeliveryFrom.EditValue), DataUtil.Convert<DateTime>(dtpDeliveryTo.EditValue)
                                                            , chkShippingCompleted.Checked ? 1 : 0
                                                            , txtInvoiceNo.Text).ToList();
               // bs.DataSource = Datasource;
                grdSearchResult.DataSource = this.Datasource;

                DataSet PrototypeDS = new DataSet("ProductTypeDataSetResult");
                DataTable PrototypeDT = new DataTable("ProductTypeDataTableResult");
                PrototypeDT.Columns.Add("ProductType");
                PrototypeDT.Columns.Add("Display");

                PrototypeDT.Rows.Add("Part", (chkPart.Checked)? 1 : 0);
                PrototypeDT.Rows.Add("PackingMaterial", (chkPackingMaterial.Checked) ? 1 : 0);
                PrototypeDT.Rows.Add("ServicePart", (chkServicePart.Checked) ? 1 : 0);
                PrototypeDT.Rows.Add("AfterMarket", (chkAfterMarket.Checked) ? 1 : 0);
                

                PrototypeDS.Tables.Add(PrototypeDT);

                DataTable tmpLoading = BusinessClass.GetDataExportToAccpect(ownerControl.OwnerID
                                                            , warehouseControl.WarehouseID
                                                            , string.IsNullOrWhiteSpace(shipmentControl.ShipmentNo) ? null : shipmentControl.ShipmentNo
                                                            , pickingControl.PickingNo
                                                            , shippingAreaControl.ShippingAreaID
                                                            , DataUtil.Convert<DateTime>(dtPickingFrom.EditValue), DataUtil.Convert<DateTime>(dtPickingTo.EditValue)
                                                            , customerControl.CustomerID
                                                            , DataUtil.Convert<DateTime>(dtpDeliveryFrom.EditValue), DataUtil.Convert<DateTime>(dtpDeliveryTo.EditValue)
                                                            , chkShippingCompleted.Checked ? 1 : 0
                                                            , PrototypeDS.GetXml());
                DtResultExportToAccpect = tmpLoading.Clone();

                if (DtResultExportToAccpect.Columns["RecieveDate"] != null
                        && DtResultExportToAccpect.Columns["DeliveryDate"] != null)
                {
                    DtResultExportToAccpect.Rows.Clear();

                    DtResultExportToAccpect.Columns["RecieveDate"].DataType = typeof(DateTime);
                    DtResultExportToAccpect.Columns["DeliveryDate"].DataType = typeof(DateTime);
                }

                foreach (DataRow dr in tmpLoading.Rows)
                {

                    DtResultExportToAccpect.Rows.Add(dr.ItemArray);
                    //if (dr["RecieveDate"] == null || string.IsNullOrEmpty(dr["RecieveDate"].ToString()))
                    //{
                    //    dr["RecieveDate"] = DBNull.Value;
                    //}

                    //if (dr["DeliveryDate"] == null || string.IsNullOrEmpty(dr["DeliveryDate"].ToString()))
                    //{
                    //    dr["DeliveryDate"] = DBNull.Value;
                    //}


                }


                //DtResultExportToAccpect = BusinessClass.GetDataExportToAccpect(ownerControl.OwnerID
                //                                            , warehouseControl.WarehouseID
                //                                            , string.IsNullOrWhiteSpace(shipmentControl.ShipmentNo) ? null : shipmentControl.ShipmentNo
                //                                            , pickingControl.PickingNo
                //                                            , shippingAreaControl.ShippingAreaID
                //                                            , DataUtil.Convert<DateTime>(dtPickingFrom.EditValue), DataUtil.Convert<DateTime>(dtPickingTo.EditValue)
                //                                            , customerControl.CustomerID
                //                                            , DataUtil.Convert<DateTime>(dtpDeliveryFrom.EditValue), DataUtil.Convert<DateTime>(dtpDeliveryTo.EditValue)
                //                                            , chkShippingCompleted.Checked ? 1 : 0
                //                                            , PrototypeDS.GetXml());

                base.GridViewOnChangeLanguage(grdSearchResult);
                gdvSearchResult.OptionsBehavior.Editable = true;
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

        private void ClearAll()
        {
            ControlUtil.ClearControlData(this.Controls);
            dtpDeliveryFrom.EditValue = ControlUtil.GetStartDate();
            dtpDeliveryTo.EditValue = ControlUtil.GetEndDate();
            dtPickingFrom.EditValue = ControlUtil.GetStartDate();
            dtPickingTo.EditValue = ControlUtil.GetEndDate();

            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();
            customerControl.OwnerID = Common.GetDefaultOwnerID();
            customerControl.DataLoading();
            shipmentControl.OwnerID = Common.GetDefaultOwnerID();
            shipmentControl.StatusIdList = BusinessClass.GetSpecificStatusId();
            shipmentControl.DataLoading();
            pickingControl.ShipmentNo = "-1";
            pickingControl.DataLoading();
            chkShippingCompleted.Checked = false;
        }
        
        private Boolean ValidateDataWhenSearch() 
        {
            errorProvider.ClearErrors();
            Boolean validate = true;
            string messageId = string.Empty;

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
            if (true == validate && false == BusinessClass.CheckWorkMethod(ownerControl.OwnerID, warehouseControl.WarehouseID, out messageId))
            {
                validate = false;
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage(messageId));
            }

            if (dtpDeliveryFrom.EditValue == null)
            {
                errorProvider.SetError(dtpDeliveryFrom, Common.GetMessage("I0136"));
                validate = false;
            }
            if (dtpDeliveryTo.EditValue == null)
            {
                errorProvider.SetError(dtpDeliveryTo, Common.GetMessage("I0136"));
                validate = false;
            }

            return validate;
        }

        private List<sp_ISHS030_ConfirmShipService_GetConfirmShip_Result> GetData()
        {
            // force commit change
            this.ownerControl.Focus();

            // get only row checked

            List<sp_ISHS030_ConfirmShipService_GetConfirmShip_Result> Records
                = (List<sp_ISHS030_ConfirmShipService_GetConfirmShip_Result>)grdSearchResult.DataSource;

            List<sp_ISHS030_ConfirmShipService_GetConfirmShip_Result> selectedRecords = Records.Where(e => e.SELECT == true).ToList();


            return selectedRecords;
        }


        private void SetSelectColumn(bool select)
        {
            // 20 Feb 2013: clear sort before select all
            gdvSearchResult.ClearSorting();
            // end 20 Feb 2013
            Boolean noError = true;
            for (int rowIndex = 0; rowIndex < gdvSearchResult.RowCount; rowIndex++)
            {
                sp_ISHS030_ConfirmShipService_GetConfirmShip_Result data = (sp_ISHS030_ConfirmShipService_GetConfirmShip_Result)gdvSearchResult.GetRow(rowIndex);

                gdvSearchResult.SetRowCellValue(rowIndex, gdcSelect, select);

            }
            gdcSelect.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.Default;
            //if(noError == false)
            //    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0107"));
        }

        #endregion     


    }
}
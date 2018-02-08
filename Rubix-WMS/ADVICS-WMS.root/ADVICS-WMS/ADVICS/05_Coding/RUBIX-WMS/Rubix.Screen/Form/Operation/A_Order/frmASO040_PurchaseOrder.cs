﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CSI.Business.DataObjects;
using CSI.Business.Report;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Rubix.Framework;
using CSI.Business.Operation;
using CSI.Business.BusinessFactory.Common;
using Rubix.Screen.Report;


namespace Rubix.Screen.Form.Operation.A_Order
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Add, Permission.Edit, Permission.Delete, Permission.Export)]
    public partial class frmASO040_PurchaseOrder : FormBase
    {        
        #region Member
        private Dialog.dlgASO041_PurchaseOrder m_Dialog = null;
        private SalePurchaseOrder db;
        private PartDeliverySheetReport m_rptPartDeliverySheet = null;
        private RawMaterialTagReport m_rptRawMaterialTag = null;
        private DataTable dtChild;
        private DataTable dtParent;
        private bool isEdit = false;
        #endregion

        #region Properties
        private Dialog.dlgASO041_PurchaseOrder Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgASO041_PurchaseOrder();
                }
                return m_Dialog;
            }
            set
            {
                m_Dialog = value;
            }
        }
        private SalePurchaseOrder BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new SalePurchaseOrder();
                }
                return db;
            }
        }

        private PartDeliverySheetReport ReportBusiness
        {
            get
            {
                if (m_rptPartDeliverySheet == null)
                {
                    m_rptPartDeliverySheet = new PartDeliverySheetReport();
                }
                return m_rptPartDeliverySheet;
            }
        }

        private RawMaterialTagReport RMTagReportClass
        {
            get
            {

                if (m_rptRawMaterialTag == null)
                {
                    m_rptRawMaterialTag = new RawMaterialTagReport();
                }
                return m_rptRawMaterialTag;
            }
        }

        #endregion

        #region Constructor
        public frmASO040_PurchaseOrder()
        {
            InitializeComponent();
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel, m_toolBarRefresh);
            base.SetExpandGroupControl(groupControl1);

            iv = new IdleValidator("tbt_PurchaseOrderHeader", "UpdateDate", "PONo");
            
        }
        #endregion

        #region Override Method
        public override bool OnCommandAdd()
        {
            try
            {
                Dialog.CanEdit = true;
                OpenDialog(Common.eScreenMode.Add);
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
                return false;
            }
        }
        public override bool OnCommandSave()
        {
            try
            {
                GridView Mastergrv = ((GridView)(((GridView)grdSearchResult.Views[0]).GetDetailView(gdvSearchResult.FocusedRowHandle, 0)));
                if (Mastergrv != null)
                {
                    Mastergrv.CloseEditor();
                    Mastergrv.UpdateCurrentRow();
                }
                gdvSearchResult.CloseEditor();
                gdvSearchResult.UpdateCurrentRow();
                SaveData();
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
                return false;
            }
            finally
            {
                isEdit = false;
                for (int i = 0; i < grdSearchResult.Views[0].RowCount; i++)
                {
                    GridView grv = ((GridView)(((GridView)grdSearchResult.Views[0]).GetDetailView(i, 0)));
                    if (grv != null)
                    {
                        grv.OptionsBehavior.Editable = false;
                    }
                }
                gdvSearchResult.OptionsBehavior.Editable = false;
                DataLoading();
                ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel);
                ControlUtil.HiddenControl(false, m_toolBarEdit);
            }
        }

        public override bool OnCommandCancel()
        {
            try
            {
                isEdit = false;
                for (int i = 0; i < grdSearchResult.Views[0].RowCount; i++)
                {
                    GridView grv = ((GridView)(((GridView)grdSearchResult.Views[0]).GetDetailView(i, 0)));
                    if (grv != null)
                    {
                        grv.OptionsBehavior.Editable = false;
                    }
                }
                gdvSearchResult.OptionsBehavior.Editable = false;
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
                return false;
            }
            finally
            {
                DataLoading();
                ControlUtil.HiddenControl(true, m_toolBarSave, m_toolBarCancel);
                ControlUtil.HiddenControl(false, m_toolBarEdit);
            }

        }

        public override bool OnCommandView()
        {
            try
            {
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }

                OpenDialog(Common.eScreenMode.View);
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
                return false;
            }
        }
        public override bool OnCommandEdit()
        {
            
            try
            {
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }
                isEdit = true;
                //Dialog.CanEdit = true;
                if (CheckCanEditOrDelete())
                {
                    //OpenDialog(Common.eScreenMode.Edit);
                    //return true;
                    for (int i = 0; i < grdSearchResult.Views[0].RowCount; i++)
                    {
                        GridView grv = ((GridView)(((GridView)grdSearchResult.Views[0]).GetDetailView(i, 0)));
                        if (grv != null)
                        {
                            grv.OptionsBehavior.Editable = true;
                        }
                    }
                    gdvSearchResult.OptionsBehavior.Editable = true;
                    ControlUtil.HiddenControl(false, m_toolBarSave, m_toolBarCancel);
                    ControlUtil.HiddenControl(true, m_toolBarEdit);
                    
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
                return false;
            }
        }
        public override bool OnCommandDelete()
        {
            try
            {
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return false;
                }

                DataRow data = gdvSearchResult.GetFocusedDataRow();

                if (!iv.ValidateTicket(data["PONo"].ToString()))
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                    return false;
                }
                isEdit = false;
                if (CheckCanEditOrDelete())
                {
                    if (MessageDialog.ShowConfirmationMsg(this, String.Format(Rubix.Screen.Common.GetMessage("I0002"), data["PONo"].ToString())) == DialogButton.Yes)
                    {
                        ShowWaitScreen();
                        BusinessClass.PurchaseOrderDeleteData(data["PONo"].ToString());
                        MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0013"), data["PONo"].ToString()));
                        DataLoading();
                    }
                }
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
         private void frmASO020_PurchaseOrder_Load(object sender, EventArgs e)
        {
            try
            {
                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                supplierControl.OwnerID = Common.GetDefaultOwnerID();
                supplierControl.DataLoading();
                gdvSearchResult.OptionsDetail.ShowDetailTabs = false;
                dtPOIssueDateFrom.EditValue = ControlUtil.GetStartDate();
                dtPOIssueDateTo.EditValue = ControlUtil.GetEndDate();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

         private void gdvSearchResult_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
         {
             try
             {
                 DataRow dr = gdvSearchResult.GetDataRow(e.RowHandle);
                 dr.AcceptChanges();
                 dr.SetModified();
             }
             catch (Exception ex)
             {

                 throw ex;
             }

         }

         private void ownerControl_EditValueChanged(object sender, EventArgs e)
         {
             try
             {
                 ShowWaitScreen();
                 if (ownerControl.OwnerID != null)
                 {
                     customerControl.OwnerID = ownerControl.OwnerID;
                     customerControl.DataLoading();
                     warehouseControl.OwnerID = ownerControl.OwnerID;
                     warehouseControl.DataLoading();
                     supplierControl.OwnerID = ownerControl.OwnerID;
                     supplierControl.DataLoading();
                 }
                 else
                 {
                     customerControl.OwnerID = Common.GetDefaultOwnerID();
                     customerControl.DataLoading();
                     warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                     warehouseControl.DataLoading();
                     supplierControl.OwnerID = Common.GetDefaultOwnerID();
                     supplierControl.DataLoading();
                 }
                 CloseWaitScreen();
             }
             catch (Exception ex)
             {
                 MessageDialog.ShowSystemErrorMsg(this, ex); ;
             }
         }

        private void gdvSearchResult_CellMerge(object sender, CellMergeEventArgs e)
        {
            //try
            //{
            //    e.Handled = true;
            //    if (e.Column == gdcStatusName || e.Column == gdcPONo || e.Column == gdcOwnerCode || e.Column == gdcOwnerName ||
            //        e.Column == gdcWarehouseCode || e.Column == gdcWarehouseName || e.Column == gdcSupplierCode || e.Column == gdcSupplierName || e.Column == gdcCustomerCode || e.Column == gdcCustomerName ||
            //        e.Column == gdcPOIssueDate || e.Column == gdcVat || e.Column == gdcArrivalDate || e.Column == gdcCollectDate || e.Column == gdcRemark ||
            //        e.Column == gdcCreateDate || e.Column == gdcCreateUser || e.Column == gdcUpdateDate || e.Column == gdcUpdateUser
            //       )
            //    {
            //        DataRow firstRow = gdvSearchResult.GetDataRow(e.RowHandle1);
            //        DataRow secondRow = gdvSearchResult.GetDataRow(e.RowHandle2);

            //        if (firstRow["StatusName"].ToString() == secondRow["StatusName"].ToString() &&
            //            firstRow["PONo"].ToString() == secondRow["PONo"].ToString() &&
            //            //firstRow["SONo"].ToString() == secondRow["SONo"].ToString() &&
            //            firstRow["OwnerCode"].ToString() == secondRow["OwnerCode"].ToString() &&
            //            firstRow["OwnerName"].ToString() == secondRow["OwnerName"].ToString() &&
            //            firstRow["WarehouseCode"].ToString() == secondRow["WarehouseCode"].ToString() &&
            //            firstRow["WarehouseName"].ToString() == secondRow["WarehouseName"].ToString() &&
            //            firstRow["SupplierCode"].ToString() == secondRow["SupplierCode"].ToString() &&
            //            firstRow["SupplierName"].ToString() == secondRow["SupplierName"].ToString() &&
            //            firstRow["CustomerCode"].ToString() == secondRow["CustomerCode"].ToString() &&
            //            firstRow["CustomerName"].ToString() == secondRow["CustomerName"].ToString() &&
            //            //firstRow["ShippingDate"].ToString() == secondRow["ShippingDate"].ToString() &&
            //            firstRow["IssuedDate"].ToString() == secondRow["IssuedDate"].ToString() &&
            //            //firstRow["CurrencyCode"].ToString() == secondRow["CurrencyCode"].ToString() &&
            //            firstRow["Vat"].ToString() == secondRow["Vat"].ToString() &&
            //            firstRow["ArrivalDate"].ToString() == secondRow["ArrivalDate"].ToString() &&
            //            firstRow["CollectDate"].ToString() == secondRow["CollectDate"].ToString() &&
            //            firstRow["Remark"].ToString() == secondRow["Remark"].ToString() &&
            //            firstRow["CreateDate"].ToString() == secondRow["CreateDate"].ToString() &&
            //            firstRow["CreateUser"].ToString() == secondRow["CreateUser"].ToString() &&
            //            firstRow["UpdateDate"].ToString() == secondRow["UpdateDate"].ToString() &&
            //            firstRow["UpdateUser"].ToString() == secondRow["UpdateUser"].ToString())
            //        {
            //            e.Merge = true;

            //        }
            //        else
            //        {
            //            e.Merge = false;
            //        }
            //    }
            //    else
            //    {
            //        e.Merge = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageDialog.ShowSystemErrorMsg(this, ex);
            //}
        }    
  
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSearchCriteria())
                {
                    DataLoading();
                    if (gdvSearchResult.RowCount <= 0)
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
                ownerControl.ClearData();
                customerControl.OwnerID = Common.GetDefaultOwnerID();
                customerControl.DataLoading();
                warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                warehouseControl.DataLoading();
                supplierControl.OwnerID = Common.GetDefaultOwnerID();
                supplierControl.DataLoading();
                ControlUtil.ClearControlData(txtSONo, txtPONo, txtCustomerPONo, chkAllStatus);
                grdSearchResult.DataSource = null;

                dtPOIssueDateFrom.EditValue = ControlUtil.GetStartDate();
                dtPOIssueDateTo.EditValue = ControlUtil.GetEndDate();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnPrintRMTag_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return;
                }
                

                DataRow drSelect = gdvSearchResult.GetFocusedDataRow();

                string PONo = Convert.ToString(drSelect["PONo"]);

                DataSet dsReport = RMTagReportClass.GetDataReport(PONo);

                // สร้างความสัมพันธ์ของข้อมูล Header กับ PalletDetail
                if (dsReport.Tables["dtbPalletBoxDetail"].Rows.Count > 0)
                {
                    dsReport.Relations.Add("HeaderPalletBoxDetail"
                        , dsReport.Tables["dtbHeader"].Columns["PDSNo"]
                        , dsReport.Tables["dtbPalletBoxDetail"].Columns["PDSNo"], false);
                }

                // สร้างความสัมพันธ์ของข้อมูล Header กับ BoxDetail
                //if (dsReport.Tables["dtbBoxDetail"].Rows.Count > 0)
                //{
                //    dsReport.Relations.Add("HeaderBoxDetail"
                //        , dsReport.Tables["dtbHeader"].Columns["PDSNo"]
                //        , dsReport.Tables["dtbBoxDetail"].Columns["PDSNo"], false);
                //}

                rptRPT032_RawMaterialTag rpt = new rptRPT032_RawMaterialTag(ReportBusiness.GetReportDefaultParams("RPT032"));
                rpt.DataSource = dsReport;

                ReportUtil.ShowPreview(rpt);

                if (dsReport.Tables["dtbBoxDetail_ServicePart"].Rows.Count > 0)
                {
                    dsReport.Relations.Add("HeaderBoxDetail_ServicePart"
                        , dsReport.Tables["dtbHeader"].Columns["PDSNo"]
                        , dsReport.Tables["dtbBoxDetail_ServicePart"].Columns["PDSNo"], false);

                    rptRPT032_RawMaterialTag_Service_Part rpt2 = new rptRPT032_RawMaterialTag_Service_Part(ReportBusiness.GetReportDefaultParams("RPT032"));
                    rpt2.DataSource = dsReport;

                    ReportUtil.ShowPreview(rpt2);
                }
             
                
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnPrintPDS_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return;
                }
                ShowWaitScreen();
                DataRow dr = gdvSearchResult.GetFocusedDataRow();
                List<sp_RPT033_PartDeliverySheet_GetData_Result> lstReport = ReportBusiness.GetDataReport(Convert.ToString(dr["PONo"]));
                List<sp_RPT033_PartDeliverySheet_GetSubData_Result> lstReportSub = ReportBusiness.GetSubDataReport(Convert.ToString(dr["PONo"]));

                rptRPT033_PartDeliverySheetReport rpt = new rptRPT033_PartDeliverySheetReport(ReportBusiness.GetReportDefaultParams("RPT033"));
                rpt.DataSource = lstReport;
                rpt.SetSubReportDatasource(lstReportSub);
                rpt.SetParameterReport("printBy", AppConfig.Name);
                rpt.SetParameterReport("ISO", "FM-LED-03(Rev.00)");

                ReportUtil.ShowPreview(rpt);
                CloseWaitScreen();

            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void gdvSearchResult_MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                base.GridViewChildOnChangeLanguage(grdSearchResult, e.RowHandle);
                GridView grv = ((GridView)(((GridView)grdSearchResult.Views[0]).GetDetailView(e.RowHandle, 0)));
                if (grv != null)
                {
                    grv.Columns["PONo"].Visible = false;
                    grv.Columns["SONo"].OptionsColumn.AllowEdit = false;
                    grv.Columns["CustomerPONo"].OptionsColumn.AllowEdit = false;
                    grv.Columns["PDSNo"].OptionsColumn.AllowEdit = false;
                    grv.Columns["ReceivingNo"].OptionsColumn.AllowEdit = false;
                    grv.Columns["ArrivalDate"].OptionsColumn.AllowEdit = false;
                    grv.Columns["CollectDate"].OptionsColumn.AllowEdit = false;
                    grv.Columns["PDSInvoiceNo"].OptionsColumn.AllowEdit = true;
                    grv.Columns["PurchaseDate"].OptionsColumn.AllowEdit = true;
                    grv.Columns["PurchaseDate"].ColumnEdit = repPurchaseDate;
                    grv.Columns["PurchaseDate"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    //grv.Columns["ArrivalDate"].OptionsColumn.AllowEdit = true;
                    //grv.Columns["ArrivalDate"].ColumnEdit = repPurchaseDate;
                    //grv.Columns["ArrivalDate"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    //grv.Columns["CollectDate"].OptionsColumn.AllowEdit = true;
                    //grv.Columns["CollectDate"].ColumnEdit = repPurchaseDate;
                    //grv.Columns["CollectDate"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    

                    if (isEdit)
                    {
                        gdvSearchResult.OptionsBehavior.Editable = true;
                        grv.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(grv_CellValueChanging);
                    }
                    else
                    {
                        gdvSearchResult.OptionsBehavior.Editable = false;
                        grv.CellValueChanging -= new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(grv_CellValueChanging);
                    }
                }
            }
        }

        private void grv_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView Mastergrv = ((GridView)(((GridView)grdSearchResult.Views[0]).GetDetailView(gdvSearchResult.FocusedRowHandle, 0)));
            DataRow dr = Mastergrv.GetDataRow(e.RowHandle);
            dr.AcceptChanges();
            dr.SetModified();
        }

        private void grdSearchResult_FocusedViewChanged(object sender, ViewFocusEventArgs e)
        {
            try
            {
                if (e.View != null && e.View.IsDetailView)
                    (e.View.ParentView as GridView).FocusedRowHandle = e.View.SourceRowHandle;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void gdvSearchResult_MasterRowCollapsed(object sender, CustomMasterRowEventArgs e)
        {
            if (isEdit)
            {
                if (MessageDialog.ShowConfirmationMsg(this, "If detail data not expanded data will not save, do you want to collapse it?") == DialogButton.No)
                {
                    gdvSearchResult.ExpandMasterRow(e.RowHandle);
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
                grdSearchResult.DataSource = null;
                iv.ClearTicket();
                if (dtParent != null)
                {
                    dtParent.Rows.Clear();
                }
                if (dtChild != null)
                {
                    dtChild.Rows.Clear();
                }
                DataSet ds = BusinessClass.PurchaseOrderDataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, supplierControl.SupplierID, customerControl.CustomerID,
                                                                      dtPOIssueDateFrom.EditValue == null ? null : dtPOIssueDateFrom.DateTime.ToString("yyyy/MM/dd"),
                                                                      dtPOIssueDateTo.EditValue == null ? null : dtPOIssueDateTo.DateTime.ToString("yyyy/MM/dd"),
                                                                      txtSONo.Text.Trim(), txtPONo.Text.Trim(), txtCustomerPONo.Text.Trim(), chkAllStatus.Checked ? null : DataUtil.Convert<int>(10)
                                                                      , chkAfterMarket.Checked ? 1 : 0);

                if (ds.Tables[0].Rows.Count <= 0)
                {
                    return;
                }

                DataTable dt0 = ds.Tables[1].Clone();
                dt0.Columns["PurchaseDate"].DataType = typeof(DateTime);
                dt0.Columns["ArrivalDate"].DataType = typeof(DateTime);
                dt0.Columns["CollectDate"].DataType = typeof(DateTime);
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    dt0.Rows.Add(ds.Tables[1].Rows[i][0]
                        , ds.Tables[1].Rows[i][1]
                        , ds.Tables[1].Rows[i][2]
                        , ds.Tables[1].Rows[i][3]
                        , ds.Tables[1].Rows[i][4]
                        , ds.Tables[1].Rows[i][5]
                        , ds.Tables[1].Rows[i][6]
                        , DateTime.ParseExact(ds.Tables[1].Rows[i][7].ToString(), "dd/MM/yyyy mm:ss", new System.Globalization.CultureInfo("en-US"))
                        , DateTime.ParseExact(ds.Tables[1].Rows[i][8].ToString(), "dd/MM/yyyy mm:ss", new System.Globalization.CultureInfo("en-US")));
                }
                
                DataSet ds1 = new DataSet();
                ds1.Tables.Add(ds.Tables[0].Copy());
                ds1.Tables.Add(dt0);

                ds = ds1;

                dtParent = ds.Tables[0];
                dtChild = ds.Tables[1];



                if (dtParent.Rows.Count > 0 && dtChild.Rows.Count > 0)
                {
                    DataColumn[] dcHeader = new DataColumn[] { dtParent.Columns["PONo"] };
                    DataColumn[] dcDetail = new DataColumn[] { dtChild.Columns["PONo"] };
                    ds.Relations.Add("PORelation", dcHeader, dcDetail, false);                    
                }
                grdSearchResult.DataSource = ds.Tables[0];
                
                //Check duplicate Owner and Warehouse
                DataTable distinctTable1 = dtParent.DefaultView.ToTable(true, "OwnerCode");
                DataTable distinctTable2 = dtParent.DefaultView.ToTable(true, "WarehouseCode");

                gdcOwnerCode.Visible = distinctTable1.Rows.Count > 1;
                gdcOwnerName.Visible = distinctTable1.Rows.Count > 1;
                gdcWarehouseCode.Visible = distinctTable2.Rows.Count > 1;
                gdcWarehouseName.Visible = distinctTable2.Rows.Count > 1;

                //IdleValidator
                foreach (DataRow dr in dtParent.Rows)
                {
                    iv.PushTicket(Convert.ToDateTime(dr["DateForValiDate"]), dr["PONo"].ToString());
                }
                base.GridViewOnChangeLanguage(grdSearchResult);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void OpenDialog(Common.eScreenMode ScreenMode)
        {
            Dialog.IdleValidatorControl = this.iv;
            Dialog.ScreenMode = ScreenMode;

            if (ScreenMode != Common.eScreenMode.Add)
            {
                Dialog.PONo = gdvSearchResult.GetFocusedDataRow()["PONo"].ToString();
            }

            if (Dialog.ShowDialog(this) == DialogResult.OK)
            {
                DataLoading();
                MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), Dialog.PONo));
            }
            Dialog = null;
        }

        private bool CheckCanEditOrDelete()
        {
            DataRow data = gdvSearchResult.GetFocusedDataRow();
            string SONo = string.Empty;
            if (!iv.ValidateTicket(data["PONo"].ToString()))
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0270"));
                return false;
            }

            DataRow[] dr = dtChild.Select(string.Format("PONo = '{0}' ", gdvSearchResult.GetFocusedDataRow()["PONo"]));

            if (dr.Length > 0)
            {
                SONo = dr[0]["SONo"].ToString();
            }

            if ((data["StatusID"].ToString() != CSI.Business.Common.Status.NewPurchaseOrder.ToString() || !string.IsNullOrEmpty(SONo)) && !isEdit)
            {
                //Unable to delete. Status of {0} is not new.
                MessageDialog.ShowBusinessErrorMsg(this, string.Format(Rubix.Screen.Common.GetMessage("I0254"), "Purchase Order"));
                return false;
            }
            else if ((data["StatusID"].ToString() != CSI.Business.Common.Status.NewPurchaseOrder.ToString() || !string.IsNullOrEmpty(SONo)) && isEdit)
            {
                Dialog.CanEdit = false;
                //Unable to edit. Status of {0} is not new.
                //MessageDialog.ShowBusinessErrorMsg(this, string.Format(Rubix.Screen.Common.GetMessage("I0417"), "Purchase Order"));
                //return false;
            }

            return true;
        }

        private bool ValidateSearchCriteria()
        {
            errorProvider.ClearErrors();
            bool validate = true;

            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;
            
            //supplierControl.ErrorText = Common.GetMessage("I0300");
            //supplierControl.RequireField = true;

            validate &= ownerControl.ValidateControl();
            validate &= warehouseControl.ValidateControl();
            //validate &= supplierControl.ValidateControl();

            return validate;
        }

        private void SaveData()
        {
            try
            {
                BusinessClass.PurchaseOrderSavePSDInvNo(getXML());
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private string getXML()
        {
            string xml;
            if (gdvSearchResult.RowCount == 0)
            {
                xml = null;
            }
            else
            {
                DataSet ds = new DataSet("NewDataSet");
                DataTable dtSave = new DataTable();
                dtSave.TableName = "Table";
                dtSave.Columns.Add("PDSNo");
                dtSave.Columns.Add("PDSInvoiceNo");
                dtSave.Columns.Add("PurchaseDate");
                dtSave.Columns.Add("ArrivalDate");
                dtSave.Columns.Add("CollectDate");

                for (int i = 0; i < grdSearchResult.Views[0].RowCount; i++)
                {
                    GridView grv = ((GridView)(((GridView)grdSearchResult.Views[0]).GetDetailView(i, 0)));
                    if (grv != null)
                    {
                        for (int j = 0; j < grv.RowCount; j++)
                        {
                            DataRow dr = grv.GetDataRow(j);
                            
                            if (dr.RowState == DataRowState.Modified)
                            {
                                dtSave.Rows.Add(dr.ItemArray[3], dr.ItemArray[5], dr.ItemArray[6], dr.ItemArray[7], dr.ItemArray[8]);
                            }
                        }
                    }
                }
                DataTable dtHeader = new DataTable();
                dtHeader.TableName = "TableHeader";
                dtHeader.Columns.Add("PONo");
                dtHeader.Columns.Add("Remark");
                for (int i = 0; i < gdvSearchResult.RowCount; i++)
                {
                    DataRow dr = gdvSearchResult.GetDataRow(i);
                    if (dr.RowState == DataRowState.Modified)
                    {
                        dtHeader.Rows.Add(dr.ItemArray[3], dr.ItemArray[17]);
                    }
                }
                ds.Tables.Add(dtSave);
                ds.Tables.Add(dtHeader);
                xml = ds.GetXml();
            }
            return xml;
        }
        #endregion

        


    }
}

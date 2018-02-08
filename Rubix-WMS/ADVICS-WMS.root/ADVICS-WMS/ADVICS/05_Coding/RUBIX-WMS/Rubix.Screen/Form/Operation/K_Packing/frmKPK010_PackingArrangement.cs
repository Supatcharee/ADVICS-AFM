using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CSI.Business.DataObjects;
using CSI.Business.Report;
using DevExpress.XtraEditors;
using Rubix.Framework;
using DevExpress.XtraGrid;
using Rubix.Screen.Form.Operation.K_Packing.Dialog;
using Rubix.Screen.Report;
using CSI.Business.Operation;

namespace Rubix.Screen.Form.Operation.K_Packing
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Edit, Permission.Export, Permission.Print)]
    public partial class frmKPK010_PackingArrangement : FormBase
    {
        #region Member
        private PackingInstructionReport m_ReportClass = null;
        private PackingInstruction m_BusinessClass = null;
        private dlgKPK011_PackingArragement m_Dialog = null;
        #endregion

        #region Properties
        private PackingInstructionReport ReportBusiness
        {
            get
            {
                if (m_ReportClass == null)
                {
                    m_ReportClass = new PackingInstructionReport();
                }
                return m_ReportClass;
            }
        }
        private PackingInstruction BusinessClass
        {
            get
            {
                if (m_BusinessClass == null)
                {
                    m_BusinessClass = new PackingInstruction();
                }
                return m_BusinessClass;
            }
        }
        private dlgKPK011_PackingArragement Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new dlgKPK011_PackingArragement();
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
        public frmKPK010_PackingArrangement()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true,  m_toolBarRefresh,m_toolBarCancel, m_toolBarSave);
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(gpcSearchCriteria);

            customerControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            shipmentControl.OwnerID = Common.GetDefaultOwnerID();
            packingControl.ShipmentNo = "-1";

            dtPackingDateFrom.EditValue = ControlUtil.GetStartDate();
            dtPackingDateTo.EditValue = ControlUtil.GetEndDate();
        } 
        #endregion
        
        #region Override Method
        public override bool OnCommandView()
        {
            try
            {
                OpenDialog(Common.eScreenMode.View);
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
                OpenDialog(Common.eScreenMode.Edit);
                return true;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        #endregion

        #region Event Handler
        private void frmKPK010_PackingArragement_Load(object sender, EventArgs e)
        {
            try
            {
                btnPrintCaseMark.Visible = base.CanPrint;
                btnPrintPackingInstruction.Visible = base.CanPrint;
                m_toolBarPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                emptyBtn.Buttons.Clear();             
                emptyBtn.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                // set Drop down Status On load
                LookupStatus.Properties.DisplayMember = "StatusName";
                LookupStatus.Properties.ValueMember = "StatusID";
                LookupStatus.Properties.DataSource = getStatusDatasource();
                LookupStatus.EditValue = null;
                //
                //ClearData();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }
        
        private void gdvSearchResult_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            e.Handled = true;
            DataRow firstRow = gdvSearchResult.GetDataRow(e.RowHandle1);
            DataRow secondRow = gdvSearchResult.GetDataRow(e.RowHandle2);

            if (e.Column == gdcStatusName 
                || e.Column == gdcCustomerPONo 
                || e.Column == gdcShipmentNo 
                || e.Column == gdcShippingDate 
                || e.Column == gdcTransportionDate 
                || e.Column == gdcPackingDate)
            {   
                if (firstRow["StatusName"].Equals(secondRow["StatusName"]) &&
                    firstRow["CustomerPONo"].Equals(secondRow["CustomerPONo"]) &&
                    firstRow["ShipmentNo"].Equals(secondRow["ShipmentNo"]) &&
                    firstRow["ShippingDate"].Equals(secondRow["ShippingDate"]) &&
                    firstRow["TransportationDate"].Equals(secondRow["TransportationDate"]) &&
                    firstRow["PackingDate"].Equals(secondRow["PackingDate"]))
                {
                    e.Merge = true;
                }
                else
                {
                    e.Merge = false;
                }
            }
            else if (e.Column == gdcPalletNo 
                    || e.Column == gdcPackingNo 
                || e.Column == gdcPickingNo 
                || e.Column == gdcWeightLimit
                || e.Column == gdcPalletM3
                || e.Column == gdcTotalGrossWeight
                || e.Column == gdcCaseMarkWeight)
            {
                if(firstRow["PalletNo"].Equals(secondRow["PalletNo"]) 
                    && firstRow["PackingNo"].Equals(secondRow["PackingNo"])
                    && firstRow["PickingNo"].Equals(secondRow["PickingNo"])
                    && firstRow["WeightLimit"].Equals(secondRow["WeightLimit"])
                    && firstRow["M3"].Equals(secondRow["M3"])
                    && firstRow["TotalGrossWeight"].Equals(secondRow["TotalGrossWeight"])
                    && firstRow["CaseMarkWeight"].Equals(secondRow["CaseMarkWeight"]))
                {
                    e.Merge = true;
                }
                else
                {
                    e.Merge = false;
                }
            }
            else
            {
                e.Merge = false;
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
                    shipmentControl.OwnerID = ownerControl.OwnerID;
                    shipmentControl.DataLoading();
                }
                else
                {
                    customerControl.OwnerID = Common.GetDefaultOwnerID();
                    customerControl.DataLoading();
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                    shipmentControl.DataLoading();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            finally
            {
                CloseWaitScreen();
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

        private void dtPackingDateFrom_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (ownerControl.OwnerID != null && dtPackingDateFrom.EditValue != null)
                {
                    shipmentControl.PackDateFrom = dtPackingDateFrom.DateTime;
                    shipmentControl.DataLoading();
                }
                else
                {
                    shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                    shipmentControl.DataLoading();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void dtPackingDateTo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                if (ownerControl.OwnerID != null && dtPackingDateTo.EditValue != null)
                {
                    shipmentControl.PackDateTo = dtPackingDateTo.DateTime;
                    shipmentControl.DataLoading();
                }
                else
                {
                    shipmentControl.OwnerID = Common.GetDefaultOwnerID();
                    shipmentControl.DataLoading();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
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
                    packingControl.ShipmentNo = shipmentControl.ShipmentNo;
                    packingControl.DataLoading();
                }
                else
                {
                    packingControl.ShipmentNo = "-1";
                    packingControl.DataLoading();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            finally
            {
                CloseWaitScreen();
            }
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSearchCiteria())
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

        private void btnPackingManagement_Click(object sender, EventArgs e)
        {
            try
            {
                dlgKPK012_PackingManagementDialog dlg = new dlgKPK012_PackingManagementDialog();
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    DataLoading();
                }
                dlg = null;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnPrintPackingInstruction_Click(object sender, EventArgs e)
        {
            try
            {
                if (gdvSearchResult.RowCount <= 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return;
                }
                

                DataRow dr = gdvSearchResult.GetFocusedDataRow();
                string PackingNo = Convert.ToString(dr["PackingNo"]);

                rptRPT035_PackingInstruction rpt = new rptRPT035_PackingInstruction(ReportBusiness.GetReportDefaultParams("RPT035"));

                rpt.DataSource = ReportBusiness.GetDataReport(PackingNo);
                rpt.SetSubReportDatasource(ReportBusiness.GetMaterialDataReport(PackingNo));

                rpt.SetParameterReport("printBy", AppConfig.Name);

                ReportUtil.ShowPreview(rpt);
                DataLoading();
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
                ClearData();
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnPrintCaseMark_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = grdSearchResult.DataSource as DataTable;

                if (dt == null)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                    return;
                }

                //DataRow[] dr = dt.Select("Select = 1");
                DataRow dr = gdvSearchResult.GetFocusedDataRow();
                if (dr == null)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
                    return;
                }
                else
                {
                    string palletNo = dr["PalletNo"].ToString();
                    string AdditionReportFlg = dr["AdditionReportFlg"].ToString();


                    //Call report;
                    List<sp_RPT037_CaseMark_GetData_Result> report = ReportBusiness.GetCaseMarkReport(palletNo);

                    rptRPT037_CaseMark rpt = new rptRPT037_CaseMark(ReportBusiness.GetReportDefaultParams("RPT037"));
                    rpt.DataSource = report;
                    //rpt.SetParameterReport("printBy", AppConfig.Name);

                    if (AdditionReportFlg.Equals("1"))
                    {
                        rptRPT037_CaseMark_AdditionPage1 rpt2 = new rptRPT037_CaseMark_AdditionPage1(ReportBusiness.GetReportDefaultParams("RPT037"));
                        ReportUtil.CombineReport(rpt, rpt2);
                    }
                    ReportUtil.ShowPreview(rpt);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void chkPlan_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkPlan.Checked)
                {
                    ControlUtil.EnableControl(false, m_toolBarEdit);
                    btnPrintPackingInstruction.Enabled = false;
                }
                else
                {
                    ControlUtil.EnableControl(true, m_toolBarEdit);
                    btnPrintPackingInstruction.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void repositoryItemRollbackbtn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (MessageDialog.ShowConfirmationMsg(this, "Comfirm Rollback?") == DialogButton.Yes)
            {
                try
                {
                    DataRow dr = gdvSearchResult.GetFocusedDataRow();
                    DataRollback(dr.ItemArray[9].ToString()); 
                    if (ValidateSearchCiteria())
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
        }

        private void gdvSearchResult_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            
            if (e.RepositoryItem.Name == "repositoryItemRollbackbtn")
            {
                DataRow dr1 = gdvSearchResult.GetDataRow(e.RowHandle);
                DataRow dr2 = gdvSearchResult.GetDataRow(e.RowHandle - 1);
                
                if (dr1.ItemArray[23].ToString() != "75")
                {
                    e.RepositoryItem = emptyBtn;
                }
                else if (dr2 != null && dr1.ItemArray[9].ToString() == dr2.ItemArray[9].ToString())
                {
                    e.RepositoryItem = emptyBtn;
                }
            }
            else if (e.RepositoryItem.Name == "repositoryItemPickPallet")
            {
                DataRow dr1 = gdvSearchResult.GetDataRow(e.RowHandle);
                DataRow dr2 = gdvSearchResult.GetDataRow(e.RowHandle - 1);
                if (dr1.ItemArray[23].ToString() != "110")
                {
                    e.RepositoryItem = emptyBtn;
                }
                else if (dr2 != null && dr1.ItemArray[8].ToString() == dr2.ItemArray[8].ToString())
                {
                    e.RepositoryItem = emptyBtn;
                }
            }
        }

        private void repositoryItemPackPallet_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                DataRow dr = gdvSearchResult.GetFocusedDataRow();
                if (validate_Pick_Pallet(dr.ItemArray[8].ToString()))
                {
                    if (MessageDialog.ShowConfirmationMsg(this, "Comfirm Pack Pallet?") == DialogButton.Yes)
                    {
                        PickPallet(dr.ItemArray[8].ToString());
                    }
                }
                if (ValidateSearchCiteria())
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
        #endregion
                            
        #region Generic Function
        private DataTable getStatusDatasource()
        {
            DataTable DT = new DataTable();
            DT.Columns.Add("StatusID");
            DT.Columns.Add("StatusName");
            DT.Rows.Add("65", "New : Shipping Entry");
            DT.Rows.Add("75", "Picking Instruction Issued");
            DT.Rows.Add("80", "Incomplete Picking");
            DT.Rows.Add("85", "Complete Picking");
            DT.Rows.Add("100", "Packing Instruction Issued");
            DT.Rows.Add("105", "Incomplete Packing");
            DT.Rows.Add("110", "Complete Packing");
            DT.Rows.Add("120", "Complete Transportation");
            DT.Rows.Add("130", "Document Shipping Issued");
            DT.Rows.Add("140", "Incomplete Shipping");
            DT.Rows.Add("145", "Complete Shipping");

            return DT;
        }

        private void DataLoading()
        {
            try
            {
                this.ShowWaitScreen();
                //grdSearchResult.DataSource = null;
                DataTable dt = BusinessClass.PackingArragementSearchAll(ownerControl.OwnerID, customerControl.CustomerID, warehouseControl.WarehouseID,
                                                                        shipmentControl.ShipmentNo, packingControl.PackingNo, txtCustomerPO.Text.Trim(), txtPalletNo.Text,
                                                                        dtPackingDateFrom.DateTime.ToString("yyyy/MM/dd"), dtPackingDateTo.DateTime.ToString("yyyy/MM/dd")
                                                                        ,chkActual.Checked, DataUtil.Convert<int>(LookupStatus.EditValue));

                grdSearchResult.DataSource = dt;
                base.GridViewOnChangeLanguage(grdSearchResult);
                ControlUtil.SetBestWidth(gdvSearchResult);
                gdvSearchResult.OptionsBehavior.Editable = true;
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

        private void DataRollback(string PickingNo)
        {
            try
            {
                this.ShowWaitScreen();
                BusinessClass.PackingArragementRollBack(PickingNo);
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

        private void PickPallet(string PalletNo)
        {
            try
            {
                this.ShowWaitScreen();
                BusinessClass.CaseMarkPickAndPack(PalletNo);
                MessageDialog.ShowInformationMsg("Pick pallet complete");
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
            if (gdvSearchResult.RowCount == 0)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Rubix.Screen.Common.GetMessage("I0011"));
            }
            else
            {
                DataRow dr = gdvSearchResult.GetFocusedDataRow();
                if (dr != null)
                {
                    Dialog.ScreenMode = ScreenMode;
                    Dialog.SelecedDataRow = dr;
                    if (Dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        DataLoading();
                        MessageDialog.ShowInformationMsg(String.Format(Rubix.Screen.Common.GetMessage("I0012"), ""));
                    }
                    Dialog = null;
                }
            }
        }

        private bool ValidateSearchCiteria()
        {
            errorProvider.ClearErrors();
            bool validate = true;

            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            //customerControl.ErrorText = Common.GetMessage("I0249");
            //customerControl.RequireField = true;

            validate &= ownerControl.ValidateControl();
            validate &= warehouseControl.ValidateControl();
            //validate &= customerControl.ValidateControl();

            if (string.IsNullOrEmpty(dtPackingDateFrom.Text))
            {
                errorProvider.SetError(dtPackingDateFrom, Common.GetMessage("I0265"));
                validate = false;
            }

            if (string.IsNullOrEmpty(dtPackingDateTo.Text))
            {
                errorProvider.SetError(dtPackingDateTo, Common.GetMessage("I0266"));
                validate = false;
            }

            return validate;
        }

        private void ClearData()
        {
            ControlUtil.ClearControlData(gpcSearchCriteria.Controls);

            ownerControl.ClearData();
            customerControl.OwnerID = Common.GetDefaultOwnerID();
            customerControl.DataLoading();
            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();
            shipmentControl.OwnerID = Common.GetDefaultOwnerID();
            shipmentControl.DataLoading();

            dtPackingDateFrom.EditValue = ControlUtil.GetStartDate();
            dtPackingDateTo.EditValue = ControlUtil.GetEndDate();

            LookupStatus.EditValue = null;
            grdSearchResult.DataSource = null;
            chkActual.Checked = true;
        }

        private bool validate_Pick_Pallet(string PalletNo)
        {
            bool validate = true;

            DataSet ds = BusinessClass.PackingArragementValidate_PickPallet(PalletNo);
            if (ds.Tables[0].Rows.Count == 0)
            {
                validate = false;
                MessageDialog.ShowBusinessErrorMsg(this, "Cannot pick pallet, this pallet not be transit before");
                return validate;
            }

            return validate;
        }
        #endregion

        private void gdvSearchResult_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
             {
                DataRowView dv = (DataRowView)gdvSearchResult.GetRow(e.RowHandle);
                if (Convert.ToDecimal(dv["M3Pallet"]) > Convert.ToDecimal(dv["M3"]))
                {
                  
                     e.Appearance.BackColor = Color.Goldenrod;
                    
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

       
    } 
}
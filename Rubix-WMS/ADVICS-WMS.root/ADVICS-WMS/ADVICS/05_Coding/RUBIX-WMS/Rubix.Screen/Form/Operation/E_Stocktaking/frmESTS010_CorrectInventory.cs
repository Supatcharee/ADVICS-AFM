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
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using CSI.Business.Operation;
using Rubix.Framework;
using System.Data.Objects;
using CSI.Business.DataObjects;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using CSI.Business.BusinessFactory.Report;
namespace Rubix.Screen.Form.Operation.E_Stocktaking
{
    [ScreenPermissionAttribute(Permission.OpenScreen, Permission.Add, Permission.Edit, Permission.Export)]
    public partial class frmESTS010_CorrectInventory : FormBase
    {
        #region Member
        private CorrectInventory db;
        private Dialog.dlgESTS010_CorrectInventory m_Dialog = null;
        #endregion

        #region Enumeration
        private enum eColumn
        {
            Select,
            OwnerID,
            DistributionCenterID,
            LocationID,
            ProductConditionID,
            ProductID,
            ZoneCode,
            Floor,
            RackNo,
            ReceivingNo,
            ProductConditionCode,
            CustomerCode,
            CustomerName,
            DistributionCenterCode,
            DistributionCenterName,
            ProductCode,
            ProductName,
            ConditionOfProduct,
            LotNo,
            PalletNoRef,
            PalletNo,
            LocationCode,
            LocationName,
            Inventory,
            FinalUpdateDate,
            ExpiredDate
        }
        private enum eColInventory
        {
            TypeName,
            Transit,
            StockActual,
            StockHold,
            Shipping
        }
        #endregion

        #region Properties
        private CorrectInventory BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new CorrectInventory();
                }
                return db;
            }
        }
        private Dialog.dlgESTS010_CorrectInventory Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgESTS010_CorrectInventory();
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
        public frmESTS010_CorrectInventory()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarView, m_toolBarDelete, m_toolBarRefresh, m_toolBarSave, m_toolBarCancel, q_toolBarView);
            base.GridControlSearchResult = new GridControl[] { grdSearchResult };
            base.GridExportExcel = gdvSearchResult;
            base.SetExpandGroupControl(groupControl3);
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
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
                return false;
            }
        }
        public override bool OnCommandAdd()
        {
            try
            {
                OpenDialog(Common.eScreenMode.Add);
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
        private void frmESTS010_CorrectInventory_Load(object sender, EventArgs e)
        {  
            InitInventoryStatus();
            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();
            itemControl.OwnerID = Common.GetDefaultOwnerID();
            itemControl.DataLoading();
            CloseWaitScreen();
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
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < (gdvSearchResult).DataRowCount; i++)
            {
                gdvSearchResult.SetRowCellValue(i, gdvSearchResult.Columns[(int)eColumn.Select], true);
            }
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < (gdvSearchResult).DataRowCount; i++)
            {
                gdvSearchResult.SetRowCellValue(i, gdvSearchResult.Columns[(int)eColumn.Select], false);
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
                    itemControl.OwnerID = ownerControl.OwnerID;
                    itemControl.DataLoading();
                }
                else
                {
                    warehouseControl.OwnerID = Common.GetDefaultOwnerID();
                    warehouseControl.DataLoading();
                    itemControl.OwnerID = Common.GetDefaultOwnerID();
                    itemControl.DataLoading();
                }
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (true == gdvSearchResult.IsEmpty)
                {
                    return;
                }

                List<sp_ESTS010_InventoryAdjustment_SearchAll_Result> temp = (List<sp_ESTS010_InventoryAdjustment_SearchAll_Result>)grdSearchResult.DataSource;
                List<sp_ESTS010_InventoryAdjustment_SearchAll_Result> selectedList = temp.FindAll(c => c.Select == true);
                if (selectedList.Count != 0)
                {
                    XtraReport rpt = null;
                    ReceivingInstruction dalReport = new ReceivingInstruction();
                    foreach (sp_ESTS010_InventoryAdjustment_SearchAll_Result data in selectedList)
                    {
                        List<sp_RPT019_ReceivingLabel_GetData_Result> labelList = new List<sp_RPT019_ReceivingLabel_GetData_Result>();                        
                        labelList = dalReport.GetReceivingLabel(data.PalletNo, data.LocationID , data.ProductID, data.LotNo, data.ProductConditionID, null);                       

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
                        ReportUtil.ShowPreview(rpt);
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
        
        #region Generic Function
        private void OpenDialog(Common.eScreenMode ScreenMode)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if ((grdSearchResult.DefaultView).DataRowCount == 0 && ScreenMode != Common.eScreenMode.Add)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
                }
                else
                {
                    if (ScreenMode != Common.eScreenMode.Add)
                    {
                        BusinessClass.SelectData = gdvSearchResult.GetFocusedRow();
                    }

                    Dialog.BusinessClass = BusinessClass;
                    Dialog.ScreenMode = ScreenMode;

                    if (Dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        DataLoading();
                        MessageDialog.ShowInformationMsg(String.Format(Common.GetMessage("I0012"), "Data"));
                    }
                    Dialog = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                grdSearchResult.DataSource = BusinessClass.DataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, txtSlipNo.Text.Trim(), itemControl.ProductID, txtPalletNo.Text.Trim());
                gdvSearchResult.OptionsBehavior.Editable = true;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseWaitScreen();
                base.GridViewOnChangeLanguage(grdSearchResult);
            }
        }

        private void InitInventoryStatus()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(eColInventory.TypeName.ToString(), Type.GetType("System.String"));
            dt.Columns.Add(eColInventory.Transit.ToString(), Type.GetType("System.Double"));
            dt.Columns.Add(eColInventory.StockActual.ToString(), Type.GetType("System.Double"));
            dt.Columns.Add(eColInventory.StockHold.ToString(), Type.GetType("System.Double"));
            dt.Columns.Add(eColInventory.Shipping.ToString(), Type.GetType("System.Double"));

            dr = dt.NewRow();
            dr[eColInventory.TypeName.ToString()] = "Qty";
            dr[eColInventory.Transit.ToString()] = 0.0;
            dr[eColInventory.StockActual.ToString()] = 0.0;
            dr[eColInventory.StockHold.ToString()] = 0.0;
            dr[eColInventory.Shipping.ToString()] = 0.0;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[eColInventory.TypeName.ToString()] = "Weight(Kg.)";
            dr[eColInventory.Transit.ToString()] = 0.0;
            dr[eColInventory.StockActual.ToString()] = 0.0;
            dr[eColInventory.StockHold.ToString()] = 0.0;
            dr[eColInventory.Shipping.ToString()] = 0.0;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[eColInventory.TypeName.ToString()] = "Measurment(M3)";
            dr[eColInventory.Transit.ToString()] = 0.0;
            dr[eColInventory.StockActual.ToString()] = 0.0;
            dr[eColInventory.StockHold.ToString()] = 0.0;
            dr[eColInventory.Shipping.ToString()] = 0.0;
            dt.Rows.Add(dr);
        }
        
        private void ClearAll()
        {
            ShowWaitScreen();
            ControlUtil.ClearControlData(this.Controls);

            grdSearchResult.DataSource = null;
            gdvSearchResult.Columns.Clear();

            warehouseControl.OwnerID = Common.GetDefaultOwnerID();
            warehouseControl.DataLoading();
            itemControl.OwnerID = Common.GetDefaultOwnerID();
            itemControl.DataLoading();
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
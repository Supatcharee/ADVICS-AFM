using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using CSI.Business.DataObjects;
using CSI.Business.BusinessFactory.Report;
using Rubix.Screen.Report;
namespace Rubix.Screen.Form.Report
{
    [ScreenPermissionAttribute(Permission.OpenScreen)]
    public partial class frmRPS110_InventoryCheckingList : FormBase
    {
        #region Member
        private InvertoryCheckingListReport db;
        #endregion

        #region Properties
        private InvertoryCheckingListReport BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new InvertoryCheckingListReport();
                }
                return db;
            }
        }
        #endregion

        #region Constructor
        public frmRPS110_InventoryCheckingList()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarCancel, m_toolBarDelete, m_toolBarEdit, m_toolBarExport, m_toolBarRefresh, m_toolBarSave, m_toolBarView);
            ControlUtil.HiddenControl(true, m_toolBarPaintStyls, m_toolBarThemeStyls);
            
            itemControl.EnableControl = false;
            //ControlUtil.EnableControl(false, cboFloor);
            zoneControl.EnableControl = false;
            

            //gdcFloor.FieldName = "Floor";
            //cboFloor.Properties.DisplayMember = "Floor";
            //cboFloor.Properties.ValueMember = "Floor";
            foreach (System.Windows.Forms.Control ctrl in this.groupControl3.Controls)
            {
                if (ctrl is DateEdit)
                {
                    DateEdit de = (DateEdit)ctrl;
                    de.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
                    de.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    de.Properties.EditFormat.FormatString = Common.FullDateFormat;
                    de.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                    de.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                    de.Properties.Mask.EditMask = Common.FullDateFormat;
                }
            }
        }
        #endregion
        
        #region Event Handler Function
        private void frmRPS110_InventoryCheckingList_Load(object sender, EventArgs e)
        {            
            dtMovementSince.DateTime = DateTime.Today.AddDays(-1);
        }
        private void rdoZone_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoZone.Checked == true)
            {
                enableControlZone(true);
                enableControlProduct(false);
                rdoProduct.Checked = false;
            }
            else 
            {
                enableControlZone(false);
                
            }
        }
        private void rdoProduct_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoProduct.Checked == true)
            {
                enableControlProduct(true);
                enableControlZone(false);
                rdoZone.Checked = false;
            }
            else
            {
                enableControlProduct(false);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int? OwnerID, WarehouseID, productID, zoneID, Floor;
                DateTime? date;
                string OwnerName, WarehouseName, zoneName, productCode, productName;
                Cursor.Current = Cursors.WaitCursor;
                if (ValidateData())
                {
                    OwnerID = ownerControl.OwnerID;
                    WarehouseID = warehouseControl.WarehouseID;
                    OwnerName = ownerControl.OwnerName;
                    WarehouseName = warehouseControl.WarehouseName;
                    date = dtMovementSince.DateTime;
                    ////report by Product
                    if (rdoProduct.Checked == true)
                    {

                        productID = itemControl.ProductID;
                        productCode = itemControl.ProductCode;
                        productName = itemControl.ProductLongName;

                        List<sp_RPT016_InventoryCheckingListByProduct_GetData_Result> tempReport = BusinessClass.GetCheckingListByProductReport(OwnerID, WarehouseID, productID, date);
                        if (tempReport.Count > 0)
                        {
                            rptRPT016_InventoryCheckListByProductReport rpt = new rptRPT016_InventoryCheckListByProductReport(BusinessClass.GetReportDefaultParams("RPT016"));
                            rpt.DataSource = tempReport;
                            rpt.SetParameterReport("OwnerName", OwnerName);
                            rpt.SetParameterReport("WarehouseName", WarehouseName);
                            rpt.SetParameterReport("ProductCode", productCode);
                            rpt.SetParameterReport("Product", productName);
                            rpt.SetParameterReport("Date", String.Format("{0:dd MMMM yyyy}", date));
                            rpt.SetParameterReport("PrintBy", AppConfig.Name);
                            ReportUtil.ShowPreview(rpt);
                        }
                        else
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                        }
                    }

                    //report by zone
                    if (rdoZone.Checked == true)
                    {
                        zoneID = zoneControl.ZoneID;
                        zoneName = zoneControl.ZoneName;
                        Floor = null;
                        List<sp_RPT017_InventoryCheckingListByZone_GetData_Result> tempReport = BusinessClass.GetCheckingListByZoneReport(OwnerID, WarehouseID, date, zoneID, Floor);
                        if (tempReport.Count > 0)
                        {
                            rptRPT017_InventoryCheckListByZoneReport rpt_zone = new rptRPT017_InventoryCheckListByZoneReport(BusinessClass.GetReportDefaultParams("RPT017"));

                            rpt_zone.DataSource = tempReport;
                            List<sp_RPT017_InventoryCheckingListByZone_SubReport_GetData_Result> tempSubReport = BusinessClass.GetCheckingListByZoneSubReport(OwnerID, WarehouseID, date, zoneID, Floor);

                            rpt_zone.SetParameterReport("OwnerName", OwnerName);
                            rpt_zone.SetParameterReport("WarehouseName", WarehouseName);
                            rpt_zone.SetParameterReport("Date", String.Format("{0:dd MMMM yyyy}", date));
                            rpt_zone.SetParameterReport("PrintBy", AppConfig.Name);
                            if (zoneControl.ZoneID == null)
                                rpt_zone.SetParameterReport("Zone", "All");
                            else
                                rpt_zone.SetParameterReport("Zone", zoneControl.ZoneName);
                            rpt_zone.SubReportDatasource(tempSubReport);
                            ReportUtil.ShowPreview(rpt_zone);
                        }
                        else
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                        }

                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            warehouseControl.OwnerID = ownerControl.OwnerID;
            warehouseControl.DataLoading();
            setProductControl();
            setZoneControl();            
        }
        private void warehouseControl_EditValueChanged(object sender, EventArgs e)
        {

            //if (warehouseControl.WarehouseID != null)
            //{
            //    cboFloor.Properties.DataSource = BusinessClass.LoadFloor((Int32)warehouseControl.WarehouseID);
            //    cboFloor.Text = string.Empty;
            //}
            setZoneControl();
        }
        private void cboFloor_EditValueChanged(object sender, EventArgs e)
        {
            setZoneControl();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ownerControl.ClearData();
            warehouseControl.ClearData();
            itemControl.ClearData();
            zoneControl.ClearData();
            //cboFloor.EditValue = string.Empty;
            ControlUtil.ClearControlData(dtMovementSince);
            dtMovementSince.DateTime = DateTime.Today.AddDays(-1);
            rdoProduct.Checked = false;
            rdoZone.Checked = false;

        }
        #endregion

        #region Generic Function
        private Boolean ValidateData()
        {
            Boolean errFlag = true;
            // clear all error
            errorProvider.ClearErrors();
            bool choosedReport = true;

            // set require field
            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;
            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;
            zoneControl.RequireField = true;
            
            #region Customer
            //Customer 
            if (!ownerControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(ownerControl, String.Empty);
            }
            #endregion
            #region Distribution Center
            //Distribution Center
            if (!warehouseControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(ownerControl, String.Empty);
            }
            #endregion
            #region MovementSince
            if (dtMovementSince.EditValue == null)
            {
                errorProvider.SetError(dtMovementSince, Common.GetMessage("I0325"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(dtMovementSince, String.Empty);
            }
            #endregion
                       
            if (rdoProduct.Checked == false && rdoZone.Checked == false)
            {
                choosedReport = false;
            }
            if (false == choosedReport)
            {
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0211"));
            }

            return errFlag;
        }
        private void enableControlProduct(bool status) 
        {
            itemControl.EnableControl = status;
            if (status == false)
                itemControl.ClearData();
        }
        private void enableControlZone(bool status) 
        {
            //ControlUtil.EnableControl(status, cboFloor);
            zoneControl.EnableControl = status;
            //chkAllZone.Enabled = status;
            //chkAllZone.Checked = !status;
            if (status == false)
            {
                zoneControl.ClearData();
                //ControlUtil.ClearControlData(cboFloor);
            }
        }
        private void setZoneControl()
        {
            zoneControl.OwnerID = ownerControl.OwnerID;
            zoneControl.WarehouseID = warehouseControl.WarehouseID;
            //zoneControl.Floor = cboFloor.EditValue == null ? null : Rubix.Framework.DataUtil.Convert<int>(cboFloor.EditValue);
            zoneControl.DataLoading();
        }
        private void setProductControl()
        {
            itemControl.OwnerID = ownerControl.OwnerID;
            itemControl.DataLoading();
        }
        #endregion        
    }
}
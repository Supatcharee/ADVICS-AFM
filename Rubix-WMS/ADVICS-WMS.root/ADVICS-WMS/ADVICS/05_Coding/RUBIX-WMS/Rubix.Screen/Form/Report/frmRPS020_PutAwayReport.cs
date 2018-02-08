using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using CSI.Business.BusinessFactory.Report;
using System.Data.Objects;
using CSI.Business.DataObjects;
using Rubix.Screen.Report;

namespace Rubix.Screen.Form.Report
{
    [ScreenPermissionAttribute(Permission.OpenScreen)]
    public partial class frmRPS020_PutAwayReport : FormBase
    {

        #region Member
        private PutAwayReport db;
        #endregion

        #region Properties
        private PutAwayReport BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new PutAwayReport();
                }
                return db;
            }
        }
        #endregion

        #region Constructor
        public frmRPS020_PutAwayReport()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarCancel, m_toolBarDelete, m_toolBarEdit, m_toolBarExport, m_toolBarRefresh, m_toolBarSave, m_toolBarView);
            ControlUtil.HiddenControl(true, m_toolBarPaintStyls, m_toolBarThemeStyls);

            dtReceivedDateFrom.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtReceivedDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtReceivedDateFrom.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtReceivedDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtReceivedDateFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtReceivedDateFrom.Properties.Mask.EditMask = Common.FullDateFormat;

            dtReceivedDateTo.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtReceivedDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtReceivedDateTo.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtReceivedDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtReceivedDateTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtReceivedDateTo.Properties.Mask.EditMask = Common.FullDateFormat;
        }
        #endregion

        #region Event Handler Function
        private void frmRPS020_PutAwayReport_Load(object sender, EventArgs e)
        {
            DateTime from = ControlUtil.GetStartDate();
            DateTime to = ControlUtil.GetEndDate();
            dtReceivedDateFrom.DateTime = from;
            dtReceivedDateTo.DateTime = to;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (ValidateData())
                {
                    int? OwnerID, WarehouseID, productID, zoneID;
                    int TypeID;
                    String receivingNo, OwnerName, WarehouseName, productName, zoneName;
                    DateTime? transitDate1, transitDate2;

                    OwnerID = ownerControl.OwnerID;
                    OwnerName = ownerControl.OwnerName;
                    WarehouseID = warehouseControl.WarehouseID;
                    WarehouseName = warehouseControl.WarehouseName;
                    productID = itemControl.ProductID;
                    productName = itemControl.ProductLongName;
                    receivingNo = txtSlipNo.Text.Trim();
                    transitDate1 = DataUtil.Convert<DateTime>(dtReceivedDateFrom.EditValue);
                    transitDate2 = DataUtil.Convert<DateTime>(dtReceivedDateTo.EditValue);
                    zoneID = zoneControl.ZoneID;
                    zoneName = zoneControl.ZoneName;

                    TypeID = (rdoPutaway.Checked ? 1 : (rdoAdjustment.Checked ? 2 : 3));
                    
                    List<sp_RPT002_PutAwayReport_GetData_Result> tempReport = BusinessClass.GetDataReport(OwnerID, WarehouseID, productID, receivingNo, transitDate1, transitDate2, zoneID, TypeID);
                    if (tempReport.Count > 0)
                    {
                        foreach (sp_RPT002_PutAwayReport_GetData_Result item in tempReport)
                        {
                            item.Qty = Math.Round(item.Qty, 2);
                            item.StockActualQty = Math.Round(item.StockActualQty, 2);
                        }

                        //tempReport = GenNewDataSource(tempReport);

                        rptRPT002_PutAwayReport rpt = new rptRPT002_PutAwayReport(BusinessClass.GetReportDefaultParams("RPT002"));
                        rpt.DataSource = tempReport;

                        DateTime transDate1 = Convert.ToDateTime(transitDate1);
                        DateTime transDate2 = Convert.ToDateTime(transitDate2);
                        string format = "dd MMMM yyyy";


                        rpt.SetParameterReport("OwnerName", OwnerName);
                        rpt.SetParameterReport("WarehouseName", WarehouseName);
                        rpt.SetParameterReport("transitDateFrom", transDate1.ToString());//transDate1.ToString(format).Split(" ".ToCharArray())[0]);
                        rpt.SetParameterReport("transitDateTo", transDate2.ToString());//transDate2.ToString(format).Trim().Split(" ".ToCharArray())[0]);
                        rpt.SetParameterReport("printBy", AppConfig.Name);
                        rpt.SetParameterReport("ReportType", string.Format("({0})", rdoPutaway.Checked ? rdoPutaway.Text : rdoAdjustment.Checked ? rdoAdjustment.Text : rdoChangeLocaiton.Text));

                        if (string.IsNullOrWhiteSpace(zoneName))
                            zoneName = "All";
                        rpt.SetParameterReport("ZoneName", zoneName);
                        //ADD By Winai S. 04/03/2012
                        List<ReportDefaultParam> lstParam = BusinessClass.GetReportDefaultParams("RPT002");
                        if (lstParam != null && lstParam.Count != 0)
                            rpt.SetParameterReport("ISO", lstParam[7].Value);
                        ReportUtil.ShowPreview(rpt);

                    }
                    else
                    {
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                    }
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ownerControl.ClearData();
            warehouseControl.ClearData();
            itemControl.ClearData();
            ControlUtil.ClearControlData(txtSlipNo, dtReceivedDateFrom, dtReceivedDateTo);
            errorProvider.ClearErrors();
            DateTime from = DateTime.Today.AddDays(1 - DateTime.Today.Day);
            DateTime to = DateTime.Today.AddMonths(1).AddDays(-DateTime.Today.Day);
            dtReceivedDateFrom.DateTime = from;
            dtReceivedDateTo.DateTime = to;
        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            warehouseControl.OwnerID = ownerControl.OwnerID;
            warehouseControl.DataLoading();
            itemControl.OwnerID = ownerControl.OwnerID;
            itemControl.DataLoading();
            zoneControl.OwnerID = ownerControl.OwnerID;
            zoneControl.WarehouseID = warehouseControl.WarehouseID;
            //zoneControl.Floor = cboFloor.EditValue == null ? null : Rubix.Framework.DataUtil.Convert<int>(cboFloor.EditValue);
            zoneControl.DataLoading();
        }

        private void warehouseControl_EditValueChanged(object sender, EventArgs e)
        {
            zoneControl.OwnerID = ownerControl.OwnerID;
            zoneControl.WarehouseID = warehouseControl.WarehouseID;
            //zoneControl.Floor = cboFloor.EditValue == null ? null : Rubix.Framework.DataUtil.Convert<int>(cboFloor.EditValue);
            zoneControl.DataLoading();
        }

        #endregion

        #region Generic Function
        private Boolean ValidateData()
        {
            Boolean errFlag = true;

            // set require field
            ownerControl.ErrorText = Common.GetMessage("I0026");
            ownerControl.RequireField = true;
            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            if (!ownerControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(ownerControl, String.Empty);
            }
            //Distribution Center
            if (!warehouseControl.ValidateControl())
            {
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(warehouseControl, String.Empty);
            }
            //Transit Date
            if (dtReceivedDateFrom.EditValue == null)
            {
                errorProvider.SetError(dtReceivedDateFrom, Rubix.Screen.Common.GetMessage("I0265"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(dtReceivedDateFrom, String.Empty);
            }

            if (dtReceivedDateTo.EditValue == null)
            {
                errorProvider.SetError(dtReceivedDateTo, Rubix.Screen.Common.GetMessage("I0266"));
                errFlag = false;
            }
            else
            {
                errorProvider.SetError(dtReceivedDateTo, String.Empty);
            }
            return errFlag;
        }
        private List<sp_RPT002_PutAwayReport_GetData_Result> GenNewDataSource(List<sp_RPT002_PutAwayReport_GetData_Result> temp)
        {
            sp_RPT002_PutAwayReport_GetData_Result tempCopy = new sp_RPT002_PutAwayReport_GetData_Result();
            sp_RPT002_PutAwayReport_GetData_Result tempCount = new sp_RPT002_PutAwayReport_GetData_Result();
            List<int> CountRow = new List<int>();

            tempCopy = temp[0];

            for (int i = 1; i < temp.Count; i++)
            {
                tempCount = temp[i];

                if (DateTime.Equals(tempCopy.TransitDate, tempCount.TransitDate))
                {
                    if (DateTime.Equals(tempCopy.ReceivingDate, tempCount.ReceivingDate))
                    {
                        if (tempCopy.ProductLongName.Equals(tempCount.ProductLongName))
                        {
                            if (string.Equals(tempCopy.ReceivingNo, tempCount.ReceivingNo))
                            {
                                if (string.Equals(tempCopy.ProductCode, tempCount.ProductCode))
                                {
                                    if (string.Equals(tempCopy.LotNo, tempCount.LotNo))
                                    {
                                        if (string.Equals(tempCopy.PalletNoRef, tempCount.PalletNoRef))
                                        {
                                            if (string.Equals(tempCopy.PalletNo, tempCount.PalletNo))
                                            {
                                                if (string.Equals(tempCopy.LocationCode, tempCount.LocationCode))
                                                {
                                                    tempCount.ProductCode = string.Empty;
                                                    tempCount.ProductLongName = string.Empty;
                                                    tempCount.ProductCode = string.Empty;
                                                    tempCount.LocationCode = string.Empty;
                                                    tempCount.LotNo = string.Empty;
                                                    tempCount.PalletNoRef = string.Empty;
                                                    tempCount.PalletNo = string.Empty;
                                                    tempCount.DetailRemark = string.Empty;
                                                    tempCount.TransitDate = null;
                                                    tempCount.ReceivingNo = string.Empty;
                                                    tempCount.ReceivingDate = null;

                                                    // set flag to merge cell
                                                    tempCount.Flag = 1; // 1 มีค่าเหมือนกับแถวอื่น ปกติ

                                                    temp[i] = tempCount;
                                                    continue;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                tempCopy = temp[i];
                CountRow.Add(i);
            }

            // Flag = 2  เป็นแถวสุดท้ายก่อนเป็นข้อมูลชุดใหม่ที่ไม่ซ้ำ
            foreach (int item in CountRow)
            {
                temp[item - 1].Flag = 2;
            }

            // Flag = 3 เป็นแถวสุดท้ายของหน้าแต่ละหน้า
            for (int j = 14; j < temp.Count; j += 18)
            {
                temp[j].Flag = 3;
            }

            // Flag = 4 เป็นแถวสุดท้ายของ report
            temp[temp.Count - 1].Flag = 4;

            return temp;
        }
        #endregion
    }
}
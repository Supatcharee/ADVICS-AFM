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


namespace Rubix.Screen.Form.Report
{
    [ScreenPermissionAttribute(Permission.OpenScreen)]
    public partial class frmRPS010_ReceivingReport : FormBase
    {

        #region Member
        private ReceivingReport db;
        private Dialog.dlgRPS010_ReceivingReport m_Dialog = null;
        #endregion

        #region Enumeration
        // Column order in grid
        private enum eColumns
        {
            Select
            , ReceivingNo
            , OwnerID
            , OwnerCode         //CustomerCode
            , CustomerName
            , WarehouseCode     //DCCode
            , SupplierName      //DCLongNam
            , ArrivalDate
            , ReceivingDate
        }

        #endregion

        #region Properties
        private ReceivingReport BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new ReceivingReport();
                }
                return db;
            }
        }
        private Dialog.dlgRPS010_ReceivingReport Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgRPS010_ReceivingReport();
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
        public frmRPS010_ReceivingReport()
        {
            InitializeComponent();
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarCancel, m_toolBarDelete, m_toolBarEdit, m_toolBarExport, m_toolBarRefresh, m_toolBarSave, m_toolBarView);
            ControlUtil.HiddenControl(true, m_toolBarPaintStyls, m_toolBarThemeStyls);

            dtReceivedDateActFrom.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtReceivedDateActFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtReceivedDateActFrom.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtReceivedDateActFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtReceivedDateActFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtReceivedDateActFrom.Properties.Mask.EditMask = Common.FullDateFormat;

            dtReceivedDateActTo.Properties.DisplayFormat.FormatString = Common.FullDateFormat;
            dtReceivedDateActTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtReceivedDateActTo.Properties.EditFormat.FormatString = Common.FullDateFormat;
            dtReceivedDateActTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            dtReceivedDateActTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            dtReceivedDateActTo.Properties.Mask.EditMask = Common.FullDateFormat;

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

            colArrivalDate.DisplayFormat.FormatString = Common.FullDateFormat;
            colArrivalDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;

            colReceivedDate.DisplayFormat.FormatString = Common.FullDatetimeFormat;
            colReceivedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
        }
        #endregion

        #region Event Handler Function
        private void frmRPS010_ReceivingReport_Load(object sender, EventArgs e)
        {
            DateTime from = ControlUtil.GetStartDate();
            DateTime to = ControlUtil.GetEndDate();
            dtReceivedDateActFrom.DateTime = from;
            dtReceivedDateFrom.DateTime = from;
            dtReceivedDateActTo.DateTime = to;
            dtReceivedDateTo.DateTime = to;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataLoading();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (true == gdvSearchResult.IsEmpty)
            {
                return;
            }

            List<sp_RPT001_ReceivingReport_SearchAll_Result> temp = (List<sp_RPT001_ReceivingReport_SearchAll_Result>)grdSearchResult.DataSource;
            List<sp_RPT001_ReceivingReport_SearchAll_Result> selectedList = temp.FindAll(c => c.select == true);
            if (selectedList.Count != 0)
            {
                OpenDialog(selectedList);
            }
            else
            {
                MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0011"));
            }
            Cursor.Current = Cursors.Default;
            #region [Not use]
            //foreach (sp_RPT001_ReceivingReport_SearchAll_Result item in temp)
            //{
            //    if (item.select == true)
            //    {
            //        List<sp_RPT001_ReceivingReport_GetData_Result> tempReport = BusinessClass.GetDataReport(item.ReceivingNo);

            //        if (tempReport.Count > 0)
            //        {
            //            tempReport = GenNewDataSource(tempReport);

            //            Rubix.Screen.Report.rptRPT001_ReceivingReport rpt = new Rubix.Screen.Report.rptRPT001_ReceivingReport(BusinessClass.GetReportDefaultParams("RPT001"));

            //            rpt.DataSource = tempReport;
            //            //rpt.SubReportDatasource(CSI.Business.Database.AdminContext.tb_User.Execute(System.Data.Objects.MergeOption.OverwriteChanges));
            //            // Create a report instance, assigned to a Print Tool.
            //            //ReportPrintTool pt = new ReportPrintTool(rpt);
            //            ReportUtil.ShowPreview(rpt);
            //            // Send the report to the default printer.
            //            //pt.ShowPreview();
            //        }
            //        else
            //        {
            //            MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
            //        }

            //    }
            //}
            #endregion

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ControlUtil.ClearControlData(txtSlipNo, dtReceivedDateFrom, dtReceivedDateTo, dtReceivedDateActFrom, dtReceivedDateActTo);
            grdSearchResult.DataSource = null;
            //gdvSearchResult.Columns.Clear();
            ownerControl.ClearData();
            warehouseControl.ClearData();
            ownerControl.ClearData();
            DateTime from = DateTime.Today.AddDays(1 - DateTime.Today.Day);
            DateTime to = DateTime.Today.AddMonths(1).AddDays(-DateTime.Today.Day);
            dtReceivedDateActFrom.DateTime = from;
            dtReceivedDateFrom.DateTime = from;
            dtReceivedDateActTo.DateTime = to;
            dtReceivedDateTo.DateTime = to;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SetSelectColumn(true);
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            SetSelectColumn(false);
        }

        private void customerControl_EditValueChanged(object sender, EventArgs e)
        {
            warehouseControl.OwnerID = ownerControl.OwnerID;
            warehouseControl.DataLoading();
        }
        #endregion

        #region Generic Function
        private void DataLoading()
        {
            try
            {
                if (ValidateData())
                {

                    List<sp_RPT001_ReceivingReport_SearchAll_Result> tempData = BusinessClass.DataLoading(ownerControl.OwnerID, warehouseControl.WarehouseID, txtSlipNo.Text.Trim(), DataUtil.Convert<DateTime>(dtReceivedDateFrom.EditValue), DataUtil.Convert<DateTime>(dtReceivedDateTo.EditValue), DataUtil.Convert<DateTime>(dtReceivedDateActFrom.EditValue), DataUtil.Convert<DateTime>(dtReceivedDateActTo.EditValue));
                    if (tempData.Count > 0)
                    {
                        grdSearchResult.DataSource = tempData;
                        Rubix.Framework.ControlUtil.SetBestWidth(gdvSearchResult);

                        gdvSearchResult.OptionsBehavior.Editable = true;

                        for (int i = 1; i < gdvSearchResult.Columns.Count; i++)
                        {
                            gdvSearchResult.Columns[i].OptionsColumn.AllowEdit = false;
                            gdvSearchResult.Columns[i].OptionsColumn.AllowFocus = false;
                        }
                    }
                    else
                    {
                        grdSearchResult.DataSource = null;
                        MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0014"));
                    } 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetSelectColumn(bool select)
        {
            for (int rowIndex = 0; rowIndex < gdvSearchResult.RowCount; rowIndex++)
            {
                gdvSearchResult.SetRowCellValue(rowIndex, gdvSearchResult.Columns[(int)eColumns.Select], select);
            }
        }

        private void OpenDialog(List<sp_RPT001_ReceivingReport_SearchAll_Result> list)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                Dialog.DataSource = list;
                Dialog.BusinessClass = BusinessClass;

                Dialog.ShowDialog(this);
                Dialog = null;
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

            return errFlag;
        }
        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rubix.Framework;
using CSI.Business.Operation;

namespace Rubix.Screen.Form.Operation.N_PackingMaterial.Dialog
{
    public partial class dlgNPM012_PackingMaterialSummary : DialogBase
    {
        #region member
        private DataTable _SONO;
        private SalePurchaseOrder db;
        private DataSet _dsResult;
        private object ValueBeforeChange;
        private int CanSave = 0;
        #endregion

        #region properties
        public DataSet dsResult
        {
            get { return _dsResult; }
            set { _dsResult = value; }
        }
        public DataTable SONO
        {
            get { return _SONO; }
            set { _SONO = value; }
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
        #endregion

        #region constructor
        public dlgNPM012_PackingMaterialSummary()
        {
            InitializeComponent();
        }
        #endregion

        #region override
        public override bool OnCommandSave()
        {
            try
            {
                ShowWaitScreen();
                gdvSearchResult.CloseEditor();
                gdvSearchResult.UpdateCurrentRow();
                if (CanSave == 0)
                {
                    MessageDialog.ShowBusinessErrorMsg(this, "No purchase price");
                    return false;
                }
                if (!CheckMinOrder())
                {
                    return false;
                }
                DataTable dt = (grdSearchResult.DataSource as DataTable).Copy();
                dt.Columns["Period"].DateTimeMode = DataSetDateTime.Unspecified;
                DataSet ds = new DataSet("PackingMaterialDataSetResult");
                dt.TableName = "PackingMaterialDataTableResult";
                ds.Tables.Add(dt);
                DataSet DSSONo = new DataSet("PackingMaterialDataSet");
                DataTable DTSono = new DataTable("PackingMaterialDataTable");
                DTSono.Columns.Add("SONo");
                foreach (DataRow item in SONO.Rows)
                {
                    DTSono.Rows.Add(item["SONO"].ToString());
                }
                DSSONo.Tables.Add(DTSono);
                int CalculateMethod = (rdoWithSafe.Checked) ? 1 : 0;
                DataSet Result = BusinessClass.Packing_Material_Summary_Save(DSSONo.GetXml(), ds.GetXml(), CalculateMethod);
                dsResult = new DataSet();
                if (Result.Tables.Count > 2)
                {
                    dsResult.Tables.Add(Result.Tables[Result.Tables.Count - 3].Copy());
                    dsResult.Tables.Add(Result.Tables[Result.Tables.Count - 2].Copy());
                    dsResult.Tables.Add(Result.Tables[Result.Tables.Count - 1].Copy());
                }

                this.DialogResult = DialogResult.OK;
                return true;
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
        #endregion

        #region event hendler
        private void dlgNPM012_PackingMaterialSummary_Load(object sender, EventArgs e)
        {
            ControlUtil.HiddenControl(true, m_toolBarClear, m_toolBarImport, m_toolBarSaveACopy, m_toolBarPrint);
            m_statusBar.Visible = false;
            dataLoading();
            CanSave = 1;
        }

        //private void repNumberEdit_Enter(object sender, EventArgs e)
        //{
        //    ValueBeforeChange = (gdvSearchResult.GetFocusedValue() == DBNull.Value) ? 0 : gdvSearchResult.GetFocusedValue();
        //}

        private void repNumberEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewValue.ToString()))
            {
                return;
            }
            DataRow dr = gdvSearchResult.GetFocusedDataRow();
            if (dr != null && !string.IsNullOrEmpty(dr["DMGQty"].ToString()) && !string.IsNullOrEmpty(dr["Adjust"].ToString()))
            {
                double BOM = Convert.ToDouble(dr["BOMQty"]), PrevBal = Convert.ToDouble(dr["CURRENTQty"]), Reserved = Convert.ToDouble(dr["RESERVEDQty"])
                    , DMG = Convert.ToDouble(dr["DMGQty"]), Adjust = Convert.ToDouble(dr["Adjust"]), current = 0, result = 0, SafetyStock = Convert.ToDouble(dr["SafetyStock"]), EstimateStockNextMonth = 0;
                if (gdvSearchResult.FocusedColumn.FieldName == "Adjust")
                {
                    Adjust = Convert.ToDouble(e.NewValue);
                }
                else if (gdvSearchResult.FocusedColumn.FieldName == "DMGQty")
                {
                    DMG = Convert.ToDouble(e.NewValue);
                }
                current = ((BOM - (PrevBal - Reserved)) < 0) ? 0 : (BOM - (PrevBal - Reserved));
                result = current + (DMG + Adjust);
                if (rdoWithSafe.Checked)
                {
                    result = result + SafetyStock;
                }
                EstimateStockNextMonth = (PrevBal - Reserved) + result - BOM;
                dr["TotalOrder"] = result;
                dr["EstimateStockNextMonth"] = EstimateStockNextMonth;
            }
        }
        
        //private void gdvSearchResult_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
        //    try
        //    {
        //        DataRow dr = gdvSearchResult.GetFocusedDataRow();
        //        if (dr != null && !string.IsNullOrEmpty(dr["DMGQty"].ToString()) && !string.IsNullOrEmpty(dr["Adjust"].ToString()))
        //        {
        //            double BOM = Convert.ToDouble(dr["BOMQty"]), PrevBal = Convert.ToDouble(dr["CURRENTQty"]), Reserved = Convert.ToDouble(dr["RESERVEDQty"])
        //                , DMG = Convert.ToDouble(dr["DMGQty"]), Adjust = Convert.ToDouble(dr["Adjust"]), MinOrder = Convert.ToDouble(dr["MinOrder"]), current = 0, SafetyStock = Convert.ToDouble(dr["SafetyStock"]);
        //            current = ((BOM - (PrevBal - Reserved)) < 0) ? 0 : (BOM - (PrevBal - Reserved));
        //            double result = current + (DMG + Adjust);
        //            if (rdoWithSafe.Checked)
        //            {
        //                result = result + SafetyStock;
        //            }
        //            if (result % MinOrder != 0)
        //            {
        //                MessageDialog.ShowBusinessErrorMsg(this, "Item(s) are not order by MOQ. Please re-check.");
        //                dr[e.Column.FieldName] = ValueBeforeChange.ToString();
        //                repNumberEdit_EditValueChanging(sender, new DevExpress.XtraEditors.Controls.ChangingEventArgs(e.Value, ValueBeforeChange));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        private void rdoWithSafe_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gdvSearchResult.RowCount; i++)
                {
                    DataRow drEdit = gdvSearchResult.GetDataRow(i);
                    drEdit["Adjust"] = 0;
                    double BOM = Convert.ToDouble(drEdit["BOMQty"]), PrevBal = Convert.ToDouble(drEdit["CURRENTQty"]), Reserved = Convert.ToDouble(drEdit["RESERVEDQty"])
                    , DMG = Convert.ToDouble(drEdit["DMGQty"]), Adjust = Convert.ToDouble(drEdit["Adjust"]), current = 0, result = 0, SafetyStock = Convert.ToDouble(drEdit["SafetyStock"]), EstimateStockNextMonth = 0;
                    current = ((BOM - (PrevBal - Reserved)) < 0) ? 0 : (BOM - (PrevBal - Reserved));
                    result = current + (DMG + Adjust);
                    if (rdoWithSafe.Checked)
                    {
                        result = result + SafetyStock;
                    }
                    EstimateStockNextMonth = (PrevBal - Reserved) + result - BOM;
                    drEdit["TotalOrder"] = result;
                    drEdit["EstimateStockNextMonth"] = EstimateStockNextMonth;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region generic function
        private void dataLoading()
        {
            try
            {
                ShowWaitScreen();
                DataSet paramSearch = new DataSet("PackingMaterialDataSet");
                DataTable DTSono = new DataTable("PackingMaterialDataTable");
                DTSono.Columns.Add("SONo");
                foreach (DataRow item in SONO.Rows)
                {
                    DTSono.Rows.Add(item["SONO"].ToString());
                }
                paramSearch.Tables.Add(DTSono);
                DataSet ds = BusinessClass.Packing_Material_Summary_Search(paramSearch.GetXml());
                DataTable dt = ds.Tables[0];
                dt.Columns.Add("Adjust", typeof(int));
                dt.Columns.Add("TotalOrder", typeof(int));
                dt.Columns.Add("EstimateStockNextMonth", typeof(int));
                foreach (DataRow drEdit in dt.Rows)
                {
                    drEdit["Adjust"] = 0;
                    double BOM = Convert.ToDouble(drEdit["BOMQty"]), PrevBal = Convert.ToDouble(drEdit["CURRENTQty"]), Reserved = Convert.ToDouble(drEdit["RESERVEDQty"])
                    , DMG = Convert.ToDouble(drEdit["DMGQty"]), Adjust = Convert.ToDouble(drEdit["Adjust"]), current = 0, result = 0
                    , SafetyStock = Convert.ToDouble(drEdit["SafetyStock"]), EstimateStockNextMonth = 0, MinOrder = Convert.ToDouble(drEdit["MinOrder"]);
                    current = ((BOM - (PrevBal - Reserved)) < 0) ? 0 : (BOM - (PrevBal - Reserved));
                    result = current + (DMG + Adjust);
                    if (rdoWithSafe.Checked)
                    {
                        result = result + SafetyStock;
                    }
                    EstimateStockNextMonth = (PrevBal - Reserved) + result - BOM;
                    drEdit["TotalOrder"] = result;
                    drEdit["EstimateStockNextMonth"] = EstimateStockNextMonth;
                    if (result % MinOrder != 0)
                    {
                        drEdit["Adjust"] = MinOrder - (result % MinOrder);
                        Adjust = MinOrder - (result % MinOrder);
                        result = current + (DMG + Adjust);
                        EstimateStockNextMonth = (PrevBal - Reserved) + result - BOM;
                        drEdit["TotalOrder"] = result;
                        drEdit["EstimateStockNextMonth"] = EstimateStockNextMonth;
                    }
                }
                grdSearchResult.DataSource = dt;
                gdvSearchResult.BestFitColumns();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private bool CheckMinOrder()
        {
            try
            {
                for (int i = 0; i < gdvSearchResult.RowCount; i++)
                {
                    DataRow dr = gdvSearchResult.GetDataRow(i);
                    if (dr != null && !string.IsNullOrEmpty(dr["DMGQty"].ToString()) && !string.IsNullOrEmpty(dr["Adjust"].ToString()))
                    {
                        double BOM = Convert.ToDouble(dr["BOMQty"]), PrevBal = Convert.ToDouble(dr["CURRENTQty"]), Reserved = Convert.ToDouble(dr["RESERVEDQty"])
                            , DMG = Convert.ToDouble(dr["DMGQty"]), Adjust = Convert.ToDouble(dr["Adjust"]), MinOrder = Convert.ToDouble(dr["MinOrder"]), current = 0, SafetyStock = Convert.ToDouble(dr["SafetyStock"]);
                        current = ((BOM - (PrevBal - Reserved)) < 0) ? 0 : (BOM - (PrevBal - Reserved));
                        double result = current + (DMG + Adjust);
                        if (rdoWithSafe.Checked)
                        {
                            result = result + SafetyStock;
                        }
                        if (result % MinOrder != 0)
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, "Item " + dr["ProductCode"] + " are not order by MOQ. Please re-check.");
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        private void gdvSearchResult_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                if (e.Column != gdcSupplierCode)
                {
                    DataRow dr = gdvSearchResult.GetDataRow(e.RowHandle);
                    if (dr["PurchasePrice"] == DBNull.Value)
                    {
                        e.Appearance.BackColor = Color.Red;
                        CanSave = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
        }

        private void gdvSearchResult_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            try
            {
                e.Handled = true;
                DataRow FirstRow = gdvSearchResult.GetDataRow(e.RowHandle1);
                DataRow SecondRow = gdvSearchResult.GetDataRow(e.RowHandle2);
                if (e.Column == gdcSupplierCode)
                {
                    if (FirstRow["SupplierCode"].Equals(SecondRow["SupplierCode"]))
                    {
                        e.Merge = true;
                    }
                    else
                    {
                        e.Merge = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog SaveDialog = new SaveFileDialog();
                SaveDialog.AddExtension = true;
                SaveDialog.CheckPathExists = true;
                SaveDialog.DefaultExt = "xlsx";
                SaveDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls";
                SaveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (SaveDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    bool flgAllowCellMerge = gdvSearchResult.OptionsView.AllowCellMerge;
                    try
                    {
                        gdvSearchResult.OptionsPrint.AutoWidth = false;
                        gdvSearchResult.BestFitColumns();
                        gdvSearchResult.OptionsPrint.PrintHeader = gdvSearchResult.OptionsView.ShowColumnHeaders;

                        gdvSearchResult.OptionsView.AllowCellMerge = false;
                        if (SaveDialog.FilterIndex == 1)
                        {
                            gdvSearchResult.ExportToXlsx(SaveDialog.FileName);
                        }
                        else if (SaveDialog.FilterIndex == 2)
                        {
                            gdvSearchResult.ExportToXls(SaveDialog.FileName);
                        }
                        Type officeType = Type.GetTypeFromProgID("Excel.Application");
                        if (officeType == null)
                        {
                            MessageDialog.ShowBusinessErrorMsg(this, "Cannot open this file type! Please check if device is compatible or try copy the file to compatible device.");
                        }
                        else
                        {
                            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                            excel.Visible = true;
                            excel.Workbooks.Open(SaveDialog.FileName);
                        }
                        Rubix.Framework.ControlUtil.SetBestWidth(gdvSearchResult);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, ex.ToString());
                    }
                    gdvSearchResult.OptionsView.AllowCellMerge = flgAllowCellMerge;
                }

            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message); throw ex;
            }
        }


    }
}

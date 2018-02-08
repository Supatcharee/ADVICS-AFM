/*
 * 20121218:
 * 1. Modify EnableControl function to support tab control
 * 12 Feb 2013:
 * 1. add new method for hide control
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTab;
using System.IO;
using System.Data;
namespace Rubix.Framework
{
    public class ControlUtil
    {
        private ControlUtil() { }

        #region EnabledControl

        private static void _EnabledControl(bool bEnabled, Control ctl)
        {
            if (ctl == null || ctl is LabelControl || ctl.GetType().FullName.Contains("Rubix.Control.RequireField"))
                return;
            if (ctl is TextEdit || ctl is DateEdit || ctl is SearchLookUpEdit)
            {
                ((TextEdit)ctl).Properties.ReadOnly = !bEnabled;
                //((TextEdit)ctl).Enabled = bEnabled;
                ((TextEdit)ctl).TabStop = bEnabled;
                ((TextEdit)ctl).ForeColor = SystemColors.ControlText;
            }
            else if (ctl is SimpleButton)
            {
                ((SimpleButton)ctl).Enabled = bEnabled;
                ((SimpleButton)ctl).TabStop = bEnabled;
            }
            else if (ctl is XtraUserControl)
            {
                if (ctl.CanFocus)
                {
                    ctl.TabStop = bEnabled;
                }
                EnableControl(bEnabled, ctl.Controls);
            }
            else if (ctl is CheckEdit)
            {
                ((CheckEdit)ctl).Properties.ReadOnly = !bEnabled;
                ((CheckEdit)ctl).TabStop = bEnabled;
            }
            else if (ctl is ComboBoxEdit)
            {
                ((ComboBoxEdit)ctl).Properties.ReadOnly = !bEnabled;
                ((ComboBoxEdit)ctl).Enabled = bEnabled;
                ((ComboBoxEdit)ctl).TabStop = bEnabled;
                ((ComboBoxEdit)ctl).ForeColor = SystemColors.ControlText;
            }
        }      

        public static void EnableControl(bool bEnabled, params TextEdit[] textedit)
        {
            foreach (TextEdit tex in textedit)
            {
                _EnabledControl(bEnabled, tex);
            }
        }
        public static void EnableControl(bool bEnabled, params BarButtonItem[] barButtonItem)
        {
            foreach (BarButtonItem bar in barButtonItem)
            {
                bar.Enabled = bEnabled;
            }
        }
        public static void EnableControl(bool bEnabled, params SearchLookUpEdit[] searchlookupedit)
        {
            foreach (SearchLookUpEdit sle in searchlookupedit)
            {
                _EnabledControl(bEnabled, sle);
            }
        }
        public static void EnableControl(bool bEnabled, params Control[] Controls)
        {
            foreach (Control c in Controls)
            {
                if (c.Tag != null && c.Tag.ToString().Contains("no control"))
                {

                }
                else
                {
                    if (c is ToolStrip)
                    {
                        return;
                    }
                    else if (c is PanelControl)
                    {
                        EnableControl(bEnabled, ((PanelControl)c).Controls);
                    }
                    else if (c is GroupControl)
                    {
                        EnableControl(bEnabled, ((GroupControl)c).Controls);
                    }
                    else if (c is GroupBox)
                    {
                        EnableControl(bEnabled, ((GroupBox)c).Controls);
                    }
                    else if (c is XtraTabControl)
                    {
                        foreach (XtraTabPage tabPage in ((XtraTabControl)c).TabPages)
                        {
                            EnableControl(bEnabled, tabPage.Controls);
                        }
                    }
                    else
                    {
                        _EnabledControl(bEnabled, c);
                    }
                }
            }
        }
        public static void EnableControl(bool bEnabled, Control.ControlCollection Controls)
        {
            foreach (Control c in Controls)
            {
                //Raktai 2007/06/14---------------
                if (c.Tag != null && c.Tag.ToString().Contains("no control"))
                {

                }
                else
                    //--------------------------------
                    if (c is ToolStrip)
                    {
                        return;
                    }
                    else if (c is PanelControl)
                    {
                        EnableControl(bEnabled, ((PanelControl)c).Controls);
                    }
                    else if (c is GroupControl)
                    {
                        EnableControl(bEnabled, ((GroupControl)c).Controls);
                    }
                    else if (c is GroupBox)
                    {
                        EnableControl(bEnabled, ((GroupBox)c).Controls);
                    }
                    else if (c is XtraTabControl)
                    {
                        foreach (XtraTabPage tabPage in ((XtraTabControl)c).TabPages)
                        {
                            EnableControl(bEnabled, tabPage.Controls);
                        }
                    }
                    else
                    {
                        _EnabledControl(bEnabled, c);
                    }
            }
        }

        public static string LMethod { get; set; }
        public static string LStart { get; set; }
        public static string LStartCurrentDateDate { get; set; }
        public static String LParameter { get; set; }
        public static string LEnd { get; set; }
        public static string LEndCurrentDate { get; set; }
        #endregion

        #region HiddenControl
        
        public static void HiddenControl(bool bHidden, params BarButtonItem[] barButtonItem)
        {
            foreach (BarButtonItem bar in barButtonItem)
            {
                if (bHidden)
                    bar.Visibility = BarItemVisibility.Never;
                else
                {
                    // barButtonItem's tag is used to specify whether can be operated
                    if (bar.Tag == null)
                        bar.Visibility = BarItemVisibility.Always;
                    else
                    {
                        bool canVisible = true;
                        if (bool.TryParse(bar.Tag.ToString(), out canVisible))
                        {
                            bar.Visibility = canVisible ? BarItemVisibility.Always : BarItemVisibility.Never;
                        }
                        else
                        {
                            bar.Visibility = BarItemVisibility.Always;
                        }
                    }
                }
            }
        }

        public static void HiddenControl(bool bHidden, params Bar[] bar)
        {
            foreach (Bar br in bar)
            {
                br.Visible = !bHidden;
            }
        }

        // 12 Feb 2013: add new method
        public static void HiddenControl(bool bHidden, params Control[] Controls)
        {
            foreach (Control c in Controls)
            {
                c.Visible = !bHidden;
            }
        }
        // end 12 Feb 2013

        public static void HiddenControl(bool bHidden, params BarEditItem[] barEditItem)
        {
            foreach (BarEditItem bar in barEditItem)
            {
                if(bHidden)
                    bar.Visibility = BarItemVisibility.Never;
                else
                    bar.Visibility = BarItemVisibility.Always;
            }
        }

        public static void HiddenControl(bool bHidden, GridView gdv, params int[] ColumnHidden)
        {
            foreach (int i in ColumnHidden)
            {
                HiddenControl(bHidden, gdv.Columns[i]);
            }
        }

        public static void HiddenControl(bool bHidden, params GridColumn[] gcArray)
        {

            foreach (GridColumn gc in gcArray)
            {
                bool isVisible = !bHidden;
                gc.Visible = isVisible;
                gc.OptionsColumn.AllowShowHide = isVisible;
                gc.OptionsColumn.ShowInCustomizationForm = isVisible;
                gc.OptionsColumn.ShowInExpressionEditor = isVisible;
            }            
        }
        #endregion

        #region ClearControlData
        private static void _ClearControlData(Control ctl)
        {
            if (ctl == null)
                return;
            if (ctl is DevExpress.XtraEditors.TextEdit)
            {
                ((TextEdit)ctl).EditValue = null;
            }
            else if (ctl is DateEdit)
            {
                ((DateEdit)ctl).EditValue = null;
            }
            else if (ctl is LookUpEdit)
            {
                ((LookUpEdit)ctl).EditValue = null;
            }
            else if (ctl is CheckEdit)
            {
                ((CheckEdit)ctl).EditValue = false;
            }
            else if (ctl is ComboBoxEdit)
            {
                ((ComboBoxEdit)ctl).EditValue = null;
            }
            else if (ctl is IClearable)
            {
                ((IClearable)ctl).ClearData();
            }
            else if (ctl is DevExpress.XtraGrid.GridControl)
            {
                ((DevExpress.XtraGrid.GridControl)ctl).DataSource = null;
                ((DevExpress.XtraGrid.GridControl)ctl).RefreshDataSource();
                //((DevExpress.XtraGrid.GridControl)ctl).MainView.PopulateColumns();
            }
            else if (ctl is System.Windows.Forms.ComboBox && ((System.Windows.Forms.ComboBox)ctl).DropDownStyle == ComboBoxStyle.DropDownList)
            {
                if (((System.Windows.Forms.ComboBox)ctl).Items.Count > 0)
                    ((System.Windows.Forms.ComboBox)ctl).SelectedIndex = 0;
                else
                    ((System.Windows.Forms.ComboBox)ctl).SelectedIndex = -1;
            }
        }
        public static void ClearControlData(params Control[] Controls)
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(GroupBox))
                {
                    ClearControlData(((GroupBox)c).Controls);
                }
                else if (c.GetType() == typeof(TabControl))
                {
                    ClearControlData(((TabControl)c).Controls);
                }
                else if (c.GetType() == typeof(TabPage))
                {
                    ClearControlData(((TabPage)c).Controls);
                }
                else if (c.GetType() == typeof(DevExpress.XtraTab.XtraTabPage))
                {
                    ClearControlData(((DevExpress.XtraTab.XtraTabPage)c).Controls);
                }
                else if (c.GetType() == typeof(Panel))
                {
                    ClearControlData(((Panel)c).Controls);
                }
                else if (c.GetType() == typeof(PanelControl))
                {
                    ClearControlData(((PanelControl)c).Controls);
                }
                else
                {
                    _ClearControlData(c);
                }
            }
        }
        public static void ClearControlData(Control.ControlCollection Controls)
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(GroupBox))
                {
                    ClearControlData(((GroupBox)c).Controls);
                }
                ////Add by Wirachai T. 2007/07/04
                //else if (c.GetType() == typeof(ComboBox))
                //{
                //    ClearControlData(((ComboBox)c).Controls);
                //}
                //// ============================
                else if (c.GetType() == typeof(TabControl))
                {
                    ClearControlData(((TabControl)c).Controls);
                }
                else if (c.GetType() == typeof(TabPage))
                {
                    ClearControlData(((TabPage)c).Controls);
                }
                else if (c.GetType() == typeof(Panel))
                {
                    ClearControlData(((Panel)c).Controls);
                }
                else if (c.GetType() == typeof(PanelControl))
                {
                    ClearControlData(((PanelControl)c).Controls);
                }
                else if (c.GetType() == typeof(GroupControl))
                {
                    ClearControlData(((PanelControl)c).Controls);
                }
                else
                {
                    _ClearControlData(c);
                }
            }
        }
        #endregion

        #region DateTimeConfig
        public static DateTime GetStartDate()
        {
            try
            {
                if (AppConfig.DisplayPeriodMonth <= 0)
                {
                    DateTime dDateFrom = DateTime.Now.AddMonths(AppConfig.DisplayPeriodMonth);
                    return Convert.ToDateTime(string.Format("{0}/{1}/01", dDateFrom.Year, dDateFrom.Month));
                }
                else
                {
                    return Convert.ToDateTime(string.Format("{0}/{1}/01", DateTime.Now.Year, DateTime.Now.Month));
                }
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
        }

        public static DateTime GetEndDate()
        {
            try
            {
                if (AppConfig.DisplayPeriodMonth <= 0)
                {
                    //return Convert.ToDateTime(string.Format("{0}/{1}/01", DateTime.Now.Year, DateTime.Now.Month));
                    DateTime firstOfNextMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);
                    return firstOfNextMonth.AddDays(-1);
                }
                else
                {
                    DateTime dDateFrom = DateTime.Now.AddMonths(AppConfig.DisplayPeriodMonth);
                    //return Convert.ToDateTime(string.Format("{0}/{1}/01", dDateFrom.Year, dDateFrom.Month));

                    DateTime firstOfNextMonth = new DateTime(dDateFrom.Year, dDateFrom.Month, 1).AddMonths(1);
                    return firstOfNextMonth.AddDays(-1);
                }
            }
            catch (Exception ex)
            {
                return DateTime.Now;
            }
        }
        #endregion

        public static void SetBestWidth(DevExpress.XtraGrid.Views.Grid.GridView gv)
        {
            if (gv is BandedGridView)
                SetBestWidthBands((BandedGridView)gv);
            else
                SetBestWidth(gv, null);
        }

        private static void SetBestWidthBands(BandedGridView view)
        {
            bool isVisible = view.OptionsView.ShowColumnHeaders;
            view.BeginUpdate();
            view.OptionsView.ShowColumnHeaders = true;
            foreach (BandedGridColumn col in view.Columns)
            {
                if (col.OwnerBand != null)
                    col.Caption = col.OwnerBand.Caption;
            }
            view.BestFitColumns();
            view.OptionsView.ShowColumnHeaders = isVisible;
            view.EndUpdate();
        }

        public static void SetBestWidth(DevExpress.XtraGrid.Views.Grid.GridView gv, params string[] hideColName)
        {
            gv.BeginUpdate();
            gv.BestFitColumns();
            if (hideColName != null)
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn gc in gv.Columns)
                {
                    if (hideColName.Contains(gc.FieldName))
                        HiddenControl(true, gc);
                }
            }
            gv.EndUpdate();
        }

        public static void SetGridColumnFormat(GridColumn col, string format)
        {
            col.DisplayFormat.FormatString = format;
            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            if (col.RealColumnEdit != null)
            {
                col.RealColumnEdit.EditFormat.FormatString = format;
                col.RealColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            }
        }

        public static Image ConvertByteToImage(byte[] byteImage)
        {
            try
            {
                //Log file
                LMethod = "ConvertByteToImage(byte[] byteImage)";
                LStart = "START";
                LStartCurrentDateDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                
                if (byteImage != null)
                {
                    LParameter = "byte[] byteImage is not null";
                    LogFileStart(LMethod, LStart, LStartCurrentDateDate, LParameter);
                    //----------------------

                    MemoryStream ms = new MemoryStream(byteImage);

                    LEnd = "END";
                    LEndCurrentDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                    LogFileEnd(LMethod, LEnd, LEndCurrentDate);
                    return Image.FromStream(ms);
                }
                else
                {
                    LParameter = "byte[] byteImage is null";
                    LogFileStart(LMethod, LStart, LStartCurrentDateDate, LParameter);

                    LEnd = "END";
                    LEndCurrentDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                    LogFileEnd(LMethod, LEnd, LEndCurrentDate);
                    return null;
                }
            }
            catch (Exception ex)
            {
                LMethod = "Exception --> ConvertByteToImage(byte[] byteImage)";
                LStart = "Start Exception";
                LStartCurrentDateDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                LParameter = String.Format("Exception Message is {0}; StackTrace is {1}", ex.Message, ex.StackTrace);
                LogFileStart(LMethod, LStart, LStartCurrentDateDate, LParameter);

                LEnd = "End Exception";
                LEndCurrentDate = DateTime.Now.ToString("dd/MM/yy HH:mm:ss tt");
                LogFileEnd(LMethod, LEnd, LEndCurrentDate);
                return null;
            }
        }

        public static byte[] ConvertImageByte(Image objImage)
        {
            if (objImage != null)
            {
                ImageConverter _imageConverter = new ImageConverter();
                return (byte[])_imageConverter.ConvertTo(objImage, typeof(byte[]));
            }
            else
            {
                return null;
            }
        }
        public static void LogFile(string Method, string Start, string StartDate, String Parameter, string End, string EndDate)
        {
            DataTable logDataTable = new DataTable();
            logDataTable.Columns.Add("Method", typeof(string));
            logDataTable.Columns.Add("Start", typeof(string));
            logDataTable.Columns.Add("StartDate", typeof(string));
            logDataTable.Columns.Add("Parameter", typeof(string));
            logDataTable.Columns.Add("End", typeof(string));
            logDataTable.Columns.Add("EndDate", typeof(string));


            DataRow logDataRow = logDataTable.NewRow();
            logDataRow["Method"] = Method;
            logDataRow["Start"] = Start;
            logDataRow["StartDate"] = StartDate;
            logDataRow["Parameter"] = Parameter;
            logDataRow["End"] = End;
            logDataRow["EndDate"] = EndDate;

            logDataTable.Rows.Add(logDataRow);

            logDataTable.WriteToCsvFile("");
        }

        public static void LogFileStart(string Method, string Start, string StartDate, string Parameter)
        {
            DataTable logDataTable = new DataTable();
            logDataTable.Columns.Add("Method", typeof(string));
            logDataTable.Columns.Add("Status", typeof(string));
            logDataTable.Columns.Add("CurrentDate", typeof(string));
            logDataTable.Columns.Add("Parameter", typeof(string));

            DataRow logDataRow = logDataTable.NewRow();
            logDataRow["Method"] = Method;
            logDataRow["Status"] = Start;
            logDataRow["CurrentDate"] = StartDate;
            logDataRow["Parameter"] = Parameter;

            logDataTable.Rows.Add(logDataRow);

            logDataTable.WriteToCsvFile("");
        }

        public static void LogFileEnd(string Method, string End, string EndDate)
        {
            DataTable logDataTable = new DataTable();
            logDataTable.Columns.Add("Method", typeof(string));
            logDataTable.Columns.Add("Status", typeof(string));
            logDataTable.Columns.Add("CurrentDate", typeof(string));

            DataRow logDataRow = logDataTable.NewRow();
            logDataRow["Method"] = Method;
            logDataRow["Status"] = End;
            logDataRow["CurrentDate"] = EndDate;

            logDataTable.Rows.Add(logDataRow);

            logDataTable.WriteToCsvFile("");
        }
    }
    
    public static class DataTableExtensions
    {

        public static void WriteToCsvFile(this DataTable dataTable, string filePath)
        {
            StringBuilder fileContent = new StringBuilder();

            string namedir = "Advics_LOG_" + DateTime.Now.ToString("ddMMyyyy");
            string filename = string.Format("ISLog_{0}.csv", DateTime.Now.ToString("yyyyMMdd"));
            string PathFolder = AppDomain.CurrentDomain.BaseDirectory + "\\" + "Advics_LOG" + "\\" + namedir;//AppDomain.CurrentDomain.BaseDirectory + "\\" + namedir;
            string PathFile = string.Format("{0}/{1}", PathFolder, filename);

            if (!Directory.Exists(PathFolder))
            {
                Directory.CreateDirectory(PathFolder);

            }

            if (!File.Exists(PathFile))
            {

                foreach (var col in dataTable.Columns)
                {
                    fileContent.Append(col.ToString() + ",");
                }

                fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);



                foreach (DataRow dr in dataTable.Rows)
                {

                    foreach (var column in dr.ItemArray)
                    {
                        fileContent.Append("\"" + column.ToString() + "\",");
                    }

                    fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
                }


                System.IO.File.WriteAllText(PathFile, fileContent.ToString());
            }
            else
            {
                foreach (DataRow dr in dataTable.Rows)
                {

                    foreach (var column in dr.ItemArray)
                    {
                        fileContent.Append("\"" + column.ToString() + "\",");
                    }

                    fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
                }

                try
                {
                    System.IO.File.AppendAllText(PathFile, fileContent.ToString());
                    FileStream fileStream = new FileStream(PathFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                    fileStream.Close();
                }
                catch (Exception ex) 
                {
                    FileStream fileStream = new FileStream(PathFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                    fileStream.Close();
                }
            }

        }
    }
}

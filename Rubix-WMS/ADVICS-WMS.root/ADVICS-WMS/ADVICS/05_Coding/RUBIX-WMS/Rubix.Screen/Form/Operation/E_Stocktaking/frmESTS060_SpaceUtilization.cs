using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;
using CSI.Business.Operation;
using CSI.Business.Master;
using DevExpress.XtraCharts;

namespace Rubix.Screen.Form.Operation.E_Stocktaking
{
    [ScreenPermissionAttribute(Permission.OpenScreen)]
    public partial class frmESTS060_SpaceUtilization : FormBase
    {
        #region Member
        private WarehouseUtilization db;
        private Dialog.dlgESTS060_SpaceUtilization m_Dialog = null;
        /////////////////////////////////////////////
        private System.Windows.Forms.Control _FocusControl = new System.Windows.Forms.Control();
        private SimpleButton SelectButton;
        private const float FONT_SIZE_BUTTON = 7;
        private const float FONT_SIZE_LABEL = 8;
        private int MarginX = 5;
        private int MarginY = 5;
        private const int NoPixelPerMM = 4;
        /////////////////////////////////////////////
        #endregion

        #region Properties
        private WarehouseUtilization BusinessClass
        {
            get
            {
                if (db == null)
                {
                    db = new WarehouseUtilization();
                }
                return db;
            }
        }

        private Point PointStart
        {
            get { return pnDrawing.AutoScrollPosition; }
        }

        private Dialog.dlgESTS060_SpaceUtilization Dialog
        {
            get
            {
                if (m_Dialog == null)
                {
                    return m_Dialog = new Dialog.dlgESTS060_SpaceUtilization();
                }
                return m_Dialog;
            }
            set
            {
                m_Dialog = value;
            }
        }

        private DataSet SearchResult { get; set; }
        #endregion
        
        #region Construnctor
        public frmESTS060_SpaceUtilization()
        {
            InitializeComponent();
            //base.SetExpandGroupControl(gcSearchCriteria);
            base.SetExpandGroupControl(gcSearchCriteria);
            ControlUtil.HiddenControl(true, m_toolBarAdd, m_toolBarView, m_toolBarSave, m_toolBarRefresh, m_toolBarCancel);
            ControlUtil.HiddenControl(true, m_toolBarPaintStyls, m_toolBarThemeStyls);
            ControlUtil.HiddenControl(true, m_toolBar);
        }
        #endregion

        #region Event Handler
        private void frmESTS060_SpaceUtilization_Load(object sender, EventArgs e)
        {
            warehouseControl.OwnerID = null;
            warehouseControl.DataLoading();

            warehouseControl.ErrorText = Common.GetMessage("I0045");
            warehouseControl.RequireField = true;

            cboLabelPosition.EditValue = "Radial";
            ClearChartData();
            InitChartStyle();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!warehouseControl.ValidateControl())
                {
                    return;
                }

                ShowWaitScreen();
                chtChartingView.Visible = true;
                DataLoading();
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                CloseWaitScreen();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearWareHousePanel();
                warehouseControl.ClearData();
                warehouseControl.OwnerID = null;
                warehouseControl.DataLoading();
                grdZoneSearchResult.DataSource = null;
                grdZoneExportByLocation.DataSource = null;
                SearchResult = null;
                rdoByZone.Checked = true;
                chtChartingView.Visible = false;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            try
            {
                SimpleButton button = (sender as SimpleButton);
                LocationGraphic Tag = button.Tag as LocationGraphic;
                Dialog.LocationInformationDetail = Tag;
                this.Dialog.ShowDialog(this);
                this.Dialog = null;
            }
            catch (Exception ex)
            {
                MessageDialog.ShowSystemErrorMsg(this, ex);
            }
        }

        private void repExport_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                DataRow dr = gdvZoneSearchResult.GetFocusedDataRow();
                grdZoneExportByLocation.DataSource = SearchResult.Tables[2].Select(string.Format("ZoneID = {0}", dr["ZoneID"])).CopyToDataTable();
                if (gdvZoneExportByLocation.RowCount > 0)
                {
                    CloseWaitScreen();
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.AddExtension = true;
                    saveFile.CheckPathExists = true;
                    saveFile.DefaultExt = "xlsx";
                    saveFile.Filter = "Excel Workbook (*.xlsx)|*.xlsx|Excel 97-2003 Workbook (*.xls)|*.xls";
                    saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        gdvZoneExportByLocation.OptionsPrint.AutoWidth = false;
                        gdvZoneExportByLocation.BestFitColumns();
                        gdvZoneExportByLocation.OptionsPrint.PrintHeader = gdvZoneExportByLocation.OptionsView.ShowColumnHeaders;

                        if (saveFile.FilterIndex == 1)
                        {
                            gdvZoneExportByLocation.ExportToXlsx(saveFile.FileName);
                        }
                        else if (saveFile.FilterIndex == 2)
                        {
                            gdvZoneExportByLocation.ExportToXls(saveFile.FileName);
                        }
                        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                        excel.Visible = true;
                        excel.Workbooks.Open(saveFile.FileName);
                    }
                }
                else
                {
                    CloseWaitScreen();
                    MessageDialog.ShowBusinessErrorMsg(this, Common.GetMessage("I0333"));
                }
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
            finally
            {
                CloseWaitScreen();
            }
        }
        
        private void rdoLocationView_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ShowWaitScreen();
                foreach (System.Windows.Forms.Control control in pnDrawing.Controls)
                {
                    if (control.GetType() == typeof(SimpleButton))
                    {
                        SimpleButton button = control as SimpleButton;
                        LocationGraphic Tag = ((control as SimpleButton).Tag as LocationGraphic);
                        if (rdoByZone.Checked)
                        {
                            button.Appearance.BackColor = ColorTranslator.FromHtml(string.Format("#{0}", Tag.ZoneColor));
                        }
                        else if (rdoByUsage.Checked && Tag.UsageUnit == 0)
                        {
                            button.Appearance.BackColor = Color.White;
                        }
                        else if (rdoByUsage.Checked && Tag.UsageUnit != 0 && Tag.UsageUnit < Tag.FullUnit)
                        {
                            button.Appearance.BackColor = Color.LimeGreen;
                        }
                        else
                        {
                            button.Appearance.BackColor = Color.Red;
                        }
                    }
                }
                CloseWaitScreen();
            }
            catch (Exception ex)
            {
                CloseWaitScreen();
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        
        private void chkValueAsPercent_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoWarehouseUsageByUnit.Checked || rdoWarehouseUsageByCapacity.Checked)
                {
                    SetDisplayPercentValue(0);
                }
                else if (rdoProductGroupUsage.Checked)
                {
                    SetDisplayPercentValue(1);
                }
                else if (rdoOwnerUsage.Checked)
                {
                    SetDisplayPercentValue(2);
                }
                else
                {
                    SetDisplayPercentValue(3);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void chkShowLabel_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoWarehouseUsageByUnit.Checked || rdoWarehouseUsageByCapacity.Checked)
                {
                    SetDisplayLabel(0);
                }
                else if (rdoProductGroupUsage.Checked)
                {
                    SetDisplayLabel(1);
                }
                else if (rdoOwnerUsage.Checked)
                {
                    SetDisplayLabel(2);
                }
                else
                {
                    SetDisplayLabel(3);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void cboLabelPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoWarehouseUsageByUnit.Checked || rdoWarehouseUsageByCapacity.Checked)
                {
                    SetLabelPosition(0);
                }
                else if (rdoProductGroupUsage.Checked)
                {
                    SetLabelPosition(1);
                }
                else if (rdoOwnerUsage.Checked)
                {
                    SetLabelPosition(2);
                }
                else
                {
                    SetLabelPosition(3);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void cboExplodeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoWarehouseUsageByUnit.Checked || rdoWarehouseUsageByCapacity.Checked)
                {
                    SetExplodeMode(0);
                }
                else if (rdoProductGroupUsage.Checked)
                {
                    SetExplodeMode(1);
                }
                else if (rdoOwnerUsage.Checked)
                {
                    SetExplodeMode(2);
                }
                else
                {
                    SetExplodeMode(3);
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void rdoUsage_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SetSelectUsageData();
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }

        private void chartUsage_PieSeriesPointExploded(object sender, PieSeriesPointExplodedEventArgs e)
        {
            if (e.Dragged)
            {
                cboExplodeMode.SelectedItem = PieExplodingHelper.Custom;
            }
        }

        private void cboChartStyle_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboChartStyle.EditValue != null)
                {
                    chtChartingView.PaletteName = cboChartStyle.EditValue.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusinessErrorMsg(this, ex.Message, ex.ToString());
            }
        }
        #endregion

        #region Generic Function
        private void DataLoading()
        {
            SearchResult = BusinessClass.SpaceUtilization_Load(Convert.ToInt32(warehouseControl.WarehouseID));
            grdZoneSearchResult.DataSource = SearchResult.Tables[1];
            Rubix.Framework.ControlUtil.SetBestWidth(gdvZoneSearchResult);
            
            List<LocationGraphic> ListLocation = new List<LocationGraphic>();

            foreach (DataRow dr in SearchResult.Tables[0].Rows)
            {
                LocationGraphic lg = new LocationGraphic();
                lg.LayoutID = Convert.ToInt32(dr["LayoutID"]);
                lg.Type = dr["Type"].ToString();
                lg.LocationCode = dr["LocationLayoutCode"].ToString();
                lg.LocationName = dr["LocationLayoutName"].ToString();
                lg.ZoneCode = dr["ZoneCode"].ToString();
                lg.ZoneName = dr["ZoneName"].ToString();
                lg.ZoneColor = dr["ZoneColor"].ToString();
                lg.FullUnit = DataUtil.Convert<int>(dr["FullUnit"].ToString());
                lg.UsageUnit = DataUtil.Convert<int>(dr["UsageUnit"].ToString());
                lg.AvailableUnit = DataUtil.Convert<int>(dr["AvailableUnit"].ToString());
                lg.CaptionPosition = dr["CaptionPosition"].ToString();
                lg.CaptionOffset = GetCaptionOffSet(lg.CaptionPosition);
                lg.LayoutSizeWidthX = Convert.ToInt32(dr["Width"]);
                lg.LayoutSizeHeightY = Convert.ToInt32(dr["Height"]);
                lg.LayoutLocationX = Convert.ToInt32(dr["PositionX"]);
                lg.LayoutLocationY = Convert.ToInt32(dr["PositionY"]);

                DataRow[] drr = SearchResult.Tables[2].Select(string.Format(" LayoutID='{0}' ", dr["LayoutID"]));
                if (drr.Length > 0)
                {
                    lg.LocationInformation = drr.CopyToDataTable();
                }                
                ListLocation.Add(lg);
            }

            LoadWarehouseAndDrawing(ListLocation);
            SetSelectUsageData();
        }

        private void SetSelectUsageData()
        {
            if (rdoWarehouseUsageByUnit.Checked || rdoWarehouseUsageByCapacity.Checked)
            {
                LoadWarehouseUsage();
            }
            else if (rdoProductGroupUsage.Checked)
            {
                LoadProductGroupUsage();
            }
            else if (rdoOwnerUsage.Checked)
            {
                LoadOwnerUsage();
            }
            else
            {
                LoadZoneUsage();
            }
        }

        private void LoadWarehouseUsage()
        {
            if (SearchResult == null)
            {
                return;
            }

            DataTable dt = SearchResult.Tables[3];
            chtChartingView.Series[0].Points.Clear();
            SetSequenceDisplayChart(0);
            int usage = 0;
            int available = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (rdoWarehouseUsageByUnit.Checked)
                {
                    if (dr["AvailableUnit"] != DBNull.Value)
                    {
                        usage = Convert.ToInt32(dr["UsageUnit"]);
                        available = Convert.ToInt32(dr["AvailableUnit"]);
                    }
                    else
                    {
                        available = Convert.ToInt32(dr["FullUnit"]);
                        usage = 0;
                    }
                }
                else
                {
                    if (dr["AvailableUnit"] != DBNull.Value)
                    {
                        usage = Convert.ToInt32(dr["UsageCapacity"]);
                        available = Convert.ToInt32(dr["AvailableCapacity"]);
                    }
                    else
                    {
                        available = Convert.ToInt32(dr["FullCapacity"]);
                        usage = 0;
                    }
                }
                chtChartingView.Series[0].Points.Add(new SeriesPoint("Avaliable", available));
                chtChartingView.Series[0].Points.Add(new SeriesPoint("Usage", usage));
            }
            
            InitExplodeModeComboBox(0);
        }

        private void LoadProductGroupUsage()
        {
            if (SearchResult == null)
            {
                return;
            }

            DataTable dt = SearchResult.Tables[4];
            chtChartingView.Series[1].Points.Clear();
            SetSequenceDisplayChart(1);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["UsageCapacity"] != DBNull.Value)
                {
                    chtChartingView.Series[1].Points.Add(new SeriesPoint(string.Format("{0}", dr["ProductGroupName"]), Convert.ToInt32(dr["UsageCapacity"])));
                }
            }

            InitExplodeModeComboBox(1);
        }

        private void LoadOwnerUsage()
        {
            if (SearchResult == null)
            {
                return;
            }

            DataTable dt = SearchResult.Tables[5];
            chtChartingView.Series[2].Points.Clear();
            SetSequenceDisplayChart(2);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["UsageCapacity"] != DBNull.Value)
                {
                    chtChartingView.Series[2].Points.Add(new SeriesPoint(string.Format("{0}", dr["OwnerName"]), Convert.ToInt32(dr["UsageCapacity"])));
                }
            }

            InitExplodeModeComboBox(2);
        }

        private void LoadZoneUsage()
        {
            if (SearchResult == null)
            {
                return;
            }

            DataTable dt = SearchResult.Tables[1];
            chtChartingView.Series[3].Points.Clear();
            SetSequenceDisplayChart(3);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["UsageCap"] != DBNull.Value)
                {
                    chtChartingView.Series[3].Points.Add(new SeriesPoint(string.Format("{0}:{1}", dr["ZoneCode"], dr["ZoneName"]), Convert.ToInt32(Convert.ToDecimal(dr["UsageCap"]) * 1000)));
                }
            }

            InitExplodeModeComboBox(3);
        }

        private void LoadWarehouseAndDrawing(List<LocationGraphic> list)
        {
            ClearWareHousePanel();

            try
            {
                pnDrawing.SuspendLayout();

                if (list == null || list.Count <= 0)
                {
                    return;
                }

                foreach (LocationGraphic item in list)
                {
                    if (item.LayoutLocationX == null
                        || item.LayoutLocationY == null
                        || item.LayoutSizeWidthX == null
                        || item.LayoutSizeHeightY == null
                        || item.CaptionOffset == null
                        || item.CaptionPosition == null) continue;

                    SimpleButton button = new SimpleButton();
                    Point PointLocation = new Point(item.LayoutLocationX, item.LayoutLocationY);
                    button.Location = PointLocation;
                    button.AllowDrop = true;
                    button.Text = string.Format("{0}{1}{2}/{3}", item.LocationName, Environment.NewLine, item.UsageUnit, item.FullUnit);
                    button.Size = new Size(item.LayoutSizeWidthX * NoPixelPerMM, item.LayoutSizeHeightY * NoPixelPerMM);
                    button.Tag = item;
                    button.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
                    button.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                    button.Appearance.ForeColor = Color.Black;

                    if (rdoByZone.Checked)
                    {
                        button.Appearance.BackColor = ColorTranslator.FromHtml(string.Format("#{0}", item.ZoneColor));
                    }
                    else if (rdoByUsage.Checked && item.UsageUnit == 0)
                    {
                        button.Appearance.BackColor = Color.White;
                    }
                    else if (rdoByUsage.Checked && item.UsageUnit != 0 && item.UsageUnit < item.FullUnit)
                    {
                        button.Appearance.BackColor = Color.LimeGreen;
                    }
                    else
                    {
                        button.Appearance.BackColor = Color.Red;
                    }

                    DevExpress.Utils.SuperToolTip superToolTip = new DevExpress.Utils.SuperToolTip();
                    DevExpress.Utils.ToolTipTitleItem ttTitleItemHeader = new DevExpress.Utils.ToolTipTitleItem();
                    DevExpress.Utils.ToolTipItem ttItemContent = new DevExpress.Utils.ToolTipItem();
                    ttTitleItemHeader.Text = String.Format("Location - {0} : {1}", item.LocationCode, item.LocationName);
                    ttItemContent.LeftIndent = 6;
                    //\r\n
                    ttItemContent.Text = String.Format(@"Zone - {1} : {2}{0}Usage Qty: {3}{0}Available Qty: {4}{0}Full Capacity Qty: {5}",
                        "\r\n",
                        item.ZoneCode,
                        item.ZoneName,
                        item.UsageUnit.Value.ToString("N0"),
                        item.AvailableUnit.Value.ToString("N0"),
                        item.FullUnit.Value.ToString("N0"));
                    superToolTip.Items.Add(ttTitleItemHeader);
                    superToolTip.Items.Add(ttItemContent);
                    button.SuperTip = superToolTip;

                    Font _Font = new Font(button.Appearance.Font.FontFamily, FONT_SIZE_BUTTON);
                    button.Appearance.Font = _Font;

                    button.Click += Button_Click;

                    LabelControl label = new LabelControl();
                    label.AllowDrop = true;

                    _Font = new Font(label.Appearance.Font.FontFamily, FONT_SIZE_LABEL);
                    label.Appearance.Font = _Font;
                    label.Appearance.BackColor = Color.Transparent;
                    label.Appearance.ForeColor = Color.Black;

                    label.AutoSizeMode = LabelAutoSizeMode.Default;

                    item.LabelDetail = label;
                    SetLabel(button);
                    pnDrawing.Controls.Add(button);
                    pnDrawing.Controls.Add(label);
                }
                AdjustPanelDrawing();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                pnDrawing.ResumeLayout();
            }
        }

        public int GetCaptionOffSet(string PositionKey)
        {
            switch (PositionKey)
            {
                case "T": return 1;
                case "B": return 1;
                case "L": return 3;
                case "R": return 3;
                default: return 0;
            }
        }

        protected void SetLabel(SimpleButton button)
        {
            //LocationGraphic item = button.Tag as LocationGraphic;
            //LabelControl label = item.LabelDetail;
            //Point CaptionLocation;
            //label.Text = item.LocationName;
            //label.Size = label.CalcBestSize();

            //if (item.CaptionPosition == "T")
            //{
            //    CaptionLocation = new Point(button.Location.X + ((button.Size.Width - label.Size.Width) / 2)
            //                                , button.Location.Y - label.Size.Height - item.CaptionOffset);
            //}
            //else if (item.CaptionPosition == "B")
            //{
            //    CaptionLocation = new Point(button.Location.X + ((button.Size.Width - label.Size.Width) / 2)
            //                                , button.Location.Y + button.Size.Height + item.CaptionOffset);
            //}
            //else if (item.CaptionPosition == "R")
            //{
            //    CaptionLocation = new Point(button.Location.X + button.Size.Width + item.CaptionOffset
            //                                , button.Location.Y + ((button.Size.Height - label.Size.Height) / 2));
            //}
            //else
            //{
            //    CaptionLocation = new Point(button.Location.X - label.Size.Width - item.CaptionOffset
            //                                , button.Location.Y + ((button.Size.Height - label.Size.Height) / 2));
            //}

            //label.Location = CaptionLocation;
        }

        protected void AdjustPanelDrawing()
        {
            List<System.Windows.Forms.Control> listControl = new List<System.Windows.Forms.Control>();
            SimpleButton button;
            LabelControl label;
            foreach (System.Windows.Forms.Control control in pnDrawing.Controls)
            {
                if (control.GetType() == typeof(SimpleButton))
                {
                    button = control as SimpleButton;
                    LocationGraphic tag = button.Tag as LocationGraphic;
                    label = tag.LabelDetail;

                    if (label.Location.X < PointStart.X
                        || button.Location.X < PointStart.X)
                    {
                        if (label.Location.X < button.Location.X)
                        {
                            button.Location = new Point(button.Location.X + PointStart.X - label.Location.X + MarginX, button.Location.Y);
                            label.Location = new Point(PointStart.X + MarginX, label.Location.Y);
                        }
                        else
                        {
                            label.Location = new Point(label.Location.X + PointStart.X - button.Location.X + MarginX, label.Location.Y);
                            button.Location = new Point(PointStart.X + MarginX, button.Location.Y);
                        }
                    }

                    if (label.Location.Y < PointStart.Y
                        || button.Location.Y < PointStart.Y)
                    {
                        if (label.Location.Y < button.Location.Y)
                        {
                            button.Location = new Point(button.Location.X, button.Location.Y + PointStart.Y - label.Location.Y + MarginY);
                            label.Location = new Point(label.Location.X, PointStart.Y + MarginY);
                        }
                        else
                        {
                            label.Location = new Point(label.Location.X, label.Location.Y + PointStart.Y - button.Location.Y + MarginY);
                            button.Location = new Point(button.Location.X, PointStart.Y + MarginY);
                        }
                    }
                }
            }

            if (SelectButton != null)
            {
                label = (SelectButton.Tag as LocationGraphic).LabelDetail;
                int minX = label.Location.X - PointStart.X < SelectButton.Location.X - PointStart.X ? label.Location.X - PointStart.X : SelectButton.Location.X - PointStart.X;
                int minY = label.Location.Y - PointStart.Y < SelectButton.Location.Y - PointStart.Y ? label.Location.Y - PointStart.Y : SelectButton.Location.Y - PointStart.Y;
                int maxX = label.Location.X + label.Size.Width - PointStart.X > SelectButton.Location.X + SelectButton.Size.Width - PointStart.X ? label.Location.X + label.Size.Width - PointStart.X : SelectButton.Location.X + SelectButton.Size.Width - PointStart.X;
                int maxY = label.Location.Y + label.Size.Height - PointStart.Y > SelectButton.Location.Y + SelectButton.Size.Height - PointStart.Y ? label.Location.Y + label.Size.Height - PointStart.Y : SelectButton.Location.Y + SelectButton.Size.Height - PointStart.Y;
                if (minX < 0 || minY < 0)
                {
                    pnDrawing.AutoScrollPosition = new Point(minX, minY);
                }
                if (maxX > pnDrawing.Size.Width || maxY > pnDrawing.Size.Height)
                {
                    pnDrawing.AutoScrollPosition = new Point(maxX, maxY);
                }
            }
        }
        
        private void ClearWareHousePanel()
        {
            SelectButton = null;
            _FocusControl = null;
            pnDrawing.SuspendLayout();
            int controlCnt = pnDrawing.Controls.Count;
            for (int i = 0; i < controlCnt; i++)
            {
                System.Windows.Forms.Control ctrl = pnDrawing.Controls[0];
                pnDrawing.Controls.RemoveAt(0);
                ctrl.Dispose();
                ctrl = null;
            }
            pnDrawing.ResumeLayout();
            GC.Collect();
        }

        private void SetNumericOptions(Series series, NumericFormat format, int precision)
        {
            series.Label.PointOptions.ValueNumericOptions.Format = format;
            series.Label.PointOptions.ValueNumericOptions.Precision = precision;
        }

        private void SetDisplayPercentValue(int SeriesIndex)
        {
            if (chtChartingView.Series.Count != 0)
            {
                PiePointOptions options = chtChartingView.Series[SeriesIndex].Label.PointOptions as PiePointOptions;
                if (options != null)
                {
                    options.PercentOptions.ValueAsPercent = chkValueAsPercent.Checked;
                    if (chkValueAsPercent.Checked)
                    {
                        SetNumericOptions(chtChartingView.Series[SeriesIndex], NumericFormat.Percent, 0);
                    }
                    else
                    {
                        SetNumericOptions(chtChartingView.Series[SeriesIndex], NumericFormat.FixedPoint, 0);
                    }
                }
            }
        }

        private void SetDisplayLabel(int SeriesIndex)
        {
            if (chtChartingView.Series.Count != 0)
            {
                chtChartingView.Series[SeriesIndex].Label.Visible = chkShowLabel.Checked;
            }
        }

        private void SetLabelPosition(int SeriesIndex)
        {
            if (chtChartingView.Series.Count != 0)
            {
                PieSeriesLabel label = chtChartingView.Series[SeriesIndex].Label as PieSeriesLabel;
                if (label != null)
                {
                    label.Position = (PieSeriesLabelPosition)cboLabelPosition.SelectedIndex;
                    label.TextColor = (label.Position == PieSeriesLabelPosition.Outside || label.Position == PieSeriesLabelPosition.TwoColumns) ? Color.Empty : Color.Black;
                    label.Antialiasing = label.Position == PieSeriesLabelPosition.Radial || label.Position == PieSeriesLabelPosition.Tangent;
                }
            }
        }

        private void SetExplodeMode(int SeriesIndex)
        {
            if (chtChartingView.Series.Count != 0)
            {
                PieSeriesView view = chtChartingView.Series[SeriesIndex].View as PieSeriesView;
                if (view != null)
                {
                    string mode = (string)cboExplodeMode.SelectedItem;
                    PieExplodingHelper.ApplyMode(view, mode);
                }
            }
        }

        private void InitExplodeModeComboBox(int SeriesIndex)
        {
            if (chtChartingView.Series.Count != 0)
            {
                cboExplodeMode.Properties.Items.Clear();
                cboExplodeMode.Properties.Items.AddRange(PieExplodingHelper.CreateModeList(chtChartingView.Series[SeriesIndex].Points, true));
                cboExplodeMode.SelectedIndex = 0;
            }
        }

        private void SetSequenceDisplayChart(int Sequence)
        {
            if (chtChartingView.Series.Count != 0)
            {
                chtChartingView.Series[0].Visible = 0 == Sequence;
                chtChartingView.Series[1].Visible = 1 == Sequence;
                chtChartingView.Series[2].Visible = 2 == Sequence;
                chtChartingView.Series[3].Visible = 3 == Sequence;

                SetDisplayPercentValue(Sequence);
                SetDisplayLabel(Sequence);
                SetLabelPosition(Sequence);
                SetExplodeMode(Sequence);
            }
        }

        private void ClearChartData()
        {
            chtChartingView.Series[0].Points.Clear();
            chtChartingView.Series[1].Points.Clear();
            chtChartingView.Series[2].Points.Clear();
            chtChartingView.Series[3].Points.Clear();
        }

        private void InitChartStyle()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("StyleName", typeof(string));
            dt.Columns.Add("StylePicture", typeof(byte[]));

            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Apex", Properties.Resources.Apex));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Aspect", Properties.Resources.Aspect));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Black and White", Properties.Resources.Black_and_White));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Chameleon", Properties.Resources.Chameleon));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Civic", Properties.Resources.Civic));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Concourse", Properties.Resources.Concourse));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Equity", Properties.Resources.Equity));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Flow", Properties.Resources.Flow));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Foundry", Properties.Resources.Foundry));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Grayscale", Properties.Resources.Grayscale));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "In A Fog", Properties.Resources.In_A_Fog));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Median", Properties.Resources.Median));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Metro", Properties.Resources.Metro));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Module", Properties.Resources.Module));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Nature Colors", Properties.Resources.Nature_Colors));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Northern Lights", Properties.Resources.Narthern_Lights));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Office", Properties.Resources.Office));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Opulent", Properties.Resources.Opulent));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Oriel", Properties.Resources.Oriel));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Origin", Properties.Resources.Origin));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Paper", Properties.Resources.Paper));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Pastel Kit", Properties.Resources.Pastel_Kit));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Solstice", Properties.Resources.Solstice));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Terracotta Pie", Properties.Resources.Terracotta_Pie));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "The Mixed", Properties.Resources.The_Mixed));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "The Trees", Properties.Resources.The_Trees));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Trek", Properties.Resources.Trek));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Urban", Properties.Resources.Urban));
            dt.Rows.Add(InitialChartStyleRow(dt.NewRow(), "Verve", Properties.Resources.Verve));
            
            cboChartStyle.Properties.DataSource = dt;
            cboChartStyle.Properties.ValueMember = "StyleName";
            cboChartStyle.Properties.DisplayMember = "StyleName";
            cboChartStyle.EditValue = "In A Fog";
            
        }

        private DataRow InitialChartStyleRow(DataRow dr, string StyleName, Bitmap StylePicture)
        {
            dr["StyleName"] = StyleName;
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            StylePicture.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            dr["StylePicture"] = stream.ToArray();
            return dr;
        }
        #endregion    
    }

    public static class PieExplodingHelper
    {
        static SeriesPointFilter CreateFilter(string mode)
        {
            return new SeriesPointFilter(SeriesPointKey.Argument, DataFilterCondition.Equal, mode);
        }

        static void ApplyFilterMode(PieSeriesViewBase view, string mode)
        {
            view.ExplodedPointsFilters.Clear();
            view.ExplodedPointsFilters.Add(CreateFilter(mode));
            view.ExplodeMode = PieExplodeMode.UseFilters;
        }

        public const string None = "None";
        public const string All = "All";
        public const string MinValue = "Min Value";
        public const string MaxValue = "Max Value";
        public const string Custom = "Custom";

        public static List<string> CreateModeList(SeriesPointCollection points, bool supportCustom)
        {
            List<string> list = new List<string>();
            list.Add(None);
            list.Add(All);
            list.Add(MinValue);
            list.Add(MaxValue);
            foreach (SeriesPoint point in points)
                list.Add(point.Argument);
            if (supportCustom)
                list.Add(Custom);
            return list;
        }

        public static void ApplyMode(PieSeriesViewBase view, string mode)
        {
            switch (mode)
            {
                case Custom:
                    break;
                case None:
                    view.ExplodeMode = PieExplodeMode.None;
                    break;
                case All:
                    view.ExplodeMode = PieExplodeMode.All;
                    break;
                case MinValue:
                    view.ExplodeMode = PieExplodeMode.MinValue;
                    break;
                case MaxValue:
                    view.ExplodeMode = PieExplodeMode.MaxValue;
                    break;
                default:
                    ApplyFilterMode(view, mode);
                    break;
            }
        }
    }
}

 
namespace Rubix.Screen.Form.Operation.E_Stocktaking
{
    partial class frmESTS060_SpaceUtilization
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmESTS060_SpaceUtilization));
            DevExpress.XtraCharts.Series series9 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel11 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PiePointOptions piePointOptions9 = new DevExpress.XtraCharts.PiePointOptions();
            DevExpress.XtraCharts.SeriesPoint seriesPoint5 = new DevExpress.XtraCharts.SeriesPoint("Available", new object[] {
            ((object)(60D))}, 0);
            DevExpress.XtraCharts.SeriesPoint seriesPoint6 = new DevExpress.XtraCharts.SeriesPoint("Usage", new object[] {
            ((object)(40D))}, 1);
            DevExpress.XtraCharts.PieSeriesView pieSeriesView11 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.Series series10 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel12 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PiePointOptions piePointOptions10 = new DevExpress.XtraCharts.PiePointOptions();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView12 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.Series series11 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel13 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PiePointOptions piePointOptions11 = new DevExpress.XtraCharts.PiePointOptions();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView13 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.Series series12 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel14 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PiePointOptions piePointOptions12 = new DevExpress.XtraCharts.PiePointOptions();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView14 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel15 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView15 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gcSearchCriteria = new DevExpress.XtraEditors.GroupControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.requireField4 = new Rubix.Control.RequireField();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblEmpty = new DevExpress.XtraEditors.LabelControl();
            this.lblFull = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.rdoByUsage = new DevExpress.XtraEditors.CheckEdit();
            this.rdoByZone = new DevExpress.XtraEditors.CheckEdit();
            this.tabWarehouseUtilization = new DevExpress.XtraTab.XtraTabControl();
            this.xtpTopView = new DevExpress.XtraTab.XtraTabPage();
            this.pnDrawing = new DevExpress.XtraEditors.XtraScrollableControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.xtpChartingView = new DevExpress.XtraTab.XtraTabPage();
            this.chtChartingView = new DevExpress.XtraCharts.ChartControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cboChartStyle = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcStyleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcStylePicture = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkValueAsPercent = new DevExpress.XtraEditors.CheckEdit();
            this.chkShowLabel = new DevExpress.XtraEditors.CheckEdit();
            this.label1 = new DevExpress.XtraEditors.LabelControl();
            this.cboLabelPosition = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelPosition = new DevExpress.XtraEditors.LabelControl();
            this.cboExplodeMode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.rdoWarehouseUsageByCapacity = new DevExpress.XtraEditors.CheckEdit();
            this.rdoZoneUsage = new DevExpress.XtraEditors.CheckEdit();
            this.rdoOwnerUsage = new DevExpress.XtraEditors.CheckEdit();
            this.rdoProductGroupUsage = new DevExpress.XtraEditors.CheckEdit();
            this.rdoWarehouseUsageByUnit = new DevExpress.XtraEditors.CheckEdit();
            this.xtpDetailView = new DevExpress.XtraTab.XtraTabPage();
            this.grdZoneExportByLocation = new DevExpress.XtraGrid.GridControl();
            this.gdvZoneExportByLocation = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand24 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand26 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gdcZoneCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand25 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gdcZoneName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand13 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand28 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gdcLocationName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand27 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gdcLocationCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand14 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand15 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gdcFullCapacity = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand16 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gdcUsageCapacity = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand17 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gdcAvailableCapacity = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand18 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand19 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand20 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand21 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand22 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand23 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.grdZoneSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvZoneSearchResult = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colZoneName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colZoneColor = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repColorEdit = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
            this.colZoneID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colFullCap = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colUsageCap = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colAvailableCap = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colUsagePercentCap = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colFullUnit = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colUsageUnit = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand11 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colAvailableUnit = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand10 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colUsagePercentUnit = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand12 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colExport = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repExport = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSearchCriteria)).BeginInit();
            this.gcSearchCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoByUsage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoByZone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabWarehouseUtilization)).BeginInit();
            this.tabWarehouseUtilization.SuspendLayout();
            this.xtpTopView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.xtpChartingView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtChartingView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboChartStyle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkValueAsPercent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLabelPosition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExplodeMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoWarehouseUsageByCapacity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoZoneUsage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoOwnerUsage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoProductGroupUsage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoWarehouseUsageByUnit.Properties)).BeginInit();
            this.xtpDetailView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdZoneExportByLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvZoneExportByLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZoneSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvZoneSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repColorEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repExport)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Location = new System.Drawing.Point(0, 88);
            this.ribbonControl1.Size = new System.Drawing.Size(1051, 47);
            // 
            // gcSearchCriteria
            // 
            this.gcSearchCriteria.Controls.Add(this.btnSearch);
            this.gcSearchCriteria.Controls.Add(this.btnClear);
            this.gcSearchCriteria.Controls.Add(this.requireField4);
            this.gcSearchCriteria.Controls.Add(this.warehouseControl);
            this.gcSearchCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcSearchCriteria.Location = new System.Drawing.Point(0, 31);
            this.gcSearchCriteria.Name = "gcSearchCriteria";
            this.gcSearchCriteria.Size = new System.Drawing.Size(1051, 57);
            this.gcSearchCriteria.TabIndex = 35;
            this.gcSearchCriteria.Text = "Search Criteria";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(890, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(971, 27);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // requireField4
            // 
            this.requireField4.Location = new System.Drawing.Point(92, 34);
            this.requireField4.Name = "requireField4";
            this.requireField4.Size = new System.Drawing.Size(10, 10);
            this.requireField4.TabIndex = 156;
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(28, 28);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(434, 21);
            this.warehouseControl.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.lblEmpty);
            this.panelControl1.Controls.Add(this.lblFull);
            this.panelControl1.Controls.Add(this.simpleButton3);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Location = new System.Drawing.Point(737, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(300, 34);
            this.panelControl1.TabIndex = 165;
            // 
            // lblEmpty
            // 
            this.lblEmpty.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblEmpty.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblEmpty.Location = new System.Drawing.Point(37, 8);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(71, 17);
            this.lblEmpty.TabIndex = 162;
            this.lblEmpty.Text = "Empty";
            // 
            // lblFull
            // 
            this.lblFull.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblFull.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFull.Location = new System.Drawing.Point(251, 8);
            this.lblFull.Name = "lblFull";
            this.lblFull.Size = new System.Drawing.Size(71, 17);
            this.lblFull.TabIndex = 163;
            this.lblFull.Text = "Full";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.BackColor = System.Drawing.Color.Red;
            this.simpleButton3.Appearance.Options.UseBackColor = true;
            this.simpleButton3.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton3.Enabled = false;
            this.simpleButton3.Location = new System.Drawing.Point(220, 5);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(27, 23);
            this.simpleButton3.TabIndex = 161;
            this.simpleButton3.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(143, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 17);
            this.labelControl1.TabIndex = 164;
            this.labelControl1.Text = "Available";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.White;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton1.Enabled = false;
            this.simpleButton1.Location = new System.Drawing.Point(5, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(27, 23);
            this.simpleButton1.TabIndex = 159;
            this.simpleButton1.TabStop = false;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.BackColor = System.Drawing.Color.LimeGreen;
            this.simpleButton2.Appearance.Options.UseBackColor = true;
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.simpleButton2.Enabled = false;
            this.simpleButton2.Location = new System.Drawing.Point(111, 5);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(27, 23);
            this.simpleButton2.TabIndex = 160;
            this.simpleButton2.TabStop = false;
            // 
            // rdoByUsage
            // 
            this.rdoByUsage.Location = new System.Drawing.Point(151, 32);
            this.rdoByUsage.MenuManager = this.ribbonControl1;
            this.rdoByUsage.Name = "rdoByUsage";
            this.rdoByUsage.Properties.Caption = "By Usage";
            this.rdoByUsage.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdoByUsage.Properties.RadioGroupIndex = 0;
            this.rdoByUsage.Size = new System.Drawing.Size(139, 19);
            this.rdoByUsage.TabIndex = 5;
            this.rdoByUsage.TabStop = false;
            this.rdoByUsage.CheckedChanged += new System.EventHandler(this.rdoLocationView_CheckedChanged);
            // 
            // rdoByZone
            // 
            this.rdoByZone.EditValue = true;
            this.rdoByZone.Location = new System.Drawing.Point(15, 32);
            this.rdoByZone.MenuManager = this.ribbonControl1;
            this.rdoByZone.Name = "rdoByZone";
            this.rdoByZone.Properties.Caption = "By Zone";
            this.rdoByZone.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdoByZone.Properties.RadioGroupIndex = 0;
            this.rdoByZone.Size = new System.Drawing.Size(132, 19);
            this.rdoByZone.TabIndex = 4;
            this.rdoByZone.CheckedChanged += new System.EventHandler(this.rdoLocationView_CheckedChanged);
            // 
            // tabWarehouseUtilization
            // 
            this.tabWarehouseUtilization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabWarehouseUtilization.Location = new System.Drawing.Point(0, 135);
            this.tabWarehouseUtilization.Name = "tabWarehouseUtilization";
            this.tabWarehouseUtilization.SelectedTabPage = this.xtpTopView;
            this.tabWarehouseUtilization.Size = new System.Drawing.Size(1051, 524);
            this.tabWarehouseUtilization.TabIndex = 38;
            this.tabWarehouseUtilization.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtpTopView,
            this.xtpChartingView,
            this.xtpDetailView});
            // 
            // xtpTopView
            // 
            this.xtpTopView.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtpTopView.Appearance.Header.Options.UseFont = true;
            this.xtpTopView.Controls.Add(this.pnDrawing);
            this.xtpTopView.Controls.Add(this.groupControl3);
            this.xtpTopView.Name = "xtpTopView";
            this.xtpTopView.Size = new System.Drawing.Size(1045, 496);
            this.xtpTopView.Text = "Top View";
            // 
            // pnDrawing
            // 
            this.pnDrawing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDrawing.Location = new System.Drawing.Point(0, 64);
            this.pnDrawing.Name = "pnDrawing";
            this.pnDrawing.Size = new System.Drawing.Size(1045, 432);
            this.pnDrawing.TabIndex = 179;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.panelControl1);
            this.groupControl3.Controls.Add(this.rdoByZone);
            this.groupControl3.Controls.Add(this.rdoByUsage);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(1045, 64);
            this.groupControl3.TabIndex = 177;
            this.groupControl3.Text = "Location View";
            // 
            // xtpChartingView
            // 
            this.xtpChartingView.AccessibleName = "";
            this.xtpChartingView.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.xtpChartingView.Appearance.Header.Options.UseFont = true;
            this.xtpChartingView.Appearance.PageClient.BackColor = System.Drawing.Color.Maroon;
            this.xtpChartingView.Appearance.PageClient.Options.UseBackColor = true;
            this.xtpChartingView.Controls.Add(this.chtChartingView);
            this.xtpChartingView.Controls.Add(this.groupControl2);
            this.xtpChartingView.Controls.Add(this.groupControl1);
            this.xtpChartingView.Name = "xtpChartingView";
            this.xtpChartingView.Size = new System.Drawing.Size(1045, 496);
            this.xtpChartingView.Text = "Charting View";
            // 
            // chtChartingView
            // 
            this.chtChartingView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chtChartingView.AppearanceNameSerializable = "In A Fog";
            this.chtChartingView.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;
            this.chtChartingView.Legend.BackColor = System.Drawing.Color.Transparent;
            this.chtChartingView.Location = new System.Drawing.Point(1, 105);
            this.chtChartingView.Name = "chtChartingView";
            pieSeriesLabel11.BackColor = System.Drawing.Color.Transparent;
            pieSeriesLabel11.Border.Visible = false;
            pieSeriesLabel11.ColumnIndent = 20;
            pieSeriesLabel11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            pieSeriesLabel11.LineLength = 30;
            pieSeriesLabel11.LineVisible = true;
            piePointOptions9.PercentOptions.ValueAsPercent = false;
            piePointOptions9.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
            piePointOptions9.ValueNumericOptions.Precision = 0;
            pieSeriesLabel11.PointOptions = piePointOptions9;
            pieSeriesLabel11.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.TwoColumns;
            series9.Label = pieSeriesLabel11;
            series9.Name = "WarehouseUsage";
            series9.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint5,
            seriesPoint6});
            pieSeriesView11.Rotation = 90;
            pieSeriesView11.RuntimeExploding = true;
            series9.View = pieSeriesView11;
            pieSeriesLabel12.BackColor = System.Drawing.Color.Transparent;
            pieSeriesLabel12.Border.Visible = false;
            pieSeriesLabel12.ColumnIndent = 20;
            pieSeriesLabel12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            pieSeriesLabel12.LineLength = 30;
            pieSeriesLabel12.LineVisible = true;
            piePointOptions10.PercentOptions.ValueAsPercent = false;
            piePointOptions10.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
            piePointOptions10.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.FixedPoint;
            piePointOptions10.ValueNumericOptions.Precision = 0;
            pieSeriesLabel12.PointOptions = piePointOptions10;
            pieSeriesLabel12.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.TwoColumns;
            series10.Label = pieSeriesLabel12;
            series10.Name = "ProductGroupUsage";
            pieSeriesView12.Rotation = 90;
            pieSeriesView12.RuntimeExploding = true;
            series10.View = pieSeriesView12;
            series10.Visible = false;
            pieSeriesLabel13.BackColor = System.Drawing.Color.Transparent;
            pieSeriesLabel13.Border.Visible = false;
            pieSeriesLabel13.ColumnIndent = 20;
            pieSeriesLabel13.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            pieSeriesLabel13.LineLength = 30;
            pieSeriesLabel13.LineVisible = true;
            piePointOptions11.PercentOptions.ValueAsPercent = false;
            piePointOptions11.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
            piePointOptions11.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.FixedPoint;
            piePointOptions11.ValueNumericOptions.Precision = 0;
            pieSeriesLabel13.PointOptions = piePointOptions11;
            pieSeriesLabel13.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.TwoColumns;
            series11.Label = pieSeriesLabel13;
            series11.Name = "OwnerUsage";
            pieSeriesView13.Rotation = 90;
            pieSeriesView13.RuntimeExploding = true;
            series11.View = pieSeriesView13;
            series11.Visible = false;
            pieSeriesLabel14.BackColor = System.Drawing.Color.Transparent;
            pieSeriesLabel14.Border.Visible = false;
            pieSeriesLabel14.ColumnIndent = 20;
            pieSeriesLabel14.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            pieSeriesLabel14.LineLength = 30;
            pieSeriesLabel14.LineVisible = true;
            piePointOptions12.PercentOptions.ValueAsPercent = false;
            piePointOptions12.PointView = DevExpress.XtraCharts.PointView.ArgumentAndValues;
            piePointOptions12.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.FixedPoint;
            piePointOptions12.ValueNumericOptions.Precision = 0;
            pieSeriesLabel14.PointOptions = piePointOptions12;
            pieSeriesLabel14.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.TwoColumns;
            series12.Label = pieSeriesLabel14;
            series12.Name = "ZoneUsage";
            pieSeriesView14.Rotation = 90;
            pieSeriesView14.RuntimeExploding = true;
            series12.View = pieSeriesView14;
            series12.Visible = false;
            this.chtChartingView.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series9,
        series10,
        series11,
        series12};
            pieSeriesLabel15.LineVisible = true;
            this.chtChartingView.SeriesTemplate.Label = pieSeriesLabel15;
            pieSeriesView15.RuntimeExploding = false;
            this.chtChartingView.SeriesTemplate.View = pieSeriesView15;
            this.chtChartingView.Size = new System.Drawing.Size(1040, 388);
            this.chtChartingView.TabIndex = 180;
            this.chtChartingView.TabStop = false;
            this.chtChartingView.PieSeriesPointExploded += new DevExpress.XtraCharts.PieSeriesPointExplodedEventHandler(this.chartUsage_PieSeriesPointExploded);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.cboChartStyle);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.chkValueAsPercent);
            this.groupControl2.Controls.Add(this.chkShowLabel);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Controls.Add(this.cboLabelPosition);
            this.groupControl2.Controls.Add(this.labelPosition);
            this.groupControl2.Controls.Add(this.cboExplodeMode);
            this.groupControl2.Location = new System.Drawing.Point(582, 5);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(458, 94);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Charting Appearance";
            // 
            // cboChartStyle
            // 
            this.cboChartStyle.Location = new System.Drawing.Point(151, 68);
            this.cboChartStyle.MenuManager = this.ribbonControl1;
            this.cboChartStyle.Name = "cboChartStyle";
            this.cboChartStyle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboChartStyle.Properties.NullText = "";
            this.cboChartStyle.Properties.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1});
            this.cboChartStyle.Properties.ShowClearButton = false;
            this.cboChartStyle.Properties.View = this.searchLookUpEdit1View;
            this.cboChartStyle.Size = new System.Drawing.Size(115, 20);
            this.cboChartStyle.TabIndex = 2;
            this.cboChartStyle.EditValueChanged += new System.EventHandler(this.cboChartStyle_EditValueChanged);
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcStyleName,
            this.gdcStylePicture});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.searchLookUpEdit1View.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gdcStyleName
            // 
            this.gdcStyleName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcStyleName.AppearanceHeader.Options.UseFont = true;
            this.gdcStyleName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcStyleName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcStyleName.Caption = "Style Name";
            this.gdcStyleName.FieldName = "StyleName";
            this.gdcStyleName.Name = "gdcStyleName";
            this.gdcStyleName.Visible = true;
            this.gdcStyleName.VisibleIndex = 0;
            // 
            // gdcStylePicture
            // 
            this.gdcStylePicture.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcStylePicture.AppearanceHeader.Options.UseFont = true;
            this.gdcStylePicture.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcStylePicture.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcStylePicture.Caption = "Example";
            this.gdcStylePicture.ColumnEdit = this.repositoryItemPictureEdit1;
            this.gdcStylePicture.FieldName = "StylePicture";
            this.gdcStylePicture.Name = "gdcStylePicture";
            this.gdcStylePicture.Visible = true;
            this.gdcStylePicture.VisibleIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(6, 71);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(138, 13);
            this.labelControl2.TabIndex = 179;
            this.labelControl2.Text = "Chart Style:";
            // 
            // chkValueAsPercent
            // 
            this.chkValueAsPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkValueAsPercent.Location = new System.Drawing.Point(299, 24);
            this.chkValueAsPercent.MenuManager = this.ribbonControl1;
            this.chkValueAsPercent.Name = "chkValueAsPercent";
            this.chkValueAsPercent.Properties.Caption = "Value As Percent";
            this.chkValueAsPercent.Size = new System.Drawing.Size(149, 19);
            this.chkValueAsPercent.TabIndex = 3;
            this.chkValueAsPercent.CheckedChanged += new System.EventHandler(this.chkValueAsPercent_CheckedChanged);
            // 
            // chkShowLabel
            // 
            this.chkShowLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowLabel.EditValue = true;
            this.chkShowLabel.Location = new System.Drawing.Point(299, 47);
            this.chkShowLabel.MenuManager = this.ribbonControl1;
            this.chkShowLabel.Name = "chkShowLabel";
            this.chkShowLabel.Properties.Caption = "Show Labels";
            this.chkShowLabel.Size = new System.Drawing.Size(149, 19);
            this.chkShowLabel.TabIndex = 4;
            this.chkShowLabel.CheckedChanged += new System.EventHandler(this.chkShowLabel_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.label1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 177;
            this.label1.Text = "Exploded Points:";
            // 
            // cboLabelPosition
            // 
            this.cboLabelPosition.Location = new System.Drawing.Point(151, 23);
            this.cboLabelPosition.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.cboLabelPosition.Name = "cboLabelPosition";
            this.cboLabelPosition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLabelPosition.Properties.Items.AddRange(new object[] {
            "Inside",
            "Outside",
            "Two Columns",
            "Radial"});
            this.cboLabelPosition.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboLabelPosition.Size = new System.Drawing.Size(115, 20);
            this.cboLabelPosition.TabIndex = 0;
            this.cboLabelPosition.SelectedIndexChanged += new System.EventHandler(this.cboLabelPosition_SelectedIndexChanged);
            // 
            // labelPosition
            // 
            this.labelPosition.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelPosition.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelPosition.Location = new System.Drawing.Point(6, 27);
            this.labelPosition.Margin = new System.Windows.Forms.Padding(10, 10, 3, 10);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(139, 13);
            this.labelPosition.TabIndex = 176;
            this.labelPosition.Text = "Label Position:";
            // 
            // cboExplodeMode
            // 
            this.cboExplodeMode.Location = new System.Drawing.Point(151, 45);
            this.cboExplodeMode.Margin = new System.Windows.Forms.Padding(0, 10, 10, 0);
            this.cboExplodeMode.Name = "cboExplodeMode";
            this.cboExplodeMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboExplodeMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboExplodeMode.Size = new System.Drawing.Size(115, 20);
            this.cboExplodeMode.TabIndex = 1;
            this.cboExplodeMode.SelectedIndexChanged += new System.EventHandler(this.cboExplodeMode_SelectedIndexChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.rdoWarehouseUsageByCapacity);
            this.groupControl1.Controls.Add(this.rdoZoneUsage);
            this.groupControl1.Controls.Add(this.rdoOwnerUsage);
            this.groupControl1.Controls.Add(this.rdoProductGroupUsage);
            this.groupControl1.Controls.Add(this.rdoWarehouseUsageByUnit);
            this.groupControl1.Location = new System.Drawing.Point(4, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(572, 94);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Charting Type";
            // 
            // rdoWarehouseUsageByCapacity
            // 
            this.rdoWarehouseUsageByCapacity.Location = new System.Drawing.Point(281, 26);
            this.rdoWarehouseUsageByCapacity.MenuManager = this.ribbonControl1;
            this.rdoWarehouseUsageByCapacity.Name = "rdoWarehouseUsageByCapacity";
            this.rdoWarehouseUsageByCapacity.Properties.Caption = "Warehouse Usage by Capacity (kg)";
            this.rdoWarehouseUsageByCapacity.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdoWarehouseUsageByCapacity.Properties.RadioGroupIndex = 5;
            this.rdoWarehouseUsageByCapacity.Size = new System.Drawing.Size(245, 19);
            this.rdoWarehouseUsageByCapacity.TabIndex = 3;
            this.rdoWarehouseUsageByCapacity.TabStop = false;
            this.rdoWarehouseUsageByCapacity.CheckedChanged += new System.EventHandler(this.rdoUsage_CheckedChanged);
            // 
            // rdoZoneUsage
            // 
            this.rdoZoneUsage.Location = new System.Drawing.Point(281, 45);
            this.rdoZoneUsage.MenuManager = this.ribbonControl1;
            this.rdoZoneUsage.Name = "rdoZoneUsage";
            this.rdoZoneUsage.Properties.Caption = "Zone Usage";
            this.rdoZoneUsage.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdoZoneUsage.Properties.RadioGroupIndex = 5;
            this.rdoZoneUsage.Size = new System.Drawing.Size(185, 19);
            this.rdoZoneUsage.TabIndex = 4;
            this.rdoZoneUsage.TabStop = false;
            this.rdoZoneUsage.CheckedChanged += new System.EventHandler(this.rdoUsage_CheckedChanged);
            // 
            // rdoOwnerUsage
            // 
            this.rdoOwnerUsage.Location = new System.Drawing.Point(30, 68);
            this.rdoOwnerUsage.MenuManager = this.ribbonControl1;
            this.rdoOwnerUsage.Name = "rdoOwnerUsage";
            this.rdoOwnerUsage.Properties.Caption = "Owner Usage";
            this.rdoOwnerUsage.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdoOwnerUsage.Properties.RadioGroupIndex = 5;
            this.rdoOwnerUsage.Size = new System.Drawing.Size(221, 19);
            this.rdoOwnerUsage.TabIndex = 2;
            this.rdoOwnerUsage.TabStop = false;
            this.rdoOwnerUsage.CheckedChanged += new System.EventHandler(this.rdoUsage_CheckedChanged);
            // 
            // rdoProductGroupUsage
            // 
            this.rdoProductGroupUsage.Location = new System.Drawing.Point(30, 45);
            this.rdoProductGroupUsage.MenuManager = this.ribbonControl1;
            this.rdoProductGroupUsage.Name = "rdoProductGroupUsage";
            this.rdoProductGroupUsage.Properties.Caption = "Product Group Usage";
            this.rdoProductGroupUsage.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdoProductGroupUsage.Properties.RadioGroupIndex = 5;
            this.rdoProductGroupUsage.Size = new System.Drawing.Size(221, 19);
            this.rdoProductGroupUsage.TabIndex = 1;
            this.rdoProductGroupUsage.TabStop = false;
            this.rdoProductGroupUsage.CheckedChanged += new System.EventHandler(this.rdoUsage_CheckedChanged);
            // 
            // rdoWarehouseUsageByUnit
            // 
            this.rdoWarehouseUsageByUnit.EditValue = true;
            this.rdoWarehouseUsageByUnit.Location = new System.Drawing.Point(30, 24);
            this.rdoWarehouseUsageByUnit.MenuManager = this.ribbonControl1;
            this.rdoWarehouseUsageByUnit.Name = "rdoWarehouseUsageByUnit";
            this.rdoWarehouseUsageByUnit.Properties.Caption = "Warehouse Usage by Unit";
            this.rdoWarehouseUsageByUnit.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdoWarehouseUsageByUnit.Properties.RadioGroupIndex = 5;
            this.rdoWarehouseUsageByUnit.Size = new System.Drawing.Size(245, 19);
            this.rdoWarehouseUsageByUnit.TabIndex = 0;
            this.rdoWarehouseUsageByUnit.CheckedChanged += new System.EventHandler(this.rdoUsage_CheckedChanged);
            // 
            // xtpDetailView
            // 
            this.xtpDetailView.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xtpDetailView.Appearance.Header.Options.UseFont = true;
            this.xtpDetailView.Controls.Add(this.grdZoneExportByLocation);
            this.xtpDetailView.Controls.Add(this.grdZoneSearchResult);
            this.xtpDetailView.Name = "xtpDetailView";
            this.xtpDetailView.Size = new System.Drawing.Size(1045, 496);
            this.xtpDetailView.Text = "Detail View";
            // 
            // grdZoneExportByLocation
            // 
            this.grdZoneExportByLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdZoneExportByLocation.Location = new System.Drawing.Point(11, 115);
            this.grdZoneExportByLocation.MainView = this.gdvZoneExportByLocation;
            this.grdZoneExportByLocation.Name = "grdZoneExportByLocation";
            this.grdZoneExportByLocation.Size = new System.Drawing.Size(1027, 184);
            this.grdZoneExportByLocation.TabIndex = 4;
            this.grdZoneExportByLocation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvZoneExportByLocation});
            this.grdZoneExportByLocation.Visible = false;
            // 
            // gdvZoneExportByLocation
            // 
            this.gdvZoneExportByLocation.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand24,
            this.gridBand13,
            this.gridBand14,
            this.gridBand19});
            this.gdvZoneExportByLocation.BestFitMaxRowCount = 50;
            this.gdvZoneExportByLocation.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gdcZoneCode,
            this.gdcZoneName,
            this.gdcLocationCode,
            this.gdcLocationName,
            this.gdcFullCapacity,
            this.gdcUsageCapacity,
            this.gdcAvailableCapacity,
            this.bandedGridColumn4,
            this.bandedGridColumn5,
            this.bandedGridColumn6,
            this.bandedGridColumn7,
            this.bandedGridColumn8});
            this.gdvZoneExportByLocation.GridControl = this.grdZoneExportByLocation;
            this.gdvZoneExportByLocation.Name = "gdvZoneExportByLocation";
            this.gdvZoneExportByLocation.OptionsCustomization.AllowGroup = false;
            this.gdvZoneExportByLocation.OptionsView.ColumnAutoWidth = false;
            this.gdvZoneExportByLocation.OptionsView.ShowColumnHeaders = false;
            this.gdvZoneExportByLocation.OptionsView.ShowFooter = true;
            this.gdvZoneExportByLocation.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand24
            // 
            this.gridBand24.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand24.AppearanceHeader.Options.UseFont = true;
            this.gridBand24.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand24.Caption = "Zone";
            this.gridBand24.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand26,
            this.gridBand25});
            this.gridBand24.Name = "gridBand24";
            this.gridBand24.Width = 176;
            // 
            // gridBand26
            // 
            this.gridBand26.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand26.AppearanceHeader.Options.UseFont = true;
            this.gridBand26.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand26.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand26.Caption = "Code";
            this.gridBand26.Columns.Add(this.gdcZoneCode);
            this.gridBand26.Name = "gridBand26";
            this.gridBand26.Width = 75;
            // 
            // gdcZoneCode
            // 
            this.gdcZoneCode.Caption = "Zone Code";
            this.gdcZoneCode.FieldName = "ZoneCode";
            this.gdcZoneCode.Name = "gdcZoneCode";
            this.gdcZoneCode.Visible = true;
            // 
            // gridBand25
            // 
            this.gridBand25.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand25.AppearanceHeader.Options.UseFont = true;
            this.gridBand25.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand25.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand25.Caption = "Name";
            this.gridBand25.Columns.Add(this.gdcZoneName);
            this.gridBand25.Name = "gridBand25";
            this.gridBand25.Width = 101;
            // 
            // gdcZoneName
            // 
            this.gdcZoneName.Caption = "Zone Name";
            this.gdcZoneName.FieldName = "ZoneName";
            this.gdcZoneName.Name = "gdcZoneName";
            this.gdcZoneName.Visible = true;
            this.gdcZoneName.Width = 101;
            // 
            // gridBand13
            // 
            this.gridBand13.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand13.AppearanceHeader.Options.UseFont = true;
            this.gridBand13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand13.Caption = "Location";
            this.gridBand13.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand28,
            this.gridBand27});
            this.gridBand13.Name = "gridBand13";
            this.gridBand13.Width = 208;
            // 
            // gridBand28
            // 
            this.gridBand28.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand28.AppearanceHeader.Options.UseFont = true;
            this.gridBand28.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand28.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand28.Caption = "Code";
            this.gridBand28.Columns.Add(this.gdcLocationName);
            this.gridBand28.Name = "gridBand28";
            this.gridBand28.Width = 85;
            // 
            // gdcLocationName
            // 
            this.gdcLocationName.Caption = "Location Name";
            this.gdcLocationName.FieldName = "LocationName";
            this.gdcLocationName.Name = "gdcLocationName";
            this.gdcLocationName.Visible = true;
            this.gdcLocationName.Width = 85;
            // 
            // gridBand27
            // 
            this.gridBand27.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand27.AppearanceHeader.Options.UseFont = true;
            this.gridBand27.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand27.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand27.Caption = "Name";
            this.gridBand27.Columns.Add(this.gdcLocationCode);
            this.gridBand27.Name = "gridBand27";
            this.gridBand27.Width = 123;
            // 
            // gdcLocationCode
            // 
            this.gdcLocationCode.Caption = "Location Code";
            this.gdcLocationCode.FieldName = "LocationCode";
            this.gdcLocationCode.Name = "gdcLocationCode";
            this.gdcLocationCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "LocationCode", "Summary", "Summary")});
            this.gdcLocationCode.Tag = "";
            this.gdcLocationCode.Visible = true;
            this.gdcLocationCode.Width = 123;
            // 
            // gridBand14
            // 
            this.gridBand14.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand14.AppearanceHeader.Options.UseFont = true;
            this.gridBand14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand14.Caption = "Capacity (Kg)";
            this.gridBand14.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand15,
            this.gridBand16,
            this.gridBand17,
            this.gridBand18});
            this.gridBand14.Name = "gridBand14";
            this.gridBand14.Width = 340;
            // 
            // gridBand15
            // 
            this.gridBand15.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand15.AppearanceHeader.Options.UseFont = true;
            this.gridBand15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand15.Caption = "Full";
            this.gridBand15.Columns.Add(this.gdcFullCapacity);
            this.gridBand15.Name = "gridBand15";
            this.gridBand15.Width = 75;
            // 
            // gdcFullCapacity
            // 
            this.gdcFullCapacity.Caption = "Full Capacity";
            this.gdcFullCapacity.DisplayFormat.FormatString = "#,##0.000";
            this.gdcFullCapacity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcFullCapacity.FieldName = "FullCapacity";
            this.gdcFullCapacity.Name = "gdcFullCapacity";
            this.gdcFullCapacity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FullCapacity", "{0:#,##0.000}")});
            this.gdcFullCapacity.Visible = true;
            // 
            // gridBand16
            // 
            this.gridBand16.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand16.AppearanceHeader.Options.UseFont = true;
            this.gridBand16.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand16.Caption = "Actual Usage";
            this.gridBand16.Columns.Add(this.gdcUsageCapacity);
            this.gridBand16.Name = "gridBand16";
            this.gridBand16.Width = 106;
            // 
            // gdcUsageCapacity
            // 
            this.gdcUsageCapacity.Caption = "Usage Capacity";
            this.gdcUsageCapacity.DisplayFormat.FormatString = "#,##0.000";
            this.gdcUsageCapacity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcUsageCapacity.FieldName = "UsageCapacity";
            this.gdcUsageCapacity.Name = "gdcUsageCapacity";
            this.gdcUsageCapacity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UsageCapacity", "{0:#,##0.000}")});
            this.gdcUsageCapacity.Visible = true;
            this.gdcUsageCapacity.Width = 106;
            // 
            // gridBand17
            // 
            this.gridBand17.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand17.AppearanceHeader.Options.UseFont = true;
            this.gridBand17.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand17.Caption = "Available";
            this.gridBand17.Columns.Add(this.gdcAvailableCapacity);
            this.gridBand17.Name = "gridBand17";
            this.gridBand17.Width = 84;
            // 
            // gdcAvailableCapacity
            // 
            this.gdcAvailableCapacity.Caption = "Available Capacity";
            this.gdcAvailableCapacity.DisplayFormat.FormatString = "#,##0.000";
            this.gdcAvailableCapacity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gdcAvailableCapacity.FieldName = "AvailableCapacity";
            this.gdcAvailableCapacity.Name = "gdcAvailableCapacity";
            this.gdcAvailableCapacity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AvailableCapacity", "{0:#,##0.000}")});
            this.gdcAvailableCapacity.Visible = true;
            this.gdcAvailableCapacity.Width = 84;
            // 
            // gridBand18
            // 
            this.gridBand18.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand18.AppearanceHeader.Options.UseFont = true;
            this.gridBand18.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand18.Caption = "Usage (%)";
            this.gridBand18.Columns.Add(this.bandedGridColumn4);
            this.gridBand18.Name = "gridBand18";
            this.gridBand18.Width = 75;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.Caption = "Usage Percent Cap";
            this.bandedGridColumn4.DisplayFormat.FormatString = "#,##0.00";
            this.bandedGridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn4.FieldName = "UsagePercentCapacity";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "UsagePercentCapacity", "{0:#,##0.00}")});
            this.bandedGridColumn4.Visible = true;
            // 
            // gridBand19
            // 
            this.gridBand19.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand19.AppearanceHeader.Options.UseFont = true;
            this.gridBand19.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand19.Caption = "Unit";
            this.gridBand19.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand20,
            this.gridBand21,
            this.gridBand22,
            this.gridBand23});
            this.gridBand19.Name = "gridBand19";
            this.gridBand19.Width = 300;
            // 
            // gridBand20
            // 
            this.gridBand20.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand20.AppearanceHeader.Options.UseFont = true;
            this.gridBand20.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand20.Caption = "Full";
            this.gridBand20.Columns.Add(this.bandedGridColumn5);
            this.gridBand20.Name = "gridBand20";
            this.gridBand20.Width = 75;
            // 
            // bandedGridColumn5
            // 
            this.bandedGridColumn5.Caption = "Full Unit";
            this.bandedGridColumn5.DisplayFormat.FormatString = "#,##0";
            this.bandedGridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn5.FieldName = "FullUnit";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FullUnit", "{0:#,##0}")});
            this.bandedGridColumn5.Visible = true;
            // 
            // gridBand21
            // 
            this.gridBand21.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand21.AppearanceHeader.Options.UseFont = true;
            this.gridBand21.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand21.Caption = "Usage";
            this.gridBand21.Columns.Add(this.bandedGridColumn6);
            this.gridBand21.Name = "gridBand21";
            this.gridBand21.Width = 75;
            // 
            // bandedGridColumn6
            // 
            this.bandedGridColumn6.Caption = "Usage Unit";
            this.bandedGridColumn6.DisplayFormat.FormatString = "#,##0";
            this.bandedGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn6.FieldName = "UsageUnit";
            this.bandedGridColumn6.Name = "bandedGridColumn6";
            this.bandedGridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UsageUnit", "{0:#,##0}")});
            this.bandedGridColumn6.Visible = true;
            // 
            // gridBand22
            // 
            this.gridBand22.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand22.AppearanceHeader.Options.UseFont = true;
            this.gridBand22.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand22.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand22.Caption = "Available";
            this.gridBand22.Columns.Add(this.bandedGridColumn7);
            this.gridBand22.Name = "gridBand22";
            this.gridBand22.Width = 75;
            // 
            // bandedGridColumn7
            // 
            this.bandedGridColumn7.Caption = "Available Unit";
            this.bandedGridColumn7.DisplayFormat.FormatString = "#,##0";
            this.bandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn7.FieldName = "AvailableUnit";
            this.bandedGridColumn7.Name = "bandedGridColumn7";
            this.bandedGridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AvailableUnit", "{0:#,##0}")});
            this.bandedGridColumn7.Visible = true;
            // 
            // gridBand23
            // 
            this.gridBand23.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand23.AppearanceHeader.Options.UseFont = true;
            this.gridBand23.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand23.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand23.Caption = "Usage (%)";
            this.gridBand23.Columns.Add(this.bandedGridColumn8);
            this.gridBand23.Name = "gridBand23";
            this.gridBand23.Width = 75;
            // 
            // bandedGridColumn8
            // 
            this.bandedGridColumn8.Caption = "Usage Percent Unit";
            this.bandedGridColumn8.DisplayFormat.FormatString = "#,##0.00";
            this.bandedGridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bandedGridColumn8.FieldName = "UsagePercentUnit";
            this.bandedGridColumn8.Name = "bandedGridColumn8";
            this.bandedGridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "UsagePercentUnit", "{0:#,##0.00}")});
            this.bandedGridColumn8.Visible = true;
            // 
            // grdZoneSearchResult
            // 
            this.grdZoneSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdZoneSearchResult.Location = new System.Drawing.Point(0, 0);
            this.grdZoneSearchResult.MainView = this.gdvZoneSearchResult;
            this.grdZoneSearchResult.Name = "grdZoneSearchResult";
            this.grdZoneSearchResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repColorEdit,
            this.repExport});
            this.grdZoneSearchResult.Size = new System.Drawing.Size(1045, 496);
            this.grdZoneSearchResult.TabIndex = 2;
            this.grdZoneSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvZoneSearchResult});
            // 
            // gdvZoneSearchResult
            // 
            this.gdvZoneSearchResult.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand3,
            this.gridBand1,
            this.gridBand4,
            this.gridBand12});
            this.gdvZoneSearchResult.BestFitMaxRowCount = 50;
            this.gdvZoneSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colZoneID,
            this.colZoneName,
            this.colZoneColor,
            this.colFullCap,
            this.colUsageCap,
            this.colAvailableCap,
            this.colUsagePercentCap,
            this.colFullUnit,
            this.colUsageUnit,
            this.colAvailableUnit,
            this.colUsagePercentUnit,
            this.colExport});
            this.gdvZoneSearchResult.GridControl = this.grdZoneSearchResult;
            this.gdvZoneSearchResult.Name = "gdvZoneSearchResult";
            this.gdvZoneSearchResult.OptionsBehavior.AutoPopulateColumns = false;
            this.gdvZoneSearchResult.OptionsCustomization.AllowGroup = false;
            this.gdvZoneSearchResult.OptionsView.ShowColumnHeaders = false;
            this.gdvZoneSearchResult.OptionsView.ShowFooter = true;
            this.gdvZoneSearchResult.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand3.AppearanceHeader.Options.UseFont = true;
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "Zone";
            this.gridBand3.Columns.Add(this.colZoneName);
            this.gridBand3.Columns.Add(this.colZoneColor);
            this.gridBand3.Columns.Add(this.colZoneID);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 150;
            // 
            // colZoneName
            // 
            this.colZoneName.Caption = "Zone Name";
            this.colZoneName.FieldName = "ZoneName";
            this.colZoneName.Name = "colZoneName";
            this.colZoneName.OptionsColumn.AllowEdit = false;
            this.colZoneName.Visible = true;
            // 
            // colZoneColor
            // 
            this.colZoneColor.Caption = "Zone Color";
            this.colZoneColor.ColumnEdit = this.repColorEdit;
            this.colZoneColor.FieldName = "ZoneColor";
            this.colZoneColor.Name = "colZoneColor";
            this.colZoneColor.OptionsColumn.AllowEdit = false;
            this.colZoneColor.Visible = true;
            // 
            // repColorEdit
            // 
            this.repColorEdit.AutoHeight = false;
            this.repColorEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repColorEdit.Name = "repColorEdit";
            // 
            // colZoneID
            // 
            this.colZoneID.Caption = "Zone ID";
            this.colZoneID.FieldName = "ZoneID";
            this.colZoneID.Name = "colZoneID";
            this.colZoneID.OptionsColumn.AllowEdit = false;
            this.colZoneID.OptionsColumn.ShowInCustomizationForm = false;
            this.colZoneID.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "Capacity (Ton)";
            this.gridBand1.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand6,
            this.gridBand8,
            this.gridBand7});
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 307;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Full";
            this.gridBand2.Columns.Add(this.colFullCap);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 75;
            // 
            // colFullCap
            // 
            this.colFullCap.Caption = "Full1";
            this.colFullCap.DisplayFormat.FormatString = "#,##0.000";
            this.colFullCap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFullCap.FieldName = "FullCap";
            this.colFullCap.Name = "colFullCap";
            this.colFullCap.OptionsColumn.AllowEdit = false;
            this.colFullCap.Visible = true;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand6.AppearanceHeader.Options.UseFont = true;
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.Caption = "Actual Usage";
            this.gridBand6.Columns.Add(this.colUsageCap);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.Width = 82;
            // 
            // colUsageCap
            // 
            this.colUsageCap.Caption = "Actual Usage1";
            this.colUsageCap.DisplayFormat.FormatString = "#,##0.000";
            this.colUsageCap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUsageCap.FieldName = "UsageCap";
            this.colUsageCap.Name = "colUsageCap";
            this.colUsageCap.OptionsColumn.AllowEdit = false;
            this.colUsageCap.Visible = true;
            this.colUsageCap.Width = 82;
            // 
            // gridBand8
            // 
            this.gridBand8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand8.AppearanceHeader.Options.UseFont = true;
            this.gridBand8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand8.Caption = "Available";
            this.gridBand8.Columns.Add(this.colAvailableCap);
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.Width = 75;
            // 
            // colAvailableCap
            // 
            this.colAvailableCap.Caption = "Available1";
            this.colAvailableCap.DisplayFormat.FormatString = "#,##0.000";
            this.colAvailableCap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAvailableCap.FieldName = "AvailableCap";
            this.colAvailableCap.Name = "colAvailableCap";
            this.colAvailableCap.OptionsColumn.AllowEdit = false;
            this.colAvailableCap.Visible = true;
            // 
            // gridBand7
            // 
            this.gridBand7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand7.AppearanceHeader.Options.UseFont = true;
            this.gridBand7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand7.Caption = "Usage (%)";
            this.gridBand7.Columns.Add(this.colUsagePercentCap);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.Width = 75;
            // 
            // colUsagePercentCap
            // 
            this.colUsagePercentCap.Caption = "Usage (%)1";
            this.colUsagePercentCap.DisplayFormat.FormatString = "##0.00";
            this.colUsagePercentCap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUsagePercentCap.FieldName = "UsagePercentCap";
            this.colUsagePercentCap.Name = "colUsagePercentCap";
            this.colUsagePercentCap.OptionsColumn.AllowEdit = false;
            this.colUsagePercentCap.Visible = true;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand4.AppearanceHeader.Options.UseFont = true;
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "Unit";
            this.gridBand4.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand5,
            this.gridBand9,
            this.gridBand11,
            this.gridBand10});
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Width = 300;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand5.AppearanceHeader.Options.UseFont = true;
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "Full";
            this.gridBand5.Columns.Add(this.colFullUnit);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.Width = 75;
            // 
            // colFullUnit
            // 
            this.colFullUnit.Caption = "Full";
            this.colFullUnit.DisplayFormat.FormatString = "#,##0";
            this.colFullUnit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFullUnit.FieldName = "FullUnit";
            this.colFullUnit.Name = "colFullUnit";
            this.colFullUnit.OptionsColumn.AllowEdit = false;
            this.colFullUnit.Visible = true;
            // 
            // gridBand9
            // 
            this.gridBand9.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand9.AppearanceHeader.Options.UseFont = true;
            this.gridBand9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand9.Caption = "Usage";
            this.gridBand9.Columns.Add(this.colUsageUnit);
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.Width = 75;
            // 
            // colUsageUnit
            // 
            this.colUsageUnit.Caption = "Usage";
            this.colUsageUnit.DisplayFormat.FormatString = "#,##0";
            this.colUsageUnit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUsageUnit.FieldName = "UsageUnit";
            this.colUsageUnit.Name = "colUsageUnit";
            this.colUsageUnit.OptionsColumn.AllowEdit = false;
            this.colUsageUnit.Visible = true;
            // 
            // gridBand11
            // 
            this.gridBand11.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand11.AppearanceHeader.Options.UseFont = true;
            this.gridBand11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand11.Caption = "Available";
            this.gridBand11.Columns.Add(this.colAvailableUnit);
            this.gridBand11.Name = "gridBand11";
            this.gridBand11.Width = 75;
            // 
            // colAvailableUnit
            // 
            this.colAvailableUnit.Caption = "Available";
            this.colAvailableUnit.DisplayFormat.FormatString = "#,##0";
            this.colAvailableUnit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAvailableUnit.FieldName = "AvailableUnit";
            this.colAvailableUnit.Name = "colAvailableUnit";
            this.colAvailableUnit.OptionsColumn.AllowEdit = false;
            this.colAvailableUnit.Visible = true;
            // 
            // gridBand10
            // 
            this.gridBand10.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand10.AppearanceHeader.Options.UseFont = true;
            this.gridBand10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand10.Caption = "Usage (%)";
            this.gridBand10.Columns.Add(this.colUsagePercentUnit);
            this.gridBand10.Name = "gridBand10";
            this.gridBand10.Width = 75;
            // 
            // colUsagePercentUnit
            // 
            this.colUsagePercentUnit.Caption = "Usage (%)";
            this.colUsagePercentUnit.DisplayFormat.FormatString = "#,##0.00";
            this.colUsagePercentUnit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUsagePercentUnit.FieldName = "UsagePercentUnit";
            this.colUsagePercentUnit.Name = "colUsagePercentUnit";
            this.colUsagePercentUnit.OptionsColumn.AllowEdit = false;
            this.colUsagePercentUnit.Visible = true;
            // 
            // gridBand12
            // 
            this.gridBand12.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand12.AppearanceHeader.Options.UseFont = true;
            this.gridBand12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand12.Caption = "Export";
            this.gridBand12.Columns.Add(this.colExport);
            this.gridBand12.Name = "gridBand12";
            this.gridBand12.Width = 75;
            // 
            // colExport
            // 
            this.colExport.Caption = "Export";
            this.colExport.ColumnEdit = this.repExport;
            this.colExport.Name = "colExport";
            this.colExport.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colExport.Visible = true;
            // 
            // repExport
            // 
            this.repExport.AutoHeight = false;
            this.repExport.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "Export", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.repExport.Name = "repExport";
            this.repExport.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repExport.Click += new System.EventHandler(this.repExport_Click);
            // 
            // frmESTS060_SpaceUtilization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 659);
            this.Controls.Add(this.tabWarehouseUtilization);
            this.Controls.Add(this.gcSearchCriteria);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmESTS060_SpaceUtilization";
            this.Text = "ESTS060 : Space Utilization";
            this.Load += new System.EventHandler(this.frmESTS060_SpaceUtilization_Load);
            this.Controls.SetChildIndex(this.gcSearchCriteria, 0);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.tabWarehouseUtilization, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSearchCriteria)).EndInit();
            this.gcSearchCriteria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdoByUsage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoByZone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabWarehouseUtilization)).EndInit();
            this.tabWarehouseUtilization.ResumeLayout(false);
            this.xtpTopView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.xtpChartingView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtChartingView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboChartStyle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkValueAsPercent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLabelPosition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboExplodeMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdoWarehouseUsageByCapacity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoZoneUsage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoOwnerUsage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoProductGroupUsage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoWarehouseUsageByUnit.Properties)).EndInit();
            this.xtpDetailView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdZoneExportByLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvZoneExportByLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZoneSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvZoneSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repColorEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repExport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gcSearchCriteria;
        private Control.RequireField requireField4;
        private Control.WarehouseControl warehouseControl;
        private DevExpress.XtraEditors.CheckEdit rdoByUsage;
        private DevExpress.XtraEditors.CheckEdit rdoByZone;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblFull;
        private DevExpress.XtraEditors.LabelControl lblEmpty;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraTab.XtraTabControl tabWarehouseUtilization;
        private DevExpress.XtraTab.XtraTabPage xtpTopView;
        private DevExpress.XtraTab.XtraTabPage xtpChartingView;
        private DevExpress.XtraEditors.LabelControl label1;
        private DevExpress.XtraEditors.LabelControl labelPosition;
        private DevExpress.XtraEditors.ComboBoxEdit cboExplodeMode;
        private DevExpress.XtraEditors.ComboBoxEdit cboLabelPosition;
        private DevExpress.XtraEditors.CheckEdit chkValueAsPercent;
        private DevExpress.XtraEditors.CheckEdit chkShowLabel;
        private DevExpress.XtraTab.XtraTabPage xtpDetailView;
        private DevExpress.XtraGrid.GridControl grdZoneExportByLocation;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gdvZoneExportByLocation;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand24;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand26;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gdcZoneCode;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand25;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gdcZoneName;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand13;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand28;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gdcLocationName;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand27;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gdcLocationCode;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand14;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand15;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gdcFullCapacity;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand16;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gdcUsageCapacity;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand17;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gdcAvailableCapacity;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand18;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand19;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand20;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand21;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand22;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand23;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn8;
        private DevExpress.XtraGrid.GridControl grdZoneSearchResult;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gdvZoneSearchResult;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colZoneName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colZoneColor;
        private DevExpress.XtraEditors.Repository.RepositoryItemColorEdit repColorEdit;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colZoneID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFullCap;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUsageCap;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colAvailableCap;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUsagePercentCap;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFullUnit;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUsageUnit;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colAvailableUnit;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUsagePercentUnit;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colExport;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repExport;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit rdoZoneUsage;
        private DevExpress.XtraEditors.CheckEdit rdoOwnerUsage;
        private DevExpress.XtraEditors.CheckEdit rdoProductGroupUsage;
        private DevExpress.XtraEditors.CheckEdit rdoWarehouseUsageByUnit;
        private DevExpress.XtraCharts.ChartControl chtChartingView;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.XtraScrollableControl pnDrawing;
        private DevExpress.XtraEditors.CheckEdit rdoWarehouseUsageByCapacity;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit cboChartStyle;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gdcStyleName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcStylePicture;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand9;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand11;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand10;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand12;



    }
}
namespace Rubix.Screen.Report
{
    partial class rptRPT033_PartDeliverySheet_SubReport
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell_Total = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell_QtyPack = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell_QtyBox = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.PDSNo = new DevExpress.XtraReports.Parameters.Parameter();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrCrossBandLine1 = new DevExpress.XtraReports.UI.XRCrossBandLine();
            this.xrTableCell_QtyPCS = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable});
            this.Detail.HeightF = 25.00001F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable
            // 
            this.xrTable.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrTable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTable.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable.Name = "xrTable";
            this.xrTable.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 100F);
            this.xrTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow});
            this.xrTable.SizeF = new System.Drawing.SizeF(613.96F, 25F);
            this.xrTable.StylePriority.UseBorders = false;
            this.xrTable.StylePriority.UseFont = false;
            this.xrTable.StylePriority.UsePadding = false;
            this.xrTable.StylePriority.UseTextAlignment = false;
            this.xrTable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow
            // 
            this.xrTableRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell_Total,
            this.xrTableCell1,
            this.xrTableCell_QtyPack,
            this.xrTableCell_QtyBox,
            this.xrTableCell_QtyPCS});
            this.xrTableRow.Name = "xrTableRow";
            this.xrTableRow.Weight = 1D;
            // 
            // xrTableCell_Total
            // 
            this.xrTableCell_Total.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell_Total.CanGrow = false;
            this.xrTableCell_Total.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1});
            this.xrTableCell_Total.Name = "xrTableCell_Total";
            this.xrTableCell_Total.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 4, 0, 0, 100F);
            this.xrTableCell_Total.StylePriority.UseBorders = false;
            this.xrTableCell_Total.StylePriority.UsePadding = false;
            this.xrTableCell_Total.Weight = 1.7947039221706878D;
            this.xrTableCell_Total.WordWrap = false;
            this.xrTableCell_Total.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrTableCell_Total_BeforePrint);
            // 
            // xrLabel1
            // 
            this.xrLabel1.AutoWidth = true;
            this.xrLabel1.BorderWidth = 0;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(255.5349F, 0.1838599F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.ProcessDuplicates = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel1.SizeF = new System.Drawing.SizeF(69.23511F, 20.81614F);
            this.xrLabel1.StylePriority.UseBorderWidth = false;
            this.xrLabel1.Text = "Total";
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3});
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.Weight = 0.37449462435437081D;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 1.183859F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.ProcessDuplicates = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel3.SizeF = new System.Drawing.SizeF(67.20001F, 20.81614F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "[QtyBox!#,#] [UnitLv2]";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableCell_QtyPack
            // 
            this.xrTableCell_QtyPack.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell_QtyPack.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4});
            this.xrTableCell_QtyPack.Name = "xrTableCell_QtyPack";
            this.xrTableCell_QtyPack.StylePriority.UseBorders = false;
            this.xrTableCell_QtyPack.StylePriority.UseTextAlignment = false;
            this.xrTableCell_QtyPack.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell_QtyPack.Weight = 0.38175160232362559D;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(2F, 1.183859F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.ProcessDuplicates = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel4.SizeF = new System.Drawing.SizeF(66.22147F, 20.81614F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.Text = "[QtyPCS!#,#] [UnitLv3]";
            // 
            // xrTableCell_QtyBox
            // 
            this.xrTableCell_QtyBox.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell_QtyBox.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2});
            this.xrTableCell_QtyBox.Name = "xrTableCell_QtyBox";
            this.xrTableCell_QtyBox.StylePriority.UseBorders = false;
            this.xrTableCell_QtyBox.StylePriority.UseTextAlignment = false;
            this.xrTableCell_QtyBox.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell_QtyBox.Weight = 0.36734602062304478D;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(2F, 1.183859F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.ProcessDuplicates = DevExpress.XtraReports.UI.ValueSuppressType.Suppress;
            this.xrLabel2.SizeF = new System.Drawing.SizeF(64.60464F, 20.81614F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.Text = "[QtyPack!#,#] [UnitPact]";
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "QtyPack")});
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = "[QtyPack] [UnitLv3]";
            this.xrTableCell2.Weight = 0.80465141757371161D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Text = "xrTableCell3";
            this.xrTableCell3.Weight = 0.69534858242628839D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Text = "xrTableCell4";
            this.xrTableCell4.Weight = 0.5D;
            // 
            // PDSNo
            // 
            this.PDSNo.Name = "PDSNo";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(CSI.Business.DataObjects.sp_RPT033_PartDeliverySheet_GetSubData_Result);
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.White;
            this.Title.BorderColor = System.Drawing.SystemColors.ControlText;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1;
            this.Title.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.Title.ForeColor = System.Drawing.Color.Maroon;
            this.Title.Name = "Title";
            // 
            // FieldCaption
            // 
            this.FieldCaption.BackColor = System.Drawing.Color.White;
            this.FieldCaption.BorderColor = System.Drawing.SystemColors.ControlText;
            this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.FieldCaption.BorderWidth = 1;
            this.FieldCaption.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.FieldCaption.ForeColor = System.Drawing.Color.Maroon;
            this.FieldCaption.Name = "FieldCaption";
            // 
            // PageInfo
            // 
            this.PageInfo.BackColor = System.Drawing.Color.White;
            this.PageInfo.BorderColor = System.Drawing.SystemColors.ControlText;
            this.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PageInfo.BorderWidth = 1;
            this.PageInfo.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.PageInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PageInfo.Name = "PageInfo";
            // 
            // DataField
            // 
            this.DataField.BackColor = System.Drawing.Color.White;
            this.DataField.BorderColor = System.Drawing.SystemColors.ControlText;
            this.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataField.BorderWidth = 1;
            this.DataField.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.DataField.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DataField.Name = "DataField";
            this.DataField.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 0F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 37.58335F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // PageHeader
            // 
            this.PageHeader.HeightF = 1F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrCrossBandLine1
            // 
            this.xrCrossBandLine1.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.None;
            this.xrCrossBandLine1.EndBand = this.PageHeader;
            this.xrCrossBandLine1.EndPointFloat = new DevExpress.Utils.PointFloat(0F, 1.000001F);
            this.xrCrossBandLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrCrossBandLine1.Name = "xrCrossBandLine1";
            this.xrCrossBandLine1.StartBand = this.PageHeader;
            this.xrCrossBandLine1.StartPointFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrCrossBandLine1.WidthF = 782.83F;
            // 
            // xrTableCell_QtyPCS
            // 
            this.xrTableCell_QtyPCS.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell_QtyPCS.Name = "xrTableCell_QtyPCS";
            this.xrTableCell_QtyPCS.StylePriority.UseBorders = false;
            this.xrTableCell_QtyPCS.StylePriority.UseTextAlignment = false;
            this.xrTableCell_QtyPCS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell_QtyPCS.Weight = 0.40671775881881561D;
            // 
            // rptRPT033_PartDeliverySheet_SubReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.topMarginBand1,
            this.bottomMarginBand1,
            this.PageHeader});
            this.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.CrossBandControls.AddRange(new DevExpress.XtraReports.UI.XRCrossBandControl[] {
            this.xrCrossBandLine1});
            this.DataSource = this.bindingSource1;
            this.FilterString = "[PDSNo] = ?PDSNo";
            this.Margins = new System.Drawing.Printing.Margins(0, 17, 0, 38);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.PDSNo});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
            this.Version = "11.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private System.Windows.Forms.BindingSource bindingSource1;
        public DevExpress.XtraReports.Parameters.Parameter PDSNo;
        private DevExpress.XtraReports.UI.XRControlStyle Title;
        private DevExpress.XtraReports.UI.XRControlStyle FieldCaption;
        private DevExpress.XtraReports.UI.XRControlStyle PageInfo;
        private DevExpress.XtraReports.UI.XRControlStyle DataField;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTable xrTable;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell_Total;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell_QtyPack;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell_QtyBox;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRCrossBandLine xrCrossBandLine1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell_QtyPCS;
    }
}

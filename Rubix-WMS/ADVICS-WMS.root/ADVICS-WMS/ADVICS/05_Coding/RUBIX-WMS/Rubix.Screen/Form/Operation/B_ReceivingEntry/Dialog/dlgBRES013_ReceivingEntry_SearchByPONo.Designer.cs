namespace Rubix.Screen.Form.Operation.B_ReceivingEntry.Dialog
{
    partial class dlgBRES013_ReceivingEntry_SearchByPONo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgBRES013_ReceivingEntry_SearchByPONo));
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcIssuedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPDS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dtCustomerPOIssueDateTo = new DevExpress.XtraEditors.DateEdit();
            this.dtCustomerPOIssueDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSearchResult.Location = new System.Drawing.Point(0, 72);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.Size = new System.Drawing.Size(468, 252);
            this.grdSearchResult.TabIndex = 4;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcIssuedDate,
            this.gdcPONo,
            this.gdcPDS});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsView.ShowGroupPanel = false;
            // 
            // gdcIssuedDate
            // 
            this.gdcIssuedDate.AppearanceCell.Options.UseTextOptions = true;
            this.gdcIssuedDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcIssuedDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcIssuedDate.AppearanceHeader.Options.UseFont = true;
            this.gdcIssuedDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcIssuedDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcIssuedDate.Caption = "Issued Date";
            this.gdcIssuedDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gdcIssuedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gdcIssuedDate.FieldName = "IssuedDate";
            this.gdcIssuedDate.Name = "gdcIssuedDate";
            this.gdcIssuedDate.OptionsColumn.AllowEdit = false;
            this.gdcIssuedDate.Visible = true;
            this.gdcIssuedDate.VisibleIndex = 0;
            // 
            // gdcPONo
            // 
            this.gdcPONo.AppearanceCell.Options.UseTextOptions = true;
            this.gdcPONo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPONo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPONo.AppearanceHeader.Options.UseFont = true;
            this.gdcPONo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPONo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPONo.Caption = "PO No.";
            this.gdcPONo.FieldName = "PONo";
            this.gdcPONo.Name = "gdcPONo";
            this.gdcPONo.OptionsColumn.AllowEdit = false;
            this.gdcPONo.Visible = true;
            this.gdcPONo.VisibleIndex = 1;
            // 
            // gdcPDS
            // 
            this.gdcPDS.AppearanceCell.Options.UseTextOptions = true;
            this.gdcPDS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPDS.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPDS.AppearanceHeader.Options.UseFont = true;
            this.gdcPDS.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPDS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPDS.Caption = "PDS No.";
            this.gdcPDS.FieldName = "PDSNo";
            this.gdcPDS.Name = "gdcPDS";
            this.gdcPDS.OptionsColumn.AllowEdit = false;
            this.gdcPDS.Visible = true;
            this.gdcPDS.VisibleIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.dtCustomerPOIssueDateTo);
            this.panelControl1.Controls.Add(this.dtCustomerPOIssueDateFrom);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 31);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(468, 41);
            this.panelControl1.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(388, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(237, 13);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(29, 13);
            this.labelControl4.TabIndex = 21;
            this.labelControl4.Text = "To";
            // 
            // dtCustomerPOIssueDateTo
            // 
            this.dtCustomerPOIssueDateTo.EditValue = null;
            this.dtCustomerPOIssueDateTo.Location = new System.Drawing.Point(272, 10);
            this.dtCustomerPOIssueDateTo.Name = "dtCustomerPOIssueDateTo";
            this.dtCustomerPOIssueDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtCustomerPOIssueDateTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtCustomerPOIssueDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCustomerPOIssueDateTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtCustomerPOIssueDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCustomerPOIssueDateTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtCustomerPOIssueDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtCustomerPOIssueDateTo.Size = new System.Drawing.Size(99, 20);
            this.dtCustomerPOIssueDateTo.TabIndex = 19;
            // 
            // dtCustomerPOIssueDateFrom
            // 
            this.dtCustomerPOIssueDateFrom.EditValue = null;
            this.dtCustomerPOIssueDateFrom.Location = new System.Drawing.Point(132, 10);
            this.dtCustomerPOIssueDateFrom.Name = "dtCustomerPOIssueDateFrom";
            this.dtCustomerPOIssueDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtCustomerPOIssueDateFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtCustomerPOIssueDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCustomerPOIssueDateFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtCustomerPOIssueDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCustomerPOIssueDateFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtCustomerPOIssueDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtCustomerPOIssueDateFrom.Size = new System.Drawing.Size(99, 20);
            this.dtCustomerPOIssueDateFrom.TabIndex = 18;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(5, 13);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(121, 13);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "P/O Issue Date";
            // 
            // dlgBRES013_ReceivingEntry_SearchByPONo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 324);
            this.Controls.Add(this.grdSearchResult);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgBRES013_ReceivingEntry_SearchByPONo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BRES013 : Receiving Entry Search By PO No. Dialog";
            this.Load += new System.EventHandler(this.dlgBRES013_ReceivingEntry_SearchByPONo_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.grdSearchResult, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCustomerPOIssueDateFrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraGrid.Columns.GridColumn gdcIssuedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPONo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPDS;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit dtCustomerPOIssueDateTo;
        private DevExpress.XtraEditors.DateEdit dtCustomerPOIssueDateFrom;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
    }
}
namespace Rubix.Screen.Form.Admin
{
    partial class frmADM050_MultiLanguage
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
            this.gpcHeader = new DevExpress.XtraEditors.GroupControl();
            this.cboScreen = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcScreenName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcScreenID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboType = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboLang = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcLanguage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblScreenName = new DevExpress.XtraEditors.LabelControl();
            this.lblType = new DevExpress.XtraEditors.LabelControl();
            this.lblLanguage = new DevExpress.XtraEditors.LabelControl();
            this.gpcResult = new DevExpress.XtraEditors.GroupControl();
            this.grdResult = new DevExpress.XtraGrid.GridControl();
            this.gdvResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcMAP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCTRL_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcORIGIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcLANG_WORD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcMODIFIED_ON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcMODIFIED_BY = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcHeader)).BeginInit();
            this.gpcHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboScreen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcResult)).BeginInit();
            this.gpcResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Size = new System.Drawing.Size(866, 47);
            // 
            // gpcHeader
            // 
            this.gpcHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpcHeader.Controls.Add(this.cboScreen);
            this.gpcHeader.Controls.Add(this.cboType);
            this.gpcHeader.Controls.Add(this.cboLang);
            this.gpcHeader.Controls.Add(this.lblScreenName);
            this.gpcHeader.Controls.Add(this.lblType);
            this.gpcHeader.Controls.Add(this.lblLanguage);
            this.gpcHeader.Location = new System.Drawing.Point(5, 36);
            this.gpcHeader.Name = "gpcHeader";
            this.gpcHeader.Size = new System.Drawing.Size(857, 109);
            this.gpcHeader.TabIndex = 31;
            this.gpcHeader.Text = "Header";
            // 
            // cboScreen
            // 
            this.cboScreen.EnterMoveNextControl = true;
            this.cboScreen.Location = new System.Drawing.Point(99, 79);
            this.cboScreen.Name = "cboScreen";
            this.cboScreen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboScreen.Properties.NullText = "";
            this.cboScreen.Properties.PopupFormSize = new System.Drawing.Size(800, 0);
            this.cboScreen.Properties.View = this.gridView2;
            this.cboScreen.Size = new System.Drawing.Size(324, 20);
            this.cboScreen.TabIndex = 50;
            this.cboScreen.Tag = "require";
            this.cboScreen.EditValueChanged += new System.EventHandler(this.cboScreen_EditValueChanged);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcScreenName,
            this.grcScreenID});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // grcScreenName
            // 
            this.grcScreenName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grcScreenName.AppearanceHeader.Options.UseFont = true;
            this.grcScreenName.AppearanceHeader.Options.UseTextOptions = true;
            this.grcScreenName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcScreenName.Caption = "Screen Name";
            this.grcScreenName.FieldName = "ORIGIN";
            this.grcScreenName.Name = "grcScreenName";
            this.grcScreenName.OptionsColumn.FixedWidth = true;
            this.grcScreenName.Visible = true;
            this.grcScreenName.VisibleIndex = 0;
            this.grcScreenName.Width = 400;
            // 
            // grcScreenID
            // 
            this.grcScreenID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grcScreenID.AppearanceHeader.Options.UseFont = true;
            this.grcScreenID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcScreenID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcScreenID.Caption = "Screen ID";
            this.grcScreenID.FieldName = "FORM_ID";
            this.grcScreenID.Name = "grcScreenID";
            this.grcScreenID.OptionsColumn.FixedWidth = true;
            this.grcScreenID.Visible = true;
            this.grcScreenID.VisibleIndex = 1;
            this.grcScreenID.Width = 370;
            // 
            // cboType
            // 
            this.cboType.EnterMoveNextControl = true;
            this.cboType.Location = new System.Drawing.Point(99, 55);
            this.cboType.Name = "cboType";
            this.cboType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboType.Properties.NullText = "";
            this.cboType.Properties.View = this.gridView1;
            this.cboType.Size = new System.Drawing.Size(170, 20);
            this.cboType.TabIndex = 49;
            this.cboType.Tag = "require";
            this.cboType.EditValueChanged += new System.EventHandler(this.cboType_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcType});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // grcType
            // 
            this.grcType.AppearanceCell.Options.UseTextOptions = true;
            this.grcType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grcType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grcType.AppearanceHeader.Options.UseFont = true;
            this.grcType.AppearanceHeader.Options.UseTextOptions = true;
            this.grcType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcType.Caption = "Type";
            this.grcType.FieldName = "Text";
            this.grcType.Name = "grcType";
            this.grcType.Visible = true;
            this.grcType.VisibleIndex = 0;
            this.grcType.Width = 127;
            // 
            // cboLang
            // 
            this.cboLang.EnterMoveNextControl = true;
            this.cboLang.Location = new System.Drawing.Point(99, 30);
            this.cboLang.Name = "cboLang";
            this.cboLang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLang.Properties.NullText = "";
            this.cboLang.Properties.View = this.gridView3;
            this.cboLang.Size = new System.Drawing.Size(170, 20);
            this.cboLang.TabIndex = 48;
            this.cboLang.Tag = "require";
            this.cboLang.EditValueChanged += new System.EventHandler(this.cboLang_EditValueChanged);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcLanguage});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ColumnAutoWidth = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // grcLanguage
            // 
            this.grcLanguage.AppearanceCell.Options.UseTextOptions = true;
            this.grcLanguage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grcLanguage.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grcLanguage.AppearanceHeader.Options.UseFont = true;
            this.grcLanguage.AppearanceHeader.Options.UseTextOptions = true;
            this.grcLanguage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcLanguage.Caption = "Language";
            this.grcLanguage.FieldName = "Description";
            this.grcLanguage.Name = "grcLanguage";
            this.grcLanguage.Visible = true;
            this.grcLanguage.VisibleIndex = 0;
            this.grcLanguage.Width = 127;
            // 
            // lblScreenName
            // 
            this.lblScreenName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblScreenName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblScreenName.Location = new System.Drawing.Point(7, 81);
            this.lblScreenName.Name = "lblScreenName";
            this.lblScreenName.Size = new System.Drawing.Size(84, 16);
            this.lblScreenName.TabIndex = 3;
            this.lblScreenName.Text = "Screen Name";
            // 
            // lblType
            // 
            this.lblType.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblType.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblType.Location = new System.Drawing.Point(5, 57);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(86, 16);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type";
            // 
            // lblLanguage
            // 
            this.lblLanguage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblLanguage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLanguage.Location = new System.Drawing.Point(7, 32);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(84, 16);
            this.lblLanguage.TabIndex = 1;
            this.lblLanguage.Text = "Language";
            // 
            // gpcResult
            // 
            this.gpcResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpcResult.Controls.Add(this.grdResult);
            this.gpcResult.Location = new System.Drawing.Point(5, 151);
            this.gpcResult.Name = "gpcResult";
            this.gpcResult.Size = new System.Drawing.Size(857, 334);
            this.gpcResult.TabIndex = 46;
            this.gpcResult.Text = "Result";
            // 
            // grdResult
            // 
            this.grdResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdResult.Location = new System.Drawing.Point(7, 24);
            this.grdResult.MainView = this.gdvResult;
            this.grdResult.Name = "grdResult";
            this.grdResult.Size = new System.Drawing.Size(844, 304);
            this.grdResult.TabIndex = 0;
            this.grdResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvResult});
            // 
            // gdvResult
            // 
            this.gdvResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcMAP_ID,
            this.grcCTRL_ID,
            this.grcORIGIN,
            this.grcLANG_WORD,
            this.grcMODIFIED_ON,
            this.grcMODIFIED_BY});
            this.gdvResult.GridControl = this.grdResult;
            this.gdvResult.Name = "gdvResult";
            this.gdvResult.OptionsCustomization.AllowFilter = false;
            this.gdvResult.OptionsHint.ShowColumnHeaderHints = false;
            this.gdvResult.OptionsMenu.EnableColumnMenu = false;
            this.gdvResult.OptionsMenu.EnableFooterMenu = false;
            this.gdvResult.OptionsMenu.EnableGroupPanelMenu = false;
            this.gdvResult.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gdvResult.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gdvResult.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gdvResult.OptionsView.ShowGroupPanel = false;
            this.gdvResult.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.Default;
            // 
            // grcMAP_ID
            // 
            this.grcMAP_ID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grcMAP_ID.AppearanceHeader.Options.UseFont = true;
            this.grcMAP_ID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcMAP_ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcMAP_ID.Caption = "Map ID";
            this.grcMAP_ID.FieldName = "MAP_ID";
            this.grcMAP_ID.Name = "grcMAP_ID";
            this.grcMAP_ID.OptionsColumn.AllowEdit = false;
            this.grcMAP_ID.Width = 81;
            // 
            // grcCTRL_ID
            // 
            this.grcCTRL_ID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grcCTRL_ID.AppearanceHeader.Options.UseFont = true;
            this.grcCTRL_ID.AppearanceHeader.Options.UseTextOptions = true;
            this.grcCTRL_ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcCTRL_ID.Caption = "Control Name";
            this.grcCTRL_ID.FieldName = "CTRL_ID";
            this.grcCTRL_ID.Name = "grcCTRL_ID";
            this.grcCTRL_ID.OptionsColumn.AllowEdit = false;
            this.grcCTRL_ID.Visible = true;
            this.grcCTRL_ID.VisibleIndex = 0;
            this.grcCTRL_ID.Width = 251;
            // 
            // grcORIGIN
            // 
            this.grcORIGIN.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grcORIGIN.AppearanceHeader.Options.UseFont = true;
            this.grcORIGIN.AppearanceHeader.Options.UseTextOptions = true;
            this.grcORIGIN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcORIGIN.Caption = "Original Text";
            this.grcORIGIN.FieldName = "ORIGIN";
            this.grcORIGIN.Name = "grcORIGIN";
            this.grcORIGIN.OptionsColumn.AllowEdit = false;
            this.grcORIGIN.Visible = true;
            this.grcORIGIN.VisibleIndex = 1;
            this.grcORIGIN.Width = 203;
            // 
            // grcLANG_WORD
            // 
            this.grcLANG_WORD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grcLANG_WORD.AppearanceHeader.Options.UseFont = true;
            this.grcLANG_WORD.AppearanceHeader.Options.UseTextOptions = true;
            this.grcLANG_WORD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcLANG_WORD.Caption = "New Text";
            this.grcLANG_WORD.FieldName = "LANG_WORD";
            this.grcLANG_WORD.Name = "grcLANG_WORD";
            this.grcLANG_WORD.Visible = true;
            this.grcLANG_WORD.VisibleIndex = 2;
            this.grcLANG_WORD.Width = 208;
            // 
            // grcMODIFIED_ON
            // 
            this.grcMODIFIED_ON.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grcMODIFIED_ON.AppearanceHeader.Options.UseFont = true;
            this.grcMODIFIED_ON.AppearanceHeader.Options.UseTextOptions = true;
            this.grcMODIFIED_ON.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcMODIFIED_ON.Caption = "Last Changed";
            this.grcMODIFIED_ON.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            this.grcMODIFIED_ON.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grcMODIFIED_ON.FieldName = "MODIFIED_ON";
            this.grcMODIFIED_ON.Name = "grcMODIFIED_ON";
            this.grcMODIFIED_ON.OptionsColumn.AllowEdit = false;
            this.grcMODIFIED_ON.Visible = true;
            this.grcMODIFIED_ON.VisibleIndex = 3;
            this.grcMODIFIED_ON.Width = 165;
            // 
            // grcMODIFIED_BY
            // 
            this.grcMODIFIED_BY.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grcMODIFIED_BY.AppearanceHeader.Options.UseFont = true;
            this.grcMODIFIED_BY.AppearanceHeader.Options.UseTextOptions = true;
            this.grcMODIFIED_BY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grcMODIFIED_BY.Caption = "Changed By";
            this.grcMODIFIED_BY.FieldName = "MODIFIED_BY";
            this.grcMODIFIED_BY.Name = "grcMODIFIED_BY";
            this.grcMODIFIED_BY.OptionsColumn.AllowEdit = false;
            this.grcMODIFIED_BY.Visible = true;
            this.grcMODIFIED_BY.VisibleIndex = 4;
            this.grcMODIFIED_BY.Width = 186;
            // 
            // frmADM050_MultiLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 490);
            this.Controls.Add(this.gpcResult);
            this.Controls.Add(this.gpcHeader);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmADM050_MultiLanguage";
            this.Text = "frmADM050_MultiLanguage";
            this.Load += new System.EventHandler(this.frmADM050_MultiLanguage_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmADM050_MultiLanguage_KeyDown);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.gpcHeader, 0);
            this.Controls.SetChildIndex(this.gpcResult, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcHeader)).EndInit();
            this.gpcHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboScreen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcResult)).EndInit();
            this.gpcResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpcHeader;
        private DevExpress.XtraEditors.LabelControl lblScreenName;
        private DevExpress.XtraEditors.LabelControl lblType;
        private DevExpress.XtraEditors.LabelControl lblLanguage;
        private DevExpress.XtraEditors.GroupControl gpcResult;
        private DevExpress.XtraGrid.GridControl grdResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvResult;
        private DevExpress.XtraEditors.SearchLookUpEdit cboType;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn grcType;
        private DevExpress.XtraEditors.SearchLookUpEdit cboLang;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn grcLanguage;
        private DevExpress.XtraEditors.SearchLookUpEdit cboScreen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn grcScreenID;
        private DevExpress.XtraGrid.Columns.GridColumn grcMAP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn grcCTRL_ID;
        private DevExpress.XtraGrid.Columns.GridColumn grcORIGIN;
        private DevExpress.XtraGrid.Columns.GridColumn grcLANG_WORD;
        private DevExpress.XtraGrid.Columns.GridColumn grcMODIFIED_ON;
        private DevExpress.XtraGrid.Columns.GridColumn grcMODIFIED_BY;
        private DevExpress.XtraGrid.Columns.GridColumn grcScreenName;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenMgr;
    }
}
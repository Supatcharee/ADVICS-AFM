namespace Rubix.Screen.Form.Operation.D_Storing.Dialog
{
    partial class dlgDSRS013_COADownloadDialog
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcView = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repView = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.sfdDownload = new System.Windows.Forms.SaveFileDialog();
            this.txtReceivingNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceivingNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSearchResult.Location = new System.Drawing.Point(4, 62);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repView});
            this.grdSearchResult.Size = new System.Drawing.Size(659, 243);
            this.grdSearchResult.TabIndex = 1;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gcFileName,
            this.grcView});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "COA_ID";
            this.gridColumn1.FieldName = "COA_ID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gcFileName
            // 
            this.gcFileName.AppearanceCell.Options.UseTextOptions = true;
            this.gcFileName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.gcFileName.Caption = "File Name";
            this.gcFileName.FieldName = "COA_FileName";
            this.gcFileName.Name = "gcFileName";
            this.gcFileName.OptionsColumn.AllowEdit = false;
            this.gcFileName.Visible = true;
            this.gcFileName.VisibleIndex = 0;
            this.gcFileName.Width = 968;
            // 
            // grcView
            // 
            this.grcView.AppearanceCell.Options.UseTextOptions = true;
            this.grcView.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.grcView.Caption = "Download";
            this.grcView.ColumnEdit = this.repView;
            this.grcView.Name = "grcView";
            this.grcView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.grcView.Visible = true;
            this.grcView.VisibleIndex = 1;
            this.grcView.Width = 126;
            // 
            // repView
            // 
            this.repView.AutoHeight = false;
            this.repView.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down, "Download", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repView.Name = "repView";
            this.repView.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repView.Click += new System.EventHandler(this.repView_Click);
            // 
            // sfdDownload
            // 
            this.sfdDownload.Filter = "All Files|*.*";
            // 
            // txtReceivingNo
            // 
            this.txtReceivingNo.Enabled = false;
            this.txtReceivingNo.Location = new System.Drawing.Point(124, 36);
            this.txtReceivingNo.Name = "txtReceivingNo";
            this.txtReceivingNo.Properties.ReadOnly = true;
            this.txtReceivingNo.Size = new System.Drawing.Size(326, 20);
            this.txtReceivingNo.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(9, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(105, 17);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Receiving No.";
            // 
            // dlgDSRS013_COADownloadDialog
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 309);
            this.Controls.Add(this.txtReceivingNo);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.grdSearchResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgDSRS013_COADownloadDialog";
            this.ShowIcon = false;
            this.Text = "DSRS013 : COA Download Dialog";
            this.Load += new System.EventHandler(this.dlgDSRS013_COADownloadDialog_Load);
            this.Controls.SetChildIndex(this.grdSearchResult, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.txtReceivingNo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceivingNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraGrid.Columns.GridColumn gcFileName;
        private DevExpress.XtraGrid.Columns.GridColumn grcView;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repView;
        private System.Windows.Forms.SaveFileDialog sfdDownload;
        private DevExpress.XtraEditors.TextEdit txtReceivingNo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}
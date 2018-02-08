namespace Rubix.Screen.Form.Operation.I_Shipping.Dialog
{
    partial class frmISHS062_DownloadAttachFileDialog
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtPickingNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtShipmentNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.grdResult = new DevExpress.XtraGrid.GridControl();
            this.gdvResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCOA_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLotNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceivingNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDownload = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.sfdDownload = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPickingNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipmentNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownload)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtPickingNo);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtShipmentNo);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(4, 34);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(858, 59);
            this.panelControl1.TabIndex = 4;
            // 
            // txtPickingNo
            // 
            this.txtPickingNo.Location = new System.Drawing.Point(92, 31);
            this.txtPickingNo.Name = "txtPickingNo";
            this.txtPickingNo.Properties.ReadOnly = true;
            this.txtPickingNo.Size = new System.Drawing.Size(152, 20);
            this.txtPickingNo.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(22, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 17);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Picking No.";
            // 
            // txtShipmentNo
            // 
            this.txtShipmentNo.Location = new System.Drawing.Point(92, 5);
            this.txtShipmentNo.Name = "txtShipmentNo";
            this.txtShipmentNo.Properties.ReadOnly = true;
            this.txtShipmentNo.Size = new System.Drawing.Size(152, 20);
            this.txtShipmentNo.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(8, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 17);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Shipment No.";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.grdResult);
            this.panelControl2.Location = new System.Drawing.Point(4, 99);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(858, 264);
            this.panelControl2.TabIndex = 5;
            // 
            // grdResult
            // 
            this.grdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResult.Location = new System.Drawing.Point(2, 2);
            this.grdResult.MainView = this.gdvResult;
            this.grdResult.Name = "grdResult";
            this.grdResult.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnDownload});
            this.grdResult.Size = new System.Drawing.Size(854, 260);
            this.grdResult.TabIndex = 0;
            this.grdResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvResult});
            // 
            // gdvResult
            // 
            this.gdvResult.BestFitMaxRowCount = 50;
            this.gdvResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCOA_ID,
            this.colLineNo,
            this.colProductCode,
            this.gcItemName,
            this.colLotNo,
            this.colReceivingNo,
            this.colFileName,
            this.gridColumn1});
            this.gdvResult.GridControl = this.grdResult;
            this.gdvResult.Name = "gdvResult";
            this.gdvResult.OptionsView.ColumnAutoWidth = false;
            // 
            // colCOA_ID
            // 
            this.colCOA_ID.Caption = "COA ID";
            this.colCOA_ID.FieldName = "COA_ID";
            this.colCOA_ID.FieldNameSortGroup = "COA_ID";
            this.colCOA_ID.Name = "colCOA_ID";
            // 
            // colLineNo
            // 
            this.colLineNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colLineNo.AppearanceHeader.Options.UseFont = true;
            this.colLineNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colLineNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLineNo.FieldName = "LineNo";
            this.colLineNo.Name = "colLineNo";
            this.colLineNo.OptionsColumn.AllowEdit = false;
            this.colLineNo.Visible = true;
            this.colLineNo.VisibleIndex = 0;
            // 
            // colProductCode
            // 
            this.colProductCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colProductCode.AppearanceHeader.Options.UseFont = true;
            this.colProductCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colProductCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProductCode.Caption = "Item Code";
            this.colProductCode.FieldName = "ProductCode";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.OptionsColumn.AllowEdit = false;
            this.colProductCode.Visible = true;
            this.colProductCode.VisibleIndex = 1;
            // 
            // gcItemName
            // 
            this.gcItemName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gcItemName.AppearanceHeader.Options.UseFont = true;
            this.gcItemName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcItemName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcItemName.Caption = "Item Name";
            this.gcItemName.FieldName = "ProductLongName";
            this.gcItemName.Name = "gcItemName";
            this.gcItemName.Visible = true;
            this.gcItemName.VisibleIndex = 2;
            // 
            // colLotNo
            // 
            this.colLotNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colLotNo.AppearanceHeader.Options.UseFont = true;
            this.colLotNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colLotNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLotNo.FieldName = "LotNo";
            this.colLotNo.Name = "colLotNo";
            this.colLotNo.OptionsColumn.AllowEdit = false;
            this.colLotNo.Visible = true;
            this.colLotNo.VisibleIndex = 3;
            // 
            // colReceivingNo
            // 
            this.colReceivingNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colReceivingNo.AppearanceHeader.Options.UseFont = true;
            this.colReceivingNo.AppearanceHeader.Options.UseTextOptions = true;
            this.colReceivingNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReceivingNo.FieldName = "ReceivingNo";
            this.colReceivingNo.Name = "colReceivingNo";
            this.colReceivingNo.OptionsColumn.AllowEdit = false;
            this.colReceivingNo.Visible = true;
            this.colReceivingNo.VisibleIndex = 4;
            // 
            // colFileName
            // 
            this.colFileName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colFileName.AppearanceHeader.Options.UseFont = true;
            this.colFileName.AppearanceHeader.Options.UseTextOptions = true;
            this.colFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileName.Caption = "File Name";
            this.colFileName.FieldName = "COA_FileName";
            this.colFileName.FieldNameSortGroup = "COA_FileName";
            this.colFileName.Name = "colFileName";
            this.colFileName.OptionsColumn.AllowEdit = false;
            this.colFileName.Visible = true;
            this.colFileName.VisibleIndex = 5;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Download";
            this.gridColumn1.ColumnEdit = this.btnDownload;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // btnDownload
            // 
            this.btnDownload.AutoHeight = false;
            this.btnDownload.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // frmISHS062_DownloadAttachFileDialog
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 367);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmISHS062_DownloadAttachFileDialog";
            this.ShowIcon = false;
            this.Text = "ISHS061 : Download Attachment File Dialog";
            this.Load += new System.EventHandler(this.frmISH062_DownloadAttachFileDialog_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.panelControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPickingNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShipmentNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownload)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtPickingNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtShipmentNo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl grdResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvResult;
        private DevExpress.XtraGrid.Columns.GridColumn colLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn colProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLotNo;
        private DevExpress.XtraGrid.Columns.GridColumn colReceivingNo;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDownload;
        private System.Windows.Forms.SaveFileDialog sfdDownload;
        private DevExpress.XtraGrid.Columns.GridColumn gcItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colCOA_ID;
    }
}
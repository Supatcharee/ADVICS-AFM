namespace Rubix.Screen.Form.Master.Dialog
{
    partial class dlgXMSS052_Item_SearchPallet
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
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcPalletCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPalletName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcLength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcWidth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcHeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcM3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSearchResult.Location = new System.Drawing.Point(0, 31);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.Size = new System.Drawing.Size(684, 249);
            this.grdSearchResult.TabIndex = 4;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcPalletCode,
            this.gdcPalletName,
            this.gdcLength,
            this.gdcWidth,
            this.gdcHeight,
            this.gdcM3});
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.DoubleClick += new System.EventHandler(this.gdvSearchResult_DoubleClick);
            // 
            // gdcPalletCode
            // 
            this.gdcPalletCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPalletCode.AppearanceHeader.Options.UseFont = true;
            this.gdcPalletCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPalletCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPalletCode.Caption = "Pallet Code";
            this.gdcPalletCode.FieldName = "PalletCode";
            this.gdcPalletCode.Name = "gdcPalletCode";
            this.gdcPalletCode.OptionsColumn.AllowEdit = false;
            this.gdcPalletCode.Visible = true;
            this.gdcPalletCode.VisibleIndex = 0;
            // 
            // gdcPalletName
            // 
            this.gdcPalletName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcPalletName.AppearanceHeader.Options.UseFont = true;
            this.gdcPalletName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPalletName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPalletName.Caption = "Pallet Name";
            this.gdcPalletName.FieldName = "PalletName";
            this.gdcPalletName.Name = "gdcPalletName";
            this.gdcPalletName.OptionsColumn.AllowEdit = false;
            this.gdcPalletName.Visible = true;
            this.gdcPalletName.VisibleIndex = 1;
            // 
            // gdcLength
            // 
            this.gdcLength.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcLength.AppearanceHeader.Options.UseFont = true;
            this.gdcLength.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcLength.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcLength.Caption = "Length";
            this.gdcLength.FieldName = "Length";
            this.gdcLength.Name = "gdcLength";
            this.gdcLength.OptionsColumn.AllowEdit = false;
            this.gdcLength.Visible = true;
            this.gdcLength.VisibleIndex = 2;
            // 
            // gdcWidth
            // 
            this.gdcWidth.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcWidth.AppearanceHeader.Options.UseFont = true;
            this.gdcWidth.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcWidth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcWidth.Caption = "Width";
            this.gdcWidth.FieldName = "Width";
            this.gdcWidth.Name = "gdcWidth";
            this.gdcWidth.OptionsColumn.AllowEdit = false;
            this.gdcWidth.Visible = true;
            this.gdcWidth.VisibleIndex = 3;
            // 
            // gdcHeight
            // 
            this.gdcHeight.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcHeight.AppearanceHeader.Options.UseFont = true;
            this.gdcHeight.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcHeight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcHeight.Caption = "Height";
            this.gdcHeight.FieldName = "Height";
            this.gdcHeight.Name = "gdcHeight";
            this.gdcHeight.OptionsColumn.AllowEdit = false;
            this.gdcHeight.Visible = true;
            this.gdcHeight.VisibleIndex = 4;
            // 
            // gdcM3
            // 
            this.gdcM3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gdcM3.AppearanceHeader.Options.UseFont = true;
            this.gdcM3.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcM3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcM3.Caption = "M3";
            this.gdcM3.FieldName = "M3";
            this.gdcM3.Name = "gdcM3";
            this.gdcM3.OptionsColumn.AllowEdit = false;
            this.gdcM3.Visible = true;
            this.gdcM3.VisibleIndex = 5;
            // 
            // dlgXMSS052_Item_SearchPallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 280);
            this.Controls.Add(this.grdSearchResult);
            this.Name = "dlgXMSS052_Item_SearchPallet";
            this.Text = "dlgXMSS052_Item_SearchPallet";
            this.Load += new System.EventHandler(this.dlgXMSS052_Item_SearchPallet_Load);
            this.Controls.SetChildIndex(this.grdSearchResult, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPalletCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPalletName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcLength;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWidth;
        private DevExpress.XtraGrid.Columns.GridColumn gdcHeight;
        private DevExpress.XtraGrid.Columns.GridColumn gdcM3;
    }
}
namespace Rubix.Screen.Form.Operation.A_Order.Dialog
{
    partial class dlgASO031_SaleOrderByContainer
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
            this.grdResult = new DevExpress.XtraGrid.GridControl();
            this.gdvResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcContainerNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcPalletNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcProductLongName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcOrderQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.grdResult);
            this.panelControl1.Location = new System.Drawing.Point(3, 33);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(860, 362);
            this.panelControl1.TabIndex = 4;
            // 
            // grdResult
            // 
            this.grdResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdResult.Location = new System.Drawing.Point(5, 5);
            this.grdResult.MainView = this.gdvResult;
            this.grdResult.Name = "grdResult";
            this.grdResult.Size = new System.Drawing.Size(851, 353);
            this.grdResult.TabIndex = 0;
            this.grdResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvResult});
            // 
            // gdvResult
            // 
            this.gdvResult.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdvResult.Appearance.HeaderPanel.Options.UseFont = true;
            this.gdvResult.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcContainerNo,
            this.gdcPalletNo,
            this.gdcProductCode,
            this.gdcProductLongName,
            this.gdcOrderQty,
            this.gdcUnitName});
            this.gdvResult.GridControl = this.grdResult;
            this.gdvResult.Name = "gdvResult";
            this.gdvResult.OptionsBehavior.Editable = false;
            this.gdvResult.OptionsCustomization.AllowGroup = false;
            this.gdvResult.OptionsView.ColumnAutoWidth = false;
            this.gdvResult.OptionsView.ShowGroupPanel = false;
            // 
            // gdcContainerNo
            // 
            this.gdcContainerNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcContainerNo.AppearanceHeader.Options.UseFont = true;
            this.gdcContainerNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcContainerNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcContainerNo.Caption = "Container No.";
            this.gdcContainerNo.FieldName = "ContainerNo";
            this.gdcContainerNo.Name = "gdcContainerNo";
            this.gdcContainerNo.Visible = true;
            this.gdcContainerNo.VisibleIndex = 0;
            // 
            // gdcPalletNo
            // 
            this.gdcPalletNo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcPalletNo.AppearanceHeader.Options.UseFont = true;
            this.gdcPalletNo.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcPalletNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcPalletNo.Caption = "Pallet No.";
            this.gdcPalletNo.FieldName = "PalletNo";
            this.gdcPalletNo.Name = "gdcPalletNo";
            this.gdcPalletNo.Visible = true;
            this.gdcPalletNo.VisibleIndex = 1;
            // 
            // gdcProductCode
            // 
            this.gdcProductCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcProductCode.AppearanceHeader.Options.UseFont = true;
            this.gdcProductCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcProductCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcProductCode.Caption = "Product Code";
            this.gdcProductCode.FieldName = "ProductCode";
            this.gdcProductCode.Name = "gdcProductCode";
            this.gdcProductCode.Visible = true;
            this.gdcProductCode.VisibleIndex = 2;
            // 
            // gdcProductLongName
            // 
            this.gdcProductLongName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcProductLongName.AppearanceHeader.Options.UseFont = true;
            this.gdcProductLongName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcProductLongName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcProductLongName.Caption = "Product Name";
            this.gdcProductLongName.FieldName = "ProductLongName";
            this.gdcProductLongName.Name = "gdcProductLongName";
            this.gdcProductLongName.Visible = true;
            this.gdcProductLongName.VisibleIndex = 3;
            // 
            // gdcOrderQty
            // 
            this.gdcOrderQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcOrderQty.AppearanceHeader.Options.UseFont = true;
            this.gdcOrderQty.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcOrderQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcOrderQty.Caption = "Qty";
            this.gdcOrderQty.FieldName = "OrderQty";
            this.gdcOrderQty.Name = "gdcOrderQty";
            this.gdcOrderQty.Visible = true;
            this.gdcOrderQty.VisibleIndex = 4;
            // 
            // gdcUnitName
            // 
            this.gdcUnitName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdcUnitName.AppearanceHeader.Options.UseFont = true;
            this.gdcUnitName.AppearanceHeader.Options.UseTextOptions = true;
            this.gdcUnitName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gdcUnitName.Caption = "Unit";
            this.gdcUnitName.FieldName = "UnitName";
            this.gdcUnitName.Name = "gdcUnitName";
            this.gdcUnitName.Visible = true;
            this.gdcUnitName.VisibleIndex = 5;
            // 
            // dlgASO031_SaleOrderByContainer
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 400);
            this.Controls.Add(this.panelControl1);
            this.Name = "dlgASO031_SaleOrderByContainer";
            this.Text = "ASO031 : Checking Sale Order by Container Dialog";
            this.Load += new System.EventHandler(this.dlgASO031_CheckingSaleOrder_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvResult;
        private DevExpress.XtraGrid.Columns.GridColumn gdcContainerNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPalletNo;
        private DevExpress.XtraGrid.Columns.GridColumn gdcProductCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcProductLongName;
        private DevExpress.XtraGrid.Columns.GridColumn gdcOrderQty;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUnitName;
    }
}
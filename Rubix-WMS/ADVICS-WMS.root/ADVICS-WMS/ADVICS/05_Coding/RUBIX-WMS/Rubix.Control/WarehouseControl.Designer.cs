namespace Rubix.Control
{
    partial class WarehouseControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtWarehouseName = new DevExpress.XtraEditors.TextEdit();
            this.cboWarehouse = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.GridSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcWarehouseCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcWarehouseShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWarehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtWarehouseName
            // 
            this.txtWarehouseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWarehouseName.Location = new System.Drawing.Point(199, 1);
            this.txtWarehouseName.Name = "txtWarehouseName";
            this.txtWarehouseName.Properties.ReadOnly = true;
            this.txtWarehouseName.Size = new System.Drawing.Size(235, 20);
            this.txtWarehouseName.TabIndex = 7;
            this.txtWarehouseName.Tag = "no control";
            // 
            // cboWarehouse
            // 
            this.cboWarehouse.EditValue = "";
            this.cboWarehouse.Location = new System.Drawing.Point(74, 1);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboWarehouse.Properties.NullText = "";
            this.cboWarehouse.Properties.ShowAddNewButton = true;
            this.cboWarehouse.Properties.View = this.GridSearch;
            this.cboWarehouse.Size = new System.Drawing.Size(123, 20);
            this.cboWarehouse.TabIndex = 6;
            this.cboWarehouse.EditValueChanged += new System.EventHandler(this.cboWarehouse_EditValueChanged);
            // 
            // GridSearch
            // 
            this.GridSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcWarehouseCode,
            this.gdcWarehouseShortName});
            this.GridSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridSearch.OptionsView.ShowGroupPanel = false;
            // 
            // gdcWarehouseCode
            // 
            this.gdcWarehouseCode.Caption = "Warehouse Code";
            this.gdcWarehouseCode.Name = "gdcWarehouseCode";
            this.gdcWarehouseCode.Visible = true;
            this.gdcWarehouseCode.VisibleIndex = 0;
            // 
            // gdcWarehouseShortName
            // 
            this.gdcWarehouseShortName.Caption = "Warehouse Name";
            this.gdcWarehouseShortName.FieldName = "WarehouseName";
            this.gdcWarehouseShortName.Name = "gdcWarehouseShortName";
            this.gdcWarehouseShortName.Visible = true;
            this.gdcWarehouseShortName.VisibleIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(65, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(6, 13);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "  ";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(2, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 13);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "Warehouse";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // WarehouseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtWarehouseName);
            this.Controls.Add(this.cboWarehouse);
            this.Name = "WarehouseControl";
            this.Size = new System.Drawing.Size(434, 22);
            this.Load += new System.EventHandler(this.WarehouseControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtWarehouseName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWarehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtWarehouseName;
        private DevExpress.XtraEditors.SearchLookUpEdit cboWarehouse;
        private DevExpress.XtraGrid.Views.Grid.GridView GridSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWarehouseCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcWarehouseShortName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider errorProvider;
    }
}

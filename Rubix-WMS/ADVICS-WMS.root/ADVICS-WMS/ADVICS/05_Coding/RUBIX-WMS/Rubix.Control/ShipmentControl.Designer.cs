namespace Rubix.Control
{
    partial class ShipmentControl
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboShipmentNo = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.GridSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcShipmentNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            ((System.ComponentModel.ISupportInitialize)(this.cboShipmentNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(8, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(115, 13);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Shipment No.";
            // 
            // cboShipmentNo
            // 
            this.cboShipmentNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboShipmentNo.EditValue = "";
            this.cboShipmentNo.Location = new System.Drawing.Point(135, 2);
            this.cboShipmentNo.Name = "cboShipmentNo";
            this.cboShipmentNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboShipmentNo.Properties.NullText = "";
            this.cboShipmentNo.Properties.View = this.GridSearch;
            this.cboShipmentNo.Size = new System.Drawing.Size(176, 20);
            this.cboShipmentNo.TabIndex = 16;
            this.cboShipmentNo.EditValueChanged += new System.EventHandler(this.cboShipmentNo_EditValueChanged);
            // 
            // GridSearch
            // 
            this.GridSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcShipmentNo});
            this.GridSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridSearch.OptionsView.ShowGroupPanel = false;
            // 
            // gdcShipmentNo
            // 
            this.gdcShipmentNo.Caption = "Shipment No";
            this.gdcShipmentNo.Name = "gdcShipmentNo";
            this.gdcShipmentNo.Visible = true;
            this.gdcShipmentNo.VisibleIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(68, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(6, 13);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "  ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ShipmentControl
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cboShipmentNo);
            this.Controls.Add(this.labelControl2);
            this.Name = "ShipmentControl";
            this.Size = new System.Drawing.Size(311, 22);
            this.Load += new System.EventHandler(this.ShipmentControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboShipmentNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gdcShipmentNo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit cboShipmentNo;
        private DevExpress.XtraGrid.Views.Grid.GridView GridSearch;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider errorProvider;
    }
}

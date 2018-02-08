namespace Rubix.Screen.Form.Operation.H_Picking.Dialog
{
    partial class dlgHPCS011_ReprintPickingList
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
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.requireField2 = new Rubix.Control.RequireField();
            this.requireField1 = new Rubix.Control.RequireField();
            this.dtPickingDateTo = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtPickingDateFrom = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pickingControl = new Rubix.Control.PickingControl();
            this.finalDestinationControl = new Rubix.Control.FinalDestinationControl();
            this.portOfDischargeControl = new Rubix.Control.PortOfDischarge();
            this.warehouseControl = new Rubix.Control.WarehouseControl();
            this.ownerControl = new Rubix.Control.OwnerControl();
            this.shipmentControl = new Rubix.Control.ShipmentControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.requireField2);
            this.groupControl3.Controls.Add(this.requireField1);
            this.groupControl3.Controls.Add(this.dtPickingDateTo);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Controls.Add(this.dtPickingDateFrom);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.pickingControl);
            this.groupControl3.Controls.Add(this.finalDestinationControl);
            this.groupControl3.Controls.Add(this.portOfDischargeControl);
            this.groupControl3.Controls.Add(this.warehouseControl);
            this.groupControl3.Controls.Add(this.ownerControl);
            this.groupControl3.Controls.Add(this.shipmentControl);
            this.groupControl3.Location = new System.Drawing.Point(2, 31);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(543, 181);
            this.groupControl3.TabIndex = 0;
            this.groupControl3.Text = "Search Criteria";
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(125, 51);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 119;
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(125, 30);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 119;
            // 
            // dtPickingDateTo
            // 
            this.dtPickingDateTo.EditValue = null;
            this.dtPickingDateTo.Location = new System.Drawing.Point(282, 114);
            this.dtPickingDateTo.Name = "dtPickingDateTo";
            this.dtPickingDateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtPickingDateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtPickingDateTo.Size = new System.Drawing.Size(123, 20);
            this.dtPickingDateTo.TabIndex = 5;
            this.dtPickingDateTo.EditValueChanged += new System.EventHandler(this.dtPickingDateTo_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(265, 117);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(11, 17);
            this.labelControl2.TabIndex = 122;
            this.labelControl2.Text = "to";
            // 
            // dtPickingDateFrom
            // 
            this.dtPickingDateFrom.EditValue = null;
            this.dtPickingDateFrom.Location = new System.Drawing.Point(136, 114);
            this.dtPickingDateFrom.Name = "dtPickingDateFrom";
            this.dtPickingDateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtPickingDateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtPickingDateFrom.Size = new System.Drawing.Size(123, 20);
            this.dtPickingDateFrom.TabIndex = 4;
            this.dtPickingDateFrom.EditValueChanged += new System.EventHandler(this.dtPickingDateFrom_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(39, 117);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(86, 13);
            this.labelControl1.TabIndex = 120;
            this.labelControl1.Text = "Picking Date";
            // 
            // pickingControl
            // 
            this.pickingControl.ComboType = Rubix.Control.PickingControl.eComboType.Screen;
            this.pickingControl.ErrorText = "Picking Control is Require Field";
            this.pickingControl.Location = new System.Drawing.Point(4, 157);
            this.pickingControl.Name = "pickingControl";
            this.pickingControl.OwnerID = null;
            this.pickingControl.RequireField = false;
            this.pickingControl.Size = new System.Drawing.Size(491, 22);
            this.pickingControl.TabIndex = 7;
            this.pickingControl.WarehouseID = null;
            // 
            // finalDestinationControl
            // 
            this.finalDestinationControl.ErrorText = "Final Destionation Control is Require Field";
            this.finalDestinationControl.Location = new System.Drawing.Point(42, 91);
            this.finalDestinationControl.Name = "finalDestinationControl";
            this.finalDestinationControl.ReadOnly = false;
            this.finalDestinationControl.RequireField = false;
            this.finalDestinationControl.Size = new System.Drawing.Size(456, 21);
            this.finalDestinationControl.TabIndex = 3;
            // 
            // portOfDischargeControl
            // 
            this.portOfDischargeControl.ErrorText = "Port of Discharge Control is Require Field";
            this.portOfDischargeControl.Location = new System.Drawing.Point(39, 67);
            this.portOfDischargeControl.Name = "portOfDischargeControl";
            this.portOfDischargeControl.RequireField = false;
            this.portOfDischargeControl.Size = new System.Drawing.Size(460, 25);
            this.portOfDischargeControl.TabIndex = 2;
            // 
            // warehouseControl
            // 
            this.warehouseControl.ErrorText = "Warehouse Control is Require Field";
            this.warehouseControl.IsForEdit = false;
            this.warehouseControl.Location = new System.Drawing.Point(62, 46);
            this.warehouseControl.Name = "warehouseControl";
            this.warehouseControl.RequireField = false;
            this.warehouseControl.Size = new System.Drawing.Size(433, 21);
            this.warehouseControl.TabIndex = 1;
            // 
            // ownerControl
            // 
            this.ownerControl.ErrorText = "Owner Control is Require Field";
            this.ownerControl.IsForEdit = false;
            this.ownerControl.IsLoginScreen = false;
            this.ownerControl.Location = new System.Drawing.Point(76, 24);
            this.ownerControl.Name = "ownerControl";
            this.ownerControl.ReadOnly = false;
            this.ownerControl.RequireField = false;
            this.ownerControl.Size = new System.Drawing.Size(419, 21);
            this.ownerControl.TabIndex = 0;
            this.ownerControl.EditValueChanged += new System.EventHandler(this.ownerControl_EditValueChanged);
            // 
            // shipmentControl
            // 
            this.shipmentControl.ErrorText = "Shipment Control is Require Field";
            this.shipmentControl.Location = new System.Drawing.Point(1, 134);
            this.shipmentControl.Name = "shipmentControl";
            this.shipmentControl.RequireField = false;
            this.shipmentControl.Size = new System.Drawing.Size(494, 22);
            this.shipmentControl.TabIndex = 6;
            this.shipmentControl.EditValueChanged += new System.EventHandler(this.shipmentControl_EditValueChanged);
            // 
            // dlgHPCS011_ReprintPickingList
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 218);
            this.Controls.Add(this.groupControl3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgHPCS011_ReprintPickingList";
            this.ShowIcon = false;
            this.Text = "HPCS011 : Picking List Reprint Dialog";
            this.Load += new System.EventHandler(this.dlgHPCS011_ReprintPickingList_Load);
            this.Controls.SetChildIndex(this.groupControl3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPickingDateFrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl3;
        private Control.ShipmentControl shipmentControl;
        private Control.PickingControl pickingControl;
        private Control.FinalDestinationControl finalDestinationControl;
        private Control.PortOfDischarge portOfDischargeControl;
        private Control.WarehouseControl warehouseControl;
        private Control.OwnerControl ownerControl;
        private DevExpress.XtraEditors.DateEdit dtPickingDateTo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dtPickingDateFrom;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Control.RequireField requireField2;
        private Control.RequireField requireField1;
    }
}
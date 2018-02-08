﻿namespace Rubix.Control
{
    partial class PortOfLoading
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
            this.components = new System.ComponentModel.Container();
            this.gdcPortCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.GridSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcPortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboPort = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.txtPortName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPortName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gdcPortCode
            // 
            this.gdcPortCode.Caption = "Port Code";
            this.gdcPortCode.Name = "gdcPortCode";
            this.gdcPortCode.Visible = true;
            this.gdcPortCode.VisibleIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(1, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 13);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "Port of Loading";
            // 
            // GridSearch
            // 
            this.GridSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcPortCode,
            this.gdcPortName});
            this.GridSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridSearch.OptionsView.ShowGroupPanel = false;
            // 
            // gdcPortName
            // 
            this.gdcPortName.Caption = "Port Name";
            this.gdcPortName.Name = "gdcPortName";
            this.gdcPortName.Visible = true;
            this.gdcPortName.VisibleIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(29, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(6, 13);
            this.labelControl2.TabIndex = 33;
            this.labelControl2.Text = "  ";
            // 
            // cboPort
            // 
            this.cboPort.EditValue = "";
            this.cboPort.Location = new System.Drawing.Point(86, 1);
            this.cboPort.Name = "cboPort";
            this.cboPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPort.Properties.NullText = "";
            this.cboPort.Properties.View = this.GridSearch;
            this.cboPort.Size = new System.Drawing.Size(123, 20);
            this.cboPort.TabIndex = 31;
            this.cboPort.EditValueChanged += new System.EventHandler(this.cboPort_EditValueChanged);
            // 
            // txtPortName
            // 
            this.txtPortName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPortName.Location = new System.Drawing.Point(211, 1);
            this.txtPortName.Name = "txtPortName";
            this.txtPortName.Properties.ReadOnly = true;
            this.txtPortName.Size = new System.Drawing.Size(234, 20);
            this.txtPortName.TabIndex = 32;
            this.txtPortName.Tag = "no control";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(77, 5);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(6, 13);
            this.labelControl3.TabIndex = 35;
            this.labelControl3.Text = "  ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // PortOfLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboPort);
            this.Controls.Add(this.txtPortName);
            this.Name = "PortOfLoading";
            this.Size = new System.Drawing.Size(448, 22);
            this.Load += new System.EventHandler(this.PortOfLoading_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPortName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gdcPortCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView GridSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gdcPortName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit cboPort;
        private DevExpress.XtraEditors.TextEdit txtPortName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider errorProvider;
    }
}

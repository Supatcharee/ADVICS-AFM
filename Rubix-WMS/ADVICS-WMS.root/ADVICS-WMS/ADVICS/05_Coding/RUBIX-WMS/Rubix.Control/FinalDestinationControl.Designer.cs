namespace Rubix.Control
{
    partial class FinalDestinationControl
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboFinalDestination = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.GridSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcFinalDestinationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcFinalDestinationShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtFinalDestinationName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboFinalDestination.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinalDestinationName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(4, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 13);
            this.labelControl1.TabIndex = 30;
            this.labelControl1.Text = "Final Destination";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(35, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(6, 13);
            this.labelControl2.TabIndex = 29;
            this.labelControl2.Text = "  ";
            // 
            // cboFinalDestination
            // 
            this.cboFinalDestination.EditValue = "";
            this.cboFinalDestination.Location = new System.Drawing.Point(94, 1);
            this.cboFinalDestination.Name = "cboFinalDestination";
            this.cboFinalDestination.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFinalDestination.Properties.NullText = "";
            this.cboFinalDestination.Properties.View = this.GridSearch;
            this.cboFinalDestination.Size = new System.Drawing.Size(123, 20);
            this.cboFinalDestination.TabIndex = 27;
            this.cboFinalDestination.EditValueChanged += new System.EventHandler(this.cboFinalDestination_EditValueChanged);
            // 
            // GridSearch
            // 
            this.GridSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcFinalDestinationCode,
            this.gdcFinalDestinationShortName});
            this.GridSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridSearch.OptionsView.ShowGroupPanel = false;
            // 
            // gdcFinalDestinationCode
            // 
            this.gdcFinalDestinationCode.Caption = "Final Destination Code";
            this.gdcFinalDestinationCode.Name = "gdcFinalDestinationCode";
            this.gdcFinalDestinationCode.Visible = true;
            this.gdcFinalDestinationCode.VisibleIndex = 0;
            // 
            // gdcFinalDestinationShortName
            // 
            this.gdcFinalDestinationShortName.Caption = "Final Destination Short Name";
            this.gdcFinalDestinationShortName.Name = "gdcFinalDestinationShortName";
            this.gdcFinalDestinationShortName.Visible = true;
            this.gdcFinalDestinationShortName.VisibleIndex = 1;
            // 
            // txtFinalDestinationName
            // 
            this.txtFinalDestinationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFinalDestinationName.Location = new System.Drawing.Point(219, 1);
            this.txtFinalDestinationName.Name = "txtFinalDestinationName";
            this.txtFinalDestinationName.Properties.ReadOnly = true;
            this.txtFinalDestinationName.Size = new System.Drawing.Size(235, 20);
            this.txtFinalDestinationName.TabIndex = 28;
            this.txtFinalDestinationName.Tag = "no control";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(85, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(6, 13);
            this.labelControl3.TabIndex = 31;
            this.labelControl3.Text = "  ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FinalDestinationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboFinalDestination);
            this.Controls.Add(this.txtFinalDestinationName);
            this.Name = "FinalDestinationControl";
            this.Size = new System.Drawing.Size(456, 21);
            this.Load += new System.EventHandler(this.FinalDestinationControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboFinalDestination.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinalDestinationName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit cboFinalDestination;
        private DevExpress.XtraGrid.Views.Grid.GridView GridSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gdcFinalDestinationCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcFinalDestinationShortName;
        private DevExpress.XtraEditors.TextEdit txtFinalDestinationName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider errorProvider;
    }
}

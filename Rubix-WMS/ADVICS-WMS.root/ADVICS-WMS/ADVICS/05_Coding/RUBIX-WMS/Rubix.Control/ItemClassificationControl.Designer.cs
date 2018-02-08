namespace Rubix.Control
{
    partial class ItemClassificationControl
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
            this.cboItemClassification = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.GridSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcItemClassificationCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcItemClassificationName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtItemClassificationName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboItemClassification.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemClassificationName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cboItemClassification
            // 
            this.cboItemClassification.EditValue = 0;
            this.cboItemClassification.Location = new System.Drawing.Point(105, 2);
            this.cboItemClassification.Name = "cboItemClassification";
            this.cboItemClassification.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboItemClassification.Properties.NullText = "";
            this.cboItemClassification.Properties.View = this.GridSearch;
            this.cboItemClassification.Size = new System.Drawing.Size(123, 20);
            this.cboItemClassification.TabIndex = 12;
            this.cboItemClassification.EditValueChanged += new System.EventHandler(this.cboItemClassification_EditValueChanged);
            // 
            // GridSearch
            // 
            this.GridSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcItemClassificationCode,
            this.gdcItemClassificationName});
            this.GridSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridSearch.OptionsView.ShowGroupPanel = false;
            // 
            // gdcItemClassificationCode
            // 
            this.gdcItemClassificationCode.Caption = "Item Classification Code";
            this.gdcItemClassificationCode.Name = "gdcItemClassificationCode";
            this.gdcItemClassificationCode.Visible = true;
            this.gdcItemClassificationCode.VisibleIndex = 0;
            // 
            // gdcItemClassificationName
            // 
            this.gdcItemClassificationName.Caption = "Item Classification Name";
            this.gdcItemClassificationName.Name = "gdcItemClassificationName";
            this.gdcItemClassificationName.Visible = true;
            this.gdcItemClassificationName.VisibleIndex = 1;
            // 
            // txtItemClassificationName
            // 
            this.txtItemClassificationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemClassificationName.Location = new System.Drawing.Point(230, 2);
            this.txtItemClassificationName.Name = "txtItemClassificationName";
            this.txtItemClassificationName.Properties.ReadOnly = true;
            this.txtItemClassificationName.Size = new System.Drawing.Size(258, 20);
            this.txtItemClassificationName.TabIndex = 13;
            this.txtItemClassificationName.Tag = "no control";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(5, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 13);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Item Classification";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(95, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(6, 13);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "  ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ClassificationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboItemClassification);
            this.Controls.Add(this.txtItemClassificationName);
            this.Controls.Add(this.labelControl1);
            this.Name = "ClassificationControl";
            this.Size = new System.Drawing.Size(488, 22);
            this.Load += new System.EventHandler(this.ItemClassificationControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboItemClassification.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemClassificationName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gdcItemClassificationCode;
        private DevExpress.XtraEditors.SearchLookUpEdit cboItemClassification;
        private DevExpress.XtraGrid.Views.Grid.GridView GridSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gdcItemClassificationName;
        private DevExpress.XtraEditors.TextEdit txtItemClassificationName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider errorProvider;
    }
}

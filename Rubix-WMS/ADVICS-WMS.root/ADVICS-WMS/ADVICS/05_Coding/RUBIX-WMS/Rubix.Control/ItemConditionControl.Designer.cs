namespace Rubix.Control
{
    partial class ItemConditionControl
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
            this.GridSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcItemConditionCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcItemConditionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboItemCondition = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.txtItemConditionName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboItemCondition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemConditionName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // GridSearch
            // 
            this.GridSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcItemConditionCode,
            this.gdcItemConditionName});
            this.GridSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridSearch.OptionsView.ShowGroupPanel = false;
            // 
            // gdcItemConditionCode
            // 
            this.gdcItemConditionCode.Caption = "Item Condition Code";
            this.gdcItemConditionCode.Name = "gdcItemConditionCode";
            this.gdcItemConditionCode.Visible = true;
            this.gdcItemConditionCode.VisibleIndex = 0;
            // 
            // gdcItemConditionName
            // 
            this.gdcItemConditionName.Caption = "Item Condition Name";
            this.gdcItemConditionName.Name = "gdcItemConditionName";
            this.gdcItemConditionName.Visible = true;
            this.gdcItemConditionName.VisibleIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(93, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(6, 13);
            this.labelControl2.TabIndex = 21;
            this.labelControl2.Text = "  ";
            // 
            // cboItemCondition
            // 
            this.cboItemCondition.EditValue = "";
            this.cboItemCondition.Location = new System.Drawing.Point(102, 2);
            this.cboItemCondition.Name = "cboItemCondition";
            this.cboItemCondition.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboItemCondition.Properties.NullText = "";
            this.cboItemCondition.Properties.View = this.GridSearch;
            this.cboItemCondition.Size = new System.Drawing.Size(88, 20);
            this.cboItemCondition.TabIndex = 18;
            this.cboItemCondition.EditValueChanged += new System.EventHandler(this.cboItemCondition_EditValueChanged);
            // 
            // txtItemConditionName
            // 
            this.txtItemConditionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemConditionName.Location = new System.Drawing.Point(191, 2);
            this.txtItemConditionName.Name = "txtItemConditionName";
            this.txtItemConditionName.Properties.ReadOnly = true;
            this.txtItemConditionName.Size = new System.Drawing.Size(285, 20);
            this.txtItemConditionName.TabIndex = 19;
            this.txtItemConditionName.Tag = "no control";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(3, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 13);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "Item Condition";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ItemConditionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboItemCondition);
            this.Controls.Add(this.txtItemConditionName);
            this.Name = "ItemConditionControl";
            this.Size = new System.Drawing.Size(476, 22);
            this.Load += new System.EventHandler(this.ItemCondition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboItemCondition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemConditionName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView GridSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gdcItemConditionCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcItemConditionName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit cboItemCondition;
        private DevExpress.XtraEditors.TextEdit txtItemConditionName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider errorProvider;
    }
}

namespace Rubix.Control
{
    partial class ItemPriceControl
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
            this.cboItem = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.GridSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcItemShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtItemName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.errorProvider = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboItem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cboItem
            // 
            this.cboItem.EditValue = "";
            this.cboItem.Location = new System.Drawing.Point(41, 1);
            this.cboItem.Name = "cboItem";
            this.cboItem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboItem.Properties.NullText = "";
            this.cboItem.Properties.View = this.GridSearch;
            this.cboItem.Size = new System.Drawing.Size(123, 20);
            this.cboItem.TabIndex = 2;
            this.cboItem.EditValueChanged += new System.EventHandler(this.cboItem_EditValueChanged);
            // 
            // GridSearch
            // 
            this.GridSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcItemCode,
            this.gdcItemShortName});
            this.GridSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridSearch.OptionsView.ShowGroupPanel = false;
            // 
            // gdcItemCode
            // 
            this.gdcItemCode.Caption = "Item Code";
            this.gdcItemCode.Name = "gdcItemCode";
            this.gdcItemCode.Visible = true;
            this.gdcItemCode.VisibleIndex = 0;
            // 
            // gdcItemShortName
            // 
            this.gdcItemShortName.Caption = "Item Name";
            this.gdcItemShortName.Name = "gdcItemShortName";
            this.gdcItemShortName.Visible = true;
            this.gdcItemShortName.VisibleIndex = 1;
            // 
            // txtItemName
            // 
            this.txtItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemName.Location = new System.Drawing.Point(166, 1);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Properties.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(234, 20);
            this.txtItemName.TabIndex = 3;
            this.txtItemName.Tag = "no control";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(4, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(25, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Item";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(32, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(6, 13);
            this.labelControl2.TabIndex = 17;
            this.labelControl2.Text = "  ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ProductControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cboItem);
            this.Controls.Add(this.txtItemName);
            this.Name = "ProductControl";
            this.Size = new System.Drawing.Size(400, 22);
            this.Load += new System.EventHandler(this.ItemPriceControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboItem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit cboItem;
        private DevExpress.XtraGrid.Views.Grid.GridView GridSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gdcItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn gdcItemShortName;
        private DevExpress.XtraEditors.TextEdit txtItemName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider errorProvider;
    }
}

namespace Rubix.Screen.Form.Master
{
    partial class frmXMSS230_WorkMethod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXMSS230_WorkMethod));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grdSearchResult = new DevExpress.XtraGrid.GridControl();
            this.gdvSearchResult = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtWorkMethodName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtWorkMethodCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkMethodName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkMethodCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Size = new System.Drawing.Size(887, 47);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdSearchResult);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 161);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(887, 333);
            this.groupControl2.TabIndex = 11;
            this.groupControl2.Text = "Search Result";
            // 
            // grdSearchResult
            // 
            this.grdSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSearchResult.Location = new System.Drawing.Point(6, 24);
            this.grdSearchResult.MainView = this.gdvSearchResult;
            this.grdSearchResult.MenuManager = this.ribbonControl1;
            this.grdSearchResult.Name = "grdSearchResult";
            this.grdSearchResult.Size = new System.Drawing.Size(875, 303);
            this.grdSearchResult.TabIndex = 0;
            this.grdSearchResult.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvSearchResult});
            // 
            // gdvSearchResult
            // 
            this.gdvSearchResult.BestFitMaxRowCount = 50;
            this.gdvSearchResult.GridControl = this.grdSearchResult;
            this.gdvSearchResult.Name = "gdvSearchResult";
            this.gdvSearchResult.OptionsView.ColumnAutoWidth = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtWorkMethodName);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.btnClear);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.txtWorkMethodCode);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 78);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(887, 83);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "Search Criteria";
            // 
            // txtWorkMethodName
            // 
            this.txtWorkMethodName.Location = new System.Drawing.Point(114, 50);
            this.txtWorkMethodName.MenuManager = this.ribbonControl1;
            this.txtWorkMethodName.Name = "txtWorkMethodName";
            this.txtWorkMethodName.Size = new System.Drawing.Size(360, 20);
            this.txtWorkMethodName.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(15, 57);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(94, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Work Method Name";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.Location = new System.Drawing.Point(804, 46);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(723, 46);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtWorkMethodCode
            // 
            this.txtWorkMethodCode.Location = new System.Drawing.Point(114, 27);
            this.txtWorkMethodCode.MenuManager = this.ribbonControl1;
            this.txtWorkMethodCode.Name = "txtWorkMethodCode";
            this.txtWorkMethodCode.Size = new System.Drawing.Size(125, 20);
            this.txtWorkMethodCode.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(9, 32);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(101, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Work Method Code";
            // 
            // frmXMSS230_WorkMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 494);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmXMSS230_WorkMethod";
            this.Text = "XMSS230 : Work Method Master";
            this.Load += new System.EventHandler(this.frmXMSS230_WorkMethod_Load);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvSearchResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkMethodName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkMethodCode.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdSearchResult;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvSearchResult;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtWorkMethodName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.TextEdit txtWorkMethodCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
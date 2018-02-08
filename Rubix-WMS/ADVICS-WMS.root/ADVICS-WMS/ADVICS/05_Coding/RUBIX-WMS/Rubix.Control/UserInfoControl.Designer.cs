namespace Rubix.Control
{
    partial class UserInfoControl
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
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.cboUser = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.GridSearch = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gdcUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gdcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(190, 1);
            this.txtName.Name = "txtName";
            this.txtName.Properties.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(238, 20);
            this.txtName.TabIndex = 7;
            this.txtName.Tag = "no control";
            // 
            // cboUser
            // 
            this.cboUser.EditValue = "";
            this.cboUser.Location = new System.Drawing.Point(65, 1);
            this.cboUser.Name = "cboUser";
            this.cboUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUser.Properties.NullText = "";
            this.cboUser.Properties.View = this.GridSearch;
            this.cboUser.Size = new System.Drawing.Size(123, 20);
            this.cboUser.TabIndex = 6;
            this.cboUser.EditValueChanged += new System.EventHandler(this.cboUser_EditValueChanged);
            // 
            // GridSearch
            // 
            this.GridSearch.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gdcUserID,
            this.gdcName});
            this.GridSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.GridSearch.Name = "GridSearch";
            this.GridSearch.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.GridSearch.OptionsView.ShowGroupPanel = false;
            // 
            // gdcUserID
            // 
            this.gdcUserID.Caption = "User ID";
            this.gdcUserID.Name = "gdcUserID";
            this.gdcUserID.Visible = true;
            this.gdcUserID.VisibleIndex = 0;
            // 
            // gdcName
            // 
            this.gdcName.Caption = "Name";
            this.gdcName.Name = "gdcName";
            this.gdcName.Visible = true;
            this.gdcName.VisibleIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(56, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(6, 13);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "  ";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(0, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 17;
            this.labelControl1.Text = "User Name";
            // 
            // UserInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cboUser);
            this.Name = "UserInfoControl";
            this.Size = new System.Drawing.Size(430, 21);
            this.Load += new System.EventHandler(this.UserInfoControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.SearchLookUpEdit cboUser;
        private DevExpress.XtraGrid.Views.Grid.GridView GridSearch;
        private DevExpress.XtraGrid.Columns.GridColumn gdcUserID;
        private DevExpress.XtraGrid.Columns.GridColumn gdcName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}

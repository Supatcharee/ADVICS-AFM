namespace Rubix.Screen.Form.Admin.Dialog
{
    partial class dlgADM050_MultiLanguage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgADM050_MultiLanguage));
            this.txtFileName = new DevExpress.XtraEditors.TextEdit();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.lblFile = new DevExpress.XtraEditors.LabelControl();
            this.lblFilter = new DevExpress.XtraEditors.LabelControl();
            this.txtFilter = new DevExpress.XtraEditors.TextEdit();
            this.lstvControl = new System.Windows.Forms.ListView();
            this.clhControlType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhControlName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstvScreen = new System.Windows.Forms.ListView();
            this.clhScreenName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnUnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(40, 9);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Properties.MaxLength = 15;
            this.txtFileName.Size = new System.Drawing.Size(595, 20);
            this.txtFileName.TabIndex = 27;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowse.Image")));
            this.btnBrowse.Location = new System.Drawing.Point(641, 7);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(71, 24);
            this.btnBrowse.TabIndex = 28;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblFile
            // 
            this.lblFile.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblFile.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFile.Location = new System.Drawing.Point(2, 11);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(36, 17);
            this.lblFile.TabIndex = 29;
            this.lblFile.Text = "File";
            // 
            // lblFilter
            // 
            this.lblFilter.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblFilter.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFilter.Location = new System.Drawing.Point(1, 34);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(38, 16);
            this.lblFilter.TabIndex = 30;
            this.lblFilter.Text = "Filter";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(40, 32);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Properties.MaxLength = 15;
            this.txtFilter.Size = new System.Drawing.Size(595, 20);
            this.txtFilter.TabIndex = 31;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lstvControl
            // 
            this.lstvControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstvControl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhControlType,
            this.clhControlName});
            this.lstvControl.Location = new System.Drawing.Point(360, 58);
            this.lstvControl.Name = "lstvControl";
            this.lstvControl.Size = new System.Drawing.Size(352, 314);
            this.lstvControl.TabIndex = 33;
            this.lstvControl.UseCompatibleStateImageBehavior = false;
            this.lstvControl.View = System.Windows.Forms.View.Details;
            // 
            // clhControlType
            // 
            this.clhControlType.Text = "Control Type";
            this.clhControlType.Width = 172;
            // 
            // clhControlName
            // 
            this.clhControlName.Text = "Control Name";
            this.clhControlName.Width = 175;
            // 
            // lstvScreen
            // 
            this.lstvScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstvScreen.CheckBoxes = true;
            this.lstvScreen.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhScreenName});
            this.lstvScreen.Location = new System.Drawing.Point(6, 58);
            this.lstvScreen.Name = "lstvScreen";
            this.lstvScreen.Size = new System.Drawing.Size(348, 314);
            this.lstvScreen.TabIndex = 32;
            this.lstvScreen.UseCompatibleStateImageBehavior = false;
            this.lstvScreen.View = System.Windows.Forms.View.Details;
            this.lstvScreen.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstvScreen_ColumnClick);
            this.lstvScreen.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstvScreen_ItemSelectionChanged);
            // 
            // clhScreenName
            // 
            this.clhScreenName.Text = "Class Name";
            this.clhScreenName.Width = 344;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.Location = new System.Drawing.Point(6, 378);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(99, 24);
            this.btnSelectAll.TabIndex = 34;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnUnSelectAll
            // 
            this.btnUnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnUnSelectAll.Image")));
            this.btnUnSelectAll.Location = new System.Drawing.Point(111, 378);
            this.btnUnSelectAll.Name = "btnUnSelectAll";
            this.btnUnSelectAll.Size = new System.Drawing.Size(99, 24);
            this.btnUnSelectAll.TabIndex = 35;
            this.btnUnSelectAll.Text = "Un-Select All";
            this.btnUnSelectAll.Click += new System.EventHandler(this.btnUnSelectAll_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(6, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(706, 3);
            this.label1.TabIndex = 36;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(641, 423);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 24);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(564, 423);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(71, 24);
            this.btnOK.TabIndex = 38;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dlgADM050_MultiLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 457);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUnSelectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.lstvControl);
            this.Controls.Add(this.lstvScreen);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFileName);
            this.Name = "dlgADM050_MultiLanguage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ADM050 : List Screen MultiLanguage";
            this.Load += new System.EventHandler(this.dlgADM050_MultiLanguage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtFileName;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private DevExpress.XtraEditors.LabelControl lblFile;
        private DevExpress.XtraEditors.LabelControl lblFilter;
        private DevExpress.XtraEditors.TextEdit txtFilter;
        private System.Windows.Forms.ListView lstvControl;
        private System.Windows.Forms.ColumnHeader clhControlType;
        private System.Windows.Forms.ColumnHeader clhControlName;
        private System.Windows.Forms.ListView lstvScreen;
        private System.Windows.Forms.ColumnHeader clhScreenName;
        private DevExpress.XtraEditors.SimpleButton btnSelectAll;
        private DevExpress.XtraEditors.SimpleButton btnUnSelectAll;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
    }
}
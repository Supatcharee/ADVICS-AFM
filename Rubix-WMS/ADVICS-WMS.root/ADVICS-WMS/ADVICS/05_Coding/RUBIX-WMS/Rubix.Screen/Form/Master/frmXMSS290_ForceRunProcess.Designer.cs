namespace Rubix.Screen.Form.Master
{
    partial class frmXMSS290_ForceRunProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXMSS290_ForceRunProcess));
            this.grpDailyProcessConfig = new DevExpress.XtraEditors.GroupControl();
            this.lblDailyProcess = new DevExpress.XtraEditors.LabelControl();
            this.btnRunDaily = new DevExpress.XtraEditors.SimpleButton();
            this.grpMonthlyProcessConfig = new DevExpress.XtraEditors.GroupControl();
            this.lblMonthly = new DevExpress.XtraEditors.LabelControl();
            this.btnRunMonthly = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnAutoCalculateProcess = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDailyProcessConfig)).BeginInit();
            this.grpDailyProcessConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMonthlyProcessConfig)).BeginInit();
            this.grpMonthlyProcessConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
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
            // grpDailyProcessConfig
            // 
            this.grpDailyProcessConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDailyProcessConfig.Controls.Add(this.lblDailyProcess);
            this.grpDailyProcessConfig.Controls.Add(this.btnRunDaily);
            this.grpDailyProcessConfig.Location = new System.Drawing.Point(4, 34);
            this.grpDailyProcessConfig.Name = "grpDailyProcessConfig";
            this.grpDailyProcessConfig.Size = new System.Drawing.Size(878, 99);
            this.grpDailyProcessConfig.TabIndex = 0;
            this.grpDailyProcessConfig.Text = "Daily Process ";
            // 
            // lblDailyProcess
            // 
            this.lblDailyProcess.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDailyProcess.Location = new System.Drawing.Point(38, 50);
            this.lblDailyProcess.Name = "lblDailyProcess";
            this.lblDailyProcess.Size = new System.Drawing.Size(480, 19);
            this.lblDailyProcess.TabIndex = 1;
            this.lblDailyProcess.Text = "Daily Process will be ran everyday at 01:00 AM";
            // 
            // btnRunDaily
            // 
            this.btnRunDaily.Image = ((System.Drawing.Image)(resources.GetObject("btnRunDaily.Image")));
            this.btnRunDaily.Location = new System.Drawing.Point(524, 37);
            this.btnRunDaily.Name = "btnRunDaily";
            this.btnRunDaily.Size = new System.Drawing.Size(187, 43);
            this.btnRunDaily.TabIndex = 1;
            this.btnRunDaily.Text = "Force Run Daily";
            this.btnRunDaily.Click += new System.EventHandler(this.btnRunDaily_Click);
            // 
            // grpMonthlyProcessConfig
            // 
            this.grpMonthlyProcessConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMonthlyProcessConfig.Controls.Add(this.lblMonthly);
            this.grpMonthlyProcessConfig.Controls.Add(this.btnRunMonthly);
            this.grpMonthlyProcessConfig.Location = new System.Drawing.Point(4, 142);
            this.grpMonthlyProcessConfig.Name = "grpMonthlyProcessConfig";
            this.grpMonthlyProcessConfig.Size = new System.Drawing.Size(878, 106);
            this.grpMonthlyProcessConfig.TabIndex = 1;
            this.grpMonthlyProcessConfig.Text = "Monthly Process";
            // 
            // lblMonthly
            // 
            this.lblMonthly.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMonthly.Location = new System.Drawing.Point(38, 53);
            this.lblMonthly.Name = "lblMonthly";
            this.lblMonthly.Size = new System.Drawing.Size(480, 19);
            this.lblMonthly.TabIndex = 2;
            this.lblMonthly.Text = "Monthy Process will be ran at the beginning of month at 01:00 AM";
            // 
            // btnRunMonthly
            // 
            this.btnRunMonthly.Image = ((System.Drawing.Image)(resources.GetObject("btnRunMonthly.Image")));
            this.btnRunMonthly.Location = new System.Drawing.Point(524, 41);
            this.btnRunMonthly.Name = "btnRunMonthly";
            this.btnRunMonthly.Size = new System.Drawing.Size(187, 42);
            this.btnRunMonthly.TabIndex = 2;
            this.btnRunMonthly.Text = "Force Run Monthly";
            this.btnRunMonthly.Click += new System.EventHandler(this.btnRunMonthly_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btnAutoCalculateProcess);
            this.groupControl1.Location = new System.Drawing.Point(4, 254);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(878, 106);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Auto Calculate Process";
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(38, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(480, 19);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Auto Calculate Process will be ran everyday at 01:00 AM";
            // 
            // btnAutoCalculateProcess
            // 
            this.btnAutoCalculateProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoCalculateProcess.Image")));
            this.btnAutoCalculateProcess.Location = new System.Drawing.Point(524, 41);
            this.btnAutoCalculateProcess.Name = "btnAutoCalculateProcess";
            this.btnAutoCalculateProcess.Size = new System.Drawing.Size(187, 42);
            this.btnAutoCalculateProcess.TabIndex = 2;
            this.btnAutoCalculateProcess.Text = "Force Run Auto Calculate";
            this.btnAutoCalculateProcess.Click += new System.EventHandler(this.btnAutoCalculateProcess_Click);
            // 
            // frmXMSS290_ForceRunProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 569);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.grpDailyProcessConfig);
            this.Controls.Add(this.grpMonthlyProcessConfig);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmXMSS290_ForceRunProcess";
            this.Text = "XMSS290 : Force Run Process";
            this.Load += new System.EventHandler(this.frmXMSS290_ForceRunProcess_Load);
            this.Controls.SetChildIndex(this.grpMonthlyProcessConfig, 0);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.grpDailyProcessConfig, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpDailyProcessConfig)).EndInit();
            this.grpDailyProcessConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpMonthlyProcessConfig)).EndInit();
            this.grpMonthlyProcessConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpDailyProcessConfig;
        private DevExpress.XtraEditors.GroupControl grpMonthlyProcessConfig;
        private DevExpress.XtraEditors.SimpleButton btnRunMonthly;
        private DevExpress.XtraEditors.SimpleButton btnRunDaily;
        private DevExpress.XtraEditors.LabelControl lblDailyProcess;
        private DevExpress.XtraEditors.LabelControl lblMonthly;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnAutoCalculateProcess;
    }
}
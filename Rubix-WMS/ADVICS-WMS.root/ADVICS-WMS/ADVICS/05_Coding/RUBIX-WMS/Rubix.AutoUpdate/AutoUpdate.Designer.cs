namespace Rubix.AutoUpdate
{
    partial class AutoUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoUpdate));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblFileName = new DevExpress.XtraEditors.LabelControl();
            this.prgUpdateTotal = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblTotalCurrent = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalAll = new DevExpress.XtraEditors.LabelControl();
            this.lblCurrentTotal = new DevExpress.XtraEditors.LabelControl();
            this.lblCurrent = new DevExpress.XtraEditors.LabelControl();
            this.prgUpdateCurrent = new DevExpress.XtraEditors.ProgressBarControl();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prgUpdateTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgUpdateCurrent.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Controls.Add(this.lblFileName);
            this.panel2.Location = new System.Drawing.Point(79, -25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(331, 174);
            this.panel2.TabIndex = 25;
            // 
            // lblFileName
            // 
            this.lblFileName.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFileName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblFileName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFileName.Location = new System.Drawing.Point(3, 156);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(300, 14);
            this.lblFileName.TabIndex = 33;
            // 
            // prgUpdateTotal
            // 
            this.prgUpdateTotal.Location = new System.Drawing.Point(81, 176);
            this.prgUpdateTotal.Name = "prgUpdateTotal";
            this.prgUpdateTotal.Size = new System.Drawing.Size(301, 22);
            this.prgUpdateTotal.TabIndex = 27;
            // 
            // lblTotalCurrent
            // 
            this.lblTotalCurrent.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCurrent.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTotalCurrent.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblTotalCurrent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTotalCurrent.Location = new System.Drawing.Point(0, 180);
            this.lblTotalCurrent.Name = "lblTotalCurrent";
            this.lblTotalCurrent.Size = new System.Drawing.Size(76, 14);
            this.lblTotalCurrent.TabIndex = 28;
            this.lblTotalCurrent.Text = "0.0 KB";
            // 
            // lblTotalAll
            // 
            this.lblTotalAll.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAll.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTotalAll.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTotalAll.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTotalAll.Location = new System.Drawing.Point(387, 180);
            this.lblTotalAll.Name = "lblTotalAll";
            this.lblTotalAll.Size = new System.Drawing.Size(77, 14);
            this.lblTotalAll.TabIndex = 29;
            this.lblTotalAll.Text = "100 KB";
            // 
            // lblCurrentTotal
            // 
            this.lblCurrentTotal.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTotal.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblCurrentTotal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCurrentTotal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCurrentTotal.Location = new System.Drawing.Point(387, 155);
            this.lblCurrentTotal.Name = "lblCurrentTotal";
            this.lblCurrentTotal.Size = new System.Drawing.Size(77, 14);
            this.lblCurrentTotal.TabIndex = 32;
            this.lblCurrentTotal.Text = "100 KB";
            // 
            // lblCurrent
            // 
            this.lblCurrent.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrent.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblCurrent.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblCurrent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCurrent.Location = new System.Drawing.Point(0, 155);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(76, 14);
            this.lblCurrent.TabIndex = 31;
            this.lblCurrent.Text = "0.0 KB";
            // 
            // prgUpdateCurrent
            // 
            this.prgUpdateCurrent.Location = new System.Drawing.Point(81, 151);
            this.prgUpdateCurrent.Name = "prgUpdateCurrent";
            this.prgUpdateCurrent.Size = new System.Drawing.Size(301, 22);
            this.prgUpdateCurrent.TabIndex = 30;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // AutoUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 203);
            this.ControlBox = false;
            this.Controls.Add(this.lblCurrentTotal);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.prgUpdateCurrent);
            this.Controls.Add(this.lblTotalAll);
            this.Controls.Add(this.lblTotalCurrent);
            this.Controls.Add(this.prgUpdateTotal);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutoUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rubix Update";
            this.Load += new System.EventHandler(this.AutoUpdate_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prgUpdateTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgUpdateCurrent.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.ProgressBarControl prgUpdateTotal;
        private DevExpress.XtraEditors.LabelControl lblTotalCurrent;
        private DevExpress.XtraEditors.LabelControl lblTotalAll;
        private DevExpress.XtraEditors.LabelControl lblCurrentTotal;
        private DevExpress.XtraEditors.LabelControl lblCurrent;
        private DevExpress.XtraEditors.ProgressBarControl prgUpdateCurrent;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.LabelControl lblFileName;
    }
}
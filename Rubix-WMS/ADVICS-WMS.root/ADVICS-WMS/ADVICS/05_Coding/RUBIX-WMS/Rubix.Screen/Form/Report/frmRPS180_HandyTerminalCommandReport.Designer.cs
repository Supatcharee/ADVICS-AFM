namespace Rubix.Screen.Form.Report
{
    partial class frmRPS180_HandyTerminalCommandReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRPS180_HandyTerminalCommandReport));
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.rdoPackingCommand = new DevExpress.XtraEditors.CheckEdit();
            this.rdoHandy = new DevExpress.XtraEditors.CheckEdit();
            this.btnPrintReport = new DevExpress.XtraEditors.SimpleButton();
            this.chkUserStickerLabel = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoPackingCommand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoHandy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUserStickerLabel.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Size = new System.Drawing.Size(858, 47);
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Controls.Add(this.chkUserStickerLabel);
            this.groupControl3.Controls.Add(this.rdoPackingCommand);
            this.groupControl3.Controls.Add(this.rdoHandy);
            this.groupControl3.Controls.Add(this.btnPrintReport);
            this.groupControl3.Location = new System.Drawing.Point(2, 32);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(854, 293);
            this.groupControl3.TabIndex = 129;
            this.groupControl3.Text = "Search Criteria";
            // 
            // rdoPackingCommand
            // 
            this.rdoPackingCommand.Location = new System.Drawing.Point(112, 96);
            this.rdoPackingCommand.Name = "rdoPackingCommand";
            this.rdoPackingCommand.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPackingCommand.Properties.Appearance.Options.UseFont = true;
            this.rdoPackingCommand.Properties.Caption = "Packing Command Instruction";
            this.rdoPackingCommand.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdoPackingCommand.Properties.RadioGroupIndex = 0;
            this.rdoPackingCommand.Size = new System.Drawing.Size(418, 21);
            this.rdoPackingCommand.TabIndex = 127;
            this.rdoPackingCommand.TabStop = false;
            // 
            // rdoHandy
            // 
            this.rdoHandy.EditValue = true;
            this.rdoHandy.Location = new System.Drawing.Point(112, 52);
            this.rdoHandy.Name = "rdoHandy";
            this.rdoHandy.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoHandy.Properties.Appearance.Options.UseFont = true;
            this.rdoHandy.Properties.Caption = "Handy Terminal Command";
            this.rdoHandy.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.rdoHandy.Properties.RadioGroupIndex = 0;
            this.rdoHandy.Size = new System.Drawing.Size(418, 21);
            this.rdoHandy.TabIndex = 126;
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintReport.Image")));
            this.btnPrintReport.Location = new System.Drawing.Point(326, 194);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(75, 23);
            this.btnPrintReport.TabIndex = 4;
            this.btnPrintReport.Text = "Report";
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // chkUserStickerLabel
            // 
            this.chkUserStickerLabel.Location = new System.Drawing.Point(112, 139);
            this.chkUserStickerLabel.Name = "chkUserStickerLabel";
            this.chkUserStickerLabel.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUserStickerLabel.Properties.Appearance.Options.UseFont = true;
            this.chkUserStickerLabel.Properties.Caption = "User Sticker Label";
            this.chkUserStickerLabel.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkUserStickerLabel.Properties.RadioGroupIndex = 0;
            this.chkUserStickerLabel.Size = new System.Drawing.Size(418, 21);
            this.chkUserStickerLabel.TabIndex = 128;
            this.chkUserStickerLabel.TabStop = false;
            // 
            // frmRPS180_HandyTerminalCommandReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 329);
            this.Controls.Add(this.groupControl3);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "frmRPS180_HandyTerminalCommandReport";
            this.Text = "RPS180 : Handy Terminal Command Report";
            this.Load += new System.EventHandler(this.frmRPS180_HandyTerminalCommandReport_Load_1);
            this.Controls.SetChildIndex(this.ribbonControl1, 0);
            this.Controls.SetChildIndex(this.groupControl3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdoPackingCommand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoHandy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUserStickerLabel.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.CheckEdit rdoPackingCommand;
        private DevExpress.XtraEditors.CheckEdit rdoHandy;
        private DevExpress.XtraEditors.SimpleButton btnPrintReport;
        private DevExpress.XtraEditors.CheckEdit chkUserStickerLabel;

    }
}
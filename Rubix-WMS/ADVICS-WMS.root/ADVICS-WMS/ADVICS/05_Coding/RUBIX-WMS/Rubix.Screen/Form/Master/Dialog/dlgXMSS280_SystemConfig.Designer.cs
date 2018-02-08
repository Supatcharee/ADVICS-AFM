namespace Rubix.Screen.Form.Master.Dialog
{
    partial class dlgXMSS280_SystemConfig
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
            this.pnlUnit = new DevExpress.XtraEditors.PanelControl();
            this.requireField2 = new Rubix.Control.RequireField();
            this.requireField1 = new Rubix.Control.RequireField();
            this.memoDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtConfigValue = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtConfigItem = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUnit)).BeginInit();
            this.pnlUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfigValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfigItem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUnit
            // 
            this.pnlUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUnit.Controls.Add(this.requireField2);
            this.pnlUnit.Controls.Add(this.requireField1);
            this.pnlUnit.Controls.Add(this.memoDescription);
            this.pnlUnit.Controls.Add(this.labelControl9);
            this.pnlUnit.Controls.Add(this.txtConfigValue);
            this.pnlUnit.Controls.Add(this.labelControl7);
            this.pnlUnit.Controls.Add(this.txtConfigItem);
            this.pnlUnit.Controls.Add(this.labelControl6);
            this.pnlUnit.Location = new System.Drawing.Point(2, 36);
            this.pnlUnit.Name = "pnlUnit";
            this.pnlUnit.Size = new System.Drawing.Size(793, 132);
            this.pnlUnit.TabIndex = 4;
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(148, 40);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 143;
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(148, 19);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 142;
            // 
            // memoDescription
            // 
            this.memoDescription.Location = new System.Drawing.Point(159, 56);
            this.memoDescription.Name = "memoDescription";
            this.memoDescription.Properties.MaxLength = 200;
            this.memoDescription.Size = new System.Drawing.Size(554, 55);
            this.memoDescription.TabIndex = 2;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl9.Location = new System.Drawing.Point(10, 60);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(137, 17);
            this.labelControl9.TabIndex = 140;
            this.labelControl9.Text = "Description";
            // 
            // txtConfigValue
            // 
            this.txtConfigValue.Location = new System.Drawing.Point(159, 34);
            this.txtConfigValue.Name = "txtConfigValue";
            this.txtConfigValue.Properties.MaxLength = 255;
            this.txtConfigValue.Size = new System.Drawing.Size(554, 20);
            this.txtConfigValue.TabIndex = 1;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.Location = new System.Drawing.Point(4, 38);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(144, 17);
            this.labelControl7.TabIndex = 136;
            this.labelControl7.Text = "Config Value";
            // 
            // txtConfigItem
            // 
            this.txtConfigItem.Location = new System.Drawing.Point(159, 12);
            this.txtConfigItem.Name = "txtConfigItem";
            this.txtConfigItem.Properties.MaxLength = 10;
            this.txtConfigItem.Size = new System.Drawing.Size(183, 20);
            this.txtConfigItem.TabIndex = 0;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(8, 16);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(140, 17);
            this.labelControl6.TabIndex = 134;
            this.labelControl6.Text = "Config Item";
            // 
            // dlgXMSS280_SystemConfig
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 207);
            this.Controls.Add(this.pnlUnit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgXMSS280_SystemConfig";
            this.Text = "XMSS281 : System Configuration Dialog";
            this.Load += new System.EventHandler(this.dlgXMSS220_UnitType_Load);
            this.Controls.SetChildIndex(this.pnlUnit, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlUnit)).EndInit();
            this.pnlUnit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfigValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfigItem.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlUnit;
        private DevExpress.XtraEditors.MemoEdit memoDescription;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtConfigValue;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtConfigItem;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private Control.RequireField requireField2;
        private Control.RequireField requireField1;
    }
}
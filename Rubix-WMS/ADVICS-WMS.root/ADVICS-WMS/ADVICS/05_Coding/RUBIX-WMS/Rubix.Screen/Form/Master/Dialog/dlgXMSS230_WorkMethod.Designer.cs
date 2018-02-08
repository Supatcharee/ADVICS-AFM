namespace Rubix.Screen.Form.Master.Dialog
{
    partial class dlgXMSS230_WorkMethod
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
            this.memoDesc = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtWorkMethodCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtUnitName = new DevExpress.XtraEditors.PanelControl();
            this.requireField2 = new Rubix.Control.RequireField();
            this.requireField1 = new Rubix.Control.RequireField();
            this.txtWorkMethodName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkMethodCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitName)).BeginInit();
            this.txtUnitName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkMethodName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // memoDesc
            // 
            this.memoDesc.Location = new System.Drawing.Point(193, 59);
            this.memoDesc.Name = "memoDesc";
            this.memoDesc.Properties.MaxLength = 200;
            this.memoDesc.Size = new System.Drawing.Size(554, 55);
            this.memoDesc.TabIndex = 2;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl9.Location = new System.Drawing.Point(5, 60);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(173, 13);
            this.labelControl9.TabIndex = 140;
            this.labelControl9.Text = "Description";
            // 
            // txtWorkMethodCode
            // 
            this.txtWorkMethodCode.Location = new System.Drawing.Point(193, 12);
            this.txtWorkMethodCode.Name = "txtWorkMethodCode";
            this.txtWorkMethodCode.Properties.MaxLength = 20;
            this.txtWorkMethodCode.Size = new System.Drawing.Size(183, 20);
            this.txtWorkMethodCode.TabIndex = 0;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(5, 16);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(173, 13);
            this.labelControl6.TabIndex = 134;
            this.labelControl6.Text = "Work Method Code";
            // 
            // txtUnitName
            // 
            this.txtUnitName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnitName.Controls.Add(this.requireField2);
            this.txtUnitName.Controls.Add(this.requireField1);
            this.txtUnitName.Controls.Add(this.memoDesc);
            this.txtUnitName.Controls.Add(this.labelControl9);
            this.txtUnitName.Controls.Add(this.txtWorkMethodName);
            this.txtUnitName.Controls.Add(this.labelControl7);
            this.txtUnitName.Controls.Add(this.txtWorkMethodCode);
            this.txtUnitName.Controls.Add(this.labelControl6);
            this.txtUnitName.Location = new System.Drawing.Point(2, 37);
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Size = new System.Drawing.Size(793, 125);
            this.txtUnitName.TabIndex = 5;
            // 
            // requireField2
            // 
            this.requireField2.Location = new System.Drawing.Point(180, 41);
            this.requireField2.Name = "requireField2";
            this.requireField2.Size = new System.Drawing.Size(10, 10);
            this.requireField2.TabIndex = 143;
            // 
            // requireField1
            // 
            this.requireField1.Location = new System.Drawing.Point(180, 19);
            this.requireField1.Name = "requireField1";
            this.requireField1.Size = new System.Drawing.Size(10, 10);
            this.requireField1.TabIndex = 142;
            // 
            // txtWorkMethodName
            // 
            this.txtWorkMethodName.Location = new System.Drawing.Point(193, 35);
            this.txtWorkMethodName.Name = "txtWorkMethodName";
            this.txtWorkMethodName.Properties.MaxLength = 50;
            this.txtWorkMethodName.Size = new System.Drawing.Size(554, 20);
            this.txtWorkMethodName.TabIndex = 1;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.Location = new System.Drawing.Point(5, 38);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(173, 13);
            this.labelControl7.TabIndex = 136;
            this.labelControl7.Text = "Work Method Name";
            // 
            // dlgXMSS230_WorkMethod
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 199);
            this.Controls.Add(this.txtUnitName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgXMSS230_WorkMethod";
            this.Text = "XMSS231 : Work Method Dialog";
            this.Load += new System.EventHandler(this.dlgXMSS230_WorkMethod_Load);
            this.Controls.SetChildIndex(this.txtUnitName, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkMethodCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitName)).EndInit();
            this.txtUnitName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkMethodName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit memoDesc;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtWorkMethodCode;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.PanelControl txtUnitName;
        private DevExpress.XtraEditors.TextEdit txtWorkMethodName;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private Control.RequireField requireField2;
        private Control.RequireField requireField1;
    }
}
namespace Rubix.ScreenMaster.Dialog
{
    partial class SerialSettingDialog
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
            this.txtSerial = new DevExpress.XtraEditors.TextEdit();
            this.lblSerial = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSerial
            // 
            this.txtSerial.EditValue = "";
            this.txtSerial.Location = new System.Drawing.Point(128, 58);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerial.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSerial.Properties.Appearance.Options.UseFont = true;
            this.txtSerial.Properties.Appearance.Options.UseForeColor = true;
            this.txtSerial.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtSerial.Size = new System.Drawing.Size(234, 20);
            this.txtSerial.TabIndex = 11;
            // 
            // lblSerial
            // 
            this.lblSerial.Appearance.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerial.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.lblSerial.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblSerial.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSerial.Location = new System.Drawing.Point(6, 58);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(111, 20);
            this.lblSerial.TabIndex = 10;
            this.lblSerial.Text = "Serial";
            // 
            // panelControl1
            // 
            this.panelControl1.Location = new System.Drawing.Point(0, 32);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(377, 78);
            this.panelControl1.TabIndex = 12;
            // 
            // SerialSettingDialog
            // 
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 112);
            this.ControlBox = false;
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SerialSettingDialog";
            this.ShowIcon = false;
            this.Text = "Serial Setting Dialog";
            this.Load += new System.EventHandler(this.SerialSettingDialog_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.txtSerial, 0);
            this.Controls.SetChildIndex(this.lblSerial, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtSerial;
        private DevExpress.XtraEditors.LabelControl lblSerial;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}
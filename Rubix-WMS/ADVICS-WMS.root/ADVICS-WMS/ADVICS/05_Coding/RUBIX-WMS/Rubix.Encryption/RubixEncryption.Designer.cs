namespace Rubix.Encryption
{
    partial class RubixEncryption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RubixEncryption));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSerialCipherText = new DevExpress.XtraEditors.MemoEdit();
            this.txtSerialPlainText = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPasswordSymPlainText = new DevExpress.XtraEditors.TextEdit();
            this.txtPasswordSymCipherText = new DevExpress.XtraEditors.MemoEdit();
            this.btnEncrypt = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.txtPasswordSHA1CipherText = new DevExpress.XtraEditors.MemoEdit();
            this.txtPasswordSHA1PlainText = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialCipherText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialPlainText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordSymPlainText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordSymCipherText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordSHA1CipherText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordSHA1PlainText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Serial";
            // 
            // txtSerialCipherText
            // 
            this.txtSerialCipherText.Location = new System.Drawing.Point(75, 36);
            this.txtSerialCipherText.Name = "txtSerialCipherText";
            this.txtSerialCipherText.Size = new System.Drawing.Size(540, 71);
            this.txtSerialCipherText.TabIndex = 1;
            // 
            // txtSerialPlainText
            // 
            this.txtSerialPlainText.Location = new System.Drawing.Point(75, 10);
            this.txtSerialPlainText.Name = "txtSerialPlainText";
            this.txtSerialPlainText.Size = new System.Drawing.Size(540, 20);
            this.txtSerialPlainText.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 141);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Symmetric";
            // 
            // txtPasswordSymPlainText
            // 
            this.txtPasswordSymPlainText.Location = new System.Drawing.Point(79, 138);
            this.txtPasswordSymPlainText.Name = "txtPasswordSymPlainText";
            this.txtPasswordSymPlainText.Size = new System.Drawing.Size(540, 20);
            this.txtPasswordSymPlainText.TabIndex = 4;
            // 
            // txtPasswordSymCipherText
            // 
            this.txtPasswordSymCipherText.Location = new System.Drawing.Point(78, 164);
            this.txtPasswordSymCipherText.Name = "txtPasswordSymCipherText";
            this.txtPasswordSymCipherText.Size = new System.Drawing.Size(540, 71);
            this.txtPasswordSymCipherText.TabIndex = 5;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(453, 433);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 6;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(545, 433);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtPasswordSHA1CipherText
            // 
            this.txtPasswordSHA1CipherText.Location = new System.Drawing.Point(78, 287);
            this.txtPasswordSHA1CipherText.Name = "txtPasswordSHA1CipherText";
            this.txtPasswordSHA1CipherText.Size = new System.Drawing.Size(540, 71);
            this.txtPasswordSHA1CipherText.TabIndex = 10;
            // 
            // txtPasswordSHA1PlainText
            // 
            this.txtPasswordSHA1PlainText.Location = new System.Drawing.Point(79, 261);
            this.txtPasswordSHA1PlainText.Name = "txtPasswordSHA1PlainText";
            this.txtPasswordSHA1PlainText.Size = new System.Drawing.Size(540, 20);
            this.txtPasswordSHA1PlainText.TabIndex = 9;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(34, 264);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(26, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "SHA1";
            // 
            // Rubix.Encryption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 464);
            this.Controls.Add(this.txtPasswordSHA1CipherText);
            this.Controls.Add(this.txtPasswordSHA1PlainText);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtPasswordSymCipherText);
            this.Controls.Add(this.txtPasswordSymPlainText);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtSerialPlainText);
            this.Controls.Add(this.txtSerialCipherText);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Rubix.Encryption";
            this.Text = "Rubix Encryption";
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialCipherText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerialPlainText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordSymPlainText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordSymCipherText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordSHA1CipherText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordSHA1PlainText.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtSerialCipherText;
        private DevExpress.XtraEditors.TextEdit txtSerialPlainText;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtPasswordSymPlainText;
        private DevExpress.XtraEditors.MemoEdit txtPasswordSymCipherText;
        private DevExpress.XtraEditors.SimpleButton btnEncrypt;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.MemoEdit txtPasswordSHA1CipherText;
        private DevExpress.XtraEditors.TextEdit txtPasswordSHA1PlainText;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}
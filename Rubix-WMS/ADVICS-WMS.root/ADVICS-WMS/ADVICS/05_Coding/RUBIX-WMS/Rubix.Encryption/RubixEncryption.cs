using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Rubix.Framework;

namespace Rubix.Encryption
{
    public partial class RubixEncryption : DevExpress.XtraEditors.XtraForm
    {
        public RubixEncryption()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtSerialPlainText.Text.Trim() != string.Empty)
            {
                txtSerialCipherText.Text = DataUtil.MD5Encrypt(txtSerialPlainText.Text);
            }

            if (txtPasswordSymPlainText.Text.Trim() != string.Empty)
            {
                txtPasswordSymCipherText.Text = DataUtil.SymmetricEncrypt(txtPasswordSymPlainText.Text);
            }

            if (txtPasswordSHA1PlainText.Text.Trim() != string.Empty)
            {
                txtPasswordSHA1CipherText.Text = DataUtil.Encrypt(txtPasswordSHA1PlainText.Text);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSerialPlainText.Text = string.Empty;
            txtSerialCipherText.Text = string.Empty;
            txtPasswordSymPlainText.Text = string.Empty;
            txtPasswordSymCipherText.Text = string.Empty;
            txtPasswordSHA1PlainText.Text = string.Empty;
            txtPasswordSHA1CipherText.Text = string.Empty;
        }
    }
}
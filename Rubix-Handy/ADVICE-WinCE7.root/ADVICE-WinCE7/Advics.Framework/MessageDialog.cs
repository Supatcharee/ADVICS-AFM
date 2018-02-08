using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Advics.Framework
{
    public class MessageDialog
    {
        public static void Show(string ErrorMessage, string Caption)
        {
            AppConfig.dialogResult = DialogResult.None;
            AppConfig.dialogResult = MessageBox.Show(ErrorMessage, Caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
    }
}

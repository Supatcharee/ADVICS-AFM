using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Advics.Framework
{
    public class ControlUtil
    {
        public static void HiddenControl(bool bHidden, params PictureBox[] picBox)
        {
            foreach (PictureBox p in picBox)
            {
                p.Visible = !bHidden;
            }
        }

        public static string GetDataFromClipboard()
        {
            string strReturn = string.Empty;
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                strReturn = Clipboard.GetDataObject().GetData(DataFormats.Text).ToString();
                Clipboard.SetDataObject(string.Empty);
            }
            return strReturn;
        }
    }
}

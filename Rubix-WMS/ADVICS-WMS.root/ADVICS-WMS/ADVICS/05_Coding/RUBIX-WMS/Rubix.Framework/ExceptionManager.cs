using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Rubix.Framework
{
    public class ExceptionManager
    {
        public static bool IsThrowException { get; set; }
        public static string ErrorFilename { get; set; }
        public static string ErrorFileExtension { get; set; }
        public static bool IsAddTimeStampToFilename { get; set; }
        public static void ManageException(IWin32Window owner, Exception ex)
        {
            ManageException(owner, ex, IsThrowException);
        }
        private static void ManageException(IWin32Window owner, Exception ex, bool isThrowException)
        {
            MessageDialog.ShowSystemErrorMsg(owner, ex);

            using (FileStream fs = new FileStream(string.Format("{0}.{1}", ErrorFilename, ErrorFileExtension), FileMode.Append))
            {
                
            }
            if (isThrowException)
                throw ex;
        }
    }
}

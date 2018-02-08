using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;

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

        public static DataTable ResponseException(Exception ex)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ErrorException", typeof(string));
            dt.Columns.Add("Message", typeof(string));
            dt.Columns.Add("ToString", typeof(string));            
            DataRow dr = dt.NewRow();
            if (ex.Message.ToUpper().Contains("SEE THE INNER EXCEPTION"))
            {                
                dr["Message"] = ex.InnerException.Message;
                dr["ToString"] = ex.InnerException.ToString();
            }
            else
            {
                dr["Message"] = ex.Message;
                dr["ToString"] = ex.ToString();
            }
            dr["ErrorException"] = "ErrorException";
            dt.Rows.Add(dr);
            dt.TableName = "ErrorException";            

            return dt;
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Advics.Framework;
using System.Data;
using System.IO;
using System.Reflection;

namespace Advics.Startup
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0].ToString() == "GotoStartUp")
                {
                    DataSet dsSystemConfig = new DataSet();
                    string xmlPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\xmlDatabase.xml";

                    try
                    {
                        if (File.Exists(xmlPath))
                        {
                            dsSystemConfig.ReadXml(xmlPath);
                            if (dsSystemConfig.Tables.Count > 0)
                            {
                                AppConfig.AdvicsWebApiUrl = dsSystemConfig.Tables[0].Rows[0]["WebAPIURL"].ToString();
                                AppConfig.ProgramVersion = dsSystemConfig.Tables[2].Rows[0]["Version"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    Application.Run(new frmLogin());
                }
            }

            
        }
    }
}
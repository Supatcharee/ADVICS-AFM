using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Skins;
using Rubix.Framework;
using Microsoft.Win32;
using CSI.Business;
using System.IO;
namespace Main
{
    class App
    {
        [STAThread]
        public static void Main(string[] args)
        {
            AppConfig.SplashScreenType = null;

            if (PriorProcess() != null)
            {
                MessageBox.Show("This application is already running.");
                return;
            }
            ///////////////////////////////////////////////////////////////////
            if (RunAutoUpdate())
            {
                return;
            }
            ///////////////////////////////////////////////////////////////////
            
            ExceptionManager.ErrorFilename = "Error";
            ExceptionManager.ErrorFileExtension = "log";
            ExceptionManager.IsAddTimeStampToFilename = true;
            ExceptionManager.IsThrowException = false;
            
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartUp.Dialog.frmLOG010_Login());
        }

        public static Process PriorProcess()
        {
            var curr = Process.GetCurrentProcess();
            var procs = Process.GetProcessesByName(curr.ProcessName);
            return procs.FirstOrDefault(p => (p.Id != curr.Id) && (p.MainModule.FileName == curr.MainModule.FileName));
        }

        private static bool RunAutoUpdate()
        {
            try
            {
                AutoUpdateBiz au = new AutoUpdateBiz();
                if (au.CheckProgramUpdate())
                {
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = Path.Combine(Application.StartupPath, "Rubix.AutoUpdate.exe");
                    info.Arguments = "GotoRubixUpdate";

                    Process p = new Process();
                    p.StartInfo = info;

                    p.Start();
                    return true;
                }
            }
            catch (Exception ex)
            {
                //throw;
            }
            return false;
        }
    }
}

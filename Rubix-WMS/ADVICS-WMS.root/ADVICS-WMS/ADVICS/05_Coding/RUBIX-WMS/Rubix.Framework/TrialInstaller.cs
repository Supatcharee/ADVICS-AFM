using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using Microsoft.Win32;
using System.Text;
using System.IO;


namespace Rubix.Framework
{
    [RunInstaller(true)]
    public partial class TrialInstaller : System.Configuration.Install.Installer
    {
        public TrialInstaller()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            //RegistryKey r = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft", true);
            //string end = (string)r.GetValue("CED_V");
            //if (end == null)
            //{
            //    r.SetValue("CED_V", Rubix.Framework.DataUtil.SymmetricEncrypt(DateTime.Now.Add(new TimeSpan(30, 0, 0, 0)).ToString("yyyyMMddHHmmss")));
            //}
        }

        private void TrialInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
        }
    }
}

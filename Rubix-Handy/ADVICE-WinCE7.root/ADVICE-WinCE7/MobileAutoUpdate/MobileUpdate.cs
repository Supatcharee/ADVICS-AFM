using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.IO;
using System.Collections;
using System.Reflection;
using Microsoft.Win32;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MobileAutoUpdate
{
    public partial class MobileUpdate : Form
    {
        #region Member
        DataSet dsSystemConfig = null;
        String strUpdateFileName = string.Empty;
        bool bIsThreadRunning = true;
        private string xmlPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\xmlDatabase.xml";
        #endregion

        #region Properties

        #endregion

        #region Constructor
        public MobileUpdate()
        {
            InitializeComponent();
            dsSystemConfig = new DataSet();

            try
            {
                if (File.Exists(xmlPath))
                {
                    dsSystemConfig.ReadXml(xmlPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        #endregion
        
        #region Event Handler
        private void AutoUpdate_Load(object sender, EventArgs e)
        {
            Uri LoadingURI = new Uri(string.Format("{0}Loading.html", dsSystemConfig.Tables[1].Rows[0]["WebUrl"]));
            webBrowser1.Url = LoadingURI;
            Thread myThread = new Thread(new ThreadStart(Do_work));
            myThread.Start();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!bIsThreadRunning)
            {
                timer1.Enabled = false;
                ProcessStartInfo info = new ProcessStartInfo();
                info.Arguments = "GotoStartUp";
                info.FileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Advics.Startup.exe";

                Process p = new Process();
                p.StartInfo = info;
                p.Start();

                this.Close();
            }
        } 
        #endregion

        #region Generic Function
        private void Do_work()
        {
            try
            {
                string version = dsSystemConfig.Tables[2].Rows[0]["Version"].ToString();
                DataSet ds = LoadMobileUpdateData(version);
                byte[] fileUpdate = null;

                //Update Config Version.
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dsSystemConfig.Tables[2].Rows[0]["Version"] = dr["UpdateVersion"].ToString();
                    dsSystemConfig.WriteXml(xmlPath);
                }

                //Load Update file.
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    strUpdateFileName = "File name: " + dr["FileName"].ToString();

                    this.Invoke(new Action(ChangeText), null);

                    fileUpdate = LoadFileMobileData(dr["FileName"].ToString());
                    string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\" + dr["FileName"].ToString();
                    if (File.Exists(fileName))
                    {
                        File.Delete(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\" + dr["FileName"].ToString());
                    }
                    FileStream f = new FileStream(fileName, FileMode.CreateNew);
                    f.Write(fileUpdate, 0, fileUpdate.Length);
                    f.Close();
                }

                ds.Dispose();
                ds = null;

                bIsThreadRunning = false;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private DataSet LoadMobileUpdateData(string CurrentVersion)
        {
            try
            {

                string strResult = AdvicsWebAPI.ExecuteObjectResult("AutoUpdate/LoadMobileUpdateData", JsonConvert.SerializeObject(CurrentVersion));
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadModelUpdate ERROR: " + ex.Message + " |||| " + ex.ToString());
                throw ex;
            }

        }

        private byte[] LoadFileMobileData(string fileName)
        {
            try
            {
                string strResult = AdvicsWebAPI.ExecuteObjectResult("AutoUpdate/LoadFileMobileData", JsonConvert.SerializeObject(fileName));
                return JsonConvert.DeserializeObject<byte[]>(JsonConvert.DeserializeObject<string>(strResult));
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadFile ERROR: " + ex.Message + " |||| " + ex.ToString());
                throw ex;
            }
        }

        private void ChangeText()
        {
            lblUpdateFile.Text = strUpdateFileName;
        } 
        #endregion
    }
}
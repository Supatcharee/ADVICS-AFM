using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.IO;
using System.Configuration;

namespace Rubix.AutoUpdate
{
    public partial class AutoUpdate : XtraForm
    {
        #region Member
        private static WebClient _client = null;
        private Thread thread;
        private AutoUpdateBiz au = null;
        DataSet ds = null;
        double dTotalCurrent = 0;
        double dCurrentFileSize = 0;
        bool SuppressLoop = true;

        double dAllFileSize = 0;
        double dCurrent = 0;
        double dCurrentTotal = 0;

        string strCurrentFileName = string.Empty;
        #endregion

        #region Properties
        public static WebClient RubixWebClient
        {
            get
            {
                if (_client == null)
                {
                    _client = new WebClient();

                    _client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    _client.Encoding = Encoding.UTF8;
                    _client.Encoding = UTF8Encoding.UTF8;

                    IWebProxy defaultWebProxy = WebRequest.DefaultWebProxy;
                    defaultWebProxy.Credentials = CredentialCache.DefaultCredentials;
                    _client.Proxy = defaultWebProxy;

                    _client.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);

                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateCertificate);
                }
                return _client;
            }
        }
        private AutoUpdateBiz AutoUpdateData
        {
            get
            {
                if (au == null)
                {
                    au = new AutoUpdateBiz();
                }
                return au;
            }
        }
        #endregion
        
        #region Constructor
        public AutoUpdate()
        {
            InitializeComponent();
        } 
        #endregion

        #region Event Handler
        private void AutoUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                lblTotalAll.Text = string.Empty;
                lblCurrentTotal.Text = string.Empty;

                //System.Threading.Thread.Sleep(10000);
                //MessageBox.Show("OK To Running");

                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {                
                ds = AutoUpdateData.LoadUpdateData(AppConfig.ProgramVersion);

                //Update Config file
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    AppConfig.AddNewConfig(dr["ConfigKey"].ToString(), dr["ConfigValue"].ToString());
                }
                //Update Config Version
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    AppConfig.ProgramVersion = dr["UpdateVersion"].ToString();
                }
                //set total all files size
                dAllFileSize = Convert.ToDouble(ds.Tables[2].Rows[0]["AllFileSize"]);

                foreach (DataRow dr in ds.Tables[3].Rows)
                {
                    SuppressLoop = true;
                    string URLPathDownload = string.Format("{0}{1}", AppConfig.RubixAutoUpdateURL , "AutoUpdate");

                    if (dr["Folder"].ToString() != string.Empty)
                    {
                        URLPathDownload = URLPathDownload + "/" + dr["Folder"].ToString();
                    }

                    URLPathDownload = URLPathDownload + "/" + dr["FileName"].ToString();
                    
                    dTotalCurrent = dTotalCurrent + dCurrentFileSize;
                    dCurrentFileSize = 0;
                    strCurrentFileName = dr["FileName"].ToString();
                    
                    thread = null;
                    thread = new Thread(() =>
                    {                        
                        RubixWebClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                        RubixWebClient.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                        RubixWebClient.DownloadFileAsync(new Uri(URLPathDownload), String.Format("{0}\\{1}", Application.StartupPath, dr["FileName"].ToString()));
                    });
                    thread.Start();

                    while (SuppressLoop)
                    {
                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = Path.Combine(Application.StartupPath, "Rubix-WMS.exe");

            Process p = new Process();
            p.StartInfo = info;
            p.Start();

            this.Close();
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                dCurrent = bytesIn;
                dCurrentTotal = totalBytes;
                dCurrentFileSize = bytesIn;

                double percentage = dCurrent / dCurrentTotal * 100;
                prgUpdateCurrent.EditValue = int.Parse(Math.Truncate(percentage).ToString());

                double percentageTotal = (dTotalCurrent + dCurrent) / Convert.ToDouble(ds.Tables[2].Rows[0]["AllFileSize"]) * 100;
                prgUpdateTotal.EditValue = int.Parse(Math.Truncate(percentageTotal).ToString());

                SetFileSizeDisplay(lblTotalAll, dAllFileSize);
                SetFileSizeDisplay(lblTotalCurrent, dTotalCurrent + dCurrent);
                SetFileSizeDisplay(lblCurrentTotal, dCurrentTotal);
                SetFileSizeDisplay(lblCurrent, dCurrent);
                lblFileName.Text = string.Format("File Name : {0}", strCurrentFileName);
            });
        }
                
        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            SuppressLoop = false;
        }
        #endregion

        #region Generic Function
        private void SetFileSizeDisplay(LabelControl lb,double totalBytes)
        {
            totalBytes = totalBytes / 1024;
            if (totalBytes > 1024)
            {
                totalBytes = totalBytes / 1024;
                lb.Text = string.Format("{0} MB", Math.Round(totalBytes, 2));
            }
            else
            {
                lb.Text = string.Format("{0} KB", Math.Round(totalBytes, 2));
            }
        }
        
        public static bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        #endregion

    }
}
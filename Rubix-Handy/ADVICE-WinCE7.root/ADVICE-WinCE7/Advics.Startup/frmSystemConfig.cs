using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessLayer;
using System.Reflection;
using System.IO;
using Advics.Framework;

namespace Advics.Startup
{
    public partial class frmSystemConfig : Form
    {
        #region Member
        DataSet dsSystemConfig = new DataSet();
        private string xmlPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\xmlDatabase.xml";
        #endregion

        #region Properties
        public frmLogin FormLogin { get; set; } 
        #endregion
        
        #region Constructor
        public frmSystemConfig()
        {
            InitializeComponent();
        } 
        #endregion
        
        #region Event Handler
        private void frmSystemConfig_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(xmlPath))
                {
                    dsSystemConfig.ReadXml(xmlPath);
                    if (dsSystemConfig.Tables.Count > 0)
                    {
                        txtWebAPIURL.Text = dsSystemConfig.Tables[0].Rows[0]["WebApiUrl"].ToString();
                    }
                }                
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtWebAPIURL.Text = string.Empty;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(xmlPath))
                {
                    dsSystemConfig.ReadXml(xmlPath);
                    if (dsSystemConfig.Tables.Count > 0)
                    {
                        dsSystemConfig.DataSetName = "dsDatabase";
                        dsSystemConfig.Tables[0].TableName = "dtDatabase";
                        dsSystemConfig.Tables[1].TableName = "dtAutoUpdate";
                        dsSystemConfig.Tables[2].TableName = "dtVersion";
                        dsSystemConfig.Tables[0].Rows[0]["WebApiUrl"] = txtWebAPIURL.Text.Trim();
                        dsSystemConfig.WriteXml(xmlPath);

                        AppConfig.AdvicsWebApiUrl = txtWebAPIURL.Text.Trim();
                    }
                } 
                FormLogin.Show();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageDialog.Show(ex.Message, AppConfig.Caption);
            }
        } 

        private void frmSystemConfig_Closed(object sender, EventArgs e)
        {
            this.Dispose();
            FormLogin.Dispose();            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormLogin.Show();
            this.Dispose();
        }
        #endregion
        
        #region Generic Function

        #endregion
    }
}
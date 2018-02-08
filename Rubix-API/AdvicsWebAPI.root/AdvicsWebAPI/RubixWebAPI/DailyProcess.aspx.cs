using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSI.Business.Operation;
using Rubix.Framework;
using System.Configuration;

namespace RubixWebAPI
{
    public partial class DailyProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["param"] != null && Request.QueryString["param"].ToString() == "PHOENIX-RUBIX")
                {
                    AppConfig.DatabaseServerName = ConfigurationManager.AppSettings["DataSource"].ToString();
                    AppConfig.DatabaseName = ConfigurationManager.AppSettings["DBName"].ToString();
                    AppConfig.DatabaseUserName = ConfigurationManager.AppSettings["DBUserName"].ToString();
                    AppConfig.DatabasePassword = DataUtil.SymmetricDecrypt(ConfigurationManager.AppSettings["DBPassword"].ToString());

                    ProcessConfig obj = new ProcessConfig();
                    obj.ScheduleRunDailyProcess();
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}
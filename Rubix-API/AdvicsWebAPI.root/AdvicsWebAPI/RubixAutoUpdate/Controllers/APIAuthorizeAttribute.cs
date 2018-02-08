using System;
using System.Collections.Generic;
using System.Linq;
using Rubix.Framework;
using System.Configuration;

namespace RubixAuthentication.Controllers
{
    public class APIAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            try
            {
                AppConfig.DatabaseServerName = ConfigurationManager.AppSettings["DataSource"].ToString();
                AppConfig.DatabaseName = ConfigurationManager.AppSettings["DBName"].ToString();
                AppConfig.DatabaseUserName = ConfigurationManager.AppSettings["DBUserName"].ToString();
                AppConfig.DatabasePassword = DataUtil.SymmetricDecrypt(ConfigurationManager.AppSettings["DBPassword"].ToString());                   
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Net.Http;
using CSI.Business;
using System.Data;
using Rubix.Framework;
using System.Configuration;

namespace RubixWebAPI.Controllers
{
    public class APIAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        Authentication obj = new Authentication();

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            try
            {
                //string ComputerName = ((string[])(actionContext.Request.Headers.GetValues("COMPUTER_NAME")))[0];
                //string UserLogin = ((string[])(actionContext.Request.Headers.GetValues("USER_LOGIN")))[0];
                //string Token = ((string[])(actionContext.Request.Headers.GetValues("TOKEN")))[0];

                //AppConfig.DatabaseServerName = ((string[])(actionContext.Request.Headers.GetValues("DATABASE_SERVER_NAME")))[0];
                //AppConfig.DatabaseName = ((string[])(actionContext.Request.Headers.GetValues("DATABASE_NAME")))[0];
                //AppConfig.DatabaseUserName = ((string[])(actionContext.Request.Headers.GetValues("DATABASE_USER_NAME")))[0];
                //AppConfig.DatabasePassword = DataUtil.SymmetricDecrypt(((string[])(actionContext.Request.Headers.GetValues("DATABASE_PASSWORD")))[0]);

                AppConfig.DatabaseServerName = ConfigurationManager.AppSettings["DATABASE_SERVER_NAME"];
                AppConfig.DatabaseName = ConfigurationManager.AppSettings["DATABASE_NAME"];
                AppConfig.DatabaseUserName = ConfigurationManager.AppSettings["DATABASE_USER_NAME"];
                AppConfig.DatabasePassword = DataUtil.SymmetricDecrypt(ConfigurationManager.AppSettings["DATABASE_PASSWORD"]);
                
                //P' Bom ให้เอาออกก่อน ถ้าเค้าอยากได้ค่อยขายเพิ่ม
                //if (obj.CheckExistToken(Token))
                //{
                //    //Update Token to Database
                //    obj.SaveToken(string.Empty, ComputerName, UserLogin, Token);
                //}
                //else
                //{
                //    HandleUnauthorizedRequest(actionContext);
                //}
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}

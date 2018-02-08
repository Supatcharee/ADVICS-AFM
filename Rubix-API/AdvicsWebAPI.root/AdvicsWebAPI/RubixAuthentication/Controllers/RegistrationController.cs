using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CSI.Business;
using System.Net.Http;
using System.Net;
using Rubix.Framework;
using System.Data;

namespace RubixAuthentication.Controllers
{
    public class RegistrationController : ApiController
    {
        Authentication obj = new Authentication();
        struct RegistrationStruct
        {
            public string Token;
            public string RubixWebURL;
            public string DatabaseServerName;
            public string DatabaseName;
            public string DatabaseUserName;
            public string DatabasePassword;
            public int AuthenLevel;
            public string CompanyCode;
            public string CompanyName;
        }

        [HttpPost, APIAuthorize]
        public HttpResponseMessage RegistrationToken()
        {
            RegistrationStruct reg = new RegistrationStruct();
            try
            {
                // Parameters
                string Serial = Request.Content.ReadAsStringAsync().Result;

                // Retrieve data from Header
                string ComputerName = ((string[])(Request.Headers.GetValues("COMPUTER_NAME")))[0];
                string UserLogin = ((string[])(Request.Headers.GetValues("USER_LOGIN")))[0];
                string GUID = ((string[])(Request.Headers.GetValues("GUID")))[0];
                
                if (obj.CheckNoOfConnection(Serial))
                {                    
                    reg.Token = DataUtil.MD5Encrypt(GUID);
                    //Add new Token to Database
                    DataTable dt = obj.SaveToken(Serial, ComputerName, UserLogin, reg.Token);
                    reg.DatabaseServerName = dt.Rows[0]["DBServerName"].ToString();
                    reg.DatabaseName = dt.Rows[0]["DBName"].ToString();
                    reg.DatabaseUserName = dt.Rows[0]["UserName"].ToString();
                    reg.DatabasePassword = dt.Rows[0]["Password"].ToString();
                    reg.RubixWebURL = dt.Rows[0]["ServiceURL"].ToString();
                    reg.AuthenLevel = Convert.ToInt32(dt.Rows[0]["AuthenLevel"]);
                    reg.CompanyCode = dt.Rows[0]["CompanyCode"].ToString();
                    reg.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                    /////////////////////////////////////////////////////////////////////////////
                    //Change Connection to company database to save token
                    AppConfig.DatabaseServerName = reg.DatabaseServerName;
                    AppConfig.DatabaseName = reg.DatabaseName;
                    AppConfig.DatabaseUserName = reg.DatabaseUserName;
                    AppConfig.DatabasePassword = DataUtil.SymmetricDecrypt(reg.DatabasePassword);

                    obj.SaveToken(Serial, ComputerName, UserLogin, reg.Token); 
                    /////////////////////////////////////////////////////////////////////////////
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, reg);
        }

        [HttpPost, APIAuthorize]
        public HttpResponseMessage CheckActivateSerial()
        {
            string Serial = Request.Content.ReadAsStringAsync().Result;
            bool ResultReturn = false;
            try
            {
                ResultReturn = obj.CheckActivateSerial(Serial);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }

        [HttpPost, APIAuthorize]
        public HttpResponseMessage RegisterMachine(string Serial, string MainboardSerial)
        {        
            bool ResultReturn = false;
            try
            {
                ResultReturn = obj.RegisterMachine(Serial, MainboardSerial);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, ResultReturn);
        }
    }
}

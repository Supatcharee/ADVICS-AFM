using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Advics.Framework;
using System.Collections;
using System.Data;

namespace BusinessLayer
{
    public class LoginBusiness
    {
        struct strLogin
        {
            public string Username;
            public string Password;
        }

        public DataTable VerifyUser(string UserName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("UserName", UserName);
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/UserLogin", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataTable LoadMainMenu(string UserID, string ScreenPermission)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("UserID", UserID);
                hs.Add("Permission", ScreenPermission);
                string strResult = AdvicsWebAPI.ExecuteObjectResult("HandyTerminal/LoadMainMenu", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

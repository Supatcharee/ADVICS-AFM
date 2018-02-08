using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSI.Business.DataObjects;
using System.Data;
using CSI.Business;
using System.Data.SqlClient;
using System.Data.Objects;
using Rubix.Framework;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Collections;

namespace CSI.Business.Admin
{
    public class SecurityMapping
    {

        public string[] GetScreenPermission(Type formType)
        {
            if (formType != null)
            {
                object[] att = formType.GetCustomAttributes(typeof(ScreenPermissionAttribute), true);
                List<string> lstPerm = new List<string>();
                foreach (object o in att)
                {
                    if (o is ScreenPermissionAttribute)
                    {
                        lstPerm.AddRange(((ScreenPermissionAttribute)o).PermissionItems);
                    }
                }
                return lstPerm.ToArray();
            }
            else
            {
                return new string[0];
            }
        }

        public bool IsAllowToPerformAuthen(string className, string userID, string permission)
        {
            Hashtable hs = new Hashtable();
            hs.Add("className", className);
            hs.Add("userID", userID);
            hs.Add("permission", permission);
            hs.Add("AuthenLevel", AppConfig.AuthenLevel);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("SecurityMapping/IsAllowToPerformAuthen", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadAllGroup()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("SecurityMapping/LoadAllGroup");
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadAllScreen()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("SecurityMapping/LoadAllScreen");
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadAllUser()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("SecurityMapping/LoadAllUser");
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadGroupByUserID(string userID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("userID", userID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("SecurityMapping/LoadGroupByUserID", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadUserPermissionByUserID(string userID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("userID", userID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("SecurityMapping/LoadUserPermissionByUserID", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadGroupPermissionByGroupID(int groupID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("groupID", groupID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("SecurityMapping/LoadGroupPermissionByGroupID", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadUserByGroupID(int groupID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("groupID", groupID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("SecurityMapping/LoadUserByGroupID", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadGroupPermissionByScreenID(int screenID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("screenID", screenID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("SecurityMapping/LoadGroupPermissionByScreenID", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadUserPermissionByScreenID(int screenID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("screenID", screenID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("SecurityMapping/LoadUserPermissionByScreenID", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveChanges(List<tb_SecurityMatch> SecurityList)
        {
            RubixWebAPI.ExecuteObjectResult("SecurityMapping/SecurityMappingSaveChange", JsonConvert.SerializeObject(SecurityList));
        }

        public DataTable LoadMainMenu(string UserID, string ScreenPermission)
        {
            Hashtable hs = new Hashtable();
            hs.Add("UserID", UserID);
            hs.Add("ScreenPermission", ScreenPermission);
            hs.Add("AuthenLevel", AppConfig.AuthenLevel);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("SecurityMapping/LoadMainMenu", hs);
                return JsonConvert.DeserializeObject<DataTable>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

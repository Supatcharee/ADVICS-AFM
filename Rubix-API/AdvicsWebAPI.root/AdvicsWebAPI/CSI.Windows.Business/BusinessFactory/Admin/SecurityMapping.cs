using System;
using System.Collections.Generic;
using System.Linq;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;
using System.Data;
using Rubix.Framework;

namespace CSI.Business.Admin
{
    public class SecurityMapping 
    {
        #region Member
        private BusinessCommon ims = null;
        #endregion

        #region Properties
        private BusinessCommon Database
        {
            get
            {
                if (ims == null)
                {
                    ims = new BusinessCommon();
                }
                return ims;
            }
        }
        #endregion
        
        public bool IsAllowToPerformAuthen(string className, string userID, string permission, int AuthenLevel)
        {
            try
            {
                Hashtable hs = new Hashtable();
                Hashtable hsOut = new Hashtable();
                hs.Add("ClassName", className);
                hs.Add("UserID", userID);
                hs.Add("Permission", permission);
                hs.Add("AuthenLevel", AuthenLevel);
                hsOut.Add("Result", "");
                Database.ExecuteNonQuery("sp_ADM000_IsAllowToPerform_Authen", hs, ref hsOut);

                return Convert.ToInt32(hsOut["Result"]) > 0;
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
                Hashtable hs = new Hashtable();
                hs.Add("GroupID", null);
                return Database.ExecuteDataSet("sp_ADM020_LoadGroup", hs).Tables[0];
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
                return Database.ExecuteDataSet("sp_ADM040_LoadAllScreen").Tables[0];
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
                return Database.ExecuteDataSet("sp_ADM010_UserMaintenance_SearchAll").Tables[0];
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataTable LoadGroupByUserID(string userID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("UserID", userID);
                return Database.ExecuteDataSet("sp_ADM040_LoadGroupByUserID", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadUserPermissionByUserID(string userID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("UserID", userID);
                return Database.ExecuteDataSet("sp_ADM040_LoadUserPermissionByUserID", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadGroupPermissionByGroupID(int groupID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("GroupID", groupID);
                return Database.ExecuteDataSet("sp_ADM040_LoadGroupPermissionByGroupID", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadUserByGroupID(int groupID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("GroupID", groupID);
                return Database.ExecuteDataSet("sp_ADM040_LoadUserByGroupID", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadGroupPermissionByScreenID(int screenID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ScreenID", screenID);
                return Database.ExecuteDataSet("sp_ADM040_LoadGroupPermissionByScreenID", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadUserPermissionByScreenID(int screenID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("ScreenID", screenID);
                return Database.ExecuteDataSet("sp_ADM040_LoadUserPermissionByScreenID", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SecurityMappingSaveChange(decimal? ScreenID, string Permission, string Username, decimal? GroupID, string CreateUser)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("USERID", Username);
                hs.Add("GROUPID", GroupID);
                hs.Add("SCREENID", ScreenID);
                hs.Add("PERMISSION", Permission);
                hs.Add("CREATEUSER", CreateUser);

                Database.ExecuteNonQuery("sp_ADM040_SecurityMatch_SaveChange", hs);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //For generate dynamic main menu
        public DataTable LoadMainMenu(string UserID, string ScreenPermission, int AuthenLevel)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("UserID", UserID);
                hs.Add("Permission", ScreenPermission);
                hs.Add("AuthenLevel", AuthenLevel);

                return Database.ExecuteDataSet("sp_ADM040_LoadMainMenu", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

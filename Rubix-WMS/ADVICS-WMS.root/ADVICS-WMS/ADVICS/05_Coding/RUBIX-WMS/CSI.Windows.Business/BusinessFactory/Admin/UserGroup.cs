using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using CSI.Business;
using System.Data;
using System.Collections;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Transactions;
using Rubix.Framework;
using Newtonsoft.Json;

namespace CSI.Business.Admin
{
    public class UserGroup
    {
        public List<sp_ADM020_LoadGroup_Result> LoadGroup()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("UserGroup/LoadGroup");
                return JsonConvert.DeserializeObject<List<sp_ADM020_LoadGroup_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tb_UserGroups GetUserGroup(decimal GroupID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("GroupID", GroupID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("UserGroup/GetUserGroup", hs);
                return JsonConvert.DeserializeObject<tb_UserGroups>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<sp_ADM020_LoadUserByGroup_Result> LoadUserByGroup(decimal GroupID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("GroupID", GroupID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("UserGroup/LoadUserByGroup", hs);
                return JsonConvert.DeserializeObject<List<sp_ADM020_LoadUserByGroup_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public sp_ADM020_LoadUserByGroup_Result GetUserInfo(string UserID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("UserID", UserID);
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("UserGroup/GetUserInfo", hs);
                return JsonConvert.DeserializeObject<sp_ADM020_LoadUserByGroup_Result>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsDuplicatedGroupName(decimal? GroupID, string GroupName)
        {

            Hashtable hs = new Hashtable();
            hs.Add("GroupID", GroupID);
            hs.Add("GroupName", GroupName);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("UserGroup/IsDuplicatedGroupName", hs);
                return JsonConvert.DeserializeObject<bool>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void SaveChange(decimal? GroupID, string GroupName, string Description, string CreateBy, List<sp_ADM020_LoadUserByGroup_Result> lstUser)
        {

            Hashtable hs = new Hashtable();
            hs.Add("GroupID", GroupID);
            hs.Add("GroupName", GroupName);
            hs.Add("Description", Description);
            hs.Add("CreateBy", CreateBy);

            try
            {
                RubixWebAPI.ExecuteObjectResult("UserGroup/SaveChange", hs, JsonConvert.SerializeObject(lstUser.ToList()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteGroup(int GroupID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("GroupID", GroupID);

            try
            {
                RubixWebAPI.ExecuteObjectResult("UserGroup/DeleteGroup", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

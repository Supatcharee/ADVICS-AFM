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

namespace CSI.Business.Admin
{
    public class UserGroup 
    {
        #region Member
        private AdminModelContainer _context = null;
        #endregion

        #region Properties
        private AdminModelContainer Context
        {
            get
            {
                if (_context == null)
                {
                    _context = Database.AdminContext;
                }
                return _context;
            }
        }
        #endregion

        public ObjectResult<sp_ADM020_LoadGroup_Result> LoadGroup()
        {
            return Context.sp_ADM020_LoadGroup(null);
        }

        public tb_UserGroups GetUserGroup(decimal GroupID)
        {
            return Context.tb_UserGroups.Where(c => c.GROUPID == GroupID).FirstOrDefault<tb_UserGroups>();
        }

        public ObjectResult<sp_ADM020_LoadUserByGroup_Result> LoadUserByGroup(decimal GroupID)
        {
            return Context.sp_ADM020_LoadUserByGroup(GroupID);
        }

        public sp_ADM020_LoadUserByGroup_Result GetUserInfo(string UserID)
        {
            return Context.sp_ADM020_GetUserInfo(UserID).FirstOrDefault();
        }

        public bool IsDuplicatedGroupName(decimal? GroupID, string GroupName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("GroupID", GroupID);
                hs.Add("GroupName", GroupName);

                return Convert.ToInt16(Database.ExecuteScalar("sp_ADM020_UserGroup_CheckExist", hs)) == 1;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            
        }

        public void SaveChange(decimal? GroupID, string GroupName, string Description, string CreateUser, List<sp_ADM020_LoadUserByGroup_Result> lstUser)
        {
            try
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();

                dt.Columns.Add("UserID", typeof(string));

                foreach (sp_ADM020_LoadUserByGroup_Result data in lstUser)
                {
                    DataRow dr = dt.NewRow();
                    dr["UserID"] = data.UserID;
                    dt.Rows.Add(dr);
                }
                dt.AcceptChanges();

                dt.TableName = "UserMapping";
                ds.Tables.Add(dt);

                Hashtable hs = new Hashtable();
                hs.Add("GroupID", GroupID);
                hs.Add("GroupName", GroupName);
                hs.Add("Description", Description);
                hs.Add("CreateUser", CreateUser);
                hs.Add("UserGroupXML", ds.GetXml());

                Database.ExecuteNonQuery("sp_ADM020_UserGroup_SaveChange", hs);       
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteGroup(int GroupID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("GroupID", GroupID);
                Database.ExecuteNonQuery("sp_ADM020_UserGroup_Delete", hs);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}

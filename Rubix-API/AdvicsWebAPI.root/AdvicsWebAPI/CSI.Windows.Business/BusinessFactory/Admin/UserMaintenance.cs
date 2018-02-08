using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CSI.Business.DataObjects;
using System.Data.Objects;
using System.Collections;

namespace CSI.Business.Admin
{
    public class UserMaintenance
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

        public ObjectResult<sp_ADM010_UserMaintenance_SearchAll_Result> DataLoading()
        {
            return Context.sp_ADM010_UserMaintenance_SearchAll(); ;
        }

        public bool AddUser(string userid, string password, string firstname, string lastname, string address, string email, string mobile, string tel, string createby, int? dcid, int? ownerID, int LoginType, string DomainIPAddress, string DomainName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("USERID", userid);
                hs.Add("FIRSTNAME", firstname);
                hs.Add("LASTNAME", lastname);
                hs.Add("PASSWORD", password);
                hs.Add("ADDRESS", address);
                hs.Add("TEL", tel);
                hs.Add("MOBILE", mobile);
                hs.Add("EMAIL", email);
                hs.Add("LoginType", LoginType);
                hs.Add("DomainIPAddress", DomainIPAddress);
                hs.Add("DomainName", DomainName);
                hs.Add("WarehouseID", dcid);
                hs.Add("OwnerID", ownerID);
                hs.Add("CREATEUSER", createby);
                return Database.ExecuteNonQuery("sp_ADM010_UserMaintenance_Save", hs) == 1;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool EditUser(string userID, string password, string firstname, string lastname, string address, string email, string mobile, string tel, string createby, int? dcid, int? ownerID, int LoginType, string DomainIPAddress, string DomainName)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("USERID", userID);
                hs.Add("FIRSTNAME", firstname);
                hs.Add("LASTNAME", lastname);
                hs.Add("PASSWORD", password);
                hs.Add("ADDRESS", address);
                hs.Add("TEL", tel);
                hs.Add("MOBILE", mobile);
                hs.Add("EMAIL", email);
                hs.Add("LoginType", LoginType);
                hs.Add("DomainIPAddress", DomainIPAddress);
                hs.Add("DomainName", DomainName);
                hs.Add("WarehouseID", dcid);
                hs.Add("OwnerID", ownerID);
                hs.Add("CREATEUSER", createby);
                return Database.ExecuteNonQuery("sp_ADM010_UserMaintenance_Save", hs) == 1;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool ChangePassword(string userID, string password, string createby)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("USERID", userID);
                hs.Add("PASSWORD", password);
                hs.Add("CREATEUSER", createby);
                return Database.ExecuteNonQuery("sp_ADM010_UserMaintenance_ChangePassword", hs) == 1;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool DeleteUser(string userID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("USERID", userID);
                return Database.ExecuteNonQuery("sp_ADM010_UserMaintenance_Delete", hs) == 1;
            }
            catch (Exception ex)
            {                
                throw ex;
            }

        }
        
        public tb_User GetUser(string userID)
        {
            return Context.tb_User.SingleOrDefault(c => c.UserID == userID);
        }

        public bool VerifyUser(string userID, string password)
        {
            tb_User result = GetUser(userID);
            return result.Password.Equals(password, StringComparison.Ordinal);
        }

        public bool IsExists(string userID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("USERID", userID);
                return Convert.ToInt32(Database.ExecuteScalar("sp_ADM010_UserMaintenance_IsExists", hs)) == 1;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}

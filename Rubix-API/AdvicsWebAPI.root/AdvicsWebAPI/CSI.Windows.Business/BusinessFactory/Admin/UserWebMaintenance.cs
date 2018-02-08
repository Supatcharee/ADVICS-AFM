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
    public class UserWebMaintenance
    {
        public DataTable DataLoading()
        {
            try
            {
                return Database.ExecuteDataSet("sp_ADM060_UserWebMaintenance_SearchAll").Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddUser(string UserID, string Password, string FirstName, string LastName, string Address, string Email, string Mobile, string Telephone, int OwnerID, string xmlUserWebMapping, string CreatedBy)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("UserID", UserID);
                hs.Add("FirstName", FirstName);
                hs.Add("LastName", LastName);
                hs.Add("Password", Password);
                hs.Add("Address", Address);
                hs.Add("Tel", Telephone);
                hs.Add("Mobile", Mobile);
                hs.Add("Email", Email);
                hs.Add("OwnerID", OwnerID);
                hs.Add("MappingXML", xmlUserWebMapping);
                hs.Add("CreateUser", CreatedBy);

                Database.ExecuteDataSet("sp_ADM060_AddNewUser", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditUser(string UserID, string Password, string FirstName, string LastName, string Address, string Email, string Mobile, string Telephone, int OwnerID, string xmlUserWebMapping, string UpdatedBy)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("UserID", UserID);
                hs.Add("FirstName", FirstName);
                hs.Add("LastName", LastName);
                hs.Add("Password", Password);
                hs.Add("Address", Address);
                hs.Add("Tel", Telephone);
                hs.Add("Mobile", Mobile);
                hs.Add("Email", Email);
                hs.Add("OwnerID", OwnerID);
                hs.Add("MappingXML", xmlUserWebMapping);
                hs.Add("UpdateUser", UpdatedBy);

                Database.ExecuteDataSet("sp_ADM060_UpdateUser", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void DeleteUser(string UserID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("UserID", UserID);
                Database.ExecuteDataSet("sp_ADM060_DeleteUser", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet LoadUserWebInformation(string UserID)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("UserID", UserID);
                return Database.ExecuteDataSet("sp_ADM060_LoadUserWebInformation", hs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable UserLoginForWeb(string UserID, string Password)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("USERID", UserID);
                hs.Add("PASSWORD", Rubix.Framework.DataUtil.SymmetricEncrypt(Password));
                return Database.ExecuteDataSet("sp_ADM060_UserWebLogin", hs).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CSI.Business.DataObjects;
using System.Data.Objects;
using Newtonsoft.Json;
using System.Collections;
using Rubix.Framework;

namespace CSI.Business.Admin
{
    public class UserWebMaintenance
    {
        struct UserWebInfoStruct
        {
            public string UserID;
            public string Password;
            public string FirstName;
            public string LastName;
            public string Address;
            public string Email;
            public string Mobile;
            public string Telephone;
            public int OwnerID;
            public string xmlUserWebMapping;
            public string CreatedUser;
        }

        public DataTable DataLoading()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("UserWebMaintenance/DataLoading");
                return JsonConvert.DeserializeObject<DataTable>(strResult);
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
                UserWebInfoStruct stc;
                stc.UserID = UserID;
                stc.Password = DataUtil.SymmetricEncrypt(Password);
                stc.FirstName = FirstName;
                stc.LastName = LastName;
                stc.Address = Address;
                stc.Email = Email;
                stc.Mobile = Mobile;
                stc.Telephone = Telephone;
                stc.OwnerID = OwnerID;
                stc.xmlUserWebMapping = xmlUserWebMapping;
                stc.CreatedUser = CreatedBy;

                RubixWebAPI.ExecuteObjectResult("UserWebMaintenance/AddUser", JsonConvert.SerializeObject(stc));
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
                UserWebInfoStruct stc;
                stc.UserID = UserID;
                stc.Password = DataUtil.SymmetricEncrypt(Password);
                stc.FirstName = FirstName;
                stc.LastName = LastName;
                stc.Address = Address;
                stc.Email = Email;
                stc.Mobile = Mobile;
                stc.Telephone = Telephone;
                stc.OwnerID = OwnerID;
                stc.xmlUserWebMapping = xmlUserWebMapping;
                stc.CreatedUser = UpdatedBy;

                RubixWebAPI.ExecuteObjectResult("UserWebMaintenance/EditUser", JsonConvert.SerializeObject(stc));
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

                RubixWebAPI.ExecuteObjectResult("UserWebMaintenance/DeleteUser", hs);
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

                string strResult = RubixWebAPI.ExecuteObjectResult("UserWebMaintenance/LoadUserWebInformation", hs);
                return JsonConvert.DeserializeObject<DataSet>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

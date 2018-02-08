using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CSI.Business.DataObjects;
using System.Data.Objects;
using Newtonsoft.Json;
using System.Collections;

namespace CSI.Business.Admin
{
    public class UserMaintenance
    {
        struct UserStruct
        {
            public string UserID;
            public string Password;
            public string FirstName;
            public string LastName;
            public string Address;
            public string Email;
            public string Mobile;
            public string Telephone;
            public string CreateBy;
            public int? WarehouseID;
            public int? OwnerID;
            public int LoginType;
            public string DomainIPAddress;
            public string DomainName;
        }


        public List<sp_ADM010_UserMaintenance_SearchAll_Result> DataLoading()
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("UserMaintenance/DataLoading");
                return JsonConvert.DeserializeObject<List<sp_ADM010_UserMaintenance_SearchAll_Result>>(strResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddUser(string userid, string password, string firstname, string lastname, string address, string email, string mobile, string tel, string createby, int? dcid, int? ownerID, int LoginType, string DomainIPAddress, string DomainName)
        {
            UserStruct str = new UserStruct();
            str.UserID = userid;
            str.Password = Rubix.Framework.DataUtil.Encrypt(password);
            str.FirstName = firstname;
            str.LastName = lastname;
            str.Address = address;
            str.Email = email;
            str.Mobile = mobile;
            str.Telephone = tel;
            str.CreateBy = createby;
            str.WarehouseID = dcid;
            str.OwnerID = ownerID;
            str.LoginType = LoginType;
            str.DomainIPAddress = DomainIPAddress;
            str.DomainName = DomainName;

            string strResult = RubixWebAPI.ExecuteObjectResult("UserMaintenance/AddUser", JsonConvert.SerializeObject(str));
            return JsonConvert.DeserializeObject<bool>(strResult);
        }

        public bool EditUser(string userID, string password, string firstname, string lastname, string address, string email, string mobile, string tel, string createby, int? dcid, int? ownerID, int LoginType, string DomainIPAddress, string DomainName)
        {
            UserStruct str = new UserStruct();
            str.UserID = userID;
            str.Password = password.Trim() == string.Empty ? null : Rubix.Framework.DataUtil.Encrypt(password);
            str.FirstName = firstname;
            str.LastName = lastname;
            str.Address = address;
            str.Email = email;
            str.Mobile = mobile;
            str.Telephone = tel;
            str.CreateBy = createby;
            str.WarehouseID = dcid;
            str.OwnerID = ownerID;
            str.LoginType = LoginType;
            str.DomainIPAddress = DomainIPAddress;
            str.DomainName = DomainName;

            string strResult = RubixWebAPI.ExecuteObjectResult("UserMaintenance/EditUser", JsonConvert.SerializeObject(str));
            return JsonConvert.DeserializeObject<bool>(strResult);
        }
        
        public bool ChangePassword(string userID, string password, string createby)
        {
            Hashtable hs = new Hashtable();
            hs.Add("userID", userID);
            hs.Add("password", Rubix.Framework.DataUtil.Encrypt(password));
            hs.Add("createby", createby);

            string strResult = RubixWebAPI.ExecuteObjectResult("UserMaintenance/ChangePassword", hs);
            return JsonConvert.DeserializeObject<bool>(strResult);
        }
        
        public bool DeleteUser(string userID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("UserID", userID);

            string strResult = RubixWebAPI.ExecuteObjectResult("UserMaintenance/DeleteUser", hs);
            return JsonConvert.DeserializeObject<bool>(strResult);
        }
        
        public bool VerifyUser(string userID, string password)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("UserID", userID);

                string strResult = RubixWebAPI.ExecuteObjectResult("UserMaintenance/GetUser", hs);
                tb_User result = JsonConvert.DeserializeObject<tb_User>(strResult);

                if (result == null)
                    return false;
                else
                    return result.Password.Equals(Rubix.Framework.DataUtil.Encrypt(password), StringComparison.Ordinal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public tb_User GetUser(string userID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("UserID", userID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("UserMaintenance/GetUser",hs); 
                return JsonConvert.DeserializeObject<tb_User>(strResult);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public bool IsExists(string userID)
        {
            Hashtable hs = new Hashtable();
            hs.Add("UserID", userID);

            try
            {
                string strResult = RubixWebAPI.ExecuteObjectResult("UserMaintenance/IsExists", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string GetToken(string SerialNumber)
        {
            try
            {
                return RubixWebAPI.ExecuteAuthenObjectResult("Registration/RegistrationToken", SerialNumber);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool CheckActivateSerial(string Serial)
        {
            try
            {
                string strResult = RubixWebAPI.ExecuteAuthenObjectResult("Registration/CheckActivateSerial", Serial);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool RegisterMachine(string Serial, string MainboardSerial)
        {
            try
            {
                Hashtable hs = new Hashtable();
                hs.Add("Serial", Serial);
                hs.Add("MainboardSerial", MainboardSerial);

                string strResult = RubixWebAPI.ExecuteAuthenObjectResult("Registration/RegisterMachine", hs);
                return JsonConvert.DeserializeObject<Boolean>(strResult);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

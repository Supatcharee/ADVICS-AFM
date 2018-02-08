using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CSI.Business.Admin;
using System.Data.Objects;
using CSI.Business.DataObjects;
using System.Data;
using Rubix.Framework;
using Newtonsoft.Json;

namespace RubixWebAPI.Controllers.Admin
{
    public class UserMaintenanceController : ApiController
    {
        private UserMaintenance um = new UserMaintenance();

        struct strLogin
        {
            public string Username;
            public string Password;
        }

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

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage AddUser()
        {
            bool blnResult;
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            UserStruct stc = JsonConvert.DeserializeObject<UserStruct>(strParameterData);

            try
            {
                blnResult = um.AddUser(stc.UserID, stc.Password, stc.FirstName, stc.LastName, stc.Address, stc.Email, stc.Mobile, stc.Telephone, stc.CreateBy, stc.WarehouseID, stc.OwnerID, stc.LoginType, stc.DomainIPAddress, stc.DomainName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, blnResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage ChangePassword(string userID, string password, string createby)
        {
            bool blnResult;

            try
            {
                blnResult = um.ChangePassword(userID, password, createby);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, blnResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading()
        {
            ObjectResult<sp_ADM010_UserMaintenance_SearchAll_Result> objResult;

            try
            {
                objResult = um.DataLoading();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, objResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteUser(string userID)
        {
            bool blnResult;
            try
            {
                blnResult = um.DeleteUser(userID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, blnResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage EditUser()
        {
            bool blnResult;
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            UserStruct stc = JsonConvert.DeserializeObject<UserStruct>(strParameterData);

            try
            {
                blnResult = um.EditUser(stc.UserID, stc.Password, stc.FirstName, stc.LastName, stc.Address, stc.Email, stc.Mobile, stc.Telephone, stc.CreateBy, stc.WarehouseID, stc.OwnerID, stc.LoginType, stc.DomainIPAddress, stc.DomainName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, blnResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage GetUser(string userID)
        {
            tb_User tbResult;            

            try
            {
                tbResult = um.GetUser(userID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, tbResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage IsExists(string userID)
        {
            bool boolResult;

            try
            {
                boolResult = um.IsExists(userID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, boolResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage VerifyUser()
        {            
            bool boolResult;

            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            strLogin stc = JsonConvert.DeserializeObject<strLogin>(strParameterData);

            try
            {
                boolResult = um.VerifyUser(stc.Username, stc.Password);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, boolResult);
        }
    }
}

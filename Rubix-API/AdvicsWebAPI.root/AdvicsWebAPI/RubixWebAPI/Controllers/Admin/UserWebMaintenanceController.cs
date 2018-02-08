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
    public class UserWebMaintenanceController : ApiController
    {
        private UserWebMaintenance obj = new UserWebMaintenance();
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

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DataLoading()
        {
            DataTable objResult;

            try
            {
                objResult = obj.DataLoading();
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, objResult);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage AddUser()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            UserWebInfoStruct stc = JsonConvert.DeserializeObject<UserWebInfoStruct>(strParameterData);
            
            try
            {
                obj.AddUser(stc.UserID, stc.Password, stc.FirstName, stc.LastName, stc.Address, stc.Email, stc.Mobile, stc.Telephone, stc.OwnerID, stc.xmlUserWebMapping, stc.CreatedUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage EditUser()
        {
            string strParameterData = Request.Content.ReadAsStringAsync().Result;
            UserWebInfoStruct stc = JsonConvert.DeserializeObject<UserWebInfoStruct>(strParameterData);

            try
            {
                obj.EditUser(stc.UserID, stc.Password, stc.FirstName, stc.LastName, stc.Address, stc.Email, stc.Mobile, stc.Telephone, stc.OwnerID, stc.xmlUserWebMapping, stc.CreatedUser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage DeleteUser(string UserID)
        {
            try
            {
                obj.DeleteUser(UserID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Rubix.Framework.ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        [HttpPost, HttpGet, APIAuthorize]
        public HttpResponseMessage LoadUserWebInformation(string UserID)
        {
            DataSet tbResult;            

            try
            {
                tbResult = obj.LoadUserWebInformation(UserID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ExceptionManager.ResponseException(ex));
            }

            return Request.CreateResponse(HttpStatusCode.OK, tbResult);
        }

    }
}
